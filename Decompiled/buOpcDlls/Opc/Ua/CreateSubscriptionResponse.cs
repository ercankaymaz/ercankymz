using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class CreateSubscriptionResponse : IEncodeable, ICloneable, IJsonEncodeable, IServiceResponse
{
	private ResponseHeader m_responseHeader;

	private uint m_subscriptionId;

	private double m_revisedPublishingInterval;

	private uint m_revisedLifetimeCount;

	private uint m_revisedMaxKeepAliveCount;

	[DataMember(Name = "ResponseHeader", IsRequired = false, Order = 1)]
	public ResponseHeader ResponseHeader
	{
		get
		{
			return m_responseHeader;
		}
		set
		{
			m_responseHeader = value;
			if (value == null)
			{
				m_responseHeader = new ResponseHeader();
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

	[DataMember(Name = "RevisedPublishingInterval", IsRequired = false, Order = 3)]
	public double RevisedPublishingInterval
	{
		get
		{
			return m_revisedPublishingInterval;
		}
		set
		{
			m_revisedPublishingInterval = value;
		}
	}

	[DataMember(Name = "RevisedLifetimeCount", IsRequired = false, Order = 4)]
	public uint RevisedLifetimeCount
	{
		get
		{
			return m_revisedLifetimeCount;
		}
		set
		{
			m_revisedLifetimeCount = value;
		}
	}

	[DataMember(Name = "RevisedMaxKeepAliveCount", IsRequired = false, Order = 5)]
	public uint RevisedMaxKeepAliveCount
	{
		get
		{
			return m_revisedMaxKeepAliveCount;
		}
		set
		{
			m_revisedMaxKeepAliveCount = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.CreateSubscriptionResponse;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.CreateSubscriptionResponse_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.CreateSubscriptionResponse_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.CreateSubscriptionResponse_Encoding_DefaultJson;

	public CreateSubscriptionResponse()
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
		m_responseHeader = new ResponseHeader();
		m_subscriptionId = 0u;
		m_revisedPublishingInterval = 0.0;
		m_revisedLifetimeCount = 0u;
		m_revisedMaxKeepAliveCount = 0u;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeable("ResponseHeader", ResponseHeader, typeof(ResponseHeader));
		encoder.WriteUInt32("SubscriptionId", SubscriptionId);
		encoder.WriteDouble("RevisedPublishingInterval", RevisedPublishingInterval);
		encoder.WriteUInt32("RevisedLifetimeCount", RevisedLifetimeCount);
		encoder.WriteUInt32("RevisedMaxKeepAliveCount", RevisedMaxKeepAliveCount);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		ResponseHeader = (ResponseHeader)decoder.ReadEncodeable("ResponseHeader", typeof(ResponseHeader));
		SubscriptionId = decoder.ReadUInt32("SubscriptionId");
		RevisedPublishingInterval = decoder.ReadDouble("RevisedPublishingInterval");
		RevisedLifetimeCount = decoder.ReadUInt32("RevisedLifetimeCount");
		RevisedMaxKeepAliveCount = decoder.ReadUInt32("RevisedMaxKeepAliveCount");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is CreateSubscriptionResponse createSubscriptionResponse))
		{
			return false;
		}
		if (!Utils.IsEqual(m_responseHeader, createSubscriptionResponse.m_responseHeader))
		{
			return false;
		}
		if (!Utils.IsEqual(m_subscriptionId, createSubscriptionResponse.m_subscriptionId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_revisedPublishingInterval, createSubscriptionResponse.m_revisedPublishingInterval))
		{
			return false;
		}
		if (!Utils.IsEqual(m_revisedLifetimeCount, createSubscriptionResponse.m_revisedLifetimeCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_revisedMaxKeepAliveCount, createSubscriptionResponse.m_revisedMaxKeepAliveCount))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (CreateSubscriptionResponse)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		CreateSubscriptionResponse obj = (CreateSubscriptionResponse)base.MemberwiseClone();
		obj.m_responseHeader = (ResponseHeader)Utils.Clone(m_responseHeader);
		obj.m_subscriptionId = (uint)Utils.Clone(m_subscriptionId);
		obj.m_revisedPublishingInterval = (double)Utils.Clone(m_revisedPublishingInterval);
		obj.m_revisedLifetimeCount = (uint)Utils.Clone(m_revisedLifetimeCount);
		obj.m_revisedMaxKeepAliveCount = (uint)Utils.Clone(m_revisedMaxKeepAliveCount);
		return obj;
	}
}
