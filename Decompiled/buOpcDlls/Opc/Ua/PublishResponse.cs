using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class PublishResponse : IEncodeable, ICloneable, IJsonEncodeable, IServiceResponse
{
	private ResponseHeader m_responseHeader;

	private uint m_subscriptionId;

	private UInt32Collection m_availableSequenceNumbers;

	private bool m_moreNotifications;

	private NotificationMessage m_notificationMessage;

	private StatusCodeCollection m_results;

	private DiagnosticInfoCollection m_diagnosticInfos;

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

	[DataMember(Name = "AvailableSequenceNumbers", IsRequired = false, Order = 3)]
	public UInt32Collection AvailableSequenceNumbers
	{
		get
		{
			return m_availableSequenceNumbers;
		}
		set
		{
			m_availableSequenceNumbers = value;
			if (value == null)
			{
				m_availableSequenceNumbers = new UInt32Collection();
			}
		}
	}

	[DataMember(Name = "MoreNotifications", IsRequired = false, Order = 4)]
	public bool MoreNotifications
	{
		get
		{
			return m_moreNotifications;
		}
		set
		{
			m_moreNotifications = value;
		}
	}

	[DataMember(Name = "NotificationMessage", IsRequired = false, Order = 5)]
	public NotificationMessage NotificationMessage
	{
		get
		{
			return m_notificationMessage;
		}
		set
		{
			m_notificationMessage = value;
			if (value == null)
			{
				m_notificationMessage = new NotificationMessage();
			}
		}
	}

	[DataMember(Name = "Results", IsRequired = false, Order = 6)]
	public StatusCodeCollection Results
	{
		get
		{
			return m_results;
		}
		set
		{
			m_results = value;
			if (value == null)
			{
				m_results = new StatusCodeCollection();
			}
		}
	}

	[DataMember(Name = "DiagnosticInfos", IsRequired = false, Order = 7)]
	public DiagnosticInfoCollection DiagnosticInfos
	{
		get
		{
			return m_diagnosticInfos;
		}
		set
		{
			m_diagnosticInfos = value;
			if (value == null)
			{
				m_diagnosticInfos = new DiagnosticInfoCollection();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.PublishResponse;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.PublishResponse_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.PublishResponse_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.PublishResponse_Encoding_DefaultJson;

	public PublishResponse()
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
		m_availableSequenceNumbers = new UInt32Collection();
		m_moreNotifications = true;
		m_notificationMessage = new NotificationMessage();
		m_results = new StatusCodeCollection();
		m_diagnosticInfos = new DiagnosticInfoCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeable("ResponseHeader", ResponseHeader, typeof(ResponseHeader));
		encoder.WriteUInt32("SubscriptionId", SubscriptionId);
		encoder.WriteUInt32Array("AvailableSequenceNumbers", AvailableSequenceNumbers);
		encoder.WriteBoolean("MoreNotifications", MoreNotifications);
		encoder.WriteEncodeable("NotificationMessage", NotificationMessage, typeof(NotificationMessage));
		encoder.WriteStatusCodeArray("Results", Results);
		encoder.WriteDiagnosticInfoArray("DiagnosticInfos", DiagnosticInfos);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		ResponseHeader = (ResponseHeader)decoder.ReadEncodeable("ResponseHeader", typeof(ResponseHeader));
		SubscriptionId = decoder.ReadUInt32("SubscriptionId");
		AvailableSequenceNumbers = decoder.ReadUInt32Array("AvailableSequenceNumbers");
		MoreNotifications = decoder.ReadBoolean("MoreNotifications");
		NotificationMessage = (NotificationMessage)decoder.ReadEncodeable("NotificationMessage", typeof(NotificationMessage));
		Results = decoder.ReadStatusCodeArray("Results");
		DiagnosticInfos = decoder.ReadDiagnosticInfoArray("DiagnosticInfos");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is PublishResponse publishResponse))
		{
			return false;
		}
		if (!Utils.IsEqual(m_responseHeader, publishResponse.m_responseHeader))
		{
			return false;
		}
		if (!Utils.IsEqual(m_subscriptionId, publishResponse.m_subscriptionId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_availableSequenceNumbers, publishResponse.m_availableSequenceNumbers))
		{
			return false;
		}
		if (!Utils.IsEqual(m_moreNotifications, publishResponse.m_moreNotifications))
		{
			return false;
		}
		if (!Utils.IsEqual(m_notificationMessage, publishResponse.m_notificationMessage))
		{
			return false;
		}
		if (!Utils.IsEqual(m_results, publishResponse.m_results))
		{
			return false;
		}
		if (!Utils.IsEqual(m_diagnosticInfos, publishResponse.m_diagnosticInfos))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (PublishResponse)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		PublishResponse obj = (PublishResponse)base.MemberwiseClone();
		obj.m_responseHeader = (ResponseHeader)Utils.Clone(m_responseHeader);
		obj.m_subscriptionId = (uint)Utils.Clone(m_subscriptionId);
		obj.m_availableSequenceNumbers = (UInt32Collection)Utils.Clone(m_availableSequenceNumbers);
		obj.m_moreNotifications = (bool)Utils.Clone(m_moreNotifications);
		obj.m_notificationMessage = (NotificationMessage)Utils.Clone(m_notificationMessage);
		obj.m_results = (StatusCodeCollection)Utils.Clone(m_results);
		obj.m_diagnosticInfos = (DiagnosticInfoCollection)Utils.Clone(m_diagnosticInfos);
		return obj;
	}
}
