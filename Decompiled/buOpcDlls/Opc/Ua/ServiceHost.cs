using System;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public class ServiceHost : IServiceHostBase, IDisposable
{
	private ServerBase m_server;

	private Type m_endpointType;

	private Uri[] m_addresses;

	public IServerBase Server => m_server;

	public ServiceHostState State { get; private set; }

	public ServiceHost(ServerBase server, Type endpointType, params Uri[] addresses)
	{
		m_server = server;
		m_endpointType = endpointType;
		m_addresses = addresses;
	}

	public void Dispose()
	{
		Dispose(disposing: true);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (disposing && State == ServiceHostState.Opened)
		{
			Close();
		}
	}

	public virtual void Open()
	{
		State = ServiceHostState.Opened;
	}

	public virtual void Abort()
	{
	}

	public virtual void Close()
	{
		State = ServiceHostState.Closed;
	}
}
