using System.Runtime;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace System.ServiceModel.Channels;

internal abstract class ChannelReliableSession : ISession
{
	private enum SessionFaultState
	{
		NotFaulted,
		LocallyFaulted,
		RemotelyFaulted,
		CleanedUp
	}

	public delegate void UnblockChannelCloseHandler();

	private IReliableChannelBinder _binder;

	private bool _canSendFault = true;

	private SessionFaultState _faulted;

	private SequenceRangeCollection _finalRanges;

	private InterruptibleTimer _inactivityTimer;

	private bool _isSessionClosed;

	private RequestContext _replyFaultContext;

	private Message _terminatingFault;

	private UnblockChannelCloseHandler _unblockChannelCloseCallback;

	protected ChannelBase Channel { get; }

	protected Guard Guard { get; } = new Guard(int.MaxValue);

	public string Id
	{
		get
		{
			UniqueId sequenceID = SequenceID;
			if (sequenceID == null)
			{
				return null;
			}
			return sequenceID.ToString();
		}
	}

	public TimeSpan InitiationTime { get; protected set; }

	public UniqueId InputID { get; protected set; }

	protected FaultHelper FaultHelper { get; }

	public UniqueId OutputID { get; protected set; }

	public abstract UniqueId SequenceID { get; }

	public IReliableFactorySettings Settings { get; }

	protected object ThisLock { get; } = new object();

	public UnblockChannelCloseHandler UnblockChannelCloseCallback
	{
		set
		{
			_unblockChannelCloseCallback = value;
		}
	}

	protected ChannelReliableSession(ChannelBase channel, IReliableFactorySettings settings, IReliableChannelBinder binder, FaultHelper faultHelper)
	{
		Channel = channel;
		Settings = settings;
		_binder = binder;
		FaultHelper = faultHelper;
		_inactivityTimer = new InterruptibleTimer(Settings.InactivityTimeout, (WaitCallback)OnInactivityElapsed, (object)null);
		InitiationTime = ReliableMessagingConstants.UnknownInitiationTime;
	}

	public virtual void Abort()
	{
		Guard.Abort();
		_inactivityTimer.Abort();
		bool flag;
		lock (ThisLock)
		{
			if (_faulted == SessionFaultState.CleanedUp)
			{
				return;
			}
			flag = _canSendFault && _faulted != SessionFaultState.RemotelyFaulted;
			_faulted = SessionFaultState.CleanedUp;
		}
		if (flag && _binder.State == CommunicationState.Opened && _binder.Connected)
		{
			if (_terminatingFault == null)
			{
				UniqueId uniqueId = InputID ?? OutputID;
				if (uniqueId != null)
				{
					WsrmFault wsrmFault = SequenceTerminatedFault.CreateCommunicationFault(uniqueId, System.SR.SequenceTerminatedOnAbort, null);
					_terminatingFault = wsrmFault.CreateMessage(Settings.MessageVersion, Settings.ReliableMessagingVersion);
				}
			}
			if (_terminatingFault != null)
			{
				AddFinalRanges();
				FaultHelper.SendFaultAsync(_binder, _replyFaultContext, _terminatingFault);
				return;
			}
		}
		if (_terminatingFault != null)
		{
			_terminatingFault.Close();
		}
		if (_replyFaultContext != null)
		{
			_replyFaultContext.Abort();
		}
		_binder.Abort();
	}

	private void AddFinalRanges()
	{
		if (_finalRanges != null)
		{
			WsrmUtilities.AddAcknowledgementHeader(Settings.ReliableMessagingVersion, _terminatingFault, InputID, _finalRanges, final: true);
		}
	}

	public abstract Task OpenAsync(TimeSpan timeout);

	public virtual async Task CloseAsync(TimeSpan timeout)
	{
		await Guard.CloseAsync(timeout);
		_inactivityTimer.Abort();
	}

	public void CloseSession()
	{
		_isSessionClosed = true;
	}

	protected virtual void FaultCore()
	{
		if (WcfEventSource.Instance.ReliableSessionChannelFaultedIsEnabled())
		{
			WcfEventSource.Instance.ReliableSessionChannelFaulted(Id);
		}
		_inactivityTimer.Abort();
	}

	public void OnLocalFault(Exception e, WsrmFault fault, RequestContext context)
	{
		Message faultMessage = fault?.CreateMessage(Settings.MessageVersion, Settings.ReliableMessagingVersion);
		OnLocalFault(e, faultMessage, context);
	}

	public void OnLocalFault(Exception e, Message faultMessage, RequestContext context)
	{
		if (Channel.Aborted || Channel.State == CommunicationState.Faulted || Channel.State == CommunicationState.Closed)
		{
			faultMessage?.Close();
			context?.Abort();
			return;
		}
		lock (ThisLock)
		{
			if (_faulted != SessionFaultState.NotFaulted)
			{
				return;
			}
			_faulted = SessionFaultState.LocallyFaulted;
			_terminatingFault = faultMessage;
			_replyFaultContext = context;
		}
		FaultCore();
		Channel.Fault(e);
		UnblockChannelIfNecessary();
	}

	public void OnRemoteFault(WsrmFault fault)
	{
		OnRemoteFault(WsrmFault.CreateException(fault));
	}

	public void OnRemoteFault(Exception e)
	{
		if (Channel.Aborted || Channel.State == CommunicationState.Faulted || Channel.State == CommunicationState.Closed)
		{
			return;
		}
		lock (ThisLock)
		{
			if (_faulted != SessionFaultState.NotFaulted)
			{
				return;
			}
			_faulted = SessionFaultState.RemotelyFaulted;
		}
		FaultCore();
		Channel.Fault(e);
		UnblockChannelIfNecessary();
	}

	public virtual void OnFaulted()
	{
		FaultCore();
		bool flag;
		lock (ThisLock)
		{
			if (_faulted == SessionFaultState.NotFaulted || _faulted == SessionFaultState.CleanedUp)
			{
				return;
			}
			flag = _canSendFault && _faulted != SessionFaultState.RemotelyFaulted;
			_faulted = SessionFaultState.CleanedUp;
		}
		if (flag && _binder.State == CommunicationState.Opened && _binder.Connected && _terminatingFault != null)
		{
			AddFinalRanges();
			FaultHelper.SendFaultAsync(_binder, _replyFaultContext, _terminatingFault);
			return;
		}
		if (_terminatingFault != null)
		{
			_terminatingFault.Close();
		}
		if (_replyFaultContext != null)
		{
			_replyFaultContext.Abort();
		}
		_binder.Abort();
	}

	private void OnInactivityElapsed(object state)
	{
		string text = System.SR.Format(System.SR.SequenceTerminatedInactivityTimeoutExceeded, Settings.InactivityTimeout);
		if (WcfEventSource.Instance.InactivityTimeoutIsEnabled())
		{
			WcfEventSource.Instance.InactivityTimeout(text);
		}
		WsrmFault wsrmFault;
		Exception e;
		if (SequenceID != null)
		{
			string faultReason = System.SR.Format(System.SR.SequenceTerminatedInactivityTimeoutExceeded, Settings.InactivityTimeout);
			wsrmFault = SequenceTerminatedFault.CreateCommunicationFault(SequenceID, faultReason, text);
			e = wsrmFault.CreateException();
		}
		else
		{
			wsrmFault = null;
			e = new CommunicationException(text);
		}
		OnLocalFault(e, wsrmFault, null);
	}

	public abstract void OnLocalActivity();

	public void OnUnknownException(Exception e)
	{
		_canSendFault = false;
		OnLocalFault(e, (Message)null, (RequestContext)null);
	}

	public virtual void OnRemoteActivity(bool fastPolling)
	{
		_inactivityTimer.Set();
	}

	public bool ProcessInfo(WsrmMessageInfo info, RequestContext context)
	{
		return ProcessInfo(info, context, throwException: false);
	}

	public bool ProcessInfo(WsrmMessageInfo info, RequestContext context, bool throwException)
	{
		Exception ex;
		if (info.ParsingException != null)
		{
			WsrmFault fault;
			if (SequenceID != null)
			{
				string faultReason = System.SR.Format(System.SR.CouldNotParseWithAction, info.Action);
				fault = SequenceTerminatedFault.CreateProtocolFault(SequenceID, faultReason, null);
			}
			else
			{
				fault = null;
			}
			ex = new ProtocolException(System.SR.MessageExceptionOccurred, info.ParsingException);
			OnLocalFault(throwException ? null : ex, fault, context);
		}
		else if (info.FaultReply != null)
		{
			ex = info.FaultException;
			OnLocalFault(throwException ? null : ex, info.FaultReply, context);
		}
		else if (info.WsrmHeaderFault != null && info.WsrmHeaderFault.SequenceID != InputID && info.WsrmHeaderFault.SequenceID != OutputID)
		{
			ex = new ProtocolException(System.SR.Format(System.SR.WrongIdentifierFault, FaultException.GetSafeReasonText(info.WsrmHeaderFault.Reason)));
			OnLocalFault(throwException ? null : ex, (Message)null, context);
		}
		else
		{
			if (info.FaultInfo == null)
			{
				return true;
			}
			if (_isSessionClosed && info.FaultInfo is UnknownSequenceFault { SequenceID: var sequenceID } && ((OutputID != null && OutputID == sequenceID) || (InputID != null && InputID == sequenceID)))
			{
				if (Settings.ReliableMessagingVersion == ReliableMessagingVersion.WSReliableMessagingFebruary2005)
				{
					info.Message.Close();
					return false;
				}
				if (Settings.ReliableMessagingVersion == ReliableMessagingVersion.WSReliableMessaging11)
				{
					return true;
				}
				throw Fx.AssertAndThrow("Unknown version.");
			}
			ex = info.FaultException;
			context?.Close();
			OnRemoteFault(throwException ? null : ex);
		}
		info.Message.Close();
		if (throwException)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(ex);
		}
		return false;
	}

	public void SetFinalAck(SequenceRangeCollection finalRanges)
	{
		_finalRanges = finalRanges;
	}

	public virtual void StartInactivityTimer()
	{
		_inactivityTimer.Set();
	}

	private void UnblockChannelIfNecessary()
	{
		lock (ThisLock)
		{
			if (_faulted == SessionFaultState.NotFaulted)
			{
				throw Fx.AssertAndThrow("This method must be called from a fault thread.");
			}
			if (_faulted == SessionFaultState.CleanedUp)
			{
				return;
			}
		}
		OnFaulted();
		_unblockChannelCloseCallback();
	}

	public bool VerifyDuplexProtocolElements(WsrmMessageInfo info, RequestContext context)
	{
		return VerifyDuplexProtocolElements(info, context, throwException: false);
	}

	public bool VerifyDuplexProtocolElements(WsrmMessageInfo info, RequestContext context, bool throwException)
	{
		WsrmFault wsrmFault = VerifyDuplexProtocolElements(info);
		if (wsrmFault == null)
		{
			return true;
		}
		if (throwException)
		{
			Exception exception = wsrmFault.CreateException();
			OnLocalFault(null, wsrmFault, context);
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(exception);
		}
		OnLocalFault(wsrmFault.CreateException(), wsrmFault, context);
		return false;
	}

	protected virtual WsrmFault VerifyDuplexProtocolElements(WsrmMessageInfo info)
	{
		if (info.AcknowledgementInfo != null && info.AcknowledgementInfo.SequenceID != OutputID)
		{
			return new UnknownSequenceFault(info.AcknowledgementInfo.SequenceID);
		}
		if (info.AckRequestedInfo != null && info.AckRequestedInfo.SequenceID != InputID)
		{
			return new UnknownSequenceFault(info.AckRequestedInfo.SequenceID);
		}
		if (info.SequencedMessageInfo != null && info.SequencedMessageInfo.SequenceID != InputID)
		{
			return new UnknownSequenceFault(info.SequencedMessageInfo.SequenceID);
		}
		if (info.TerminateSequenceInfo != null && info.TerminateSequenceInfo.Identifier != InputID)
		{
			if (Settings.ReliableMessagingVersion == ReliableMessagingVersion.WSReliableMessagingFebruary2005)
			{
				return SequenceTerminatedFault.CreateProtocolFault(OutputID, System.SR.SequenceTerminatedUnexpectedTerminateSequence, System.SR.UnexpectedTerminateSequence);
			}
			if (info.TerminateSequenceInfo.Identifier == OutputID)
			{
				return null;
			}
			return new UnknownSequenceFault(info.TerminateSequenceInfo.Identifier);
		}
		if (info.TerminateSequenceResponseInfo != null)
		{
			WsrmUtilities.AssertWsrm11(Settings.ReliableMessagingVersion);
			if (info.TerminateSequenceResponseInfo.Identifier == OutputID)
			{
				return null;
			}
			return new UnknownSequenceFault(info.TerminateSequenceResponseInfo.Identifier);
		}
		if (info.CloseSequenceInfo != null)
		{
			WsrmUtilities.AssertWsrm11(Settings.ReliableMessagingVersion);
			if (info.CloseSequenceInfo.Identifier == InputID)
			{
				return null;
			}
			if (info.CloseSequenceInfo.Identifier == OutputID)
			{
				return SequenceTerminatedFault.CreateProtocolFault(OutputID, System.SR.SequenceTerminatedUnsupportedClose, System.SR.UnsupportedCloseExceptionString);
			}
			return new UnknownSequenceFault(info.CloseSequenceInfo.Identifier);
		}
		if (info.CloseSequenceResponseInfo != null)
		{
			WsrmUtilities.AssertWsrm11(Settings.ReliableMessagingVersion);
			if (info.CloseSequenceResponseInfo.Identifier == OutputID)
			{
				return null;
			}
			if (info.CloseSequenceResponseInfo.Identifier == InputID)
			{
				return SequenceTerminatedFault.CreateProtocolFault(InputID, System.SR.SequenceTerminatedUnexpectedCloseSequenceResponse, System.SR.UnexpectedCloseSequenceResponse);
			}
			return new UnknownSequenceFault(info.CloseSequenceResponseInfo.Identifier);
		}
		return null;
	}

	public bool VerifySimplexProtocolElements(WsrmMessageInfo info, RequestContext context)
	{
		return VerifySimplexProtocolElements(info, context, throwException: false);
	}

	public bool VerifySimplexProtocolElements(WsrmMessageInfo info, RequestContext context, bool throwException)
	{
		WsrmFault wsrmFault = VerifySimplexProtocolElements(info);
		if (wsrmFault == null)
		{
			return true;
		}
		info.Message.Close();
		if (throwException)
		{
			Exception exception = wsrmFault.CreateException();
			OnLocalFault(null, wsrmFault, context);
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(exception);
		}
		OnLocalFault(wsrmFault.CreateException(), wsrmFault, context);
		return false;
	}

	protected abstract WsrmFault VerifySimplexProtocolElements(WsrmMessageInfo info);
}
