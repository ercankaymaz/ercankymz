using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class ObjectNode : InstanceNode, IObject, ILocalNode, INode
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

	public override ExpandedNodeId TypeId => DataTypeIds.ObjectNode;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.ObjectNode_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.ObjectNode_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.ObjectNode_Encoding_DefaultJson;

	public ObjectNode()
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
		if (!(encodeable is ObjectNode objectNode))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_eventNotifier, objectNode.m_eventNotifier))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (ObjectNode)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ObjectNode obj = (ObjectNode)base.MemberwiseClone();
		obj.m_eventNotifier = (byte)Utils.Clone(m_eventNotifier);
		return obj;
	}

	public ObjectNode(ILocalNode source)
		: base(source)
	{
		base.NodeClass = NodeClass.Object;
		if (source is IObject obj)
		{
			EventNotifier = obj.EventNotifier;
		}
	}

	public override bool SupportsAttribute(uint attributeId)
	{
		if (attributeId == 12)
		{
			return true;
		}
		return base.SupportsAttribute(attributeId);
	}

	protected override object Read(uint attributeId)
	{
		if (attributeId == 12)
		{
			return m_eventNotifier;
		}
		return base.Read(attributeId);
	}

	protected override ServiceResult Write(uint attributeId, object value)
	{
		if (attributeId == 12)
		{
			m_eventNotifier = (byte)value;
			return ServiceResult.Good;
		}
		return base.Write(attributeId, value);
	}
}
