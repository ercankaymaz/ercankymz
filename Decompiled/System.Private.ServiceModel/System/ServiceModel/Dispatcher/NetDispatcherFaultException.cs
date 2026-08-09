namespace System.ServiceModel.Dispatcher;

internal class NetDispatcherFaultException : FaultException
{
	public NetDispatcherFaultException(string reason, FaultCode code, Exception innerException)
		: base(reason, code, "http://schemas.microsoft.com/net/2005/12/windowscommunicationfoundation/dispatcher/fault", innerException)
	{
	}

	public NetDispatcherFaultException(FaultReason reason, FaultCode code, Exception innerException)
		: base(reason, code, "http://schemas.microsoft.com/net/2005/12/windowscommunicationfoundation/dispatcher/fault", innerException)
	{
	}
}
