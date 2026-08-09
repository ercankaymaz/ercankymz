using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public class FolderTypeState : BaseObjectTypeState
{
	protected override void Initialize(ISystemContext context)
	{
		base.SuperTypeId = NodeId.Create(61u, "http://opcfoundation.org/UA/", context.NamespaceUris);
		base.NodeId = NodeId.Create(61u, "http://opcfoundation.org/UA/", context.NamespaceUris);
		base.BrowseName = QualifiedName.Create("FolderType", "http://opcfoundation.org/UA/", context.NamespaceUris);
		base.DisplayName = new LocalizedText("FolderType", string.Empty, "FolderType");
		base.Description = null;
		base.WriteMask = AttributeWriteMask.None;
		base.UserWriteMask = AttributeWriteMask.None;
		base.IsAbstract = false;
	}
}
