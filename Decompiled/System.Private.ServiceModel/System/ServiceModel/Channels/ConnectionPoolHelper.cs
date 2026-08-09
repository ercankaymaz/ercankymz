using System.Runtime;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal abstract class ConnectionPoolHelper
{
	private IConnectionInitiator _connectionInitiator;

	private ConnectionPool _connectionPool;

	private Uri _via;

	private bool _closed;

	private string _connectionKey;

	private bool _isConnectionFromPool;

	private IConnection _rawConnection;

	private IConnection _upgradedConnection;

	private object ThisLock => this;

	public ConnectionPoolHelper(ConnectionPool connectionPool, IConnectionInitiator connectionInitiator, Uri via)
	{
		_connectionInitiator = connectionInitiator;
		_connectionPool = connectionPool;
		_via = via;
	}

	protected abstract IConnection AcceptPooledConnection(IConnection connection, ref TimeoutHelper timeoutHelper);

	protected abstract Task<IConnection> AcceptPooledConnectionAsync(IConnection connection, ref TimeoutHelper timeoutHelper);

	protected abstract TimeoutException CreateNewConnectionTimeoutException(TimeSpan timeout, TimeoutException innerException);

	private IConnection TakeConnection(TimeSpan timeout)
	{
		return _connectionPool.TakeConnection(null, _via, timeout, out _connectionKey);
	}

	public async Task<IConnection> EstablishConnectionAsync(TimeSpan timeout)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		IConnection localRawConnection = null;
		IConnection localUpgradedConnection = null;
		bool localIsConnectionFromPool = true;
		while (localIsConnectionFromPool)
		{
			localRawConnection = TakeConnection(timeoutHelper.RemainingTime());
			if (localRawConnection == null)
			{
				localIsConnectionFromPool = false;
				continue;
			}
			bool preambleSuccess = false;
			try
			{
				localUpgradedConnection = await AcceptPooledConnectionAsync(localRawConnection, ref timeoutHelper);
				preambleSuccess = true;
			}
			catch (CommunicationException)
			{
				continue;
			}
			catch (TimeoutException)
			{
				continue;
			}
			finally
			{
				if (!preambleSuccess)
				{
					_connectionPool.ReturnConnection(_connectionKey, localRawConnection, connectionIsStillGood: false, TimeSpan.Zero);
				}
			}
			break;
		}
		if (!localIsConnectionFromPool)
		{
			bool preambleSuccess = false;
			TimeSpan connectTimeout = timeoutHelper.RemainingTime();
			try
			{
				try
				{
					localRawConnection = await _connectionInitiator.ConnectAsync(_via, connectTimeout);
				}
				catch (TimeoutException innerException)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(CreateNewConnectionTimeoutException(connectTimeout, innerException));
				}
				_connectionInitiator = null;
				localUpgradedConnection = await AcceptPooledConnectionAsync(localRawConnection, ref timeoutHelper);
				preambleSuccess = true;
			}
			finally
			{
				if (!preambleSuccess)
				{
					_connectionKey = null;
					localRawConnection?.Abort();
				}
			}
		}
		SnapshotConnection(localUpgradedConnection, localRawConnection, localIsConnectionFromPool);
		return localUpgradedConnection;
	}

	public IConnection EstablishConnection(TimeSpan timeout)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		IConnection connection = null;
		IConnection connection2 = null;
		bool flag = true;
		while (flag)
		{
			connection = TakeConnection(timeoutHelper.RemainingTime());
			if (connection == null)
			{
				flag = false;
				continue;
			}
			bool flag2 = false;
			try
			{
				connection2 = AcceptPooledConnection(connection, ref timeoutHelper);
				flag2 = true;
			}
			catch (CommunicationException)
			{
				continue;
			}
			catch (TimeoutException)
			{
				continue;
			}
			finally
			{
				if (!flag2)
				{
					_connectionPool.ReturnConnection(_connectionKey, connection, connectionIsStillGood: false, TimeSpan.Zero);
				}
			}
			break;
		}
		if (!flag)
		{
			bool flag3 = false;
			TimeSpan timeout2 = timeoutHelper.RemainingTime();
			try
			{
				try
				{
					connection = _connectionInitiator.Connect(_via, timeout2);
				}
				catch (TimeoutException innerException)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(CreateNewConnectionTimeoutException(timeout2, innerException));
				}
				_connectionInitiator = null;
				connection2 = AcceptPooledConnection(connection, ref timeoutHelper);
				flag3 = true;
			}
			finally
			{
				if (!flag3)
				{
					_connectionKey = null;
					connection?.Abort();
				}
			}
		}
		SnapshotConnection(connection2, connection, flag);
		return connection2;
	}

	private void SnapshotConnection(IConnection upgradedConnection, IConnection rawConnection, bool isConnectionFromPool)
	{
		lock (ThisLock)
		{
			if (_closed)
			{
				upgradedConnection.Abort();
				if (isConnectionFromPool)
				{
					_connectionPool.ReturnConnection(_connectionKey, rawConnection, connectionIsStillGood: false, TimeSpan.Zero);
				}
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new CommunicationObjectAbortedException(System.SR.Format(System.SR.OperationAbortedDuringConnectionEstablishment, _via)));
			}
			_upgradedConnection = upgradedConnection;
			_rawConnection = rawConnection;
			_isConnectionFromPool = isConnectionFromPool;
		}
	}

	public void Abort()
	{
		ReleaseConnection(abort: true, TimeSpan.Zero);
	}

	public void Close(TimeSpan timeout)
	{
		ReleaseConnection(abort: false, timeout);
	}

	private void ReleaseConnection(bool abort, TimeSpan timeout)
	{
		string connectionKey;
		IConnection upgradedConnection;
		IConnection rawConnection;
		lock (ThisLock)
		{
			_closed = true;
			connectionKey = _connectionKey;
			upgradedConnection = _upgradedConnection;
			rawConnection = _rawConnection;
			_upgradedConnection = null;
			_rawConnection = null;
		}
		if (upgradedConnection == null)
		{
			return;
		}
		try
		{
			if (_isConnectionFromPool)
			{
				_connectionPool.ReturnConnection(connectionKey, rawConnection, !abort, timeout);
			}
			else if (abort)
			{
				upgradedConnection.Abort();
			}
			else
			{
				_connectionPool.AddConnection(connectionKey, rawConnection, timeout);
			}
		}
		catch (CommunicationException)
		{
			upgradedConnection.Abort();
		}
	}
}
