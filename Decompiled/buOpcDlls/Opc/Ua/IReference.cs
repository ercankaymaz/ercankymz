using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public interface IReference
{
	NodeId ReferenceTypeId { get; }

	bool IsInverse { get; }

	ExpandedNodeId TargetId { get; }
}
