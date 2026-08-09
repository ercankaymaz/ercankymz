using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class ReadEventDetails : HistoryReadDetails
{
	private uint m_numValuesPerNode;

	private DateTime m_startTime;

	private DateTime m_endTime;

	private EventFilter m_filter;

	[DataMember(Name = "NumValuesPerNode", IsRequired = false, Order = 1)]
	public uint NumValuesPerNode
	{
		get
		{
			return m_numValuesPerNode;
		}
		set
		{
			m_numValuesPerNode = value;
		}
	}

	[DataMember(Name = "StartTime", IsRequired = false, Order = 2)]
	public DateTime StartTime
	{
		get
		{
			return m_startTime;
		}
		set
		{
			m_startTime = value;
		}
	}

	[DataMember(Name = "EndTime", IsRequired = false, Order = 3)]
	public DateTime EndTime
	{
		get
		{
			return m_endTime;
		}
		set
		{
			m_endTime = value;
		}
	}

	[DataMember(Name = "Filter", IsRequired = false, Order = 4)]
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

	public override ExpandedNodeId TypeId => DataTypeIds.ReadEventDetails;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.ReadEventDetails_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.ReadEventDetails_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.ReadEventDetails_Encoding_DefaultJson;

	public ReadEventDetails()
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
		m_numValuesPerNode = 0u;
		m_startTime = DateTime.MinValue;
		m_endTime = DateTime.MinValue;
		m_filter = new EventFilter();
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteUInt32("NumValuesPerNode", NumValuesPerNode);
		encoder.WriteDateTime("StartTime", StartTime);
		encoder.WriteDateTime("EndTime", EndTime);
		encoder.WriteEncodeable("Filter", Filter, typeof(EventFilter));
		encoder.PopNamespace();
	}

	public override void Decode(IDecoder decoder)
	{
		base.Decode(decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		NumValuesPerNode = decoder.ReadUInt32("NumValuesPerNode");
		StartTime = decoder.ReadDateTime("StartTime");
		EndTime = decoder.ReadDateTime("EndTime");
		Filter = (EventFilter)decoder.ReadEncodeable("Filter", typeof(EventFilter));
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is ReadEventDetails readEventDetails))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_numValuesPerNode, readEventDetails.m_numValuesPerNode))
		{
			return false;
		}
		if (!Utils.IsEqual(m_startTime, readEventDetails.m_startTime))
		{
			return false;
		}
		if (!Utils.IsEqual(m_endTime, readEventDetails.m_endTime))
		{
			return false;
		}
		if (!Utils.IsEqual(m_filter, readEventDetails.m_filter))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (ReadEventDetails)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ReadEventDetails obj = (ReadEventDetails)base.MemberwiseClone();
		obj.m_numValuesPerNode = (uint)Utils.Clone(m_numValuesPerNode);
		obj.m_startTime = (DateTime)Utils.Clone(m_startTime);
		obj.m_endTime = (DateTime)Utils.Clone(m_endTime);
		obj.m_filter = (EventFilter)Utils.Clone(m_filter);
		return obj;
	}
}
