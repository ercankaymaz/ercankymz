using System.ServiceModel.Security.Tokens;

namespace System.ServiceModel.Security;

internal sealed class NonceToken : BinarySecretSecurityToken
{
	public NonceToken(byte[] key)
		: this(SecurityUniqueId.Create().Value, key)
	{
	}

	public NonceToken(string id, byte[] key)
		: base(id, key, allowCrypto: false)
	{
	}

	public NonceToken(int keySizeInBits)
		: base(SecurityUniqueId.Create().Value, keySizeInBits, allowCrypto: false)
	{
	}
}
