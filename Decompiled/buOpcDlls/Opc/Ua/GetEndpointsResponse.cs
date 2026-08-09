using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class GetEndpointsResponse : IEncodeable, ICloneable, IJsonEncodeable, IServiceResponse
{
	private ResponseHeader m_responseHeader;

	private EndpointDescriptionCollection m_endpoints;

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

	[DataMember(Name = "Endpoints", IsRequired = false, Order = 2)]
	public EndpointDescriptionCollection Endpoints
	{
		get
		{
			return m_endpoints;
		}
		set
		{
			m_endpoints = value;
			if (value == null)
			{
				m_endpoints = new EndpointDescriptionCollection();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.GetEndpointsResponse;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.GetEndpointsResponse_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.GetEndpointsResponse_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.GetEndpointsResponse_Encoding_DefaultJson;

	public GetEndpointsResponse()
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
		m_endpoints = new EndpointDescriptionCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeable("ResponseHeader", ResponseHeader, typeof(ResponseHeader));
		encoder.WriteEncodeableArray("Endpoints", Endpoints.ToArray(), typeof(EndpointDescription));
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		ResponseHeader = (ResponseHeader)decoder.ReadEncodeable("ResponseHeader", typeof(ResponseHeader));
		Endpoints = (EndpointDescription[])decoder.ReadEncodeableArray("Endpoints", typeof(EndpointDescription));
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is GetEndpointsResponse getEndpointsResponse))
		{
			return false;
		}
		if (!Utils.IsEqual(m_responseHeader, getEndpointsResponse.m_responseHeader))
		{
			return false;
		}
		if (!Utils.IsEqual(m_endpoints, getEndpointsResponse.m_endpoints))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (GetEndpointsResponse)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		GetEndpointsResponse obj = (GetEndpointsResponse)base.MemberwiseClone();
		obj.m_responseHeader = (ResponseHeader)Utils.Clone(m_responseHeader);
		obj.m_endpoints = (EndpointDescriptionCollection)Utils.Clone(m_endpoints);
		return obj;
	}
}
