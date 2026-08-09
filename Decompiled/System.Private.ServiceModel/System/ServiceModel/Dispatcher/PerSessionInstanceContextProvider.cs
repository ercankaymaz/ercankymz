using System.ServiceModel.Channels;

namespace System.ServiceModel.Dispatcher;

internal class PerSessionInstanceContextProvider : InstanceContextProviderBase
{
	internal PerSessionInstanceContextProvider(DispatchRuntime dispatchRuntime)
		: base(dispatchRuntime)
	{
	}

	public override InstanceContext GetExistingInstanceContext(Message message, IContextChannel channel)
	{
		return GetServiceChannelFromProxy(channel)?.InstanceContext;
	}
}
