using Org.BouncyCastle.Crypto.Engines;

namespace Org.BouncyCastle.Crypto;

public static class AesUtilities
{
	public static bool IsHardwareAccelerated => false;

	public static IBlockCipher CreateEngine()
	{
		return new AesEngine();
	}
}
