using System.ComponentModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Xml;

namespace System.ServiceModel;

public abstract class HttpBindingBase : Binding, IBindingRuntimePreferences
{
	private HttpTransportBindingElement _httpTransport;

	private HttpsTransportBindingElement _httpsTransport;

	[DefaultValue(false)]
	public bool AllowCookies
	{
		get
		{
			return _httpTransport.AllowCookies;
		}
		set
		{
			_httpTransport.AllowCookies = value;
			_httpsTransport.AllowCookies = value;
		}
	}

	[DefaultValue(false)]
	public bool BypassProxyOnLocal
	{
		get
		{
			return _httpTransport.BypassProxyOnLocal;
		}
		set
		{
			_httpTransport.BypassProxyOnLocal = value;
			_httpsTransport.BypassProxyOnLocal = value;
		}
	}

	[DefaultValue(HostNameComparisonMode.StrongWildcard)]
	public HostNameComparisonMode HostNameComparisonMode
	{
		get
		{
			return _httpTransport.HostNameComparisonMode;
		}
		set
		{
			_httpTransport.HostNameComparisonMode = value;
			_httpsTransport.HostNameComparisonMode = value;
		}
	}

	[DefaultValue(65536)]
	public int MaxBufferSize
	{
		get
		{
			return _httpTransport.MaxBufferSize;
		}
		set
		{
			_httpTransport.MaxBufferSize = value;
			_httpsTransport.MaxBufferSize = value;
			MtomMessageEncodingBindingElement.MaxBufferSize = value;
		}
	}

	[DefaultValue(524288L)]
	public long MaxBufferPoolSize
	{
		get
		{
			return _httpTransport.MaxBufferPoolSize;
		}
		set
		{
			_httpTransport.MaxBufferPoolSize = value;
			_httpsTransport.MaxBufferPoolSize = value;
		}
	}

	[DefaultValue(65536L)]
	public long MaxReceivedMessageSize
	{
		get
		{
			return _httpTransport.MaxReceivedMessageSize;
		}
		set
		{
			_httpTransport.MaxReceivedMessageSize = value;
			_httpsTransport.MaxReceivedMessageSize = value;
		}
	}

	[DefaultValue(null)]
	[TypeConverter(typeof(UriTypeConverter))]
	public Uri ProxyAddress
	{
		get
		{
			return _httpTransport.ProxyAddress;
		}
		set
		{
			_httpTransport.ProxyAddress = value;
			_httpsTransport.ProxyAddress = value;
		}
	}

	public XmlDictionaryReaderQuotas ReaderQuotas
	{
		get
		{
			return TextMessageEncodingBindingElement.ReaderQuotas;
		}
		set
		{
			if (value == null)
			{
				throw FxTrace.Exception.ArgumentNull("value");
			}
			value.CopyTo(TextMessageEncodingBindingElement.ReaderQuotas);
			value.CopyTo(MtomMessageEncodingBindingElement.ReaderQuotas);
			SetReaderQuotas(value);
		}
	}

	public override string Scheme => GetTransport().Scheme;

	public EnvelopeVersion EnvelopeVersion => GetEnvelopeVersion();

	public Encoding TextEncoding
	{
		get
		{
			return TextMessageEncodingBindingElement.WriteEncoding;
		}
		set
		{
			TextMessageEncodingBindingElement.WriteEncoding = value;
			MtomMessageEncodingBindingElement.WriteEncoding = value;
		}
	}

	[DefaultValue(TransferMode.Buffered)]
	public TransferMode TransferMode
	{
		get
		{
			return _httpTransport.TransferMode;
		}
		set
		{
			_httpTransport.TransferMode = value;
			_httpsTransport.TransferMode = value;
		}
	}

	[DefaultValue(true)]
	public bool UseDefaultWebProxy
	{
		get
		{
			return _httpTransport.UseDefaultWebProxy;
		}
		set
		{
			_httpTransport.UseDefaultWebProxy = value;
			_httpsTransport.UseDefaultWebProxy = value;
		}
	}

	bool IBindingRuntimePreferences.ReceiveSynchronously => false;

	internal TextMessageEncodingBindingElement TextMessageEncodingBindingElement { get; }

	internal MtomMessageEncodingBindingElement MtomMessageEncodingBindingElement { get; }

	internal abstract BasicHttpSecurity BasicHttpSecurity { get; }

	internal WebSocketTransportSettings InternalWebSocketSettings => _httpTransport.WebSocketSettings;

	internal HttpBindingBase()
	{
		_httpTransport = new HttpTransportBindingElement();
		_httpsTransport = new HttpsTransportBindingElement();
		TextMessageEncodingBindingElement = new TextMessageEncodingBindingElement();
		TextMessageEncodingBindingElement.MessageVersion = MessageVersion.Soap11;
		MtomMessageEncodingBindingElement = new MtomMessageEncodingBindingElement();
		MtomMessageEncodingBindingElement.MessageVersion = MessageVersion.Soap11;
		_httpsTransport.WebSocketSettings = _httpTransport.WebSocketSettings;
	}

	internal static bool GetSecurityModeFromTransport(HttpTransportBindingElement http, HttpTransportSecurity transportSecurity, out UnifiedSecurityMode mode)
	{
		mode = UnifiedSecurityMode.None;
		if (http == null)
		{
			return false;
		}
		if (http is HttpsTransportBindingElement)
		{
			mode = UnifiedSecurityMode.Transport | UnifiedSecurityMode.TransportWithMessageCredential;
			BasicHttpSecurity.EnableTransportSecurity((HttpsTransportBindingElement)http, transportSecurity);
		}
		else if (HttpTransportSecurity.IsDisabledTransportAuthentication(http))
		{
			mode = UnifiedSecurityMode.None | UnifiedSecurityMode.Message;
		}
		else
		{
			if (!BasicHttpSecurity.IsEnabledTransportAuthentication(http, transportSecurity))
			{
				return false;
			}
			mode = UnifiedSecurityMode.TransportCredentialOnly;
		}
		return true;
	}

	internal TransportBindingElement GetTransport()
	{
		BasicHttpSecurity basicHttpSecurity = BasicHttpSecurity;
		if (basicHttpSecurity.Mode == BasicHttpSecurityMode.Transport || basicHttpSecurity.Mode == BasicHttpSecurityMode.TransportWithMessageCredential)
		{
			basicHttpSecurity.EnableTransportSecurity(_httpsTransport);
			return _httpsTransport;
		}
		if (basicHttpSecurity.Mode == BasicHttpSecurityMode.TransportCredentialOnly)
		{
			basicHttpSecurity.EnableTransportAuthentication(_httpTransport);
			return _httpTransport;
		}
		basicHttpSecurity.DisableTransportAuthentication(_httpTransport);
		return _httpTransport;
	}

	internal abstract EnvelopeVersion GetEnvelopeVersion();

	internal virtual void SetReaderQuotas(XmlDictionaryReaderQuotas readerQuotas)
	{
	}

	internal virtual void CheckSettings()
	{
		BasicHttpSecurity basicHttpSecurity = BasicHttpSecurity;
		if (basicHttpSecurity == null)
		{
			return;
		}
		BasicHttpSecurityMode mode = basicHttpSecurity.Mode;
		switch (mode)
		{
		case BasicHttpSecurityMode.None:
			return;
		case BasicHttpSecurityMode.Message:
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException(System.SR.Format(System.SR.UnsupportedSecuritySetting, "Mode", mode)));
		}
		HttpTransportSecurity transport = basicHttpSecurity.Transport;
		if (transport == null || transport.ClientCredentialType != HttpClientCredentialType.InheritedFromHost)
		{
			return;
		}
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException(System.SR.Format(System.SR.UnsupportedSecuritySetting, "Transport.ClientCredentialType", transport.ClientCredentialType)));
	}
}
