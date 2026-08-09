using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class MonitoredItemCreateResult : IEncodeable, ICloneable, IJsonEncodeable
{
	private StatusCode m_statusCode;

	private uint m_monitoredItemId;

	private double m_revisedSamplingInterval;

	private uint m_revisedQueueSize;

	private ExtensionObject m_filterResult;

	[DataMember(Name = "StatusCode", IsRequired = false, Order = 1)]
	public StatusCode StatusCode
	{
		get
		{
			return m_statusCode;
		}
		set
		{
			m_statusCode = value;
		}
	}

	[DataMember(Name = "MonitoredItemId", IsRequired = false, Order = 2)]
	public uint MonitoredItemId
	{
		get
		{
			return m_monitoredItemId;
		}
		set
		{
			m_monitoredItemId = value;
		}
	}

	[DataMember(Name = "RevisedSamplingInterval", IsRequired = false, Order = 3)]
	public double RevisedSamplingInterval
	{
		get
		{
			return m_revisedSamplingInterval;
		}
		set
		{
			m_revisedSamplingInterval = value;
		}
	}

	[DataMember(Name = "RevisedQueueSize", IsRequired = false, Order = 4)]
	public uint RevisedQueueSize
	{
		get
		{
			return m_revisedQueueSize;
		}
		set
		{
			m_revisedQueueSize = value;
		}
	}

	[DataMember(Name = "FilterResult", IsRequired = false, Order = 5)]
	public ExtensionObject FilterResult
	{
		get
		{
			return m_filterResult;
		}
		set
		{
			m_filterResult = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.MonitoredItemCreateResult;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.MonitoredItemCreateResult_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.MonitoredItemCreateResult_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.MonitoredItemCreateResult_Encoding_DefaultJson;

	public MonitoredItemCreateResult()
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
		m_statusCode = 0u;
		m_monitoredItemId = 0u;
		m_revisedSamplingInterval = 0.0;
		m_revisedQueueSize = 0u;
		m_filterResult = null;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteStatusCode("StatusCode", StatusCode);
		encoder.WriteUInt32("MonitoredItemId", MonitoredItemId);
		encoder.WriteDouble("RevisedSamplingInterval", RevisedSamplingInterval);
		encoder.WriteUInt32("RevisedQueueSize", RevisedQueueSize);
		encoder.WriteExtensionObject("FilterResult", FilterResult);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		StatusCode = decoder.ReadStatusCode("StatusCode");
		MonitoredItemId = decoder.ReadUInt32("MonitoredItemId");
		RevisedSamplingInterval = decoder.ReadDouble("RevisedSamplingInterval");
		RevisedQueueSize = decoder.ReadUInt32("RevisedQueueSize");
		FilterResult = decoder.ReadExtensionObject("FilterResult");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is MonitoredItemCreateResult monitoredItemCreateResult))
		{
			return false;
		}
		if (!Utils.IsEqual(m_statusCode, monitoredItemCreateResult.m_statusCode))
		{
			return false;
		}
		if (!Utils.IsEqual(m_monitoredItemId, monitoredItemCreateResult.m_monitoredItemId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_revisedSamplingInterval, monitoredItemCreateResult.m_revisedSamplingInterval))
		{
			return false;
		}
		if (!Utils.IsEqual(m_revisedQueueSize, monitoredItemCreateResult.m_revisedQueueSize))
		{
			return false;
		}
		if (!Utils.IsEqual(m_filterResult, monitoredItemCreateResult.m_filterResult))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (MonitoredItemCreateResult)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		MonitoredItemCreateResult obj = (MonitoredItemCreateResult)base.MemberwiseClone();
		obj.m_statusCode = (StatusCode)Utils.Clone(m_statusCode);
		obj.m_monitoredItemId = (uint)Utils.Clone(m_monitoredItemId);
		obj.m_revisedSamplingInterval = (double)Utils.Clone(m_revisedSamplingInterval);
		obj.m_revisedQueueSize = (uint)Utils.Clone(m_revisedQueueSize);
		obj.m_filterResult = (ExtensionObject)Utils.Clone(m_filterResult);
		return obj;
	}

	public MonitoredItemCreateResult(uint statusCode)
	{
		Initialize();
		m_statusCode = statusCode;
	}
}
