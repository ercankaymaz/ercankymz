using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class UserTokenPolicy : IEncodeable, ICloneable, IJsonEncodeable, IFormattable
{
	private string m_policyId;

	private UserTokenType m_tokenType;

	private string m_issuedTokenType;

	private string m_issuerEndpointUrl;

	private string m_securityPolicyUri;

	[DataMember(Name = "PolicyId", IsRequired = false, Order = 1)]
	public string PolicyId
	{
		get
		{
			return m_policyId;
		}
		set
		{
			m_policyId = value;
		}
	}

	[DataMember(Name = "TokenType", IsRequired = false, Order = 2)]
	public UserTokenType TokenType
	{
		get
		{
			return m_tokenType;
		}
		set
		{
			m_tokenType = value;
		}
	}

	[DataMember(Name = "IssuedTokenType", IsRequired = false, Order = 3)]
	public string IssuedTokenType
	{
		get
		{
			return m_issuedTokenType;
		}
		set
		{
			m_issuedTokenType = value;
		}
	}

	[DataMember(Name = "IssuerEndpointUrl", IsRequired = false, Order = 4)]
	public string IssuerEndpointUrl
	{
		get
		{
			return m_issuerEndpointUrl;
		}
		set
		{
			m_issuerEndpointUrl = value;
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

	public virtual ExpandedNodeId TypeId => DataTypeIds.UserTokenPolicy;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.UserTokenPolicy_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.UserTokenPolicy_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.UserTokenPolicy_Encoding_DefaultJson;

	public UserTokenPolicy()
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
		m_policyId = null;
		m_tokenType = UserTokenType.Anonymous;
		m_issuedTokenType = null;
		m_issuerEndpointUrl = null;
		m_securityPolicyUri = null;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteString("PolicyId", PolicyId);
		encoder.WriteEnumerated("TokenType", TokenType);
		encoder.WriteString("IssuedTokenType", IssuedTokenType);
		encoder.WriteString("IssuerEndpointUrl", IssuerEndpointUrl);
		encoder.WriteString("SecurityPolicyUri", SecurityPolicyUri);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		PolicyId = decoder.ReadString("PolicyId");
		TokenType = (UserTokenType)(object)decoder.ReadEnumerated("TokenType", typeof(UserTokenType));
		IssuedTokenType = decoder.ReadString("IssuedTokenType");
		IssuerEndpointUrl = decoder.ReadString("IssuerEndpointUrl");
		SecurityPolicyUri = decoder.ReadString("SecurityPolicyUri");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is UserTokenPolicy userTokenPolicy))
		{
			return false;
		}
		if (!Utils.IsEqual(m_policyId, userTokenPolicy.m_policyId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_tokenType, userTokenPolicy.m_tokenType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_issuedTokenType, userTokenPolicy.m_issuedTokenType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_issuerEndpointUrl, userTokenPolicy.m_issuerEndpointUrl))
		{
			return false;
		}
		if (!Utils.IsEqual(m_securityPolicyUri, userTokenPolicy.m_securityPolicyUri))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (UserTokenPolicy)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		UserTokenPolicy obj = (UserTokenPolicy)base.MemberwiseClone();
		obj.m_policyId = (string)Utils.Clone(m_policyId);
		obj.m_tokenType = (UserTokenType)Utils.Clone(m_tokenType);
		obj.m_issuedTokenType = (string)Utils.Clone(m_issuedTokenType);
		obj.m_issuerEndpointUrl = (string)Utils.Clone(m_issuerEndpointUrl);
		obj.m_securityPolicyUri = (string)Utils.Clone(m_securityPolicyUri);
		return obj;
	}

	public UserTokenPolicy(UserTokenType tokenType)
	{
		Initialize();
		m_tokenType = tokenType;
	}

	public override string ToString()
	{
		return m_tokenType.ToString();
	}

	public string ToString(string format, IFormatProvider formatProvider)
	{
		if (format == null)
		{
			return string.Format(formatProvider, "{0}", ToString());
		}
		throw new FormatException(Utils.Format("Invalid format string: '{0}'.", format));
	}
}
