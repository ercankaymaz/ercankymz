using System.Collections.ObjectModel;
using System.IdentityModel.Tokens;
using System.ServiceModel;

namespace System.IdentityModel.Selectors;

public abstract class SecurityTokenResolver
{
	private class SimpleTokenResolver : SecurityTokenResolver
	{
		private ReadOnlyCollection<SecurityToken> _tokens;

		private bool _canMatchLocalId;

		public SimpleTokenResolver(ReadOnlyCollection<SecurityToken> tokens, bool canMatchLocalId)
		{
			_tokens = tokens ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("tokens");
			_canMatchLocalId = canMatchLocalId;
		}

		protected override bool TryResolveSecurityKeyCore(SecurityKeyIdentifierClause keyIdentifierClause, out SecurityKey key)
		{
			if (keyIdentifierClause == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("keyIdentifierClause");
			}
			key = null;
			for (int i = 0; i < _tokens.Count; i++)
			{
				SecurityKey securityKey = _tokens[i].ResolveKeyIdentifierClause(keyIdentifierClause);
				if (securityKey != null)
				{
					key = securityKey;
					return true;
				}
			}
			if (keyIdentifierClause is EncryptedKeyIdentifierClause)
			{
				EncryptedKeyIdentifierClause encryptedKeyIdentifierClause = (EncryptedKeyIdentifierClause)keyIdentifierClause;
				SecurityKeyIdentifier encryptingKeyIdentifier = encryptedKeyIdentifierClause.EncryptingKeyIdentifier;
				if (encryptingKeyIdentifier != null && encryptingKeyIdentifier.Count > 0)
				{
					for (int j = 0; j < encryptingKeyIdentifier.Count; j++)
					{
						SecurityKey key2 = null;
						if (TryResolveSecurityKey(encryptingKeyIdentifier[j], out key2))
						{
							byte[] encryptedKey = encryptedKeyIdentifierClause.GetEncryptedKey();
							string encryptionMethod = encryptedKeyIdentifierClause.EncryptionMethod;
							byte[] symmetricKey = key2.DecryptKey(encryptionMethod, encryptedKey);
							key = new InMemorySymmetricSecurityKey(symmetricKey, cloneBuffer: false);
							return true;
						}
					}
				}
			}
			return key != null;
		}

		protected override bool TryResolveTokenCore(SecurityKeyIdentifier keyIdentifier, out SecurityToken token)
		{
			if (keyIdentifier == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("keyIdentifier");
			}
			token = null;
			for (int i = 0; i < keyIdentifier.Count; i++)
			{
				SecurityToken securityToken = ResolveSecurityToken(keyIdentifier[i]);
				if (securityToken != null)
				{
					token = securityToken;
					break;
				}
			}
			return token != null;
		}

		protected override bool TryResolveTokenCore(SecurityKeyIdentifierClause keyIdentifierClause, out SecurityToken token)
		{
			if (keyIdentifierClause == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("keyIdentifierClause");
			}
			token = null;
			SecurityToken securityToken = ResolveSecurityToken(keyIdentifierClause);
			if (securityToken != null)
			{
				token = securityToken;
			}
			return token != null;
		}

		private SecurityToken ResolveSecurityToken(SecurityKeyIdentifierClause keyIdentifierClause)
		{
			if (keyIdentifierClause == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("keyIdentifierClause");
			}
			if (!_canMatchLocalId && keyIdentifierClause is LocalIdKeyIdentifierClause)
			{
				return null;
			}
			for (int i = 0; i < _tokens.Count; i++)
			{
				if (_tokens[i].MatchesKeyIdentifierClause(keyIdentifierClause))
				{
					return _tokens[i];
				}
			}
			return null;
		}
	}

	public SecurityToken ResolveToken(SecurityKeyIdentifier keyIdentifier)
	{
		if (keyIdentifier == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("keyIdentifier");
		}
		if (!TryResolveTokenCore(keyIdentifier, out var token))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperWarning(new InvalidOperationException(System.SR.Format(System.SR.UnableToResolveTokenReference, keyIdentifier)));
		}
		return token;
	}

	public bool TryResolveToken(SecurityKeyIdentifier keyIdentifier, out SecurityToken token)
	{
		if (keyIdentifier == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("keyIdentifier");
		}
		return TryResolveTokenCore(keyIdentifier, out token);
	}

	public SecurityToken ResolveToken(SecurityKeyIdentifierClause keyIdentifierClause)
	{
		if (keyIdentifierClause == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("keyIdentifierClause");
		}
		if (!TryResolveTokenCore(keyIdentifierClause, out var token))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperWarning(new InvalidOperationException(System.SR.Format(System.SR.UnableToResolveTokenReference, keyIdentifierClause)));
		}
		return token;
	}

	public bool TryResolveToken(SecurityKeyIdentifierClause keyIdentifierClause, out SecurityToken token)
	{
		if (keyIdentifierClause == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("keyIdentifierClause");
		}
		return TryResolveTokenCore(keyIdentifierClause, out token);
	}

	public SecurityKey ResolveSecurityKey(SecurityKeyIdentifierClause keyIdentifierClause)
	{
		if (keyIdentifierClause == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("keyIdentifierClause");
		}
		if (!TryResolveSecurityKeyCore(keyIdentifierClause, out var key))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperWarning(new InvalidOperationException(System.SR.Format(System.SR.UnableToResolveKeyReference, keyIdentifierClause)));
		}
		return key;
	}

	public bool TryResolveSecurityKey(SecurityKeyIdentifierClause keyIdentifierClause, out SecurityKey key)
	{
		if (keyIdentifierClause == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("keyIdentifierClause");
		}
		return TryResolveSecurityKeyCore(keyIdentifierClause, out key);
	}

	protected abstract bool TryResolveTokenCore(SecurityKeyIdentifier keyIdentifier, out SecurityToken token);

	protected abstract bool TryResolveTokenCore(SecurityKeyIdentifierClause keyIdentifierClause, out SecurityToken token);

	protected abstract bool TryResolveSecurityKeyCore(SecurityKeyIdentifierClause keyIdentifierClause, out SecurityKey key);

	public static SecurityTokenResolver CreateDefaultSecurityTokenResolver(ReadOnlyCollection<SecurityToken> tokens, bool canMatchLocalId)
	{
		return new SimpleTokenResolver(tokens, canMatchLocalId);
	}
}
