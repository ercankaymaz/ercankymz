using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class KeyCredentialAuditEventState : AuditUpdateMethodEventState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAIwAAAEtleUNyZWRlbnRpYWxBdWRpdEV2ZW50VHlwZUluc3RhbmNlAQBbRgEAW0ZbRgAA/////xAAAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAFxGAC4ARFxGAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAF1GAC4ARF1GAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQBeRgAuAEReRgAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEAX0YALgBEX0YAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAGBGAC4ARGBGAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQBhRgAuAERhRgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQBjRgAuAERjRgAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAGRGAC4ARGRGAAAABf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABBY3Rpb25UaW1lU3RhbXABAGVGAC4ARGVGAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAFN0YXR1cwEAZkYALgBEZkYAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNlcnZlcklkAQBnRgAuAERnRgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ2xpZW50QXVkaXRFbnRyeUlkAQBoRgAuAERoRgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQ2xpZW50VXNlcklkAQBpRgAuAERpRgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAIAAAATWV0aG9kSWQBAGpGAC4ARGpGAAAAEf////8BAf////8AAAAAF2CJCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAa0YALgBEa0YAAAAYAQAAAAEAAAAAAAAAAQH/////AAAAABVgiQoCAAAAAAALAAAAUmVzb3VyY2VVcmkBAGxGAC4ARGxGAAAADP////8BAf////8AAAAA";

	private PropertyState<string> m_resourceUri;

	public PropertyState<string> ResourceUri
	{
		get
		{
			return m_resourceUri;
		}
		set
		{
			if (m_resourceUri != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_resourceUri = value;
		}
	}

	public KeyCredentialAuditEventState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(18011u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAIwAAAEtleUNyZWRlbnRpYWxBdWRpdEV2ZW50VHlwZUluc3RhbmNlAQBbRgEAW0ZbRgAA/////xAAAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAFxGAC4ARFxGAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAF1GAC4ARF1GAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQBeRgAuAEReRgAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEAX0YALgBEX0YAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAGBGAC4ARGBGAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQBhRgAuAERhRgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQBjRgAuAERjRgAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAGRGAC4ARGRGAAAABf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABBY3Rpb25UaW1lU3RhbXABAGVGAC4ARGVGAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAFN0YXR1cwEAZkYALgBEZkYAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNlcnZlcklkAQBnRgAuAERnRgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ2xpZW50QXVkaXRFbnRyeUlkAQBoRgAuAERoRgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQ2xpZW50VXNlcklkAQBpRgAuAERpRgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAIAAAATWV0aG9kSWQBAGpGAC4ARGpGAAAAEf////8BAf////8AAAAAF2CJCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAa0YALgBEa0YAAAAYAQAAAAEAAAAAAAAAAQH/////AAAAABVgiQoCAAAAAAALAAAAUmVzb3VyY2VVcmkBAGxGAC4ARGxGAAAADP////8BAf////8AAAAA");
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
		if (m_resourceUri != null)
		{
			children.Add(m_resourceUri);
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
		if (browseName.Name == "ResourceUri")
		{
			if (createOrReplace && ResourceUri == null)
			{
				if (replacement == null)
				{
					ResourceUri = new PropertyState<string>(this);
				}
				else
				{
					ResourceUri = (PropertyState<string>)replacement;
				}
			}
			baseInstanceState = ResourceUri;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
