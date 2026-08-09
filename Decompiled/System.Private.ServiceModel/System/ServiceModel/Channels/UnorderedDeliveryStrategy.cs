namespace System.ServiceModel.Channels;

internal class UnorderedDeliveryStrategy<ItemType> : DeliveryStrategy<ItemType> where ItemType : class, IDisposable
{
	public override int EnqueuedCount => base.Channel.InternalPendingItems;

	public UnorderedDeliveryStrategy(InputQueueChannel<ItemType> channel, int quota)
		: base(channel, quota)
	{
	}

	public override bool CanEnqueue(long sequenceNumber)
	{
		return EnqueuedCount < base.Quota;
	}

	public override bool Enqueue(ItemType item, long sequenceNumber)
	{
		return base.Channel.EnqueueWithoutDispatch(item, base.DequeueCallback);
	}
}
