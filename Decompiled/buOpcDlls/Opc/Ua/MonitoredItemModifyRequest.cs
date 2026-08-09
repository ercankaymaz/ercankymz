using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class MonitoredItemModifyRequest : IEncodeable, ICloneable, IJsonEncodeable
{
	private uint m_monitoredItemId;

	private MonitoringParameters m_requestedParameters;

	private object m_handle;

	private bool m_processed;

	[DataMember(Name = "MonitoredItemId", IsRequired = false, Order = 1)]
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

	[DataMember(Name = "RequestedParameters", IsRequired = false, Order = 2)]
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

	public virtual ExpandedNodeId TypeId => DataTypeIds.MonitoredItemModifyRequest;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.MonitoredItemModifyRequest_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.MonitoredItemModifyRequest_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.MonitoredItemModifyRequest_Encoding_DefaultJson;

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

	public MonitoredItemModifyRequest()
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
		m_monitoredItemId = 0u;
		m_requestedParameters = new MonitoringParameters();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteUInt32("MonitoredItemId", MonitoredItemId);
		encoder.WriteEncodeable("RequestedParameters", RequestedParameters, typeof(MonitoringParameters));
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		MonitoredItemId = decoder.ReadUInt32("MonitoredItemId");
		RequestedParameters = (MonitoringParameters)decoder.ReadEncodeable("RequestedParameters", typeof(MonitoringParameters));
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is MonitoredItemModifyRequest monitoredItemModifyRequest))
		{
			return false;
		}
		if (!Utils.IsEqual(m_monitoredItemId, monitoredItemModifyRequest.m_monitoredItemId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_requestedParameters, monitoredItemModifyRequest.m_requestedParameters))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (MonitoredItemModifyRequest)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		MonitoredItemModifyRequest obj = (MonitoredItemModifyRequest)base.MemberwiseClone();
		obj.m_monitoredItemId = (uint)Utils.Clone(m_monitoredItemId);
		obj.m_requestedParameters = (MonitoringParameters)Utils.Clone(m_requestedParameters);
		return obj;
	}
}
