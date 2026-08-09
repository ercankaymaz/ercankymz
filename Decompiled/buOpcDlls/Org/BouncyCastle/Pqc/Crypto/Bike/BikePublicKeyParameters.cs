using Org.BouncyCastle.Utilities;

namespace Org.BouncyCastle.Pqc.Crypto.Bike;

public sealed class BikePublicKeyParameters : BikeKeyParameters
{
	private readonly byte[] publicKey;

	internal byte[] PublicKey => publicKey;

	public BikePublicKeyParameters(BikeParameters param, byte[] publicKey)
		: base(isPrivate: false, param)
	{
		this.publicKey = Arrays.Clone(publicKey);
	}

	public byte[] GetEncoded()
	{
		return Arrays.Clone(publicKey);
	}
}
