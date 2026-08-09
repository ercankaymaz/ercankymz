using System.ComponentModel;
using System.Net.Security;
using System.Security.Authentication;
using System.ServiceModel.Security;

namespace System.ServiceModel.Channels;

public class SslStreamSecurityBindingElement : StreamUpgradeBindingElement
{
	private IdentityVerifier _identityVerifier;

	private SslProtocols _sslProtocols;

	public IdentityVerifier IdentityVerifier
	{
		get
		{
			if (_identityVerifier == null)
			{
				_identityVerifier = IdentityVerifier.CreateDefault();
			}
			return _identityVerifier;
		}
		set
		{
			_identityVerifier = value ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("value");
		}
	}

	[DefaultValue(false)]
	public bool RequireClientCertificate { get; set; }

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

	public SslStreamSecurityBindingElement()
	{
		RequireClientCertificate = false;
		_sslProtocols = SslProtocols.Tls | SslProtocols.Tls11 | SslProtocols.Tls12;
	}

	protected SslStreamSecurityBindingElement(SslStreamSecurityBindingElement elementToBeCloned)
		: base(elementToBeCloned)
	{
		_identityVerifier = elementToBeCloned._identityVerifier;
		RequireClientCertificate = elementToBeCloned.RequireClientCertificate;
		_sslProtocols = elementToBeCloned._sslProtocols;
	}

	public override IChannelFactory<TChannel> BuildChannelFactory<TChannel>(BindingContext context)
	{
		if (context == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("context");
		}
		context.BindingParameters.Add(this);
		return context.BuildInnerChannelFactory<TChannel>();
	}

	public override bool CanBuildChannelFactory<TChannel>(BindingContext context)
	{
		if (context == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("context");
		}
		context.BindingParameters.Add(this);
		return context.CanBuildInnerChannelFactory<TChannel>();
	}

	public override BindingElement Clone()
	{
		return new SslStreamSecurityBindingElement(this);
	}

	public override T GetProperty<T>(BindingContext context)
	{
		if (context == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("context");
		}
		if (typeof(T) == typeof(ISecurityCapabilities))
		{
			return (T)(object)new SecurityCapabilities(RequireClientCertificate, supportsServerAuth: true, RequireClientCertificate, ProtectionLevel.EncryptAndSign, ProtectionLevel.EncryptAndSign);
		}
		if (typeof(T) == typeof(IdentityVerifier))
		{
			return (T)(object)IdentityVerifier;
		}
		return context.GetInnerProperty<T>();
	}

	public override StreamUpgradeProvider BuildClientStreamUpgradeProvider(BindingContext context)
	{
		return SslStreamSecurityUpgradeProvider.CreateClientProvider(this, context);
	}

	internal override bool IsMatch(BindingElement b)
	{
		if (b == null)
		{
			return false;
		}
		if (!(b is SslStreamSecurityBindingElement sslStreamSecurityBindingElement))
		{
			return false;
		}
		if (RequireClientCertificate == sslStreamSecurityBindingElement.RequireClientCertificate)
		{
			return _sslProtocols == sslStreamSecurityBindingElement._sslProtocols;
		}
		return false;
	}
}
