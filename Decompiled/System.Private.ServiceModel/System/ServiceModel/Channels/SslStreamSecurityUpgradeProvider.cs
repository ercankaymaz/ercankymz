using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Runtime;
using System.Security.Authentication;
using System.Security.Authentication.ExtendedProtection;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.Description;
using System.ServiceModel.Security;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal class SslStreamSecurityUpgradeProvider : StreamSecurityUpgradeProvider, IStreamUpgradeChannelBindingProvider, IChannelBindingProvider
{
	private SecurityTokenAuthenticator _clientCertificateAuthenticator;

	private SecurityTokenProvider _serverTokenProvider;

	private EndpointIdentity _identity;

	private bool _enableChannelBinding;

	public override EndpointIdentity Identity
	{
		get
		{
			if (_identity == null && ServerCertificate != null)
			{
				throw ExceptionHelper.PlatformNotSupported("SslStreamSecurityUpgradeProvider.Identity - server certificate");
			}
			return _identity;
		}
	}

	public IdentityVerifier IdentityVerifier { get; }

	public bool RequireClientCertificate { get; }

	public X509Certificate2 ServerCertificate { get; private set; }

	public SecurityTokenAuthenticator ClientCertificateAuthenticator
	{
		get
		{
			if (_clientCertificateAuthenticator == null)
			{
				_clientCertificateAuthenticator = new X509SecurityTokenAuthenticator(X509ClientCertificateAuthentication.DefaultCertificateValidator);
			}
			return _clientCertificateAuthenticator;
		}
	}

	public SecurityTokenManager ClientSecurityTokenManager { get; }

	public string Scheme { get; }

	public SslProtocols SslProtocols { get; }

	bool IChannelBindingProvider.IsChannelBindingSupportEnabled => _enableChannelBinding;

	private SslStreamSecurityUpgradeProvider(IDefaultCommunicationTimeouts timeouts, SecurityTokenManager clientSecurityTokenManager, bool requireClientCertificate, string scheme, IdentityVerifier identityVerifier, SslProtocols sslProtocols)
		: base(timeouts)
	{
		IdentityVerifier = identityVerifier;
		Scheme = scheme;
		ClientSecurityTokenManager = clientSecurityTokenManager;
		RequireClientCertificate = requireClientCertificate;
		SslProtocols = sslProtocols;
	}

	private SslStreamSecurityUpgradeProvider(IDefaultCommunicationTimeouts timeouts, SecurityTokenProvider serverTokenProvider, bool requireClientCertificate, SecurityTokenAuthenticator clientCertificateAuthenticator, string scheme, IdentityVerifier identityVerifier, SslProtocols sslProtocols)
		: base(timeouts)
	{
		_serverTokenProvider = serverTokenProvider;
		RequireClientCertificate = requireClientCertificate;
		_clientCertificateAuthenticator = clientCertificateAuthenticator;
		IdentityVerifier = identityVerifier;
		Scheme = scheme;
		SslProtocols = sslProtocols;
	}

	public static SslStreamSecurityUpgradeProvider CreateClientProvider(SslStreamSecurityBindingElement bindingElement, BindingContext context)
	{
		SecurityCredentialsManager securityCredentialsManager = context.BindingParameters.Find<SecurityCredentialsManager>();
		if (securityCredentialsManager == null)
		{
			securityCredentialsManager = ClientCredentials.CreateDefaultCredentials();
		}
		SecurityTokenManager clientSecurityTokenManager = securityCredentialsManager.CreateSecurityTokenManager();
		return new SslStreamSecurityUpgradeProvider(context.Binding, clientSecurityTokenManager, bindingElement.RequireClientCertificate, context.Binding.Scheme, bindingElement.IdentityVerifier, bindingElement.SslProtocols);
	}

	public override T GetProperty<T>()
	{
		if (typeof(T) == typeof(IChannelBindingProvider) || typeof(T) == typeof(IStreamUpgradeChannelBindingProvider))
		{
			return (T)(object)this;
		}
		return base.GetProperty<T>();
	}

	ChannelBinding IStreamUpgradeChannelBindingProvider.GetChannelBinding(StreamUpgradeInitiator upgradeInitiator, ChannelBindingKind kind)
	{
		if (upgradeInitiator == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("upgradeInitiator");
		}
		if (!(upgradeInitiator is SslStreamSecurityUpgradeInitiator sslStreamSecurityUpgradeInitiator))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument("upgradeInitiator", System.SR.Format(System.SR.UnsupportedUpgradeInitiator, upgradeInitiator.GetType()));
		}
		if (kind != ChannelBindingKind.Endpoint)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument("kind", System.SR.Format(System.SR.StreamUpgradeUnsupportedChannelBindingKind, GetType(), kind));
		}
		return sslStreamSecurityUpgradeInitiator.ChannelBinding;
	}

	void IChannelBindingProvider.EnableChannelBindingSupport()
	{
		_enableChannelBinding = true;
	}

	public override StreamUpgradeInitiator CreateUpgradeInitiator(EndpointAddress remoteAddress, Uri via)
	{
		ThrowIfDisposedOrNotOpen();
		return new SslStreamSecurityUpgradeInitiator(this, remoteAddress, via);
	}

	protected override void OnAbort()
	{
		if (_clientCertificateAuthenticator != null)
		{
			SecurityUtils.AbortTokenAuthenticatorIfRequired(_clientCertificateAuthenticator);
		}
		CleanupServerCertificate();
	}

	protected override void OnClose(TimeSpan timeout)
	{
		if (_clientCertificateAuthenticator != null)
		{
			SecurityUtils.CloseTokenAuthenticatorIfRequired(_clientCertificateAuthenticator, timeout);
		}
		CleanupServerCertificate();
	}

	protected internal override Task OnCloseAsync(TimeSpan timeout)
	{
		OnClose(timeout);
		return TaskHelpers.CompletedTask();
	}

	protected override IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
	{
		return OnCloseAsync(timeout).ToApm(callback, state);
	}

	protected override void OnEndClose(IAsyncResult result)
	{
		result.ToApmEnd();
	}

	private void SetupServerCertificate(SecurityToken token)
	{
		if (!(token is X509SecurityToken x509SecurityToken))
		{
			SecurityUtils.AbortTokenProviderIfRequired(_serverTokenProvider);
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.InvalidTokenProvided, _serverTokenProvider.GetType(), typeof(X509SecurityToken))));
		}
		ServerCertificate = new X509Certificate2(x509SecurityToken.Certificate);
	}

	private void CleanupServerCertificate()
	{
		if (ServerCertificate != null)
		{
			ServerCertificate.Dispose();
			ServerCertificate = null;
		}
	}

	protected override void OnOpen(TimeSpan timeout)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		SecurityUtils.OpenTokenAuthenticatorIfRequired(ClientCertificateAuthenticator, timeoutHelper.RemainingTime());
		if (_serverTokenProvider != null)
		{
			SecurityUtils.OpenTokenProviderIfRequired(_serverTokenProvider, timeoutHelper.RemainingTime());
			SecurityToken result = _serverTokenProvider.GetTokenAsync(timeoutHelper.RemainingTime()).GetAwaiter().GetResult();
			SetupServerCertificate(result);
			SecurityUtils.CloseTokenProviderIfRequired(_serverTokenProvider, timeoutHelper.RemainingTime());
			_serverTokenProvider = null;
		}
	}

	protected internal override Task OnOpenAsync(TimeSpan timeout)
	{
		OnOpen(timeout);
		return TaskHelpers.CompletedTask();
	}

	protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
	{
		return OnOpenAsync(timeout).ToApm(callback, state);
	}

	protected override void OnEndOpen(IAsyncResult result)
	{
		result.ToApmEnd();
	}
}
