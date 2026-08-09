using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class CloseSessionRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
	private RequestHeader m_requestHeader;

	private bool m_deleteSubscriptions;

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

	[DataMember(Name = "DeleteSubscriptions", IsRequired = false, Order = 2)]
	public bool DeleteSubscriptions
	{
		get
		{
			return m_deleteSubscriptions;
		}
		set
		{
			m_deleteSubscriptions = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.CloseSessionRequest;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.CloseSessionRequest_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.CloseSessionRequest_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.CloseSessionRequest_Encoding_DefaultJson;

	public CloseSessionRequest()
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
		m_deleteSubscriptions = true;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeable("RequestHeader", RequestHeader, typeof(RequestHeader));
		encoder.WriteBoolean("DeleteSubscriptions", DeleteSubscriptions);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		RequestHeader = (RequestHeader)decoder.ReadEncodeable("RequestHeader", typeof(RequestHeader));
		DeleteSubscriptions = decoder.ReadBoolean("DeleteSubscriptions");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is CloseSessionRequest closeSessionRequest))
		{
			return false;
		}
		if (!Utils.IsEqual(m_requestHeader, closeSessionRequest.m_requestHeader))
		{
			return false;
		}
		if (!Utils.IsEqual(m_deleteSubscriptions, closeSessionRequest.m_deleteSubscriptions))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (CloseSessionRequest)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		CloseSessionRequest obj = (CloseSessionRequest)base.MemberwiseClone();
		obj.m_requestHeader = (RequestHeader)Utils.Clone(m_requestHeader);
		obj.m_deleteSubscriptions = (bool)Utils.Clone(m_deleteSubscriptions);
		return obj;
	}
}
