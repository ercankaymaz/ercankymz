using System.Collections.Generic;
using System.Runtime;
using System.Threading;

namespace System.ServiceModel.Channels;

public abstract class IdlingCommunicationPool<TKey, TItem> : CommunicationPool<TKey, TItem> where TKey : class where TItem : class
{
	protected class IdleTimeoutEndpointConnectionPool : EndpointConnectionPool
	{
		protected class IdleTimeoutIdleConnectionPool : PoolIdleConnectionPool
		{
			internal class IdlingConnectionSettings
			{
				private DateTime _lastUsage;

				public DateTime CreationTime { get; }

				public DateTime LastUsage
				{
					get
					{
						return _lastUsage;
					}
					set
					{
						_lastUsage = value;
					}
				}

				public IdlingConnectionSettings()
				{
					CreationTime = DateTime.UtcNow;
					_lastUsage = CreationTime;
				}
			}

			private const int timerThreshold = 1;

			private IdleTimeoutEndpointConnectionPool _parent;

			private TimeSpan _idleTimeout;

			private TimeSpan _leaseTimeout;

			private Timer _idleTimer;

			private static Action<object> s_onIdle;

			private object _thisLock;

			private Exception _pendingException;

			private Dictionary<TItem, IdlingConnectionSettings> _connectionMapping;

			public IdleTimeoutIdleConnectionPool(IdleTimeoutEndpointConnectionPool parent, object thisLock)
				: base(parent.Parent.MaxIdleConnectionPoolCount)
			{
				_parent = parent;
				IdlingCommunicationPool<TKey, TItem> idlingCommunicationPool = (IdlingCommunicationPool<TKey, TItem>)parent.Parent;
				_idleTimeout = idlingCommunicationPool.IdleTimeout;
				_leaseTimeout = idlingCommunicationPool._leaseTimeout;
				_thisLock = thisLock;
				_connectionMapping = new Dictionary<TItem, IdlingConnectionSettings>();
			}

			public override bool Add(TItem connection)
			{
				ThrowPendingException();
				bool flag = base.Add(connection);
				if (flag)
				{
					_connectionMapping.Add(connection, new IdlingConnectionSettings());
					StartTimerIfNecessary();
				}
				return flag;
			}

			public override bool Return(TItem connection)
			{
				ThrowPendingException();
				if (!_connectionMapping.ContainsKey(connection))
				{
					return false;
				}
				bool flag = base.Return(connection);
				if (flag)
				{
					_connectionMapping[connection].LastUsage = DateTime.UtcNow;
					StartTimerIfNecessary();
				}
				return flag;
			}

			public override TItem Take(out bool closeItem)
			{
				ThrowPendingException();
				DateTime utcNow = DateTime.UtcNow;
				TItem val = base.Take(out closeItem);
				if (!closeItem)
				{
					closeItem = IdleOutConnection(val, utcNow);
				}
				return val;
			}

			public void OnItemClosing(TItem connection)
			{
				ThrowPendingException();
				lock (_thisLock)
				{
					_connectionMapping.Remove(connection);
				}
			}

			private void CancelTimer()
			{
				if (_idleTimer != null)
				{
					_idleTimer.Change(TimeSpan.FromMilliseconds(-1.0), TimeSpan.FromMilliseconds(-1.0));
				}
			}

			private void StartTimerIfNecessary()
			{
				if (Count <= 1)
				{
					return;
				}
				if (_idleTimer == null)
				{
					if (s_onIdle == null)
					{
						s_onIdle = OnIdle;
					}
					_idleTimer = new Timer(new Action<object>(s_onIdle.Invoke).Invoke, this, _idleTimeout, TimeSpan.FromMilliseconds(-1.0));
				}
				else
				{
					_idleTimer.Change(_idleTimeout, TimeSpan.FromMilliseconds(-1.0));
				}
			}

			private static void OnIdle(object state)
			{
				IdleTimeoutIdleConnectionPool idleTimeoutIdleConnectionPool = (IdleTimeoutIdleConnectionPool)state;
				idleTimeoutIdleConnectionPool.OnIdle();
			}

			private void OnIdle()
			{
				List<TItem> list = new List<TItem>();
				lock (_thisLock)
				{
					try
					{
						Prune(list, calledFromTimer: true);
					}
					catch (Exception ex)
					{
						if (Fx.IsFatal(ex))
						{
							throw;
						}
						_pendingException = ex;
						CancelTimer();
					}
				}
				TimeoutHelper timeoutHelper = new TimeoutHelper(TimeoutHelper.Divide(_idleTimeout, 2));
				for (int i = 0; i < list.Count; i++)
				{
					_parent.CloseIdleConnection(list[i], timeoutHelper.RemainingTime());
				}
			}

			public void Prune(List<TItem> itemsToClose, bool calledFromTimer)
			{
				if (!calledFromTimer)
				{
					ThrowPendingException();
				}
				if (Count == 0)
				{
					return;
				}
				DateTime utcNow = DateTime.UtcNow;
				bool flag = false;
				lock (_thisLock)
				{
					TItem[] array = new TItem[Count];
					for (int i = 0; i < array.Length; i++)
					{
						array[i] = base.Take(out bool closeItem);
						if (closeItem || IdleOutConnection(array[i], utcNow))
						{
							itemsToClose.Add(array[i]);
							array[i] = null;
						}
					}
					for (int j = 0; j < array.Length; j++)
					{
						if (array[j] != null)
						{
							bool flag2 = base.Return(array[j]);
						}
					}
					flag = Count > 0;
				}
				if (calledFromTimer && flag)
				{
					_idleTimer.Change(_idleTimeout, TimeSpan.FromMilliseconds(-1.0));
				}
			}

			private bool IdleOutConnection(TItem connection, DateTime now)
			{
				if (connection == null)
				{
					return false;
				}
				bool result = false;
				IdlingConnectionSettings idlingConnectionSettings = _connectionMapping[connection];
				if (now > idlingConnectionSettings.LastUsage + _idleTimeout)
				{
					TraceConnectionIdleTimeoutExpired();
					result = true;
				}
				else if (now - idlingConnectionSettings.CreationTime >= _leaseTimeout)
				{
					TraceConnectionLeaseTimeoutExpired();
					result = true;
				}
				return result;
			}

			private void ThrowPendingException()
			{
				if (_pendingException == null)
				{
					return;
				}
				lock (_thisLock)
				{
					if (_pendingException != null)
					{
						Exception pendingException = _pendingException;
						_pendingException = null;
						throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(pendingException);
					}
				}
			}

			private void TraceConnectionLeaseTimeoutExpired()
			{
				if (WcfEventSource.Instance.LeaseTimeoutIsEnabled())
				{
					WcfEventSource.Instance.LeaseTimeout(System.SR.Format(System.SR.TraceCodeConnectionPoolLeaseTimeoutReached, _leaseTimeout), _parent.Key.ToString());
				}
			}

			private void TraceConnectionIdleTimeoutExpired()
			{
				if (WcfEventSource.Instance.IdleTimeoutIsEnabled())
				{
					WcfEventSource.Instance.IdleTimeout(System.SR.Format(System.SR.TraceCodeConnectionPoolIdleTimeoutReached, _idleTimeout), _parent.Key.ToString());
				}
			}
		}

		private IdleTimeoutIdleConnectionPool _connections;

		public IdleTimeoutEndpointConnectionPool(IdlingCommunicationPool<TKey, TItem> parent, TKey key)
			: base((CommunicationPool<TKey, TItem>)parent, key)
		{
			_connections = new IdleTimeoutIdleConnectionPool(this, base.ThisLock);
		}

		protected override IdleConnectionPool GetIdleConnectionPool()
		{
			return _connections;
		}

		protected override void AbortItem(TItem item)
		{
			_connections.OnItemClosing(item);
			base.AbortItem(item);
		}

		protected override void CloseItemAsync(TItem item, TimeSpan timeout)
		{
			_connections.OnItemClosing(item);
			base.CloseItemAsync(item, timeout);
		}

		protected override void CloseItem(TItem item, TimeSpan timeout)
		{
			_connections.OnItemClosing(item);
			base.CloseItem(item, timeout);
		}

		public override void Prune(List<TItem> itemsToClose)
		{
			if (_connections != null)
			{
				_connections.Prune(itemsToClose, calledFromTimer: false);
			}
		}
	}

	private TimeSpan _leaseTimeout;

	public TimeSpan IdleTimeout { get; }

	protected TimeSpan LeaseTimeout => _leaseTimeout;

	protected IdlingCommunicationPool(int maxCount, TimeSpan idleTimeout, TimeSpan leaseTimeout)
		: base(maxCount)
	{
		IdleTimeout = idleTimeout;
		_leaseTimeout = leaseTimeout;
	}

	protected override void CloseItemAsync(TItem item, TimeSpan timeout)
	{
		CloseItem(item, timeout);
	}

	protected override EndpointConnectionPool CreateEndpointConnectionPool(TKey key)
	{
		if (IdleTimeout != TimeSpan.MaxValue || _leaseTimeout != TimeSpan.MaxValue)
		{
			return new IdleTimeoutEndpointConnectionPool(this, key);
		}
		return base.CreateEndpointConnectionPool(key);
	}
}
