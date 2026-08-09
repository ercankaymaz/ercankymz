using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public interface INode
{
	ExpandedNodeId NodeId { get; }

	NodeClass NodeClass { get; }

	QualifiedName BrowseName { get; }

	LocalizedText DisplayName { get; }

	ExpandedNodeId TypeDefinitionId { get; }
}
