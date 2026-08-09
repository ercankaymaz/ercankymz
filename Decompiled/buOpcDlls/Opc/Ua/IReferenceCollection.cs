using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public interface IReferenceCollection : ICollection<IReference>, IEnumerable<IReference>, IEnumerable
{
	void Add(NodeId referenceTypeId, bool isInverse, ExpandedNodeId targetId);

	bool Remove(NodeId referenceTypeId, bool isInverse, ExpandedNodeId targetId);

	bool RemoveAll(NodeId referenceTypeId, bool isInverse);

	bool Exists(NodeId referenceTypeId, bool isInverse, ExpandedNodeId targetId, bool includeSubtypes, ITypeTable typeTree);

	IList<IReference> Find(NodeId referenceTypeId, bool isInverse, bool includeSubtypes, ITypeTable typeTree);

	ExpandedNodeId FindTarget(NodeId referenceTypeId, bool isInverse, bool includeSubtypes, ITypeTable typeTree, int index);

	IList<IReference> FindReferencesToTarget(ExpandedNodeId targetId);
}
