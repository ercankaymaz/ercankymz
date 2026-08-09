using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace Opc.Ua.Client;

[ComVisible(true)]
public class ReverseConnectManager : IDisposable
{
	private enum ReverseConnectManagerState
	{
		New,
		Stopped,
		Started,
		Errored
	}

	private enum ReverseConnectHostState
	{
		New,
		Closed,
		Open,
		Errored
	}

	[Flags]
	public enum ReverseConnectStrategy
	{
		Undefined = 0,
		Once = 1,
		Always = 2,
		Any = 0x80,
		AnyOnce = 0x81,
		AnyAlways = 0x82
	}

	private class ReverseConnectInfo
	{
		public ReverseConnectHost ReverseConnectHost;

		public ReverseConnectHostState State;

		public bool ConfigEntry;

		public ReverseConnectInfo(ReverseConnectHost reverseConnectHost, bool configEntry)
		{
			ReverseConnectHost = reverseConnectHost;
			State = ReverseConnectHostState.New;
			ConfigEntry = configEntry;
		}
	}

	private class Registration
	{
		public readonly string ServerUri;

		public readonly Uri EndpointUrl;

		public readonly EventHandler<ConnectionWaitingEventArgs> OnConnectionWaiting;

		public ReverseConnectStrategy ReverseConnectStrategy;

		public Registration(string serverUri, Uri endpointUrl, EventHandler<ConnectionWaitingEventArgs> onConnectionWaiting)
			: this(endpointUrl, onConnectionWaiting)
		{
			ServerUri = Utils.ReplaceLocalhost(serverUri);
		}

		public Registration(X509Certificate2 serverCertificate, Uri endpointUrl, EventHandler<ConnectionWaitingEventArgs> onConnectionWaiting)
			: this(endpointUrl, onConnectionWaiting)
		{
			ServerUri = X509Utils.GetApplicationUriFromCertificate(serverCertificate);
		}

		private Registration(Uri endpointUrl, EventHandler<ConnectionWaitingEventArgs> onConnectionWaiting)
		{
			EndpointUrl = new Uri(Utils.ReplaceLocalhost(endpointUrl.ToString()));
			OnConnectionWaiting = onConnectionWaiting;
			ReverseConnectStrategy = ReverseConnectStrategy.Once;
		}
	}

	public const int DefaultWaitTimeout = 20000;

	private readonly object m_lock = new object();

	private ConfigurationWatcher m_configurationWatcher;

	private ApplicationType m_applicationType;

	private Type m_configType;

	private ReverseConnectClientConfiguration m_configuration;

	private Dictionary<Uri, ReverseConnectInfo> m_endpointUrls;

	private ReverseConnectManagerState m_state;

	private List<Registration> m_registrations;

	private readonly object m_registrationsLock = new object();

	private CancellationTokenSource m_cts;

	public ReverseConnectManager()
	{
		m_state = ReverseConnectManagerState.New;
		m_registrations = new List<Registration>();
		m_endpointUrls = new Dictionary<Uri, ReverseConnectInfo>();
		m_cts = new CancellationTokenSource();
	}

	public void Dispose()
	{
		Dispose(disposing: true);
	}

	public virtual void Dispose(bool disposing)
	{
		if (m_configurationWatcher != null)
		{
			Utils.SilentDispose(m_configurationWatcher);
			m_configurationWatcher = null;
		}
		if (m_cts != null)
		{
			Utils.SilentDispose(m_cts);
			m_cts = null;
		}
		DisposeHosts();
	}

	protected virtual async void OnConfigurationChanged(object sender, ConfigurationWatcherEventArgs args)
	{
		try
		{
			OnUpdateConfiguration(await ApplicationConfiguration.Load(new FileInfo(args.FilePath), m_applicationType, m_configType).ConfigureAwait(continueOnCapturedContext: false));
		}
		catch (Exception exception)
		{
			Utils.LogError(exception, "Could not load updated configuration file from: {0}", args);
		}
	}

	protected virtual void OnUpdateConfiguration(ApplicationConfiguration configuration)
	{
		m_applicationType = configuration.ApplicationType;
		m_configType = configuration.GetType();
		OnUpdateConfiguration(configuration.ClientConfiguration.ReverseConnect);
	}

	protected virtual void OnUpdateConfiguration(ReverseConnectClientConfiguration configuration)
	{
		bool flag = false;
		lock (m_lock)
		{
			if (m_configuration != null)
			{
				StopService();
				m_configuration = null;
				flag = true;
			}
			m_configuration = configuration ?? new ReverseConnectClientConfiguration();
			ClearEndpoints(configEntry: true);
			if (configuration?.ClientEndpoints != null)
			{
				foreach (ReverseConnectClientEndpoint clientEndpoint in configuration.ClientEndpoints)
				{
					Uri uri = Utils.ParseUri(clientEndpoint.EndpointUrl);
					if (uri != null)
					{
						AddEndpointInternal(uri, configEntry: true);
					}
				}
			}
			if (flag)
			{
				StartService();
			}
		}
	}

	private void OpenHosts()
	{
		lock (m_lock)
		{
			foreach (KeyValuePair<Uri, ReverseConnectInfo> endpointUrl in m_endpointUrls)
			{
				ReverseConnectInfo value = endpointUrl.Value;
				try
				{
					if (endpointUrl.Value.State < ReverseConnectHostState.Open)
					{
						value.ReverseConnectHost.Open();
						value.State = ReverseConnectHostState.Open;
					}
				}
				catch (Exception exception)
				{
					Utils.LogError(exception, "Failed to Open {0}.", endpointUrl.Key);
					value.State = ReverseConnectHostState.Errored;
				}
			}
		}
	}

	private void CloseHosts()
	{
		lock (m_lock)
		{
			foreach (KeyValuePair<Uri, ReverseConnectInfo> endpointUrl in m_endpointUrls)
			{
				ReverseConnectInfo value = endpointUrl.Value;
				try
				{
					if (value.State == ReverseConnectHostState.Open)
					{
						value.ReverseConnectHost.Close();
						value.State = ReverseConnectHostState.Closed;
					}
				}
				catch (Exception exception)
				{
					Utils.LogError(exception, "Failed to Close {0}.", endpointUrl.Key);
					value.State = ReverseConnectHostState.Errored;
				}
			}
		}
	}

	private void DisposeHosts()
	{
		lock (m_lock)
		{
			CloseHosts();
			m_endpointUrls = null;
		}
	}

	public void AddEndpoint(Uri endpointUrl)
	{
		if (endpointUrl == null)
		{
			throw new ArgumentNullException("endpointUrl");
		}
		lock (m_lock)
		{
			if (m_state == ReverseConnectManagerState.Started)
			{
				throw new ServiceResultException(2158952448u);
			}
			AddEndpointInternal(endpointUrl, configEntry: false);
		}
	}

	public void StartService(ApplicationConfiguration configuration)
	{
		if (configuration == null)
		{
			throw new ArgumentNullException("configuration");
		}
		lock (m_lock)
		{
			if (m_state == ReverseConnectManagerState.Started)
			{
				throw new ServiceResultException(2158952448u);
			}
			try
			{
				OnUpdateConfiguration(configuration);
				StartService();
				if (!string.IsNullOrEmpty(configuration.SourceFilePath))
				{
					m_configurationWatcher = new ConfigurationWatcher(configuration);
					m_configurationWatcher.Changed += OnConfigurationChanged;
				}
			}
			catch (Exception ex)
			{
				Utils.LogError(ex, "Unexpected error starting reverse connect manager.");
				m_state = ReverseConnectManagerState.Errored;
				throw new ServiceResultException(ServiceResult.Create(ex, 2147614720u, "Unexpected error starting application"));
			}
		}
	}

	public void StartService(ReverseConnectClientConfiguration configuration)
	{
		if (configuration == null)
		{
			throw new ArgumentNullException("configuration");
		}
		lock (m_lock)
		{
			if (m_state == ReverseConnectManagerState.Started)
			{
				throw new ServiceResultException(2158952448u);
			}
			try
			{
				m_configurationWatcher = null;
				OnUpdateConfiguration(configuration);
				OpenHosts();
				m_state = ReverseConnectManagerState.Started;
			}
			catch (Exception ex)
			{
				Utils.LogError(ex, "Unexpected error starting reverse connect manager.");
				m_state = ReverseConnectManagerState.Errored;
				throw new ServiceResultException(ServiceResult.Create(ex, 2147614720u, "Unexpected error starting reverse connect manager"));
			}
		}
	}

	public void ClearWaitingConnections()
	{
		lock (m_registrationsLock)
		{
			m_registrations.Clear();
			CancelAndRenewTokenSource();
		}
	}

	public async Task<ITransportWaitingConnection> WaitForConnection(Uri endpointUrl, string serverUri, CancellationToken ct = default(CancellationToken))
	{
		TaskCompletionSource<ITransportWaitingConnection> tcs = new TaskCompletionSource<ITransportWaitingConnection>();
		int hashCode = RegisterWaitingConnection(endpointUrl, serverUri, delegate(object sender, ConnectionWaitingEventArgs e)
		{
			tcs.TrySetResult(e);
		}, ReverseConnectStrategy.Once);
		Func<Task> func = async delegate
		{
			if (!(ct == default(CancellationToken)))
			{
				await Task.Delay(-1, ct).ContinueWith(delegate
				{
				}).ConfigureAwait(continueOnCapturedContext: false);
			}
			else
			{
				await Task.Delay((m_configuration.WaitTimeout > 0) ? m_configuration.WaitTimeout : 20000).ConfigureAwait(continueOnCapturedContext: false);
			}
			tcs.TrySetCanceled();
		};
		await Task.WhenAny(tcs.Task, func()).ConfigureAwait(continueOnCapturedContext: false);
		if (!tcs.Task.IsCompleted || tcs.Task.IsCanceled)
		{
			UnregisterWaitingConnection(hashCode);
			throw new ServiceResultException(2148139008u, "Waiting for the reverse connection timed out.");
		}
		return await tcs.Task.ConfigureAwait(continueOnCapturedContext: false);
	}

	public int RegisterWaitingConnection(Uri endpointUrl, string serverUri, EventHandler<ConnectionWaitingEventArgs> onConnectionWaiting, ReverseConnectStrategy reverseConnectStrategy)
	{
		if (endpointUrl == null)
		{
			throw new ArgumentNullException("endpointUrl");
		}
		Registration registration = new Registration(serverUri, endpointUrl, onConnectionWaiting)
		{
			ReverseConnectStrategy = reverseConnectStrategy
		};
		lock (m_registrationsLock)
		{
			m_registrations.Add(registration);
			CancelAndRenewTokenSource();
		}
		return registration.GetHashCode();
	}

	public void UnregisterWaitingConnection(int hashCode)
	{
		lock (m_registrationsLock)
		{
			Registration registration = null;
			foreach (Registration registration2 in m_registrations)
			{
				if (registration2.GetHashCode() == hashCode)
				{
					registration = registration2;
					break;
				}
			}
			if (registration != null)
			{
				m_registrations.Remove(registration);
				CancelAndRenewTokenSource();
			}
		}
	}

	private void StopService()
	{
		ClearWaitingConnections();
		lock (m_lock)
		{
			CloseHosts();
			m_state = ReverseConnectManagerState.Stopped;
		}
	}

	private void StartService()
	{
		lock (m_lock)
		{
			OpenHosts();
			m_state = ReverseConnectManagerState.Started;
		}
	}

	private void ClearEndpoints(bool configEntry)
	{
		Dictionary<Uri, ReverseConnectInfo> dictionary = new Dictionary<Uri, ReverseConnectInfo>();
		foreach (KeyValuePair<Uri, ReverseConnectInfo> endpointUrl in m_endpointUrls)
		{
			if (endpointUrl.Value.ConfigEntry != configEntry)
			{
				dictionary[endpointUrl.Key] = endpointUrl.Value;
			}
		}
		m_endpointUrls = dictionary;
	}

	private void AddEndpointInternal(Uri endpointUrl, bool configEntry)
	{
		ReverseConnectHost reverseConnectHost = new ReverseConnectHost();
		ReverseConnectInfo reverseConnectInfo = new ReverseConnectInfo(reverseConnectHost, configEntry);
		try
		{
			m_endpointUrls[endpointUrl] = reverseConnectInfo;
			reverseConnectHost.CreateListener(endpointUrl, OnConnectionWaiting, OnConnectionStatusChanged);
		}
		catch (ArgumentException exception)
		{
			Utils.LogError(exception, "No listener was found for endpoint {0}.", endpointUrl);
			reverseConnectInfo.State = ReverseConnectHostState.Errored;
		}
	}

	private async Task OnConnectionWaiting(object sender, ConnectionWaitingEventArgs e)
	{
		DateTime startTime = DateTime.UtcNow;
		DateTime dateTime = startTime + TimeSpan.FromMilliseconds(m_configuration.HoldTime);
		bool matched = MatchRegistration(sender, e);
		if (!matched)
		{
			Utils.LogInfo("Holding reverse connection: {0} {1}", e.ServerUri, e.EndpointUrl);
			CancellationToken token;
			lock (m_registrationsLock)
			{
				token = m_cts.Token;
			}
			TimeSpan delay = dateTime - DateTime.UtcNow;
			if (delay.TotalMilliseconds > 0.0)
			{
				await Task.Delay(delay, token).ContinueWith(delegate(Task tsk)
				{
					if (tsk.IsCanceled)
					{
						matched = MatchRegistration(sender, e);
						if (matched)
						{
							Utils.LogInfo("Matched reverse connection {0} {1} after {2}ms", e.ServerUri, e.EndpointUrl, (int)(DateTime.UtcNow - startTime).TotalMilliseconds);
						}
					}
				}).ConfigureAwait(continueOnCapturedContext: false);
			}
		}
		Utils.LogInfo("{0} reverse connection: {1} {2} after {3}ms", e.Accepted ? "Accepted" : "Rejected", e.ServerUri, e.EndpointUrl, (int)DateTime.UtcNow.Subtract(startTime).TotalMilliseconds);
	}

	private bool MatchRegistration(object sender, ConnectionWaitingEventArgs e)
	{
		Registration registration = null;
		bool result = false;
		lock (m_registrationsLock)
		{
			foreach (Registration item in m_registrations.Where((Registration r) => (r.ReverseConnectStrategy & ReverseConnectStrategy.Any) == 0))
			{
				if (item.EndpointUrl.Scheme.Equals(e.EndpointUrl.Scheme, StringComparison.InvariantCulture) && (item.ServerUri == e.ServerUri || item.EndpointUrl.Authority.Equals(e.EndpointUrl.Authority, StringComparison.InvariantCulture)))
				{
					registration = item;
					e.Accepted = true;
					result = true;
					Utils.LogInfo("Accepted reverse connection: {0} {1}", e.ServerUri, e.EndpointUrl);
					break;
				}
			}
			if (registration == null)
			{
				foreach (Registration item2 in m_registrations.Where((Registration r) => (r.ReverseConnectStrategy & ReverseConnectStrategy.Any) != 0))
				{
					if (item2.EndpointUrl.Scheme.Equals(e.EndpointUrl.Scheme, StringComparison.InvariantCulture))
					{
						registration = item2;
						e.Accepted = true;
						result = true;
						Utils.LogInfo("Accept any reverse connection for approval: {0} {1}", e.ServerUri, e.EndpointUrl);
						break;
					}
				}
			}
			if (registration != null && (registration.ReverseConnectStrategy & ReverseConnectStrategy.Once) != ReverseConnectStrategy.Undefined)
			{
				m_registrations.Remove(registration);
			}
		}
		registration?.OnConnectionWaiting?.Invoke(sender, e);
		return result;
	}

	private void OnConnectionStatusChanged(object sender, ConnectionStatusEventArgs e)
	{
		Utils.LogInfo("Channel status: {0} {1} {2}", e.EndpointUrl, e.ChannelStatus, e.Closed);
	}

	private void CancelAndRenewTokenSource()
	{
		CancellationTokenSource cts = m_cts;
		m_cts = new CancellationTokenSource();
		cts.Cancel();
		cts.Dispose();
	}
}
