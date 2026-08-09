using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AuditOpenSecureChannelEventState : AuditChannelEventState
{
	private const string CertificateErrorEventId_InitializationString = "//////////8VYIkKAgAAAAAAFwAAAENlcnRpZmljYXRlRXJyb3JFdmVudElkAQBHXgAuAERHXgAAAAz/////AQH/////AAAAAA==";

	private const string InitializationString = "//////////8EYIACAQAAAAAAJwAAAEF1ZGl0T3BlblNlY3VyZUNoYW5uZWxFdmVudFR5cGVJbnN0YW5jZQEADAgBAAwIDAgAAP////8VAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQClDAAuAESlDAAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQCmDAAuAESmDAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEApwwALgBEpwwAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAKgMAC4ARKgMAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQCpDAAuAESpDAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEAqgwALgBEqgwAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEArAwALgBErAwAAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQCtDAAuAEStDAAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQWN0aW9uVGltZVN0YW1wAQCuDAAuAESuDAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABTdGF0dXMBAK8MAC4ARK8MAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXJ2ZXJJZAEAsAwALgBEsAwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENsaWVudEF1ZGl0RW50cnlJZAEAsQwALgBEsQwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEAsgwALgBEsgwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAFNlY3VyZUNoYW5uZWxJZAEAswwALgBEswwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEQAAAENsaWVudENlcnRpZmljYXRlAQANCAAuAEQNCAAAAA//////AQH/////AAAAABVgiQoCAAAAAAAbAAAAQ2xpZW50Q2VydGlmaWNhdGVUaHVtYnByaW50AQC6CgAuAES6CgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVxdWVzdFR5cGUBAA4IAC4ARA4IAAABADsB/////wEB/////wAAAAAVYIkKAgAAAAAAEQAAAFNlY3VyaXR5UG9saWN5VXJpAQAPCAAuAEQPCAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAU2VjdXJpdHlNb2RlAQARCAAuAEQRCAAAAQAuAf////8BAf////8AAAAAFWCJCgIAAAAAABEAAABSZXF1ZXN0ZWRMaWZldGltZQEAEggALgBEEggAAAEAIgH/////AQH/////AAAAABVgiQoCAAAAAAAXAAAAQ2VydGlmaWNhdGVFcnJvckV2ZW50SWQBAEdeAC4AREdeAAAADP////8BAf////8AAAAA";

	private PropertyState<byte[]> m_clientCertificate;

	private PropertyState<string> m_clientCertificateThumbprint;

	private PropertyState<SecurityTokenRequestType> m_requestType;

	private PropertyState<string> m_securityPolicyUri;

	private PropertyState<MessageSecurityMode> m_securityMode;

	private PropertyState<double> m_requestedLifetime;

	private PropertyState<string> m_certificateErrorEventId;

	public PropertyState<byte[]> ClientCertificate
	{
		get
		{
			return m_clientCertificate;
		}
		set
		{
			if (m_clientCertificate != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_clientCertificate = value;
		}
	}

	public PropertyState<string> ClientCertificateThumbprint
	{
		get
		{
			return m_clientCertificateThumbprint;
		}
		set
		{
			if (m_clientCertificateThumbprint != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_clientCertificateThumbprint = value;
		}
	}

	public PropertyState<SecurityTokenRequestType> RequestType
	{
		get
		{
			return m_requestType;
		}
		set
		{
			if (m_requestType != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_requestType = value;
		}
	}

	public PropertyState<string> SecurityPolicyUri
	{
		get
		{
			return m_securityPolicyUri;
		}
		set
		{
			if (m_securityPolicyUri != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_securityPolicyUri = value;
		}
	}

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

	public PropertyState<double> RequestedLifetime
	{
		get
		{
			return m_requestedLifetime;
		}
		set
		{
			if (m_requestedLifetime != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_requestedLifetime = value;
		}
	}

	public PropertyState<string> CertificateErrorEventId
	{
		get
		{
			return m_certificateErrorEventId;
		}
		set
		{
			if (m_certificateErrorEventId != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_certificateErrorEventId = value;
		}
	}

	public AuditOpenSecureChannelEventState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2060u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAJwAAAEF1ZGl0T3BlblNlY3VyZUNoYW5uZWxFdmVudFR5cGVJbnN0YW5jZQEADAgBAAwIDAgAAP////8VAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQClDAAuAESlDAAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQCmDAAuAESmDAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEApwwALgBEpwwAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAKgMAC4ARKgMAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQCpDAAuAESpDAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEAqgwALgBEqgwAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEArAwALgBErAwAAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQCtDAAuAEStDAAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQWN0aW9uVGltZVN0YW1wAQCuDAAuAESuDAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABTdGF0dXMBAK8MAC4ARK8MAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXJ2ZXJJZAEAsAwALgBEsAwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENsaWVudEF1ZGl0RW50cnlJZAEAsQwALgBEsQwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEAsgwALgBEsgwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAFNlY3VyZUNoYW5uZWxJZAEAswwALgBEswwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEQAAAENsaWVudENlcnRpZmljYXRlAQANCAAuAEQNCAAAAA//////AQH/////AAAAABVgiQoCAAAAAAAbAAAAQ2xpZW50Q2VydGlmaWNhdGVUaHVtYnByaW50AQC6CgAuAES6CgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVxdWVzdFR5cGUBAA4IAC4ARA4IAAABADsB/////wEB/////wAAAAAVYIkKAgAAAAAAEQAAAFNlY3VyaXR5UG9saWN5VXJpAQAPCAAuAEQPCAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAU2VjdXJpdHlNb2RlAQARCAAuAEQRCAAAAQAuAf////8BAf////8AAAAAFWCJCgIAAAAAABEAAABSZXF1ZXN0ZWRMaWZldGltZQEAEggALgBEEggAAAEAIgH/////AQH/////AAAAABVgiQoCAAAAAAAXAAAAQ2VydGlmaWNhdGVFcnJvckV2ZW50SWQBAEdeAC4AREdeAAAADP////8BAf////8AAAAA");
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
		if (CertificateErrorEventId != null)
		{
			CertificateErrorEventId.Initialize(context, "//////////8VYIkKAgAAAAAAFwAAAENlcnRpZmljYXRlRXJyb3JFdmVudElkAQBHXgAuAERHXgAAAAz/////AQH/////AAAAAA==");
		}
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_clientCertificate != null)
		{
			children.Add(m_clientCertificate);
		}
		if (m_clientCertificateThumbprint != null)
		{
			children.Add(m_clientCertificateThumbprint);
		}
		if (m_requestType != null)
		{
			children.Add(m_requestType);
		}
		if (m_securityPolicyUri != null)
		{
			children.Add(m_securityPolicyUri);
		}
		if (m_securityMode != null)
		{
			children.Add(m_securityMode);
		}
		if (m_requestedLifetime != null)
		{
			children.Add(m_requestedLifetime);
		}
		if (m_certificateErrorEventId != null)
		{
			children.Add(m_certificateErrorEventId);
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
		case "ClientCertificate":
			if (createOrReplace && ClientCertificate == null)
			{
				if (replacement == null)
				{
					ClientCertificate = new PropertyState<byte[]>(this);
				}
				else
				{
					ClientCertificate = (PropertyState<byte[]>)replacement;
				}
			}
			baseInstanceState = ClientCertificate;
			break;
		case "ClientCertificateThumbprint":
			if (createOrReplace && ClientCertificateThumbprint == null)
			{
				if (replacement == null)
				{
					ClientCertificateThumbprint = new PropertyState<string>(this);
				}
				else
				{
					ClientCertificateThumbprint = (PropertyState<string>)replacement;
				}
			}
			baseInstanceState = ClientCertificateThumbprint;
			break;
		case "RequestType":
			if (createOrReplace && RequestType == null)
			{
				if (replacement == null)
				{
					RequestType = new PropertyState<SecurityTokenRequestType>(this);
				}
				else
				{
					RequestType = (PropertyState<SecurityTokenRequestType>)replacement;
				}
			}
			baseInstanceState = RequestType;
			break;
		case "SecurityPolicyUri":
			if (createOrReplace && SecurityPolicyUri == null)
			{
				if (replacement == null)
				{
					SecurityPolicyUri = new PropertyState<string>(this);
				}
				else
				{
					SecurityPolicyUri = (PropertyState<string>)replacement;
				}
			}
			baseInstanceState = SecurityPolicyUri;
			break;
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
		case "RequestedLifetime":
			if (createOrReplace && RequestedLifetime == null)
			{
				if (replacement == null)
				{
					RequestedLifetime = new PropertyState<double>(this);
				}
				else
				{
					RequestedLifetime = (PropertyState<double>)replacement;
				}
			}
			baseInstanceState = RequestedLifetime;
			break;
		case "CertificateErrorEventId":
			if (createOrReplace && CertificateErrorEventId == null)
			{
				if (replacement == null)
				{
					CertificateErrorEventId = new PropertyState<string>(this);
				}
				else
				{
					CertificateErrorEventId = (PropertyState<string>)replacement;
				}
			}
			baseInstanceState = CertificateErrorEventId;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
