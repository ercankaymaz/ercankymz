using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Net;
using System.Net.Security;
using System.Runtime;
using System.Security.Principal;
using System.ServiceModel.Security;
using System.ServiceModel.Security.Tokens;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal static class TransportSecurityHelpers
{
	public static async Task<NetworkCredential> GetSspiCredentialAsync(SecurityTokenProviderContainer tokenProvider, OutWrapper<TokenImpersonationLevel> impersonationLevelWrapper, OutWrapper<AuthenticationLevel> authenticationLevelWrapper, TimeSpan timeout)
	{
		OutWrapper<bool> extractGroupsForWindowsAccounts = new OutWrapper<bool>();
		OutWrapper<bool> allowNtlmWrapper = new OutWrapper<bool>();
		NetworkCredential result = await GetSspiCredentialAsync(tokenProvider.TokenProvider as SspiSecurityTokenProvider, extractGroupsForWindowsAccounts, impersonationLevelWrapper, allowNtlmWrapper, timeout);
		authenticationLevelWrapper.Value = (allowNtlmWrapper.Value ? AuthenticationLevel.MutualAuthRequested : AuthenticationLevel.MutualAuthRequired);
		return result;
	}

	public static Task<NetworkCredential> GetSspiCredentialAsync(SspiSecurityTokenProvider tokenProvider, OutWrapper<TokenImpersonationLevel> impersonationLevel, OutWrapper<bool> allowNtlm, TimeSpan timeout)
	{
		OutWrapper<bool> extractGroupsForWindowsAccounts = new OutWrapper<bool>();
		return GetSspiCredentialAsync(tokenProvider, extractGroupsForWindowsAccounts, impersonationLevel, allowNtlm, timeout);
	}

	public static NetworkCredential GetSspiCredential(SecurityTokenManager credentialProvider, SecurityTokenRequirement sspiTokenRequirement, TimeSpan timeout, out bool extractGroupsForWindowsAccounts)
	{
		extractGroupsForWindowsAccounts = true;
		NetworkCredential result = null;
		if (credentialProvider != null)
		{
			SecurityTokenProvider securityTokenProvider = credentialProvider.CreateSecurityTokenProvider(sspiTokenRequirement);
			if (securityTokenProvider != null)
			{
				TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
				SecurityUtils.OpenTokenProviderIfRequired(securityTokenProvider, timeoutHelper.RemainingTime());
				bool flag = false;
				try
				{
					OutWrapper<TokenImpersonationLevel> impersonationLevelWrapper = new OutWrapper<TokenImpersonationLevel>();
					OutWrapper<bool> allowNtlmWrapper = new OutWrapper<bool>();
					OutWrapper<bool> extractGroupsForWindowsAccounts2 = new OutWrapper<bool>();
					result = GetSspiCredentialAsync((SspiSecurityTokenProvider)securityTokenProvider, extractGroupsForWindowsAccounts2, impersonationLevelWrapper, allowNtlmWrapper, timeoutHelper.RemainingTime()).GetAwaiter().GetResult();
					flag = true;
				}
				finally
				{
					if (!flag)
					{
						SecurityUtils.AbortTokenProviderIfRequired(securityTokenProvider);
					}
				}
				SecurityUtils.CloseTokenProviderIfRequired(securityTokenProvider, timeoutHelper.RemainingTime());
			}
		}
		return result;
	}

	public static async Task<NetworkCredential> GetSspiCredentialAsync(SspiSecurityTokenProvider tokenProvider, OutWrapper<bool> extractGroupsForWindowsAccounts, OutWrapper<TokenImpersonationLevel> impersonationLevelWrapper, OutWrapper<bool> allowNtlmWrapper, TimeSpan timeout)
	{
		NetworkCredential credential = null;
		extractGroupsForWindowsAccounts.Value = true;
		impersonationLevelWrapper.Value = TokenImpersonationLevel.Identification;
		allowNtlmWrapper.Value = true;
		if (tokenProvider != null)
		{
			SspiSecurityToken sspiSecurityToken = await GetTokenAsync<SspiSecurityToken>(tokenProvider, timeout);
			if (sspiSecurityToken != null)
			{
				extractGroupsForWindowsAccounts.Value = sspiSecurityToken.ExtractGroupsForWindowsAccounts;
				impersonationLevelWrapper.Value = sspiSecurityToken.ImpersonationLevel;
				allowNtlmWrapper.Value = sspiSecurityToken.AllowNtlm;
				if (sspiSecurityToken.NetworkCredential != null)
				{
					credential = sspiSecurityToken.NetworkCredential;
					SecurityUtils.FixNetworkCredential(ref credential);
				}
			}
		}
		if (credential == null)
		{
			credential = CredentialCache.DefaultNetworkCredentials;
		}
		return credential;
	}

	internal static SecurityTokenRequirement CreateSspiTokenRequirement(string transportScheme, Uri listenUri)
	{
		RecipientServiceModelSecurityTokenRequirement recipientServiceModelSecurityTokenRequirement = new RecipientServiceModelSecurityTokenRequirement();
		recipientServiceModelSecurityTokenRequirement.TransportScheme = transportScheme;
		recipientServiceModelSecurityTokenRequirement.RequireCryptographicToken = false;
		recipientServiceModelSecurityTokenRequirement.ListenUri = listenUri;
		recipientServiceModelSecurityTokenRequirement.TokenType = ServiceModelSecurityTokenTypes.SspiCredential;
		return recipientServiceModelSecurityTokenRequirement;
	}

	internal static SecurityTokenRequirement CreateSspiTokenRequirement(EndpointAddress target, Uri via, string transportScheme)
	{
		InitiatorServiceModelSecurityTokenRequirement initiatorServiceModelSecurityTokenRequirement = new InitiatorServiceModelSecurityTokenRequirement();
		initiatorServiceModelSecurityTokenRequirement.TokenType = ServiceModelSecurityTokenTypes.SspiCredential;
		initiatorServiceModelSecurityTokenRequirement.RequireCryptographicToken = false;
		initiatorServiceModelSecurityTokenRequirement.TransportScheme = transportScheme;
		initiatorServiceModelSecurityTokenRequirement.TargetAddress = target;
		initiatorServiceModelSecurityTokenRequirement.Via = via;
		return initiatorServiceModelSecurityTokenRequirement;
	}

	public static SspiSecurityTokenProvider GetSspiTokenProvider(SecurityTokenManager tokenManager, EndpointAddress target, Uri via, string transportScheme, AuthenticationSchemes authenticationScheme, ChannelParameterCollection channelParameters)
	{
		if (tokenManager != null)
		{
			SecurityTokenRequirement securityTokenRequirement = CreateSspiTokenRequirement(target, via, transportScheme);
			securityTokenRequirement.Properties[ServiceModelSecurityTokenRequirement.HttpAuthenticationSchemeProperty] = authenticationScheme;
			if (channelParameters != null)
			{
				securityTokenRequirement.Properties[ServiceModelSecurityTokenRequirement.ChannelParametersCollectionProperty] = channelParameters;
			}
			return tokenManager.CreateSecurityTokenProvider(securityTokenRequirement) as SspiSecurityTokenProvider;
		}
		return null;
	}

	public static SspiSecurityTokenProvider GetSspiTokenProvider(SecurityTokenManager tokenManager, EndpointAddress target, Uri via, string transportScheme, out IdentityVerifier identityVerifier)
	{
		identityVerifier = null;
		if (tokenManager != null)
		{
			SspiSecurityTokenProvider sspiSecurityTokenProvider = tokenManager.CreateSecurityTokenProvider(CreateSspiTokenRequirement(target, via, transportScheme)) as SspiSecurityTokenProvider;
			if (sspiSecurityTokenProvider != null)
			{
				identityVerifier = IdentityVerifier.CreateDefault();
			}
			return sspiSecurityTokenProvider;
		}
		return null;
	}

	public static SecurityTokenProvider GetDigestTokenProvider(SecurityTokenManager tokenManager, EndpointAddress target, Uri via, string transportScheme, AuthenticationSchemes authenticationScheme, ChannelParameterCollection channelParameters)
	{
		if (tokenManager != null)
		{
			InitiatorServiceModelSecurityTokenRequirement initiatorServiceModelSecurityTokenRequirement = new InitiatorServiceModelSecurityTokenRequirement();
			initiatorServiceModelSecurityTokenRequirement.TokenType = ServiceModelSecurityTokenTypes.SspiCredential;
			initiatorServiceModelSecurityTokenRequirement.TargetAddress = target;
			initiatorServiceModelSecurityTokenRequirement.Via = via;
			initiatorServiceModelSecurityTokenRequirement.RequireCryptographicToken = false;
			initiatorServiceModelSecurityTokenRequirement.TransportScheme = transportScheme;
			initiatorServiceModelSecurityTokenRequirement.Properties[ServiceModelSecurityTokenRequirement.HttpAuthenticationSchemeProperty] = authenticationScheme;
			if (channelParameters != null)
			{
				initiatorServiceModelSecurityTokenRequirement.Properties[ServiceModelSecurityTokenRequirement.ChannelParametersCollectionProperty] = channelParameters;
			}
			return tokenManager.CreateSecurityTokenProvider(initiatorServiceModelSecurityTokenRequirement) as SspiSecurityTokenProvider;
		}
		return null;
	}

	public static SecurityTokenProvider GetCertificateTokenProvider(SecurityTokenManager tokenManager, EndpointAddress target, Uri via, string transportScheme, ChannelParameterCollection channelParameters)
	{
		if (tokenManager != null)
		{
			InitiatorServiceModelSecurityTokenRequirement initiatorServiceModelSecurityTokenRequirement = new InitiatorServiceModelSecurityTokenRequirement();
			initiatorServiceModelSecurityTokenRequirement.TokenType = SecurityTokenTypes.X509Certificate;
			initiatorServiceModelSecurityTokenRequirement.TargetAddress = target;
			initiatorServiceModelSecurityTokenRequirement.Via = via;
			initiatorServiceModelSecurityTokenRequirement.RequireCryptographicToken = false;
			initiatorServiceModelSecurityTokenRequirement.TransportScheme = transportScheme;
			if (channelParameters != null)
			{
				initiatorServiceModelSecurityTokenRequirement.Properties[ServiceModelSecurityTokenRequirement.ChannelParametersCollectionProperty] = channelParameters;
			}
			return tokenManager.CreateSecurityTokenProvider(initiatorServiceModelSecurityTokenRequirement);
		}
		return null;
	}

	private static async Task<T> GetTokenAsync<T>(SecurityTokenProvider tokenProvider, TimeSpan timeout) where T : SecurityToken
	{
		SecurityToken securityToken = await tokenProvider.GetTokenAsync(timeout);
		if (securityToken != null && !(securityToken is T))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.InvalidTokenProvided, tokenProvider.GetType(), typeof(T))));
		}
		return securityToken as T;
	}

	public static async Task<NetworkCredential> GetUserNameCredentialAsync(SecurityTokenProviderContainer tokenProvider, TimeSpan timeout)
	{
		NetworkCredential result = null;
		if (tokenProvider != null && tokenProvider.TokenProvider != null)
		{
			UserNameSecurityToken userNameSecurityToken = await GetTokenAsync<UserNameSecurityToken>(tokenProvider.TokenProvider, timeout);
			if (userNameSecurityToken != null)
			{
				result = new NetworkCredential(userNameSecurityToken.UserName, userNameSecurityToken.Password);
			}
		}
		if (result == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.NoUserNameTokenProvided));
		}
		return result;
	}

	public static SecurityTokenProvider GetUserNameTokenProvider(SecurityTokenManager tokenManager, EndpointAddress target, Uri via, string transportScheme, AuthenticationSchemes authenticationScheme, ChannelParameterCollection channelParameters)
	{
		SecurityTokenProvider result = null;
		if (tokenManager != null)
		{
			SecurityTokenRequirement securityTokenRequirement = CreateUserNameTokenRequirement(target, via, transportScheme);
			securityTokenRequirement.Properties[ServiceModelSecurityTokenRequirement.HttpAuthenticationSchemeProperty] = authenticationScheme;
			if (channelParameters != null)
			{
				securityTokenRequirement.Properties[ServiceModelSecurityTokenRequirement.ChannelParametersCollectionProperty] = channelParameters;
			}
			result = tokenManager.CreateSecurityTokenProvider(securityTokenRequirement);
		}
		return result;
	}

	public static Uri GetListenUri(Uri baseAddress, string relativeAddress)
	{
		Uri result = baseAddress;
		if (!string.IsNullOrEmpty(relativeAddress))
		{
			if (!baseAddress.AbsolutePath.EndsWith("/", StringComparison.Ordinal))
			{
				UriBuilder uriBuilder = new UriBuilder(baseAddress);
				FixIpv6Hostname(uriBuilder, baseAddress);
				uriBuilder.Path += "/";
				baseAddress = uriBuilder.Uri;
			}
			result = new Uri(baseAddress, relativeAddress);
		}
		return result;
	}

	private static InitiatorServiceModelSecurityTokenRequirement CreateUserNameTokenRequirement(EndpointAddress target, Uri via, string transportScheme)
	{
		InitiatorServiceModelSecurityTokenRequirement initiatorServiceModelSecurityTokenRequirement = new InitiatorServiceModelSecurityTokenRequirement();
		initiatorServiceModelSecurityTokenRequirement.RequireCryptographicToken = false;
		initiatorServiceModelSecurityTokenRequirement.TokenType = SecurityTokenTypes.UserName;
		initiatorServiceModelSecurityTokenRequirement.TargetAddress = target;
		initiatorServiceModelSecurityTokenRequirement.Via = via;
		initiatorServiceModelSecurityTokenRequirement.TransportScheme = transportScheme;
		return initiatorServiceModelSecurityTokenRequirement;
	}

	private static void FixIpv6Hostname(UriBuilder uriBuilder, Uri originalUri)
	{
		if (originalUri.HostNameType == UriHostNameType.IPv6)
		{
			string dnsSafeHost = originalUri.DnsSafeHost;
			uriBuilder.Host = "[" + dnsSafeHost + "]";
		}
	}
}
