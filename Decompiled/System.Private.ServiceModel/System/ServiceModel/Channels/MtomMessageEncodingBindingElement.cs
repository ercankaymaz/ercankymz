using System.ComponentModel;
using System.Text;
using System.Xml;

namespace System.ServiceModel.Channels;

public sealed class MtomMessageEncodingBindingElement : MessageEncodingBindingElement
{
	private int _maxReadPoolSize;

	private int _maxWritePoolSize;

	private XmlDictionaryReaderQuotas _readerQuotas;

	private int _maxBufferSize;

	private Encoding _writeEncoding;

	private MessageVersion _messageVersion;

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

	public XmlDictionaryReaderQuotas ReaderQuotas => _readerQuotas;

	[DefaultValue(65536)]
	public int MaxBufferSize
	{
		get
		{
			return _maxBufferSize;
		}
		set
		{
			if (value <= 0)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value", value, System.SR.ValueMustBePositive));
			}
			_maxBufferSize = value;
		}
	}

	public Encoding WriteEncoding
	{
		get
		{
			return _writeEncoding;
		}
		set
		{
			if (value == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("value");
			}
			TextEncoderDefaults.ValidateEncoding(value);
			_writeEncoding = value;
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
			if (value == MessageVersion.None)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentException(System.SR.Format(System.SR.MtomEncoderBadMessageVersion, value.ToString()), "value"));
			}
			_messageVersion = value;
		}
	}

	public MtomMessageEncodingBindingElement()
		: this(MessageVersion.Default, TextEncoderDefaults.Encoding)
	{
	}

	public MtomMessageEncodingBindingElement(MessageVersion messageVersion, Encoding writeEncoding)
	{
		if (messageVersion == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("messageVersion");
		}
		if (messageVersion == MessageVersion.None)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentException(System.SR.Format(System.SR.MtomEncoderBadMessageVersion, messageVersion.ToString()), "messageVersion"));
		}
		if (writeEncoding == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("writeEncoding");
		}
		TextEncoderDefaults.ValidateEncoding(writeEncoding);
		_maxReadPoolSize = 64;
		_maxWritePoolSize = 16;
		_readerQuotas = new XmlDictionaryReaderQuotas();
		EncoderDefaults.ReaderQuotas.CopyTo(_readerQuotas);
		_maxBufferSize = 65536;
		_messageVersion = messageVersion;
		_writeEncoding = writeEncoding;
	}

	private MtomMessageEncodingBindingElement(MtomMessageEncodingBindingElement elementToBeCloned)
		: base(elementToBeCloned)
	{
		_maxReadPoolSize = elementToBeCloned._maxReadPoolSize;
		_maxWritePoolSize = elementToBeCloned._maxWritePoolSize;
		_readerQuotas = new XmlDictionaryReaderQuotas();
		elementToBeCloned._readerQuotas.CopyTo(_readerQuotas);
		_maxBufferSize = elementToBeCloned._maxBufferSize;
		_writeEncoding = elementToBeCloned._writeEncoding;
		_messageVersion = elementToBeCloned._messageVersion;
	}

	public override IChannelFactory<TChannel> BuildChannelFactory<TChannel>(BindingContext context)
	{
		return InternalBuildChannelFactory<TChannel>(context);
	}

	public override bool CanBuildChannelFactory<TChannel>(BindingContext context)
	{
		return InternalCanBuildChannelFactory<TChannel>(context);
	}

	public override BindingElement Clone()
	{
		return new MtomMessageEncodingBindingElement(this);
	}

	public override MessageEncoderFactory CreateMessageEncoderFactory()
	{
		return new MtomMessageEncoderFactory(MessageVersion, WriteEncoding, MaxReadPoolSize, MaxWritePoolSize, MaxBufferSize, ReaderQuotas);
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

	internal override bool CheckEncodingVersion(EnvelopeVersion version)
	{
		return _messageVersion.Envelope == version;
	}

	internal override bool IsMatch(BindingElement b)
	{
		if (!base.IsMatch(b))
		{
			return false;
		}
		if (!(b is MtomMessageEncodingBindingElement mtomMessageEncodingBindingElement))
		{
			return false;
		}
		if (_maxReadPoolSize != mtomMessageEncodingBindingElement.MaxReadPoolSize)
		{
			return false;
		}
		if (_maxWritePoolSize != mtomMessageEncodingBindingElement.MaxWritePoolSize)
		{
			return false;
		}
		if (_readerQuotas.MaxStringContentLength != mtomMessageEncodingBindingElement.ReaderQuotas.MaxStringContentLength)
		{
			return false;
		}
		if (_readerQuotas.MaxArrayLength != mtomMessageEncodingBindingElement.ReaderQuotas.MaxArrayLength)
		{
			return false;
		}
		if (_readerQuotas.MaxBytesPerRead != mtomMessageEncodingBindingElement.ReaderQuotas.MaxBytesPerRead)
		{
			return false;
		}
		if (_readerQuotas.MaxDepth != mtomMessageEncodingBindingElement.ReaderQuotas.MaxDepth)
		{
			return false;
		}
		if (_readerQuotas.MaxNameTableCharCount != mtomMessageEncodingBindingElement.ReaderQuotas.MaxNameTableCharCount)
		{
			return false;
		}
		if (_maxBufferSize != mtomMessageEncodingBindingElement.MaxBufferSize)
		{
			return false;
		}
		if (WriteEncoding.EncodingName != mtomMessageEncodingBindingElement.WriteEncoding.EncodingName)
		{
			return false;
		}
		if (!MessageVersion.IsMatch(mtomMessageEncodingBindingElement.MessageVersion))
		{
			return false;
		}
		return true;
	}
}
