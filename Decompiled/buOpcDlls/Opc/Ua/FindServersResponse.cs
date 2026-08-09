using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class FindServersResponse : IEncodeable, ICloneable, IJsonEncodeable, IServiceResponse
{
	private ResponseHeader m_responseHeader;

	private ApplicationDescriptionCollection m_servers;

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

	[DataMember(Name = "Servers", IsRequired = false, Order = 2)]
	public ApplicationDescriptionCollection Servers
	{
		get
		{
			return m_servers;
		}
		set
		{
			m_servers = value;
			if (value == null)
			{
				m_servers = new ApplicationDescriptionCollection();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.FindServersResponse;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.FindServersResponse_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.FindServersResponse_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.FindServersResponse_Encoding_DefaultJson;

	public FindServersResponse()
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
		m_servers = new ApplicationDescriptionCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeable("ResponseHeader", ResponseHeader, typeof(ResponseHeader));
		encoder.WriteEncodeableArray("Servers", Servers.ToArray(), typeof(ApplicationDescription));
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		ResponseHeader = (ResponseHeader)decoder.ReadEncodeable("ResponseHeader", typeof(ResponseHeader));
		Servers = (ApplicationDescription[])decoder.ReadEncodeableArray("Servers", typeof(ApplicationDescription));
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is FindServersResponse findServersResponse))
		{
			return false;
		}
		if (!Utils.IsEqual(m_responseHeader, findServersResponse.m_responseHeader))
		{
			return false;
		}
		if (!Utils.IsEqual(m_servers, findServersResponse.m_servers))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (FindServersResponse)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		FindServersResponse obj = (FindServersResponse)base.MemberwiseClone();
		obj.m_responseHeader = (ResponseHeader)Utils.Clone(m_responseHeader);
		obj.m_servers = (ApplicationDescriptionCollection)Utils.Clone(m_servers);
		return obj;
	}
}
