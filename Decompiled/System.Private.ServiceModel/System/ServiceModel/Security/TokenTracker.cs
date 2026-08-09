using System.IdentityModel.Tokens;

namespace System.ServiceModel.Security;

internal class TokenTracker
{
	private bool _allowFirstTokenMismatch;

	public SupportingTokenAuthenticatorSpecification spec;

	public SecurityToken Token { get; set; }

	public bool IsDerivedFrom { get; set; }

	public bool IsSigned { get; set; }

	public bool IsEncrypted { get; set; }

	public bool IsEndorsing { get; set; }

	public bool AlreadyReadEndorsingSignature { get; set; }

	public TokenTracker(SupportingTokenAuthenticatorSpecification spec)
		: this(spec, null, allowFirstTokenMismatch: false)
	{
	}

	public TokenTracker(SupportingTokenAuthenticatorSpecification spec, SecurityToken token, bool allowFirstTokenMismatch)
	{
		this.spec = spec;
		Token = token;
		_allowFirstTokenMismatch = allowFirstTokenMismatch;
	}

	public void RecordToken(SecurityToken token)
	{
		if (Token == null)
		{
			Token = token;
		}
		else if (_allowFirstTokenMismatch)
		{
			if (!AreTokensEqual(Token, token))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MessageSecurityException(System.SR.MismatchInSecurityOperationToken));
			}
			Token = token;
			_allowFirstTokenMismatch = false;
		}
		else if (Token != token)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MessageSecurityException(System.SR.MismatchInSecurityOperationToken));
		}
	}

	private static bool AreTokensEqual(SecurityToken outOfBandToken, SecurityToken replyToken)
	{
		if (outOfBandToken is X509SecurityToken && replyToken is X509SecurityToken)
		{
			byte[] certHash = ((X509SecurityToken)outOfBandToken).Certificate.GetCertHash();
			byte[] certHash2 = ((X509SecurityToken)replyToken).Certificate.GetCertHash();
			return SecurityUtils.IsEqual(certHash, certHash2);
		}
		return false;
	}
}
