using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class SessionSecurityDiagnosticsDataType : IEncodeable, ICloneable, IJsonEncodeable
{
	private NodeId m_sessionId;

	private string m_clientUserIdOfSession;

	private StringCollection m_clientUserIdHistory;

	private string m_authenticationMechanism;

	private string m_encoding;

	private string m_transportProtocol;

	private MessageSecurityMode m_securityMode;

	private string m_securityPolicyUri;

	private byte[] m_clientCertificate;

	[DataMember(Name = "SessionId", IsRequired = false, Order = 1)]
	public NodeId SessionId
	{
		get
		{
			return m_sessionId;
		}
		set
		{
			m_sessionId = value;
		}
	}

	[DataMember(Name = "ClientUserIdOfSession", IsRequired = false, Order = 2)]
	public string ClientUserIdOfSession
	{
		get
		{
			return m_clientUserIdOfSession;
		}
		set
		{
			m_clientUserIdOfSession = value;
		}
	}

	[DataMember(Name = "ClientUserIdHistory", IsRequired = false, Order = 3)]
	public StringCollection ClientUserIdHistory
	{
		get
		{
			return m_clientUserIdHistory;
		}
		set
		{
			m_clientUserIdHistory = value;
			if (value == null)
			{
				m_clientUserIdHistory = new StringCollection();
			}
		}
	}

	[DataMember(Name = "AuthenticationMechanism", IsRequired = false, Order = 4)]
	public string AuthenticationMechanism
	{
		get
		{
			return m_authenticationMechanism;
		}
		set
		{
			m_authenticationMechanism = value;
		}
	}

	[DataMember(Name = "Encoding", IsRequired = false, Order = 5)]
	public string Encoding
	{
		get
		{
			return m_encoding;
		}
		set
		{
			m_encoding = value;
		}
	}

	[DataMember(Name = "TransportProtocol", IsRequired = false, Order = 6)]
	public string TransportProtocol
	{
		get
		{
			return m_transportProtocol;
		}
		set
		{
			m_transportProtocol = value;
		}
	}

	[DataMember(Name = "SecurityMode", IsRequired = false, Order = 7)]
	public MessageSecurityMode SecurityMode
	{
		get
		{
			return m_securityMode;
		}
		set
		{
			m_securityMode = value;
		}
	}

	[DataMember(Name = "SecurityPolicyUri", IsRequired = false, Order = 8)]
	public string SecurityPolicyUri
	{
		get
		{
			return m_securityPolicyUri;
		}
		set
		{
			m_securityPolicyUri = value;
		}
	}

	[DataMember(Name = "ClientCertificate", IsRequired = false, Order = 9)]
	public byte[] ClientCertificate
	{
		get
		{
			return m_clientCertificate;
		}
		set
		{
			m_clientCertificate = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.SessionSecurityDiagnosticsDataType;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.SessionSecurityDiagnosticsDataType_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.SessionSecurityDiagnosticsDataType_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.SessionSecurityDiagnosticsDataType_Encoding_DefaultJson;

	public SessionSecurityDiagnosticsDataType()
	{
		Initialize();
	}

	[OnDeserializing]
	private void Initialize(StreamingContext context)
	{
		Initialize();
	}

	private void Initialize()
	{
		m_sessionId = null;
		m_clientUserIdOfSession = null;
		m_clientUserIdHistory = new StringCollection();
		m_authenticationMechanism = null;
		m_encoding = null;
		m_transportProtocol = null;
		m_securityMode = MessageSecurityMode.Invalid;
		m_securityPolicyUri = null;
		m_clientCertificate = null;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteNodeId("SessionId", SessionId);
		encoder.WriteString("ClientUserIdOfSession", ClientUserIdOfSession);
		encoder.WriteStringArray("ClientUserIdHistory", ClientUserIdHistory);
		encoder.WriteString("AuthenticationMechanism", AuthenticationMechanism);
		encoder.WriteString("Encoding", Encoding);
		encoder.WriteString("TransportProtocol", TransportProtocol);
		encoder.WriteEnumerated("SecurityMode", SecurityMode);
		encoder.WriteString("SecurityPolicyUri", SecurityPolicyUri);
		encoder.WriteByteString("ClientCertificate", ClientCertificate);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		SessionId = decoder.ReadNodeId("SessionId");
		ClientUserIdOfSession = decoder.ReadString("ClientUserIdOfSession");
		ClientUserIdHistory = decoder.ReadStringArray("ClientUserIdHistory");
		AuthenticationMechanism = decoder.ReadString("AuthenticationMechanism");
		Encoding = decoder.ReadString("Encoding");
		TransportProtocol = decoder.ReadString("TransportProtocol");
		SecurityMode = (MessageSecurityMode)(object)decoder.ReadEnumerated("SecurityMode", typeof(MessageSecurityMode));
		SecurityPolicyUri = decoder.ReadString("SecurityPolicyUri");
		ClientCertificate = decoder.ReadByteString("ClientCertificate");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is SessionSecurityDiagnosticsDataType sessionSecurityDiagnosticsDataType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_sessionId, sessionSecurityDiagnosticsDataType.m_sessionId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_clientUserIdOfSession, sessionSecurityDiagnosticsDataType.m_clientUserIdOfSession))
		{
			return false;
		}
		if (!Utils.IsEqual(m_clientUserIdHistory, sessionSecurityDiagnosticsDataType.m_clientUserIdHistory))
		{
			return false;
		}
		if (!Utils.IsEqual(m_authenticationMechanism, sessionSecurityDiagnosticsDataType.m_authenticationMechanism))
		{
			return false;
		}
		if (!Utils.IsEqual(m_encoding, sessionSecurityDiagnosticsDataType.m_encoding))
		{
			return false;
		}
		if (!Utils.IsEqual(m_transportProtocol, sessionSecurityDiagnosticsDataType.m_transportProtocol))
		{
			return false;
		}
		if (!Utils.IsEqual(m_securityMode, sessionSecurityDiagnosticsDataType.m_securityMode))
		{
			return false;
		}
		if (!Utils.IsEqual(m_securityPolicyUri, sessionSecurityDiagnosticsDataType.m_securityPolicyUri))
		{
			return false;
		}
		if (!Utils.IsEqual(m_clientCertificate, sessionSecurityDiagnosticsDataType.m_clientCertificate))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (SessionSecurityDiagnosticsDataType)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		SessionSecurityDiagnosticsDataType obj = (SessionSecurityDiagnosticsDataType)base.MemberwiseClone();
		obj.m_sessionId = (NodeId)Utils.Clone(m_sessionId);
		obj.m_clientUserIdOfSession = (string)Utils.Clone(m_clientUserIdOfSession);
		obj.m_clientUserIdHistory = (StringCollection)Utils.Clone(m_clientUserIdHistory);
		obj.m_authenticationMechanism = (string)Utils.Clone(m_authenticationMechanism);
		obj.m_encoding = (string)Utils.Clone(m_encoding);
		obj.m_transportProtocol = (string)Utils.Clone(m_transportProtocol);
		obj.m_securityMode = (MessageSecurityMode)Utils.Clone(m_securityMode);
		obj.m_securityPolicyUri = (string)Utils.Clone(m_securityPolicyUri);
		obj.m_clientCertificate = (byte[])Utils.Clone(m_clientCertificate);
		return obj;
	}
}
