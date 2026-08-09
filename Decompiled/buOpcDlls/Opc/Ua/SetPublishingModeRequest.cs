using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class SetPublishingModeRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
	private RequestHeader m_requestHeader;

	private bool m_publishingEnabled;

	private UInt32Collection m_subscriptionIds;

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

	[DataMember(Name = "PublishingEnabled", IsRequired = false, Order = 2)]
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

	[DataMember(Name = "SubscriptionIds", IsRequired = false, Order = 3)]
	public UInt32Collection SubscriptionIds
	{
		get
		{
			return m_subscriptionIds;
		}
		set
		{
			m_subscriptionIds = value;
			if (value == null)
			{
				m_subscriptionIds = new UInt32Collection();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.SetPublishingModeRequest;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.SetPublishingModeRequest_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.SetPublishingModeRequest_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.SetPublishingModeRequest_Encoding_DefaultJson;

	public SetPublishingModeRequest()
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
		m_publishingEnabled = true;
		m_subscriptionIds = new UInt32Collection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeable("RequestHeader", RequestHeader, typeof(RequestHeader));
		encoder.WriteBoolean("PublishingEnabled", PublishingEnabled);
		encoder.WriteUInt32Array("SubscriptionIds", SubscriptionIds);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		RequestHeader = (RequestHeader)decoder.ReadEncodeable("RequestHeader", typeof(RequestHeader));
		PublishingEnabled = decoder.ReadBoolean("PublishingEnabled");
		SubscriptionIds = decoder.ReadUInt32Array("SubscriptionIds");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is SetPublishingModeRequest setPublishingModeRequest))
		{
			return false;
		}
		if (!Utils.IsEqual(m_requestHeader, setPublishingModeRequest.m_requestHeader))
		{
			return false;
		}
		if (!Utils.IsEqual(m_publishingEnabled, setPublishingModeRequest.m_publishingEnabled))
		{
			return false;
		}
		if (!Utils.IsEqual(m_subscriptionIds, setPublishingModeRequest.m_subscriptionIds))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (SetPublishingModeRequest)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		SetPublishingModeRequest obj = (SetPublishingModeRequest)base.MemberwiseClone();
		obj.m_requestHeader = (RequestHeader)Utils.Clone(m_requestHeader);
		obj.m_publishingEnabled = (bool)Utils.Clone(m_publishingEnabled);
		obj.m_subscriptionIds = (UInt32Collection)Utils.Clone(m_subscriptionIds);
		return obj;
	}
}
