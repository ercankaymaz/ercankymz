using System.ComponentModel;
using System.ServiceModel.Channels;
using System.Xml;

namespace System.ServiceModel;

public class NetHttpBinding : HttpBindingBase
{
	private BinaryMessageEncodingBindingElement _binaryMessageEncodingBindingElement;

	private ReliableSessionBindingElement _session;

	private OptionalReliableSession _reliableSession;

	private BasicHttpSecurity _basicHttpSecurity;

	[DefaultValue(NetHttpMessageEncoding.Binary)]
	public NetHttpMessageEncoding MessageEncoding { get; set; }

	public BasicHttpSecurity Security
	{
		get
		{
			return _basicHttpSecurity;
		}
		set
		{
			_basicHttpSecurity = value ?? throw FxTrace.Exception.ArgumentNull("value");
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
				throw FxTrace.Exception.ArgumentNull("value");
			}
			_reliableSession.CopySettings(value);
		}
	}

	public WebSocketTransportSettings WebSocketSettings => base.InternalWebSocketSettings;

	internal override BasicHttpSecurity BasicHttpSecurity => _basicHttpSecurity;

	public NetHttpBinding()
		: this(BasicHttpSecurityMode.None)
	{
	}

	public NetHttpBinding(BasicHttpSecurityMode securityMode)
	{
		Initialize();
		_basicHttpSecurity.Mode = securityMode;
	}

	public NetHttpBinding(BasicHttpSecurityMode securityMode, bool reliableSessionEnabled)
		: this(securityMode)
	{
		ReliableSession.Enabled = reliableSessionEnabled;
	}

	public NetHttpBinding(string configurationName)
	{
		Initialize();
	}

	private NetHttpBinding(BasicHttpSecurity security)
	{
		Initialize();
		_basicHttpSecurity = security;
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
		WebSocketSettings.TransportUsage = WebSocketTransportUsage.WhenDuplex;
		WebSocketSettings.SubProtocol = "soap";
		_basicHttpSecurity = new BasicHttpSecurity();
	}
}
