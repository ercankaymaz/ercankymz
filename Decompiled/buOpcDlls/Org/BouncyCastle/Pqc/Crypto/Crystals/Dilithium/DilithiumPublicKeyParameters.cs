using Org.BouncyCastle.Utilities;

namespace Org.BouncyCastle.Pqc.Crypto.Crystals.Dilithium;

public sealed class DilithiumPublicKeyParameters : DilithiumKeyParameters
{
	internal byte[] rho;

	internal byte[] t1;

	internal byte[] Rho => rho;

	internal byte[] T1 => t1;

	public DilithiumPublicKeyParameters(DilithiumParameters parameters, byte[] pkEncoded)
		: base(isPrivate: false, parameters)
	{
		rho = Arrays.CopyOfRange(pkEncoded, 0, 32);
		t1 = Arrays.CopyOfRange(pkEncoded, 32, pkEncoded.Length);
	}

	public DilithiumPublicKeyParameters(DilithiumParameters parameters, byte[] rho, byte[] t1)
		: base(isPrivate: false, parameters)
	{
		this.rho = Arrays.Clone(rho);
		this.t1 = Arrays.Clone(t1);
	}

	public byte[] GetEncoded()
	{
		return Arrays.Concatenate(rho, t1);
	}
}
