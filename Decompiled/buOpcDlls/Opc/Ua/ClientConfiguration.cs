using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/SDK/Configuration.xsd")]
[ComVisible(true)]
public class ClientConfiguration
{
	private StringCollection m_wellKnownDiscoveryUrls;

	private EndpointDescriptionCollection m_discoveryServers;

	private int m_defaultSessionTimeout;

	private string m_endpointCacheFilePath;

	private int m_minSubscriptionLifetime;

	private ReverseConnectClientConfiguration m_reverseConnect;

	private OperationLimits m_operationLimits;

	[DataMember(IsRequired = false, Order = 0)]
	public int DefaultSessionTimeout
	{
		get
		{
			return m_defaultSessionTimeout;
		}
		set
		{
			m_defaultSessionTimeout = value;
		}
	}

	[DataMember(IsRequired = false, EmitDefaultValue = false, Order = 1)]
	public StringCollection WellKnownDiscoveryUrls
	{
		get
		{
			return m_wellKnownDiscoveryUrls;
		}
		set
		{
			m_wellKnownDiscoveryUrls = value;
			if (m_wellKnownDiscoveryUrls == null)
			{
				m_wellKnownDiscoveryUrls = new StringCollection();
			}
		}
	}

	[DataMember(IsRequired = false, EmitDefaultValue = false, Order = 2)]
	public EndpointDescriptionCollection DiscoveryServers
	{
		get
		{
			return m_discoveryServers;
		}
		set
		{
			m_discoveryServers = value;
			if (m_discoveryServers == null)
			{
				m_discoveryServers = new EndpointDescriptionCollection();
			}
		}
	}

	[DataMember(IsRequired = false, Order = 3)]
	public string EndpointCacheFilePath
	{
		get
		{
			return m_endpointCacheFilePath;
		}
		set
		{
			m_endpointCacheFilePath = value;
		}
	}

	[DataMember(IsRequired = false, Order = 4)]
	public int MinSubscriptionLifetime
	{
		get
		{
			return m_minSubscriptionLifetime;
		}
		set
		{
			m_minSubscriptionLifetime = value;
		}
	}

	[DataMember(IsRequired = false, Order = 5)]
	public ReverseConnectClientConfiguration ReverseConnect
	{
		get
		{
			return m_reverseConnect;
		}
		set
		{
			m_reverseConnect = value;
		}
	}

	[DataMember(IsRequired = false, Order = 6)]
	public OperationLimits OperationLimits
	{
		get
		{
			return m_operationLimits;
		}
		set
		{
			m_operationLimits = value;
		}
	}

	public ClientConfiguration()
	{
		Initialize();
	}

	private void Initialize()
	{
		m_defaultSessionTimeout = 60000;
		m_minSubscriptionLifetime = 10000;
		m_wellKnownDiscoveryUrls = new StringCollection();
		m_discoveryServers = new EndpointDescriptionCollection();
		m_operationLimits = new OperationLimits();
	}

	[OnDeserializing]
	public void Initialize(StreamingContext context)
	{
		Initialize();
	}

	public void Validate()
	{
		if (WellKnownDiscoveryUrls.Count == 0)
		{
			WellKnownDiscoveryUrls.AddRange(Utils.DiscoveryUrls);
		}
	}
}
