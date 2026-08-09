using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AuthorizationServiceConfigurationState : BaseObjectState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAALQAAAEF1dGhvcml6YXRpb25TZXJ2aWNlQ29uZmlndXJhdGlvblR5cGVJbnN0YW5jZQEAvEUBALxFvEUAAP////8DAAAAFWCJCgIAAAAAAAoAAABTZXJ2aWNlVXJpAQCYRgAuAESYRgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAASAAAAU2VydmljZUNlcnRpZmljYXRlAQDERQAuAETERQAAAA//////AQH/////AAAAABVgiQoCAAAAAAARAAAASXNzdWVyRW5kcG9pbnRVcmwBAJlGAC4ARJlGAAAADP////8BAf////8AAAAA";

	private PropertyState<string> m_serviceUri;

	private PropertyState<byte[]> m_serviceCertificate;

	private PropertyState<string> m_issuerEndpointUrl;

	public PropertyState<string> ServiceUri
	{
		get
		{
			return m_serviceUri;
		}
		set
		{
			if (m_serviceUri != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_serviceUri = value;
		}
	}

	public PropertyState<byte[]> ServiceCertificate
	{
		get
		{
			return m_serviceCertificate;
		}
		set
		{
			if (m_serviceCertificate != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_serviceCertificate = value;
		}
	}

	public PropertyState<string> IssuerEndpointUrl
	{
		get
		{
			return m_issuerEndpointUrl;
		}
		set
		{
			if (m_issuerEndpointUrl != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_issuerEndpointUrl = value;
		}
	}

	public AuthorizationServiceConfigurationState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(17852u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAALQAAAEF1dGhvcml6YXRpb25TZXJ2aWNlQ29uZmlndXJhdGlvblR5cGVJbnN0YW5jZQEAvEUBALxFvEUAAP////8DAAAAFWCJCgIAAAAAAAoAAABTZXJ2aWNlVXJpAQCYRgAuAESYRgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAASAAAAU2VydmljZUNlcnRpZmljYXRlAQDERQAuAETERQAAAA//////AQH/////AAAAABVgiQoCAAAAAAARAAAASXNzdWVyRW5kcG9pbnRVcmwBAJlGAC4ARJlGAAAADP////8BAf////8AAAAA");
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
		if (m_serviceUri != null)
		{
			children.Add(m_serviceUri);
		}
		if (m_serviceCertificate != null)
		{
			children.Add(m_serviceCertificate);
		}
		if (m_issuerEndpointUrl != null)
		{
			children.Add(m_issuerEndpointUrl);
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
		case "ServiceUri":
			if (createOrReplace && ServiceUri == null)
			{
				if (replacement == null)
				{
					ServiceUri = new PropertyState<string>(this);
				}
				else
				{
					ServiceUri = (PropertyState<string>)replacement;
				}
			}
			baseInstanceState = ServiceUri;
			break;
		case "ServiceCertificate":
			if (createOrReplace && ServiceCertificate == null)
			{
				if (replacement == null)
				{
					ServiceCertificate = new PropertyState<byte[]>(this);
				}
				else
				{
					ServiceCertificate = (PropertyState<byte[]>)replacement;
				}
			}
			baseInstanceState = ServiceCertificate;
			break;
		case "IssuerEndpointUrl":
			if (createOrReplace && IssuerEndpointUrl == null)
			{
				if (replacement == null)
				{
					IssuerEndpointUrl = new PropertyState<string>(this);
				}
				else
				{
					IssuerEndpointUrl = (PropertyState<string>)replacement;
				}
			}
			baseInstanceState = IssuerEndpointUrl;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
