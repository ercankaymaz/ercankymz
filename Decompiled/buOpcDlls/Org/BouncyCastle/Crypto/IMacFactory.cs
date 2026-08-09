namespace Org.BouncyCastle.Crypto;

public interface IMacFactory
{
	object AlgorithmDetails { get; }

	IStreamCalculator<IBlockResult> CreateCalculator();
}
