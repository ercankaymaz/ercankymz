using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IdentityModel;
using System.IdentityModel.Policy;
using System.IdentityModel.Tokens;
using System.Xml;

namespace System.ServiceModel.Security.Tokens;

internal class SecurityContextSecurityToken : SecurityToken, TimeBoundedCache.IExpirableItem, IDisposable
{
	private UniqueId _keyGeneration;

	private DateTime _tokenEffectiveTime;

	private DateTime _tokenExpirationTime;

	private byte[] _key;

	private ReadOnlyCollection<IAuthorizationPolicy> _authorizationPolicies;

	private ReadOnlyCollection<SecurityKey> _securityKeys;

	private string _id;

	private bool _disposed;

	public SecurityMessageProperty BootstrapMessageProperty { get; set; }

	public override string Id => _id;

	public UniqueId ContextId { get; private set; }

	public UniqueId KeyGeneration => _keyGeneration;

	public DateTime KeyEffectiveTime { get; private set; }

	public DateTime KeyExpirationTime { get; private set; }

	public ReadOnlyCollection<IAuthorizationPolicy> AuthorizationPolicies
	{
		get
		{
			ThrowIfDisposed();
			return _authorizationPolicies;
		}
		internal set
		{
			_authorizationPolicies = value;
		}
	}

	public override ReadOnlyCollection<SecurityKey> SecurityKeys => _securityKeys;

	public override DateTime ValidFrom => _tokenEffectiveTime;

	public override DateTime ValidTo => _tokenExpirationTime;

	internal byte[] CookieBlob { get; }

	public bool IsCookieMode { get; private set; }

	DateTime TimeBoundedCache.IExpirableItem.ExpirationTime => ValidTo;

	internal SecurityContextSecurityToken(SecurityContextSecurityToken sourceToken, string id)
		: this(sourceToken, id, sourceToken._key, sourceToken._keyGeneration, sourceToken.KeyEffectiveTime, sourceToken.KeyExpirationTime, sourceToken.AuthorizationPolicies)
	{
	}

	internal SecurityContextSecurityToken(SecurityContextSecurityToken sourceToken, string id, byte[] key, UniqueId keyGeneration, DateTime keyEffectiveTime, DateTime keyExpirationTime, ReadOnlyCollection<IAuthorizationPolicy> authorizationPolicies)
	{
		_id = id;
		Initialize(sourceToken.ContextId, key, sourceToken.ValidFrom, sourceToken.ValidTo, authorizationPolicies, sourceToken.IsCookieMode, keyGeneration, keyEffectiveTime, keyExpirationTime);
		CookieBlob = sourceToken.CookieBlob;
		BootstrapMessageProperty = ((sourceToken.BootstrapMessageProperty == null) ? null : ((SecurityMessageProperty)sourceToken.BootstrapMessageProperty.CreateCopy()));
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.CurrentCulture, "SecurityContextSecurityToken(Identifier='{0}', KeyGeneration='{1}')", ContextId, _keyGeneration);
	}

	private void Initialize(UniqueId contextId, byte[] key, DateTime validFrom, DateTime validTo, ReadOnlyCollection<IAuthorizationPolicy> authorizationPolicies, bool isCookieMode, UniqueId keyGeneration, DateTime keyEffectiveTime, DateTime keyExpirationTime)
	{
		if (key == null || key.Length == 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("key");
		}
		DateTime dateTime = validFrom.ToUniversalTime();
		DateTime dateTime2 = validTo.ToUniversalTime();
		if (dateTime > dateTime2)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument("validFrom", System.SR.EffectiveGreaterThanExpiration);
		}
		_tokenEffectiveTime = dateTime;
		_tokenExpirationTime = dateTime2;
		KeyEffectiveTime = keyEffectiveTime.ToUniversalTime();
		KeyExpirationTime = keyExpirationTime.ToUniversalTime();
		if (KeyEffectiveTime > KeyExpirationTime)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument("keyEffectiveTime", System.SR.EffectiveGreaterThanExpiration);
		}
		if (KeyEffectiveTime < dateTime || KeyExpirationTime > dateTime2)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument(System.SR.KeyLifetimeNotWithinTokenLifetime);
		}
		_key = new byte[key.Length];
		Buffer.BlockCopy(key, 0, _key, 0, key.Length);
		ContextId = contextId ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("contextId");
		_keyGeneration = keyGeneration;
		_authorizationPolicies = authorizationPolicies ?? EmptyReadOnlyCollection<IAuthorizationPolicy>.Instance;
		List<SecurityKey> list = new List<SecurityKey>(1);
		list.Add(new InMemorySymmetricSecurityKey(_key, cloneBuffer: false));
		_securityKeys = new ReadOnlyCollection<SecurityKey>(list);
		IsCookieMode = isCookieMode;
	}

	public void Dispose()
	{
		if (!_disposed)
		{
			_disposed = true;
			System.IdentityModel.SecurityUtils.DisposeAuthorizationPoliciesIfNecessary(_authorizationPolicies);
			if (BootstrapMessageProperty != null)
			{
				BootstrapMessageProperty.Dispose();
			}
		}
	}

	private void ThrowIfDisposed()
	{
		if (_disposed)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ObjectDisposedException(GetType().FullName));
		}
	}
}
