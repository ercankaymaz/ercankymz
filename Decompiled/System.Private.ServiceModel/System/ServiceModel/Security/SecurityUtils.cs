using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IdentityModel.Claims;
using System.IdentityModel.Policy;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Net;
using System.Net.Security;
using System.Runtime;
using System.Security.Authentication.ExtendedProtection;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.ServiceModel.Channels;
using System.ServiceModel.Security.Tokens;
using System.Text;
using System.Threading.Tasks;

namespace System.ServiceModel.Security;

internal static class SecurityUtils
{
	internal static class NetworkCredentialHelper
	{
		private static string s_currentUser = string.Empty;

		private const string DefaultCurrentUser = "____CURRENTUSER_NOT_AVAILABLE____";

		internal static bool IsNullOrEmpty(NetworkCredential credential)
		{
			if (credential != null)
			{
				if (string.IsNullOrEmpty(credential.UserName) && string.IsNullOrEmpty(credential.Domain))
				{
					return string.IsNullOrEmpty(credential.Password);
				}
				return false;
			}
			return true;
		}

		internal static bool IsDefault(NetworkCredential credential)
		{
			return CredentialCache.DefaultNetworkCredentials.Equals(credential);
		}

		internal static string GetCurrentUserIdAsString(NetworkCredential credential)
		{
			if (!string.IsNullOrEmpty(s_currentUser))
			{
				return s_currentUser;
			}
			try
			{
				WindowsIdentity current = WindowsIdentity.GetCurrent();
				try
				{
					s_currentUser = ((IdentityReference)current.User).Value;
				}
				finally
				{
					((IDisposable)current)?.Dispose();
				}
			}
			catch (PlatformNotSupportedException)
			{
				s_currentUser = "____CURRENTUSER_NOT_AVAILABLE____";
			}
			return s_currentUser;
		}
	}

	public const string Principal = "Principal";

	public const string Identities = "Identities";

	private static IIdentity s_anonymousIdentity;

	private static X509SecurityTokenAuthenticator s_nonValidatingX509Authenticator;

	public const int MaxSecurityFaultSize = 16384;

	internal static X509SecurityTokenAuthenticator NonValidatingX509Authenticator
	{
		get
		{
			if (s_nonValidatingX509Authenticator == null)
			{
				s_nonValidatingX509Authenticator = new X509SecurityTokenAuthenticator(X509CertificateValidator.None);
			}
			return s_nonValidatingX509Authenticator;
		}
	}

	internal static IIdentity AnonymousIdentity
	{
		get
		{
			if (s_anonymousIdentity == null)
			{
				s_anonymousIdentity = CreateIdentity(string.Empty);
			}
			return s_anonymousIdentity;
		}
	}

	public static DateTime MaxUtcDateTime
	{
		get
		{
			DateTime maxValue = DateTime.MaxValue;
			return new DateTime(maxValue.Ticks - 864000000000L, DateTimeKind.Utc);
		}
	}

	public static DateTime MinUtcDateTime
	{
		get
		{
			DateTime minValue = DateTime.MinValue;
			return new DateTime(minValue.Ticks + 864000000000L, DateTimeKind.Utc);
		}
	}

	internal static bool IsChannelBindingDisabled => false;

	public static ChannelBinding GetChannelBindingFromMessage(Message message)
	{
		if (message == null)
		{
			return null;
		}
		ChannelBindingMessageProperty property = null;
		ChannelBindingMessageProperty.TryGet(message, out property);
		ChannelBinding result = null;
		if (property != null)
		{
			result = property.ChannelBinding;
		}
		return result;
	}

	internal static IIdentity CreateIdentity(string name)
	{
		return new GenericIdentity(name);
	}

	internal static EndpointIdentity CreateWindowsIdentity()
	{
		return CreateWindowsIdentity(spnOnly: false);
	}

	internal static EndpointIdentity CreateWindowsIdentity(NetworkCredential serverCredential)
	{
		if (serverCredential != null && !NetworkCredentialHelper.IsDefault(serverCredential))
		{
			string upnName = ((serverCredential.Domain == null || serverCredential.Domain.Length <= 0) ? serverCredential.UserName : (serverCredential.UserName + "@" + serverCredential.Domain));
			return EndpointIdentity.CreateUpnIdentity(upnName);
		}
		return CreateWindowsIdentity();
	}

	private static bool IsSystemAccount(WindowsIdentity self)
	{
		SecurityIdentifier user = self.User;
		if (user == (SecurityIdentifier)null)
		{
			return false;
		}
		if (!user.IsWellKnown((WellKnownSidType)22) && !user.IsWellKnown((WellKnownSidType)24) && !user.IsWellKnown((WellKnownSidType)23))
		{
			return ((IdentityReference)self.User).Value.StartsWith("S-1-5-82", StringComparison.OrdinalIgnoreCase);
		}
		return true;
	}

	internal static EndpointIdentity CreateWindowsIdentity(bool spnOnly)
	{
		EndpointIdentity result = null;
		WindowsIdentity current = WindowsIdentity.GetCurrent();
		try
		{
			bool flag = IsSystemAccount(current);
			result = ((!(spnOnly || flag)) ? new UpnEndpointIdentity(CloneWindowsIdentityIfNecessary(current)) : EndpointIdentity.CreateSpnIdentity(string.Format(CultureInfo.InvariantCulture, "host/{0}", DnsCache.MachineName)));
		}
		finally
		{
			((IDisposable)current)?.Dispose();
		}
		return result;
	}

	internal static WindowsIdentity CloneWindowsIdentityIfNecessary(WindowsIdentity wid)
	{
		return CloneWindowsIdentityIfNecessary(wid, null);
	}

	internal static WindowsIdentity CloneWindowsIdentityIfNecessary(WindowsIdentity wid, string authType)
	{
		if (wid != null)
		{
			IntPtr intPtr = UnsafeGetWindowsIdentityToken(wid);
			if (intPtr != IntPtr.Zero)
			{
				return UnsafeCreateWindowsIdentityFromToken(intPtr, authType);
			}
		}
		return wid;
	}

	private static IntPtr UnsafeGetWindowsIdentityToken(WindowsIdentity wid)
	{
		throw ExceptionHelper.PlatformNotSupported("UnsafeGetWindowsIdentityToken is not supported");
	}

	private static WindowsIdentity UnsafeCreateWindowsIdentityFromToken(IntPtr token, string authType)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		if (authType == null)
		{
			return new WindowsIdentity(token);
		}
		return new WindowsIdentity(token, authType);
	}

	internal static T GetSecurityKey<T>(SecurityToken token) where T : SecurityKey
	{
		T val = null;
		if (token.SecurityKeys != null)
		{
			for (int i = 0; i < token.SecurityKeys.Count; i++)
			{
				if (token.SecurityKeys[i] is T val2)
				{
					if (val != null)
					{
						throw DiagnosticUtility.ExceptionUtility.ThrowHelperWarning(new MessageSecurityException(System.SR.Format(System.SR.MultipleMatchingCryptosFound, typeof(T).ToString())));
					}
					val = val2;
				}
			}
		}
		return val;
	}

	internal static byte[] GenerateDerivedKey(SecurityToken tokenToDerive, string derivationAlgorithm, byte[] label, byte[] nonce, int keySize, int offset)
	{
		SymmetricSecurityKey securityKey = GetSecurityKey<SymmetricSecurityKey>(tokenToDerive);
		if (securityKey == null || !securityKey.IsSupportedAlgorithm(derivationAlgorithm))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperWarning(new MessageSecurityException(System.SR.Format(System.SR.CannotFindMatchingCrypto, derivationAlgorithm)));
		}
		return securityKey.GenerateDerivedKey(derivationAlgorithm, label, nonce, keySize, offset);
	}

	internal static string GetSpnFromIdentity(EndpointIdentity identity, EndpointAddress target)
	{
		bool flag = false;
		string result = null;
		if (identity != null)
		{
			if (ClaimTypes.Spn.Equals(identity.IdentityClaim.ClaimType))
			{
				result = (string)identity.IdentityClaim.Resource;
				flag = true;
			}
			else if (ClaimTypes.Upn.Equals(identity.IdentityClaim.ClaimType))
			{
				result = (string)identity.IdentityClaim.Resource;
				flag = true;
			}
			else if (ClaimTypes.Dns.Equals(identity.IdentityClaim.ClaimType))
			{
				result = string.Format(CultureInfo.InvariantCulture, "host/{0}", (string)identity.IdentityClaim.Resource);
				flag = true;
			}
		}
		if (!flag)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MessageSecurityException(System.SR.Format(System.SR.CannotDetermineSPNBasedOnAddress, target)));
		}
		return result;
	}

	internal static string GetSpnFromTarget(EndpointAddress target)
	{
		if (target == null)
		{
			throw Fx.AssertAndThrow("target should not be null - expecting an EndpointAddress");
		}
		return string.Format(CultureInfo.InvariantCulture, "host/{0}", target.Uri.DnsSafeHost);
	}

	internal static bool IsEqual(byte[] a, byte[] b)
	{
		if (a == null || b == null || a.Length != b.Length)
		{
			return false;
		}
		for (int i = 0; i < a.Length; i++)
		{
			if (a[i] != b[i])
			{
				return false;
			}
		}
		return true;
	}

	internal static bool IsSupportedAlgorithm(string algorithm, SecurityToken token)
	{
		if (token.SecurityKeys == null)
		{
			return false;
		}
		for (int i = 0; i < token.SecurityKeys.Count; i++)
		{
			if (token.SecurityKeys[i].IsSupportedAlgorithm(algorithm))
			{
				return true;
			}
		}
		return false;
	}

	internal static Claim GetPrimaryIdentityClaim(ReadOnlyCollection<IAuthorizationPolicy> authorizationPolicies)
	{
		return GetPrimaryIdentityClaim(AuthorizationContext.CreateDefaultAuthorizationContext(authorizationPolicies));
	}

	internal static Claim GetPrimaryIdentityClaim(AuthorizationContext authContext)
	{
		if (authContext != null)
		{
			for (int i = 0; i < authContext.ClaimSets.Count; i++)
			{
				ClaimSet claimSet = authContext.ClaimSets[i];
				using IEnumerator<Claim> enumerator = claimSet.FindClaims(null, Rights.Identity).GetEnumerator();
				if (enumerator.MoveNext())
				{
					return enumerator.Current;
				}
			}
		}
		return null;
	}

	internal static string GenerateId()
	{
		return SecurityUniqueId.Create().Value;
	}

	internal static ReadOnlyCollection<IAuthorizationPolicy> CreatePrincipalNameAuthorizationPolicies(string principalName)
	{
		if (principalName == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("principalName");
		}
		Claim item;
		Claim item2;
		if (principalName.Contains("@") || principalName.Contains("\\"))
		{
			item = new Claim(ClaimTypes.Upn, principalName, Rights.Identity);
			item2 = Claim.CreateUpnClaim(principalName);
		}
		else
		{
			item = new Claim(ClaimTypes.Spn, principalName, Rights.Identity);
			item2 = Claim.CreateSpnClaim(principalName);
		}
		List<Claim> list = new List<Claim>(2);
		list.Add(item);
		list.Add(item2);
		List<IAuthorizationPolicy> list2 = new List<IAuthorizationPolicy>(1);
		list2.Add(new UnconditionalPolicy(CreateIdentity(principalName), new DefaultClaimSet(ClaimSet.Anonymous, list)));
		return list2.AsReadOnly();
	}

	internal static string GetIdentityNamesFromContext(AuthorizationContext authContext)
	{
		if (authContext == null)
		{
			return string.Empty;
		}
		StringBuilder stringBuilder = new StringBuilder(256);
		for (int i = 0; i < authContext.ClaimSets.Count; i++)
		{
			ClaimSet claimSet = authContext.ClaimSets[i];
			if (claimSet is WindowsClaimSet windowsClaimSet)
			{
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append(", ");
				}
				AppendIdentityName(stringBuilder, (IIdentity)windowsClaimSet.WindowsIdentity);
			}
			else if (claimSet is X509CertificateClaimSet x509CertificateClaimSet)
			{
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append(", ");
				}
				AppendCertificateIdentityName(stringBuilder, x509CertificateClaimSet.X509Certificate);
			}
		}
		if (stringBuilder.Length <= 0)
		{
			List<IIdentity> list = null;
			if (authContext.Properties.TryGetValue("Identities", out var value))
			{
				list = value as List<IIdentity>;
			}
			if (list != null)
			{
				for (int j = 0; j < list.Count; j++)
				{
					IIdentity identity = list[j];
					if (identity != null)
					{
						if (stringBuilder.Length > 0)
						{
							stringBuilder.Append(", ");
						}
						AppendIdentityName(stringBuilder, identity);
					}
				}
			}
		}
		if (stringBuilder.Length > 0)
		{
			return stringBuilder.ToString();
		}
		return string.Empty;
	}

	internal static void AppendCertificateIdentityName(StringBuilder str, X509Certificate2 certificate)
	{
		string text = certificate.SubjectName.Name;
		if (string.IsNullOrEmpty(text))
		{
			text = certificate.GetNameInfo(X509NameType.DnsName, forIssuer: false);
			if (string.IsNullOrEmpty(text))
			{
				text = certificate.GetNameInfo(X509NameType.SimpleName, forIssuer: false);
				if (string.IsNullOrEmpty(text))
				{
					text = certificate.GetNameInfo(X509NameType.EmailName, forIssuer: false);
					if (string.IsNullOrEmpty(text))
					{
						text = certificate.GetNameInfo(X509NameType.UpnName, forIssuer: false);
					}
				}
			}
		}
		str.Append(string.IsNullOrEmpty(text) ? "<x509>" : text);
		str.Append("; ");
		str.Append(certificate.Thumbprint);
	}

	internal static void AppendIdentityName(StringBuilder str, IIdentity identity)
	{
		string text = null;
		try
		{
			text = identity.Name;
		}
		catch (Exception exception)
		{
			if (Fx.IsFatal(exception))
			{
				throw;
			}
		}
		str.Append(string.IsNullOrEmpty(text) ? "<null>" : text);
		WindowsIdentity val = (WindowsIdentity)((identity is WindowsIdentity) ? identity : null);
		if (val != null)
		{
			if (val.User != (SecurityIdentifier)null)
			{
				str.Append("; ");
				str.Append(((object)val.User).ToString());
			}
		}
		else if (identity is WindowsSidIdentity windowsSidIdentity)
		{
			str.Append("; ");
			str.Append(((object)windowsSidIdentity.SecurityIdentifier).ToString());
		}
	}

	internal static bool IsSecurityBindingSuitableForChannelBinding(TransportSecurityBindingElement securityBindingElement)
	{
		if (securityBindingElement == null)
		{
			return false;
		}
		if (AreSecurityTokenParametersSuitableForChannelBinding(securityBindingElement.EndpointSupportingTokenParameters.Endorsing))
		{
			return true;
		}
		if (AreSecurityTokenParametersSuitableForChannelBinding(securityBindingElement.EndpointSupportingTokenParameters.Signed))
		{
			return true;
		}
		if (AreSecurityTokenParametersSuitableForChannelBinding(securityBindingElement.EndpointSupportingTokenParameters.SignedEncrypted))
		{
			return true;
		}
		if (AreSecurityTokenParametersSuitableForChannelBinding(securityBindingElement.EndpointSupportingTokenParameters.SignedEndorsing))
		{
			return true;
		}
		return false;
	}

	internal static bool AreSecurityTokenParametersSuitableForChannelBinding(Collection<SecurityTokenParameters> tokenParameters)
	{
		if (tokenParameters == null)
		{
			return false;
		}
		foreach (SecurityTokenParameters tokenParameter in tokenParameters)
		{
			if (tokenParameter is SecureConversationSecurityTokenParameters secureConversationSecurityTokenParameters)
			{
				return IsSecurityBindingSuitableForChannelBinding(secureConversationSecurityTokenParameters.BootstrapSecurityBindingElement as TransportSecurityBindingElement);
			}
		}
		return false;
	}

	internal static Task OpenTokenProviderIfRequiredAsync(SecurityTokenProvider tokenProvider, TimeSpan timeout)
	{
		if (tokenProvider is IAsyncCommunicationObject obj)
		{
			return OpenCommunicationObjectAsync(obj, timeout);
		}
		if (tokenProvider is ICommunicationObject communicationObject && communicationObject != null)
		{
			return Task.Factory.FromAsync(communicationObject.BeginOpen, communicationObject.EndOpen, timeout, null, TaskCreationOptions.None);
		}
		return Task.CompletedTask;
	}

	internal static void OpenTokenProviderIfRequired(SecurityTokenProvider tokenProvider, TimeSpan timeout)
	{
		OpenCommunicationObject(tokenProvider as ICommunicationObject, timeout);
	}

	internal static void CloseTokenProviderIfRequired(SecurityTokenProvider tokenProvider, TimeSpan timeout)
	{
		CloseCommunicationObject(tokenProvider, aborted: false, timeout);
	}

	internal static Task CloseTokenProviderIfRequiredAsync(SecurityTokenProvider tokenProvider, TimeSpan timeout)
	{
		if (tokenProvider is IAsyncCommunicationObject obj)
		{
			return CloseCommunicationObjectAsync(obj, aborted: false, timeout);
		}
		if (tokenProvider is ICommunicationObject communicationObject && communicationObject != null)
		{
			return Task.Factory.FromAsync(communicationObject.BeginClose, communicationObject.EndClose, timeout, null, TaskCreationOptions.None);
		}
		return Task.CompletedTask;
	}

	internal static void AbortTokenProviderIfRequired(SecurityTokenProvider tokenProvider)
	{
		CloseCommunicationObject(tokenProvider, aborted: true, TimeSpan.Zero);
	}

	internal static void OpenTokenAuthenticatorIfRequired(SecurityTokenAuthenticator tokenAuthenticator, TimeSpan timeout)
	{
		OpenCommunicationObject(tokenAuthenticator as ICommunicationObject, timeout);
	}

	internal static void CloseTokenAuthenticatorIfRequired(SecurityTokenAuthenticator tokenAuthenticator, TimeSpan timeout)
	{
		CloseTokenAuthenticatorIfRequired(tokenAuthenticator, aborted: false, timeout);
	}

	internal static void CloseTokenAuthenticatorIfRequired(SecurityTokenAuthenticator tokenAuthenticator, bool aborted, TimeSpan timeout)
	{
		CloseCommunicationObject(tokenAuthenticator, aborted, timeout);
	}

	internal static void AbortTokenAuthenticatorIfRequired(SecurityTokenAuthenticator tokenAuthenticator)
	{
		CloseCommunicationObject(tokenAuthenticator, aborted: true, TimeSpan.Zero);
	}

	private static Task OpenCommunicationObjectAsync(IAsyncCommunicationObject obj, TimeSpan timeout)
	{
		if (obj != null)
		{
			return obj.OpenAsync(timeout);
		}
		return Task.CompletedTask;
	}

	private static void OpenCommunicationObject(ICommunicationObject obj, TimeSpan timeout)
	{
		obj?.Open(timeout);
	}

	private static Task CloseCommunicationObjectAsync(IAsyncCommunicationObject obj, bool aborted, TimeSpan timeout)
	{
		if (obj != null)
		{
			if (!aborted)
			{
				return obj.CloseAsync(timeout);
			}
			try
			{
				obj.Abort();
			}
			catch (CommunicationException)
			{
			}
		}
		return Task.CompletedTask;
	}

	private static void CloseCommunicationObject(object obj, bool aborted, TimeSpan timeout)
	{
		if (obj == null)
		{
			return;
		}
		if (obj is ICommunicationObject communicationObject)
		{
			if (aborted)
			{
				try
				{
					communicationObject.Abort();
					return;
				}
				catch (CommunicationException)
				{
					return;
				}
			}
			communicationObject.Close(timeout);
		}
		else if (obj is IDisposable)
		{
			((IDisposable)obj).Dispose();
		}
	}

	internal static SecurityStandardsManager CreateSecurityStandardsManager(MessageSecurityVersion securityVersion, SecurityTokenManager tokenManager)
	{
		SecurityTokenSerializer tokenSerializer = tokenManager.CreateSecurityTokenSerializer(securityVersion.SecurityTokenVersion);
		return new SecurityStandardsManager(securityVersion, tokenSerializer);
	}

	internal static SecurityStandardsManager CreateSecurityStandardsManager(SecurityTokenRequirement requirement, SecurityTokenManager tokenManager)
	{
		MessageSecurityTokenVersion property = requirement.GetProperty<MessageSecurityTokenVersion>(ServiceModelSecurityTokenRequirement.MessageSecurityVersionProperty);
		if (property == MessageSecurityTokenVersion.WSSecurity10WSTrustFebruary2005WSSecureConversationFebruary2005BasicSecurityProfile10)
		{
			return CreateSecurityStandardsManager(MessageSecurityVersion.WSSecurity10WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11BasicSecurityProfile10, tokenManager);
		}
		if (property == MessageSecurityTokenVersion.WSSecurity11WSTrustFebruary2005WSSecureConversationFebruary2005)
		{
			return CreateSecurityStandardsManager(MessageSecurityVersion.WSSecurity11WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11, tokenManager);
		}
		if (property == MessageSecurityTokenVersion.WSSecurity11WSTrustFebruary2005WSSecureConversationFebruary2005BasicSecurityProfile10)
		{
			return CreateSecurityStandardsManager(MessageSecurityVersion.WSSecurity11WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11BasicSecurityProfile10, tokenManager);
		}
		if (property == MessageSecurityTokenVersion.WSSecurity10WSTrust13WSSecureConversation13BasicSecurityProfile10)
		{
			return CreateSecurityStandardsManager(MessageSecurityVersion.WSSecurity10WSTrust13WSSecureConversation13WSSecurityPolicy12BasicSecurityProfile10, tokenManager);
		}
		if (property == MessageSecurityTokenVersion.WSSecurity11WSTrust13WSSecureConversation13)
		{
			return CreateSecurityStandardsManager(MessageSecurityVersion.WSSecurity11WSTrust13WSSecureConversation13WSSecurityPolicy12, tokenManager);
		}
		if (property == MessageSecurityTokenVersion.WSSecurity11WSTrust13WSSecureConversation13BasicSecurityProfile10)
		{
			return CreateSecurityStandardsManager(MessageSecurityVersion.WSSecurity11WSTrust13WSSecureConversation13WSSecurityPolicy12BasicSecurityProfile10, tokenManager);
		}
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException());
	}

	internal static SecurityStandardsManager CreateSecurityStandardsManager(MessageSecurityVersion securityVersion, SecurityTokenSerializer securityTokenSerializer)
	{
		if (securityVersion == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("securityVersion"));
		}
		if (securityTokenSerializer == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("securityTokenSerializer");
		}
		return new SecurityStandardsManager(securityVersion, securityTokenSerializer);
	}

	internal static NetworkCredential GetNetworkCredentialsCopy(NetworkCredential networkCredential)
	{
		if (networkCredential != null && !NetworkCredentialHelper.IsDefault(networkCredential))
		{
			return new NetworkCredential(networkCredential.UserName, networkCredential.Password, networkCredential.Domain);
		}
		return networkCredential;
	}

	internal static NetworkCredential GetNetworkCredentialOrDefault(NetworkCredential credential)
	{
		if (NetworkCredentialHelper.IsNullOrEmpty(credential))
		{
			return CredentialCache.DefaultNetworkCredentials;
		}
		return credential;
	}

	public static bool TryCreateKeyFromIntrinsicKeyClause(SecurityKeyIdentifierClause keyIdentifierClause, SecurityTokenResolver resolver, out SecurityKey key)
	{
		key = null;
		if (keyIdentifierClause.CanCreateKey)
		{
			key = keyIdentifierClause.CreateKey();
			return true;
		}
		if (keyIdentifierClause is EncryptedKeyIdentifierClause)
		{
			EncryptedKeyIdentifierClause encryptedKeyIdentifierClause = (EncryptedKeyIdentifierClause)keyIdentifierClause;
			for (int i = 0; i < encryptedKeyIdentifierClause.EncryptingKeyIdentifier.Count; i++)
			{
				SecurityKey key2 = null;
				if (resolver.TryResolveSecurityKey(encryptedKeyIdentifierClause.EncryptingKeyIdentifier[i], out key2))
				{
					byte[] encryptedKey = encryptedKeyIdentifierClause.GetEncryptedKey();
					string encryptionMethod = encryptedKeyIdentifierClause.EncryptionMethod;
					byte[] symmetricKey = key2.DecryptKey(encryptionMethod, encryptedKey);
					key = new InMemorySymmetricSecurityKey(symmetricKey, cloneBuffer: false);
					return true;
				}
			}
		}
		return false;
	}

	internal static string AppendWindowsAuthenticationInfo(string inputString, NetworkCredential credential, AuthenticationLevel authenticationLevel, TokenImpersonationLevel impersonationLevel)
	{
		if (NetworkCredentialHelper.IsDefault(credential))
		{
			string currentUserIdAsString = NetworkCredentialHelper.GetCurrentUserIdAsString(credential);
			return inputString + "\0" + currentUserIdAsString + "\0" + AuthenticationLevelHelper.ToString(authenticationLevel) + "\0" + TokenImpersonationLevelHelper.ToString(impersonationLevel);
		}
		return inputString + "\0" + credential.Domain + "\0" + credential.UserName + "\0" + credential.Password + "\0" + AuthenticationLevelHelper.ToString(authenticationLevel) + "\0" + TokenImpersonationLevelHelper.ToString(impersonationLevel);
	}

	internal static SecurityToken CreateTokenFromEncryptedKeyClause(EncryptedKeyIdentifierClause keyClause, SecurityToken unwrappingToken)
	{
		throw new NotImplementedException();
	}

	internal static byte[] CloneBuffer(byte[] buffer)
	{
		byte[] array = Fx.AllocateByteArray(buffer.Length);
		Buffer.BlockCopy(buffer, 0, array, 0, buffer.Length);
		return array;
	}

	internal static ReadOnlyCollection<SecurityKey> CreateSymmetricSecurityKeys(byte[] key)
	{
		List<SecurityKey> list = new List<SecurityKey>(1);
		list.Add(new InMemorySymmetricSecurityKey(key));
		return list.AsReadOnly();
	}

	internal static string GetKeyDerivationAlgorithm(SecureConversationVersion version)
	{
		string text = null;
		if (version == SecureConversationVersion.WSSecureConversationFeb2005)
		{
			return "http://schemas.xmlsoap.org/ws/2005/02/sc/dk/p_sha1";
		}
		if (version == SecureConversationVersion.WSSecureConversation13)
		{
			return "http://docs.oasis-open.org/ws-sx/ws-secureconversation/200512/dk/p_sha1";
		}
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException());
	}

	internal static X509Certificate2 GetCertificateFromStore(StoreName storeName, StoreLocation storeLocation, X509FindType findType, object findValue, EndpointAddress target)
	{
		X509Certificate2 certificateFromStoreCore = GetCertificateFromStoreCore(storeName, storeLocation, findType, findValue, target, throwIfMultipleOrNoMatch: true);
		if (certificateFromStoreCore == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.CannotFindCert, storeName, storeLocation, findType, findValue)));
		}
		return certificateFromStoreCore;
	}

	internal static bool TryGetCertificateFromStore(StoreName storeName, StoreLocation storeLocation, X509FindType findType, object findValue, EndpointAddress target, out X509Certificate2 certificate)
	{
		certificate = GetCertificateFromStoreCore(storeName, storeLocation, findType, findValue, target, throwIfMultipleOrNoMatch: false);
		return certificate != null;
	}

	private static X509Certificate2 GetCertificateFromStoreCore(StoreName storeName, StoreLocation storeLocation, X509FindType findType, object findValue, EndpointAddress target, bool throwIfMultipleOrNoMatch)
	{
		if (findValue == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("findValue");
		}
		X509Store x509Store = new X509Store(storeName, storeLocation);
		X509Certificate2Collection x509Certificate2Collection = null;
		try
		{
			x509Store.Open(OpenFlags.ReadOnly);
			x509Certificate2Collection = x509Store.Certificates.Find(findType, findValue, validOnly: false);
			if (x509Certificate2Collection.Count == 1)
			{
				return new X509Certificate2(x509Certificate2Collection[0]);
			}
			if (throwIfMultipleOrNoMatch)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(CreateCertificateLoadException(storeName, storeLocation, findType, findValue, target, x509Certificate2Collection.Count));
			}
			return null;
		}
		finally
		{
			ResetAllCertificates(x509Certificate2Collection);
			x509Store.Dispose();
		}
	}

	internal static Exception CreateCertificateLoadException(StoreName storeName, StoreLocation storeLocation, X509FindType findType, object findValue, EndpointAddress target, int certCount)
	{
		if (certCount == 0)
		{
			if (target == null)
			{
				return new InvalidOperationException(System.SR.Format(System.SR.CannotFindCert, storeName, storeLocation, findType, findValue));
			}
			return new InvalidOperationException(System.SR.Format(System.SR.CannotFindCertForTarget, storeName, storeLocation, findType, findValue, target));
		}
		if (target == null)
		{
			return new InvalidOperationException(System.SR.Format(System.SR.FoundMultipleCerts, storeName, storeLocation, findType, findValue));
		}
		return new InvalidOperationException(System.SR.Format(System.SR.FoundMultipleCertsForTarget, storeName, storeLocation, findType, findValue, target));
	}

	public static SecurityBindingElement GetIssuerSecurityBindingElement(ServiceModelSecurityTokenRequirement requirement)
	{
		SecurityBindingElement secureConversationSecurityBindingElement = requirement.SecureConversationSecurityBindingElement;
		if (secureConversationSecurityBindingElement != null)
		{
			return secureConversationSecurityBindingElement;
		}
		Binding issuerBinding = requirement.IssuerBinding;
		if (issuerBinding == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument(System.SR.Format(System.SR.IssuerBindingNotPresentInTokenRequirement, requirement));
		}
		BindingElementCollection bindingElementCollection = issuerBinding.CreateBindingElements();
		return bindingElementCollection.Find<SecurityBindingElement>();
	}

	internal static void FixNetworkCredential(ref NetworkCredential credential)
	{
		if (credential == null)
		{
			return;
		}
		string userName = credential.UserName;
		string domain = credential.Domain;
		if (string.IsNullOrEmpty(userName) || !string.IsNullOrEmpty(domain))
		{
			return;
		}
		string[] array = userName.Split(new char[1] { '\\' });
		string[] array2 = userName.Split(new char[1] { '@' });
		if (array.Length == 2 && array2.Length == 1)
		{
			if (!string.IsNullOrEmpty(array[0]) && !string.IsNullOrEmpty(array[1]))
			{
				credential = new NetworkCredential(array[1], credential.Password, array[0]);
			}
		}
		else if (array.Length == 1 && array2.Length == 2 && !string.IsNullOrEmpty(array2[0]) && !string.IsNullOrEmpty(array2[1]))
		{
			credential = new NetworkCredential(array2[0], credential.Password, array2[1]);
		}
	}

	internal static bool IsSecurityFault(MessageFault fault, SecurityStandardsManager standardsManager)
	{
		if (fault.Code.IsSenderFault)
		{
			FaultCode subCode = fault.Code.SubCode;
			if (subCode != null)
			{
				if (!(subCode.Namespace == standardsManager.SecurityVersion.HeaderNamespace.Value) && !(subCode.Namespace == standardsManager.SecureConversationDriver.Namespace.Value) && !(subCode.Namespace == standardsManager.TrustDriver.Namespace.Value))
				{
					return subCode.Namespace == "http://schemas.microsoft.com/ws/2006/05/security";
				}
				return true;
			}
		}
		return false;
	}

	internal static Exception CreateSecurityFaultException(MessageFault fault)
	{
		FaultException innerException = FaultException.CreateFault(fault, typeof(string), typeof(object));
		return new MessageSecurityException(System.SR.UnsecuredMessageFaultReceived, innerException);
	}

	public static void ValidateAnonymityConstraint(WindowsIdentity identity, bool allowUnauthenticatedCallers)
	{
		if (!allowUnauthenticatedCallers && identity.User.IsWellKnown((WellKnownSidType)13))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperWarning(new SecurityTokenValidationException(System.SR.Format(System.SR.AnonymousLogonsAreNotAllowed)));
		}
	}

	public static bool TryCreateX509CertificateFromRawData(byte[] rawData, out X509Certificate2 certificate)
	{
		certificate = ((rawData == null || rawData.Length == 0) ? null : new X509Certificate2(rawData));
		if (certificate != null)
		{
			return certificate.Handle != IntPtr.Zero;
		}
		return false;
	}

	internal static void ResetAllCertificates(X509Certificate2Collection certificates)
	{
		if (certificates != null)
		{
			for (int i = 0; i < certificates.Count; i++)
			{
				ResetCertificate(certificates[i]);
			}
		}
	}

	internal static void ResetCertificate(X509Certificate2 certificate)
	{
		certificate.Dispose();
	}

	internal static void ThrowIfNegotiationFault(Message message, EndpointAddress target)
	{
		if (!message.IsFault)
		{
			return;
		}
		MessageFault messageFault = MessageFault.CreateFault(message, 16384);
		Exception ex = new FaultException(messageFault, message.Headers.Action);
		if (messageFault.Code != null && messageFault.Code.IsReceiverFault && messageFault.Code.SubCode != null)
		{
			FaultCode subCode = messageFault.Code.SubCode;
			if (subCode.Name == "ServerTooBusy" && subCode.Namespace == "http://schemas.microsoft.com/ws/2006/05/security")
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ServerTooBusyException(System.SR.Format(System.SR.SecurityServerTooBusy, target), ex));
			}
			if (subCode.Name == "EndpointUnavailable" && subCode.Namespace == message.Version.Addressing.Namespace())
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new EndpointNotFoundException(System.SR.Format(System.SR.SecurityEndpointNotFound, target), ex));
			}
		}
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(ex);
	}
}
