using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class ModifyMonitoredItemsRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
	private RequestHeader m_requestHeader;

	private uint m_subscriptionId;

	private TimestampsToReturn m_timestampsToReturn;

	private MonitoredItemModifyRequestCollection m_itemsToModify;

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

	[DataMember(Name = "TimestampsToReturn", IsRequired = false, Order = 3)]
	public TimestampsToReturn TimestampsToReturn
	{
		get
		{
			return m_timestampsToReturn;
		}
		set
		{
			m_timestampsToReturn = value;
		}
	}

	[DataMember(Name = "ItemsToModify", IsRequired = false, Order = 4)]
	public MonitoredItemModifyRequestCollection ItemsToModify
	{
		get
		{
			return m_itemsToModify;
		}
		set
		{
			m_itemsToModify = value;
			if (value == null)
			{
				m_itemsToModify = new MonitoredItemModifyRequestCollection();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.ModifyMonitoredItemsRequest;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.ModifyMonitoredItemsRequest_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.ModifyMonitoredItemsRequest_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.ModifyMonitoredItemsRequest_Encoding_DefaultJson;

	public ModifyMonitoredItemsRequest()
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
		m_timestampsToReturn = TimestampsToReturn.Source;
		m_itemsToModify = new MonitoredItemModifyRequestCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeable("RequestHeader", RequestHeader, typeof(RequestHeader));
		encoder.WriteUInt32("SubscriptionId", SubscriptionId);
		encoder.WriteEnumerated("TimestampsToReturn", TimestampsToReturn);
		encoder.WriteEncodeableArray("ItemsToModify", ItemsToModify.ToArray(), typeof(MonitoredItemModifyRequest));
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		RequestHeader = (RequestHeader)decoder.ReadEncodeable("RequestHeader", typeof(RequestHeader));
		SubscriptionId = decoder.ReadUInt32("SubscriptionId");
		TimestampsToReturn = (TimestampsToReturn)(object)decoder.ReadEnumerated("TimestampsToReturn", typeof(TimestampsToReturn));
		ItemsToModify = (MonitoredItemModifyRequest[])decoder.ReadEncodeableArray("ItemsToModify", typeof(MonitoredItemModifyRequest));
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is ModifyMonitoredItemsRequest modifyMonitoredItemsRequest))
		{
			return false;
		}
		if (!Utils.IsEqual(m_requestHeader, modifyMonitoredItemsRequest.m_requestHeader))
		{
			return false;
		}
		if (!Utils.IsEqual(m_subscriptionId, modifyMonitoredItemsRequest.m_subscriptionId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_timestampsToReturn, modifyMonitoredItemsRequest.m_timestampsToReturn))
		{
			return false;
		}
		if (!Utils.IsEqual(m_itemsToModify, modifyMonitoredItemsRequest.m_itemsToModify))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (ModifyMonitoredItemsRequest)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ModifyMonitoredItemsRequest obj = (ModifyMonitoredItemsRequest)base.MemberwiseClone();
		obj.m_requestHeader = (RequestHeader)Utils.Clone(m_requestHeader);
		obj.m_subscriptionId = (uint)Utils.Clone(m_subscriptionId);
		obj.m_timestampsToReturn = (TimestampsToReturn)Utils.Clone(m_timestampsToReturn);
		obj.m_itemsToModify = (MonitoredItemModifyRequestCollection)Utils.Clone(m_itemsToModify);
		return obj;
	}
}
