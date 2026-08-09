using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;

namespace System.ServiceModel.Security.Tokens;

public class UserNameSecurityTokenParameters : SecurityTokenParameters
{
	protected internal override bool HasAsymmetricKey => false;

	protected internal override bool SupportsClientAuthentication => true;

	protected internal override bool SupportsServerAuthentication => false;

	protected internal override bool SupportsClientWindowsIdentity => true;

	protected UserNameSecurityTokenParameters(UserNameSecurityTokenParameters other)
		: base(other)
	{
		base.RequireDerivedKeys = false;
	}

	public UserNameSecurityTokenParameters()
	{
		base.RequireDerivedKeys = false;
	}

	protected override SecurityTokenParameters CloneCore()
	{
		return new UserNameSecurityTokenParameters(this);
	}

	protected internal override SecurityKeyIdentifierClause CreateKeyIdentifierClause(SecurityToken token, SecurityTokenReferenceStyle referenceStyle)
	{
		return CreateKeyIdentifierClause<SecurityKeyIdentifierClause, LocalIdKeyIdentifierClause>(token, referenceStyle);
	}

	protected internal override void InitializeSecurityTokenRequirement(SecurityTokenRequirement requirement)
	{
		requirement.TokenType = SecurityTokenTypes.UserName;
		requirement.RequireCryptographicToken = false;
	}
}
