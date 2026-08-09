namespace System.ServiceModel.Channels;

public abstract class BindingElement
{
	protected BindingElement()
	{
	}

	protected BindingElement(BindingElement elementToBeCloned)
	{
	}

	public abstract BindingElement Clone();

	public virtual IChannelFactory<TChannel> BuildChannelFactory<TChannel>(BindingContext context)
	{
		if (context == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("context");
		}
		return context.BuildInnerChannelFactory<TChannel>();
	}

	public virtual bool CanBuildChannelFactory<TChannel>(BindingContext context)
	{
		if (context == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("context");
		}
		return context.CanBuildInnerChannelFactory<TChannel>();
	}

	public abstract T GetProperty<T>(BindingContext context) where T : class;

	internal T GetIndividualProperty<T>() where T : class
	{
		return GetProperty<T>(new BindingContext(new CustomBinding(), new BindingParameterCollection()));
	}

	internal virtual bool IsMatch(BindingElement b)
	{
		return false;
	}
}
