using System.IdentityModel.Claims;

namespace System.ServiceModel;

public class SpnEndpointIdentity : EndpointIdentity
{
	private static TimeSpan s_spnLookupTime = TimeSpan.FromMinutes(1.0);

	public static TimeSpan SpnLookupTime
	{
		get
		{
			return s_spnLookupTime;
		}
		set
		{
			if (value.Ticks < 0)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value", value.Ticks, System.SR.Format(System.SR.ValueMustBeNonNegative)));
			}
			s_spnLookupTime = value;
		}
	}

	public SpnEndpointIdentity(string spnName)
	{
		if (spnName == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("spnName");
		}
		Initialize(Claim.CreateSpnClaim(spnName));
	}

	public SpnEndpointIdentity(Claim identity)
	{
		if (identity == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("identity");
		}
		if (!identity.ClaimType.Equals(ClaimTypes.Spn))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument(System.SR.Format(System.SR.UnrecognizedClaimTypeForIdentity, identity.ClaimType, ClaimTypes.Spn));
		}
		Initialize(identity);
	}
}
