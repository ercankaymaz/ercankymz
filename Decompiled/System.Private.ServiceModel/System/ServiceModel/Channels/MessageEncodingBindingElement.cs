namespace System.ServiceModel.Channels;

public abstract class MessageEncodingBindingElement : BindingElement
{
	public abstract MessageVersion MessageVersion { get; set; }

	internal virtual bool IsWsdlExportable => true;

	protected MessageEncodingBindingElement()
	{
	}

	protected MessageEncodingBindingElement(MessageEncodingBindingElement elementToBeCloned)
		: base(elementToBeCloned)
	{
	}

	internal IChannelFactory<TChannel> InternalBuildChannelFactory<TChannel>(BindingContext context)
	{
		if (context == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("context"));
		}
		context.BindingParameters.Add(this);
		return context.BuildInnerChannelFactory<TChannel>();
	}

	internal bool InternalCanBuildChannelFactory<TChannel>(BindingContext context)
	{
		if (context == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("context"));
		}
		context.BindingParameters.Add(this);
		return context.CanBuildInnerChannelFactory<TChannel>();
	}

	public abstract MessageEncoderFactory CreateMessageEncoderFactory();

	public override T GetProperty<T>(BindingContext context)
	{
		if (context == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("context");
		}
		if (typeof(T) == typeof(MessageVersion))
		{
			return (T)(object)MessageVersion;
		}
		return context.GetInnerProperty<T>();
	}

	internal virtual bool CheckEncodingVersion(EnvelopeVersion version)
	{
		return false;
	}

	internal override bool IsMatch(BindingElement b)
	{
		if (b == null)
		{
			return false;
		}
		if (!(b is MessageEncodingBindingElement))
		{
			return false;
		}
		return true;
	}
}
