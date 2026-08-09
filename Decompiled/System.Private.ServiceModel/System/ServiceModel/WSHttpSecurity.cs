using System.ServiceModel.Channels;

namespace System.ServiceModel;

public sealed class WSHttpSecurity
{
	internal const SecurityMode DefaultMode = SecurityMode.Message;

	private SecurityMode _mode;

	private HttpTransportSecurity _transportSecurity;

	private NonDualMessageSecurityOverHttp _messageSecurity;

	public SecurityMode Mode
	{
		get
		{
			return _mode;
		}
		set
		{
			if (!SecurityModeHelper.IsDefined(value))
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
			_transportSecurity = value ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("value"));
		}
	}

	public NonDualMessageSecurityOverHttp Message
	{
		get
		{
			return _messageSecurity;
		}
		set
		{
			_messageSecurity = value ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("value"));
		}
	}

	public WSHttpSecurity()
		: this(SecurityMode.Message, GetDefaultHttpTransportSecurity(), new NonDualMessageSecurityOverHttp())
	{
	}

	internal WSHttpSecurity(SecurityMode mode, HttpTransportSecurity transportSecurity, NonDualMessageSecurityOverHttp messageSecurity)
	{
		_mode = mode;
		_transportSecurity = ((transportSecurity == null) ? GetDefaultHttpTransportSecurity() : transportSecurity);
		_messageSecurity = ((messageSecurity == null) ? new NonDualMessageSecurityOverHttp() : messageSecurity);
	}

	internal static HttpTransportSecurity GetDefaultHttpTransportSecurity()
	{
		return new HttpTransportSecurity
		{
			ClientCredentialType = HttpClientCredentialType.Windows
		};
	}

	internal void ApplyTransportSecurity(HttpsTransportBindingElement https)
	{
		if (_mode == SecurityMode.TransportWithMessageCredential)
		{
			_transportSecurity.ConfigureTransportProtectionOnly(https);
		}
		else
		{
			_transportSecurity.ConfigureTransportProtectionAndAuthentication(https);
		}
	}

	internal static void ApplyTransportSecurity(HttpsTransportBindingElement transport, HttpTransportSecurity transportSecurity)
	{
		HttpTransportSecurity.ConfigureTransportProtectionAndAuthentication(transport, transportSecurity);
	}

	internal SecurityBindingElement CreateMessageSecurity(bool isReliableSessionEnabled, MessageSecurityVersion version)
	{
		if (_mode == SecurityMode.Message || _mode == SecurityMode.TransportWithMessageCredential)
		{
			return _messageSecurity.CreateSecurityBindingElement(Mode == SecurityMode.TransportWithMessageCredential, isReliableSessionEnabled, version);
		}
		return null;
	}
}
