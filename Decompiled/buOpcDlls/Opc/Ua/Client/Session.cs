using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using Opc.Ua.Bindings;

namespace Opc.Ua.Client;

[ComVisible(true)]
public class Session : SessionClientBatched, ISession, ISessionClient, ISessionClientMethods, IClientBase, IDisposable
{
	private class AsyncRequestState
	{
		public uint RequestTypeId;

		public uint RequestId;

		public DateTime Timestamp;

		public IAsyncResult Result;

		public bool Defunct;
	}

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

	private SystemContext m_systemContext;

	private NodeCache m_nodeCache;

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

	private LinkedList<AsyncRequestState> m_outstandingRequests;

	private readonly EndpointDescriptionCollection m_discoveryServerEndpoints;

	private readonly StringCollection m_discoveryProfileUris;

	private readonly object m_eventLock = new object();

	public ISessionFactory SessionFactory
	{
		get
		{
			return m_sessionFactory;
		}
		set
		{
			m_sessionFactory = value;
		}
	}

	public ConfiguredEndpoint ConfiguredEndpoint => m_endpoint;

	public string SessionName => m_sessionName;

	public double SessionTimeout => m_sessionTimeout;

	public object Handle
	{
		get
		{
			return m_handle;
		}
		set
		{
			m_handle = value;
		}
	}

	public IUserIdentity Identity => m_identity;

	public IEnumerable<IUserIdentity> IdentityHistory => m_identityHistory;

	public NamespaceTable NamespaceUris => m_namespaceUris;

	public StringTable ServerUris => m_serverUris;

	public ISystemContext SystemContext => m_systemContext;

	public IEncodeableFactory Factory => m_factory;

	public ITypeTable TypeTree => m_nodeCache.TypeTree;

	public INodeCache NodeCache => m_nodeCache;

	public FilterContext FilterContext => new FilterContext(m_namespaceUris, m_nodeCache.TypeTree, m_preferredLocales);

	public StringCollection PreferredLocales => m_preferredLocales;

	public IReadOnlyDictionary<NodeId, DataDictionary> DataTypeSystem => m_dictionaries;

	public IEnumerable<Subscription> Subscriptions
	{
		get
		{
			lock (base.SyncRoot)
			{
				return new ReadOnlyList<Subscription>(m_subscriptions);
			}
		}
	}

	public int SubscriptionCount
	{
		get
		{
			lock (base.SyncRoot)
			{
				return m_subscriptions.Count;
			}
		}
	}

	public bool DeleteSubscriptionsOnClose
	{
		get
		{
			return m_deleteSubscriptionsOnClose;
		}
		set
		{
			m_deleteSubscriptionsOnClose = value;
		}
	}

	public bool TransferSubscriptionsOnReconnect
	{
		get
		{
			return m_transferSubscriptionsOnReconnect;
		}
		set
		{
			m_transferSubscriptionsOnReconnect = value;
		}
	}

	public bool CheckDomain => m_checkDomain;

	public Subscription DefaultSubscription
	{
		get
		{
			return m_defaultSubscription;
		}
		set
		{
			m_defaultSubscription = value;
		}
	}

	public int KeepAliveInterval
	{
		get
		{
			return m_keepAliveInterval;
		}
		set
		{
			m_keepAliveInterval = value;
			StartKeepAliveTimer();
		}
	}

	public bool KeepAliveStopped
	{
		get
		{
			lock (m_eventLock)
			{
				long num = DateTime.UtcNow.Ticks - m_lastKeepAliveTime.Ticks;
				return (long)(m_keepAliveInterval * 2) * 10000L <= num;
			}
		}
	}

	public DateTime LastKeepAliveTime => m_lastKeepAliveTime;

	public int OutstandingRequestCount
	{
		get
		{
			lock (m_outstandingRequests)
			{
				return m_outstandingRequests.Count;
			}
		}
	}

	public int DefunctRequestCount
	{
		get
		{
			lock (m_outstandingRequests)
			{
				int num = 0;
				for (LinkedListNode<AsyncRequestState> linkedListNode = m_outstandingRequests.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
				{
					if (linkedListNode.Value.Defunct)
					{
						num++;
					}
				}
				return num;
			}
		}
	}

	public int GoodPublishRequestCount
	{
		get
		{
			lock (m_outstandingRequests)
			{
				int num = 0;
				for (LinkedListNode<AsyncRequestState> linkedListNode = m_outstandingRequests.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
				{
					if (!linkedListNode.Value.Defunct && linkedListNode.Value.RequestTypeId == 824)
					{
						num++;
					}
				}
				return num;
			}
		}
	}

	public int MinPublishRequestCount
	{
		get
		{
			return m_minPublishRequestCount;
		}
		set
		{
			lock (base.SyncRoot)
			{
				if (value >= 1 && value <= 100)
				{
					m_minPublishRequestCount = value;
					return;
				}
				throw new ArgumentOutOfRangeException("MinPublishRequestCount", $"Minimum publish request count must be between {1} and {100}.");
			}
		}
	}

	public event KeepAliveEventHandler KeepAlive
	{
		add
		{
			lock (m_eventLock)
			{
				m_KeepAlive += value;
			}
		}
		remove
		{
			lock (m_eventLock)
			{
				m_KeepAlive -= value;
			}
		}
	}

	public event NotificationEventHandler Notification
	{
		add
		{
			lock (m_eventLock)
			{
				m_Publish += value;
			}
		}
		remove
		{
			lock (m_eventLock)
			{
				m_Publish -= value;
			}
		}
	}

	public event PublishErrorEventHandler PublishError
	{
		add
		{
			lock (m_eventLock)
			{
				m_PublishError += value;
			}
		}
		remove
		{
			lock (m_eventLock)
			{
				m_PublishError -= value;
			}
		}
	}

	public event PublishSequenceNumbersToAcknowledgeEventHandler PublishSequenceNumbersToAcknowledge
	{
		add
		{
			lock (m_eventLock)
			{
				m_PublishSequenceNumbersToAcknowledge += value;
			}
		}
		remove
		{
			lock (m_eventLock)
			{
				m_PublishSequenceNumbersToAcknowledge -= value;
			}
		}
	}

	public event EventHandler SubscriptionsChanged
	{
		add
		{
			m_SubscriptionsChanged += value;
		}
		remove
		{
			m_SubscriptionsChanged -= value;
		}
	}

	public event EventHandler SessionClosing
	{
		add
		{
			m_SessionClosing += value;
		}
		remove
		{
			m_SessionClosing -= value;
		}
	}

	public event EventHandler SessionConfigurationChanged
	{
		add
		{
			m_SessionConfigurationChanged += value;
		}
		remove
		{
			m_SessionConfigurationChanged -= value;
		}
	}

	public event RenewUserIdentityEventHandler RenewUserIdentity
	{
		add
		{
			m_RenewUserIdentity += value;
		}
		remove
		{
			m_RenewUserIdentity -= value;
		}
	}

	private event RenewUserIdentityEventHandler m_RenewUserIdentity;

	private event KeepAliveEventHandler m_KeepAlive;

	private event NotificationEventHandler m_Publish;

	private event PublishErrorEventHandler m_PublishError;

	private event PublishSequenceNumbersToAcknowledgeEventHandler m_PublishSequenceNumbersToAcknowledge;

	private event EventHandler m_SubscriptionsChanged;

	private event EventHandler m_SessionClosing;

	private event EventHandler m_SessionConfigurationChanged;

	public Session(ISessionChannel channel, ApplicationConfiguration configuration, ConfiguredEndpoint endpoint)
		: this(channel as ITransportChannel, configuration, endpoint, null)
	{
	}

	public Session(ITransportChannel channel, ApplicationConfiguration configuration, ConfiguredEndpoint endpoint, X509Certificate2 clientCertificate, EndpointDescriptionCollection availableEndpoints = null, StringCollection discoveryProfileUris = null)
		: base(channel)
	{
		Initialize(channel, configuration, endpoint, clientCertificate);
		m_discoveryServerEndpoints = availableEndpoints;
		m_discoveryProfileUris = discoveryProfileUris;
	}

	public Session(ITransportChannel channel, Session template, bool copyEventHandlers)
		: base(channel)
	{
		Initialize(channel, template.m_configuration, template.ConfiguredEndpoint, template.m_instanceCertificate);
		m_sessionFactory = template.m_sessionFactory;
		m_defaultSubscription = template.m_defaultSubscription;
		m_deleteSubscriptionsOnClose = template.m_deleteSubscriptionsOnClose;
		m_transferSubscriptionsOnReconnect = template.m_transferSubscriptionsOnReconnect;
		m_sessionTimeout = template.m_sessionTimeout;
		m_maxRequestMessageSize = template.m_maxRequestMessageSize;
		m_minPublishRequestCount = template.m_minPublishRequestCount;
		m_preferredLocales = template.PreferredLocales;
		m_sessionName = template.SessionName;
		m_handle = template.Handle;
		m_identity = template.Identity;
		m_keepAliveInterval = template.KeepAliveInterval;
		m_checkDomain = template.m_checkDomain;
		if (template.OperationTimeout > 0)
		{
			base.OperationTimeout = template.OperationTimeout;
		}
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
		{
			AddSubscription(subscription.CloneSubscription(copyEventHandlers));
		}
	}

	private void Initialize(ITransportChannel channel, ApplicationConfiguration configuration, ConfiguredEndpoint endpoint, X509Certificate2 clientCertificate)
	{
		Initialize();
		ValidateClientConfiguration(configuration);
		m_configuration = configuration;
		m_endpoint = endpoint;
		m_defaultSubscription.MinLifetimeInterval = (uint)configuration.ClientConfiguration.MinSubscriptionLifetime;
		if (m_endpoint.Description.SecurityPolicyUri != "http://opcfoundation.org/UA/SecurityPolicy#None")
		{
			m_instanceCertificate = clientCertificate;
			if (clientCertificate == null)
			{
				if (m_configuration.SecurityConfiguration.ApplicationCertificate == null)
				{
					throw new ServiceResultException(2156462080u, "The client configuration does not specify an application instance certificate.");
				}
				m_instanceCertificate = m_configuration.SecurityConfiguration.ApplicationCertificate.Find(needPrivateKey: true).Result;
			}
			if (m_instanceCertificate == null)
			{
				CertificateIdentifier applicationCertificate = m_configuration.SecurityConfiguration.ApplicationCertificate;
				throw ServiceResultException.Create(2156462080u, "Cannot find the application instance certificate. Store={0}, SubjectName={1}, Thumbprint={2}.", applicationCertificate.StorePath, applicationCertificate.SubjectName, applicationCertificate.Thumbprint);
			}
			if (!m_instanceCertificate.HasPrivateKey)
			{
				throw ServiceResultException.Create(2156462080u, "No private key for the application instance certificate. Subject={0}, Thumbprint={1}.", m_instanceCertificate.Subject, m_instanceCertificate.Thumbprint);
			}
			m_instanceCertificateChain = new X509Certificate2Collection(m_instanceCertificate);
			List<CertificateIdentifier> list = new List<CertificateIdentifier>();
			configuration.CertificateValidator.GetIssuers(m_instanceCertificate, list).Wait();
			for (int i = 0; i < list.Count; i++)
			{
				m_instanceCertificateChain.Add(list[i].Certificate);
			}
		}
		IServiceMessageContext messageContext = channel.MessageContext;
		if (messageContext != null)
		{
			m_namespaceUris = messageContext.NamespaceUris;
			m_serverUris = messageContext.ServerUris;
			m_factory = messageContext.Factory;
		}
		else
		{
			m_namespaceUris = new NamespaceTable();
			m_serverUris = new StringTable();
			m_factory = new EncodeableFactory(EncodeableFactory.GlobalFactory);
		}
		m_nodeCache = new NodeCache(this);
		m_preferredLocales = new string[1] { CultureInfo.CurrentCulture.Name };
		m_systemContext = new SystemContext
		{
			SystemHandle = this,
			EncodeableFactory = m_factory,
			NamespaceUris = m_namespaceUris,
			ServerUris = m_serverUris,
			TypeTable = TypeTree,
			PreferredLocales = null,
			SessionId = null,
			UserIdentity = null
		};
	}

	private void Initialize()
	{
		m_sessionFactory = DefaultSessionFactory.Instance;
		m_sessionTimeout = 0.0;
		m_namespaceUris = new NamespaceTable();
		m_serverUris = new StringTable();
		m_factory = EncodeableFactory.GlobalFactory;
		m_configuration = null;
		m_instanceCertificate = null;
		m_endpoint = null;
		m_subscriptions = new List<Subscription>();
		m_dictionaries = new Dictionary<NodeId, DataDictionary>();
		m_acknowledgementsToSend = new SubscriptionAcknowledgementCollection();
		m_latestAcknowledgementsSent = new Dictionary<uint, uint>();
		m_identityHistory = new List<IUserIdentity>();
		m_outstandingRequests = new LinkedList<AsyncRequestState>();
		m_keepAliveInterval = 5000;
		m_tooManyPublishRequests = 0;
		m_minPublishRequestCount = 1;
		m_sessionName = "";
		m_deleteSubscriptionsOnClose = true;
		m_transferSubscriptionsOnReconnect = false;
		m_reconnecting = false;
		m_reconnectLock = new SemaphoreSlim(1, 1);
		m_defaultSubscription = new Subscription
		{
			DisplayName = "Subscription",
			PublishingInterval = 1000,
			KeepAliveCount = 10u,
			LifetimeCount = 1000u,
			Priority = byte.MaxValue,
			PublishingEnabled = true
		};
	}

	private void ValidateClientConfiguration(ApplicationConfiguration configuration)
	{
		if (configuration == null)
		{
			throw new ArgumentNullException("configuration");
		}
		string text;
		if (configuration.ClientConfiguration == null)
		{
			text = "ClientConfiguration";
		}
		else if (configuration.SecurityConfiguration == null)
		{
			text = "SecurityConfiguration";
		}
		else
		{
			if (configuration.CertificateValidator != null)
			{
				return;
			}
			text = "CertificateValidator";
		}
		throw new ServiceResultException(2156462080u, "The client configuration does not specify the " + text + ".");
	}

	private void ValidateServerNonce(IUserIdentity identity, byte[] serverNonce, string securityPolicyUri, byte[] previousServerNonce, MessageSecurityMode channelSecurityMode = MessageSecurityMode.None)
	{
		if (string.IsNullOrEmpty(securityPolicyUri) || securityPolicyUri == "http://opcfoundation.org/UA/SecurityPolicy#None" || identity == null || identity.TokenType == UserTokenType.Anonymous)
		{
			return;
		}
		if (!Utils.Nonce.ValidateNonce(serverNonce, MessageSecurityMode.SignAndEncrypt, (uint)m_configuration.SecurityConfiguration.NonceLength))
		{
			if (channelSecurityMode != MessageSecurityMode.SignAndEncrypt && !m_configuration.SecurityConfiguration.SuppressNonceValidationErrors)
			{
				throw ServiceResultException.Create(2149842944u, "The server nonce has not the correct length or is not random enough.");
			}
			Utils.LogWarning(512, "Warning: The server nonce has not the correct length or is not random enough. The error is suppressed by user setting or because the channel is encrypted.");
		}
		if (previousServerNonce != null && Utils.CompareNonce(serverNonce, previousServerNonce))
		{
			if (channelSecurityMode != MessageSecurityMode.SignAndEncrypt && !m_configuration.SecurityConfiguration.SuppressNonceValidationErrors)
			{
				throw ServiceResultException.Create(2149842944u, "Server nonce is equal with previously returned nonce.");
			}
			Utils.LogWarning(512, "Warning: The Server nonce is equal with previously returned nonce. The error is suppressed by user setting or because the channel is encrypted.");
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			StopKeepAliveTimer();
			Utils.SilentDispose(m_defaultSubscription);
			m_defaultSubscription = null;
			Utils.SilentDispose(m_nodeCache);
			m_nodeCache = null;
			IList<Subscription> list = null;
			lock (base.SyncRoot)
			{
				list = new List<Subscription>(m_subscriptions);
				m_subscriptions.Clear();
			}
			foreach (Subscription item in list)
			{
				Utils.SilentDispose(item);
			}
		}
		base.Dispose(disposing);
		if (disposing)
		{
			this.m_KeepAlive = null;
			this.m_Publish = null;
			this.m_PublishError = null;
			this.m_PublishSequenceNumbersToAcknowledge = null;
			this.m_SubscriptionsChanged = null;
			this.m_SessionClosing = null;
			this.m_SessionConfigurationChanged = null;
		}
	}

	public static Task<Session> Create(ApplicationConfiguration configuration, ConfiguredEndpoint endpoint, bool updateBeforeConnect, string sessionName, uint sessionTimeout, IUserIdentity identity, IList<string> preferredLocales, CancellationToken ct = default(CancellationToken))
	{
		return Create(configuration, endpoint, updateBeforeConnect, checkDomain: false, sessionName, sessionTimeout, identity, preferredLocales, ct);
	}

	public static Task<Session> Create(ApplicationConfiguration configuration, ConfiguredEndpoint endpoint, bool updateBeforeConnect, bool checkDomain, string sessionName, uint sessionTimeout, IUserIdentity identity, IList<string> preferredLocales, CancellationToken ct = default(CancellationToken))
	{
		return Create(configuration, (ITransportWaitingConnection)null, endpoint, updateBeforeConnect, checkDomain, sessionName, sessionTimeout, identity, preferredLocales, ct);
	}

	public static Session Create(ApplicationConfiguration configuration, ITransportChannel channel, ConfiguredEndpoint endpoint, X509Certificate2 clientCertificate, EndpointDescriptionCollection availableEndpoints = null, StringCollection discoveryProfileUris = null)
	{
		return Create(DefaultSessionFactory.Instance, configuration, channel, endpoint, clientCertificate, availableEndpoints, discoveryProfileUris);
	}

	public static Session Create(ISessionInstantiator sessionInstantiator, ApplicationConfiguration configuration, ITransportChannel channel, ConfiguredEndpoint endpoint, X509Certificate2 clientCertificate, EndpointDescriptionCollection availableEndpoints = null, StringCollection discoveryProfileUris = null)
	{
		return sessionInstantiator.Create(channel, configuration, endpoint, clientCertificate, availableEndpoints, discoveryProfileUris);
	}

	public static async Task<ITransportChannel> CreateChannelAsync(ApplicationConfiguration configuration, ITransportWaitingConnection connection, ConfiguredEndpoint endpoint, bool updateBeforeConnect, bool checkDomain, CancellationToken ct = default(CancellationToken))
	{
		endpoint.UpdateBeforeConnect = updateBeforeConnect;
		EndpointDescription endpointDescription = endpoint.Description;
		EndpointConfiguration endpointConfiguration = endpoint.Configuration;
		if (endpointConfiguration == null)
		{
			EndpointConfiguration configuration2;
			endpointConfiguration = (configuration2 = EndpointConfiguration.Create(configuration));
			endpoint.Configuration = configuration2;
		}
		IServiceMessageContext messageContext = configuration.CreateMessageContext(clonedFactory: true);
		if (endpoint.UpdateBeforeConnect && connection == null)
		{
			await endpoint.UpdateFromServerAsync(ct).ConfigureAwait(continueOnCapturedContext: false);
			endpointDescription = endpoint.Description;
			endpointConfiguration = endpoint.Configuration;
		}
		if (checkDomain && endpoint.Description.ServerCertificate != null && endpoint.Description.ServerCertificate.Length != 0)
		{
			configuration.CertificateValidator?.ValidateDomains(new X509Certificate2(endpoint.Description.ServerCertificate), endpoint);
			checkDomain = false;
		}
		X509Certificate2 clientCertificate = null;
		X509Certificate2Collection clientCertificateChain = null;
		if (endpointDescription.SecurityPolicyUri != "http://opcfoundation.org/UA/SecurityPolicy#None")
		{
			clientCertificate = await LoadCertificate(configuration).ConfigureAwait(continueOnCapturedContext: false);
			clientCertificateChain = await LoadCertificateChain(configuration, clientCertificate).ConfigureAwait(continueOnCapturedContext: false);
		}
		return (connection == null) ? SessionChannel.Create(configuration, endpointDescription, endpointConfiguration, clientCertificate, clientCertificateChain, messageContext) : UaChannelBase.CreateUaBinaryChannel(configuration, connection, endpointDescription, endpointConfiguration, clientCertificate, clientCertificateChain, messageContext);
	}

	public static Task<Session> Create(ApplicationConfiguration configuration, ITransportWaitingConnection connection, ConfiguredEndpoint endpoint, bool updateBeforeConnect, bool checkDomain, string sessionName, uint sessionTimeout, IUserIdentity identity, IList<string> preferredLocales, CancellationToken ct = default(CancellationToken))
	{
		return Create(DefaultSessionFactory.Instance, configuration, connection, endpoint, updateBeforeConnect, checkDomain, sessionName, sessionTimeout, identity, preferredLocales, ct);
	}

	public static async Task<Session> Create(ISessionInstantiator sessionInstantiator, ApplicationConfiguration configuration, ITransportWaitingConnection connection, ConfiguredEndpoint endpoint, bool updateBeforeConnect, bool checkDomain, string sessionName, uint sessionTimeout, IUserIdentity identity, IList<string> preferredLocales, CancellationToken ct = default(CancellationToken))
	{
		Session session = sessionInstantiator.Create(await CreateChannelAsync(configuration, connection, endpoint, updateBeforeConnect, checkDomain, ct).ConfigureAwait(continueOnCapturedContext: false), configuration, endpoint, null);
		try
		{
			await session.OpenAsync(sessionName, sessionTimeout, identity, preferredLocales, checkDomain, ct).ConfigureAwait(continueOnCapturedContext: false);
			return session;
		}
		catch (Exception)
		{
			session.Dispose();
			throw;
		}
	}

	public static Task<Session> Create(ApplicationConfiguration configuration, ReverseConnectManager reverseConnectManager, ConfiguredEndpoint endpoint, bool updateBeforeConnect, bool checkDomain, string sessionName, uint sessionTimeout, IUserIdentity userIdentity, IList<string> preferredLocales, CancellationToken ct = default(CancellationToken))
	{
		return Create(DefaultSessionFactory.Instance, configuration, reverseConnectManager, endpoint, updateBeforeConnect, checkDomain, sessionName, sessionTimeout, userIdentity, preferredLocales, ct);
	}

	public static async Task<Session> Create(ISessionInstantiator sessionInstantiator, ApplicationConfiguration configuration, ReverseConnectManager reverseConnectManager, ConfiguredEndpoint endpoint, bool updateBeforeConnect, bool checkDomain, string sessionName, uint sessionTimeout, IUserIdentity userIdentity, IList<string> preferredLocales, CancellationToken ct = default(CancellationToken))
	{
		if (reverseConnectManager == null)
		{
			return await Create(sessionInstantiator, configuration, (ITransportWaitingConnection)null, endpoint, updateBeforeConnect, checkDomain, sessionName, sessionTimeout, userIdentity, preferredLocales, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
		ITransportWaitingConnection transportWaitingConnection;
		do
		{
			transportWaitingConnection = await reverseConnectManager.WaitForConnection(endpoint.EndpointUrl, endpoint.ReverseConnect?.ServerUri, ct).ConfigureAwait(continueOnCapturedContext: false);
			if (updateBeforeConnect)
			{
				await endpoint.UpdateFromServerAsync(endpoint.EndpointUrl, transportWaitingConnection, endpoint.Description.SecurityMode, endpoint.Description.SecurityPolicyUri, ct).ConfigureAwait(continueOnCapturedContext: false);
				updateBeforeConnect = false;
				transportWaitingConnection = null;
			}
		}
		while (transportWaitingConnection == null);
		return await Create(sessionInstantiator, configuration, transportWaitingConnection, endpoint, updateBeforeConnect: false, checkDomain, sessionName, sessionTimeout, userIdentity, preferredLocales, ct).ConfigureAwait(continueOnCapturedContext: false);
	}

	public static Session Recreate(Session template)
	{
		ServiceMessageContext serviceMessageContext = template.m_configuration.CreateMessageContext();
		serviceMessageContext.Factory = template.Factory;
		ITransportChannel channel = SessionChannel.Create(template.m_configuration, template.ConfiguredEndpoint.Description, template.ConfiguredEndpoint.Configuration, template.m_instanceCertificate, template.m_configuration.SecurityConfiguration.SendCertificateChain ? template.m_instanceCertificateChain : null, serviceMessageContext);
		Session session = template.CloneSession(channel, copyEventHandlers: true);
		try
		{
			session.Open(template.SessionName, (uint)template.SessionTimeout, template.Identity, template.PreferredLocales, template.m_checkDomain);
			session.RecreateSubscriptions(template.Subscriptions);
			return session;
		}
		catch (Exception e)
		{
			session.Dispose();
			throw ServiceResultException.Create(2147811328u, e, "Could not recreate session. {0}", template.SessionName);
		}
	}

	public static Session Recreate(Session template, ITransportWaitingConnection connection)
	{
		ServiceMessageContext serviceMessageContext = template.m_configuration.CreateMessageContext();
		serviceMessageContext.Factory = template.Factory;
		ITransportChannel channel = SessionChannel.Create(template.m_configuration, connection, template.m_endpoint.Description, template.m_endpoint.Configuration, template.m_instanceCertificate, template.m_configuration.SecurityConfiguration.SendCertificateChain ? template.m_instanceCertificateChain : null, serviceMessageContext);
		Session session = template.CloneSession(channel, copyEventHandlers: true);
		try
		{
			session.Open(template.m_sessionName, (uint)template.m_sessionTimeout, template.m_identity, template.m_preferredLocales, template.m_checkDomain);
			session.RecreateSubscriptions(template.Subscriptions);
			return session;
		}
		catch (Exception e)
		{
			session.Dispose();
			throw ServiceResultException.Create(2147811328u, e, "Could not recreate session. {0}", template.m_sessionName);
		}
	}

	public static Session Recreate(Session template, ITransportChannel transportChannel)
	{
		template.m_configuration.CreateMessageContext().Factory = template.Factory;
		Session session = template.CloneSession(transportChannel, copyEventHandlers: true);
		try
		{
			session.Open(template.m_sessionName, (uint)template.m_sessionTimeout, template.m_identity, template.m_preferredLocales, template.m_checkDomain);
			foreach (Subscription subscription in session.Subscriptions)
			{
				subscription.Create();
			}
			return session;
		}
		catch (Exception e)
		{
			session.Dispose();
			throw ServiceResultException.Create(2147811328u, e, "Could not recreate session. {0}", template.m_sessionName);
		}
	}

	public bool ApplySessionConfiguration(SessionConfiguration sessionConfiguration)
	{
		if (sessionConfiguration == null)
		{
			throw new ArgumentNullException("sessionConfiguration");
		}
		byte[] array = m_endpoint.Description?.ServerCertificate;
		m_sessionName = sessionConfiguration.SessionName;
		m_serverCertificate = ((array != null) ? new X509Certificate2(array) : null);
		m_identity = sessionConfiguration.Identity;
		m_checkDomain = sessionConfiguration.CheckDomain;
		m_serverNonce = sessionConfiguration.ServerNonce;
		SessionCreated(sessionConfiguration.SessionId, sessionConfiguration.AuthenticationToken);
		return true;
	}

	public SessionConfiguration SaveSessionConfiguration(Stream stream = null)
	{
		SessionConfiguration sessionConfiguration = new SessionConfiguration(this, m_serverNonce, base.AuthenticationToken);
		if (stream != null)
		{
			XmlWriterSettings settings = Utils.DefaultXmlWriterSettings();
			using XmlWriter writer = XmlWriter.Create(stream, settings);
			new DataContractSerializer(typeof(SessionConfiguration)).WriteObject(writer, sessionConfiguration);
		}
		return sessionConfiguration;
	}

	public void Reconnect()
	{
		Reconnect(null, null);
	}

	public void Reconnect(ITransportWaitingConnection connection)
	{
		Reconnect(connection, null);
	}

	public void Reconnect(ITransportChannel channel)
	{
		Reconnect(null, channel);
	}

	private void Reconnect(ITransportWaitingConnection connection, ITransportChannel transportChannel = null)
	{
		bool flag = false;
		try
		{
			Utils.LogInfo("Session RECONNECT {0} starting.", base.SessionId);
			m_reconnectLock.Wait();
			bool reconnecting = m_reconnecting;
			m_reconnecting = true;
			flag = true;
			m_reconnectLock.Release();
			if (reconnecting)
			{
				Utils.LogWarning("Session is already attempting to reconnect.");
				throw ServiceResultException.Create(2158952448u, "Session is already attempting to reconnect.");
			}
			IAsyncResult asyncResult = PrepareReconnectBeginActivate(connection, transportChannel);
			if (!asyncResult.AsyncWaitHandle.WaitOne(7500))
			{
				Utils.LogWarning("WARNING: ACTIVATE SESSION timed out. {0}/{1}", GoodPublishRequestCount, OutstandingRequestCount);
			}
			byte[] serverNonce = null;
			StatusCodeCollection results = null;
			DiagnosticInfoCollection diagnosticInfos = null;
			EndActivateSession(asyncResult, out serverNonce, out results, out diagnosticInfos);
			int num = 0;
			Utils.LogInfo("Session RECONNECT {0} completed successfully.", base.SessionId);
			lock (base.SyncRoot)
			{
				m_previousServerNonce = m_serverNonce;
				m_serverNonce = serverNonce;
				num = GetMinPublishRequestCount(createdOnly: true);
			}
			m_reconnectLock.Wait();
			m_reconnecting = false;
			flag = false;
			m_reconnectLock.Release();
			for (int i = 0; i < num; i++)
			{
				BeginPublish(base.OperationTimeout);
			}
			StartKeepAliveTimer();
			IndicateSessionConfigurationChanged();
		}
		finally
		{
			if (flag)
			{
				m_reconnectLock.Wait();
				m_reconnecting = false;
				m_reconnectLock.Release();
			}
		}
	}

	public void Save(string filePath, IEnumerable<Type> knownTypes = null)
	{
		Save(filePath, Subscriptions, knownTypes);
	}

	public void Save(Stream stream, IEnumerable<Subscription> subscriptions, IEnumerable<Type> knownTypes = null)
	{
		SubscriptionCollection graph = new SubscriptionCollection(subscriptions);
		XmlWriterSettings settings = Utils.DefaultXmlWriterSettings();
		using XmlWriter writer = XmlWriter.Create(stream, settings);
		new DataContractSerializer(typeof(SubscriptionCollection), knownTypes).WriteObject(writer, graph);
	}

	public void Save(string filePath, IEnumerable<Subscription> subscriptions, IEnumerable<Type> knownTypes = null)
	{
		using FileStream stream = new FileStream(filePath, FileMode.Create);
		Save(stream, subscriptions, knownTypes);
	}

	public IEnumerable<Subscription> Load(Stream stream, bool transferSubscriptions = false, IEnumerable<Type> knownTypes = null)
	{
		XmlReaderSettings xmlReaderSettings = Utils.DefaultXmlReaderSettings();
		xmlReaderSettings.CloseInput = true;
		using XmlReader reader = XmlReader.Create(stream, xmlReaderSettings);
		SubscriptionCollection subscriptionCollection = (SubscriptionCollection)new DataContractSerializer(typeof(SubscriptionCollection), knownTypes).ReadObject(reader);
		foreach (Subscription item in subscriptionCollection)
		{
			if (!transferSubscriptions)
			{
				foreach (MonitoredItem monitoredItem in item.MonitoredItems)
				{
					monitoredItem.ServerId = 0u;
				}
			}
			AddSubscription(item);
		}
		return subscriptionCollection;
	}

	public IEnumerable<Subscription> Load(string filePath, bool transferSubscriptions = false, IEnumerable<Type> knownTypes = null)
	{
		using FileStream stream = File.OpenRead(filePath);
		return Load(stream, transferSubscriptions, knownTypes);
	}

	public void FetchNamespaceTables()
	{
		ReadValueIdCollection readValueIdCollection = PrepareNamespaceTableNodesToRead();
		DataValueCollection results;
		DiagnosticInfoCollection diagnosticInfos;
		ResponseHeader responseHeader = Read(null, 0.0, TimestampsToReturn.Neither, readValueIdCollection, out results, out diagnosticInfos);
		ClientBase.ValidateResponse(results, readValueIdCollection);
		ClientBase.ValidateDiagnosticInfos(diagnosticInfos, readValueIdCollection);
		UpdateNamespaceTable(results, diagnosticInfos, responseHeader);
	}

	public void FetchOperationLimits()
	{
		try
		{
			List<string> list = (from p in typeof(OperationLimits).GetProperties()
				select p.Name).ToList();
			NodeIdCollection nodeIdCollection = new NodeIdCollection(list.Select((string name) => (NodeId)typeof(VariableIds).GetField("Server_ServerCapabilities_OperationLimits_" + name, BindingFlags.Static | BindingFlags.Public).GetValue(null)));
			ReadValues(nodeIdCollection, Enumerable.Repeat(typeof(uint), nodeIdCollection.Count).ToList(), out var values, out var errors);
			OperationLimits obj = m_configuration?.ClientConfiguration?.OperationLimits ?? new OperationLimits();
			OperationLimits operationLimits = new OperationLimits();
			for (int num = 0; num < nodeIdCollection.Count; num++)
			{
				PropertyInfo property = typeof(OperationLimits).GetProperty(list[num]);
				uint num2 = (uint)property.GetValue(obj);
				if (values[num] != null && ServiceResult.IsNotBad(errors[num]))
				{
					uint num3 = (uint)values[num];
					if (num3 != 0 && (num2 == 0 || num3 < num2))
					{
						num2 = num3;
					}
				}
				property.SetValue(operationLimits, num2);
			}
			base.OperationLimits = operationLimits;
		}
		catch (Exception exception)
		{
			Utils.LogError(exception, "Failed to read operation limits from server. Using configuration defaults.");
			OperationLimits operationLimits2 = m_configuration?.ClientConfiguration?.OperationLimits;
			if (operationLimits2 != null)
			{
				base.OperationLimits = operationLimits2;
			}
		}
	}

	public void FetchTypeTree(ExpandedNodeId typeId)
	{
		if (!(NodeCache.Find(typeId) is Node node))
		{
			return;
		}
		ExpandedNodeIdCollection expandedNodeIdCollection = new ExpandedNodeIdCollection();
		foreach (IReference item in node.Find(ReferenceTypeIds.HasSubtype, isInverse: false))
		{
			expandedNodeIdCollection.Add(item.TargetId);
		}
		if (expandedNodeIdCollection.Count > 0)
		{
			FetchTypeTree(expandedNodeIdCollection);
		}
	}

	public void FetchTypeTree(ExpandedNodeIdCollection typeIds)
	{
		NodeIdCollection referenceTypeIds = new NodeIdCollection { ReferenceTypeIds.HasSubtype };
		IList<INode> list = NodeCache.FindReferences(typeIds, referenceTypeIds, isInverse: false, includeSubtypes: false);
		ExpandedNodeIdCollection expandedNodeIdCollection = new ExpandedNodeIdCollection();
		foreach (INode item in list)
		{
			if (!(item is Node node))
			{
				continue;
			}
			foreach (IReference item2 in node.Find(ReferenceTypeIds.HasSubtype, isInverse: false))
			{
				if (!typeIds.Contains(item2.TargetId))
				{
					expandedNodeIdCollection.Add(item2.TargetId);
				}
			}
		}
		if (expandedNodeIdCollection.Count > 0)
		{
			FetchTypeTree(expandedNodeIdCollection);
		}
	}

	public ReferenceDescriptionCollection ReadAvailableEncodings(NodeId variableId)
	{
		if (!(NodeCache.Find(variableId) is VariableNode variableNode))
		{
			throw ServiceResultException.Create(2150825984u, "NodeId does not refer to a valid variable node.");
		}
		if (NodeId.IsNull(variableNode.DataType))
		{
			return new ReferenceDescriptionCollection();
		}
		if (!TypeTree.IsTypeOf(variableNode.DataType, 22u))
		{
			return new ReferenceDescriptionCollection();
		}
		IList<INode> list = NodeCache.Find(variableId, ReferenceTypeIds.HasEncoding, isInverse: false, includeSubtypes: true);
		if (list.Count > 0)
		{
			ReferenceDescriptionCollection referenceDescriptionCollection = new ReferenceDescriptionCollection();
			{
				foreach (INode item in list)
				{
					ReferenceDescription referenceDescription = new ReferenceDescription();
					referenceDescription.ReferenceTypeId = ReferenceTypeIds.HasEncoding;
					referenceDescription.IsForward = true;
					referenceDescription.NodeId = item.NodeId;
					referenceDescription.NodeClass = item.NodeClass;
					referenceDescription.BrowseName = item.BrowseName;
					referenceDescription.DisplayName = item.DisplayName;
					referenceDescription.TypeDefinition = item.TypeDefinitionId;
					referenceDescriptionCollection.Add(referenceDescription);
				}
				return referenceDescriptionCollection;
			}
		}
		return new Browser(this)
		{
			BrowseDirection = BrowseDirection.Forward,
			ReferenceTypeId = ReferenceTypeIds.HasEncoding,
			IncludeSubtypes = false,
			NodeClassMask = 0
		}.Browse(variableNode.DataType);
	}

	public ReferenceDescription FindDataDescription(NodeId encodingId)
	{
		ReferenceDescriptionCollection referenceDescriptionCollection = new Browser(this)
		{
			BrowseDirection = BrowseDirection.Forward,
			ReferenceTypeId = ReferenceTypeIds.HasDescription,
			IncludeSubtypes = false,
			NodeClassMask = 0
		}.Browse(encodingId);
		if (referenceDescriptionCollection.Count == 0)
		{
			throw ServiceResultException.Create(2150825984u, "Encoding does not refer to a valid data description.");
		}
		return referenceDescriptionCollection[0];
	}

	public async Task<DataDictionary> FindDataDictionary(NodeId descriptionId, CancellationToken ct = default(CancellationToken))
	{
		foreach (DataDictionary value in m_dictionaries.Values)
		{
			if (value.Contains(descriptionId))
			{
				return value;
			}
		}
		IList<INode> list = await NodeCache.FindReferencesAsync(descriptionId, ReferenceTypeIds.HasComponent, isInverse: true, includeSubtypes: false, ct).ConfigureAwait(continueOnCapturedContext: false);
		if (list.Count == 0)
		{
			throw ServiceResultException.Create(2150825984u, "Description does not refer to a valid data dictionary.");
		}
		NodeId key = ExpandedNodeId.ToNodeId(list[0].NodeId, m_namespaceUris);
		DataDictionary dataDictionary = new DataDictionary(this);
		dataDictionary.Load(list[0]);
		m_dictionaries[key] = dataDictionary;
		return dataDictionary;
	}

	public DataDictionary LoadDataDictionary(ReferenceDescription dictionaryNode, bool forceReload = false)
	{
		NodeId nodeId = ExpandedNodeId.ToNodeId(dictionaryNode.NodeId, m_namespaceUris);
		if (!forceReload && m_dictionaries.TryGetValue(nodeId, out var value))
		{
			return value;
		}
		DataDictionary dataDictionary = new DataDictionary(this);
		dataDictionary.Load(nodeId, dictionaryNode.ToString());
		m_dictionaries[nodeId] = dataDictionary;
		return dataDictionary;
	}

	public async Task<Dictionary<NodeId, DataDictionary>> LoadDataTypeSystem(NodeId dataTypeSystem = null, CancellationToken ct = default(CancellationToken))
	{
		if (dataTypeSystem == null)
		{
			dataTypeSystem = ObjectIds.OPCBinarySchema_TypeSystem;
		}
		else if (!Utils.IsEqual(dataTypeSystem, ObjectIds.OPCBinarySchema_TypeSystem) && !Utils.IsEqual(dataTypeSystem, ObjectIds.XmlSchema_TypeSystem))
		{
			throw ServiceResultException.Create(2150825984u, "dataTypeSystem does not refer to a valid data dictionary.");
		}
		IList<INode> references = NodeCache.FindReferences(dataTypeSystem, ReferenceTypeIds.HasComponent, isInverse: false, includeSubtypes: false);
		if (references.Count == 0)
		{
			throw ServiceResultException.Create(2150825984u, "Type system does not contain a valid data dictionary.");
		}
		List<ExpandedNodeId> referenceNodeIds = references.Select((INode r) => r.NodeId).ToList();
		List<INode> source = (from n in NodeCache.FindReferences(referenceNodeIds, new NodeIdCollection { ReferenceTypeIds.HasProperty }, isInverse: false, includeSubtypes: false)
			where n.BrowseName == "NamespaceUri"
			select n).ToList();
		List<NodeId> namespaceNodeIds = source.Select((INode n) => ExpandedNodeId.ToNodeId(n.NodeId, NamespaceUris)).ToList();
		List<NodeId> dictionaryIds = (from r in references
			select ExpandedNodeId.ToNodeId(r.NodeId, NamespaceUris) into n
			where n.NamespaceIndex != 0
			select n).ToList();
		IDictionary<NodeId, byte[]> dictionary = await DataDictionary.ReadDictionaries(this, dictionaryIds, ct).ConfigureAwait(continueOnCapturedContext: false);
		Dictionary<NodeId, string> dictionary2 = new Dictionary<NodeId, string>();
		ReadValues(namespaceNodeIds, Enumerable.Repeat(typeof(string), namespaceNodeIds.Count).ToList(), out var values, out var errors);
		for (int num = 0; num < values.Count; num++)
		{
			if (StatusCode.IsNotBad(errors[num].StatusCode))
			{
				if (values[num] != null)
				{
					dictionary2[(NodeId)referenceNodeIds[num]] = (string)values[num];
				}
			}
			else
			{
				Utils.LogWarning("Failed to load namespace {0}: {1}", namespaceNodeIds[num], errors[num]);
			}
		}
		Dictionary<string, byte[]> dictionary3 = new Dictionary<string, byte[]>();
		foreach (INode item in references)
		{
			NodeId key = ExpandedNodeId.ToNodeId(item.NodeId, NamespaceUris);
			if (dictionary.TryGetValue(key, out var value) && dictionary2.TryGetValue(key, out var value2))
			{
				dictionary3[value2] = value;
			}
		}
		foreach (INode item2 in references)
		{
			DataDictionary value3 = null;
			NodeId nodeId = ExpandedNodeId.ToNodeId(item2.NodeId, m_namespaceUris);
			if (nodeId.NamespaceIndex == 0 || m_dictionaries.TryGetValue(nodeId, out value3))
			{
				continue;
			}
			try
			{
				value3 = new DataDictionary(this);
				if (dictionary.TryGetValue(nodeId, out var value4))
				{
					value3.Load(nodeId, nodeId.ToString(), value4, dictionary3);
				}
				else
				{
					value3.Load(nodeId, nodeId.ToString());
				}
				m_dictionaries[nodeId] = value3;
			}
			catch (Exception ex)
			{
				Utils.LogError("Dictionary load error for Dictionary {0} : {1}", item2.NodeId, ex.Message);
			}
		}
		return m_dictionaries;
	}

	public void ReadNodes(IList<NodeId> nodeIds, NodeClass nodeClass, out IList<Node> nodeCollection, out IList<ServiceResult> errors, bool optionalAttributes = false)
	{
		if (nodeIds.Count == 0)
		{
			nodeCollection = new NodeCollection();
			errors = new List<ServiceResult>();
			return;
		}
		if (nodeClass == NodeClass.Unspecified)
		{
			ReadNodes(nodeIds, out nodeCollection, out errors, optionalAttributes);
			return;
		}
		List<IDictionary<uint, DataValue>> attributesPerNodeId = new List<IDictionary<uint, DataValue>>(nodeIds.Count);
		ReadValueIdCollection readValueIdCollection = new ReadValueIdCollection();
		nodeCollection = new NodeCollection(nodeIds.Count);
		CreateNodeClassAttributesReadNodesRequest(nodeIds, nodeClass, readValueIdCollection, attributesPerNodeId, nodeCollection, optionalAttributes);
		DataValueCollection results;
		DiagnosticInfoCollection diagnosticInfos;
		ResponseHeader responseHeader = Read(null, 0.0, TimestampsToReturn.Neither, readValueIdCollection, out results, out diagnosticInfos);
		ClientBase.ValidateResponse(results, readValueIdCollection);
		ClientBase.ValidateDiagnosticInfos(diagnosticInfos, readValueIdCollection);
		errors = new ServiceResult[nodeIds.Count].ToList();
		ProcessAttributesReadNodesResponse(responseHeader, readValueIdCollection, attributesPerNodeId, results, diagnosticInfos, nodeCollection, errors);
	}

	public void ReadNodes(IList<NodeId> nodeIds, out IList<Node> nodeCollection, out IList<ServiceResult> errors, bool optionalAttributes = false)
	{
		int count = nodeIds.Count;
		nodeCollection = new NodeCollection(count);
		errors = new List<ServiceResult>(count);
		if (count != 0)
		{
			ReadValueIdCollection readValueIdCollection = new ReadValueIdCollection(nodeIds.Select((NodeId nodeId) => new ReadValueId
			{
				NodeId = nodeId,
				AttributeId = 2u
			}));
			DataValueCollection results = null;
			DiagnosticInfoCollection diagnosticInfos = null;
			ResponseHeader responseHeader = null;
			if (count > 1)
			{
				responseHeader = Read(null, 0.0, TimestampsToReturn.Neither, readValueIdCollection, out results, out diagnosticInfos);
				ClientBase.ValidateResponse(results, readValueIdCollection);
				ClientBase.ValidateDiagnosticInfos(diagnosticInfos, readValueIdCollection);
			}
			else
			{
				results = new DataValueCollection
				{
					new DataValue(new Variant(0), 0u)
				};
			}
			List<IDictionary<uint, DataValue>> attributesPerNodeId = new List<IDictionary<uint, DataValue>>(count);
			ReadValueIdCollection readValueIdCollection2 = new ReadValueIdCollection();
			CreateAttributesReadNodesRequest(responseHeader, readValueIdCollection, results, diagnosticInfos, readValueIdCollection2, attributesPerNodeId, nodeCollection, errors, optionalAttributes);
			if (readValueIdCollection2.Count > 0)
			{
				responseHeader = Read(null, 0.0, TimestampsToReturn.Neither, readValueIdCollection2, out var results2, out diagnosticInfos);
				ClientBase.ValidateResponse(results2, readValueIdCollection2);
				ClientBase.ValidateDiagnosticInfos(diagnosticInfos, readValueIdCollection2);
				ProcessAttributesReadNodesResponse(responseHeader, readValueIdCollection2, attributesPerNodeId, results2, diagnosticInfos, nodeCollection, errors);
			}
		}
	}

	public Node ReadNode(NodeId nodeId)
	{
		return ReadNode(nodeId, NodeClass.Unspecified);
	}

	public Node ReadNode(NodeId nodeId, NodeClass nodeClass, bool optionalAttributes = true)
	{
		IDictionary<uint, DataValue> dictionary = CreateAttributes(nodeClass, optionalAttributes);
		ReadValueIdCollection readValueIdCollection = new ReadValueIdCollection();
		foreach (uint key in dictionary.Keys)
		{
			ReadValueId item = new ReadValueId
			{
				NodeId = nodeId,
				AttributeId = key
			};
			readValueIdCollection.Add(item);
		}
		DataValueCollection results = null;
		DiagnosticInfoCollection diagnosticInfos = null;
		ResponseHeader responseHeader = Read(null, 0.0, TimestampsToReturn.Neither, readValueIdCollection, out results, out diagnosticInfos);
		ClientBase.ValidateResponse(results, readValueIdCollection);
		ClientBase.ValidateDiagnosticInfos(diagnosticInfos, readValueIdCollection);
		return ProcessReadResponse(responseHeader, dictionary, readValueIdCollection, results, diagnosticInfos);
	}

	public DataValue ReadValue(NodeId nodeId)
	{
		ReadValueId item = new ReadValueId
		{
			NodeId = nodeId,
			AttributeId = 13u
		};
		ReadValueIdCollection readValueIdCollection = new ReadValueIdCollection { item };
		DataValueCollection results = null;
		DiagnosticInfoCollection diagnosticInfos = null;
		ResponseHeader responseHeader = Read(null, 0.0, TimestampsToReturn.Both, readValueIdCollection, out results, out diagnosticInfos);
		ClientBase.ValidateResponse(results, readValueIdCollection);
		ClientBase.ValidateDiagnosticInfos(diagnosticInfos, readValueIdCollection);
		if (StatusCode.IsBad(results[0].StatusCode))
		{
			throw new ServiceResultException(ClientBase.GetResult(results[0].StatusCode, 0, diagnosticInfos, responseHeader));
		}
		return results[0];
	}

	public void ReadValues(IList<NodeId> nodeIds, out DataValueCollection values, out IList<ServiceResult> errors)
	{
		if (nodeIds.Count == 0)
		{
			values = new DataValueCollection();
			errors = new List<ServiceResult>();
			return;
		}
		ReadValueIdCollection readValueIdCollection = new ReadValueIdCollection(nodeIds.Select((NodeId nodeId) => new ReadValueId
		{
			NodeId = nodeId,
			AttributeId = 13u
		}));
		errors = new List<ServiceResult>(readValueIdCollection.Count);
		DiagnosticInfoCollection diagnosticInfos;
		ResponseHeader responseHeader = Read(null, 0.0, TimestampsToReturn.Both, readValueIdCollection, out values, out diagnosticInfos);
		ClientBase.ValidateResponse(values, readValueIdCollection);
		ClientBase.ValidateDiagnosticInfos(diagnosticInfos, readValueIdCollection);
		int num = 0;
		foreach (DataValue value in values)
		{
			ServiceResult item = ServiceResult.Good;
			if (StatusCode.IsNotGood(value.StatusCode))
			{
				item = ClientBase.GetResult(value.StatusCode, num, diagnosticInfos, responseHeader);
			}
			errors.Add(item);
			num++;
		}
	}

	public object ReadValue(NodeId nodeId, Type expectedType)
	{
		object obj = ReadValue(nodeId).Value;
		if (expectedType != null)
		{
			if (obj is ExtensionObject extensionObject)
			{
				obj = extensionObject.Body;
			}
			if (!expectedType.IsInstanceOfType(obj))
			{
				throw ServiceResultException.Create(2155085824u, "Server returned value unexpected type: {0}", (obj != null) ? obj.GetType().Name : "(null)");
			}
		}
		return obj;
	}

	public ReferenceDescriptionCollection FetchReferences(NodeId nodeId)
	{
		Browse(null, null, nodeId, 0u, BrowseDirection.Both, null, includeSubtypes: true, 0u, out var continuationPoint, out var references);
		while (continuationPoint != null)
		{
			BrowseNext(null, releaseContinuationPoint: false, continuationPoint, out var revisedContinuationPoint, out var references2);
			continuationPoint = revisedContinuationPoint;
			references.AddRange(references2);
		}
		return references;
	}

	public void FetchReferences(IList<NodeId> nodeIds, out IList<ReferenceDescriptionCollection> referenceDescriptions, out IList<ServiceResult> errors)
	{
		List<ReferenceDescriptionCollection> list = new List<ReferenceDescriptionCollection>();
		Browse(null, null, nodeIds, 0u, BrowseDirection.Both, null, includeSubtypes: true, 0u, out var continuationPoints, out var referencesList, out errors);
		list.AddRange(referencesList);
		List<ReferenceDescriptionCollection> list2 = list;
		IList<ServiceResult> list3 = errors;
		while (HasAnyContinuationPoint(continuationPoints))
		{
			ByteStringCollection byteStringCollection = new ByteStringCollection();
			List<ReferenceDescriptionCollection> list4 = new List<ReferenceDescriptionCollection>();
			List<ServiceResult> list5 = new List<ServiceResult>();
			for (int i = 0; i < continuationPoints.Count; i++)
			{
				byte[] array = continuationPoints[i];
				if (array != null)
				{
					byteStringCollection.Add(array);
					list4.Add(list2[i]);
					list5.Add(list3[i]);
				}
			}
			BrowseNext(null, releaseContinuationPoint: false, byteStringCollection, out var revisedContinuationPoints, out referencesList, out var errors2);
			continuationPoints = revisedContinuationPoints;
			list2 = list4;
			list3 = list5;
			for (int j = 0; j < referencesList.Count; j++)
			{
				list4[j].AddRange(referencesList[j]);
				if (StatusCode.IsBad(errors2[j].StatusCode))
				{
					list5[j] = errors2[j];
				}
			}
		}
		referenceDescriptions = list;
	}

	public void Open(string sessionName, IUserIdentity identity)
	{
		Open(sessionName, 0u, identity, null);
	}

	public void Open(string sessionName, uint sessionTimeout, IUserIdentity identity, IList<string> preferredLocales)
	{
		Open(sessionName, sessionTimeout, identity, preferredLocales, checkDomain: true);
	}

	public void Open(string sessionName, uint sessionTimeout, IUserIdentity identity, IList<string> preferredLocales, bool checkDomain)
	{
		OpenValidateIdentity(ref identity, out var identityToken, out var identityPolicy, out var securityPolicyUri, out var requireEncryption);
		X509Certificate2 x509Certificate = null;
		byte[] serverCertificate = m_endpoint.Description.ServerCertificate;
		if (serverCertificate != null && serverCertificate.Length != 0)
		{
			X509Certificate2Collection x509Certificate2Collection = Utils.ParseCertificateChainBlob(serverCertificate);
			if (x509Certificate2Collection.Count > 0)
			{
				x509Certificate = x509Certificate2Collection[0];
			}
			if (requireEncryption)
			{
				if (checkDomain)
				{
					m_configuration.CertificateValidator.Validate(x509Certificate2Collection, m_endpoint);
				}
				else
				{
					m_configuration.CertificateValidator.Validate(x509Certificate2Collection);
				}
				m_checkDomain = checkDomain;
			}
		}
		byte[] clientNonce = Utils.Nonce.CreateNonce((uint)m_configuration.SecurityConfiguration.NonceLength);
		NodeId sessionId = null;
		NodeId authenticationToken = null;
		byte[] serverNonce = Array.Empty<byte>();
		byte[] serverCertificate2 = Array.Empty<byte>();
		SignatureData serverSignature = null;
		EndpointDescriptionCollection serverEndpoints = null;
		SignedSoftwareCertificateCollection serverSoftwareCertificates = null;
		BuildCertificateData(out var clientCertificateData, out var clientCertificateChainData);
		ApplicationDescription clientDescription = new ApplicationDescription
		{
			ApplicationUri = m_configuration.ApplicationUri,
			ApplicationName = m_configuration.ApplicationName,
			ApplicationType = ApplicationType.Client,
			ProductUri = m_configuration.ProductUri
		};
		if (sessionTimeout == 0)
		{
			sessionTimeout = (uint)m_configuration.ClientConfiguration.DefaultSessionTimeout;
		}
		bool flag = false;
		if (m_endpoint.Description.SecurityPolicyUri == "http://opcfoundation.org/UA/SecurityPolicy#None")
		{
			try
			{
				base.CreateSession(null, clientDescription, m_endpoint.Description.Server.ApplicationUri, m_endpoint.EndpointUrl.ToString(), sessionName, clientNonce, null, sessionTimeout, (uint)base.MessageContext.MaxMessageSize, out sessionId, out authenticationToken, out m_sessionTimeout, out serverNonce, out serverCertificate2, out serverEndpoints, out serverSoftwareCertificates, out serverSignature, out m_maxRequestMessageSize);
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
			base.CreateSession(null, clientDescription, m_endpoint.Description.Server.ApplicationUri, m_endpoint.EndpointUrl.ToString(), sessionName, clientNonce, (clientCertificateChainData != null) ? clientCertificateChainData : clientCertificateData, sessionTimeout, (uint)base.MessageContext.MaxMessageSize, out sessionId, out authenticationToken, out m_sessionTimeout, out serverNonce, out serverCertificate2, out serverEndpoints, out serverSoftwareCertificates, out serverSignature, out m_maxRequestMessageSize);
		}
		lock (base.SyncRoot)
		{
			base.SessionCreated(sessionId, authenticationToken);
		}
		Utils.LogInfo("Revised session timeout value: {0}. ", m_sessionTimeout);
		Utils.LogInfo("Max response message size value: {0}. Max request message size: {1} ", base.MessageContext.MaxMessageSize, m_maxRequestMessageSize);
		try
		{
			ValidateServerCertificateData(serverCertificate2);
			ValidateServerEndpoints(serverEndpoints);
			ValidateServerSignature(x509Certificate, serverSignature, clientCertificateData, clientCertificateChainData, clientNonce);
			HandleSignedSoftwareCertificates(serverSoftwareCertificates);
			byte[] dataToSign = Utils.Append(x509Certificate?.RawData, serverNonce);
			SignatureData clientSignature = SecurityPolicies.Sign(m_instanceCertificate, securityPolicyUri, dataToSign);
			securityPolicyUri = identityPolicy.SecurityPolicyUri;
			if (string.IsNullOrEmpty(securityPolicyUri))
			{
				securityPolicyUri = m_endpoint.Description.SecurityPolicyUri;
			}
			byte[] previousServerNonce = null;
			if (base.TransportChannel.CurrentToken != null)
			{
				previousServerNonce = base.TransportChannel.CurrentToken.ServerNonce;
			}
			ValidateServerNonce(identity, serverNonce, securityPolicyUri, previousServerNonce, m_endpoint.Description.SecurityMode);
			SignatureData userTokenSignature = identityToken.Sign(dataToSign, securityPolicyUri);
			identityToken.Encrypt(x509Certificate, serverNonce, securityPolicyUri);
			SignedSoftwareCertificateCollection softwareCertificates = GetSoftwareCertificates();
			if (preferredLocales != null && preferredLocales.Count > 0)
			{
				m_preferredLocales = new StringCollection(preferredLocales);
			}
			StatusCodeCollection results = null;
			DiagnosticInfoCollection diagnosticInfos = null;
			ActivateSession(null, clientSignature, softwareCertificates, m_preferredLocales, new ExtensionObject(identityToken), userTokenSignature, out serverNonce, out results, out diagnosticInfos);
			if (results != null)
			{
				for (int i = 0; i < results.Count; i++)
				{
					Utils.LogInfo("ActivateSession result[{0}] = {1}", i, results[i]);
				}
			}
			if (results == null || results.Count == 0)
			{
				Utils.LogInfo("Empty results were received for the ActivateSession call.");
			}
			FetchNamespaceTables();
			lock (base.SyncRoot)
			{
				m_sessionName = sessionName;
				m_identity = identity;
				m_previousServerNonce = previousServerNonce;
				m_serverNonce = serverNonce;
				m_serverCertificate = x509Certificate;
				m_systemContext.PreferredLocales = m_preferredLocales;
				m_systemContext.SessionId = base.SessionId;
				m_systemContext.UserIdentity = identity;
			}
			FetchOperationLimits();
			StartKeepAliveTimer();
			IndicateSessionConfigurationChanged();
		}
		catch (Exception)
		{
			try
			{
				CloseSession(null, deleteSubscriptions: false);
				CloseChannel();
			}
			catch (Exception ex3)
			{
				Utils.LogError("Cleanup: CloseSession() or CloseChannel() raised exception. " + ex3.Message);
			}
			finally
			{
				SessionCreated(null, null);
			}
			throw;
		}
	}

	public void ChangePreferredLocales(StringCollection preferredLocales)
	{
		UpdateSession(Identity, preferredLocales);
	}

	public void UpdateSession(IUserIdentity identity, StringCollection preferredLocales)
	{
		byte[] serverNonce = null;
		lock (base.SyncRoot)
		{
			if (!base.Connected)
			{
				throw new ServiceResultException(2158952448u, "Not connected to server.");
			}
			serverNonce = m_serverNonce;
			if (preferredLocales == null)
			{
				preferredLocales = m_preferredLocales;
			}
		}
		UserIdentityToken userIdentityToken = null;
		SignatureData signatureData = null;
		string securityPolicyUri = m_endpoint.Description.SecurityPolicyUri;
		byte[] dataToSign = Utils.Append((m_serverCertificate != null) ? m_serverCertificate.RawData : null, serverNonce);
		SignatureData clientSignature = SecurityPolicies.Sign(m_instanceCertificate, securityPolicyUri, dataToSign);
		if (identity == null)
		{
			identity = new UserIdentity();
		}
		UserTokenPolicy userTokenPolicy = m_endpoint.Description.FindUserTokenPolicy(identity.TokenType, identity.IssuedTokenType);
		if (userTokenPolicy == null)
		{
			throw ServiceResultException.Create(2149515264u, "Endpoint does not support the user identity type provided.");
		}
		securityPolicyUri = userTokenPolicy.SecurityPolicyUri;
		if (string.IsNullOrEmpty(securityPolicyUri))
		{
			securityPolicyUri = m_endpoint.Description.SecurityPolicyUri;
		}
		bool flag = securityPolicyUri != "http://opcfoundation.org/UA/SecurityPolicy#None";
		if (m_serverCertificate != null && flag && identity.TokenType != UserTokenType.Anonymous)
		{
			m_configuration.CertificateValidator.Validate(m_serverCertificate);
		}
		ValidateServerNonce(identity, serverNonce, securityPolicyUri, m_previousServerNonce, m_endpoint.Description.SecurityMode);
		userIdentityToken = identity.GetIdentityToken();
		userIdentityToken.PolicyId = userTokenPolicy.PolicyId;
		signatureData = userIdentityToken.Sign(dataToSign, securityPolicyUri);
		userIdentityToken.Encrypt(m_serverCertificate, serverNonce, securityPolicyUri);
		SignedSoftwareCertificateCollection softwareCertificates = GetSoftwareCertificates();
		StatusCodeCollection results = null;
		DiagnosticInfoCollection diagnosticInfos = null;
		ActivateSession(null, clientSignature, softwareCertificates, preferredLocales, new ExtensionObject(userIdentityToken), signatureData, out serverNonce, out results, out diagnosticInfos);
		lock (base.SyncRoot)
		{
			if (identity != null)
			{
				m_identity = identity;
			}
			m_previousServerNonce = m_serverNonce;
			m_serverNonce = serverNonce;
			m_preferredLocales = preferredLocales;
			m_systemContext.PreferredLocales = m_preferredLocales;
			m_systemContext.SessionId = base.SessionId;
			m_systemContext.UserIdentity = identity;
		}
		IndicateSessionConfigurationChanged();
	}

	public void FindComponentIds(NodeId instanceId, IList<string> componentPaths, out NodeIdCollection componentIds, out List<ServiceResult> errors)
	{
		componentIds = new NodeIdCollection();
		errors = new List<ServiceResult>();
		BrowsePathCollection browsePathCollection = new BrowsePathCollection();
		for (int i = 0; i < componentPaths.Count; i++)
		{
			BrowsePath browsePath = new BrowsePath();
			browsePath.StartingNode = instanceId;
			browsePath.RelativePath = RelativePath.Parse(componentPaths[i], TypeTree);
			browsePathCollection.Add(browsePath);
		}
		BrowsePathResultCollection results = null;
		DiagnosticInfoCollection diagnosticInfos = null;
		ResponseHeader responseHeader = TranslateBrowsePathsToNodeIds(null, browsePathCollection, out results, out diagnosticInfos);
		ClientBase.ValidateResponse(results, browsePathCollection);
		ClientBase.ValidateDiagnosticInfos(diagnosticInfos, browsePathCollection);
		for (int j = 0; j < componentPaths.Count; j++)
		{
			componentIds.Add(NodeId.Null);
			errors.Add(ServiceResult.Good);
			if (StatusCode.IsBad(results[j].StatusCode))
			{
				errors[j] = new ServiceResult(results[j].StatusCode, j, diagnosticInfos, responseHeader.StringTable);
			}
			else if (results[j].Targets.Count == 0)
			{
				errors[j] = ServiceResult.Create(2154102784u, "Could not find target for path: {0}.", componentPaths[j]);
			}
			else if (results[j].Targets.Count != 1)
			{
				errors[j] = ServiceResult.Create(2154627072u, "Too many matches found for path: {0}.", componentPaths[j]);
			}
			else if (results[j].Targets[0].RemainingPathIndex != uint.MaxValue)
			{
				errors[j] = ServiceResult.Create(2154102784u, "Cannot follow path to external server: {0}.", componentPaths[j]);
			}
			else if (NodeId.IsNull(results[j].Targets[0].TargetId))
			{
				errors[j] = ServiceResult.Create(2147549184u, "Server returned a null NodeId for path: {0}.", componentPaths[j]);
			}
			else if (results[j].Targets[0].TargetId.IsAbsolute)
			{
				errors[j] = ServiceResult.Create(2147549184u, "Server returned a remote node for path: {0}.", componentPaths[j]);
			}
			else
			{
				componentIds[j] = ExpandedNodeId.ToNodeId(results[j].Targets[0].TargetId, m_namespaceUris);
			}
		}
	}

	public void ReadValues(IList<NodeId> variableIds, IList<Type> expectedTypes, out List<object> values, out List<ServiceResult> errors)
	{
		values = new List<object>();
		errors = new List<ServiceResult>();
		ReadValueIdCollection readValueIdCollection = new ReadValueIdCollection();
		for (int i = 0; i < variableIds.Count; i++)
		{
			ReadValueId readValueId = new ReadValueId();
			readValueId.NodeId = variableIds[i];
			readValueId.AttributeId = 13u;
			readValueId.IndexRange = null;
			readValueId.DataEncoding = null;
			readValueIdCollection.Add(readValueId);
		}
		DataValueCollection results = null;
		DiagnosticInfoCollection diagnosticInfos = null;
		ResponseHeader responseHeader = Read(null, 0.0, TimestampsToReturn.Both, readValueIdCollection, out results, out diagnosticInfos);
		ClientBase.ValidateResponse(results, readValueIdCollection);
		ClientBase.ValidateDiagnosticInfos(diagnosticInfos, readValueIdCollection);
		for (int j = 0; j < variableIds.Count; j++)
		{
			values.Add(null);
			errors.Add(ServiceResult.Good);
			if (StatusCode.IsNotGood(results[j].StatusCode))
			{
				errors[j] = new ServiceResult(results[j].StatusCode, j, diagnosticInfos, responseHeader.StringTable);
				if (StatusCode.IsBad(results[j].StatusCode))
				{
					continue;
				}
			}
			object obj = results[j].Value;
			if (obj is ExtensionObject extensionObject && extensionObject.Body is IEncodeable)
			{
				obj = extensionObject.Body;
			}
			if (expectedTypes[j] != null && !expectedTypes[j].IsInstanceOfType(obj))
			{
				errors[j] = ServiceResult.Create(2155085824u, "Value {0} does not have expected type: {1}.", obj, expectedTypes[j].Name);
			}
			else
			{
				values[j] = obj;
			}
		}
	}

	public void ReadDisplayName(IList<NodeId> nodeIds, out IList<string> displayNames, out IList<ServiceResult> errors)
	{
		displayNames = new List<string>();
		errors = new List<ServiceResult>();
		ReadValueIdCollection readValueIdCollection = new ReadValueIdCollection();
		for (int i = 0; i < nodeIds.Count; i++)
		{
			ReadValueId readValueId = new ReadValueId();
			readValueId.NodeId = nodeIds[i];
			readValueId.AttributeId = 4u;
			readValueId.IndexRange = null;
			readValueId.DataEncoding = null;
			readValueIdCollection.Add(readValueId);
		}
		DataValueCollection results = null;
		DiagnosticInfoCollection diagnosticInfos = null;
		ResponseHeader responseHeader = Read(null, 2147483647.0, TimestampsToReturn.Neither, readValueIdCollection, out results, out diagnosticInfos);
		ClientBase.ValidateResponse(results, readValueIdCollection);
		ClientBase.ValidateDiagnosticInfos(diagnosticInfos, readValueIdCollection);
		for (int j = 0; j < nodeIds.Count; j++)
		{
			displayNames.Add(string.Empty);
			errors.Add(ServiceResult.Good);
			if (StatusCode.IsNotGood(results[j].StatusCode))
			{
				errors[j] = new ServiceResult(results[j].StatusCode, j, diagnosticInfos, responseHeader.StringTable);
				continue;
			}
			LocalizedText value = results[j].GetValue<LocalizedText>(null);
			if (!LocalizedText.IsNullOrEmpty(value))
			{
				displayNames[j] = value.Text;
			}
		}
	}

	public override bool Equals(object obj)
	{
		if (this == obj)
		{
			return true;
		}
		if (obj is ISession session)
		{
			if (!m_endpoint.Equals(session.Endpoint))
			{
				return false;
			}
			if (!m_sessionName.Equals(session.SessionName, StringComparison.Ordinal))
			{
				return false;
			}
			if (!base.SessionId.Equals(session.SessionId))
			{
				return false;
			}
			return true;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(m_endpoint, m_sessionName, base.SessionId);
	}

	public virtual Session CloneSession(ITransportChannel channel, bool copyEventHandlers)
	{
		return new Session(channel, this, copyEventHandlers);
	}

	public override StatusCode Close()
	{
		return Close(m_keepAliveInterval, closeChannel: true);
	}

	public StatusCode Close(bool closeChannel)
	{
		return Close(m_keepAliveInterval, closeChannel);
	}

	public StatusCode Close(int timeout)
	{
		return Close(timeout, closeChannel: true);
	}

	public virtual StatusCode Close(int timeout, bool closeChannel)
	{
		if (base.Disposed)
		{
			return 0u;
		}
		StatusCode statusCode = 0u;
		StopKeepAliveTimer();
		bool connected = base.Connected;
		if (connected && this.m_SessionClosing != null)
		{
			try
			{
				this.m_SessionClosing(this, null);
			}
			catch (Exception exception)
			{
				Utils.LogError(exception, "Session: Unexpected eror raising SessionClosing event.");
			}
		}
		if (connected && !KeepAliveStopped)
		{
			int operationTimeout = base.OperationTimeout;
			try
			{
				base.OperationTimeout = timeout;
				CloseSession(null, m_deleteSubscriptionsOnClose);
				base.OperationTimeout = operationTimeout;
				if (closeChannel)
				{
					CloseChannel();
				}
				SessionCreated(null, null);
			}
			catch (Exception ex)
			{
				statusCode = ((!(ex is ServiceResultException ex2)) ? ((StatusCode)2147483648u) : ((StatusCode)ex2.StatusCode));
				StatusCode statusCode2 = statusCode;
				Utils.LogError("Session close error: " + statusCode2.ToString());
			}
		}
		if (closeChannel)
		{
			Dispose();
		}
		return statusCode;
	}

	public bool AddSubscription(Subscription subscription)
	{
		if (subscription == null)
		{
			throw new ArgumentNullException("subscription");
		}
		lock (base.SyncRoot)
		{
			if (m_subscriptions.Contains(subscription))
			{
				return false;
			}
			subscription.Session = this;
			m_subscriptions.Add(subscription);
		}
		if (this.m_SubscriptionsChanged != null)
		{
			this.m_SubscriptionsChanged(this, null);
		}
		return true;
	}

	public bool RemoveSubscription(Subscription subscription)
	{
		if (subscription == null)
		{
			throw new ArgumentNullException("subscription");
		}
		if (subscription.Created)
		{
			subscription.Delete(silent: false);
		}
		lock (base.SyncRoot)
		{
			if (!m_subscriptions.Remove(subscription))
			{
				return false;
			}
			subscription.Session = null;
		}
		if (this.m_SubscriptionsChanged != null)
		{
			this.m_SubscriptionsChanged(this, null);
		}
		return true;
	}

	public bool RemoveSubscriptions(IEnumerable<Subscription> subscriptions)
	{
		if (subscriptions == null)
		{
			throw new ArgumentNullException("subscriptions");
		}
		List<Subscription> list = new List<Subscription>();
		bool flag = PrepareSubscriptionsToDelete(subscriptions, list);
		foreach (Subscription item in list)
		{
			item.Delete(silent: true);
		}
		if (flag && this.m_SubscriptionsChanged != null)
		{
			this.m_SubscriptionsChanged(this, null);
		}
		return flag;
	}

	public bool RemoveTransferredSubscription(Subscription subscription)
	{
		if (subscription == null)
		{
			throw new ArgumentNullException("subscription");
		}
		if (subscription.Session != this)
		{
			return false;
		}
		lock (base.SyncRoot)
		{
			if (!m_subscriptions.Remove(subscription))
			{
				return false;
			}
			subscription.Session = null;
		}
		if (this.m_SubscriptionsChanged != null)
		{
			this.m_SubscriptionsChanged(this, null);
		}
		return true;
	}

	public bool ReactivateSubscriptions(SubscriptionCollection subscriptions, bool sendInitialValues)
	{
		int num = 0;
		UInt32Collection uInt32Collection = CreateSubscriptionIdsForTransfer(subscriptions);
		if (uInt32Collection.Count > 0)
		{
			try
			{
				m_reconnectLock.Wait();
				m_reconnecting = true;
				for (int i = 0; i < subscriptions.Count; i++)
				{
					if (!subscriptions[i].Transfer(this, uInt32Collection[i], new UInt32Collection()))
					{
						Utils.LogError("SubscriptionId {0} failed to reactivate.", uInt32Collection[i]);
						num++;
					}
				}
				if (sendInitialValues)
				{
					if (!ResendData(subscriptions, out var errors))
					{
						Utils.LogError("Failed to call resend data for subscriptions.");
					}
					else if (errors != null)
					{
						for (int j = 0; j < errors.Count; j++)
						{
							if (StatusCode.IsNotGood(errors[j].StatusCode))
							{
								Utils.LogError("SubscriptionId {0} failed to resend data.", uInt32Collection[j]);
							}
						}
					}
				}
				Utils.LogInfo("Session REACTIVATE of {0} subscriptions completed. {1} failed.", subscriptions.Count, num);
			}
			finally
			{
				m_reconnecting = false;
				m_reconnectLock.Release();
			}
			RestartPublishing();
		}
		else
		{
			Utils.LogInfo("No subscriptions. Transfersubscription skipped.");
		}
		return num == 0;
	}

	public bool TransferSubscriptions(SubscriptionCollection subscriptions, bool sendInitialValues)
	{
		int num = 0;
		UInt32Collection uInt32Collection = CreateSubscriptionIdsForTransfer(subscriptions);
		if (uInt32Collection.Count > 0)
		{
			if (m_reconnecting)
			{
				Utils.LogWarning("Already Reconnecting. Can not transfer subscriptions.");
				return false;
			}
			try
			{
				m_reconnectLock.Wait();
				m_reconnecting = true;
				TransferResultCollection results;
				DiagnosticInfoCollection diagnosticInfos;
				ResponseHeader responseHeader = base.TransferSubscriptions(null, uInt32Collection, sendInitialValues, out results, out diagnosticInfos);
				if (!StatusCode.IsGood(responseHeader.ServiceResult))
				{
					Utils.LogError("TransferSubscription failed: {0}", responseHeader.ServiceResult);
					return false;
				}
				ClientBase.ValidateResponse(results, uInt32Collection);
				ClientBase.ValidateDiagnosticInfos(diagnosticInfos, uInt32Collection);
				for (int i = 0; i < subscriptions.Count; i++)
				{
					if (StatusCode.IsGood(results[i].StatusCode))
					{
						if (!subscriptions[i].Transfer(this, uInt32Collection[i], results[i].AvailableSequenceNumbers))
						{
							continue;
						}
						lock (base.SyncRoot)
						{
							foreach (uint availableSequenceNumber in results[i].AvailableSequenceNumbers)
							{
								SubscriptionAcknowledgement item = new SubscriptionAcknowledgement
								{
									SubscriptionId = uInt32Collection[i],
									SequenceNumber = availableSequenceNumber
								};
								m_acknowledgementsToSend.Add(item);
							}
						}
					}
					else if (results[i].StatusCode == 2148466688u)
					{
						Utils.LogInfo("SubscriptionId {0} is already member of the session.", uInt32Collection[i]);
						num++;
					}
					else
					{
						Utils.LogError("SubscriptionId {0} failed to transfer, StatusCode={1}", uInt32Collection[i], results[i].StatusCode);
						num++;
					}
				}
				Utils.LogInfo("Session TRANSFER of {0} subscriptions completed. {1} failed.", subscriptions.Count, num);
			}
			finally
			{
				m_reconnecting = false;
				m_reconnectLock.Release();
			}
			RestartPublishing();
		}
		else
		{
			Utils.LogInfo("No subscriptions. Transfersubscription skipped.");
		}
		return num == 0;
	}

	public virtual ResponseHeader Browse(RequestHeader requestHeader, ViewDescription view, NodeId nodeToBrowse, uint maxResultsToReturn, BrowseDirection browseDirection, NodeId referenceTypeId, bool includeSubtypes, uint nodeClassMask, out byte[] continuationPoint, out ReferenceDescriptionCollection references)
	{
		BrowseDescription browseDescription = new BrowseDescription();
		browseDescription.NodeId = nodeToBrowse;
		browseDescription.BrowseDirection = browseDirection;
		browseDescription.ReferenceTypeId = referenceTypeId;
		browseDescription.IncludeSubtypes = includeSubtypes;
		browseDescription.NodeClassMask = nodeClassMask;
		browseDescription.ResultMask = 63u;
		BrowseDescriptionCollection browseDescriptionCollection = new BrowseDescriptionCollection();
		browseDescriptionCollection.Add(browseDescription);
		BrowseResultCollection results;
		DiagnosticInfoCollection diagnosticInfos;
		ResponseHeader responseHeader = Browse(requestHeader, view, maxResultsToReturn, browseDescriptionCollection, out results, out diagnosticInfos);
		ClientBase.ValidateResponse(results, browseDescriptionCollection);
		ClientBase.ValidateDiagnosticInfos(diagnosticInfos, browseDescriptionCollection);
		if (StatusCode.IsBad(results[0].StatusCode))
		{
			throw new ServiceResultException(new ServiceResult(results[0].StatusCode, 0, diagnosticInfos, responseHeader.StringTable));
		}
		continuationPoint = results[0].ContinuationPoint;
		references = results[0].References;
		return responseHeader;
	}

	public virtual ResponseHeader Browse(RequestHeader requestHeader, ViewDescription view, IList<NodeId> nodesToBrowse, uint maxResultsToReturn, BrowseDirection browseDirection, NodeId referenceTypeId, bool includeSubtypes, uint nodeClassMask, out ByteStringCollection continuationPoints, out IList<ReferenceDescriptionCollection> referencesList, out IList<ServiceResult> errors)
	{
		BrowseDescriptionCollection browseDescriptionCollection = new BrowseDescriptionCollection();
		foreach (NodeId item2 in nodesToBrowse)
		{
			BrowseDescription item = new BrowseDescription
			{
				NodeId = item2,
				BrowseDirection = browseDirection,
				ReferenceTypeId = referenceTypeId,
				IncludeSubtypes = includeSubtypes,
				NodeClassMask = nodeClassMask,
				ResultMask = 63u
			};
			browseDescriptionCollection.Add(item);
		}
		BrowseResultCollection results;
		DiagnosticInfoCollection diagnosticInfos;
		ResponseHeader responseHeader = Browse(requestHeader, view, maxResultsToReturn, browseDescriptionCollection, out results, out diagnosticInfos);
		ClientBase.ValidateResponse(results, browseDescriptionCollection);
		ClientBase.ValidateDiagnosticInfos(diagnosticInfos, browseDescriptionCollection);
		int num = 0;
		errors = new List<ServiceResult>();
		continuationPoints = new ByteStringCollection();
		referencesList = new List<ReferenceDescriptionCollection>();
		foreach (BrowseResult item3 in results)
		{
			if (StatusCode.IsBad(item3.StatusCode))
			{
				errors.Add(new ServiceResult(item3.StatusCode, num, diagnosticInfos, responseHeader.StringTable));
			}
			else
			{
				errors.Add(ServiceResult.Good);
			}
			continuationPoints.Add(item3.ContinuationPoint);
			referencesList.Add(item3.References);
			num++;
		}
		return responseHeader;
	}

	public IAsyncResult BeginBrowse(RequestHeader requestHeader, ViewDescription view, NodeId nodeToBrowse, uint maxResultsToReturn, BrowseDirection browseDirection, NodeId referenceTypeId, bool includeSubtypes, uint nodeClassMask, AsyncCallback callback, object asyncState)
	{
		BrowseDescription browseDescription = new BrowseDescription();
		browseDescription.NodeId = nodeToBrowse;
		browseDescription.BrowseDirection = browseDirection;
		browseDescription.ReferenceTypeId = referenceTypeId;
		browseDescription.IncludeSubtypes = includeSubtypes;
		browseDescription.NodeClassMask = nodeClassMask;
		browseDescription.ResultMask = 63u;
		BrowseDescriptionCollection browseDescriptionCollection = new BrowseDescriptionCollection();
		browseDescriptionCollection.Add(browseDescription);
		return BeginBrowse(requestHeader, view, maxResultsToReturn, browseDescriptionCollection, callback, asyncState);
	}

	public ResponseHeader EndBrowse(IAsyncResult result, out byte[] continuationPoint, out ReferenceDescriptionCollection references)
	{
		BrowseResultCollection results;
		DiagnosticInfoCollection diagnosticInfos;
		ResponseHeader responseHeader = EndBrowse(result, out results, out diagnosticInfos);
		if (results == null || results.Count != 1)
		{
			throw new ServiceResultException(2148073472u);
		}
		if (StatusCode.IsBad(results[0].StatusCode))
		{
			throw new ServiceResultException(new ServiceResult(results[0].StatusCode, 0, diagnosticInfos, responseHeader.StringTable));
		}
		continuationPoint = results[0].ContinuationPoint;
		references = results[0].References;
		return responseHeader;
	}

	public virtual ResponseHeader BrowseNext(RequestHeader requestHeader, bool releaseContinuationPoint, byte[] continuationPoint, out byte[] revisedContinuationPoint, out ReferenceDescriptionCollection references)
	{
		ByteStringCollection byteStringCollection = new ByteStringCollection();
		byteStringCollection.Add(continuationPoint);
		BrowseResultCollection results;
		DiagnosticInfoCollection diagnosticInfos;
		ResponseHeader responseHeader = BrowseNext(requestHeader, releaseContinuationPoint, byteStringCollection, out results, out diagnosticInfos);
		ClientBase.ValidateResponse(results, byteStringCollection);
		ClientBase.ValidateDiagnosticInfos(diagnosticInfos, byteStringCollection);
		if (StatusCode.IsBad(results[0].StatusCode))
		{
			throw new ServiceResultException(new ServiceResult(results[0].StatusCode, 0, diagnosticInfos, responseHeader.StringTable));
		}
		revisedContinuationPoint = results[0].ContinuationPoint;
		references = results[0].References;
		return responseHeader;
	}

	public virtual ResponseHeader BrowseNext(RequestHeader requestHeader, bool releaseContinuationPoint, ByteStringCollection continuationPoints, out ByteStringCollection revisedContinuationPoints, out IList<ReferenceDescriptionCollection> referencesList, out IList<ServiceResult> errors)
	{
		BrowseResultCollection results;
		DiagnosticInfoCollection diagnosticInfos;
		ResponseHeader responseHeader = BrowseNext(requestHeader, releaseContinuationPoint, continuationPoints, out results, out diagnosticInfos);
		ClientBase.ValidateResponse(results, continuationPoints);
		ClientBase.ValidateDiagnosticInfos(diagnosticInfos, continuationPoints);
		int num = 0;
		errors = new List<ServiceResult>();
		revisedContinuationPoints = new ByteStringCollection();
		referencesList = new List<ReferenceDescriptionCollection>();
		foreach (BrowseResult item in results)
		{
			if (StatusCode.IsBad(item.StatusCode))
			{
				errors.Add(new ServiceResult(item.StatusCode, num, diagnosticInfos, responseHeader.StringTable));
			}
			else
			{
				errors.Add(ServiceResult.Good);
			}
			revisedContinuationPoints.Add(item.ContinuationPoint);
			referencesList.Add(item.References);
			num++;
		}
		return responseHeader;
	}

	public IAsyncResult BeginBrowseNext(RequestHeader requestHeader, bool releaseContinuationPoint, byte[] continuationPoint, AsyncCallback callback, object asyncState)
	{
		ByteStringCollection byteStringCollection = new ByteStringCollection();
		byteStringCollection.Add(continuationPoint);
		return BeginBrowseNext(requestHeader, releaseContinuationPoint, byteStringCollection, callback, asyncState);
	}

	public ResponseHeader EndBrowseNext(IAsyncResult result, out byte[] revisedContinuationPoint, out ReferenceDescriptionCollection references)
	{
		BrowseResultCollection results;
		DiagnosticInfoCollection diagnosticInfos;
		ResponseHeader responseHeader = EndBrowseNext(result, out results, out diagnosticInfos);
		if (results == null || results.Count != 1)
		{
			throw new ServiceResultException(2148073472u);
		}
		if (StatusCode.IsBad(results[0].StatusCode))
		{
			throw new ServiceResultException(new ServiceResult(results[0].StatusCode, 0, diagnosticInfos, responseHeader.StringTable));
		}
		revisedContinuationPoint = results[0].ContinuationPoint;
		references = results[0].References;
		return responseHeader;
	}

	public IList<object> Call(NodeId objectId, NodeId methodId, params object[] args)
	{
		VariantCollection variantCollection = new VariantCollection();
		if (args != null)
		{
			for (int i = 0; i < args.Length; i++)
			{
				variantCollection.Add(new Variant(args[i]));
			}
		}
		CallMethodRequest callMethodRequest = new CallMethodRequest();
		callMethodRequest.ObjectId = objectId;
		callMethodRequest.MethodId = methodId;
		callMethodRequest.InputArguments = variantCollection;
		CallMethodRequestCollection callMethodRequestCollection = new CallMethodRequestCollection();
		callMethodRequestCollection.Add(callMethodRequest);
		CallMethodResultCollection results;
		DiagnosticInfoCollection diagnosticInfos;
		ResponseHeader responseHeader = Call(null, callMethodRequestCollection, out results, out diagnosticInfos);
		ClientBase.ValidateResponse(results, callMethodRequestCollection);
		ClientBase.ValidateDiagnosticInfos(diagnosticInfos, callMethodRequestCollection);
		if (StatusCode.IsBad(results[0].StatusCode))
		{
			throw ServiceResultException.Create(results[0].StatusCode, 0, diagnosticInfos, responseHeader.StringTable);
		}
		List<object> list = new List<object>();
		foreach (Variant outputArgument in results[0].OutputArguments)
		{
			list.Add(outputArgument.Value);
		}
		return list;
	}

	protected virtual SignedSoftwareCertificateCollection GetSoftwareCertificates()
	{
		return new SignedSoftwareCertificateCollection();
	}

	protected virtual void OnApplicationCertificateError(byte[] serverCertificate, ServiceResult result)
	{
		throw new ServiceResultException(result);
	}

	protected virtual void OnSoftwareCertificateError(SignedSoftwareCertificate signedCertificate, ServiceResult result)
	{
		throw new ServiceResultException(result);
	}

	protected virtual void ValidateSoftwareCertificates(List<SoftwareCertificate> softwareCertificates)
	{
	}

	private void StartKeepAliveTimer()
	{
		int keepAliveInterval = m_keepAliveInterval;
		lock (m_eventLock)
		{
			m_serverState = ServerState.Unknown;
			m_lastKeepAliveTime = DateTime.UtcNow;
		}
		ReadValueIdCollection state = new ReadValueIdCollection
		{
			new ReadValueId
			{
				NodeId = 2259u,
				AttributeId = 13u,
				DataEncoding = null,
				IndexRange = null
			}
		};
		lock (base.SyncRoot)
		{
			StopKeepAliveTimer();
			m_keepAliveTimer = new Timer(OnKeepAlive, state, keepAliveInterval, keepAliveInterval);
		}
		OnKeepAlive(state);
	}

	private void StopKeepAliveTimer()
	{
		Utils.SilentDispose(m_keepAliveTimer);
		m_keepAliveTimer = null;
	}

	private AsyncRequestState RemoveRequest(IAsyncResult result, uint requestId, uint typeId)
	{
		lock (m_outstandingRequests)
		{
			for (LinkedListNode<AsyncRequestState> linkedListNode = m_outstandingRequests.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
			{
				if (result == linkedListNode.Value.Result || (requestId == linkedListNode.Value.RequestId && typeId == linkedListNode.Value.RequestTypeId))
				{
					AsyncRequestState value = linkedListNode.Value;
					m_outstandingRequests.Remove(linkedListNode);
					return value;
				}
			}
			return null;
		}
	}

	private void AsyncRequestStarted(IAsyncResult result, uint requestId, uint typeId)
	{
		lock (m_outstandingRequests)
		{
			AsyncRequestState asyncRequestState = RemoveRequest(result, requestId, typeId);
			if (asyncRequestState == null)
			{
				asyncRequestState = new AsyncRequestState();
				asyncRequestState.Defunct = false;
				asyncRequestState.RequestId = requestId;
				asyncRequestState.RequestTypeId = typeId;
				asyncRequestState.Result = result;
				asyncRequestState.Timestamp = DateTime.UtcNow;
				m_outstandingRequests.AddLast(asyncRequestState);
			}
		}
	}

	private void AsyncRequestCompleted(IAsyncResult result, uint requestId, uint typeId)
	{
		lock (m_outstandingRequests)
		{
			AsyncRequestState asyncRequestState = RemoveRequest(result, requestId, typeId);
			if (asyncRequestState != null)
			{
				DateTime dateTime = asyncRequestState.Timestamp.AddSeconds(-1.0);
				for (LinkedListNode<AsyncRequestState> linkedListNode = m_outstandingRequests.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
				{
					if (linkedListNode.Value.RequestTypeId == typeId && linkedListNode.Value.Timestamp < dateTime)
					{
						linkedListNode.Value.Defunct = true;
					}
				}
			}
			if (asyncRequestState == null)
			{
				asyncRequestState = new AsyncRequestState();
				asyncRequestState.Defunct = true;
				asyncRequestState.RequestId = requestId;
				asyncRequestState.RequestTypeId = typeId;
				asyncRequestState.Result = result;
				asyncRequestState.Timestamp = DateTime.UtcNow;
				m_outstandingRequests.AddLast(asyncRequestState);
			}
		}
	}

	private void OnKeepAlive(object state)
	{
		ReadValueIdCollection readValueIdCollection = (ReadValueIdCollection)state;
		try
		{
			if (base.Connected && m_keepAliveTimer != null && (!KeepAliveStopped || OnKeepAliveError(ServiceResult.Create(2150694912u, "Server not responding to keep alive requests."))))
			{
				RequestHeader requestHeader = new RequestHeader();
				requestHeader.RequestHandle = Utils.IncrementIdentifier(ref m_keepAliveCounter);
				requestHeader.TimeoutHint = (uint)(KeepAliveInterval * 2);
				requestHeader.ReturnDiagnostics = 0u;
				IAsyncResult result = BeginRead(requestHeader, 0.0, TimestampsToReturn.Neither, readValueIdCollection, OnKeepAliveComplete, readValueIdCollection);
				AsyncRequestStarted(result, requestHeader.RequestHandle, 629u);
			}
		}
		catch (Exception ex)
		{
			Utils.LogError("Could not send keep alive request: {0} {1}", ex.GetType().FullName, ex.Message);
		}
	}

	private void OnKeepAliveComplete(IAsyncResult result)
	{
		ReadValueIdCollection request = (ReadValueIdCollection)result.AsyncState;
		AsyncRequestCompleted(result, 0u, 629u);
		try
		{
			DataValueCollection results = new DataValueCollection();
			DiagnosticInfoCollection diagnosticInfos = new DiagnosticInfoCollection();
			ResponseHeader responseHeader = EndRead(result, out results, out diagnosticInfos);
			ClientBase.ValidateResponse(results, request);
			ClientBase.ValidateDiagnosticInfos(diagnosticInfos, request);
			ServiceResult status = ClientBase.ValidateDataValue(results[0], typeof(int), 0, diagnosticInfos, responseHeader);
			if (ServiceResult.IsBad(status))
			{
				throw new ServiceResultException(status);
			}
			OnKeepAlive((ServerState)(int)results[0].Value, responseHeader.Timestamp);
		}
		catch (Exception ex)
		{
			Utils.LogError("Unexpected keep alive error occurred: {0}", ex.Message);
		}
	}

	protected virtual void OnKeepAlive(ServerState currentState, DateTime currentTime)
	{
		if (KeepAliveStopped)
		{
			if (m_reconnecting)
			{
				return;
			}
			int num = 0;
			lock (m_outstandingRequests)
			{
				for (LinkedListNode<AsyncRequestState> linkedListNode = m_outstandingRequests.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
				{
					if (linkedListNode.Value.RequestTypeId == 824)
					{
						linkedListNode.Value.Defunct = true;
					}
				}
			}
			num = GetMinPublishRequestCount(createdOnly: false);
			while (num-- > 0)
			{
				BeginPublish(base.OperationTimeout);
			}
		}
		KeepAliveEventHandler keepAliveEventHandler = null;
		lock (m_eventLock)
		{
			keepAliveEventHandler = this.m_KeepAlive;
			m_serverState = currentState;
			m_lastKeepAliveTime = DateTime.UtcNow;
		}
		if (keepAliveEventHandler != null)
		{
			try
			{
				keepAliveEventHandler(this, new KeepAliveEventArgs(null, currentState, currentTime));
			}
			catch (Exception exception)
			{
				Utils.LogError(exception, "Session: Unexpected error invoking KeepAliveCallback.");
			}
		}
	}

	protected virtual bool OnKeepAliveError(ServiceResult result)
	{
		long num = 0L;
		lock (m_eventLock)
		{
			num = DateTime.UtcNow.Ticks - m_lastKeepAliveTime.Ticks;
		}
		Utils.LogInfo("KEEP ALIVE LATE: {0}s, EndpointUrl={1}, RequestCount={2}/{3}", (double)num / 10000000.0, base.Endpoint.EndpointUrl, GoodPublishRequestCount, OutstandingRequestCount);
		KeepAliveEventHandler keepAliveEventHandler = null;
		lock (m_eventLock)
		{
			keepAliveEventHandler = this.m_KeepAlive;
		}
		if (keepAliveEventHandler != null)
		{
			try
			{
				KeepAliveEventArgs e = new KeepAliveEventArgs(result, ServerState.Unknown, DateTime.UtcNow);
				keepAliveEventHandler(this, e);
				return !e.CancelKeepAlive;
			}
			catch (Exception exception)
			{
				Utils.LogError(exception, "Session: Unexpected error invoking KeepAliveCallback.");
			}
		}
		return true;
	}

	private bool PrepareSubscriptionsToDelete(IEnumerable<Subscription> subscriptions, IList<Subscription> subscriptionsToDelete)
	{
		bool result = false;
		lock (base.SyncRoot)
		{
			foreach (Subscription subscription in subscriptions)
			{
				if (m_subscriptions.Remove(subscription))
				{
					if (subscription.Created)
					{
						subscriptionsToDelete.Add(subscription);
					}
					result = true;
				}
			}
			return result;
		}
	}

	private void CreateNodeClassAttributesReadNodesRequest(IList<NodeId> nodeIdCollection, NodeClass nodeClass, ReadValueIdCollection attributesToRead, IList<IDictionary<uint, DataValue>> attributesPerNodeId, IList<Node> nodeCollection, bool optionalAttributes)
	{
		for (int i = 0; i < nodeIdCollection.Count; i++)
		{
			Node node = new Node();
			node.NodeId = nodeIdCollection[i];
			node.NodeClass = nodeClass;
			IDictionary<uint, DataValue> dictionary = CreateAttributes(node.NodeClass, optionalAttributes);
			foreach (uint key in dictionary.Keys)
			{
				ReadValueId item = new ReadValueId
				{
					NodeId = node.NodeId,
					AttributeId = key
				};
				attributesToRead.Add(item);
			}
			nodeCollection.Add(node);
			attributesPerNodeId.Add(dictionary);
		}
	}

	private ReadValueIdCollection PrepareNamespaceTableNodesToRead()
	{
		ReadValueIdCollection readValueIdCollection = new ReadValueIdCollection();
		ReadValueId item = new ReadValueId
		{
			NodeId = 2255u,
			AttributeId = 13u
		};
		readValueIdCollection.Add(item);
		item = new ReadValueId
		{
			NodeId = 2254u,
			AttributeId = 13u
		};
		readValueIdCollection.Add(item);
		return readValueIdCollection;
	}

	private void UpdateNamespaceTable(DataValueCollection values, DiagnosticInfoCollection diagnosticInfos, ResponseHeader responseHeader)
	{
		ServiceResult serviceResult = ClientBase.ValidateDataValue(values[0], typeof(string[]), 0, diagnosticInfos, responseHeader);
		if (ServiceResult.IsBad(serviceResult))
		{
			Utils.LogError("FetchNamespaceTables: Cannot read NamespaceArray node: {0}", serviceResult.StatusCode);
		}
		else
		{
			m_namespaceUris.Update((string[])values[0].Value);
		}
		serviceResult = ClientBase.ValidateDataValue(values[1], typeof(string[]), 1, diagnosticInfos, responseHeader);
		if (ServiceResult.IsBad(serviceResult))
		{
			Utils.LogError("FetchNamespaceTables: Cannot read ServerArray node: {0} ", serviceResult.StatusCode);
		}
		else
		{
			m_serverUris.Update((string[])values[1].Value);
		}
	}

	private void CreateAttributesReadNodesRequest(ResponseHeader responseHeader, ReadValueIdCollection itemsToRead, DataValueCollection nodeClassValues, DiagnosticInfoCollection diagnosticInfos, ReadValueIdCollection attributesToRead, IList<IDictionary<uint, DataValue>> attributesPerNodeId, IList<Node> nodeCollection, IList<ServiceResult> errors, bool optionalAttributes)
	{
		for (int i = 0; i < itemsToRead.Count; i++)
		{
			Node node = new Node();
			node.NodeId = itemsToRead[i].NodeId;
			if (!DataValue.IsGood(nodeClassValues[i]))
			{
				nodeCollection.Add(node);
				errors.Add(new ServiceResult(nodeClassValues[i].StatusCode, i, diagnosticInfos, responseHeader.StringTable));
				attributesPerNodeId.Add(null);
				continue;
			}
			int? num = nodeClassValues[i].Value as int?;
			if (!num.HasValue)
			{
				nodeCollection.Add(node);
				errors.Add(ServiceResult.Create(2147549184u, "Node does not have a valid value for NodeClass: {0}.", nodeClassValues[i].Value));
				attributesPerNodeId.Add(null);
				continue;
			}
			node.NodeClass = (NodeClass)num.Value;
			IDictionary<uint, DataValue> dictionary = CreateAttributes(node.NodeClass, optionalAttributes);
			foreach (uint key in dictionary.Keys)
			{
				ReadValueId item = new ReadValueId
				{
					NodeId = node.NodeId,
					AttributeId = key
				};
				attributesToRead.Add(item);
			}
			nodeCollection.Add(node);
			errors.Add(ServiceResult.Good);
			attributesPerNodeId.Add(dictionary);
		}
	}

	private void ProcessAttributesReadNodesResponse(ResponseHeader responseHeader, ReadValueIdCollection attributesToRead, IList<IDictionary<uint, DataValue>> attributesPerNodeId, DataValueCollection values, DiagnosticInfoCollection diagnosticInfos, IList<Node> nodeCollection, IList<ServiceResult> errors)
	{
		int num = 0;
		for (int i = 0; i < nodeCollection.Count; i++)
		{
			IDictionary<uint, DataValue> dictionary = attributesPerNodeId[i];
			if (dictionary != null)
			{
				int count = dictionary.Count;
				ReadValueIdCollection itemsToRead = new ReadValueIdCollection(attributesToRead.GetRange(num, count));
				DataValueCollection values2 = new DataValueCollection(values.GetRange(num, count));
				DiagnosticInfoCollection diagnosticInfos2 = ((diagnosticInfos.Count > 0) ? new DiagnosticInfoCollection(diagnosticInfos.GetRange(num, count)) : diagnosticInfos);
				try
				{
					nodeCollection[i] = ProcessReadResponse(responseHeader, dictionary, itemsToRead, values2, diagnosticInfos2);
					errors[i] = ServiceResult.Good;
				}
				catch (ServiceResultException ex)
				{
					errors[i] = ex.Result;
				}
				num += count;
			}
		}
	}

	private Node ProcessReadResponse(ResponseHeader responseHeader, IDictionary<uint, DataValue> attributes, ReadValueIdCollection itemsToRead, DataValueCollection values, DiagnosticInfoCollection diagnosticInfos)
	{
		int? num = null;
		for (int i = 0; i < itemsToRead.Count; i++)
		{
			uint attributeId = itemsToRead[i].AttributeId;
			if (attributeId == 2)
			{
				if (!DataValue.IsGood(values[i]))
				{
					throw ServiceResultException.Create(values[i].StatusCode, i, diagnosticInfos, responseHeader.StringTable);
				}
				num = values[i].Value as int?;
				if (!num.HasValue)
				{
					throw ServiceResultException.Create(2147549184u, "Node does not have a valid value for NodeClass: {0}.", values[i].Value);
				}
			}
			else if (!DataValue.IsGood(values[i]))
			{
				if (values[i].StatusCode == 2150957056u || (StatusCode.IsBad(values[i].StatusCode) && (attributeId == 26 || attributeId == 5 || attributeId == 24 || attributeId == 25 || attributeId == 7 || attributeId == 6)))
				{
					continue;
				}
				if (attributeId != 13)
				{
					throw ServiceResultException.Create(values[i].StatusCode, i, diagnosticInfos, responseHeader.StringTable);
				}
			}
			attributes[attributeId] = values[i];
		}
		Node node;
		DataValue dataValue;
		switch ((NodeClass)num.Value)
		{
		default:
			throw ServiceResultException.Create(2147549184u, "Node does not have a valid value for NodeClass: {0}.", num.Value);
		case NodeClass.Object:
		{
			ObjectNode objectNode = new ObjectNode();
			dataValue = attributes[12u];
			if (dataValue == null)
			{
				throw ServiceResultException.Create(2147549184u, "Object does not support the EventNotifier attribute.");
			}
			objectNode.EventNotifier = (byte)dataValue.GetValue(typeof(byte));
			node = objectNode;
			break;
		}
		case NodeClass.ObjectType:
		{
			ObjectTypeNode objectTypeNode = new ObjectTypeNode();
			dataValue = attributes[8u];
			if (dataValue == null)
			{
				throw ServiceResultException.Create(2147549184u, "ObjectType does not support the IsAbstract attribute.");
			}
			objectTypeNode.IsAbstract = (bool)dataValue.GetValue(typeof(bool));
			node = objectTypeNode;
			break;
		}
		case NodeClass.Variable:
		{
			VariableNode variableNode = new VariableNode();
			dataValue = attributes[14u];
			if (dataValue == null)
			{
				throw ServiceResultException.Create(2147549184u, "Variable does not support the DataType attribute.");
			}
			variableNode.DataType = (NodeId)dataValue.GetValue(typeof(NodeId));
			dataValue = attributes[15u];
			if (dataValue == null)
			{
				throw ServiceResultException.Create(2147549184u, "Variable does not support the ValueRank attribute.");
			}
			variableNode.ValueRank = (int)dataValue.GetValue(typeof(int));
			dataValue = attributes[16u];
			if (dataValue != null)
			{
				if (dataValue.Value == null)
				{
					variableNode.ArrayDimensions = Array.Empty<uint>();
				}
				else
				{
					variableNode.ArrayDimensions = (uint[])dataValue.GetValue(typeof(uint[]));
				}
			}
			dataValue = attributes[17u];
			if (dataValue == null)
			{
				throw ServiceResultException.Create(2147549184u, "Variable does not support the AccessLevel attribute.");
			}
			variableNode.AccessLevel = (byte)dataValue.GetValue(typeof(byte));
			dataValue = attributes[18u];
			if (dataValue == null)
			{
				throw ServiceResultException.Create(2147549184u, "Variable does not support the UserAccessLevel attribute.");
			}
			variableNode.UserAccessLevel = (byte)dataValue.GetValue(typeof(byte));
			dataValue = attributes[20u];
			if (dataValue == null)
			{
				throw ServiceResultException.Create(2147549184u, "Variable does not support the Historizing attribute.");
			}
			variableNode.Historizing = (bool)dataValue.GetValue(typeof(bool));
			dataValue = attributes[19u];
			if (dataValue != null)
			{
				variableNode.MinimumSamplingInterval = Convert.ToDouble(attributes[19u].Value);
			}
			dataValue = attributes[27u];
			if (dataValue != null)
			{
				variableNode.AccessLevelEx = (uint)dataValue.GetValue(typeof(uint));
			}
			node = variableNode;
			break;
		}
		case NodeClass.VariableType:
		{
			VariableTypeNode variableTypeNode = new VariableTypeNode();
			dataValue = attributes[8u];
			if (dataValue == null)
			{
				throw ServiceResultException.Create(2147549184u, "VariableType does not support the IsAbstract attribute.");
			}
			variableTypeNode.IsAbstract = (bool)dataValue.GetValue(typeof(bool));
			dataValue = attributes[14u];
			if (dataValue == null)
			{
				throw ServiceResultException.Create(2147549184u, "VariableType does not support the DataType attribute.");
			}
			variableTypeNode.DataType = (NodeId)dataValue.GetValue(typeof(NodeId));
			dataValue = attributes[15u];
			if (dataValue == null)
			{
				throw ServiceResultException.Create(2147549184u, "VariableType does not support the ValueRank attribute.");
			}
			variableTypeNode.ValueRank = (int)dataValue.GetValue(typeof(int));
			dataValue = attributes[16u];
			if (dataValue != null && dataValue.Value != null)
			{
				variableTypeNode.ArrayDimensions = (uint[])dataValue.GetValue(typeof(uint[]));
			}
			node = variableTypeNode;
			break;
		}
		case NodeClass.Method:
		{
			MethodNode methodNode = new MethodNode();
			dataValue = attributes[21u];
			if (dataValue == null)
			{
				throw ServiceResultException.Create(2147549184u, "Method does not support the Executable attribute.");
			}
			methodNode.Executable = (bool)dataValue.GetValue(typeof(bool));
			dataValue = attributes[22u];
			if (dataValue == null)
			{
				throw ServiceResultException.Create(2147549184u, "Method does not support the UserExecutable attribute.");
			}
			methodNode.UserExecutable = (bool)dataValue.GetValue(typeof(bool));
			node = methodNode;
			break;
		}
		case NodeClass.DataType:
		{
			DataTypeNode dataTypeNode = new DataTypeNode();
			dataValue = attributes[8u];
			if (dataValue == null)
			{
				throw ServiceResultException.Create(2147549184u, "DataType does not support the IsAbstract attribute.");
			}
			dataTypeNode.IsAbstract = (bool)dataValue.GetValue(typeof(bool));
			dataValue = attributes[23u];
			if (dataValue != null)
			{
				dataTypeNode.DataTypeDefinition = dataValue.Value as ExtensionObject;
			}
			node = dataTypeNode;
			break;
		}
		case NodeClass.ReferenceType:
		{
			ReferenceTypeNode referenceTypeNode = new ReferenceTypeNode();
			dataValue = attributes[8u];
			if (dataValue == null)
			{
				throw ServiceResultException.Create(2147549184u, "ReferenceType does not support the IsAbstract attribute.");
			}
			referenceTypeNode.IsAbstract = (bool)dataValue.GetValue(typeof(bool));
			dataValue = attributes[9u];
			if (dataValue == null)
			{
				throw ServiceResultException.Create(2147549184u, "ReferenceType does not support the Symmetric attribute.");
			}
			referenceTypeNode.Symmetric = (bool)dataValue.GetValue(typeof(bool));
			dataValue = attributes[10u];
			if (dataValue != null && dataValue.Value != null)
			{
				referenceTypeNode.InverseName = (LocalizedText)dataValue.GetValue(typeof(LocalizedText));
			}
			node = referenceTypeNode;
			break;
		}
		case NodeClass.View:
		{
			ViewNode viewNode = new ViewNode();
			dataValue = attributes[12u];
			if (dataValue == null)
			{
				throw ServiceResultException.Create(2147549184u, "View does not support the EventNotifier attribute.");
			}
			viewNode.EventNotifier = (byte)dataValue.GetValue(typeof(byte));
			dataValue = attributes[11u];
			if (dataValue == null)
			{
				throw ServiceResultException.Create(2147549184u, "View does not support the ContainsNoLoops attribute.");
			}
			viewNode.ContainsNoLoops = (bool)dataValue.GetValue(typeof(bool));
			node = viewNode;
			break;
		}
		}
		dataValue = attributes[1u];
		if (dataValue == null)
		{
			throw ServiceResultException.Create(2147549184u, "Node does not support the NodeId attribute.");
		}
		node.NodeId = (NodeId)dataValue.GetValue(typeof(NodeId));
		node.NodeClass = (NodeClass)num.Value;
		dataValue = attributes[3u];
		if (dataValue == null)
		{
			throw ServiceResultException.Create(2147549184u, "Node does not support the BrowseName attribute.");
		}
		node.BrowseName = (QualifiedName)dataValue.GetValue(typeof(QualifiedName));
		dataValue = attributes[4u];
		if (dataValue == null)
		{
			throw ServiceResultException.Create(2147549184u, "Node does not support the DisplayName attribute.");
		}
		node.DisplayName = (LocalizedText)dataValue.GetValue(typeof(LocalizedText));
		if (attributes.TryGetValue(5u, out dataValue) && dataValue != null && dataValue.Value != null)
		{
			node.Description = (LocalizedText)dataValue.GetValue(typeof(LocalizedText));
		}
		if (attributes.TryGetValue(6u, out dataValue) && dataValue != null)
		{
			node.WriteMask = (uint)dataValue.GetValue(typeof(uint));
		}
		if (attributes.TryGetValue(7u, out dataValue) && dataValue != null)
		{
			node.UserWriteMask = (uint)dataValue.GetValue(typeof(uint));
		}
		if (attributes.TryGetValue(24u, out dataValue) && dataValue != null && dataValue.Value is ExtensionObject[] array)
		{
			node.RolePermissions = new RolePermissionTypeCollection();
			ExtensionObject[] array2 = array;
			foreach (ExtensionObject extensionObject in array2)
			{
				node.RolePermissions.Add(extensionObject.Body as RolePermissionType);
			}
		}
		if (attributes.TryGetValue(25u, out dataValue) && dataValue != null && dataValue.Value is ExtensionObject[] array3)
		{
			node.UserRolePermissions = new RolePermissionTypeCollection();
			ExtensionObject[] array2 = array3;
			foreach (ExtensionObject extensionObject2 in array2)
			{
				node.UserRolePermissions.Add(extensionObject2.Body as RolePermissionType);
			}
		}
		if (attributes.TryGetValue(26u, out dataValue) && dataValue != null)
		{
			node.AccessRestrictions = (ushort)dataValue.GetValue(typeof(ushort));
		}
		return node;
	}

	private IDictionary<uint, DataValue> CreateAttributes(NodeClass nodeclass = NodeClass.Unspecified, bool optionalAttributes = true)
	{
		SortedDictionary<uint, DataValue> sortedDictionary = new SortedDictionary<uint, DataValue>
		{
			{ 1u, null },
			{ 2u, null },
			{ 3u, null },
			{ 4u, null }
		};
		switch (nodeclass)
		{
		case NodeClass.Object:
			sortedDictionary.Add(12u, null);
			break;
		case NodeClass.Variable:
			sortedDictionary.Add(14u, null);
			sortedDictionary.Add(15u, null);
			sortedDictionary.Add(16u, null);
			sortedDictionary.Add(17u, null);
			sortedDictionary.Add(18u, null);
			sortedDictionary.Add(20u, null);
			sortedDictionary.Add(19u, null);
			sortedDictionary.Add(27u, null);
			break;
		case NodeClass.Method:
			sortedDictionary.Add(21u, null);
			sortedDictionary.Add(22u, null);
			break;
		case NodeClass.ObjectType:
			sortedDictionary.Add(8u, null);
			break;
		case NodeClass.VariableType:
			sortedDictionary.Add(8u, null);
			sortedDictionary.Add(14u, null);
			sortedDictionary.Add(15u, null);
			sortedDictionary.Add(16u, null);
			break;
		case NodeClass.ReferenceType:
			sortedDictionary.Add(8u, null);
			sortedDictionary.Add(9u, null);
			sortedDictionary.Add(10u, null);
			break;
		case NodeClass.DataType:
			sortedDictionary.Add(8u, null);
			sortedDictionary.Add(23u, null);
			break;
		case NodeClass.View:
			sortedDictionary.Add(12u, null);
			sortedDictionary.Add(11u, null);
			break;
		default:
			sortedDictionary = new SortedDictionary<uint, DataValue>
			{
				{ 1u, null },
				{ 2u, null },
				{ 3u, null },
				{ 4u, null },
				{ 14u, null },
				{ 15u, null },
				{ 16u, null },
				{ 17u, null },
				{ 18u, null },
				{ 19u, null },
				{ 20u, null },
				{ 12u, null },
				{ 21u, null },
				{ 22u, null },
				{ 8u, null },
				{ 10u, null },
				{ 9u, null },
				{ 11u, null },
				{ 23u, null },
				{ 27u, null }
			};
			break;
		}
		if (optionalAttributes)
		{
			sortedDictionary.Add(5u, null);
			sortedDictionary.Add(6u, null);
			sortedDictionary.Add(7u, null);
			sortedDictionary.Add(24u, null);
			sortedDictionary.Add(25u, null);
			sortedDictionary.Add(26u, null);
		}
		return sortedDictionary;
	}

	public IAsyncResult BeginPublish(int timeout)
	{
		if (m_reconnecting)
		{
			Utils.LogWarning("Publish skipped due to reconnect");
			return null;
		}
		PublishSequenceNumbersToAcknowledgeEventHandler publishSequenceNumbersToAcknowledgeEventHandler = null;
		lock (m_eventLock)
		{
			publishSequenceNumbersToAcknowledgeEventHandler = this.m_PublishSequenceNumbersToAcknowledge;
		}
		SubscriptionAcknowledgementCollection subscriptionAcknowledgementCollection = null;
		lock (base.SyncRoot)
		{
			if (publishSequenceNumbersToAcknowledgeEventHandler != null)
			{
				try
				{
					SubscriptionAcknowledgementCollection subscriptionAcknowledgementCollection2 = new SubscriptionAcknowledgementCollection();
					publishSequenceNumbersToAcknowledgeEventHandler(this, new PublishSequenceNumbersToAcknowledgeEventArgs(m_acknowledgementsToSend, subscriptionAcknowledgementCollection2));
					subscriptionAcknowledgementCollection = m_acknowledgementsToSend;
					m_acknowledgementsToSend = subscriptionAcknowledgementCollection2;
				}
				catch (Exception exception)
				{
					Utils.LogError(exception, "Session: Unexpected error invoking PublishSequenceNumbersToAcknowledgeEventArgs.");
				}
			}
			if (subscriptionAcknowledgementCollection == null)
			{
				subscriptionAcknowledgementCollection = m_acknowledgementsToSend;
				m_acknowledgementsToSend = new SubscriptionAcknowledgementCollection();
			}
			foreach (SubscriptionAcknowledgement item in subscriptionAcknowledgementCollection)
			{
				m_latestAcknowledgementsSent[item.SubscriptionId] = item.SequenceNumber;
			}
		}
		RequestHeader requestHeader = new RequestHeader();
		requestHeader.TimeoutHint = (uint)base.OperationTimeout / 2u;
		requestHeader.ReturnDiagnostics = (uint)base.ReturnDiagnostics;
		requestHeader.RequestHandle = Utils.IncrementIdentifier(ref m_publishCounter);
		new AsyncRequestState
		{
			RequestTypeId = 824u,
			RequestId = requestHeader.RequestHandle,
			Timestamp = DateTime.UtcNow
		};
		CoreClientUtils.EventLog.PublishStart((int)requestHeader.RequestHandle);
		try
		{
			IAsyncResult result = BeginPublish(requestHeader, subscriptionAcknowledgementCollection, OnPublishComplete, new object[3] { base.SessionId, subscriptionAcknowledgementCollection, requestHeader });
			AsyncRequestStarted(result, requestHeader.RequestHandle, 824u);
			return result;
		}
		catch (Exception exception2)
		{
			Utils.LogError(exception2, "Unexpected error sending publish request.");
			return null;
		}
	}

	private void OnPublishComplete(IAsyncResult result)
	{
		object[] obj = (object[])result.AsyncState;
		NodeId nodeId = (NodeId)obj[0];
		SubscriptionAcknowledgementCollection subscriptionAcknowledgementCollection = (SubscriptionAcknowledgementCollection)obj[1];
		RequestHeader requestHeader = (RequestHeader)obj[2];
		AsyncRequestCompleted(result, requestHeader.RequestHandle, 824u);
		CoreClientUtils.EventLog.PublishStop((int)requestHeader.RequestHandle);
		try
		{
			m_reconnectLock.Wait();
			bool reconnecting = m_reconnecting;
			m_reconnectLock.Release();
			uint subscriptionId;
			UInt32Collection availableSequenceNumbers;
			bool moreNotifications;
			NotificationMessage notificationMessage;
			StatusCodeCollection results;
			DiagnosticInfoCollection diagnosticInfos;
			ResponseHeader responseHeader = EndPublish(result, out subscriptionId, out availableSequenceNumbers, out moreNotifications, out notificationMessage, out results, out diagnosticInfos);
			foreach (StatusCode item in results)
			{
				if (StatusCode.IsBad(item))
				{
					Utils.LogError("Error - Publish call finished. ResultCode={0}; SubscriptionId={1};", item.ToString(), subscriptionId);
				}
			}
			if (nodeId != base.SessionId)
			{
				Utils.LogWarning("Publish response discarded because session id changed: Old {0} != New {1}", nodeId, base.SessionId);
				return;
			}
			CoreClientUtils.EventLog.NotificationReceived((int)subscriptionId, (int)notificationMessage.SequenceNumber);
			ProcessPublishResponse(responseHeader, subscriptionId, availableSequenceNumbers, moreNotifications, notificationMessage);
			if (reconnecting)
			{
				Utils.LogWarning("No new publish sent because of reconnect in progress.");
				return;
			}
		}
		catch (Exception ex)
		{
			if (m_subscriptions.Count == 0)
			{
				Utils.LogError("Publish #{0}, Subscription count = 0, Error: {1}", requestHeader.RequestHandle, ex.Message);
			}
			else
			{
				Utils.LogError("Publish #{0}, Reconnecting={1}, Error: {2}", requestHeader.RequestHandle, m_reconnecting, ex.Message);
			}
			bool moreNotifications = false;
			if (m_reconnecting)
			{
				Utils.LogWarning("Publish abandoned after error due to reconnect: {0}", ex.Message);
				return;
			}
			if (nodeId != base.SessionId)
			{
				Utils.LogError("Publish abandoned after error because session id changed: Old {0} != New {1}", nodeId, base.SessionId);
				return;
			}
			if (subscriptionAcknowledgementCollection != null)
			{
				lock (base.SyncRoot)
				{
					m_acknowledgementsToSend.AddRange(subscriptionAcknowledgementCollection);
				}
			}
			ServiceResult serviceResult = new ServiceResult(ex);
			if (serviceResult.Code != 2155413504u)
			{
				PublishErrorEventHandler publishErrorEventHandler = null;
				lock (m_eventLock)
				{
					publishErrorEventHandler = this.m_PublishError;
				}
				if (publishErrorEventHandler != null)
				{
					try
					{
						publishErrorEventHandler(this, new PublishErrorEventArgs(serviceResult));
					}
					catch (Exception exception)
					{
						Utils.LogError(exception, "Session: Unexpected error invoking PublishErrorCallback.");
					}
				}
			}
			switch (serviceResult.Code)
			{
			case 2155347968u:
			{
				int goodPublishRequestCount = GoodPublishRequestCount;
				if (BelowPublishRequestLimit(goodPublishRequestCount))
				{
					m_tooManyPublishRequests = goodPublishRequestCount;
					Utils.LogInfo("PUBLISH - Too many requests, set limit to GoodPublishRequestCount={0}.", m_tooManyPublishRequests);
				}
				return;
			}
			case 2148401152u:
			case 2148663296u:
			case 2148728832u:
			case 2149711872u:
			case 2149908480u:
			case 2149974016u:
			case 2155413504u:
			case 2156265472u:
				return;
			default:
				Thread.Sleep(100);
				Utils.LogError(ex, "PUBLISH #{0} - Unhandled error {1} during Publish.", requestHeader.RequestHandle, serviceResult.StatusCode);
				break;
			}
		}
		int goodPublishRequestCount2 = GoodPublishRequestCount;
		int minPublishRequestCount = GetMinPublishRequestCount(createdOnly: false);
		if (goodPublishRequestCount2 < minPublishRequestCount)
		{
			BeginPublish(base.OperationTimeout);
			return;
		}
		Utils.LogInfo("PUBLISH - Did not send another publish request. GoodPublishRequestCount={0}, MinPublishRequestCount={1}", goodPublishRequestCount2, minPublishRequestCount);
	}

	public bool Republish(uint subscriptionId, uint sequenceNumber)
	{
		RequestHeader requestHeader = new RequestHeader
		{
			TimeoutHint = (uint)base.OperationTimeout,
			ReturnDiagnostics = (uint)base.ReturnDiagnostics,
			RequestHandle = Utils.IncrementIdentifier(ref m_publishCounter)
		};
		try
		{
			Utils.LogInfo("Requesting Republish for {0}-{1}", subscriptionId, sequenceNumber);
			NotificationMessage notificationMessage = null;
			ResponseHeader responseHeader = Republish(requestHeader, subscriptionId, sequenceNumber, out notificationMessage);
			Utils.LogInfo("Received Republish for {0}-{1}-{2}", subscriptionId, sequenceNumber, responseHeader.ServiceResult);
			ProcessPublishResponse(responseHeader, subscriptionId, null, moreNotifications: false, notificationMessage);
			return true;
		}
		catch (Exception e)
		{
			return ProcessRepublishResponseError(e, subscriptionId, sequenceNumber);
		}
	}

	public bool ResendData(IEnumerable<Subscription> subscriptions, out IList<ServiceResult> errors)
	{
		CallMethodRequestCollection callMethodRequestCollection = CreateCallRequestsForResendData(subscriptions);
		errors = new List<ServiceResult>(callMethodRequestCollection.Count);
		try
		{
			CallMethodResultCollection results;
			DiagnosticInfoCollection diagnosticInfos;
			ResponseHeader responseHeader = Call(null, callMethodRequestCollection, out results, out diagnosticInfos);
			ClientBase.ValidateResponse(results, callMethodRequestCollection);
			ClientBase.ValidateDiagnosticInfos(diagnosticInfos, callMethodRequestCollection);
			int num = 0;
			foreach (CallMethodResult item2 in results)
			{
				ServiceResult item = ServiceResult.Good;
				if (StatusCode.IsNotGood(item2.StatusCode))
				{
					item = ClientBase.GetResult(item2.StatusCode, num, diagnosticInfos, responseHeader);
				}
				errors.Add(item);
				num++;
			}
			return true;
		}
		catch (ServiceResultException exception)
		{
			Utils.LogError(exception, "Failed to call ResendData on server.");
		}
		return false;
	}

	private void OpenValidateIdentity(ref IUserIdentity identity, out UserIdentityToken identityToken, out UserTokenPolicy identityPolicy, out string securityPolicyUri, out bool requireEncryption)
	{
		lock (base.SyncRoot)
		{
			if (base.Connected)
			{
				throw new ServiceResultException(2158952448u, "Already connected to server.");
			}
		}
		securityPolicyUri = m_endpoint.Description.SecurityPolicyUri;
		if (SecurityPolicies.GetDisplayName(securityPolicyUri) == null)
		{
			throw ServiceResultException.Create(2148728832u, "The chosen security policy is not supported by the client to connect to the server.");
		}
		if (identity == null)
		{
			identity = new UserIdentity();
		}
		identityToken = identity.GetIdentityToken();
		identityPolicy = m_endpoint.Description.FindUserTokenPolicy(identityToken.PolicyId);
		if (identityPolicy == null)
		{
			identityPolicy = m_endpoint.Description.FindUserTokenPolicy(identity.TokenType, identity.IssuedTokenType);
			if (identityPolicy == null)
			{
				throw ServiceResultException.Create(2149515264u, "Endpoint does not support the user identity type provided.");
			}
			identityToken.PolicyId = identityPolicy.PolicyId;
		}
		requireEncryption = securityPolicyUri != "http://opcfoundation.org/UA/SecurityPolicy#None";
		if (!requireEncryption)
		{
			requireEncryption = identityPolicy.SecurityPolicyUri != "http://opcfoundation.org/UA/SecurityPolicy#None" && !string.IsNullOrEmpty(identityPolicy.SecurityPolicyUri);
		}
	}

	private void BuildCertificateData(out byte[] clientCertificateData, out byte[] clientCertificateChainData)
	{
		clientCertificateData = ((m_instanceCertificate != null) ? m_instanceCertificate.RawData : null);
		clientCertificateChainData = null;
		if (m_instanceCertificateChain != null && m_instanceCertificateChain.Count > 0 && m_configuration.SecurityConfiguration.SendCertificateChain)
		{
			List<byte> list = new List<byte>();
			for (int i = 0; i < m_instanceCertificateChain.Count; i++)
			{
				list.AddRange(m_instanceCertificateChain[i].RawData);
			}
			clientCertificateChainData = list.ToArray();
		}
	}

	private void ValidateServerCertificateData(byte[] serverCertificateData)
	{
		if (serverCertificateData == null || m_endpoint.Description.ServerCertificate == null || Utils.IsEqual(serverCertificateData, m_endpoint.Description.ServerCertificate))
		{
			return;
		}
		try
		{
			X509Certificate2Collection x509Certificate2Collection = Utils.ParseCertificateChainBlob(m_endpoint.Description.ServerCertificate);
			if (x509Certificate2Collection.Count > 0 && !Utils.IsEqual(serverCertificateData, x509Certificate2Collection[0].RawData))
			{
				throw ServiceResultException.Create(2148663296u, "Server did not return the certificate used to create the secure channel.");
			}
		}
		catch (Exception)
		{
			throw ServiceResultException.Create(2148663296u, "Server did not return the certificate used to create the secure channel.");
		}
	}

	private void ValidateServerSignature(X509Certificate2 serverCertificate, SignatureData serverSignature, byte[] clientCertificateData, byte[] clientCertificateChainData, byte[] clientNonce)
	{
		if (serverSignature == null || serverSignature.Signature == null)
		{
			Utils.LogInfo("Server signature is null or empty.");
		}
		byte[] dataToVerify = Utils.Append(clientCertificateData, clientNonce);
		if (!SecurityPolicies.Verify(serverCertificate, m_endpoint.Description.SecurityPolicyUri, dataToVerify, serverSignature))
		{
			if (clientCertificateChainData == null)
			{
				throw ServiceResultException.Create(2153250816u, "Server did not provide a correct signature for the nonce data provided by the client.");
			}
			dataToVerify = Utils.Append(clientCertificateChainData, clientNonce);
			if (!SecurityPolicies.Verify(serverCertificate, m_endpoint.Description.SecurityPolicyUri, dataToVerify, serverSignature))
			{
				throw ServiceResultException.Create(2153250816u, "Server did not provide a correct signature for the nonce data provided by the client.");
			}
		}
	}

	private void ValidateServerEndpoints(EndpointDescriptionCollection serverEndpoints)
	{
		if (m_discoveryServerEndpoints != null && m_discoveryServerEndpoints.Count > 0)
		{
			EndpointDescriptionCollection endpointDescriptionCollection = null;
			if (serverEndpoints != null && m_discoveryProfileUris != null && m_discoveryProfileUris.Count > 0)
			{
				endpointDescriptionCollection = new EndpointDescriptionCollection();
				foreach (EndpointDescription serverEndpoint in serverEndpoints)
				{
					if (m_discoveryProfileUris.Contains(serverEndpoint.TransportProfileUri))
					{
						endpointDescriptionCollection.Add(serverEndpoint);
					}
				}
			}
			else
			{
				endpointDescriptionCollection = serverEndpoints;
			}
			if (endpointDescriptionCollection == null || m_discoveryServerEndpoints.Count != endpointDescriptionCollection.Count)
			{
				throw ServiceResultException.Create(2148728832u, "Server did not return a number of ServerEndpoints that matches the one from GetEndpoints.");
			}
			for (int i = 0; i < endpointDescriptionCollection.Count; i++)
			{
				EndpointDescription endpointDescription = endpointDescriptionCollection[i];
				EndpointDescription endpointDescription2 = m_discoveryServerEndpoints[i];
				if (endpointDescription.SecurityMode != endpointDescription2.SecurityMode || endpointDescription.SecurityPolicyUri != endpointDescription2.SecurityPolicyUri || endpointDescription.TransportProfileUri != endpointDescription2.TransportProfileUri || endpointDescription.SecurityLevel != endpointDescription2.SecurityLevel)
				{
					throw ServiceResultException.Create(2148728832u, "The list of ServerEndpoints returned at CreateSession does not match the list from GetEndpoints.");
				}
				if (endpointDescription.UserIdentityTokens.Count != endpointDescription2.UserIdentityTokens.Count)
				{
					throw ServiceResultException.Create(2148728832u, "The list of ServerEndpoints returned at CreateSession does not match the one from GetEndpoints.");
				}
				for (int j = 0; j < endpointDescription.UserIdentityTokens.Count; j++)
				{
					if (!endpointDescription.UserIdentityTokens[j].IsEqual(endpointDescription2.UserIdentityTokens[j]))
					{
						throw ServiceResultException.Create(2148728832u, "The list of ServerEndpoints returned at CreateSession does not match the one from GetEndpoints.");
					}
				}
			}
		}
		bool flag = false;
		Uri uri = Utils.ParseUri(m_endpoint.Description.EndpointUrl);
		if (uri != null)
		{
			for (int k = 0; k < serverEndpoints.Count; k++)
			{
				EndpointDescription endpointDescription3 = serverEndpoints[k];
				Uri uri2 = Utils.ParseUri(endpointDescription3.EndpointUrl);
				if (uri2 != null && uri2.Scheme == uri.Scheme && endpointDescription3.SecurityPolicyUri == m_endpoint.Description.SecurityPolicyUri && endpointDescription3.SecurityMode == m_endpoint.Description.SecurityMode)
				{
					m_endpoint.Description.Server.ApplicationName = endpointDescription3.Server.ApplicationName;
					m_endpoint.Description.Server.ApplicationUri = endpointDescription3.Server.ApplicationUri;
					m_endpoint.Description.Server.ApplicationType = endpointDescription3.Server.ApplicationType;
					m_endpoint.Description.Server.ProductUri = endpointDescription3.Server.ProductUri;
					m_endpoint.Description.TransportProfileUri = endpointDescription3.TransportProfileUri;
					m_endpoint.Description.UserIdentityTokens = endpointDescription3.UserIdentityTokens;
					flag = true;
					break;
				}
			}
		}
		if (!flag)
		{
			throw ServiceResultException.Create(2148728832u, "Server did not return an EndpointDescription that matched the one used to create the secure channel.");
		}
	}

	private IAsyncResult PrepareReconnectBeginActivate(ITransportWaitingConnection connection, ITransportChannel transportChannel)
	{
		Utils.LogInfo("Session RECONNECT {0} starting.", base.SessionId);
		lock (base.SyncRoot)
		{
			StopKeepAliveTimer();
		}
		byte[] dataToSign = Utils.Append((m_serverCertificate != null) ? m_serverCertificate.RawData : null, m_serverNonce);
		EndpointDescription description = m_endpoint.Description;
		SignatureData clientSignature = SecurityPolicies.Sign(m_instanceCertificate, description.SecurityPolicyUri, dataToSign);
		UserTokenPolicy userTokenPolicy = description.FindUserTokenPolicy(m_identity.TokenType, m_identity.IssuedTokenType);
		if (userTokenPolicy == null)
		{
			Utils.LogError("Reconnect: Endpoint does not support the user identity type provided.");
			throw ServiceResultException.Create(2149515264u, "Endpoint does not support the user identity type provided.");
		}
		string securityPolicyUri = userTokenPolicy.SecurityPolicyUri;
		if (string.IsNullOrEmpty(securityPolicyUri))
		{
			securityPolicyUri = description.SecurityPolicyUri;
		}
		if (this.m_RenewUserIdentity != null)
		{
			m_identity = this.m_RenewUserIdentity(this, m_identity);
		}
		ValidateServerNonce(m_identity, m_serverNonce, securityPolicyUri, m_previousServerNonce, m_endpoint.Description.SecurityMode);
		UserIdentityToken identityToken = m_identity.GetIdentityToken();
		identityToken.PolicyId = userTokenPolicy.PolicyId;
		SignatureData userTokenSignature = identityToken.Sign(dataToSign, securityPolicyUri);
		identityToken.Encrypt(m_serverCertificate, m_serverNonce, securityPolicyUri);
		GetSoftwareCertificates();
		Utils.LogInfo("Session REPLACING channel for {0}.", base.SessionId);
		if (connection != null)
		{
			if ((base.TransportChannel.SupportedFeatures & TransportChannelFeatures.Reconnect) != TransportChannelFeatures.None)
			{
				base.TransportChannel.Reconnect(connection);
			}
			else
			{
				ITransportChannel transportChannel2 = SessionChannel.Create(m_configuration, connection, m_endpoint.Description, m_endpoint.Configuration, m_instanceCertificate, m_configuration.SecurityConfiguration.SendCertificateChain ? m_instanceCertificateChain : null, base.MessageContext);
				base.TransportChannel = transportChannel2;
			}
		}
		else if (transportChannel != null)
		{
			base.TransportChannel = transportChannel;
		}
		else if (base.TransportChannel != null && (base.TransportChannel.SupportedFeatures & TransportChannelFeatures.Reconnect) != TransportChannelFeatures.None)
		{
			base.TransportChannel.Reconnect();
		}
		else
		{
			ITransportChannel transportChannel3 = SessionChannel.Create(m_configuration, m_endpoint.Description, m_endpoint.Configuration, m_instanceCertificate, m_configuration.SecurityConfiguration.SendCertificateChain ? m_instanceCertificateChain : null, base.MessageContext);
			base.TransportChannel = transportChannel3;
		}
		Utils.LogInfo("Session RE-ACTIVATING {0}.", base.SessionId);
		RequestHeader requestHeader = new RequestHeader
		{
			TimeoutHint = 15000u
		};
		return BeginActivateSession(requestHeader, clientSignature, null, m_preferredLocales, new ExtensionObject(identityToken), userTokenSignature, null, null);
	}

	private bool ProcessRepublishResponseError(Exception e, uint subscriptionId, uint sequenceNumber)
	{
		ServiceResult serviceResult = new ServiceResult(e);
		bool result = true;
		switch (serviceResult.StatusCode.Code)
		{
		case 2155544576u:
			Utils.LogWarning("Message {0}-{1} no longer available.", subscriptionId, sequenceNumber);
			break;
		case 2148007936u:
		{
			Utils.LogError(e, "Message {0}-{1} exceeded size limits, ignored.", subscriptionId, sequenceNumber);
			SubscriptionAcknowledgement item = new SubscriptionAcknowledgement
			{
				SubscriptionId = subscriptionId,
				SequenceNumber = sequenceNumber
			};
			lock (base.SyncRoot)
			{
				m_acknowledgementsToSend.Add(item);
			}
			break;
		}
		default:
			result = false;
			Utils.LogError(e, "Unexpected error sending republish request.");
			break;
		}
		PublishErrorEventHandler publishErrorEventHandler = null;
		lock (m_eventLock)
		{
			publishErrorEventHandler = this.m_PublishError;
		}
		if (publishErrorEventHandler != null)
		{
			try
			{
				PublishErrorEventArgs e2 = new PublishErrorEventArgs(serviceResult, subscriptionId, sequenceNumber);
				publishErrorEventHandler(this, e2);
			}
			catch (Exception exception)
			{
				Utils.LogError(exception, "Session: Unexpected error invoking PublishErrorCallback.");
			}
		}
		return result;
	}

	private void HandleSignedSoftwareCertificates(SignedSoftwareCertificateCollection serverSoftwareCertificates)
	{
		CertificateValidator certificateValidator = m_configuration.CertificateValidator;
		List<SoftwareCertificate> list = new List<SoftwareCertificate>();
		foreach (SignedSoftwareCertificate serverSoftwareCertificate in serverSoftwareCertificates)
		{
			SoftwareCertificate softwareCertificate = null;
			ServiceResult serviceResult = SoftwareCertificate.Validate(certificateValidator, serverSoftwareCertificate.CertificateData, out softwareCertificate);
			if (ServiceResult.IsBad(serviceResult))
			{
				OnSoftwareCertificateError(serverSoftwareCertificate, serviceResult);
			}
			list.Add(softwareCertificate);
		}
		ValidateSoftwareCertificates(list);
	}

	private void ProcessPublishResponse(ResponseHeader responseHeader, uint subscriptionId, UInt32Collection availableSequenceNumbers, bool moreNotifications, NotificationMessage notificationMessage)
	{
		Subscription subscription = null;
		OnKeepAlive(m_serverState, responseHeader.Timestamp);
		lock (base.SyncRoot)
		{
			SubscriptionAcknowledgementCollection subscriptionAcknowledgementCollection = new SubscriptionAcknowledgementCollection();
			for (int i = 0; i < m_acknowledgementsToSend.Count; i++)
			{
				SubscriptionAcknowledgement subscriptionAcknowledgement = m_acknowledgementsToSend[i];
				if (subscriptionAcknowledgement.SubscriptionId != subscriptionId)
				{
					subscriptionAcknowledgementCollection.Add(subscriptionAcknowledgement);
				}
				else if (availableSequenceNumbers == null || availableSequenceNumbers.Contains(subscriptionAcknowledgement.SequenceNumber))
				{
					subscriptionAcknowledgementCollection.Add(subscriptionAcknowledgement);
				}
			}
			if (notificationMessage.NotificationData.Count > 0)
			{
				SubscriptionAcknowledgement subscriptionAcknowledgement2 = new SubscriptionAcknowledgement();
				subscriptionAcknowledgement2.SubscriptionId = subscriptionId;
				subscriptionAcknowledgement2.SequenceNumber = notificationMessage.SequenceNumber;
				subscriptionAcknowledgementCollection.Add(subscriptionAcknowledgement2);
			}
			if (availableSequenceNumbers != null)
			{
				foreach (SubscriptionAcknowledgement item in subscriptionAcknowledgementCollection)
				{
					if (item.SubscriptionId == subscriptionId && !availableSequenceNumbers.Contains(item.SequenceNumber))
					{
						Utils.LogWarning("Sequence number={0} was not received in the available sequence numbers.", item.SequenceNumber);
					}
				}
			}
			m_acknowledgementsToSend = subscriptionAcknowledgementCollection;
			if (notificationMessage.IsEmpty)
			{
				Utils.LogTrace("Empty notification message received for SessionId {0} with PublishTime {1}", base.SessionId, notificationMessage.PublishTime.ToLocalTime());
			}
			foreach (Subscription subscription2 in m_subscriptions)
			{
				if (subscription2.Id == subscriptionId)
				{
					subscription = subscription2;
					break;
				}
			}
		}
		if (subscription != null)
		{
			if (notificationMessage.PublishTime.AddMilliseconds(subscription.CurrentPublishingInterval * (double)subscription.CurrentLifetimeCount) < DateTime.UtcNow)
			{
				Utils.LogTrace("PublishTime {0} in publish response is too old for SubscriptionId {1}.", notificationMessage.PublishTime.ToLocalTime(), subscription.Id);
			}
			if (notificationMessage.PublishTime > DateTime.UtcNow.AddMilliseconds(subscription.CurrentPublishingInterval * (double)subscription.CurrentLifetimeCount))
			{
				Utils.LogTrace("PublishTime {0} in publish response is newer than actual time for SubscriptionId {1}.", notificationMessage.PublishTime.ToLocalTime(), subscription.Id);
			}
			subscription.SaveMessageInCache(availableSequenceNumbers, notificationMessage, responseHeader.StringTable);
			lock (m_eventLock)
			{
				NotificationEventArgs args = new NotificationEventArgs(subscription, notificationMessage, responseHeader.StringTable);
				if (this.m_Publish != null)
				{
					Task.Run(delegate
					{
						OnRaisePublishNotification(args);
					});
				}
				return;
			}
		}
		if (m_deleteSubscriptionsOnClose && !m_reconnecting)
		{
			Utils.LogWarning("Received Publish Response for Unknown SubscriptionId={0}. Deleting abandoned subscription from server.", subscriptionId);
			Task.Run(delegate
			{
				DeleteSubscription(subscriptionId);
			});
		}
		else
		{
			Utils.LogWarning("Received Publish Response for Unknown SubscriptionId={0}. Ignored.", subscriptionId);
		}
	}

	private void RecreateSubscriptions(IEnumerable<Subscription> subscriptionsTemplate)
	{
		bool flag = false;
		if (TransferSubscriptionsOnReconnect)
		{
			try
			{
				flag = TransferSubscriptions(new SubscriptionCollection(subscriptionsTemplate), sendInitialValues: false);
			}
			catch (ServiceResultException ex)
			{
				if (ex.StatusCode == 2148204544u)
				{
					TransferSubscriptionsOnReconnect = false;
					Utils.LogWarning("Transfer subscription unsupported, TransferSubscriptionsOnReconnect set to false.");
				}
				else
				{
					Utils.LogError(ex, "Transfer subscriptions failed.");
				}
			}
			catch (Exception exception)
			{
				Utils.LogError(exception, "Unexpected Transfer subscriptions error.");
			}
		}
		if (flag)
		{
			return;
		}
		foreach (Subscription subscription in Subscriptions)
		{
			if (!subscription.Created)
			{
				subscription.Create();
			}
		}
	}

	private void OnRaisePublishNotification(object state)
	{
		try
		{
			NotificationEventArgs e = (NotificationEventArgs)state;
			NotificationEventHandler notificationEventHandler = this.m_Publish;
			if (notificationEventHandler != null && e.Subscription.Id != 0)
			{
				notificationEventHandler(this, e);
			}
		}
		catch (Exception exception)
		{
			Utils.LogError(exception, "Session: Unexpected error while raising Notification event.");
		}
	}

	private void DeleteSubscription(uint subscriptionId)
	{
		try
		{
			Utils.LogInfo("Deleting server subscription for SubscriptionId={0}", subscriptionId);
			UInt32Collection uInt32Collection = new uint[1] { subscriptionId };
			StatusCodeCollection results;
			DiagnosticInfoCollection diagnosticInfos;
			ResponseHeader responseHeader = DeleteSubscriptions(null, uInt32Collection, out results, out diagnosticInfos);
			ClientBase.ValidateResponse(results, uInt32Collection);
			ClientBase.ValidateDiagnosticInfos(diagnosticInfos, uInt32Collection);
			if (StatusCode.IsBad(results[0]))
			{
				throw new ServiceResultException(ClientBase.GetResult(results[0], 0, diagnosticInfos, responseHeader));
			}
		}
		catch (Exception exception)
		{
			Utils.LogError(exception, "Session: Unexpected error while deleting subscription for SubscriptionId={0}.", subscriptionId);
		}
	}

	private static async Task<X509Certificate2> LoadCertificate(ApplicationConfiguration configuration)
	{
		if (configuration.SecurityConfiguration.ApplicationCertificate == null)
		{
			throw ServiceResultException.Create(2156462080u, "ApplicationCertificate must be specified.");
		}
		return (await configuration.SecurityConfiguration.ApplicationCertificate.Find(needPrivateKey: true).ConfigureAwait(continueOnCapturedContext: false)) ?? throw ServiceResultException.Create(2156462080u, "ApplicationCertificate cannot be found.");
	}

	private static async Task<X509Certificate2Collection> LoadCertificateChain(ApplicationConfiguration configuration, X509Certificate2 clientCertificate)
	{
		X509Certificate2Collection clientCertificateChain = null;
		if (configuration.SecurityConfiguration.SendCertificateChain)
		{
			clientCertificateChain = new X509Certificate2Collection(clientCertificate);
			List<CertificateIdentifier> issuers = new List<CertificateIdentifier>();
			await configuration.CertificateValidator.GetIssuers(clientCertificate, issuers).ConfigureAwait(continueOnCapturedContext: false);
			for (int i = 0; i < issuers.Count; i++)
			{
				clientCertificateChain.Add(issuers[i].Certificate);
			}
		}
		return clientCertificateChain;
	}

	private bool HasAnyContinuationPoint(ByteStringCollection continuationPoints)
	{
		foreach (byte[] continuationPoint in continuationPoints)
		{
			if (continuationPoint != null)
			{
				return true;
			}
		}
		return false;
	}

	private bool BelowPublishRequestLimit(int requestCount)
	{
		if (m_tooManyPublishRequests != 0)
		{
			return requestCount < m_tooManyPublishRequests;
		}
		return true;
	}

	private int GetMinPublishRequestCount(bool createdOnly)
	{
		lock (base.SyncRoot)
		{
			if (m_subscriptions.Count == 0)
			{
				return 0;
			}
			if (createdOnly)
			{
				int num = 0;
				foreach (Subscription subscription in m_subscriptions)
				{
					if (subscription.Created)
					{
						num++;
					}
				}
				if (num == 0)
				{
					return 0;
				}
				return Math.Max(num, m_minPublishRequestCount);
			}
			return Math.Max(m_subscriptions.Count, m_minPublishRequestCount);
		}
	}

	private CallMethodRequestCollection CreateCallRequestsForResendData(IEnumerable<Subscription> subscriptions)
	{
		CallMethodRequestCollection callMethodRequestCollection = new CallMethodRequestCollection();
		foreach (Subscription subscription in subscriptions)
		{
			VariantCollection inputArguments = new VariantCollection
			{
				new Variant(subscription.Id)
			};
			CallMethodRequest item = new CallMethodRequest
			{
				ObjectId = ObjectIds.Server,
				MethodId = MethodIds.Server_ResendData,
				InputArguments = inputArguments
			};
			callMethodRequestCollection.Add(item);
		}
		return callMethodRequestCollection;
	}

	private void RestartPublishing()
	{
		int num = 0;
		lock (base.SyncRoot)
		{
			num = GetMinPublishRequestCount(createdOnly: true);
		}
		for (int i = 0; i < num; i++)
		{
			BeginPublish(base.OperationTimeout);
		}
	}

	private UInt32Collection CreateSubscriptionIdsForTransfer(SubscriptionCollection subscriptions)
	{
		UInt32Collection uInt32Collection = new UInt32Collection();
		lock (base.SyncRoot)
		{
			foreach (Subscription subscription in subscriptions)
			{
				if (subscription.Created && base.SessionId.Equals(subscription.Session.SessionId))
				{
					throw new ServiceResultException(2158952448u, Utils.Format("The subscriptionId {0} is already created.", subscription.Id));
				}
				if (subscription.TransferId == 0)
				{
					throw new ServiceResultException(2158952448u, Utils.Format("A subscription can not be transferred due to missing transfer Id."));
				}
				uInt32Collection.Add(subscription.TransferId);
			}
			return uInt32Collection;
		}
	}

	private void IndicateSessionConfigurationChanged()
	{
		if (this.m_SessionConfigurationChanged != null)
		{
			try
			{
				this.m_SessionConfigurationChanged(this, EventArgs.Empty);
			}
			catch (Exception e)
			{
				Utils.Trace(e, "Unexpected error calling SessionConfigurationChanged event handler.");
			}
		}
	}

	public Task OpenAsync(string sessionName, IUserIdentity identity, CancellationToken ct)
	{
		return OpenAsync(sessionName, 0u, identity, null, ct);
	}

	public Task OpenAsync(string sessionName, uint sessionTimeout, IUserIdentity identity, IList<string> preferredLocales, CancellationToken ct)
	{
		return OpenAsync(sessionName, sessionTimeout, identity, preferredLocales, checkDomain: true, ct);
	}

	public async Task OpenAsync(string sessionName, uint sessionTimeout, IUserIdentity identity, IList<string> preferredLocales, bool checkDomain, CancellationToken ct)
	{
		OpenValidateIdentity(ref identity, out var identityToken, out var identityPolicy, out var securityPolicyUri, out var requireEncryption);
		X509Certificate2 serverCertificate = null;
		byte[] serverCertificate2 = m_endpoint.Description.ServerCertificate;
		if (serverCertificate2 != null && serverCertificate2.Length != 0)
		{
			X509Certificate2Collection x509Certificate2Collection = Utils.ParseCertificateChainBlob(serverCertificate2);
			if (x509Certificate2Collection.Count > 0)
			{
				serverCertificate = x509Certificate2Collection[0];
			}
			if (requireEncryption)
			{
				if (!checkDomain)
				{
					await m_configuration.CertificateValidator.ValidateAsync(x509Certificate2Collection, ct).ConfigureAwait(continueOnCapturedContext: false);
				}
				else
				{
					await m_configuration.CertificateValidator.ValidateAsync(x509Certificate2Collection, m_endpoint, ct).ConfigureAwait(continueOnCapturedContext: false);
				}
				m_checkDomain = checkDomain;
			}
		}
		uint nonceLength = (uint)m_configuration.SecurityConfiguration.NonceLength;
		byte[] clientNonce = Utils.Nonce.CreateNonce(nonceLength);
		BuildCertificateData(out var clientCertificateData, out var clientCertificateChainData);
		ApplicationDescription clientDescription = new ApplicationDescription
		{
			ApplicationUri = m_configuration.ApplicationUri,
			ApplicationName = m_configuration.ApplicationName,
			ApplicationType = ApplicationType.Client,
			ProductUri = m_configuration.ProductUri
		};
		if (sessionTimeout == 0)
		{
			sessionTimeout = (uint)m_configuration.ClientConfiguration.DefaultSessionTimeout;
		}
		bool flag = false;
		CreateSessionResponse response = null;
		if (m_endpoint.Description.SecurityPolicyUri == "http://opcfoundation.org/UA/SecurityPolicy#None")
		{
			try
			{
				response = await base.CreateSessionAsync(null, clientDescription, m_endpoint.Description.Server.ApplicationUri, m_endpoint.EndpointUrl.ToString(), sessionName, clientNonce, null, sessionTimeout, (uint)base.MessageContext.MaxMessageSize, ct).ConfigureAwait(continueOnCapturedContext: false);
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
			response = await base.CreateSessionAsync(null, clientDescription, m_endpoint.Description.Server.ApplicationUri, m_endpoint.EndpointUrl.ToString(), sessionName, clientNonce, (clientCertificateChainData != null) ? clientCertificateChainData : clientCertificateData, sessionTimeout, (uint)base.MessageContext.MaxMessageSize, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
		NodeId sessionId = response.SessionId;
		NodeId authenticationToken = response.AuthenticationToken;
		byte[] serverNonce = response.ServerNonce;
		byte[] serverCertificate3 = response.ServerCertificate;
		SignatureData serverSignature = response.ServerSignature;
		EndpointDescriptionCollection serverEndpoints = response.ServerEndpoints;
		SignedSoftwareCertificateCollection serverSoftwareCertificates = response.ServerSoftwareCertificates;
		m_sessionTimeout = response.RevisedSessionTimeout;
		m_maxRequestMessageSize = response.MaxRequestMessageSize;
		lock (base.SyncRoot)
		{
			base.SessionCreated(sessionId, authenticationToken);
		}
		Utils.LogInfo("Revised session timeout value: {0}. ", m_sessionTimeout);
		Utils.LogInfo("Max response message size value: {0}. Max request message size: {1} ", base.MessageContext.MaxMessageSize, m_maxRequestMessageSize);
		try
		{
			ValidateServerCertificateData(serverCertificate3);
			ValidateServerEndpoints(serverEndpoints);
			ValidateServerSignature(serverCertificate, serverSignature, clientCertificateData, clientCertificateChainData, clientNonce);
			HandleSignedSoftwareCertificates(serverSoftwareCertificates);
			byte[] dataToSign = Utils.Append(serverCertificate?.RawData, serverNonce);
			SignatureData clientSignature = SecurityPolicies.Sign(m_instanceCertificate, securityPolicyUri, dataToSign);
			securityPolicyUri = identityPolicy.SecurityPolicyUri;
			if (string.IsNullOrEmpty(securityPolicyUri))
			{
				securityPolicyUri = m_endpoint.Description.SecurityPolicyUri;
			}
			byte[] previousServerNonce = null;
			if (base.TransportChannel.CurrentToken != null)
			{
				previousServerNonce = base.TransportChannel.CurrentToken.ServerNonce;
			}
			ValidateServerNonce(identity, serverNonce, securityPolicyUri, previousServerNonce, m_endpoint.Description.SecurityMode);
			SignatureData userTokenSignature = identityToken.Sign(dataToSign, securityPolicyUri);
			identityToken.Encrypt(serverCertificate, serverNonce, securityPolicyUri);
			SignedSoftwareCertificateCollection softwareCertificates = GetSoftwareCertificates();
			if (preferredLocales != null && preferredLocales.Count > 0)
			{
				m_preferredLocales = new StringCollection(preferredLocales);
			}
			ActivateSessionResponse activateSessionResponse = await ActivateSessionAsync(null, clientSignature, softwareCertificates, m_preferredLocales, new ExtensionObject(identityToken), userTokenSignature, ct).ConfigureAwait(continueOnCapturedContext: false);
			serverNonce = activateSessionResponse.ServerNonce;
			StatusCodeCollection results = activateSessionResponse.Results;
			_ = activateSessionResponse.DiagnosticInfos;
			if (results != null)
			{
				for (int i = 0; i < results.Count; i++)
				{
					Utils.LogInfo("ActivateSession result[{0}] = {1}", i, results[i]);
				}
			}
			if (results == null || results.Count == 0)
			{
				Utils.LogInfo("Empty results were received for the ActivateSession call.");
			}
			await FetchNamespaceTablesAsync(ct).ConfigureAwait(continueOnCapturedContext: false);
			lock (base.SyncRoot)
			{
				m_sessionName = sessionName;
				m_identity = identity;
				m_previousServerNonce = previousServerNonce;
				m_serverNonce = serverNonce;
				m_serverCertificate = serverCertificate;
				m_systemContext.PreferredLocales = m_preferredLocales;
				m_systemContext.SessionId = base.SessionId;
				m_systemContext.UserIdentity = identity;
			}
			await FetchOperationLimitsAsync(ct).ConfigureAwait(continueOnCapturedContext: false);
			StartKeepAliveTimer();
			IndicateSessionConfigurationChanged();
		}
		catch (Exception)
		{
			try
			{
				await base.CloseSessionAsync(null, deleteSubscriptions: false, ct).ConfigureAwait(continueOnCapturedContext: false);
				CloseChannel();
			}
			catch (Exception ex3)
			{
				Utils.LogError("Cleanup: CloseSession() or CloseChannel() raised exception. " + ex3.Message);
			}
			finally
			{
				SessionCreated(null, null);
			}
			throw;
		}
	}

	public async Task<bool> RemoveSubscriptionAsync(Subscription subscription, CancellationToken ct = default(CancellationToken))
	{
		if (subscription == null)
		{
			throw new ArgumentNullException("subscription");
		}
		if (subscription.Created)
		{
			await subscription.DeleteAsync(silent: false, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
		lock (base.SyncRoot)
		{
			if (!m_subscriptions.Remove(subscription))
			{
				return false;
			}
			subscription.Session = null;
		}
		if (this.m_SubscriptionsChanged != null)
		{
			this.m_SubscriptionsChanged(this, null);
		}
		return true;
	}

	public async Task<bool> RemoveSubscriptionsAsync(IEnumerable<Subscription> subscriptions, CancellationToken ct = default(CancellationToken))
	{
		if (subscriptions == null)
		{
			throw new ArgumentNullException("subscriptions");
		}
		List<Subscription> list = new List<Subscription>();
		bool removed = PrepareSubscriptionsToDelete(subscriptions, list);
		foreach (Subscription item in list)
		{
			await item.DeleteAsync(silent: true, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
		if (removed && this.m_SubscriptionsChanged != null)
		{
			this.m_SubscriptionsChanged(this, null);
		}
		return removed;
	}

	public async Task<bool> ReactivateSubscriptionsAsync(SubscriptionCollection subscriptions, bool sendInitialValues, CancellationToken ct = default(CancellationToken))
	{
		UInt32Collection subscriptionIds = CreateSubscriptionIdsForTransfer(subscriptions);
		int failedSubscriptions = 0;
		if (subscriptionIds.Count > 0)
		{
			await m_reconnectLock.WaitAsync(ct).ConfigureAwait(continueOnCapturedContext: false);
			try
			{
				m_reconnecting = true;
				for (int ii = 0; ii < subscriptions.Count; ii++)
				{
					if (!(await subscriptions[ii].TransferAsync(this, subscriptionIds[ii], new UInt32Collection(), ct).ConfigureAwait(continueOnCapturedContext: false)))
					{
						Utils.LogError("SubscriptionId {0} failed to reactivate.", subscriptionIds[ii]);
						failedSubscriptions++;
					}
				}
				if (sendInitialValues)
				{
					var (flag, list) = await ResendDataAsync(subscriptions, ct).ConfigureAwait(continueOnCapturedContext: false);
					if (!flag)
					{
						Utils.LogError("Failed to call resend data for subscriptions.");
					}
					else if (list != null)
					{
						for (int i = 0; i < list.Count; i++)
						{
							if (StatusCode.IsNotGood(list[i].StatusCode))
							{
								Utils.LogError("SubscriptionId {0} failed to resend data.", subscriptionIds[i]);
							}
						}
					}
				}
				Utils.LogInfo("Session REACTIVATE of {0} subscriptions completed. {1} failed.", subscriptions.Count, failedSubscriptions);
			}
			finally
			{
				m_reconnecting = false;
				m_reconnectLock.Release();
			}
			RestartPublishing();
		}
		else
		{
			Utils.LogInfo("No subscriptions. Transfersubscription skipped.");
		}
		return failedSubscriptions == 0;
	}

	public async Task<(bool, IList<ServiceResult>)> ResendDataAsync(IEnumerable<Subscription> subscriptions, CancellationToken ct)
	{
		CallMethodRequestCollection requests = CreateCallRequestsForResendData(subscriptions);
		IList<ServiceResult> errors = new List<ServiceResult>(requests.Count);
		try
		{
			CallResponse obj = await CallAsync(null, requests, ct).ConfigureAwait(continueOnCapturedContext: false);
			CallMethodResultCollection results = obj.Results;
			DiagnosticInfoCollection diagnosticInfos = obj.DiagnosticInfos;
			ResponseHeader responseHeader = obj.ResponseHeader;
			ClientBase.ValidateResponse(results, requests);
			ClientBase.ValidateDiagnosticInfos(diagnosticInfos, requests);
			int num = 0;
			foreach (CallMethodResult item2 in results)
			{
				ServiceResult item = ServiceResult.Good;
				if (StatusCode.IsNotGood(item2.StatusCode))
				{
					item = ClientBase.GetResult(item2.StatusCode, num, diagnosticInfos, responseHeader);
				}
				errors.Add(item);
				num++;
			}
			return (true, errors);
		}
		catch (ServiceResultException exception)
		{
			Utils.LogError(exception, "Failed to call ResendData on server.");
		}
		return (false, errors);
	}

	public async Task<bool> TransferSubscriptionsAsync(SubscriptionCollection subscriptions, bool sendInitialValues, CancellationToken ct)
	{
		UInt32Collection subscriptionIds = CreateSubscriptionIdsForTransfer(subscriptions);
		int failedSubscriptions = 0;
		if (subscriptionIds.Count > 0)
		{
			await m_reconnectLock.WaitAsync(ct).ConfigureAwait(continueOnCapturedContext: false);
			try
			{
				m_reconnecting = true;
				TransferSubscriptionsResponse transferSubscriptionsResponse = await base.TransferSubscriptionsAsync(null, subscriptionIds, sendInitialValues, ct).ConfigureAwait(continueOnCapturedContext: false);
				TransferResultCollection results = transferSubscriptionsResponse.Results;
				DiagnosticInfoCollection diagnosticInfos = transferSubscriptionsResponse.DiagnosticInfos;
				ResponseHeader responseHeader = transferSubscriptionsResponse.ResponseHeader;
				if (!StatusCode.IsGood(responseHeader.ServiceResult))
				{
					Utils.LogError("TransferSubscription failed: {0}", responseHeader.ServiceResult);
					return false;
				}
				ClientBase.ValidateResponse(results, subscriptionIds);
				ClientBase.ValidateDiagnosticInfos(diagnosticInfos, subscriptionIds);
				for (int ii = 0; ii < subscriptions.Count; ii++)
				{
					if (StatusCode.IsGood(results[ii].StatusCode))
					{
						if (!(await subscriptions[ii].TransferAsync(this, subscriptionIds[ii], results[ii].AvailableSequenceNumbers, ct).ConfigureAwait(continueOnCapturedContext: false)))
						{
							continue;
						}
						lock (base.SyncRoot)
						{
							foreach (uint availableSequenceNumber in results[ii].AvailableSequenceNumbers)
							{
								SubscriptionAcknowledgement item = new SubscriptionAcknowledgement
								{
									SubscriptionId = subscriptionIds[ii],
									SequenceNumber = availableSequenceNumber
								};
								m_acknowledgementsToSend.Add(item);
							}
						}
					}
					else if (results[ii].StatusCode == 2148466688u)
					{
						Utils.LogInfo("SubscriptionId {0} is already member of the session.", subscriptionIds[ii]);
						failedSubscriptions++;
					}
					else
					{
						Utils.LogError("SubscriptionId {0} failed to transfer, StatusCode={1}", subscriptionIds[ii], results[ii].StatusCode);
						failedSubscriptions++;
					}
				}
				Utils.LogInfo("Session TRANSFER ASYNC of {0} subscriptions completed. {1} failed.", subscriptions.Count, failedSubscriptions);
			}
			finally
			{
				m_reconnecting = false;
				m_reconnectLock.Release();
			}
			RestartPublishing();
		}
		else
		{
			Utils.LogInfo("No subscriptions. Transfersubscription skipped.");
		}
		return failedSubscriptions == 0;
	}

	public async Task FetchNamespaceTablesAsync(CancellationToken ct = default(CancellationToken))
	{
		ReadValueIdCollection nodesToRead = PrepareNamespaceTableNodesToRead();
		ReadResponse obj = await ReadAsync(null, 0.0, TimestampsToReturn.Neither, nodesToRead, ct).ConfigureAwait(continueOnCapturedContext: false);
		DataValueCollection results = obj.Results;
		DiagnosticInfoCollection diagnosticInfos = obj.DiagnosticInfos;
		ResponseHeader responseHeader = obj.ResponseHeader;
		ClientBase.ValidateResponse(results, nodesToRead);
		ClientBase.ValidateDiagnosticInfos(diagnosticInfos, nodesToRead);
		UpdateNamespaceTable(results, diagnosticInfos, responseHeader);
	}

	public async Task FetchTypeTreeAsync(ExpandedNodeId typeId, CancellationToken ct = default(CancellationToken))
	{
		if (!(await NodeCache.FindAsync(typeId, ct).ConfigureAwait(continueOnCapturedContext: false) is Node node))
		{
			return;
		}
		ExpandedNodeIdCollection expandedNodeIdCollection = new ExpandedNodeIdCollection();
		foreach (IReference item in node.Find(ReferenceTypeIds.HasSubtype, isInverse: false))
		{
			expandedNodeIdCollection.Add(item.TargetId);
		}
		if (expandedNodeIdCollection.Count > 0)
		{
			await FetchTypeTreeAsync(expandedNodeIdCollection, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public async Task FetchTypeTreeAsync(ExpandedNodeIdCollection typeIds, CancellationToken ct = default(CancellationToken))
	{
		NodeIdCollection referenceTypeIds = new NodeIdCollection { ReferenceTypeIds.HasSubtype };
		IList<INode> obj = await NodeCache.FindReferencesAsync(typeIds, referenceTypeIds, isInverse: false, includeSubtypes: false, ct).ConfigureAwait(continueOnCapturedContext: false);
		ExpandedNodeIdCollection expandedNodeIdCollection = new ExpandedNodeIdCollection();
		foreach (INode item in obj)
		{
			if (!(item is Node node))
			{
				continue;
			}
			foreach (IReference item2 in node.Find(ReferenceTypeIds.HasSubtype, isInverse: false))
			{
				if (!typeIds.Contains(item2.TargetId))
				{
					expandedNodeIdCollection.Add(item2.TargetId);
				}
			}
		}
		if (expandedNodeIdCollection.Count > 0)
		{
			await FetchTypeTreeAsync(expandedNodeIdCollection, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public async Task FetchOperationLimitsAsync(CancellationToken ct)
	{
		try
		{
			List<string> operationLimitsProperties = (from p in typeof(OperationLimits).GetProperties()
				select p.Name).ToList();
			NodeIdCollection nodeIds = new NodeIdCollection(operationLimitsProperties.Select((string name) => (NodeId)typeof(VariableIds).GetField("Server_ServerCapabilities_OperationLimits_" + name, BindingFlags.Static | BindingFlags.Public).GetValue(null)));
			(DataValueCollection, IList<ServiceResult>) obj = await ReadValuesAsync(nodeIds, ct).ConfigureAwait(continueOnCapturedContext: false);
			DataValueCollection item = obj.Item1;
			IList<ServiceResult> item2 = obj.Item2;
			OperationLimits obj2 = m_configuration?.ClientConfiguration?.OperationLimits ?? new OperationLimits();
			OperationLimits operationLimits = new OperationLimits();
			for (int num = 0; num < nodeIds.Count; num++)
			{
				PropertyInfo property = typeof(OperationLimits).GetProperty(operationLimitsProperties[num]);
				uint num2 = (uint)property.GetValue(obj2);
				if (item[num] != null && ServiceResult.IsNotBad(item2[num]) && item[num].Value is uint num3 && num3 != 0 && (num2 == 0 || num3 < num2))
				{
					num2 = num3;
				}
				property.SetValue(operationLimits, num2);
			}
			base.OperationLimits = operationLimits;
		}
		catch (Exception exception)
		{
			Utils.LogError(exception, "Failed to read operation limits from server. Using configuration defaults.");
			OperationLimits operationLimits2 = m_configuration?.ClientConfiguration?.OperationLimits;
			if (operationLimits2 != null)
			{
				base.OperationLimits = operationLimits2;
			}
		}
	}

	public async Task<(IList<Node>, IList<ServiceResult>)> ReadNodesAsync(IList<NodeId> nodeIds, NodeClass nodeClass, bool optionalAttributes = false, CancellationToken ct = default(CancellationToken))
	{
		if (nodeIds.Count == 0)
		{
			return (new List<Node>(), new List<ServiceResult>());
		}
		if (nodeClass == NodeClass.Unspecified)
		{
			return await ReadNodesAsync(nodeIds, optionalAttributes, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
		NodeCollection nodeCollection = new NodeCollection(nodeIds.Count);
		List<IDictionary<uint, DataValue>> attributesPerNodeId = new List<IDictionary<uint, DataValue>>(nodeIds.Count);
		ReadValueIdCollection attributesToRead = new ReadValueIdCollection();
		CreateNodeClassAttributesReadNodesRequest(nodeIds, nodeClass, attributesToRead, attributesPerNodeId, nodeCollection, optionalAttributes);
		ReadResponse readResponse = await ReadAsync(null, 0.0, TimestampsToReturn.Neither, attributesToRead, ct).ConfigureAwait(continueOnCapturedContext: false);
		DataValueCollection results = readResponse.Results;
		DiagnosticInfoCollection diagnosticInfos = readResponse.DiagnosticInfos;
		ClientBase.ValidateResponse(results, attributesToRead);
		ClientBase.ValidateDiagnosticInfos(diagnosticInfos, attributesToRead);
		List<ServiceResult> list = new ServiceResult[nodeIds.Count].ToList();
		ProcessAttributesReadNodesResponse(readResponse.ResponseHeader, attributesToRead, attributesPerNodeId, results, diagnosticInfos, nodeCollection, list);
		return (nodeCollection, list);
	}

	public async Task<(IList<Node>, IList<ServiceResult>)> ReadNodesAsync(IList<NodeId> nodeIds, bool optionalAttributes = false, CancellationToken ct = default(CancellationToken))
	{
		if (nodeIds.Count == 0)
		{
			return (new List<Node>(), new List<ServiceResult>());
		}
		NodeCollection nodeCollection = new NodeCollection(nodeIds.Count);
		new ReadValueIdCollection(nodeIds.Count);
		ReadValueIdCollection itemsToRead = new ReadValueIdCollection(nodeIds.Select((NodeId nodeId) => new ReadValueId
		{
			NodeId = nodeId,
			AttributeId = 2u
		}));
		ReadResponse readResponse = await ReadAsync(null, 0.0, TimestampsToReturn.Neither, itemsToRead, ct).ConfigureAwait(continueOnCapturedContext: false);
		DataValueCollection results = readResponse.Results;
		DiagnosticInfoCollection diagnosticInfos = readResponse.DiagnosticInfos;
		ClientBase.ValidateResponse(results, itemsToRead);
		ClientBase.ValidateDiagnosticInfos(diagnosticInfos, itemsToRead);
		List<IDictionary<uint, DataValue>> attributesPerNodeId = new List<IDictionary<uint, DataValue>>(nodeIds.Count);
		List<ServiceResult> serviceResults = new List<ServiceResult>(nodeIds.Count);
		ReadValueIdCollection attributesToRead = new ReadValueIdCollection();
		CreateAttributesReadNodesRequest(readResponse.ResponseHeader, itemsToRead, results, diagnosticInfos, attributesToRead, attributesPerNodeId, nodeCollection, serviceResults, optionalAttributes);
		if (attributesToRead.Count > 0)
		{
			readResponse = await ReadAsync(null, 0.0, TimestampsToReturn.Neither, attributesToRead, ct).ConfigureAwait(continueOnCapturedContext: false);
			DataValueCollection results2 = readResponse.Results;
			diagnosticInfos = readResponse.DiagnosticInfos;
			ClientBase.ValidateResponse(results2, attributesToRead);
			ClientBase.ValidateDiagnosticInfos(diagnosticInfos, attributesToRead);
			ProcessAttributesReadNodesResponse(readResponse.ResponseHeader, attributesToRead, attributesPerNodeId, results2, diagnosticInfos, nodeCollection, serviceResults);
		}
		return (nodeCollection, serviceResults);
	}

	public Task<Node> ReadNodeAsync(NodeId nodeId, CancellationToken ct = default(CancellationToken))
	{
		return ReadNodeAsync(nodeId, NodeClass.Unspecified, optionalAttributes: true, ct);
	}

	public async Task<Node> ReadNodeAsync(NodeId nodeId, NodeClass nodeClass, bool optionalAttributes = true, CancellationToken ct = default(CancellationToken))
	{
		IDictionary<uint, DataValue> attributes = CreateAttributes(nodeClass, optionalAttributes);
		ReadValueIdCollection itemsToRead = new ReadValueIdCollection();
		foreach (uint key in attributes.Keys)
		{
			ReadValueId item = new ReadValueId
			{
				NodeId = nodeId,
				AttributeId = key
			};
			itemsToRead.Add(item);
		}
		ReadResponse readResponse = await ReadAsync(null, 0.0, TimestampsToReturn.Neither, itemsToRead, ct).ConfigureAwait(continueOnCapturedContext: false);
		DataValueCollection results = readResponse.Results;
		DiagnosticInfoCollection diagnosticInfos = readResponse.DiagnosticInfos;
		ClientBase.ValidateResponse(results, itemsToRead);
		ClientBase.ValidateDiagnosticInfos(diagnosticInfos, itemsToRead);
		return ProcessReadResponse(readResponse.ResponseHeader, attributes, itemsToRead, results, diagnosticInfos);
	}

	public async Task<DataValue> ReadValueAsync(NodeId nodeId, CancellationToken ct = default(CancellationToken))
	{
		ReadValueId item = new ReadValueId
		{
			NodeId = nodeId,
			AttributeId = 13u
		};
		ReadValueIdCollection itemsToRead = new ReadValueIdCollection { item };
		ReadResponse readResponse = await ReadAsync(null, 0.0, TimestampsToReturn.Both, itemsToRead, ct).ConfigureAwait(continueOnCapturedContext: false);
		DataValueCollection results = readResponse.Results;
		DiagnosticInfoCollection diagnosticInfos = readResponse.DiagnosticInfos;
		ClientBase.ValidateResponse(results, itemsToRead);
		ClientBase.ValidateDiagnosticInfos(diagnosticInfos, itemsToRead);
		if (StatusCode.IsBad(results[0].StatusCode))
		{
			throw new ServiceResultException(ClientBase.GetResult(results[0].StatusCode, 0, diagnosticInfos, readResponse.ResponseHeader));
		}
		return results[0];
	}

	public async Task<(DataValueCollection, IList<ServiceResult>)> ReadValuesAsync(IList<NodeId> nodeIds, CancellationToken ct = default(CancellationToken))
	{
		if (nodeIds.Count == 0)
		{
			return (new DataValueCollection(), new List<ServiceResult>());
		}
		ReadValueIdCollection itemsToRead = new ReadValueIdCollection(nodeIds.Select((NodeId nodeId) => new ReadValueId
		{
			NodeId = nodeId,
			AttributeId = 13u
		}));
		List<ServiceResult> errors = new List<ServiceResult>(itemsToRead.Count);
		ReadResponse readResponse = await ReadAsync(null, 0.0, TimestampsToReturn.Both, itemsToRead, ct).ConfigureAwait(continueOnCapturedContext: false);
		DataValueCollection results = readResponse.Results;
		DiagnosticInfoCollection diagnosticInfos = readResponse.DiagnosticInfos;
		ClientBase.ValidateResponse(results, itemsToRead);
		ClientBase.ValidateDiagnosticInfos(diagnosticInfos, itemsToRead);
		foreach (DataValue item2 in results)
		{
			ServiceResult item = ServiceResult.Good;
			if (StatusCode.IsBad(item2.StatusCode))
			{
				item = ClientBase.GetResult(results[0].StatusCode, 0, diagnosticInfos, readResponse.ResponseHeader);
			}
			errors.Add(item);
		}
		return (results, errors);
	}

	public async Task<(ResponseHeader responseHeader, ByteStringCollection continuationPoints, IList<ReferenceDescriptionCollection> referencesList, IList<ServiceResult> errors)> BrowseAsync(RequestHeader requestHeader, ViewDescription view, IList<NodeId> nodesToBrowse, uint maxResultsToReturn, BrowseDirection browseDirection, NodeId referenceTypeId, bool includeSubtypes, uint nodeClassMask, CancellationToken ct = default(CancellationToken))
	{
		BrowseDescriptionCollection browseDescription = new BrowseDescriptionCollection();
		foreach (NodeId item2 in nodesToBrowse)
		{
			BrowseDescription item = new BrowseDescription
			{
				NodeId = item2,
				BrowseDirection = browseDirection,
				ReferenceTypeId = referenceTypeId,
				IncludeSubtypes = includeSubtypes,
				NodeClassMask = nodeClassMask,
				ResultMask = 63u
			};
			browseDescription.Add(item);
		}
		BrowseResponse browseResponse = await BrowseAsync(requestHeader, view, maxResultsToReturn, browseDescription, ct).ConfigureAwait(continueOnCapturedContext: false);
		ClientBase.ValidateResponse(browseResponse.ResponseHeader);
		BrowseResultCollection results = browseResponse.Results;
		DiagnosticInfoCollection diagnosticInfos = browseResponse.DiagnosticInfos;
		ClientBase.ValidateResponse(results, browseDescription);
		ClientBase.ValidateDiagnosticInfos(diagnosticInfos, browseDescription);
		int num = 0;
		List<ServiceResult> list = new List<ServiceResult>();
		ByteStringCollection byteStringCollection = new ByteStringCollection();
		List<ReferenceDescriptionCollection> list2 = new List<ReferenceDescriptionCollection>();
		foreach (BrowseResult item3 in results)
		{
			if (StatusCode.IsBad(item3.StatusCode))
			{
				list.Add(new ServiceResult(item3.StatusCode, num, diagnosticInfos, browseResponse.ResponseHeader.StringTable));
			}
			else
			{
				list.Add(ServiceResult.Good);
			}
			byteStringCollection.Add(item3.ContinuationPoint);
			list2.Add(item3.References);
			num++;
		}
		return (responseHeader: browseResponse.ResponseHeader, continuationPoints: byteStringCollection, referencesList: list2, errors: list);
	}

	public async Task<(ResponseHeader responseHeader, ByteStringCollection revisedContinuationPoints, IList<ReferenceDescriptionCollection> referencesList, List<ServiceResult> errors)> BrowseNextAsync(RequestHeader requestHeader, ByteStringCollection continuationPoints, bool releaseContinuationPoint, CancellationToken ct = default(CancellationToken))
	{
		BrowseNextResponse browseNextResponse = await base.BrowseNextAsync(requestHeader, releaseContinuationPoint, continuationPoints, ct).ConfigureAwait(continueOnCapturedContext: false);
		ClientBase.ValidateResponse(browseNextResponse.ResponseHeader);
		BrowseResultCollection results = browseNextResponse.Results;
		DiagnosticInfoCollection diagnosticInfos = browseNextResponse.DiagnosticInfos;
		ClientBase.ValidateResponse(results, continuationPoints);
		ClientBase.ValidateDiagnosticInfos(diagnosticInfos, continuationPoints);
		int num = 0;
		List<ServiceResult> list = new List<ServiceResult>();
		ByteStringCollection byteStringCollection = new ByteStringCollection();
		List<ReferenceDescriptionCollection> list2 = new List<ReferenceDescriptionCollection>();
		foreach (BrowseResult item in results)
		{
			if (StatusCode.IsBad(item.StatusCode))
			{
				list.Add(new ServiceResult(item.StatusCode, num, diagnosticInfos, browseNextResponse.ResponseHeader.StringTable));
			}
			else
			{
				list.Add(ServiceResult.Good);
			}
			byteStringCollection.Add(item.ContinuationPoint);
			list2.Add(item.References);
			num++;
		}
		return (responseHeader: browseNextResponse.ResponseHeader, revisedContinuationPoints: byteStringCollection, referencesList: list2, errors: list);
	}

	public async Task<IList<object>> CallAsync(NodeId objectId, NodeId methodId, CancellationToken ct = default(CancellationToken), params object[] args)
	{
		VariantCollection variantCollection = new VariantCollection();
		if (args != null)
		{
			for (int i = 0; i < args.Length; i++)
			{
				variantCollection.Add(new Variant(args[i]));
			}
		}
		CallMethodRequest callMethodRequest = new CallMethodRequest();
		callMethodRequest.ObjectId = objectId;
		callMethodRequest.MethodId = methodId;
		callMethodRequest.InputArguments = variantCollection;
		CallMethodRequestCollection requests = new CallMethodRequestCollection { callMethodRequest };
		CallResponse callResponse = await CallAsync(null, requests, ct).ConfigureAwait(continueOnCapturedContext: false);
		CallMethodResultCollection results = callResponse.Results;
		DiagnosticInfoCollection diagnosticInfos = callResponse.DiagnosticInfos;
		ClientBase.ValidateResponse(results, requests);
		ClientBase.ValidateDiagnosticInfos(diagnosticInfos, requests);
		if (StatusCode.IsBad(results[0].StatusCode))
		{
			throw ServiceResultException.Create(results[0].StatusCode, 0, diagnosticInfos, callResponse.ResponseHeader.StringTable);
		}
		List<object> list = new List<object>();
		foreach (Variant outputArgument in results[0].OutputArguments)
		{
			list.Add(outputArgument.Value);
		}
		return list;
	}

	public async Task<ReferenceDescriptionCollection> FetchReferencesAsync(NodeId nodeId, CancellationToken ct = default(CancellationToken))
	{
		ReferenceDescriptionCollection results = new ReferenceDescriptionCollection();
		(ResponseHeader, ByteStringCollection, IList<ReferenceDescriptionCollection>, IList<ServiceResult>) obj = await BrowseAsync(null, null, new NodeId[1] { nodeId }, 0u, BrowseDirection.Both, null, includeSubtypes: true, 0u, ct).ConfigureAwait(continueOnCapturedContext: false);
		ByteStringCollection byteStringCollection = obj.Item2;
		IList<ReferenceDescriptionCollection> item = obj.Item3;
		if (item.Count > 0)
		{
			results.AddRange(item[0]);
			while (byteStringCollection != null && ((byteStringCollection.Count > 0) & (byteStringCollection[0] != null)))
			{
				(ResponseHeader, ByteStringCollection, IList<ReferenceDescriptionCollection>, List<ServiceResult>) obj2 = await BrowseNextAsync(null, byteStringCollection, releaseContinuationPoint: false, ct).ConfigureAwait(continueOnCapturedContext: false);
				ByteStringCollection item2 = obj2.Item2;
				IList<ReferenceDescriptionCollection> item3 = obj2.Item3;
				byteStringCollection = item2;
				if (item3.Count > 0)
				{
					results.AddRange(item3[0]);
				}
			}
		}
		return results;
	}

	public async Task<(IList<ReferenceDescriptionCollection>, IList<ServiceResult>)> FetchReferencesAsync(IList<NodeId> nodeIds, CancellationToken ct = default(CancellationToken))
	{
		List<ReferenceDescriptionCollection> result = new List<ReferenceDescriptionCollection>();
		(ResponseHeader, ByteStringCollection, IList<ReferenceDescriptionCollection>, IList<ServiceResult>) tuple = await BrowseAsync(null, null, nodeIds, 0u, BrowseDirection.Both, null, includeSubtypes: true, 0u, ct).ConfigureAwait(continueOnCapturedContext: false);
		ByteStringCollection byteStringCollection = tuple.Item2;
		IList<ReferenceDescriptionCollection> item = tuple.Item3;
		IList<ServiceResult> errors = tuple.Item4;
		result.AddRange(item);
		List<ReferenceDescriptionCollection> list = result;
		IList<ServiceResult> list2 = errors;
		while (HasAnyContinuationPoint(byteStringCollection))
		{
			ByteStringCollection byteStringCollection2 = new ByteStringCollection();
			List<ReferenceDescriptionCollection> nextResult = new List<ReferenceDescriptionCollection>();
			List<ServiceResult> nextErrors = new List<ServiceResult>();
			for (int i = 0; i < byteStringCollection.Count; i++)
			{
				byte[] array = byteStringCollection[i];
				if (array != null)
				{
					byteStringCollection2.Add(array);
					nextResult.Add(list[i]);
					nextErrors.Add(list2[i]);
				}
			}
			(ResponseHeader, ByteStringCollection, IList<ReferenceDescriptionCollection>, List<ServiceResult>) obj = await BrowseNextAsync(null, byteStringCollection2, releaseContinuationPoint: false, ct).ConfigureAwait(continueOnCapturedContext: false);
			IList<ServiceResult> item2 = obj.Item4;
			ByteStringCollection item3 = obj.Item2;
			IList<ReferenceDescriptionCollection> item4 = obj.Item3;
			IList<ServiceResult> list3 = item2;
			byteStringCollection = item3;
			list = nextResult;
			list2 = nextErrors;
			for (int j = 0; j < item4.Count; j++)
			{
				nextResult[j].AddRange(item4[j]);
				if (StatusCode.IsBad(list3[j].StatusCode))
				{
					nextErrors[j] = list3[j];
				}
			}
		}
		return (result, errors);
	}

	public static async Task<Session> RecreateAsync(Session sessionTemplate, CancellationToken ct = default(CancellationToken))
	{
		ServiceMessageContext serviceMessageContext = sessionTemplate.m_configuration.CreateMessageContext();
		serviceMessageContext.Factory = sessionTemplate.Factory;
		ITransportChannel channel = SessionChannel.Create(sessionTemplate.m_configuration, sessionTemplate.ConfiguredEndpoint.Description, sessionTemplate.ConfiguredEndpoint.Configuration, sessionTemplate.m_instanceCertificate, sessionTemplate.m_configuration.SecurityConfiguration.SendCertificateChain ? sessionTemplate.m_instanceCertificateChain : null, serviceMessageContext);
		Session session = sessionTemplate.CloneSession(channel, copyEventHandlers: true);
		try
		{
			await session.OpenAsync(sessionTemplate.SessionName, (uint)sessionTemplate.SessionTimeout, sessionTemplate.Identity, sessionTemplate.PreferredLocales, sessionTemplate.m_checkDomain, ct).ConfigureAwait(continueOnCapturedContext: false);
			await session.RecreateSubscriptionsAsync(sessionTemplate.Subscriptions, ct).ConfigureAwait(continueOnCapturedContext: false);
			return session;
		}
		catch (Exception e)
		{
			session.Dispose();
			throw ServiceResultException.Create(2147811328u, e, "Could not recreate session. {0}", sessionTemplate.SessionName);
		}
	}

	public static async Task<Session> RecreateAsync(Session sessionTemplate, ITransportWaitingConnection connection, CancellationToken ct = default(CancellationToken))
	{
		ServiceMessageContext serviceMessageContext = sessionTemplate.m_configuration.CreateMessageContext();
		serviceMessageContext.Factory = sessionTemplate.Factory;
		ITransportChannel channel = SessionChannel.Create(sessionTemplate.m_configuration, connection, sessionTemplate.m_endpoint.Description, sessionTemplate.m_endpoint.Configuration, sessionTemplate.m_instanceCertificate, sessionTemplate.m_configuration.SecurityConfiguration.SendCertificateChain ? sessionTemplate.m_instanceCertificateChain : null, serviceMessageContext);
		Session session = sessionTemplate.CloneSession(channel, copyEventHandlers: true);
		try
		{
			await session.OpenAsync(sessionTemplate.m_sessionName, (uint)sessionTemplate.m_sessionTimeout, sessionTemplate.m_identity, sessionTemplate.m_preferredLocales, sessionTemplate.m_checkDomain, ct).ConfigureAwait(continueOnCapturedContext: false);
			await session.RecreateSubscriptionsAsync(sessionTemplate.Subscriptions, ct).ConfigureAwait(continueOnCapturedContext: false);
			return session;
		}
		catch (Exception e)
		{
			session.Dispose();
			throw ServiceResultException.Create(2147811328u, e, "Could not recreate session. {0}", sessionTemplate.m_sessionName);
		}
	}

	public static async Task<Session> RecreateAsync(Session sessionTemplate, ITransportChannel transportChannel, CancellationToken ct = default(CancellationToken))
	{
		sessionTemplate.m_configuration.CreateMessageContext().Factory = sessionTemplate.Factory;
		Session session = sessionTemplate.CloneSession(transportChannel, copyEventHandlers: true);
		try
		{
			await session.OpenAsync(sessionTemplate.m_sessionName, (uint)sessionTemplate.m_sessionTimeout, sessionTemplate.m_identity, sessionTemplate.m_preferredLocales, sessionTemplate.m_checkDomain, ct).ConfigureAwait(continueOnCapturedContext: false);
			foreach (Subscription subscription in session.Subscriptions)
			{
				await subscription.CreateAsync(ct).ConfigureAwait(continueOnCapturedContext: false);
			}
			return session;
		}
		catch (Exception e)
		{
			session.Dispose();
			throw ServiceResultException.Create(2147811328u, e, "Could not recreate session. {0}", sessionTemplate.m_sessionName);
		}
	}

	public override Task<StatusCode> CloseAsync(CancellationToken ct = default(CancellationToken))
	{
		return CloseAsync(m_keepAliveInterval, closeChannel: true, ct);
	}

	public Task<StatusCode> CloseAsync(bool closeChannel, CancellationToken ct = default(CancellationToken))
	{
		return CloseAsync(m_keepAliveInterval, closeChannel, ct);
	}

	public Task<StatusCode> CloseAsync(int timeout, CancellationToken ct = default(CancellationToken))
	{
		return CloseAsync(timeout, closeChannel: true, ct);
	}

	public virtual async Task<StatusCode> CloseAsync(int timeout, bool closeChannel, CancellationToken ct = default(CancellationToken))
	{
		if (base.Disposed)
		{
			return 0u;
		}
		StatusCode result = 0u;
		Utils.SilentDispose(m_keepAliveTimer);
		m_keepAliveTimer = null;
		bool connected = base.Connected;
		if (connected && this.m_SessionClosing != null)
		{
			try
			{
				this.m_SessionClosing(this, null);
			}
			catch (Exception exception)
			{
				Utils.LogError(exception, "Session: Unexpected eror raising SessionClosing event.");
			}
		}
		if (connected && !KeepAliveStopped)
		{
			int existingTimeout = base.OperationTimeout;
			try
			{
				base.OperationTimeout = timeout;
				await base.CloseSessionAsync(null, m_deleteSubscriptionsOnClose, ct).ConfigureAwait(continueOnCapturedContext: false);
				base.OperationTimeout = existingTimeout;
				if (closeChannel)
				{
					CloseChannel();
				}
				SessionCreated(null, null);
			}
			catch (Exception ex)
			{
				result = ((!(ex is ServiceResultException)) ? ((StatusCode)2147483648u) : ((StatusCode)((ServiceResultException)ex).StatusCode));
				StatusCode statusCode = result;
				Utils.LogError("Session close error: " + statusCode.ToString());
			}
			finally
			{
				base.OperationTimeout = existingTimeout;
			}
		}
		if (closeChannel)
		{
			Dispose();
		}
		return result;
	}

	public Task ReconnectAsync(CancellationToken ct)
	{
		return ReconnectAsync(null, null, ct);
	}

	public Task ReconnectAsync(ITransportWaitingConnection connection, CancellationToken ct)
	{
		return ReconnectAsync(connection, null, ct);
	}

	public Task ReconnectAsync(ITransportChannel channel, CancellationToken ct)
	{
		return ReconnectAsync(null, channel, ct);
	}

	private async Task ReconnectAsync(ITransportWaitingConnection connection, ITransportChannel transportChannel, CancellationToken ct)
	{
		bool resetReconnect = false;
		await m_reconnectLock.WaitAsync(ct).ConfigureAwait(continueOnCapturedContext: false);
		try
		{
			bool reconnecting = m_reconnecting;
			m_reconnecting = true;
			resetReconnect = true;
			m_reconnectLock.Release();
			if (reconnecting)
			{
				Utils.LogWarning("Session is already attempting to reconnect.");
				throw ServiceResultException.Create(2158952448u, "Session is already attempting to reconnect.");
			}
			IAsyncResult result = PrepareReconnectBeginActivate(connection, transportChannel);
			if (!(result is ChannelAsyncOperation<int> channelAsyncOperation))
			{
				throw new ArgumentNullException("result");
			}
			try
			{
				await channelAsyncOperation.EndAsync(7500, throwOnError: true, ct).ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (ServiceResultException)
			{
				Utils.LogWarning("WARNING: ACTIVATE SESSION {0} timed out. {1}/{2}", base.SessionId, GoodPublishRequestCount, OutstandingRequestCount);
			}
			byte[] serverNonce = null;
			StatusCodeCollection results = null;
			DiagnosticInfoCollection diagnosticInfos = null;
			EndActivateSession(result, out serverNonce, out results, out diagnosticInfos);
			int publishCount = 0;
			Utils.LogInfo("Session RECONNECT {0} completed successfully.", base.SessionId);
			lock (base.SyncRoot)
			{
				m_previousServerNonce = m_serverNonce;
				m_serverNonce = serverNonce;
				publishCount = GetMinPublishRequestCount(createdOnly: true);
			}
			await m_reconnectLock.WaitAsync(ct).ConfigureAwait(continueOnCapturedContext: false);
			m_reconnecting = false;
			resetReconnect = false;
			m_reconnectLock.Release();
			for (int i = 0; i < publishCount; i++)
			{
				BeginPublish(base.OperationTimeout);
			}
			StartKeepAliveTimer();
			IndicateSessionConfigurationChanged();
		}
		finally
		{
			if (resetReconnect)
			{
				await m_reconnectLock.WaitAsync(ct).ConfigureAwait(continueOnCapturedContext: false);
				m_reconnecting = false;
				m_reconnectLock.Release();
			}
		}
	}

	public async Task<bool> RepublishAsync(uint subscriptionId, uint sequenceNumber, CancellationToken ct)
	{
		RequestHeader requestHeader = new RequestHeader
		{
			TimeoutHint = (uint)base.OperationTimeout,
			ReturnDiagnostics = (uint)base.ReturnDiagnostics,
			RequestHandle = Utils.IncrementIdentifier(ref m_publishCounter)
		};
		try
		{
			Utils.LogInfo("Requesting RepublishAsync for {0}-{1}", subscriptionId, sequenceNumber);
			RepublishResponse obj = await RepublishAsync(requestHeader, subscriptionId, sequenceNumber, ct).ConfigureAwait(continueOnCapturedContext: false);
			ResponseHeader responseHeader = obj.ResponseHeader;
			NotificationMessage notificationMessage = obj.NotificationMessage;
			Utils.LogInfo("Received RepublishAsync for {0}-{1}-{2}", subscriptionId, sequenceNumber, responseHeader.ServiceResult);
			ProcessPublishResponse(responseHeader, subscriptionId, null, moreNotifications: false, notificationMessage);
			return true;
		}
		catch (Exception e)
		{
			return ProcessRepublishResponseError(e, subscriptionId, sequenceNumber);
		}
	}

	private async Task RecreateSubscriptionsAsync(IEnumerable<Subscription> subscriptionsTemplate, CancellationToken ct)
	{
		bool transferred = false;
		if (TransferSubscriptionsOnReconnect)
		{
			try
			{
				transferred = await TransferSubscriptionsAsync(new SubscriptionCollection(subscriptionsTemplate), sendInitialValues: false, ct).ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (ServiceResultException ex)
			{
				if (ex.StatusCode == 2148204544u)
				{
					TransferSubscriptionsOnReconnect = false;
					Utils.LogWarning("Transfer subscription unsupported, TransferSubscriptionsOnReconnect set to false.");
				}
				else
				{
					Utils.LogError(ex, "Transfer subscriptions failed.");
				}
			}
			catch (Exception exception)
			{
				Utils.LogError(exception, "Unexpected Transfer subscriptions error.");
			}
		}
		if (transferred)
		{
			return;
		}
		foreach (Subscription subscription in Subscriptions)
		{
			if (!subscription.Created)
			{
				await subscription.CreateAsync(ct).ConfigureAwait(continueOnCapturedContext: false);
			}
		}
	}

	[Obsolete("Call Create instead. Service Call doesn't create Session.")]
	public override ResponseHeader CreateSession(RequestHeader requestHeader, ApplicationDescription clientDescription, string serverUri, string endpointUrl, string sessionName, byte[] clientNonce, byte[] clientCertificate, double requestedSessionTimeout, uint maxResponseMessageSize, out NodeId sessionId, out NodeId authenticationToken, out double revisedSessionTimeout, out byte[] serverNonce, out byte[] serverCertificate, out EndpointDescriptionCollection serverEndpoints, out SignedSoftwareCertificateCollection serverSoftwareCertificates, out SignatureData serverSignature, out uint maxRequestMessageSize)
	{
		return base.CreateSession(requestHeader, clientDescription, serverUri, endpointUrl, sessionName, clientNonce, clientCertificate, requestedSessionTimeout, maxResponseMessageSize, out sessionId, out authenticationToken, out revisedSessionTimeout, out serverNonce, out serverCertificate, out serverEndpoints, out serverSoftwareCertificates, out serverSignature, out maxRequestMessageSize);
	}

	[Obsolete("Call Create instead. Service Call doesn't create Session.")]
	public override Task<CreateSessionResponse> CreateSessionAsync(RequestHeader requestHeader, ApplicationDescription clientDescription, string serverUri, string endpointUrl, string sessionName, byte[] clientNonce, byte[] clientCertificate, double requestedSessionTimeout, uint maxResponseMessageSize, CancellationToken ct)
	{
		return base.CreateSessionAsync(requestHeader, clientDescription, serverUri, endpointUrl, sessionName, clientNonce, clientCertificate, requestedSessionTimeout, maxResponseMessageSize, ct);
	}

	[Obsolete("Call Close instead. Service Call doesn't clean up Session.")]
	public override ResponseHeader CloseSession(RequestHeader requestHeader, bool deleteSubscriptions)
	{
		return base.CloseSession(requestHeader, deleteSubscriptions);
	}

	[Obsolete("Call CloseAsync instead. Service Call doesn't clean up Session.")]
	public override Task<CloseSessionResponse> CloseSessionAsync(RequestHeader requestHeader, bool deleteSubscriptions, CancellationToken ct)
	{
		return base.CloseSessionAsync(requestHeader, deleteSubscriptions, ct);
	}

	[Obsolete("Call ISession.TransferSubscriptions(SubscriptionIds, bool) instead.")]
	public override ResponseHeader TransferSubscriptions(RequestHeader requestHeader, UInt32Collection subscriptionIds, bool sendInitialValues, out TransferResultCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		return base.TransferSubscriptions(requestHeader, subscriptionIds, sendInitialValues, out results, out diagnosticInfos);
	}

	[Obsolete("Call ISession.TransferSubscriptionsAsync(SubscriptionIds, bool) instead.")]
	public override Task<TransferSubscriptionsResponse> TransferSubscriptionsAsync(RequestHeader requestHeader, UInt32Collection subscriptionIds, bool sendInitialValues, CancellationToken ct)
	{
		return base.TransferSubscriptionsAsync(requestHeader, subscriptionIds, sendInitialValues, ct);
	}
}
