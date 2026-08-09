using System.IdentityModel.Claims;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Net.Http;
using System.Net.Security;
using System.Runtime;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.Description;
using System.ServiceModel.Security;
using System.ServiceModel.Security.Tokens;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal class HttpsChannelFactory<TChannel> : HttpChannelFactory<TChannel>
{
	protected class HttpsClientRequestChannel : HttpClientRequestChannel
	{
		private SecurityTokenProvider _certificateProvider;

		public new HttpsChannelFactory<IRequestChannel> Factory { get; }

		public HttpsClientRequestChannel(HttpsChannelFactory<IRequestChannel> factory, EndpointAddress to, Uri via, bool manualAddressing)
			: base((HttpChannelFactory<IRequestChannel>)factory, to, via, manualAddressing)
		{
			Factory = factory;
		}

		private void CreateAndOpenTokenProvider(TimeSpan timeout)
		{
			if (!base.ManualAddressing && Factory.RequireClientCertificate)
			{
				_certificateProvider = Factory.CreateAndOpenCertificateTokenProvider(base.RemoteAddress, base.Via, base.ChannelParameters, timeout);
			}
		}

		private void CloseTokenProvider(TimeSpan timeout)
		{
			if (_certificateProvider != null)
			{
				SecurityUtils.CloseTokenProviderIfRequired(_certificateProvider, timeout);
			}
		}

		private void AbortTokenProvider()
		{
			if (_certificateProvider != null)
			{
				SecurityUtils.AbortTokenProviderIfRequired(_certificateProvider);
			}
		}

		protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
		{
			TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
			CreateAndOpenTokenProvider(timeoutHelper.RemainingTime());
			return base.OnBeginOpen(timeoutHelper.RemainingTime(), callback, state);
		}

		protected override void OnOpen(TimeSpan timeout)
		{
			TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
			CreateAndOpenTokenProvider(timeoutHelper.RemainingTime());
			base.OnOpen(timeoutHelper.RemainingTime());
		}

		protected internal override Task OnOpenAsync(TimeSpan timeout)
		{
			TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
			CreateAndOpenTokenProvider(timeoutHelper.RemainingTime());
			return base.OnOpenAsync(timeoutHelper.RemainingTime());
		}

		protected override void OnAbort()
		{
			AbortTokenProvider();
			base.OnAbort();
		}

		protected override IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
		{
			TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
			CloseTokenProvider(timeoutHelper.RemainingTime());
			return base.OnBeginClose(timeoutHelper.RemainingTime(), callback, state);
		}

		protected override void OnClose(TimeSpan timeout)
		{
			TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
			CloseTokenProvider(timeoutHelper.RemainingTime());
			base.OnClose(timeoutHelper.RemainingTime());
		}

		internal override void OnHttpRequestCompleted(HttpRequestMessage request)
		{
		}

		internal override async Task<HttpClient> GetHttpClientAsync(EndpointAddress to, Uri via, TimeoutHelper timeoutHelper)
		{
			SecurityTokenContainer certificateSecurityToken = Factory.GetCertificateSecurityToken(_certificateProvider, to, via, base.ChannelParameters, ref timeoutHelper);
			return await GetHttpClientAsync(to, via, certificateSecurityToken, timeoutHelper);
		}
	}

	private X509CertificateValidator _sslCertificateValidator;

	private Func<HttpRequestMessage, X509Certificate2, X509Chain, SslPolicyErrors, bool> _remoteCertificateValidationCallback;

	public override string Scheme => "https";

	public bool RequireClientCertificate { get; }

	public override bool IsChannelBindingSupportEnabled => false;

	internal override bool IsExpectContinueHeaderRequired
	{
		get
		{
			if (!RequireClientCertificate)
			{
				return base.IsExpectContinueHeaderRequired;
			}
			return true;
		}
	}

	internal HttpsChannelFactory(HttpsTransportBindingElement httpsBindingElement, BindingContext context)
		: base((HttpTransportBindingElement)httpsBindingElement, context)
	{
		RequireClientCertificate = httpsBindingElement.RequireClientCertificate;
		ClientCredentials clientCredentials = context.BindingParameters.Find<ClientCredentials>();
		if (clientCredentials != null && clientCredentials.ServiceCertificate.SslCertificateAuthentication != null)
		{
			_sslCertificateValidator = clientCredentials.ServiceCertificate.SslCertificateAuthentication.GetCertificateValidator();
			_remoteCertificateValidationCallback = RemoteCertificateValidationCallback;
		}
	}

	public override T GetProperty<T>()
	{
		return base.GetProperty<T>();
	}

	protected override void ValidateCreateChannelParameters(EndpointAddress remoteAddress, Uri via)
	{
		if (remoteAddress.Identity != null)
		{
			X509CertificateEndpointIdentity x509CertificateEndpointIdentity = remoteAddress.Identity as X509CertificateEndpointIdentity;
			if (x509CertificateEndpointIdentity != null && x509CertificateEndpointIdentity.Certificates.Count > 1)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument("remoteAddress", System.SR.Format(System.SR.HttpsIdentityMultipleCerts, remoteAddress.Uri));
			}
			EndpointIdentity identity = remoteAddress.Identity;
			bool flag = x509CertificateEndpointIdentity != null || ClaimTypes.Spn.Equals(identity.IdentityClaim.ClaimType) || ClaimTypes.Upn.Equals(identity.IdentityClaim.ClaimType) || ClaimTypes.Dns.Equals(identity.IdentityClaim.ClaimType);
			if (!HttpChannelFactory<TChannel>.IsWindowsAuth(base.AuthenticationScheme) && !flag)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument("remoteAddress", System.SR.HttpsExplicitIdentity);
			}
		}
		if (string.Compare(via.Scheme, "wss", StringComparison.OrdinalIgnoreCase) != 0)
		{
			ValidateScheme(via);
		}
		if (base.MessageVersion.Addressing == AddressingVersion.None && remoteAddress.Uri != via)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(CreateToMustEqualViaException(remoteAddress.Uri, via));
		}
	}

	protected override TChannel OnCreateChannelCore(EndpointAddress address, Uri via)
	{
		ValidateCreateChannelParameters(address, via);
		ValidateWebSocketTransportUsage();
		if (typeof(TChannel) == typeof(IRequestChannel))
		{
			return (TChannel)(object)new HttpsClientRequestChannel((HttpsChannelFactory<IRequestChannel>)(object)this, address, via, base.ManualAddressing);
		}
		return (TChannel)(object)new ClientWebSocketTransportDuplexSessionChannel((HttpChannelFactory<IDuplexSessionChannel>)(object)this, _clientWebSocketFactory, address, via);
	}

	protected override bool IsSecurityTokenManagerRequired()
	{
		if (!RequireClientCertificate)
		{
			return base.IsSecurityTokenManagerRequired();
		}
		return true;
	}

	private void OnOpenCore()
	{
		if (RequireClientCertificate && base.SecurityTokenManager == null)
		{
			throw Fx.AssertAndThrow("HttpsChannelFactory: SecurityTokenManager is null on open.");
		}
	}

	protected override void OnEndOpen(IAsyncResult result)
	{
		base.OnEndOpen(result);
		OnOpenCore();
	}

	protected override void OnOpen(TimeSpan timeout)
	{
		base.OnOpen(timeout);
		OnOpenCore();
	}

	protected internal override async Task OnOpenAsync(TimeSpan timeout)
	{
		await base.OnOpenAsync(timeout);
		OnOpenCore();
	}

	internal SecurityTokenProvider CreateAndOpenCertificateTokenProvider(EndpointAddress target, Uri via, ChannelParameterCollection channelParameters, TimeSpan timeout)
	{
		if (!RequireClientCertificate)
		{
			return null;
		}
		SecurityTokenProvider certificateTokenProvider = TransportSecurityHelpers.GetCertificateTokenProvider(base.SecurityTokenManager, target, via, Scheme, channelParameters);
		SecurityUtils.OpenTokenProviderIfRequired(certificateTokenProvider, timeout);
		return certificateTokenProvider;
	}

	internal SecurityTokenContainer GetCertificateSecurityToken(SecurityTokenProvider certificateProvider, EndpointAddress to, Uri via, ChannelParameterCollection channelParameters, ref TimeoutHelper timeoutHelper)
	{
		SecurityToken securityToken = null;
		SecurityTokenContainer result = null;
		SecurityTokenProvider securityTokenProvider = ((!base.ManualAddressing || !RequireClientCertificate) ? certificateProvider : CreateAndOpenCertificateTokenProvider(to, via, channelParameters, timeoutHelper.RemainingTime()));
		if (securityTokenProvider != null)
		{
			securityToken = securityTokenProvider.GetToken(timeoutHelper.RemainingTime());
		}
		if (base.ManualAddressing && RequireClientCertificate)
		{
			SecurityUtils.AbortTokenProviderIfRequired(securityTokenProvider);
		}
		if (securityToken != null)
		{
			result = new SecurityTokenContainer(securityToken);
		}
		return result;
	}

	private void AddServerCertMappingOrSetRemoteCertificateValidationCallback(HttpClientHandler httpClientHandler, EndpointAddress to)
	{
		if (_sslCertificateValidator != null)
		{
			httpClientHandler.ServerCertificateCustomValidationCallback = _remoteCertificateValidationCallback;
		}
		else
		{
			HttpTransportSecurityHelpers.AddServerCertIdentityValidation(httpClientHandler, to);
		}
	}

	private bool RemoteCertificateValidationCallback(HttpRequestMessage sender, X509Certificate2 certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
	{
		try
		{
			_sslCertificateValidator.Validate(certificate);
			return true;
		}
		catch (SecurityTokenValidationException exception)
		{
			FxTrace.Exception.AsInformation(exception);
			return false;
		}
		catch (Exception exception2)
		{
			if (Fx.IsFatal(exception2))
			{
				throw;
			}
			FxTrace.Exception.AsWarning(exception2);
			return false;
		}
	}

	internal override HttpClientHandler GetHttpClientHandler(EndpointAddress to, SecurityTokenContainer clientCertificateToken)
	{
		HttpClientHandler httpClientHandler = base.GetHttpClientHandler(to, clientCertificateToken);
		if (RequireClientCertificate)
		{
			SetCertificate(httpClientHandler, clientCertificateToken);
		}
		AddServerCertMappingOrSetRemoteCertificateValidationCallback(httpClientHandler, to);
		return httpClientHandler;
	}

	private static void SetCertificate(HttpClientHandler handler, SecurityTokenContainer clientCertificateToken)
	{
		if (clientCertificateToken != null)
		{
			X509SecurityToken x509SecurityToken = (X509SecurityToken)clientCertificateToken.Token;
			ValidateClientCertificate(x509SecurityToken.Certificate);
			handler.ClientCertificateOptions = ClientCertificateOption.Manual;
			handler.ClientCertificates.Add(x509SecurityToken.Certificate);
		}
	}

	private static void ValidateClientCertificate(X509Certificate2 certificate)
	{
		if (!Fx.IsUap)
		{
			return;
		}
		using X509Store x509Store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
		x509Store.Open(OpenFlags.ReadOnly);
		if (x509Store.Certificates.Find(X509FindType.FindByThumbprint, certificate.GetCertHashString(), validOnly: true).Count == 0)
		{
			throw ExceptionHelper.PlatformNotSupported("Certificate could not be found in the MY store.");
		}
	}
}
