using System.ComponentModel;
using System.Xml;

namespace System.ServiceModel.Channels;

public sealed class BinaryMessageEncodingBindingElement : MessageEncodingBindingElement
{
	private int _maxReadPoolSize;

	private int _maxWritePoolSize;

	private XmlDictionaryReaderQuotas _readerQuotas;

	private int _maxSessionSize;

	private BinaryVersion _binaryVersion;

	private MessageVersion _messageVersion;

	private long _maxReceivedMessageSize;

	[DefaultValue(CompressionFormat.None)]
	public CompressionFormat CompressionFormat { get; set; }

	private BinaryVersion BinaryVersion
	{
		get
		{
			return _binaryVersion;
		}
		set
		{
			_binaryVersion = value ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("value"));
		}
	}

	public override MessageVersion MessageVersion
	{
		get
		{
			return _messageVersion;
		}
		set
		{
			if (value == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("value");
			}
			if (value.Envelope != BinaryEncoderDefaults.EnvelopeVersion)
			{
				string message = System.SR.Format(System.SR.UnsupportedEnvelopeVersion, GetType().FullName, BinaryEncoderDefaults.EnvelopeVersion, value.Envelope);
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(message));
			}
			_messageVersion = MessageVersion.CreateVersion(BinaryEncoderDefaults.EnvelopeVersion, value.Addressing);
		}
	}

	[DefaultValue(64)]
	public int MaxReadPoolSize
	{
		get
		{
			return _maxReadPoolSize;
		}
		set
		{
			if (value <= 0)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value", value, System.SR.ValueMustBePositive));
			}
			_maxReadPoolSize = value;
		}
	}

	[DefaultValue(16)]
	public int MaxWritePoolSize
	{
		get
		{
			return _maxWritePoolSize;
		}
		set
		{
			if (value <= 0)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value", value, System.SR.ValueMustBePositive));
			}
			_maxWritePoolSize = value;
		}
	}

	public XmlDictionaryReaderQuotas ReaderQuotas
	{
		get
		{
			return _readerQuotas;
		}
		set
		{
			if (value == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("value");
			}
			value.CopyTo(_readerQuotas);
		}
	}

	[DefaultValue(2048)]
	public int MaxSessionSize
	{
		get
		{
			return _maxSessionSize;
		}
		set
		{
			if (value < 0)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value", value, System.SR.ValueMustBeNonNegative));
			}
			_maxSessionSize = value;
		}
	}

	public BinaryMessageEncodingBindingElement()
	{
		_maxReadPoolSize = 64;
		_maxWritePoolSize = 16;
		_readerQuotas = new XmlDictionaryReaderQuotas();
		EncoderDefaults.ReaderQuotas.CopyTo(_readerQuotas);
		_maxSessionSize = 2048;
		_binaryVersion = BinaryEncoderDefaults.BinaryVersion;
		_messageVersion = MessageVersion.CreateVersion(BinaryEncoderDefaults.EnvelopeVersion);
		CompressionFormat = CompressionFormat.None;
	}

	private BinaryMessageEncodingBindingElement(BinaryMessageEncodingBindingElement elementToBeCloned)
		: base(elementToBeCloned)
	{
		_maxReadPoolSize = elementToBeCloned._maxReadPoolSize;
		_maxWritePoolSize = elementToBeCloned._maxWritePoolSize;
		_readerQuotas = new XmlDictionaryReaderQuotas();
		elementToBeCloned._readerQuotas.CopyTo(_readerQuotas);
		MaxSessionSize = elementToBeCloned.MaxSessionSize;
		BinaryVersion = elementToBeCloned.BinaryVersion;
		_messageVersion = elementToBeCloned._messageVersion;
		CompressionFormat = elementToBeCloned.CompressionFormat;
		_maxReceivedMessageSize = elementToBeCloned._maxReceivedMessageSize;
	}

	private void VerifyCompression(BindingContext context)
	{
		if (CompressionFormat != CompressionFormat.None)
		{
			ITransportCompressionSupport innerProperty = context.GetInnerProperty<ITransportCompressionSupport>();
			if (innerProperty == null || !innerProperty.IsCompressionFormatSupported(CompressionFormat))
			{
				throw FxTrace.Exception.AsError(new NotSupportedException(System.SR.Format(System.SR.TransportDoesNotSupportCompression, CompressionFormat.ToString(), GetType().Name, CompressionFormat.None.ToString())));
			}
		}
	}

	private void SetMaxReceivedMessageSizeFromTransport(BindingContext context)
	{
		TransportBindingElement transportBindingElement = context.Binding.Elements.Find<TransportBindingElement>();
		if (transportBindingElement != null)
		{
			_maxReceivedMessageSize = transportBindingElement.MaxReceivedMessageSize;
		}
	}

	public override IChannelFactory<TChannel> BuildChannelFactory<TChannel>(BindingContext context)
	{
		VerifyCompression(context);
		SetMaxReceivedMessageSizeFromTransport(context);
		return InternalBuildChannelFactory<TChannel>(context);
	}

	public override BindingElement Clone()
	{
		return new BinaryMessageEncodingBindingElement(this);
	}

	public override MessageEncoderFactory CreateMessageEncoderFactory()
	{
		return new BinaryMessageEncoderFactory(MessageVersion, MaxReadPoolSize, MaxWritePoolSize, MaxSessionSize, ReaderQuotas, _maxReceivedMessageSize, BinaryVersion, CompressionFormat);
	}

	public override T GetProperty<T>(BindingContext context)
	{
		if (context == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("context");
		}
		if (typeof(T) == typeof(XmlDictionaryReaderQuotas))
		{
			return (T)(object)_readerQuotas;
		}
		return base.GetProperty<T>(context);
	}

	internal override bool IsMatch(BindingElement b)
	{
		if (!base.IsMatch(b))
		{
			return false;
		}
		if (!(b is BinaryMessageEncodingBindingElement binaryMessageEncodingBindingElement))
		{
			return false;
		}
		if (_maxReadPoolSize != binaryMessageEncodingBindingElement.MaxReadPoolSize)
		{
			return false;
		}
		if (_maxWritePoolSize != binaryMessageEncodingBindingElement.MaxWritePoolSize)
		{
			return false;
		}
		if (_readerQuotas.MaxStringContentLength != binaryMessageEncodingBindingElement.ReaderQuotas.MaxStringContentLength)
		{
			return false;
		}
		if (_readerQuotas.MaxArrayLength != binaryMessageEncodingBindingElement.ReaderQuotas.MaxArrayLength)
		{
			return false;
		}
		if (_readerQuotas.MaxBytesPerRead != binaryMessageEncodingBindingElement.ReaderQuotas.MaxBytesPerRead)
		{
			return false;
		}
		if (_readerQuotas.MaxDepth != binaryMessageEncodingBindingElement.ReaderQuotas.MaxDepth)
		{
			return false;
		}
		if (_readerQuotas.MaxNameTableCharCount != binaryMessageEncodingBindingElement.ReaderQuotas.MaxNameTableCharCount)
		{
			return false;
		}
		if (MaxSessionSize != binaryMessageEncodingBindingElement.MaxSessionSize)
		{
			return false;
		}
		if (CompressionFormat != binaryMessageEncodingBindingElement.CompressionFormat)
		{
			return false;
		}
		return true;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool ShouldSerializeReaderQuotas()
	{
		return !EncoderDefaults.IsDefaultReaderQuotas(ReaderQuotas);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool ShouldSerializeMessageVersion()
	{
		return !_messageVersion.IsMatch(MessageVersion.Default);
	}
}
