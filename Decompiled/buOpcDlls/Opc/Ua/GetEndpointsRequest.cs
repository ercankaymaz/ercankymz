using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class GetEndpointsRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
	private RequestHeader m_requestHeader;

	private string m_endpointUrl;

	private StringCollection m_localeIds;

	private StringCollection m_profileUris;

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

	[DataMember(Name = "EndpointUrl", IsRequired = false, Order = 2)]
	public string EndpointUrl
	{
		get
		{
			return m_endpointUrl;
		}
		set
		{
			m_endpointUrl = value;
		}
	}

	[DataMember(Name = "LocaleIds", IsRequired = false, Order = 3)]
	public StringCollection LocaleIds
	{
		get
		{
			return m_localeIds;
		}
		set
		{
			m_localeIds = value;
			if (value == null)
			{
				m_localeIds = new StringCollection();
			}
		}
	}

	[DataMember(Name = "ProfileUris", IsRequired = false, Order = 4)]
	public StringCollection ProfileUris
	{
		get
		{
			return m_profileUris;
		}
		set
		{
			m_profileUris = value;
			if (value == null)
			{
				m_profileUris = new StringCollection();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.GetEndpointsRequest;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.GetEndpointsRequest_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.GetEndpointsRequest_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.GetEndpointsRequest_Encoding_DefaultJson;

	public GetEndpointsRequest()
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
		m_endpointUrl = null;
		m_localeIds = new StringCollection();
		m_profileUris = new StringCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeable("RequestHeader", RequestHeader, typeof(RequestHeader));
		encoder.WriteString("EndpointUrl", EndpointUrl);
		encoder.WriteStringArray("LocaleIds", LocaleIds);
		encoder.WriteStringArray("ProfileUris", ProfileUris);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		RequestHeader = (RequestHeader)decoder.ReadEncodeable("RequestHeader", typeof(RequestHeader));
		EndpointUrl = decoder.ReadString("EndpointUrl");
		LocaleIds = decoder.ReadStringArray("LocaleIds");
		ProfileUris = decoder.ReadStringArray("ProfileUris");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is GetEndpointsRequest getEndpointsRequest))
		{
			return false;
		}
		if (!Utils.IsEqual(m_requestHeader, getEndpointsRequest.m_requestHeader))
		{
			return false;
		}
		if (!Utils.IsEqual(m_endpointUrl, getEndpointsRequest.m_endpointUrl))
		{
			return false;
		}
		if (!Utils.IsEqual(m_localeIds, getEndpointsRequest.m_localeIds))
		{
			return false;
		}
		if (!Utils.IsEqual(m_profileUris, getEndpointsRequest.m_profileUris))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (GetEndpointsRequest)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		GetEndpointsRequest obj = (GetEndpointsRequest)base.MemberwiseClone();
		obj.m_requestHeader = (RequestHeader)Utils.Clone(m_requestHeader);
		obj.m_endpointUrl = (string)Utils.Clone(m_endpointUrl);
		obj.m_localeIds = (StringCollection)Utils.Clone(m_localeIds);
		obj.m_profileUris = (StringCollection)Utils.Clone(m_profileUris);
		return obj;
	}
}
