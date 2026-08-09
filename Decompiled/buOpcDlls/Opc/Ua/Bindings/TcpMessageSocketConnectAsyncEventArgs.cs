using System;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace Opc.Ua.Bindings;

[ComVisible(true)]
public class TcpMessageSocketConnectAsyncEventArgs : IMessageSocketAsyncEventArgs, IDisposable
{
	private SocketError m_socketError;

	public object UserToken { get; set; }

	public bool IsSocketError => m_socketError != SocketError.Success;

	public string SocketErrorString => m_socketError.ToString();

	public int BytesTransferred => 0;

	public byte[] Buffer => null;

	public BufferCollection BufferList
	{
		get
		{
			return null;
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	public event EventHandler<IMessageSocketAsyncEventArgs> Completed
	{
		add
		{
			throw new NotImplementedException();
		}
		remove
		{
			throw new NotImplementedException();
		}
	}

	public TcpMessageSocketConnectAsyncEventArgs(SocketError error)
	{
		m_socketError = error;
	}

	public void Dispose()
	{
	}

	public void SetBuffer(byte[] buffer, int offset, int count)
	{
		throw new NotImplementedException();
	}
}
