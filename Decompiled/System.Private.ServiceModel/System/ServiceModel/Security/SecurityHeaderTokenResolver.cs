using System.Globalization;
using System.IO;
using System.IdentityModel;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.Security.Tokens;

namespace System.ServiceModel.Security;

internal sealed class SecurityHeaderTokenResolver : SecurityTokenResolver, IWrappedTokenKeyResolver
{
	private struct SecurityTokenEntry(SecurityToken token, SecurityTokenParameters tokenParameters, SecurityTokenReferenceStyle allowedReferenceStyle)
	{
		private SecurityTokenReferenceStyle _allowedReferenceStyle = allowedReferenceStyle;

		public SecurityToken Token { get; } = token;

		public SecurityTokenParameters TokenParameters { get; } = tokenParameters;

		public SecurityTokenReferenceStyle AllowedReferenceStyle => _allowedReferenceStyle;
	}

	private const int InitialTokenArraySize = 10;

	private int _tokenCount;

	private SecurityTokenEntry[] _tokens;

	private ReceiveSecurityHeader _securityHeader;

	public SecurityToken ExpectedWrapper { get; set; }

	public SecurityTokenParameters ExpectedWrapperTokenParameters { get; set; }

	public SecurityHeaderTokenResolver()
		: this(null)
	{
	}

	public SecurityHeaderTokenResolver(ReceiveSecurityHeader securityHeader)
	{
		_tokens = new SecurityTokenEntry[10];
		_securityHeader = securityHeader;
	}

	public void Add(SecurityToken token)
	{
		Add(token, SecurityTokenReferenceStyle.Internal, null);
	}

	public void Add(SecurityToken token, SecurityTokenReferenceStyle allowedReferenceStyle, SecurityTokenParameters tokenParameters)
	{
		if (token == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("token");
		}
		if (allowedReferenceStyle == SecurityTokenReferenceStyle.External && tokenParameters == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument(System.SR.ResolvingExternalTokensRequireSecurityTokenParameters);
		}
		EnsureCapacityToAddToken();
		_tokens[_tokenCount++] = new SecurityTokenEntry(token, tokenParameters, allowedReferenceStyle);
	}

	private void EnsureCapacityToAddToken()
	{
		if (_tokenCount == _tokens.Length)
		{
			SecurityTokenEntry[] array = new SecurityTokenEntry[_tokens.Length * 2];
			Array.Copy(_tokens, 0, array, 0, _tokenCount);
			_tokens = array;
		}
	}

	public bool CheckExternalWrapperMatch(SecurityKeyIdentifier keyIdentifier)
	{
		if (ExpectedWrapper == null || ExpectedWrapperTokenParameters == null)
		{
			return false;
		}
		for (int i = 0; i < keyIdentifier.Count; i++)
		{
			if (ExpectedWrapperTokenParameters.MatchesKeyIdentifierClause(ExpectedWrapper, keyIdentifier[i], SecurityTokenReferenceStyle.External))
			{
				return true;
			}
		}
		return false;
	}

	internal SecurityToken ResolveToken(SecurityKeyIdentifier keyIdentifier, bool matchOnlyExternalTokens, bool resolveIntrinsicKeyClause)
	{
		if (keyIdentifier == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("keyIdentifier");
		}
		for (int i = 0; i < keyIdentifier.Count; i++)
		{
			SecurityToken securityToken = ResolveToken(keyIdentifier[i], matchOnlyExternalTokens, resolveIntrinsicKeyClause);
			if (securityToken != null)
			{
				return securityToken;
			}
		}
		return null;
	}

	private SecurityKey ResolveSecurityKeyCore(SecurityKeyIdentifierClause keyIdentifierClause, bool createIntrinsicKeys)
	{
		if (keyIdentifierClause == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("keyIdentifierClause"));
		}
		SecurityKey key;
		for (int i = 0; i < _tokenCount; i++)
		{
			key = _tokens[i].Token.ResolveKeyIdentifierClause(keyIdentifierClause);
			if (key != null)
			{
				return key;
			}
		}
		if (createIntrinsicKeys && SecurityUtils.TryCreateKeyFromIntrinsicKeyClause(keyIdentifierClause, this, out key))
		{
			return key;
		}
		return null;
	}

	private bool MatchDirectReference(SecurityToken token, SecurityKeyIdentifierClause keyClause)
	{
		if (!(keyClause is LocalIdKeyIdentifierClause keyIdentifierClause))
		{
			return false;
		}
		return token.MatchesKeyIdentifierClause(keyIdentifierClause);
	}

	internal SecurityToken ResolveToken(SecurityKeyIdentifierClause keyIdentifierClause, bool matchOnlyExternal, bool resolveIntrinsicKeyClause)
	{
		if (keyIdentifierClause == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("keyIdentifierClause");
		}
		SecurityToken securityToken = null;
		for (int i = 0; i < _tokenCount; i++)
		{
			if (!matchOnlyExternal || _tokens[i].AllowedReferenceStyle == SecurityTokenReferenceStyle.External)
			{
				SecurityToken token = _tokens[i].Token;
				if (_tokens[i].TokenParameters != null && _tokens[i].TokenParameters.MatchesKeyIdentifierClause(token, keyIdentifierClause, _tokens[i].AllowedReferenceStyle))
				{
					securityToken = token;
					break;
				}
				if (_tokens[i].TokenParameters == null && _tokens[i].AllowedReferenceStyle == SecurityTokenReferenceStyle.Internal && MatchDirectReference(token, keyIdentifierClause))
				{
					securityToken = token;
					break;
				}
			}
		}
		if (securityToken == null && keyIdentifierClause is X509RawDataKeyIdentifierClause && !matchOnlyExternal && resolveIntrinsicKeyClause)
		{
			securityToken = new X509SecurityToken(new X509Certificate2(((X509RawDataKeyIdentifierClause)keyIdentifierClause).GetX509RawData()));
		}
		byte[] derivationNonce = keyIdentifierClause.GetDerivationNonce();
		if (securityToken != null && derivationNonce != null)
		{
			if (SecurityUtils.GetSecurityKey<SymmetricSecurityKey>(securityToken) == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MessageSecurityException(System.SR.Format(System.SR.UnableToDeriveKeyFromKeyInfoClause, keyIdentifierClause, securityToken)));
			}
			int num = ((keyIdentifierClause.DerivationLength == 0) ? 32 : keyIdentifierClause.DerivationLength);
			if (num > _securityHeader.MaxDerivedKeyLength)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MessageSecurityException(System.SR.Format(System.SR.DerivedKeyLengthSpecifiedInImplicitDerivedKeyClauseTooLong, keyIdentifierClause.ToString(), num, _securityHeader.MaxDerivedKeyLength)));
			}
			bool flag = false;
			for (int j = 0; j < _tokenCount; j++)
			{
				if (_tokens[j].Token is DerivedKeySecurityToken derivedKeySecurityToken && derivedKeySecurityToken.Length == num && SecurityUtils.IsEqual(derivedKeySecurityToken.Nonce, derivationNonce) && derivedKeySecurityToken.TokenToDerive.MatchesKeyIdentifierClause(keyIdentifierClause))
				{
					securityToken = _tokens[j].Token;
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				string keyDerivationAlgorithm = SecurityUtils.GetKeyDerivationAlgorithm(_securityHeader.StandardsManager.MessageSecurityVersion.SecureConversationVersion);
				securityToken = new DerivedKeySecurityToken(-1, 0, num, null, derivationNonce, securityToken, keyIdentifierClause, keyDerivationAlgorithm, SecurityUtils.GenerateId());
				((DerivedKeySecurityToken)securityToken).InitializeDerivedKey(num);
				Add(securityToken, SecurityTokenReferenceStyle.Internal, null);
				_securityHeader.EnsureDerivedKeyLimitNotReached();
			}
		}
		return securityToken;
	}

	public override string ToString()
	{
		using StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture);
		stringWriter.WriteLine("SecurityTokenResolver");
		stringWriter.WriteLine("    (");
		stringWriter.WriteLine("    TokenCount = {0},", _tokenCount);
		for (int i = 0; i < _tokenCount; i++)
		{
			stringWriter.WriteLine("    TokenEntry[{0}] = (AllowedReferenceStyle={1}, Token={2}, Parameters={3})", i, _tokens[i].AllowedReferenceStyle, _tokens[i].Token.GetType(), _tokens[i].TokenParameters);
		}
		stringWriter.WriteLine("    )");
		return stringWriter.ToString();
	}

	protected override bool TryResolveTokenCore(SecurityKeyIdentifier keyIdentifier, out SecurityToken token)
	{
		token = ResolveToken(keyIdentifier, matchOnlyExternalTokens: false, resolveIntrinsicKeyClause: true);
		return token != null;
	}

	internal bool TryResolveToken(SecurityKeyIdentifier keyIdentifier, bool matchOnlyExternalTokens, bool resolveIntrinsicKeyClause, out SecurityToken token)
	{
		token = ResolveToken(keyIdentifier, matchOnlyExternalTokens, resolveIntrinsicKeyClause);
		return token != null;
	}

	protected override bool TryResolveTokenCore(SecurityKeyIdentifierClause keyIdentifierClause, out SecurityToken token)
	{
		token = ResolveToken(keyIdentifierClause, matchOnlyExternal: false, resolveIntrinsicKeyClause: true);
		return token != null;
	}

	internal bool TryResolveToken(SecurityKeyIdentifierClause keyIdentifierClause, bool matchOnlyExternalTokens, bool resolveIntrinsicKeyClause, out SecurityToken token)
	{
		token = ResolveToken(keyIdentifierClause, matchOnlyExternalTokens, resolveIntrinsicKeyClause);
		return token != null;
	}

	internal bool TryResolveSecurityKey(SecurityKeyIdentifierClause keyIdentifierClause, bool createIntrinsicKeys, out SecurityKey key)
	{
		if (keyIdentifierClause == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("keyIdentifierClause");
		}
		key = ResolveSecurityKeyCore(keyIdentifierClause, createIntrinsicKeys);
		return key != null;
	}

	protected override bool TryResolveSecurityKeyCore(SecurityKeyIdentifierClause keyIdentifierClause, out SecurityKey key)
	{
		key = ResolveSecurityKeyCore(keyIdentifierClause, createIntrinsicKeys: true);
		return key != null;
	}
}
