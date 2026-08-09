using System.IdentityModel.Tokens;

namespace System.ServiceModel.Security;

public class BinarySecretKeyIdentifierClause : BinaryKeyIdentifierClause
{
	private InMemorySymmetricSecurityKey _symmetricKey;

	public override bool CanCreateKey => true;

	public BinarySecretKeyIdentifierClause(byte[] key)
		: this(key, cloneBuffer: true)
	{
	}

	public BinarySecretKeyIdentifierClause(byte[] key, bool cloneBuffer)
		: this(key, cloneBuffer, null, 0)
	{
	}

	public BinarySecretKeyIdentifierClause(byte[] key, bool cloneBuffer, byte[] derivationNonce, int derivationLength)
		: base(XD.TrustFeb2005Dictionary.BinarySecretClauseType.Value, key, cloneBuffer, derivationNonce, derivationLength)
	{
	}

	public byte[] GetKeyBytes()
	{
		return GetBuffer();
	}

	public override SecurityKey CreateKey()
	{
		if (_symmetricKey == null)
		{
			_symmetricKey = new InMemorySymmetricSecurityKey(GetBuffer(), cloneBuffer: false);
		}
		return _symmetricKey;
	}

	public override bool Matches(SecurityKeyIdentifierClause keyIdentifierClause)
	{
		BinarySecretKeyIdentifierClause binarySecretKeyIdentifierClause = keyIdentifierClause as BinarySecretKeyIdentifierClause;
		if (this != binarySecretKeyIdentifierClause)
		{
			return binarySecretKeyIdentifierClause?.Matches(GetRawBuffer()) ?? false;
		}
		return true;
	}
}
