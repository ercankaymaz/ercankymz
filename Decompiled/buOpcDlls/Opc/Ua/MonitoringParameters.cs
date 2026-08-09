using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class MonitoringParameters : IEncodeable, ICloneable, IJsonEncodeable
{
	private uint m_clientHandle;

	private double m_samplingInterval;

	private ExtensionObject m_filter;

	private uint m_queueSize;

	private bool m_discardOldest;

	[DataMember(Name = "ClientHandle", IsRequired = false, Order = 1)]
	public uint ClientHandle
	{
		get
		{
			return m_clientHandle;
		}
		set
		{
			m_clientHandle = value;
		}
	}

	[DataMember(Name = "SamplingInterval", IsRequired = false, Order = 2)]
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

	[DataMember(Name = "Filter", IsRequired = false, Order = 3)]
	public ExtensionObject Filter
	{
		get
		{
			return m_filter;
		}
		set
		{
			m_filter = value;
		}
	}

	[DataMember(Name = "QueueSize", IsRequired = false, Order = 4)]
	public uint QueueSize
	{
		get
		{
			return m_queueSize;
		}
		set
		{
			m_queueSize = value;
		}
	}

	[DataMember(Name = "DiscardOldest", IsRequired = false, Order = 5)]
	public bool DiscardOldest
	{
		get
		{
			return m_discardOldest;
		}
		set
		{
			m_discardOldest = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.MonitoringParameters;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.MonitoringParameters_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.MonitoringParameters_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.MonitoringParameters_Encoding_DefaultJson;

	public MonitoringParameters()
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
		m_clientHandle = 0u;
		m_samplingInterval = 0.0;
		m_filter = null;
		m_queueSize = 0u;
		m_discardOldest = true;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteUInt32("ClientHandle", ClientHandle);
		encoder.WriteDouble("SamplingInterval", SamplingInterval);
		encoder.WriteExtensionObject("Filter", Filter);
		encoder.WriteUInt32("QueueSize", QueueSize);
		encoder.WriteBoolean("DiscardOldest", DiscardOldest);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		ClientHandle = decoder.ReadUInt32("ClientHandle");
		SamplingInterval = decoder.ReadDouble("SamplingInterval");
		Filter = decoder.ReadExtensionObject("Filter");
		QueueSize = decoder.ReadUInt32("QueueSize");
		DiscardOldest = decoder.ReadBoolean("DiscardOldest");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is MonitoringParameters monitoringParameters))
		{
			return false;
		}
		if (!Utils.IsEqual(m_clientHandle, monitoringParameters.m_clientHandle))
		{
			return false;
		}
		if (!Utils.IsEqual(m_samplingInterval, monitoringParameters.m_samplingInterval))
		{
			return false;
		}
		if (!Utils.IsEqual(m_filter, monitoringParameters.m_filter))
		{
			return false;
		}
		if (!Utils.IsEqual(m_queueSize, monitoringParameters.m_queueSize))
		{
			return false;
		}
		if (!Utils.IsEqual(m_discardOldest, monitoringParameters.m_discardOldest))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (MonitoringParameters)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		MonitoringParameters obj = (MonitoringParameters)base.MemberwiseClone();
		obj.m_clientHandle = (uint)Utils.Clone(m_clientHandle);
		obj.m_samplingInterval = (double)Utils.Clone(m_samplingInterval);
		obj.m_filter = (ExtensionObject)Utils.Clone(m_filter);
		obj.m_queueSize = (uint)Utils.Clone(m_queueSize);
		obj.m_discardOldest = (bool)Utils.Clone(m_discardOldest);
		return obj;
	}
}
