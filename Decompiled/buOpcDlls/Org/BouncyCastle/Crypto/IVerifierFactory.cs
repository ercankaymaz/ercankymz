namespace Org.BouncyCastle.Crypto;

public interface IVerifierFactory
{
	object AlgorithmDetails { get; }

	IStreamCalculator<IVerifier> CreateCalculator();
}
