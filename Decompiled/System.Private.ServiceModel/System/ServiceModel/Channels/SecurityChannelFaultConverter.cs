namespace System.ServiceModel.Channels;

internal class SecurityChannelFaultConverter : FaultConverter
{
	private IChannel _innerChannel;

	internal SecurityChannelFaultConverter(IChannel innerChannel)
	{
		_innerChannel = innerChannel;
	}

	protected override bool OnTryCreateException(Message message, MessageFault fault, out Exception exception)
	{
		if (_innerChannel == null)
		{
			exception = null;
			return false;
		}
		FaultConverter property = _innerChannel.GetProperty<FaultConverter>();
		if (property != null)
		{
			return property.TryCreateException(message, fault, out exception);
		}
		exception = null;
		return false;
	}

	protected override bool OnTryCreateFaultMessage(Exception exception, out Message message)
	{
		if (_innerChannel == null)
		{
			message = null;
			return false;
		}
		FaultConverter property = _innerChannel.GetProperty<FaultConverter>();
		if (property != null)
		{
			return property.TryCreateFaultMessage(exception, out message);
		}
		message = null;
		return false;
	}
}
