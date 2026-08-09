using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class DoubleComplexNumberType : IEncodeable, ICloneable, IJsonEncodeable
{
	private double m_real;

	private double m_imaginary;

	[DataMember(Name = "Real", IsRequired = false, Order = 1)]
	public double Real
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
	public double Imaginary
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

	public virtual ExpandedNodeId TypeId => DataTypeIds.DoubleComplexNumberType;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.DoubleComplexNumberType_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.DoubleComplexNumberType_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.DoubleComplexNumberType_Encoding_DefaultJson;

	public DoubleComplexNumberType()
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
		m_real = 0.0;
		m_imaginary = 0.0;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteDouble("Real", Real);
		encoder.WriteDouble("Imaginary", Imaginary);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		Real = decoder.ReadDouble("Real");
		Imaginary = decoder.ReadDouble("Imaginary");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is DoubleComplexNumberType doubleComplexNumberType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_real, doubleComplexNumberType.m_real))
		{
			return false;
		}
		if (!Utils.IsEqual(m_imaginary, doubleComplexNumberType.m_imaginary))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (DoubleComplexNumberType)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		DoubleComplexNumberType obj = (DoubleComplexNumberType)base.MemberwiseClone();
		obj.m_real = (double)Utils.Clone(m_real);
		obj.m_imaginary = (double)Utils.Clone(m_imaginary);
		return obj;
	}
}
