using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class FindServersRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
	private RequestHeader m_requestHeader;

	private string m_endpointUrl;

	private StringCollection m_localeIds;

	private StringCollection m_serverUris;

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

	[DataMember(Name = "ServerUris", IsRequired = false, Order = 4)]
	public StringCollection ServerUris
	{
		get
		{
			return m_serverUris;
		}
		set
		{
			m_serverUris = value;
			if (value == null)
			{
				m_serverUris = new StringCollection();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.FindServersRequest;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.FindServersRequest_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.FindServersRequest_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.FindServersRequest_Encoding_DefaultJson;

	public FindServersRequest()
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
		m_serverUris = new StringCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeable("RequestHeader", RequestHeader, typeof(RequestHeader));
		encoder.WriteString("EndpointUrl", EndpointUrl);
		encoder.WriteStringArray("LocaleIds", LocaleIds);
		encoder.WriteStringArray("ServerUris", ServerUris);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		RequestHeader = (RequestHeader)decoder.ReadEncodeable("RequestHeader", typeof(RequestHeader));
		EndpointUrl = decoder.ReadString("EndpointUrl");
		LocaleIds = decoder.ReadStringArray("LocaleIds");
		ServerUris = decoder.ReadStringArray("ServerUris");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is FindServersRequest findServersRequest))
		{
			return false;
		}
		if (!Utils.IsEqual(m_requestHeader, findServersRequest.m_requestHeader))
		{
			return false;
		}
		if (!Utils.IsEqual(m_endpointUrl, findServersRequest.m_endpointUrl))
		{
			return false;
		}
		if (!Utils.IsEqual(m_localeIds, findServersRequest.m_localeIds))
		{
			return false;
		}
		if (!Utils.IsEqual(m_serverUris, findServersRequest.m_serverUris))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (FindServersRequest)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		FindServersRequest obj = (FindServersRequest)base.MemberwiseClone();
		obj.m_requestHeader = (RequestHeader)Utils.Clone(m_requestHeader);
		obj.m_endpointUrl = (string)Utils.Clone(m_endpointUrl);
		obj.m_localeIds = (StringCollection)Utils.Clone(m_localeIds);
		obj.m_serverUris = (StringCollection)Utils.Clone(m_serverUris);
		return obj;
	}
}
