using System;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Signers;

namespace Org.BouncyCastle.Tls.Crypto.Impl.BC;

public class BcTlsRsaPssSigner : BcTlsSigner
{
	private readonly int m_signatureScheme;

	public BcTlsRsaPssSigner(BcTlsCrypto crypto, RsaKeyParameters privateKey, int signatureScheme)
		: base(crypto, privateKey)
	{
		if (!SignatureScheme.IsRsaPss(signatureScheme))
		{
			throw new ArgumentException("signatureScheme");
		}
		m_signatureScheme = signatureScheme;
	}

	public override byte[] GenerateRawSignature(SignatureAndHashAlgorithm algorithm, byte[] hash)
	{
		if (algorithm == null || SignatureScheme.From(algorithm) != m_signatureScheme)
		{
			throw new InvalidOperationException("Invalid algorithm: " + algorithm);
		}
		int cryptoHashAlgorithm = SignatureScheme.GetCryptoHashAlgorithm(m_signatureScheme);
		IDigest digest = m_crypto.CreateDigest(cryptoHashAlgorithm);
		PssSigner pssSigner = PssSigner.CreateRawSigner(new RsaBlindedEngine(), digest, digest, digest.GetDigestSize(), 188);
		pssSigner.Init(forSigning: true, new ParametersWithRandom(m_privateKey, m_crypto.SecureRandom));
		pssSigner.BlockUpdate(hash, 0, hash.Length);
		try
		{
			return pssSigner.GenerateSignature();
		}
		catch (CryptoException alertCause)
		{
			throw new TlsFatalAlert(80, alertCause);
		}
	}
}
