using System.ComponentModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Xml;

namespace System.ServiceModel;

public abstract class WSHttpBindingBase : Binding
{
	private OptionalReliableSession _reliableSession;

	private TextMessageEncodingBindingElement _textEncoding;

	private MtomMessageEncodingBindingElement _mtomEncoding;

	private ReliableSessionBindingElement _session;

	[DefaultValue(false)]
	public bool BypassProxyOnLocal
	{
		get
		{
			return HttpTransport.BypassProxyOnLocal;
		}
		set
		{
			HttpTransport.BypassProxyOnLocal = value;
			HttpsTransport.BypassProxyOnLocal = value;
		}
	}

	[DefaultValue(false)]
	public bool TransactionFlow
	{
		get
		{
			return false;
		}
		set
		{
			if (value)
			{
				throw ExceptionHelper.PlatformNotSupported();
			}
		}
	}

	[DefaultValue(524288L)]
	public long MaxBufferPoolSize
	{
		get
		{
			return HttpTransport.MaxBufferPoolSize;
		}
		set
		{
			HttpTransport.MaxBufferPoolSize = value;
			HttpsTransport.MaxBufferPoolSize = value;
		}
	}

	[DefaultValue(65536L)]
	public long MaxReceivedMessageSize
	{
		get
		{
			return HttpTransport.MaxReceivedMessageSize;
		}
		set
		{
			if (value > int.MaxValue)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("MaxReceivedMessageSize", System.SR.MaxReceivedMessageSizeMustBeInIntegerRange));
			}
			HttpTransport.MaxReceivedMessageSize = value;
			HttpsTransport.MaxReceivedMessageSize = value;
			_mtomEncoding.MaxBufferSize = (int)value;
		}
	}

	public WSMessageEncoding MessageEncoding { get; set; }

	[DefaultValue(null)]
	public Uri ProxyAddress
	{
		get
		{
			return HttpTransport.ProxyAddress;
		}
		set
		{
			HttpTransport.ProxyAddress = value;
			HttpsTransport.ProxyAddress = value;
		}
	}

	public XmlDictionaryReaderQuotas ReaderQuotas
	{
		get
		{
			return _textEncoding.ReaderQuotas;
		}
		set
		{
			if (value == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("value");
			}
			value.CopyTo(_textEncoding.ReaderQuotas);
			value.CopyTo(_mtomEncoding.ReaderQuotas);
		}
	}

	public OptionalReliableSession ReliableSession
	{
		get
		{
			return _reliableSession;
		}
		set
		{
			if (value == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("value"));
			}
			_reliableSession.CopySettings(value);
		}
	}

	public override string Scheme => GetTransport().Scheme;

	public EnvelopeVersion EnvelopeVersion => EnvelopeVersion.Soap12;

	public Encoding TextEncoding
	{
		get
		{
			return _textEncoding.WriteEncoding;
		}
		set
		{
			_textEncoding.WriteEncoding = value;
			_mtomEncoding.WriteEncoding = value;
		}
	}

	[DefaultValue(true)]
	public bool UseDefaultWebProxy
	{
		get
		{
			return HttpTransport.UseDefaultWebProxy;
		}
		set
		{
			HttpTransport.UseDefaultWebProxy = value;
			HttpsTransport.UseDefaultWebProxy = value;
		}
	}

	internal HttpTransportBindingElement HttpTransport { get; private set; }

	internal HttpsTransportBindingElement HttpsTransport { get; private set; }

	protected WSHttpBindingBase()
	{
		Initialize();
	}

	protected WSHttpBindingBase(bool reliableSessionEnabled)
		: this()
	{
		ReliableSession.Enabled = reliableSessionEnabled;
	}

	private void Initialize()
	{
		HttpTransport = new HttpTransportBindingElement();
		HttpsTransport = new HttpsTransportBindingElement();
		_session = new ReliableSessionBindingElement(ordered: true);
		_textEncoding = new TextMessageEncodingBindingElement();
		_textEncoding.MessageVersion = MessageVersion.Soap12WSAddressing10;
		_mtomEncoding = new MtomMessageEncodingBindingElement();
		_mtomEncoding.MessageVersion = MessageVersion.Soap12WSAddressing10;
		_reliableSession = new OptionalReliableSession(_session);
	}

	public override BindingElementCollection CreateBindingElements()
	{
		BindingElementCollection bindingElementCollection = new BindingElementCollection();
		if (_reliableSession.Enabled)
		{
			bindingElementCollection.Add(_session);
		}
		SecurityBindingElement securityBindingElement = CreateMessageSecurity();
		if (securityBindingElement != null)
		{
			bindingElementCollection.Add(securityBindingElement);
		}
		WSMessageEncodingHelper.SyncUpEncodingBindingElementProperties(_textEncoding, _mtomEncoding);
		if (MessageEncoding == WSMessageEncoding.Text)
		{
			bindingElementCollection.Add(_textEncoding);
		}
		else if (MessageEncoding == WSMessageEncoding.Mtom)
		{
			bindingElementCollection.Add(_mtomEncoding);
		}
		bindingElementCollection.Add(GetTransport());
		return bindingElementCollection.Clone();
	}

	protected abstract TransportBindingElement GetTransport();

	protected abstract SecurityBindingElement CreateMessageSecurity();
}
