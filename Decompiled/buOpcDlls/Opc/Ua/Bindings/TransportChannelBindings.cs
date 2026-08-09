using System;
using System.Runtime.InteropServices;

namespace Opc.Ua.Bindings;

[ComVisible(true)]
public class TransportChannelBindings : TransportBindingsBase<ITransportChannelFactory>
{
	public TransportChannelBindings(Type[] defaultBindings)
		: base(defaultBindings)
	{
	}

	public ITransportChannel GetChannel(string uriScheme)
	{
		return GetBinding(uriScheme)?.Create();
	}
}
