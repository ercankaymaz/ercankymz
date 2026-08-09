using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class XVType : IEncodeable, ICloneable, IJsonEncodeable
{
	private double m_x;

	private float m_value;

	[DataMember(Name = "X", IsRequired = false, Order = 1)]
	public double X
	{
		get
		{
			return m_x;
		}
		set
		{
			m_x = value;
		}
	}

	[DataMember(Name = "Value", IsRequired = false, Order = 2)]
	public float Value
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

	public virtual ExpandedNodeId TypeId => DataTypeIds.XVType;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.XVType_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.XVType_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.XVType_Encoding_DefaultJson;

	public XVType()
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
		m_x = 0.0;
		m_value = 0f;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteDouble("X", X);
		encoder.WriteFloat("Value", Value);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		X = decoder.ReadDouble("X");
		Value = decoder.ReadFloat("Value");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is XVType xVType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_x, xVType.m_x))
		{
			return false;
		}
		if (!Utils.IsEqual(m_value, xVType.m_value))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (XVType)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		XVType obj = (XVType)base.MemberwiseClone();
		obj.m_x = (double)Utils.Clone(m_x);
		obj.m_value = (float)Utils.Clone(m_value);
		return obj;
	}
}
