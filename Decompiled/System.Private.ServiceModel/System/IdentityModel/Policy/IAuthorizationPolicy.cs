using System.IdentityModel.Claims;

namespace System.IdentityModel.Policy;

public interface IAuthorizationPolicy : IAuthorizationComponent
{
	ClaimSet Issuer { get; }

	bool Evaluate(EvaluationContext evaluationContext, ref object state);
}
