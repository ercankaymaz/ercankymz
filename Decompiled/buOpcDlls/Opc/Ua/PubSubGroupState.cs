using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class PubSubGroupState : BaseObjectState
{
	private const string SecurityGroupId_InitializationString = "//////////8VYIkKAgAAAAAADwAAAFNlY3VyaXR5R3JvdXBJZAEANz4ALgBENz4AAAAM/////wEB/////wAAAAA=";

	private const string SecurityKeyServices_InitializationString = "//////////8XYIkKAgAAAAAAEwAAAFNlY3VyaXR5S2V5U2VydmljZXMBADg+AC4ARDg+AAABADgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==";

	private const string InitializationString = "//////////8EYIACAQAAAAAAFwAAAFB1YlN1Ykdyb3VwVHlwZUluc3RhbmNlAQCYNwEAmDeYNwAA/////wYAAAAVYIkKAgAAAAAADAAAAFNlY3VyaXR5TW9kZQEANj4ALgBENj4AAAEALgH/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAU2VjdXJpdHlHcm91cElkAQA3PgAuAEQ3PgAAAAz/////AQH/////AAAAABdgiQoCAAAAAAATAAAAU2VjdXJpdHlLZXlTZXJ2aWNlcwEAOD4ALgBEOD4AAAEAOAEBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAABUAAABNYXhOZXR3b3JrTWVzc2FnZVNpemUBADxFAC4ARDxFAAAAB/////8BAf////8AAAAAF2CJCgIAAAAAAA8AAABHcm91cFByb3BlcnRpZXMBAFBEAC4ARFBEAAABAMU4AQAAAAEAAAAAAAAAAQH/////AAAAAARggAoBAAAAAAAGAAAAU3RhdHVzAQChOwAvAQAzOaE7AAD/////AQAAABVgiQoCAAAAAAAFAAAAU3RhdGUBAKI7AC8AP6I7AAABADc5/////wEB/////wAAAAA=";

	private PropertyState<MessageSecurityMode> m_securityMode;

	private PropertyState<string> m_securityGroupId;

	private PropertyState<EndpointDescription[]> m_securityKeyServices;

	private PropertyState<uint> m_maxNetworkMessageSize;

	private PropertyState<KeyValuePair[]> m_groupProperties;

	private PubSubStatusState m_status;

	public PropertyState<MessageSecurityMode> SecurityMode
	{
		get
		{
			return m_securityMode;
		}
		set
		{
			if (m_securityMode != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_securityMode = value;
		}
	}

	public PropertyState<string> SecurityGroupId
	{
		get
		{
			return m_securityGroupId;
		}
		set
		{
			if (m_securityGroupId != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_securityGroupId = value;
		}
	}

	public PropertyState<EndpointDescription[]> SecurityKeyServices
	{
		get
		{
			return m_securityKeyServices;
		}
		set
		{
			if (m_securityKeyServices != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_securityKeyServices = value;
		}
	}

	public PropertyState<uint> MaxNetworkMessageSize
	{
		get
		{
			return m_maxNetworkMessageSize;
		}
		set
		{
			if (m_maxNetworkMessageSize != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_maxNetworkMessageSize = value;
		}
	}

	public PropertyState<KeyValuePair[]> GroupProperties
	{
		get
		{
			return m_groupProperties;
		}
		set
		{
			if (m_groupProperties != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_groupProperties = value;
		}
	}

	public PubSubStatusState Status
	{
		get
		{
			return m_status;
		}
		set
		{
			if (m_status != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_status = value;
		}
	}

	public PubSubGroupState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(14232u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAFwAAAFB1YlN1Ykdyb3VwVHlwZUluc3RhbmNlAQCYNwEAmDeYNwAA/////wYAAAAVYIkKAgAAAAAADAAAAFNlY3VyaXR5TW9kZQEANj4ALgBENj4AAAEALgH/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAU2VjdXJpdHlHcm91cElkAQA3PgAuAEQ3PgAAAAz/////AQH/////AAAAABdgiQoCAAAAAAATAAAAU2VjdXJpdHlLZXlTZXJ2aWNlcwEAOD4ALgBEOD4AAAEAOAEBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAABUAAABNYXhOZXR3b3JrTWVzc2FnZVNpemUBADxFAC4ARDxFAAAAB/////8BAf////8AAAAAF2CJCgIAAAAAAA8AAABHcm91cFByb3BlcnRpZXMBAFBEAC4ARFBEAAABAMU4AQAAAAEAAAAAAAAAAQH/////AAAAAARggAoBAAAAAAAGAAAAU3RhdHVzAQChOwAvAQAzOaE7AAD/////AQAAABVgiQoCAAAAAAAFAAAAU3RhdGUBAKI7AC8AP6I7AAABADc5/////wEB/////wAAAAA=");
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
		if (SecurityGroupId != null)
		{
			SecurityGroupId.Initialize(context, "//////////8VYIkKAgAAAAAADwAAAFNlY3VyaXR5R3JvdXBJZAEANz4ALgBENz4AAAAM/////wEB/////wAAAAA=");
		}
		if (SecurityKeyServices != null)
		{
			SecurityKeyServices.Initialize(context, "//////////8XYIkKAgAAAAAAEwAAAFNlY3VyaXR5S2V5U2VydmljZXMBADg+AC4ARDg+AAABADgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
		}
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_securityMode != null)
		{
			children.Add(m_securityMode);
		}
		if (m_securityGroupId != null)
		{
			children.Add(m_securityGroupId);
		}
		if (m_securityKeyServices != null)
		{
			children.Add(m_securityKeyServices);
		}
		if (m_maxNetworkMessageSize != null)
		{
			children.Add(m_maxNetworkMessageSize);
		}
		if (m_groupProperties != null)
		{
			children.Add(m_groupProperties);
		}
		if (m_status != null)
		{
			children.Add(m_status);
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
		switch (browseName.Name)
		{
		case "SecurityMode":
			if (createOrReplace && SecurityMode == null)
			{
				if (replacement == null)
				{
					SecurityMode = new PropertyState<MessageSecurityMode>(this);
				}
				else
				{
					SecurityMode = (PropertyState<MessageSecurityMode>)replacement;
				}
			}
			baseInstanceState = SecurityMode;
			break;
		case "SecurityGroupId":
			if (createOrReplace && SecurityGroupId == null)
			{
				if (replacement == null)
				{
					SecurityGroupId = new PropertyState<string>(this);
				}
				else
				{
					SecurityGroupId = (PropertyState<string>)replacement;
				}
			}
			baseInstanceState = SecurityGroupId;
			break;
		case "SecurityKeyServices":
			if (createOrReplace && SecurityKeyServices == null)
			{
				if (replacement == null)
				{
					SecurityKeyServices = new PropertyState<EndpointDescription[]>(this);
				}
				else
				{
					SecurityKeyServices = (PropertyState<EndpointDescription[]>)replacement;
				}
			}
			baseInstanceState = SecurityKeyServices;
			break;
		case "MaxNetworkMessageSize":
			if (createOrReplace && MaxNetworkMessageSize == null)
			{
				if (replacement == null)
				{
					MaxNetworkMessageSize = new PropertyState<uint>(this);
				}
				else
				{
					MaxNetworkMessageSize = (PropertyState<uint>)replacement;
				}
			}
			baseInstanceState = MaxNetworkMessageSize;
			break;
		case "GroupProperties":
			if (createOrReplace && GroupProperties == null)
			{
				if (replacement == null)
				{
					GroupProperties = new PropertyState<KeyValuePair[]>(this);
				}
				else
				{
					GroupProperties = (PropertyState<KeyValuePair[]>)replacement;
				}
			}
			baseInstanceState = GroupProperties;
			break;
		case "Status":
			if (createOrReplace && Status == null)
			{
				if (replacement == null)
				{
					Status = new PubSubStatusState(this);
				}
				else
				{
					Status = (PubSubStatusState)replacement;
				}
			}
			baseInstanceState = Status;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
