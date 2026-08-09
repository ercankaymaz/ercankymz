using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class HistoryEvent : IEncodeable, ICloneable, IJsonEncodeable
{
	private HistoryEventFieldListCollection m_events;

	[DataMember(Name = "Events", IsRequired = false, Order = 1)]
	public HistoryEventFieldListCollection Events
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
				m_events = new HistoryEventFieldListCollection();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.HistoryEvent;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.HistoryEvent_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.HistoryEvent_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.HistoryEvent_Encoding_DefaultJson;

	public HistoryEvent()
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
		m_events = new HistoryEventFieldListCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeableArray("Events", Events.ToArray(), typeof(HistoryEventFieldList));
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		Events = (HistoryEventFieldList[])decoder.ReadEncodeableArray("Events", typeof(HistoryEventFieldList));
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is HistoryEvent historyEvent))
		{
			return false;
		}
		if (!Utils.IsEqual(m_events, historyEvent.m_events))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (HistoryEvent)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		HistoryEvent obj = (HistoryEvent)base.MemberwiseClone();
		obj.m_events = (HistoryEventFieldListCollection)Utils.Clone(m_events);
		return obj;
	}
}
