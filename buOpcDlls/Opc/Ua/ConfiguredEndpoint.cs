// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ConfiguredEndpoint
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

#nullable disable
namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/SDK/Configuration.xsd")]
[KnownType(typeof (UserNameIdentityToken))]
[KnownType(typeof (X509IdentityToken))]
[KnownType(typeof (IssuedIdentityToken))]
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

  public ConfiguredEndpoint() => this.Initialize();

  [OnDeserializing]
  public void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_collection = (ConfiguredEndpointCollection) null;
    this.m_description = new EndpointDescription();
    this.m_configuration = (EndpointConfiguration) null;
    this.m_updateBeforeConnect = true;
    this.m_binaryEncodingSupport = BinaryEncodingSupport.Optional;
    this.m_selectedUserTokenPolicyIndex = 0;
    this.m_userIdentity = (UserIdentityToken) null;
    this.m_reverseConnect = (ReverseConnectEndpoint) null;
  }

  [DataMember(Name = "Endpoint", Order = 1, IsRequired = true)]
  public EndpointDescription Description
  {
    get => this.m_description;
    private set
    {
      if (value == null)
        this.m_description = new EndpointDescription();
      else
        this.m_description = value;
    }
  }

  [DataMember(Name = "Configuration", Order = 2, IsRequired = false)]
  public EndpointConfiguration Configuration
  {
    get => this.m_configuration;
    set
    {
      this.m_configuration = value;
      if (this.m_configuration != null)
        return;
      if (this.m_collection != null)
        this.Update(this.m_collection.DefaultConfiguration);
      else
        this.Update(EndpointConfiguration.Create());
    }
  }

  [DataMember(Name = "UpdateBeforeConnect", Order = 3, IsRequired = false)]
  public bool UpdateBeforeConnect
  {
    get => this.m_updateBeforeConnect;
    set => this.m_updateBeforeConnect = value;
  }

  [DataMember(Name = "BinaryEncodingSupport", Order = 4, IsRequired = false)]
  public BinaryEncodingSupport BinaryEncodingSupport
  {
    get => this.m_binaryEncodingSupport;
    set => this.m_binaryEncodingSupport = value;
  }

  [DataMember(Name = "SelectedUserTokenPolicy", Order = 5, IsRequired = false)]
  public int SelectedUserTokenPolicyIndex
  {
    get => this.m_selectedUserTokenPolicyIndex;
    set => this.m_selectedUserTokenPolicyIndex = value;
  }

  [DataMember(Name = "UserIdentity", Order = 6, IsRequired = false)]
  public UserIdentityToken UserIdentity
  {
    get => this.m_userIdentity;
    set => this.m_userIdentity = value;
  }

  [DataMember(Name = "ReverseConnect", Order = 8, IsRequired = false)]
  public ReverseConnectEndpoint ReverseConnect
  {
    get => this.m_reverseConnect;
    set => this.m_reverseConnect = value;
  }

  [DataMember(IsRequired = false, EmitDefaultValue = false, Order = 9)]
  public XmlElementCollection Extensions
  {
    get => this.m_extensions;
    set => this.m_extensions = value;
  }

  public ConfiguredEndpoint(ApplicationDescription server, EndpointConfiguration configuration)
  {
    if (server == null)
      throw new ArgumentNullException(nameof (server));
    this.m_description = new EndpointDescription();
    this.m_updateBeforeConnect = true;
    this.m_description.Server = server;
    foreach (string discoveryUrl in (List<string>) server.DiscoveryUrls)
    {
      string uri1 = discoveryUrl;
      if (uri1 != null && uri1.StartsWith("http", StringComparison.Ordinal) && uri1.EndsWith("/discovery", StringComparison.Ordinal))
        uri1 = uri1.Substring(0, uri1.Length - "/discovery".Length);
      Uri uri2 = Utils.ParseUri(uri1);
      if (uri2 != (Uri) null)
      {
        this.m_description.EndpointUrl = uri2.ToString();
        this.m_description.SecurityMode = MessageSecurityMode.SignAndEncrypt;
        this.m_description.SecurityPolicyUri = "http://opcfoundation.org/UA/SecurityPolicy#Basic256Sha256";
        this.m_description.UserIdentityTokens.Add(new UserTokenPolicy(UserTokenType.Anonymous));
        if (uri2.Scheme == "opc.tcp")
        {
          this.m_description.TransportProfileUri = "http://opcfoundation.org/UA-Profile/Transport/uatcp-uasc-uabinary";
          break;
        }
        if (Utils.IsUriHttpsScheme(uri2.Scheme))
        {
          this.m_description.TransportProfileUri = "http://opcfoundation.org/UA-Profile/Transport/https-uabinary";
          break;
        }
        if (uri2.Scheme == "opc.wss")
        {
          this.m_description.TransportProfileUri = "http://opcfoundation.org/UA-Profile/Transport/uawss-uasc-uabinary";
          break;
        }
        break;
      }
    }
    if (configuration == null)
      configuration = EndpointConfiguration.Create();
    this.Update(configuration);
  }

  public ConfiguredEndpoint(
    ConfiguredEndpointCollection collection,
    EndpointDescription description)
    : this(collection, description, (EndpointConfiguration) null)
  {
  }

  public ConfiguredEndpoint(
    ConfiguredEndpointCollection collection,
    EndpointDescription description,
    EndpointConfiguration configuration)
  {
    if (description == null)
      throw new ArgumentNullException(nameof (description));
    this.m_collection = collection;
    this.m_description = description;
    this.m_updateBeforeConnect = true;
    if (configuration == null)
      configuration = collection == null ? EndpointConfiguration.Create() : collection.DefaultConfiguration;
    this.Update(configuration);
  }

  public virtual object Clone() => this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ConfiguredEndpoint configuredEndpoint = new ConfiguredEndpoint();
    configuredEndpoint.Collection = this.Collection;
    configuredEndpoint.Update(this);
    return (object) configuredEndpoint;
  }

  public override string ToString() => this.ToString((string) null, (IFormatProvider) null);

  public string ToString(string format, IFormatProvider formatProvider)
  {
    if (format == null)
      return Utils.Format("{0} - [{1}:{2}:{3}]", (object) this.m_description.EndpointUrl, (object) this.m_description.SecurityMode, (object) SecurityPolicies.GetDisplayName(this.m_description.SecurityPolicyUri), this.m_configuration == null || !this.m_configuration.UseBinaryEncoding ? (object) "XML" : (object) "Binary");
    throw new FormatException(Utils.Format("Invalid format string: '{0}'.", (object) format));
  }

  public bool NeedUpdateFromServer()
  {
    bool flag = this.Description.ServerCertificate != null && this.Description.ServerCertificate.Length != 0;
    return ((this.SelectedUserTokenPolicy.TokenType == UserTokenType.Anonymous ? 0 : ((this.SelectedUserTokenPolicy.SecurityPolicyUri ?? "http://opcfoundation.org/UA/SecurityPolicy#None") != "http://opcfoundation.org/UA/SecurityPolicy#None" ? 1 : 0)) | (this.Description.SecurityPolicyUri != "http://opcfoundation.org/UA/SecurityPolicy#None" ? 1 : 0)) != 0 && !flag;
  }

  public void Update(ConfiguredEndpoint endpoint)
  {
    this.m_description = endpoint != null ? (EndpointDescription) endpoint.Description.MemberwiseClone() : throw new ArgumentNullException(nameof (endpoint));
    this.m_configuration = (EndpointConfiguration) endpoint.Configuration.MemberwiseClone();
    if (this.m_description.TransportProfileUri != null)
      this.m_description.TransportProfileUri = Profiles.NormalizeUri(this.m_description.TransportProfileUri);
    this.m_updateBeforeConnect = endpoint.m_updateBeforeConnect;
    this.m_selectedUserTokenPolicyIndex = endpoint.m_selectedUserTokenPolicyIndex;
    this.m_binaryEncodingSupport = endpoint.m_binaryEncodingSupport;
    if (endpoint.m_userIdentity == null)
      return;
    this.m_userIdentity = (UserIdentityToken) endpoint.m_userIdentity.MemberwiseClone();
  }

  public void Update(EndpointDescription description)
  {
    this.m_description = description != null ? (EndpointDescription) description.MemberwiseClone() : throw new ArgumentNullException(nameof (description));
    if (this.m_description.TransportProfileUri != null)
      this.m_description.TransportProfileUri = Profiles.NormalizeUri(this.m_description.TransportProfileUri);
    if (this.m_collection == null || this.m_description.EndpointUrl == null || !this.m_description.EndpointUrl.StartsWith("opc.tcp", StringComparison.Ordinal))
      return;
    this.m_description.ProxyUrl = this.m_collection.TcpProxyUrl;
  }

  public void Update(EndpointConfiguration configuration)
  {
    this.m_configuration = configuration != null ? (EndpointConfiguration) configuration.MemberwiseClone() : throw new ArgumentNullException(nameof (configuration));
    BinaryEncodingSupport binaryEncodingSupport = this.m_description.EncodingSupport;
    if (binaryEncodingSupport == BinaryEncodingSupport.Optional)
      binaryEncodingSupport = this.m_binaryEncodingSupport;
    if (binaryEncodingSupport == BinaryEncodingSupport.None)
      this.m_configuration.UseBinaryEncoding = false;
    if (binaryEncodingSupport != BinaryEncodingSupport.Required)
      return;
    this.m_configuration.UseBinaryEncoding = true;
  }

  public void UpdateFromServer()
  {
    this.UpdateFromServer(this.EndpointUrl, this.m_description.SecurityMode, this.m_description.SecurityPolicyUri);
  }

  public void UpdateFromServer(
    Uri endpointUrl,
    MessageSecurityMode securityMode,
    string securityPolicyUri)
  {
    this.UpdateFromServer(endpointUrl, (ITransportWaitingConnection) null, securityMode, securityPolicyUri);
  }

  public void UpdateFromServer(
    Uri endpointUrl,
    ITransportWaitingConnection connection,
    MessageSecurityMode securityMode,
    string securityPolicyUri)
  {
    Uri discoveryUrl = this.GetDiscoveryUrl(endpointUrl);
    DiscoveryClient discoveryClient = connection == null ? DiscoveryClient.Create(discoveryUrl, this.m_configuration) : DiscoveryClient.Create(connection, this.m_configuration);
    try
    {
      this.Update(this.SelectBestMatch(this.MatchEndpoints(discoveryClient.GetEndpoints((StringCollection) null), endpointUrl, securityMode, securityPolicyUri), discoveryUrl));
    }
    finally
    {
      discoveryClient.Close();
    }
  }

  public Task UpdateFromServerAsync(CancellationToken ct = default (CancellationToken))
  {
    return this.UpdateFromServerAsync(this.EndpointUrl, this.m_description.SecurityMode, this.m_description.SecurityPolicyUri, ct);
  }

  public Task UpdateFromServerAsync(
    Uri endpointUrl,
    MessageSecurityMode securityMode,
    string securityPolicyUri,
    CancellationToken ct = default (CancellationToken))
  {
    return this.UpdateFromServerAsync(endpointUrl, (ITransportWaitingConnection) null, securityMode, securityPolicyUri, ct);
  }

  public async Task UpdateFromServerAsync(
    Uri endpointUrl,
    ITransportWaitingConnection connection,
    MessageSecurityMode securityMode,
    string securityPolicyUri,
    CancellationToken ct = default (CancellationToken))
  {
    Uri discoveryUrl = this.GetDiscoveryUrl(endpointUrl);
    DiscoveryClient client = connection == null ? DiscoveryClient.Create(discoveryUrl, this.m_configuration) : DiscoveryClient.Create(connection, this.m_configuration);
    try
    {
      this.Update(this.SelectBestMatch(this.MatchEndpoints(await client.GetEndpointsAsync((StringCollection) null, ct).ConfigureAwait(false), endpointUrl, securityMode, securityPolicyUri), discoveryUrl));
    }
    finally
    {
      StatusCode statusCode = await client.CloseAsync(ct).ConfigureAwait(false);
    }
    discoveryUrl = (Uri) null;
    client = (DiscoveryClient) null;
  }

  public Uri GetDiscoveryUrl(Uri endpointUrl)
  {
    if (endpointUrl != (Uri) null)
      this.m_description.EndpointUrl = endpointUrl.ToString();
    else
      endpointUrl = Utils.ParseUri(this.m_description.EndpointUrl);
    StringCollection stringCollection = (StringCollection) null;
    if (this.m_description.Server != null)
      stringCollection = this.m_description.Server.DiscoveryUrls;
    if (stringCollection != null && stringCollection.Count != 0)
    {
      for (int index = 1; index < stringCollection.Count; ++index)
      {
        if (stringCollection[index].StartsWith(endpointUrl.Scheme, StringComparison.Ordinal))
          return Utils.ParseUri(stringCollection[index]);
      }
      return Utils.ParseUri(stringCollection[0]);
    }
    return endpointUrl.Scheme.StartsWith("http", StringComparison.Ordinal) ? new Uri(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "{0}/discovery", (object) endpointUrl)) : endpointUrl;
  }

  public T ParseExtension<T>(XmlQualifiedName elementName)
  {
    return Utils.ParseExtension<T>((IList<XmlElement>) this.m_extensions, elementName);
  }

  public void UpdateExtension<T>(XmlQualifiedName elementName, object value)
  {
    Utils.UpdateExtension<T>(ref this.m_extensions, elementName, value);
  }

  public ConfiguredEndpointCollection Collection
  {
    get => this.m_collection;
    internal set
    {
      this.m_collection = value != null ? value : throw new ArgumentNullException(nameof (value));
    }
  }

  public Uri EndpointUrl
  {
    get
    {
      return string.IsNullOrEmpty(this.m_description.EndpointUrl) ? (Uri) null : Utils.ParseUri(this.m_description.EndpointUrl);
    }
    set
    {
      if (value == (Uri) null)
        this.m_description.EndpointUrl = (string) null;
      this.m_description.EndpointUrl = string.Format((IFormatProvider) CultureInfo.InvariantCulture, "{0}", (object) value);
    }
  }

  public UserTokenPolicy SelectedUserTokenPolicy
  {
    get
    {
      if (this.m_description != null && this.m_description.UserIdentityTokens != null)
      {
        UserTokenPolicyCollection userIdentityTokens = this.m_description.UserIdentityTokens;
        if (this.m_selectedUserTokenPolicyIndex >= 0 && userIdentityTokens.Count > this.m_selectedUserTokenPolicyIndex)
          return userIdentityTokens[this.m_selectedUserTokenPolicyIndex];
      }
      return (UserTokenPolicy) null;
    }
    set
    {
      if (this.m_description != null && this.m_description.UserIdentityTokens != null)
      {
        UserTokenPolicyCollection userIdentityTokens = this.m_description.UserIdentityTokens;
        for (int index = 0; index < userIdentityTokens.Count; ++index)
        {
          if (userIdentityTokens[index] == value)
          {
            this.m_selectedUserTokenPolicyIndex = index;
            break;
          }
        }
      }
      this.m_selectedUserTokenPolicyIndex = -1;
    }
  }

  private EndpointDescriptionCollection MatchEndpoints(
    EndpointDescriptionCollection collection,
    Uri endpointUrl,
    MessageSecurityMode securityMode,
    string securityPolicyUri)
  {
    if (collection == null || collection.Count == 0)
      throw ServiceResultException.Create(2148073472U /*0x80090000*/, "Server does not have any endpoints defined.");
    EndpointDescriptionCollection descriptionCollection = new EndpointDescriptionCollection();
    foreach (EndpointDescription endpointDescription in (List<EndpointDescription>) collection)
    {
      if ((string.IsNullOrEmpty(securityPolicyUri) || !(securityPolicyUri != endpointDescription.SecurityPolicyUri)) && (securityMode == MessageSecurityMode.Invalid || securityMode == endpointDescription.SecurityMode))
        descriptionCollection.Add(endpointDescription);
    }
    if (descriptionCollection.Count == 0)
      descriptionCollection = collection;
    if (descriptionCollection.Count > 1)
    {
      collection = descriptionCollection;
      descriptionCollection = new EndpointDescriptionCollection();
      foreach (EndpointDescription endpointDescription in (List<EndpointDescription>) collection)
      {
        Uri uri = Utils.ParseUri(endpointDescription.EndpointUrl);
        if (!(uri == (Uri) null) && !(uri.Scheme != endpointUrl.Scheme))
          descriptionCollection.Add(endpointDescription);
      }
    }
    if (descriptionCollection.Count == 0)
      descriptionCollection = collection;
    return descriptionCollection;
  }

  private EndpointDescription SelectBestMatch(
    EndpointDescriptionCollection matches,
    Uri discoveryUrl)
  {
    EndpointDescription endpointDescription = matches[0];
    if (matches.Count > 1)
    {
      foreach (EndpointDescription match in (List<EndpointDescription>) matches)
      {
        if ((int) match.SecurityLevel > (int) endpointDescription.SecurityLevel)
          endpointDescription = match;
      }
    }
    if (discoveryUrl != (Uri) null)
    {
      Uri uri = Utils.ParseUri(endpointDescription.EndpointUrl);
      if (uri == (Uri) null || !string.Equals(discoveryUrl.DnsSafeHost, uri.DnsSafeHost, StringComparison.OrdinalIgnoreCase))
      {
        endpointDescription.EndpointUrl = new UriBuilder(uri)
        {
          Host = discoveryUrl.DnsSafeHost,
          Port = discoveryUrl.Port
        }.ToString();
        endpointDescription.Server.DiscoveryUrls.Clear();
        endpointDescription.Server.DiscoveryUrls.Add(discoveryUrl.ToString());
      }
    }
    return endpointDescription;
  }
}
