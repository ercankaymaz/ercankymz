using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class SamplingIntervalDiagnosticsDataType : IEncodeable, ICloneable, IJsonEncodeable
{
	private double m_samplingInterval;

	private uint m_monitoredItemCount;

	private uint m_maxMonitoredItemCount;

	private uint m_disabledMonitoredItemCount;

	[DataMember(Name = "SamplingInterval", IsRequired = false, Order = 1)]
	public double SamplingInterval
	{
		get
		{
			return m_samplingInterval;
		}
		set
		{
			m_samplingInterval = value;
		}
	}

	[DataMember(Name = "MonitoredItemCount", IsRequired = false, Order = 2)]
	public uint MonitoredItemCount
	{
		get
		{
			return m_monitoredItemCount;
		}
		set
		{
			m_monitoredItemCount = value;
		}
	}

	[DataMember(Name = "MaxMonitoredItemCount", IsRequired = false, Order = 3)]
	public uint MaxMonitoredItemCount
	{
		get
		{
			return m_maxMonitoredItemCount;
		}
		set
		{
			m_maxMonitoredItemCount = value;
		}
	}

	[DataMember(Name = "DisabledMonitoredItemCount", IsRequired = false, Order = 4)]
	public uint DisabledMonitoredItemCount
	{
		get
		{
			return m_disabledMonitoredItemCount;
		}
		set
		{
			m_disabledMonitoredItemCount = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.SamplingIntervalDiagnosticsDataType;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.SamplingIntervalDiagnosticsDataType_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.SamplingIntervalDiagnosticsDataType_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.SamplingIntervalDiagnosticsDataType_Encoding_DefaultJson;

	public SamplingIntervalDiagnosticsDataType()
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
		m_samplingInterval = 0.0;
		m_monitoredItemCount = 0u;
		m_maxMonitoredItemCount = 0u;
		m_disabledMonitoredItemCount = 0u;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteDouble("SamplingInterval", SamplingInterval);
		encoder.WriteUInt32("MonitoredItemCount", MonitoredItemCount);
		encoder.WriteUInt32("MaxMonitoredItemCount", MaxMonitoredItemCount);
		encoder.WriteUInt32("DisabledMonitoredItemCount", DisabledMonitoredItemCount);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		SamplingInterval = decoder.ReadDouble("SamplingInterval");
		MonitoredItemCount = decoder.ReadUInt32("MonitoredItemCount");
		MaxMonitoredItemCount = decoder.ReadUInt32("MaxMonitoredItemCount");
		DisabledMonitoredItemCount = decoder.ReadUInt32("DisabledMonitoredItemCount");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is SamplingIntervalDiagnosticsDataType samplingIntervalDiagnosticsDataType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_samplingInterval, samplingIntervalDiagnosticsDataType.m_samplingInterval))
		{
			return false;
		}
		if (!Utils.IsEqual(m_monitoredItemCount, samplingIntervalDiagnosticsDataType.m_monitoredItemCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_maxMonitoredItemCount, samplingIntervalDiagnosticsDataType.m_maxMonitoredItemCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_disabledMonitoredItemCount, samplingIntervalDiagnosticsDataType.m_disabledMonitoredItemCount))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (SamplingIntervalDiagnosticsDataType)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		SamplingIntervalDiagnosticsDataType obj = (SamplingIntervalDiagnosticsDataType)base.MemberwiseClone();
		obj.m_samplingInterval = (double)Utils.Clone(m_samplingInterval);
		obj.m_monitoredItemCount = (uint)Utils.Clone(m_monitoredItemCount);
		obj.m_maxMonitoredItemCount = (uint)Utils.Clone(m_maxMonitoredItemCount);
		obj.m_disabledMonitoredItemCount = (uint)Utils.Clone(m_disabledMonitoredItemCount);
		return obj;
	}
}
