using Org.BouncyCastle.Utilities;

namespace Org.BouncyCastle.Pqc.Crypto.Lms;

public class LmsSignedPubKey : IEncodable
{
	private LmsSignature signature;

	private LmsPublicKeyParameters publicKey;

	public LmsSignedPubKey(LmsSignature signature, LmsPublicKeyParameters publicKey)
	{
		this.signature = signature;
		this.publicKey = publicKey;
	}

	public LmsSignature GetSignature()
	{
		return signature;
	}

	public LmsPublicKeyParameters GetPublicKey()
	{
		return publicKey;
	}

	public override bool Equals(object o)
	{
		if (this == o)
		{
			return true;
		}
		if (o == null || GetType() != o.GetType())
		{
			return false;
		}
		LmsSignedPubKey lmsSignedPubKey = (LmsSignedPubKey)o;
		if ((signature != null) ? (!signature.Equals(lmsSignedPubKey.signature)) : (lmsSignedPubKey.signature != null))
		{
			return false;
		}
		if (publicKey == null)
		{
			return lmsSignedPubKey.publicKey == null;
		}
		return publicKey.Equals(lmsSignedPubKey.publicKey);
	}

	public override int GetHashCode()
	{
		int num = ((signature != null) ? signature.GetHashCode() : 0);
		return 31 * num + ((publicKey != null) ? publicKey.GetHashCode() : 0);
	}

	public byte[] GetEncoded()
	{
		return Composer.Compose().Bytes(signature.GetEncoded()).Bytes(publicKey.GetEncoded())
			.Build();
	}
}
