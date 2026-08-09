using System.IdentityModel.Claims;
using System.IdentityModel.Policy;
using System.Runtime.Diagnostics;

namespace System.ServiceModel.Diagnostics;

internal static class SecurityTraceRecordHelper
{
	internal static void TraceIdentityVerificationSuccess(EventTraceActivity eventTraceActivity, EndpointIdentity identity, Claim claim, Type identityVerifier)
	{
	}

	internal static void TraceIdentityVerificationFailure(EndpointIdentity identity, AuthorizationContext authContext, Type identityVerifier)
	{
	}

	internal static void TraceIdentityDeterminationSuccess(EndpointAddress epr, EndpointIdentity identity, Type identityVerifier)
	{
	}

	internal static void TraceIdentityDeterminationFailure(EndpointAddress epr, Type identityVerifier)
	{
	}

	internal static void TraceSpnToSidMappingFailure(string spn, Exception e)
	{
	}
}
