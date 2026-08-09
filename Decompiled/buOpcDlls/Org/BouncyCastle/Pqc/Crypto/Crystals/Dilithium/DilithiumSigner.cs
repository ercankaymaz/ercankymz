using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;

namespace Org.BouncyCastle.Pqc.Crypto.Crystals.Dilithium;

public class DilithiumSigner : IMessageSigner
{
	private DilithiumPrivateKeyParameters privKey;

	private DilithiumPublicKeyParameters pubKey;

	private SecureRandom random;

	public void Init(bool forSigning, ICipherParameters param)
	{
		if (forSigning)
		{
			if (param is ParametersWithRandom parametersWithRandom)
			{
				privKey = (DilithiumPrivateKeyParameters)parametersWithRandom.Parameters;
				random = parametersWithRandom.Random;
			}
			else
			{
				privKey = (DilithiumPrivateKeyParameters)param;
				random = null;
			}
		}
		else
		{
			pubKey = (DilithiumPublicKeyParameters)param;
			random = null;
		}
	}

	public byte[] GenerateSignature(byte[] message)
	{
		DilithiumEngine engine = privKey.Parameters.GetEngine(random);
		byte[] array = new byte[engine.CryptoBytes];
		engine.Sign(array, array.Length, message, message.Length, privKey.rho, privKey.k, privKey.tr, privKey.t0, privKey.s1, privKey.s2);
		return array;
	}

	public bool VerifySignature(byte[] message, byte[] signature)
	{
		return pubKey.Parameters.GetEngine(random).SignOpen(message, signature, signature.Length, pubKey.rho, pubKey.t1);
	}
}
