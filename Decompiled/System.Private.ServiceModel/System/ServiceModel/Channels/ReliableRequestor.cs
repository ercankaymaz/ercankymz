using System.Diagnostics;
using System.Runtime;
using System.ServiceModel.Security;
using System.Threading.Tasks;
using System.Xml;

namespace System.ServiceModel.Channels;

internal abstract class ReliableRequestor
{
	private InterruptibleWaitObject abortHandle = new InterruptibleWaitObject(signaled: false, throwTimeoutByDefault: false);

	private IReliableChannelBinder binder;

	private bool isCreateSequence;

	private ActionHeader messageAction;

	private BodyWriter messageBody;

	private WsrmMessageHeader messageHeader;

	private UniqueId messageId;

	private MessageVersion messageVersion;

	private TimeSpan originalTimeout;

	private string timeoutString1Index;

	public IReliableChannelBinder Binder
	{
		protected get
		{
			return binder;
		}
		set
		{
			binder = value;
		}
	}

	public bool IsCreateSequence
	{
		protected get
		{
			return isCreateSequence;
		}
		set
		{
			isCreateSequence = value;
		}
	}

	public ActionHeader MessageAction
	{
		set
		{
			messageAction = value;
		}
	}

	public BodyWriter MessageBody
	{
		set
		{
			messageBody = value;
		}
	}

	public UniqueId MessageId => messageId;

	public WsrmMessageHeader MessageHeader
	{
		get
		{
			return messageHeader;
		}
		set
		{
			messageHeader = value;
		}
	}

	public MessageVersion MessageVersion
	{
		set
		{
			messageVersion = value;
		}
	}

	public string TimeoutString1Index
	{
		set
		{
			timeoutString1Index = value;
		}
	}

	public void Abort(CommunicationObject communicationObject)
	{
		abortHandle.Abort(communicationObject);
	}

	private Message CreateRequestMessage()
	{
		Message message = Message.CreateMessage(messageVersion, messageAction, messageBody);
		message.Properties.AllowOutputBatching = false;
		if (messageHeader != null)
		{
			message.Headers.Insert(0, messageHeader);
		}
		if (messageId != null)
		{
			message.Headers.MessageId = messageId;
			RequestReplyCorrelator.PrepareRequest(message);
			EndpointAddress localAddress = binder.LocalAddress;
			if (localAddress == null)
			{
				message.Headers.ReplyTo = null;
			}
			else if (messageVersion.Addressing == AddressingVersion.WSAddressingAugust2004)
			{
				message.Headers.ReplyTo = localAddress;
			}
			else
			{
				if (messageVersion.Addressing != AddressingVersion.WSAddressing10)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ProtocolException(System.SR.Format(System.SR.AddressingVersionNotSupported, messageVersion.Addressing)));
				}
				message.Headers.ReplyTo = (localAddress.IsAnonymous ? null : localAddress);
			}
		}
		return message;
	}

	private Task<bool> EnsureChannelAsync()
	{
		if (IsCreateSequence)
		{
			IClientReliableChannelBinder clientReliableChannelBinder = (IClientReliableChannelBinder)binder;
			return clientReliableChannelBinder.EnsureChannelForRequestAsync();
		}
		return Task.FromResult(result: true);
	}

	public virtual void Fault(CommunicationObject communicationObject)
	{
		abortHandle.Fault(communicationObject);
	}

	public abstract WsrmMessageInfo GetInfo();

	private TimeSpan GetNextRequestTimeout(TimeSpan remainingTimeout, out TimeoutHelper iterationTimeout, out bool lastIteration)
	{
		iterationTimeout = new TimeoutHelper(ReliableMessagingConstants.RequestorIterationTime);
		lastIteration = remainingTimeout <= iterationTimeout.RemainingTime();
		return remainingTimeout;
	}

	private bool HandleException(Exception exception, bool lastIteration)
	{
		if (IsCreateSequence)
		{
			if (exception is QuotaExceededException)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new CommunicationException(exception.Message, exception));
			}
			if (!binder.IsHandleable(exception) || exception is MessageSecurityException || exception is SecurityNegotiationException || exception is SecurityAccessDeniedException || binder.State != CommunicationState.Opened || lastIteration)
			{
				return false;
			}
			return true;
		}
		return binder.IsHandleable(exception);
	}

	private void ThrowTimeoutException()
	{
		if (timeoutString1Index != null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new TimeoutException(System.SR.Format(timeoutString1Index, originalTimeout)));
		}
	}

	protected abstract Task<Message> OnRequestAsync(Message request, TimeSpan timeout, bool last);

	public async Task<Message> RequestAsync(TimeSpan timeout)
	{
		originalTimeout = timeout;
		TimeoutHelper timeoutHelper = new TimeoutHelper(originalTimeout);
		while (true)
		{
			Message request = null;
			Message reply = null;
			bool requestCompleted = false;
			TimeoutHelper iterationTimeoutHelper;
			bool lastIteration;
			TimeSpan requestTimeout = GetNextRequestTimeout(timeoutHelper.RemainingTime(), out iterationTimeoutHelper, out lastIteration);
			try
			{
				if (await EnsureChannelAsync())
				{
					request = CreateRequestMessage();
					reply = await OnRequestAsync(request, requestTimeout, lastIteration);
					requestCompleted = true;
				}
			}
			catch (Exception exception)
			{
				if (Fx.IsFatal(exception) || !HandleException(exception, lastIteration))
				{
					throw;
				}
				DiagnosticUtility.TraceHandledException(exception, TraceEventType.Information);
			}
			finally
			{
				request?.Close();
			}
			if (requestCompleted && ValidateReply(reply))
			{
				return reply;
			}
			if (lastIteration)
			{
				break;
			}
			await abortHandle.WaitAsync(iterationTimeoutHelper.RemainingTime());
		}
		ThrowTimeoutException();
		return null;
	}

	public abstract void SetInfo(WsrmMessageInfo info);

	public void SetRequestResponsePattern()
	{
		if (messageId != null)
		{
			throw Fx.AssertAndThrow("Initialize messageId only once.");
		}
		messageId = new UniqueId();
	}

	private bool ValidateReply(Message response)
	{
		if (messageId != null)
		{
			return response != null;
		}
		return true;
	}
}
