using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public class FolderState : BaseObjectState
{
	public FolderState(NodeState parent)
		: base(parent)
	{
	}

	protected override void Initialize(ISystemContext context)
	{
		base.SymbolicName = Utils.Format("{0}_Instance1", "FolderType");
		base.NodeId = null;
		base.BrowseName = new QualifiedName(base.SymbolicName, 1);
		base.DisplayName = base.SymbolicName;
		base.Description = null;
		base.WriteMask = AttributeWriteMask.None;
		base.UserWriteMask = AttributeWriteMask.None;
		base.TypeDefinitionId = GetDefaultTypeDefinitionId(context.NamespaceUris);
		base.NumericId = 61u;
		base.EventNotifier = 0;
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return 61u;
	}
}
