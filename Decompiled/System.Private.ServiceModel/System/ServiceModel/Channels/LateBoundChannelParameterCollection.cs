namespace System.ServiceModel.Channels;

internal class LateBoundChannelParameterCollection : ChannelParameterCollection
{
	private IChannel _channel;

	protected override IChannel Channel => _channel;

	internal void SetChannel(IChannel channel)
	{
		_channel = channel;
	}
}
