using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class SubscriptionAcknowledgement : IEncodeable, ICloneable, IJsonEncodeable
{
	private uint m_subscriptionId;

	private uint m_sequenceNumber;

	[DataMember(Name = "SubscriptionId", IsRequired = false, Order = 1)]
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

	[DataMember(Name = "SequenceNumber", IsRequired = false, Order = 2)]
	public uint SequenceNumber
	{
		get
		{
			return m_sequenceNumber;
		}
		set
		{
			m_sequenceNumber = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.SubscriptionAcknowledgement;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.SubscriptionAcknowledgement_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.SubscriptionAcknowledgement_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.SubscriptionAcknowledgement_Encoding_DefaultJson;

	public SubscriptionAcknowledgement()
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
		m_subscriptionId = 0u;
		m_sequenceNumber = 0u;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteUInt32("SubscriptionId", SubscriptionId);
		encoder.WriteUInt32("SequenceNumber", SequenceNumber);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		SubscriptionId = decoder.ReadUInt32("SubscriptionId");
		SequenceNumber = decoder.ReadUInt32("SequenceNumber");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is SubscriptionAcknowledgement subscriptionAcknowledgement))
		{
			return false;
		}
		if (!Utils.IsEqual(m_subscriptionId, subscriptionAcknowledgement.m_subscriptionId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_sequenceNumber, subscriptionAcknowledgement.m_sequenceNumber))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (SubscriptionAcknowledgement)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		SubscriptionAcknowledgement obj = (SubscriptionAcknowledgement)base.MemberwiseClone();
		obj.m_subscriptionId = (uint)Utils.Clone(m_subscriptionId);
		obj.m_sequenceNumber = (uint)Utils.Clone(m_sequenceNumber);
		return obj;
	}
}
