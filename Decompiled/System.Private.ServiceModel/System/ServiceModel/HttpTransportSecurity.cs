using System.Net;
using System.Security.Authentication.ExtendedProtection;
using System.ServiceModel.Channels;

namespace System.ServiceModel;

public sealed class HttpTransportSecurity
{
	internal const HttpClientCredentialType DefaultClientCredentialType = HttpClientCredentialType.None;

	internal const HttpProxyCredentialType DefaultProxyCredentialType = HttpProxyCredentialType.None;

	internal const string DefaultRealm = "";

	private HttpClientCredentialType _clientCredentialType;

	private HttpProxyCredentialType _proxyCredentialType;

	private ExtendedProtectionPolicy _extendedProtectionPolicy;

	public HttpClientCredentialType ClientCredentialType
	{
		get
		{
			return _clientCredentialType;
		}
		set
		{
			if (!HttpClientCredentialTypeHelper.IsDefined(value))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value"));
			}
			_clientCredentialType = value;
		}
	}

	public HttpProxyCredentialType ProxyCredentialType
	{
		get
		{
			return _proxyCredentialType;
		}
		set
		{
			if (!HttpProxyCredentialTypeHelper.IsDefined(value))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value"));
			}
			_proxyCredentialType = value;
		}
	}

	public string Realm { get; set; }

	public ExtendedProtectionPolicy ExtendedProtectionPolicy
	{
		get
		{
			return _extendedProtectionPolicy;
		}
		set
		{
			if (value == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("value");
			}
			if (value.PolicyEnforcement == PolicyEnforcement.Always && !ExtendedProtectionPolicy.OSSupportsExtendedProtection)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new PlatformNotSupportedException(System.SR.ExtendedProtectionNotSupported));
			}
			_extendedProtectionPolicy = value;
		}
	}

	public HttpTransportSecurity()
	{
		_clientCredentialType = HttpClientCredentialType.None;
		_proxyCredentialType = HttpProxyCredentialType.None;
		Realm = "";
		_extendedProtectionPolicy = ChannelBindingUtility.DefaultPolicy;
	}

	internal void ConfigureTransportProtectionOnly(HttpsTransportBindingElement https)
	{
		DisableAuthentication(https);
		https.RequireClientCertificate = false;
	}

	private void ConfigureAuthentication(HttpTransportBindingElement http)
	{
		http.AuthenticationScheme = HttpClientCredentialTypeHelper.MapToAuthenticationScheme(_clientCredentialType);
		http.ProxyAuthenticationScheme = HttpProxyCredentialTypeHelper.MapToAuthenticationScheme(_proxyCredentialType);
		http.Realm = Realm;
		http.ExtendedProtectionPolicy = ExtendedProtectionPolicy;
	}

	private static void ConfigureAuthentication(HttpTransportBindingElement http, HttpTransportSecurity transportSecurity)
	{
		transportSecurity._clientCredentialType = HttpClientCredentialTypeHelper.MapToClientCredentialType(http.AuthenticationScheme);
		transportSecurity._proxyCredentialType = HttpProxyCredentialTypeHelper.MapToProxyCredentialType(http.ProxyAuthenticationScheme);
		transportSecurity.Realm = http.Realm;
		transportSecurity._extendedProtectionPolicy = http.ExtendedProtectionPolicy;
	}

	private void DisableAuthentication(HttpTransportBindingElement http)
	{
		http.AuthenticationScheme = AuthenticationSchemes.Anonymous;
		http.Realm = "";
	}

	private static bool IsDisabledAuthentication(HttpTransportBindingElement http)
	{
		if (http.AuthenticationScheme == AuthenticationSchemes.Anonymous)
		{
			return http.Realm == "";
		}
		return false;
	}

	internal void ConfigureTransportProtectionAndAuthentication(HttpsTransportBindingElement https)
	{
		ConfigureAuthentication(https);
		https.RequireClientCertificate = _clientCredentialType == HttpClientCredentialType.Certificate;
	}

	public static void ConfigureTransportProtectionAndAuthentication(HttpsTransportBindingElement https, HttpTransportSecurity transportSecurity)
	{
		ConfigureAuthentication(https, transportSecurity);
		if (https.RequireClientCertificate)
		{
			transportSecurity.ClientCredentialType = HttpClientCredentialType.Certificate;
		}
	}

	internal void ConfigureTransportAuthentication(HttpTransportBindingElement http)
	{
		if (_clientCredentialType == HttpClientCredentialType.Certificate)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.CertificateUnsupportedForHttpTransportCredentialOnly));
		}
		ConfigureAuthentication(http);
	}

	internal static bool IsConfiguredTransportAuthentication(HttpTransportBindingElement http, HttpTransportSecurity transportSecurity)
	{
		if (HttpClientCredentialTypeHelper.MapToClientCredentialType(http.AuthenticationScheme) == HttpClientCredentialType.Certificate)
		{
			return false;
		}
		ConfigureAuthentication(http, transportSecurity);
		return true;
	}

	internal void DisableTransportAuthentication(HttpTransportBindingElement http)
	{
		DisableAuthentication(http);
	}

	internal static bool IsDisabledTransportAuthentication(HttpTransportBindingElement http)
	{
		return IsDisabledAuthentication(http);
	}
}
