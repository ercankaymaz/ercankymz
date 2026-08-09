using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class CreateMonitoredItemsRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
	private RequestHeader m_requestHeader;

	private uint m_subscriptionId;

	private TimestampsToReturn m_timestampsToReturn;

	private MonitoredItemCreateRequestCollection m_itemsToCreate;

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

	[DataMember(Name = "ItemsToCreate", IsRequired = false, Order = 4)]
	public MonitoredItemCreateRequestCollection ItemsToCreate
	{
		get
		{
			return m_itemsToCreate;
		}
		set
		{
			m_itemsToCreate = value;
			if (value == null)
			{
				m_itemsToCreate = new MonitoredItemCreateRequestCollection();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.CreateMonitoredItemsRequest;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.CreateMonitoredItemsRequest_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.CreateMonitoredItemsRequest_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.CreateMonitoredItemsRequest_Encoding_DefaultJson;

	public CreateMonitoredItemsRequest()
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
		m_itemsToCreate = new MonitoredItemCreateRequestCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeable("RequestHeader", RequestHeader, typeof(RequestHeader));
		encoder.WriteUInt32("SubscriptionId", SubscriptionId);
		encoder.WriteEnumerated("TimestampsToReturn", TimestampsToReturn);
		encoder.WriteEncodeableArray("ItemsToCreate", ItemsToCreate.ToArray(), typeof(MonitoredItemCreateRequest));
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		RequestHeader = (RequestHeader)decoder.ReadEncodeable("RequestHeader", typeof(RequestHeader));
		SubscriptionId = decoder.ReadUInt32("SubscriptionId");
		TimestampsToReturn = (TimestampsToReturn)(object)decoder.ReadEnumerated("TimestampsToReturn", typeof(TimestampsToReturn));
		ItemsToCreate = (MonitoredItemCreateRequest[])decoder.ReadEncodeableArray("ItemsToCreate", typeof(MonitoredItemCreateRequest));
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is CreateMonitoredItemsRequest createMonitoredItemsRequest))
		{
			return false;
		}
		if (!Utils.IsEqual(m_requestHeader, createMonitoredItemsRequest.m_requestHeader))
		{
			return false;
		}
		if (!Utils.IsEqual(m_subscriptionId, createMonitoredItemsRequest.m_subscriptionId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_timestampsToReturn, createMonitoredItemsRequest.m_timestampsToReturn))
		{
			return false;
		}
		if (!Utils.IsEqual(m_itemsToCreate, createMonitoredItemsRequest.m_itemsToCreate))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (CreateMonitoredItemsRequest)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		CreateMonitoredItemsRequest obj = (CreateMonitoredItemsRequest)base.MemberwiseClone();
		obj.m_requestHeader = (RequestHeader)Utils.Clone(m_requestHeader);
		obj.m_subscriptionId = (uint)Utils.Clone(m_subscriptionId);
		obj.m_timestampsToReturn = (TimestampsToReturn)Utils.Clone(m_timestampsToReturn);
		obj.m_itemsToCreate = (MonitoredItemCreateRequestCollection)Utils.Clone(m_itemsToCreate);
		return obj;
	}
}
