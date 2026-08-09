using System;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public class BaseObjectTypeState : BaseTypeState
{
	public BaseObjectTypeState()
		: base(NodeClass.ObjectType)
	{
	}

	protected override void Initialize(ISystemContext context)
	{
		base.SuperTypeId = NodeId.Create(58u, "http://opcfoundation.org/UA/", context.NamespaceUris);
		base.NodeId = NodeId.Create(58u, "http://opcfoundation.org/UA/", context.NamespaceUris);
		base.BrowseName = QualifiedName.Create("BaseObjectType", "http://opcfoundation.org/UA/", context.NamespaceUris);
		base.DisplayName = new LocalizedText("BaseObjectType", string.Empty, "BaseObjectType");
		base.Description = null;
		base.WriteMask = AttributeWriteMask.None;
		base.UserWriteMask = AttributeWriteMask.None;
		base.IsAbstract = false;
	}

	public static NodeState Construct(NodeState parent)
	{
		return new BaseObjectTypeState();
	}

	public override object Clone()
	{
		return MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		BaseObjectTypeState clone = (BaseObjectTypeState)Activator.CreateInstance(GetType());
		return CloneChildren(clone);
	}
}
