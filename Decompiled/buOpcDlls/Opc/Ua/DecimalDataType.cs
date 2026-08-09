using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class DecimalDataType : IEncodeable, ICloneable, IJsonEncodeable
{
	private short m_scale;

	private byte[] m_value;

	[DataMember(Name = "Scale", IsRequired = false, Order = 1)]
	public short Scale
	{
		get
		{
			return m_scale;
		}
		set
		{
			m_scale = value;
		}
	}

	[DataMember(Name = "Value", IsRequired = false, Order = 2)]
	public byte[] Value
	{
		get
		{
			return m_value;
		}
		set
		{
			m_value = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.DecimalDataType;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.DecimalDataType_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.DecimalDataType_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.DecimalDataType_Encoding_DefaultJson;

	public DecimalDataType()
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
		m_scale = 0;
		m_value = null;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteInt16("Scale", Scale);
		encoder.WriteByteString("Value", Value);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		Scale = decoder.ReadInt16("Scale");
		Value = decoder.ReadByteString("Value");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is DecimalDataType decimalDataType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_scale, decimalDataType.m_scale))
		{
			return false;
		}
		if (!Utils.IsEqual(m_value, decimalDataType.m_value))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (DecimalDataType)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		DecimalDataType obj = (DecimalDataType)base.MemberwiseClone();
		obj.m_scale = (short)Utils.Clone(m_scale);
		obj.m_value = (byte[])Utils.Clone(m_value);
		return obj;
	}
}
