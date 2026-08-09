using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public interface INodeTable
{
	NamespaceTable NamespaceUris { get; }

	StringTable ServerUris { get; }

	ITypeTable TypeTree { get; }

	bool Exists(ExpandedNodeId nodeId);

	INode Find(ExpandedNodeId nodeId);

	INode Find(ExpandedNodeId sourceId, NodeId referenceTypeId, bool isInverse, bool includeSubtypes, QualifiedName browseName);

	IList<INode> Find(ExpandedNodeId sourceId, NodeId referenceTypeId, bool isInverse, bool includeSubtypes);
}
