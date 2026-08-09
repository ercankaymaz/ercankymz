using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class AggregateFilterResult : MonitoringFilterResult
{
	private DateTime m_revisedStartTime;

	private double m_revisedProcessingInterval;

	private AggregateConfiguration m_revisedAggregateConfiguration;

	[DataMember(Name = "RevisedStartTime", IsRequired = false, Order = 1)]
	public DateTime RevisedStartTime
	{
		get
		{
			return m_revisedStartTime;
		}
		set
		{
			m_revisedStartTime = value;
		}
	}

	[DataMember(Name = "RevisedProcessingInterval", IsRequired = false, Order = 2)]
	public double RevisedProcessingInterval
	{
		get
		{
			return m_revisedProcessingInterval;
		}
		set
		{
			m_revisedProcessingInterval = value;
		}
	}

	[DataMember(Name = "RevisedAggregateConfiguration", IsRequired = false, Order = 3)]
	public AggregateConfiguration RevisedAggregateConfiguration
	{
		get
		{
			return m_revisedAggregateConfiguration;
		}
		set
		{
			m_revisedAggregateConfiguration = value;
			if (value == null)
			{
				m_revisedAggregateConfiguration = new AggregateConfiguration();
			}
		}
	}

	public override ExpandedNodeId TypeId => DataTypeIds.AggregateFilterResult;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.AggregateFilterResult_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.AggregateFilterResult_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.AggregateFilterResult_Encoding_DefaultJson;

	public AggregateFilterResult()
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
		m_revisedStartTime = DateTime.MinValue;
		m_revisedProcessingInterval = 0.0;
		m_revisedAggregateConfiguration = new AggregateConfiguration();
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteDateTime("RevisedStartTime", RevisedStartTime);
		encoder.WriteDouble("RevisedProcessingInterval", RevisedProcessingInterval);
		encoder.WriteEncodeable("RevisedAggregateConfiguration", RevisedAggregateConfiguration, typeof(AggregateConfiguration));
		encoder.PopNamespace();
	}

	public override void Decode(IDecoder decoder)
	{
		base.Decode(decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		RevisedStartTime = decoder.ReadDateTime("RevisedStartTime");
		RevisedProcessingInterval = decoder.ReadDouble("RevisedProcessingInterval");
		RevisedAggregateConfiguration = (AggregateConfiguration)decoder.ReadEncodeable("RevisedAggregateConfiguration", typeof(AggregateConfiguration));
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is AggregateFilterResult aggregateFilterResult))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_revisedStartTime, aggregateFilterResult.m_revisedStartTime))
		{
			return false;
		}
		if (!Utils.IsEqual(m_revisedProcessingInterval, aggregateFilterResult.m_revisedProcessingInterval))
		{
			return false;
		}
		if (!Utils.IsEqual(m_revisedAggregateConfiguration, aggregateFilterResult.m_revisedAggregateConfiguration))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (AggregateFilterResult)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		AggregateFilterResult obj = (AggregateFilterResult)base.MemberwiseClone();
		obj.m_revisedStartTime = (DateTime)Utils.Clone(m_revisedStartTime);
		obj.m_revisedProcessingInterval = (double)Utils.Clone(m_revisedProcessingInterval);
		obj.m_revisedAggregateConfiguration = (AggregateConfiguration)Utils.Clone(m_revisedAggregateConfiguration);
		return obj;
	}
}
