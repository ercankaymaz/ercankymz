using System.IO;

namespace Org.BouncyCastle.Tls.Crypto;

public interface TlsStreamSigner
{
	Stream Stream { get; }

	byte[] GetSignature();
}
