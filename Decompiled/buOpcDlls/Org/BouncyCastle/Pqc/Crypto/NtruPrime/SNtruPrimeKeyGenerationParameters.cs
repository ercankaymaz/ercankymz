using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;

namespace Org.BouncyCastle.Pqc.Crypto.NtruPrime;

public class SNtruPrimeKeyGenerationParameters : KeyGenerationParameters
{
	private SNtruPrimeParameters _primeParameters;

	public SNtruPrimeParameters Parameters => _primeParameters;

	public SNtruPrimeKeyGenerationParameters(SecureRandom random, SNtruPrimeParameters ntruPrimeParameters)
		: base(random, 256)
	{
		_primeParameters = ntruPrimeParameters;
	}
}
