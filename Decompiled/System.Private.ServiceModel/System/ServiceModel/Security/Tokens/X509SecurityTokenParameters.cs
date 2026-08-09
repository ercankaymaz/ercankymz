using System.Globalization;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Text;

namespace System.ServiceModel.Security.Tokens;

public class X509SecurityTokenParameters : SecurityTokenParameters
{
	internal const X509KeyIdentifierClauseType defaultX509ReferenceStyle = X509KeyIdentifierClauseType.Any;

	private X509KeyIdentifierClauseType _x509ReferenceStyle;

	protected internal override bool HasAsymmetricKey => true;

	public X509KeyIdentifierClauseType X509ReferenceStyle
	{
		get
		{
			return _x509ReferenceStyle;
		}
		set
		{
			X509SecurityTokenReferenceStyleHelper.Validate(value);
			_x509ReferenceStyle = value;
		}
	}

	protected internal override bool SupportsClientAuthentication => true;

	protected internal override bool SupportsServerAuthentication => true;

	protected internal override bool SupportsClientWindowsIdentity => true;

	protected X509SecurityTokenParameters(X509SecurityTokenParameters other)
		: base(other)
	{
		_x509ReferenceStyle = other._x509ReferenceStyle;
	}

	public X509SecurityTokenParameters()
		: this(X509KeyIdentifierClauseType.Any, SecurityTokenInclusionMode.AlwaysToRecipient)
	{
	}

	public X509SecurityTokenParameters(X509KeyIdentifierClauseType x509ReferenceStyle)
		: this(x509ReferenceStyle, SecurityTokenInclusionMode.AlwaysToRecipient)
	{
	}

	public X509SecurityTokenParameters(X509KeyIdentifierClauseType x509ReferenceStyle, SecurityTokenInclusionMode inclusionMode)
		: this(x509ReferenceStyle, inclusionMode, requireDerivedKeys: true)
	{
	}

	internal X509SecurityTokenParameters(X509KeyIdentifierClauseType x509ReferenceStyle, SecurityTokenInclusionMode inclusionMode, bool requireDerivedKeys)
	{
		X509ReferenceStyle = x509ReferenceStyle;
		base.InclusionMode = inclusionMode;
		base.RequireDerivedKeys = requireDerivedKeys;
	}

	protected override SecurityTokenParameters CloneCore()
	{
		return new X509SecurityTokenParameters(this);
	}

	protected internal override SecurityKeyIdentifierClause CreateKeyIdentifierClause(SecurityToken token, SecurityTokenReferenceStyle referenceStyle)
	{
		SecurityKeyIdentifierClause securityKeyIdentifierClause = null;
		switch (_x509ReferenceStyle)
		{
		default:
			if (referenceStyle == SecurityTokenReferenceStyle.External)
			{
				if (token is X509SecurityToken x509SecurityToken && X509SubjectKeyIdentifierClause.TryCreateFrom(x509SecurityToken.Certificate, out var keyIdentifierClause))
				{
					securityKeyIdentifierClause = keyIdentifierClause;
				}
				if (securityKeyIdentifierClause == null)
				{
					throw new PlatformNotSupportedException();
				}
			}
			else
			{
				securityKeyIdentifierClause = token.CreateKeyIdentifierClause<LocalIdKeyIdentifierClause>();
			}
			break;
		case X509KeyIdentifierClauseType.Thumbprint:
			securityKeyIdentifierClause = CreateKeyIdentifierClause<X509ThumbprintKeyIdentifierClause, LocalIdKeyIdentifierClause>(token, referenceStyle);
			break;
		case X509KeyIdentifierClauseType.SubjectKeyIdentifier:
			securityKeyIdentifierClause = CreateKeyIdentifierClause<X509SubjectKeyIdentifierClause, LocalIdKeyIdentifierClause>(token, referenceStyle);
			break;
		case X509KeyIdentifierClauseType.IssuerSerial:
			securityKeyIdentifierClause = CreateKeyIdentifierClause<X509IssuerSerialKeyIdentifierClause, LocalIdKeyIdentifierClause>(token, referenceStyle);
			break;
		case X509KeyIdentifierClauseType.RawDataKeyIdentifier:
			securityKeyIdentifierClause = CreateKeyIdentifierClause<X509RawDataKeyIdentifierClause, LocalIdKeyIdentifierClause>(token, referenceStyle);
			break;
		}
		return securityKeyIdentifierClause;
	}

	protected internal override void InitializeSecurityTokenRequirement(SecurityTokenRequirement requirement)
	{
		requirement.TokenType = SecurityTokenTypes.X509Certificate;
		requirement.RequireCryptographicToken = true;
		requirement.KeyType = SecurityKeyType.AsymmetricKey;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine(base.ToString());
		stringBuilder.Append(string.Format(CultureInfo.InvariantCulture, "X509ReferenceStyle: {0}", _x509ReferenceStyle.ToString()));
		return stringBuilder.ToString();
	}
}
