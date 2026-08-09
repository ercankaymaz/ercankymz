using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace Opc.Ua.Client;

[ComVisible(true)]
public class SessionReconnectHandler : IDisposable
{
	public enum ReconnectState
	{
		Ready = 0,
		Triggered = 1,
		Reconnecting = 2,
		Disposed = 4
	}

	public const int MinReconnectPeriod = 500;

	public const int MaxReconnectPeriod = 30000;

	public const int DefaultReconnectPeriod = 1000;

	public const int MinReconnectOperationTimeout = 5000;

	private readonly object m_lock = new object();

	private ISession m_session;

	private ReconnectState m_state;

	private Random m_random;

	private bool m_reconnectFailed;

	private bool m_reconnectAbort;

	private bool m_cancelReconnect;

	private bool m_updateFromServer;

	private int m_reconnectPeriod;

	private int m_baseReconnectPeriod;

	private int m_maxReconnectPeriod;

	private Timer m_reconnectTimer;

	private EventHandler m_callback;

	private ReverseConnectManager m_reverseConnectManager;

	public ISession Session => m_session;

	public ReconnectState State
	{
		get
		{
			lock (m_lock)
			{
				if (m_reconnectTimer == null)
				{
					return ReconnectState.Disposed;
				}
				return m_state;
			}
		}
	}

	public SessionReconnectHandler(bool reconnectAbort = false, int maxReconnectPeriod = -1)
	{
		m_reconnectAbort = reconnectAbort;
		m_reconnectTimer = new Timer(OnReconnectAsync, this, -1, -1);
		m_state = ReconnectState.Ready;
		m_cancelReconnect = false;
		m_updateFromServer = false;
		m_baseReconnectPeriod = 1000;
		m_maxReconnectPeriod = ((maxReconnectPeriod < 0) ? (-1) : Math.Max(500, Math.Min(maxReconnectPeriod, 30000)));
		m_random = new Random();
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
		lock (m_lock)
		{
			if (m_reconnectTimer != null)
			{
				m_reconnectTimer.Dispose();
				m_reconnectTimer = null;
			}
			m_state = ReconnectState.Disposed;
		}
	}

	public void CancelReconnect()
	{
		lock (m_lock)
		{
			if (m_reconnectTimer != null)
			{
				if (m_state == ReconnectState.Triggered)
				{
					m_session = null;
					EnterReadyState();
				}
				else
				{
					m_cancelReconnect = true;
				}
			}
		}
	}

	public ReconnectState BeginReconnect(ISession session, int reconnectPeriod, EventHandler callback)
	{
		return BeginReconnect(session, null, reconnectPeriod, callback);
	}

	public ReconnectState BeginReconnect(ISession session, ReverseConnectManager reverseConnectManager, int reconnectPeriod, EventHandler callback)
	{
		lock (m_lock)
		{
			if (m_reconnectTimer == null)
			{
				throw new ServiceResultException(2158952448u);
			}
			if (session == null)
			{
				if (m_state == ReconnectState.Triggered)
				{
					m_session = null;
					EnterReadyState();
					return m_state;
				}
				m_cancelReconnect = true;
				return m_state;
			}
			reconnectPeriod = CheckedReconnectPeriod(reconnectPeriod);
			if (m_state == ReconnectState.Ready)
			{
				m_session = session;
				m_baseReconnectPeriod = reconnectPeriod;
				m_reconnectFailed = false;
				m_cancelReconnect = false;
				m_callback = callback;
				m_reverseConnectManager = reverseConnectManager;
				m_reconnectTimer.Change(JitteredReconnectPeriod(reconnectPeriod), -1);
				m_reconnectPeriod = CheckedReconnectPeriod(reconnectPeriod, exponentialBackoff: true);
				m_state = ReconnectState.Triggered;
				return m_state;
			}
			if (m_state == ReconnectState.Triggered && reconnectPeriod < m_baseReconnectPeriod)
			{
				m_baseReconnectPeriod = reconnectPeriod;
				m_reconnectTimer.Change(JitteredReconnectPeriod(reconnectPeriod), -1);
				m_reconnectPeriod = CheckedReconnectPeriod(reconnectPeriod, exponentialBackoff: true);
			}
			return m_state;
		}
	}

	public virtual int JitteredReconnectPeriod(int reconnectPeriod)
	{
		int num = reconnectPeriod * m_random.Next(-1000, 1000) / 10000;
		return reconnectPeriod + num;
	}

	public virtual int CheckedReconnectPeriod(int reconnectPeriod, bool exponentialBackoff = false)
	{
		if (m_maxReconnectPeriod > 500)
		{
			if (exponentialBackoff)
			{
				reconnectPeriod *= 2;
			}
			return Math.Min(Math.Max(reconnectPeriod, 500), m_maxReconnectPeriod);
		}
		return Math.Max(reconnectPeriod, 500);
	}

	private async void OnReconnectAsync(object state)
	{
		DateTime reconnectStart = DateTime.UtcNow;
		try
		{
			lock (m_lock)
			{
				if (m_reconnectTimer == null || m_session == null || m_state != ReconnectState.Triggered)
				{
					return;
				}
				m_state = ReconnectState.Reconnecting;
			}
			bool flag = false;
			if (m_session != null && m_reconnectAbort && m_session.Connected && !m_session.KeepAliveStopped)
			{
				flag = true;
				m_session = null;
				Utils.LogInfo("Reconnect aborted, KeepAlive recovered.");
			}
			bool flag2 = flag;
			if (!flag2)
			{
				flag2 = await DoReconnectAsync().ConfigureAwait(continueOnCapturedContext: false);
			}
			if (flag2)
			{
				lock (m_lock)
				{
					EnterReadyState();
				}
				m_callback(this, null);
				return;
			}
		}
		catch (Exception exception)
		{
			Utils.LogError(exception, "Unexpected error during reconnect.");
		}
		lock (m_lock)
		{
			if (m_state != ReconnectState.Disposed)
			{
				if (m_cancelReconnect)
				{
					EnterReadyState();
					return;
				}
				int num = (int)DateTime.UtcNow.Subtract(reconnectStart).TotalMilliseconds;
				Utils.LogInfo("Reconnect period is {0} ms, {1} ms elapsed in reconnect.", m_reconnectPeriod, num);
				int reconnectPeriod = CheckedReconnectPeriod(m_reconnectPeriod - num);
				reconnectPeriod = JitteredReconnectPeriod(reconnectPeriod);
				m_reconnectTimer.Change(reconnectPeriod, -1);
				Utils.LogInfo("Next adjusted reconnect scheduled in {0} ms.", reconnectPeriod);
				m_reconnectPeriod = CheckedReconnectPeriod(m_reconnectPeriod, exponentialBackoff: true);
				m_state = ReconnectState.Triggered;
			}
		}
	}

	private async Task<bool> DoReconnectAsync()
	{
		int operationTimeout = m_session.OperationTimeout;
		int reconnectOperationTimeout = Math.Max(m_reconnectPeriod, 5000);
		if (!m_reconnectFailed)
		{
			try
			{
				m_session.OperationTimeout = reconnectOperationTimeout;
				if (m_reverseConnectManager == null)
				{
					await m_session.ReconnectAsync().ConfigureAwait(continueOnCapturedContext: false);
				}
				else
				{
					ITransportWaitingConnection connection = await m_reverseConnectManager.WaitForConnection(new Uri(m_session.Endpoint.EndpointUrl), m_session.Endpoint.Server.ApplicationUri).ConfigureAwait(continueOnCapturedContext: false);
					await m_session.ReconnectAsync(connection).ConfigureAwait(continueOnCapturedContext: false);
				}
				return true;
			}
			catch (Exception ex)
			{
				if (ex is ServiceResultException ex2)
				{
					Utils.LogWarning("Reconnect failed. Reason={0}.", ex2.Result);
					if (ex2.StatusCode == 2156003328u || ex2.StatusCode == 2147811328u || ex2.StatusCode == 2156527616u || ex2.StatusCode == 2156199936u || ex2.StatusCode == 2148139008u)
					{
						TimeSpan timeSpan = m_session.LastKeepAliveTime.AddMilliseconds(m_session.SessionTimeout) - DateTime.UtcNow;
						if (timeSpan.TotalMilliseconds > 0.0)
						{
							Utils.LogInfo("Retry to reactivate, est. session timeout in {0} ms.", timeSpan.TotalMilliseconds);
							return false;
						}
					}
					if (ex2.StatusCode == 2148728832u || ex2.StatusCode == 2148663296u)
					{
						m_updateFromServer = true;
						Utils.LogInfo("Reconnect failed due to security check. Request endpoint update from server. {0}", ex2.Message);
					}
					else if (ex2.StatusCode != 2149908480u)
					{
						m_reconnectFailed = true;
						return false;
					}
				}
				else
				{
					Utils.LogError(ex, "Reconnect failed.");
				}
				m_reconnectFailed = true;
			}
			finally
			{
				m_session.OperationTimeout = operationTimeout;
			}
		}
		try
		{
			m_session.OperationTimeout = reconnectOperationTimeout;
			ISession session;
			if (m_reverseConnectManager != null)
			{
				ITransportWaitingConnection transportWaitingConnection;
				do
				{
					transportWaitingConnection = await m_reverseConnectManager.WaitForConnection(new Uri(m_session.Endpoint.EndpointUrl), m_session.Endpoint.Server.ApplicationUri).ConfigureAwait(continueOnCapturedContext: false);
					if (m_updateFromServer)
					{
						ConfiguredEndpoint configuredEndpoint = m_session.ConfiguredEndpoint;
						await configuredEndpoint.UpdateFromServerAsync(configuredEndpoint.EndpointUrl, transportWaitingConnection, configuredEndpoint.Description.SecurityMode, configuredEndpoint.Description.SecurityPolicyUri).ConfigureAwait(continueOnCapturedContext: false);
						m_updateFromServer = false;
						transportWaitingConnection = null;
					}
				}
				while (transportWaitingConnection == null);
				session = await m_session.SessionFactory.RecreateAsync(m_session, transportWaitingConnection).ConfigureAwait(continueOnCapturedContext: false);
			}
			else
			{
				if (m_updateFromServer)
				{
					ConfiguredEndpoint configuredEndpoint2 = m_session.ConfiguredEndpoint;
					await configuredEndpoint2.UpdateFromServerAsync(configuredEndpoint2.EndpointUrl, configuredEndpoint2.Description.SecurityMode, configuredEndpoint2.Description.SecurityPolicyUri).ConfigureAwait(continueOnCapturedContext: false);
					m_updateFromServer = false;
				}
				session = await m_session.SessionFactory.RecreateAsync(m_session).ConfigureAwait(continueOnCapturedContext: false);
			}
			m_session = session;
			return true;
		}
		catch (ServiceResultException ex3)
		{
			if (ex3.InnerResult?.StatusCode == (StatusCode?)(StatusCode)2148728832u || ex3.InnerResult?.StatusCode == (StatusCode?)(StatusCode)2148663296u)
			{
				m_updateFromServer = true;
				if (m_maxReconnectPeriod > 500 && m_reconnectPeriod >= m_maxReconnectPeriod)
				{
					m_reconnectPeriod = m_baseReconnectPeriod;
				}
				Utils.LogError("Could not reconnect due to failed security check. Request endpoint update from server. {0}", ex3.Message);
			}
			else
			{
				Utils.LogError("Could not reconnect the Session. {0}", ex3.Message);
			}
			return false;
		}
		catch (Exception ex4)
		{
			Utils.LogError("Could not reconnect the Session. {0}", ex4.Message);
			return false;
		}
		finally
		{
			m_session.OperationTimeout = operationTimeout;
		}
	}

	private void EnterReadyState()
	{
		m_reconnectTimer.Change(-1, -1);
		m_state = ReconnectState.Ready;
		m_cancelReconnect = false;
		m_updateFromServer = false;
	}
}
