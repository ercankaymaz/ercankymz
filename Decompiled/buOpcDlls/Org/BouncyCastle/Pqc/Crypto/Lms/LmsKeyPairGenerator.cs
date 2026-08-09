using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;

namespace Org.BouncyCastle.Pqc.Crypto.Lms;

public sealed class LmsKeyPairGenerator : IAsymmetricCipherKeyPairGenerator
{
	private LmsKeyGenerationParameters m_parameters;

	public void Init(KeyGenerationParameters parameters)
	{
		m_parameters = (LmsKeyGenerationParameters)parameters;
	}

	public AsymmetricCipherKeyPair GenerateKeyPair()
	{
		SecureRandom random = m_parameters.Random;
		byte[] array = new byte[16];
		random.NextBytes(array);
		byte[] array2 = new byte[32];
		random.NextBytes(array2);
		LmsPrivateKeyParameters lmsPrivateKeyParameters = Lms.GenerateKeys(m_parameters.LmsParameters.LMSigParameters, m_parameters.LmsParameters.LMOtsParameters, 0, array, array2);
		return new AsymmetricCipherKeyPair(lmsPrivateKeyParameters.GetPublicKey(), lmsPrivateKeyParameters);
	}
}
