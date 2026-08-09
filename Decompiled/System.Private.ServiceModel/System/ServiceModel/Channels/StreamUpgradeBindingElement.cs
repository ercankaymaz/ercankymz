namespace System.ServiceModel.Channels;

public abstract class StreamUpgradeBindingElement : BindingElement
{
	protected StreamUpgradeBindingElement()
	{
	}

	protected StreamUpgradeBindingElement(StreamUpgradeBindingElement elementToBeCloned)
		: base(elementToBeCloned)
	{
	}

	public abstract StreamUpgradeProvider BuildClientStreamUpgradeProvider(BindingContext context);
}
