using System.Collections.Generic;
using System.Runtime;

namespace System.ServiceModel.Channels;

internal class OrderedDeliveryStrategy<ItemType> : DeliveryStrategy<ItemType> where ItemType : class, IDisposable
{
	private bool isEnqueueInOrder;

	private Dictionary<long, ItemType> items;

	private Action<object> onDispatchCallback;

	private long windowStart;

	public override int EnqueuedCount => base.Channel.InternalPendingItems + items.Count;

	private Action<object> OnDispatchCallback
	{
		get
		{
			if (onDispatchCallback == null)
			{
				onDispatchCallback = OnDispatch;
			}
			return onDispatchCallback;
		}
	}

	public OrderedDeliveryStrategy(InputQueueChannel<ItemType> channel, int quota, bool isEnqueueInOrder)
		: base(channel, quota)
	{
		this.isEnqueueInOrder = isEnqueueInOrder;
		items = new Dictionary<long, ItemType>();
		windowStart = 1L;
	}

	public override bool CanEnqueue(long sequenceNumber)
	{
		if (EnqueuedCount >= base.Quota)
		{
			return false;
		}
		if (isEnqueueInOrder && sequenceNumber > windowStart)
		{
			return false;
		}
		return base.Channel.InternalPendingItems + sequenceNumber - windowStart < base.Quota;
	}

	public override bool Enqueue(ItemType item, long sequenceNumber)
	{
		if (sequenceNumber > windowStart)
		{
			items.Add(sequenceNumber, item);
			return false;
		}
		windowStart++;
		while (items.ContainsKey(windowStart))
		{
			if (base.Channel.EnqueueWithoutDispatch(item, base.DequeueCallback))
			{
				ActionItem.Schedule(OnDispatchCallback, null);
			}
			item = items[windowStart];
			items.Remove(windowStart);
			windowStart++;
		}
		return base.Channel.EnqueueWithoutDispatch(item, base.DequeueCallback);
	}

	private static void DisposeItems(Dictionary<long, ItemType>.Enumerator items)
	{
		if (items.MoveNext())
		{
			using (items.Current.Value)
			{
				DisposeItems(items);
			}
		}
	}

	public override void Dispose()
	{
		DisposeItems(items.GetEnumerator());
		items.Clear();
		base.Dispose();
	}

	private void OnDispatch(object state)
	{
		base.Channel.Dispatch();
	}
}
