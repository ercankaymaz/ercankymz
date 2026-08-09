using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public interface IObjectType : ILocalNode, INode
{
	bool IsAbstract { get; set; }
}
