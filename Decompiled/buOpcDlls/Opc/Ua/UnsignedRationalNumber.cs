using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class UnsignedRationalNumber : IEncodeable, ICloneable, IJsonEncodeable
{
	private uint m_numerator;

	private uint m_denominator;

	[DataMember(Name = "Numerator", IsRequired = false, Order = 1)]
	public uint Numerator
	{
		get
		{
			return m_numerator;
		}
		set
		{
			m_numerator = value;
		}
	}

	[DataMember(Name = "Denominator", IsRequired = false, Order = 2)]
	public uint Denominator
	{
		get
		{
			return m_denominator;
		}
		set
		{
			m_denominator = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.UnsignedRationalNumber;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.UnsignedRationalNumber_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.UnsignedRationalNumber_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.UnsignedRationalNumber_Encoding_DefaultJson;

	public UnsignedRationalNumber()
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
		m_numerator = 0u;
		m_denominator = 0u;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteUInt32("Numerator", Numerator);
		encoder.WriteUInt32("Denominator", Denominator);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		Numerator = decoder.ReadUInt32("Numerator");
		Denominator = decoder.ReadUInt32("Denominator");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is UnsignedRationalNumber unsignedRationalNumber))
		{
			return false;
		}
		if (!Utils.IsEqual(m_numerator, unsignedRationalNumber.m_numerator))
		{
			return false;
		}
		if (!Utils.IsEqual(m_denominator, unsignedRationalNumber.m_denominator))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (UnsignedRationalNumber)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		UnsignedRationalNumber obj = (UnsignedRationalNumber)base.MemberwiseClone();
		obj.m_numerator = (uint)Utils.Clone(m_numerator);
		obj.m_denominator = (uint)Utils.Clone(m_denominator);
		return obj;
	}
}
