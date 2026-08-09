using System.Security.Cryptography;

namespace HEDS;

internal class HedsCrypt
{
	private RSACryptoServiceProvider rsaProvider;

	public void Init(string s)
	{
		rsaProvider = new RSACryptoServiceProvider();
		rsaProvider.FromXmlString(s);
	}

	public bool VerifyData(byte[] bSource, byte[] bSign)
	{
		return rsaProvider.VerifyData(bSource, new SHA1CryptoServiceProvider(), bSign);
	}
}
