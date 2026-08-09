using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class AggregateFilter : MonitoringFilter
{
	private DateTime m_startTime;

	private NodeId m_aggregateType;

	private double m_processingInterval;

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

	[DataMember(Name = "AggregateType", IsRequired = false, Order = 2)]
	public NodeId AggregateType
	{
		get
		{
			return m_aggregateType;
		}
		set
		{
			m_aggregateType = value;
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

	[DataMember(Name = "AggregateConfiguration", IsRequired = false, Order = 4)]
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

	public override ExpandedNodeId TypeId => DataTypeIds.AggregateFilter;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.AggregateFilter_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.AggregateFilter_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.AggregateFilter_Encoding_DefaultJson;

	public AggregateFilter()
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
		m_aggregateType = null;
		m_processingInterval = 0.0;
		m_aggregateConfiguration = new AggregateConfiguration();
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteDateTime("StartTime", StartTime);
		encoder.WriteNodeId("AggregateType", AggregateType);
		encoder.WriteDouble("ProcessingInterval", ProcessingInterval);
		encoder.WriteEncodeable("AggregateConfiguration", AggregateConfiguration, typeof(AggregateConfiguration));
		encoder.PopNamespace();
	}

	public override void Decode(IDecoder decoder)
	{
		base.Decode(decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		StartTime = decoder.ReadDateTime("StartTime");
		AggregateType = decoder.ReadNodeId("AggregateType");
		ProcessingInterval = decoder.ReadDouble("ProcessingInterval");
		AggregateConfiguration = (AggregateConfiguration)decoder.ReadEncodeable("AggregateConfiguration", typeof(AggregateConfiguration));
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is AggregateFilter aggregateFilter))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_startTime, aggregateFilter.m_startTime))
		{
			return false;
		}
		if (!Utils.IsEqual(m_aggregateType, aggregateFilter.m_aggregateType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_processingInterval, aggregateFilter.m_processingInterval))
		{
			return false;
		}
		if (!Utils.IsEqual(m_aggregateConfiguration, aggregateFilter.m_aggregateConfiguration))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (AggregateFilter)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		AggregateFilter obj = (AggregateFilter)base.MemberwiseClone();
		obj.m_startTime = (DateTime)Utils.Clone(m_startTime);
		obj.m_aggregateType = (NodeId)Utils.Clone(m_aggregateType);
		obj.m_processingInterval = (double)Utils.Clone(m_processingInterval);
		obj.m_aggregateConfiguration = (AggregateConfiguration)Utils.Clone(m_aggregateConfiguration);
		return obj;
	}
}
