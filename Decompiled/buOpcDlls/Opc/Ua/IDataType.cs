using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public interface IDataType : ILocalNode, INode
{
	bool IsAbstract { get; set; }
}
