using System.Collections.Generic;
using System.Runtime;

namespace System.ServiceModel.Channels;

public abstract class CommunicationPool<TKey, TItem> where TKey : class where TItem : class
{
	protected abstract class IdleConnectionPool
	{
		public abstract int Count { get; }

		public abstract bool Add(TItem item);

		public abstract bool Return(TItem item);

		public abstract TItem Take(out bool closeItem);
	}

	protected class EndpointConnectionPool
	{
		protected class PoolIdleConnectionPool : IdleConnectionPool
		{
			private Pool<TItem> _idleConnections;

			private int _maxCount;

			public override int Count => _idleConnections.Count;

			public PoolIdleConnectionPool(int maxCount)
			{
				_idleConnections = new Pool<TItem>(maxCount);
				_maxCount = maxCount;
			}

			public override bool Add(TItem connection)
			{
				return ReturnToPool(connection);
			}

			public override bool Return(TItem connection)
			{
				return ReturnToPool(connection);
			}

			private bool ReturnToPool(TItem connection)
			{
				bool flag = _idleConnections.Return(connection);
				if (!flag)
				{
					if (WcfEventSource.Instance.MaxOutboundConnectionsPerEndpointExceededIsEnabled())
					{
						WcfEventSource.Instance.MaxOutboundConnectionsPerEndpointExceeded(System.SR.Format(System.SR.TraceCodeConnectionPoolMaxOutboundConnectionsPerEndpointQuotaReached, _maxCount));
					}
				}
				else if (WcfEventSource.Instance.OutboundConnectionsPerEndpointRatioIsEnabled())
				{
					WcfEventSource.Instance.OutboundConnectionsPerEndpointRatio(_idleConnections.Count, _maxCount);
				}
				return flag;
			}

			public override TItem Take(out bool closeItem)
			{
				closeItem = false;
				TItem result = _idleConnections.Take();
				if (WcfEventSource.Instance.OutboundConnectionsPerEndpointRatioIsEnabled())
				{
					WcfEventSource.Instance.OutboundConnectionsPerEndpointRatio(_idleConnections.Count, _maxCount);
				}
				return result;
			}
		}

		private List<TItem> _busyConnections;

		private bool _closed;

		private IdleConnectionPool _idleConnections;

		protected TKey Key { get; }

		private IdleConnectionPool IdleConnections
		{
			get
			{
				if (_idleConnections == null)
				{
					_idleConnections = GetIdleConnectionPool();
				}
				return _idleConnections;
			}
		}

		protected CommunicationPool<TKey, TItem> Parent { get; }

		protected object ThisLock => this;

		public EndpointConnectionPool(CommunicationPool<TKey, TItem> parent, TKey key)
		{
			Key = key;
			Parent = parent;
			_busyConnections = new List<TItem>();
		}

		public bool CloseIfEmpty()
		{
			lock (ThisLock)
			{
				if (!_closed)
				{
					if (_busyConnections.Count > 0)
					{
						return false;
					}
					if (_idleConnections != null && _idleConnections.Count > 0)
					{
						return false;
					}
					_closed = true;
				}
			}
			return true;
		}

		protected virtual void AbortItem(TItem item)
		{
			Parent.AbortItem(item);
		}

		protected virtual void CloseItem(TItem item, TimeSpan timeout)
		{
			Parent.CloseItem(item, timeout);
		}

		protected virtual void CloseItemAsync(TItem item, TimeSpan timeout)
		{
			Parent.CloseItemAsync(item, timeout);
		}

		public void Abort()
		{
			if (_closed)
			{
				return;
			}
			List<TItem> idleItemsToClose = null;
			lock (ThisLock)
			{
				if (_closed)
				{
					return;
				}
				_closed = true;
				idleItemsToClose = SnapshotIdleConnections();
			}
			AbortConnections(idleItemsToClose);
		}

		public void Close(TimeSpan timeout)
		{
			List<TItem> list = null;
			lock (ThisLock)
			{
				if (_closed)
				{
					return;
				}
				_closed = true;
				list = SnapshotIdleConnections();
			}
			try
			{
				TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
				for (int i = 0; i < list.Count; i++)
				{
					CloseItem(list[i], timeoutHelper.RemainingTime());
				}
				list.Clear();
			}
			finally
			{
				AbortConnections(list);
			}
		}

		private void AbortConnections(List<TItem> idleItemsToClose)
		{
			for (int i = 0; i < idleItemsToClose.Count; i++)
			{
				AbortItem(idleItemsToClose[i]);
			}
			for (int j = 0; j < _busyConnections.Count; j++)
			{
				AbortItem(_busyConnections[j]);
			}
			_busyConnections.Clear();
		}

		private List<TItem> SnapshotIdleConnections()
		{
			List<TItem> list = new List<TItem>();
			while (true)
			{
				bool closeItem;
				TItem val = IdleConnections.Take(out closeItem);
				if (val == null)
				{
					break;
				}
				list.Add(val);
			}
			return list;
		}

		public void AddConnection(TItem connection, TimeSpan timeout)
		{
			bool flag = false;
			lock (ThisLock)
			{
				if (!_closed && Parent.OpenCount > 0)
				{
					if (!IdleConnections.Add(connection))
					{
						flag = true;
					}
				}
				else
				{
					flag = true;
				}
			}
			if (flag)
			{
				CloseIdleConnection(connection, timeout);
			}
		}

		protected virtual IdleConnectionPool GetIdleConnectionPool()
		{
			return new PoolIdleConnectionPool(Parent.MaxIdleConnectionPoolCount);
		}

		public virtual void Prune(List<TItem> itemsToClose)
		{
		}

		public TItem TakeConnection(TimeSpan timeout)
		{
			TItem val = null;
			List<TItem> list = null;
			lock (ThisLock)
			{
				if (_closed)
				{
					return null;
				}
				while (true)
				{
					val = IdleConnections.Take(out var closeItem);
					if (val == null)
					{
						break;
					}
					if (!closeItem)
					{
						_busyConnections.Add(val);
						break;
					}
					if (list == null)
					{
						list = new List<TItem>();
					}
					list.Add(val);
				}
			}
			if (list != null)
			{
				TimeoutHelper timeoutHelper = new TimeoutHelper(TimeoutHelper.Divide(timeout, 2));
				for (int i = 0; i < list.Count; i++)
				{
					CloseIdleConnection(list[i], timeoutHelper.RemainingTime());
				}
			}
			if (WcfEventSource.Instance.ConnectionPoolMissIsEnabled() && val == null && _busyConnections != null)
			{
				WcfEventSource.Instance.ConnectionPoolMiss((Key != null) ? Key.ToString() : string.Empty, _busyConnections.Count);
			}
			return val;
		}

		public void ReturnConnection(TItem connection, bool connectionIsStillGood, TimeSpan timeout)
		{
			bool flag = false;
			bool flag2 = false;
			lock (ThisLock)
			{
				if (!_closed)
				{
					if (_busyConnections.Remove(connection) && connectionIsStillGood)
					{
						if (Parent.OpenCount == 0 || !IdleConnections.Return(connection))
						{
							flag = true;
						}
					}
					else
					{
						flag2 = true;
					}
				}
				else
				{
					flag2 = true;
				}
			}
			if (flag)
			{
				CloseIdleConnection(connection, timeout);
			}
			else if (flag2)
			{
				AbortItem(connection);
				OnConnectionAborted();
			}
		}

		public void CloseIdleConnection(TItem connection, TimeSpan timeout)
		{
			bool flag = true;
			try
			{
				CloseItemAsync(connection, timeout);
				flag = false;
			}
			catch (Exception exception)
			{
				if (Fx.IsFatal(exception))
				{
					throw;
				}
			}
			finally
			{
				if (flag)
				{
					AbortItem(connection);
				}
			}
		}

		protected virtual void OnConnectionAborted()
		{
		}
	}

	private Dictionary<TKey, EndpointConnectionPool> _endpointPools;

	private int _pruneAccrual;

	private const int pruneThreshold = 30;

	public int MaxIdleConnectionPoolCount { get; }

	protected object ThisLock => this;

	internal int OpenCount { get; set; }

	protected CommunicationPool(int maxCount)
	{
		MaxIdleConnectionPoolCount = maxCount;
		_endpointPools = new Dictionary<TKey, EndpointConnectionPool>();
		OpenCount = 1;
	}

	protected abstract void AbortItem(TItem item);

	protected abstract void CloseItem(TItem item, TimeSpan timeout);

	protected abstract void CloseItemAsync(TItem item, TimeSpan timeout);

	protected abstract TKey GetPoolKey(EndpointAddress address, Uri via);

	protected virtual EndpointConnectionPool CreateEndpointConnectionPool(TKey key)
	{
		return new EndpointConnectionPool(this, key);
	}

	public bool Close(TimeSpan timeout)
	{
		lock (ThisLock)
		{
			if (OpenCount <= 0)
			{
				return true;
			}
			OpenCount--;
			if (OpenCount == 0)
			{
				OnClose(timeout);
				return true;
			}
			return false;
		}
	}

	private List<TItem> PruneIfNecessary()
	{
		List<TItem> list = null;
		_pruneAccrual++;
		if (_pruneAccrual > 30)
		{
			_pruneAccrual = 0;
			list = new List<TItem>();
			foreach (EndpointConnectionPool value in _endpointPools.Values)
			{
				value.Prune(list);
			}
			List<TKey> list2 = null;
			foreach (KeyValuePair<TKey, EndpointConnectionPool> endpointPool in _endpointPools)
			{
				if (endpointPool.Value.CloseIfEmpty())
				{
					if (list2 == null)
					{
						list2 = new List<TKey>();
					}
					list2.Add(endpointPool.Key);
				}
			}
			if (list2 != null)
			{
				for (int i = 0; i < list2.Count; i++)
				{
					_endpointPools.Remove(list2[i]);
				}
			}
		}
		return list;
	}

	private EndpointConnectionPool GetEndpointPool(TKey key, TimeSpan timeout)
	{
		EndpointConnectionPool value = null;
		List<TItem> list = null;
		lock (ThisLock)
		{
			if (!_endpointPools.TryGetValue(key, out value))
			{
				list = PruneIfNecessary();
				value = CreateEndpointConnectionPool(key);
				_endpointPools.Add(key, value);
			}
		}
		if (list != null && list.Count > 0)
		{
			TimeoutHelper timeoutHelper = new TimeoutHelper(TimeoutHelper.Divide(timeout, 2));
			for (int i = 0; i < list.Count; i++)
			{
				value.CloseIdleConnection(list[i], timeoutHelper.RemainingTime());
			}
		}
		return value;
	}

	public bool TryOpen()
	{
		lock (ThisLock)
		{
			if (OpenCount <= 0)
			{
				return false;
			}
			OpenCount++;
			return true;
		}
	}

	protected virtual void OnClosed()
	{
	}

	private void OnClose(TimeSpan timeout)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		foreach (EndpointConnectionPool value in _endpointPools.Values)
		{
			try
			{
				value.Close(timeoutHelper.RemainingTime());
			}
			catch (CommunicationException)
			{
			}
			catch (TimeoutException ex2)
			{
				if (WcfEventSource.Instance.CloseTimeoutIsEnabled())
				{
					WcfEventSource.Instance.CloseTimeout(ex2.Message);
				}
			}
		}
		_endpointPools.Clear();
	}

	public void AddConnection(TKey key, TItem connection, TimeSpan timeout)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		EndpointConnectionPool endpointPool = GetEndpointPool(key, timeoutHelper.RemainingTime());
		endpointPool.AddConnection(connection, timeoutHelper.RemainingTime());
	}

	public TItem TakeConnection(EndpointAddress address, Uri via, TimeSpan timeout, out TKey key)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		key = GetPoolKey(address, via);
		EndpointConnectionPool endpointPool = GetEndpointPool(key, timeoutHelper.RemainingTime());
		return endpointPool.TakeConnection(timeoutHelper.RemainingTime());
	}

	public void ReturnConnection(TKey key, TItem connection, bool connectionIsStillGood, TimeSpan timeout)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		EndpointConnectionPool endpointPool = GetEndpointPool(key, timeoutHelper.RemainingTime());
		endpointPool.ReturnConnection(connection, connectionIsStillGood, timeoutHelper.RemainingTime());
	}
}
