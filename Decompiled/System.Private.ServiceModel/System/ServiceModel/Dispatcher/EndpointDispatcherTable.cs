using System.Collections.Generic;
using System.ServiceModel.Channels;

namespace System.ServiceModel.Dispatcher;

internal class EndpointDispatcherTable
{
	private const int optimizationThreshold = 2;

	private List<EndpointDispatcher> _cachedEndpoints;

	private object ThisLock { get; }

	public EndpointDispatcherTable(object thisLock)
	{
		ThisLock = thisLock;
	}

	public void AddEndpoint(EndpointDispatcher endpoint)
	{
		lock (ThisLock)
		{
			int filterPriority = endpoint.FilterPriority;
			if (_cachedEndpoints == null)
			{
				_cachedEndpoints = new List<EndpointDispatcher>(2);
			}
			if (_cachedEndpoints.Count < 2)
			{
				_cachedEndpoints.Add(endpoint);
			}
		}
	}

	public void RemoveEndpoint(EndpointDispatcher endpoint)
	{
		lock (ThisLock)
		{
			if (_cachedEndpoints != null && _cachedEndpoints.Contains(endpoint))
			{
				_cachedEndpoints.Remove(endpoint);
			}
		}
	}

	public EndpointDispatcher Lookup(Message message, out bool addressMatched)
	{
		addressMatched = false;
		return null;
	}
}
