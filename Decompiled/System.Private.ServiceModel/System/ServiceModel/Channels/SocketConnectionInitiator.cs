using System.Net;
using System.Net.Sockets;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal class SocketConnectionInitiator : IConnectionInitiator
{
	private int _bufferSize;

	private ConnectionBufferPool _connectionBufferPool;

	public SocketConnectionInitiator(int bufferSize)
	{
		_bufferSize = bufferSize;
		_connectionBufferPool = new ConnectionBufferPool(bufferSize);
	}

	private IConnection CreateConnection(IPAddress address, int port)
	{
		Socket socket = null;
		try
		{
			AddressFamily addressFamily = address.AddressFamily;
			socket = new Socket(addressFamily, SocketType.Stream, ProtocolType.Tcp);
			socket.Connect(new IPEndPoint(address, port));
			return new SocketConnection(socket, _connectionBufferPool, autoBindToCompletionPort: false);
		}
		catch
		{
			socket.Dispose();
			throw;
		}
	}

	private async Task<IConnection> CreateConnectionAsync(IPAddress address, int port)
	{
		Socket socket = null;
		try
		{
			AddressFamily addressFamily = address.AddressFamily;
			socket = new Socket(addressFamily, SocketType.Stream, ProtocolType.Tcp);
			await SocketTaskExtensions.ConnectAsync(socket, new IPEndPoint(address, port));
			return new SocketConnection(socket, _connectionBufferPool, autoBindToCompletionPort: false);
		}
		catch
		{
			socket.Dispose();
			throw;
		}
	}

	public static Exception ConvertConnectException(SocketException socketException, Uri remoteUri, TimeSpan timeSpent, Exception innerException)
	{
		if (socketException.SocketErrorCode == (SocketError)6)
		{
			return new CommunicationObjectAbortedException(socketException.Message, socketException);
		}
		if (socketException.SocketErrorCode == SocketError.AddressNotAvailable || socketException.SocketErrorCode == SocketError.ConnectionRefused || socketException.SocketErrorCode == SocketError.NetworkDown || socketException.SocketErrorCode == SocketError.NetworkUnreachable || socketException.SocketErrorCode == SocketError.HostDown || socketException.SocketErrorCode == SocketError.HostUnreachable || socketException.SocketErrorCode == SocketError.TimedOut)
		{
			if (timeSpent == TimeSpan.MaxValue)
			{
				return new EndpointNotFoundException(System.SR.Format(System.SR.TcpConnectError, remoteUri.AbsoluteUri, (int)socketException.SocketErrorCode, socketException.Message), innerException);
			}
			return new EndpointNotFoundException(System.SR.Format(System.SR.TcpConnectErrorWithTimeSpan, remoteUri.AbsoluteUri, (int)socketException.SocketErrorCode, socketException.Message, timeSpent), innerException);
		}
		if (socketException.SocketErrorCode == SocketError.NoBufferSpaceAvailable)
		{
			return new InsufficientMemoryException(System.SR.TcpConnectNoBufs, innerException);
		}
		if (socketException.SocketErrorCode == (SocketError)8 || socketException.SocketErrorCode == (SocketError)1450 || socketException.SocketErrorCode == (SocketError)14)
		{
			return new InsufficientMemoryException(System.SR.InsufficentMemory, socketException);
		}
		if (timeSpent == TimeSpan.MaxValue)
		{
			return new CommunicationException(System.SR.Format(System.SR.TcpConnectError, remoteUri.AbsoluteUri, (int)socketException.SocketErrorCode, socketException.Message), innerException);
		}
		return new CommunicationException(System.SR.Format(System.SR.TcpConnectErrorWithTimeSpan, remoteUri.AbsoluteUri, (int)socketException.SocketErrorCode, socketException.Message, timeSpent), innerException);
	}

	private static async Task<IPAddress[]> GetIPAddressesAsync(Uri uri)
	{
		if (uri.HostNameType == UriHostNameType.IPv4 || uri.HostNameType == UriHostNameType.IPv6)
		{
			IPAddress iPAddress = IPAddress.Parse(uri.DnsSafeHost);
			return new IPAddress[1] { iPAddress };
		}
		if ("localhost".Equals(uri.DnsSafeHost, StringComparison.OrdinalIgnoreCase))
		{
			if (Socket.OSSupportsIPv6)
			{
				return new IPAddress[2]
				{
					IPAddress.IPv6Loopback,
					IPAddress.Loopback
				};
			}
			return new IPAddress[1] { IPAddress.Loopback };
		}
		IPAddress[] array;
		try
		{
			array = await DnsCache.ResolveAsync(uri);
		}
		catch (SocketException innerException)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new EndpointNotFoundException(System.SR.Format(System.SR.UnableToResolveHost, uri.Host), innerException));
		}
		if (array.Length == 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new EndpointNotFoundException(System.SR.Format(System.SR.UnableToResolveHost, uri.Host)));
		}
		return array;
	}

	private static TimeoutException CreateTimeoutException(Uri uri, TimeSpan timeout, IPAddress[] addresses, int invalidAddressCount, SocketException innerException)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < invalidAddressCount; i++)
		{
			if (addresses[i] != null)
			{
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append(", ");
				}
				stringBuilder.Append(addresses[i].ToString());
			}
		}
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new TimeoutException(System.SR.Format(System.SR.TcpConnectingToViaTimedOut, uri.AbsoluteUri, timeout.ToString(), invalidAddressCount, addresses.Length, stringBuilder.ToString()), innerException));
	}

	public IConnection Connect(Uri uri, TimeSpan timeout)
	{
		int num = uri.Port;
		IPAddress[] result = GetIPAddressesAsync(uri).GetAwaiter().GetResult();
		IConnection connection = null;
		SocketException ex = null;
		if (num == -1)
		{
			num = 808;
		}
		int num2 = 0;
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		for (int i = 0; i < result.Length; i++)
		{
			if (timeoutHelper.RemainingTime() == TimeSpan.Zero)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(CreateTimeoutException(uri, timeoutHelper.OriginalTimeout, result, num2, ex));
			}
			DateTime utcNow = DateTime.UtcNow;
			try
			{
				connection = CreateConnection(result[i], num);
				ex = null;
			}
			catch (SocketException ex2)
			{
				num2++;
				ex = ex2;
				continue;
			}
			break;
		}
		if (connection == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new EndpointNotFoundException(System.SR.Format(System.SR.NoIPEndpointsFoundForHost, uri.Host)));
		}
		if (ex != null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(ConvertConnectException(ex, uri, timeoutHelper.ElapsedTime(), ex));
		}
		return connection;
	}

	public async Task<IConnection> ConnectAsync(Uri uri, TimeSpan timeout)
	{
		int port = uri.Port;
		IPAddress[] addresses = await GetIPAddressesAsync(uri);
		IConnection socketConnection = null;
		SocketException ex = null;
		if (port == -1)
		{
			port = 808;
		}
		int invalidAddressCount = 0;
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		for (int i = 0; i < addresses.Length; i++)
		{
			if (timeoutHelper.RemainingTime() == TimeSpan.Zero)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(CreateTimeoutException(uri, timeoutHelper.OriginalTimeout, addresses, invalidAddressCount, ex));
			}
			_ = DateTime.UtcNow;
			try
			{
				socketConnection = await CreateConnectionAsync(addresses[i], port);
				ex = null;
			}
			catch (SocketException ex2)
			{
				invalidAddressCount++;
				ex = ex2;
				continue;
			}
			break;
		}
		if (socketConnection == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new EndpointNotFoundException(System.SR.Format(System.SR.NoIPEndpointsFoundForHost, uri.Host)));
		}
		if (ex != null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(ConvertConnectException(ex, uri, timeoutHelper.ElapsedTime(), ex));
		}
		return socketConnection;
	}
}
