using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate void NodeStateReferenceRemoved(NodeState node, NodeId referenceTypeId, bool isInverse, ExpandedNodeId targetId);
