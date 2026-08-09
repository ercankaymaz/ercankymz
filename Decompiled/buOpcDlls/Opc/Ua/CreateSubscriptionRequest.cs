using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class CreateSubscriptionRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
	private RequestHeader m_requestHeader;

	private double m_requestedPublishingInterval;

	private uint m_requestedLifetimeCount;

	private uint m_requestedMaxKeepAliveCount;

	private uint m_maxNotificationsPerPublish;

	private bool m_publishingEnabled;

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

	[DataMember(Name = "RequestedPublishingInterval", IsRequired = false, Order = 2)]
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

	[DataMember(Name = "RequestedLifetimeCount", IsRequired = false, Order = 3)]
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

	[DataMember(Name = "RequestedMaxKeepAliveCount", IsRequired = false, Order = 4)]
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

	[DataMember(Name = "MaxNotificationsPerPublish", IsRequired = false, Order = 5)]
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

	[DataMember(Name = "PublishingEnabled", IsRequired = false, Order = 6)]
	public bool PublishingEnabled
	{
		get
		{
			return m_publishingEnabled;
		}
		set
		{
			m_publishingEnabled = value;
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

	public virtual ExpandedNodeId TypeId => DataTypeIds.CreateSubscriptionRequest;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.CreateSubscriptionRequest_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.CreateSubscriptionRequest_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.CreateSubscriptionRequest_Encoding_DefaultJson;

	public CreateSubscriptionRequest()
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
		m_requestedPublishingInterval = 0.0;
		m_requestedLifetimeCount = 0u;
		m_requestedMaxKeepAliveCount = 0u;
		m_maxNotificationsPerPublish = 0u;
		m_publishingEnabled = true;
		m_priority = 0;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeable("RequestHeader", RequestHeader, typeof(RequestHeader));
		encoder.WriteDouble("RequestedPublishingInterval", RequestedPublishingInterval);
		encoder.WriteUInt32("RequestedLifetimeCount", RequestedLifetimeCount);
		encoder.WriteUInt32("RequestedMaxKeepAliveCount", RequestedMaxKeepAliveCount);
		encoder.WriteUInt32("MaxNotificationsPerPublish", MaxNotificationsPerPublish);
		encoder.WriteBoolean("PublishingEnabled", PublishingEnabled);
		encoder.WriteByte("Priority", Priority);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		RequestHeader = (RequestHeader)decoder.ReadEncodeable("RequestHeader", typeof(RequestHeader));
		RequestedPublishingInterval = decoder.ReadDouble("RequestedPublishingInterval");
		RequestedLifetimeCount = decoder.ReadUInt32("RequestedLifetimeCount");
		RequestedMaxKeepAliveCount = decoder.ReadUInt32("RequestedMaxKeepAliveCount");
		MaxNotificationsPerPublish = decoder.ReadUInt32("MaxNotificationsPerPublish");
		PublishingEnabled = decoder.ReadBoolean("PublishingEnabled");
		Priority = decoder.ReadByte("Priority");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is CreateSubscriptionRequest createSubscriptionRequest))
		{
			return false;
		}
		if (!Utils.IsEqual(m_requestHeader, createSubscriptionRequest.m_requestHeader))
		{
			return false;
		}
		if (!Utils.IsEqual(m_requestedPublishingInterval, createSubscriptionRequest.m_requestedPublishingInterval))
		{
			return false;
		}
		if (!Utils.IsEqual(m_requestedLifetimeCount, createSubscriptionRequest.m_requestedLifetimeCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_requestedMaxKeepAliveCount, createSubscriptionRequest.m_requestedMaxKeepAliveCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_maxNotificationsPerPublish, createSubscriptionRequest.m_maxNotificationsPerPublish))
		{
			return false;
		}
		if (!Utils.IsEqual(m_publishingEnabled, createSubscriptionRequest.m_publishingEnabled))
		{
			return false;
		}
		if (!Utils.IsEqual(m_priority, createSubscriptionRequest.m_priority))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (CreateSubscriptionRequest)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		CreateSubscriptionRequest obj = (CreateSubscriptionRequest)base.MemberwiseClone();
		obj.m_requestHeader = (RequestHeader)Utils.Clone(m_requestHeader);
		obj.m_requestedPublishingInterval = (double)Utils.Clone(m_requestedPublishingInterval);
		obj.m_requestedLifetimeCount = (uint)Utils.Clone(m_requestedLifetimeCount);
		obj.m_requestedMaxKeepAliveCount = (uint)Utils.Clone(m_requestedMaxKeepAliveCount);
		obj.m_maxNotificationsPerPublish = (uint)Utils.Clone(m_maxNotificationsPerPublish);
		obj.m_publishingEnabled = (bool)Utils.Clone(m_publishingEnabled);
		obj.m_priority = (byte)Utils.Clone(m_priority);
		return obj;
	}
}
