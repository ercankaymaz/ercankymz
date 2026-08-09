using System.Collections.ObjectModel;
using System.IO;
using System.IdentityModel.Policy;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Net.Security;
using System.Runtime;
using System.Security.Authentication;
using System.Security.Authentication.ExtendedProtection;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.Security;
using System.ServiceModel.Security.Tokens;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal class SslStreamSecurityUpgradeInitiator : StreamSecurityUpgradeInitiatorBase
{
	private SslStreamSecurityUpgradeProvider _parent;

	private SecurityMessageProperty _serverSecurity;

	private SecurityTokenProvider _clientCertificateProvider;

	private X509SecurityToken _clientToken;

	private SecurityTokenAuthenticator _serverCertificateAuthenticator;

	private ChannelBinding _channelBindingToken;

	private static LocalCertificateSelectionCallback s_clientCertificateSelectionCallback;

	private static LocalCertificateSelectionCallback ClientCertificateSelectionCallback
	{
		get
		{
			if (s_clientCertificateSelectionCallback == null)
			{
				s_clientCertificateSelectionCallback = SelectClientCertificate;
			}
			return s_clientCertificateSelectionCallback;
		}
	}

	internal ChannelBinding ChannelBinding => _channelBindingToken;

	internal bool IsChannelBindingSupportEnabled => ((IChannelBindingProvider)_parent).IsChannelBindingSupportEnabled;

	public SslStreamSecurityUpgradeInitiator(SslStreamSecurityUpgradeProvider parent, EndpointAddress remoteAddress, Uri via)
		: base("application/ssl-tls", remoteAddress, via)
	{
		_parent = parent;
		InitiatorServiceModelSecurityTokenRequirement tokenRequirement = new InitiatorServiceModelSecurityTokenRequirement
		{
			TokenType = SecurityTokenTypes.X509Certificate,
			RequireCryptographicToken = true,
			KeyUsage = SecurityKeyUsage.Exchange,
			TargetAddress = remoteAddress,
			Via = via,
			TransportScheme = _parent.Scheme,
			PreferSslCertificateAuthenticator = true
		};
		_serverCertificateAuthenticator = parent.ClientSecurityTokenManager.CreateSecurityTokenAuthenticator(tokenRequirement, out var _);
		if (parent.RequireClientCertificate)
		{
			InitiatorServiceModelSecurityTokenRequirement initiatorServiceModelSecurityTokenRequirement = new InitiatorServiceModelSecurityTokenRequirement
			{
				TokenType = SecurityTokenTypes.X509Certificate,
				RequireCryptographicToken = true,
				KeyUsage = SecurityKeyUsage.Signature,
				TargetAddress = remoteAddress,
				Via = via,
				TransportScheme = _parent.Scheme
			};
			_clientCertificateProvider = parent.ClientSecurityTokenManager.CreateSecurityTokenProvider(initiatorServiceModelSecurityTokenRequirement);
			if (_clientCertificateProvider == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.ClientCredentialsUnableToCreateLocalTokenProvider, initiatorServiceModelSecurityTokenRequirement)));
			}
		}
	}

	internal override void Open(TimeSpan timeout)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		base.Open(timeoutHelper.RemainingTime());
		if (_clientCertificateProvider != null)
		{
			SecurityUtils.OpenTokenProviderIfRequired(_clientCertificateProvider, timeoutHelper.RemainingTime());
			_clientToken = (X509SecurityToken)_clientCertificateProvider.GetTokenAsync(timeoutHelper.RemainingTime()).GetAwaiter().GetResult();
		}
	}

	internal override async Task OpenAsync(TimeSpan timeout)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		await base.OpenAsync(timeoutHelper.RemainingTime());
		if (_clientCertificateProvider != null)
		{
			SecurityUtils.OpenTokenProviderIfRequired(_clientCertificateProvider, timeoutHelper.RemainingTime());
			_clientToken = (X509SecurityToken)(await _clientCertificateProvider.GetTokenAsync(timeoutHelper.RemainingTime()));
		}
	}

	internal override void Close(TimeSpan timeout)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		base.Close(timeoutHelper.RemainingTime());
		if (_clientCertificateProvider != null)
		{
			SecurityUtils.CloseTokenProviderIfRequired(_clientCertificateProvider, timeoutHelper.RemainingTime());
		}
	}

	internal override async Task CloseAsync(TimeSpan timeout)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		await base.CloseAsync(timeoutHelper.RemainingTime());
		if (_clientCertificateProvider != null)
		{
			SecurityUtils.CloseTokenProviderIfRequired(_clientCertificateProvider, timeoutHelper.RemainingTime());
		}
	}

	protected override Stream OnInitiateUpgrade(Stream stream, out SecurityMessageProperty remoteSecurity)
	{
		OutWrapper<SecurityMessageProperty> outWrapper = new OutWrapper<SecurityMessageProperty>();
		Stream result = OnInitiateUpgradeAsync(stream, outWrapper).GetAwaiter().GetResult();
		remoteSecurity = outWrapper.Value;
		return result;
	}

	protected override async Task<Stream> OnInitiateUpgradeAsync(Stream stream, OutWrapper<SecurityMessageProperty> remoteSecurityWrapper)
	{
		if (WcfEventSource.Instance.SslOnInitiateUpgradeIsEnabled())
		{
			WcfEventSource.Instance.SslOnInitiateUpgrade();
		}
		X509CertificateCollection x509CertificateCollection = null;
		LocalCertificateSelectionCallback userCertificateSelectionCallback = null;
		if (_clientToken != null)
		{
			x509CertificateCollection = new X509CertificateCollection();
			x509CertificateCollection.Add(_clientToken.Certificate);
			userCertificateSelectionCallback = ClientCertificateSelectionCallback;
		}
		SslStream sslStream = new SslStream(stream, leaveInnerStreamOpen: false, ValidateRemoteCertificate, userCertificateSelectionCallback);
		try
		{
			await sslStream.AuthenticateAsClientAsync(string.Empty, x509CertificateCollection, _parent.SslProtocols, checkCertificateRevocation: false);
		}
		catch (SecurityTokenValidationException ex)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new SecurityNegotiationException(ex.Message, ex));
		}
		catch (AuthenticationException ex2)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new SecurityNegotiationException(ex2.Message, ex2));
		}
		catch (IOException ex3)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new SecurityNegotiationException(System.SR.Format(System.SR.NegotiationFailedIO, ex3.Message), ex3));
		}
		remoteSecurityWrapper.Value = _serverSecurity;
		if (IsChannelBindingSupportEnabled)
		{
			_channelBindingToken = ChannelBindingUtility.GetToken(sslStream);
		}
		return sslStream;
	}

	private static X509Certificate SelectClientCertificate(object sender, string targetHost, X509CertificateCollection localCertificates, X509Certificate remoteCertificate, string[] acceptableIssuers)
	{
		return localCertificates[0];
	}

	private bool ValidateRemoteCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
	{
		X509Certificate2 certificate2 = new X509Certificate2(certificate);
		SecurityToken token = new X509SecurityToken(certificate2, clone: false);
		ReadOnlyCollection<IAuthorizationPolicy> readOnlyCollection = _serverCertificateAuthenticator.ValidateToken(token);
		_serverSecurity = new SecurityMessageProperty();
		_serverSecurity.TransportToken = new SecurityTokenSpecification(token, readOnlyCollection);
		_serverSecurity.ServiceSecurityContext = new ServiceSecurityContext(readOnlyCollection);
		AuthorizationContext authorizationContext = _serverSecurity.ServiceSecurityContext.AuthorizationContext;
		_parent.IdentityVerifier.EnsureOutgoingIdentity(base.RemoteAddress, base.Via, authorizationContext);
		return true;
	}
}
