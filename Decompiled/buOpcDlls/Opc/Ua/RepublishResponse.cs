using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class RepublishResponse : IEncodeable, ICloneable, IJsonEncodeable, IServiceResponse
{
	private ResponseHeader m_responseHeader;

	private NotificationMessage m_notificationMessage;

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

	[DataMember(Name = "NotificationMessage", IsRequired = false, Order = 2)]
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

	public virtual ExpandedNodeId TypeId => DataTypeIds.RepublishResponse;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.RepublishResponse_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.RepublishResponse_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.RepublishResponse_Encoding_DefaultJson;

	public RepublishResponse()
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
		m_notificationMessage = new NotificationMessage();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeable("ResponseHeader", ResponseHeader, typeof(ResponseHeader));
		encoder.WriteEncodeable("NotificationMessage", NotificationMessage, typeof(NotificationMessage));
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		ResponseHeader = (ResponseHeader)decoder.ReadEncodeable("ResponseHeader", typeof(ResponseHeader));
		NotificationMessage = (NotificationMessage)decoder.ReadEncodeable("NotificationMessage", typeof(NotificationMessage));
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is RepublishResponse republishResponse))
		{
			return false;
		}
		if (!Utils.IsEqual(m_responseHeader, republishResponse.m_responseHeader))
		{
			return false;
		}
		if (!Utils.IsEqual(m_notificationMessage, republishResponse.m_notificationMessage))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (RepublishResponse)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		RepublishResponse obj = (RepublishResponse)base.MemberwiseClone();
		obj.m_responseHeader = (ResponseHeader)Utils.Clone(m_responseHeader);
		obj.m_notificationMessage = (NotificationMessage)Utils.Clone(m_notificationMessage);
		return obj;
	}
}
