using System.ComponentModel;
using System.ServiceModel.Channels;
using System.Xml;

namespace System.ServiceModel;

public class NetTcpBinding : Binding
{
	private OptionalReliableSession reliableSession;

	private TcpTransportBindingElement _transport;

	private BinaryMessageEncodingBindingElement _encoding;

	private ReliableSessionBindingElement session;

	private NetTcpSecurity _security = new NetTcpSecurity();

	[DefaultValue(TransferMode.Buffered)]
	public TransferMode TransferMode
	{
		get
		{
			return _transport.TransferMode;
		}
		set
		{
			_transport.TransferMode = value;
		}
	}

	[DefaultValue(524288L)]
	public long MaxBufferPoolSize { get; set; }

	[DefaultValue(65536)]
	public int MaxBufferSize
	{
		get
		{
			return _transport.MaxBufferSize;
		}
		set
		{
			_transport.MaxBufferSize = value;
		}
	}

	[DefaultValue(65536L)]
	public long MaxReceivedMessageSize
	{
		get
		{
			return _transport.MaxReceivedMessageSize;
		}
		set
		{
			_transport.MaxReceivedMessageSize = value;
		}
	}

	public XmlDictionaryReaderQuotas ReaderQuotas
	{
		get
		{
			return _encoding.ReaderQuotas;
		}
		set
		{
			if (value == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("value");
			}
			value.CopyTo(_encoding.ReaderQuotas);
		}
	}

	public OptionalReliableSession ReliableSession
	{
		get
		{
			return reliableSession;
		}
		set
		{
			if (value == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("value"));
			}
			reliableSession.CopySettings(value);
		}
	}

	public override string Scheme => _transport.Scheme;

	public EnvelopeVersion EnvelopeVersion => EnvelopeVersion.Soap12;

	public NetTcpSecurity Security
	{
		get
		{
			return _security;
		}
		set
		{
			_security = value ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("value");
		}
	}

	public NetTcpBinding()
	{
		Initialize();
	}

	public NetTcpBinding(SecurityMode securityMode)
		: this()
	{
		_security.Mode = securityMode;
	}

	public NetTcpBinding(SecurityMode securityMode, bool reliableSessionEnabled)
		: this(securityMode)
	{
		ReliableSession.Enabled = reliableSessionEnabled;
	}

	public NetTcpBinding(string configurationName)
		: this()
	{
		if (!string.IsNullOrEmpty(configurationName))
		{
			throw ExceptionHelper.PlatformNotSupported();
		}
	}

	private void Initialize()
	{
		_transport = new TcpTransportBindingElement();
		_encoding = new BinaryMessageEncodingBindingElement();
		MaxBufferPoolSize = 524288L;
		session = new ReliableSessionBindingElement();
		reliableSession = new OptionalReliableSession(session);
	}

	private void CheckSettings()
	{
	}

	public override BindingElementCollection CreateBindingElements()
	{
		CheckSettings();
		BindingElementCollection bindingElementCollection = new BindingElementCollection();
		if (reliableSession.Enabled)
		{
			bindingElementCollection.Add(session);
		}
		SecurityBindingElement securityBindingElement = CreateMessageSecurity();
		if (securityBindingElement != null)
		{
			bindingElementCollection.Add(securityBindingElement);
		}
		bindingElementCollection.Add(_encoding);
		BindingElement bindingElement = CreateTransportSecurity();
		if (bindingElement != null)
		{
			bindingElementCollection.Add(bindingElement);
		}
		_transport.ExtendedProtectionPolicy = _security.Transport.ExtendedProtectionPolicy;
		bindingElementCollection.Add(_transport);
		return bindingElementCollection.Clone();
	}

	private BindingElement CreateTransportSecurity()
	{
		return _security.CreateTransportSecurity();
	}

	private SecurityBindingElement CreateMessageSecurity()
	{
		if (_security.Mode == SecurityMode.Message)
		{
			throw ExceptionHelper.PlatformNotSupported("Message");
		}
		if (_security.Mode == SecurityMode.TransportWithMessageCredential)
		{
			return _security.CreateMessageSecurity(ReliableSession.Enabled);
		}
		return null;
	}
}
