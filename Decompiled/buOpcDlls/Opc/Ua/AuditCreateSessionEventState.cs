using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AuditCreateSessionEventState : AuditSessionEventState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAIwAAAEF1ZGl0Q3JlYXRlU2Vzc2lvbkV2ZW50VHlwZUluc3RhbmNlAQAXCAEAFwgXCAAA/////xIAAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAMIMAC4ARMIMAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAMMMAC4ARMMMAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQDEDAAuAETEDAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEAxQwALgBExQwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAMYMAC4ARMYMAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQDHDAAuAETHDAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQDJDAAuAETJDAAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAMoMAC4ARMoMAAAABf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABBY3Rpb25UaW1lU3RhbXABAMsMAC4ARMsMAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAFN0YXR1cwEAzAwALgBEzAwAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNlcnZlcklkAQDNDAAuAETNDAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ2xpZW50QXVkaXRFbnRyeUlkAQDODAAuAETODAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQ2xpZW50VXNlcklkAQDPDAAuAETPDAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAJAAAAU2Vzc2lvbklkAQBNOAAuAERNOAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAU2VjdXJlQ2hhbm5lbElkAQAYCAAuAEQYCAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAARAAAAQ2xpZW50Q2VydGlmaWNhdGUBABkIAC4ARBkIAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAABsAAABDbGllbnRDZXJ0aWZpY2F0ZVRodW1icHJpbnQBALsKAC4ARLsKAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABUAAABSZXZpc2VkU2Vzc2lvblRpbWVvdXQBABoIAC4ARBoIAAABACIB/////wEB/////wAAAAA=";

	private PropertyState<string> m_secureChannelId;

	private PropertyState<byte[]> m_clientCertificate;

	private PropertyState<string> m_clientCertificateThumbprint;

	private PropertyState<double> m_revisedSessionTimeout;

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

	public PropertyState<double> RevisedSessionTimeout
	{
		get
		{
			return m_revisedSessionTimeout;
		}
		set
		{
			if (m_revisedSessionTimeout != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_revisedSessionTimeout = value;
		}
	}

	public AuditCreateSessionEventState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2071u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAIwAAAEF1ZGl0Q3JlYXRlU2Vzc2lvbkV2ZW50VHlwZUluc3RhbmNlAQAXCAEAFwgXCAAA/////xIAAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAMIMAC4ARMIMAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAMMMAC4ARMMMAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQDEDAAuAETEDAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEAxQwALgBExQwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAMYMAC4ARMYMAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQDHDAAuAETHDAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQDJDAAuAETJDAAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAMoMAC4ARMoMAAAABf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABBY3Rpb25UaW1lU3RhbXABAMsMAC4ARMsMAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAFN0YXR1cwEAzAwALgBEzAwAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNlcnZlcklkAQDNDAAuAETNDAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ2xpZW50QXVkaXRFbnRyeUlkAQDODAAuAETODAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQ2xpZW50VXNlcklkAQDPDAAuAETPDAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAJAAAAU2Vzc2lvbklkAQBNOAAuAERNOAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAU2VjdXJlQ2hhbm5lbElkAQAYCAAuAEQYCAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAARAAAAQ2xpZW50Q2VydGlmaWNhdGUBABkIAC4ARBkIAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAABsAAABDbGllbnRDZXJ0aWZpY2F0ZVRodW1icHJpbnQBALsKAC4ARLsKAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABUAAABSZXZpc2VkU2Vzc2lvblRpbWVvdXQBABoIAC4ARBoIAAABACIB/////wEB/////wAAAAA=");
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
		if (m_clientCertificate != null)
		{
			children.Add(m_clientCertificate);
		}
		if (m_clientCertificateThumbprint != null)
		{
			children.Add(m_clientCertificateThumbprint);
		}
		if (m_revisedSessionTimeout != null)
		{
			children.Add(m_revisedSessionTimeout);
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
		case "SecureChannelId":
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
			break;
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
		case "RevisedSessionTimeout":
			if (createOrReplace && RevisedSessionTimeout == null)
			{
				if (replacement == null)
				{
					RevisedSessionTimeout = new PropertyState<double>(this);
				}
				else
				{
					RevisedSessionTimeout = (PropertyState<double>)replacement;
				}
			}
			baseInstanceState = RevisedSessionTimeout;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
