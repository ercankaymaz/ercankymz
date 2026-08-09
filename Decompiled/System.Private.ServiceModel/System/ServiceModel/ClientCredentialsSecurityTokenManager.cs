using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Net;
using System.Security.Principal;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Security;
using System.ServiceModel.Security.Tokens;

namespace System.ServiceModel;

public class ClientCredentialsSecurityTokenManager : SecurityTokenManager
{
	public ClientCredentials ClientCredentials { get; }

	public ClientCredentialsSecurityTokenManager(ClientCredentials clientCredentials)
	{
		ClientCredentials = clientCredentials ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("clientCredentials");
	}

	private string GetServicePrincipalName(InitiatorServiceModelSecurityTokenRequirement initiatorRequirement)
	{
		EndpointAddress targetAddress = initiatorRequirement.TargetAddress;
		if (targetAddress == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument(System.SR.Format(System.SR.TokenRequirementDoesNotSpecifyTargetAddress, initiatorRequirement));
		}
		SecurityBindingElement securityBindingElement = initiatorRequirement.SecurityBindingElement;
		IdentityVerifier identityVerifier = ((securityBindingElement == null) ? IdentityVerifier.CreateDefault() : securityBindingElement.LocalClientSettings.IdentityVerifier);
		identityVerifier.TryGetIdentity(targetAddress, out var identity);
		return SecurityUtils.GetSpnFromIdentity(identity, targetAddress);
	}

	private bool IsDigestAuthenticationScheme(SecurityTokenRequirement requirement)
	{
		if (requirement.Properties.ContainsKey(ServiceModelSecurityTokenRequirement.HttpAuthenticationSchemeProperty))
		{
			AuthenticationSchemes authenticationSchemes = (AuthenticationSchemes)requirement.Properties[ServiceModelSecurityTokenRequirement.HttpAuthenticationSchemeProperty];
			if (!authenticationSchemes.IsSingleton() && authenticationSchemes != AuthenticationSchemes.IntegratedWindowsAuthentication)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument("authScheme", string.Format(System.SR.HttpRequiresSingleAuthScheme, authenticationSchemes));
			}
			return authenticationSchemes == AuthenticationSchemes.Digest;
		}
		return false;
	}

	protected internal bool IsIssuedSecurityTokenRequirement(SecurityTokenRequirement requirement)
	{
		if (requirement != null && requirement.Properties.ContainsKey(ServiceModelSecurityTokenRequirement.IssuerAddressProperty))
		{
			if (requirement.TokenType == ServiceModelSecurityTokenTypes.AnonymousSslnego || requirement.TokenType == ServiceModelSecurityTokenTypes.MutualSslnego || requirement.TokenType == ServiceModelSecurityTokenTypes.SecureConversation || requirement.TokenType == ServiceModelSecurityTokenTypes.Spnego)
			{
				return false;
			}
			return true;
		}
		return false;
	}

	public override SecurityTokenProvider CreateSecurityTokenProvider(SecurityTokenRequirement tokenRequirement)
	{
		if (tokenRequirement == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("tokenRequirement");
		}
		SecurityTokenProvider securityTokenProvider = null;
		if (tokenRequirement is RecipientServiceModelSecurityTokenRequirement && tokenRequirement.TokenType == SecurityTokenTypes.X509Certificate && tokenRequirement.KeyUsage == SecurityKeyUsage.Exchange)
		{
			if (ClientCredentials.ClientCertificate.Certificate == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.ClientCertificateNotProvidedOnClientCredentials)));
			}
			securityTokenProvider = new X509SecurityTokenProvider(ClientCredentials.ClientCertificate.Certificate, ClientCredentials.ClientCertificate.CloneCertificate);
		}
		else if (tokenRequirement is InitiatorServiceModelSecurityTokenRequirement)
		{
			InitiatorServiceModelSecurityTokenRequirement initiatorServiceModelSecurityTokenRequirement = tokenRequirement as InitiatorServiceModelSecurityTokenRequirement;
			string tokenType = initiatorServiceModelSecurityTokenRequirement.TokenType;
			if (IsIssuedSecurityTokenRequirement(initiatorServiceModelSecurityTokenRequirement))
			{
				throw ExceptionHelper.PlatformNotSupported("CreateSecurityTokenProvider (IsIssuedSecurityTokenRequirement(initiatorRequirement)");
			}
			if (tokenType == SecurityTokenTypes.X509Certificate)
			{
				if (initiatorServiceModelSecurityTokenRequirement.Properties.ContainsKey(SecurityTokenRequirement.KeyUsageProperty) && initiatorServiceModelSecurityTokenRequirement.KeyUsage == SecurityKeyUsage.Exchange)
				{
					throw ExceptionHelper.PlatformNotSupported("CreateSecurityTokenProvider X509Certificate - SecurityKeyUsage.Exchange");
				}
				if (ClientCredentials.ClientCertificate.Certificate == null)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.ClientCertificateNotProvidedOnClientCredentials)));
				}
				securityTokenProvider = new X509SecurityTokenProvider(ClientCredentials.ClientCertificate.Certificate, ClientCredentials.ClientCertificate.CloneCertificate);
			}
			else if (tokenType == SecurityTokenTypes.Kerberos)
			{
				string servicePrincipalName = GetServicePrincipalName(initiatorServiceModelSecurityTokenRequirement);
				securityTokenProvider = new KerberosSecurityTokenProviderWrapper(new KerberosSecurityTokenProvider(servicePrincipalName, ClientCredentials.Windows.AllowedImpersonationLevel, SecurityUtils.GetNetworkCredentialOrDefault(ClientCredentials.Windows.ClientCredential)));
			}
			else if (tokenType == SecurityTokenTypes.UserName)
			{
				if (ClientCredentials.UserName.UserName == null)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.UserNamePasswordNotProvidedOnClientCredentials));
				}
				securityTokenProvider = new UserNameSecurityTokenProvider(ClientCredentials.UserName.UserName, ClientCredentials.UserName.Password);
			}
			else if (tokenType == ServiceModelSecurityTokenTypes.SspiCredential)
			{
				securityTokenProvider = ((!IsDigestAuthenticationScheme(initiatorServiceModelSecurityTokenRequirement)) ? new SspiSecurityTokenProvider(SecurityUtils.GetNetworkCredentialOrDefault(ClientCredentials.Windows.ClientCredential), ClientCredentials.Windows.AllowNtlm, ClientCredentials.Windows.AllowedImpersonationLevel) : new SspiSecurityTokenProvider(SecurityUtils.GetNetworkCredentialOrDefault(ClientCredentials.HttpDigest.ClientCredential), allowNtlm: true, TokenImpersonationLevel.Delegation));
			}
			else if (tokenType == ServiceModelSecurityTokenTypes.SecureConversation)
			{
				securityTokenProvider = CreateSecureConversationSecurityTokenProvider(initiatorServiceModelSecurityTokenRequirement);
			}
		}
		if (securityTokenProvider == null && !tokenRequirement.IsOptionalToken)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException(System.SR.Format(System.SR.SecurityTokenManagerCannotCreateProviderForRequirement, tokenRequirement)));
		}
		return securityTokenProvider;
	}

	public override SecurityTokenSerializer CreateSecurityTokenSerializer(SecurityTokenVersion version)
	{
		if (version == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("version");
		}
		if (version is MessageSecurityTokenVersion messageSecurityTokenVersion)
		{
			return new WSSecurityTokenSerializer(messageSecurityTokenVersion.SecurityVersion, messageSecurityTokenVersion.TrustVersion, messageSecurityTokenVersion.SecureConversationVersion, messageSecurityTokenVersion.EmitBspRequiredAttributes, null, null, null);
		}
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException(System.SR.Format(System.SR.SecurityTokenManagerCannotCreateSerializerForVersion, version)));
	}

	private SecurityTokenProvider CreateSecureConversationSecurityTokenProvider(InitiatorServiceModelSecurityTokenRequirement initiatorRequirement)
	{
		EndpointAddress targetAddress = initiatorRequirement.TargetAddress;
		if (targetAddress == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument(System.SR.Format(System.SR.TokenRequirementDoesNotSpecifyTargetAddress, initiatorRequirement));
		}
		SecurityBindingElement securityBindingElement = initiatorRequirement.SecurityBindingElement;
		if (securityBindingElement == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument(System.SR.Format(System.SR.TokenProviderRequiresSecurityBindingElement, initiatorRequirement));
		}
		LocalClientSecuritySettings localClientSettings = securityBindingElement.LocalClientSettings;
		BindingContext property = initiatorRequirement.GetProperty<BindingContext>(ServiceModelSecurityTokenRequirement.IssuerBindingContextProperty);
		ChannelParameterCollection propertyOrDefault = initiatorRequirement.GetPropertyOrDefault<ChannelParameterCollection>(ServiceModelSecurityTokenRequirement.ChannelParametersCollectionProperty, null);
		if (initiatorRequirement.SupportSecurityContextCancellation)
		{
			SecuritySessionSecurityTokenProvider securitySessionSecurityTokenProvider = new SecuritySessionSecurityTokenProvider();
			securitySessionSecurityTokenProvider.BootstrapSecurityBindingElement = SecurityUtils.GetIssuerSecurityBindingElement(initiatorRequirement);
			securitySessionSecurityTokenProvider.IssuedSecurityTokenParameters = initiatorRequirement.GetProperty<SecurityTokenParameters>(ServiceModelSecurityTokenRequirement.IssuedSecurityTokenParametersProperty);
			securitySessionSecurityTokenProvider.IssuerBindingContext = property;
			securitySessionSecurityTokenProvider.KeyEntropyMode = securityBindingElement.KeyEntropyMode;
			securitySessionSecurityTokenProvider.SecurityAlgorithmSuite = initiatorRequirement.SecurityAlgorithmSuite;
			securitySessionSecurityTokenProvider.StandardsManager = SecurityUtils.CreateSecurityStandardsManager(initiatorRequirement, this);
			securitySessionSecurityTokenProvider.TargetAddress = targetAddress;
			securitySessionSecurityTokenProvider.Via = initiatorRequirement.GetPropertyOrDefault<Uri>(ServiceModelSecurityTokenRequirement.ViaProperty, null);
			if (initiatorRequirement.TryGetProperty<Uri>(ServiceModelSecurityTokenRequirement.PrivacyNoticeUriProperty, out var result))
			{
				securitySessionSecurityTokenProvider.PrivacyNoticeUri = result;
			}
			if (initiatorRequirement.TryGetProperty<int>(ServiceModelSecurityTokenRequirement.PrivacyNoticeVersionProperty, out var result2))
			{
				securitySessionSecurityTokenProvider.PrivacyNoticeVersion = result2;
			}
			if (initiatorRequirement.TryGetProperty<EndpointAddress>(ServiceModelSecurityTokenRequirement.DuplexClientLocalAddressProperty, out var result3))
			{
				securitySessionSecurityTokenProvider.LocalAddress = result3;
			}
			securitySessionSecurityTokenProvider.ChannelParameters = propertyOrDefault;
			securitySessionSecurityTokenProvider.WebHeaders = initiatorRequirement.WebHeaders;
			return securitySessionSecurityTokenProvider;
		}
		AcceleratedTokenProvider acceleratedTokenProvider = new AcceleratedTokenProvider();
		acceleratedTokenProvider.IssuerAddress = initiatorRequirement.IssuerAddress;
		acceleratedTokenProvider.BootstrapSecurityBindingElement = SecurityUtils.GetIssuerSecurityBindingElement(initiatorRequirement);
		acceleratedTokenProvider.CacheServiceTokens = localClientSettings.CacheCookies;
		acceleratedTokenProvider.IssuerBindingContext = property;
		acceleratedTokenProvider.KeyEntropyMode = securityBindingElement.KeyEntropyMode;
		acceleratedTokenProvider.MaxServiceTokenCachingTime = localClientSettings.MaxCookieCachingTime;
		acceleratedTokenProvider.SecurityAlgorithmSuite = initiatorRequirement.SecurityAlgorithmSuite;
		acceleratedTokenProvider.ServiceTokenValidityThresholdPercentage = localClientSettings.CookieRenewalThresholdPercentage;
		acceleratedTokenProvider.StandardsManager = SecurityUtils.CreateSecurityStandardsManager(initiatorRequirement, this);
		acceleratedTokenProvider.TargetAddress = targetAddress;
		acceleratedTokenProvider.Via = initiatorRequirement.GetPropertyOrDefault<Uri>(ServiceModelSecurityTokenRequirement.ViaProperty, null);
		return acceleratedTokenProvider;
	}

	private X509SecurityTokenAuthenticator CreateServerX509TokenAuthenticator()
	{
		return new X509SecurityTokenAuthenticator(ClientCredentials.ServiceCertificate.Authentication.GetCertificateValidator(), mapToWindows: false);
	}

	private X509SecurityTokenAuthenticator CreateServerSslX509TokenAuthenticator()
	{
		if (ClientCredentials.ServiceCertificate.SslCertificateAuthentication != null)
		{
			return new X509SecurityTokenAuthenticator(ClientCredentials.ServiceCertificate.SslCertificateAuthentication.GetCertificateValidator(), mapToWindows: false);
		}
		return CreateServerX509TokenAuthenticator();
	}

	public override SecurityTokenAuthenticator CreateSecurityTokenAuthenticator(SecurityTokenRequirement tokenRequirement, out SecurityTokenResolver outOfBandTokenResolver)
	{
		if (tokenRequirement == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("tokenRequirement");
		}
		outOfBandTokenResolver = null;
		SecurityTokenAuthenticator securityTokenAuthenticator = null;
		if (tokenRequirement is InitiatorServiceModelSecurityTokenRequirement { TokenType: var tokenType } initiatorServiceModelSecurityTokenRequirement)
		{
			if (IsIssuedSecurityTokenRequirement(initiatorServiceModelSecurityTokenRequirement))
			{
				throw ExceptionHelper.PlatformNotSupported("CreateSecurityTokenAuthenticator : GenericXmlSecurityTokenAuthenticator");
			}
			if (tokenType == SecurityTokenTypes.X509Certificate)
			{
				securityTokenAuthenticator = (initiatorServiceModelSecurityTokenRequirement.IsOutOfBandToken ? new X509SecurityTokenAuthenticator(X509CertificateValidator.None) : ((!initiatorServiceModelSecurityTokenRequirement.PreferSslCertificateAuthenticator) ? CreateServerX509TokenAuthenticator() : CreateServerSslX509TokenAuthenticator()));
			}
			else
			{
				if (tokenType == SecurityTokenTypes.Rsa)
				{
					throw ExceptionHelper.PlatformNotSupported("CreateSecurityTokenAuthenticator : SecurityTokenTypes.Rsa");
				}
				if (tokenType == SecurityTokenTypes.Kerberos)
				{
					throw ExceptionHelper.PlatformNotSupported("CreateSecurityTokenAuthenticator : SecurityTokenTypes.Kerberos");
				}
				if (tokenType == ServiceModelSecurityTokenTypes.SecureConversation || tokenType == ServiceModelSecurityTokenTypes.MutualSslnego || tokenType == ServiceModelSecurityTokenTypes.AnonymousSslnego || tokenType == ServiceModelSecurityTokenTypes.Spnego)
				{
					throw ExceptionHelper.PlatformNotSupported("CreateSecurityTokenAuthenticator : GenericXmlSecurityTokenAuthenticator");
				}
			}
		}
		else if (tokenRequirement is RecipientServiceModelSecurityTokenRequirement && tokenRequirement.TokenType == SecurityTokenTypes.X509Certificate)
		{
			securityTokenAuthenticator = CreateServerX509TokenAuthenticator();
		}
		if (securityTokenAuthenticator == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException(System.SR.Format(System.SR.SecurityTokenManagerCannotCreateAuthenticatorForRequirement, tokenRequirement)));
		}
		return securityTokenAuthenticator;
	}
}
