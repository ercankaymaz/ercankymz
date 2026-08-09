using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class ThreeDFrame : Frame
{
	private ThreeDCartesianCoordinates m_cartesianCoordinates;

	private ThreeDOrientation m_orientation;

	[DataMember(Name = "CartesianCoordinates", IsRequired = false, Order = 1)]
	public ThreeDCartesianCoordinates CartesianCoordinates
	{
		get
		{
			return m_cartesianCoordinates;
		}
		set
		{
			m_cartesianCoordinates = value;
			if (value == null)
			{
				m_cartesianCoordinates = new ThreeDCartesianCoordinates();
			}
		}
	}

	[DataMember(Name = "Orientation", IsRequired = false, Order = 2)]
	public ThreeDOrientation Orientation
	{
		get
		{
			return m_orientation;
		}
		set
		{
			m_orientation = value;
			if (value == null)
			{
				m_orientation = new ThreeDOrientation();
			}
		}
	}

	public override ExpandedNodeId TypeId => DataTypeIds.ThreeDFrame;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.ThreeDFrame_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.ThreeDFrame_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.ThreeDFrame_Encoding_DefaultJson;

	public ThreeDFrame()
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
		m_cartesianCoordinates = new ThreeDCartesianCoordinates();
		m_orientation = new ThreeDOrientation();
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeable("CartesianCoordinates", CartesianCoordinates, typeof(ThreeDCartesianCoordinates));
		encoder.WriteEncodeable("Orientation", Orientation, typeof(ThreeDOrientation));
		encoder.PopNamespace();
	}

	public override void Decode(IDecoder decoder)
	{
		base.Decode(decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		CartesianCoordinates = (ThreeDCartesianCoordinates)decoder.ReadEncodeable("CartesianCoordinates", typeof(ThreeDCartesianCoordinates));
		Orientation = (ThreeDOrientation)decoder.ReadEncodeable("Orientation", typeof(ThreeDOrientation));
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is ThreeDFrame threeDFrame))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_cartesianCoordinates, threeDFrame.m_cartesianCoordinates))
		{
			return false;
		}
		if (!Utils.IsEqual(m_orientation, threeDFrame.m_orientation))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (ThreeDFrame)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ThreeDFrame obj = (ThreeDFrame)base.MemberwiseClone();
		obj.m_cartesianCoordinates = (ThreeDCartesianCoordinates)Utils.Clone(m_cartesianCoordinates);
		obj.m_orientation = (ThreeDOrientation)Utils.Clone(m_orientation);
		return obj;
	}
}
