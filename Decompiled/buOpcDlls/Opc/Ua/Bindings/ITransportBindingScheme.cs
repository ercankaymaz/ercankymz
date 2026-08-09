using System.Runtime.InteropServices;

namespace Opc.Ua.Bindings;

[ComVisible(true)]
public interface ITransportBindingScheme
{
	string UriScheme { get; }
}
