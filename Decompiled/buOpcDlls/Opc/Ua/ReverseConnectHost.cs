using System;
using System.Runtime.InteropServices;
using Opc.Ua.Bindings;

namespace Opc.Ua;

[ComVisible(true)]
public class ReverseConnectHost
{
	private ITransportListener m_listener;

	private ConnectionWaitingHandlerAsync m_onConnectionWaiting;

	private EventHandler<ConnectionStatusEventArgs> m_onConnectionStatusChanged;

	public Uri Url { get; private set; }

	public void CreateListener(Uri url, ConnectionWaitingHandlerAsync OnConnectionWaiting, EventHandler<ConnectionStatusEventArgs> OnConnectionStatusChanged)
	{
		if (url == null)
		{
			throw new ArgumentNullException("url");
		}
		ITransportListener listener = TransportBindings.Listeners.GetListener(url.Scheme);
		if (listener == null)
		{
			throw ServiceResultException.Create(2159935488u, "Unsupported transport profile for scheme {0}.", url.Scheme);
		}
		m_listener = listener;
		Url = url;
		m_onConnectionWaiting = OnConnectionWaiting;
		m_onConnectionStatusChanged = OnConnectionStatusChanged;
	}

	public void Open()
	{
		try
		{
			TransportListenerSettings settings = new TransportListenerSettings
			{
				Descriptions = null,
				Configuration = null,
				CertificateValidator = null,
				NamespaceUris = null,
				Factory = null,
				ServerCertificate = null,
				ServerCertificateChain = null,
				ReverseConnectListener = true
			};
			Utils.LogInfo("Open reverse connect listener for {0}.", Url);
			m_listener.Open(Url, settings, null);
			m_listener.ConnectionWaiting += m_onConnectionWaiting;
			m_listener.ConnectionStatusChanged += m_onConnectionStatusChanged;
		}
		catch (Exception exception)
		{
			Utils.LogError(exception, "Could not open listener for {0}.", Url);
			throw;
		}
	}

	public void Close()
	{
		m_listener.ConnectionWaiting -= m_onConnectionWaiting;
		m_listener.ConnectionStatusChanged -= m_onConnectionStatusChanged;
		m_listener.Close();
	}
}
