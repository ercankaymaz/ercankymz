using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class EventNotificationList : NotificationData
{
	private EventFieldListCollection m_events;

	[DataMember(Name = "Events", IsRequired = false, Order = 1)]
	public EventFieldListCollection Events
	{
		get
		{
			return m_events;
		}
		set
		{
			m_events = value;
			if (value == null)
			{
				m_events = new EventFieldListCollection();
			}
		}
	}

	public override ExpandedNodeId TypeId => DataTypeIds.EventNotificationList;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.EventNotificationList_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.EventNotificationList_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.EventNotificationList_Encoding_DefaultJson;

	public EventNotificationList()
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
		m_events = new EventFieldListCollection();
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeableArray("Events", Events.ToArray(), typeof(EventFieldList));
		encoder.PopNamespace();
	}

	public override void Decode(IDecoder decoder)
	{
		base.Decode(decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		Events = (EventFieldList[])decoder.ReadEncodeableArray("Events", typeof(EventFieldList));
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is EventNotificationList eventNotificationList))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_events, eventNotificationList.m_events))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (EventNotificationList)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		EventNotificationList obj = (EventNotificationList)base.MemberwiseClone();
		obj.m_events = (EventFieldListCollection)Utils.Clone(m_events);
		return obj;
	}
}
