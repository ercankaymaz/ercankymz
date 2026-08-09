using System.IO;

namespace Org.BouncyCastle.Tls.Crypto;

public interface Tls13Verifier
{
	Stream Stream { get; }

	bool VerifySignature(byte[] signature);
}
