using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class UserIdentityToken : IEncodeable, ICloneable, IJsonEncodeable
{
	private string m_policyId;

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

	public virtual ExpandedNodeId TypeId => DataTypeIds.UserIdentityToken;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.UserIdentityToken_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.UserIdentityToken_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.UserIdentityToken_Encoding_DefaultJson;

	public UserIdentityToken()
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
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteString("PolicyId", PolicyId);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		PolicyId = decoder.ReadString("PolicyId");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is UserIdentityToken userIdentityToken))
		{
			return false;
		}
		if (!Utils.IsEqual(m_policyId, userIdentityToken.m_policyId))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (UserIdentityToken)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		UserIdentityToken obj = (UserIdentityToken)base.MemberwiseClone();
		obj.m_policyId = (string)Utils.Clone(m_policyId);
		return obj;
	}

	public virtual void Encrypt(X509Certificate2 certificate, byte[] receiverNonce, string securityPolicyUri)
	{
	}

	public virtual void Decrypt(X509Certificate2 certificate, byte[] receiverNonce, string securityPolicyUri)
	{
	}

	public virtual SignatureData Sign(byte[] dataToSign, string securityPolicyUri)
	{
		return new SignatureData();
	}

	public virtual bool Verify(byte[] dataToVerify, SignatureData signatureData, string securityPolicyUri)
	{
		return true;
	}
}
