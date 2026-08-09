using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IdentityModel.Claims;
using System.IdentityModel.Policy;
using System.Runtime;
using System.Runtime.Diagnostics;
using System.ServiceModel.Diagnostics;

namespace System.ServiceModel.Security;

public abstract class IdentityVerifier
{
	private class DefaultIdentityVerifier : IdentityVerifier
	{
		public static DefaultIdentityVerifier Instance { get; } = new DefaultIdentityVerifier();

		public override bool TryGetIdentity(EndpointAddress reference, out EndpointIdentity identity)
		{
			if (reference == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("reference");
			}
			identity = reference.Identity;
			if (identity == null)
			{
				identity = TryCreateDnsIdentity(reference);
			}
			if (identity == null)
			{
				SecurityTraceRecordHelper.TraceIdentityDeterminationFailure(reference, typeof(DefaultIdentityVerifier));
				return false;
			}
			SecurityTraceRecordHelper.TraceIdentityDeterminationSuccess(reference, identity, typeof(DefaultIdentityVerifier));
			return true;
		}

		private EndpointIdentity TryCreateDnsIdentity(EndpointAddress reference)
		{
			Uri uri = reference.Uri;
			if (!uri.IsAbsoluteUri)
			{
				return null;
			}
			return EndpointIdentity.CreateDnsIdentity(uri.DnsSafeHost);
		}

		internal Claim CheckDnsEquivalence(ClaimSet claimSet, string expectedSpn)
		{
			IEnumerable<Claim> enumerable = claimSet.FindClaims(ClaimTypes.Spn, Rights.PossessProperty);
			foreach (Claim item in enumerable)
			{
				if (expectedSpn.Equals((string)item.Resource, StringComparison.OrdinalIgnoreCase))
				{
					return item;
				}
			}
			return null;
		}

		public override bool CheckAccess(EndpointIdentity identity, AuthorizationContext authContext)
		{
			EventTraceActivity eventTraceActivity = null;
			if (identity == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("identity");
			}
			if (authContext == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("authContext");
			}
			if (FxTrace.Trace.IsEnd2EndActivityTracingEnabled)
			{
				eventTraceActivity = EventTraceActivityHelper.TryExtractActivity((OperationContext.Current != null) ? OperationContext.Current.IncomingMessage : null);
			}
			for (int i = 0; i < authContext.ClaimSets.Count; i++)
			{
				ClaimSet claimSet = authContext.ClaimSets[i];
				if (claimSet.ContainsClaim(identity.IdentityClaim))
				{
					SecurityTraceRecordHelper.TraceIdentityVerificationSuccess(eventTraceActivity, identity, identity.IdentityClaim, GetType());
					return true;
				}
				string text = null;
				if (ClaimTypes.Dns.Equals(identity.IdentityClaim.ClaimType))
				{
					text = string.Format(CultureInfo.InvariantCulture, "host/{0}", (string)identity.IdentityClaim.Resource);
					Claim claim = CheckDnsEquivalence(claimSet, text);
					if (claim != null)
					{
						SecurityTraceRecordHelper.TraceIdentityVerificationSuccess(eventTraceActivity, identity, claim, GetType());
						return true;
					}
				}
			}
			SecurityTraceRecordHelper.TraceIdentityVerificationFailure(identity, authContext, GetType());
			if (WcfEventSource.Instance.SecurityIdentityVerificationFailureIsEnabled())
			{
				WcfEventSource.Instance.SecurityIdentityVerificationFailure(eventTraceActivity);
			}
			return false;
		}
	}

	public static IdentityVerifier CreateDefault()
	{
		return DefaultIdentityVerifier.Instance;
	}

	public abstract bool CheckAccess(EndpointIdentity identity, AuthorizationContext authContext);

	public abstract bool TryGetIdentity(EndpointAddress reference, out EndpointIdentity identity);

	private static void AdjustAddress(ref EndpointAddress reference, Uri via)
	{
		if (reference.Identity == null && reference.Uri != via)
		{
			reference = new EndpointAddress(via);
		}
	}

	internal bool TryGetIdentity(EndpointAddress reference, Uri via, out EndpointIdentity identity)
	{
		AdjustAddress(ref reference, via);
		return TryGetIdentity(reference, out identity);
	}

	internal void EnsureOutgoingIdentity(EndpointAddress serviceReference, Uri via, AuthorizationContext authorizationContext)
	{
		AdjustAddress(ref serviceReference, via);
		EnsureIdentity(serviceReference, authorizationContext, System.SR.IdentityCheckFailedForOutgoingMessage);
	}

	internal void EnsureOutgoingIdentity(EndpointAddress serviceReference, ReadOnlyCollection<IAuthorizationPolicy> authorizationPolicies)
	{
		if (authorizationPolicies == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("authorizationPolicies");
		}
		AuthorizationContext authorizationContext = AuthorizationContext.CreateDefaultAuthorizationContext(authorizationPolicies);
		EnsureIdentity(serviceReference, authorizationContext, System.SR.IdentityCheckFailedForOutgoingMessage);
	}

	private void EnsureIdentity(EndpointAddress serviceReference, AuthorizationContext authorizationContext, string errorString)
	{
		if (authorizationContext == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("authorizationContext");
		}
		if (!TryGetIdentity(serviceReference, out var identity))
		{
			SecurityTraceRecordHelper.TraceIdentityVerificationFailure(identity, authorizationContext, GetType());
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperWarning(new MessageSecurityException(System.SR.Format(errorString, identity, serviceReference)));
		}
		if (!CheckAccess(identity, authorizationContext))
		{
			Exception exception = CreateIdentityCheckException(identity, authorizationContext, errorString, serviceReference);
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperWarning(exception);
		}
	}

	private Exception CreateIdentityCheckException(EndpointIdentity identity, AuthorizationContext authorizationContext, string errorString, EndpointAddress serviceReference)
	{
		if (identity.IdentityClaim != null && identity.IdentityClaim.ClaimType == ClaimTypes.Dns && identity.IdentityClaim.Right == Rights.PossessProperty && identity.IdentityClaim.Resource is string)
		{
			string p = (string)identity.IdentityClaim.Resource;
			string text = null;
			for (int i = 0; i < authorizationContext.ClaimSets.Count; i++)
			{
				ClaimSet claimSet = authorizationContext.ClaimSets[i];
				foreach (Claim item in claimSet.FindClaims(ClaimTypes.Dns, Rights.PossessProperty))
				{
					if (item.Resource is string)
					{
						text = (string)item.Resource;
						break;
					}
				}
				if (text != null)
				{
					break;
				}
			}
			if (System.SR.IdentityCheckFailedForIncomingMessage.Equals(errorString))
			{
				if (text == null)
				{
					return new MessageSecurityException(System.SR.Format(System.SR.DnsIdentityCheckFailedForIncomingMessageLackOfDnsClaim, p));
				}
				return new MessageSecurityException(System.SR.Format(System.SR.DnsIdentityCheckFailedForIncomingMessage, p, text));
			}
			if (System.SR.IdentityCheckFailedForOutgoingMessage.Equals(errorString))
			{
				if (text == null)
				{
					return new MessageSecurityException(System.SR.Format(System.SR.DnsIdentityCheckFailedForOutgoingMessageLackOfDnsClaim, p));
				}
				return new MessageSecurityException(System.SR.Format(System.SR.DnsIdentityCheckFailedForOutgoingMessage, p, text));
			}
			return new MessageSecurityException(System.SR.Format(errorString, identity, serviceReference));
		}
		return new MessageSecurityException(System.SR.Format(errorString, identity, serviceReference));
	}
}
