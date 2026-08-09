using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Principal;
using System.ServiceModel;

namespace System.IdentityModel.Claims;

[DataContract(Namespace = "http://schemas.xmlsoap.org/ws/2005/05/identity")]
public abstract class ClaimSet : IEnumerable<Claim>, IEnumerable
{
	private static ClaimSet s_system;

	private static ClaimSet s_windows;

	private static ClaimSet s_anonymous;

	public static ClaimSet System
	{
		get
		{
			if (s_system == null)
			{
				List<Claim> list = new List<Claim>(2);
				list.Add(Claim.System);
				list.Add(new Claim(ClaimTypes.System, "System", Rights.PossessProperty));
				s_system = new DefaultClaimSet(list);
			}
			return s_system;
		}
	}

	public static ClaimSet Windows
	{
		get
		{
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Expected O, but got Unknown
			if (s_windows == null)
			{
				List<Claim> list = new List<Claim>(2);
				SecurityIdentifier val = new SecurityIdentifier((WellKnownSidType)7, (SecurityIdentifier)null);
				list.Add(new Claim(ClaimTypes.Sid, val, Rights.Identity));
				list.Add(Claim.CreateWindowsSidClaim(val));
				s_windows = new DefaultClaimSet(list);
			}
			return s_windows;
		}
	}

	internal static ClaimSet Anonymous
	{
		get
		{
			if (s_anonymous == null)
			{
				s_anonymous = new DefaultClaimSet();
			}
			return s_anonymous;
		}
	}

	public abstract Claim this[int index] { get; }

	public abstract int Count { get; }

	public abstract ClaimSet Issuer { get; }

	internal static bool SupportedRight(string right)
	{
		if (right != null && !Rights.Identity.Equals(right))
		{
			return Rights.PossessProperty.Equals(right);
		}
		return true;
	}

	public virtual bool ContainsClaim(Claim claim, IEqualityComparer<Claim> comparer)
	{
		if (claim == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("claim");
		}
		if (comparer == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("comparer");
		}
		IEnumerable<Claim> enumerable = FindClaims(null, null);
		if (enumerable != null)
		{
			foreach (Claim item in enumerable)
			{
				if (comparer.Equals(claim, item))
				{
					return true;
				}
			}
		}
		return false;
	}

	public virtual bool ContainsClaim(Claim claim)
	{
		if (claim == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("claim");
		}
		IEnumerable<Claim> enumerable = FindClaims(claim.ClaimType, claim.Right);
		if (enumerable != null)
		{
			foreach (Claim item in enumerable)
			{
				if (claim.Equals(item))
				{
					return true;
				}
			}
		}
		return false;
	}

	public abstract IEnumerable<Claim> FindClaims(string claimType, string right);

	public abstract IEnumerator<Claim> GetEnumerator();

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
