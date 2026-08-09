using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class ModifySubscriptionRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
	private RequestHeader m_requestHeader;

	private uint m_subscriptionId;

	private double m_requestedPublishingInterval;

	private uint m_requestedLifetimeCount;

	private uint m_requestedMaxKeepAliveCount;

	private uint m_maxNotificationsPerPublish;

	private byte m_priority;

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

	[DataMember(Name = "RequestedPublishingInterval", IsRequired = false, Order = 3)]
	public double RequestedPublishingInterval
	{
		get
		{
			return m_requestedPublishingInterval;
		}
		set
		{
			m_requestedPublishingInterval = value;
		}
	}

	[DataMember(Name = "RequestedLifetimeCount", IsRequired = false, Order = 4)]
	public uint RequestedLifetimeCount
	{
		get
		{
			return m_requestedLifetimeCount;
		}
		set
		{
			m_requestedLifetimeCount = value;
		}
	}

	[DataMember(Name = "RequestedMaxKeepAliveCount", IsRequired = false, Order = 5)]
	public uint RequestedMaxKeepAliveCount
	{
		get
		{
			return m_requestedMaxKeepAliveCount;
		}
		set
		{
			m_requestedMaxKeepAliveCount = value;
		}
	}

	[DataMember(Name = "MaxNotificationsPerPublish", IsRequired = false, Order = 6)]
	public uint MaxNotificationsPerPublish
	{
		get
		{
			return m_maxNotificationsPerPublish;
		}
		set
		{
			m_maxNotificationsPerPublish = value;
		}
	}

	[DataMember(Name = "Priority", IsRequired = false, Order = 7)]
	public byte Priority
	{
		get
		{
			return m_priority;
		}
		set
		{
			m_priority = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.ModifySubscriptionRequest;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.ModifySubscriptionRequest_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.ModifySubscriptionRequest_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.ModifySubscriptionRequest_Encoding_DefaultJson;

	public ModifySubscriptionRequest()
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
		m_requestedPublishingInterval = 0.0;
		m_requestedLifetimeCount = 0u;
		m_requestedMaxKeepAliveCount = 0u;
		m_maxNotificationsPerPublish = 0u;
		m_priority = 0;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeable("RequestHeader", RequestHeader, typeof(RequestHeader));
		encoder.WriteUInt32("SubscriptionId", SubscriptionId);
		encoder.WriteDouble("RequestedPublishingInterval", RequestedPublishingInterval);
		encoder.WriteUInt32("RequestedLifetimeCount", RequestedLifetimeCount);
		encoder.WriteUInt32("RequestedMaxKeepAliveCount", RequestedMaxKeepAliveCount);
		encoder.WriteUInt32("MaxNotificationsPerPublish", MaxNotificationsPerPublish);
		encoder.WriteByte("Priority", Priority);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		RequestHeader = (RequestHeader)decoder.ReadEncodeable("RequestHeader", typeof(RequestHeader));
		SubscriptionId = decoder.ReadUInt32("SubscriptionId");
		RequestedPublishingInterval = decoder.ReadDouble("RequestedPublishingInterval");
		RequestedLifetimeCount = decoder.ReadUInt32("RequestedLifetimeCount");
		RequestedMaxKeepAliveCount = decoder.ReadUInt32("RequestedMaxKeepAliveCount");
		MaxNotificationsPerPublish = decoder.ReadUInt32("MaxNotificationsPerPublish");
		Priority = decoder.ReadByte("Priority");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is ModifySubscriptionRequest modifySubscriptionRequest))
		{
			return false;
		}
		if (!Utils.IsEqual(m_requestHeader, modifySubscriptionRequest.m_requestHeader))
		{
			return false;
		}
		if (!Utils.IsEqual(m_subscriptionId, modifySubscriptionRequest.m_subscriptionId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_requestedPublishingInterval, modifySubscriptionRequest.m_requestedPublishingInterval))
		{
			return false;
		}
		if (!Utils.IsEqual(m_requestedLifetimeCount, modifySubscriptionRequest.m_requestedLifetimeCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_requestedMaxKeepAliveCount, modifySubscriptionRequest.m_requestedMaxKeepAliveCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_maxNotificationsPerPublish, modifySubscriptionRequest.m_maxNotificationsPerPublish))
		{
			return false;
		}
		if (!Utils.IsEqual(m_priority, modifySubscriptionRequest.m_priority))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (ModifySubscriptionRequest)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ModifySubscriptionRequest obj = (ModifySubscriptionRequest)base.MemberwiseClone();
		obj.m_requestHeader = (RequestHeader)Utils.Clone(m_requestHeader);
		obj.m_subscriptionId = (uint)Utils.Clone(m_subscriptionId);
		obj.m_requestedPublishingInterval = (double)Utils.Clone(m_requestedPublishingInterval);
		obj.m_requestedLifetimeCount = (uint)Utils.Clone(m_requestedLifetimeCount);
		obj.m_requestedMaxKeepAliveCount = (uint)Utils.Clone(m_requestedMaxKeepAliveCount);
		obj.m_maxNotificationsPerPublish = (uint)Utils.Clone(m_maxNotificationsPerPublish);
		obj.m_priority = (byte)Utils.Clone(m_priority);
		return obj;
	}
}
