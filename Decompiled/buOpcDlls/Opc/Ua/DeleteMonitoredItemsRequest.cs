using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class DeleteMonitoredItemsRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
	private RequestHeader m_requestHeader;

	private uint m_subscriptionId;

	private UInt32Collection m_monitoredItemIds;

	[DataMember(Name = "RequestHeader", IsRequired = false, Order = 1)]
	public RequestHeader RequestHeader
	{
		get
		{
			return m_requestHeader;
		}
		set
		{
			m_requestHeader = value;
			if (value == null)
			{
				m_requestHeader = new RequestHeader();
			}
		}
	}

	[DataMember(Name = "SubscriptionId", IsRequired = false, Order = 2)]
	public uint SubscriptionId
	{
		get
		{
			return m_subscriptionId;
		}
		set
		{
			m_subscriptionId = value;
		}
	}

	[DataMember(Name = "MonitoredItemIds", IsRequired = false, Order = 3)]
	public UInt32Collection MonitoredItemIds
	{
		get
		{
			return m_monitoredItemIds;
		}
		set
		{
			m_monitoredItemIds = value;
			if (value == null)
			{
				m_monitoredItemIds = new UInt32Collection();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.DeleteMonitoredItemsRequest;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.DeleteMonitoredItemsRequest_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.DeleteMonitoredItemsRequest_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.DeleteMonitoredItemsRequest_Encoding_DefaultJson;

	public DeleteMonitoredItemsRequest()
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
		m_requestHeader = new RequestHeader();
		m_subscriptionId = 0u;
		m_monitoredItemIds = new UInt32Collection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeable("RequestHeader", RequestHeader, typeof(RequestHeader));
		encoder.WriteUInt32("SubscriptionId", SubscriptionId);
		encoder.WriteUInt32Array("MonitoredItemIds", MonitoredItemIds);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		RequestHeader = (RequestHeader)decoder.ReadEncodeable("RequestHeader", typeof(RequestHeader));
		SubscriptionId = decoder.ReadUInt32("SubscriptionId");
		MonitoredItemIds = decoder.ReadUInt32Array("MonitoredItemIds");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is DeleteMonitoredItemsRequest deleteMonitoredItemsRequest))
		{
			return false;
		}
		if (!Utils.IsEqual(m_requestHeader, deleteMonitoredItemsRequest.m_requestHeader))
		{
			return false;
		}
		if (!Utils.IsEqual(m_subscriptionId, deleteMonitoredItemsRequest.m_subscriptionId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_monitoredItemIds, deleteMonitoredItemsRequest.m_monitoredItemIds))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (DeleteMonitoredItemsRequest)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		DeleteMonitoredItemsRequest obj = (DeleteMonitoredItemsRequest)base.MemberwiseClone();
		obj.m_requestHeader = (RequestHeader)Utils.Clone(m_requestHeader);
		obj.m_subscriptionId = (uint)Utils.Clone(m_subscriptionId);
		obj.m_monitoredItemIds = (UInt32Collection)Utils.Clone(m_monitoredItemIds);
		return obj;
	}
}
