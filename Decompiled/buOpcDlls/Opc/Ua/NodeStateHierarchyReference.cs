using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public class NodeStateHierarchyReference
{
	private string m_sourcePath;

	private NodeId m_referenceTypeId;

	private bool m_isInverse;

	private ExpandedNodeId m_targetId;

	private string m_targetPath;

	public string SourcePath => m_sourcePath;

	public NodeId ReferenceTypeId => m_referenceTypeId;

	public bool IsInverse => m_isInverse;

	public ExpandedNodeId TargetId => m_targetId;

	public string TargetPath => m_targetPath;

	public NodeStateHierarchyReference(string sourcePath, IReference reference)
	{
		m_sourcePath = sourcePath;
		m_referenceTypeId = reference.ReferenceTypeId;
		m_isInverse = reference.IsInverse;
		m_targetPath = null;
		m_targetId = reference.TargetId;
	}

	public NodeStateHierarchyReference(string sourcePath, string targetPath, IReference reference)
	{
		m_sourcePath = sourcePath;
		m_referenceTypeId = reference.ReferenceTypeId;
		m_isInverse = reference.IsInverse;
		m_targetPath = targetPath;
	}
}
