using System.Security.Cryptography;
using System.ServiceModel;

namespace System.IdentityModel.Tokens;

internal class InMemorySymmetricSecurityKey : SymmetricSecurityKey
{
	private int _keySize;

	private byte[] _symmetricKey;

	public override int KeySize => _keySize;

	public InMemorySymmetricSecurityKey(byte[] symmetricKey)
		: this(symmetricKey, cloneBuffer: true)
	{
	}

	public InMemorySymmetricSecurityKey(byte[] symmetricKey, bool cloneBuffer)
	{
		if (symmetricKey == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("symmetricKey"));
		}
		if (symmetricKey.Length == 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentException(System.SR.Format(System.SR.SymmetricKeyLengthTooShort, symmetricKey.Length)));
		}
		_keySize = symmetricKey.Length * 8;
		if (cloneBuffer)
		{
			_symmetricKey = new byte[symmetricKey.Length];
			Buffer.BlockCopy(symmetricKey, 0, _symmetricKey, 0, symmetricKey.Length);
		}
		else
		{
			_symmetricKey = symmetricKey;
		}
	}

	public override byte[] DecryptKey(string algorithm, byte[] keyData)
	{
		return CryptoHelper.UnwrapKey(_symmetricKey, keyData, algorithm);
	}

	public override byte[] EncryptKey(string algorithm, byte[] keyData)
	{
		return CryptoHelper.WrapKey(_symmetricKey, keyData, algorithm);
	}

	public override byte[] GenerateDerivedKey(string algorithm, byte[] label, byte[] nonce, int derivedKeyLength, int offset)
	{
		return CryptoHelper.GenerateDerivedKey(_symmetricKey, algorithm, label, nonce, derivedKeyLength, offset);
	}

	public override ICryptoTransform GetDecryptionTransform(string algorithm, byte[] iv)
	{
		return CryptoHelper.CreateDecryptor(_symmetricKey, iv, algorithm);
	}

	public override ICryptoTransform GetEncryptionTransform(string algorithm, byte[] iv)
	{
		return CryptoHelper.CreateEncryptor(_symmetricKey, iv, algorithm);
	}

	public override int GetIVSize(string algorithm)
	{
		return CryptoHelper.GetIVSize(algorithm);
	}

	public override KeyedHashAlgorithm GetKeyedHashAlgorithm(string algorithm)
	{
		return CryptoHelper.CreateKeyedHashAlgorithm(_symmetricKey, algorithm);
	}

	public override SymmetricAlgorithm GetSymmetricAlgorithm(string algorithm)
	{
		return CryptoHelper.GetSymmetricAlgorithm(_symmetricKey, algorithm);
	}

	public override byte[] GetSymmetricKey()
	{
		byte[] array = new byte[_symmetricKey.Length];
		Buffer.BlockCopy(_symmetricKey, 0, array, 0, _symmetricKey.Length);
		return array;
	}

	public override bool IsAsymmetricAlgorithm(string algorithm)
	{
		return CryptoHelper.IsAsymmetricAlgorithm(algorithm);
	}

	public override bool IsSupportedAlgorithm(string algorithm)
	{
		return CryptoHelper.IsSymmetricSupportedAlgorithm(algorithm, KeySize);
	}

	public override bool IsSymmetricAlgorithm(string algorithm)
	{
		return CryptoHelper.IsSymmetricAlgorithm(algorithm);
	}
}
