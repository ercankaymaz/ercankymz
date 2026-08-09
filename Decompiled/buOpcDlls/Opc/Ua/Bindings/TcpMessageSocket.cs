using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace Opc.Ua.Bindings;

[ComVisible(true)]
public class TcpMessageSocket : IMessageSocket, IDisposable
{
	private delegate void CallbackAction(SocketError error);

	private enum ReadState
	{
		Ready = 0,
		ReadNextMessage = 1,
		ReadNextBlock = 2,
		Receive = 3,
		ReadComplete = 4,
		NotConnected = 5,
		Error = 255
	}

	private static readonly int s_defaultRetryNextAddressTimeout = 1000;

	private IMessageSink m_sink;

	private BufferManager m_bufferManager;

	private readonly int m_receiveBufferSize;

	private readonly EventHandler<SocketAsyncEventArgs> m_readComplete;

	private readonly object m_socketLock = new object();

	private Socket m_socket;

	private bool m_closed;

	private TaskCompletionSource<SocketError> m_tcs;

	private int m_socketResponses;

	private readonly object m_readLock = new object();

	private byte[] m_receiveBuffer;

	private int m_bytesReceived;

	private int m_bytesToReceive;

	private int m_incomingMessageSize;

	private ReadState m_readState;

	public int Handle
	{
		get
		{
			if (m_socket == null)
			{
				return -1;
			}
			return m_socket.GetHashCode();
		}
	}

	public EndPoint LocalEndpoint => m_socket.LocalEndPoint;

	public TransportChannelFeatures MessageSocketFeatures => TransportChannelFeatures.Reconnect | TransportChannelFeatures.ReverseConnect;

	public TcpMessageSocket(IMessageSink sink, BufferManager bufferManager, int receiveBufferSize)
	{
		if (bufferManager == null)
		{
			throw new ArgumentNullException("bufferManager");
		}
		m_sink = sink;
		m_socket = null;
		m_bufferManager = bufferManager;
		m_receiveBufferSize = receiveBufferSize;
		m_incomingMessageSize = -1;
		m_readComplete = OnReadComplete;
		m_readState = ReadState.Ready;
	}

	public TcpMessageSocket(IMessageSink sink, Socket socket, BufferManager bufferManager, int receiveBufferSize)
	{
		if (socket == null)
		{
			throw new ArgumentNullException("socket");
		}
		if (bufferManager == null)
		{
			throw new ArgumentNullException("bufferManager");
		}
		m_sink = sink;
		m_socket = socket;
		m_bufferManager = bufferManager;
		m_receiveBufferSize = receiveBufferSize;
		m_incomingMessageSize = -1;
		m_readComplete = OnReadComplete;
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (disposing)
		{
			m_socket.Dispose();
		}
	}

	public async Task<bool> BeginConnect(Uri endpointUrl, EventHandler<IMessageSocketAsyncEventArgs> callback, object state, CancellationToken cts)
	{
		if (endpointUrl == null)
		{
			throw new ArgumentNullException("endpointUrl");
		}
		if (m_socket != null)
		{
			throw new InvalidOperationException("The socket is already connected.");
		}
		CallbackAction doCallback = delegate(SocketError socketError)
		{
			callback(this, new TcpMessageSocketConnectAsyncEventArgs(socketError)
			{
				UserToken = state
			});
		};
		IPAddress[] source;
		SocketError error;
		try
		{
			source = await Dns.GetHostAddressesAsync(endpointUrl.DnsSafeHost).ConfigureAwait(continueOnCapturedContext: false);
		}
		catch (SocketException ex)
		{
			Utils.LogWarning("Name resolution failed for: {0} Error: {1}", endpointUrl.DnsSafeHost, ex.Message);
			error = ex.SocketErrorCode;
			goto IL_054d;
		}
		IPAddress[] addressesV4 = source.Where((IPAddress a) => a.AddressFamily == AddressFamily.InterNetwork).ToArray();
		IPAddress[] addressesV6 = source.Where((IPAddress a) => a.AddressFamily == AddressFamily.InterNetworkV6).ToArray();
		int port = endpointUrl.Port;
		if (port <= 0 || port > 65535)
		{
			port = 4840;
		}
		int arrayV4Index = 0;
		int arrayV6Index = 0;
		m_socketResponses = 0;
		m_tcs = new TaskCompletionSource<SocketError>();
		bool moreAddresses;
		do
		{
			error = SocketError.NotInitialized;
			lock (m_socketLock)
			{
				if (addressesV6.Length > arrayV6Index)
				{
					m_socketResponses++;
				}
				if (addressesV4.Length > arrayV4Index)
				{
					m_socketResponses++;
				}
				if (m_tcs.Task.IsCompleted)
				{
					m_tcs = new TaskCompletionSource<SocketError>();
				}
			}
			if (addressesV6.Length > arrayV6Index && m_socket == null)
			{
				if (BeginConnect(addressesV6[arrayV6Index], AddressFamily.InterNetworkV6, port, doCallback) == SocketError.Success)
				{
					return true;
				}
				arrayV6Index++;
			}
			if (addressesV4.Length > arrayV4Index && m_socket == null)
			{
				if (BeginConnect(addressesV4[arrayV4Index], AddressFamily.InterNetwork, port, doCallback) == SocketError.Success)
				{
					return true;
				}
				arrayV4Index++;
			}
			moreAddresses = addressesV6.Length > arrayV6Index || addressesV4.Length > arrayV4Index;
			if (moreAddresses && !m_tcs.Task.IsCompleted)
			{
				await Task.Delay(s_defaultRetryNextAddressTimeout, cts).ContinueWith(delegate(Task tsk)
				{
					if (tsk.IsCanceled)
					{
						moreAddresses = false;
					}
				}, cts).ConfigureAwait(continueOnCapturedContext: false);
			}
			if (!moreAddresses || m_tcs.Task.IsCompleted)
			{
				error = await m_tcs.Task.ConfigureAwait(continueOnCapturedContext: false);
				switch (error)
				{
				case SocketError.Success:
					return true;
				case SocketError.ConnectionRefused:
					continue;
				}
				break;
			}
		}
		while (moreAddresses);
		goto IL_054d;
		IL_054d:
		doCallback(error);
		return false;
	}

	public void Close()
	{
		lock (m_socketLock)
		{
			m_closed = true;
			if (m_socket == null)
			{
				return;
			}
			try
			{
				if (m_socket.Connected)
				{
					m_socket.Shutdown(SocketShutdown.Both);
				}
			}
			catch (Exception exception)
			{
				Utils.LogError(exception, "Unexpected error closing socket.");
			}
			finally
			{
				m_socket.Dispose();
				m_socket = null;
			}
		}
	}

	public void ReadNextMessage()
	{
		lock (m_readLock)
		{
			do
			{
				if (m_receiveBuffer == null)
				{
					m_receiveBuffer = m_bufferManager.TakeBuffer(m_receiveBufferSize, "ReadNextMessage");
				}
				m_bytesReceived = 0;
				m_bytesToReceive = 8;
				m_incomingMessageSize = -1;
				do
				{
					ReadNextBlock();
				}
				while (m_readState == ReadState.ReadNextBlock);
			}
			while (m_readState == ReadState.ReadNextMessage);
		}
	}

	public void ChangeSink(IMessageSink sink)
	{
		lock (m_readLock)
		{
			m_sink = sink;
		}
	}

	private void OnReadComplete(object sender, SocketAsyncEventArgs e)
	{
		lock (m_readLock)
		{
			ServiceResult serviceResult = null;
			try
			{
				bool num = m_readState == ReadState.ReadComplete;
				serviceResult = DoReadComplete(e);
				if (!num && !ServiceResult.IsBad(serviceResult))
				{
					while (ReadNext())
					{
					}
				}
			}
			catch (Exception ex)
			{
				Utils.LogError(ex, "Unexpected error during OnReadComplete,");
				serviceResult = ServiceResult.Create(ex, 2156003328u, ex.Message);
			}
			finally
			{
				e?.Dispose();
			}
			if (m_readState == ReadState.NotConnected && ServiceResult.IsGood(serviceResult))
			{
				serviceResult = ServiceResult.Create(2158886912u, "Remote side closed connection.");
			}
			if (ServiceResult.IsBad(serviceResult))
			{
				if (m_receiveBuffer != null)
				{
					m_bufferManager.ReturnBuffer(m_receiveBuffer, "OnReadComplete");
					m_receiveBuffer = null;
				}
				m_sink?.OnReceiveError(this, serviceResult);
			}
		}
	}

	private ServiceResult DoReadComplete(SocketAsyncEventArgs e)
	{
		int bytesTransferred = e.BytesTransferred;
		m_readState = ReadState.Ready;
		lock (m_socketLock)
		{
			BufferManager.UnlockBuffer(m_receiveBuffer);
		}
		if (bytesTransferred == 0)
		{
			if (m_receiveBuffer != null)
			{
				m_bufferManager.ReturnBuffer(m_receiveBuffer, "DoReadComplete");
				m_receiveBuffer = null;
			}
			m_readState = ReadState.Error;
			return ServiceResult.Create(2158886912u, "Remote side closed connection");
		}
		m_bytesReceived += bytesTransferred;
		if (m_bytesReceived < m_bytesToReceive)
		{
			m_readState = ReadState.ReadNextBlock;
			return ServiceResult.Good;
		}
		if (m_incomingMessageSize < 0)
		{
			m_incomingMessageSize = BitConverter.ToInt32(m_receiveBuffer, 4);
			if (m_incomingMessageSize <= 0 || m_incomingMessageSize > m_receiveBufferSize)
			{
				Utils.LogError("BadTcpMessageTooLarge: BufferSize={0}; MessageSize={1}", m_receiveBufferSize, m_incomingMessageSize);
				m_readState = ReadState.Error;
				return ServiceResult.Create(2155872256u, "Messages size {0} bytes is too large for buffer of size {1}.", m_incomingMessageSize, m_receiveBufferSize);
			}
			m_bytesToReceive = m_incomingMessageSize;
			m_readState = ReadState.ReadNextBlock;
			return ServiceResult.Good;
		}
		if (m_sink != null)
		{
			try
			{
				ArraySegment<byte> message = new ArraySegment<byte>(m_receiveBuffer, 0, m_incomingMessageSize);
				m_receiveBuffer = null;
				m_sink.OnMessageReceived(this, message);
			}
			catch (Exception exception)
			{
				Utils.LogError(exception, "Unexpected error invoking OnMessageReceived callback.");
			}
		}
		if (m_receiveBuffer != null)
		{
			m_bufferManager.ReturnBuffer(m_receiveBuffer, "DoReadComplete");
			m_receiveBuffer = null;
		}
		m_readState = ReadState.ReadNextMessage;
		return ServiceResult.Good;
	}

	private void ReadNextBlock()
	{
		Socket socket = null;
		lock (m_socketLock)
		{
			socket = m_socket;
			if (socket == null || !socket.Connected)
			{
				m_readState = ReadState.NotConnected;
				return;
			}
		}
		BufferManager.LockBuffer(m_receiveBuffer);
		SocketAsyncEventArgs e = new SocketAsyncEventArgs();
		try
		{
			m_readState = ReadState.Receive;
			e.SetBuffer(m_receiveBuffer, m_bytesReceived, m_bytesToReceive - m_bytesReceived);
			e.Completed += m_readComplete;
			if (!socket.ReceiveAsync(e))
			{
				if (e.SocketError != SocketError.Success)
				{
					throw ServiceResultException.Create(2156003328u, e.SocketError.ToString());
				}
				m_readState = ReadState.ReadComplete;
				m_readComplete(null, e);
			}
		}
		catch (ServiceResultException)
		{
			e?.Dispose();
			BufferManager.UnlockBuffer(m_receiveBuffer);
			throw;
		}
		catch (Exception e2)
		{
			e?.Dispose();
			BufferManager.UnlockBuffer(m_receiveBuffer);
			throw ServiceResultException.Create(2156003328u, e2, "BeginReceive failed.");
		}
	}

	private bool ReadNext()
	{
		bool result = true;
		switch (m_readState)
		{
		case ReadState.ReadNextBlock:
			ReadNextBlock();
			break;
		case ReadState.ReadNextMessage:
			ReadNextMessage();
			break;
		default:
			result = false;
			break;
		}
		return result;
	}

	private SocketError BeginConnect(IPAddress address, AddressFamily addressFamily, int port, CallbackAction callback)
	{
		Socket socket = new Socket(addressFamily, SocketType.Stream, ProtocolType.Tcp);
		SocketAsyncEventArgs e = new SocketAsyncEventArgs
		{
			UserToken = callback,
			RemoteEndPoint = new IPEndPoint(address, port)
		};
		e.Completed += OnSocketConnected;
		if (!socket.ConnectAsync(e))
		{
			OnSocketConnected(socket, e);
			return e.SocketError;
		}
		return SocketError.InProgress;
	}

	private void OnSocketConnected(object sender, SocketAsyncEventArgs args)
	{
		Socket socket = sender as Socket;
		bool flag = false;
		lock (m_socketLock)
		{
			m_socketResponses--;
			if (!m_closed && m_socket == null)
			{
				if (args.SocketError == SocketError.Success)
				{
					m_socket = socket;
					flag = true;
					m_tcs.SetResult(args.SocketError);
				}
				else if (m_socketResponses == 0)
				{
					m_tcs.SetResult(args.SocketError);
				}
			}
		}
		if (flag)
		{
			((CallbackAction)args.UserToken)(args.SocketError);
		}
		else
		{
			try
			{
				if (socket.Connected)
				{
					socket.Shutdown(SocketShutdown.Both);
				}
			}
			catch
			{
			}
			finally
			{
				socket.Dispose();
			}
		}
		args.Dispose();
	}

	public bool SendAsync(IMessageSocketAsyncEventArgs args)
	{
		if (!(args is TcpMessageSocketAsyncEventArgs e))
		{
			throw new ArgumentNullException("args");
		}
		if (m_socket == null)
		{
			throw new InvalidOperationException("The socket is not connected.");
		}
		e.Args.SocketError = SocketError.NotConnected;
		return m_socket.SendAsync(e.Args);
	}

	public IMessageSocketAsyncEventArgs MessageSocketEventArgs()
	{
		return new TcpMessageSocketAsyncEventArgs();
	}
}
