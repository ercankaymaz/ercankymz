using System.Runtime;
using System.Threading.Tasks;
using System.Xml;

namespace System.ServiceModel.Channels;

internal sealed class ReliableOutputConnection
{
	private static Func<object, Task> s_sendRetries = SendRetries;

	private UniqueId _id;

	private ReliableMessagingVersion _reliableMessagingVersion;

	private Guard _sendGuard = new Guard(int.MaxValue);

	private SendAsyncHandler _sendAsyncHandler;

	private OperationWithTimeoutAsyncCallback _sendAckRequestedAsyncHandler;

	private TimeSpan _sendTimeout;

	private InterruptibleWaitObject _shutdownHandle = new InterruptibleWaitObject(signaled: false);

	private bool _terminated;

	public ComponentFaultedHandler Faulted;

	public ComponentExceptionHandler OnException;

	private MessageVersion MessageVersion { get; }

	public bool Closed { get; private set; }

	public long Last => Strategy.Last;

	public SendAsyncHandler SendAsyncHandler
	{
		set
		{
			_sendAsyncHandler = value;
		}
	}

	public OperationWithTimeoutAsyncCallback SendAckRequestedAsyncHandler
	{
		set
		{
			_sendAckRequestedAsyncHandler = value;
		}
	}

	public TransmissionStrategy Strategy { get; }

	private object ThisLock { get; } = new object();

	public ReliableOutputConnection(UniqueId id, int maxTransferWindowSize, MessageVersion messageVersion, ReliableMessagingVersion reliableMessagingVersion, TimeSpan initialRtt, bool requestAcks, TimeSpan sendTimeout)
	{
		_id = id;
		MessageVersion = messageVersion;
		_reliableMessagingVersion = reliableMessagingVersion;
		_sendTimeout = sendTimeout;
		Strategy = new TransmissionStrategy(reliableMessagingVersion, initialRtt, maxTransferWindowSize, requestAcks, id);
		Strategy.RetryTimeoutElapsed = OnRetryTimeoutElapsed;
		Strategy.OnException = RaiseOnException;
	}

	public void Abort(ChannelBase channel)
	{
		_sendGuard.Abort();
		_shutdownHandle.Abort(channel);
		Strategy.Abort(channel);
	}

	private Task CompleteTransferAsync(TimeSpan timeout)
	{
		if (_reliableMessagingVersion == ReliableMessagingVersion.WSReliableMessagingFebruary2005)
		{
			Message message = Message.CreateMessage(MessageVersion, "http://schemas.xmlsoap.org/ws/2005/02/rm/LastMessage");
			message.Properties.AllowOutputBatching = false;
			return InternalAddMessageAsync(message, timeout, null, isLast: true);
		}
		if (_reliableMessagingVersion == ReliableMessagingVersion.WSReliableMessaging11)
		{
			if (Strategy.SetLast())
			{
				_shutdownHandle.Set();
				return Task.CompletedTask;
			}
			return _sendAckRequestedAsyncHandler(timeout);
		}
		throw Fx.AssertAndThrow("Unsupported version.");
	}

	public Task<bool> AddMessageAsync(Message message, TimeSpan timeout, object state)
	{
		return InternalAddMessageAsync(message, timeout, state, isLast: false);
	}

	public bool CheckForTermination()
	{
		return Strategy.DoneTransmitting;
	}

	public async Task CloseAsync(TimeSpan timeout)
	{
		bool flag = false;
		lock (ThisLock)
		{
			flag = !Closed;
			Closed = true;
		}
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		if (flag)
		{
			await CompleteTransferAsync(timeoutHelper.RemainingTime());
		}
		await _shutdownHandle.WaitAsync(timeoutHelper.RemainingTime());
		await _sendGuard.CloseAsync(timeoutHelper.RemainingTime());
		Strategy.Close();
	}

	public void Fault(ChannelBase channel)
	{
		_sendGuard.Abort();
		_shutdownHandle.Fault(channel);
		Strategy.Fault(channel);
	}

	private async Task<bool> InternalAddMessageAsync(Message message, TimeSpan timeout, object state, bool isLast)
	{
		TimeoutHelper helper = new TimeoutHelper(timeout);
		MessageAttemptInfo attemptInfo;
		try
		{
			if (isLast)
			{
				if (state != null)
				{
					throw Fx.AssertAndThrow("The isLast overload does not take a state.");
				}
				attemptInfo = await Strategy.AddLastAsync(message, helper.RemainingTime(), null);
			}
			else
			{
				(MessageAttemptInfo, bool) tuple = await Strategy.AddAsync(message, helper.RemainingTime(), state);
				(attemptInfo, _) = tuple;
				if (!tuple.Item2)
				{
					return false;
				}
			}
		}
		catch (TimeoutException)
		{
			if (isLast)
			{
				RaiseFault(null, SequenceTerminatedFault.CreateCommunicationFault(_id, System.SR.SequenceTerminatedAddLastToWindowTimedOut, null));
			}
			throw;
		}
		catch (Exception exception)
		{
			if (!Fx.IsFatal(exception))
			{
				RaiseFault(null, SequenceTerminatedFault.CreateCommunicationFault(_id, System.SR.SequenceTerminatedUnknownAddToWindowError, null));
			}
			throw;
		}
		if (_sendGuard.Enter())
		{
			try
			{
				await _sendAsyncHandler(attemptInfo, helper.RemainingTime(), maskUnhandledException: false);
			}
			catch (QuotaExceededException)
			{
				RaiseFault(null, SequenceTerminatedFault.CreateQuotaExceededFault(_id));
				throw;
			}
			finally
			{
				_sendGuard.Exit();
			}
		}
		return true;
	}

	public bool IsFinalAckConsistent(SequenceRangeCollection ranges)
	{
		return Strategy.IsFinalAckConsistent(ranges);
	}

	private async Task OnRetryTimeoutElapsed(MessageAttemptInfo attemptInfo)
	{
		if (_sendGuard.Enter())
		{
			try
			{
				await _sendAsyncHandler(attemptInfo, _sendTimeout, maskUnhandledException: true);
			}
			finally
			{
				_sendGuard.Exit();
			}
		}
	}

	private void OnTransferComplete()
	{
		Strategy.DequeuePending();
		if (Strategy.DoneTransmitting)
		{
			Terminate();
		}
	}

	public void ProcessTransferred(long transferred, SequenceRangeCollection ranges, int quotaRemaining)
	{
		if (transferred < 0)
		{
			throw Fx.AssertAndThrow("Argument transferred must be a valid sequence number or 0 for protocol messages.");
		}
		Strategy.ProcessAcknowledgement(ranges, out var invalidAck, out var _);
		if (!invalidAck && (transferred == 0L || ranges.Contains(transferred)))
		{
			if (transferred > 0 && Strategy.ProcessTransferred(transferred, quotaRemaining))
			{
				ActionItem.Schedule(s_sendRetries, this);
			}
			else
			{
				OnTransferComplete();
			}
		}
		else
		{
			WsrmFault wsrmFault = new InvalidAcknowledgementFault(_id, ranges);
			RaiseFault(wsrmFault.CreateException(), wsrmFault);
		}
	}

	public void ProcessTransferred(SequenceRangeCollection ranges, int quotaRemaining)
	{
		Strategy.ProcessAcknowledgement(ranges, out var invalidAck, out var inconsistentAck);
		if (!invalidAck && !inconsistentAck)
		{
			if (Strategy.ProcessTransferred(ranges, quotaRemaining))
			{
				ActionItem.Schedule(s_sendRetries, this);
			}
			else
			{
				OnTransferComplete();
			}
		}
		else
		{
			WsrmFault wsrmFault = new InvalidAcknowledgementFault(_id, ranges);
			RaiseFault(wsrmFault.CreateException(), wsrmFault);
		}
	}

	private void RaiseFault(Exception faultException, WsrmFault fault)
	{
		Faulted?.Invoke(faultException, fault);
	}

	private void RaiseOnException(Exception exception)
	{
		OnException?.Invoke(exception);
	}

	private async Task SendRetries()
	{
		try
		{
			while (_sendGuard.Enter())
			{
				try
				{
					MessageAttemptInfo messageInfoForRetry = Strategy.GetMessageInfoForRetry(remove: false);
					if (messageInfoForRetry.Message == null)
					{
						break;
					}
					await _sendAsyncHandler(messageInfoForRetry, _sendTimeout, maskUnhandledException: true);
				}
				finally
				{
					_sendGuard.Exit();
				}
				Strategy.DequeuePending();
				OnTransferComplete();
			}
		}
		catch (Exception exception)
		{
			if (Fx.IsFatal(exception))
			{
				throw;
			}
			RaiseOnException(exception);
		}
	}

	private static Task SendRetries(object state)
	{
		ReliableOutputConnection reliableOutputConnection = (ReliableOutputConnection)state;
		return reliableOutputConnection.SendRetries();
	}

	public void Terminate()
	{
		lock (ThisLock)
		{
			if (_terminated)
			{
				return;
			}
			_terminated = true;
		}
		_shutdownHandle.Set();
	}
}
