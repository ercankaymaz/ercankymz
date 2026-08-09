using System.Runtime.InteropServices;

namespace Opc.Ua.Bindings;

[ComVisible(true)]
public interface ITransportBindingFactory<T> : ITransportBindingScheme
{
	T Create();
}
