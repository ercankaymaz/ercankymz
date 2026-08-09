using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class IssuedIdentityToken : UserIdentityToken
{
	private byte[] m_tokenData;

	private string m_encryptionAlgorithm;

	private byte[] m_decryptedTokenData;

	[DataMember(Name = "TokenData", IsRequired = false, Order = 1)]
	public byte[] TokenData
	{
		get
		{
			return m_tokenData;
		}
		set
		{
			m_tokenData = value;
		}
	}

	[DataMember(Name = "EncryptionAlgorithm", IsRequired = false, Order = 2)]
	public string EncryptionAlgorithm
	{
		get
		{
			return m_encryptionAlgorithm;
		}
		set
		{
			m_encryptionAlgorithm = value;
		}
	}

	public override ExpandedNodeId TypeId => DataTypeIds.IssuedIdentityToken;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.IssuedIdentityToken_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.IssuedIdentityToken_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.IssuedIdentityToken_Encoding_DefaultJson;

	public IssuedTokenType IssuedTokenType { get; set; }

	public byte[] DecryptedTokenData
	{
		get
		{
			return m_decryptedTokenData;
		}
		set
		{
			m_decryptedTokenData = value;
		}
	}

	public IssuedIdentityToken()
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
		m_tokenData = null;
		m_encryptionAlgorithm = null;
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteByteString("TokenData", TokenData);
		encoder.WriteString("EncryptionAlgorithm", EncryptionAlgorithm);
		encoder.PopNamespace();
	}

	public override void Decode(IDecoder decoder)
	{
		base.Decode(decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		TokenData = decoder.ReadByteString("TokenData");
		EncryptionAlgorithm = decoder.ReadString("EncryptionAlgorithm");
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is IssuedIdentityToken issuedIdentityToken))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_tokenData, issuedIdentityToken.m_tokenData))
		{
			return false;
		}
		if (!Utils.IsEqual(m_encryptionAlgorithm, issuedIdentityToken.m_encryptionAlgorithm))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (IssuedIdentityToken)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		IssuedIdentityToken obj = (IssuedIdentityToken)base.MemberwiseClone();
		obj.m_tokenData = (byte[])Utils.Clone(m_tokenData);
		obj.m_encryptionAlgorithm = (string)Utils.Clone(m_encryptionAlgorithm);
		return obj;
	}

	public override void Encrypt(X509Certificate2 certificate, byte[] senderNonce, string securityPolicyUri)
	{
		if (string.IsNullOrEmpty(securityPolicyUri) || securityPolicyUri == "http://opcfoundation.org/UA/SecurityPolicy#None")
		{
			m_tokenData = m_decryptedTokenData;
			m_encryptionAlgorithm = string.Empty;
			return;
		}
		byte[] plainText = Utils.Append(m_decryptedTokenData, senderNonce);
		EncryptedData encryptedData = SecurityPolicies.Encrypt(certificate, securityPolicyUri, plainText);
		m_tokenData = encryptedData.Data;
		m_encryptionAlgorithm = encryptedData.Algorithm;
	}

	public override void Decrypt(X509Certificate2 certificate, byte[] senderNonce, string securityPolicyUri)
	{
		if (string.IsNullOrEmpty(securityPolicyUri) || securityPolicyUri == "http://opcfoundation.org/UA/SecurityPolicy#None")
		{
			m_decryptedTokenData = m_tokenData;
			return;
		}
		EncryptedData encryptedData = new EncryptedData();
		encryptedData.Data = m_tokenData;
		encryptedData.Algorithm = m_encryptionAlgorithm;
		byte[] array = SecurityPolicies.Decrypt(certificate, securityPolicyUri, encryptedData);
		int num = array.Length;
		if (senderNonce != null)
		{
			num -= senderNonce.Length;
			for (int i = 0; i < senderNonce.Length; i++)
			{
				if (senderNonce[i] != array[i + num])
				{
					throw new ServiceResultException(2149646336u);
				}
			}
		}
		m_decryptedTokenData = new byte[num];
		Array.Copy(array, m_decryptedTokenData, num);
	}

	public override SignatureData Sign(byte[] dataToSign, string securityPolicyUri)
	{
		return null;
	}

	public override bool Verify(byte[] dataToVerify, SignatureData signatureData, string securityPolicyUri)
	{
		return true;
	}
}
