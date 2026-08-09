using System;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace Opc.Ua.Bindings;

[ComVisible(true)]
public class TcpMessageSocketAsyncEventArgs : IMessageSocketAsyncEventArgs, IDisposable
{
	private SocketAsyncEventArgs m_args;

	public object UserToken { get; set; }

	public bool IsSocketError => m_args.SocketError != SocketError.Success;

	public string SocketErrorString => m_args.SocketError.ToString();

	public int BytesTransferred => m_args.BytesTransferred;

	public byte[] Buffer => m_args.Buffer;

	public BufferCollection BufferList
	{
		get
		{
			return m_args.BufferList as BufferCollection;
		}
		set
		{
			m_args.BufferList = value;
		}
	}

	public SocketAsyncEventArgs Args => m_args;

	public event EventHandler<IMessageSocketAsyncEventArgs> Completed
	{
		add
		{
			m_InternalComplete += value;
			m_args.Completed += OnComplete;
		}
		remove
		{
			m_InternalComplete -= value;
			m_args.Completed -= OnComplete;
		}
	}

	private event EventHandler<IMessageSocketAsyncEventArgs> m_InternalComplete;

	public TcpMessageSocketAsyncEventArgs()
	{
		m_args = new SocketAsyncEventArgs
		{
			UserToken = this
		};
	}

	public void Dispose()
	{
		m_args.Dispose();
	}

	public void SetBuffer(byte[] buffer, int offset, int count)
	{
		m_args.SetBuffer(buffer, offset, count);
	}

	protected void OnComplete(object sender, SocketAsyncEventArgs e)
	{
		if (e.UserToken != null)
		{
			this.m_InternalComplete(this, e.UserToken as IMessageSocketAsyncEventArgs);
		}
	}
}
