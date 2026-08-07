// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ServerBase
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Opc.Ua.Bindings;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public class ServerBase : IServerBase, IAuditEventCallback, IDisposable
{
  private object m_messageContext;
  private object m_serverError;
  private object m_certificateValidator;
  private object m_instanceCertificate;
  private X509Certificate2Collection m_instanceCertificateChain;
  private object m_serverProperties;
  private object m_configuration;
  private object m_serverDescription;
  private List<ServiceHost> m_hosts;
  private List<ITransportListener> m_listeners;
  private ReadOnlyList<EndpointDescription> m_endpoints;
  private ServerBase.RequestQueue m_requestQueue;
  private int m_userTokenPolicyId;

  public ServerBase()
  {
    this.m_messageContext = (object) new ServiceMessageContext();
    this.m_serverError = (object) new ServiceResult(2148401152U /*0x800E0000*/);
    this.m_hosts = new List<ServiceHost>();
    this.m_listeners = new List<ITransportListener>();
    this.m_endpoints = (ReadOnlyList<EndpointDescription>) null;
    this.m_requestQueue = new ServerBase.RequestQueue(this, 10, 100, 1000);
    this.m_userTokenPolicyId = 0;
  }

  public void Dispose()
  {
    this.Dispose(true);
    GC.SuppressFinalize((object) this);
  }

  protected virtual void Dispose(bool disposing)
  {
    if (!disposing)
      return;
    if (this.m_listeners != null)
    {
      for (int index = 0; index < this.m_listeners.Count; ++index)
        Utils.SilentDispose((IDisposable) this.m_listeners[index]);
      this.m_listeners.Clear();
    }
    if (this.m_hosts != null)
    {
      for (int index = 0; index < this.m_hosts.Count; ++index)
        Utils.SilentDispose((IDisposable) this.m_hosts[index]);
      this.m_hosts.Clear();
    }
    Utils.SilentDispose((IDisposable) this.m_requestQueue);
  }

  public IServiceMessageContext MessageContext
  {
    get => (IServiceMessageContext) this.m_messageContext;
    set => Interlocked.Exchange(ref this.m_messageContext, (object) value);
  }

  public ServiceResult ServerError
  {
    get => (ServiceResult) this.m_serverError;
    set => Interlocked.Exchange(ref this.m_serverError, (object) value);
  }

  public virtual EndpointDescriptionCollection GetEndpoints()
  {
    ReadOnlyList<EndpointDescription> endpoints = this.m_endpoints;
    return endpoints != null ? new EndpointDescriptionCollection((IEnumerable<EndpointDescription>) endpoints) : new EndpointDescriptionCollection();
  }

  public virtual void ScheduleIncomingRequest(IEndpointIncomingRequest request)
  {
    this.m_requestQueue.ScheduleIncomingRequest(request);
  }

  public virtual void ReportAuditOpenSecureChannelEvent(
    string globalChannelId,
    EndpointDescription endpointDescription,
    OpenSecureChannelRequest request,
    X509Certificate2 clientCertificate,
    Exception exception)
  {
  }

  public virtual void ReportAuditCloseSecureChannelEvent(
    string globalChannelId,
    Exception exception)
  {
  }

  public virtual void ReportAuditCertificateEvent(
    X509Certificate2 clientCertificate,
    Exception exception)
  {
  }

  public event EventHandler<ConnectionStatusEventArgs> ConnectionStatusChanged;

  protected virtual void OnConnectionStatusChanged(object sender, ConnectionStatusEventArgs e)
  {
    EventHandler<ConnectionStatusEventArgs> connectionStatusChanged = this.ConnectionStatusChanged;
    if (connectionStatusChanged == null)
      return;
    connectionStatusChanged(sender, e);
  }

  public void CreateConnection(Uri url, int timeout)
  {
    ITransportListener transportListener1 = (ITransportListener) null;
    Utils.LogInfo("Create Reverse Connection to Client at {0}.", (object) url);
    if (this.TransportListeners != null)
    {
      foreach (ITransportListener transportListener2 in this.TransportListeners)
      {
        if (transportListener2.UriScheme == url.Scheme)
        {
          transportListener1 = transportListener2;
          transportListener1.CreateReverseConnection(url, timeout);
        }
      }
    }
    if (transportListener1 == null)
      throw new ArgumentException("No suitable listener found.", nameof (url));
  }

  public ServiceHost Start(ApplicationConfiguration configuration, params Uri[] baseAddresses)
  {
    if (configuration == null)
      throw new ArgumentNullException(nameof (configuration));
    this.OnServerStarting(configuration);
    this.InitializeRequestQueue(configuration);
    TransportListenerBindings listeners = TransportBindings.Listeners;
    this.ServerCapabilities = configuration.ServerConfiguration.ServerCapabilities;
    this.InitializeBaseAddresses(configuration);
    ApplicationDescription serverDescription = (ApplicationDescription) null;
    EndpointDescriptionCollection endpoints = (EndpointDescriptionCollection) null;
    IList<ServiceHost> serviceHostList = this.InitializeServiceHosts(configuration, listeners, out serverDescription, out endpoints);
    this.ServerDescription = serverDescription;
    this.m_endpoints = new ReadOnlyList<EndpointDescription>((IList<EndpointDescription>) endpoints);
    this.StartApplication(configuration);
    if (serviceHostList == null || serviceHostList.Count == 0)
      throw ServiceResultException.Create(2156462080U /*0x80890000*/, "The UA server does not have a default host.");
    lock (this.m_hosts)
    {
      for (int index = 1; index < serviceHostList.Count; ++index)
      {
        serviceHostList[index].Open();
        this.m_hosts.Add(serviceHostList[index]);
      }
    }
    return serviceHostList[0];
  }

  public void Start(ApplicationConfiguration configuration)
  {
    if (configuration == null)
      throw new ArgumentNullException(nameof (configuration));
    this.OnServerStarting(configuration);
    this.InitializeRequestQueue(configuration);
    TransportListenerBindings listeners = TransportBindings.Listeners;
    this.ServerCapabilities = configuration.ServerConfiguration.ServerCapabilities;
    this.InitializeBaseAddresses(configuration);
    ApplicationDescription serverDescription = (ApplicationDescription) null;
    EndpointDescriptionCollection endpoints = (EndpointDescriptionCollection) null;
    IList<ServiceHost> serviceHostList = this.InitializeServiceHosts(configuration, listeners, out serverDescription, out endpoints);
    this.ServerDescription = serverDescription;
    this.m_endpoints = new ReadOnlyList<EndpointDescription>((IList<EndpointDescription>) endpoints);
    this.StartApplication(configuration);
    lock (this.m_hosts)
    {
      foreach (ServiceHost serviceHost in (IEnumerable<ServiceHost>) serviceHostList)
      {
        serviceHost.Open();
        this.m_hosts.Add(serviceHost);
      }
    }
  }

  private void InitializeBaseAddresses(ApplicationConfiguration configuration)
  {
    this.BaseAddresses = (IList<ServerBase.BaseAddress>) new List<ServerBase.BaseAddress>();
    StringCollection stringCollection1 = (StringCollection) null;
    StringCollection stringCollection2 = (StringCollection) null;
    if (configuration.ServerConfiguration != null)
    {
      stringCollection1 = configuration.ServerConfiguration.BaseAddresses;
      stringCollection2 = configuration.ServerConfiguration.AlternateBaseAddresses;
    }
    if (configuration.DiscoveryServerConfiguration != null)
    {
      stringCollection1 = configuration.DiscoveryServerConfiguration.BaseAddresses;
      stringCollection2 = configuration.DiscoveryServerConfiguration.AlternateBaseAddresses;
    }
    if (stringCollection1 == null)
      return;
    foreach (string uriString1 in (List<string>) stringCollection1)
    {
      ServerBase.BaseAddress baseAddress = new ServerBase.BaseAddress()
      {
        Url = new Uri(uriString1)
      };
      if (stringCollection2 != null)
      {
        foreach (string uriString2 in (List<string>) stringCollection2)
        {
          Uri uri = new Uri(uriString2);
          if (uri.Scheme == baseAddress.Url.Scheme)
          {
            if (baseAddress.AlternateUrls == null)
              baseAddress.AlternateUrls = new List<Uri>();
            baseAddress.AlternateUrls.Add(uri);
          }
        }
      }
      switch (baseAddress.Url.Scheme)
      {
        case "https":
        case "opc.https":
          baseAddress.ProfileUri = "http://opcfoundation.org/UA-Profile/Transport/https-uabinary";
          baseAddress.DiscoveryUrl = baseAddress.Url;
          break;
        case "opc.tcp":
          baseAddress.ProfileUri = "http://opcfoundation.org/UA-Profile/Transport/uatcp-uasc-uabinary";
          baseAddress.DiscoveryUrl = baseAddress.Url;
          break;
        case "opc.wss":
          baseAddress.ProfileUri = "http://opcfoundation.org/UA-Profile/Transport/uawss-uasc-uabinary";
          baseAddress.DiscoveryUrl = baseAddress.Url;
          break;
      }
      this.BaseAddresses.Add(baseAddress);
    }
  }

  protected StringCollection GetDiscoveryUrls()
  {
    StringCollection discoveryUrls = new StringCollection();
    string hostName = Utils.GetHostName();
    foreach (ServerBase.BaseAddress baseAddress in (IEnumerable<ServerBase.BaseAddress>) this.BaseAddresses)
    {
      UriBuilder uriBuilder1 = new UriBuilder(baseAddress.DiscoveryUrl);
      int num = uriBuilder1.Host.IndexOf("localhost", StringComparison.OrdinalIgnoreCase);
      if (num == -1)
        num = uriBuilder1.Host.IndexOf("{0}", StringComparison.OrdinalIgnoreCase);
      if (num != -1)
        uriBuilder1.Host = hostName;
      discoveryUrls.Add(uriBuilder1.ToString());
      if (baseAddress.AlternateUrls != null)
      {
        foreach (Uri alternateUrl in baseAddress.AlternateUrls)
        {
          UriBuilder uriBuilder2 = new UriBuilder(alternateUrl);
          discoveryUrls.Add(uriBuilder2.ToString());
        }
      }
    }
    return discoveryUrls;
  }

  protected void InitializeRequestQueue(ApplicationConfiguration configuration)
  {
    int minThreadCount = 10;
    int maxThreadCount = 1000;
    int maxRequestCount = 2000;
    if (configuration.ServerConfiguration != null)
    {
      minThreadCount = configuration.ServerConfiguration.MinRequestThreadCount;
      maxThreadCount = configuration.ServerConfiguration.MaxRequestThreadCount;
      maxRequestCount = configuration.ServerConfiguration.MaxQueuedRequestCount;
    }
    else if (configuration.DiscoveryServerConfiguration != null)
    {
      minThreadCount = configuration.DiscoveryServerConfiguration.MinRequestThreadCount;
      maxThreadCount = configuration.DiscoveryServerConfiguration.MaxRequestThreadCount;
      maxRequestCount = configuration.DiscoveryServerConfiguration.MaxQueuedRequestCount;
    }
    if (minThreadCount < 1)
      minThreadCount = 1;
    if (maxThreadCount < minThreadCount)
      maxThreadCount = minThreadCount;
    if (maxThreadCount < 100)
      maxThreadCount = 100;
    if (maxRequestCount < 100)
      maxRequestCount = 100;
    if (this.m_requestQueue != null)
      this.m_requestQueue.Dispose();
    this.m_requestQueue = new ServerBase.RequestQueue(this, minThreadCount, maxThreadCount, maxRequestCount);
  }

  public virtual void Stop()
  {
    try
    {
      this.OnServerStopping();
    }
    catch (Exception ex)
    {
      this.m_serverError = (object) new ServiceResult(ex);
    }
    List<ITransportListener> listeners = this.m_listeners;
    if (listeners != null)
    {
      for (int index = 0; index < listeners.Count; ++index)
      {
        try
        {
          listeners[index].Close();
        }
        catch (Exception ex)
        {
          object[] objArray = new object[1]
          {
            (object) listeners[index].GetType().FullName
          };
          Utils.LogError(ex, "Unexpected error closing a listener. {0}", objArray);
        }
      }
      listeners.Clear();
    }
    lock (this.m_hosts)
    {
      foreach (ServiceHost host in this.m_hosts)
      {
        if (host.State == ServiceHostState.Opened)
          host.Abort();
        host.Close();
      }
    }
  }

  public virtual ServiceHost CreateServiceHost(ServerBase server, params Uri[] addresses)
  {
    return (ServiceHost) null;
  }

  protected IList<ServerBase.BaseAddress> BaseAddresses { get; set; }

  protected ReadOnlyList<EndpointDescription> Endpoints => this.m_endpoints;

  public CertificateValidator CertificateValidator
  {
    get => (CertificateValidator) this.m_certificateValidator;
    private set => this.m_certificateValidator = (object) value;
  }

  protected X509Certificate2 InstanceCertificate
  {
    get => (X509Certificate2) this.m_instanceCertificate;
    private set => this.m_instanceCertificate = (object) value;
  }

  protected X509Certificate2Collection InstanceCertificateChain
  {
    get => this.m_instanceCertificateChain;
    private set => this.m_instanceCertificateChain = value;
  }

  protected ServerProperties ServerProperties
  {
    get => (ServerProperties) this.m_serverProperties;
    private set => this.m_serverProperties = (object) value;
  }

  protected ApplicationConfiguration Configuration
  {
    get => (ApplicationConfiguration) this.m_configuration;
    private set => this.m_configuration = (object) value;
  }

  protected ApplicationDescription ServerDescription
  {
    get => (ApplicationDescription) this.m_serverDescription;
    private set => this.m_serverDescription = (object) value;
  }

  protected List<ServiceHost> ServiceHosts => this.m_hosts;

  protected StringCollection ServerCapabilities { get; set; }

  protected List<ITransportListener> TransportListeners => this.m_listeners;

  protected virtual Type GetServiceContract() => (Type) null;

  protected virtual EndpointBase GetEndpointInstance(ServerBase server) => (EndpointBase) null;

  public static bool RequireEncryption(EndpointDescription description)
  {
    bool flag = false;
    if (description != null && !(flag = description.SecurityPolicyUri != "http://opcfoundation.org/UA/SecurityPolicy#None"))
    {
      foreach (UserTokenPolicy userIdentityToken in (List<UserTokenPolicy>) description.UserIdentityTokens)
      {
        if (userIdentityToken.SecurityPolicyUri != "http://opcfoundation.org/UA/SecurityPolicy#None")
        {
          flag = true;
          break;
        }
      }
    }
    return flag;
  }

  protected virtual void OnCertificateUpdate(object sender, CertificateUpdateEventArgs e)
  {
    this.InstanceCertificateChain = (X509Certificate2Collection) null;
    this.InstanceCertificate = e.SecurityConfiguration.ApplicationCertificate.Certificate;
    if (this.Configuration.SecurityConfiguration.SendCertificateChain)
    {
      this.InstanceCertificateChain = new X509Certificate2Collection(this.InstanceCertificate);
      List<CertificateIdentifier> issuers = new List<CertificateIdentifier>();
      Dictionary<X509Certificate2, ServiceResultException> validationErrors = new Dictionary<X509Certificate2, ServiceResultException>();
      this.Configuration.CertificateValidator.GetIssuersNoExceptionsOnGetIssuer(this.InstanceCertificateChain, issuers, validationErrors).GetAwaiter().GetResult();
      foreach (KeyValuePair<X509Certificate2, ServiceResultException> keyValuePair in validationErrors)
      {
        if (keyValuePair.Value != null)
          Utils.LogCertificate("OnCertificateUpdate: GetIssuers Validation Error: {0}", keyValuePair.Key, (object) keyValuePair.Value.Result);
      }
      for (int index = 0; index < issuers.Count; ++index)
        this.InstanceCertificateChain.Add(issuers[index].Certificate);
    }
    foreach (ITransportListener transportListener in this.TransportListeners)
      transportListener.CertificateUpdate(e.CertificateValidator, this.InstanceCertificate, this.InstanceCertificateChain);
  }

  public virtual void CreateServiceHostEndpoint(
    Uri endpointUri,
    EndpointDescriptionCollection endpoints,
    EndpointConfiguration endpointConfiguration,
    ITransportListener listener,
    ICertificateValidator certificateValidator)
  {
    try
    {
      listener.Open(endpointUri, new TransportListenerSettings()
      {
        Descriptions = endpoints,
        Configuration = endpointConfiguration,
        ServerCertificate = this.InstanceCertificate,
        CertificateValidator = certificateValidator,
        NamespaceUris = this.MessageContext.NamespaceUris,
        Factory = this.MessageContext.Factory
      }, (ITransportListenerCallback) this.GetEndpointInstance(this));
      this.TransportListeners.Add(listener);
      listener.ConnectionStatusChanged += new EventHandler<ConnectionStatusEventArgs>(this.OnConnectionStatusChanged);
    }
    catch (Exception ex)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("Could not load ").Append(endpointUri.Scheme).Append(" Stack Listener.");
      if (ex.InnerException != null)
        stringBuilder.Append(' ').Append(ex.InnerException.Message);
      Utils.LogError(ex, stringBuilder.ToString());
      throw;
    }
  }

  public virtual UserTokenPolicyCollection GetUserTokenPolicies(
    ApplicationConfiguration configuration,
    EndpointDescription description)
  {
    UserTokenPolicyCollection userTokenPolicies = new UserTokenPolicyCollection();
    if (configuration.ServerConfiguration == null || configuration.ServerConfiguration.UserTokenPolicies == null)
      return userTokenPolicies;
    foreach (UserTokenPolicy userTokenPolicy1 in (List<UserTokenPolicy>) configuration.ServerConfiguration.UserTokenPolicies)
    {
      UserTokenPolicy userTokenPolicy2 = (UserTokenPolicy) userTokenPolicy1.Clone();
      if (string.IsNullOrEmpty(userTokenPolicy1.SecurityPolicyUri) && description.SecurityMode == MessageSecurityMode.None)
        userTokenPolicy2.SecurityPolicyUri = userTokenPolicy2.TokenType != UserTokenType.Anonymous ? "http://opcfoundation.org/UA/SecurityPolicy#Basic256Sha256" : "http://opcfoundation.org/UA/SecurityPolicy#None";
      userTokenPolicy2.PolicyId = Utils.Format("{0}", (object) ++this.m_userTokenPolicyId);
      userTokenPolicies.Add(userTokenPolicy2);
    }
    return userTokenPolicies;
  }

  protected string NormalizeHostname(string hostname)
  {
    string hostName = Utils.GetHostName();
    if (Utils.AreDomainsEqual(hostname, "localhost"))
      return hostName.ToUpper(CultureInfo.InvariantCulture);
    IPAddress address = (IPAddress) null;
    if (IPAddress.TryParse(hostname, out address))
    {
      if (IPAddress.IsLoopback(address))
        return hostName.ToUpper(CultureInfo.InvariantCulture);
      foreach (object hostAddress in Utils.GetHostAddresses(Utils.GetHostName()))
      {
        if (hostAddress.Equals((object) address))
          return hostName.ToUpper(CultureInfo.InvariantCulture);
      }
      return hostname.ToUpper(CultureInfo.InvariantCulture);
    }
    IPHostEntry ipHostEntry = (IPHostEntry) null;
    try
    {
      ipHostEntry = Dns.GetHostEntry(hostName);
    }
    catch (SocketException ex)
    {
      object[] objArray = new object[1]{ (object) hostName };
      Utils.LogError((Exception) ex, "Unable to check aliases for hostname {0}.", objArray);
    }
    if (ipHostEntry != null)
    {
      for (int index = 0; index < ipHostEntry.Aliases.Length; ++index)
      {
        if (Utils.AreDomainsEqual(hostname, ipHostEntry.Aliases[index]))
          return hostName.ToUpper(CultureInfo.InvariantCulture);
      }
    }
    return hostname.ToUpper(CultureInfo.InvariantCulture);
  }

  protected IList<ServerBase.BaseAddress> FilterByProfile(
    StringCollection profileUris,
    IList<ServerBase.BaseAddress> baseAddresses)
  {
    if (profileUris == null || profileUris.Count == 0)
      return baseAddresses;
    List<ServerBase.BaseAddress> baseAddressList = new List<ServerBase.BaseAddress>();
    foreach (ServerBase.BaseAddress baseAddress in (IEnumerable<ServerBase.BaseAddress>) baseAddresses)
    {
      foreach (string profileUri in (List<string>) profileUris)
      {
        if (baseAddress.ProfileUri == Profiles.NormalizeUri(profileUri))
        {
          baseAddressList.Add(baseAddress);
          break;
        }
      }
    }
    return (IList<ServerBase.BaseAddress>) baseAddressList;
  }

  protected IList<ServerBase.BaseAddress> FilterByEndpointUrl(
    Uri endpointUrl,
    IList<ServerBase.BaseAddress> baseAddresses)
  {
    List<ServerBase.BaseAddress> baseAddressList = new List<ServerBase.BaseAddress>();
    foreach (ServerBase.BaseAddress baseAddress in (IEnumerable<ServerBase.BaseAddress>) baseAddresses)
    {
      if (baseAddress.Url.DnsSafeHost == endpointUrl.DnsSafeHost)
        baseAddressList.Add(baseAddress);
      else if (baseAddress.AlternateUrls != null)
      {
        foreach (Uri alternateUrl in baseAddress.AlternateUrls)
        {
          if (alternateUrl.DnsSafeHost == endpointUrl.DnsSafeHost)
          {
            baseAddressList.Add(new ServerBase.BaseAddress()
            {
              Url = alternateUrl,
              ProfileUri = baseAddress.ProfileUri,
              DiscoveryUrl = alternateUrl
            });
            break;
          }
        }
      }
    }
    if (baseAddressList.Count != 0)
      return (IList<ServerBase.BaseAddress>) baseAddressList;
    if (this.NormalizeHostname(endpointUrl.DnsSafeHost) == this.NormalizeHostname("localhost"))
      return baseAddresses;
    foreach (ServerBase.BaseAddress baseAddress in (IEnumerable<ServerBase.BaseAddress>) baseAddresses)
    {
      if (baseAddress.Url.Scheme == endpointUrl.Scheme)
        baseAddressList.Add(baseAddress);
    }
    return (IList<ServerBase.BaseAddress>) baseAddressList;
  }

  private static string GetBestDiscoveryUrl(Uri clientUrl, ServerBase.BaseAddress baseAddress)
  {
    string bestDiscoveryUrl = baseAddress.Url.ToString();
    if (baseAddress.ProfileUri == "http://opcfoundation.org/UA-Profile/Transport/https-uabinary" && bestDiscoveryUrl.StartsWith("http") && !bestDiscoveryUrl.EndsWith("discovery"))
      bestDiscoveryUrl += "/discovery";
    return bestDiscoveryUrl;
  }

  protected ApplicationDescription TranslateApplicationDescription(
    Uri clientUrl,
    ApplicationDescription description,
    IList<ServerBase.BaseAddress> baseAddresses,
    LocalizedText applicationName)
  {
    StringCollection stringCollection = new StringCollection();
    foreach (ServerBase.BaseAddress baseAddress in (IEnumerable<ServerBase.BaseAddress>) baseAddresses)
      stringCollection.Add(ServerBase.GetBestDiscoveryUrl(clientUrl, baseAddress));
    ApplicationDescription applicationDescription = new ApplicationDescription();
    applicationDescription.ApplicationName = description.ApplicationName;
    applicationDescription.ApplicationUri = description.ApplicationUri;
    applicationDescription.ApplicationType = description.ApplicationType;
    applicationDescription.ProductUri = description.ProductUri;
    applicationDescription.GatewayServerUri = description.DiscoveryProfileUri;
    applicationDescription.DiscoveryUrls = stringCollection;
    if (!LocalizedText.IsNullOrEmpty(applicationName))
      applicationDescription.ApplicationName = applicationName;
    return applicationDescription;
  }

  protected EndpointDescriptionCollection TranslateEndpointDescriptions(
    Uri clientUrl,
    IList<ServerBase.BaseAddress> baseAddresses,
    IList<EndpointDescription> endpoints,
    ApplicationDescription application)
  {
    EndpointDescriptionCollection descriptionCollection = new EndpointDescriptionCollection();
    foreach (EndpointDescription endpoint in (IEnumerable<EndpointDescription>) endpoints)
    {
      UriBuilder uriBuilder = new UriBuilder(endpoint.EndpointUrl);
      foreach (ServerBase.BaseAddress baseAddress in (IEnumerable<ServerBase.BaseAddress>) baseAddresses)
      {
        bool flag = false;
        if (endpoint.TransportProfileUri == "http://opcfoundation.org/UA-Profile/Transport/https-uabinary" && baseAddress.ProfileUri == "http://opcfoundation.org/UA-Profile/Transport/https-uabinary")
          flag = true;
        if ((!(endpoint.TransportProfileUri != baseAddress.ProfileUri) || flag) && !(uriBuilder.Scheme != baseAddress.Url.Scheme) && uriBuilder.Port == baseAddress.Url.Port)
        {
          EndpointDescription endpointDescription = new EndpointDescription();
          endpointDescription.EndpointUrl = baseAddress.Url.ToString();
          if (uriBuilder.Path.StartsWith(baseAddress.Url.PathAndQuery, StringComparison.Ordinal) && uriBuilder.Path.Length > baseAddress.Url.PathAndQuery.Length)
          {
            string str = uriBuilder.Path.Substring(baseAddress.Url.PathAndQuery.Length);
            endpointDescription.EndpointUrl += str;
          }
          endpointDescription.ProxyUrl = endpoint.ProxyUrl;
          endpointDescription.SecurityLevel = endpoint.SecurityLevel;
          endpointDescription.SecurityMode = endpoint.SecurityMode;
          endpointDescription.SecurityPolicyUri = endpoint.SecurityPolicyUri;
          endpointDescription.ServerCertificate = endpoint.ServerCertificate;
          endpointDescription.TransportProfileUri = endpoint.TransportProfileUri;
          endpointDescription.UserIdentityTokens = endpoint.UserIdentityTokens;
          endpointDescription.Server = application;
          descriptionCollection.Add(endpointDescription);
        }
      }
    }
    return descriptionCollection;
  }

  protected virtual void ValidateRequest(RequestHeader requestHeader)
  {
    if (requestHeader == null)
      throw new ServiceResultException(2150236160U /*0x802A0000*/);
    requestHeader.ReturnDiagnostics &= 1023U /*0x03FF*/;
  }

  protected virtual ResponseHeader CreateResponse(RequestHeader requestHeader, uint statusCode)
  {
    if (StatusCode.IsBad((StatusCode) statusCode))
      throw new ServiceResultException(statusCode);
    return new ResponseHeader()
    {
      Timestamp = DateTime.UtcNow,
      RequestHandle = requestHeader.RequestHandle
    };
  }

  protected virtual ResponseHeader CreateResponse(RequestHeader requestHeader, Exception exception)
  {
    ResponseHeader response = new ResponseHeader();
    response.Timestamp = DateTime.UtcNow;
    response.RequestHandle = requestHeader.RequestHandle;
    StringTable stringTable = new StringTable();
    response.ServiceDiagnostics = new DiagnosticInfo(exception, (DiagnosticsMasks) requestHeader.ReturnDiagnostics, true, stringTable);
    response.StringTable = (StringCollection) stringTable.ToArray();
    return response;
  }

  protected virtual ResponseHeader CreateResponse(
    RequestHeader requestHeader,
    StringTable stringTable)
  {
    ResponseHeader response = new ResponseHeader();
    response.Timestamp = DateTime.UtcNow;
    response.RequestHandle = requestHeader.RequestHandle;
    response.StringTable.AddRange((IEnumerable<string>) stringTable.ToArray());
    return response;
  }

  protected virtual void OnUpdateConfiguration(ApplicationConfiguration configuration)
  {
  }

  protected virtual void OnServerStarting(ApplicationConfiguration configuration)
  {
    this.Configuration = configuration;
    this.ServerProperties = this.LoadServerProperties();
    if (configuration.ServerConfiguration != null)
    {
      if (configuration.ServerConfiguration.SecurityPolicies.Count == 0)
        configuration.ServerConfiguration.SecurityPolicies.Add(new ServerSecurityPolicy());
      if (configuration.ServerConfiguration.UserTokenPolicies.Count == 0)
      {
        UserTokenPolicy userTokenPolicy = new UserTokenPolicy()
        {
          TokenType = UserTokenType.Anonymous
        };
        userTokenPolicy.PolicyId = userTokenPolicy.TokenType.ToString();
        configuration.ServerConfiguration.UserTokenPolicies.Add(userTokenPolicy);
      }
    }
    if (configuration.SecurityConfiguration.ApplicationCertificate != null)
      this.InstanceCertificate = configuration.SecurityConfiguration.ApplicationCertificate.Find(true).GetAwaiter().GetResult();
    if (this.InstanceCertificate == null)
      throw new ServiceResultException(2156462080U /*0x80890000*/, "Server does not have an instance certificate assigned.");
    this.InstanceCertificateChain = this.InstanceCertificate.HasPrivateKey ? new X509Certificate2Collection(this.InstanceCertificate) : throw new ServiceResultException(2156462080U /*0x80890000*/, "Server does not have access to the private key for the instance certificate.");
    List<CertificateIdentifier> issuers = new List<CertificateIdentifier>();
    Dictionary<X509Certificate2, ServiceResultException> validationErrors = new Dictionary<X509Certificate2, ServiceResultException>();
    configuration.CertificateValidator.GetIssuersNoExceptionsOnGetIssuer(this.InstanceCertificateChain, issuers, validationErrors).Wait();
    if (validationErrors.Count > 0)
    {
      Utils.LogWarning("Issuer validation errors ignored on startup:");
      foreach (KeyValuePair<X509Certificate2, ServiceResultException> keyValuePair in validationErrors)
      {
        if (keyValuePair.Value != null)
          Utils.LogCertificate(Microsoft.Extensions.Logging.LogLevel.Warning, "- " + keyValuePair.Value.Message, keyValuePair.Key);
      }
    }
    for (int index = 0; index < issuers.Count; ++index)
      this.InstanceCertificateChain.Add(issuers[index].Certificate);
    ServiceMessageContext messageContext = configuration.CreateMessageContext(true);
    messageContext.NamespaceUris = new NamespaceTable();
    this.MessageContext = (IServiceMessageContext) messageContext;
    if (string.IsNullOrEmpty(configuration.ApplicationUri))
    {
      configuration.ApplicationUri = X509Utils.GetApplicationUriFromCertificate(this.InstanceCertificate);
      if (string.IsNullOrEmpty(configuration.ApplicationUri))
        configuration.ApplicationUri = Utils.Format("http://{0}/{1}/{2}", (object) Utils.GetHostName(), (object) configuration.ApplicationName, (object) Guid.NewGuid());
    }
    this.MessageContext.NamespaceUris.Append(configuration.ApplicationUri);
    if (string.IsNullOrEmpty(configuration.ApplicationName) && this.InstanceCertificate != null)
      configuration.ApplicationName = this.InstanceCertificate.GetNameInfo(X509NameType.DnsName, false);
    this.CertificateValidator = configuration.CertificateValidator;
  }

  protected virtual IList<ServiceHost> InitializeServiceHosts(
    ApplicationConfiguration configuration,
    TransportListenerBindings bindingFactory,
    out ApplicationDescription serverDescription,
    out EndpointDescriptionCollection endpoints)
  {
    serverDescription = (ApplicationDescription) null;
    endpoints = (EndpointDescriptionCollection) null;
    return (IList<ServiceHost>) new List<ServiceHost>();
  }

  protected virtual void StartApplication(ApplicationConfiguration configuration)
  {
  }

  protected virtual void OnServerStopping()
  {
  }

  protected virtual ServerProperties LoadServerProperties() => new ServerProperties();

  protected virtual void ProcessRequest(IEndpointIncomingRequest request, object calldata)
  {
    request.CallSynchronously();
  }

  protected class BaseAddress
  {
    public Uri Url { get; set; }

    public List<Uri> AlternateUrls { get; set; }

    public string ProfileUri { get; set; }

    public Uri DiscoveryUrl { get; set; }
  }

  protected class RequestQueue : IDisposable
  {
    private ServerBase m_server;
    private bool m_stopped;
    private int m_activeThreadCount;
    private int m_maxThreadCount;
    private int m_minThreadCount;
    private int m_maxRequestCount;
    private readonly object m_lock = new object();
    private Queue<IEndpointIncomingRequest> m_queue;
    private int m_totalThreadCount;

    public RequestQueue(
      ServerBase server,
      int minThreadCount,
      int maxThreadCount,
      int maxRequestCount)
    {
      this.m_server = server;
      this.m_stopped = false;
      this.m_minThreadCount = minThreadCount;
      this.m_maxThreadCount = maxThreadCount;
      this.m_maxRequestCount = maxRequestCount;
      this.m_activeThreadCount = 0;
      this.m_queue = new Queue<IEndpointIncomingRequest>(maxRequestCount);
      this.m_totalThreadCount = 0;
      int completionPortThreads1;
      ThreadPool.GetMinThreads(out minThreadCount, out completionPortThreads1);
      ThreadPool.SetMinThreads(Math.Max(minThreadCount, this.m_minThreadCount), Math.Max(completionPortThreads1, this.m_minThreadCount));
      int completionPortThreads2;
      ThreadPool.GetMaxThreads(out maxThreadCount, out completionPortThreads2);
      ThreadPool.SetMaxThreads(Math.Max(maxThreadCount, this.m_maxThreadCount), Math.Max(completionPortThreads2, this.m_maxThreadCount));
    }

    public void Dispose() => this.Dispose(true);

    protected virtual void Dispose(bool disposing)
    {
      if (!disposing)
        return;
      lock (this.m_lock)
      {
        this.m_stopped = true;
        Monitor.PulseAll(this.m_lock);
        this.m_queue.Clear();
      }
    }

    public void ScheduleIncomingRequest(IEndpointIncomingRequest request)
    {
      Monitor.Enter(this.m_lock);
      bool flag = true;
      try
      {
        if (this.m_stopped)
        {
          flag = false;
          Monitor.Exit(this.m_lock);
          request.OperationCompleted((IServiceResponse) null, (ServiceResult) 2148401152U /*0x800E0000*/);
          Utils.LogTrace("Server halted.");
        }
        else if (this.m_queue.Count >= this.m_maxRequestCount)
        {
          int totalThreadCount = this.m_totalThreadCount;
          int activeThreadCount = this.m_activeThreadCount;
          flag = false;
          Monitor.Exit(this.m_lock);
          request.OperationCompleted((IServiceResponse) null, (ServiceResult) 2163081216U /*0x80EE0000*/);
          Utils.LogTrace("Too many operations. Total: {0} Active: {1}", (object) totalThreadCount, (object) activeThreadCount);
        }
        else
        {
          this.m_queue.Enqueue(request);
          if (this.m_activeThreadCount < this.m_totalThreadCount)
          {
            Monitor.Pulse(this.m_lock);
          }
          else
          {
            if (this.m_totalThreadCount >= this.m_maxThreadCount)
              return;
            int num1 = ++this.m_totalThreadCount;
            int num2 = ++this.m_activeThreadCount;
            flag = false;
            Monitor.Exit(this.m_lock);
            Thread thread = new Thread(new ParameterizedThreadStart(this.OnProcessRequestQueue));
            thread.IsBackground = true;
            thread.Start((object) null);
            Utils.LogTrace("Thread created: {0:X8}. Total: {1} Active: {2}", (object) thread.ManagedThreadId, (object) num1, (object) num2);
          }
        }
      }
      finally
      {
        if (flag)
          Monitor.Exit(this.m_lock);
      }
    }

    private void OnProcessRequestQueue(object state)
    {
      lock (this.m_lock)
      {
        while (true)
        {
          while (this.m_queue.Count == 0)
          {
            --this.m_activeThreadCount;
            if (!this.m_stopped && (Monitor.Wait(this.m_lock, 15000) || this.m_totalThreadCount <= this.m_minThreadCount))
            {
              ++this.m_activeThreadCount;
            }
            else
            {
              --this.m_totalThreadCount;
              Utils.LogTrace("Thread ended: {0:X8}. Total: {1} Active: {2}", (object) Environment.CurrentManagedThreadId, (object) this.m_totalThreadCount, (object) this.m_activeThreadCount);
              return;
            }
          }
          IEndpointIncomingRequest request = this.m_queue.Dequeue();
          Monitor.Exit(this.m_lock);
          try
          {
            this.m_server.ProcessRequest(request, state);
          }
          catch (Exception ex)
          {
            object[] objArray = Array.Empty<object>();
            Utils.LogError(ex, "Unexpected error processing incoming request.", objArray);
          }
          finally
          {
            Monitor.Enter(this.m_lock);
          }
        }
      }
    }
  }
}
