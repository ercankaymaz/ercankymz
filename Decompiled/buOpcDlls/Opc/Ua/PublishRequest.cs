using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class PublishRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
	private RequestHeader m_requestHeader;

	private SubscriptionAcknowledgementCollection m_subscriptionAcknowledgements;

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

	[DataMember(Name = "SubscriptionAcknowledgements", IsRequired = false, Order = 2)]
	public SubscriptionAcknowledgementCollection SubscriptionAcknowledgements
	{
		get
		{
			return m_subscriptionAcknowledgements;
		}
		set
		{
			m_subscriptionAcknowledgements = value;
			if (value == null)
			{
				m_subscriptionAcknowledgements = new SubscriptionAcknowledgementCollection();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.PublishRequest;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.PublishRequest_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.PublishRequest_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.PublishRequest_Encoding_DefaultJson;

	public PublishRequest()
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
		m_subscriptionAcknowledgements = new SubscriptionAcknowledgementCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeable("RequestHeader", RequestHeader, typeof(RequestHeader));
		encoder.WriteEncodeableArray("SubscriptionAcknowledgements", SubscriptionAcknowledgements.ToArray(), typeof(SubscriptionAcknowledgement));
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		RequestHeader = (RequestHeader)decoder.ReadEncodeable("RequestHeader", typeof(RequestHeader));
		SubscriptionAcknowledgements = (SubscriptionAcknowledgement[])decoder.ReadEncodeableArray("SubscriptionAcknowledgements", typeof(SubscriptionAcknowledgement));
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is PublishRequest publishRequest))
		{
			return false;
		}
		if (!Utils.IsEqual(m_requestHeader, publishRequest.m_requestHeader))
		{
			return false;
		}
		if (!Utils.IsEqual(m_subscriptionAcknowledgements, publishRequest.m_subscriptionAcknowledgements))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (PublishRequest)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		PublishRequest obj = (PublishRequest)base.MemberwiseClone();
		obj.m_requestHeader = (RequestHeader)Utils.Clone(m_requestHeader);
		obj.m_subscriptionAcknowledgements = (SubscriptionAcknowledgementCollection)Utils.Clone(m_subscriptionAcknowledgements);
		return obj;
	}
}
