using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class EphemeralKeyType : IEncodeable, ICloneable, IJsonEncodeable
{
	private byte[] m_publicKey;

	private byte[] m_signature;

	[DataMember(Name = "PublicKey", IsRequired = false, Order = 1)]
	public byte[] PublicKey
	{
		get
		{
			return m_publicKey;
		}
		set
		{
			m_publicKey = value;
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

	public virtual ExpandedNodeId TypeId => DataTypeIds.EphemeralKeyType;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.EphemeralKeyType_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.EphemeralKeyType_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.EphemeralKeyType_Encoding_DefaultJson;

	public EphemeralKeyType()
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
		m_publicKey = null;
		m_signature = null;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteByteString("PublicKey", PublicKey);
		encoder.WriteByteString("Signature", Signature);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		PublicKey = decoder.ReadByteString("PublicKey");
		Signature = decoder.ReadByteString("Signature");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is EphemeralKeyType ephemeralKeyType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_publicKey, ephemeralKeyType.m_publicKey))
		{
			return false;
		}
		if (!Utils.IsEqual(m_signature, ephemeralKeyType.m_signature))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (EphemeralKeyType)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		EphemeralKeyType obj = (EphemeralKeyType)base.MemberwiseClone();
		obj.m_publicKey = (byte[])Utils.Clone(m_publicKey);
		obj.m_signature = (byte[])Utils.Clone(m_signature);
		return obj;
	}
}
