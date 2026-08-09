using System.Runtime;
using System.ServiceModel.Security;
using System.Threading.Tasks;
using System.Xml;

namespace System.ServiceModel.Channels;

internal class ClientReliableSession : ChannelReliableSession, IOutputSession, ISession
{
	public delegate Task PollingHandler();

	private enum PollingMode
	{
		Idle,
		KeepAlive,
		FastPolling,
		NotPolling
	}

	private IClientReliableChannelBinder _binder;

	private PollingMode _oldPollingMode;

	private PollingHandler _pollingHandler;

	private PollingMode _pollingMode;

	private InterruptibleTimer _pollingTimer;

	private ReliableRequestor _requestor;

	public PollingHandler PollingCallback
	{
		set
		{
			_pollingHandler = value;
		}
	}

	public override UniqueId SequenceID => base.OutputID;

	public ClientReliableSession(ChannelBase channel, IReliableFactorySettings factory, IClientReliableChannelBinder binder, FaultHelper faultHelper, UniqueId inputID)
		: base(channel, factory, binder, faultHelper)
	{
		_binder = binder;
		base.InputID = inputID;
		_pollingTimer = new InterruptibleTimer(GetPollingInterval(), (InterruptibleTimer.AsyncWaitCallback)OnPollingTimerElapsed, (object)null);
		if (_binder.Channel is IRequestChannel)
		{
			_requestor = new RequestReliableRequestor();
		}
		else if (_binder.Channel is IDuplexChannel)
		{
			_requestor = new SendReceiveReliableRequestor
			{
				TimeoutIsSafe = !ChannelSupportsOneCreateSequenceAttempt()
			};
		}
		MessageVersion messageVersion = base.Settings.MessageVersion;
		ReliableMessagingVersion reliableMessagingVersion = base.Settings.ReliableMessagingVersion;
		_requestor.MessageVersion = messageVersion;
		_requestor.Binder = _binder;
		_requestor.IsCreateSequence = true;
		_requestor.TimeoutString1Index = System.SR.TimeoutOnOpen;
		_requestor.MessageAction = WsrmIndex.GetCreateSequenceActionHeader(messageVersion.Addressing, reliableMessagingVersion);
		if (reliableMessagingVersion == ReliableMessagingVersion.WSReliableMessaging11 && _binder.GetInnerSession() is ISecureConversationSession)
		{
			_requestor.MessageHeader = new WsrmUsesSequenceSTRHeader();
		}
		_requestor.MessageBody = new CreateSequence(base.Settings.MessageVersion.Addressing, reliableMessagingVersion, base.Settings.Ordered, _binder, base.InputID);
		_requestor.SetRequestResponsePattern();
	}

	public override void Abort()
	{
		_requestor?.Abort(base.Channel);
		_pollingTimer.Abort();
		base.Abort();
	}

	public override async Task OpenAsync(TimeSpan timeout)
	{
		if (_pollingHandler == null)
		{
			throw Fx.AssertAndThrow("The client reliable channel must set the polling handler prior to opening the client reliable session.");
		}
		ProcessCreateSequenceResponse(start: DateTime.UtcNow, response: await _requestor.RequestAsync(timeout));
		_requestor = null;
	}

	private bool ChannelSupportsOneCreateSequenceAttempt()
	{
		if (!(_binder.Channel is IDuplexSessionChannel duplexSessionChannel))
		{
			return false;
		}
		if (duplexSessionChannel.Session is ISecuritySession)
		{
			return !(duplexSessionChannel.Session is ISecureConversationSession);
		}
		return false;
	}

	public override async Task CloseAsync(TimeSpan timeout)
	{
		await base.CloseAsync(timeout);
		_pollingTimer.Abort();
	}

	protected override void FaultCore()
	{
		_pollingTimer.Abort();
		base.FaultCore();
	}

	private TimeSpan GetPollingInterval()
	{
		switch (_pollingMode)
		{
		case PollingMode.Idle:
			return Ticks.ToTimeSpan(Ticks.FromTimeSpan(base.Settings.InactivityTimeout) / 2);
		case PollingMode.KeepAlive:
			return WsrmUtilities.CalculateKeepAliveInterval(base.Settings.InactivityTimeout, base.Settings.MaxRetryCount);
		case PollingMode.NotPolling:
			return TimeSpan.MaxValue;
		case PollingMode.FastPolling:
		{
			TimeSpan timeSpan = WsrmUtilities.CalculateKeepAliveInterval(base.Settings.InactivityTimeout, base.Settings.MaxRetryCount);
			TimeSpan timeSpan2 = Ticks.ToTimeSpan(Ticks.FromTimeSpan(_binder.DefaultSendTimeout) / 2);
			if (timeSpan2 < timeSpan)
			{
				return timeSpan2;
			}
			return timeSpan;
		}
		default:
			throw Fx.AssertAndThrow("Unknown polling mode.");
		}
	}

	public override void OnFaulted()
	{
		base.OnFaulted();
		ReliableRequestor requestor = _requestor;
		if (requestor != null)
		{
			_requestor.Fault(base.Channel);
		}
	}

	private async Task OnPollingTimerElapsed(object state)
	{
		if (!base.Guard.Enter())
		{
			return;
		}
		try
		{
			lock (base.ThisLock)
			{
				if (_pollingMode == PollingMode.NotPolling)
				{
					return;
				}
				if (_pollingMode == PollingMode.Idle)
				{
					_pollingMode = PollingMode.KeepAlive;
				}
			}
			await _pollingHandler();
			_pollingTimer.Set(GetPollingInterval());
		}
		finally
		{
			base.Guard.Exit();
		}
	}

	public override void OnLocalActivity()
	{
		lock (base.ThisLock)
		{
			if (_pollingMode != PollingMode.NotPolling)
			{
				_pollingTimer.Set(GetPollingInterval());
			}
		}
	}

	public override void OnRemoteActivity(bool fastPolling)
	{
		base.OnRemoteActivity(fastPolling);
		lock (base.ThisLock)
		{
			if (_pollingMode != PollingMode.NotPolling)
			{
				if (fastPolling)
				{
					_pollingMode = PollingMode.FastPolling;
				}
				else
				{
					_pollingMode = PollingMode.Idle;
				}
				_pollingTimer.Set(GetPollingInterval());
			}
		}
	}

	private void ProcessCreateSequenceResponse(Message response, DateTime start)
	{
		CreateSequenceResponseInfo createSequenceResponseInfo = null;
		using (response)
		{
			if (response.IsFault)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(WsrmUtilities.CreateCSFaultException(base.Settings.MessageVersion, base.Settings.ReliableMessagingVersion, response, _binder.Channel));
			}
			WsrmMessageInfo wsrmMessageInfo = WsrmMessageInfo.Get(base.Settings.MessageVersion, base.Settings.ReliableMessagingVersion, _binder.Channel, _binder.GetInnerSession(), response, csrOnly: true);
			if (wsrmMessageInfo.ParsingException != null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ProtocolException(System.SR.UnparsableCSResponse, wsrmMessageInfo.ParsingException));
			}
			ProcessInfo(wsrmMessageInfo, null, throwException: true);
			createSequenceResponseInfo = wsrmMessageInfo.CreateSequenceResponseInfo;
			string text = null;
			string text2 = null;
			if (createSequenceResponseInfo == null)
			{
				text = System.SR.Format(System.SR.InvalidWsrmResponseChannelNotOpened, "CreateSequence", wsrmMessageInfo.Action, WsrmIndex.GetCreateSequenceResponseActionString(base.Settings.ReliableMessagingVersion));
			}
			else if (!object.Equals(createSequenceResponseInfo.RelatesTo, _requestor.MessageId))
			{
				text = System.SR.Format(System.SR.WsrmMessageWithWrongRelatesToExceptionString, "CreateSequence");
				text2 = System.SR.Format(System.SR.WsrmMessageWithWrongRelatesToFaultString, "CreateSequence");
			}
			else if (createSequenceResponseInfo.AcceptAcksTo == null && base.InputID != null)
			{
				if (base.Settings.ReliableMessagingVersion == ReliableMessagingVersion.WSReliableMessagingFebruary2005)
				{
					text = System.SR.CSResponseWithoutOffer;
					text2 = System.SR.CSResponseWithoutOfferReason;
				}
				else
				{
					if (base.Settings.ReliableMessagingVersion != ReliableMessagingVersion.WSReliableMessaging11)
					{
						throw Fx.AssertAndThrow("Reliable messaging version not supported.");
					}
					text = System.SR.CSResponseOfferRejected;
					text2 = System.SR.CSResponseOfferRejectedReason;
				}
			}
			else if (createSequenceResponseInfo.AcceptAcksTo != null && base.InputID == null)
			{
				text = System.SR.CSResponseWithOffer;
				text2 = System.SR.CSResponseWithOfferReason;
			}
			else if (createSequenceResponseInfo.AcceptAcksTo != null && createSequenceResponseInfo.AcceptAcksTo.Uri != _binder.RemoteAddress.Uri)
			{
				text = System.SR.AcksToMustBeSameAsRemoteAddress;
				text2 = System.SR.AcksToMustBeSameAsRemoteAddressReason;
			}
			if (text2 != null && createSequenceResponseInfo != null)
			{
				UniqueId identifier = createSequenceResponseInfo.Identifier;
				WsrmFault fault = SequenceTerminatedFault.CreateProtocolFault(identifier, text2, null);
				OnLocalFault(null, fault, null);
			}
			if (text != null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ProtocolException(text));
			}
		}
		base.InitiationTime = DateTime.UtcNow - start;
		base.OutputID = createSequenceResponseInfo.Identifier;
		_pollingTimer.Set(GetPollingInterval());
		base.StartInactivityTimer();
	}

	public void ResumePolling(bool fastPolling)
	{
		lock (base.ThisLock)
		{
			if (_pollingMode != PollingMode.NotPolling)
			{
				throw Fx.AssertAndThrow("Can't resume polling if pollingMode != PollingMode.NotPolling");
			}
			if (fastPolling)
			{
				_pollingMode = PollingMode.FastPolling;
			}
			else if (_oldPollingMode == PollingMode.FastPolling)
			{
				_pollingMode = PollingMode.Idle;
			}
			else
			{
				_pollingMode = _oldPollingMode;
			}
			base.Guard.Exit();
			_pollingTimer.Set(GetPollingInterval());
		}
	}

	public bool StopPolling()
	{
		lock (base.ThisLock)
		{
			if (_pollingMode == PollingMode.NotPolling)
			{
				return false;
			}
			_oldPollingMode = _pollingMode;
			_pollingMode = PollingMode.NotPolling;
			_pollingTimer.Cancel();
			return base.Guard.Enter();
		}
	}

	protected override WsrmFault VerifyDuplexProtocolElements(WsrmMessageInfo info)
	{
		WsrmFault wsrmFault = base.VerifyDuplexProtocolElements(info);
		if (wsrmFault != null)
		{
			return wsrmFault;
		}
		if (info.CreateSequenceInfo != null)
		{
			return SequenceTerminatedFault.CreateProtocolFault(base.OutputID, System.SR.SequenceTerminatedUnexpectedCS, System.SR.UnexpectedCS);
		}
		if (info.CreateSequenceResponseInfo != null && info.CreateSequenceResponseInfo.Identifier != base.OutputID)
		{
			return SequenceTerminatedFault.CreateProtocolFault(base.OutputID, System.SR.SequenceTerminatedUnexpectedCSROfferId, System.SR.UnexpectedCSROfferId);
		}
		return null;
	}

	protected override WsrmFault VerifySimplexProtocolElements(WsrmMessageInfo info)
	{
		if (info.AcknowledgementInfo != null && info.AcknowledgementInfo.SequenceID != base.OutputID)
		{
			return new UnknownSequenceFault(info.AcknowledgementInfo.SequenceID);
		}
		if (info.AckRequestedInfo != null)
		{
			return SequenceTerminatedFault.CreateProtocolFault(base.OutputID, System.SR.SequenceTerminatedUnexpectedAckRequested, System.SR.UnexpectedAckRequested);
		}
		if (info.CreateSequenceInfo != null)
		{
			return SequenceTerminatedFault.CreateProtocolFault(base.OutputID, System.SR.SequenceTerminatedUnexpectedCS, System.SR.UnexpectedCS);
		}
		if (info.SequencedMessageInfo != null)
		{
			return new UnknownSequenceFault(info.SequencedMessageInfo.SequenceID);
		}
		if (info.TerminateSequenceInfo != null)
		{
			if (base.Settings.ReliableMessagingVersion == ReliableMessagingVersion.WSReliableMessagingFebruary2005)
			{
				return SequenceTerminatedFault.CreateProtocolFault(base.OutputID, System.SR.SequenceTerminatedUnexpectedTerminateSequence, System.SR.UnexpectedTerminateSequence);
			}
			if (info.TerminateSequenceInfo.Identifier == base.OutputID)
			{
				return null;
			}
			return new UnknownSequenceFault(info.TerminateSequenceInfo.Identifier);
		}
		if (info.TerminateSequenceResponseInfo != null)
		{
			WsrmUtilities.AssertWsrm11(base.Settings.ReliableMessagingVersion);
			if (info.TerminateSequenceResponseInfo.Identifier == base.OutputID)
			{
				return null;
			}
			return new UnknownSequenceFault(info.TerminateSequenceResponseInfo.Identifier);
		}
		if (info.CloseSequenceInfo != null)
		{
			WsrmUtilities.AssertWsrm11(base.Settings.ReliableMessagingVersion);
			if (info.CloseSequenceInfo.Identifier == base.OutputID)
			{
				return SequenceTerminatedFault.CreateProtocolFault(base.OutputID, System.SR.SequenceTerminatedUnsupportedClose, System.SR.UnsupportedCloseExceptionString);
			}
			return new UnknownSequenceFault(info.CloseSequenceInfo.Identifier);
		}
		if (info.CloseSequenceResponseInfo != null)
		{
			WsrmUtilities.AssertWsrm11(base.Settings.ReliableMessagingVersion);
			if (info.CloseSequenceResponseInfo.Identifier == base.OutputID)
			{
				return null;
			}
			return new UnknownSequenceFault(info.CloseSequenceResponseInfo.Identifier);
		}
		return null;
	}
}
