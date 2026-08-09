using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class X509IdentityToken : UserIdentityToken
{
	private byte[] m_certificateData;

	private X509Certificate2 m_certificate;

	[DataMember(Name = "CertificateData", IsRequired = false, Order = 1)]
	public byte[] CertificateData
	{
		get
		{
			return m_certificateData;
		}
		set
		{
			m_certificateData = value;
		}
	}

	public override ExpandedNodeId TypeId => DataTypeIds.X509IdentityToken;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.X509IdentityToken_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.X509IdentityToken_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.X509IdentityToken_Encoding_DefaultJson;

	public X509Certificate2 Certificate
	{
		get
		{
			if (m_certificate == null && m_certificateData != null)
			{
				return CertificateFactory.Create(m_certificateData, useCache: true);
			}
			return m_certificate;
		}
		set
		{
			m_certificate = value;
		}
	}

	public X509IdentityToken()
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
		m_certificateData = null;
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteByteString("CertificateData", CertificateData);
		encoder.PopNamespace();
	}

	public override void Decode(IDecoder decoder)
	{
		base.Decode(decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		CertificateData = decoder.ReadByteString("CertificateData");
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is X509IdentityToken x509IdentityToken))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_certificateData, x509IdentityToken.m_certificateData))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (X509IdentityToken)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		X509IdentityToken obj = (X509IdentityToken)base.MemberwiseClone();
		obj.m_certificateData = (byte[])Utils.Clone(m_certificateData);
		return obj;
	}

	public override SignatureData Sign(byte[] dataToSign, string securityPolicyUri)
	{
		X509Certificate2 x509Certificate = m_certificate;
		if (x509Certificate == null)
		{
			x509Certificate = CertificateFactory.Create(m_certificateData, useCache: true);
		}
		SignatureData result = SecurityPolicies.Sign(x509Certificate, securityPolicyUri, dataToSign);
		m_certificateData = x509Certificate.RawData;
		return result;
	}

	public override bool Verify(byte[] dataToVerify, SignatureData signatureData, string securityPolicyUri)
	{
		try
		{
			X509Certificate2 x509Certificate = m_certificate;
			if (x509Certificate == null)
			{
				x509Certificate = CertificateFactory.Create(m_certificateData, useCache: true);
			}
			bool result = SecurityPolicies.Verify(x509Certificate, securityPolicyUri, dataToVerify, signatureData);
			m_certificateData = x509Certificate.RawData;
			return result;
		}
		catch (Exception e)
		{
			throw ServiceResultException.Create(2149580800u, e, "Could not verify user signature!");
		}
	}
}
