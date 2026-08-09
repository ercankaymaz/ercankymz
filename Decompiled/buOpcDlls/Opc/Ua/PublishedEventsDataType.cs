using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class PublishedEventsDataType : PublishedDataSetSourceDataType
{
	private NodeId m_eventNotifier;

	private SimpleAttributeOperandCollection m_selectedFields;

	private ContentFilter m_filter;

	[DataMember(Name = "EventNotifier", IsRequired = false, Order = 1)]
	public NodeId EventNotifier
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

	[DataMember(Name = "SelectedFields", IsRequired = false, Order = 2)]
	public SimpleAttributeOperandCollection SelectedFields
	{
		get
		{
			return m_selectedFields;
		}
		set
		{
			m_selectedFields = value;
			if (value == null)
			{
				m_selectedFields = new SimpleAttributeOperandCollection();
			}
		}
	}

	[DataMember(Name = "Filter", IsRequired = false, Order = 3)]
	public ContentFilter Filter
	{
		get
		{
			return m_filter;
		}
		set
		{
			m_filter = value;
			if (value == null)
			{
				m_filter = new ContentFilter();
			}
		}
	}

	public override ExpandedNodeId TypeId => DataTypeIds.PublishedEventsDataType;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.PublishedEventsDataType_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.PublishedEventsDataType_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.PublishedEventsDataType_Encoding_DefaultJson;

	public PublishedEventsDataType()
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
		m_eventNotifier = null;
		m_selectedFields = new SimpleAttributeOperandCollection();
		m_filter = new ContentFilter();
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteNodeId("EventNotifier", EventNotifier);
		encoder.WriteEncodeableArray("SelectedFields", SelectedFields.ToArray(), typeof(SimpleAttributeOperand));
		encoder.WriteEncodeable("Filter", Filter, typeof(ContentFilter));
		encoder.PopNamespace();
	}

	public override void Decode(IDecoder decoder)
	{
		base.Decode(decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		EventNotifier = decoder.ReadNodeId("EventNotifier");
		SelectedFields = (SimpleAttributeOperand[])decoder.ReadEncodeableArray("SelectedFields", typeof(SimpleAttributeOperand));
		Filter = (ContentFilter)decoder.ReadEncodeable("Filter", typeof(ContentFilter));
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is PublishedEventsDataType publishedEventsDataType))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_eventNotifier, publishedEventsDataType.m_eventNotifier))
		{
			return false;
		}
		if (!Utils.IsEqual(m_selectedFields, publishedEventsDataType.m_selectedFields))
		{
			return false;
		}
		if (!Utils.IsEqual(m_filter, publishedEventsDataType.m_filter))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (PublishedEventsDataType)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		PublishedEventsDataType obj = (PublishedEventsDataType)base.MemberwiseClone();
		obj.m_eventNotifier = (NodeId)Utils.Clone(m_eventNotifier);
		obj.m_selectedFields = (SimpleAttributeOperandCollection)Utils.Clone(m_selectedFields);
		obj.m_filter = (ContentFilter)Utils.Clone(m_filter);
		return obj;
	}
}
