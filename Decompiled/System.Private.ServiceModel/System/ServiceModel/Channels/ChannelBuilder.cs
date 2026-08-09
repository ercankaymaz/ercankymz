namespace System.ServiceModel.Channels;

internal class ChannelBuilder
{
	private BindingContext _context;

	public CustomBinding Binding { get; set; }

	public BindingParameterCollection BindingParameters { get; set; }

	public ChannelBuilder(BindingContext context, bool addChannelDemuxerIfRequired)
	{
		_context = context;
		if (addChannelDemuxerIfRequired)
		{
			AddDemuxerBindingElement(context.RemainingBindingElements);
		}
		Binding = new CustomBinding(context.Binding, context.RemainingBindingElements);
		BindingParameters = context.BindingParameters;
	}

	public ChannelBuilder(Binding binding, BindingParameterCollection bindingParameters, bool addChannelDemuxerIfRequired)
	{
		Binding = new CustomBinding(binding);
		BindingParameters = bindingParameters;
		if (addChannelDemuxerIfRequired)
		{
			throw ExceptionHelper.PlatformNotSupported();
		}
	}

	public ChannelBuilder(ChannelBuilder channelBuilder)
	{
		Binding = new CustomBinding(channelBuilder.Binding);
		BindingParameters = channelBuilder.BindingParameters;
	}

	private void AddDemuxerBindingElement(BindingElementCollection elements)
	{
		if (elements.Find<ChannelDemuxerBindingElement>() == null)
		{
			TransportBindingElement transportBindingElement = elements.Find<TransportBindingElement>();
			if (transportBindingElement == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.TransportBindingElementNotFound));
			}
			elements.Insert(elements.IndexOf(transportBindingElement), new ChannelDemuxerBindingElement(cacheContextState: true));
		}
	}

	public IChannelFactory<TChannel> BuildChannelFactory<TChannel>()
	{
		if (_context != null)
		{
			IChannelFactory<TChannel> result = _context.BuildInnerChannelFactory<TChannel>();
			_context = null;
			return result;
		}
		return Binding.BuildChannelFactory<TChannel>(BindingParameters);
	}

	public bool CanBuildChannelFactory<TChannel>()
	{
		return Binding.CanBuildChannelFactory<TChannel>(BindingParameters);
	}
}
