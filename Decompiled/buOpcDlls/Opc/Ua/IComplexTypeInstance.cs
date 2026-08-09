using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public interface IComplexTypeInstance
{
	ExpandedNodeId TypeId { get; set; }
}
