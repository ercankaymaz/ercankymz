using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/SDK/Configuration.xsd")]
[ComVisible(true)]
public class ServerBaseConfiguration
{
	private StringCollection m_baseAddresses;

	private StringCollection m_alternateBaseAddresses;

	private ServerSecurityPolicyCollection m_securityPolicies;

	private int m_minRequestThreadCount;

	private int m_maxRequestThreadCount;

	private int m_maxQueuedRequestCount;

	[DataMember(IsRequired = false, Order = 0)]
	public StringCollection BaseAddresses
	{
		get
		{
			return m_baseAddresses;
		}
		set
		{
			m_baseAddresses = value;
			if (m_baseAddresses == null)
			{
				m_baseAddresses = new StringCollection();
			}
		}
	}

	[DataMember(IsRequired = false, Order = 1)]
	public StringCollection AlternateBaseAddresses
	{
		get
		{
			return m_alternateBaseAddresses;
		}
		set
		{
			m_alternateBaseAddresses = value;
			if (m_alternateBaseAddresses == null)
			{
				m_alternateBaseAddresses = new StringCollection();
			}
		}
	}

	[DataMember(IsRequired = false, Order = 2)]
	public ServerSecurityPolicyCollection SecurityPolicies
	{
		get
		{
			return m_securityPolicies;
		}
		set
		{
			m_securityPolicies = value;
			if (m_securityPolicies == null)
			{
				m_securityPolicies = new ServerSecurityPolicyCollection();
			}
		}
	}

	[DataMember(IsRequired = false, Order = 3)]
	public int MinRequestThreadCount
	{
		get
		{
			return m_minRequestThreadCount;
		}
		set
		{
			m_minRequestThreadCount = value;
		}
	}

	[DataMember(IsRequired = false, Order = 4)]
	public int MaxRequestThreadCount
	{
		get
		{
			return m_maxRequestThreadCount;
		}
		set
		{
			m_maxRequestThreadCount = value;
		}
	}

	[DataMember(IsRequired = false, Order = 5)]
	public int MaxQueuedRequestCount
	{
		get
		{
			return m_maxQueuedRequestCount;
		}
		set
		{
			m_maxQueuedRequestCount = value;
		}
	}

	public ServerBaseConfiguration()
	{
		Initialize();
	}

	private void Initialize()
	{
		m_baseAddresses = new StringCollection();
		m_alternateBaseAddresses = new StringCollection();
		m_securityPolicies = new ServerSecurityPolicyCollection();
		m_minRequestThreadCount = 10;
		m_maxRequestThreadCount = 100;
		m_maxQueuedRequestCount = 200;
	}

	[OnDeserializing]
	public void Initialize(StreamingContext context)
	{
		Initialize();
	}

	[OnDeserialized]
	private void ValidateSecurityPolicyCollection(StreamingContext context)
	{
		string[] displayNames = Opc.Ua.SecurityPolicies.GetDisplayNames();
		ServerSecurityPolicyCollection serverSecurityPolicyCollection = new ServerSecurityPolicyCollection();
		foreach (ServerSecurityPolicy securityPolicy in m_securityPolicies)
		{
			if (string.IsNullOrWhiteSpace(securityPolicy.SecurityPolicyUri))
			{
				string[] defaultUris = Opc.Ua.SecurityPolicies.GetDefaultUris();
				foreach (string securityPolicyUri in defaultUris)
				{
					ServerSecurityPolicy newPolicy = new ServerSecurityPolicy
					{
						SecurityMode = securityPolicy.SecurityMode,
						SecurityPolicyUri = securityPolicyUri
					};
					if (serverSecurityPolicyCollection.Find((ServerSecurityPolicy s) => s.SecurityMode == newPolicy.SecurityMode && string.Equals(s.SecurityPolicyUri, newPolicy.SecurityPolicyUri, StringComparison.Ordinal)) == null)
					{
						serverSecurityPolicyCollection.Add(newPolicy);
					}
				}
				continue;
			}
			for (int num = 0; num < displayNames.Length; num++)
			{
				if (securityPolicy.SecurityPolicyUri.Contains(displayNames[num]))
				{
					if (serverSecurityPolicyCollection.Find((ServerSecurityPolicy s) => s.SecurityMode == securityPolicy.SecurityMode && string.Equals(s.SecurityPolicyUri, securityPolicy.SecurityPolicyUri, StringComparison.Ordinal)) == null)
					{
						serverSecurityPolicyCollection.Add(securityPolicy);
					}
					break;
				}
			}
		}
		m_securityPolicies = serverSecurityPolicyCollection;
	}

	public virtual void Validate()
	{
		if (m_securityPolicies.Count == 0)
		{
			m_securityPolicies.Add(new ServerSecurityPolicy());
		}
	}
}
