using System.Globalization;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Text;

namespace System.ServiceModel.Security.Tokens;

public abstract class SecurityTokenParameters
{
	internal const SecurityTokenInclusionMode defaultInclusionMode = SecurityTokenInclusionMode.AlwaysToRecipient;

	internal const bool defaultRequireDerivedKeys = true;

	private SecurityTokenInclusionMode _inclusionMode;

	protected internal abstract bool HasAsymmetricKey { get; }

	public SecurityTokenInclusionMode InclusionMode
	{
		get
		{
			return _inclusionMode;
		}
		set
		{
			SecurityTokenInclusionModeHelper.Validate(value);
			_inclusionMode = value;
		}
	}

	public bool RequireDerivedKeys { get; set; } = true;

	protected internal abstract bool SupportsClientAuthentication { get; }

	protected internal abstract bool SupportsServerAuthentication { get; }

	protected internal abstract bool SupportsClientWindowsIdentity { get; }

	protected SecurityTokenParameters(SecurityTokenParameters other)
	{
		if (other == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("other");
		}
		RequireDerivedKeys = other.RequireDerivedKeys;
	}

	protected SecurityTokenParameters()
	{
	}

	public SecurityTokenParameters Clone()
	{
		SecurityTokenParameters securityTokenParameters = CloneCore();
		if (securityTokenParameters == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SecurityTokenParametersCloneInvalidResult, GetType().ToString())));
		}
		return securityTokenParameters;
	}

	protected abstract SecurityTokenParameters CloneCore();

	protected internal abstract SecurityKeyIdentifierClause CreateKeyIdentifierClause(SecurityToken token, SecurityTokenReferenceStyle referenceStyle);

	internal SecurityKeyIdentifierClause CreateKeyIdentifierClause<TExternalClause, TInternalClause>(SecurityToken token, SecurityTokenReferenceStyle referenceStyle) where TExternalClause : SecurityKeyIdentifierClause where TInternalClause : SecurityKeyIdentifierClause
	{
		if (token == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("token");
		}
		return referenceStyle switch
		{
			SecurityTokenReferenceStyle.External => token.CreateKeyIdentifierClause<TExternalClause>(), 
			SecurityTokenReferenceStyle.Internal => token.CreateKeyIdentifierClause<TInternalClause>(), 
			_ => throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException(System.SR.Format(System.SR.TokenDoesNotSupportKeyIdentifierClauseCreation, token.GetType().Name, referenceStyle))), 
		};
	}

	internal SecurityKeyIdentifierClause CreateGenericXmlTokenKeyIdentifierClause(SecurityToken token, SecurityTokenReferenceStyle referenceStyle)
	{
		if (token is GenericXmlSecurityToken genericXmlSecurityToken)
		{
			if (referenceStyle == SecurityTokenReferenceStyle.Internal && genericXmlSecurityToken.InternalTokenReference != null)
			{
				return genericXmlSecurityToken.InternalTokenReference;
			}
			if (referenceStyle == SecurityTokenReferenceStyle.External && genericXmlSecurityToken.ExternalTokenReference != null)
			{
				return genericXmlSecurityToken.ExternalTokenReference;
			}
		}
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MessageSecurityException(System.SR.UnableToCreateTokenReference));
	}

	protected internal virtual bool MatchesKeyIdentifierClause(SecurityToken token, SecurityKeyIdentifierClause keyIdentifierClause, SecurityTokenReferenceStyle referenceStyle)
	{
		if (token == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("token");
		}
		if (token is GenericXmlSecurityToken)
		{
			return MatchesGenericXmlTokenKeyIdentifierClause(token, keyIdentifierClause, referenceStyle);
		}
		switch (referenceStyle)
		{
		default:
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException(System.SR.Format(System.SR.TokenDoesNotSupportKeyIdentifierClauseCreation, token.GetType().Name, referenceStyle)));
		case SecurityTokenReferenceStyle.External:
			if (keyIdentifierClause is LocalIdKeyIdentifierClause)
			{
				return false;
			}
			return token.MatchesKeyIdentifierClause(keyIdentifierClause);
		case SecurityTokenReferenceStyle.Internal:
			return token.MatchesKeyIdentifierClause(keyIdentifierClause);
		}
	}

	protected internal abstract void InitializeSecurityTokenRequirement(SecurityTokenRequirement requirement);

	internal bool MatchesGenericXmlTokenKeyIdentifierClause(SecurityToken token, SecurityKeyIdentifierClause keyIdentifierClause, SecurityTokenReferenceStyle referenceStyle)
	{
		if (token == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("token");
		}
		if (!(token is GenericXmlSecurityToken genericXmlSecurityToken))
		{
			return false;
		}
		if (referenceStyle == SecurityTokenReferenceStyle.External && genericXmlSecurityToken.ExternalTokenReference != null)
		{
			return genericXmlSecurityToken.ExternalTokenReference.Matches(keyIdentifierClause);
		}
		if (referenceStyle == SecurityTokenReferenceStyle.Internal)
		{
			return genericXmlSecurityToken.MatchesKeyIdentifierClause(keyIdentifierClause);
		}
		return false;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine(string.Format(CultureInfo.InvariantCulture, "{0}:", GetType().ToString()));
		stringBuilder.Append(string.Format(CultureInfo.InvariantCulture, "RequireDerivedKeys: {0}", RequireDerivedKeys.ToString()));
		return stringBuilder.ToString();
	}
}
