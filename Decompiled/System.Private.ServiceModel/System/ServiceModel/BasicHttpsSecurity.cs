using System.ServiceModel.Channels;

namespace System.ServiceModel;

public sealed class BasicHttpsSecurity
{
	internal const BasicHttpsSecurityMode DefaultMode = BasicHttpsSecurityMode.Transport;

	public BasicHttpsSecurityMode Mode
	{
		get
		{
			return BasicHttpsSecurityModeHelper.ToBasicHttpsSecurityMode(BasicHttpSecurity.Mode);
		}
		set
		{
			if (!BasicHttpsSecurityModeHelper.IsDefined(value))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value"));
			}
			BasicHttpSecurity.Mode = BasicHttpsSecurityModeHelper.ToBasicHttpSecurityMode(value);
		}
	}

	public HttpTransportSecurity Transport
	{
		get
		{
			return BasicHttpSecurity.Transport;
		}
		set
		{
			BasicHttpSecurity.Transport = value;
		}
	}

	public BasicHttpMessageSecurity Message
	{
		get
		{
			return BasicHttpSecurity.Message;
		}
		set
		{
			BasicHttpSecurity.Message = value;
		}
	}

	internal BasicHttpSecurity BasicHttpSecurity { get; }

	public BasicHttpsSecurity()
		: this(BasicHttpsSecurityMode.Transport, new HttpTransportSecurity(), new BasicHttpMessageSecurity())
	{
	}

	private BasicHttpsSecurity(BasicHttpsSecurityMode mode, HttpTransportSecurity transportSecurity, BasicHttpMessageSecurity messageSecurity)
	{
		if (!BasicHttpsSecurityModeHelper.IsDefined(mode))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("mode"));
		}
		HttpTransportSecurity transport = ((transportSecurity == null) ? new HttpTransportSecurity() : transportSecurity);
		BasicHttpMessageSecurity message = ((messageSecurity == null) ? new BasicHttpMessageSecurity() : messageSecurity);
		BasicHttpSecurityMode mode2 = BasicHttpsSecurityModeHelper.ToBasicHttpSecurityMode(mode);
		BasicHttpSecurity = new BasicHttpSecurity
		{
			Mode = mode2,
			Transport = transport,
			Message = message
		};
	}

	internal static BasicHttpSecurity ToBasicHttpSecurity(BasicHttpsSecurity basicHttpsSecurity)
	{
		return new BasicHttpSecurity
		{
			Message = basicHttpsSecurity.Message,
			Transport = basicHttpsSecurity.Transport,
			Mode = BasicHttpsSecurityModeHelper.ToBasicHttpSecurityMode(basicHttpsSecurity.Mode)
		};
	}

	internal static BasicHttpsSecurity ToBasicHttpsSecurity(BasicHttpSecurity basicHttpSecurity)
	{
		return new BasicHttpsSecurity
		{
			Message = basicHttpSecurity.Message,
			Transport = basicHttpSecurity.Transport,
			Mode = BasicHttpsSecurityModeHelper.ToBasicHttpsSecurityMode(basicHttpSecurity.Mode)
		};
	}

	internal static void EnableTransportSecurity(HttpsTransportBindingElement https, HttpTransportSecurity transportSecurity)
	{
		BasicHttpSecurity.EnableTransportSecurity(https, transportSecurity);
	}

	internal static bool IsEnabledTransportAuthentication(HttpTransportBindingElement http, HttpTransportSecurity transportSecurity)
	{
		return BasicHttpSecurity.IsEnabledTransportAuthentication(http, transportSecurity);
	}

	internal void EnableTransportSecurity(HttpsTransportBindingElement https)
	{
		BasicHttpSecurity.EnableTransportSecurity(https);
	}

	internal void EnableTransportAuthentication(HttpTransportBindingElement http)
	{
		BasicHttpSecurity.EnableTransportAuthentication(http);
	}

	internal void DisableTransportAuthentication(HttpTransportBindingElement http)
	{
		BasicHttpSecurity.DisableTransportAuthentication(http);
	}

	internal SecurityBindingElement CreateMessageSecurity()
	{
		return BasicHttpSecurity.CreateMessageSecurity();
	}
}
