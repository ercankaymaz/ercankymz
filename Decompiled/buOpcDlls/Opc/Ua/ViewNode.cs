using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class ViewNode : InstanceNode, IView, ILocalNode, INode
{
	private bool m_containsNoLoops;

	private byte m_eventNotifier;

	[DataMember(Name = "ContainsNoLoops", IsRequired = false, Order = 1)]
	public bool ContainsNoLoops
	{
		get
		{
			return m_containsNoLoops;
		}
		set
		{
			m_containsNoLoops = value;
		}
	}

	[DataMember(Name = "EventNotifier", IsRequired = false, Order = 2)]
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

	public override ExpandedNodeId TypeId => DataTypeIds.ViewNode;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.ViewNode_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.ViewNode_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.ViewNode_Encoding_DefaultJson;

	public ViewNode()
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
		m_containsNoLoops = true;
		m_eventNotifier = 0;
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteBoolean("ContainsNoLoops", ContainsNoLoops);
		encoder.WriteByte("EventNotifier", EventNotifier);
		encoder.PopNamespace();
	}

	public override void Decode(IDecoder decoder)
	{
		base.Decode(decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		ContainsNoLoops = decoder.ReadBoolean("ContainsNoLoops");
		EventNotifier = decoder.ReadByte("EventNotifier");
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is ViewNode viewNode))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_containsNoLoops, viewNode.m_containsNoLoops))
		{
			return false;
		}
		if (!Utils.IsEqual(m_eventNotifier, viewNode.m_eventNotifier))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (ViewNode)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ViewNode obj = (ViewNode)base.MemberwiseClone();
		obj.m_containsNoLoops = (bool)Utils.Clone(m_containsNoLoops);
		obj.m_eventNotifier = (byte)Utils.Clone(m_eventNotifier);
		return obj;
	}

	public ViewNode(ILocalNode source)
		: base(source)
	{
		base.NodeClass = NodeClass.View;
		if (source is IView view)
		{
			EventNotifier = view.EventNotifier;
			ContainsNoLoops = view.ContainsNoLoops;
		}
	}

	public override bool SupportsAttribute(uint attributeId)
	{
		if (attributeId - 11 <= 1)
		{
			return true;
		}
		return base.SupportsAttribute(attributeId);
	}

	protected override object Read(uint attributeId)
	{
		return attributeId switch
		{
			12u => m_eventNotifier, 
			11u => m_containsNoLoops, 
			_ => base.Read(attributeId), 
		};
	}

	protected override ServiceResult Write(uint attributeId, object value)
	{
		switch (attributeId)
		{
		case 12u:
			m_eventNotifier = (byte)value;
			return ServiceResult.Good;
		case 11u:
			m_containsNoLoops = (bool)value;
			return ServiceResult.Good;
		default:
			return base.Write(attributeId, value);
		}
	}
}
