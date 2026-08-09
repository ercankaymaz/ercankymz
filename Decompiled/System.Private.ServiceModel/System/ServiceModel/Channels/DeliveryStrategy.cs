using System.Runtime;

namespace System.ServiceModel.Channels;

internal abstract class DeliveryStrategy<ItemType> : IDisposable where ItemType : class, IDisposable
{
	protected InputQueueChannel<ItemType> Channel { get; }

	public Action DequeueCallback { get; set; }

	public abstract int EnqueuedCount { get; }

	protected int Quota { get; }

	public DeliveryStrategy(InputQueueChannel<ItemType> channel, int quota)
	{
		if (quota <= 0)
		{
			throw Fx.AssertAndThrow("Argument quota must be positive.");
		}
		Channel = channel;
		Quota = quota;
	}

	public abstract bool CanEnqueue(long sequenceNumber);

	public virtual void Dispose()
	{
	}

	public abstract bool Enqueue(ItemType item, long sequenceNumber);
}
