using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class RegisterServer2Request : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
	private RequestHeader m_requestHeader;

	private RegisteredServer m_server;

	private ExtensionObjectCollection m_discoveryConfiguration;

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

	[DataMember(Name = "DiscoveryConfiguration", IsRequired = false, Order = 3)]
	public ExtensionObjectCollection DiscoveryConfiguration
	{
		get
		{
			return m_discoveryConfiguration;
		}
		set
		{
			m_discoveryConfiguration = value;
			if (value == null)
			{
				m_discoveryConfiguration = new ExtensionObjectCollection();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.RegisterServer2Request;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.RegisterServer2Request_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.RegisterServer2Request_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.RegisterServer2Request_Encoding_DefaultJson;

	public RegisterServer2Request()
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
		m_discoveryConfiguration = new ExtensionObjectCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeable("RequestHeader", RequestHeader, typeof(RequestHeader));
		encoder.WriteEncodeable("Server", Server, typeof(RegisteredServer));
		encoder.WriteExtensionObjectArray("DiscoveryConfiguration", DiscoveryConfiguration);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		RequestHeader = (RequestHeader)decoder.ReadEncodeable("RequestHeader", typeof(RequestHeader));
		Server = (RegisteredServer)decoder.ReadEncodeable("Server", typeof(RegisteredServer));
		DiscoveryConfiguration = decoder.ReadExtensionObjectArray("DiscoveryConfiguration");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is RegisterServer2Request registerServer2Request))
		{
			return false;
		}
		if (!Utils.IsEqual(m_requestHeader, registerServer2Request.m_requestHeader))
		{
			return false;
		}
		if (!Utils.IsEqual(m_server, registerServer2Request.m_server))
		{
			return false;
		}
		if (!Utils.IsEqual(m_discoveryConfiguration, registerServer2Request.m_discoveryConfiguration))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (RegisterServer2Request)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		RegisterServer2Request obj = (RegisterServer2Request)base.MemberwiseClone();
		obj.m_requestHeader = (RequestHeader)Utils.Clone(m_requestHeader);
		obj.m_server = (RegisteredServer)Utils.Clone(m_server);
		obj.m_discoveryConfiguration = (ExtensionObjectCollection)Utils.Clone(m_discoveryConfiguration);
		return obj;
	}
}
