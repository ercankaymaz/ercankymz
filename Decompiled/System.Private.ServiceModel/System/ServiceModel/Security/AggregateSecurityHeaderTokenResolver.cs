using System.Collections.ObjectModel;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Security.Cryptography.X509Certificates;

namespace System.ServiceModel.Security;

internal class AggregateSecurityHeaderTokenResolver : AggregateTokenResolver
{
	private SecurityHeaderTokenResolver _tokenResolver;

	public AggregateSecurityHeaderTokenResolver(SecurityHeaderTokenResolver tokenResolver, ReadOnlyCollection<SecurityTokenResolver> outOfBandTokenResolvers)
		: base(outOfBandTokenResolvers)
	{
		_tokenResolver = tokenResolver ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("tokenResolver");
	}

	protected override bool TryResolveSecurityKeyCore(SecurityKeyIdentifierClause keyIdentifierClause, out SecurityKey key)
	{
		bool flag = false;
		key = null;
		flag = _tokenResolver.TryResolveSecurityKey(keyIdentifierClause, createIntrinsicKeys: false, out key);
		if (!flag)
		{
			flag = base.TryResolveSecurityKeyCore(keyIdentifierClause, out key);
		}
		if (!flag)
		{
			flag = SecurityUtils.TryCreateKeyFromIntrinsicKeyClause(keyIdentifierClause, this, out key);
		}
		return flag;
	}

	protected override bool TryResolveTokenCore(SecurityKeyIdentifier keyIdentifier, out SecurityToken token)
	{
		bool flag = false;
		token = null;
		flag = _tokenResolver.TryResolveToken(keyIdentifier, matchOnlyExternalTokens: false, resolveIntrinsicKeyClause: false, out token);
		if (!flag)
		{
			flag = base.TryResolveTokenCore(keyIdentifier, out token);
		}
		if (!flag)
		{
			for (int i = 0; i < keyIdentifier.Count; i++)
			{
				if (TryResolveTokenFromIntrinsicKeyClause(keyIdentifier[i], out token))
				{
					flag = true;
					break;
				}
			}
		}
		return flag;
	}

	private bool TryResolveTokenFromIntrinsicKeyClause(SecurityKeyIdentifierClause keyIdentifierClause, out SecurityToken token)
	{
		token = null;
		if (keyIdentifierClause is X509RawDataKeyIdentifierClause)
		{
			token = new X509SecurityToken(new X509Certificate2(((X509RawDataKeyIdentifierClause)keyIdentifierClause).GetX509RawData()), clone: false);
			return true;
		}
		if (keyIdentifierClause is EncryptedKeyIdentifierClause)
		{
			throw ExceptionHelper.PlatformNotSupported();
		}
		return false;
	}

	protected override bool TryResolveTokenCore(SecurityKeyIdentifierClause keyIdentifierClause, out SecurityToken token)
	{
		bool flag = false;
		token = null;
		flag = _tokenResolver.TryResolveToken(keyIdentifierClause, matchOnlyExternalTokens: false, resolveIntrinsicKeyClause: false, out token);
		if (!flag)
		{
			flag = base.TryResolveTokenCore(keyIdentifierClause, out token);
		}
		if (!flag)
		{
			flag = TryResolveTokenFromIntrinsicKeyClause(keyIdentifierClause, out token);
		}
		return flag;
	}
}
