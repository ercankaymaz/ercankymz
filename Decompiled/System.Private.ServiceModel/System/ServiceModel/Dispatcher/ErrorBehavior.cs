using System.Diagnostics;
using System.Runtime;
using System.ServiceModel.Channels;
using System.ServiceModel.Diagnostics;

namespace System.ServiceModel.Dispatcher;

internal class ErrorBehavior
{
	private IErrorHandler[] _handlers;

	private bool _debug;

	private bool _isOnServer;

	private MessageVersion _messageVersion;

	internal ErrorBehavior(ChannelDispatcher channelDispatcher)
	{
		_handlers = EmptyArray<IErrorHandler>.ToArray(channelDispatcher.ErrorHandlers);
		_debug = channelDispatcher.IncludeExceptionDetailInFaults;
		_isOnServer = channelDispatcher.IsOnServer;
		_messageVersion = channelDispatcher.MessageVersion;
	}

	private void InitializeFault(ref MessageRpc rpc)
	{
		Exception error = rpc.Error;
		if (error is FaultException faultException)
		{
			string action;
			MessageFault messageFault = rpc.Operation.FaultFormatter.Serialize(faultException, out action);
			if (action == null)
			{
				action = rpc.RequestVersion.Addressing.DefaultFaultAction;
			}
			if (messageFault != null)
			{
				rpc.FaultInfo.Fault = Message.CreateMessage(rpc.RequestVersion, messageFault, action);
			}
		}
	}

	internal void ProvideMessageFault(ref MessageRpc rpc)
	{
		if (rpc.Error != null)
		{
			ProvideMessageFaultCore(ref rpc);
		}
	}

	private void ProvideMessageFaultCore(ref MessageRpc rpc)
	{
		_ = _messageVersion;
		_ = rpc.RequestVersion;
		InitializeFault(ref rpc);
		ProvideFault(rpc.Error, rpc.Channel.GetProperty<FaultConverter>(), ref rpc.FaultInfo);
		ProvideMessageFaultCoreCoda(ref rpc);
	}

	private void ProvideMessageFaultCoreCoda(ref MessageRpc rpc)
	{
		if (rpc.FaultInfo.Fault.Headers.Action == null)
		{
			rpc.FaultInfo.Fault.Headers.Action = rpc.RequestVersion.Addressing.DefaultFaultAction;
		}
		rpc.Reply = rpc.FaultInfo.Fault;
	}

	internal void ProvideOnlyFaultOfLastResort(ref MessageRpc rpc)
	{
		ProvideFaultOfLastResort(rpc.Error, ref rpc.FaultInfo);
		ProvideMessageFaultCoreCoda(ref rpc);
	}

	private void ProvideFaultOfLastResort(Exception error, ref ErrorHandlerFaultInfo faultInfo)
	{
		if (faultInfo.Fault == null)
		{
			FaultCode subCode = new FaultCode("InternalServiceFault", "http://schemas.microsoft.com/net/2005/12/windowscommunicationfoundation/dispatcher");
			subCode = FaultCode.CreateReceiverFaultCode(subCode);
			string text = "http://schemas.microsoft.com/net/2005/12/windowscommunicationfoundation/dispatcher/fault";
			MessageFault fault;
			if (_debug)
			{
				faultInfo.DefaultFaultAction = text;
				fault = MessageFault.CreateFault(subCode, new FaultReason(error.Message), new ExceptionDetail(error));
			}
			else
			{
				string text2 = (_isOnServer ? System.SR.SFxInternalServerError : System.SR.SFxInternalCallbackError);
				fault = MessageFault.CreateFault(subCode, new FaultReason(text2));
			}
			faultInfo.IsConsideredUnhandled = true;
			faultInfo.Fault = Message.CreateMessage(_messageVersion, fault, text);
		}
		else if (error != null && error is FaultException { Fault: not null } ex && ex.Fault.Code != null && ex.Fault.Code.SubCode != null && string.Compare(ex.Fault.Code.SubCode.Namespace, "http://schemas.microsoft.com/net/2005/12/windowscommunicationfoundation/dispatcher", StringComparison.Ordinal) == 0 && string.Compare(ex.Fault.Code.SubCode.Name, "InternalServiceFault", StringComparison.Ordinal) == 0)
		{
			faultInfo.IsConsideredUnhandled = true;
		}
	}

	internal void ProvideFault(Exception e, FaultConverter faultConverter, ref ErrorHandlerFaultInfo faultInfo)
	{
		ProvideWellKnownFault(e, faultConverter, ref faultInfo);
		for (int i = 0; i < _handlers.Length; i++)
		{
			Message fault = faultInfo.Fault;
			_handlers[i].ProvideFault(e, _messageVersion, ref fault);
			faultInfo.Fault = fault;
			if (WcfEventSource.Instance.FaultProviderInvokedIsEnabled())
			{
				WcfEventSource.Instance.FaultProviderInvoked(_handlers[i].GetType().FullName, e.Message);
			}
		}
		ProvideFaultOfLastResort(e, ref faultInfo);
	}

	private void ProvideWellKnownFault(Exception e, FaultConverter faultConverter, ref ErrorHandlerFaultInfo faultInfo)
	{
		if (faultConverter != null && faultConverter.TryCreateFaultMessage(e, out var message))
		{
			faultInfo.Fault = message;
		}
		else if (e is NetDispatcherFaultException)
		{
			NetDispatcherFaultException ex = e as NetDispatcherFaultException;
			if (_debug)
			{
				ExceptionDetail detail = new ExceptionDetail(ex);
				faultInfo.Fault = Message.CreateMessage(_messageVersion, MessageFault.CreateFault(ex.Code, ex.Reason, detail), ex.Action);
			}
			else
			{
				faultInfo.Fault = Message.CreateMessage(_messageVersion, ex.CreateMessageFault(), ex.Action);
			}
		}
	}

	internal void HandleError(ref MessageRpc rpc)
	{
		if (rpc.Error != null)
		{
			HandleErrorCore(ref rpc);
		}
	}

	private void HandleErrorCore(ref MessageRpc rpc)
	{
		if (HandleErrorCommon(rpc.Error, ref rpc.FaultInfo))
		{
			rpc.Error = null;
		}
	}

	private bool HandleErrorCommon(Exception error, ref ErrorHandlerFaultInfo faultInfo)
	{
		bool flag = ((faultInfo.Fault != null && !faultInfo.IsConsideredUnhandled) ? true : false);
		try
		{
			if (WcfEventSource.Instance.ServiceExceptionIsEnabled())
			{
				WcfEventSource.Instance.ServiceException(error.ToString(), error.GetType().FullName);
			}
			for (int i = 0; i < _handlers.Length; i++)
			{
				bool flag2 = _handlers[i].HandleError(error);
				flag = flag2 || flag;
				if (WcfEventSource.Instance.ErrorHandlerInvokedIsEnabled())
				{
					WcfEventSource.Instance.ErrorHandlerInvoked(_handlers[i].GetType().FullName, flag2, error.GetType().FullName);
				}
			}
			return flag;
		}
		catch (Exception ex)
		{
			if (Fx.IsFatal(ex))
			{
				throw;
			}
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperCallback(ex);
		}
	}

	internal bool HandleError(Exception error)
	{
		ErrorHandlerFaultInfo faultInfo = new ErrorHandlerFaultInfo(_messageVersion.Addressing.DefaultFaultAction);
		return HandleError(error, ref faultInfo);
	}

	internal bool HandleError(Exception error, ref ErrorHandlerFaultInfo faultInfo)
	{
		return HandleErrorCommon(error, ref faultInfo);
	}

	internal static bool ShouldRethrowExceptionAsIs(Exception e)
	{
		return true;
	}

	internal static bool ShouldRethrowClientSideExceptionAsIs(Exception e)
	{
		return true;
	}

	internal static void ThrowAndCatch(Exception e, Message message)
	{
		try
		{
			if (Debugger.IsAttached)
			{
				if (message == null)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(e);
				}
				throw TraceUtility.ThrowHelperError(e, message);
			}
			if (message == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(e);
			}
			TraceUtility.ThrowHelperError(e, message);
		}
		catch (Exception ex)
		{
			if (e != ex)
			{
				throw;
			}
		}
	}

	internal static void ThrowAndCatch(Exception e)
	{
		ThrowAndCatch(e, null);
	}
}
