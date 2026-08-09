using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/SDK/Configuration.xsd")]
[ComVisible(true)]
public class ServerRegistration
{
	private string m_applicationUri;

	private StringCollection m_alternateDiscoveryUrls;

	[DataMember(IsRequired = false, EmitDefaultValue = false, Order = 1)]
	public string ApplicationUri
	{
		get
		{
			return m_applicationUri;
		}
		set
		{
			m_applicationUri = value;
		}
	}

	[DataMember(IsRequired = false, EmitDefaultValue = false, Order = 2)]
	public StringCollection AlternateDiscoveryUrls
	{
		get
		{
			return m_alternateDiscoveryUrls;
		}
		set
		{
			m_alternateDiscoveryUrls = value;
			if (m_alternateDiscoveryUrls == null)
			{
				m_alternateDiscoveryUrls = new StringCollection();
			}
		}
	}

	public ServerRegistration()
	{
		Initialize();
	}

	private void Initialize()
	{
		m_applicationUri = null;
		m_alternateDiscoveryUrls = new StringCollection();
	}

	[OnDeserializing]
	public void Initialize(StreamingContext context)
	{
		Initialize();
	}
}
