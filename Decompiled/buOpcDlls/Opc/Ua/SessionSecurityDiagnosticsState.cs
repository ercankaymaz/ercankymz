using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class SessionSecurityDiagnosticsState : BaseDataVariableState<SessionSecurityDiagnosticsDataType>
{
	private const string InitializationString = "//////////8VYIkCAgAAAAAAJgAAAFNlc3Npb25TZWN1cml0eURpYWdub3N0aWNzVHlwZUluc3RhbmNlAQDECAEAxAjECAAAAQBkA/////8BAf////8JAAAAFWCJCgIAAAAAAAkAAABTZXNzaW9uSWQBAMUIAC8AP8UIAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAABUAAABDbGllbnRVc2VySWRPZlNlc3Npb24BAMYIAC8AP8YIAAAADP////8BAf////8AAAAAF2CJCgIAAAAAABMAAABDbGllbnRVc2VySWRIaXN0b3J5AQDHCAAvAD/HCAAAAAwBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAABcAAABBdXRoZW50aWNhdGlvbk1lY2hhbmlzbQEAyAgALwA/yAgAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAEVuY29kaW5nAQDJCAAvAD/JCAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAARAAAAVHJhbnNwb3J0UHJvdG9jb2wBAMoIAC8AP8oIAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABTZWN1cml0eU1vZGUBAMsIAC8AP8sIAAABAC4B/////wEB/////wAAAAAVYIkKAgAAAAAAEQAAAFNlY3VyaXR5UG9saWN5VXJpAQDMCAAvAD/MCAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAARAAAAQ2xpZW50Q2VydGlmaWNhdGUBAPILAC8AP/ILAAAAD/////8BAf////8AAAAA";

	private BaseDataVariableState<NodeId> m_sessionId;

	private BaseDataVariableState<string> m_clientUserIdOfSession;

	private BaseDataVariableState<string[]> m_clientUserIdHistory;

	private BaseDataVariableState<string> m_authenticationMechanism;

	private BaseDataVariableState<string> m_encoding;

	private BaseDataVariableState<string> m_transportProtocol;

	private BaseDataVariableState<MessageSecurityMode> m_securityMode;

	private BaseDataVariableState<string> m_securityPolicyUri;

	private BaseDataVariableState<byte[]> m_clientCertificate;

	public BaseDataVariableState<NodeId> SessionId
	{
		get
		{
			return m_sessionId;
		}
		set
		{
			if (m_sessionId != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_sessionId = value;
		}
	}

	public BaseDataVariableState<string> ClientUserIdOfSession
	{
		get
		{
			return m_clientUserIdOfSession;
		}
		set
		{
			if (m_clientUserIdOfSession != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_clientUserIdOfSession = value;
		}
	}

	public BaseDataVariableState<string[]> ClientUserIdHistory
	{
		get
		{
			return m_clientUserIdHistory;
		}
		set
		{
			if (m_clientUserIdHistory != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_clientUserIdHistory = value;
		}
	}

	public BaseDataVariableState<string> AuthenticationMechanism
	{
		get
		{
			return m_authenticationMechanism;
		}
		set
		{
			if (m_authenticationMechanism != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_authenticationMechanism = value;
		}
	}

	public BaseDataVariableState<string> Encoding
	{
		get
		{
			return m_encoding;
		}
		set
		{
			if (m_encoding != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_encoding = value;
		}
	}

	public BaseDataVariableState<string> TransportProtocol
	{
		get
		{
			return m_transportProtocol;
		}
		set
		{
			if (m_transportProtocol != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_transportProtocol = value;
		}
	}

	public BaseDataVariableState<MessageSecurityMode> SecurityMode
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

	public BaseDataVariableState<string> SecurityPolicyUri
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

	public BaseDataVariableState<byte[]> ClientCertificate
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

	public SessionSecurityDiagnosticsState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2244u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(868u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override int GetDefaultValueRank()
	{
		return -1;
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8VYIkCAgAAAAAAJgAAAFNlc3Npb25TZWN1cml0eURpYWdub3N0aWNzVHlwZUluc3RhbmNlAQDECAEAxAjECAAAAQBkA/////8BAf////8JAAAAFWCJCgIAAAAAAAkAAABTZXNzaW9uSWQBAMUIAC8AP8UIAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAABUAAABDbGllbnRVc2VySWRPZlNlc3Npb24BAMYIAC8AP8YIAAAADP////8BAf////8AAAAAF2CJCgIAAAAAABMAAABDbGllbnRVc2VySWRIaXN0b3J5AQDHCAAvAD/HCAAAAAwBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAABcAAABBdXRoZW50aWNhdGlvbk1lY2hhbmlzbQEAyAgALwA/yAgAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAEVuY29kaW5nAQDJCAAvAD/JCAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAARAAAAVHJhbnNwb3J0UHJvdG9jb2wBAMoIAC8AP8oIAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABTZWN1cml0eU1vZGUBAMsIAC8AP8sIAAABAC4B/////wEB/////wAAAAAVYIkKAgAAAAAAEQAAAFNlY3VyaXR5UG9saWN5VXJpAQDMCAAvAD/MCAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAARAAAAQ2xpZW50Q2VydGlmaWNhdGUBAPILAC8AP/ILAAAAD/////8BAf////8AAAAA");
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
		if (m_sessionId != null)
		{
			children.Add(m_sessionId);
		}
		if (m_clientUserIdOfSession != null)
		{
			children.Add(m_clientUserIdOfSession);
		}
		if (m_clientUserIdHistory != null)
		{
			children.Add(m_clientUserIdHistory);
		}
		if (m_authenticationMechanism != null)
		{
			children.Add(m_authenticationMechanism);
		}
		if (m_encoding != null)
		{
			children.Add(m_encoding);
		}
		if (m_transportProtocol != null)
		{
			children.Add(m_transportProtocol);
		}
		if (m_securityMode != null)
		{
			children.Add(m_securityMode);
		}
		if (m_securityPolicyUri != null)
		{
			children.Add(m_securityPolicyUri);
		}
		if (m_clientCertificate != null)
		{
			children.Add(m_clientCertificate);
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
		case "SessionId":
			if (createOrReplace && SessionId == null)
			{
				if (replacement == null)
				{
					SessionId = new BaseDataVariableState<NodeId>(this);
				}
				else
				{
					SessionId = (BaseDataVariableState<NodeId>)replacement;
				}
			}
			baseInstanceState = SessionId;
			break;
		case "ClientUserIdOfSession":
			if (createOrReplace && ClientUserIdOfSession == null)
			{
				if (replacement == null)
				{
					ClientUserIdOfSession = new BaseDataVariableState<string>(this);
				}
				else
				{
					ClientUserIdOfSession = (BaseDataVariableState<string>)replacement;
				}
			}
			baseInstanceState = ClientUserIdOfSession;
			break;
		case "ClientUserIdHistory":
			if (createOrReplace && ClientUserIdHistory == null)
			{
				if (replacement == null)
				{
					ClientUserIdHistory = new BaseDataVariableState<string[]>(this);
				}
				else
				{
					ClientUserIdHistory = (BaseDataVariableState<string[]>)replacement;
				}
			}
			baseInstanceState = ClientUserIdHistory;
			break;
		case "AuthenticationMechanism":
			if (createOrReplace && AuthenticationMechanism == null)
			{
				if (replacement == null)
				{
					AuthenticationMechanism = new BaseDataVariableState<string>(this);
				}
				else
				{
					AuthenticationMechanism = (BaseDataVariableState<string>)replacement;
				}
			}
			baseInstanceState = AuthenticationMechanism;
			break;
		case "Encoding":
			if (createOrReplace && Encoding == null)
			{
				if (replacement == null)
				{
					Encoding = new BaseDataVariableState<string>(this);
				}
				else
				{
					Encoding = (BaseDataVariableState<string>)replacement;
				}
			}
			baseInstanceState = Encoding;
			break;
		case "TransportProtocol":
			if (createOrReplace && TransportProtocol == null)
			{
				if (replacement == null)
				{
					TransportProtocol = new BaseDataVariableState<string>(this);
				}
				else
				{
					TransportProtocol = (BaseDataVariableState<string>)replacement;
				}
			}
			baseInstanceState = TransportProtocol;
			break;
		case "SecurityMode":
			if (createOrReplace && SecurityMode == null)
			{
				if (replacement == null)
				{
					SecurityMode = new BaseDataVariableState<MessageSecurityMode>(this);
				}
				else
				{
					SecurityMode = (BaseDataVariableState<MessageSecurityMode>)replacement;
				}
			}
			baseInstanceState = SecurityMode;
			break;
		case "SecurityPolicyUri":
			if (createOrReplace && SecurityPolicyUri == null)
			{
				if (replacement == null)
				{
					SecurityPolicyUri = new BaseDataVariableState<string>(this);
				}
				else
				{
					SecurityPolicyUri = (BaseDataVariableState<string>)replacement;
				}
			}
			baseInstanceState = SecurityPolicyUri;
			break;
		case "ClientCertificate":
			if (createOrReplace && ClientCertificate == null)
			{
				if (replacement == null)
				{
					ClientCertificate = new BaseDataVariableState<byte[]>(this);
				}
				else
				{
					ClientCertificate = (BaseDataVariableState<byte[]>)replacement;
				}
			}
			baseInstanceState = ClientCertificate;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
