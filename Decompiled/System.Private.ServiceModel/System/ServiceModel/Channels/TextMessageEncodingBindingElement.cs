using System.ComponentModel;
using System.Text;
using System.Xml;

namespace System.ServiceModel.Channels;

public sealed class TextMessageEncodingBindingElement : MessageEncodingBindingElement
{
	private int _maxReadPoolSize;

	private int _maxWritePoolSize;

	private XmlDictionaryReaderQuotas _readerQuotas;

	private MessageVersion _messageVersion;

	private Encoding _writeEncoding;

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

	public override MessageVersion MessageVersion
	{
		get
		{
			return _messageVersion;
		}
		set
		{
			_messageVersion = value ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("value");
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

	public TextMessageEncodingBindingElement()
		: this(MessageVersion.Default, TextEncoderDefaults.Encoding)
	{
	}

	public TextMessageEncodingBindingElement(MessageVersion messageVersion, Encoding writeEncoding)
	{
		if (writeEncoding == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("writeEncoding");
		}
		TextEncoderDefaults.ValidateEncoding(writeEncoding);
		_maxReadPoolSize = 64;
		_maxWritePoolSize = 16;
		_readerQuotas = new XmlDictionaryReaderQuotas();
		EncoderDefaults.ReaderQuotas.CopyTo(_readerQuotas);
		_messageVersion = messageVersion ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("messageVersion");
		_writeEncoding = writeEncoding;
	}

	private TextMessageEncodingBindingElement(TextMessageEncodingBindingElement elementToBeCloned)
		: base(elementToBeCloned)
	{
		_maxReadPoolSize = elementToBeCloned._maxReadPoolSize;
		_maxWritePoolSize = elementToBeCloned._maxWritePoolSize;
		_readerQuotas = new XmlDictionaryReaderQuotas();
		elementToBeCloned._readerQuotas.CopyTo(_readerQuotas);
		_writeEncoding = elementToBeCloned._writeEncoding;
		_messageVersion = elementToBeCloned._messageVersion;
	}

	public override IChannelFactory<TChannel> BuildChannelFactory<TChannel>(BindingContext context)
	{
		return InternalBuildChannelFactory<TChannel>(context);
	}

	public override BindingElement Clone()
	{
		return new TextMessageEncodingBindingElement(this);
	}

	public override MessageEncoderFactory CreateMessageEncoderFactory()
	{
		return new TextMessageEncoderFactory(MessageVersion, WriteEncoding, MaxReadPoolSize, MaxWritePoolSize, ReaderQuotas);
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
		if (!(b is TextMessageEncodingBindingElement textMessageEncodingBindingElement))
		{
			return false;
		}
		if (_maxReadPoolSize != textMessageEncodingBindingElement.MaxReadPoolSize)
		{
			return false;
		}
		if (_maxWritePoolSize != textMessageEncodingBindingElement.MaxWritePoolSize)
		{
			return false;
		}
		if (_readerQuotas.MaxStringContentLength != textMessageEncodingBindingElement.ReaderQuotas.MaxStringContentLength)
		{
			return false;
		}
		if (_readerQuotas.MaxArrayLength != textMessageEncodingBindingElement.ReaderQuotas.MaxArrayLength)
		{
			return false;
		}
		if (_readerQuotas.MaxBytesPerRead != textMessageEncodingBindingElement.ReaderQuotas.MaxBytesPerRead)
		{
			return false;
		}
		if (_readerQuotas.MaxDepth != textMessageEncodingBindingElement.ReaderQuotas.MaxDepth)
		{
			return false;
		}
		if (_readerQuotas.MaxNameTableCharCount != textMessageEncodingBindingElement.ReaderQuotas.MaxNameTableCharCount)
		{
			return false;
		}
		if (WriteEncoding.WebName != textMessageEncodingBindingElement.WriteEncoding.WebName)
		{
			return false;
		}
		if (!MessageVersion.IsMatch(textMessageEncodingBindingElement.MessageVersion))
		{
			return false;
		}
		return true;
	}
}
