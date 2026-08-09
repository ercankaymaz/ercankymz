using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace System.IdentityModel.Claims;

[DataContract(Namespace = "http://schemas.xmlsoap.org/ws/2005/05/identity")]
public class DefaultClaimSet : ClaimSet
{
	[DataMember(Name = "Issuer")]
	private ClaimSet _issuer;

	[DataMember(Name = "Claims")]
	private IList<Claim> _claims;

	public override Claim this[int index] => _claims[index];

	public override int Count => _claims.Count;

	public override ClaimSet Issuer => _issuer;

	public DefaultClaimSet(params Claim[] claims)
	{
		Initialize(this, claims);
	}

	public DefaultClaimSet(IList<Claim> claims)
	{
		Initialize(this, claims);
	}

	public DefaultClaimSet(ClaimSet issuer, params Claim[] claims)
	{
		Initialize(issuer, claims);
	}

	public DefaultClaimSet(ClaimSet issuer, IList<Claim> claims)
	{
		Initialize(issuer, claims);
	}

	public override bool ContainsClaim(Claim claim)
	{
		if (claim == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("claim");
		}
		for (int i = 0; i < _claims.Count; i++)
		{
			if (claim.Equals(_claims[i]))
			{
				return true;
			}
		}
		return false;
	}

	public override IEnumerable<Claim> FindClaims(string claimType, string right)
	{
		bool anyClaimType = claimType == null;
		bool anyRight = right == null;
		int i = 0;
		while (i < _claims.Count)
		{
			Claim claim = _claims[i];
			if (claim != null && (anyClaimType || claimType == claim.ClaimType) && (anyRight || right == claim.Right))
			{
				yield return claim;
			}
			int num = i + 1;
			i = num;
		}
	}

	public override IEnumerator<Claim> GetEnumerator()
	{
		return _claims.GetEnumerator();
	}

	protected void Initialize(ClaimSet issuer, IList<Claim> claims)
	{
		_issuer = issuer ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("issuer");
		_claims = claims ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("claims");
	}

	public override string ToString()
	{
		return SecurityUtils.ClaimSetToString(this);
	}
}
