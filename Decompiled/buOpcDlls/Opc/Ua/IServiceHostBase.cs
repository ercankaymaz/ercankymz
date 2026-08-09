using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public interface IServiceHostBase
{
	IServerBase Server { get; }
}
