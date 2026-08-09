using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class RegisterServerRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
	private RequestHeader m_requestHeader;

	private RegisteredServer m_server;

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

	[DataMember(Name = "Server", IsRequired = false, Order = 2)]
	public RegisteredServer Server
	{
		get
		{
			return m_server;
		}
		set
		{
			m_server = value;
			if (value == null)
			{
				m_server = new RegisteredServer();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.RegisterServerRequest;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.RegisterServerRequest_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.RegisterServerRequest_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.RegisterServerRequest_Encoding_DefaultJson;

	public RegisterServerRequest()
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
		m_server = new RegisteredServer();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeable("RequestHeader", RequestHeader, typeof(RequestHeader));
		encoder.WriteEncodeable("Server", Server, typeof(RegisteredServer));
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		RequestHeader = (RequestHeader)decoder.ReadEncodeable("RequestHeader", typeof(RequestHeader));
		Server = (RegisteredServer)decoder.ReadEncodeable("Server", typeof(RegisteredServer));
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is RegisterServerRequest registerServerRequest))
		{
			return false;
		}
		if (!Utils.IsEqual(m_requestHeader, registerServerRequest.m_requestHeader))
		{
			return false;
		}
		if (!Utils.IsEqual(m_server, registerServerRequest.m_server))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (RegisterServerRequest)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		RegisterServerRequest obj = (RegisterServerRequest)base.MemberwiseClone();
		obj.m_requestHeader = (RequestHeader)Utils.Clone(m_requestHeader);
		obj.m_server = (RegisteredServer)Utils.Clone(m_server);
		return obj;
	}
}
