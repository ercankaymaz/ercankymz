using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Pqc.Crypto.Utilities;
using Org.BouncyCastle.Security;

namespace Org.BouncyCastle.Pqc.Crypto.Frodo;

public class FrodoKEMGenerator : IEncapsulatedSecretGenerator
{
	private readonly SecureRandom sr;

	public FrodoKEMGenerator(SecureRandom random)
	{
		sr = random;
	}

	public ISecretWithEncapsulation GenerateEncapsulated(AsymmetricKeyParameter recipientKey)
	{
		FrodoPublicKeyParameters frodoPublicKeyParameters = (FrodoPublicKeyParameters)recipientKey;
		FrodoEngine engine = frodoPublicKeyParameters.Parameters.Engine;
		byte[] array = new byte[engine.CipherTextSize];
		byte[] array2 = new byte[engine.SessionKeySize];
		engine.kem_enc(array, array2, frodoPublicKeyParameters.m_publicKey, sr);
		return new SecretWithEncapsulationImpl(array2, array);
	}
}
