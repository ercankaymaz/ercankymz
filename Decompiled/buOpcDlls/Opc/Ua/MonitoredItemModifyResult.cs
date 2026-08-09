using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class MonitoredItemModifyResult : IEncodeable, ICloneable, IJsonEncodeable
{
	private StatusCode m_statusCode;

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

	[DataMember(Name = "RevisedSamplingInterval", IsRequired = false, Order = 2)]
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

	[DataMember(Name = "RevisedQueueSize", IsRequired = false, Order = 3)]
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

	[DataMember(Name = "FilterResult", IsRequired = false, Order = 4)]
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

	public virtual ExpandedNodeId TypeId => DataTypeIds.MonitoredItemModifyResult;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.MonitoredItemModifyResult_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.MonitoredItemModifyResult_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.MonitoredItemModifyResult_Encoding_DefaultJson;

	public MonitoredItemModifyResult()
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
		m_revisedSamplingInterval = 0.0;
		m_revisedQueueSize = 0u;
		m_filterResult = null;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteStatusCode("StatusCode", StatusCode);
		encoder.WriteDouble("RevisedSamplingInterval", RevisedSamplingInterval);
		encoder.WriteUInt32("RevisedQueueSize", RevisedQueueSize);
		encoder.WriteExtensionObject("FilterResult", FilterResult);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		StatusCode = decoder.ReadStatusCode("StatusCode");
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
		if (!(encodeable is MonitoredItemModifyResult monitoredItemModifyResult))
		{
			return false;
		}
		if (!Utils.IsEqual(m_statusCode, monitoredItemModifyResult.m_statusCode))
		{
			return false;
		}
		if (!Utils.IsEqual(m_revisedSamplingInterval, monitoredItemModifyResult.m_revisedSamplingInterval))
		{
			return false;
		}
		if (!Utils.IsEqual(m_revisedQueueSize, monitoredItemModifyResult.m_revisedQueueSize))
		{
			return false;
		}
		if (!Utils.IsEqual(m_filterResult, monitoredItemModifyResult.m_filterResult))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (MonitoredItemModifyResult)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		MonitoredItemModifyResult obj = (MonitoredItemModifyResult)base.MemberwiseClone();
		obj.m_statusCode = (StatusCode)Utils.Clone(m_statusCode);
		obj.m_revisedSamplingInterval = (double)Utils.Clone(m_revisedSamplingInterval);
		obj.m_revisedQueueSize = (uint)Utils.Clone(m_revisedQueueSize);
		obj.m_filterResult = (ExtensionObject)Utils.Clone(m_filterResult);
		return obj;
	}
}
