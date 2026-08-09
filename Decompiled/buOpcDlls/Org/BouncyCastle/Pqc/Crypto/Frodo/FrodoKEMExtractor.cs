using Org.BouncyCastle.Crypto;

namespace Org.BouncyCastle.Pqc.Crypto.Frodo;

public class FrodoKEMExtractor : IEncapsulatedSecretExtractor
{
	private FrodoEngine engine;

	private FrodoKeyParameters key;

	public int EncapsulationLength => engine.CipherTextSize;

	public FrodoKEMExtractor(FrodoKeyParameters privParams)
	{
		key = privParams;
		InitCipher(key.Parameters);
	}

	private void InitCipher(FrodoParameters param)
	{
		engine = param.Engine;
	}

	public byte[] ExtractSecret(byte[] encapsulation)
	{
		byte[] array = new byte[engine.SessionKeySize];
		engine.kem_dec(array, encapsulation, ((FrodoPrivateKeyParameters)key).privateKey);
		return array;
	}
}
