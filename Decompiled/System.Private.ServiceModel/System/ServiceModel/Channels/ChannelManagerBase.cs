namespace System.ServiceModel.Channels;

public abstract class ChannelManagerBase : CommunicationObject, IDefaultCommunicationTimeouts
{
	protected abstract TimeSpan DefaultReceiveTimeout { get; }

	protected abstract TimeSpan DefaultSendTimeout { get; }

	internal TimeSpan InternalReceiveTimeout => DefaultReceiveTimeout;

	internal TimeSpan InternalSendTimeout => DefaultSendTimeout;

	TimeSpan IDefaultCommunicationTimeouts.CloseTimeout => DefaultCloseTimeout;

	TimeSpan IDefaultCommunicationTimeouts.OpenTimeout => DefaultOpenTimeout;

	TimeSpan IDefaultCommunicationTimeouts.ReceiveTimeout => DefaultReceiveTimeout;

	TimeSpan IDefaultCommunicationTimeouts.SendTimeout => DefaultSendTimeout;

	internal Exception CreateChannelTypeNotSupportedException(Type type)
	{
		return new ArgumentException(System.SR.Format(System.SR.ChannelTypeNotSupported, type), "TChannel");
	}
}
