using System.Collections.Generic;

namespace System.ServiceModel.Channels;

public abstract class ConnectionPoolRegistry
{
	private Dictionary<string, List<ConnectionPool>> _registry;

	private object ThisLock => _registry;

	protected ConnectionPoolRegistry()
	{
		_registry = new Dictionary<string, List<ConnectionPool>>();
	}

	public ConnectionPool Lookup(IConnectionOrientedTransportChannelFactorySettings settings)
	{
		ConnectionPool connectionPool = null;
		string connectionPoolGroupName = settings.ConnectionPoolGroupName;
		lock (ThisLock)
		{
			List<ConnectionPool> value = null;
			if (_registry.TryGetValue(connectionPoolGroupName, out value))
			{
				for (int i = 0; i < value.Count; i++)
				{
					if (value[i].IsCompatible(settings) && value[i].TryOpen())
					{
						connectionPool = value[i];
						break;
					}
				}
			}
			else
			{
				value = new List<ConnectionPool>();
				_registry.Add(connectionPoolGroupName, value);
			}
			if (connectionPool == null)
			{
				connectionPool = CreatePool(settings);
				value.Add(connectionPool);
			}
		}
		return connectionPool;
	}

	protected abstract ConnectionPool CreatePool(IConnectionOrientedTransportChannelFactorySettings settings);

	public void Release(ConnectionPool pool, TimeSpan timeout)
	{
		lock (ThisLock)
		{
			if (!pool.Close(timeout))
			{
				return;
			}
			List<ConnectionPool> list = _registry[pool.Name];
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i] == pool)
				{
					list.RemoveAt(i);
					break;
				}
			}
			if (list.Count == 0)
			{
				_registry.Remove(pool.Name);
			}
		}
	}
}
