using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class ComplexNumberType : IEncodeable, ICloneable, IJsonEncodeable
{
	private float m_real;

	private float m_imaginary;

	[DataMember(Name = "Real", IsRequired = false, Order = 1)]
	public float Real
	{
		get
		{
			return m_real;
		}
		set
		{
			m_real = value;
		}
	}

	[DataMember(Name = "Imaginary", IsRequired = false, Order = 2)]
	public float Imaginary
	{
		get
		{
			return m_imaginary;
		}
		set
		{
			m_imaginary = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.ComplexNumberType;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.ComplexNumberType_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.ComplexNumberType_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.ComplexNumberType_Encoding_DefaultJson;

	public ComplexNumberType()
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
		m_real = 0f;
		m_imaginary = 0f;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteFloat("Real", Real);
		encoder.WriteFloat("Imaginary", Imaginary);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		Real = decoder.ReadFloat("Real");
		Imaginary = decoder.ReadFloat("Imaginary");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is ComplexNumberType complexNumberType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_real, complexNumberType.m_real))
		{
			return false;
		}
		if (!Utils.IsEqual(m_imaginary, complexNumberType.m_imaginary))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (ComplexNumberType)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ComplexNumberType obj = (ComplexNumberType)base.MemberwiseClone();
		obj.m_real = (float)Utils.Clone(m_real);
		obj.m_imaginary = (float)Utils.Clone(m_imaginary);
		return obj;
	}
}
