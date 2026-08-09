using System.ServiceModel.Channels;

namespace System.ServiceModel;

public sealed class BasicHttpSecurity
{
	internal const BasicHttpSecurityMode DefaultMode = BasicHttpSecurityMode.None;

	private BasicHttpSecurityMode _mode;

	private HttpTransportSecurity _transportSecurity;

	private BasicHttpMessageSecurity _messageSecurity;

	public BasicHttpSecurityMode Mode
	{
		get
		{
			return _mode;
		}
		set
		{
			if (value == BasicHttpSecurityMode.Message)
			{
				throw ExceptionHelper.PlatformNotSupported(System.SR.Format(System.SR.UnsupportedSecuritySetting, "value", value));
			}
			if (!BasicHttpSecurityModeHelper.IsDefined(value))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value"));
			}
			_mode = value;
		}
	}

	public HttpTransportSecurity Transport
	{
		get
		{
			return _transportSecurity;
		}
		set
		{
			_transportSecurity = ((value == null) ? new HttpTransportSecurity() : value);
		}
	}

	public BasicHttpMessageSecurity Message
	{
		get
		{
			return _messageSecurity;
		}
		set
		{
			_messageSecurity = ((value == null) ? new BasicHttpMessageSecurity() : value);
		}
	}

	public BasicHttpSecurity()
		: this(BasicHttpSecurityMode.None, new HttpTransportSecurity(), new BasicHttpMessageSecurity())
	{
	}

	private BasicHttpSecurity(BasicHttpSecurityMode mode, HttpTransportSecurity transportSecurity, BasicHttpMessageSecurity messageSecurity)
	{
		Mode = mode;
		_transportSecurity = ((transportSecurity == null) ? new HttpTransportSecurity() : transportSecurity);
		_messageSecurity = ((messageSecurity == null) ? new BasicHttpMessageSecurity() : messageSecurity);
	}

	internal void EnableTransportSecurity(HttpsTransportBindingElement https)
	{
		if (_mode == BasicHttpSecurityMode.TransportWithMessageCredential)
		{
			_transportSecurity.ConfigureTransportProtectionOnly(https);
		}
		else
		{
			_transportSecurity.ConfigureTransportProtectionAndAuthentication(https);
		}
	}

	internal static void EnableTransportSecurity(HttpsTransportBindingElement https, HttpTransportSecurity transportSecurity)
	{
		HttpTransportSecurity.ConfigureTransportProtectionAndAuthentication(https, transportSecurity);
	}

	internal void EnableTransportAuthentication(HttpTransportBindingElement http)
	{
		_transportSecurity.ConfigureTransportAuthentication(http);
	}

	internal static bool IsEnabledTransportAuthentication(HttpTransportBindingElement http, HttpTransportSecurity transportSecurity)
	{
		return HttpTransportSecurity.IsConfiguredTransportAuthentication(http, transportSecurity);
	}

	internal void DisableTransportAuthentication(HttpTransportBindingElement http)
	{
		_transportSecurity.DisableTransportAuthentication(http);
	}

	internal SecurityBindingElement CreateMessageSecurity()
	{
		if (_mode == BasicHttpSecurityMode.Message)
		{
			throw ExceptionHelper.PlatformNotSupported();
		}
		if (_mode == BasicHttpSecurityMode.TransportWithMessageCredential)
		{
			return _messageSecurity.CreateMessageSecurity(_mode == BasicHttpSecurityMode.TransportWithMessageCredential);
		}
		return null;
	}
}
