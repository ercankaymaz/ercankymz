using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class ReadProcessedDetails : HistoryReadDetails
{
	private DateTime m_startTime;

	private DateTime m_endTime;

	private double m_processingInterval;

	private NodeIdCollection m_aggregateType;

	private AggregateConfiguration m_aggregateConfiguration;

	[DataMember(Name = "StartTime", IsRequired = false, Order = 1)]
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

	[DataMember(Name = "EndTime", IsRequired = false, Order = 2)]
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

	[DataMember(Name = "ProcessingInterval", IsRequired = false, Order = 3)]
	public double ProcessingInterval
	{
		get
		{
			return m_processingInterval;
		}
		set
		{
			m_processingInterval = value;
		}
	}

	[DataMember(Name = "AggregateType", IsRequired = false, Order = 4)]
	public NodeIdCollection AggregateType
	{
		get
		{
			return m_aggregateType;
		}
		set
		{
			m_aggregateType = value;
			if (value == null)
			{
				m_aggregateType = new NodeIdCollection();
			}
		}
	}

	[DataMember(Name = "AggregateConfiguration", IsRequired = false, Order = 5)]
	public AggregateConfiguration AggregateConfiguration
	{
		get
		{
			return m_aggregateConfiguration;
		}
		set
		{
			m_aggregateConfiguration = value;
			if (value == null)
			{
				m_aggregateConfiguration = new AggregateConfiguration();
			}
		}
	}

	public override ExpandedNodeId TypeId => DataTypeIds.ReadProcessedDetails;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.ReadProcessedDetails_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.ReadProcessedDetails_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.ReadProcessedDetails_Encoding_DefaultJson;

	public ReadProcessedDetails()
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
		m_startTime = DateTime.MinValue;
		m_endTime = DateTime.MinValue;
		m_processingInterval = 0.0;
		m_aggregateType = new NodeIdCollection();
		m_aggregateConfiguration = new AggregateConfiguration();
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteDateTime("StartTime", StartTime);
		encoder.WriteDateTime("EndTime", EndTime);
		encoder.WriteDouble("ProcessingInterval", ProcessingInterval);
		encoder.WriteNodeIdArray("AggregateType", AggregateType);
		encoder.WriteEncodeable("AggregateConfiguration", AggregateConfiguration, typeof(AggregateConfiguration));
		encoder.PopNamespace();
	}

	public override void Decode(IDecoder decoder)
	{
		base.Decode(decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		StartTime = decoder.ReadDateTime("StartTime");
		EndTime = decoder.ReadDateTime("EndTime");
		ProcessingInterval = decoder.ReadDouble("ProcessingInterval");
		AggregateType = decoder.ReadNodeIdArray("AggregateType");
		AggregateConfiguration = (AggregateConfiguration)decoder.ReadEncodeable("AggregateConfiguration", typeof(AggregateConfiguration));
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is ReadProcessedDetails readProcessedDetails))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_startTime, readProcessedDetails.m_startTime))
		{
			return false;
		}
		if (!Utils.IsEqual(m_endTime, readProcessedDetails.m_endTime))
		{
			return false;
		}
		if (!Utils.IsEqual(m_processingInterval, readProcessedDetails.m_processingInterval))
		{
			return false;
		}
		if (!Utils.IsEqual(m_aggregateType, readProcessedDetails.m_aggregateType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_aggregateConfiguration, readProcessedDetails.m_aggregateConfiguration))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (ReadProcessedDetails)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ReadProcessedDetails obj = (ReadProcessedDetails)base.MemberwiseClone();
		obj.m_startTime = (DateTime)Utils.Clone(m_startTime);
		obj.m_endTime = (DateTime)Utils.Clone(m_endTime);
		obj.m_processingInterval = (double)Utils.Clone(m_processingInterval);
		obj.m_aggregateType = (NodeIdCollection)Utils.Clone(m_aggregateType);
		obj.m_aggregateConfiguration = (AggregateConfiguration)Utils.Clone(m_aggregateConfiguration);
		return obj;
	}
}
