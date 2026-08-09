using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

public abstract class TransportChannelFactory<TChannel> : ChannelFactoryBase<TChannel>, ITransportFactorySettings, IDefaultCommunicationTimeouts
{
	private long _maxReceivedMessageSize;

	private MessageVersion _messageVersion;

	public BufferManager BufferManager { get; private set; }

	public long MaxBufferPoolSize { get; }

	public long MaxReceivedMessageSize => _maxReceivedMessageSize;

	public MessageEncoderFactory MessageEncoderFactory { get; }

	public MessageVersion MessageVersion => _messageVersion;

	public bool ManualAddressing { get; }

	public abstract string Scheme { get; }

	long ITransportFactorySettings.MaxReceivedMessageSize => MaxReceivedMessageSize;

	BufferManager ITransportFactorySettings.BufferManager => BufferManager;

	bool ITransportFactorySettings.ManualAddressing => ManualAddressing;

	MessageEncoderFactory ITransportFactorySettings.MessageEncoderFactory => MessageEncoderFactory;

	protected TransportChannelFactory(TransportBindingElement bindingElement, BindingContext context)
		: this(bindingElement, context, TransportDefaults.GetDefaultMessageEncoderFactory())
	{
	}

	protected TransportChannelFactory(TransportBindingElement bindingElement, BindingContext context, MessageEncoderFactory defaultMessageEncoderFactory)
		: base((IDefaultCommunicationTimeouts)context.Binding)
	{
		ManualAddressing = bindingElement.ManualAddressing;
		MaxBufferPoolSize = bindingElement.MaxBufferPoolSize;
		_maxReceivedMessageSize = bindingElement.MaxReceivedMessageSize;
		Collection<MessageEncodingBindingElement> collection = context.BindingParameters.FindAll<MessageEncodingBindingElement>();
		if (collection.Count > 1)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.MultipleMebesInParameters));
		}
		if (collection.Count == 1)
		{
			MessageEncoderFactory = collection[0].CreateMessageEncoderFactory();
			context.BindingParameters.Remove<MessageEncodingBindingElement>();
		}
		else
		{
			MessageEncoderFactory = defaultMessageEncoderFactory;
		}
		if (MessageEncoderFactory != null)
		{
			_messageVersion = MessageEncoderFactory.MessageVersion;
		}
		else
		{
			_messageVersion = MessageVersion.None;
		}
	}

	public override T GetProperty<T>()
	{
		if (typeof(T) == typeof(MessageVersion))
		{
			return (T)(object)MessageVersion;
		}
		if (typeof(T) == typeof(FaultConverter))
		{
			if (MessageEncoderFactory == null)
			{
				return null;
			}
			return MessageEncoderFactory.Encoder.GetProperty<T>();
		}
		if (typeof(T) == typeof(ITransportFactorySettings))
		{
			return (T)(object)this;
		}
		return base.GetProperty<T>();
	}

	protected override void OnAbort()
	{
		OnCloseOrAbort();
		base.OnAbort();
	}

	protected override IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
	{
		OnCloseOrAbort();
		return base.OnBeginClose(timeout, callback, state);
	}

	protected override void OnClose(TimeSpan timeout)
	{
		OnCloseOrAbort();
		base.OnClose(timeout);
	}

	protected internal override Task OnCloseAsync(TimeSpan timeout)
	{
		OnCloseOrAbort();
		return base.OnCloseAsync(timeout);
	}

	private void OnCloseOrAbort()
	{
		if (BufferManager != null)
		{
			BufferManager.Clear();
		}
	}

	public virtual int GetMaxBufferSize()
	{
		if (MaxReceivedMessageSize > int.MaxValue)
		{
			return int.MaxValue;
		}
		return (int)MaxReceivedMessageSize;
	}

	protected override void OnOpening()
	{
		base.OnOpening();
		BufferManager = BufferManager.CreateBufferManager(MaxBufferPoolSize, GetMaxBufferSize());
	}

	public void ValidateScheme(Uri via)
	{
		if (via.Scheme != Scheme && string.Compare(via.Scheme, Scheme, StringComparison.OrdinalIgnoreCase) != 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument("via", System.SR.Format(System.SR.InvalidUriScheme, via.Scheme, Scheme));
		}
	}
}
