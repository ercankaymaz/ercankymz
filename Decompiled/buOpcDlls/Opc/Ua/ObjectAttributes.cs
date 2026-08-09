using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class ObjectAttributes : NodeAttributes
{
	private byte m_eventNotifier;

	[DataMember(Name = "EventNotifier", IsRequired = false, Order = 1)]
	public byte EventNotifier
	{
		get
		{
			return m_eventNotifier;
		}
		set
		{
			m_eventNotifier = value;
		}
	}

	public override ExpandedNodeId TypeId => DataTypeIds.ObjectAttributes;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.ObjectAttributes_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.ObjectAttributes_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.ObjectAttributes_Encoding_DefaultJson;

	public ObjectAttributes()
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
		m_eventNotifier = 0;
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteByte("EventNotifier", EventNotifier);
		encoder.PopNamespace();
	}

	public override void Decode(IDecoder decoder)
	{
		base.Decode(decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		EventNotifier = decoder.ReadByte("EventNotifier");
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is ObjectAttributes objectAttributes))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_eventNotifier, objectAttributes.m_eventNotifier))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (ObjectAttributes)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ObjectAttributes obj = (ObjectAttributes)base.MemberwiseClone();
		obj.m_eventNotifier = (byte)Utils.Clone(m_eventNotifier);
		return obj;
	}
}
