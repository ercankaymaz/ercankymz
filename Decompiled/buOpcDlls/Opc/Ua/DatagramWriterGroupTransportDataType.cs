using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class DatagramWriterGroupTransportDataType : WriterGroupTransportDataType
{
	private byte m_messageRepeatCount;

	private double m_messageRepeatDelay;

	[DataMember(Name = "MessageRepeatCount", IsRequired = false, Order = 1)]
	public byte MessageRepeatCount
	{
		get
		{
			return m_messageRepeatCount;
		}
		set
		{
			m_messageRepeatCount = value;
		}
	}

	[DataMember(Name = "MessageRepeatDelay", IsRequired = false, Order = 2)]
	public double MessageRepeatDelay
	{
		get
		{
			return m_messageRepeatDelay;
		}
		set
		{
			m_messageRepeatDelay = value;
		}
	}

	public override ExpandedNodeId TypeId => DataTypeIds.DatagramWriterGroupTransportDataType;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.DatagramWriterGroupTransportDataType_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.DatagramWriterGroupTransportDataType_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.DatagramWriterGroupTransportDataType_Encoding_DefaultJson;

	public DatagramWriterGroupTransportDataType()
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
		m_messageRepeatCount = 0;
		m_messageRepeatDelay = 0.0;
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteByte("MessageRepeatCount", MessageRepeatCount);
		encoder.WriteDouble("MessageRepeatDelay", MessageRepeatDelay);
		encoder.PopNamespace();
	}

	public override void Decode(IDecoder decoder)
	{
		base.Decode(decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		MessageRepeatCount = decoder.ReadByte("MessageRepeatCount");
		MessageRepeatDelay = decoder.ReadDouble("MessageRepeatDelay");
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is DatagramWriterGroupTransportDataType datagramWriterGroupTransportDataType))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_messageRepeatCount, datagramWriterGroupTransportDataType.m_messageRepeatCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_messageRepeatDelay, datagramWriterGroupTransportDataType.m_messageRepeatDelay))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (DatagramWriterGroupTransportDataType)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		DatagramWriterGroupTransportDataType obj = (DatagramWriterGroupTransportDataType)base.MemberwiseClone();
		obj.m_messageRepeatCount = (byte)Utils.Clone(m_messageRepeatCount);
		obj.m_messageRepeatDelay = (double)Utils.Clone(m_messageRepeatDelay);
		return obj;
	}
}
