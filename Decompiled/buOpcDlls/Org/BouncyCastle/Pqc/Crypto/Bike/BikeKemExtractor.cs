using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Utilities;

namespace Org.BouncyCastle.Pqc.Crypto.Bike;

public sealed class BikeKemExtractor : IEncapsulatedSecretExtractor
{
	private readonly BikeKeyParameters key;

	public int EncapsulationLength => key.Parameters.RByte + key.Parameters.LByte;

	public BikeKemExtractor(BikePrivateKeyParameters privParams)
	{
		key = privParams;
	}

	public byte[] ExtractSecret(byte[] encapsulation)
	{
		BikeParameters parameters = key.Parameters;
		BikeEngine bikeEngine = parameters.BikeEngine;
		int defaultKeySize = parameters.DefaultKeySize;
		byte[] array = new byte[bikeEngine.SessionKeySize];
		BikePrivateKeyParameters bikePrivateKeyParameters = (BikePrivateKeyParameters)key;
		byte[] c = Arrays.CopyOfRange(encapsulation, 0, bikePrivateKeyParameters.Parameters.RByte);
		byte[] c2 = Arrays.CopyOfRange(encapsulation, bikePrivateKeyParameters.Parameters.RByte, encapsulation.Length);
		byte[] h = bikePrivateKeyParameters.GetH0();
		byte[] h2 = bikePrivateKeyParameters.GetH1();
		byte[] sigma = bikePrivateKeyParameters.GetSigma();
		bikeEngine.Decaps(array, h, h2, sigma, c, c2);
		return Arrays.CopyOfRange(array, 0, defaultKeySize / 8);
	}
}
