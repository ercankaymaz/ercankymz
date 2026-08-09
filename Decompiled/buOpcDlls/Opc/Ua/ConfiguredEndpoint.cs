using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/SDK/Configuration.xsd")]
[KnownType(typeof(UserNameIdentityToken))]
[KnownType(typeof(X509IdentityToken))]
[KnownType(typeof(IssuedIdentityToken))]
[ComVisible(true)]
public class ConfiguredEndpoint : IFormattable, ICloneable
{
	private ConfiguredEndpointCollection m_collection;

	private EndpointDescription m_description;

	private EndpointConfiguration m_configuration;

	private bool m_updateBeforeConnect;

	private BinaryEncodingSupport m_binaryEncodingSupport;

	private int m_selectedUserTokenPolicyIndex;

	private UserIdentityToken m_userIdentity;

	private ReverseConnectEndpoint m_reverseConnect;

	private XmlElementCollection m_extensions;

	private const string kDiscoverySuffix = "/discovery";

	[DataMember(Name = "Endpoint", Order = 1, IsRequired = true)]
	public EndpointDescription Description
	{
		get
		{
			return m_description;
		}
		private set
		{
			if (value == null)
			{
				m_description = new EndpointDescription();
			}
			else
			{
				m_description = value;
			}
		}
	}

	[DataMember(Name = "Configuration", Order = 2, IsRequired = false)]
	public EndpointConfiguration Configuration
	{
		get
		{
			return m_configuration;
		}
		set
		{
			m_configuration = value;
			if (m_configuration == null)
			{
				if (m_collection != null)
				{
					Update(m_collection.DefaultConfiguration);
				}
				else
				{
					Update(EndpointConfiguration.Create());
				}
			}
		}
	}

	[DataMember(Name = "UpdateBeforeConnect", Order = 3, IsRequired = false)]
	public bool UpdateBeforeConnect
	{
		get
		{
			return m_updateBeforeConnect;
		}
		set
		{
			m_updateBeforeConnect = value;
		}
	}

	[DataMember(Name = "BinaryEncodingSupport", Order = 4, IsRequired = false)]
	public BinaryEncodingSupport BinaryEncodingSupport
	{
		get
		{
			return m_binaryEncodingSupport;
		}
		set
		{
			m_binaryEncodingSupport = value;
		}
	}

	[DataMember(Name = "SelectedUserTokenPolicy", Order = 5, IsRequired = false)]
	public int SelectedUserTokenPolicyIndex
	{
		get
		{
			return m_selectedUserTokenPolicyIndex;
		}
		set
		{
			m_selectedUserTokenPolicyIndex = value;
		}
	}

	[DataMember(Name = "UserIdentity", Order = 6, IsRequired = false)]
	public UserIdentityToken UserIdentity
	{
		get
		{
			return m_userIdentity;
		}
		set
		{
			m_userIdentity = value;
		}
	}

	[DataMember(Name = "ReverseConnect", Order = 8, IsRequired = false)]
	public ReverseConnectEndpoint ReverseConnect
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

	[DataMember(IsRequired = false, EmitDefaultValue = false, Order = 9)]
	public XmlElementCollection Extensions
	{
		get
		{
			return m_extensions;
		}
		set
		{
			m_extensions = value;
		}
	}

	public ConfiguredEndpointCollection Collection
	{
		get
		{
			return m_collection;
		}
		internal set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			m_collection = value;
		}
	}

	public Uri EndpointUrl
	{
		get
		{
			if (string.IsNullOrEmpty(m_description.EndpointUrl))
			{
				return null;
			}
			return Utils.ParseUri(m_description.EndpointUrl);
		}
		set
		{
			if (value == null)
			{
				m_description.EndpointUrl = null;
			}
			m_description.EndpointUrl = string.Format(CultureInfo.InvariantCulture, "{0}", value);
		}
	}

	public UserTokenPolicy SelectedUserTokenPolicy
	{
		get
		{
			if (m_description != null && m_description.UserIdentityTokens != null)
			{
				UserTokenPolicyCollection userIdentityTokens = m_description.UserIdentityTokens;
				if (m_selectedUserTokenPolicyIndex >= 0 && userIdentityTokens.Count > m_selectedUserTokenPolicyIndex)
				{
					return userIdentityTokens[m_selectedUserTokenPolicyIndex];
				}
			}
			return null;
		}
		set
		{
			if (m_description != null && m_description.UserIdentityTokens != null)
			{
				UserTokenPolicyCollection userIdentityTokens = m_description.UserIdentityTokens;
				for (int i = 0; i < userIdentityTokens.Count; i++)
				{
					if (userIdentityTokens[i] == value)
					{
						m_selectedUserTokenPolicyIndex = i;
						break;
					}
				}
			}
			m_selectedUserTokenPolicyIndex = -1;
		}
	}

	public ConfiguredEndpoint()
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
		m_collection = null;
		m_description = new EndpointDescription();
		m_configuration = null;
		m_updateBeforeConnect = true;
		m_binaryEncodingSupport = BinaryEncodingSupport.Optional;
		m_selectedUserTokenPolicyIndex = 0;
		m_userIdentity = null;
		m_reverseConnect = null;
	}

	public ConfiguredEndpoint(ApplicationDescription server, EndpointConfiguration configuration)
	{
		if (server == null)
		{
			throw new ArgumentNullException("server");
		}
		m_description = new EndpointDescription();
		m_updateBeforeConnect = true;
		m_description.Server = server;
		foreach (string discoveryUrl in server.DiscoveryUrls)
		{
			string text = discoveryUrl;
			if (text != null && text.StartsWith("http", StringComparison.Ordinal) && text.EndsWith("/discovery", StringComparison.Ordinal))
			{
				text = text.Substring(0, text.Length - "/discovery".Length);
			}
			Uri uri = Utils.ParseUri(text);
			if (uri != null)
			{
				m_description.EndpointUrl = uri.ToString();
				m_description.SecurityMode = MessageSecurityMode.SignAndEncrypt;
				m_description.SecurityPolicyUri = "http://opcfoundation.org/UA/SecurityPolicy#Basic256Sha256";
				m_description.UserIdentityTokens.Add(new UserTokenPolicy(UserTokenType.Anonymous));
				if (uri.Scheme == "opc.tcp")
				{
					m_description.TransportProfileUri = "http://opcfoundation.org/UA-Profile/Transport/uatcp-uasc-uabinary";
				}
				else if (Utils.IsUriHttpsScheme(uri.Scheme))
				{
					m_description.TransportProfileUri = "http://opcfoundation.org/UA-Profile/Transport/https-uabinary";
				}
				else if (uri.Scheme == "opc.wss")
				{
					m_description.TransportProfileUri = "http://opcfoundation.org/UA-Profile/Transport/uawss-uasc-uabinary";
				}
				break;
			}
		}
		if (configuration == null)
		{
			configuration = EndpointConfiguration.Create();
		}
		Update(configuration);
	}

	public ConfiguredEndpoint(ConfiguredEndpointCollection collection, EndpointDescription description)
		: this(collection, description, null)
	{
	}

	public ConfiguredEndpoint(ConfiguredEndpointCollection collection, EndpointDescription description, EndpointConfiguration configuration)
	{
		if (description == null)
		{
			throw new ArgumentNullException("description");
		}
		m_collection = collection;
		m_description = description;
		m_updateBeforeConnect = true;
		if (configuration == null)
		{
			configuration = ((collection == null) ? EndpointConfiguration.Create() : collection.DefaultConfiguration);
		}
		Update(configuration);
	}

	public virtual object Clone()
	{
		return MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ConfiguredEndpoint configuredEndpoint = new ConfiguredEndpoint();
		configuredEndpoint.Collection = Collection;
		configuredEndpoint.Update(this);
		return configuredEndpoint;
	}

	public override string ToString()
	{
		return ToString(null, null);
	}

	public string ToString(string format, IFormatProvider formatProvider)
	{
		if (format == null)
		{
			return Utils.Format("{0} - [{1}:{2}:{3}]", m_description.EndpointUrl, m_description.SecurityMode, SecurityPolicies.GetDisplayName(m_description.SecurityPolicyUri), (m_configuration != null && m_configuration.UseBinaryEncoding) ? "Binary" : "XML");
		}
		throw new FormatException(Utils.Format("Invalid format string: '{0}'.", format));
	}

	public bool NeedUpdateFromServer()
	{
		bool flag = Description.ServerCertificate != null && Description.ServerCertificate.Length != 0;
		bool num = SelectedUserTokenPolicy.TokenType != UserTokenType.Anonymous && (SelectedUserTokenPolicy.SecurityPolicyUri ?? "http://opcfoundation.org/UA/SecurityPolicy#None") != "http://opcfoundation.org/UA/SecurityPolicy#None";
		bool flag2 = Description.SecurityPolicyUri != "http://opcfoundation.org/UA/SecurityPolicy#None";
		if (num || flag2)
		{
			return !flag;
		}
		return false;
	}

	public void Update(ConfiguredEndpoint endpoint)
	{
		if (endpoint == null)
		{
			throw new ArgumentNullException("endpoint");
		}
		m_description = (EndpointDescription)endpoint.Description.MemberwiseClone();
		m_configuration = (EndpointConfiguration)endpoint.Configuration.MemberwiseClone();
		if (m_description.TransportProfileUri != null)
		{
			m_description.TransportProfileUri = Profiles.NormalizeUri(m_description.TransportProfileUri);
		}
		m_updateBeforeConnect = endpoint.m_updateBeforeConnect;
		m_selectedUserTokenPolicyIndex = endpoint.m_selectedUserTokenPolicyIndex;
		m_binaryEncodingSupport = endpoint.m_binaryEncodingSupport;
		if (endpoint.m_userIdentity != null)
		{
			m_userIdentity = (UserIdentityToken)endpoint.m_userIdentity.MemberwiseClone();
		}
	}

	public void Update(EndpointDescription description)
	{
		if (description == null)
		{
			throw new ArgumentNullException("description");
		}
		m_description = (EndpointDescription)description.MemberwiseClone();
		if (m_description.TransportProfileUri != null)
		{
			m_description.TransportProfileUri = Profiles.NormalizeUri(m_description.TransportProfileUri);
		}
		if (m_collection != null && m_description.EndpointUrl != null && m_description.EndpointUrl.StartsWith("opc.tcp", StringComparison.Ordinal))
		{
			m_description.ProxyUrl = m_collection.TcpProxyUrl;
		}
	}

	public void Update(EndpointConfiguration configuration)
	{
		if (configuration == null)
		{
			throw new ArgumentNullException("configuration");
		}
		m_configuration = (EndpointConfiguration)configuration.MemberwiseClone();
		BinaryEncodingSupport binaryEncodingSupport = m_description.EncodingSupport;
		if (binaryEncodingSupport == BinaryEncodingSupport.Optional)
		{
			binaryEncodingSupport = m_binaryEncodingSupport;
		}
		if (binaryEncodingSupport == BinaryEncodingSupport.None)
		{
			m_configuration.UseBinaryEncoding = false;
		}
		if (binaryEncodingSupport == BinaryEncodingSupport.Required)
		{
			m_configuration.UseBinaryEncoding = true;
		}
	}

	public void UpdateFromServer()
	{
		UpdateFromServer(EndpointUrl, m_description.SecurityMode, m_description.SecurityPolicyUri);
	}

	public void UpdateFromServer(Uri endpointUrl, MessageSecurityMode securityMode, string securityPolicyUri)
	{
		UpdateFromServer(endpointUrl, null, securityMode, securityPolicyUri);
	}

	public void UpdateFromServer(Uri endpointUrl, ITransportWaitingConnection connection, MessageSecurityMode securityMode, string securityPolicyUri)
	{
		Uri discoveryUrl = GetDiscoveryUrl(endpointUrl);
		DiscoveryClient discoveryClient = ((connection == null) ? DiscoveryClient.Create(discoveryUrl, m_configuration) : DiscoveryClient.Create(connection, m_configuration));
		try
		{
			EndpointDescriptionCollection endpoints = discoveryClient.GetEndpoints(null);
			EndpointDescriptionCollection matches = MatchEndpoints(endpoints, endpointUrl, securityMode, securityPolicyUri);
			EndpointDescription description = SelectBestMatch(matches, discoveryUrl);
			Update(description);
		}
		finally
		{
			discoveryClient.Close();
		}
	}

	public Task UpdateFromServerAsync(CancellationToken ct = default(CancellationToken))
	{
		return UpdateFromServerAsync(EndpointUrl, m_description.SecurityMode, m_description.SecurityPolicyUri, ct);
	}

	public Task UpdateFromServerAsync(Uri endpointUrl, MessageSecurityMode securityMode, string securityPolicyUri, CancellationToken ct = default(CancellationToken))
	{
		return UpdateFromServerAsync(endpointUrl, null, securityMode, securityPolicyUri, ct);
	}

	public async Task UpdateFromServerAsync(Uri endpointUrl, ITransportWaitingConnection connection, MessageSecurityMode securityMode, string securityPolicyUri, CancellationToken ct = default(CancellationToken))
	{
		Uri discoveryUrl = GetDiscoveryUrl(endpointUrl);
		DiscoveryClient client = ((connection == null) ? DiscoveryClient.Create(discoveryUrl, m_configuration) : DiscoveryClient.Create(connection, m_configuration));
		try
		{
			EndpointDescriptionCollection matches = MatchEndpoints(await client.GetEndpointsAsync(null, ct).ConfigureAwait(continueOnCapturedContext: false), endpointUrl, securityMode, securityPolicyUri);
			EndpointDescription description = SelectBestMatch(matches, discoveryUrl);
			Update(description);
		}
		finally
		{
			await client.CloseAsync(ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public Uri GetDiscoveryUrl(Uri endpointUrl)
	{
		if (endpointUrl != null)
		{
			m_description.EndpointUrl = endpointUrl.ToString();
		}
		else
		{
			endpointUrl = Utils.ParseUri(m_description.EndpointUrl);
		}
		StringCollection stringCollection = null;
		if (m_description.Server != null)
		{
			stringCollection = m_description.Server.DiscoveryUrls;
		}
		if (stringCollection == null || stringCollection.Count == 0)
		{
			if (endpointUrl.Scheme.StartsWith("http", StringComparison.Ordinal))
			{
				return new Uri(string.Format(CultureInfo.InvariantCulture, "{0}/discovery", endpointUrl));
			}
			return endpointUrl;
		}
		for (int i = 1; i < stringCollection.Count; i++)
		{
			if (stringCollection[i].StartsWith(endpointUrl.Scheme, StringComparison.Ordinal))
			{
				return Utils.ParseUri(stringCollection[i]);
			}
		}
		return Utils.ParseUri(stringCollection[0]);
	}

	public T ParseExtension<T>(XmlQualifiedName elementName)
	{
		return Utils.ParseExtension<T>(m_extensions, elementName);
	}

	public void UpdateExtension<T>(XmlQualifiedName elementName, object value)
	{
		Utils.UpdateExtension<T>(ref m_extensions, elementName, value);
	}

	private EndpointDescriptionCollection MatchEndpoints(EndpointDescriptionCollection collection, Uri endpointUrl, MessageSecurityMode securityMode, string securityPolicyUri)
	{
		if (collection == null || collection.Count == 0)
		{
			throw ServiceResultException.Create(2148073472u, "Server does not have any endpoints defined.");
		}
		EndpointDescriptionCollection endpointDescriptionCollection = new EndpointDescriptionCollection();
		foreach (EndpointDescription item in collection)
		{
			if ((string.IsNullOrEmpty(securityPolicyUri) || !(securityPolicyUri != item.SecurityPolicyUri)) && (securityMode == MessageSecurityMode.Invalid || securityMode == item.SecurityMode))
			{
				endpointDescriptionCollection.Add(item);
			}
		}
		if (endpointDescriptionCollection.Count == 0)
		{
			endpointDescriptionCollection = collection;
		}
		if (endpointDescriptionCollection.Count > 1)
		{
			collection = endpointDescriptionCollection;
			endpointDescriptionCollection = new EndpointDescriptionCollection();
			foreach (EndpointDescription item2 in collection)
			{
				Uri uri = Utils.ParseUri(item2.EndpointUrl);
				if (!(uri == null) && !(uri.Scheme != endpointUrl.Scheme))
				{
					endpointDescriptionCollection.Add(item2);
				}
			}
		}
		if (endpointDescriptionCollection.Count == 0)
		{
			endpointDescriptionCollection = collection;
		}
		return endpointDescriptionCollection;
	}

	private EndpointDescription SelectBestMatch(EndpointDescriptionCollection matches, Uri discoveryUrl)
	{
		EndpointDescription endpointDescription = matches[0];
		if (matches.Count > 1)
		{
			foreach (EndpointDescription match in matches)
			{
				if (match.SecurityLevel > endpointDescription.SecurityLevel)
				{
					endpointDescription = match;
				}
			}
		}
		if (discoveryUrl != null)
		{
			Uri uri = Utils.ParseUri(endpointDescription.EndpointUrl);
			if (uri == null || !string.Equals(discoveryUrl.DnsSafeHost, uri.DnsSafeHost, StringComparison.OrdinalIgnoreCase))
			{
				UriBuilder uriBuilder = new UriBuilder(uri);
				uriBuilder.Host = discoveryUrl.DnsSafeHost;
				uriBuilder.Port = discoveryUrl.Port;
				endpointDescription.EndpointUrl = uriBuilder.ToString();
				endpointDescription.Server.DiscoveryUrls.Clear();
				endpointDescription.Server.DiscoveryUrls.Add(discoveryUrl.ToString());
			}
		}
		return endpointDescription;
	}
}
