using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class RationalNumber : IEncodeable, ICloneable, IJsonEncodeable
{
	private int m_numerator;

	private uint m_denominator;

	[DataMember(Name = "Numerator", IsRequired = false, Order = 1)]
	public int Numerator
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

	public virtual ExpandedNodeId TypeId => DataTypeIds.RationalNumber;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.RationalNumber_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.RationalNumber_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.RationalNumber_Encoding_DefaultJson;

	public RationalNumber()
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
		m_numerator = 0;
		m_denominator = 0u;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteInt32("Numerator", Numerator);
		encoder.WriteUInt32("Denominator", Denominator);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		Numerator = decoder.ReadInt32("Numerator");
		Denominator = decoder.ReadUInt32("Denominator");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is RationalNumber rationalNumber))
		{
			return false;
		}
		if (!Utils.IsEqual(m_numerator, rationalNumber.m_numerator))
		{
			return false;
		}
		if (!Utils.IsEqual(m_denominator, rationalNumber.m_denominator))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (RationalNumber)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		RationalNumber obj = (RationalNumber)base.MemberwiseClone();
		obj.m_numerator = (int)Utils.Clone(m_numerator);
		obj.m_denominator = (uint)Utils.Clone(m_denominator);
		return obj;
	}
}
