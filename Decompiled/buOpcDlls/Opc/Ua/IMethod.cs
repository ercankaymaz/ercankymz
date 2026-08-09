using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public interface IMethod : ILocalNode, INode
{
	bool Executable { get; set; }

	bool UserExecutable { get; set; }
}
