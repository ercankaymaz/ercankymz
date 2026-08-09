using System;
using System.Runtime.InteropServices;

namespace Opc.Ua.Bindings;

[ComVisible(true)]
public class TransportListenerBindings : TransportBindingsBase<ITransportListenerFactory>
{
	public TransportListenerBindings(Type[] defaultBindings)
		: base(defaultBindings)
	{
	}

	public ITransportListener GetListener(string uriScheme)
	{
		return GetBinding(uriScheme)?.Create();
	}
}
