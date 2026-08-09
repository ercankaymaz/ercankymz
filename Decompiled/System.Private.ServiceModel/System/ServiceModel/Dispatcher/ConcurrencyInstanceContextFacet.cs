using System.Collections.Generic;

namespace System.ServiceModel.Dispatcher;

internal class ConcurrencyInstanceContextFacet
{
	internal bool Locked;

	private Queue<ConcurrencyBehavior.IWaiter> _calloutMessageQueue;

	private Queue<ConcurrencyBehavior.IWaiter> _newMessageQueue;

	internal bool HasWaiters
	{
		get
		{
			if (_calloutMessageQueue == null || _calloutMessageQueue.Count <= 0)
			{
				if (_newMessageQueue != null)
				{
					return _newMessageQueue.Count > 0;
				}
				return false;
			}
			return true;
		}
	}

	private ConcurrencyBehavior.IWaiter DequeueFrom(Queue<ConcurrencyBehavior.IWaiter> queue)
	{
		ConcurrencyBehavior.IWaiter result = queue.Dequeue();
		if (queue.Count == 0)
		{
			queue.TrimExcess();
		}
		return result;
	}

	internal ConcurrencyBehavior.IWaiter DequeueWaiter()
	{
		if (_calloutMessageQueue != null && _calloutMessageQueue.Count > 0)
		{
			return DequeueFrom(_calloutMessageQueue);
		}
		return DequeueFrom(_newMessageQueue);
	}

	internal void EnqueueNewMessage(ConcurrencyBehavior.IWaiter waiter)
	{
		if (_newMessageQueue == null)
		{
			_newMessageQueue = new Queue<ConcurrencyBehavior.IWaiter>();
		}
		_newMessageQueue.Enqueue(waiter);
	}

	internal void EnqueueCalloutMessage(ConcurrencyBehavior.IWaiter waiter)
	{
		if (_calloutMessageQueue == null)
		{
			_calloutMessageQueue = new Queue<ConcurrencyBehavior.IWaiter>();
		}
		_calloutMessageQueue.Enqueue(waiter);
	}
}
