namespace Org.BouncyCastle.Crypto;

public interface IEncapsulatedSecretExtractor
{
	int EncapsulationLength { get; }

	byte[] ExtractSecret(byte[] encapsulation);
}
