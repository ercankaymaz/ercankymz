using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class UpdateEventDetails : HistoryUpdateDetails
{
	private PerformUpdateType m_performInsertReplace;

	private EventFilter m_filter;

	private HistoryEventFieldListCollection m_eventData;

	[DataMember(Name = "PerformInsertReplace", IsRequired = false, Order = 1)]
	public PerformUpdateType PerformInsertReplace
	{
		get
		{
			return m_performInsertReplace;
		}
		set
		{
			m_performInsertReplace = value;
		}
	}

	[DataMember(Name = "Filter", IsRequired = false, Order = 2)]
	public EventFilter Filter
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
				m_filter = new EventFilter();
			}
		}
	}

	[DataMember(Name = "EventData", IsRequired = false, Order = 3)]
	public HistoryEventFieldListCollection EventData
	{
		get
		{
			return m_eventData;
		}
		set
		{
			m_eventData = value;
			if (value == null)
			{
				m_eventData = new HistoryEventFieldListCollection();
			}
		}
	}

	public override ExpandedNodeId TypeId => DataTypeIds.UpdateEventDetails;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.UpdateEventDetails_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.UpdateEventDetails_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.UpdateEventDetails_Encoding_DefaultJson;

	public UpdateEventDetails()
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
		m_performInsertReplace = PerformUpdateType.Insert;
		m_filter = new EventFilter();
		m_eventData = new HistoryEventFieldListCollection();
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEnumerated("PerformInsertReplace", PerformInsertReplace);
		encoder.WriteEncodeable("Filter", Filter, typeof(EventFilter));
		encoder.WriteEncodeableArray("EventData", EventData.ToArray(), typeof(HistoryEventFieldList));
		encoder.PopNamespace();
	}

	public override void Decode(IDecoder decoder)
	{
		base.Decode(decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		PerformInsertReplace = (PerformUpdateType)(object)decoder.ReadEnumerated("PerformInsertReplace", typeof(PerformUpdateType));
		Filter = (EventFilter)decoder.ReadEncodeable("Filter", typeof(EventFilter));
		EventData = (HistoryEventFieldList[])decoder.ReadEncodeableArray("EventData", typeof(HistoryEventFieldList));
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is UpdateEventDetails updateEventDetails))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_performInsertReplace, updateEventDetails.m_performInsertReplace))
		{
			return false;
		}
		if (!Utils.IsEqual(m_filter, updateEventDetails.m_filter))
		{
			return false;
		}
		if (!Utils.IsEqual(m_eventData, updateEventDetails.m_eventData))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (UpdateEventDetails)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		UpdateEventDetails obj = (UpdateEventDetails)base.MemberwiseClone();
		obj.m_performInsertReplace = (PerformUpdateType)Utils.Clone(m_performInsertReplace);
		obj.m_filter = (EventFilter)Utils.Clone(m_filter);
		obj.m_eventData = (HistoryEventFieldListCollection)Utils.Clone(m_eventData);
		return obj;
	}
}
