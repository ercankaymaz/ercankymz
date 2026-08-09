using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class ThreeDCartesianCoordinates : CartesianCoordinates
{
	private double m_x;

	private double m_y;

	private double m_z;

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

	[DataMember(Name = "Y", IsRequired = false, Order = 2)]
	public double Y
	{
		get
		{
			return m_y;
		}
		set
		{
			m_y = value;
		}
	}

	[DataMember(Name = "Z", IsRequired = false, Order = 3)]
	public double Z
	{
		get
		{
			return m_z;
		}
		set
		{
			m_z = value;
		}
	}

	public override ExpandedNodeId TypeId => DataTypeIds.ThreeDCartesianCoordinates;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.ThreeDCartesianCoordinates_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.ThreeDCartesianCoordinates_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.ThreeDCartesianCoordinates_Encoding_DefaultJson;

	public ThreeDCartesianCoordinates()
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
		m_y = 0.0;
		m_z = 0.0;
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteDouble("X", X);
		encoder.WriteDouble("Y", Y);
		encoder.WriteDouble("Z", Z);
		encoder.PopNamespace();
	}

	public override void Decode(IDecoder decoder)
	{
		base.Decode(decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		X = decoder.ReadDouble("X");
		Y = decoder.ReadDouble("Y");
		Z = decoder.ReadDouble("Z");
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is ThreeDCartesianCoordinates threeDCartesianCoordinates))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_x, threeDCartesianCoordinates.m_x))
		{
			return false;
		}
		if (!Utils.IsEqual(m_y, threeDCartesianCoordinates.m_y))
		{
			return false;
		}
		if (!Utils.IsEqual(m_z, threeDCartesianCoordinates.m_z))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (ThreeDCartesianCoordinates)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ThreeDCartesianCoordinates obj = (ThreeDCartesianCoordinates)base.MemberwiseClone();
		obj.m_x = (double)Utils.Clone(m_x);
		obj.m_y = (double)Utils.Clone(m_y);
		obj.m_z = (double)Utils.Clone(m_z);
		return obj;
	}
}
