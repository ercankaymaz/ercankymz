using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class MonitoredItemCreateRequest : IEncodeable, ICloneable, IJsonEncodeable
{
	private ReadValueId m_itemToMonitor;

	private MonitoringMode m_monitoringMode;

	private MonitoringParameters m_requestedParameters;

	private object m_handle;

	private bool m_processed;

	[DataMember(Name = "ItemToMonitor", IsRequired = false, Order = 1)]
	public ReadValueId ItemToMonitor
	{
		get
		{
			return m_itemToMonitor;
		}
		set
		{
			m_itemToMonitor = value;
			if (value == null)
			{
				m_itemToMonitor = new ReadValueId();
			}
		}
	}

	[DataMember(Name = "MonitoringMode", IsRequired = false, Order = 2)]
	public MonitoringMode MonitoringMode
	{
		get
		{
			return m_monitoringMode;
		}
		set
		{
			m_monitoringMode = value;
		}
	}

	[DataMember(Name = "RequestedParameters", IsRequired = false, Order = 3)]
	public MonitoringParameters RequestedParameters
	{
		get
		{
			return m_requestedParameters;
		}
		set
		{
			m_requestedParameters = value;
			if (value == null)
			{
				m_requestedParameters = new MonitoringParameters();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.MonitoredItemCreateRequest;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.MonitoredItemCreateRequest_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.MonitoredItemCreateRequest_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.MonitoredItemCreateRequest_Encoding_DefaultJson;

	public object Handle
	{
		get
		{
			return m_handle;
		}
		set
		{
			m_handle = value;
		}
	}

	public bool Processed
	{
		get
		{
			return m_processed;
		}
		set
		{
			m_processed = value;
		}
	}

	public MonitoredItemCreateRequest()
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
		m_itemToMonitor = new ReadValueId();
		m_monitoringMode = MonitoringMode.Disabled;
		m_requestedParameters = new MonitoringParameters();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeable("ItemToMonitor", ItemToMonitor, typeof(ReadValueId));
		encoder.WriteEnumerated("MonitoringMode", MonitoringMode);
		encoder.WriteEncodeable("RequestedParameters", RequestedParameters, typeof(MonitoringParameters));
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		ItemToMonitor = (ReadValueId)decoder.ReadEncodeable("ItemToMonitor", typeof(ReadValueId));
		MonitoringMode = (MonitoringMode)(object)decoder.ReadEnumerated("MonitoringMode", typeof(MonitoringMode));
		RequestedParameters = (MonitoringParameters)decoder.ReadEncodeable("RequestedParameters", typeof(MonitoringParameters));
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is MonitoredItemCreateRequest monitoredItemCreateRequest))
		{
			return false;
		}
		if (!Utils.IsEqual(m_itemToMonitor, monitoredItemCreateRequest.m_itemToMonitor))
		{
			return false;
		}
		if (!Utils.IsEqual(m_monitoringMode, monitoredItemCreateRequest.m_monitoringMode))
		{
			return false;
		}
		if (!Utils.IsEqual(m_requestedParameters, monitoredItemCreateRequest.m_requestedParameters))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (MonitoredItemCreateRequest)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		MonitoredItemCreateRequest obj = (MonitoredItemCreateRequest)base.MemberwiseClone();
		obj.m_itemToMonitor = (ReadValueId)Utils.Clone(m_itemToMonitor);
		obj.m_monitoringMode = (MonitoringMode)Utils.Clone(m_monitoringMode);
		obj.m_requestedParameters = (MonitoringParameters)Utils.Clone(m_requestedParameters);
		return obj;
	}
}
