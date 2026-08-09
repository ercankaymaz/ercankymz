using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class SetTriggeringRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
	private RequestHeader m_requestHeader;

	private uint m_subscriptionId;

	private uint m_triggeringItemId;

	private UInt32Collection m_linksToAdd;

	private UInt32Collection m_linksToRemove;

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

	[DataMember(Name = "TriggeringItemId", IsRequired = false, Order = 3)]
	public uint TriggeringItemId
	{
		get
		{
			return m_triggeringItemId;
		}
		set
		{
			m_triggeringItemId = value;
		}
	}

	[DataMember(Name = "LinksToAdd", IsRequired = false, Order = 4)]
	public UInt32Collection LinksToAdd
	{
		get
		{
			return m_linksToAdd;
		}
		set
		{
			m_linksToAdd = value;
			if (value == null)
			{
				m_linksToAdd = new UInt32Collection();
			}
		}
	}

	[DataMember(Name = "LinksToRemove", IsRequired = false, Order = 5)]
	public UInt32Collection LinksToRemove
	{
		get
		{
			return m_linksToRemove;
		}
		set
		{
			m_linksToRemove = value;
			if (value == null)
			{
				m_linksToRemove = new UInt32Collection();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.SetTriggeringRequest;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.SetTriggeringRequest_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.SetTriggeringRequest_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.SetTriggeringRequest_Encoding_DefaultJson;

	public SetTriggeringRequest()
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
		m_triggeringItemId = 0u;
		m_linksToAdd = new UInt32Collection();
		m_linksToRemove = new UInt32Collection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeable("RequestHeader", RequestHeader, typeof(RequestHeader));
		encoder.WriteUInt32("SubscriptionId", SubscriptionId);
		encoder.WriteUInt32("TriggeringItemId", TriggeringItemId);
		encoder.WriteUInt32Array("LinksToAdd", LinksToAdd);
		encoder.WriteUInt32Array("LinksToRemove", LinksToRemove);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		RequestHeader = (RequestHeader)decoder.ReadEncodeable("RequestHeader", typeof(RequestHeader));
		SubscriptionId = decoder.ReadUInt32("SubscriptionId");
		TriggeringItemId = decoder.ReadUInt32("TriggeringItemId");
		LinksToAdd = decoder.ReadUInt32Array("LinksToAdd");
		LinksToRemove = decoder.ReadUInt32Array("LinksToRemove");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is SetTriggeringRequest setTriggeringRequest))
		{
			return false;
		}
		if (!Utils.IsEqual(m_requestHeader, setTriggeringRequest.m_requestHeader))
		{
			return false;
		}
		if (!Utils.IsEqual(m_subscriptionId, setTriggeringRequest.m_subscriptionId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_triggeringItemId, setTriggeringRequest.m_triggeringItemId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_linksToAdd, setTriggeringRequest.m_linksToAdd))
		{
			return false;
		}
		if (!Utils.IsEqual(m_linksToRemove, setTriggeringRequest.m_linksToRemove))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (SetTriggeringRequest)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		SetTriggeringRequest obj = (SetTriggeringRequest)base.MemberwiseClone();
		obj.m_requestHeader = (RequestHeader)Utils.Clone(m_requestHeader);
		obj.m_subscriptionId = (uint)Utils.Clone(m_subscriptionId);
		obj.m_triggeringItemId = (uint)Utils.Clone(m_triggeringItemId);
		obj.m_linksToAdd = (UInt32Collection)Utils.Clone(m_linksToAdd);
		obj.m_linksToRemove = (UInt32Collection)Utils.Clone(m_linksToRemove);
		return obj;
	}
}
