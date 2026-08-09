using System.ComponentModel;

namespace System.ServiceModel.Channels;

public abstract class ConnectionOrientedTransportBindingElement : TransportBindingElement
{
	private int _connectionBufferSize;

	private int _maxBufferSize;

	private bool _maxBufferSizeInitialized;

	private TransferMode _transferMode;

	[DefaultValue(8192)]
	public int ConnectionBufferSize
	{
		get
		{
			return _connectionBufferSize;
		}
		set
		{
			if (value < 0)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value", value, System.SR.ValueMustBeNonNegative));
			}
			_connectionBufferSize = value;
		}
	}

	internal bool ExposeConnectionProperty { get; set; }

	[DefaultValue(65536)]
	public int MaxBufferSize
	{
		get
		{
			if (_maxBufferSizeInitialized || TransferMode != TransferMode.Buffered)
			{
				return _maxBufferSize;
			}
			long maxReceivedMessageSize = MaxReceivedMessageSize;
			if (maxReceivedMessageSize > int.MaxValue)
			{
				return int.MaxValue;
			}
			return (int)maxReceivedMessageSize;
		}
		set
		{
			if (value <= 0)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value", value, System.SR.ValueMustBePositive));
			}
			_maxBufferSizeInitialized = true;
			_maxBufferSize = value;
		}
	}

	internal TimeSpan MaxOutputDelay { get; }

	[DefaultValue(TransferMode.Buffered)]
	public TransferMode TransferMode
	{
		get
		{
			return _transferMode;
		}
		set
		{
			TransferModeHelper.Validate(value);
			_transferMode = value;
		}
	}

	internal ConnectionOrientedTransportBindingElement()
	{
		_connectionBufferSize = 8192;
		MaxOutputDelay = ConnectionOrientedTransportDefaults.MaxOutputDelay;
		_maxBufferSize = 65536;
		_transferMode = TransferMode.Buffered;
	}

	internal ConnectionOrientedTransportBindingElement(ConnectionOrientedTransportBindingElement elementToBeCloned)
		: base(elementToBeCloned)
	{
		_connectionBufferSize = elementToBeCloned._connectionBufferSize;
		ExposeConnectionProperty = elementToBeCloned.ExposeConnectionProperty;
		_maxBufferSize = elementToBeCloned._maxBufferSize;
		_maxBufferSizeInitialized = elementToBeCloned._maxBufferSizeInitialized;
		_transferMode = elementToBeCloned._transferMode;
	}

	public override bool CanBuildChannelFactory<TChannel>(BindingContext context)
	{
		if (context == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("context");
		}
		if (TransferMode == TransferMode.Buffered)
		{
			return typeof(TChannel) == typeof(IDuplexSessionChannel);
		}
		return typeof(TChannel) == typeof(IRequestChannel);
	}

	public override T GetProperty<T>(BindingContext context)
	{
		if (context == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("context");
		}
		if (typeof(T) == typeof(TransferMode))
		{
			return (T)(object)TransferMode;
		}
		return base.GetProperty<T>(context);
	}

	internal override bool IsMatch(BindingElement b)
	{
		if (!base.IsMatch(b))
		{
			return false;
		}
		if (!(b is ConnectionOrientedTransportBindingElement connectionOrientedTransportBindingElement))
		{
			return false;
		}
		if (_connectionBufferSize != connectionOrientedTransportBindingElement._connectionBufferSize)
		{
			return false;
		}
		if (_maxBufferSize != connectionOrientedTransportBindingElement._maxBufferSize)
		{
			return false;
		}
		if (_transferMode != connectionOrientedTransportBindingElement._transferMode)
		{
			return false;
		}
		return true;
	}

	private MessageEncodingBindingElement FindMessageEncodingBindingElement(BindingElementCollection bindingElements, out bool createdNew)
	{
		createdNew = false;
		MessageEncodingBindingElement messageEncodingBindingElement = bindingElements.Find<MessageEncodingBindingElement>();
		if (messageEncodingBindingElement == null)
		{
			createdNew = true;
			messageEncodingBindingElement = new BinaryMessageEncodingBindingElement();
		}
		return messageEncodingBindingElement;
	}
}
