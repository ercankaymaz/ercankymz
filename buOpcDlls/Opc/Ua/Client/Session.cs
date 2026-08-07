// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Client.Session
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Microsoft.Extensions.Logging;
using Opc.Ua.Bindings;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

#nullable disable
namespace Opc.Ua.Client;

[ComVisible(true)]
public class Session : 
  SessionClientBatched,
  ISession,
  ISessionClient,
  ISessionClientMethods,
  IClientBase,
  IDisposable
{
  protected double m_sessionTimeout;
  protected StringCollection m_preferredLocales;
  protected ApplicationConfiguration m_configuration;
  protected ConfiguredEndpoint m_endpoint;
  protected X509Certificate2 m_instanceCertificate;
  protected X509Certificate2Collection m_instanceCertificateChain;
  protected bool m_checkDomain;
  protected string m_sessionName;
  protected IUserIdentity m_identity;
  private ISessionFactory m_sessionFactory;
  private SubscriptionAcknowledgementCollection m_acknowledgementsToSend;
  private Dictionary<uint, uint> m_latestAcknowledgementsSent;
  private List<Subscription> m_subscriptions;
  private Dictionary<NodeId, DataDictionary> m_dictionaries;
  private Subscription m_defaultSubscription;
  private bool m_deleteSubscriptionsOnClose;
  private bool m_transferSubscriptionsOnReconnect;
  private uint m_maxRequestMessageSize;
  private NamespaceTable m_namespaceUris;
  private StringTable m_serverUris;
  private IEncodeableFactory m_factory;
  private Opc.Ua.SystemContext m_systemContext;
  private Opc.Ua.Client.NodeCache m_nodeCache;
  private List<IUserIdentity> m_identityHistory;
  private object m_handle;
  private byte[] m_serverNonce;
  private byte[] m_previousServerNonce;
  private X509Certificate2 m_serverCertificate;
  private long m_publishCounter;
  private int m_tooManyPublishRequests;
  private DateTime m_lastKeepAliveTime;
  private ServerState m_serverState;
  private int m_keepAliveInterval;
  private Timer m_keepAliveTimer;
  private long m_keepAliveCounter;
  private bool m_reconnecting;
  private SemaphoreSlim m_reconnectLock;
  private const int kReconnectTimeout = 15000;
  private const int kMinPublishRequestCountMax = 100;
  private const int kDefaultPublishRequestCount = 1;
  private int m_minPublishRequestCount;
  private LinkedList<Session.AsyncRequestState> m_outstandingRequests;
  private readonly EndpointDescriptionCollection m_discoveryServerEndpoints;
  private readonly StringCollection m_discoveryProfileUris;
  private readonly object m_eventLock = new object();

  public Session(
    ISessionChannel channel,
    ApplicationConfiguration configuration,
    ConfiguredEndpoint endpoint)
    : this(channel as ITransportChannel, configuration, endpoint, (X509Certificate2) null)
  {
  }

  public Session(
    ITransportChannel channel,
    ApplicationConfiguration configuration,
    ConfiguredEndpoint endpoint,
    X509Certificate2 clientCertificate,
    EndpointDescriptionCollection availableEndpoints = null,
    StringCollection discoveryProfileUris = null)
    : base(channel)
  {
    this.Initialize(channel, configuration, endpoint, clientCertificate);
    this.m_discoveryServerEndpoints = availableEndpoints;
    this.m_discoveryProfileUris = discoveryProfileUris;
  }

  public Session(ITransportChannel channel, Session template, bool copyEventHandlers)
    : base(channel)
  {
    this.Initialize(channel, template.m_configuration, template.ConfiguredEndpoint, template.m_instanceCertificate);
    this.m_sessionFactory = template.m_sessionFactory;
    this.m_defaultSubscription = template.m_defaultSubscription;
    this.m_deleteSubscriptionsOnClose = template.m_deleteSubscriptionsOnClose;
    this.m_transferSubscriptionsOnReconnect = template.m_transferSubscriptionsOnReconnect;
    this.m_sessionTimeout = template.m_sessionTimeout;
    this.m_maxRequestMessageSize = template.m_maxRequestMessageSize;
    this.m_minPublishRequestCount = template.m_minPublishRequestCount;
    this.m_preferredLocales = template.PreferredLocales;
    this.m_sessionName = template.SessionName;
    this.m_handle = template.Handle;
    this.m_identity = template.Identity;
    this.m_keepAliveInterval = template.KeepAliveInterval;
    this.m_checkDomain = template.m_checkDomain;
    if (template.OperationTimeout > 0)
      this.OperationTimeout = template.OperationTimeout;
    if (copyEventHandlers)
    {
      this.m_KeepAlive = template.m_KeepAlive;
      this.m_Publish = template.m_Publish;
      this.m_PublishError = template.m_PublishError;
      this.m_PublishSequenceNumbersToAcknowledge = template.m_PublishSequenceNumbersToAcknowledge;
      this.m_SubscriptionsChanged = template.m_SubscriptionsChanged;
      this.m_SessionClosing = template.m_SessionClosing;
      this.m_SessionConfigurationChanged = template.m_SessionConfigurationChanged;
    }
    foreach (Subscription subscription in template.Subscriptions)
      this.AddSubscription(subscription.CloneSubscription(copyEventHandlers));
  }

  private void Initialize(
    ITransportChannel channel,
    ApplicationConfiguration configuration,
    ConfiguredEndpoint endpoint,
    X509Certificate2 clientCertificate)
  {
    this.Initialize();
    this.ValidateClientConfiguration(configuration);
    this.m_configuration = configuration;
    this.m_endpoint = endpoint;
    this.m_defaultSubscription.MinLifetimeInterval = (uint) configuration.ClientConfiguration.MinSubscriptionLifetime;
    if (this.m_endpoint.Description.SecurityPolicyUri != "http://opcfoundation.org/UA/SecurityPolicy#None")
    {
      this.m_instanceCertificate = clientCertificate;
      if (clientCertificate == null)
      {
        if (this.m_configuration.SecurityConfiguration.ApplicationCertificate == null)
          throw new ServiceResultException(2156462080U /*0x80890000*/, "The client configuration does not specify an application instance certificate.");
        this.m_instanceCertificate = this.m_configuration.SecurityConfiguration.ApplicationCertificate.Find(true).Result;
      }
      if (this.m_instanceCertificate == null)
      {
        CertificateIdentifier applicationCertificate = this.m_configuration.SecurityConfiguration.ApplicationCertificate;
        throw ServiceResultException.Create(2156462080U /*0x80890000*/, "Cannot find the application instance certificate. Store={0}, SubjectName={1}, Thumbprint={2}.", (object) applicationCertificate.StorePath, (object) applicationCertificate.SubjectName, (object) applicationCertificate.Thumbprint);
      }
      this.m_instanceCertificateChain = this.m_instanceCertificate.HasPrivateKey ? new X509Certificate2Collection(this.m_instanceCertificate) : throw ServiceResultException.Create(2156462080U /*0x80890000*/, "No private key for the application instance certificate. Subject={0}, Thumbprint={1}.", (object) this.m_instanceCertificate.Subject, (object) this.m_instanceCertificate.Thumbprint);
      List<CertificateIdentifier> issuers = new List<CertificateIdentifier>();
      configuration.CertificateValidator.GetIssuers(this.m_instanceCertificate, issuers).Wait();
      for (int index = 0; index < issuers.Count; ++index)
        this.m_instanceCertificateChain.Add(issuers[index].Certificate);
    }
    IServiceMessageContext messageContext = channel.MessageContext;
    if (messageContext != null)
    {
      this.m_namespaceUris = messageContext.NamespaceUris;
      this.m_serverUris = messageContext.ServerUris;
      this.m_factory = messageContext.Factory;
    }
    else
    {
      this.m_namespaceUris = new NamespaceTable();
      this.m_serverUris = new StringTable();
      this.m_factory = (IEncodeableFactory) new EncodeableFactory((IEncodeableFactory) EncodeableFactory.GlobalFactory);
    }
    this.m_nodeCache = new Opc.Ua.Client.NodeCache((ISession) this);
    this.m_preferredLocales = (StringCollection) new string[1]
    {
      CultureInfo.CurrentCulture.Name
    };
    this.m_systemContext = new Opc.Ua.SystemContext()
    {
      SystemHandle = (object) this,
      EncodeableFactory = this.m_factory,
      NamespaceUris = this.m_namespaceUris,
      ServerUris = this.m_serverUris,
      TypeTable = this.TypeTree,
      PreferredLocales = (IList<string>) null,
      SessionId = (NodeId) null,
      UserIdentity = (IUserIdentity) null
    };
  }

  private void Initialize()
  {
    this.m_sessionFactory = (ISessionFactory) DefaultSessionFactory.Instance;
    this.m_sessionTimeout = 0.0;
    this.m_namespaceUris = new NamespaceTable();
    this.m_serverUris = new StringTable();
    this.m_factory = (IEncodeableFactory) EncodeableFactory.GlobalFactory;
    this.m_configuration = (ApplicationConfiguration) null;
    this.m_instanceCertificate = (X509Certificate2) null;
    this.m_endpoint = (ConfiguredEndpoint) null;
    this.m_subscriptions = new List<Subscription>();
    this.m_dictionaries = new Dictionary<NodeId, DataDictionary>();
    this.m_acknowledgementsToSend = new SubscriptionAcknowledgementCollection();
    this.m_latestAcknowledgementsSent = new Dictionary<uint, uint>();
    this.m_identityHistory = new List<IUserIdentity>();
    this.m_outstandingRequests = new LinkedList<Session.AsyncRequestState>();
    this.m_keepAliveInterval = 5000;
    this.m_tooManyPublishRequests = 0;
    this.m_minPublishRequestCount = 1;
    this.m_sessionName = "";
    this.m_deleteSubscriptionsOnClose = true;
    this.m_transferSubscriptionsOnReconnect = false;
    this.m_reconnecting = false;
    this.m_reconnectLock = new SemaphoreSlim(1, 1);
    this.m_defaultSubscription = new Subscription()
    {
      DisplayName = "Subscription",
      PublishingInterval = 1000,
      KeepAliveCount = 10U,
      LifetimeCount = 1000U,
      Priority = byte.MaxValue,
      PublishingEnabled = true
    };
  }

  private void ValidateClientConfiguration(ApplicationConfiguration configuration)
  {
    if (configuration == null)
      throw new ArgumentNullException(nameof (configuration));
    string str;
    if (configuration.ClientConfiguration == null)
      str = "ClientConfiguration";
    else if (configuration.SecurityConfiguration == null)
    {
      str = "SecurityConfiguration";
    }
    else
    {
      if (configuration.CertificateValidator != null)
        return;
      str = "CertificateValidator";
    }
    throw new ServiceResultException(2156462080U /*0x80890000*/, $"The client configuration does not specify the {str}.");
  }

  private void ValidateServerNonce(
    IUserIdentity identity,
    byte[] serverNonce,
    string securityPolicyUri,
    byte[] previousServerNonce,
    MessageSecurityMode channelSecurityMode = MessageSecurityMode.None)
  {
    if (string.IsNullOrEmpty(securityPolicyUri) || securityPolicyUri == "http://opcfoundation.org/UA/SecurityPolicy#None" || identity == null || identity.TokenType == UserTokenType.Anonymous)
      return;
    if (!Utils.Nonce.ValidateNonce(serverNonce, MessageSecurityMode.SignAndEncrypt, (uint) this.m_configuration.SecurityConfiguration.NonceLength))
    {
      if (channelSecurityMode != MessageSecurityMode.SignAndEncrypt && !this.m_configuration.SecurityConfiguration.SuppressNonceValidationErrors)
        throw ServiceResultException.Create(2149842944U /*0x80240000*/, "The server nonce has not the correct length or is not random enough.");
      Utils.LogWarning((EventId) 512 /*0x0200*/, "Warning: The server nonce has not the correct length or is not random enough. The error is suppressed by user setting or because the channel is encrypted.");
    }
    if (previousServerNonce == null || !Utils.CompareNonce(serverNonce, previousServerNonce))
      return;
    if (channelSecurityMode != MessageSecurityMode.SignAndEncrypt && !this.m_configuration.SecurityConfiguration.SuppressNonceValidationErrors)
      throw ServiceResultException.Create(2149842944U /*0x80240000*/, "Server nonce is equal with previously returned nonce.");
    Utils.LogWarning((EventId) 512 /*0x0200*/, "Warning: The Server nonce is equal with previously returned nonce. The error is suppressed by user setting or because the channel is encrypted.");
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing)
    {
      this.StopKeepAliveTimer();
      Utils.SilentDispose((IDisposable) this.m_defaultSubscription);
      this.m_defaultSubscription = (Subscription) null;
      Utils.SilentDispose((IDisposable) this.m_nodeCache);
      this.m_nodeCache = (Opc.Ua.Client.NodeCache) null;
      IList<Subscription> subscriptionList = (IList<Subscription>) null;
      lock (this.SyncRoot)
      {
        subscriptionList = (IList<Subscription>) new List<Subscription>((IEnumerable<Subscription>) this.m_subscriptions);
        this.m_subscriptions.Clear();
      }
      foreach (IDisposable disposable in (IEnumerable<Subscription>) subscriptionList)
        Utils.SilentDispose(disposable);
    }
    base.Dispose(disposing);
    if (!disposing)
      return;
    this.m_KeepAlive = (KeepAliveEventHandler) null;
    this.m_Publish = (NotificationEventHandler) null;
    this.m_PublishError = (PublishErrorEventHandler) null;
    this.m_PublishSequenceNumbersToAcknowledge = (PublishSequenceNumbersToAcknowledgeEventHandler) null;
    this.m_SubscriptionsChanged = (EventHandler) null;
    this.m_SessionClosing = (EventHandler) null;
    this.m_SessionConfigurationChanged = (EventHandler) null;
  }

  public event KeepAliveEventHandler KeepAlive
  {
    add
    {
      lock (this.m_eventLock)
        this.m_KeepAlive += value;
    }
    remove
    {
      lock (this.m_eventLock)
        this.m_KeepAlive -= value;
    }
  }

  public event NotificationEventHandler Notification
  {
    add
    {
      lock (this.m_eventLock)
        this.m_Publish += value;
    }
    remove
    {
      lock (this.m_eventLock)
        this.m_Publish -= value;
    }
  }

  public event PublishErrorEventHandler PublishError
  {
    add
    {
      lock (this.m_eventLock)
        this.m_PublishError += value;
    }
    remove
    {
      lock (this.m_eventLock)
        this.m_PublishError -= value;
    }
  }

  public event PublishSequenceNumbersToAcknowledgeEventHandler PublishSequenceNumbersToAcknowledge
  {
    add
    {
      lock (this.m_eventLock)
        this.m_PublishSequenceNumbersToAcknowledge += value;
    }
    remove
    {
      lock (this.m_eventLock)
        this.m_PublishSequenceNumbersToAcknowledge -= value;
    }
  }

  public event EventHandler SubscriptionsChanged
  {
    add => this.m_SubscriptionsChanged += value;
    remove => this.m_SubscriptionsChanged -= value;
  }

  public event EventHandler SessionClosing
  {
    add => this.m_SessionClosing += value;
    remove => this.m_SessionClosing -= value;
  }

  public event EventHandler SessionConfigurationChanged
  {
    add => this.m_SessionConfigurationChanged += value;
    remove => this.m_SessionConfigurationChanged -= value;
  }

  public ISessionFactory SessionFactory
  {
    get => this.m_sessionFactory;
    set => this.m_sessionFactory = value;
  }

  public ConfiguredEndpoint ConfiguredEndpoint => this.m_endpoint;

  public string SessionName => this.m_sessionName;

  public double SessionTimeout => this.m_sessionTimeout;

  public object Handle
  {
    get => this.m_handle;
    set => this.m_handle = value;
  }

  public IUserIdentity Identity => this.m_identity;

  public IEnumerable<IUserIdentity> IdentityHistory
  {
    get => (IEnumerable<IUserIdentity>) this.m_identityHistory;
  }

  public NamespaceTable NamespaceUris => this.m_namespaceUris;

  public StringTable ServerUris => this.m_serverUris;

  public ISystemContext SystemContext => (ISystemContext) this.m_systemContext;

  public IEncodeableFactory Factory => this.m_factory;

  public ITypeTable TypeTree => this.m_nodeCache.TypeTree;

  public INodeCache NodeCache => (INodeCache) this.m_nodeCache;

  public FilterContext FilterContext
  {
    get
    {
      return new FilterContext(this.m_namespaceUris, this.m_nodeCache.TypeTree, (IList<string>) this.m_preferredLocales);
    }
  }

  public StringCollection PreferredLocales => this.m_preferredLocales;

  public IReadOnlyDictionary<NodeId, DataDictionary> DataTypeSystem
  {
    get => (IReadOnlyDictionary<NodeId, DataDictionary>) this.m_dictionaries;
  }

  public IEnumerable<Subscription> Subscriptions
  {
    get
    {
      lock (this.SyncRoot)
        return (IEnumerable<Subscription>) new ReadOnlyList<Subscription>((IList<Subscription>) this.m_subscriptions);
    }
  }

  public int SubscriptionCount
  {
    get
    {
      lock (this.SyncRoot)
        return this.m_subscriptions.Count;
    }
  }

  public bool DeleteSubscriptionsOnClose
  {
    get => this.m_deleteSubscriptionsOnClose;
    set => this.m_deleteSubscriptionsOnClose = value;
  }

  public bool TransferSubscriptionsOnReconnect
  {
    get => this.m_transferSubscriptionsOnReconnect;
    set => this.m_transferSubscriptionsOnReconnect = value;
  }

  public bool CheckDomain => this.m_checkDomain;

  public Subscription DefaultSubscription
  {
    get => this.m_defaultSubscription;
    set => this.m_defaultSubscription = value;
  }

  public int KeepAliveInterval
  {
    get => this.m_keepAliveInterval;
    set
    {
      this.m_keepAliveInterval = value;
      this.StartKeepAliveTimer();
    }
  }

  public bool KeepAliveStopped
  {
    get
    {
      lock (this.m_eventLock)
        return (long) (this.m_keepAliveInterval * 2) * 10000L <= DateTime.UtcNow.Ticks - this.m_lastKeepAliveTime.Ticks;
    }
  }

  public DateTime LastKeepAliveTime => this.m_lastKeepAliveTime;

  public int OutstandingRequestCount
  {
    get
    {
      lock (this.m_outstandingRequests)
        return this.m_outstandingRequests.Count;
    }
  }

  public int DefunctRequestCount
  {
    get
    {
      lock (this.m_outstandingRequests)
      {
        int defunctRequestCount = 0;
        for (LinkedListNode<Session.AsyncRequestState> linkedListNode = this.m_outstandingRequests.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
        {
          if (linkedListNode.Value.Defunct)
            ++defunctRequestCount;
        }
        return defunctRequestCount;
      }
    }
  }

  public int GoodPublishRequestCount
  {
    get
    {
      lock (this.m_outstandingRequests)
      {
        int publishRequestCount = 0;
        for (LinkedListNode<Session.AsyncRequestState> linkedListNode = this.m_outstandingRequests.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
        {
          if (!linkedListNode.Value.Defunct && linkedListNode.Value.RequestTypeId == 824U)
            ++publishRequestCount;
        }
        return publishRequestCount;
      }
    }
  }

  public int MinPublishRequestCount
  {
    get => this.m_minPublishRequestCount;
    set
    {
      lock (this.SyncRoot)
        this.m_minPublishRequestCount = value >= 1 && value <= 100 ? value : throw new ArgumentOutOfRangeException(nameof (MinPublishRequestCount), $"Minimum publish request count must be between {1} and {100}.");
    }
  }

  public static Task<Session> Create(
    ApplicationConfiguration configuration,
    ConfiguredEndpoint endpoint,
    bool updateBeforeConnect,
    string sessionName,
    uint sessionTimeout,
    IUserIdentity identity,
    IList<string> preferredLocales,
    CancellationToken ct = default (CancellationToken))
  {
    return Session.Create(configuration, endpoint, updateBeforeConnect, false, sessionName, sessionTimeout, identity, preferredLocales, ct);
  }

  public static Task<Session> Create(
    ApplicationConfiguration configuration,
    ConfiguredEndpoint endpoint,
    bool updateBeforeConnect,
    bool checkDomain,
    string sessionName,
    uint sessionTimeout,
    IUserIdentity identity,
    IList<string> preferredLocales,
    CancellationToken ct = default (CancellationToken))
  {
    return Session.Create(configuration, (ITransportWaitingConnection) null, endpoint, updateBeforeConnect, checkDomain, sessionName, sessionTimeout, identity, preferredLocales, ct);
  }

  public static Session Create(
    ApplicationConfiguration configuration,
    ITransportChannel channel,
    ConfiguredEndpoint endpoint,
    X509Certificate2 clientCertificate,
    EndpointDescriptionCollection availableEndpoints = null,
    StringCollection discoveryProfileUris = null)
  {
    return Session.Create((ISessionInstantiator) DefaultSessionFactory.Instance, configuration, channel, endpoint, clientCertificate, availableEndpoints, discoveryProfileUris);
  }

  public static Session Create(
    ISessionInstantiator sessionInstantiator,
    ApplicationConfiguration configuration,
    ITransportChannel channel,
    ConfiguredEndpoint endpoint,
    X509Certificate2 clientCertificate,
    EndpointDescriptionCollection availableEndpoints = null,
    StringCollection discoveryProfileUris = null)
  {
    return sessionInstantiator.Create(channel, configuration, endpoint, clientCertificate, availableEndpoints, discoveryProfileUris);
  }

  public static async Task<ITransportChannel> CreateChannelAsync(
    ApplicationConfiguration configuration,
    ITransportWaitingConnection connection,
    ConfiguredEndpoint endpoint,
    bool updateBeforeConnect,
    bool checkDomain,
    CancellationToken ct = default (CancellationToken))
  {
    endpoint.UpdateBeforeConnect = updateBeforeConnect;
    EndpointDescription endpointDescription = endpoint.Description;
    EndpointConfiguration endpointConfiguration = endpoint.Configuration;
    if (endpointConfiguration == null)
      endpoint.Configuration = endpointConfiguration = EndpointConfiguration.Create(configuration);
    IServiceMessageContext messageContext = (IServiceMessageContext) configuration.CreateMessageContext(true);
    if (endpoint.UpdateBeforeConnect && connection == null)
    {
      await endpoint.UpdateFromServerAsync(ct).ConfigureAwait(false);
      endpointDescription = endpoint.Description;
      endpointConfiguration = endpoint.Configuration;
    }
    if (checkDomain && endpoint.Description.ServerCertificate != null && endpoint.Description.ServerCertificate.Length != 0)
    {
      configuration.CertificateValidator?.ValidateDomains(new X509Certificate2(endpoint.Description.ServerCertificate), endpoint);
      checkDomain = false;
    }
    X509Certificate2 clientCertificate = (X509Certificate2) null;
    X509Certificate2Collection clientCertificateChain = (X509Certificate2Collection) null;
    if (endpointDescription.SecurityPolicyUri != "http://opcfoundation.org/UA/SecurityPolicy#None")
    {
      clientCertificate = await Session.LoadCertificate(configuration).ConfigureAwait(false);
      clientCertificateChain = await Session.LoadCertificateChain(configuration, clientCertificate).ConfigureAwait(false);
    }
    ITransportChannel channelAsync = connection == null ? SessionChannel.Create(configuration, endpointDescription, endpointConfiguration, clientCertificate, clientCertificateChain, messageContext) : UaChannelBase.CreateUaBinaryChannel(configuration, connection, endpointDescription, endpointConfiguration, clientCertificate, clientCertificateChain, messageContext);
    endpointDescription = (EndpointDescription) null;
    endpointConfiguration = (EndpointConfiguration) null;
    messageContext = (IServiceMessageContext) null;
    clientCertificate = (X509Certificate2) null;
    return channelAsync;
  }

  public static Task<Session> Create(
    ApplicationConfiguration configuration,
    ITransportWaitingConnection connection,
    ConfiguredEndpoint endpoint,
    bool updateBeforeConnect,
    bool checkDomain,
    string sessionName,
    uint sessionTimeout,
    IUserIdentity identity,
    IList<string> preferredLocales,
    CancellationToken ct = default (CancellationToken))
  {
    return Session.Create((ISessionInstantiator) DefaultSessionFactory.Instance, configuration, connection, endpoint, updateBeforeConnect, checkDomain, sessionName, sessionTimeout, identity, preferredLocales, ct);
  }

  public static async Task<Session> Create(
    ISessionInstantiator sessionInstantiator,
    ApplicationConfiguration configuration,
    ITransportWaitingConnection connection,
    ConfiguredEndpoint endpoint,
    bool updateBeforeConnect,
    bool checkDomain,
    string sessionName,
    uint sessionTimeout,
    IUserIdentity identity,
    IList<string> preferredLocales,
    CancellationToken ct = default (CancellationToken))
  {
    Session session = sessionInstantiator.Create(await Session.CreateChannelAsync(configuration, connection, endpoint, updateBeforeConnect, checkDomain, ct).ConfigureAwait(false), configuration, endpoint, (X509Certificate2) null);
    try
    {
      await session.OpenAsync(sessionName, sessionTimeout, identity, preferredLocales, checkDomain, ct).ConfigureAwait(false);
    }
    catch (Exception ex)
    {
      session.Dispose();
      throw;
    }
    Session session1 = session;
    session = (Session) null;
    return session1;
  }

  public static Task<Session> Create(
    ApplicationConfiguration configuration,
    ReverseConnectManager reverseConnectManager,
    ConfiguredEndpoint endpoint,
    bool updateBeforeConnect,
    bool checkDomain,
    string sessionName,
    uint sessionTimeout,
    IUserIdentity userIdentity,
    IList<string> preferredLocales,
    CancellationToken ct = default (CancellationToken))
  {
    return Session.Create((ISessionInstantiator) DefaultSessionFactory.Instance, configuration, reverseConnectManager, endpoint, updateBeforeConnect, checkDomain, sessionName, sessionTimeout, userIdentity, preferredLocales, ct);
  }

  public static async Task<Session> Create(
    ISessionInstantiator sessionInstantiator,
    ApplicationConfiguration configuration,
    ReverseConnectManager reverseConnectManager,
    ConfiguredEndpoint endpoint,
    bool updateBeforeConnect,
    bool checkDomain,
    string sessionName,
    uint sessionTimeout,
    IUserIdentity userIdentity,
    IList<string> preferredLocales,
    CancellationToken ct = default (CancellationToken))
  {
    if (reverseConnectManager == null)
      return await Session.Create(sessionInstantiator, configuration, (ITransportWaitingConnection) null, endpoint, updateBeforeConnect, checkDomain, sessionName, sessionTimeout, userIdentity, preferredLocales, ct).ConfigureAwait(false);
    ConfiguredTaskAwaitable<ITransportWaitingConnection>.ConfiguredTaskAwaiter awaiter1;
    ConfiguredTaskAwaitable.ConfiguredTaskAwaiter awaiter2;
    ITransportWaitingConnection connection;
    do
    {
      awaiter1 = reverseConnectManager.WaitForConnection(endpoint.EndpointUrl, endpoint.ReverseConnect?.ServerUri, ct).ConfigureAwait(false).GetAwaiter();
      if (awaiter1.IsCompleted)
      {
        connection = awaiter1.GetResult();
        if (updateBeforeConnect)
          goto label_6;
label_5:
        continue;
label_6:
        awaiter2 = endpoint.UpdateFromServerAsync(endpoint.EndpointUrl, connection, endpoint.Description.SecurityMode, endpoint.Description.SecurityPolicyUri, ct).ConfigureAwait(false).GetAwaiter();
        if (awaiter2.IsCompleted)
        {
          awaiter2.GetResult();
          updateBeforeConnect = false;
          connection = (ITransportWaitingConnection) null;
          goto label_5;
        }
        goto label_9;
      }
      goto label_8;
    }
    while (connection == null);
    goto label_10;
label_8:
    int num = 1;
    // ISSUE: explicit reference operation
    // ISSUE: reference to a compiler-generated field
    (^this).\u003C\u003E1__state = 1;
    ConfiguredTaskAwaitable<ITransportWaitingConnection>.ConfiguredTaskAwaiter configuredTaskAwaiter1 = awaiter1;
    // ISSUE: explicit reference operation
    // ISSUE: reference to a compiler-generated field
    (^this).\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ConfiguredTaskAwaitable<ITransportWaitingConnection>.ConfiguredTaskAwaiter, Session.\u003CCreate\u003Ed__102>(ref awaiter1, this);
    return;
label_9:
    num = 2;
    // ISSUE: explicit reference operation
    // ISSUE: reference to a compiler-generated field
    (^this).\u003C\u003E1__state = 2;
    ConfiguredTaskAwaitable.ConfiguredTaskAwaiter configuredTaskAwaiter2 = awaiter2;
    // ISSUE: explicit reference operation
    // ISSUE: reference to a compiler-generated field
    (^this).\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ConfiguredTaskAwaitable.ConfiguredTaskAwaiter, Session.\u003CCreate\u003Ed__102>(ref awaiter2, this);
    return;
label_10:
    return await Session.Create(sessionInstantiator, configuration, connection, endpoint, false, checkDomain, sessionName, sessionTimeout, userIdentity, preferredLocales, ct).ConfigureAwait(false);
  }

  public static Session Recreate(Session template)
  {
    ServiceMessageContext messageContext = template.m_configuration.CreateMessageContext();
    messageContext.Factory = template.Factory;
    ITransportChannel channel = SessionChannel.Create(template.m_configuration, template.ConfiguredEndpoint.Description, template.ConfiguredEndpoint.Configuration, template.m_instanceCertificate, template.m_configuration.SecurityConfiguration.SendCertificateChain ? template.m_instanceCertificateChain : (X509Certificate2Collection) null, (IServiceMessageContext) messageContext);
    Session session = template.CloneSession(channel, true);
    try
    {
      session.Open(template.SessionName, (uint) template.SessionTimeout, template.Identity, (IList<string>) template.PreferredLocales, template.m_checkDomain);
      session.RecreateSubscriptions(template.Subscriptions);
    }
    catch (Exception ex)
    {
      session.Dispose();
      throw ServiceResultException.Create(2147811328U /*0x80050000*/, ex, "Could not recreate session. {0}", (object) template.SessionName);
    }
    return session;
  }

  public static Session Recreate(Session template, ITransportWaitingConnection connection)
  {
    ServiceMessageContext messageContext = template.m_configuration.CreateMessageContext();
    messageContext.Factory = template.Factory;
    ITransportChannel channel = SessionChannel.Create(template.m_configuration, connection, template.m_endpoint.Description, template.m_endpoint.Configuration, template.m_instanceCertificate, template.m_configuration.SecurityConfiguration.SendCertificateChain ? template.m_instanceCertificateChain : (X509Certificate2Collection) null, (IServiceMessageContext) messageContext);
    Session session = template.CloneSession(channel, true);
    try
    {
      session.Open(template.m_sessionName, (uint) template.m_sessionTimeout, template.m_identity, (IList<string>) template.m_preferredLocales, template.m_checkDomain);
      session.RecreateSubscriptions(template.Subscriptions);
    }
    catch (Exception ex)
    {
      session.Dispose();
      throw ServiceResultException.Create(2147811328U /*0x80050000*/, ex, "Could not recreate session. {0}", (object) template.m_sessionName);
    }
    return session;
  }

  public static Session Recreate(Session template, ITransportChannel transportChannel)
  {
    template.m_configuration.CreateMessageContext().Factory = template.Factory;
    Session session = template.CloneSession(transportChannel, true);
    try
    {
      session.Open(template.m_sessionName, (uint) template.m_sessionTimeout, template.m_identity, (IList<string>) template.m_preferredLocales, template.m_checkDomain);
      foreach (Subscription subscription in session.Subscriptions)
        subscription.Create();
    }
    catch (Exception ex)
    {
      session.Dispose();
      throw ServiceResultException.Create(2147811328U /*0x80050000*/, ex, "Could not recreate session. {0}", (object) template.m_sessionName);
    }
    return session;
  }

  public event RenewUserIdentityEventHandler RenewUserIdentity
  {
    add => this.m_RenewUserIdentity += value;
    remove => this.m_RenewUserIdentity -= value;
  }

  private event RenewUserIdentityEventHandler m_RenewUserIdentity;

  public bool ApplySessionConfiguration(SessionConfiguration sessionConfiguration)
  {
    if (sessionConfiguration == null)
      throw new ArgumentNullException(nameof (sessionConfiguration));
    byte[] serverCertificate = this.m_endpoint.Description?.ServerCertificate;
    this.m_sessionName = sessionConfiguration.SessionName;
    this.m_serverCertificate = serverCertificate != null ? new X509Certificate2(serverCertificate) : (X509Certificate2) null;
    this.m_identity = sessionConfiguration.Identity;
    this.m_checkDomain = sessionConfiguration.CheckDomain;
    this.m_serverNonce = sessionConfiguration.ServerNonce;
    this.SessionCreated(sessionConfiguration.SessionId, sessionConfiguration.AuthenticationToken);
    return true;
  }

  public SessionConfiguration SaveSessionConfiguration(Stream stream = null)
  {
    SessionConfiguration graph = new SessionConfiguration((ISession) this, this.m_serverNonce, this.AuthenticationToken);
    if (stream != null)
    {
      XmlWriterSettings settings = Utils.DefaultXmlWriterSettings();
      using (XmlWriter writer = XmlWriter.Create(stream, settings))
        new DataContractSerializer(typeof (SessionConfiguration)).WriteObject(writer, (object) graph);
    }
    return graph;
  }

  public void Reconnect()
  {
    this.Reconnect((ITransportWaitingConnection) null, (ITransportChannel) null);
  }

  public void Reconnect(ITransportWaitingConnection connection)
  {
    this.Reconnect(connection, (ITransportChannel) null);
  }

  public void Reconnect(ITransportChannel channel)
  {
    this.Reconnect((ITransportWaitingConnection) null, channel);
  }

  private void Reconnect(ITransportWaitingConnection connection, ITransportChannel transportChannel = null)
  {
    bool flag = false;
    try
    {
      Utils.LogInfo("Session RECONNECT {0} starting.", (object) this.SessionId);
      this.m_reconnectLock.Wait();
      int num1 = this.m_reconnecting ? 1 : 0;
      this.m_reconnecting = true;
      flag = true;
      this.m_reconnectLock.Release();
      if (num1 != 0)
      {
        Utils.LogWarning("Session is already attempting to reconnect.");
        throw ServiceResultException.Create(2158952448U /*0x80AF0000*/, "Session is already attempting to reconnect.");
      }
      IAsyncResult result = this.PrepareReconnectBeginActivate(connection, transportChannel);
      if (!result.AsyncWaitHandle.WaitOne(7500))
        Utils.LogWarning("WARNING: ACTIVATE SESSION timed out. {0}/{1}", (object) this.GoodPublishRequestCount, (object) this.OutstandingRequestCount);
      byte[] serverNonce = (byte[]) null;
      StatusCodeCollection results = (StatusCodeCollection) null;
      DiagnosticInfoCollection diagnosticInfos = (DiagnosticInfoCollection) null;
      this.EndActivateSession(result, out serverNonce, out results, out diagnosticInfos);
      int num2 = 0;
      Utils.LogInfo("Session RECONNECT {0} completed successfully.", (object) this.SessionId);
      lock (this.SyncRoot)
      {
        this.m_previousServerNonce = this.m_serverNonce;
        this.m_serverNonce = serverNonce;
        num2 = this.GetMinPublishRequestCount(true);
      }
      this.m_reconnectLock.Wait();
      this.m_reconnecting = false;
      flag = false;
      this.m_reconnectLock.Release();
      for (int index = 0; index < num2; ++index)
        this.BeginPublish(this.OperationTimeout);
      this.StartKeepAliveTimer();
      this.IndicateSessionConfigurationChanged();
    }
    finally
    {
      if (flag)
      {
        this.m_reconnectLock.Wait();
        this.m_reconnecting = false;
        this.m_reconnectLock.Release();
      }
    }
  }

  public void Save(string filePath, IEnumerable<Type> knownTypes = null)
  {
    this.Save(filePath, this.Subscriptions, knownTypes);
  }

  public void Save(
    Stream stream,
    IEnumerable<Subscription> subscriptions,
    IEnumerable<Type> knownTypes = null)
  {
    SubscriptionCollection graph = new SubscriptionCollection(subscriptions);
    XmlWriterSettings settings = Utils.DefaultXmlWriterSettings();
    using (XmlWriter writer = XmlWriter.Create(stream, settings))
      new DataContractSerializer(typeof (SubscriptionCollection), knownTypes).WriteObject(writer, (object) graph);
  }

  public void Save(
    string filePath,
    IEnumerable<Subscription> subscriptions,
    IEnumerable<Type> knownTypes = null)
  {
    using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
      this.Save((Stream) fileStream, subscriptions, knownTypes);
  }

  public IEnumerable<Subscription> Load(
    Stream stream,
    bool transferSubscriptions = false,
    IEnumerable<Type> knownTypes = null)
  {
    XmlReaderSettings settings = Utils.DefaultXmlReaderSettings();
    settings.CloseInput = true;
    using (XmlReader reader = XmlReader.Create(stream, settings))
    {
      SubscriptionCollection subscriptionCollection = (SubscriptionCollection) new DataContractSerializer(typeof (SubscriptionCollection), knownTypes).ReadObject(reader);
      foreach (Subscription subscription in (List<Subscription>) subscriptionCollection)
      {
        if (!transferSubscriptions)
        {
          foreach (MonitoredItem monitoredItem in subscription.MonitoredItems)
            monitoredItem.ServerId = 0U;
        }
        this.AddSubscription(subscription);
      }
      return (IEnumerable<Subscription>) subscriptionCollection;
    }
  }

  public IEnumerable<Subscription> Load(
    string filePath,
    bool transferSubscriptions = false,
    IEnumerable<Type> knownTypes = null)
  {
    using (FileStream fileStream = File.OpenRead(filePath))
      return this.Load((Stream) fileStream, transferSubscriptions, knownTypes);
  }

  public void FetchNamespaceTables()
  {
    ReadValueIdCollection read = this.PrepareNamespaceTableNodesToRead();
    DataValueCollection results;
    DiagnosticInfoCollection diagnosticInfos;
    ResponseHeader responseHeader = this.Read((RequestHeader) null, 0.0, TimestampsToReturn.Neither, read, out results, out diagnosticInfos);
    ClientBase.ValidateResponse((IList) results, (IList) read);
    ClientBase.ValidateDiagnosticInfos(diagnosticInfos, (IList) read);
    this.UpdateNamespaceTable(results, diagnosticInfos, responseHeader);
  }

  public void FetchOperationLimits()
  {
    try
    {
      List<string> list = ((IEnumerable<PropertyInfo>) typeof (OperationLimits).GetProperties()).Select<PropertyInfo, string>((Func<PropertyInfo, string>) (p => p.Name)).ToList<string>();
      NodeIdCollection variableIds = new NodeIdCollection(list.Select<string, NodeId>((Func<string, NodeId>) (name => (NodeId) typeof (VariableIds).GetField("Server_ServerCapabilities_OperationLimits_" + name, BindingFlags.Static | BindingFlags.Public).GetValue((object) null))));
      List<object> values;
      List<ServiceResult> errors;
      this.ReadValues((IList<NodeId>) variableIds, (IList<Type>) Enumerable.Repeat<Type>(typeof (uint), variableIds.Count).ToList<Type>(), out values, out errors);
      ApplicationConfiguration configuration = this.m_configuration;
      OperationLimits operationLimits1;
      if (configuration == null)
      {
        operationLimits1 = (OperationLimits) null;
      }
      else
      {
        ClientConfiguration clientConfiguration = configuration.ClientConfiguration;
        if (clientConfiguration == null)
        {
          operationLimits1 = (OperationLimits) null;
        }
        else
        {
          operationLimits1 = clientConfiguration.OperationLimits;
          if (operationLimits1 != null)
            goto label_6;
        }
      }
      operationLimits1 = new OperationLimits();
label_6:
      OperationLimits operationLimits2 = operationLimits1;
      OperationLimits operationLimits3 = new OperationLimits();
      for (int index = 0; index < variableIds.Count; ++index)
      {
        PropertyInfo property = typeof (OperationLimits).GetProperty(list[index]);
        uint num1 = (uint) property.GetValue((object) operationLimits2);
        if (values[index] != null && ServiceResult.IsNotBad(errors[index]))
        {
          uint num2 = (uint) values[index];
          if (num2 > 0U && (num1 == 0U || num2 < num1))
            num1 = num2;
        }
        property.SetValue((object) operationLimits3, (object) num1);
      }
      this.OperationLimits = operationLimits3;
    }
    catch (Exception ex)
    {
      object[] objArray = Array.Empty<object>();
      Utils.LogError(ex, "Failed to read operation limits from server. Using configuration defaults.", objArray);
      OperationLimits operationLimits = this.m_configuration?.ClientConfiguration?.OperationLimits;
      if (operationLimits == null)
        return;
      this.OperationLimits = operationLimits;
    }
  }

  public void FetchTypeTree(ExpandedNodeId typeId)
  {
    if (!(this.NodeCache.Find(typeId) is Opc.Ua.Node node))
      return;
    ExpandedNodeIdCollection typeIds = new ExpandedNodeIdCollection();
    foreach (IReference reference in (IEnumerable<IReference>) node.Find(ReferenceTypeIds.HasSubtype, false))
      typeIds.Add(reference.TargetId);
    if (typeIds.Count <= 0)
      return;
    this.FetchTypeTree(typeIds);
  }

  public void FetchTypeTree(ExpandedNodeIdCollection typeIds)
  {
    NodeIdCollection nodeIdCollection = new NodeIdCollection();
    nodeIdCollection.Add(ReferenceTypeIds.HasSubtype);
    NodeIdCollection referenceTypeIds = nodeIdCollection;
    IList<INode> references = this.NodeCache.FindReferences((IList<ExpandedNodeId>) typeIds, (IList<NodeId>) referenceTypeIds, false, false);
    ExpandedNodeIdCollection typeIds1 = new ExpandedNodeIdCollection();
    foreach (INode node1 in (IEnumerable<INode>) references)
    {
      if (node1 is Opc.Ua.Node node2)
      {
        foreach (IReference reference in (IEnumerable<IReference>) node2.Find(ReferenceTypeIds.HasSubtype, false))
        {
          if (!typeIds.Contains(reference.TargetId))
            typeIds1.Add(reference.TargetId);
        }
      }
    }
    if (typeIds1.Count <= 0)
      return;
    this.FetchTypeTree(typeIds1);
  }

  public ReferenceDescriptionCollection ReadAvailableEncodings(NodeId variableId)
  {
    if (!(this.NodeCache.Find((ExpandedNodeId) variableId) is VariableNode variableNode))
      throw ServiceResultException.Create(2150825984U /*0x80330000*/, "NodeId does not refer to a valid variable node.");
    if (NodeId.IsNull(variableNode.DataType))
      return new ReferenceDescriptionCollection();
    if (!this.TypeTree.IsTypeOf(variableNode.DataType, (NodeId) 22U))
      return new ReferenceDescriptionCollection();
    IList<INode> nodeList = this.NodeCache.Find((ExpandedNodeId) variableId, ReferenceTypeIds.HasEncoding, false, true);
    if (nodeList.Count > 0)
    {
      ReferenceDescriptionCollection descriptionCollection = new ReferenceDescriptionCollection();
      foreach (INode node in (IEnumerable<INode>) nodeList)
        descriptionCollection.Add(new ReferenceDescription()
        {
          ReferenceTypeId = ReferenceTypeIds.HasEncoding,
          IsForward = true,
          NodeId = node.NodeId,
          NodeClass = node.NodeClass,
          BrowseName = node.BrowseName,
          DisplayName = node.DisplayName,
          TypeDefinition = node.TypeDefinitionId
        });
      return descriptionCollection;
    }
    return new Browser((ISession) this)
    {
      BrowseDirection = BrowseDirection.Forward,
      ReferenceTypeId = ReferenceTypeIds.HasEncoding,
      IncludeSubtypes = false,
      NodeClassMask = 0
    }.Browse(variableNode.DataType);
  }

  public ReferenceDescription FindDataDescription(NodeId encodingId)
  {
    ReferenceDescriptionCollection descriptionCollection = new Browser((ISession) this)
    {
      BrowseDirection = BrowseDirection.Forward,
      ReferenceTypeId = ReferenceTypeIds.HasDescription,
      IncludeSubtypes = false,
      NodeClassMask = 0
    }.Browse(encodingId);
    return descriptionCollection.Count != 0 ? descriptionCollection[0] : throw ServiceResultException.Create(2150825984U /*0x80330000*/, "Encoding does not refer to a valid data description.");
  }

  public async Task<DataDictionary> FindDataDictionary(NodeId descriptionId, CancellationToken ct = default (CancellationToken))
  {
    Session session = this;
    foreach (DataDictionary dataDictionary in session.m_dictionaries.Values)
    {
      if (dataDictionary.Contains(descriptionId))
        return dataDictionary;
    }
    // ISSUE: explicit non-virtual call
    IList<INode> nodeList = await __nonvirtual (session.NodeCache).FindReferencesAsync((ExpandedNodeId) descriptionId, ReferenceTypeIds.HasComponent, true, false, ct).ConfigureAwait(false);
    if (nodeList.Count == 0)
      throw ServiceResultException.Create(2150825984U /*0x80330000*/, "Description does not refer to a valid data dictionary.");
    NodeId nodeId = ExpandedNodeId.ToNodeId(nodeList[0].NodeId, session.m_namespaceUris);
    DataDictionary dataDictionary1 = new DataDictionary((ISession) session);
    dataDictionary1.Load(nodeList[0]);
    session.m_dictionaries[nodeId] = dataDictionary1;
    return dataDictionary1;
  }

  public DataDictionary LoadDataDictionary(ReferenceDescription dictionaryNode, bool forceReload = false)
  {
    NodeId nodeId = ExpandedNodeId.ToNodeId(dictionaryNode.NodeId, this.m_namespaceUris);
    DataDictionary dataDictionary1;
    if (!forceReload && this.m_dictionaries.TryGetValue(nodeId, out dataDictionary1))
      return dataDictionary1;
    DataDictionary dataDictionary2 = new DataDictionary((ISession) this);
    dataDictionary2.Load(nodeId, dictionaryNode.ToString());
    this.m_dictionaries[nodeId] = dataDictionary2;
    return dataDictionary2;
  }

  public async Task<Dictionary<NodeId, DataDictionary>> LoadDataTypeSystem(
    NodeId dataTypeSystem = null,
    CancellationToken ct = default (CancellationToken))
  {
    Session session = this;
    if (dataTypeSystem == (object) null)
      dataTypeSystem = ObjectIds.OPCBinarySchema_TypeSystem;
    else if (!Utils.IsEqual((object) dataTypeSystem, (object) ObjectIds.OPCBinarySchema_TypeSystem) && !Utils.IsEqual((object) dataTypeSystem, (object) ObjectIds.XmlSchema_TypeSystem))
      throw ServiceResultException.Create(2150825984U /*0x80330000*/, "dataTypeSystem does not refer to a valid data dictionary.");
    // ISSUE: explicit non-virtual call
    IList<INode> references = __nonvirtual (session.NodeCache).FindReferences((ExpandedNodeId) dataTypeSystem, ReferenceTypeIds.HasComponent, false, false);
    if (references.Count == 0)
      throw ServiceResultException.Create(2150825984U /*0x80330000*/, "Type system does not contain a valid data dictionary.");
    List<ExpandedNodeId> referenceNodeIds = references.Select<INode, ExpandedNodeId>((Func<INode, ExpandedNodeId>) (r => r.NodeId)).ToList<ExpandedNodeId>();
    // ISSUE: explicit non-virtual call
    INodeCache nodeCache = __nonvirtual (session.NodeCache);
    List<ExpandedNodeId> nodeIds = referenceNodeIds;
    NodeIdCollection referenceTypeIds = new NodeIdCollection();
    referenceTypeIds.Add(ReferenceTypeIds.HasProperty);
    // ISSUE: reference to a compiler-generated method
    List<NodeId> namespaceNodeIds = nodeCache.FindReferences((IList<ExpandedNodeId>) nodeIds, (IList<NodeId>) referenceTypeIds, false, false).Where<INode>((Func<INode, bool>) (n => n.BrowseName == (QualifiedName) "NamespaceUri")).ToList<INode>().Select<INode, NodeId>(new Func<INode, NodeId>(session.\u003CLoadDataTypeSystem\u003Eb__131_2)).ToList<NodeId>();
    // ISSUE: reference to a compiler-generated method
    List<NodeId> list = references.Select<INode, NodeId>(new Func<INode, NodeId>(session.\u003CLoadDataTypeSystem\u003Eb__131_3)).Where<NodeId>((Func<NodeId, bool>) (n => n.NamespaceIndex > (ushort) 0)).ToList<NodeId>();
    IDictionary<NodeId, byte[]> dictionary1 = await DataDictionary.ReadDictionaries((ISessionClientMethods) session, (IList<NodeId>) list, ct).ConfigureAwait(false);
    Dictionary<NodeId, string> dictionary2 = new Dictionary<NodeId, string>();
    List<object> values;
    List<ServiceResult> errors;
    // ISSUE: explicit non-virtual call
    __nonvirtual (session.ReadValues((IList<NodeId>) namespaceNodeIds, (IList<Type>) Enumerable.Repeat<Type>(typeof (string), namespaceNodeIds.Count).ToList<Type>(), out values, out errors));
    for (int index = 0; index < values.Count; ++index)
    {
      if (StatusCode.IsNotBad(errors[index].StatusCode))
      {
        if (values[index] != null)
          dictionary2[(NodeId) referenceNodeIds[index]] = (string) values[index];
      }
      else
        Utils.LogWarning("Failed to load namespace {0}: {1}", (object) namespaceNodeIds[index], (object) errors[index]);
    }
    Dictionary<string, byte[]> imports = new Dictionary<string, byte[]>();
    foreach (INode node in (IEnumerable<INode>) references)
    {
      // ISSUE: explicit non-virtual call
      NodeId nodeId = ExpandedNodeId.ToNodeId(node.NodeId, __nonvirtual (session.NamespaceUris));
      byte[] numArray;
      string key;
      if (dictionary1.TryGetValue(nodeId, out numArray) && dictionary2.TryGetValue(nodeId, out key))
        imports[key] = numArray;
    }
    foreach (INode node in (IEnumerable<INode>) references)
    {
      DataDictionary dataDictionary1 = (DataDictionary) null;
      NodeId nodeId = ExpandedNodeId.ToNodeId(node.NodeId, session.m_namespaceUris);
      if (nodeId.NamespaceIndex != (ushort) 0)
      {
        if (!session.m_dictionaries.TryGetValue(nodeId, out dataDictionary1))
        {
          try
          {
            DataDictionary dataDictionary2 = new DataDictionary((ISession) session);
            byte[] schema;
            if (dictionary1.TryGetValue(nodeId, out schema))
              dataDictionary2.Load(nodeId, nodeId.ToString(), schema, (IDictionary<string, byte[]>) imports);
            else
              dataDictionary2.Load(nodeId, nodeId.ToString());
            session.m_dictionaries[nodeId] = dataDictionary2;
          }
          catch (Exception ex)
          {
            Utils.LogError("Dictionary load error for Dictionary {0} : {1}", (object) node.NodeId, (object) ex.Message);
          }
        }
      }
    }
    Dictionary<NodeId, DataDictionary> dictionaries = session.m_dictionaries;
    references = (IList<INode>) null;
    referenceNodeIds = (List<ExpandedNodeId>) null;
    namespaceNodeIds = (List<NodeId>) null;
    return dictionaries;
  }

  public void ReadNodes(
    IList<NodeId> nodeIds,
    NodeClass nodeClass,
    out IList<Opc.Ua.Node> nodeCollection,
    out IList<ServiceResult> errors,
    bool optionalAttributes = false)
  {
    if (nodeIds.Count == 0)
    {
      nodeCollection = (IList<Opc.Ua.Node>) new NodeCollection();
      errors = (IList<ServiceResult>) new List<ServiceResult>();
    }
    else if (nodeClass == NodeClass.Unspecified)
    {
      this.ReadNodes(nodeIds, out nodeCollection, out errors, optionalAttributes);
    }
    else
    {
      List<IDictionary<uint, DataValue>> attributesPerNodeId = new List<IDictionary<uint, DataValue>>(nodeIds.Count);
      ReadValueIdCollection valueIdCollection = new ReadValueIdCollection();
      nodeCollection = (IList<Opc.Ua.Node>) new NodeCollection(nodeIds.Count);
      this.CreateNodeClassAttributesReadNodesRequest(nodeIds, nodeClass, valueIdCollection, (IList<IDictionary<uint, DataValue>>) attributesPerNodeId, nodeCollection, optionalAttributes);
      DataValueCollection results;
      DiagnosticInfoCollection diagnosticInfos;
      ResponseHeader responseHeader = this.Read((RequestHeader) null, 0.0, TimestampsToReturn.Neither, valueIdCollection, out results, out diagnosticInfos);
      ClientBase.ValidateResponse((IList) results, (IList) valueIdCollection);
      ClientBase.ValidateDiagnosticInfos(diagnosticInfos, (IList) valueIdCollection);
      errors = (IList<ServiceResult>) ((IEnumerable<ServiceResult>) new ServiceResult[nodeIds.Count]).ToList<ServiceResult>();
      this.ProcessAttributesReadNodesResponse(responseHeader, valueIdCollection, (IList<IDictionary<uint, DataValue>>) attributesPerNodeId, results, diagnosticInfos, nodeCollection, errors);
    }
  }

  public void ReadNodes(
    IList<NodeId> nodeIds,
    out IList<Opc.Ua.Node> nodeCollection,
    out IList<ServiceResult> errors,
    bool optionalAttributes = false)
  {
    int count = nodeIds.Count;
    nodeCollection = (IList<Opc.Ua.Node>) new NodeCollection(count);
    errors = (IList<ServiceResult>) new List<ServiceResult>(count);
    if (count == 0)
      return;
    ReadValueIdCollection valueIdCollection1 = new ReadValueIdCollection(nodeIds.Select<NodeId, ReadValueId>((Func<NodeId, ReadValueId>) (nodeId => new ReadValueId()
    {
      NodeId = nodeId,
      AttributeId = 2U
    })));
    DataValueCollection results1 = (DataValueCollection) null;
    DiagnosticInfoCollection diagnosticInfos = (DiagnosticInfoCollection) null;
    ResponseHeader responseHeader1 = (ResponseHeader) null;
    if (count > 1)
    {
      responseHeader1 = this.Read((RequestHeader) null, 0.0, TimestampsToReturn.Neither, valueIdCollection1, out results1, out diagnosticInfos);
      ClientBase.ValidateResponse((IList) results1, (IList) valueIdCollection1);
      ClientBase.ValidateDiagnosticInfos(diagnosticInfos, (IList) valueIdCollection1);
    }
    else
    {
      DataValueCollection dataValueCollection = new DataValueCollection();
      dataValueCollection.Add(new DataValue(new Opc.Ua.Variant(0), (StatusCode) 0U));
      results1 = dataValueCollection;
    }
    List<IDictionary<uint, DataValue>> attributesPerNodeId = new List<IDictionary<uint, DataValue>>(count);
    ReadValueIdCollection valueIdCollection2 = new ReadValueIdCollection();
    this.CreateAttributesReadNodesRequest(responseHeader1, valueIdCollection1, results1, diagnosticInfos, valueIdCollection2, (IList<IDictionary<uint, DataValue>>) attributesPerNodeId, nodeCollection, errors, optionalAttributes);
    if (valueIdCollection2.Count <= 0)
      return;
    DataValueCollection results2;
    ResponseHeader responseHeader2 = this.Read((RequestHeader) null, 0.0, TimestampsToReturn.Neither, valueIdCollection2, out results2, out diagnosticInfos);
    ClientBase.ValidateResponse((IList) results2, (IList) valueIdCollection2);
    ClientBase.ValidateDiagnosticInfos(diagnosticInfos, (IList) valueIdCollection2);
    this.ProcessAttributesReadNodesResponse(responseHeader2, valueIdCollection2, (IList<IDictionary<uint, DataValue>>) attributesPerNodeId, results2, diagnosticInfos, nodeCollection, errors);
  }

  public Opc.Ua.Node ReadNode(NodeId nodeId) => this.ReadNode(nodeId, NodeClass.Unspecified, true);

  public Opc.Ua.Node ReadNode(NodeId nodeId, NodeClass nodeClass, bool optionalAttributes = true)
  {
    IDictionary<uint, DataValue> attributes = this.CreateAttributes(nodeClass, optionalAttributes);
    ReadValueIdCollection valueIdCollection = new ReadValueIdCollection();
    foreach (uint key in (IEnumerable<uint>) attributes.Keys)
    {
      ReadValueId readValueId = new ReadValueId()
      {
        NodeId = nodeId,
        AttributeId = key
      };
      valueIdCollection.Add(readValueId);
    }
    DataValueCollection results = (DataValueCollection) null;
    DiagnosticInfoCollection diagnosticInfos = (DiagnosticInfoCollection) null;
    ResponseHeader responseHeader = this.Read((RequestHeader) null, 0.0, TimestampsToReturn.Neither, valueIdCollection, out results, out diagnosticInfos);
    ClientBase.ValidateResponse((IList) results, (IList) valueIdCollection);
    ClientBase.ValidateDiagnosticInfos(diagnosticInfos, (IList) valueIdCollection);
    return this.ProcessReadResponse(responseHeader, attributes, valueIdCollection, results, diagnosticInfos);
  }

  public DataValue ReadValue(NodeId nodeId)
  {
    ReadValueId readValueId = new ReadValueId()
    {
      NodeId = nodeId,
      AttributeId = 13
    };
    ReadValueIdCollection valueIdCollection1 = new ReadValueIdCollection();
    valueIdCollection1.Add(readValueId);
    ReadValueIdCollection valueIdCollection2 = valueIdCollection1;
    DataValueCollection results = (DataValueCollection) null;
    DiagnosticInfoCollection diagnosticInfos = (DiagnosticInfoCollection) null;
    ResponseHeader responseHeader = this.Read((RequestHeader) null, 0.0, TimestampsToReturn.Both, valueIdCollection2, out results, out diagnosticInfos);
    ClientBase.ValidateResponse((IList) results, (IList) valueIdCollection2);
    ClientBase.ValidateDiagnosticInfos(diagnosticInfos, (IList) valueIdCollection2);
    return !StatusCode.IsBad(results[0].StatusCode) ? results[0] : throw new ServiceResultException(ClientBase.GetResult(results[0].StatusCode, 0, diagnosticInfos, responseHeader));
  }

  public void ReadValues(
    IList<NodeId> nodeIds,
    out DataValueCollection values,
    out IList<ServiceResult> errors)
  {
    if (nodeIds.Count == 0)
    {
      values = new DataValueCollection();
      errors = (IList<ServiceResult>) new List<ServiceResult>();
    }
    else
    {
      ReadValueIdCollection valueIdCollection = new ReadValueIdCollection(nodeIds.Select<NodeId, ReadValueId>((Func<NodeId, ReadValueId>) (nodeId => new ReadValueId()
      {
        NodeId = nodeId,
        AttributeId = 13U
      })));
      errors = (IList<ServiceResult>) new List<ServiceResult>(valueIdCollection.Count);
      DiagnosticInfoCollection diagnosticInfos;
      ResponseHeader responseHeader = this.Read((RequestHeader) null, 0.0, TimestampsToReturn.Both, valueIdCollection, out values, out diagnosticInfos);
      ClientBase.ValidateResponse((IList) values, (IList) valueIdCollection);
      ClientBase.ValidateDiagnosticInfos(diagnosticInfos, (IList) valueIdCollection);
      int index = 0;
      foreach (DataValue dataValue in (List<DataValue>) values)
      {
        ServiceResult serviceResult = ServiceResult.Good;
        if (StatusCode.IsNotGood(dataValue.StatusCode))
          serviceResult = ClientBase.GetResult(dataValue.StatusCode, index, diagnosticInfos, responseHeader);
        errors.Add(serviceResult);
        ++index;
      }
    }
  }

  public object ReadValue(NodeId nodeId, Type expectedType)
  {
    object body = this.ReadValue(nodeId).Value;
    if (expectedType != (Type) null)
    {
      if (body is ExtensionObject extensionObject)
        body = extensionObject.Body;
      if (!expectedType.IsInstanceOfType(body))
        throw ServiceResultException.Create(2155085824U /*0x80740000*/, "Server returned value unexpected type: {0}", body != null ? (object) body.GetType().Name : (object) "(null)");
    }
    return body;
  }

  public ReferenceDescriptionCollection FetchReferences(NodeId nodeId)
  {
    byte[] continuationPoint;
    ReferenceDescriptionCollection references1;
    this.Browse((RequestHeader) null, (ViewDescription) null, nodeId, 0U, BrowseDirection.Both, (NodeId) null, true, 0U, out continuationPoint, out references1);
    while (continuationPoint != null)
    {
      byte[] revisedContinuationPoint;
      ReferenceDescriptionCollection references2;
      this.BrowseNext((RequestHeader) null, false, continuationPoint, out revisedContinuationPoint, out references2);
      continuationPoint = revisedContinuationPoint;
      references1.AddRange((IEnumerable<ReferenceDescription>) references2);
    }
    return references1;
  }

  public void FetchReferences(
    IList<NodeId> nodeIds,
    out IList<ReferenceDescriptionCollection> referenceDescriptions,
    out IList<ServiceResult> errors)
  {
    List<ReferenceDescriptionCollection> descriptionCollectionList1 = new List<ReferenceDescriptionCollection>();
    ByteStringCollection continuationPoints1;
    IList<ReferenceDescriptionCollection> referencesList;
    this.Browse((RequestHeader) null, (ViewDescription) null, nodeIds, 0U, BrowseDirection.Both, (NodeId) null, true, 0U, out continuationPoints1, out referencesList, out errors);
    descriptionCollectionList1.AddRange((IEnumerable<ReferenceDescriptionCollection>) referencesList);
    List<ReferenceDescriptionCollection> descriptionCollectionList2 = descriptionCollectionList1;
    IList<ServiceResult> serviceResultList1 = errors;
    while (this.HasAnyContinuationPoint(continuationPoints1))
    {
      ByteStringCollection continuationPoints2 = new ByteStringCollection();
      List<ReferenceDescriptionCollection> descriptionCollectionList3 = new List<ReferenceDescriptionCollection>();
      List<ServiceResult> serviceResultList2 = new List<ServiceResult>();
      for (int index = 0; index < continuationPoints1.Count; ++index)
      {
        byte[] numArray = continuationPoints1[index];
        if (numArray != null)
        {
          continuationPoints2.Add(numArray);
          descriptionCollectionList3.Add(descriptionCollectionList2[index]);
          serviceResultList2.Add(serviceResultList1[index]);
        }
      }
      ByteStringCollection revisedContinuationPoints;
      IList<ServiceResult> errors1;
      this.BrowseNext((RequestHeader) null, false, continuationPoints2, out revisedContinuationPoints, out referencesList, out errors1);
      continuationPoints1 = revisedContinuationPoints;
      descriptionCollectionList2 = descriptionCollectionList3;
      serviceResultList1 = (IList<ServiceResult>) serviceResultList2;
      for (int index = 0; index < referencesList.Count; ++index)
      {
        descriptionCollectionList3[index].AddRange((IEnumerable<ReferenceDescription>) referencesList[index]);
        if (StatusCode.IsBad(errors1[index].StatusCode))
          serviceResultList2[index] = errors1[index];
      }
    }
    referenceDescriptions = (IList<ReferenceDescriptionCollection>) descriptionCollectionList1;
  }

  public void Open(string sessionName, IUserIdentity identity)
  {
    this.Open(sessionName, 0U, identity, (IList<string>) null);
  }

  public void Open(
    string sessionName,
    uint sessionTimeout,
    IUserIdentity identity,
    IList<string> preferredLocales)
  {
    this.Open(sessionName, sessionTimeout, identity, preferredLocales, true);
  }

  public void Open(
    string sessionName,
    uint sessionTimeout,
    IUserIdentity identity,
    IList<string> preferredLocales,
    bool checkDomain)
  {
    UserIdentityToken identityToken;
    UserTokenPolicy identityPolicy;
    string securityPolicyUri1;
    bool requireEncryption;
    this.OpenValidateIdentity(ref identity, out identityToken, out identityPolicy, out securityPolicyUri1, out requireEncryption);
    X509Certificate2 x509Certificate2 = (X509Certificate2) null;
    byte[] serverCertificate1 = this.m_endpoint.Description.ServerCertificate;
    if (serverCertificate1 != null && serverCertificate1.Length != 0)
    {
      X509Certificate2Collection certificateChainBlob = Utils.ParseCertificateChainBlob(serverCertificate1);
      if (certificateChainBlob.Count > 0)
        x509Certificate2 = certificateChainBlob[0];
      if (requireEncryption)
      {
        if (checkDomain)
          this.m_configuration.CertificateValidator.Validate(certificateChainBlob, this.m_endpoint);
        else
          this.m_configuration.CertificateValidator.Validate(certificateChainBlob);
        this.m_checkDomain = checkDomain;
      }
    }
    byte[] nonce = Utils.Nonce.CreateNonce((uint) this.m_configuration.SecurityConfiguration.NonceLength);
    NodeId sessionId = (NodeId) null;
    NodeId authenticationToken = (NodeId) null;
    byte[] serverNonce = Array.Empty<byte>();
    byte[] serverCertificate2 = Array.Empty<byte>();
    SignatureData serverSignature = (SignatureData) null;
    EndpointDescriptionCollection serverEndpoints = (EndpointDescriptionCollection) null;
    SignedSoftwareCertificateCollection serverSoftwareCertificates = (SignedSoftwareCertificateCollection) null;
    byte[] clientCertificateData;
    byte[] clientCertificateChainData;
    this.BuildCertificateData(out clientCertificateData, out clientCertificateChainData);
    ApplicationDescription clientDescription = new ApplicationDescription()
    {
      ApplicationUri = this.m_configuration.ApplicationUri,
      ApplicationName = (LocalizedText) this.m_configuration.ApplicationName,
      ApplicationType = ApplicationType.Client,
      ProductUri = this.m_configuration.ProductUri
    };
    if (sessionTimeout == 0U)
      sessionTimeout = (uint) this.m_configuration.ClientConfiguration.DefaultSessionTimeout;
    bool flag = false;
    if (this.m_endpoint.Description.SecurityPolicyUri == "http://opcfoundation.org/UA/SecurityPolicy#None")
    {
      try
      {
        base.CreateSession((RequestHeader) null, clientDescription, this.m_endpoint.Description.Server.ApplicationUri, this.m_endpoint.EndpointUrl.ToString(), sessionName, nonce, (byte[]) null, (double) sessionTimeout, (uint) this.MessageContext.MaxMessageSize, out sessionId, out authenticationToken, out this.m_sessionTimeout, out serverNonce, out serverCertificate2, out serverEndpoints, out serverSoftwareCertificates, out serverSignature, out this.m_maxRequestMessageSize);
        flag = true;
      }
      catch (Exception ex)
      {
        Utils.LogInfo("Create session failed with client certificate NULL. " + ex.Message);
        flag = false;
      }
    }
    if (!flag)
      base.CreateSession((RequestHeader) null, clientDescription, this.m_endpoint.Description.Server.ApplicationUri, this.m_endpoint.EndpointUrl.ToString(), sessionName, nonce, clientCertificateChainData ?? clientCertificateData, (double) sessionTimeout, (uint) this.MessageContext.MaxMessageSize, out sessionId, out authenticationToken, out this.m_sessionTimeout, out serverNonce, out serverCertificate2, out serverEndpoints, out serverSoftwareCertificates, out serverSignature, out this.m_maxRequestMessageSize);
    lock (this.SyncRoot)
      this.SessionCreated(sessionId, authenticationToken);
    Utils.LogInfo("Revised session timeout value: {0}. ", (object) this.m_sessionTimeout);
    Utils.LogInfo("Max response message size value: {0}. Max request message size: {1} ", (object) this.MessageContext.MaxMessageSize, (object) this.m_maxRequestMessageSize);
    try
    {
      this.ValidateServerCertificateData(serverCertificate2);
      this.ValidateServerEndpoints(serverEndpoints);
      this.ValidateServerSignature(x509Certificate2, serverSignature, clientCertificateData, clientCertificateChainData, nonce);
      this.HandleSignedSoftwareCertificates(serverSoftwareCertificates);
      byte[] dataToSign = Utils.Append(x509Certificate2?.RawData, serverNonce);
      SignatureData clientSignature = SecurityPolicies.Sign(this.m_instanceCertificate, securityPolicyUri1, dataToSign);
      string securityPolicyUri2 = identityPolicy.SecurityPolicyUri;
      if (string.IsNullOrEmpty(securityPolicyUri2))
        securityPolicyUri2 = this.m_endpoint.Description.SecurityPolicyUri;
      byte[] previousServerNonce = (byte[]) null;
      if (this.TransportChannel.CurrentToken != null)
        previousServerNonce = this.TransportChannel.CurrentToken.ServerNonce;
      this.ValidateServerNonce(identity, serverNonce, securityPolicyUri2, previousServerNonce, this.m_endpoint.Description.SecurityMode);
      SignatureData userTokenSignature = identityToken.Sign(dataToSign, securityPolicyUri2);
      identityToken.Encrypt(x509Certificate2, serverNonce, securityPolicyUri2);
      SignedSoftwareCertificateCollection softwareCertificates = this.GetSoftwareCertificates();
      if (preferredLocales != null && preferredLocales.Count > 0)
        this.m_preferredLocales = new StringCollection((IEnumerable<string>) preferredLocales);
      StatusCodeCollection results = (StatusCodeCollection) null;
      DiagnosticInfoCollection diagnosticInfos = (DiagnosticInfoCollection) null;
      this.ActivateSession((RequestHeader) null, clientSignature, softwareCertificates, this.m_preferredLocales, new ExtensionObject((object) identityToken), userTokenSignature, out serverNonce, out results, out diagnosticInfos);
      if (results != null)
      {
        for (int index = 0; index < results.Count; ++index)
          Utils.LogInfo("ActivateSession result[{0}] = {1}", (object) index, (object) results[index]);
      }
      if (results == null || results.Count == 0)
        Utils.LogInfo("Empty results were received for the ActivateSession call.");
      this.FetchNamespaceTables();
      lock (this.SyncRoot)
      {
        this.m_sessionName = sessionName;
        this.m_identity = identity;
        this.m_previousServerNonce = previousServerNonce;
        this.m_serverNonce = serverNonce;
        this.m_serverCertificate = x509Certificate2;
        this.m_systemContext.PreferredLocales = (IList<string>) this.m_preferredLocales;
        this.m_systemContext.SessionId = this.SessionId;
        this.m_systemContext.UserIdentity = identity;
      }
      this.FetchOperationLimits();
      this.StartKeepAliveTimer();
      this.IndicateSessionConfigurationChanged();
    }
    catch (Exception ex1)
    {
      try
      {
        this.CloseSession((RequestHeader) null, false);
        this.CloseChannel();
      }
      catch (Exception ex2)
      {
        Utils.LogError("Cleanup: CloseSession() or CloseChannel() raised exception. " + ex2.Message);
      }
      finally
      {
        this.SessionCreated((NodeId) null, (NodeId) null);
      }
      throw;
    }
  }

  public void ChangePreferredLocales(StringCollection preferredLocales)
  {
    this.UpdateSession(this.Identity, preferredLocales);
  }

  public void UpdateSession(IUserIdentity identity, StringCollection preferredLocales)
  {
    byte[] serverNonce = (byte[]) null;
    lock (this.SyncRoot)
    {
      if (!this.Connected)
        throw new ServiceResultException(2158952448U /*0x80AF0000*/, "Not connected to server.");
      serverNonce = this.m_serverNonce;
      if (preferredLocales == null)
        preferredLocales = this.m_preferredLocales;
    }
    string securityPolicyUri1 = this.m_endpoint.Description.SecurityPolicyUri;
    byte[] dataToSign = Utils.Append(this.m_serverCertificate != null ? this.m_serverCertificate.RawData : (byte[]) null, serverNonce);
    SignatureData clientSignature = SecurityPolicies.Sign(this.m_instanceCertificate, securityPolicyUri1, dataToSign);
    if (identity == null)
      identity = (IUserIdentity) new UserIdentity();
    UserTokenPolicy userTokenPolicy = this.m_endpoint.Description.FindUserTokenPolicy(identity.TokenType, identity.IssuedTokenType);
    string securityPolicyUri2 = userTokenPolicy != null ? userTokenPolicy.SecurityPolicyUri : throw ServiceResultException.Create(2149515264U /*0x801F0000*/, "Endpoint does not support the user identity type provided.");
    if (string.IsNullOrEmpty(securityPolicyUri2))
      securityPolicyUri2 = this.m_endpoint.Description.SecurityPolicyUri;
    if (this.m_serverCertificate != null & securityPolicyUri2 != "http://opcfoundation.org/UA/SecurityPolicy#None" && identity.TokenType != UserTokenType.Anonymous)
      this.m_configuration.CertificateValidator.Validate(this.m_serverCertificate);
    this.ValidateServerNonce(identity, serverNonce, securityPolicyUri2, this.m_previousServerNonce, this.m_endpoint.Description.SecurityMode);
    UserIdentityToken identityToken = identity.GetIdentityToken();
    identityToken.PolicyId = userTokenPolicy.PolicyId;
    SignatureData userTokenSignature = identityToken.Sign(dataToSign, securityPolicyUri2);
    identityToken.Encrypt(this.m_serverCertificate, serverNonce, securityPolicyUri2);
    SignedSoftwareCertificateCollection softwareCertificates = this.GetSoftwareCertificates();
    StatusCodeCollection results = (StatusCodeCollection) null;
    DiagnosticInfoCollection diagnosticInfos = (DiagnosticInfoCollection) null;
    this.ActivateSession((RequestHeader) null, clientSignature, softwareCertificates, preferredLocales, new ExtensionObject((object) identityToken), userTokenSignature, out serverNonce, out results, out diagnosticInfos);
    lock (this.SyncRoot)
    {
      if (identity != null)
        this.m_identity = identity;
      this.m_previousServerNonce = this.m_serverNonce;
      this.m_serverNonce = serverNonce;
      this.m_preferredLocales = preferredLocales;
      this.m_systemContext.PreferredLocales = (IList<string>) this.m_preferredLocales;
      this.m_systemContext.SessionId = this.SessionId;
      this.m_systemContext.UserIdentity = identity;
    }
    this.IndicateSessionConfigurationChanged();
  }

  public void FindComponentIds(
    NodeId instanceId,
    IList<string> componentPaths,
    out NodeIdCollection componentIds,
    out List<ServiceResult> errors)
  {
    componentIds = new NodeIdCollection();
    errors = new List<ServiceResult>();
    BrowsePathCollection browsePathCollection = new BrowsePathCollection();
    for (int index = 0; index < componentPaths.Count; ++index)
      browsePathCollection.Add(new BrowsePath()
      {
        StartingNode = instanceId,
        RelativePath = RelativePath.Parse(componentPaths[index], this.TypeTree)
      });
    BrowsePathResultCollection results = (BrowsePathResultCollection) null;
    DiagnosticInfoCollection diagnosticInfos = (DiagnosticInfoCollection) null;
    ResponseHeader nodeIds = this.TranslateBrowsePathsToNodeIds((RequestHeader) null, browsePathCollection, out results, out diagnosticInfos);
    ClientBase.ValidateResponse((IList) results, (IList) browsePathCollection);
    ClientBase.ValidateDiagnosticInfos(diagnosticInfos, (IList) browsePathCollection);
    for (int index = 0; index < componentPaths.Count; ++index)
    {
      componentIds.Add(NodeId.Null);
      errors.Add(ServiceResult.Good);
      if (StatusCode.IsBad(results[index].StatusCode))
        errors[index] = new ServiceResult(results[index].StatusCode, index, diagnosticInfos, (IList<string>) nodeIds.StringTable);
      else if (results[index].Targets.Count == 0)
        errors[index] = ServiceResult.Create(2154102784U /*0x80650000*/, "Could not find target for path: {0}.", (object) componentPaths[index]);
      else if (results[index].Targets.Count != 1)
        errors[index] = ServiceResult.Create(2154627072U /*0x806D0000*/, "Too many matches found for path: {0}.", (object) componentPaths[index]);
      else if (results[index].Targets[0].RemainingPathIndex != uint.MaxValue)
        errors[index] = ServiceResult.Create(2154102784U /*0x80650000*/, "Cannot follow path to external server: {0}.", (object) componentPaths[index]);
      else if (NodeId.IsNull(results[index].Targets[0].TargetId))
        errors[index] = ServiceResult.Create(2147549184U /*0x80010000*/, "Server returned a null NodeId for path: {0}.", (object) componentPaths[index]);
      else if (results[index].Targets[0].TargetId.IsAbsolute)
        errors[index] = ServiceResult.Create(2147549184U /*0x80010000*/, "Server returned a remote node for path: {0}.", (object) componentPaths[index]);
      else
        componentIds[index] = ExpandedNodeId.ToNodeId(results[index].Targets[0].TargetId, this.m_namespaceUris);
    }
  }

  public void ReadValues(
    IList<NodeId> variableIds,
    IList<Type> expectedTypes,
    out List<object> values,
    out List<ServiceResult> errors)
  {
    values = new List<object>();
    errors = new List<ServiceResult>();
    ReadValueIdCollection valueIdCollection = new ReadValueIdCollection();
    for (int index = 0; index < variableIds.Count; ++index)
      valueIdCollection.Add(new ReadValueId()
      {
        NodeId = variableIds[index],
        AttributeId = 13U,
        IndexRange = (string) null,
        DataEncoding = (QualifiedName) null
      });
    DataValueCollection results = (DataValueCollection) null;
    DiagnosticInfoCollection diagnosticInfos = (DiagnosticInfoCollection) null;
    ResponseHeader responseHeader = this.Read((RequestHeader) null, 0.0, TimestampsToReturn.Both, valueIdCollection, out results, out diagnosticInfos);
    ClientBase.ValidateResponse((IList) results, (IList) valueIdCollection);
    ClientBase.ValidateDiagnosticInfos(diagnosticInfos, (IList) valueIdCollection);
    for (int index = 0; index < variableIds.Count; ++index)
    {
      values.Add((object) null);
      errors.Add(ServiceResult.Good);
      if (StatusCode.IsNotGood(results[index].StatusCode))
      {
        errors[index] = new ServiceResult(results[index].StatusCode, index, diagnosticInfos, (IList<string>) responseHeader.StringTable);
        if (StatusCode.IsBad(results[index].StatusCode))
          continue;
      }
      object body = results[index].Value;
      if (body is ExtensionObject extensionObject && extensionObject.Body is IEncodeable)
        body = extensionObject.Body;
      if (expectedTypes[index] != (Type) null && !expectedTypes[index].IsInstanceOfType(body))
        errors[index] = ServiceResult.Create(2155085824U /*0x80740000*/, "Value {0} does not have expected type: {1}.", body, (object) expectedTypes[index].Name);
      else
        values[index] = body;
    }
  }

  public void ReadDisplayName(
    IList<NodeId> nodeIds,
    out IList<string> displayNames,
    out IList<ServiceResult> errors)
  {
    displayNames = (IList<string>) new List<string>();
    errors = (IList<ServiceResult>) new List<ServiceResult>();
    ReadValueIdCollection valueIdCollection = new ReadValueIdCollection();
    for (int index = 0; index < nodeIds.Count; ++index)
      valueIdCollection.Add(new ReadValueId()
      {
        NodeId = nodeIds[index],
        AttributeId = 4U,
        IndexRange = (string) null,
        DataEncoding = (QualifiedName) null
      });
    DataValueCollection results = (DataValueCollection) null;
    DiagnosticInfoCollection diagnosticInfos = (DiagnosticInfoCollection) null;
    ResponseHeader responseHeader = this.Read((RequestHeader) null, (double) int.MaxValue, TimestampsToReturn.Neither, valueIdCollection, out results, out diagnosticInfos);
    ClientBase.ValidateResponse((IList) results, (IList) valueIdCollection);
    ClientBase.ValidateDiagnosticInfos(diagnosticInfos, (IList) valueIdCollection);
    for (int index = 0; index < nodeIds.Count; ++index)
    {
      displayNames.Add(string.Empty);
      errors.Add(ServiceResult.Good);
      if (StatusCode.IsNotGood(results[index].StatusCode))
      {
        errors[index] = new ServiceResult(results[index].StatusCode, index, diagnosticInfos, (IList<string>) responseHeader.StringTable);
      }
      else
      {
        LocalizedText localizedText = results[index].GetValue<LocalizedText>((LocalizedText) null);
        if (!LocalizedText.IsNullOrEmpty(localizedText))
          displayNames[index] = localizedText.Text;
      }
    }
  }

  public override bool Equals(object obj)
  {
    return this == obj || obj is ISession session && this.m_endpoint.Equals((object) session.Endpoint) && this.m_sessionName.Equals(session.SessionName, StringComparison.Ordinal) && this.SessionId.Equals(session.SessionId);
  }

  public override int GetHashCode()
  {
    return HashCode.Combine<ConfiguredEndpoint, string, NodeId>(this.m_endpoint, this.m_sessionName, this.SessionId);
  }

  public virtual Session CloneSession(ITransportChannel channel, bool copyEventHandlers)
  {
    return new Session(channel, this, copyEventHandlers);
  }

  public override StatusCode Close() => this.Close(this.m_keepAliveInterval, true);

  public StatusCode Close(bool closeChannel) => this.Close(this.m_keepAliveInterval, closeChannel);

  public StatusCode Close(int timeout) => this.Close(timeout, true);

  public virtual StatusCode Close(int timeout, bool closeChannel)
  {
    if (this.Disposed)
      return (StatusCode) 0U;
    StatusCode statusCode = (StatusCode) 0U;
    this.StopKeepAliveTimer();
    bool connected;
    if (connected = this.Connected)
    {
      if (this.m_SessionClosing != null)
      {
        try
        {
          this.m_SessionClosing((object) this, (EventArgs) null);
        }
        catch (Exception ex)
        {
          object[] objArray = Array.Empty<object>();
          Utils.LogError(ex, "Session: Unexpected eror raising SessionClosing event.", objArray);
        }
      }
    }
    if (connected && !this.KeepAliveStopped)
    {
      int operationTimeout = this.OperationTimeout;
      try
      {
        this.OperationTimeout = timeout;
        this.CloseSession((RequestHeader) null, this.m_deleteSubscriptionsOnClose);
        this.OperationTimeout = operationTimeout;
        if (closeChannel)
          this.CloseChannel();
        this.SessionCreated((NodeId) null, (NodeId) null);
      }
      catch (Exception ex)
      {
        statusCode = !(ex is ServiceResultException serviceResultException) ? (StatusCode) 2147483648U /*0x80000000*/ : (StatusCode) serviceResultException.StatusCode;
        Utils.LogError("Session close error: " + statusCode.ToString());
      }
    }
    if (closeChannel)
      this.Dispose();
    return statusCode;
  }

  public bool AddSubscription(Subscription subscription)
  {
    if (subscription == null)
      throw new ArgumentNullException(nameof (subscription));
    lock (this.SyncRoot)
    {
      if (this.m_subscriptions.Contains(subscription))
        return false;
      subscription.Session = (ISession) this;
      this.m_subscriptions.Add(subscription);
    }
    if (this.m_SubscriptionsChanged != null)
      this.m_SubscriptionsChanged((object) this, (EventArgs) null);
    return true;
  }

  public bool RemoveSubscription(Subscription subscription)
  {
    if (subscription == null)
      throw new ArgumentNullException(nameof (subscription));
    if (subscription.Created)
      subscription.Delete(false);
    lock (this.SyncRoot)
    {
      if (!this.m_subscriptions.Remove(subscription))
        return false;
      subscription.Session = (ISession) null;
    }
    if (this.m_SubscriptionsChanged != null)
      this.m_SubscriptionsChanged((object) this, (EventArgs) null);
    return true;
  }

  public bool RemoveSubscriptions(IEnumerable<Subscription> subscriptions)
  {
    if (subscriptions == null)
      throw new ArgumentNullException(nameof (subscriptions));
    List<Subscription> subscriptionsToDelete = new List<Subscription>();
    bool delete = this.PrepareSubscriptionsToDelete(subscriptions, (IList<Subscription>) subscriptionsToDelete);
    foreach (Subscription subscription in subscriptionsToDelete)
      subscription.Delete(true);
    if (delete && this.m_SubscriptionsChanged != null)
      this.m_SubscriptionsChanged((object) this, (EventArgs) null);
    return delete;
  }

  public bool RemoveTransferredSubscription(Subscription subscription)
  {
    if (subscription == null)
      throw new ArgumentNullException(nameof (subscription));
    if (subscription.Session != this)
      return false;
    lock (this.SyncRoot)
    {
      if (!this.m_subscriptions.Remove(subscription))
        return false;
      subscription.Session = (ISession) null;
    }
    if (this.m_SubscriptionsChanged != null)
      this.m_SubscriptionsChanged((object) this, (EventArgs) null);
    return true;
  }

  public bool ReactivateSubscriptions(SubscriptionCollection subscriptions, bool sendInitialValues)
  {
    int num = 0;
    UInt32Collection subscriptionIdsForTransfer = this.CreateSubscriptionIdsForTransfer(subscriptions);
    if (subscriptionIdsForTransfer.Count > 0)
    {
      try
      {
        this.m_reconnectLock.Wait();
        this.m_reconnecting = true;
        for (int index = 0; index < subscriptions.Count; ++index)
        {
          if (!subscriptions[index].Transfer((ISession) this, subscriptionIdsForTransfer[index], new UInt32Collection()))
          {
            Utils.LogError("SubscriptionId {0} failed to reactivate.", (object) subscriptionIdsForTransfer[index]);
            ++num;
          }
        }
        if (sendInitialValues)
        {
          IList<ServiceResult> errors;
          if (!this.ResendData((IEnumerable<Subscription>) subscriptions, out errors))
            Utils.LogError("Failed to call resend data for subscriptions.");
          else if (errors != null)
          {
            for (int index = 0; index < errors.Count; ++index)
            {
              if (StatusCode.IsNotGood(errors[index].StatusCode))
                Utils.LogError("SubscriptionId {0} failed to resend data.", (object) subscriptionIdsForTransfer[index]);
            }
          }
        }
        Utils.LogInfo("Session REACTIVATE of {0} subscriptions completed. {1} failed.", (object) subscriptions.Count, (object) num);
      }
      finally
      {
        this.m_reconnecting = false;
        this.m_reconnectLock.Release();
      }
      this.RestartPublishing();
    }
    else
      Utils.LogInfo("No subscriptions. Transfersubscription skipped.");
    return num == 0;
  }

  public bool TransferSubscriptions(SubscriptionCollection subscriptions, bool sendInitialValues)
  {
    int num = 0;
    UInt32Collection subscriptionIdsForTransfer = this.CreateSubscriptionIdsForTransfer(subscriptions);
    if (subscriptionIdsForTransfer.Count > 0)
    {
      if (this.m_reconnecting)
      {
        Utils.LogWarning("Already Reconnecting. Can not transfer subscriptions.");
        return false;
      }
      try
      {
        this.m_reconnectLock.Wait();
        this.m_reconnecting = true;
        TransferResultCollection results;
        DiagnosticInfoCollection diagnosticInfos;
        ResponseHeader responseHeader = base.TransferSubscriptions((RequestHeader) null, subscriptionIdsForTransfer, sendInitialValues, out results, out diagnosticInfos);
        if (!StatusCode.IsGood(responseHeader.ServiceResult))
        {
          Utils.LogError("TransferSubscription failed: {0}", (object) responseHeader.ServiceResult);
          return false;
        }
        ClientBase.ValidateResponse((IList) results, (IList) subscriptionIdsForTransfer);
        ClientBase.ValidateDiagnosticInfos(diagnosticInfos, (IList) subscriptionIdsForTransfer);
        for (int index = 0; index < subscriptions.Count; ++index)
        {
          if (StatusCode.IsGood(results[index].StatusCode))
          {
            if (subscriptions[index].Transfer((ISession) this, subscriptionIdsForTransfer[index], results[index].AvailableSequenceNumbers))
            {
              lock (this.SyncRoot)
              {
                foreach (uint availableSequenceNumber in (List<uint>) results[index].AvailableSequenceNumbers)
                  this.m_acknowledgementsToSend.Add(new SubscriptionAcknowledgement()
                  {
                    SubscriptionId = subscriptionIdsForTransfer[index],
                    SequenceNumber = availableSequenceNumber
                  });
              }
            }
          }
          else if (results[index].StatusCode == 2148466688U /*0x800F0000*/)
          {
            Utils.LogInfo("SubscriptionId {0} is already member of the session.", (object) subscriptionIdsForTransfer[index]);
            ++num;
          }
          else
          {
            Utils.LogError("SubscriptionId {0} failed to transfer, StatusCode={1}", (object) subscriptionIdsForTransfer[index], (object) results[index].StatusCode);
            ++num;
          }
        }
        Utils.LogInfo("Session TRANSFER of {0} subscriptions completed. {1} failed.", (object) subscriptions.Count, (object) num);
      }
      finally
      {
        this.m_reconnecting = false;
        this.m_reconnectLock.Release();
      }
      this.RestartPublishing();
    }
    else
      Utils.LogInfo("No subscriptions. Transfersubscription skipped.");
    return num == 0;
  }

  public virtual ResponseHeader Browse(
    RequestHeader requestHeader,
    ViewDescription view,
    NodeId nodeToBrowse,
    uint maxResultsToReturn,
    BrowseDirection browseDirection,
    NodeId referenceTypeId,
    bool includeSubtypes,
    uint nodeClassMask,
    out byte[] continuationPoint,
    out ReferenceDescriptionCollection references)
  {
    BrowseDescription browseDescription = new BrowseDescription();
    browseDescription.NodeId = nodeToBrowse;
    browseDescription.BrowseDirection = browseDirection;
    browseDescription.ReferenceTypeId = referenceTypeId;
    browseDescription.IncludeSubtypes = includeSubtypes;
    browseDescription.NodeClassMask = nodeClassMask;
    browseDescription.ResultMask = 63U /*0x3F*/;
    BrowseDescriptionCollection descriptionCollection = new BrowseDescriptionCollection();
    descriptionCollection.Add(browseDescription);
    BrowseResultCollection results;
    DiagnosticInfoCollection diagnosticInfos;
    ResponseHeader responseHeader = this.Browse(requestHeader, view, maxResultsToReturn, descriptionCollection, out results, out diagnosticInfos);
    ClientBase.ValidateResponse((IList) results, (IList) descriptionCollection);
    ClientBase.ValidateDiagnosticInfos(diagnosticInfos, (IList) descriptionCollection);
    continuationPoint = !StatusCode.IsBad(results[0].StatusCode) ? results[0].ContinuationPoint : throw new ServiceResultException(new ServiceResult(results[0].StatusCode, 0, diagnosticInfos, (IList<string>) responseHeader.StringTable));
    references = results[0].References;
    return responseHeader;
  }

  public virtual ResponseHeader Browse(
    RequestHeader requestHeader,
    ViewDescription view,
    IList<NodeId> nodesToBrowse,
    uint maxResultsToReturn,
    BrowseDirection browseDirection,
    NodeId referenceTypeId,
    bool includeSubtypes,
    uint nodeClassMask,
    out ByteStringCollection continuationPoints,
    out IList<ReferenceDescriptionCollection> referencesList,
    out IList<ServiceResult> errors)
  {
    BrowseDescriptionCollection descriptionCollection = new BrowseDescriptionCollection();
    foreach (NodeId nodeId in (IEnumerable<NodeId>) nodesToBrowse)
    {
      BrowseDescription browseDescription = new BrowseDescription()
      {
        NodeId = nodeId,
        BrowseDirection = browseDirection,
        ReferenceTypeId = referenceTypeId,
        IncludeSubtypes = includeSubtypes,
        NodeClassMask = nodeClassMask,
        ResultMask = 63 /*0x3F*/
      };
      descriptionCollection.Add(browseDescription);
    }
    BrowseResultCollection results;
    DiagnosticInfoCollection diagnosticInfos;
    ResponseHeader responseHeader = this.Browse(requestHeader, view, maxResultsToReturn, descriptionCollection, out results, out diagnosticInfos);
    ClientBase.ValidateResponse((IList) results, (IList) descriptionCollection);
    ClientBase.ValidateDiagnosticInfos(diagnosticInfos, (IList) descriptionCollection);
    int index = 0;
    errors = (IList<ServiceResult>) new List<ServiceResult>();
    continuationPoints = new ByteStringCollection();
    referencesList = (IList<ReferenceDescriptionCollection>) new List<ReferenceDescriptionCollection>();
    foreach (BrowseResult browseResult in (List<BrowseResult>) results)
    {
      if (StatusCode.IsBad(browseResult.StatusCode))
        errors.Add(new ServiceResult(browseResult.StatusCode, index, diagnosticInfos, (IList<string>) responseHeader.StringTable));
      else
        errors.Add(ServiceResult.Good);
      continuationPoints.Add(browseResult.ContinuationPoint);
      referencesList.Add(browseResult.References);
      ++index;
    }
    return responseHeader;
  }

  public IAsyncResult BeginBrowse(
    RequestHeader requestHeader,
    ViewDescription view,
    NodeId nodeToBrowse,
    uint maxResultsToReturn,
    BrowseDirection browseDirection,
    NodeId referenceTypeId,
    bool includeSubtypes,
    uint nodeClassMask,
    AsyncCallback callback,
    object asyncState)
  {
    BrowseDescription browseDescription = new BrowseDescription();
    browseDescription.NodeId = nodeToBrowse;
    browseDescription.BrowseDirection = browseDirection;
    browseDescription.ReferenceTypeId = referenceTypeId;
    browseDescription.IncludeSubtypes = includeSubtypes;
    browseDescription.NodeClassMask = nodeClassMask;
    browseDescription.ResultMask = 63U /*0x3F*/;
    BrowseDescriptionCollection nodesToBrowse = new BrowseDescriptionCollection();
    nodesToBrowse.Add(browseDescription);
    return this.BeginBrowse(requestHeader, view, maxResultsToReturn, nodesToBrowse, callback, asyncState);
  }

  public ResponseHeader EndBrowse(
    IAsyncResult result,
    out byte[] continuationPoint,
    out ReferenceDescriptionCollection references)
  {
    BrowseResultCollection results;
    DiagnosticInfoCollection diagnosticInfos;
    ResponseHeader responseHeader = this.EndBrowse(result, out results, out diagnosticInfos);
    if (results == null || results.Count != 1)
      throw new ServiceResultException(2148073472U /*0x80090000*/);
    continuationPoint = !StatusCode.IsBad(results[0].StatusCode) ? results[0].ContinuationPoint : throw new ServiceResultException(new ServiceResult(results[0].StatusCode, 0, diagnosticInfos, (IList<string>) responseHeader.StringTable));
    references = results[0].References;
    return responseHeader;
  }

  public virtual ResponseHeader BrowseNext(
    RequestHeader requestHeader,
    bool releaseContinuationPoint,
    byte[] continuationPoint,
    out byte[] revisedContinuationPoint,
    out ReferenceDescriptionCollection references)
  {
    ByteStringCollection stringCollection = new ByteStringCollection();
    stringCollection.Add(continuationPoint);
    BrowseResultCollection results;
    DiagnosticInfoCollection diagnosticInfos;
    ResponseHeader responseHeader = this.BrowseNext(requestHeader, releaseContinuationPoint, stringCollection, out results, out diagnosticInfos);
    ClientBase.ValidateResponse((IList) results, (IList) stringCollection);
    ClientBase.ValidateDiagnosticInfos(diagnosticInfos, (IList) stringCollection);
    revisedContinuationPoint = !StatusCode.IsBad(results[0].StatusCode) ? results[0].ContinuationPoint : throw new ServiceResultException(new ServiceResult(results[0].StatusCode, 0, diagnosticInfos, (IList<string>) responseHeader.StringTable));
    references = results[0].References;
    return responseHeader;
  }

  public virtual ResponseHeader BrowseNext(
    RequestHeader requestHeader,
    bool releaseContinuationPoint,
    ByteStringCollection continuationPoints,
    out ByteStringCollection revisedContinuationPoints,
    out IList<ReferenceDescriptionCollection> referencesList,
    out IList<ServiceResult> errors)
  {
    BrowseResultCollection results;
    DiagnosticInfoCollection diagnosticInfos;
    ResponseHeader responseHeader = this.BrowseNext(requestHeader, releaseContinuationPoint, continuationPoints, out results, out diagnosticInfos);
    ClientBase.ValidateResponse((IList) results, (IList) continuationPoints);
    ClientBase.ValidateDiagnosticInfos(diagnosticInfos, (IList) continuationPoints);
    int index = 0;
    errors = (IList<ServiceResult>) new List<ServiceResult>();
    revisedContinuationPoints = new ByteStringCollection();
    referencesList = (IList<ReferenceDescriptionCollection>) new List<ReferenceDescriptionCollection>();
    foreach (BrowseResult browseResult in (List<BrowseResult>) results)
    {
      if (StatusCode.IsBad(browseResult.StatusCode))
        errors.Add(new ServiceResult(browseResult.StatusCode, index, diagnosticInfos, (IList<string>) responseHeader.StringTable));
      else
        errors.Add(ServiceResult.Good);
      revisedContinuationPoints.Add(browseResult.ContinuationPoint);
      referencesList.Add(browseResult.References);
      ++index;
    }
    return responseHeader;
  }

  public IAsyncResult BeginBrowseNext(
    RequestHeader requestHeader,
    bool releaseContinuationPoint,
    byte[] continuationPoint,
    AsyncCallback callback,
    object asyncState)
  {
    ByteStringCollection continuationPoints = new ByteStringCollection();
    continuationPoints.Add(continuationPoint);
    return this.BeginBrowseNext(requestHeader, releaseContinuationPoint, continuationPoints, callback, asyncState);
  }

  public ResponseHeader EndBrowseNext(
    IAsyncResult result,
    out byte[] revisedContinuationPoint,
    out ReferenceDescriptionCollection references)
  {
    BrowseResultCollection results;
    DiagnosticInfoCollection diagnosticInfos;
    ResponseHeader responseHeader = this.EndBrowseNext(result, out results, out diagnosticInfos);
    if (results == null || results.Count != 1)
      throw new ServiceResultException(2148073472U /*0x80090000*/);
    revisedContinuationPoint = !StatusCode.IsBad(results[0].StatusCode) ? results[0].ContinuationPoint : throw new ServiceResultException(new ServiceResult(results[0].StatusCode, 0, diagnosticInfos, (IList<string>) responseHeader.StringTable));
    references = results[0].References;
    return responseHeader;
  }

  public IList<object> Call(NodeId objectId, NodeId methodId, params object[] args)
  {
    VariantCollection variantCollection = new VariantCollection();
    if (args != null)
    {
      for (int index = 0; index < args.Length; ++index)
        variantCollection.Add(new Opc.Ua.Variant(args[index]));
    }
    CallMethodRequest callMethodRequest = new CallMethodRequest();
    callMethodRequest.ObjectId = objectId;
    callMethodRequest.MethodId = methodId;
    callMethodRequest.InputArguments = variantCollection;
    CallMethodRequestCollection requestCollection = new CallMethodRequestCollection();
    requestCollection.Add(callMethodRequest);
    CallMethodResultCollection results;
    DiagnosticInfoCollection diagnosticInfos;
    ResponseHeader responseHeader = this.Call((RequestHeader) null, requestCollection, out results, out diagnosticInfos);
    ClientBase.ValidateResponse((IList) results, (IList) requestCollection);
    ClientBase.ValidateDiagnosticInfos(diagnosticInfos, (IList) requestCollection);
    if (StatusCode.IsBad(results[0].StatusCode))
      throw ServiceResultException.Create(results[0].StatusCode, 0, diagnosticInfos, (IList<string>) responseHeader.StringTable);
    List<object> objectList = new List<object>();
    foreach (Opc.Ua.Variant outputArgument in (List<Opc.Ua.Variant>) results[0].OutputArguments)
      objectList.Add(outputArgument.Value);
    return (IList<object>) objectList;
  }

  protected virtual SignedSoftwareCertificateCollection GetSoftwareCertificates()
  {
    return new SignedSoftwareCertificateCollection();
  }

  protected virtual void OnApplicationCertificateError(
    byte[] serverCertificate,
    ServiceResult result)
  {
    throw new ServiceResultException(result);
  }

  protected virtual void OnSoftwareCertificateError(
    SignedSoftwareCertificate signedCertificate,
    ServiceResult result)
  {
    throw new ServiceResultException(result);
  }

  protected virtual void ValidateSoftwareCertificates(List<SoftwareCertificate> softwareCertificates)
  {
  }

  private void StartKeepAliveTimer()
  {
    int keepAliveInterval = this.m_keepAliveInterval;
    lock (this.m_eventLock)
    {
      this.m_serverState = ServerState.Unknown;
      this.m_lastKeepAliveTime = DateTime.UtcNow;
    }
    ReadValueIdCollection valueIdCollection = new ReadValueIdCollection();
    valueIdCollection.Add(new ReadValueId()
    {
      NodeId = (NodeId) 2259U,
      AttributeId = 13U,
      DataEncoding = (QualifiedName) null,
      IndexRange = (string) null
    });
    ReadValueIdCollection state = valueIdCollection;
    lock (this.SyncRoot)
    {
      this.StopKeepAliveTimer();
      this.m_keepAliveTimer = new Timer(new TimerCallback(this.OnKeepAlive), (object) state, keepAliveInterval, keepAliveInterval);
    }
    this.OnKeepAlive((object) state);
  }

  private void StopKeepAliveTimer()
  {
    Utils.SilentDispose((IDisposable) this.m_keepAliveTimer);
    this.m_keepAliveTimer = (Timer) null;
  }

  private Session.AsyncRequestState RemoveRequest(IAsyncResult result, uint requestId, uint typeId)
  {
    lock (this.m_outstandingRequests)
    {
      for (LinkedListNode<Session.AsyncRequestState> node = this.m_outstandingRequests.First; node != null; node = node.Next)
      {
        if (result == node.Value.Result || (int) requestId == (int) node.Value.RequestId && (int) typeId == (int) node.Value.RequestTypeId)
        {
          Session.AsyncRequestState asyncRequestState = node.Value;
          this.m_outstandingRequests.Remove(node);
          return asyncRequestState;
        }
      }
      return (Session.AsyncRequestState) null;
    }
  }

  private void AsyncRequestStarted(IAsyncResult result, uint requestId, uint typeId)
  {
    lock (this.m_outstandingRequests)
    {
      if (this.RemoveRequest(result, requestId, typeId) != null)
        return;
      this.m_outstandingRequests.AddLast(new Session.AsyncRequestState()
      {
        Defunct = false,
        RequestId = requestId,
        RequestTypeId = typeId,
        Result = result,
        Timestamp = DateTime.UtcNow
      });
    }
  }

  private void AsyncRequestCompleted(IAsyncResult result, uint requestId, uint typeId)
  {
    lock (this.m_outstandingRequests)
    {
      Session.AsyncRequestState asyncRequestState = this.RemoveRequest(result, requestId, typeId);
      if (asyncRequestState != null)
      {
        DateTime dateTime = asyncRequestState.Timestamp.AddSeconds(-1.0);
        for (LinkedListNode<Session.AsyncRequestState> linkedListNode = this.m_outstandingRequests.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
        {
          if ((int) linkedListNode.Value.RequestTypeId == (int) typeId && linkedListNode.Value.Timestamp < dateTime)
            linkedListNode.Value.Defunct = true;
        }
      }
      if (asyncRequestState != null)
        return;
      this.m_outstandingRequests.AddLast(new Session.AsyncRequestState()
      {
        Defunct = true,
        RequestId = requestId,
        RequestTypeId = typeId,
        Result = result,
        Timestamp = DateTime.UtcNow
      });
    }
  }

  private void OnKeepAlive(object state)
  {
    ReadValueIdCollection valueIdCollection = (ReadValueIdCollection) state;
    try
    {
      if (!this.Connected || this.m_keepAliveTimer == null || this.KeepAliveStopped && !this.OnKeepAliveError(ServiceResult.Create(2150694912U /*0x80310000*/, "Server not responding to keep alive requests.")))
        return;
      RequestHeader requestHeader = new RequestHeader();
      requestHeader.RequestHandle = Utils.IncrementIdentifier(ref this.m_keepAliveCounter);
      requestHeader.TimeoutHint = (uint) (this.KeepAliveInterval * 2);
      requestHeader.ReturnDiagnostics = 0U;
      this.AsyncRequestStarted(this.BeginRead(requestHeader, 0.0, TimestampsToReturn.Neither, valueIdCollection, new AsyncCallback(this.OnKeepAliveComplete), (object) valueIdCollection), requestHeader.RequestHandle, 629U);
    }
    catch (Exception ex)
    {
      Utils.LogError("Could not send keep alive request: {0} {1}", (object) ex.GetType().FullName, (object) ex.Message);
    }
  }

  private void OnKeepAliveComplete(IAsyncResult result)
  {
    ReadValueIdCollection asyncState = (ReadValueIdCollection) result.AsyncState;
    this.AsyncRequestCompleted(result, 0U, 629U);
    try
    {
      DataValueCollection results = new DataValueCollection();
      DiagnosticInfoCollection diagnosticInfos = new DiagnosticInfoCollection();
      ResponseHeader responseHeader = this.EndRead(result, out results, out diagnosticInfos);
      ClientBase.ValidateResponse((IList) results, (IList) asyncState);
      ClientBase.ValidateDiagnosticInfos(diagnosticInfos, (IList) asyncState);
      ServiceResult status = ClientBase.ValidateDataValue(results[0], typeof (int), 0, diagnosticInfos, responseHeader);
      if (ServiceResult.IsBad(status))
        throw new ServiceResultException(status);
      this.OnKeepAlive((ServerState) results[0].Value, responseHeader.Timestamp);
    }
    catch (Exception ex)
    {
      Utils.LogError("Unexpected keep alive error occurred: {0}", (object) ex.Message);
    }
  }

  protected virtual void OnKeepAlive(ServerState currentState, DateTime currentTime)
  {
    if (this.KeepAliveStopped)
    {
      if (this.m_reconnecting)
        return;
      lock (this.m_outstandingRequests)
      {
        for (LinkedListNode<Session.AsyncRequestState> linkedListNode = this.m_outstandingRequests.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
        {
          if (linkedListNode.Value.RequestTypeId == 824U)
            linkedListNode.Value.Defunct = true;
        }
      }
      int publishRequestCount = this.GetMinPublishRequestCount(false);
      while (publishRequestCount-- > 0)
        this.BeginPublish(this.OperationTimeout);
    }
    KeepAliveEventHandler aliveEventHandler = (KeepAliveEventHandler) null;
    lock (this.m_eventLock)
    {
      aliveEventHandler = this.m_KeepAlive;
      this.m_serverState = currentState;
      this.m_lastKeepAliveTime = DateTime.UtcNow;
    }
    if (aliveEventHandler == null)
      return;
    try
    {
      aliveEventHandler((ISession) this, new KeepAliveEventArgs((ServiceResult) null, currentState, currentTime));
    }
    catch (Exception ex)
    {
      object[] objArray = Array.Empty<object>();
      Utils.LogError(ex, "Session: Unexpected error invoking KeepAliveCallback.", objArray);
    }
  }

  protected virtual bool OnKeepAliveError(ServiceResult result)
  {
    long num = 0;
    lock (this.m_eventLock)
      num = DateTime.UtcNow.Ticks - this.m_lastKeepAliveTime.Ticks;
    Utils.LogInfo("KEEP ALIVE LATE: {0}s, EndpointUrl={1}, RequestCount={2}/{3}", (object) ((double) num / 10000000.0), (object) this.Endpoint.EndpointUrl, (object) this.GoodPublishRequestCount, (object) this.OutstandingRequestCount);
    KeepAliveEventHandler aliveEventHandler = (KeepAliveEventHandler) null;
    lock (this.m_eventLock)
      aliveEventHandler = this.m_KeepAlive;
    if (aliveEventHandler != null)
    {
      try
      {
        KeepAliveEventArgs e = new KeepAliveEventArgs(result, ServerState.Unknown, DateTime.UtcNow);
        aliveEventHandler((ISession) this, e);
        return !e.CancelKeepAlive;
      }
      catch (Exception ex)
      {
        object[] objArray = Array.Empty<object>();
        Utils.LogError(ex, "Session: Unexpected error invoking KeepAliveCallback.", objArray);
      }
    }
    return true;
  }

  private bool PrepareSubscriptionsToDelete(
    IEnumerable<Subscription> subscriptions,
    IList<Subscription> subscriptionsToDelete)
  {
    bool delete = false;
    lock (this.SyncRoot)
    {
      foreach (Subscription subscription in subscriptions)
      {
        if (this.m_subscriptions.Remove(subscription))
        {
          if (subscription.Created)
            subscriptionsToDelete.Add(subscription);
          delete = true;
        }
      }
    }
    return delete;
  }

  private void CreateNodeClassAttributesReadNodesRequest(
    IList<NodeId> nodeIdCollection,
    NodeClass nodeClass,
    ReadValueIdCollection attributesToRead,
    IList<IDictionary<uint, DataValue>> attributesPerNodeId,
    IList<Opc.Ua.Node> nodeCollection,
    bool optionalAttributes)
  {
    for (int index = 0; index < nodeIdCollection.Count; ++index)
    {
      Opc.Ua.Node node = new Opc.Ua.Node();
      node.NodeId = nodeIdCollection[index];
      node.NodeClass = nodeClass;
      IDictionary<uint, DataValue> attributes = this.CreateAttributes(node.NodeClass, optionalAttributes);
      foreach (uint key in (IEnumerable<uint>) attributes.Keys)
      {
        ReadValueId readValueId = new ReadValueId()
        {
          NodeId = node.NodeId,
          AttributeId = key
        };
        attributesToRead.Add(readValueId);
      }
      nodeCollection.Add(node);
      attributesPerNodeId.Add(attributes);
    }
  }

  private ReadValueIdCollection PrepareNamespaceTableNodesToRead()
  {
    ReadValueIdCollection read = new ReadValueIdCollection();
    read.Add(new ReadValueId()
    {
      NodeId = (NodeId) 2255U,
      AttributeId = 13U
    });
    read.Add(new ReadValueId()
    {
      NodeId = (NodeId) 2254U,
      AttributeId = 13U
    });
    return read;
  }

  private void UpdateNamespaceTable(
    DataValueCollection values,
    DiagnosticInfoCollection diagnosticInfos,
    ResponseHeader responseHeader)
  {
    ServiceResult status1 = ClientBase.ValidateDataValue(values[0], typeof (string[]), 0, diagnosticInfos, responseHeader);
    if (ServiceResult.IsBad(status1))
      Utils.LogError("FetchNamespaceTables: Cannot read NamespaceArray node: {0}", (object) status1.StatusCode);
    else
      this.m_namespaceUris.Update((IEnumerable<string>) (string[]) values[0].Value);
    ServiceResult status2 = ClientBase.ValidateDataValue(values[1], typeof (string[]), 1, diagnosticInfos, responseHeader);
    if (ServiceResult.IsBad(status2))
      Utils.LogError("FetchNamespaceTables: Cannot read ServerArray node: {0} ", (object) status2.StatusCode);
    else
      this.m_serverUris.Update((IEnumerable<string>) (string[]) values[1].Value);
  }

  private void CreateAttributesReadNodesRequest(
    ResponseHeader responseHeader,
    ReadValueIdCollection itemsToRead,
    DataValueCollection nodeClassValues,
    DiagnosticInfoCollection diagnosticInfos,
    ReadValueIdCollection attributesToRead,
    IList<IDictionary<uint, DataValue>> attributesPerNodeId,
    IList<Opc.Ua.Node> nodeCollection,
    IList<ServiceResult> errors,
    bool optionalAttributes)
  {
    for (int index = 0; index < itemsToRead.Count; ++index)
    {
      Opc.Ua.Node node = new Opc.Ua.Node();
      node.NodeId = itemsToRead[index].NodeId;
      if (!DataValue.IsGood(nodeClassValues[index]))
      {
        nodeCollection.Add(node);
        errors.Add(new ServiceResult(nodeClassValues[index].StatusCode, index, diagnosticInfos, (IList<string>) responseHeader.StringTable));
        attributesPerNodeId.Add((IDictionary<uint, DataValue>) null);
      }
      else
      {
        int? nullable = nodeClassValues[index].Value as int?;
        if (!nullable.HasValue)
        {
          nodeCollection.Add(node);
          errors.Add(ServiceResult.Create(2147549184U /*0x80010000*/, "Node does not have a valid value for NodeClass: {0}.", nodeClassValues[index].Value));
          attributesPerNodeId.Add((IDictionary<uint, DataValue>) null);
        }
        else
        {
          node.NodeClass = (NodeClass) nullable.Value;
          IDictionary<uint, DataValue> attributes = this.CreateAttributes(node.NodeClass, optionalAttributes);
          foreach (uint key in (IEnumerable<uint>) attributes.Keys)
          {
            ReadValueId readValueId = new ReadValueId()
            {
              NodeId = node.NodeId,
              AttributeId = key
            };
            attributesToRead.Add(readValueId);
          }
          nodeCollection.Add(node);
          errors.Add(ServiceResult.Good);
          attributesPerNodeId.Add(attributes);
        }
      }
    }
  }

  private void ProcessAttributesReadNodesResponse(
    ResponseHeader responseHeader,
    ReadValueIdCollection attributesToRead,
    IList<IDictionary<uint, DataValue>> attributesPerNodeId,
    DataValueCollection values,
    DiagnosticInfoCollection diagnosticInfos,
    IList<Opc.Ua.Node> nodeCollection,
    IList<ServiceResult> errors)
  {
    int index1 = 0;
    for (int index2 = 0; index2 < nodeCollection.Count; ++index2)
    {
      IDictionary<uint, DataValue> attributes = attributesPerNodeId[index2];
      if (attributes != null)
      {
        int count = attributes.Count;
        ReadValueIdCollection itemsToRead = new ReadValueIdCollection((IEnumerable<ReadValueId>) attributesToRead.GetRange(index1, count));
        DataValueCollection values1 = new DataValueCollection((IEnumerable<DataValue>) values.GetRange(index1, count));
        DiagnosticInfoCollection diagnosticInfos1 = diagnosticInfos.Count > 0 ? new DiagnosticInfoCollection((IEnumerable<DiagnosticInfo>) diagnosticInfos.GetRange(index1, count)) : diagnosticInfos;
        try
        {
          nodeCollection[index2] = this.ProcessReadResponse(responseHeader, attributes, itemsToRead, values1, diagnosticInfos1);
          errors[index2] = ServiceResult.Good;
        }
        catch (ServiceResultException ex)
        {
          errors[index2] = ex.Result;
        }
        index1 += count;
      }
    }
  }

  private Opc.Ua.Node ProcessReadResponse(
    ResponseHeader responseHeader,
    IDictionary<uint, DataValue> attributes,
    ReadValueIdCollection itemsToRead,
    DataValueCollection values,
    DiagnosticInfoCollection diagnosticInfos)
  {
    int? nullable = new int?();
    for (int index = 0; index < itemsToRead.Count; ++index)
    {
      uint attributeId = itemsToRead[index].AttributeId;
      if (attributeId == 2U)
      {
        if (!DataValue.IsGood(values[index]))
          throw ServiceResultException.Create(values[index].StatusCode, index, diagnosticInfos, (IList<string>) responseHeader.StringTable);
        nullable = values[index].Value as int?;
        if (!nullable.HasValue)
          throw ServiceResultException.Create(2147549184U /*0x80010000*/, "Node does not have a valid value for NodeClass: {0}.", values[index].Value);
      }
      else if (!DataValue.IsGood(values[index]))
      {
        if (!(values[index].StatusCode == 2150957056U /*0x80350000*/) && (!StatusCode.IsBad(values[index].StatusCode) || attributeId != 26U && attributeId != 5U && attributeId != 24U && attributeId != 25U && attributeId != 7U && attributeId != 6U))
        {
          if (attributeId != 13U)
            throw ServiceResultException.Create(values[index].StatusCode, index, diagnosticInfos, (IList<string>) responseHeader.StringTable);
        }
        else
          continue;
      }
      attributes[attributeId] = values[index];
    }
    Opc.Ua.Node node;
    switch ((NodeClass) nullable.Value)
    {
      case NodeClass.Object:
        ObjectNode objectNode = new ObjectNode();
        objectNode.EventNotifier = (byte) (attributes[12U] ?? throw ServiceResultException.Create(2147549184U /*0x80010000*/, "Object does not support the EventNotifier attribute.")).GetValue(typeof (byte));
        node = (Opc.Ua.Node) objectNode;
        break;
      case NodeClass.Variable:
        VariableNode variableNode = new VariableNode();
        variableNode.DataType = (NodeId) (attributes[14U] ?? throw ServiceResultException.Create(2147549184U /*0x80010000*/, "Variable does not support the DataType attribute.")).GetValue(typeof (NodeId));
        variableNode.ValueRank = (int) (attributes[15U] ?? throw ServiceResultException.Create(2147549184U /*0x80010000*/, "Variable does not support the ValueRank attribute.")).GetValue(typeof (int));
        DataValue attribute1 = attributes[16U /*0x10*/];
        if (attribute1 != null)
          variableNode.ArrayDimensions = attribute1.Value != null ? (UInt32Collection) (uint[]) attribute1.GetValue(typeof (uint[])) : (UInt32Collection) Array.Empty<uint>();
        variableNode.AccessLevel = (byte) (attributes[17U] ?? throw ServiceResultException.Create(2147549184U /*0x80010000*/, "Variable does not support the AccessLevel attribute.")).GetValue(typeof (byte));
        variableNode.UserAccessLevel = (byte) (attributes[18U] ?? throw ServiceResultException.Create(2147549184U /*0x80010000*/, "Variable does not support the UserAccessLevel attribute.")).GetValue(typeof (byte));
        variableNode.Historizing = (bool) (attributes[20U] ?? throw ServiceResultException.Create(2147549184U /*0x80010000*/, "Variable does not support the Historizing attribute.")).GetValue(typeof (bool));
        if (attributes[19U] != null)
          variableNode.MinimumSamplingInterval = Convert.ToDouble(attributes[19U].Value);
        DataValue attribute2 = attributes[27U];
        if (attribute2 != null)
          variableNode.AccessLevelEx = (uint) attribute2.GetValue(typeof (uint));
        node = (Opc.Ua.Node) variableNode;
        break;
      case NodeClass.Method:
        MethodNode methodNode = new MethodNode();
        methodNode.Executable = (bool) (attributes[21U] ?? throw ServiceResultException.Create(2147549184U /*0x80010000*/, "Method does not support the Executable attribute.")).GetValue(typeof (bool));
        methodNode.UserExecutable = (bool) (attributes[22U] ?? throw ServiceResultException.Create(2147549184U /*0x80010000*/, "Method does not support the UserExecutable attribute.")).GetValue(typeof (bool));
        node = (Opc.Ua.Node) methodNode;
        break;
      case NodeClass.ObjectType:
        ObjectTypeNode objectTypeNode = new ObjectTypeNode();
        objectTypeNode.IsAbstract = (bool) (attributes[8U] ?? throw ServiceResultException.Create(2147549184U /*0x80010000*/, "ObjectType does not support the IsAbstract attribute.")).GetValue(typeof (bool));
        node = (Opc.Ua.Node) objectTypeNode;
        break;
      case NodeClass.VariableType:
        VariableTypeNode variableTypeNode = new VariableTypeNode();
        variableTypeNode.IsAbstract = (bool) (attributes[8U] ?? throw ServiceResultException.Create(2147549184U /*0x80010000*/, "VariableType does not support the IsAbstract attribute.")).GetValue(typeof (bool));
        variableTypeNode.DataType = (NodeId) (attributes[14U] ?? throw ServiceResultException.Create(2147549184U /*0x80010000*/, "VariableType does not support the DataType attribute.")).GetValue(typeof (NodeId));
        variableTypeNode.ValueRank = (int) (attributes[15U] ?? throw ServiceResultException.Create(2147549184U /*0x80010000*/, "VariableType does not support the ValueRank attribute.")).GetValue(typeof (int));
        DataValue attribute3 = attributes[16U /*0x10*/];
        if (attribute3 != null && attribute3.Value != null)
          variableTypeNode.ArrayDimensions = (UInt32Collection) (uint[]) attribute3.GetValue(typeof (uint[]));
        node = (Opc.Ua.Node) variableTypeNode;
        break;
      case NodeClass.ReferenceType:
        ReferenceTypeNode referenceTypeNode = new ReferenceTypeNode();
        referenceTypeNode.IsAbstract = (bool) (attributes[8U] ?? throw ServiceResultException.Create(2147549184U /*0x80010000*/, "ReferenceType does not support the IsAbstract attribute.")).GetValue(typeof (bool));
        referenceTypeNode.Symmetric = (bool) (attributes[9U] ?? throw ServiceResultException.Create(2147549184U /*0x80010000*/, "ReferenceType does not support the Symmetric attribute.")).GetValue(typeof (bool));
        DataValue attribute4 = attributes[10U];
        if (attribute4 != null && attribute4.Value != null)
          referenceTypeNode.InverseName = (LocalizedText) attribute4.GetValue(typeof (LocalizedText));
        node = (Opc.Ua.Node) referenceTypeNode;
        break;
      case NodeClass.DataType:
        DataTypeNode dataTypeNode = new DataTypeNode();
        dataTypeNode.IsAbstract = (bool) (attributes[8U] ?? throw ServiceResultException.Create(2147549184U /*0x80010000*/, "DataType does not support the IsAbstract attribute.")).GetValue(typeof (bool));
        DataValue attribute5 = attributes[23U];
        if (attribute5 != null)
          dataTypeNode.DataTypeDefinition = attribute5.Value as ExtensionObject;
        node = (Opc.Ua.Node) dataTypeNode;
        break;
      case NodeClass.View:
        ViewNode viewNode = new ViewNode();
        viewNode.EventNotifier = (byte) (attributes[12U] ?? throw ServiceResultException.Create(2147549184U /*0x80010000*/, "View does not support the EventNotifier attribute.")).GetValue(typeof (byte));
        viewNode.ContainsNoLoops = (bool) (attributes[11U] ?? throw ServiceResultException.Create(2147549184U /*0x80010000*/, "View does not support the ContainsNoLoops attribute.")).GetValue(typeof (bool));
        node = (Opc.Ua.Node) viewNode;
        break;
      default:
        throw ServiceResultException.Create(2147549184U /*0x80010000*/, "Node does not have a valid value for NodeClass: {0}.", (object) nullable.Value);
    }
    node.NodeId = (NodeId) (attributes[1U] ?? throw ServiceResultException.Create(2147549184U /*0x80010000*/, "Node does not support the NodeId attribute.")).GetValue(typeof (NodeId));
    node.NodeClass = (NodeClass) nullable.Value;
    node.BrowseName = (QualifiedName) (attributes[3U] ?? throw ServiceResultException.Create(2147549184U /*0x80010000*/, "Node does not support the BrowseName attribute.")).GetValue(typeof (QualifiedName));
    DataValue attribute6 = attributes[4U];
    node.DisplayName = attribute6 != null ? (LocalizedText) attribute6.GetValue(typeof (LocalizedText)) : throw ServiceResultException.Create(2147549184U /*0x80010000*/, "Node does not support the DisplayName attribute.");
    if (attributes.TryGetValue(5U, out attribute6) && attribute6 != null && attribute6.Value != null)
      node.Description = (LocalizedText) attribute6.GetValue(typeof (LocalizedText));
    if (attributes.TryGetValue(6U, out attribute6) && attribute6 != null)
      node.WriteMask = (uint) attribute6.GetValue(typeof (uint));
    if (attributes.TryGetValue(7U, out attribute6) && attribute6 != null)
      node.UserWriteMask = (uint) attribute6.GetValue(typeof (uint));
    if (attributes.TryGetValue(24U, out attribute6) && attribute6 != null && attribute6.Value is ExtensionObject[] extensionObjectArray1)
    {
      node.RolePermissions = new RolePermissionTypeCollection();
      for (int index = 0; index < extensionObjectArray1.Length; ++index)
      {
        ExtensionObject extensionObject = extensionObjectArray1[index];
        node.RolePermissions.Add(extensionObject.Body as RolePermissionType);
      }
    }
    if (attributes.TryGetValue(25U, out attribute6) && attribute6 != null && attribute6.Value is ExtensionObject[] extensionObjectArray2)
    {
      node.UserRolePermissions = new RolePermissionTypeCollection();
      for (int index = 0; index < extensionObjectArray2.Length; ++index)
      {
        ExtensionObject extensionObject = extensionObjectArray2[index];
        node.UserRolePermissions.Add(extensionObject.Body as RolePermissionType);
      }
    }
    if (attributes.TryGetValue(26U, out attribute6) && attribute6 != null)
      node.AccessRestrictions = (ushort) attribute6.GetValue(typeof (ushort));
    return node;
  }

  private IDictionary<uint, DataValue> CreateAttributes(
    NodeClass nodeclass = NodeClass.Unspecified,
    bool optionalAttributes = true)
  {
    SortedDictionary<uint, DataValue> attributes = new SortedDictionary<uint, DataValue>()
    {
      {
        1U,
        (DataValue) null
      },
      {
        2U,
        (DataValue) null
      },
      {
        3U,
        (DataValue) null
      },
      {
        4U,
        (DataValue) null
      }
    };
    switch (nodeclass)
    {
      case NodeClass.Object:
        attributes.Add(12U, (DataValue) null);
        break;
      case NodeClass.Variable:
        attributes.Add(14U, (DataValue) null);
        attributes.Add(15U, (DataValue) null);
        attributes.Add(16U /*0x10*/, (DataValue) null);
        attributes.Add(17U, (DataValue) null);
        attributes.Add(18U, (DataValue) null);
        attributes.Add(20U, (DataValue) null);
        attributes.Add(19U, (DataValue) null);
        attributes.Add(27U, (DataValue) null);
        break;
      case NodeClass.Method:
        attributes.Add(21U, (DataValue) null);
        attributes.Add(22U, (DataValue) null);
        break;
      case NodeClass.ObjectType:
        attributes.Add(8U, (DataValue) null);
        break;
      case NodeClass.VariableType:
        attributes.Add(8U, (DataValue) null);
        attributes.Add(14U, (DataValue) null);
        attributes.Add(15U, (DataValue) null);
        attributes.Add(16U /*0x10*/, (DataValue) null);
        break;
      case NodeClass.ReferenceType:
        attributes.Add(8U, (DataValue) null);
        attributes.Add(9U, (DataValue) null);
        attributes.Add(10U, (DataValue) null);
        break;
      case NodeClass.DataType:
        attributes.Add(8U, (DataValue) null);
        attributes.Add(23U, (DataValue) null);
        break;
      case NodeClass.View:
        attributes.Add(12U, (DataValue) null);
        attributes.Add(11U, (DataValue) null);
        break;
      default:
        attributes = new SortedDictionary<uint, DataValue>()
        {
          {
            1U,
            (DataValue) null
          },
          {
            2U,
            (DataValue) null
          },
          {
            3U,
            (DataValue) null
          },
          {
            4U,
            (DataValue) null
          },
          {
            14U,
            (DataValue) null
          },
          {
            15U,
            (DataValue) null
          },
          {
            16U /*0x10*/,
            (DataValue) null
          },
          {
            17U,
            (DataValue) null
          },
          {
            18U,
            (DataValue) null
          },
          {
            19U,
            (DataValue) null
          },
          {
            20U,
            (DataValue) null
          },
          {
            12U,
            (DataValue) null
          },
          {
            21U,
            (DataValue) null
          },
          {
            22U,
            (DataValue) null
          },
          {
            8U,
            (DataValue) null
          },
          {
            10U,
            (DataValue) null
          },
          {
            9U,
            (DataValue) null
          },
          {
            11U,
            (DataValue) null
          },
          {
            23U,
            (DataValue) null
          },
          {
            27U,
            (DataValue) null
          }
        };
        break;
    }
    if (optionalAttributes)
    {
      attributes.Add(5U, (DataValue) null);
      attributes.Add(6U, (DataValue) null);
      attributes.Add(7U, (DataValue) null);
      attributes.Add(24U, (DataValue) null);
      attributes.Add(25U, (DataValue) null);
      attributes.Add(26U, (DataValue) null);
    }
    return (IDictionary<uint, DataValue>) attributes;
  }

  public IAsyncResult BeginPublish(int timeout)
  {
    if (this.m_reconnecting)
    {
      Utils.LogWarning("Publish skipped due to reconnect");
      return (IAsyncResult) null;
    }
    PublishSequenceNumbersToAcknowledgeEventHandler acknowledgeEventHandler = (PublishSequenceNumbersToAcknowledgeEventHandler) null;
    lock (this.m_eventLock)
      acknowledgeEventHandler = this.m_PublishSequenceNumbersToAcknowledge;
    SubscriptionAcknowledgementCollection subscriptionAcknowledgements = (SubscriptionAcknowledgementCollection) null;
    lock (this.SyncRoot)
    {
      if (acknowledgeEventHandler != null)
      {
        try
        {
          SubscriptionAcknowledgementCollection deferredAcknowledgementsToSend = new SubscriptionAcknowledgementCollection();
          acknowledgeEventHandler((ISession) this, new PublishSequenceNumbersToAcknowledgeEventArgs(this.m_acknowledgementsToSend, deferredAcknowledgementsToSend));
          subscriptionAcknowledgements = this.m_acknowledgementsToSend;
          this.m_acknowledgementsToSend = deferredAcknowledgementsToSend;
        }
        catch (Exception ex)
        {
          object[] objArray = Array.Empty<object>();
          Utils.LogError(ex, "Session: Unexpected error invoking PublishSequenceNumbersToAcknowledgeEventArgs.", objArray);
        }
      }
      if (subscriptionAcknowledgements == null)
      {
        subscriptionAcknowledgements = this.m_acknowledgementsToSend;
        this.m_acknowledgementsToSend = new SubscriptionAcknowledgementCollection();
      }
      foreach (SubscriptionAcknowledgement subscriptionAcknowledgement in (List<SubscriptionAcknowledgement>) subscriptionAcknowledgements)
        this.m_latestAcknowledgementsSent[subscriptionAcknowledgement.SubscriptionId] = subscriptionAcknowledgement.SequenceNumber;
    }
    RequestHeader requestHeader = new RequestHeader();
    requestHeader.TimeoutHint = (uint) this.OperationTimeout / 2U;
    requestHeader.ReturnDiagnostics = (uint) this.ReturnDiagnostics;
    requestHeader.RequestHandle = Utils.IncrementIdentifier(ref this.m_publishCounter);
    Session.AsyncRequestState asyncRequestState = new Session.AsyncRequestState()
    {
      RequestTypeId = 824,
      RequestId = requestHeader.RequestHandle,
      Timestamp = DateTime.UtcNow
    };
    CoreClientUtils.EventLog.PublishStart((int) requestHeader.RequestHandle);
    try
    {
      IAsyncResult result = this.BeginPublish(requestHeader, subscriptionAcknowledgements, new AsyncCallback(this.OnPublishComplete), (object) new object[3]
      {
        (object) this.SessionId,
        (object) subscriptionAcknowledgements,
        (object) requestHeader
      });
      this.AsyncRequestStarted(result, requestHeader.RequestHandle, 824U);
      return result;
    }
    catch (Exception ex)
    {
      object[] objArray = Array.Empty<object>();
      Utils.LogError(ex, "Unexpected error sending publish request.", objArray);
      return (IAsyncResult) null;
    }
  }

  private void OnPublishComplete(IAsyncResult result)
  {
    object[] asyncState = (object[]) result.AsyncState;
    NodeId nodeId = (NodeId) asyncState[0];
    SubscriptionAcknowledgementCollection collection = (SubscriptionAcknowledgementCollection) asyncState[1];
    RequestHeader requestHeader = (RequestHeader) asyncState[2];
    this.AsyncRequestCompleted(result, requestHeader.RequestHandle, 824U);
    CoreClientUtils.EventLog.PublishStop((int) requestHeader.RequestHandle);
    try
    {
      this.m_reconnectLock.Wait();
      bool reconnecting = this.m_reconnecting;
      this.m_reconnectLock.Release();
      uint subscriptionId;
      UInt32Collection availableSequenceNumbers;
      bool moreNotifications;
      NotificationMessage notificationMessage;
      StatusCodeCollection results;
      ResponseHeader responseHeader = this.EndPublish(result, out subscriptionId, out availableSequenceNumbers, out moreNotifications, out notificationMessage, out results, out DiagnosticInfoCollection _);
      foreach (StatusCode code in (List<StatusCode>) results)
      {
        if (StatusCode.IsBad(code))
          Utils.LogError("Error - Publish call finished. ResultCode={0}; SubscriptionId={1};", (object) code.ToString(), (object) subscriptionId);
      }
      if (nodeId != (object) this.SessionId)
      {
        Utils.LogWarning("Publish response discarded because session id changed: Old {0} != New {1}", (object) nodeId, (object) this.SessionId);
        return;
      }
      CoreClientUtils.EventLog.NotificationReceived((int) subscriptionId, (int) notificationMessage.SequenceNumber);
      this.ProcessPublishResponse(responseHeader, subscriptionId, availableSequenceNumbers, moreNotifications, notificationMessage);
      if (reconnecting)
      {
        Utils.LogWarning("No new publish sent because of reconnect in progress.");
        return;
      }
    }
    catch (Exception ex1)
    {
      if (this.m_subscriptions.Count == 0)
        Utils.LogError("Publish #{0}, Subscription count = 0, Error: {1}", (object) requestHeader.RequestHandle, (object) ex1.Message);
      else
        Utils.LogError("Publish #{0}, Reconnecting={1}, Error: {2}", (object) requestHeader.RequestHandle, (object) this.m_reconnecting, (object) ex1.Message);
      if (this.m_reconnecting)
      {
        Utils.LogWarning("Publish abandoned after error due to reconnect: {0}", (object) ex1.Message);
        return;
      }
      if (nodeId != (object) this.SessionId)
      {
        Utils.LogError("Publish abandoned after error because session id changed: Old {0} != New {1}", (object) nodeId, (object) this.SessionId);
        return;
      }
      if (collection != null)
      {
        lock (this.SyncRoot)
          this.m_acknowledgementsToSend.AddRange((IEnumerable<SubscriptionAcknowledgement>) collection);
      }
      ServiceResult status = new ServiceResult(ex1);
      if (status.Code != 2155413504U /*0x80790000*/)
      {
        PublishErrorEventHandler errorEventHandler = (PublishErrorEventHandler) null;
        lock (this.m_eventLock)
          errorEventHandler = this.m_PublishError;
        if (errorEventHandler != null)
        {
          try
          {
            errorEventHandler((ISession) this, new PublishErrorEventArgs(status));
          }
          catch (Exception ex2)
          {
            object[] objArray = Array.Empty<object>();
            Utils.LogError(ex2, "Session: Unexpected error invoking PublishErrorCallback.", objArray);
          }
        }
      }
      switch (status.Code)
      {
        case 2148401152 /*0x800E0000*/:
          return;
        case 2148663296 /*0x80120000*/:
          return;
        case 2148728832 /*0x80130000*/:
          return;
        case 2149711872 /*0x80220000*/:
          return;
        case 2149908480 /*0x80250000*/:
          return;
        case 2149974016 /*0x80260000*/:
          return;
        case 2155347968 /*0x80780000*/:
          int publishRequestCount = this.GoodPublishRequestCount;
          if (!this.BelowPublishRequestLimit(publishRequestCount))
            return;
          this.m_tooManyPublishRequests = publishRequestCount;
          Utils.LogInfo("PUBLISH - Too many requests, set limit to GoodPublishRequestCount={0}.", (object) this.m_tooManyPublishRequests);
          return;
        case 2155413504 /*0x80790000*/:
          return;
        case 2156265472 /*0x80860000*/:
          return;
        default:
          Thread.Sleep(100);
          Utils.LogError(ex1, "PUBLISH #{0} - Unhandled error {1} during Publish.", (object) requestHeader.RequestHandle, (object) status.StatusCode);
          break;
      }
    }
    int publishRequestCount1 = this.GoodPublishRequestCount;
    int publishRequestCount2 = this.GetMinPublishRequestCount(false);
    if (publishRequestCount1 < publishRequestCount2)
      this.BeginPublish(this.OperationTimeout);
    else
      Utils.LogInfo("PUBLISH - Did not send another publish request. GoodPublishRequestCount={0}, MinPublishRequestCount={1}", (object) publishRequestCount1, (object) publishRequestCount2);
  }

  public bool Republish(uint subscriptionId, uint sequenceNumber)
  {
    RequestHeader requestHeader = new RequestHeader()
    {
      TimeoutHint = (uint) this.OperationTimeout,
      ReturnDiagnostics = (uint) this.ReturnDiagnostics,
      RequestHandle = Utils.IncrementIdentifier(ref this.m_publishCounter)
    };
    try
    {
      Utils.LogInfo("Requesting Republish for {0}-{1}", (object) subscriptionId, (object) sequenceNumber);
      NotificationMessage notificationMessage = (NotificationMessage) null;
      ResponseHeader responseHeader = this.Republish(requestHeader, subscriptionId, sequenceNumber, out notificationMessage);
      Utils.LogInfo("Received Republish for {0}-{1}-{2}", (object) subscriptionId, (object) sequenceNumber, (object) responseHeader.ServiceResult);
      this.ProcessPublishResponse(responseHeader, subscriptionId, (UInt32Collection) null, false, notificationMessage);
      return true;
    }
    catch (Exception ex)
    {
      return this.ProcessRepublishResponseError(ex, subscriptionId, sequenceNumber);
    }
  }

  public bool ResendData(IEnumerable<Subscription> subscriptions, out IList<ServiceResult> errors)
  {
    CallMethodRequestCollection requestsForResendData = this.CreateCallRequestsForResendData(subscriptions);
    errors = (IList<ServiceResult>) new List<ServiceResult>(requestsForResendData.Count);
    try
    {
      CallMethodResultCollection results;
      DiagnosticInfoCollection diagnosticInfos;
      ResponseHeader responseHeader = this.Call((RequestHeader) null, requestsForResendData, out results, out diagnosticInfos);
      ClientBase.ValidateResponse((IList) results, (IList) requestsForResendData);
      ClientBase.ValidateDiagnosticInfos(diagnosticInfos, (IList) requestsForResendData);
      int index = 0;
      foreach (CallMethodResult callMethodResult in (List<CallMethodResult>) results)
      {
        ServiceResult serviceResult = ServiceResult.Good;
        if (StatusCode.IsNotGood(callMethodResult.StatusCode))
          serviceResult = ClientBase.GetResult(callMethodResult.StatusCode, index, diagnosticInfos, responseHeader);
        errors.Add(serviceResult);
        ++index;
      }
      return true;
    }
    catch (ServiceResultException ex)
    {
      object[] objArray = Array.Empty<object>();
      Utils.LogError((Exception) ex, "Failed to call ResendData on server.", objArray);
    }
    return false;
  }

  private void OpenValidateIdentity(
    ref IUserIdentity identity,
    out UserIdentityToken identityToken,
    out UserTokenPolicy identityPolicy,
    out string securityPolicyUri,
    out bool requireEncryption)
  {
    lock (this.SyncRoot)
    {
      if (this.Connected)
        throw new ServiceResultException(2158952448U /*0x80AF0000*/, "Already connected to server.");
    }
    securityPolicyUri = this.m_endpoint.Description.SecurityPolicyUri;
    if (SecurityPolicies.GetDisplayName(securityPolicyUri) == null)
      throw ServiceResultException.Create(2148728832U /*0x80130000*/, "The chosen security policy is not supported by the client to connect to the server.");
    if (identity == null)
      identity = (IUserIdentity) new UserIdentity();
    identityToken = identity.GetIdentityToken();
    identityPolicy = this.m_endpoint.Description.FindUserTokenPolicy(identityToken.PolicyId);
    if (identityPolicy == null)
    {
      identityPolicy = this.m_endpoint.Description.FindUserTokenPolicy(identity.TokenType, identity.IssuedTokenType);
      if (identityPolicy == null)
        throw ServiceResultException.Create(2149515264U /*0x801F0000*/, "Endpoint does not support the user identity type provided.");
      identityToken.PolicyId = identityPolicy.PolicyId;
    }
    requireEncryption = securityPolicyUri != "http://opcfoundation.org/UA/SecurityPolicy#None";
    if (requireEncryption)
      return;
    requireEncryption = identityPolicy.SecurityPolicyUri != "http://opcfoundation.org/UA/SecurityPolicy#None" && !string.IsNullOrEmpty(identityPolicy.SecurityPolicyUri);
  }

  private void BuildCertificateData(
    out byte[] clientCertificateData,
    out byte[] clientCertificateChainData)
  {
    clientCertificateData = this.m_instanceCertificate != null ? this.m_instanceCertificate.RawData : (byte[]) null;
    clientCertificateChainData = (byte[]) null;
    if (this.m_instanceCertificateChain == null || this.m_instanceCertificateChain.Count <= 0 || !this.m_configuration.SecurityConfiguration.SendCertificateChain)
      return;
    List<byte> byteList = new List<byte>();
    for (int index = 0; index < this.m_instanceCertificateChain.Count; ++index)
      byteList.AddRange((IEnumerable<byte>) this.m_instanceCertificateChain[index].RawData);
    clientCertificateChainData = byteList.ToArray();
  }

  private void ValidateServerCertificateData(byte[] serverCertificateData)
  {
    if (serverCertificateData == null || this.m_endpoint.Description.ServerCertificate == null)
      return;
    if (Utils.IsEqual((object) serverCertificateData, (object) this.m_endpoint.Description.ServerCertificate))
      return;
    try
    {
      X509Certificate2Collection certificateChainBlob = Utils.ParseCertificateChainBlob(this.m_endpoint.Description.ServerCertificate);
      if (certificateChainBlob.Count > 0 && !Utils.IsEqual((object) serverCertificateData, (object) certificateChainBlob[0].RawData))
        throw ServiceResultException.Create(2148663296U /*0x80120000*/, "Server did not return the certificate used to create the secure channel.");
    }
    catch (Exception ex)
    {
      throw ServiceResultException.Create(2148663296U /*0x80120000*/, "Server did not return the certificate used to create the secure channel.");
    }
  }

  private void ValidateServerSignature(
    X509Certificate2 serverCertificate,
    SignatureData serverSignature,
    byte[] clientCertificateData,
    byte[] clientCertificateChainData,
    byte[] clientNonce)
  {
    if (serverSignature == null || serverSignature.Signature == null)
      Utils.LogInfo("Server signature is null or empty.");
    byte[] dataToVerify1 = Utils.Append(clientCertificateData, clientNonce);
    if (SecurityPolicies.Verify(serverCertificate, this.m_endpoint.Description.SecurityPolicyUri, dataToVerify1, serverSignature))
      return;
    byte[] dataToVerify2 = clientCertificateChainData != null ? Utils.Append(clientCertificateChainData, clientNonce) : throw ServiceResultException.Create(2153250816U /*0x80580000*/, "Server did not provide a correct signature for the nonce data provided by the client.");
    if (!SecurityPolicies.Verify(serverCertificate, this.m_endpoint.Description.SecurityPolicyUri, dataToVerify2, serverSignature))
      throw ServiceResultException.Create(2153250816U /*0x80580000*/, "Server did not provide a correct signature for the nonce data provided by the client.");
  }

  private void ValidateServerEndpoints(EndpointDescriptionCollection serverEndpoints)
  {
    if (this.m_discoveryServerEndpoints != null && this.m_discoveryServerEndpoints.Count > 0)
    {
      EndpointDescriptionCollection descriptionCollection;
      if (serverEndpoints != null && this.m_discoveryProfileUris != null && this.m_discoveryProfileUris.Count > 0)
      {
        descriptionCollection = new EndpointDescriptionCollection();
        foreach (EndpointDescription serverEndpoint in (List<EndpointDescription>) serverEndpoints)
        {
          if (this.m_discoveryProfileUris.Contains(serverEndpoint.TransportProfileUri))
            descriptionCollection.Add(serverEndpoint);
        }
      }
      else
        descriptionCollection = serverEndpoints;
      if (descriptionCollection == null || this.m_discoveryServerEndpoints.Count != descriptionCollection.Count)
        throw ServiceResultException.Create(2148728832U /*0x80130000*/, "Server did not return a number of ServerEndpoints that matches the one from GetEndpoints.");
      for (int index1 = 0; index1 < descriptionCollection.Count; ++index1)
      {
        EndpointDescription endpointDescription = descriptionCollection[index1];
        EndpointDescription discoveryServerEndpoint = this.m_discoveryServerEndpoints[index1];
        if (endpointDescription.SecurityMode != discoveryServerEndpoint.SecurityMode || endpointDescription.SecurityPolicyUri != discoveryServerEndpoint.SecurityPolicyUri || endpointDescription.TransportProfileUri != discoveryServerEndpoint.TransportProfileUri || (int) endpointDescription.SecurityLevel != (int) discoveryServerEndpoint.SecurityLevel)
          throw ServiceResultException.Create(2148728832U /*0x80130000*/, "The list of ServerEndpoints returned at CreateSession does not match the list from GetEndpoints.");
        if (endpointDescription.UserIdentityTokens.Count != discoveryServerEndpoint.UserIdentityTokens.Count)
          throw ServiceResultException.Create(2148728832U /*0x80130000*/, "The list of ServerEndpoints returned at CreateSession does not match the one from GetEndpoints.");
        for (int index2 = 0; index2 < endpointDescription.UserIdentityTokens.Count; ++index2)
        {
          if (!endpointDescription.UserIdentityTokens[index2].IsEqual((IEncodeable) discoveryServerEndpoint.UserIdentityTokens[index2]))
            throw ServiceResultException.Create(2148728832U /*0x80130000*/, "The list of ServerEndpoints returned at CreateSession does not match the one from GetEndpoints.");
        }
      }
    }
    bool flag = false;
    Uri uri1 = Utils.ParseUri(this.m_endpoint.Description.EndpointUrl);
    if (uri1 != (Uri) null)
    {
      for (int index = 0; index < serverEndpoints.Count; ++index)
      {
        EndpointDescription serverEndpoint = serverEndpoints[index];
        Uri uri2 = Utils.ParseUri(serverEndpoint.EndpointUrl);
        if (uri2 != (Uri) null && uri2.Scheme == uri1.Scheme && serverEndpoint.SecurityPolicyUri == this.m_endpoint.Description.SecurityPolicyUri && serverEndpoint.SecurityMode == this.m_endpoint.Description.SecurityMode)
        {
          this.m_endpoint.Description.Server.ApplicationName = serverEndpoint.Server.ApplicationName;
          this.m_endpoint.Description.Server.ApplicationUri = serverEndpoint.Server.ApplicationUri;
          this.m_endpoint.Description.Server.ApplicationType = serverEndpoint.Server.ApplicationType;
          this.m_endpoint.Description.Server.ProductUri = serverEndpoint.Server.ProductUri;
          this.m_endpoint.Description.TransportProfileUri = serverEndpoint.TransportProfileUri;
          this.m_endpoint.Description.UserIdentityTokens = serverEndpoint.UserIdentityTokens;
          flag = true;
          break;
        }
      }
    }
    if (!flag)
      throw ServiceResultException.Create(2148728832U /*0x80130000*/, "Server did not return an EndpointDescription that matched the one used to create the secure channel.");
  }

  private IAsyncResult PrepareReconnectBeginActivate(
    ITransportWaitingConnection connection,
    ITransportChannel transportChannel)
  {
    Utils.LogInfo("Session RECONNECT {0} starting.", (object) this.SessionId);
    lock (this.SyncRoot)
      this.StopKeepAliveTimer();
    byte[] dataToSign = Utils.Append(this.m_serverCertificate != null ? this.m_serverCertificate.RawData : (byte[]) null, this.m_serverNonce);
    EndpointDescription description = this.m_endpoint.Description;
    SignatureData clientSignature = SecurityPolicies.Sign(this.m_instanceCertificate, description.SecurityPolicyUri, dataToSign);
    UserTokenPolicy userTokenPolicy = description.FindUserTokenPolicy(this.m_identity.TokenType, this.m_identity.IssuedTokenType);
    if (userTokenPolicy == null)
    {
      Utils.LogError("Reconnect: Endpoint does not support the user identity type provided.");
      throw ServiceResultException.Create(2149515264U /*0x801F0000*/, "Endpoint does not support the user identity type provided.");
    }
    string securityPolicyUri = userTokenPolicy.SecurityPolicyUri;
    if (string.IsNullOrEmpty(securityPolicyUri))
      securityPolicyUri = description.SecurityPolicyUri;
    if (this.m_RenewUserIdentity != null)
      this.m_identity = this.m_RenewUserIdentity((ISession) this, this.m_identity);
    this.ValidateServerNonce(this.m_identity, this.m_serverNonce, securityPolicyUri, this.m_previousServerNonce, this.m_endpoint.Description.SecurityMode);
    UserIdentityToken identityToken = this.m_identity.GetIdentityToken();
    identityToken.PolicyId = userTokenPolicy.PolicyId;
    SignatureData userTokenSignature = identityToken.Sign(dataToSign, securityPolicyUri);
    identityToken.Encrypt(this.m_serverCertificate, this.m_serverNonce, securityPolicyUri);
    this.GetSoftwareCertificates();
    Utils.LogInfo("Session REPLACING channel for {0}.", (object) this.SessionId);
    if (connection != null)
    {
      if ((this.TransportChannel.SupportedFeatures & TransportChannelFeatures.Reconnect) != TransportChannelFeatures.None)
        this.TransportChannel.Reconnect(connection);
      else
        this.TransportChannel = SessionChannel.Create(this.m_configuration, connection, this.m_endpoint.Description, this.m_endpoint.Configuration, this.m_instanceCertificate, this.m_configuration.SecurityConfiguration.SendCertificateChain ? this.m_instanceCertificateChain : (X509Certificate2Collection) null, this.MessageContext);
    }
    else if (transportChannel != null)
      this.TransportChannel = transportChannel;
    else if (this.TransportChannel != null && (this.TransportChannel.SupportedFeatures & TransportChannelFeatures.Reconnect) != TransportChannelFeatures.None)
      this.TransportChannel.Reconnect();
    else
      this.TransportChannel = SessionChannel.Create(this.m_configuration, this.m_endpoint.Description, this.m_endpoint.Configuration, this.m_instanceCertificate, this.m_configuration.SecurityConfiguration.SendCertificateChain ? this.m_instanceCertificateChain : (X509Certificate2Collection) null, this.MessageContext);
    Utils.LogInfo("Session RE-ACTIVATING {0}.", (object) this.SessionId);
    return this.BeginActivateSession(new RequestHeader()
    {
      TimeoutHint = 15000U
    }, clientSignature, (SignedSoftwareCertificateCollection) null, this.m_preferredLocales, new ExtensionObject((object) identityToken), userTokenSignature, (AsyncCallback) null, (object) null);
  }

  private bool ProcessRepublishResponseError(Exception e, uint subscriptionId, uint sequenceNumber)
  {
    ServiceResult status = new ServiceResult(e);
    bool flag = true;
    switch (status.StatusCode.Code)
    {
      case 2148007936 /*0x80080000*/:
        Utils.LogError(e, "Message {0}-{1} exceeded size limits, ignored.", (object) subscriptionId, (object) sequenceNumber);
        SubscriptionAcknowledgement subscriptionAcknowledgement = new SubscriptionAcknowledgement()
        {
          SubscriptionId = subscriptionId,
          SequenceNumber = sequenceNumber
        };
        lock (this.SyncRoot)
        {
          this.m_acknowledgementsToSend.Add(subscriptionAcknowledgement);
          break;
        }
      case 2155544576 /*0x807B0000*/:
        Utils.LogWarning("Message {0}-{1} no longer available.", (object) subscriptionId, (object) sequenceNumber);
        break;
      default:
        flag = false;
        Utils.LogError(e, "Unexpected error sending republish request.");
        break;
    }
    PublishErrorEventHandler errorEventHandler = (PublishErrorEventHandler) null;
    lock (this.m_eventLock)
      errorEventHandler = this.m_PublishError;
    if (errorEventHandler != null)
    {
      try
      {
        PublishErrorEventArgs e1 = new PublishErrorEventArgs(status, subscriptionId, sequenceNumber);
        errorEventHandler((ISession) this, e1);
      }
      catch (Exception ex)
      {
        object[] objArray = Array.Empty<object>();
        Utils.LogError(ex, "Session: Unexpected error invoking PublishErrorCallback.", objArray);
      }
    }
    return flag;
  }

  private void HandleSignedSoftwareCertificates(
    SignedSoftwareCertificateCollection serverSoftwareCertificates)
  {
    CertificateValidator certificateValidator = this.m_configuration.CertificateValidator;
    List<SoftwareCertificate> softwareCertificates = new List<SoftwareCertificate>();
    foreach (SignedSoftwareCertificate softwareCertificate1 in (List<SignedSoftwareCertificate>) serverSoftwareCertificates)
    {
      SoftwareCertificate softwareCertificate2 = (SoftwareCertificate) null;
      ServiceResult serviceResult = SoftwareCertificate.Validate(certificateValidator, softwareCertificate1.CertificateData, out softwareCertificate2);
      if (ServiceResult.IsBad(serviceResult))
        this.OnSoftwareCertificateError(softwareCertificate1, serviceResult);
      softwareCertificates.Add(softwareCertificate2);
    }
    this.ValidateSoftwareCertificates(softwareCertificates);
  }

  private void ProcessPublishResponse(
    ResponseHeader responseHeader,
    uint subscriptionId,
    UInt32Collection availableSequenceNumbers,
    bool moreNotifications,
    NotificationMessage notificationMessage)
  {
    Subscription subscription1 = (Subscription) null;
    this.OnKeepAlive(this.m_serverState, responseHeader.Timestamp);
    lock (this.SyncRoot)
    {
      SubscriptionAcknowledgementCollection acknowledgementCollection = new SubscriptionAcknowledgementCollection();
      for (int index = 0; index < this.m_acknowledgementsToSend.Count; ++index)
      {
        SubscriptionAcknowledgement subscriptionAcknowledgement = this.m_acknowledgementsToSend[index];
        if ((int) subscriptionAcknowledgement.SubscriptionId != (int) subscriptionId)
          acknowledgementCollection.Add(subscriptionAcknowledgement);
        else if (availableSequenceNumbers == null || availableSequenceNumbers.Contains(subscriptionAcknowledgement.SequenceNumber))
          acknowledgementCollection.Add(subscriptionAcknowledgement);
      }
      if (notificationMessage.NotificationData.Count > 0)
        acknowledgementCollection.Add(new SubscriptionAcknowledgement()
        {
          SubscriptionId = subscriptionId,
          SequenceNumber = notificationMessage.SequenceNumber
        });
      if (availableSequenceNumbers != null)
      {
        foreach (SubscriptionAcknowledgement subscriptionAcknowledgement in (List<SubscriptionAcknowledgement>) acknowledgementCollection)
        {
          if ((int) subscriptionAcknowledgement.SubscriptionId == (int) subscriptionId && !availableSequenceNumbers.Contains(subscriptionAcknowledgement.SequenceNumber))
            Utils.LogWarning("Sequence number={0} was not received in the available sequence numbers.", (object) subscriptionAcknowledgement.SequenceNumber);
        }
      }
      this.m_acknowledgementsToSend = acknowledgementCollection;
      if (notificationMessage.IsEmpty)
        Utils.LogTrace("Empty notification message received for SessionId {0} with PublishTime {1}", (object) this.SessionId, (object) notificationMessage.PublishTime.ToLocalTime());
      foreach (Subscription subscription2 in this.m_subscriptions)
      {
        if ((int) subscription2.Id == (int) subscriptionId)
        {
          subscription1 = subscription2;
          break;
        }
      }
    }
    if (subscription1 != null)
    {
      if (notificationMessage.PublishTime.AddMilliseconds(subscription1.CurrentPublishingInterval * (double) subscription1.CurrentLifetimeCount) < DateTime.UtcNow)
        Utils.LogTrace("PublishTime {0} in publish response is too old for SubscriptionId {1}.", (object) notificationMessage.PublishTime.ToLocalTime(), (object) subscription1.Id);
      DateTime publishTime = notificationMessage.PublishTime;
      DateTime dateTime1 = DateTime.UtcNow;
      DateTime dateTime2 = dateTime1.AddMilliseconds(subscription1.CurrentPublishingInterval * (double) subscription1.CurrentLifetimeCount);
      if (publishTime > dateTime2)
      {
        object[] objArray = new object[2];
        dateTime1 = notificationMessage.PublishTime;
        objArray[0] = (object) dateTime1.ToLocalTime();
        objArray[1] = (object) subscription1.Id;
        Utils.LogTrace("PublishTime {0} in publish response is newer than actual time for SubscriptionId {1}.", objArray);
      }
      subscription1.SaveMessageInCache((IList<uint>) availableSequenceNumbers, notificationMessage, (IList<string>) responseHeader.StringTable);
      lock (this.m_eventLock)
      {
        NotificationEventArgs args = new NotificationEventArgs(subscription1, notificationMessage, (IList<string>) responseHeader.StringTable);
        if (this.m_Publish == null)
          return;
        Task.Run((Action) (() => this.OnRaisePublishNotification((object) args)));
      }
    }
    else if (this.m_deleteSubscriptionsOnClose && !this.m_reconnecting)
    {
      Utils.LogWarning("Received Publish Response for Unknown SubscriptionId={0}. Deleting abandoned subscription from server.", (object) subscriptionId);
      Task.Run((Action) (() => this.DeleteSubscription(subscriptionId)));
    }
    else
      Utils.LogWarning("Received Publish Response for Unknown SubscriptionId={0}. Ignored.", (object) subscriptionId);
  }

  private void RecreateSubscriptions(IEnumerable<Subscription> subscriptionsTemplate)
  {
    bool flag = false;
    if (this.TransferSubscriptionsOnReconnect)
    {
      try
      {
        flag = this.TransferSubscriptions(new SubscriptionCollection(subscriptionsTemplate), false);
      }
      catch (ServiceResultException ex)
      {
        if (ex.StatusCode == 2148204544U /*0x800B0000*/)
        {
          this.TransferSubscriptionsOnReconnect = false;
          Utils.LogWarning("Transfer subscription unsupported, TransferSubscriptionsOnReconnect set to false.");
        }
        else
          Utils.LogError((Exception) ex, "Transfer subscriptions failed.");
      }
      catch (Exception ex)
      {
        object[] objArray = Array.Empty<object>();
        Utils.LogError(ex, "Unexpected Transfer subscriptions error.", objArray);
      }
    }
    if (flag)
      return;
    foreach (Subscription subscription in this.Subscriptions)
    {
      if (!subscription.Created)
        subscription.Create();
    }
  }

  private void OnRaisePublishNotification(object state)
  {
    try
    {
      NotificationEventArgs e = (NotificationEventArgs) state;
      NotificationEventHandler publish = this.m_Publish;
      if (publish == null || e.Subscription.Id == 0U)
        return;
      publish((ISession) this, e);
    }
    catch (Exception ex)
    {
      object[] objArray = Array.Empty<object>();
      Utils.LogError(ex, "Session: Unexpected error while raising Notification event.", objArray);
    }
  }

  private void DeleteSubscription(uint subscriptionId)
  {
    try
    {
      Utils.LogInfo("Deleting server subscription for SubscriptionId={0}", (object) subscriptionId);
      UInt32Collection uint32Collection = (UInt32Collection) new uint[1]
      {
        subscriptionId
      };
      StatusCodeCollection results;
      DiagnosticInfoCollection diagnosticInfos;
      ResponseHeader responseHeader = this.DeleteSubscriptions((RequestHeader) null, uint32Collection, out results, out diagnosticInfos);
      ClientBase.ValidateResponse((IList) results, (IList) uint32Collection);
      ClientBase.ValidateDiagnosticInfos(diagnosticInfos, (IList) uint32Collection);
      if (StatusCode.IsBad(results[0]))
        throw new ServiceResultException(ClientBase.GetResult(results[0], 0, diagnosticInfos, responseHeader));
    }
    catch (Exception ex)
    {
      object[] objArray = new object[1]
      {
        (object) subscriptionId
      };
      Utils.LogError(ex, "Session: Unexpected error while deleting subscription for SubscriptionId={0}.", objArray);
    }
  }

  private static async Task<X509Certificate2> LoadCertificate(ApplicationConfiguration configuration)
  {
    if (configuration.SecurityConfiguration.ApplicationCertificate == null)
      throw ServiceResultException.Create(2156462080U /*0x80890000*/, "ApplicationCertificate must be specified.");
    return await configuration.SecurityConfiguration.ApplicationCertificate.Find(true).ConfigureAwait(false) ?? throw ServiceResultException.Create(2156462080U /*0x80890000*/, "ApplicationCertificate cannot be found.");
  }

  private static async Task<X509Certificate2Collection> LoadCertificateChain(
    ApplicationConfiguration configuration,
    X509Certificate2 clientCertificate)
  {
    X509Certificate2Collection clientCertificateChain = (X509Certificate2Collection) null;
    if (configuration.SecurityConfiguration.SendCertificateChain)
    {
      clientCertificateChain = new X509Certificate2Collection(clientCertificate);
      List<CertificateIdentifier> issuers = new List<CertificateIdentifier>();
      int num = await configuration.CertificateValidator.GetIssuers(clientCertificate, issuers).ConfigureAwait(false) ? 1 : 0;
      for (int index = 0; index < issuers.Count; ++index)
        clientCertificateChain.Add(issuers[index].Certificate);
      issuers = (List<CertificateIdentifier>) null;
    }
    X509Certificate2Collection certificate2Collection = clientCertificateChain;
    clientCertificateChain = (X509Certificate2Collection) null;
    return certificate2Collection;
  }

  private bool HasAnyContinuationPoint(ByteStringCollection continuationPoints)
  {
    foreach (byte[] continuationPoint in (List<byte[]>) continuationPoints)
    {
      if (continuationPoint != null)
        return true;
    }
    return false;
  }

  private bool BelowPublishRequestLimit(int requestCount)
  {
    return this.m_tooManyPublishRequests == 0 || requestCount < this.m_tooManyPublishRequests;
  }

  private int GetMinPublishRequestCount(bool createdOnly)
  {
    lock (this.SyncRoot)
    {
      if (this.m_subscriptions.Count == 0)
        return 0;
      if (!createdOnly)
        return Math.Max(this.m_subscriptions.Count, this.m_minPublishRequestCount);
      int val1 = 0;
      foreach (Subscription subscription in this.m_subscriptions)
      {
        if (subscription.Created)
          ++val1;
      }
      return val1 == 0 ? 0 : Math.Max(val1, this.m_minPublishRequestCount);
    }
  }

  private CallMethodRequestCollection CreateCallRequestsForResendData(
    IEnumerable<Subscription> subscriptions)
  {
    CallMethodRequestCollection requestsForResendData = new CallMethodRequestCollection();
    foreach (Subscription subscription in subscriptions)
    {
      VariantCollection variantCollection1 = new VariantCollection();
      variantCollection1.Add(new Opc.Ua.Variant(subscription.Id));
      VariantCollection variantCollection2 = variantCollection1;
      CallMethodRequest callMethodRequest = new CallMethodRequest()
      {
        ObjectId = ObjectIds.Server,
        MethodId = MethodIds.Server_ResendData,
        InputArguments = variantCollection2
      };
      requestsForResendData.Add(callMethodRequest);
    }
    return requestsForResendData;
  }

  private void RestartPublishing()
  {
    int num = 0;
    lock (this.SyncRoot)
      num = this.GetMinPublishRequestCount(true);
    for (int index = 0; index < num; ++index)
      this.BeginPublish(this.OperationTimeout);
  }

  private UInt32Collection CreateSubscriptionIdsForTransfer(SubscriptionCollection subscriptions)
  {
    UInt32Collection subscriptionIdsForTransfer = new UInt32Collection();
    lock (this.SyncRoot)
    {
      foreach (Subscription subscription in (List<Subscription>) subscriptions)
      {
        if (!subscription.Created || !this.SessionId.Equals(subscription.Session.SessionId))
        {
          if (subscription.TransferId == 0U)
            throw new ServiceResultException(2158952448U /*0x80AF0000*/, Utils.Format("A subscription can not be transferred due to missing transfer Id."));
          subscriptionIdsForTransfer.Add(subscription.TransferId);
        }
        else
          throw new ServiceResultException(2158952448U /*0x80AF0000*/, Utils.Format("The subscriptionId {0} is already created.", (object) subscription.Id));
      }
    }
    return subscriptionIdsForTransfer;
  }

  private void IndicateSessionConfigurationChanged()
  {
    if (this.m_SessionConfigurationChanged == null)
      return;
    try
    {
      this.m_SessionConfigurationChanged((object) this, EventArgs.Empty);
    }
    catch (Exception ex)
    {
      Utils.Trace(ex, "Unexpected error calling SessionConfigurationChanged event handler.");
    }
  }

  private event KeepAliveEventHandler m_KeepAlive;

  private event NotificationEventHandler m_Publish;

  private event PublishErrorEventHandler m_PublishError;

  private event PublishSequenceNumbersToAcknowledgeEventHandler m_PublishSequenceNumbersToAcknowledge;

  private event EventHandler m_SubscriptionsChanged;

  private event EventHandler m_SessionClosing;

  private event EventHandler m_SessionConfigurationChanged;

  public Task OpenAsync(string sessionName, IUserIdentity identity, CancellationToken ct)
  {
    return this.OpenAsync(sessionName, 0U, identity, (IList<string>) null, ct);
  }

  public Task OpenAsync(
    string sessionName,
    uint sessionTimeout,
    IUserIdentity identity,
    IList<string> preferredLocales,
    CancellationToken ct)
  {
    return this.OpenAsync(sessionName, sessionTimeout, identity, preferredLocales, true, ct);
  }

  public async Task OpenAsync(
    string sessionName,
    uint sessionTimeout,
    IUserIdentity identity,
    IList<string> preferredLocales,
    bool checkDomain,
    CancellationToken ct)
  {
    Session session = this;
    UserIdentityToken identityToken;
    UserTokenPolicy identityPolicy;
    string securityPolicyUri;
    bool requireEncryption;
    session.OpenValidateIdentity(ref identity, out identityToken, out identityPolicy, out securityPolicyUri, out requireEncryption);
    X509Certificate2 serverCertificate = (X509Certificate2) null;
    byte[] serverCertificate1 = session.m_endpoint.Description.ServerCertificate;
    if (serverCertificate1 != null && serverCertificate1.Length != 0)
    {
      X509Certificate2Collection certificateChainBlob = Utils.ParseCertificateChainBlob(serverCertificate1);
      if (certificateChainBlob.Count > 0)
        serverCertificate = certificateChainBlob[0];
      if (requireEncryption)
      {
        if (checkDomain)
          await session.m_configuration.CertificateValidator.ValidateAsync(certificateChainBlob, session.m_endpoint, ct).ConfigureAwait(false);
        else
          await session.m_configuration.CertificateValidator.ValidateAsync(certificateChainBlob, ct).ConfigureAwait(false);
        session.m_checkDomain = checkDomain;
      }
    }
    byte[] clientNonce = Utils.Nonce.CreateNonce((uint) session.m_configuration.SecurityConfiguration.NonceLength);
    byte[] clientCertificateData;
    byte[] clientCertificateChainData;
    session.BuildCertificateData(out clientCertificateData, out clientCertificateChainData);
    ApplicationDescription clientDescription = new ApplicationDescription()
    {
      ApplicationUri = session.m_configuration.ApplicationUri,
      ApplicationName = (LocalizedText) session.m_configuration.ApplicationName,
      ApplicationType = ApplicationType.Client,
      ProductUri = session.m_configuration.ProductUri
    };
    if (sessionTimeout == 0U)
      sessionTimeout = (uint) session.m_configuration.ClientConfiguration.DefaultSessionTimeout;
    bool flag = false;
    CreateSessionResponse response = (CreateSessionResponse) null;
    if (session.m_endpoint.Description.SecurityPolicyUri == "http://opcfoundation.org/UA/SecurityPolicy#None")
    {
      try
      {
        // ISSUE: explicit non-virtual call
        // ISSUE: reference to a compiler-generated method
        response = await session.\u003C\u003En__0((RequestHeader) null, clientDescription, session.m_endpoint.Description.Server.ApplicationUri, session.m_endpoint.EndpointUrl.ToString(), sessionName, clientNonce, (byte[]) null, (double) sessionTimeout, (uint) __nonvirtual (session.MessageContext).MaxMessageSize, ct).ConfigureAwait(false);
        flag = true;
      }
      catch (Exception ex)
      {
        Utils.LogInfo("Create session failed with client certificate NULL. " + ex.Message);
        flag = false;
      }
    }
    if (!flag)
    {
      // ISSUE: explicit non-virtual call
      // ISSUE: reference to a compiler-generated method
      response = await session.\u003C\u003En__0((RequestHeader) null, clientDescription, session.m_endpoint.Description.Server.ApplicationUri, session.m_endpoint.EndpointUrl.ToString(), sessionName, clientNonce, clientCertificateChainData != null ? clientCertificateChainData : clientCertificateData, (double) sessionTimeout, (uint) __nonvirtual (session.MessageContext).MaxMessageSize, ct).ConfigureAwait(false);
    }
    NodeId sessionId = response.SessionId;
    NodeId authenticationToken = response.AuthenticationToken;
    byte[] serverNonce = response.ServerNonce;
    byte[] serverCertificate2 = response.ServerCertificate;
    SignatureData serverSignature = response.ServerSignature;
    EndpointDescriptionCollection serverEndpoints = response.ServerEndpoints;
    SignedSoftwareCertificateCollection softwareCertificates1 = response.ServerSoftwareCertificates;
    session.m_sessionTimeout = response.RevisedSessionTimeout;
    session.m_maxRequestMessageSize = response.MaxRequestMessageSize;
    lock (session.SyncRoot)
    {
      // ISSUE: reference to a compiler-generated method
      session.\u003C\u003En__1(sessionId, authenticationToken);
    }
    Utils.LogInfo("Revised session timeout value: {0}. ", (object) session.m_sessionTimeout);
    // ISSUE: explicit non-virtual call
    Utils.LogInfo("Max response message size value: {0}. Max request message size: {1} ", (object) __nonvirtual (session.MessageContext).MaxMessageSize, (object) session.m_maxRequestMessageSize);
    try
    {
      session.ValidateServerCertificateData(serverCertificate2);
      session.ValidateServerEndpoints(serverEndpoints);
      session.ValidateServerSignature(serverCertificate, serverSignature, clientCertificateData, clientCertificateChainData, clientNonce);
      session.HandleSignedSoftwareCertificates(softwareCertificates1);
      byte[] dataToSign = Utils.Append(serverCertificate != null ? serverCertificate.RawData : (byte[]) null, serverNonce);
      SignatureData clientSignature = SecurityPolicies.Sign(session.m_instanceCertificate, securityPolicyUri, dataToSign);
      securityPolicyUri = identityPolicy.SecurityPolicyUri;
      if (string.IsNullOrEmpty(securityPolicyUri))
        securityPolicyUri = session.m_endpoint.Description.SecurityPolicyUri;
      byte[] previousServerNonce = (byte[]) null;
      // ISSUE: explicit non-virtual call
      if (__nonvirtual (session.TransportChannel).CurrentToken != null)
      {
        // ISSUE: explicit non-virtual call
        previousServerNonce = __nonvirtual (session.TransportChannel).CurrentToken.ServerNonce;
      }
      session.ValidateServerNonce(identity, serverNonce, securityPolicyUri, previousServerNonce, session.m_endpoint.Description.SecurityMode);
      SignatureData userTokenSignature = identityToken.Sign(dataToSign, securityPolicyUri);
      identityToken.Encrypt(serverCertificate, serverNonce, securityPolicyUri);
      SignedSoftwareCertificateCollection softwareCertificates2 = session.GetSoftwareCertificates();
      if (preferredLocales != null && preferredLocales.Count > 0)
        session.m_preferredLocales = new StringCollection((IEnumerable<string>) preferredLocales);
      ActivateSessionResponse activateSessionResponse = await session.ActivateSessionAsync((RequestHeader) null, clientSignature, softwareCertificates2, session.m_preferredLocales, new ExtensionObject((object) identityToken), userTokenSignature, ct).ConfigureAwait(false);
      serverNonce = activateSessionResponse.ServerNonce;
      StatusCodeCollection results = activateSessionResponse.Results;
      DiagnosticInfoCollection diagnosticInfos = activateSessionResponse.DiagnosticInfos;
      if (results != null)
      {
        for (int index = 0; index < results.Count; ++index)
          Utils.LogInfo("ActivateSession result[{0}] = {1}", (object) index, (object) results[index]);
      }
      if (results == null || results.Count == 0)
        Utils.LogInfo("Empty results were received for the ActivateSession call.");
      // ISSUE: explicit non-virtual call
      await __nonvirtual (session.FetchNamespaceTablesAsync(ct)).ConfigureAwait(false);
      lock (session.SyncRoot)
      {
        session.m_sessionName = sessionName;
        session.m_identity = identity;
        session.m_previousServerNonce = previousServerNonce;
        session.m_serverNonce = serverNonce;
        session.m_serverCertificate = serverCertificate;
        session.m_systemContext.PreferredLocales = (IList<string>) session.m_preferredLocales;
        // ISSUE: explicit non-virtual call
        session.m_systemContext.SessionId = __nonvirtual (session.SessionId);
        session.m_systemContext.UserIdentity = identity;
      }
      await session.FetchOperationLimitsAsync(ct).ConfigureAwait(false);
      session.StartKeepAliveTimer();
      session.IndicateSessionConfigurationChanged();
      previousServerNonce = (byte[]) null;
    }
    catch (Exception ex1)
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        CloseSessionResponse closeSessionResponse = await session.\u003C\u003En__2((RequestHeader) null, false, ct).ConfigureAwait(false);
        session.CloseChannel();
      }
      catch (Exception ex2)
      {
        Utils.LogError("Cleanup: CloseSession() or CloseChannel() raised exception. " + ex2.Message);
      }
      finally
      {
        session.SessionCreated((NodeId) null, (NodeId) null);
      }
      throw;
    }
    identityToken = (UserIdentityToken) null;
    identityPolicy = (UserTokenPolicy) null;
    securityPolicyUri = (string) null;
    serverCertificate = (X509Certificate2) null;
    clientNonce = (byte[]) null;
    clientCertificateData = (byte[]) null;
    clientCertificateChainData = (byte[]) null;
    clientDescription = (ApplicationDescription) null;
    response = (CreateSessionResponse) null;
    serverNonce = (byte[]) null;
  }

  public async Task<bool> RemoveSubscriptionAsync(Subscription subscription, CancellationToken ct = default (CancellationToken))
  {
    Session sender = this;
    if (subscription == null)
      throw new ArgumentNullException(nameof (subscription));
    if (subscription.Created)
      await subscription.DeleteAsync(false, ct).ConfigureAwait(false);
    lock (sender.SyncRoot)
    {
      if (!sender.m_subscriptions.Remove(subscription))
        return false;
      subscription.Session = (ISession) null;
    }
    if (sender.m_SubscriptionsChanged != null)
      sender.m_SubscriptionsChanged((object) sender, (EventArgs) null);
    return true;
  }

  public async Task<bool> RemoveSubscriptionsAsync(
    IEnumerable<Subscription> subscriptions,
    CancellationToken ct = default (CancellationToken))
  {
    Session sender = this;
    if (subscriptions == null)
      throw new ArgumentNullException(nameof (subscriptions));
    List<Subscription> subscriptionsToDelete = new List<Subscription>();
    bool removed = sender.PrepareSubscriptionsToDelete(subscriptions, (IList<Subscription>) subscriptionsToDelete);
    foreach (Subscription subscription in subscriptionsToDelete)
    {
      ConfiguredTaskAwaitable.ConfiguredTaskAwaiter awaiter = subscription.DeleteAsync(true, ct).ConfigureAwait(false).GetAwaiter();
      if (awaiter.IsCompleted)
      {
        awaiter.GetResult();
      }
      else
      {
        // ISSUE: explicit reference operation
        // ISSUE: reference to a compiler-generated field
        (^this).\u003C\u003E1__state = 0;
        ConfiguredTaskAwaitable.ConfiguredTaskAwaiter configuredTaskAwaiter = awaiter;
        // ISSUE: explicit reference operation
        // ISSUE: reference to a compiler-generated field
        (^this).\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ConfiguredTaskAwaitable.ConfiguredTaskAwaiter, Session.\u003CRemoveSubscriptionsAsync\u003Ed__288>(ref awaiter, this);
        return;
      }
    }
    if (removed && sender.m_SubscriptionsChanged != null)
      sender.m_SubscriptionsChanged((object) sender, (EventArgs) null);
    return removed;
  }

  public async Task<bool> ReactivateSubscriptionsAsync(
    SubscriptionCollection subscriptions,
    bool sendInitialValues,
    CancellationToken ct = default (CancellationToken))
  {
    Session session = this;
    UInt32Collection subscriptionIds = session.CreateSubscriptionIdsForTransfer(subscriptions);
    int failedSubscriptions = 0;
    if (subscriptionIds.Count <= 0)
    {
      Utils.LogInfo("No subscriptions. Transfersubscription skipped.");
    }
    else
    {
      await session.m_reconnectLock.WaitAsync(ct).ConfigureAwait(false);
      try
      {
        session.m_reconnecting = true;
        for (int ii = 0; ii < subscriptions.Count; ++ii)
        {
          if (await subscriptions[ii].TransferAsync((ISession) session, subscriptionIds[ii], new UInt32Collection(), ct).ConfigureAwait(false))
            continue;
          Utils.LogError("SubscriptionId {0} failed to reactivate.", (object) subscriptionIds[ii]);
          ++failedSubscriptions;
        }
        if (sendInitialValues)
        {
          // ISSUE: explicit non-virtual call
          (bool flag, IList<ServiceResult> serviceResultList) = await __nonvirtual (session.ResendDataAsync((IEnumerable<Subscription>) subscriptions, ct)).ConfigureAwait(false);
          if (!flag)
            Utils.LogError("Failed to call resend data for subscriptions.");
          else if (serviceResultList != null)
          {
            for (int index = 0; index < serviceResultList.Count; ++index)
            {
              if (StatusCode.IsNotGood(serviceResultList[index].StatusCode))
                Utils.LogError("SubscriptionId {0} failed to resend data.", (object) subscriptionIds[index]);
            }
          }
        }
        Utils.LogInfo("Session REACTIVATE of {0} subscriptions completed. {1} failed.", (object) subscriptions.Count, (object) failedSubscriptions);
      }
      finally
      {
        session.m_reconnecting = false;
        session.m_reconnectLock.Release();
      }
      session.RestartPublishing();
    }
    bool flag1 = failedSubscriptions == 0;
    subscriptionIds = (UInt32Collection) null;
    return flag1;
  }

  public async Task<(bool, IList<ServiceResult>)> ResendDataAsync(
    IEnumerable<Subscription> subscriptions,
    CancellationToken ct)
  {
    Session session = this;
    CallMethodRequestCollection requests = session.CreateCallRequestsForResendData(subscriptions);
    IList<ServiceResult> errors = (IList<ServiceResult>) new List<ServiceResult>(requests.Count);
    try
    {
      CallResponse callResponse = await session.CallAsync((RequestHeader) null, requests, ct).ConfigureAwait(false);
      CallMethodResultCollection results = callResponse.Results;
      DiagnosticInfoCollection diagnosticInfos = callResponse.DiagnosticInfos;
      ResponseHeader responseHeader = callResponse.ResponseHeader;
      ClientBase.ValidateResponse((IList) results, (IList) requests);
      ClientBase.ValidateDiagnosticInfos(diagnosticInfos, (IList) requests);
      int index = 0;
      foreach (CallMethodResult callMethodResult in (List<CallMethodResult>) results)
      {
        ServiceResult serviceResult = ServiceResult.Good;
        if (StatusCode.IsNotGood(callMethodResult.StatusCode))
          serviceResult = ClientBase.GetResult(callMethodResult.StatusCode, index, diagnosticInfos, responseHeader);
        errors.Add(serviceResult);
        ++index;
      }
      return (true, errors);
    }
    catch (ServiceResultException ex)
    {
      object[] objArray = Array.Empty<object>();
      Utils.LogError((Exception) ex, "Failed to call ResendData on server.", objArray);
    }
    return (false, errors);
  }

  public async Task<bool> TransferSubscriptionsAsync(
    SubscriptionCollection subscriptions,
    bool sendInitialValues,
    CancellationToken ct)
  {
    Session session = this;
    UInt32Collection subscriptionIds = session.CreateSubscriptionIdsForTransfer(subscriptions);
    int failedSubscriptions = 0;
    if (subscriptionIds.Count <= 0)
    {
      Utils.LogInfo("No subscriptions. Transfersubscription skipped.");
    }
    else
    {
      await session.m_reconnectLock.WaitAsync(ct).ConfigureAwait(false);
      try
      {
        session.m_reconnecting = true;
        // ISSUE: reference to a compiler-generated method
        TransferSubscriptionsResponse subscriptionsResponse = await session.\u003C\u003En__3((RequestHeader) null, subscriptionIds, sendInitialValues, ct).ConfigureAwait(false);
        TransferResultCollection results = subscriptionsResponse.Results;
        DiagnosticInfoCollection diagnosticInfos = subscriptionsResponse.DiagnosticInfos;
        ResponseHeader responseHeader = subscriptionsResponse.ResponseHeader;
        if (!StatusCode.IsGood(responseHeader.ServiceResult))
        {
          Utils.LogError("TransferSubscription failed: {0}", (object) responseHeader.ServiceResult);
          return false;
        }
        ClientBase.ValidateResponse((IList) results, (IList) subscriptionIds);
        ClientBase.ValidateDiagnosticInfos(diagnosticInfos, (IList) subscriptionIds);
        for (int ii = 0; ii < subscriptions.Count; ++ii)
        {
          if (StatusCode.IsGood(results[ii].StatusCode))
          {
            ConfiguredTaskAwaitable<bool>.ConfiguredTaskAwaiter awaiter = subscriptions[ii].TransferAsync((ISession) session, subscriptionIds[ii], results[ii].AvailableSequenceNumbers, ct).ConfigureAwait(false).GetAwaiter();
            if (awaiter.IsCompleted)
            {
              if (awaiter.GetResult())
              {
                lock (session.SyncRoot)
                {
                  foreach (uint availableSequenceNumber in (List<uint>) results[ii].AvailableSequenceNumbers)
                  {
                    SubscriptionAcknowledgement subscriptionAcknowledgement = new SubscriptionAcknowledgement()
                    {
                      SubscriptionId = subscriptionIds[ii],
                      SequenceNumber = availableSequenceNumber
                    };
                    session.m_acknowledgementsToSend.Add(subscriptionAcknowledgement);
                  }
                }
              }
            }
            else
            {
              // ISSUE: explicit reference operation
              // ISSUE: reference to a compiler-generated field
              (^this).\u003C\u003E1__state = 2;
              ConfiguredTaskAwaitable<bool>.ConfiguredTaskAwaiter configuredTaskAwaiter = awaiter;
              // ISSUE: explicit reference operation
              // ISSUE: reference to a compiler-generated field
              (^this).\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ConfiguredTaskAwaitable<bool>.ConfiguredTaskAwaiter, Session.\u003CTransferSubscriptionsAsync\u003Ed__291>(ref awaiter, this);
              return;
            }
          }
          else if (results[ii].StatusCode == 2148466688U /*0x800F0000*/)
          {
            Utils.LogInfo("SubscriptionId {0} is already member of the session.", (object) subscriptionIds[ii]);
            ++failedSubscriptions;
          }
          else
          {
            Utils.LogError("SubscriptionId {0} failed to transfer, StatusCode={1}", (object) subscriptionIds[ii], (object) results[ii].StatusCode);
            ++failedSubscriptions;
          }
        }
        Utils.LogInfo("Session TRANSFER ASYNC of {0} subscriptions completed. {1} failed.", (object) subscriptions.Count, (object) failedSubscriptions);
        results = (TransferResultCollection) null;
      }
      finally
      {
        session.m_reconnecting = false;
        session.m_reconnectLock.Release();
      }
      session.RestartPublishing();
    }
    return failedSubscriptions == 0;
  }

  public async Task FetchNamespaceTablesAsync(CancellationToken ct = default (CancellationToken))
  {
    Session session = this;
    ReadValueIdCollection nodesToRead = session.PrepareNamespaceTableNodesToRead();
    ReadResponse readResponse = await session.ReadAsync((RequestHeader) null, 0.0, TimestampsToReturn.Neither, nodesToRead, ct).ConfigureAwait(false);
    DataValueCollection results = readResponse.Results;
    DiagnosticInfoCollection diagnosticInfos = readResponse.DiagnosticInfos;
    ResponseHeader responseHeader = readResponse.ResponseHeader;
    ClientBase.ValidateResponse((IList) results, (IList) nodesToRead);
    ClientBase.ValidateDiagnosticInfos(diagnosticInfos, (IList) nodesToRead);
    session.UpdateNamespaceTable(results, diagnosticInfos, responseHeader);
    nodesToRead = (ReadValueIdCollection) null;
  }

  public async Task FetchTypeTreeAsync(ExpandedNodeId typeId, CancellationToken ct = default (CancellationToken))
  {
    if (!(await this.NodeCache.FindAsync(typeId, ct).ConfigureAwait(false) is Opc.Ua.Node node))
      return;
    ExpandedNodeIdCollection typeIds = new ExpandedNodeIdCollection();
    foreach (IReference reference in (IEnumerable<IReference>) node.Find(ReferenceTypeIds.HasSubtype, false))
      typeIds.Add(reference.TargetId);
    if (typeIds.Count <= 0)
      return;
    await this.FetchTypeTreeAsync(typeIds, ct).ConfigureAwait(false);
  }

  public async Task FetchTypeTreeAsync(ExpandedNodeIdCollection typeIds, CancellationToken ct = default (CancellationToken))
  {
    NodeIdCollection nodeIdCollection = new NodeIdCollection();
    nodeIdCollection.Add(ReferenceTypeIds.HasSubtype);
    NodeIdCollection referenceTypeIds = nodeIdCollection;
    IList<INode> nodeList = await this.NodeCache.FindReferencesAsync((IList<ExpandedNodeId>) typeIds, (IList<NodeId>) referenceTypeIds, false, false, ct).ConfigureAwait(false);
    ExpandedNodeIdCollection typeIds1 = new ExpandedNodeIdCollection();
    foreach (INode node1 in (IEnumerable<INode>) nodeList)
    {
      if (node1 is Opc.Ua.Node node2)
      {
        foreach (IReference reference in (IEnumerable<IReference>) node2.Find(ReferenceTypeIds.HasSubtype, false))
        {
          if (!typeIds.Contains(reference.TargetId))
            typeIds1.Add(reference.TargetId);
        }
      }
    }
    if (typeIds1.Count <= 0)
      return;
    await this.FetchTypeTreeAsync(typeIds1, ct).ConfigureAwait(false);
  }

  public async Task FetchOperationLimitsAsync(CancellationToken ct)
  {
    Session session = this;
    try
    {
      List<string> operationLimitsProperties = ((IEnumerable<PropertyInfo>) typeof (OperationLimits).GetProperties()).Select<PropertyInfo, string>((Func<PropertyInfo, string>) (p => p.Name)).ToList<string>();
      NodeIdCollection nodeIds = new NodeIdCollection(operationLimitsProperties.Select<string, NodeId>((Func<string, NodeId>) (name => (NodeId) typeof (VariableIds).GetField("Server_ServerCapabilities_OperationLimits_" + name, BindingFlags.Static | BindingFlags.Public).GetValue((object) null))));
      // ISSUE: explicit non-virtual call
      (DataValueCollection dataValueCollection, IList<ServiceResult> serviceResultList) = await __nonvirtual (session.ReadValuesAsync((IList<NodeId>) nodeIds, ct)).ConfigureAwait(false);
      ApplicationConfiguration configuration = session.m_configuration;
      OperationLimits operationLimits1;
      if (configuration == null)
      {
        operationLimits1 = (OperationLimits) null;
      }
      else
      {
        ClientConfiguration clientConfiguration = configuration.ClientConfiguration;
        if (clientConfiguration == null)
        {
          operationLimits1 = (OperationLimits) null;
        }
        else
        {
          operationLimits1 = clientConfiguration.OperationLimits;
          if (operationLimits1 != null)
            goto label_8;
        }
      }
      operationLimits1 = new OperationLimits();
label_8:
      OperationLimits operationLimits2 = operationLimits1;
      OperationLimits operationLimits3 = new OperationLimits();
      for (int index = 0; index < nodeIds.Count; ++index)
      {
        PropertyInfo property = typeof (OperationLimits).GetProperty(operationLimitsProperties[index]);
        uint num1 = (uint) property.GetValue((object) operationLimits2);
        if (dataValueCollection[index] != null && ServiceResult.IsNotBad(serviceResultList[index]) && dataValueCollection[index].Value is uint num2 && num2 > 0U && (num1 == 0U || num2 < num1))
          num1 = num2;
        property.SetValue((object) operationLimits3, (object) num1);
      }
      session.OperationLimits = operationLimits3;
      operationLimitsProperties = (List<string>) null;
      nodeIds = (NodeIdCollection) null;
    }
    catch (Exception ex)
    {
      object[] objArray = Array.Empty<object>();
      Utils.LogError(ex, "Failed to read operation limits from server. Using configuration defaults.", objArray);
      OperationLimits operationLimits = session.m_configuration?.ClientConfiguration?.OperationLimits;
      if (operationLimits == null)
        return;
      session.OperationLimits = operationLimits;
    }
  }

  public async Task<(IList<Opc.Ua.Node>, IList<ServiceResult>)> ReadNodesAsync(
    IList<NodeId> nodeIds,
    NodeClass nodeClass,
    bool optionalAttributes = false,
    CancellationToken ct = default (CancellationToken))
  {
    Session session = this;
    if (nodeIds.Count == 0)
      return ((IList<Opc.Ua.Node>) new List<Opc.Ua.Node>(), (IList<ServiceResult>) new List<ServiceResult>());
    if (nodeClass == NodeClass.Unspecified)
    {
      // ISSUE: explicit non-virtual call
      return await __nonvirtual (session.ReadNodesAsync(nodeIds, optionalAttributes, ct)).ConfigureAwait(false);
    }
    NodeCollection nodeCollection = new NodeCollection(nodeIds.Count);
    List<IDictionary<uint, DataValue>> attributesPerNodeId = new List<IDictionary<uint, DataValue>>(nodeIds.Count);
    ReadValueIdCollection attributesToRead = new ReadValueIdCollection();
    session.CreateNodeClassAttributesReadNodesRequest(nodeIds, nodeClass, attributesToRead, (IList<IDictionary<uint, DataValue>>) attributesPerNodeId, (IList<Opc.Ua.Node>) nodeCollection, optionalAttributes);
    ReadResponse readResponse = await session.ReadAsync((RequestHeader) null, 0.0, TimestampsToReturn.Neither, attributesToRead, ct).ConfigureAwait(false);
    DataValueCollection results = readResponse.Results;
    DiagnosticInfoCollection diagnosticInfos = readResponse.DiagnosticInfos;
    ClientBase.ValidateResponse((IList) results, (IList) attributesToRead);
    ClientBase.ValidateDiagnosticInfos(diagnosticInfos, (IList) attributesToRead);
    List<ServiceResult> list = ((IEnumerable<ServiceResult>) new ServiceResult[nodeIds.Count]).ToList<ServiceResult>();
    session.ProcessAttributesReadNodesResponse(readResponse.ResponseHeader, attributesToRead, (IList<IDictionary<uint, DataValue>>) attributesPerNodeId, results, diagnosticInfos, (IList<Opc.Ua.Node>) nodeCollection, (IList<ServiceResult>) list);
    return ((IList<Opc.Ua.Node>) nodeCollection, (IList<ServiceResult>) list);
  }

  public async Task<(IList<Opc.Ua.Node>, IList<ServiceResult>)> ReadNodesAsync(
    IList<NodeId> nodeIds,
    bool optionalAttributes = false,
    CancellationToken ct = default (CancellationToken))
  {
    Session session = this;
    if (nodeIds.Count == 0)
      return ((IList<Opc.Ua.Node>) new List<Opc.Ua.Node>(), (IList<ServiceResult>) new List<ServiceResult>());
    NodeCollection nodeCollection = new NodeCollection(nodeIds.Count);
    ReadValueIdCollection itemsToRead = new ReadValueIdCollection(nodeIds.Count);
    itemsToRead = new ReadValueIdCollection(nodeIds.Select<NodeId, ReadValueId>((Func<NodeId, ReadValueId>) (nodeId => new ReadValueId()
    {
      NodeId = nodeId,
      AttributeId = 2U
    })));
    ReadResponse readResponse1 = await session.ReadAsync((RequestHeader) null, 0.0, TimestampsToReturn.Neither, itemsToRead, ct).ConfigureAwait(false);
    DataValueCollection results1 = readResponse1.Results;
    DiagnosticInfoCollection diagnosticInfos1 = readResponse1.DiagnosticInfos;
    ClientBase.ValidateResponse((IList) results1, (IList) itemsToRead);
    ClientBase.ValidateDiagnosticInfos(diagnosticInfos1, (IList) itemsToRead);
    List<IDictionary<uint, DataValue>> attributesPerNodeId = new List<IDictionary<uint, DataValue>>(nodeIds.Count);
    List<ServiceResult> serviceResults = new List<ServiceResult>(nodeIds.Count);
    ReadValueIdCollection attributesToRead = new ReadValueIdCollection();
    session.CreateAttributesReadNodesRequest(readResponse1.ResponseHeader, itemsToRead, results1, diagnosticInfos1, attributesToRead, (IList<IDictionary<uint, DataValue>>) attributesPerNodeId, (IList<Opc.Ua.Node>) nodeCollection, (IList<ServiceResult>) serviceResults, optionalAttributes);
    if (attributesToRead.Count > 0)
    {
      ReadResponse readResponse2 = await session.ReadAsync((RequestHeader) null, 0.0, TimestampsToReturn.Neither, attributesToRead, ct).ConfigureAwait(false);
      DataValueCollection results2 = readResponse2.Results;
      DiagnosticInfoCollection diagnosticInfos2 = readResponse2.DiagnosticInfos;
      ClientBase.ValidateResponse((IList) results2, (IList) attributesToRead);
      ClientBase.ValidateDiagnosticInfos(diagnosticInfos2, (IList) attributesToRead);
      session.ProcessAttributesReadNodesResponse(readResponse2.ResponseHeader, attributesToRead, (IList<IDictionary<uint, DataValue>>) attributesPerNodeId, results2, diagnosticInfos2, (IList<Opc.Ua.Node>) nodeCollection, (IList<ServiceResult>) serviceResults);
    }
    return ((IList<Opc.Ua.Node>) nodeCollection, (IList<ServiceResult>) serviceResults);
  }

  public Task<Opc.Ua.Node> ReadNodeAsync(NodeId nodeId, CancellationToken ct = default (CancellationToken))
  {
    return this.ReadNodeAsync(nodeId, NodeClass.Unspecified, true, ct);
  }

  public async Task<Opc.Ua.Node> ReadNodeAsync(
    NodeId nodeId,
    NodeClass nodeClass,
    bool optionalAttributes = true,
    CancellationToken ct = default (CancellationToken))
  {
    Session session = this;
    IDictionary<uint, DataValue> attributes = session.CreateAttributes(nodeClass, optionalAttributes);
    ReadValueIdCollection itemsToRead = new ReadValueIdCollection();
    foreach (uint key in (IEnumerable<uint>) attributes.Keys)
      itemsToRead.Add(new ReadValueId()
      {
        NodeId = nodeId,
        AttributeId = key
      });
    ReadResponse readResponse = await session.ReadAsync((RequestHeader) null, 0.0, TimestampsToReturn.Neither, itemsToRead, ct).ConfigureAwait(false);
    DataValueCollection results = readResponse.Results;
    DiagnosticInfoCollection diagnosticInfos = readResponse.DiagnosticInfos;
    ClientBase.ValidateResponse((IList) results, (IList) itemsToRead);
    ClientBase.ValidateDiagnosticInfos(diagnosticInfos, (IList) itemsToRead);
    Opc.Ua.Node node = session.ProcessReadResponse(readResponse.ResponseHeader, attributes, itemsToRead, results, diagnosticInfos);
    attributes = (IDictionary<uint, DataValue>) null;
    itemsToRead = (ReadValueIdCollection) null;
    return node;
  }

  public async Task<DataValue> ReadValueAsync(NodeId nodeId, CancellationToken ct = default (CancellationToken))
  {
    Session session = this;
    ReadValueId readValueId = new ReadValueId()
    {
      NodeId = nodeId,
      AttributeId = 13
    };
    ReadValueIdCollection valueIdCollection = new ReadValueIdCollection();
    valueIdCollection.Add(readValueId);
    ReadValueIdCollection itemsToRead = valueIdCollection;
    ReadResponse readResponse = await session.ReadAsync((RequestHeader) null, 0.0, TimestampsToReturn.Both, itemsToRead, ct).ConfigureAwait(false);
    DataValueCollection results = readResponse.Results;
    DiagnosticInfoCollection diagnosticInfos = readResponse.DiagnosticInfos;
    ClientBase.ValidateResponse((IList) results, (IList) itemsToRead);
    ClientBase.ValidateDiagnosticInfos(diagnosticInfos, (IList) itemsToRead);
    DataValue dataValue = !StatusCode.IsBad(results[0].StatusCode) ? results[0] : throw new ServiceResultException(ClientBase.GetResult(results[0].StatusCode, 0, diagnosticInfos, readResponse.ResponseHeader));
    itemsToRead = (ReadValueIdCollection) null;
    return dataValue;
  }

  public async Task<(DataValueCollection, IList<ServiceResult>)> ReadValuesAsync(
    IList<NodeId> nodeIds,
    CancellationToken ct = default (CancellationToken))
  {
    Session session = this;
    if (nodeIds.Count == 0)
      return (new DataValueCollection(), (IList<ServiceResult>) new List<ServiceResult>());
    ReadValueIdCollection itemsToRead = new ReadValueIdCollection(nodeIds.Select<NodeId, ReadValueId>((Func<NodeId, ReadValueId>) (nodeId => new ReadValueId()
    {
      NodeId = nodeId,
      AttributeId = 13U
    })));
    List<ServiceResult> errors = new List<ServiceResult>(itemsToRead.Count);
    ReadResponse readResponse = await session.ReadAsync((RequestHeader) null, 0.0, TimestampsToReturn.Both, itemsToRead, ct).ConfigureAwait(false);
    DataValueCollection results = readResponse.Results;
    DiagnosticInfoCollection diagnosticInfos = readResponse.DiagnosticInfos;
    ClientBase.ValidateResponse((IList) results, (IList) itemsToRead);
    ClientBase.ValidateDiagnosticInfos(diagnosticInfos, (IList) itemsToRead);
    foreach (DataValue dataValue in (List<DataValue>) results)
    {
      ServiceResult serviceResult = ServiceResult.Good;
      if (StatusCode.IsBad(dataValue.StatusCode))
        serviceResult = ClientBase.GetResult(results[0].StatusCode, 0, diagnosticInfos, readResponse.ResponseHeader);
      errors.Add(serviceResult);
    }
    return (results, (IList<ServiceResult>) errors);
  }

  public async Task<(ResponseHeader responseHeader, ByteStringCollection continuationPoints, IList<ReferenceDescriptionCollection> referencesList, IList<ServiceResult> errors)> BrowseAsync(
    RequestHeader requestHeader,
    ViewDescription view,
    IList<NodeId> nodesToBrowse,
    uint maxResultsToReturn,
    BrowseDirection browseDirection,
    NodeId referenceTypeId,
    bool includeSubtypes,
    uint nodeClassMask,
    CancellationToken ct = default (CancellationToken))
  {
    Session session = this;
    BrowseDescriptionCollection browseDescription = new BrowseDescriptionCollection();
    foreach (NodeId nodeId in (IEnumerable<NodeId>) nodesToBrowse)
      browseDescription.Add(new BrowseDescription()
      {
        NodeId = nodeId,
        BrowseDirection = browseDirection,
        ReferenceTypeId = referenceTypeId,
        IncludeSubtypes = includeSubtypes,
        NodeClassMask = nodeClassMask,
        ResultMask = 63U /*0x3F*/
      });
    BrowseResponse browseResponse = await session.BrowseAsync(requestHeader, view, maxResultsToReturn, browseDescription, ct).ConfigureAwait(false);
    ClientBase.ValidateResponse(browseResponse.ResponseHeader);
    BrowseResultCollection results = browseResponse.Results;
    DiagnosticInfoCollection diagnosticInfos = browseResponse.DiagnosticInfos;
    ClientBase.ValidateResponse((IList) results, (IList) browseDescription);
    ClientBase.ValidateDiagnosticInfos(diagnosticInfos, (IList) browseDescription);
    int index = 0;
    List<ServiceResult> serviceResultList = new List<ServiceResult>();
    ByteStringCollection stringCollection = new ByteStringCollection();
    List<ReferenceDescriptionCollection> descriptionCollectionList = new List<ReferenceDescriptionCollection>();
    foreach (BrowseResult browseResult in (List<BrowseResult>) results)
    {
      if (StatusCode.IsBad(browseResult.StatusCode))
        serviceResultList.Add(new ServiceResult(browseResult.StatusCode, index, diagnosticInfos, (IList<string>) browseResponse.ResponseHeader.StringTable));
      else
        serviceResultList.Add(ServiceResult.Good);
      stringCollection.Add(browseResult.ContinuationPoint);
      descriptionCollectionList.Add(browseResult.References);
      ++index;
    }
    (ResponseHeader, ByteStringCollection, IList<ReferenceDescriptionCollection>, IList<ServiceResult>) valueTuple = (browseResponse.ResponseHeader, stringCollection, (IList<ReferenceDescriptionCollection>) descriptionCollectionList, (IList<ServiceResult>) serviceResultList);
    browseDescription = (BrowseDescriptionCollection) null;
    return valueTuple;
  }

  public async Task<(ResponseHeader responseHeader, ByteStringCollection revisedContinuationPoints, IList<ReferenceDescriptionCollection> referencesList, List<ServiceResult> errors)> BrowseNextAsync(
    RequestHeader requestHeader,
    ByteStringCollection continuationPoints,
    bool releaseContinuationPoint,
    CancellationToken ct = default (CancellationToken))
  {
    // ISSUE: reference to a compiler-generated method
    BrowseNextResponse browseNextResponse = await this.\u003C\u003En__4(requestHeader, releaseContinuationPoint, continuationPoints, ct).ConfigureAwait(false);
    ClientBase.ValidateResponse(browseNextResponse.ResponseHeader);
    BrowseResultCollection results = browseNextResponse.Results;
    DiagnosticInfoCollection diagnosticInfos = browseNextResponse.DiagnosticInfos;
    ClientBase.ValidateResponse((IList) results, (IList) continuationPoints);
    ClientBase.ValidateDiagnosticInfos(diagnosticInfos, (IList) continuationPoints);
    int index = 0;
    List<ServiceResult> serviceResultList = new List<ServiceResult>();
    ByteStringCollection stringCollection = new ByteStringCollection();
    List<ReferenceDescriptionCollection> descriptionCollectionList = new List<ReferenceDescriptionCollection>();
    foreach (BrowseResult browseResult in (List<BrowseResult>) results)
    {
      if (StatusCode.IsBad(browseResult.StatusCode))
        serviceResultList.Add(new ServiceResult(browseResult.StatusCode, index, diagnosticInfos, (IList<string>) browseNextResponse.ResponseHeader.StringTable));
      else
        serviceResultList.Add(ServiceResult.Good);
      stringCollection.Add(browseResult.ContinuationPoint);
      descriptionCollectionList.Add(browseResult.References);
      ++index;
    }
    return (browseNextResponse.ResponseHeader, stringCollection, (IList<ReferenceDescriptionCollection>) descriptionCollectionList, serviceResultList);
  }

  public async Task<IList<object>> CallAsync(
    NodeId objectId,
    NodeId methodId,
    CancellationToken ct = default (CancellationToken),
    params object[] args)
  {
    VariantCollection variantCollection = new VariantCollection();
    if (args != null)
    {
      for (int index = 0; index < args.Length; ++index)
        variantCollection.Add(new Opc.Ua.Variant(args[index]));
    }
    CallMethodRequest callMethodRequest = new CallMethodRequest();
    callMethodRequest.ObjectId = objectId;
    callMethodRequest.MethodId = methodId;
    callMethodRequest.InputArguments = variantCollection;
    CallMethodRequestCollection requests = new CallMethodRequestCollection();
    requests.Add(callMethodRequest);
    // ISSUE: reference to a compiler-generated method
    CallResponse callResponse = await this.\u003C\u003En__5((RequestHeader) null, requests, ct).ConfigureAwait(false);
    CallMethodResultCollection results = callResponse.Results;
    DiagnosticInfoCollection diagnosticInfos = callResponse.DiagnosticInfos;
    ClientBase.ValidateResponse((IList) results, (IList) requests);
    ClientBase.ValidateDiagnosticInfos(diagnosticInfos, (IList) requests);
    if (StatusCode.IsBad(results[0].StatusCode))
      throw ServiceResultException.Create(results[0].StatusCode, 0, diagnosticInfos, (IList<string>) callResponse.ResponseHeader.StringTable);
    List<object> objectList1 = new List<object>();
    foreach (Opc.Ua.Variant outputArgument in (List<Opc.Ua.Variant>) results[0].OutputArguments)
      objectList1.Add(outputArgument.Value);
    IList<object> objectList2 = (IList<object>) objectList1;
    requests = (CallMethodRequestCollection) null;
    return objectList2;
  }

  public async Task<ReferenceDescriptionCollection> FetchReferencesAsync(
    NodeId nodeId,
    CancellationToken ct = default (CancellationToken))
  {
    Session session = this;
    ReferenceDescriptionCollection results = new ReferenceDescriptionCollection();
    (ResponseHeader _, ByteStringCollection continuationPoints, IList<ReferenceDescriptionCollection> descriptionCollectionList, IList<ServiceResult> _) = await session.BrowseAsync((RequestHeader) null, (ViewDescription) null, (IList<NodeId>) new NodeId[1]
    {
      nodeId
    }, 0U, BrowseDirection.Both, (NodeId) null, true, 0U, ct).ConfigureAwait(false);
    if (descriptionCollectionList.Count > 0)
    {
      results.AddRange((IEnumerable<ReferenceDescription>) descriptionCollectionList[0]);
      while (continuationPoints != null && continuationPoints.Count > 0 & continuationPoints[0] != null)
      {
        ConfiguredTaskAwaitable<(ResponseHeader responseHeader, ByteStringCollection revisedContinuationPoints, IList<ReferenceDescriptionCollection> referencesList, List<ServiceResult> errors)>.ConfiguredTaskAwaiter awaiter = session.BrowseNextAsync((RequestHeader) null, continuationPoints, false, ct).ConfigureAwait(false).GetAwaiter();
        if (awaiter.IsCompleted)
        {
          (ResponseHeader _, ByteStringCollection revisedContinuationPoints, IList<ReferenceDescriptionCollection> referencesList, List<ServiceResult> _) = awaiter.GetResult();
          continuationPoints = revisedContinuationPoints;
          if (referencesList.Count > 0)
            results.AddRange((IEnumerable<ReferenceDescription>) referencesList[0]);
        }
        else
        {
          // ISSUE: explicit reference operation
          // ISSUE: reference to a compiler-generated field
          (^this).\u003C\u003E1__state = 1;
          ConfiguredTaskAwaitable<(ResponseHeader, ByteStringCollection, IList<ReferenceDescriptionCollection>, List<ServiceResult>)>.ConfiguredTaskAwaiter configuredTaskAwaiter = awaiter;
          // ISSUE: explicit reference operation
          // ISSUE: reference to a compiler-generated field
          (^this).\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ConfiguredTaskAwaitable<(ResponseHeader, ByteStringCollection, IList<ReferenceDescriptionCollection>, List<ServiceResult>)>.ConfiguredTaskAwaiter, Session.\u003CFetchReferencesAsync\u003Ed__305>(ref awaiter, this);
          return;
        }
      }
    }
    ReferenceDescriptionCollection descriptionCollection = results;
    results = (ReferenceDescriptionCollection) null;
    return descriptionCollection;
  }

  public async Task<(IList<ReferenceDescriptionCollection>, IList<ServiceResult>)> FetchReferencesAsync(
    IList<NodeId> nodeIds,
    CancellationToken ct = default (CancellationToken))
  {
    List<ReferenceDescriptionCollection> result = new List<ReferenceDescriptionCollection>();
    (ResponseHeader _, ByteStringCollection continuationPoints1, IList<ReferenceDescriptionCollection> collection, IList<ServiceResult> serviceResultList1) = await this.BrowseAsync((RequestHeader) null, (ViewDescription) null, nodeIds, 0U, BrowseDirection.Both, (NodeId) null, true, 0U, ct).ConfigureAwait(false);
    result.AddRange((IEnumerable<ReferenceDescriptionCollection>) collection);
    List<ReferenceDescriptionCollection> descriptionCollectionList = result;
    IList<ServiceResult> serviceResultList2 = serviceResultList1;
    while (this.HasAnyContinuationPoint(continuationPoints1))
    {
      ByteStringCollection continuationPoints2 = new ByteStringCollection();
      List<ReferenceDescriptionCollection> nextResult = new List<ReferenceDescriptionCollection>();
      List<ServiceResult> nextErrors = new List<ServiceResult>();
      for (int index = 0; index < continuationPoints1.Count; ++index)
      {
        byte[] numArray = continuationPoints1[index];
        if (numArray != null)
        {
          continuationPoints2.Add(numArray);
          nextResult.Add(descriptionCollectionList[index]);
          nextErrors.Add(serviceResultList2[index]);
        }
      }
      ConfiguredTaskAwaitable<(ResponseHeader responseHeader, ByteStringCollection revisedContinuationPoints, IList<ReferenceDescriptionCollection> referencesList, List<ServiceResult> errors)>.ConfiguredTaskAwaiter awaiter = this.BrowseNextAsync((RequestHeader) null, continuationPoints2, false, ct).ConfigureAwait(false).GetAwaiter();
      if (awaiter.IsCompleted)
      {
        (ResponseHeader _, ByteStringCollection revisedContinuationPoints, IList<ReferenceDescriptionCollection> referencesList, IList<ServiceResult> errors) = awaiter.GetResult();
        continuationPoints1 = revisedContinuationPoints;
        descriptionCollectionList = nextResult;
        serviceResultList2 = (IList<ServiceResult>) nextErrors;
        for (int index = 0; index < referencesList.Count; ++index)
        {
          nextResult[index].AddRange((IEnumerable<ReferenceDescription>) referencesList[index]);
          if (StatusCode.IsBad(errors[index].StatusCode))
            nextErrors[index] = errors[index];
        }
        nextResult = (List<ReferenceDescriptionCollection>) null;
        nextErrors = (List<ServiceResult>) null;
      }
      else
      {
        // ISSUE: explicit reference operation
        // ISSUE: reference to a compiler-generated field
        (^this).\u003C\u003E1__state = 1;
        ConfiguredTaskAwaitable<(ResponseHeader, ByteStringCollection, IList<ReferenceDescriptionCollection>, List<ServiceResult>)>.ConfiguredTaskAwaiter configuredTaskAwaiter = awaiter;
        // ISSUE: explicit reference operation
        // ISSUE: reference to a compiler-generated field
        (^this).\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ConfiguredTaskAwaitable<(ResponseHeader, ByteStringCollection, IList<ReferenceDescriptionCollection>, List<ServiceResult>)>.ConfiguredTaskAwaiter, Session.\u003CFetchReferencesAsync\u003Ed__306>(ref awaiter, this);
        return;
      }
    }
    (IList<ReferenceDescriptionCollection>, IList<ServiceResult>) valueTuple = ((IList<ReferenceDescriptionCollection>) result, serviceResultList1);
    result = (List<ReferenceDescriptionCollection>) null;
    serviceResultList1 = (IList<ServiceResult>) null;
    return valueTuple;
  }

  public static async Task<Session> RecreateAsync(Session sessionTemplate, CancellationToken ct = default (CancellationToken))
  {
    ServiceMessageContext messageContext = sessionTemplate.m_configuration.CreateMessageContext();
    messageContext.Factory = sessionTemplate.Factory;
    Session session = sessionTemplate.CloneSession(SessionChannel.Create(sessionTemplate.m_configuration, sessionTemplate.ConfiguredEndpoint.Description, sessionTemplate.ConfiguredEndpoint.Configuration, sessionTemplate.m_instanceCertificate, sessionTemplate.m_configuration.SecurityConfiguration.SendCertificateChain ? sessionTemplate.m_instanceCertificateChain : (X509Certificate2Collection) null, (IServiceMessageContext) messageContext), true);
    try
    {
      ConfiguredTaskAwaitable configuredTaskAwaitable = session.OpenAsync(sessionTemplate.SessionName, (uint) sessionTemplate.SessionTimeout, sessionTemplate.Identity, (IList<string>) sessionTemplate.PreferredLocales, sessionTemplate.m_checkDomain, ct).ConfigureAwait(false);
      await configuredTaskAwaitable;
      configuredTaskAwaitable = session.RecreateSubscriptionsAsync(sessionTemplate.Subscriptions, ct).ConfigureAwait(false);
      await configuredTaskAwaitable;
    }
    catch (Exception ex)
    {
      session.Dispose();
      throw ServiceResultException.Create(2147811328U /*0x80050000*/, ex, "Could not recreate session. {0}", (object) sessionTemplate.SessionName);
    }
    Session session1 = session;
    session = (Session) null;
    return session1;
  }

  public static async Task<Session> RecreateAsync(
    Session sessionTemplate,
    ITransportWaitingConnection connection,
    CancellationToken ct = default (CancellationToken))
  {
    ServiceMessageContext messageContext = sessionTemplate.m_configuration.CreateMessageContext();
    messageContext.Factory = sessionTemplate.Factory;
    Session session = sessionTemplate.CloneSession(SessionChannel.Create(sessionTemplate.m_configuration, connection, sessionTemplate.m_endpoint.Description, sessionTemplate.m_endpoint.Configuration, sessionTemplate.m_instanceCertificate, sessionTemplate.m_configuration.SecurityConfiguration.SendCertificateChain ? sessionTemplate.m_instanceCertificateChain : (X509Certificate2Collection) null, (IServiceMessageContext) messageContext), true);
    try
    {
      ConfiguredTaskAwaitable configuredTaskAwaitable = session.OpenAsync(sessionTemplate.m_sessionName, (uint) sessionTemplate.m_sessionTimeout, sessionTemplate.m_identity, (IList<string>) sessionTemplate.m_preferredLocales, sessionTemplate.m_checkDomain, ct).ConfigureAwait(false);
      await configuredTaskAwaitable;
      configuredTaskAwaitable = session.RecreateSubscriptionsAsync(sessionTemplate.Subscriptions, ct).ConfigureAwait(false);
      await configuredTaskAwaitable;
    }
    catch (Exception ex)
    {
      session.Dispose();
      throw ServiceResultException.Create(2147811328U /*0x80050000*/, ex, "Could not recreate session. {0}", (object) sessionTemplate.m_sessionName);
    }
    Session session1 = session;
    session = (Session) null;
    return session1;
  }

  public static async Task<Session> RecreateAsync(
    Session sessionTemplate,
    ITransportChannel transportChannel,
    CancellationToken ct = default (CancellationToken))
  {
    sessionTemplate.m_configuration.CreateMessageContext().Factory = sessionTemplate.Factory;
    Session session = sessionTemplate.CloneSession(transportChannel, true);
    try
    {
      await session.OpenAsync(sessionTemplate.m_sessionName, (uint) sessionTemplate.m_sessionTimeout, sessionTemplate.m_identity, (IList<string>) sessionTemplate.m_preferredLocales, sessionTemplate.m_checkDomain, ct).ConfigureAwait(false);
      foreach (Subscription subscription in session.Subscriptions)
      {
        ConfiguredTaskAwaitable.ConfiguredTaskAwaiter awaiter = subscription.CreateAsync(ct).ConfigureAwait(false).GetAwaiter();
        if (awaiter.IsCompleted)
        {
          awaiter.GetResult();
        }
        else
        {
          // ISSUE: explicit reference operation
          // ISSUE: reference to a compiler-generated field
          (^this).\u003C\u003E1__state = 1;
          ConfiguredTaskAwaitable.ConfiguredTaskAwaiter configuredTaskAwaiter = awaiter;
          // ISSUE: explicit reference operation
          // ISSUE: reference to a compiler-generated field
          (^this).\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ConfiguredTaskAwaitable.ConfiguredTaskAwaiter, Session.\u003CRecreateAsync\u003Ed__309>(ref awaiter, this);
          return;
        }
      }
    }
    catch (Exception ex)
    {
      session.Dispose();
      throw ServiceResultException.Create(2147811328U /*0x80050000*/, ex, "Could not recreate session. {0}", (object) sessionTemplate.m_sessionName);
    }
    Session session1 = session;
    session = (Session) null;
    return session1;
  }

  public override Task<StatusCode> CloseAsync(CancellationToken ct = default (CancellationToken))
  {
    return this.CloseAsync(this.m_keepAliveInterval, true, ct);
  }

  public Task<StatusCode> CloseAsync(bool closeChannel, CancellationToken ct = default (CancellationToken))
  {
    return this.CloseAsync(this.m_keepAliveInterval, closeChannel, ct);
  }

  public Task<StatusCode> CloseAsync(int timeout, CancellationToken ct = default (CancellationToken))
  {
    return this.CloseAsync(timeout, true, ct);
  }

  public virtual async Task<StatusCode> CloseAsync(
    int timeout,
    bool closeChannel,
    CancellationToken ct = default (CancellationToken))
  {
    Session sender = this;
    // ISSUE: explicit non-virtual call
    if (__nonvirtual (sender.Disposed))
      return (StatusCode) 0U;
    StatusCode result = (StatusCode) 0U;
    Utils.SilentDispose((IDisposable) sender.m_keepAliveTimer);
    sender.m_keepAliveTimer = (Timer) null;
    bool connected;
    // ISSUE: explicit non-virtual call
    if (connected = __nonvirtual (sender.Connected))
    {
      if (sender.m_SessionClosing != null)
      {
        try
        {
          sender.m_SessionClosing((object) sender, (EventArgs) null);
        }
        catch (Exception ex)
        {
          object[] objArray = Array.Empty<object>();
          Utils.LogError(ex, "Session: Unexpected eror raising SessionClosing event.", objArray);
        }
      }
    }
    // ISSUE: explicit non-virtual call
    if (connected && !__nonvirtual (sender.KeepAliveStopped))
    {
      // ISSUE: explicit non-virtual call
      int existingTimeout = __nonvirtual (sender.OperationTimeout);
      try
      {
        // ISSUE: explicit non-virtual call
        __nonvirtual (sender.OperationTimeout) = timeout;
        // ISSUE: reference to a compiler-generated method
        CloseSessionResponse closeSessionResponse = await sender.\u003C\u003En__2((RequestHeader) null, sender.m_deleteSubscriptionsOnClose, ct).ConfigureAwait(false);
        // ISSUE: explicit non-virtual call
        __nonvirtual (sender.OperationTimeout) = existingTimeout;
        if (closeChannel)
          sender.CloseChannel();
        sender.SessionCreated((NodeId) null, (NodeId) null);
      }
      catch (Exception ex)
      {
        result = !(ex is ServiceResultException) ? (StatusCode) 2147483648U /*0x80000000*/ : (StatusCode) ((ServiceResultException) ex).StatusCode;
        Utils.LogError("Session close error: " + result.ToString());
      }
      finally
      {
        // ISSUE: explicit non-virtual call
        __nonvirtual (sender.OperationTimeout) = existingTimeout;
      }
    }
    if (closeChannel)
    {
      // ISSUE: explicit non-virtual call
      __nonvirtual (sender.Dispose());
    }
    return result;
  }

  public Task ReconnectAsync(CancellationToken ct)
  {
    return this.ReconnectAsync((ITransportWaitingConnection) null, (ITransportChannel) null, ct);
  }

  public Task ReconnectAsync(ITransportWaitingConnection connection, CancellationToken ct)
  {
    return this.ReconnectAsync(connection, (ITransportChannel) null, ct);
  }

  public Task ReconnectAsync(ITransportChannel channel, CancellationToken ct)
  {
    return this.ReconnectAsync((ITransportWaitingConnection) null, channel, ct);
  }

  private async Task ReconnectAsync(
    ITransportWaitingConnection connection,
    ITransportChannel transportChannel,
    CancellationToken ct)
  {
    Session session = this;
    bool resetReconnect = false;
    await session.m_reconnectLock.WaitAsync(ct).ConfigureAwait(false);
    try
    {
      int num1 = session.m_reconnecting ? 1 : 0;
      session.m_reconnecting = true;
      resetReconnect = true;
      session.m_reconnectLock.Release();
      if (num1 != 0)
      {
        Utils.LogWarning("Session is already attempting to reconnect.");
        throw ServiceResultException.Create(2158952448U /*0x80AF0000*/, "Session is already attempting to reconnect.");
      }
      IAsyncResult result = session.PrepareReconnectBeginActivate(connection, transportChannel);
      if (!(result is ChannelAsyncOperation<int> channelAsyncOperation))
        throw new ArgumentNullException("result");
      try
      {
        int num2 = await channelAsyncOperation.EndAsync(7500, ct: ct).ConfigureAwait(false);
      }
      catch (ServiceResultException ex)
      {
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        Utils.LogWarning("WARNING: ACTIVATE SESSION {0} timed out. {1}/{2}", (object) __nonvirtual (session.SessionId), (object) __nonvirtual (session.GoodPublishRequestCount), (object) __nonvirtual (session.OutstandingRequestCount));
      }
      byte[] serverNonce = (byte[]) null;
      StatusCodeCollection results = (StatusCodeCollection) null;
      DiagnosticInfoCollection diagnosticInfos = (DiagnosticInfoCollection) null;
      session.EndActivateSession(result, out serverNonce, out results, out diagnosticInfos);
      int publishCount = 0;
      // ISSUE: explicit non-virtual call
      Utils.LogInfo("Session RECONNECT {0} completed successfully.", (object) __nonvirtual (session.SessionId));
      lock (session.SyncRoot)
      {
        session.m_previousServerNonce = session.m_serverNonce;
        session.m_serverNonce = serverNonce;
        publishCount = session.GetMinPublishRequestCount(true);
      }
      await session.m_reconnectLock.WaitAsync(ct).ConfigureAwait(false);
      session.m_reconnecting = false;
      resetReconnect = false;
      session.m_reconnectLock.Release();
      for (int index = 0; index < publishCount; ++index)
      {
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        __nonvirtual (session.BeginPublish(__nonvirtual (session.OperationTimeout)));
      }
      session.StartKeepAliveTimer();
      session.IndicateSessionConfigurationChanged();
      result = (IAsyncResult) null;
    }
    finally
    {
      if (resetReconnect)
      {
        await session.m_reconnectLock.WaitAsync(ct).ConfigureAwait(false);
        session.m_reconnecting = false;
        session.m_reconnectLock.Release();
      }
    }
  }

  public async Task<bool> RepublishAsync(
    uint subscriptionId,
    uint sequenceNumber,
    CancellationToken ct)
  {
    Session session = this;
    // ISSUE: explicit non-virtual call
    // ISSUE: explicit non-virtual call
    RequestHeader requestHeader = new RequestHeader()
    {
      TimeoutHint = (uint) __nonvirtual (session.OperationTimeout),
      ReturnDiagnostics = (uint) __nonvirtual (session.ReturnDiagnostics),
      RequestHandle = Utils.IncrementIdentifier(ref session.m_publishCounter)
    };
    try
    {
      Utils.LogInfo("Requesting RepublishAsync for {0}-{1}", (object) subscriptionId, (object) sequenceNumber);
      RepublishResponse republishResponse = await session.RepublishAsync(requestHeader, subscriptionId, sequenceNumber, ct).ConfigureAwait(false);
      ResponseHeader responseHeader = republishResponse.ResponseHeader;
      NotificationMessage notificationMessage = republishResponse.NotificationMessage;
      Utils.LogInfo("Received RepublishAsync for {0}-{1}-{2}", (object) subscriptionId, (object) sequenceNumber, (object) responseHeader.ServiceResult);
      session.ProcessPublishResponse(responseHeader, subscriptionId, (UInt32Collection) null, false, notificationMessage);
      return true;
    }
    catch (Exception ex)
    {
      return session.ProcessRepublishResponseError(ex, subscriptionId, sequenceNumber);
    }
  }

  private async Task RecreateSubscriptionsAsync(
    IEnumerable<Subscription> subscriptionsTemplate,
    CancellationToken ct)
  {
    bool transferred = false;
    if (this.TransferSubscriptionsOnReconnect)
    {
      try
      {
        transferred = await this.TransferSubscriptionsAsync(new SubscriptionCollection(subscriptionsTemplate), false, ct).ConfigureAwait(false);
      }
      catch (ServiceResultException ex)
      {
        if (ex.StatusCode == 2148204544U /*0x800B0000*/)
        {
          this.TransferSubscriptionsOnReconnect = false;
          Utils.LogWarning("Transfer subscription unsupported, TransferSubscriptionsOnReconnect set to false.");
        }
        else
          Utils.LogError((Exception) ex, "Transfer subscriptions failed.");
      }
      catch (Exception ex)
      {
        object[] objArray = Array.Empty<object>();
        Utils.LogError(ex, "Unexpected Transfer subscriptions error.", objArray);
      }
    }
    if (transferred)
      return;
    foreach (Subscription subscription in this.Subscriptions)
    {
      if (!subscription.Created)
      {
        ConfiguredTaskAwaitable.ConfiguredTaskAwaiter awaiter = subscription.CreateAsync(ct).ConfigureAwait(false).GetAwaiter();
        if (awaiter.IsCompleted)
        {
          awaiter.GetResult();
        }
        else
        {
          // ISSUE: explicit reference operation
          // ISSUE: reference to a compiler-generated field
          (^this).\u003C\u003E1__state = 1;
          ConfiguredTaskAwaitable.ConfiguredTaskAwaiter configuredTaskAwaiter = awaiter;
          // ISSUE: explicit reference operation
          // ISSUE: reference to a compiler-generated field
          (^this).\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ConfiguredTaskAwaitable.ConfiguredTaskAwaiter, Session.\u003CRecreateSubscriptionsAsync\u003Ed__319>(ref awaiter, this);
          break;
        }
      }
    }
  }

  [Obsolete("Call Create instead. Service Call doesn't create Session.")]
  public override ResponseHeader CreateSession(
    RequestHeader requestHeader,
    ApplicationDescription clientDescription,
    string serverUri,
    string endpointUrl,
    string sessionName,
    byte[] clientNonce,
    byte[] clientCertificate,
    double requestedSessionTimeout,
    uint maxResponseMessageSize,
    out NodeId sessionId,
    out NodeId authenticationToken,
    out double revisedSessionTimeout,
    out byte[] serverNonce,
    out byte[] serverCertificate,
    out EndpointDescriptionCollection serverEndpoints,
    out SignedSoftwareCertificateCollection serverSoftwareCertificates,
    out SignatureData serverSignature,
    out uint maxRequestMessageSize)
  {
    return base.CreateSession(requestHeader, clientDescription, serverUri, endpointUrl, sessionName, clientNonce, clientCertificate, requestedSessionTimeout, maxResponseMessageSize, out sessionId, out authenticationToken, out revisedSessionTimeout, out serverNonce, out serverCertificate, out serverEndpoints, out serverSoftwareCertificates, out serverSignature, out maxRequestMessageSize);
  }

  [Obsolete("Call Create instead. Service Call doesn't create Session.")]
  public override Task<CreateSessionResponse> CreateSessionAsync(
    RequestHeader requestHeader,
    ApplicationDescription clientDescription,
    string serverUri,
    string endpointUrl,
    string sessionName,
    byte[] clientNonce,
    byte[] clientCertificate,
    double requestedSessionTimeout,
    uint maxResponseMessageSize,
    CancellationToken ct)
  {
    return base.CreateSessionAsync(requestHeader, clientDescription, serverUri, endpointUrl, sessionName, clientNonce, clientCertificate, requestedSessionTimeout, maxResponseMessageSize, ct);
  }

  [Obsolete("Call Close instead. Service Call doesn't clean up Session.")]
  public override ResponseHeader CloseSession(RequestHeader requestHeader, bool deleteSubscriptions)
  {
    return base.CloseSession(requestHeader, deleteSubscriptions);
  }

  [Obsolete("Call CloseAsync instead. Service Call doesn't clean up Session.")]
  public override Task<CloseSessionResponse> CloseSessionAsync(
    RequestHeader requestHeader,
    bool deleteSubscriptions,
    CancellationToken ct)
  {
    return base.CloseSessionAsync(requestHeader, deleteSubscriptions, ct);
  }

  [Obsolete("Call ISession.TransferSubscriptions(SubscriptionIds, bool) instead.")]
  public override ResponseHeader TransferSubscriptions(
    RequestHeader requestHeader,
    UInt32Collection subscriptionIds,
    bool sendInitialValues,
    out TransferResultCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    return base.TransferSubscriptions(requestHeader, subscriptionIds, sendInitialValues, out results, out diagnosticInfos);
  }

  [Obsolete("Call ISession.TransferSubscriptionsAsync(SubscriptionIds, bool) instead.")]
  public override Task<TransferSubscriptionsResponse> TransferSubscriptionsAsync(
    RequestHeader requestHeader,
    UInt32Collection subscriptionIds,
    bool sendInitialValues,
    CancellationToken ct)
  {
    return base.TransferSubscriptionsAsync(requestHeader, subscriptionIds, sendInitialValues, ct);
  }

  private class AsyncRequestState
  {
    public uint RequestTypeId;
    public uint RequestId;
    public DateTime Timestamp;
    public IAsyncResult Result;
    public bool Defunct;
  }
}
