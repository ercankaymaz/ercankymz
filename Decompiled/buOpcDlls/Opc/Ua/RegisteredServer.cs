using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class RegisteredServer : IEncodeable, ICloneable, IJsonEncodeable
{
	private string m_serverUri;

	private string m_productUri;

	private LocalizedTextCollection m_serverNames;

	private ApplicationType m_serverType;

	private string m_gatewayServerUri;

	private StringCollection m_discoveryUrls;

	private string m_semaphoreFilePath;

	private bool m_isOnline;

	[DataMember(Name = "ServerUri", IsRequired = false, Order = 1)]
	public string ServerUri
	{
		get
		{
			return m_serverUri;
		}
		set
		{
			m_serverUri = value;
		}
	}

	[DataMember(Name = "ProductUri", IsRequired = false, Order = 2)]
	public string ProductUri
	{
		get
		{
			return m_productUri;
		}
		set
		{
			m_productUri = value;
		}
	}

	[DataMember(Name = "ServerNames", IsRequired = false, Order = 3)]
	public LocalizedTextCollection ServerNames
	{
		get
		{
			return m_serverNames;
		}
		set
		{
			m_serverNames = value;
			if (value == null)
			{
				m_serverNames = new LocalizedTextCollection();
			}
		}
	}

	[DataMember(Name = "ServerType", IsRequired = false, Order = 4)]
	public ApplicationType ServerType
	{
		get
		{
			return m_serverType;
		}
		set
		{
			m_serverType = value;
		}
	}

	[DataMember(Name = "GatewayServerUri", IsRequired = false, Order = 5)]
	public string GatewayServerUri
	{
		get
		{
			return m_gatewayServerUri;
		}
		set
		{
			m_gatewayServerUri = value;
		}
	}

	[DataMember(Name = "DiscoveryUrls", IsRequired = false, Order = 6)]
	public StringCollection DiscoveryUrls
	{
		get
		{
			return m_discoveryUrls;
		}
		set
		{
			m_discoveryUrls = value;
			if (value == null)
			{
				m_discoveryUrls = new StringCollection();
			}
		}
	}

	[DataMember(Name = "SemaphoreFilePath", IsRequired = false, Order = 7)]
	public string SemaphoreFilePath
	{
		get
		{
			return m_semaphoreFilePath;
		}
		set
		{
			m_semaphoreFilePath = value;
		}
	}

	[DataMember(Name = "IsOnline", IsRequired = false, Order = 8)]
	public bool IsOnline
	{
		get
		{
			return m_isOnline;
		}
		set
		{
			m_isOnline = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.RegisteredServer;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.RegisteredServer_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.RegisteredServer_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.RegisteredServer_Encoding_DefaultJson;

	public RegisteredServer()
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
		m_serverUri = null;
		m_productUri = null;
		m_serverNames = new LocalizedTextCollection();
		m_serverType = ApplicationType.Server;
		m_gatewayServerUri = null;
		m_discoveryUrls = new StringCollection();
		m_semaphoreFilePath = null;
		m_isOnline = true;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteString("ServerUri", ServerUri);
		encoder.WriteString("ProductUri", ProductUri);
		encoder.WriteLocalizedTextArray("ServerNames", ServerNames);
		encoder.WriteEnumerated("ServerType", ServerType);
		encoder.WriteString("GatewayServerUri", GatewayServerUri);
		encoder.WriteStringArray("DiscoveryUrls", DiscoveryUrls);
		encoder.WriteString("SemaphoreFilePath", SemaphoreFilePath);
		encoder.WriteBoolean("IsOnline", IsOnline);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		ServerUri = decoder.ReadString("ServerUri");
		ProductUri = decoder.ReadString("ProductUri");
		ServerNames = decoder.ReadLocalizedTextArray("ServerNames");
		ServerType = (ApplicationType)(object)decoder.ReadEnumerated("ServerType", typeof(ApplicationType));
		GatewayServerUri = decoder.ReadString("GatewayServerUri");
		DiscoveryUrls = decoder.ReadStringArray("DiscoveryUrls");
		SemaphoreFilePath = decoder.ReadString("SemaphoreFilePath");
		IsOnline = decoder.ReadBoolean("IsOnline");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is RegisteredServer registeredServer))
		{
			return false;
		}
		if (!Utils.IsEqual(m_serverUri, registeredServer.m_serverUri))
		{
			return false;
		}
		if (!Utils.IsEqual(m_productUri, registeredServer.m_productUri))
		{
			return false;
		}
		if (!Utils.IsEqual(m_serverNames, registeredServer.m_serverNames))
		{
			return false;
		}
		if (!Utils.IsEqual(m_serverType, registeredServer.m_serverType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_gatewayServerUri, registeredServer.m_gatewayServerUri))
		{
			return false;
		}
		if (!Utils.IsEqual(m_discoveryUrls, registeredServer.m_discoveryUrls))
		{
			return false;
		}
		if (!Utils.IsEqual(m_semaphoreFilePath, registeredServer.m_semaphoreFilePath))
		{
			return false;
		}
		if (!Utils.IsEqual(m_isOnline, registeredServer.m_isOnline))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (RegisteredServer)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		RegisteredServer obj = (RegisteredServer)base.MemberwiseClone();
		obj.m_serverUri = (string)Utils.Clone(m_serverUri);
		obj.m_productUri = (string)Utils.Clone(m_productUri);
		obj.m_serverNames = (LocalizedTextCollection)Utils.Clone(m_serverNames);
		obj.m_serverType = (ApplicationType)Utils.Clone(m_serverType);
		obj.m_gatewayServerUri = (string)Utils.Clone(m_gatewayServerUri);
		obj.m_discoveryUrls = (StringCollection)Utils.Clone(m_discoveryUrls);
		obj.m_semaphoreFilePath = (string)Utils.Clone(m_semaphoreFilePath);
		obj.m_isOnline = (bool)Utils.Clone(m_isOnline);
		return obj;
	}
}
