using System.Runtime.InteropServices;

namespace Opc.Ua.Bindings;

[ComVisible(true)]
public interface ITransportChannelFactory : ITransportBindingFactory<ITransportChannel>, ITransportBindingScheme
{
}
