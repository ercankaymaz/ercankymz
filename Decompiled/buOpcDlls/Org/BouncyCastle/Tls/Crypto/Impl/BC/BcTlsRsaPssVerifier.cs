using System;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Signers;

namespace Org.BouncyCastle.Tls.Crypto.Impl.BC;

public class BcTlsRsaPssVerifier : BcTlsVerifier
{
	private readonly int m_signatureScheme;

	public BcTlsRsaPssVerifier(BcTlsCrypto crypto, RsaKeyParameters publicKey, int signatureScheme)
		: base(crypto, publicKey)
	{
		if (!SignatureScheme.IsRsaPss(signatureScheme))
		{
			throw new ArgumentException("signatureScheme");
		}
		m_signatureScheme = signatureScheme;
	}

	public override bool VerifyRawSignature(DigitallySigned digitallySigned, byte[] hash)
	{
		SignatureAndHashAlgorithm algorithm = digitallySigned.Algorithm;
		if (algorithm == null || SignatureScheme.From(algorithm) != m_signatureScheme)
		{
			throw new InvalidOperationException("Invalid algorithm: " + algorithm);
		}
		int cryptoHashAlgorithm = SignatureScheme.GetCryptoHashAlgorithm(m_signatureScheme);
		IDigest digest = m_crypto.CreateDigest(cryptoHashAlgorithm);
		PssSigner pssSigner = PssSigner.CreateRawSigner(new RsaEngine(), digest, digest, digest.GetDigestSize(), 188);
		pssSigner.Init(forSigning: false, m_publicKey);
		pssSigner.BlockUpdate(hash, 0, hash.Length);
		return pssSigner.VerifySignature(digitallySigned.Signature);
	}
}
