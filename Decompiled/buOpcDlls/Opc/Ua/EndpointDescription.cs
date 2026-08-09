using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class EndpointDescription : IEncodeable, ICloneable, IJsonEncodeable
{
	private Uri m_proxyUrl;

	private string m_endpointUrl;

	private ApplicationDescription m_server;

	private byte[] m_serverCertificate;

	private MessageSecurityMode m_securityMode;

	private string m_securityPolicyUri;

	private UserTokenPolicyCollection m_userIdentityTokens;

	private string m_transportProfileUri;

	private byte m_securityLevel;

	public BinaryEncodingSupport EncodingSupport
	{
		get
		{
			if (!string.IsNullOrEmpty(EndpointUrl) && EndpointUrl.StartsWith("opc.tcp"))
			{
				return BinaryEncodingSupport.Required;
			}
			TransportProfileUri = Profiles.NormalizeUri(TransportProfileUri);
			if (TransportProfileUri == "http://opcfoundation.org/UA-Profile/Transport/https-uabinary")
			{
				return BinaryEncodingSupport.Required;
			}
			return BinaryEncodingSupport.None;
		}
	}

	public Uri ProxyUrl
	{
		get
		{
			return m_proxyUrl;
		}
		set
		{
			m_proxyUrl = value;
		}
	}

	[DataMember(Name = "EndpointUrl", IsRequired = false, Order = 1)]
	public string EndpointUrl
	{
		get
		{
			return m_endpointUrl;
		}
		set
		{
			m_endpointUrl = value;
		}
	}

	[DataMember(Name = "Server", IsRequired = false, Order = 2)]
	public ApplicationDescription Server
	{
		get
		{
			return m_server;
		}
		set
		{
			m_server = value;
			if (value == null)
			{
				m_server = new ApplicationDescription();
			}
		}
	}

	[DataMember(Name = "ServerCertificate", IsRequired = false, Order = 3)]
	public byte[] ServerCertificate
	{
		get
		{
			return m_serverCertificate;
		}
		set
		{
			m_serverCertificate = value;
		}
	}

	[DataMember(Name = "SecurityMode", IsRequired = false, Order = 4)]
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

	[DataMember(Name = "SecurityPolicyUri", IsRequired = false, Order = 5)]
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

	[DataMember(Name = "UserIdentityTokens", IsRequired = false, Order = 6)]
	public UserTokenPolicyCollection UserIdentityTokens
	{
		get
		{
			return m_userIdentityTokens;
		}
		set
		{
			m_userIdentityTokens = value;
			if (value == null)
			{
				m_userIdentityTokens = new UserTokenPolicyCollection();
			}
		}
	}

	[DataMember(Name = "TransportProfileUri", IsRequired = false, Order = 7)]
	public string TransportProfileUri
	{
		get
		{
			return m_transportProfileUri;
		}
		set
		{
			m_transportProfileUri = value;
		}
	}

	[DataMember(Name = "SecurityLevel", IsRequired = false, Order = 8)]
	public byte SecurityLevel
	{
		get
		{
			return m_securityLevel;
		}
		set
		{
			m_securityLevel = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.EndpointDescription;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.EndpointDescription_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.EndpointDescription_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.EndpointDescription_Encoding_DefaultJson;

	public EndpointDescription(string url)
	{
		Initialize();
		UriBuilder uriBuilder = new UriBuilder(url);
		if (uriBuilder.Scheme.StartsWith("http", StringComparison.Ordinal) && !uriBuilder.Path.EndsWith("/discovery"))
		{
			uriBuilder.Path += "/discovery";
		}
		Server.DiscoveryUrls.Add(uriBuilder.ToString());
		EndpointUrl = url;
		Server.ApplicationUri = url;
		Server.ApplicationName = url;
		SecurityMode = MessageSecurityMode.None;
		SecurityPolicyUri = "http://opcfoundation.org/UA/SecurityPolicy#None";
	}

	public UserTokenPolicy FindUserTokenPolicy(string policyId)
	{
		foreach (UserTokenPolicy userIdentityToken in m_userIdentityTokens)
		{
			if (userIdentityToken.PolicyId == policyId)
			{
				return userIdentityToken;
			}
		}
		return null;
	}

	public UserTokenPolicy FindUserTokenPolicy(UserTokenType tokenType, XmlQualifiedName issuedTokenType)
	{
		if (issuedTokenType == null)
		{
			return FindUserTokenPolicy(tokenType, (string)null);
		}
		return FindUserTokenPolicy(tokenType, issuedTokenType.Namespace);
	}

	public UserTokenPolicy FindUserTokenPolicy(UserTokenType tokenType, string issuedTokenType)
	{
		foreach (UserTokenPolicy userIdentityToken in m_userIdentityTokens)
		{
			if (tokenType == userIdentityToken.TokenType && !(issuedTokenType != userIdentityToken.IssuedTokenType))
			{
				return userIdentityToken;
			}
		}
		return null;
	}

	public EndpointDescription()
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
		m_endpointUrl = null;
		m_server = new ApplicationDescription();
		m_serverCertificate = null;
		m_securityMode = MessageSecurityMode.Invalid;
		m_securityPolicyUri = null;
		m_userIdentityTokens = new UserTokenPolicyCollection();
		m_transportProfileUri = null;
		m_securityLevel = 0;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteString("EndpointUrl", EndpointUrl);
		encoder.WriteEncodeable("Server", Server, typeof(ApplicationDescription));
		encoder.WriteByteString("ServerCertificate", ServerCertificate);
		encoder.WriteEnumerated("SecurityMode", SecurityMode);
		encoder.WriteString("SecurityPolicyUri", SecurityPolicyUri);
		encoder.WriteEncodeableArray("UserIdentityTokens", UserIdentityTokens.ToArray(), typeof(UserTokenPolicy));
		encoder.WriteString("TransportProfileUri", TransportProfileUri);
		encoder.WriteByte("SecurityLevel", SecurityLevel);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		EndpointUrl = decoder.ReadString("EndpointUrl");
		Server = (ApplicationDescription)decoder.ReadEncodeable("Server", typeof(ApplicationDescription));
		ServerCertificate = decoder.ReadByteString("ServerCertificate");
		SecurityMode = (MessageSecurityMode)(object)decoder.ReadEnumerated("SecurityMode", typeof(MessageSecurityMode));
		SecurityPolicyUri = decoder.ReadString("SecurityPolicyUri");
		UserIdentityTokens = (UserTokenPolicy[])decoder.ReadEncodeableArray("UserIdentityTokens", typeof(UserTokenPolicy));
		TransportProfileUri = decoder.ReadString("TransportProfileUri");
		SecurityLevel = decoder.ReadByte("SecurityLevel");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is EndpointDescription endpointDescription))
		{
			return false;
		}
		if (!Utils.IsEqual(m_endpointUrl, endpointDescription.m_endpointUrl))
		{
			return false;
		}
		if (!Utils.IsEqual(m_server, endpointDescription.m_server))
		{
			return false;
		}
		if (!Utils.IsEqual(m_serverCertificate, endpointDescription.m_serverCertificate))
		{
			return false;
		}
		if (!Utils.IsEqual(m_securityMode, endpointDescription.m_securityMode))
		{
			return false;
		}
		if (!Utils.IsEqual(m_securityPolicyUri, endpointDescription.m_securityPolicyUri))
		{
			return false;
		}
		if (!Utils.IsEqual(m_userIdentityTokens, endpointDescription.m_userIdentityTokens))
		{
			return false;
		}
		if (!Utils.IsEqual(m_transportProfileUri, endpointDescription.m_transportProfileUri))
		{
			return false;
		}
		if (!Utils.IsEqual(m_securityLevel, endpointDescription.m_securityLevel))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (EndpointDescription)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		EndpointDescription obj = (EndpointDescription)base.MemberwiseClone();
		obj.m_endpointUrl = (string)Utils.Clone(m_endpointUrl);
		obj.m_server = (ApplicationDescription)Utils.Clone(m_server);
		obj.m_serverCertificate = (byte[])Utils.Clone(m_serverCertificate);
		obj.m_securityMode = (MessageSecurityMode)Utils.Clone(m_securityMode);
		obj.m_securityPolicyUri = (string)Utils.Clone(m_securityPolicyUri);
		obj.m_userIdentityTokens = (UserTokenPolicyCollection)Utils.Clone(m_userIdentityTokens);
		obj.m_transportProfileUri = (string)Utils.Clone(m_transportProfileUri);
		obj.m_securityLevel = (byte)Utils.Clone(m_securityLevel);
		return obj;
	}
}
