using System.Collections.ObjectModel;
using System.IdentityModel;
using System.IdentityModel.Tokens;

namespace System.ServiceModel.Security.Tokens;

public class BinarySecretSecurityToken : SecurityToken
{
	private string _id;

	private DateTime _effectiveTime;

	private byte[] _key;

	private ReadOnlyCollection<SecurityKey> _securityKeys;

	public override string Id => _id;

	public override DateTime ValidFrom => _effectiveTime;

	public override DateTime ValidTo => DateTime.MaxValue;

	public int KeySize => _key.Length * 8;

	public override ReadOnlyCollection<SecurityKey> SecurityKeys => _securityKeys;

	public BinarySecretSecurityToken(string id, byte[] key)
		: this(id, key, allowCrypto: true)
	{
	}

	public BinarySecretSecurityToken(byte[] key)
		: this(SecurityUniqueId.Create().Value, key)
	{
	}

	protected BinarySecretSecurityToken(string id, int keySizeInBits, bool allowCrypto)
	{
		if (keySizeInBits <= 0 || keySizeInBits >= 512)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("keySizeInBits", System.SR.Format(System.SR.ValueMustBeInRange, 0, 512)));
		}
		if (keySizeInBits % 8 != 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("keySizeInBits", System.SR.Format(System.SR.KeyLengthMustBeMultipleOfEight, keySizeInBits)));
		}
		_id = id;
		_effectiveTime = DateTime.UtcNow;
		_key = new byte[keySizeInBits / 8];
		CryptoHelper.FillRandomBytes(_key);
		if (allowCrypto)
		{
			throw ExceptionHelper.PlatformNotSupported();
		}
		_securityKeys = EmptyReadOnlyCollection<SecurityKey>.Instance;
	}

	protected BinarySecretSecurityToken(string id, byte[] key, bool allowCrypto)
	{
		if (key == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("key");
		}
		_id = id;
		_effectiveTime = DateTime.UtcNow;
		_key = new byte[key.Length];
		Buffer.BlockCopy(key, 0, _key, 0, key.Length);
		if (allowCrypto)
		{
			_securityKeys = SecurityUtils.CreateSymmetricSecurityKeys(_key);
		}
		else
		{
			_securityKeys = EmptyReadOnlyCollection<SecurityKey>.Instance;
		}
	}

	public byte[] GetKeyBytes()
	{
		return SecurityUtils.CloneBuffer(_key);
	}
}
