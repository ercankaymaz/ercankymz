using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public class NodeStateReference : IReference
{
	private NodeId m_referenceTypeId;

	private bool m_isInverse;

	private ExpandedNodeId m_targetId;

	private NodeState m_target;

	public NodeState Target => m_target;

	public NodeId ReferenceTypeId => m_referenceTypeId;

	public bool IsInverse => m_isInverse;

	public ExpandedNodeId TargetId => m_targetId;

	public NodeStateReference(NodeId referenceTypeId, bool isInverse, NodeState target)
	{
		m_referenceTypeId = referenceTypeId;
		m_isInverse = isInverse;
		m_targetId = target.NodeId;
		m_target = target;
	}

	public NodeStateReference(NodeId referenceTypeId, bool isInverse, ExpandedNodeId targetId)
	{
		m_referenceTypeId = referenceTypeId;
		m_isInverse = isInverse;
		m_targetId = targetId;
		m_target = null;
	}
}
