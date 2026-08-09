using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;

namespace Org.BouncyCastle.Pqc.Crypto.Crystals.Dilithium;

public sealed class DilithiumParameters : ICipherParameters
{
	public static DilithiumParameters Dilithium2 = new DilithiumParameters(2, usingAes: false);

	public static DilithiumParameters Dilithium2Aes = new DilithiumParameters(2, usingAes: true);

	public static DilithiumParameters Dilithium3 = new DilithiumParameters(3, usingAes: false);

	public static DilithiumParameters Dilithium3Aes = new DilithiumParameters(3, usingAes: true);

	public static DilithiumParameters Dilithium5 = new DilithiumParameters(5, usingAes: false);

	public static DilithiumParameters Dilithium5Aes = new DilithiumParameters(5, usingAes: true);

	private int k;

	private bool usingAes;

	private DilithiumParameters(int param, bool usingAes)
	{
		k = param;
		this.usingAes = usingAes;
	}

	internal DilithiumEngine GetEngine(SecureRandom Random)
	{
		return new DilithiumEngine(k, Random, usingAes);
	}
}
