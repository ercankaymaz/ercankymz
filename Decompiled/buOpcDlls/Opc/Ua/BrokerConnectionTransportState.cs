using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class BrokerConnectionTransportState : ConnectionTransportState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAJQAAAEJyb2tlckNvbm5lY3Rpb25UcmFuc3BvcnRUeXBlSW5zdGFuY2UBADM7AQAzOzM7AAD/////AgAAABVgiQoCAAAAAAALAAAAUmVzb3VyY2VVcmkBADQ7AC4ARDQ7AAAADP////8BAf////8AAAAAFWCJCgIAAAAAABgAAABBdXRoZW50aWNhdGlvblByb2ZpbGVVcmkBAEo7AC4AREo7AAAADP////8BAf////8AAAAA";

	private PropertyState<string> m_resourceUri;

	private PropertyState<string> m_authenticationProfileUri;

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

	public PropertyState<string> AuthenticationProfileUri
	{
		get
		{
			return m_authenticationProfileUri;
		}
		set
		{
			if (m_authenticationProfileUri != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_authenticationProfileUri = value;
		}
	}

	public BrokerConnectionTransportState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(15155u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAJQAAAEJyb2tlckNvbm5lY3Rpb25UcmFuc3BvcnRUeXBlSW5zdGFuY2UBADM7AQAzOzM7AAD/////AgAAABVgiQoCAAAAAAALAAAAUmVzb3VyY2VVcmkBADQ7AC4ARDQ7AAAADP////8BAf////8AAAAAFWCJCgIAAAAAABgAAABBdXRoZW50aWNhdGlvblByb2ZpbGVVcmkBAEo7AC4AREo7AAAADP////8BAf////8AAAAA");
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
		if (m_authenticationProfileUri != null)
		{
			children.Add(m_authenticationProfileUri);
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
		string name = browseName.Name;
		if (!(name == "ResourceUri"))
		{
			if (name == "AuthenticationProfileUri")
			{
				if (createOrReplace && AuthenticationProfileUri == null)
				{
					if (replacement == null)
					{
						AuthenticationProfileUri = new PropertyState<string>(this);
					}
					else
					{
						AuthenticationProfileUri = (PropertyState<string>)replacement;
					}
				}
				baseInstanceState = AuthenticationProfileUri;
			}
		}
		else
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
