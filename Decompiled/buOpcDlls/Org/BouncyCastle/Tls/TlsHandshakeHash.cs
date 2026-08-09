using System.IO;
using Org.BouncyCastle.Tls.Crypto;

namespace Org.BouncyCastle.Tls;

public interface TlsHandshakeHash : TlsHash
{
	void CopyBufferTo(Stream output);

	void ForceBuffering();

	void NotifyPrfDetermined();

	void TrackHashAlgorithm(int cryptoHashAlgorithm);

	void SealHashAlgorithms();

	void StopTracking();

	TlsHash ForkPrfHash();

	byte[] GetFinalHash(int cryptoHashAlgorithm);
}
