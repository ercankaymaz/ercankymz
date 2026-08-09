using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AuditChannelEventState : AuditSecurityEventState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAHQAAAEF1ZGl0Q2hhbm5lbEV2ZW50VHlwZUluc3RhbmNlAQALCAEACwgLCAAA/////w4AAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAJcMAC4ARJcMAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAJgMAC4ARJgMAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQCZDAAuAESZDAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEAmgwALgBEmgwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAJsMAC4ARJsMAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQCcDAAuAEScDAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQCeDAAuAESeDAAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAJ8MAC4ARJ8MAAAABf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABBY3Rpb25UaW1lU3RhbXABAKAMAC4ARKAMAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAFN0YXR1cwEAoQwALgBEoQwAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNlcnZlcklkAQCiDAAuAESiDAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ2xpZW50QXVkaXRFbnRyeUlkAQCjDAAuAESjDAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQ2xpZW50VXNlcklkAQCkDAAuAESkDAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAU2VjdXJlQ2hhbm5lbElkAQC5CgAuAES5CgAAAAz/////AQH/////AAAAAA==";

	private PropertyState<string> m_secureChannelId;

	public PropertyState<string> SecureChannelId
	{
		get
		{
			return m_secureChannelId;
		}
		set
		{
			if (m_secureChannelId != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_secureChannelId = value;
		}
	}

	public AuditChannelEventState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2059u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAHQAAAEF1ZGl0Q2hhbm5lbEV2ZW50VHlwZUluc3RhbmNlAQALCAEACwgLCAAA/////w4AAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAJcMAC4ARJcMAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAJgMAC4ARJgMAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQCZDAAuAESZDAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEAmgwALgBEmgwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAJsMAC4ARJsMAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQCcDAAuAEScDAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQCeDAAuAESeDAAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAJ8MAC4ARJ8MAAAABf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABBY3Rpb25UaW1lU3RhbXABAKAMAC4ARKAMAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAFN0YXR1cwEAoQwALgBEoQwAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNlcnZlcklkAQCiDAAuAESiDAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ2xpZW50QXVkaXRFbnRyeUlkAQCjDAAuAESjDAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQ2xpZW50VXNlcklkAQCkDAAuAESkDAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAU2VjdXJlQ2hhbm5lbElkAQC5CgAuAES5CgAAAAz/////AQH/////AAAAAA==");
		InitializeOptionalChildren(context);
	}

	protected override void Initialize(ISystemContext context, NodeState source)
	{
		InitializeOptionalChildren(context);
		base.Initialize(context, source);
	}

	protected override void InitializeOptionalChildren(ISystemContext context)
	{
		base.InitializeOptionalChildren(context);
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_secureChannelId != null)
		{
			children.Add(m_secureChannelId);
		}
		base.GetChildren(context, children);
	}

	protected override BaseInstanceState FindChild(ISystemContext context, QualifiedName browseName, bool createOrReplace, BaseInstanceState replacement)
	{
		if (QualifiedName.IsNull(browseName))
		{
			return null;
		}
		BaseInstanceState baseInstanceState = null;
		if (browseName.Name == "SecureChannelId")
		{
			if (createOrReplace && SecureChannelId == null)
			{
				if (replacement == null)
				{
					SecureChannelId = new PropertyState<string>(this);
				}
				else
				{
					SecureChannelId = (PropertyState<string>)replacement;
				}
			}
			baseInstanceState = SecureChannelId;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
