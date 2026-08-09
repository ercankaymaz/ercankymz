using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;

namespace Org.BouncyCastle.Pqc.Crypto.Frodo;

public class FrodoKeyPairGenerator : IAsymmetricCipherKeyPairGenerator
{
	private FrodoKeyGenerationParameters frodoParams;

	private int n;

	private int D;

	private int B;

	private SecureRandom random;

	private void Initialize(KeyGenerationParameters param)
	{
		frodoParams = (FrodoKeyGenerationParameters)param;
		random = param.Random;
		n = frodoParams.Parameters.N;
		D = frodoParams.Parameters.D;
		B = frodoParams.Parameters.B;
	}

	private AsymmetricCipherKeyPair GenKeyPair()
	{
		FrodoEngine engine = frodoParams.Parameters.Engine;
		byte[] array = new byte[engine.PrivateKeySize];
		byte[] array2 = new byte[engine.PublicKeySize];
		engine.kem_keypair(array2, array, random);
		FrodoPublicKeyParameters publicParameter = new FrodoPublicKeyParameters(frodoParams.Parameters, array2);
		FrodoPrivateKeyParameters privateParameter = new FrodoPrivateKeyParameters(frodoParams.Parameters, array);
		return new AsymmetricCipherKeyPair(publicParameter, privateParameter);
	}

	public void Init(KeyGenerationParameters param)
	{
		Initialize(param);
	}

	public AsymmetricCipherKeyPair GenerateKeyPair()
	{
		return GenKeyPair();
	}
}
