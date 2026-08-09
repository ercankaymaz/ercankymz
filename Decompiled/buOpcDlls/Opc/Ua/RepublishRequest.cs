using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class RepublishRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
	private RequestHeader m_requestHeader;

	private uint m_subscriptionId;

	private uint m_retransmitSequenceNumber;

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

	[DataMember(Name = "RetransmitSequenceNumber", IsRequired = false, Order = 3)]
	public uint RetransmitSequenceNumber
	{
		get
		{
			return m_retransmitSequenceNumber;
		}
		set
		{
			m_retransmitSequenceNumber = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.RepublishRequest;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.RepublishRequest_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.RepublishRequest_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.RepublishRequest_Encoding_DefaultJson;

	public RepublishRequest()
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
		m_retransmitSequenceNumber = 0u;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeable("RequestHeader", RequestHeader, typeof(RequestHeader));
		encoder.WriteUInt32("SubscriptionId", SubscriptionId);
		encoder.WriteUInt32("RetransmitSequenceNumber", RetransmitSequenceNumber);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		RequestHeader = (RequestHeader)decoder.ReadEncodeable("RequestHeader", typeof(RequestHeader));
		SubscriptionId = decoder.ReadUInt32("SubscriptionId");
		RetransmitSequenceNumber = decoder.ReadUInt32("RetransmitSequenceNumber");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is RepublishRequest republishRequest))
		{
			return false;
		}
		if (!Utils.IsEqual(m_requestHeader, republishRequest.m_requestHeader))
		{
			return false;
		}
		if (!Utils.IsEqual(m_subscriptionId, republishRequest.m_subscriptionId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_retransmitSequenceNumber, republishRequest.m_retransmitSequenceNumber))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (RepublishRequest)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		RepublishRequest obj = (RepublishRequest)base.MemberwiseClone();
		obj.m_requestHeader = (RequestHeader)Utils.Clone(m_requestHeader);
		obj.m_subscriptionId = (uint)Utils.Clone(m_subscriptionId);
		obj.m_retransmitSequenceNumber = (uint)Utils.Clone(m_retransmitSequenceNumber);
		return obj;
	}
}
