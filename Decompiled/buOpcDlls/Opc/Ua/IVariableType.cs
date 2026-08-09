using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public interface IVariableType : IVariableBase, ILocalNode, INode
{
	bool IsAbstract { get; set; }
}
