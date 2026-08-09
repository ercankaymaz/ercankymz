using Org.BouncyCastle.Crypto;

namespace Org.BouncyCastle.Pqc.Crypto;

public interface IMessageSigner
{
	void Init(bool forSigning, ICipherParameters param);

	byte[] GenerateSignature(byte[] message);

	bool VerifySignature(byte[] message, byte[] signature);
}
