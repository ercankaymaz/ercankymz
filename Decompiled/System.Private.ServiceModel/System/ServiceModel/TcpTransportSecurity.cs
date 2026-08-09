using System.ComponentModel;
using System.Net.Security;
using System.Security.Authentication;
using System.Security.Authentication.ExtendedProtection;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;

namespace System.ServiceModel;

public sealed class TcpTransportSecurity
{
	internal const TcpClientCredentialType DefaultClientCredentialType = TcpClientCredentialType.Windows;

	internal const ProtectionLevel DefaultProtectionLevel = ProtectionLevel.EncryptAndSign;

	private TcpClientCredentialType _clientCredentialType;

	private ProtectionLevel _protectionLevel;

	private ExtendedProtectionPolicy _extendedProtectionPolicy;

	private SslProtocols _sslProtocols;

	[DefaultValue(TcpClientCredentialType.Windows)]
	public TcpClientCredentialType ClientCredentialType
	{
		get
		{
			return _clientCredentialType;
		}
		set
		{
			if (!TcpClientCredentialTypeHelper.IsDefined(value))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value"));
			}
			_clientCredentialType = value;
		}
	}

	[DefaultValue(ProtectionLevel.EncryptAndSign)]
	public ProtectionLevel ProtectionLevel
	{
		get
		{
			return _protectionLevel;
		}
		set
		{
			if (!ProtectionLevelHelper.IsDefined(value))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value"));
			}
			_protectionLevel = value;
		}
	}

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

	[DefaultValue(SslProtocols.Tls | SslProtocols.Tls11 | SslProtocols.Tls12)]
	public SslProtocols SslProtocols
	{
		get
		{
			return _sslProtocols;
		}
		set
		{
			SslProtocolsHelper.Validate(value);
			_sslProtocols = value;
		}
	}

	public TcpTransportSecurity()
	{
		_clientCredentialType = TcpClientCredentialType.Windows;
		_protectionLevel = ProtectionLevel.EncryptAndSign;
		_extendedProtectionPolicy = ChannelBindingUtility.DefaultPolicy;
		_sslProtocols = SslProtocols.Tls | SslProtocols.Tls11 | SslProtocols.Tls12;
	}

	private SslStreamSecurityBindingElement CreateSslBindingElement(bool requireClientCertificate)
	{
		if (_protectionLevel != ProtectionLevel.EncryptAndSign)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.UnsupportedSslProtectionLevel, _protectionLevel)));
		}
		SslStreamSecurityBindingElement sslStreamSecurityBindingElement = new SslStreamSecurityBindingElement();
		sslStreamSecurityBindingElement.RequireClientCertificate = requireClientCertificate;
		sslStreamSecurityBindingElement.SslProtocols = _sslProtocols;
		return sslStreamSecurityBindingElement;
	}

	private static bool IsSslBindingElement(BindingElement element, TcpTransportSecurity transportSecurity)
	{
		if (!(element is SslStreamSecurityBindingElement))
		{
			return false;
		}
		transportSecurity.ProtectionLevel = ProtectionLevel.EncryptAndSign;
		return true;
	}

	internal BindingElement CreateTransportProtectionOnly()
	{
		return CreateSslBindingElement(requireClientCertificate: false);
	}

	internal static bool SetTransportProtectionOnly(BindingElement transport, TcpTransportSecurity transportSecurity)
	{
		return IsSslBindingElement(transport, transportSecurity);
	}

	internal BindingElement CreateTransportProtectionAndAuthentication()
	{
		if (_clientCredentialType == TcpClientCredentialType.Certificate || _clientCredentialType == TcpClientCredentialType.None)
		{
			return CreateSslBindingElement(_clientCredentialType == TcpClientCredentialType.Certificate);
		}
		WindowsStreamSecurityBindingElement windowsStreamSecurityBindingElement = new WindowsStreamSecurityBindingElement();
		windowsStreamSecurityBindingElement.ProtectionLevel = _protectionLevel;
		return windowsStreamSecurityBindingElement;
	}

	internal bool InternalShouldSerialize()
	{
		if (ClientCredentialType == TcpClientCredentialType.Windows)
		{
			return _protectionLevel != ProtectionLevel.EncryptAndSign;
		}
		return true;
	}
}
