using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class SignedSoftwareCertificate : IEncodeable, ICloneable, IJsonEncodeable
{
	private byte[] m_certificateData;

	private byte[] m_signature;

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

	[DataMember(Name = "Signature", IsRequired = false, Order = 2)]
	public byte[] Signature
	{
		get
		{
			return m_signature;
		}
		set
		{
			m_signature = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.SignedSoftwareCertificate;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.SignedSoftwareCertificate_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.SignedSoftwareCertificate_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.SignedSoftwareCertificate_Encoding_DefaultJson;

	public SignedSoftwareCertificate()
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
		m_signature = null;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteByteString("CertificateData", CertificateData);
		encoder.WriteByteString("Signature", Signature);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		CertificateData = decoder.ReadByteString("CertificateData");
		Signature = decoder.ReadByteString("Signature");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is SignedSoftwareCertificate signedSoftwareCertificate))
		{
			return false;
		}
		if (!Utils.IsEqual(m_certificateData, signedSoftwareCertificate.m_certificateData))
		{
			return false;
		}
		if (!Utils.IsEqual(m_signature, signedSoftwareCertificate.m_signature))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (SignedSoftwareCertificate)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		SignedSoftwareCertificate obj = (SignedSoftwareCertificate)base.MemberwiseClone();
		obj.m_certificateData = (byte[])Utils.Clone(m_certificateData);
		obj.m_signature = (byte[])Utils.Clone(m_signature);
		return obj;
	}
}
