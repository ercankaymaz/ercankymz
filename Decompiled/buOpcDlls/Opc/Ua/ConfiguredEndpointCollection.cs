using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/SDK/Configuration.xsd")]
[ComVisible(true)]
public class ConfiguredEndpointCollection : ICloneable
{
	private string m_filepath;

	private StringCollection m_knownHosts;

	private StringCollection m_discoveryUrls;

	private EndpointConfiguration m_defaultConfiguration;

	private List<ConfiguredEndpoint> m_endpoints;

	private Uri m_tcpProxyUrl;

	private const string kDiscoverySuffix = "/discovery";

	[DataMember(Name = "KnownHosts", IsRequired = false, Order = 1)]
	public StringCollection KnownHosts
	{
		get
		{
			return m_knownHosts;
		}
		set
		{
			if (value == null)
			{
				m_knownHosts = new StringCollection();
			}
			else
			{
				m_knownHosts = value;
			}
		}
	}

	[DataMember(Name = "Endpoints", IsRequired = false, Order = 2)]
	public List<ConfiguredEndpoint> Endpoints
	{
		get
		{
			return m_endpoints;
		}
		private set
		{
			if (value == null)
			{
				m_endpoints = new List<ConfiguredEndpoint>();
			}
			else
			{
				m_endpoints = value;
			}
			foreach (ConfiguredEndpoint endpoint in m_endpoints)
			{
				endpoint.Collection = this;
			}
		}
	}

	[DataMember(Name = "TcpProxyUrl", EmitDefaultValue = false, Order = 3)]
	public Uri TcpProxyUrl
	{
		get
		{
			return m_tcpProxyUrl;
		}
		set
		{
			m_tcpProxyUrl = value;
		}
	}

	public ConfiguredEndpoint this[int index]
	{
		get
		{
			return m_endpoints[index];
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	public int Count => m_endpoints.Count;

	public bool IsReadOnly => false;

	public StringCollection DiscoveryUrls
	{
		get
		{
			return m_discoveryUrls;
		}
		set
		{
			if (value == null)
			{
				m_discoveryUrls = new StringCollection(Utils.DiscoveryUrls);
			}
			else
			{
				m_discoveryUrls = value;
			}
		}
	}

	public EndpointConfiguration DefaultConfiguration => m_defaultConfiguration;

	public ConfiguredEndpointCollection()
	{
		Initialize();
	}

	[OnDeserializing]
	public void Initialize(StreamingContext context)
	{
		Initialize();
	}

	private void Initialize()
	{
		m_knownHosts = new StringCollection();
		m_discoveryUrls = new StringCollection(Utils.DiscoveryUrls);
		m_endpoints = new List<ConfiguredEndpoint>();
		m_defaultConfiguration = EndpointConfiguration.Create();
	}

	public ConfiguredEndpointCollection(EndpointConfiguration configuration)
	{
		Initialize();
		m_defaultConfiguration = (EndpointConfiguration)configuration.Clone();
	}

	public ConfiguredEndpointCollection(ApplicationConfiguration configuration)
	{
		Initialize();
		m_defaultConfiguration = EndpointConfiguration.Create(configuration);
		if (configuration.ClientConfiguration != null)
		{
			m_discoveryUrls = new StringCollection(configuration.ClientConfiguration.WellKnownDiscoveryUrls);
		}
	}

	public static ConfiguredEndpointCollection Load(ApplicationConfiguration configuration, string filePath)
	{
		return Load(configuration, filePath, overrideConfiguration: false);
	}

	public static ConfiguredEndpointCollection Load(ApplicationConfiguration configuration, string filePath, bool overrideConfiguration)
	{
		ConfiguredEndpointCollection configuredEndpointCollection = Load(filePath);
		configuredEndpointCollection.m_defaultConfiguration = EndpointConfiguration.Create(configuration);
		foreach (ConfiguredEndpoint endpoint in configuredEndpointCollection.Endpoints)
		{
			if (endpoint.Configuration == null || overrideConfiguration)
			{
				endpoint.Update(configuredEndpointCollection.DefaultConfiguration);
			}
		}
		return configuredEndpointCollection;
	}

	public static ConfiguredEndpointCollection Load(string filePath)
	{
		ConfiguredEndpointCollection configuredEndpointCollection;
		using (Stream istrm = File.OpenRead(filePath))
		{
			configuredEndpointCollection = Load(istrm);
		}
		configuredEndpointCollection.m_filepath = filePath;
		List<ConfiguredEndpoint> list = new List<ConfiguredEndpoint>();
		Dictionary<string, ApplicationDescription> dictionary = new Dictionary<string, ApplicationDescription>();
		foreach (ConfiguredEndpoint endpoint in configuredEndpointCollection.m_endpoints)
		{
			if (endpoint.Description == null)
			{
				list.Add(endpoint);
				continue;
			}
			if (endpoint.Description.Server == null)
			{
				endpoint.Description.Server = new ApplicationDescription();
				endpoint.Description.Server.ApplicationType = ApplicationType.Server;
			}
			if (string.IsNullOrEmpty(endpoint.Description.Server.ApplicationUri))
			{
				endpoint.Description.Server.ApplicationUri = endpoint.Description.EndpointUrl;
			}
			if (endpoint.Description.Server.DiscoveryUrls == null)
			{
				endpoint.Description.Server.DiscoveryUrls = new StringCollection();
			}
			if (endpoint.Description.Server.DiscoveryUrls.Count == 0)
			{
				string text = endpoint.Description.EndpointUrl;
				if (text.StartsWith("http"))
				{
					text += "/discovery";
				}
				endpoint.Description.Server.DiscoveryUrls.Add(text);
			}
			if (endpoint.Description.TransportProfileUri != null)
			{
				endpoint.Description.TransportProfileUri = Profiles.NormalizeUri(endpoint.Description.TransportProfileUri);
			}
			ApplicationDescription value = null;
			if (!dictionary.TryGetValue(endpoint.Description.Server.ApplicationUri, out value))
			{
				value = endpoint.Description.Server;
				dictionary[value.ApplicationUri] = value;
				value.ApplicationUri = Utils.UpdateInstanceUri(value.ApplicationUri);
				dictionary[value.ApplicationUri] = value;
			}
			else
			{
				endpoint.Description.Server = (ApplicationDescription)value.Clone();
			}
		}
		foreach (ConfiguredEndpoint item in list)
		{
			configuredEndpointCollection.Remove(item);
		}
		return configuredEndpointCollection;
	}

	public static ConfiguredEndpointCollection Load(Stream istrm)
	{
		try
		{
			ConfiguredEndpointCollection configuredEndpointCollection = new DataContractSerializer(typeof(ConfiguredEndpointCollection)).ReadObject(istrm) as ConfiguredEndpointCollection;
			if (configuredEndpointCollection != null)
			{
				foreach (ConfiguredEndpoint item in configuredEndpointCollection)
				{
					if (item.Description != null)
					{
						item.Description.TransportProfileUri = Profiles.NormalizeUri(item.Description.TransportProfileUri);
					}
				}
			}
			return configuredEndpointCollection;
		}
		catch (Exception exception)
		{
			Utils.LogError(exception, "Unexpected error loading ConfiguredEndpoints.");
			throw;
		}
	}

	public void Save()
	{
		Save(m_filepath);
	}

	public void Save(string filePath)
	{
		using (Stream ostrm = File.Open(filePath, FileMode.Create))
		{
			Save(ostrm);
		}
		m_filepath = filePath;
	}

	public void Save(Stream ostrm)
	{
		new DataContractSerializer(typeof(ConfiguredEndpointCollection)).WriteObject(ostrm, this);
	}

	public virtual object Clone()
	{
		return MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ConfiguredEndpointCollection configuredEndpointCollection = new ConfiguredEndpointCollection();
		configuredEndpointCollection.m_filepath = m_filepath;
		configuredEndpointCollection.m_knownHosts = new StringCollection(m_knownHosts);
		configuredEndpointCollection.m_defaultConfiguration = (EndpointConfiguration)m_defaultConfiguration.MemberwiseClone();
		foreach (ConfiguredEndpoint endpoint in m_endpoints)
		{
			ConfiguredEndpoint configuredEndpoint = (ConfiguredEndpoint)endpoint.MemberwiseClone();
			configuredEndpoint.Collection = configuredEndpointCollection;
			configuredEndpointCollection.m_endpoints.Add(configuredEndpoint);
		}
		return configuredEndpointCollection;
	}

	public int IndexOf(ConfiguredEndpoint item)
	{
		for (int i = 0; i < m_endpoints.Count; i++)
		{
			if (item == m_endpoints[i])
			{
				return i;
			}
		}
		return -1;
	}

	public void Insert(int index, ConfiguredEndpoint item)
	{
		Insert(item, index);
	}

	public void RemoveAt(int index)
	{
		if (index < 0 || index >= m_endpoints.Count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		Remove(m_endpoints[index]);
	}

	public void Clear()
	{
		m_endpoints.Clear();
	}

	public bool Contains(ConfiguredEndpoint item)
	{
		for (int i = 0; i < m_endpoints.Count; i++)
		{
			if (item == m_endpoints[i])
			{
				return true;
			}
		}
		return false;
	}

	public void CopyTo(ConfiguredEndpoint[] array, int arrayIndex)
	{
		m_endpoints.CopyTo(array, arrayIndex);
	}

	public IEnumerator<ConfiguredEndpoint> GetEnumerator()
	{
		return m_endpoints.GetEnumerator();
	}

	public ConfiguredEndpoint Add(EndpointDescription endpoint)
	{
		return Add(endpoint, null);
	}

	public ConfiguredEndpoint Add(EndpointDescription endpoint, EndpointConfiguration configuration)
	{
		ValidateEndpoint(endpoint);
		foreach (ConfiguredEndpoint endpoint2 in m_endpoints)
		{
			if (endpoint2.Description == endpoint)
			{
				throw new ArgumentException("Endpoint already exists in the collection.");
			}
		}
		ConfiguredEndpoint configuredEndpoint = new ConfiguredEndpoint(this, endpoint, configuration);
		m_endpoints.Add(configuredEndpoint);
		return configuredEndpoint;
	}

	public void Add(ConfiguredEndpoint item)
	{
		Insert(item, -1);
	}

	private void Insert(ConfiguredEndpoint endpoint, int index)
	{
		if (endpoint == null)
		{
			throw new ArgumentNullException("endpoint");
		}
		ValidateEndpoint(endpoint.Description);
		if (endpoint.Collection != null)
		{
			endpoint.Collection.Remove(endpoint);
		}
		endpoint.Collection = this;
		if (endpoint.Collection != this)
		{
			throw new ArgumentException("Cannot add an endpoint from another collection.");
		}
		if (m_endpoints.Contains(endpoint))
		{
			throw new ArgumentException("Endpoint already belongs to the collection.");
		}
		if (index < 0)
		{
			m_endpoints.Add(endpoint);
		}
		else
		{
			m_endpoints.Insert(index, endpoint);
		}
	}

	public bool Remove(ConfiguredEndpoint item)
	{
		if (item == null)
		{
			throw new ArgumentNullException("item");
		}
		return m_endpoints.Remove(item);
	}

	public void RemoveServer(string serverUri)
	{
		if (serverUri == null)
		{
			throw new ArgumentNullException("serverUri");
		}
		foreach (ConfiguredEndpoint endpoint in GetEndpoints(serverUri))
		{
			Remove(endpoint);
		}
	}

	public void SetApplicationDescription(string serverUri, ApplicationDescription server)
	{
		if (server == null)
		{
			throw new ArgumentNullException("server");
		}
		if (string.IsNullOrEmpty(server.ApplicationUri))
		{
			throw new ArgumentException("A ServerUri must provided.", "server");
		}
		if (server.DiscoveryUrls.Count == 0)
		{
			throw new ArgumentException("At least one DiscoveryUrl must be provided.", "server");
		}
		if (GetEndpoints(server.ApplicationUri).Count == 0)
		{
			string text = null;
			for (int i = 0; i < server.DiscoveryUrls.Count; i++)
			{
				if (!string.IsNullOrEmpty(server.DiscoveryUrls[i]))
				{
					text = server.DiscoveryUrls[i];
					break;
				}
			}
			if (text != null && text.StartsWith("http", StringComparison.Ordinal) && text.EndsWith("/discovery", StringComparison.Ordinal))
			{
				text = text.Substring(0, text.Length - "/discovery".Length);
			}
			if (text != null)
			{
				ConfiguredEndpoint configuredEndpoint = Create(text);
				configuredEndpoint.Description.Server = (ApplicationDescription)server.MemberwiseClone();
				Add(configuredEndpoint);
			}
			return;
		}
		foreach (ConfiguredEndpoint endpoint in GetEndpoints(serverUri))
		{
			endpoint.Description.Server = (ApplicationDescription)server.MemberwiseClone();
		}
	}

	public ConfiguredEndpoint Create(string url)
	{
		string text = null;
		int num = url.IndexOf("- [", StringComparison.Ordinal);
		if (num != -1)
		{
			text = url.Substring(num + 3);
			url = url.Substring(0, num).Trim();
		}
		MessageSecurityMode securityMode = MessageSecurityMode.SignAndEncrypt;
		string securityPolicyUri = "http://opcfoundation.org/UA/SecurityPolicy#Basic256Sha256";
		bool useBinaryEncoding = true;
		if (!string.IsNullOrEmpty(text))
		{
			string[] array = text.Split(new char[4] { '-', '[', ':', ']' }, StringSplitOptions.RemoveEmptyEntries);
			try
			{
				securityMode = ((array.Length == 0) ? MessageSecurityMode.None : ((MessageSecurityMode)Enum.Parse(typeof(MessageSecurityMode), array[0], ignoreCase: false)));
			}
			catch
			{
				securityMode = MessageSecurityMode.None;
			}
			try
			{
				securityPolicyUri = ((array.Length <= 1) ? "http://opcfoundation.org/UA/SecurityPolicy#None" : SecurityPolicies.GetUri(array[1]));
			}
			catch
			{
				securityPolicyUri = "http://opcfoundation.org/UA/SecurityPolicy#None";
			}
			try
			{
				useBinaryEncoding = array.Length > 2 && array[2] == "Binary";
			}
			catch
			{
				useBinaryEncoding = false;
			}
		}
		Uri uri = new Uri(url);
		EndpointDescription endpointDescription = new EndpointDescription();
		endpointDescription.EndpointUrl = uri.ToString();
		endpointDescription.SecurityMode = securityMode;
		endpointDescription.SecurityPolicyUri = securityPolicyUri;
		endpointDescription.Server.ApplicationUri = Utils.UpdateInstanceUri(uri.ToString());
		endpointDescription.Server.ApplicationName = uri.AbsolutePath;
		if (endpointDescription.EndpointUrl.StartsWith("opc.tcp", StringComparison.Ordinal))
		{
			endpointDescription.TransportProfileUri = "http://opcfoundation.org/UA-Profile/Transport/uatcp-uasc-uabinary";
			endpointDescription.Server.DiscoveryUrls.Add(endpointDescription.EndpointUrl);
		}
		else if (Utils.IsUriHttpsScheme(endpointDescription.EndpointUrl))
		{
			endpointDescription.TransportProfileUri = "http://opcfoundation.org/UA-Profile/Transport/https-uabinary";
			endpointDescription.Server.DiscoveryUrls.Add(endpointDescription.EndpointUrl);
		}
		else if (endpointDescription.EndpointUrl.StartsWith("opc.wss", StringComparison.Ordinal))
		{
			endpointDescription.TransportProfileUri = "http://opcfoundation.org/UA-Profile/Transport/uatcp-uasc-uabinary";
			endpointDescription.Server.DiscoveryUrls.Add(endpointDescription.EndpointUrl);
		}
		return new ConfiguredEndpoint(this, endpointDescription, null)
		{
			Configuration = 
			{
				UseBinaryEncoding = useBinaryEncoding
			},
			UpdateBeforeConnect = true
		};
	}

	public List<ConfiguredEndpoint> GetEndpoints(string serverUri)
	{
		List<ConfiguredEndpoint> list = new List<ConfiguredEndpoint>();
		foreach (ConfiguredEndpoint endpoint in m_endpoints)
		{
			if (endpoint.Description.Server.ApplicationUri == serverUri)
			{
				list.Add(endpoint);
			}
		}
		return list;
	}

	public ApplicationDescriptionCollection GetServers()
	{
		Dictionary<string, ApplicationDescription> dictionary = new Dictionary<string, ApplicationDescription>();
		foreach (ConfiguredEndpoint endpoint in m_endpoints)
		{
			ApplicationDescription server = endpoint.Description.Server;
			if (!string.IsNullOrEmpty(server.ApplicationUri) && !dictionary.ContainsKey(server.ApplicationUri))
			{
				dictionary.Add(server.ApplicationUri, server);
			}
		}
		return new ApplicationDescriptionCollection(dictionary.Values);
	}

	[Obsolete("Non-functional - replaced with GetEndpoints()")]
	public List<ConfiguredEndpoint> CopyEndpoints(string serverUri)
	{
		return null;
	}

	[Obsolete("Non-functional - method not used - updates should be done with ConfiguredEndpoint.UpdateFromServer()")]
	public void UpdateEndpointsForServer(string serverUri)
	{
	}

	private static void ValidateEndpoint(EndpointDescription endpoint)
	{
		if (endpoint == null)
		{
			throw new ArgumentException("Endpoint must not be null.");
		}
		if (string.IsNullOrEmpty(endpoint.EndpointUrl))
		{
			throw new ArgumentException("Endpoint must have a valid URL.");
		}
		if (endpoint.Server == null)
		{
			endpoint.Server = new ApplicationDescription();
			endpoint.Server.ApplicationType = ApplicationType.Server;
		}
		if (string.IsNullOrEmpty(endpoint.Server.ApplicationUri))
		{
			endpoint.Server.ApplicationUri = endpoint.EndpointUrl;
		}
	}
}
