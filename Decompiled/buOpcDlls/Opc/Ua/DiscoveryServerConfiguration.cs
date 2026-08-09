using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/SDK/Configuration.xsd")]
[ComVisible(true)]
public class DiscoveryServerConfiguration : ServerBaseConfiguration
{
	private LocalizedTextCollection m_serverNames;

	private string m_discoveryServerCacheFile;

	private ServerRegistrationCollection m_serverRegistrations;

	[DataMember(IsRequired = false, EmitDefaultValue = false, Order = 2)]
	public LocalizedTextCollection ServerNames
	{
		get
		{
			return m_serverNames;
		}
		set
		{
			m_serverNames = value;
			if (m_serverNames == null)
			{
				m_serverNames = new LocalizedTextCollection();
			}
		}
	}

	[DataMember(IsRequired = false, Order = 3)]
	public string DiscoveryServerCacheFile
	{
		get
		{
			return m_discoveryServerCacheFile;
		}
		set
		{
			m_discoveryServerCacheFile = value;
		}
	}

	[DataMember(IsRequired = false, EmitDefaultValue = false, Order = 4)]
	public ServerRegistrationCollection ServerRegistrations
	{
		get
		{
			return m_serverRegistrations;
		}
		set
		{
			m_serverRegistrations = value;
		}
	}

	public DiscoveryServerConfiguration()
	{
		Initialize();
	}

	private void Initialize()
	{
		m_serverNames = new LocalizedTextCollection();
		m_serverRegistrations = new ServerRegistrationCollection();
	}

	[OnDeserializing]
	public new void Initialize(StreamingContext context)
	{
		Initialize();
	}
}
