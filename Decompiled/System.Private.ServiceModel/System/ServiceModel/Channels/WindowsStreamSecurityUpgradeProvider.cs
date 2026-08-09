using System.Collections.ObjectModel;
using System.IO;
using System.IdentityModel.Policy;
using System.IdentityModel.Selectors;
using System.Net;
using System.Net.Security;
using System.Runtime;
using System.Security.Authentication;
using System.Security.Principal;
using System.ServiceModel.Description;
using System.ServiceModel.Security;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal class WindowsStreamSecurityUpgradeProvider : StreamSecurityUpgradeProvider
{
	private class WindowsStreamSecurityUpgradeInitiator : StreamSecurityUpgradeInitiatorBase
	{
		private WindowsStreamSecurityUpgradeProvider _parent;

		private IdentityVerifier _identityVerifier;

		private NetworkCredential _credential;

		private TokenImpersonationLevel _impersonationLevel;

		private SspiSecurityTokenProvider _clientTokenProvider;

		private bool _allowNtlm;

		public WindowsStreamSecurityUpgradeInitiator(WindowsStreamSecurityUpgradeProvider parent, EndpointAddress remoteAddress, Uri via)
			: base("application/negotiate", remoteAddress, via)
		{
			_parent = parent;
			_clientTokenProvider = TransportSecurityHelpers.GetSspiTokenProvider(parent._securityTokenManager, remoteAddress, via, parent.Scheme, out _identityVerifier);
		}

		internal override async Task OpenAsync(TimeSpan timeout)
		{
			TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
			base.Open(timeoutHelper.RemainingTime());
			OutWrapper<TokenImpersonationLevel> impersonationLevelWrapper = new OutWrapper<TokenImpersonationLevel>();
			OutWrapper<bool> allowNtlmWrapper = new OutWrapper<bool>();
			SecurityUtils.OpenTokenProviderIfRequired(_clientTokenProvider, timeoutHelper.RemainingTime());
			_credential = await TransportSecurityHelpers.GetSspiCredentialAsync(_clientTokenProvider, impersonationLevelWrapper, allowNtlmWrapper, timeoutHelper.RemainingTime());
			_impersonationLevel = impersonationLevelWrapper.Value;
			_allowNtlm = allowNtlmWrapper;
		}

		internal override void Open(TimeSpan timeout)
		{
			OpenAsync(timeout).GetAwaiter();
		}

		internal override void Close(TimeSpan timeout)
		{
			TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
			base.Close(timeoutHelper.RemainingTime());
			SecurityUtils.CloseTokenProviderIfRequired(_clientTokenProvider, timeoutHelper.RemainingTime());
		}

		private static SecurityMessageProperty CreateServerSecurity(NegotiateStream negotiateStream)
		{
			GenericIdentity genericIdentity = (GenericIdentity)negotiateStream.RemoteIdentity;
			string name = genericIdentity.Name;
			if (name != null && name.Length > 0)
			{
				ReadOnlyCollection<IAuthorizationPolicy> readOnlyCollection = SecurityUtils.CreatePrincipalNameAuthorizationPolicies(name);
				SecurityMessageProperty securityMessageProperty = new SecurityMessageProperty();
				securityMessageProperty.TransportToken = new SecurityTokenSpecification(null, readOnlyCollection);
				securityMessageProperty.ServiceSecurityContext = new ServiceSecurityContext(readOnlyCollection);
				return securityMessageProperty;
			}
			return null;
		}

		protected override Stream OnInitiateUpgrade(Stream stream, out SecurityMessageProperty remoteSecurity)
		{
			OutWrapper<SecurityMessageProperty> outWrapper = new OutWrapper<SecurityMessageProperty>();
			Stream result = OnInitiateUpgradeAsync(stream, outWrapper).GetAwaiter().GetResult();
			remoteSecurity = outWrapper.Value;
			return result;
		}

		protected override async Task<Stream> OnInitiateUpgradeAsync(Stream stream, OutWrapper<SecurityMessageProperty> remoteSecurity)
		{
			if (WcfEventSource.Instance.WindowsStreamSecurityOnInitiateUpgradeIsEnabled())
			{
				WcfEventSource.Instance.WindowsStreamSecurityOnInitiateUpgrade();
			}
			InitiateUpgradePrepare(stream, out var negotiateStream, out var targetName, out var identity);
			try
			{
				await negotiateStream.AuthenticateAsClientAsync(_credential, targetName, _parent.ProtectionLevel, _impersonationLevel);
			}
			catch (AuthenticationException ex)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new SecurityNegotiationException(ex.Message, ex));
			}
			catch (IOException ex2)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new SecurityNegotiationException(System.SR.Format(System.SR.NegotiationFailedIO, ex2.Message), ex2));
			}
			remoteSecurity.Value = CreateServerSecurity(negotiateStream);
			ValidateMutualAuth(identity, negotiateStream, remoteSecurity.Value, _allowNtlm);
			return negotiateStream;
		}

		private void InitiateUpgradePrepare(Stream stream, out NegotiateStream negotiateStream, out string targetName, out EndpointIdentity identity)
		{
			negotiateStream = new NegotiateStream(stream);
			targetName = string.Empty;
			identity = null;
			if (_parent.IdentityVerifier.TryGetIdentity(base.RemoteAddress, base.Via, out identity))
			{
				targetName = SecurityUtils.GetSpnFromIdentity(identity, base.RemoteAddress);
			}
			else
			{
				targetName = SecurityUtils.GetSpnFromTarget(base.RemoteAddress);
			}
		}

		private void ValidateMutualAuth(EndpointIdentity expectedIdentity, NegotiateStream negotiateStream, SecurityMessageProperty remoteSecurity, bool allowNtlm)
		{
			if (negotiateStream.IsMutuallyAuthenticated)
			{
				if (expectedIdentity != null && !_parent.IdentityVerifier.CheckAccess(expectedIdentity, remoteSecurity.ServiceSecurityContext.AuthorizationContext))
				{
					string identityNamesFromContext = SecurityUtils.GetIdentityNamesFromContext(remoteSecurity.ServiceSecurityContext.AuthorizationContext);
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new SecurityNegotiationException(System.SR.Format(System.SR.RemoteIdentityFailedVerification, identityNamesFromContext)));
				}
			}
			else if (!allowNtlm)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new SecurityNegotiationException(System.SR.Format(System.SR.StreamMutualAuthNotSatisfied)));
			}
		}
	}

	private bool _extractGroupsForWindowsAccounts;

	private EndpointIdentity _identity;

	private SecurityTokenManager _securityTokenManager;

	private bool _isClient;

	private Uri _listenUri;

	public string Scheme { get; }

	internal bool ExtractGroupsForWindowsAccounts => _extractGroupsForWindowsAccounts;

	public override EndpointIdentity Identity
	{
		get
		{
			if (ServerCredential != null && _identity == null)
			{
				lock (base.ThisLock)
				{
					if (_identity == null)
					{
						_identity = SecurityUtils.CreateWindowsIdentity(ServerCredential);
					}
				}
			}
			return _identity;
		}
	}

	internal IdentityVerifier IdentityVerifier { get; private set; }

	public ProtectionLevel ProtectionLevel { get; }

	private NetworkCredential ServerCredential { get; set; }

	public WindowsStreamSecurityUpgradeProvider(WindowsStreamSecurityBindingElement bindingElement, BindingContext context, bool isClient)
		: base(context.Binding)
	{
		_extractGroupsForWindowsAccounts = true;
		ProtectionLevel = bindingElement.ProtectionLevel;
		Scheme = context.Binding.Scheme;
		_isClient = isClient;
		_listenUri = TransportSecurityHelpers.GetListenUri(context.ListenUriBaseAddress, context.ListenUriRelativeAddress);
		SecurityCredentialsManager securityCredentialsManager = context.BindingParameters.Find<SecurityCredentialsManager>();
		if (securityCredentialsManager == null)
		{
			securityCredentialsManager = ClientCredentials.CreateDefaultCredentials();
		}
		_securityTokenManager = securityCredentialsManager.CreateSecurityTokenManager();
	}

	public override StreamUpgradeInitiator CreateUpgradeInitiator(EndpointAddress remoteAddress, Uri via)
	{
		ThrowIfDisposedOrNotOpen();
		return new WindowsStreamSecurityUpgradeInitiator(this, remoteAddress, via);
	}

	protected override void OnAbort()
	{
	}

	protected override void OnClose(TimeSpan timeout)
	{
	}

	protected internal override Task OnCloseAsync(TimeSpan timeout)
	{
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

	protected override void OnOpen(TimeSpan timeout)
	{
		if (!_isClient)
		{
			SecurityTokenRequirement sspiTokenRequirement = TransportSecurityHelpers.CreateSspiTokenRequirement(Scheme, _listenUri);
			ServerCredential = TransportSecurityHelpers.GetSspiCredential(_securityTokenManager, sspiTokenRequirement, timeout, out _extractGroupsForWindowsAccounts);
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

	protected override void OnOpened()
	{
		base.OnOpened();
		if (IdentityVerifier == null)
		{
			IdentityVerifier = IdentityVerifier.CreateDefault();
		}
		if (ServerCredential == null)
		{
			ServerCredential = CredentialCache.DefaultNetworkCredentials;
		}
	}
}
