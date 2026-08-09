using System;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Signers;

namespace Org.BouncyCastle.Tls.Crypto.Impl.BC;

public abstract class BcTlsDssVerifier : BcTlsVerifier
{
	protected abstract short SignatureAlgorithm { get; }

	protected BcTlsDssVerifier(BcTlsCrypto crypto, AsymmetricKeyParameter publicKey)
		: base(crypto, publicKey)
	{
	}

	protected abstract IDsa CreateDsaImpl();

	public override bool VerifyRawSignature(DigitallySigned digitallySigned, byte[] hash)
	{
		SignatureAndHashAlgorithm algorithm = digitallySigned.Algorithm;
		if (algorithm != null && algorithm.Signature != SignatureAlgorithm)
		{
			throw new InvalidOperationException("Invalid algorithm: " + algorithm);
		}
		ISigner signer = new DsaDigestSigner(CreateDsaImpl(), new NullDigest());
		signer.Init(forSigning: false, m_publicKey);
		if (algorithm == null)
		{
			signer.BlockUpdate(hash, 16, 20);
		}
		else
		{
			signer.BlockUpdate(hash, 0, hash.Length);
		}
		return signer.VerifySignature(digitallySigned.Signature);
	}
}
