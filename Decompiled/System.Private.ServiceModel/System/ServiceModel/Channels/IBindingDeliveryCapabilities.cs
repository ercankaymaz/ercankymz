namespace System.ServiceModel.Channels;

public interface IBindingDeliveryCapabilities
{
	bool AssuresOrderedDelivery { get; }

	bool QueuedDelivery { get; }
}
