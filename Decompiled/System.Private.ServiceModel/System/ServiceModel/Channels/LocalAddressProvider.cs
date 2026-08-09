using System.ServiceModel.Dispatcher;

namespace System.ServiceModel.Channels;

internal class LocalAddressProvider
{
	private int _priority;

	public EndpointAddress LocalAddress { get; }

	public MessageFilter Filter { get; }

	public int Priority => _priority;

	public LocalAddressProvider(EndpointAddress localAddress, MessageFilter filter)
	{
		LocalAddress = localAddress ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("localAddress");
		Filter = filter ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("filter");
		if (localAddress.Headers.FindHeader(XD.UtilityDictionary.UniqueEndpointHeaderName.Value, XD.UtilityDictionary.UniqueEndpointHeaderNamespace.Value) == null)
		{
			_priority = 2147483646;
		}
		else
		{
			_priority = int.MaxValue;
		}
	}
}
