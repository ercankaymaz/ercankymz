using System.ServiceModel.Channels;
using System.Xml;

namespace System.ServiceModel;

public class NetHttpsBinding : HttpBindingBase
{
	private BinaryMessageEncodingBindingElement _binaryMessageEncodingBindingElement;

	private ReliableSessionBindingElement _session;

	private OptionalReliableSession _reliableSession;

	private BasicHttpsSecurity _basicHttpsSecurity;

	public NetHttpMessageEncoding MessageEncoding { get; set; }

	public BasicHttpsSecurity Security
	{
		get
		{
			return _basicHttpsSecurity;
		}
		set
		{
			_basicHttpsSecurity = value ?? throw FxTrace.Exception.ArgumentNull("value");
		}
	}

	internal override BasicHttpSecurity BasicHttpSecurity => _basicHttpsSecurity.BasicHttpSecurity;

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
				throw FxTrace.Exception.ArgumentNull("value");
			}
			_reliableSession.CopySettings(value);
		}
	}

	public WebSocketTransportSettings WebSocketSettings => base.InternalWebSocketSettings;

	public NetHttpsBinding()
		: this(BasicHttpsSecurityMode.Transport)
	{
	}

	public NetHttpsBinding(BasicHttpsSecurityMode securityMode)
	{
		if (securityMode == BasicHttpsSecurityMode.TransportWithMessageCredential)
		{
			throw ExceptionHelper.PlatformNotSupported(System.SR.Format(System.SR.UnsupportedSecuritySetting, "securityMode", securityMode));
		}
		Initialize();
		_basicHttpsSecurity.Mode = securityMode;
	}

	public NetHttpsBinding(BasicHttpsSecurityMode securityMode, bool reliableSessionEnabled)
		: this(securityMode)
	{
		ReliableSession.Enabled = reliableSessionEnabled;
	}

	public override IChannelFactory<TChannel> BuildChannelFactory<TChannel>(BindingParameterCollection parameters)
	{
		if ((BasicHttpSecurity.Mode == BasicHttpSecurityMode.Transport || BasicHttpSecurity.Mode == BasicHttpSecurityMode.TransportCredentialOnly) && BasicHttpSecurity.Transport.ClientCredentialType == HttpClientCredentialType.InheritedFromHost)
		{
			throw FxTrace.Exception.AsError(new InvalidOperationException(System.SR.Format(System.SR.HttpClientCredentialTypeInvalid, BasicHttpSecurity.Transport.ClientCredentialType)));
		}
		return base.BuildChannelFactory<TChannel>(parameters);
	}

	public override BindingElementCollection CreateBindingElements()
	{
		CheckSettings();
		BindingElementCollection bindingElementCollection = new BindingElementCollection();
		if (_reliableSession.Enabled)
		{
			bindingElementCollection.Add(_session);
		}
		SecurityBindingElement securityBindingElement = BasicHttpSecurity.CreateMessageSecurity();
		if (securityBindingElement != null)
		{
			bindingElementCollection.Add(securityBindingElement);
		}
		switch (MessageEncoding)
		{
		case NetHttpMessageEncoding.Text:
			bindingElementCollection.Add(base.TextMessageEncodingBindingElement);
			break;
		case NetHttpMessageEncoding.Mtom:
			bindingElementCollection.Add(base.MtomMessageEncodingBindingElement);
			break;
		default:
			bindingElementCollection.Add(_binaryMessageEncodingBindingElement);
			break;
		}
		bindingElementCollection.Add(GetTransport());
		return bindingElementCollection.Clone();
	}

	internal override void SetReaderQuotas(XmlDictionaryReaderQuotas readerQuotas)
	{
		readerQuotas.CopyTo(_binaryMessageEncodingBindingElement.ReaderQuotas);
	}

	internal override EnvelopeVersion GetEnvelopeVersion()
	{
		return EnvelopeVersion.Soap12;
	}

	private void Initialize()
	{
		MessageEncoding = NetHttpMessageEncoding.Binary;
		_binaryMessageEncodingBindingElement = new BinaryMessageEncodingBindingElement
		{
			MessageVersion = MessageVersion.Soap12WSAddressing10
		};
		base.TextMessageEncodingBindingElement.MessageVersion = MessageVersion.Soap12WSAddressing10;
		base.MtomMessageEncodingBindingElement.MessageVersion = MessageVersion.Soap12WSAddressing10;
		_session = new ReliableSessionBindingElement();
		_reliableSession = new OptionalReliableSession(_session);
		base.InternalWebSocketSettings.TransportUsage = WebSocketTransportUsage.WhenDuplex;
		base.InternalWebSocketSettings.SubProtocol = "soap";
		_basicHttpsSecurity = new BasicHttpsSecurity();
	}
}
