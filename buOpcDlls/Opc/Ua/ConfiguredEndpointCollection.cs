// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ConfiguredEndpointCollection
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
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

  public ConfiguredEndpointCollection() => this.Initialize();

  [OnDeserializing]
  public void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_knownHosts = new StringCollection();
    this.m_discoveryUrls = new StringCollection((IEnumerable<string>) Utils.DiscoveryUrls);
    this.m_endpoints = new List<ConfiguredEndpoint>();
    this.m_defaultConfiguration = EndpointConfiguration.Create();
  }

  [DataMember(Name = "KnownHosts", IsRequired = false, Order = 1)]
  public StringCollection KnownHosts
  {
    get => this.m_knownHosts;
    set
    {
      if (value == null)
        this.m_knownHosts = new StringCollection();
      else
        this.m_knownHosts = value;
    }
  }

  [DataMember(Name = "Endpoints", IsRequired = false, Order = 2)]
  public List<ConfiguredEndpoint> Endpoints
  {
    get => this.m_endpoints;
    private set
    {
      this.m_endpoints = value != null ? value : new List<ConfiguredEndpoint>();
      foreach (ConfiguredEndpoint endpoint in this.m_endpoints)
        endpoint.Collection = this;
    }
  }

  [DataMember(Name = "TcpProxyUrl", EmitDefaultValue = false, Order = 3)]
  public Uri TcpProxyUrl
  {
    get => this.m_tcpProxyUrl;
    set => this.m_tcpProxyUrl = value;
  }

  public ConfiguredEndpointCollection(EndpointConfiguration configuration)
  {
    this.Initialize();
    this.m_defaultConfiguration = (EndpointConfiguration) configuration.Clone();
  }

  public ConfiguredEndpointCollection(ApplicationConfiguration configuration)
  {
    this.Initialize();
    this.m_defaultConfiguration = EndpointConfiguration.Create(configuration);
    if (configuration.ClientConfiguration == null)
      return;
    this.m_discoveryUrls = new StringCollection((IEnumerable<string>) configuration.ClientConfiguration.WellKnownDiscoveryUrls);
  }

  public static ConfiguredEndpointCollection Load(
    ApplicationConfiguration configuration,
    string filePath)
  {
    return ConfiguredEndpointCollection.Load(configuration, filePath, false);
  }

  public static ConfiguredEndpointCollection Load(
    ApplicationConfiguration configuration,
    string filePath,
    bool overrideConfiguration)
  {
    ConfiguredEndpointCollection endpointCollection = ConfiguredEndpointCollection.Load(filePath);
    endpointCollection.m_defaultConfiguration = EndpointConfiguration.Create(configuration);
    foreach (ConfiguredEndpoint endpoint in endpointCollection.Endpoints)
    {
      if (endpoint.Configuration == null | overrideConfiguration)
        endpoint.Update(endpointCollection.DefaultConfiguration);
    }
    return endpointCollection;
  }

  public static ConfiguredEndpointCollection Load(string filePath)
  {
    ConfiguredEndpointCollection endpointCollection;
    using (Stream istrm = (Stream) File.OpenRead(filePath))
      endpointCollection = ConfiguredEndpointCollection.Load(istrm);
    endpointCollection.m_filepath = filePath;
    List<ConfiguredEndpoint> configuredEndpointList = new List<ConfiguredEndpoint>();
    Dictionary<string, ApplicationDescription> dictionary = new Dictionary<string, ApplicationDescription>();
    foreach (ConfiguredEndpoint endpoint in endpointCollection.m_endpoints)
    {
      if (endpoint.Description == null)
      {
        configuredEndpointList.Add(endpoint);
      }
      else
      {
        if (endpoint.Description.Server == null)
        {
          endpoint.Description.Server = new ApplicationDescription();
          endpoint.Description.Server.ApplicationType = ApplicationType.Server;
        }
        if (string.IsNullOrEmpty(endpoint.Description.Server.ApplicationUri))
          endpoint.Description.Server.ApplicationUri = endpoint.Description.EndpointUrl;
        if (endpoint.Description.Server.DiscoveryUrls == null)
          endpoint.Description.Server.DiscoveryUrls = new StringCollection();
        if (endpoint.Description.Server.DiscoveryUrls.Count == 0)
        {
          string endpointUrl = endpoint.Description.EndpointUrl;
          if (endpointUrl.StartsWith("http"))
            endpointUrl += "/discovery";
          endpoint.Description.Server.DiscoveryUrls.Add(endpointUrl);
        }
        if (endpoint.Description.TransportProfileUri != null)
          endpoint.Description.TransportProfileUri = Profiles.NormalizeUri(endpoint.Description.TransportProfileUri);
        ApplicationDescription applicationDescription = (ApplicationDescription) null;
        if (!dictionary.TryGetValue(endpoint.Description.Server.ApplicationUri, out applicationDescription))
        {
          ApplicationDescription server = endpoint.Description.Server;
          dictionary[server.ApplicationUri] = server;
          server.ApplicationUri = Utils.UpdateInstanceUri(server.ApplicationUri);
          dictionary[server.ApplicationUri] = server;
        }
        else
          endpoint.Description.Server = (ApplicationDescription) applicationDescription.Clone();
      }
    }
    foreach (ConfiguredEndpoint configuredEndpoint in configuredEndpointList)
      endpointCollection.Remove(configuredEndpoint);
    return endpointCollection;
  }

  public static ConfiguredEndpointCollection Load(Stream istrm)
  {
    try
    {
      if (new DataContractSerializer(typeof (ConfiguredEndpointCollection)).ReadObject(istrm) is ConfiguredEndpointCollection endpointCollection)
      {
        foreach (ConfiguredEndpoint configuredEndpoint in endpointCollection)
        {
          if (configuredEndpoint.Description != null)
            configuredEndpoint.Description.TransportProfileUri = Profiles.NormalizeUri(configuredEndpoint.Description.TransportProfileUri);
        }
      }
      return endpointCollection;
    }
    catch (Exception ex)
    {
      object[] objArray = Array.Empty<object>();
      Utils.LogError(ex, "Unexpected error loading ConfiguredEndpoints.", objArray);
      throw;
    }
  }

  public void Save() => this.Save(this.m_filepath);

  public void Save(string filePath)
  {
    using (Stream ostrm = (Stream) File.Open(filePath, FileMode.Create))
      this.Save(ostrm);
    this.m_filepath = filePath;
  }

  public void Save(Stream ostrm)
  {
    new DataContractSerializer(typeof (ConfiguredEndpointCollection)).WriteObject(ostrm, (object) this);
  }

  public virtual object Clone() => this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ConfiguredEndpointCollection endpointCollection = new ConfiguredEndpointCollection();
    endpointCollection.m_filepath = this.m_filepath;
    endpointCollection.m_knownHosts = new StringCollection((IEnumerable<string>) this.m_knownHosts);
    endpointCollection.m_defaultConfiguration = (EndpointConfiguration) this.m_defaultConfiguration.MemberwiseClone();
    foreach (ConfiguredEndpoint endpoint in this.m_endpoints)
    {
      ConfiguredEndpoint configuredEndpoint = (ConfiguredEndpoint) endpoint.MemberwiseClone();
      configuredEndpoint.Collection = endpointCollection;
      endpointCollection.m_endpoints.Add(configuredEndpoint);
    }
    return (object) endpointCollection;
  }

  public int IndexOf(ConfiguredEndpoint item)
  {
    for (int index = 0; index < this.m_endpoints.Count; ++index)
    {
      if (item == this.m_endpoints[index])
        return index;
    }
    return -1;
  }

  public void Insert(int index, ConfiguredEndpoint item) => this.Insert(item, index);

  public void RemoveAt(int index)
  {
    if (index < 0 || index >= this.m_endpoints.Count)
      throw new ArgumentOutOfRangeException(nameof (index));
    this.Remove(this.m_endpoints[index]);
  }

  public ConfiguredEndpoint this[int index]
  {
    get => this.m_endpoints[index];
    set => throw new NotImplementedException();
  }

  public void Clear() => this.m_endpoints.Clear();

  public bool Contains(ConfiguredEndpoint item)
  {
    for (int index = 0; index < this.m_endpoints.Count; ++index)
    {
      if (item == this.m_endpoints[index])
        return true;
    }
    return false;
  }

  public void CopyTo(ConfiguredEndpoint[] array, int arrayIndex)
  {
    this.m_endpoints.CopyTo(array, arrayIndex);
  }

  public int Count => this.m_endpoints.Count;

  public bool IsReadOnly => false;

  public IEnumerator<ConfiguredEndpoint> GetEnumerator()
  {
    return (IEnumerator<ConfiguredEndpoint>) this.m_endpoints.GetEnumerator();
  }

  public ConfiguredEndpoint Add(EndpointDescription endpoint)
  {
    return this.Add(endpoint, (EndpointConfiguration) null);
  }

  public ConfiguredEndpoint Add(EndpointDescription endpoint, EndpointConfiguration configuration)
  {
    ConfiguredEndpointCollection.ValidateEndpoint(endpoint);
    foreach (ConfiguredEndpoint endpoint1 in this.m_endpoints)
    {
      if (endpoint1.Description == endpoint)
        throw new ArgumentException("Endpoint already exists in the collection.");
    }
    ConfiguredEndpoint configuredEndpoint = new ConfiguredEndpoint(this, endpoint, configuration);
    this.m_endpoints.Add(configuredEndpoint);
    return configuredEndpoint;
  }

  public void Add(ConfiguredEndpoint item) => this.Insert(item, -1);

  private void Insert(ConfiguredEndpoint endpoint, int index)
  {
    if (endpoint == null)
      throw new ArgumentNullException(nameof (endpoint));
    ConfiguredEndpointCollection.ValidateEndpoint(endpoint.Description);
    if (endpoint.Collection != null)
      endpoint.Collection.Remove(endpoint);
    endpoint.Collection = this;
    if (endpoint.Collection != this)
      throw new ArgumentException("Cannot add an endpoint from another collection.");
    if (this.m_endpoints.Contains(endpoint))
      throw new ArgumentException("Endpoint already belongs to the collection.");
    if (index < 0)
      this.m_endpoints.Add(endpoint);
    else
      this.m_endpoints.Insert(index, endpoint);
  }

  public bool Remove(ConfiguredEndpoint item)
  {
    return item != null ? this.m_endpoints.Remove(item) : throw new ArgumentNullException(nameof (item));
  }

  public void RemoveServer(string serverUri)
  {
    if (serverUri == null)
      throw new ArgumentNullException(nameof (serverUri));
    foreach (ConfiguredEndpoint endpoint in this.GetEndpoints(serverUri))
      this.Remove(endpoint);
  }

  public void SetApplicationDescription(string serverUri, ApplicationDescription server)
  {
    if (server == null)
      throw new ArgumentNullException(nameof (server));
    if (string.IsNullOrEmpty(server.ApplicationUri))
      throw new ArgumentException("A ServerUri must provided.", nameof (server));
    if (server.DiscoveryUrls.Count == 0)
      throw new ArgumentException("At least one DiscoveryUrl must be provided.", nameof (server));
    if (this.GetEndpoints(server.ApplicationUri).Count == 0)
    {
      string url = (string) null;
      for (int index = 0; index < server.DiscoveryUrls.Count; ++index)
      {
        if (!string.IsNullOrEmpty(server.DiscoveryUrls[index]))
        {
          url = server.DiscoveryUrls[index];
          break;
        }
      }
      if (url != null && url.StartsWith("http", StringComparison.Ordinal) && url.EndsWith("/discovery", StringComparison.Ordinal))
        url = url.Substring(0, url.Length - "/discovery".Length);
      if (url == null)
        return;
      ConfiguredEndpoint configuredEndpoint = this.Create(url);
      configuredEndpoint.Description.Server = (ApplicationDescription) server.MemberwiseClone();
      this.Add(configuredEndpoint);
    }
    else
    {
      foreach (ConfiguredEndpoint endpoint in this.GetEndpoints(serverUri))
        endpoint.Description.Server = (ApplicationDescription) server.MemberwiseClone();
    }
  }

  public ConfiguredEndpoint Create(string url)
  {
    string str1 = (string) null;
    int length = url.IndexOf("- [", StringComparison.Ordinal);
    if (length != -1)
    {
      str1 = url.Substring(length + 3);
      url = url.Substring(0, length).Trim();
    }
    MessageSecurityMode messageSecurityMode = MessageSecurityMode.SignAndEncrypt;
    string str2 = "http://opcfoundation.org/UA/SecurityPolicy#Basic256Sha256";
    bool flag = true;
    if (!string.IsNullOrEmpty(str1))
    {
      string[] strArray = str1.Split(new char[4]
      {
        '-',
        '[',
        ':',
        ']'
      }, StringSplitOptions.RemoveEmptyEntries);
      try
      {
        messageSecurityMode = strArray.Length == 0 ? MessageSecurityMode.None : (MessageSecurityMode) Enum.Parse(typeof (MessageSecurityMode), strArray[0], false);
      }
      catch
      {
        messageSecurityMode = MessageSecurityMode.None;
      }
      try
      {
        str2 = strArray.Length <= 1 ? "http://opcfoundation.org/UA/SecurityPolicy#None" : SecurityPolicies.GetUri(strArray[1]);
      }
      catch
      {
        str2 = "http://opcfoundation.org/UA/SecurityPolicy#None";
      }
      try
      {
        flag = strArray.Length > 2 && strArray[2] == "Binary";
      }
      catch
      {
        flag = false;
      }
    }
    Uri uri = new Uri(url);
    EndpointDescription description = new EndpointDescription();
    description.EndpointUrl = uri.ToString();
    description.SecurityMode = messageSecurityMode;
    description.SecurityPolicyUri = str2;
    description.Server.ApplicationUri = Utils.UpdateInstanceUri(uri.ToString());
    description.Server.ApplicationName = (LocalizedText) uri.AbsolutePath;
    if (description.EndpointUrl.StartsWith("opc.tcp", StringComparison.Ordinal))
    {
      description.TransportProfileUri = "http://opcfoundation.org/UA-Profile/Transport/uatcp-uasc-uabinary";
      description.Server.DiscoveryUrls.Add(description.EndpointUrl);
    }
    else if (Utils.IsUriHttpsScheme(description.EndpointUrl))
    {
      description.TransportProfileUri = "http://opcfoundation.org/UA-Profile/Transport/https-uabinary";
      description.Server.DiscoveryUrls.Add(description.EndpointUrl);
    }
    else if (description.EndpointUrl.StartsWith("opc.wss", StringComparison.Ordinal))
    {
      description.TransportProfileUri = "http://opcfoundation.org/UA-Profile/Transport/uatcp-uasc-uabinary";
      description.Server.DiscoveryUrls.Add(description.EndpointUrl);
    }
    return new ConfiguredEndpoint(this, description, (EndpointConfiguration) null)
    {
      Configuration = {
        UseBinaryEncoding = flag
      },
      UpdateBeforeConnect = true
    };
  }

  public List<ConfiguredEndpoint> GetEndpoints(string serverUri)
  {
    List<ConfiguredEndpoint> endpoints = new List<ConfiguredEndpoint>();
    foreach (ConfiguredEndpoint endpoint in this.m_endpoints)
    {
      if (endpoint.Description.Server.ApplicationUri == serverUri)
        endpoints.Add(endpoint);
    }
    return endpoints;
  }

  public ApplicationDescriptionCollection GetServers()
  {
    Dictionary<string, ApplicationDescription> dictionary = new Dictionary<string, ApplicationDescription>();
    foreach (ConfiguredEndpoint endpoint in this.m_endpoints)
    {
      ApplicationDescription server = endpoint.Description.Server;
      if (!string.IsNullOrEmpty(server.ApplicationUri) && !dictionary.ContainsKey(server.ApplicationUri))
        dictionary.Add(server.ApplicationUri, server);
    }
    return new ApplicationDescriptionCollection((IEnumerable<ApplicationDescription>) dictionary.Values);
  }

  [Obsolete("Non-functional - replaced with GetEndpoints()")]
  public List<ConfiguredEndpoint> CopyEndpoints(string serverUri)
  {
    return (List<ConfiguredEndpoint>) null;
  }

  [Obsolete("Non-functional - method not used - updates should be done with ConfiguredEndpoint.UpdateFromServer()")]
  public void UpdateEndpointsForServer(string serverUri)
  {
  }

  public StringCollection DiscoveryUrls
  {
    get => this.m_discoveryUrls;
    set
    {
      if (value == null)
        this.m_discoveryUrls = new StringCollection((IEnumerable<string>) Utils.DiscoveryUrls);
      else
        this.m_discoveryUrls = value;
    }
  }

  public EndpointConfiguration DefaultConfiguration => this.m_defaultConfiguration;

  private static void ValidateEndpoint(EndpointDescription endpoint)
  {
    if (endpoint == null)
      throw new ArgumentException("Endpoint must not be null.");
    if (string.IsNullOrEmpty(endpoint.EndpointUrl))
      throw new ArgumentException("Endpoint must have a valid URL.");
    if (endpoint.Server == null)
    {
      endpoint.Server = new ApplicationDescription();
      endpoint.Server.ApplicationType = ApplicationType.Server;
    }
    if (!string.IsNullOrEmpty(endpoint.Server.ApplicationUri))
      return;
    endpoint.Server.ApplicationUri = endpoint.EndpointUrl;
  }
}
