using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using Microsoft.Extensions.Logging;
using Opc.Ua.Bindings;

namespace Opc.Ua;

[ComVisible(true)]
public class ServerBase : IServerBase, IAuditEventCallback, IDisposable
{
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

		public RequestQueue(ServerBase server, int minThreadCount, int maxThreadCount, int maxRequestCount)
		{
			m_server = server;
			m_stopped = false;
			m_minThreadCount = minThreadCount;
			m_maxThreadCount = maxThreadCount;
			m_maxRequestCount = maxRequestCount;
			m_activeThreadCount = 0;
			m_queue = new Queue<IEndpointIncomingRequest>(maxRequestCount);
			m_totalThreadCount = 0;
			ThreadPool.GetMinThreads(out minThreadCount, out var completionPortThreads);
			ThreadPool.SetMinThreads(Math.Max(minThreadCount, m_minThreadCount), Math.Max(completionPortThreads, m_minThreadCount));
			ThreadPool.GetMaxThreads(out maxThreadCount, out var completionPortThreads2);
			ThreadPool.SetMaxThreads(Math.Max(maxThreadCount, m_maxThreadCount), Math.Max(completionPortThreads2, m_maxThreadCount));
		}

		public void Dispose()
		{
			Dispose(disposing: true);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				lock (m_lock)
				{
					m_stopped = true;
					Monitor.PulseAll(m_lock);
					m_queue.Clear();
				}
			}
		}

		public void ScheduleIncomingRequest(IEndpointIncomingRequest request)
		{
			Monitor.Enter(m_lock);
			bool flag = true;
			try
			{
				if (m_stopped)
				{
					flag = false;
					Monitor.Exit(m_lock);
					request.OperationCompleted(null, 2148401152u);
					Utils.LogTrace("Server halted.");
					return;
				}
				if (m_queue.Count >= m_maxRequestCount)
				{
					int totalThreadCount = m_totalThreadCount;
					int activeThreadCount = m_activeThreadCount;
					flag = false;
					Monitor.Exit(m_lock);
					request.OperationCompleted(null, 2163081216u);
					Utils.LogTrace("Too many operations. Total: {0} Active: {1}", totalThreadCount, activeThreadCount);
					return;
				}
				m_queue.Enqueue(request);
				if (m_activeThreadCount < m_totalThreadCount)
				{
					Monitor.Pulse(m_lock);
				}
				else if (m_totalThreadCount < m_maxThreadCount)
				{
					int totalThreadCount = ++m_totalThreadCount;
					int activeThreadCount = ++m_activeThreadCount;
					flag = false;
					Monitor.Exit(m_lock);
					Thread thread = new Thread(OnProcessRequestQueue);
					thread.IsBackground = true;
					thread.Start(null);
					Utils.LogTrace("Thread created: {0:X8}. Total: {1} Active: {2}", thread.ManagedThreadId, totalThreadCount, activeThreadCount);
				}
			}
			finally
			{
				if (flag)
				{
					Monitor.Exit(m_lock);
				}
			}
		}

		private void OnProcessRequestQueue(object state)
		{
			lock (m_lock)
			{
				while (true)
				{
					if (m_queue.Count == 0)
					{
						m_activeThreadCount--;
						if (m_stopped || (!Monitor.Wait(m_lock, 15000) && m_totalThreadCount > m_minThreadCount))
						{
							break;
						}
						m_activeThreadCount++;
						continue;
					}
					IEndpointIncomingRequest request = m_queue.Dequeue();
					Monitor.Exit(m_lock);
					try
					{
						m_server.ProcessRequest(request, state);
					}
					catch (Exception exception)
					{
						Utils.LogError(exception, "Unexpected error processing incoming request.");
					}
					finally
					{
						Monitor.Enter(m_lock);
					}
				}
				m_totalThreadCount--;
				Utils.LogTrace("Thread ended: {0:X8}. Total: {1} Active: {2}", Environment.CurrentManagedThreadId, m_totalThreadCount, m_activeThreadCount);
			}
		}
	}

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

	private RequestQueue m_requestQueue;

	private int m_userTokenPolicyId;

	public IServiceMessageContext MessageContext
	{
		get
		{
			return (IServiceMessageContext)m_messageContext;
		}
		set
		{
			Interlocked.Exchange(ref m_messageContext, value);
		}
	}

	public ServiceResult ServerError
	{
		get
		{
			return (ServiceResult)m_serverError;
		}
		set
		{
			Interlocked.Exchange(ref m_serverError, value);
		}
	}

	protected IList<BaseAddress> BaseAddresses { get; set; }

	protected ReadOnlyList<EndpointDescription> Endpoints => m_endpoints;

	public CertificateValidator CertificateValidator
	{
		get
		{
			return (CertificateValidator)m_certificateValidator;
		}
		private set
		{
			m_certificateValidator = value;
		}
	}

	protected X509Certificate2 InstanceCertificate
	{
		get
		{
			return (X509Certificate2)m_instanceCertificate;
		}
		private set
		{
			m_instanceCertificate = value;
		}
	}

	protected X509Certificate2Collection InstanceCertificateChain
	{
		get
		{
			return m_instanceCertificateChain;
		}
		private set
		{
			m_instanceCertificateChain = value;
		}
	}

	protected ServerProperties ServerProperties
	{
		get
		{
			return (ServerProperties)m_serverProperties;
		}
		private set
		{
			m_serverProperties = value;
		}
	}

	protected ApplicationConfiguration Configuration
	{
		get
		{
			return (ApplicationConfiguration)m_configuration;
		}
		private set
		{
			m_configuration = value;
		}
	}

	protected ApplicationDescription ServerDescription
	{
		get
		{
			return (ApplicationDescription)m_serverDescription;
		}
		private set
		{
			m_serverDescription = value;
		}
	}

	protected List<ServiceHost> ServiceHosts => m_hosts;

	protected StringCollection ServerCapabilities { get; set; }

	protected List<ITransportListener> TransportListeners => m_listeners;

	public event EventHandler<ConnectionStatusEventArgs> ConnectionStatusChanged;

	public ServerBase()
	{
		m_messageContext = new ServiceMessageContext();
		m_serverError = new ServiceResult(2148401152u);
		m_hosts = new List<ServiceHost>();
		m_listeners = new List<ITransportListener>();
		m_endpoints = null;
		m_requestQueue = new RequestQueue(this, 10, 100, 1000);
		m_userTokenPolicyId = 0;
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!disposing)
		{
			return;
		}
		if (m_listeners != null)
		{
			for (int i = 0; i < m_listeners.Count; i++)
			{
				Utils.SilentDispose(m_listeners[i]);
			}
			m_listeners.Clear();
		}
		if (m_hosts != null)
		{
			for (int j = 0; j < m_hosts.Count; j++)
			{
				Utils.SilentDispose(m_hosts[j]);
			}
			m_hosts.Clear();
		}
		Utils.SilentDispose(m_requestQueue);
	}

	public virtual EndpointDescriptionCollection GetEndpoints()
	{
		ReadOnlyList<EndpointDescription> endpoints = m_endpoints;
		if (endpoints != null)
		{
			return new EndpointDescriptionCollection(endpoints);
		}
		return new EndpointDescriptionCollection();
	}

	public virtual void ScheduleIncomingRequest(IEndpointIncomingRequest request)
	{
		m_requestQueue.ScheduleIncomingRequest(request);
	}

	public virtual void ReportAuditOpenSecureChannelEvent(string globalChannelId, EndpointDescription endpointDescription, OpenSecureChannelRequest request, X509Certificate2 clientCertificate, Exception exception)
	{
	}

	public virtual void ReportAuditCloseSecureChannelEvent(string globalChannelId, Exception exception)
	{
	}

	public virtual void ReportAuditCertificateEvent(X509Certificate2 clientCertificate, Exception exception)
	{
	}

	protected virtual void OnConnectionStatusChanged(object sender, ConnectionStatusEventArgs e)
	{
		this.ConnectionStatusChanged?.Invoke(sender, e);
	}

	public void CreateConnection(Uri url, int timeout)
	{
		ITransportListener transportListener = null;
		Utils.LogInfo("Create Reverse Connection to Client at {0}.", url);
		if (TransportListeners != null)
		{
			foreach (ITransportListener transportListener2 in TransportListeners)
			{
				if (transportListener2.UriScheme == url.Scheme)
				{
					transportListener = transportListener2;
					transportListener.CreateReverseConnection(url, timeout);
				}
			}
		}
		if (transportListener == null)
		{
			throw new ArgumentException("No suitable listener found.", "url");
		}
	}

	public ServiceHost Start(ApplicationConfiguration configuration, params Uri[] baseAddresses)
	{
		if (configuration == null)
		{
			throw new ArgumentNullException("configuration");
		}
		OnServerStarting(configuration);
		InitializeRequestQueue(configuration);
		TransportListenerBindings listeners = TransportBindings.Listeners;
		ServerCapabilities = configuration.ServerConfiguration.ServerCapabilities;
		InitializeBaseAddresses(configuration);
		ApplicationDescription serverDescription = null;
		EndpointDescriptionCollection endpoints = null;
		IList<ServiceHost> list = InitializeServiceHosts(configuration, listeners, out serverDescription, out endpoints);
		ServerDescription = serverDescription;
		m_endpoints = new ReadOnlyList<EndpointDescription>(endpoints);
		StartApplication(configuration);
		if (list == null || list.Count == 0)
		{
			throw ServiceResultException.Create(2156462080u, "The UA server does not have a default host.");
		}
		lock (m_hosts)
		{
			for (int i = 1; i < list.Count; i++)
			{
				list[i].Open();
				m_hosts.Add(list[i]);
			}
		}
		return list[0];
	}

	public void Start(ApplicationConfiguration configuration)
	{
		if (configuration == null)
		{
			throw new ArgumentNullException("configuration");
		}
		OnServerStarting(configuration);
		InitializeRequestQueue(configuration);
		TransportListenerBindings listeners = TransportBindings.Listeners;
		ServerCapabilities = configuration.ServerConfiguration.ServerCapabilities;
		InitializeBaseAddresses(configuration);
		ApplicationDescription serverDescription = null;
		EndpointDescriptionCollection endpoints = null;
		IList<ServiceHost> list = InitializeServiceHosts(configuration, listeners, out serverDescription, out endpoints);
		ServerDescription = serverDescription;
		m_endpoints = new ReadOnlyList<EndpointDescription>(endpoints);
		StartApplication(configuration);
		lock (m_hosts)
		{
			foreach (ServiceHost item in list)
			{
				item.Open();
				m_hosts.Add(item);
			}
		}
	}

	private void InitializeBaseAddresses(ApplicationConfiguration configuration)
	{
		BaseAddresses = new List<BaseAddress>();
		StringCollection stringCollection = null;
		StringCollection stringCollection2 = null;
		if (configuration.ServerConfiguration != null)
		{
			stringCollection = configuration.ServerConfiguration.BaseAddresses;
			stringCollection2 = configuration.ServerConfiguration.AlternateBaseAddresses;
		}
		if (configuration.DiscoveryServerConfiguration != null)
		{
			stringCollection = configuration.DiscoveryServerConfiguration.BaseAddresses;
			stringCollection2 = configuration.DiscoveryServerConfiguration.AlternateBaseAddresses;
		}
		if (stringCollection == null)
		{
			return;
		}
		foreach (string item in stringCollection)
		{
			BaseAddress baseAddress = new BaseAddress
			{
				Url = new Uri(item)
			};
			if (stringCollection2 != null)
			{
				foreach (string item2 in stringCollection2)
				{
					Uri uri = new Uri(item2);
					if (uri.Scheme == baseAddress.Url.Scheme)
					{
						if (baseAddress.AlternateUrls == null)
						{
							baseAddress.AlternateUrls = new List<Uri>();
						}
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
			BaseAddresses.Add(baseAddress);
		}
	}

	protected StringCollection GetDiscoveryUrls()
	{
		StringCollection stringCollection = new StringCollection();
		string hostName = Utils.GetHostName();
		foreach (BaseAddress baseAddress in BaseAddresses)
		{
			UriBuilder uriBuilder = new UriBuilder(baseAddress.DiscoveryUrl);
			int num = uriBuilder.Host.IndexOf("localhost", StringComparison.OrdinalIgnoreCase);
			if (num == -1)
			{
				num = uriBuilder.Host.IndexOf("{0}", StringComparison.OrdinalIgnoreCase);
			}
			if (num != -1)
			{
				uriBuilder.Host = hostName;
			}
			stringCollection.Add(uriBuilder.ToString());
			if (baseAddress.AlternateUrls == null)
			{
				continue;
			}
			foreach (Uri alternateUrl in baseAddress.AlternateUrls)
			{
				uriBuilder = new UriBuilder(alternateUrl);
				stringCollection.Add(uriBuilder.ToString());
			}
		}
		return stringCollection;
	}

	protected void InitializeRequestQueue(ApplicationConfiguration configuration)
	{
		int num = 10;
		int num2 = 1000;
		int num3 = 2000;
		if (configuration.ServerConfiguration != null)
		{
			num = configuration.ServerConfiguration.MinRequestThreadCount;
			num2 = configuration.ServerConfiguration.MaxRequestThreadCount;
			num3 = configuration.ServerConfiguration.MaxQueuedRequestCount;
		}
		else if (configuration.DiscoveryServerConfiguration != null)
		{
			num = configuration.DiscoveryServerConfiguration.MinRequestThreadCount;
			num2 = configuration.DiscoveryServerConfiguration.MaxRequestThreadCount;
			num3 = configuration.DiscoveryServerConfiguration.MaxQueuedRequestCount;
		}
		if (num < 1)
		{
			num = 1;
		}
		if (num2 < num)
		{
			num2 = num;
		}
		if (num2 < 100)
		{
			num2 = 100;
		}
		if (num3 < 100)
		{
			num3 = 100;
		}
		if (m_requestQueue != null)
		{
			m_requestQueue.Dispose();
		}
		m_requestQueue = new RequestQueue(this, num, num2, num3);
	}

	public virtual void Stop()
	{
		try
		{
			OnServerStopping();
		}
		catch (Exception exception)
		{
			m_serverError = new ServiceResult(exception);
		}
		List<ITransportListener> listeners = m_listeners;
		if (listeners != null)
		{
			for (int i = 0; i < listeners.Count; i++)
			{
				try
				{
					listeners[i].Close();
				}
				catch (Exception exception2)
				{
					Utils.LogError(exception2, "Unexpected error closing a listener. {0}", listeners[i].GetType().FullName);
				}
			}
			listeners.Clear();
		}
		lock (m_hosts)
		{
			foreach (ServiceHost host in m_hosts)
			{
				if (host.State == ServiceHostState.Opened)
				{
					host.Abort();
				}
				host.Close();
			}
		}
	}

	public virtual ServiceHost CreateServiceHost(ServerBase server, params Uri[] addresses)
	{
		return null;
	}

	protected virtual Type GetServiceContract()
	{
		return null;
	}

	protected virtual EndpointBase GetEndpointInstance(ServerBase server)
	{
		return null;
	}

	public static bool RequireEncryption(EndpointDescription description)
	{
		bool flag = false;
		if (description != null)
		{
			flag = description.SecurityPolicyUri != "http://opcfoundation.org/UA/SecurityPolicy#None";
			if (!flag)
			{
				foreach (UserTokenPolicy userIdentityToken in description.UserIdentityTokens)
				{
					if (userIdentityToken.SecurityPolicyUri != "http://opcfoundation.org/UA/SecurityPolicy#None")
					{
						flag = true;
						break;
					}
				}
			}
		}
		return flag;
	}

	protected virtual void OnCertificateUpdate(object sender, CertificateUpdateEventArgs e)
	{
		InstanceCertificateChain = null;
		InstanceCertificate = e.SecurityConfiguration.ApplicationCertificate.Certificate;
		if (Configuration.SecurityConfiguration.SendCertificateChain)
		{
			InstanceCertificateChain = new X509Certificate2Collection(InstanceCertificate);
			List<CertificateIdentifier> list = new List<CertificateIdentifier>();
			Dictionary<X509Certificate2, ServiceResultException> dictionary = new Dictionary<X509Certificate2, ServiceResultException>();
			Configuration.CertificateValidator.GetIssuersNoExceptionsOnGetIssuer(InstanceCertificateChain, list, dictionary).GetAwaiter().GetResult();
			foreach (KeyValuePair<X509Certificate2, ServiceResultException> item in dictionary)
			{
				if (item.Value != null)
				{
					Utils.LogCertificate("OnCertificateUpdate: GetIssuers Validation Error: {0}", item.Key, item.Value.Result);
				}
			}
			for (int i = 0; i < list.Count; i++)
			{
				InstanceCertificateChain.Add(list[i].Certificate);
			}
		}
		foreach (ITransportListener transportListener in TransportListeners)
		{
			transportListener.CertificateUpdate(e.CertificateValidator, InstanceCertificate, InstanceCertificateChain);
		}
	}

	public virtual void CreateServiceHostEndpoint(Uri endpointUri, EndpointDescriptionCollection endpoints, EndpointConfiguration endpointConfiguration, ITransportListener listener, ICertificateValidator certificateValidator)
	{
		try
		{
			TransportListenerSettings transportListenerSettings = new TransportListenerSettings();
			transportListenerSettings.Descriptions = endpoints;
			transportListenerSettings.Configuration = endpointConfiguration;
			transportListenerSettings.ServerCertificate = InstanceCertificate;
			transportListenerSettings.CertificateValidator = certificateValidator;
			transportListenerSettings.NamespaceUris = MessageContext.NamespaceUris;
			transportListenerSettings.Factory = MessageContext.Factory;
			listener.Open(endpointUri, transportListenerSettings, GetEndpointInstance(this));
			TransportListeners.Add(listener);
			listener.ConnectionStatusChanged += OnConnectionStatusChanged;
		}
		catch (Exception ex)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Could not load ").Append(endpointUri.Scheme).Append(" Stack Listener.");
			if (ex.InnerException != null)
			{
				stringBuilder.Append(' ').Append(ex.InnerException.Message);
			}
			Utils.LogError(ex, stringBuilder.ToString());
			throw;
		}
	}

	public virtual UserTokenPolicyCollection GetUserTokenPolicies(ApplicationConfiguration configuration, EndpointDescription description)
	{
		UserTokenPolicyCollection userTokenPolicyCollection = new UserTokenPolicyCollection();
		if (configuration.ServerConfiguration == null || configuration.ServerConfiguration.UserTokenPolicies == null)
		{
			return userTokenPolicyCollection;
		}
		foreach (UserTokenPolicy userTokenPolicy2 in configuration.ServerConfiguration.UserTokenPolicies)
		{
			UserTokenPolicy userTokenPolicy = (UserTokenPolicy)userTokenPolicy2.Clone();
			if (string.IsNullOrEmpty(userTokenPolicy2.SecurityPolicyUri) && description.SecurityMode == MessageSecurityMode.None)
			{
				if (userTokenPolicy.TokenType == UserTokenType.Anonymous)
				{
					userTokenPolicy.SecurityPolicyUri = "http://opcfoundation.org/UA/SecurityPolicy#None";
				}
				else
				{
					userTokenPolicy.SecurityPolicyUri = "http://opcfoundation.org/UA/SecurityPolicy#Basic256Sha256";
				}
			}
			userTokenPolicy.PolicyId = Utils.Format("{0}", ++m_userTokenPolicyId);
			userTokenPolicyCollection.Add(userTokenPolicy);
		}
		return userTokenPolicyCollection;
	}

	protected string NormalizeHostname(string hostname)
	{
		string hostName = Utils.GetHostName();
		if (Utils.AreDomainsEqual(hostname, "localhost"))
		{
			return hostName.ToUpper(CultureInfo.InvariantCulture);
		}
		IPAddress address = null;
		if (IPAddress.TryParse(hostname, out address))
		{
			if (IPAddress.IsLoopback(address))
			{
				return hostName.ToUpper(CultureInfo.InvariantCulture);
			}
			IPAddress[] hostAddresses = Utils.GetHostAddresses(Utils.GetHostName());
			for (int i = 0; i < hostAddresses.Length; i++)
			{
				if (hostAddresses[i].Equals(address))
				{
					return hostName.ToUpper(CultureInfo.InvariantCulture);
				}
			}
			return hostname.ToUpper(CultureInfo.InvariantCulture);
		}
		IPHostEntry iPHostEntry = null;
		try
		{
			iPHostEntry = Dns.GetHostEntry(hostName);
		}
		catch (SocketException exception)
		{
			Utils.LogError(exception, "Unable to check aliases for hostname {0}.", hostName);
		}
		if (iPHostEntry != null)
		{
			for (int j = 0; j < iPHostEntry.Aliases.Length; j++)
			{
				if (Utils.AreDomainsEqual(hostname, iPHostEntry.Aliases[j]))
				{
					return hostName.ToUpper(CultureInfo.InvariantCulture);
				}
			}
		}
		return hostname.ToUpper(CultureInfo.InvariantCulture);
	}

	protected IList<BaseAddress> FilterByProfile(StringCollection profileUris, IList<BaseAddress> baseAddresses)
	{
		if (profileUris == null || profileUris.Count == 0)
		{
			return baseAddresses;
		}
		List<BaseAddress> list = new List<BaseAddress>();
		foreach (BaseAddress baseAddress in baseAddresses)
		{
			foreach (string profileUri in profileUris)
			{
				if (baseAddress.ProfileUri == Profiles.NormalizeUri(profileUri))
				{
					list.Add(baseAddress);
					break;
				}
			}
		}
		return list;
	}

	protected IList<BaseAddress> FilterByEndpointUrl(Uri endpointUrl, IList<BaseAddress> baseAddresses)
	{
		List<BaseAddress> list = new List<BaseAddress>();
		foreach (BaseAddress baseAddress in baseAddresses)
		{
			if (baseAddress.Url.DnsSafeHost == endpointUrl.DnsSafeHost)
			{
				list.Add(baseAddress);
			}
			else
			{
				if (baseAddress.AlternateUrls == null)
				{
					continue;
				}
				foreach (Uri alternateUrl in baseAddress.AlternateUrls)
				{
					if (alternateUrl.DnsSafeHost == endpointUrl.DnsSafeHost)
					{
						list.Add(new BaseAddress
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
		if (list.Count != 0)
		{
			return list;
		}
		if (NormalizeHostname(endpointUrl.DnsSafeHost) == NormalizeHostname("localhost"))
		{
			return baseAddresses;
		}
		foreach (BaseAddress baseAddress2 in baseAddresses)
		{
			if (baseAddress2.Url.Scheme == endpointUrl.Scheme)
			{
				list.Add(baseAddress2);
			}
		}
		return list;
	}

	private static string GetBestDiscoveryUrl(Uri clientUrl, BaseAddress baseAddress)
	{
		string text = baseAddress.Url.ToString();
		if (baseAddress.ProfileUri == "http://opcfoundation.org/UA-Profile/Transport/https-uabinary" && text.StartsWith("http") && !text.EndsWith("discovery"))
		{
			text += "/discovery";
		}
		return text;
	}

	protected ApplicationDescription TranslateApplicationDescription(Uri clientUrl, ApplicationDescription description, IList<BaseAddress> baseAddresses, LocalizedText applicationName)
	{
		StringCollection stringCollection = new StringCollection();
		foreach (BaseAddress baseAddress in baseAddresses)
		{
			stringCollection.Add(GetBestDiscoveryUrl(clientUrl, baseAddress));
		}
		ApplicationDescription applicationDescription = new ApplicationDescription();
		applicationDescription.ApplicationName = description.ApplicationName;
		applicationDescription.ApplicationUri = description.ApplicationUri;
		applicationDescription.ApplicationType = description.ApplicationType;
		applicationDescription.ProductUri = description.ProductUri;
		applicationDescription.GatewayServerUri = description.DiscoveryProfileUri;
		applicationDescription.DiscoveryUrls = stringCollection;
		if (!LocalizedText.IsNullOrEmpty(applicationName))
		{
			applicationDescription.ApplicationName = applicationName;
		}
		return applicationDescription;
	}

	protected EndpointDescriptionCollection TranslateEndpointDescriptions(Uri clientUrl, IList<BaseAddress> baseAddresses, IList<EndpointDescription> endpoints, ApplicationDescription application)
	{
		EndpointDescriptionCollection endpointDescriptionCollection = new EndpointDescriptionCollection();
		foreach (EndpointDescription endpoint in endpoints)
		{
			UriBuilder uriBuilder = new UriBuilder(endpoint.EndpointUrl);
			foreach (BaseAddress baseAddress in baseAddresses)
			{
				bool flag = false;
				if (endpoint.TransportProfileUri == "http://opcfoundation.org/UA-Profile/Transport/https-uabinary" && baseAddress.ProfileUri == "http://opcfoundation.org/UA-Profile/Transport/https-uabinary")
				{
					flag = true;
				}
				if ((!(endpoint.TransportProfileUri != baseAddress.ProfileUri) || flag) && !(uriBuilder.Scheme != baseAddress.Url.Scheme) && uriBuilder.Port == baseAddress.Url.Port)
				{
					EndpointDescription endpointDescription = new EndpointDescription();
					endpointDescription.EndpointUrl = baseAddress.Url.ToString();
					if (uriBuilder.Path.StartsWith(baseAddress.Url.PathAndQuery, StringComparison.Ordinal) && uriBuilder.Path.Length > baseAddress.Url.PathAndQuery.Length)
					{
						string text = uriBuilder.Path.Substring(baseAddress.Url.PathAndQuery.Length);
						endpointDescription.EndpointUrl += text;
					}
					endpointDescription.ProxyUrl = endpoint.ProxyUrl;
					endpointDescription.SecurityLevel = endpoint.SecurityLevel;
					endpointDescription.SecurityMode = endpoint.SecurityMode;
					endpointDescription.SecurityPolicyUri = endpoint.SecurityPolicyUri;
					endpointDescription.ServerCertificate = endpoint.ServerCertificate;
					endpointDescription.TransportProfileUri = endpoint.TransportProfileUri;
					endpointDescription.UserIdentityTokens = endpoint.UserIdentityTokens;
					endpointDescription.Server = application;
					endpointDescriptionCollection.Add(endpointDescription);
				}
			}
		}
		return endpointDescriptionCollection;
	}

	protected virtual void ValidateRequest(RequestHeader requestHeader)
	{
		if (requestHeader == null)
		{
			throw new ServiceResultException(2150236160u);
		}
		requestHeader.ReturnDiagnostics &= 1023u;
	}

	protected virtual ResponseHeader CreateResponse(RequestHeader requestHeader, uint statusCode)
	{
		if (StatusCode.IsBad(statusCode))
		{
			throw new ServiceResultException(statusCode);
		}
		return new ResponseHeader
		{
			Timestamp = DateTime.UtcNow,
			RequestHandle = requestHeader.RequestHandle
		};
	}

	protected virtual ResponseHeader CreateResponse(RequestHeader requestHeader, Exception exception)
	{
		ResponseHeader obj = new ResponseHeader
		{
			Timestamp = DateTime.UtcNow,
			RequestHandle = requestHeader.RequestHandle
		};
		StringTable stringTable = new StringTable();
		obj.ServiceDiagnostics = new DiagnosticInfo(exception, (DiagnosticsMasks)requestHeader.ReturnDiagnostics, serviceLevel: true, stringTable);
		obj.StringTable = stringTable.ToArray();
		return obj;
	}

	protected virtual ResponseHeader CreateResponse(RequestHeader requestHeader, StringTable stringTable)
	{
		ResponseHeader responseHeader = new ResponseHeader();
		responseHeader.Timestamp = DateTime.UtcNow;
		responseHeader.RequestHandle = requestHeader.RequestHandle;
		responseHeader.StringTable.AddRange(stringTable.ToArray());
		return responseHeader;
	}

	protected virtual void OnUpdateConfiguration(ApplicationConfiguration configuration)
	{
	}

	protected virtual void OnServerStarting(ApplicationConfiguration configuration)
	{
		Configuration = configuration;
		ServerProperties = LoadServerProperties();
		if (configuration.ServerConfiguration != null)
		{
			if (configuration.ServerConfiguration.SecurityPolicies.Count == 0)
			{
				configuration.ServerConfiguration.SecurityPolicies.Add(new ServerSecurityPolicy());
			}
			if (configuration.ServerConfiguration.UserTokenPolicies.Count == 0)
			{
				UserTokenPolicy userTokenPolicy = new UserTokenPolicy();
				userTokenPolicy.TokenType = UserTokenType.Anonymous;
				userTokenPolicy.PolicyId = userTokenPolicy.TokenType.ToString();
				configuration.ServerConfiguration.UserTokenPolicies.Add(userTokenPolicy);
			}
		}
		if (configuration.SecurityConfiguration.ApplicationCertificate != null)
		{
			InstanceCertificate = configuration.SecurityConfiguration.ApplicationCertificate.Find(needPrivateKey: true).GetAwaiter().GetResult();
		}
		if (InstanceCertificate == null)
		{
			throw new ServiceResultException(2156462080u, "Server does not have an instance certificate assigned.");
		}
		if (!InstanceCertificate.HasPrivateKey)
		{
			throw new ServiceResultException(2156462080u, "Server does not have access to the private key for the instance certificate.");
		}
		InstanceCertificateChain = new X509Certificate2Collection(InstanceCertificate);
		List<CertificateIdentifier> list = new List<CertificateIdentifier>();
		Dictionary<X509Certificate2, ServiceResultException> dictionary = new Dictionary<X509Certificate2, ServiceResultException>();
		configuration.CertificateValidator.GetIssuersNoExceptionsOnGetIssuer(InstanceCertificateChain, list, dictionary).Wait();
		if (dictionary.Count > 0)
		{
			Utils.LogWarning("Issuer validation errors ignored on startup:");
			foreach (KeyValuePair<X509Certificate2, ServiceResultException> item in dictionary)
			{
				if (item.Value != null)
				{
					Utils.LogCertificate(LogLevel.Warning, "- " + item.Value.Message, item.Key);
				}
			}
		}
		for (int i = 0; i < list.Count; i++)
		{
			InstanceCertificateChain.Add(list[i].Certificate);
		}
		ServiceMessageContext serviceMessageContext = configuration.CreateMessageContext(clonedFactory: true);
		serviceMessageContext.NamespaceUris = new NamespaceTable();
		MessageContext = serviceMessageContext;
		if (string.IsNullOrEmpty(configuration.ApplicationUri))
		{
			configuration.ApplicationUri = X509Utils.GetApplicationUriFromCertificate(InstanceCertificate);
			if (string.IsNullOrEmpty(configuration.ApplicationUri))
			{
				configuration.ApplicationUri = Utils.Format("http://{0}/{1}/{2}", Utils.GetHostName(), configuration.ApplicationName, Guid.NewGuid());
			}
		}
		MessageContext.NamespaceUris.Append(configuration.ApplicationUri);
		if (string.IsNullOrEmpty(configuration.ApplicationName) && InstanceCertificate != null)
		{
			configuration.ApplicationName = InstanceCertificate.GetNameInfo(X509NameType.DnsName, forIssuer: false);
		}
		CertificateValidator = configuration.CertificateValidator;
	}

	protected virtual IList<ServiceHost> InitializeServiceHosts(ApplicationConfiguration configuration, TransportListenerBindings bindingFactory, out ApplicationDescription serverDescription, out EndpointDescriptionCollection endpoints)
	{
		serverDescription = null;
		endpoints = null;
		return new List<ServiceHost>();
	}

	protected virtual void StartApplication(ApplicationConfiguration configuration)
	{
	}

	protected virtual void OnServerStopping()
	{
	}

	protected virtual ServerProperties LoadServerProperties()
	{
		return new ServerProperties();
	}

	protected virtual void ProcessRequest(IEndpointIncomingRequest request, object calldata)
	{
		request.CallSynchronously();
	}
}
