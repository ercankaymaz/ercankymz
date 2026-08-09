using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class ViewAttributes : NodeAttributes
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

	public override ExpandedNodeId TypeId => DataTypeIds.ViewAttributes;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.ViewAttributes_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.ViewAttributes_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.ViewAttributes_Encoding_DefaultJson;

	public ViewAttributes()
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
		if (!(encodeable is ViewAttributes viewAttributes))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_containsNoLoops, viewAttributes.m_containsNoLoops))
		{
			return false;
		}
		if (!Utils.IsEqual(m_eventNotifier, viewAttributes.m_eventNotifier))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (ViewAttributes)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ViewAttributes obj = (ViewAttributes)base.MemberwiseClone();
		obj.m_containsNoLoops = (bool)Utils.Clone(m_containsNoLoops);
		obj.m_eventNotifier = (byte)Utils.Clone(m_eventNotifier);
		return obj;
	}
}
