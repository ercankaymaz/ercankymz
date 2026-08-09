using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public interface IObject : ILocalNode, INode
{
	byte EventNotifier { get; set; }
}
