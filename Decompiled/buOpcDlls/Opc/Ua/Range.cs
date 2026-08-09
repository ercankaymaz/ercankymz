using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class Range : IEncodeable, ICloneable, IJsonEncodeable
{
	private double m_low;

	private double m_high;

	[DataMember(Name = "Low", IsRequired = false, Order = 1)]
	public double Low
	{
		get
		{
			return m_low;
		}
		set
		{
			m_low = value;
		}
	}

	[DataMember(Name = "High", IsRequired = false, Order = 2)]
	public double High
	{
		get
		{
			return m_high;
		}
		set
		{
			m_high = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.Range;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.Range_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.Range_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.Range_Encoding_DefaultJson;

	public double Magnitude => Math.Abs(m_high - m_low);

	public Range()
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
		m_low = 0.0;
		m_high = 0.0;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteDouble("Low", Low);
		encoder.WriteDouble("High", High);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		Low = decoder.ReadDouble("Low");
		High = decoder.ReadDouble("High");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is Range range))
		{
			return false;
		}
		if (!Utils.IsEqual(m_low, range.m_low))
		{
			return false;
		}
		if (!Utils.IsEqual(m_high, range.m_high))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (Range)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		Range obj = (Range)base.MemberwiseClone();
		obj.m_low = (double)Utils.Clone(m_low);
		obj.m_high = (double)Utils.Clone(m_high);
		return obj;
	}

	public Range(double high, double low)
	{
		m_low = low;
		m_high = high;
		if (low > high)
		{
			m_high = low;
			m_low = high;
		}
	}
}
