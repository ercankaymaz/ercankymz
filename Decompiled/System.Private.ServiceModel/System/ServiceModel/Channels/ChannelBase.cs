namespace System.ServiceModel.Channels;

public abstract class ChannelBase : CommunicationObject, IChannel, ICommunicationObject, IDefaultCommunicationTimeouts
{
	TimeSpan IDefaultCommunicationTimeouts.CloseTimeout => DefaultCloseTimeout;

	TimeSpan IDefaultCommunicationTimeouts.OpenTimeout => DefaultOpenTimeout;

	TimeSpan IDefaultCommunicationTimeouts.ReceiveTimeout => DefaultReceiveTimeout;

	TimeSpan IDefaultCommunicationTimeouts.SendTimeout => DefaultSendTimeout;

	protected override TimeSpan DefaultCloseTimeout => ((IDefaultCommunicationTimeouts)Manager).CloseTimeout;

	protected override TimeSpan DefaultOpenTimeout => ((IDefaultCommunicationTimeouts)Manager).OpenTimeout;

	protected TimeSpan DefaultReceiveTimeout => ((IDefaultCommunicationTimeouts)Manager).ReceiveTimeout;

	protected TimeSpan DefaultSendTimeout => ((IDefaultCommunicationTimeouts)Manager).SendTimeout;

	protected ChannelManagerBase Manager { get; }

	protected ChannelBase(ChannelManagerBase channelManager)
	{
		Manager = channelManager ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("channelManager");
	}

	public virtual T GetProperty<T>() where T : class
	{
		if (Manager is IChannelFactory channelFactory)
		{
			return channelFactory.GetProperty<T>();
		}
		if (Manager is IChannelListener channelListener)
		{
			return channelListener.GetProperty<T>();
		}
		return null;
	}

	protected override void OnClosed()
	{
		base.OnClosed();
	}
}
