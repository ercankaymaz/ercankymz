using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class ThreeDOrientation : Orientation
{
	private double m_a;

	private double m_b;

	private double m_c;

	[DataMember(Name = "A", IsRequired = false, Order = 1)]
	public double A
	{
		get
		{
			return m_a;
		}
		set
		{
			m_a = value;
		}
	}

	[DataMember(Name = "B", IsRequired = false, Order = 2)]
	public double B
	{
		get
		{
			return m_b;
		}
		set
		{
			m_b = value;
		}
	}

	[DataMember(Name = "C", IsRequired = false, Order = 3)]
	public double C
	{
		get
		{
			return m_c;
		}
		set
		{
			m_c = value;
		}
	}

	public override ExpandedNodeId TypeId => DataTypeIds.ThreeDOrientation;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.ThreeDOrientation_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.ThreeDOrientation_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.ThreeDOrientation_Encoding_DefaultJson;

	public ThreeDOrientation()
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
		m_a = 0.0;
		m_b = 0.0;
		m_c = 0.0;
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteDouble("A", A);
		encoder.WriteDouble("B", B);
		encoder.WriteDouble("C", C);
		encoder.PopNamespace();
	}

	public override void Decode(IDecoder decoder)
	{
		base.Decode(decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		A = decoder.ReadDouble("A");
		B = decoder.ReadDouble("B");
		C = decoder.ReadDouble("C");
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is ThreeDOrientation threeDOrientation))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_a, threeDOrientation.m_a))
		{
			return false;
		}
		if (!Utils.IsEqual(m_b, threeDOrientation.m_b))
		{
			return false;
		}
		if (!Utils.IsEqual(m_c, threeDOrientation.m_c))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (ThreeDOrientation)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ThreeDOrientation obj = (ThreeDOrientation)base.MemberwiseClone();
		obj.m_a = (double)Utils.Clone(m_a);
		obj.m_b = (double)Utils.Clone(m_b);
		obj.m_c = (double)Utils.Clone(m_c);
		return obj;
	}
}
