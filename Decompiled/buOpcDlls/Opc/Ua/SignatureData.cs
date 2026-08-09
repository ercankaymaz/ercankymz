using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class SignatureData : IEncodeable, ICloneable, IJsonEncodeable
{
	private string m_algorithm;

	private byte[] m_signature;

	[DataMember(Name = "Algorithm", IsRequired = false, Order = 1)]
	public string Algorithm
	{
		get
		{
			return m_algorithm;
		}
		set
		{
			m_algorithm = value;
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

	public virtual ExpandedNodeId TypeId => DataTypeIds.SignatureData;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.SignatureData_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.SignatureData_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.SignatureData_Encoding_DefaultJson;

	public SignatureData()
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
		m_algorithm = null;
		m_signature = null;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteString("Algorithm", Algorithm);
		encoder.WriteByteString("Signature", Signature);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		Algorithm = decoder.ReadString("Algorithm");
		Signature = decoder.ReadByteString("Signature");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is SignatureData signatureData))
		{
			return false;
		}
		if (!Utils.IsEqual(m_algorithm, signatureData.m_algorithm))
		{
			return false;
		}
		if (!Utils.IsEqual(m_signature, signatureData.m_signature))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (SignatureData)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		SignatureData obj = (SignatureData)base.MemberwiseClone();
		obj.m_algorithm = (string)Utils.Clone(m_algorithm);
		obj.m_signature = (byte[])Utils.Clone(m_signature);
		return obj;
	}
}
