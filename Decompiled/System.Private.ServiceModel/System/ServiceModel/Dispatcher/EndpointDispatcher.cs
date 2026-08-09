using System.ServiceModel.Channels;

namespace System.ServiceModel.Dispatcher;

public class EndpointDispatcher
{
	private Uri _listenUri;

	private EndpointAddress _originalAddress;

	public ChannelDispatcher ChannelDispatcher { get; private set; }

	public string ContractName => string.Empty;

	public string ContractNamespace => string.Empty;

	internal ServiceChannel DatagramChannel { get; set; }

	public DispatchRuntime DispatchRuntime => null;

	public EndpointAddress EndpointAddress
	{
		get
		{
			if (ChannelDispatcher == null)
			{
				return _originalAddress;
			}
			if (_originalAddress != null && _originalAddress.Identity != null)
			{
				return _originalAddress;
			}
			IChannelListener listener = ChannelDispatcher.Listener;
			EndpointIdentity property = listener.GetProperty<EndpointIdentity>();
			if (_originalAddress != null && property == null)
			{
				return _originalAddress;
			}
			EndpointAddressBuilder endpointAddressBuilder;
			if (_originalAddress != null)
			{
				endpointAddressBuilder = new EndpointAddressBuilder(_originalAddress);
			}
			else
			{
				endpointAddressBuilder = new EndpointAddressBuilder();
				endpointAddressBuilder.Uri = listener.Uri;
			}
			endpointAddressBuilder.Identity = property;
			return endpointAddressBuilder.ToEndpointAddress();
		}
	}

	public int FilterPriority { get; set; }

	internal void Attach(ChannelDispatcher channelDispatcher)
	{
		if (ChannelDispatcher != null)
		{
			Exception exception = new InvalidOperationException(System.SR.SFxEndpointDispatcherMultipleChannelDispatcher0);
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(exception);
		}
		ChannelDispatcher = channelDispatcher ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("channelDispatcher");
		_listenUri = channelDispatcher.Listener.Uri;
	}

	internal void Detach(ChannelDispatcher channelDispatcher)
	{
		if (channelDispatcher == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("channelDispatcher");
		}
		if (ChannelDispatcher != channelDispatcher)
		{
			Exception exception = new InvalidOperationException(System.SR.SFxEndpointDispatcherDifferentChannelDispatcher0);
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(exception);
		}
		ChannelDispatcher = null;
	}
}
