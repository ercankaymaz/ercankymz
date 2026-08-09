using Org.BouncyCastle.Crypto;

namespace Org.BouncyCastle.Pqc.Crypto.NtruPrime;

public abstract class SNtruPrimeKeyParameters : AsymmetricKeyParameter
{
	private readonly SNtruPrimeParameters m_primeParameters;

	public SNtruPrimeParameters Parameters => m_primeParameters;

	internal SNtruPrimeKeyParameters(bool isPrivate, SNtruPrimeParameters primeParameters)
		: base(isPrivate)
	{
		m_primeParameters = primeParameters;
	}
}
