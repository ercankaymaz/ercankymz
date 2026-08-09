using Org.BouncyCastle.Crypto;

namespace Org.BouncyCastle.Pqc.Crypto.Crystals.Kyber;

public sealed class KyberParameters : ICipherParameters
{
	public static KyberParameters kyber512 = new KyberParameters("kyber512", 2, 128, usingAes: false);

	public static KyberParameters kyber768 = new KyberParameters("kyber768", 3, 192, usingAes: false);

	public static KyberParameters kyber1024 = new KyberParameters("kyber1024", 4, 256, usingAes: false);

	public static KyberParameters kyber512_aes = new KyberParameters("kyber512-aes", 2, 128, usingAes: true);

	public static KyberParameters kyber768_aes = new KyberParameters("kyber768-aes", 3, 192, usingAes: true);

	public static KyberParameters kyber1024_aes = new KyberParameters("kyber1024-aes", 4, 256, usingAes: true);

	private string m_name;

	private int m_sessionKeySize;

	private KyberEngine m_engine;

	public string Name => m_name;

	public int K => m_engine.K;

	public int SessionKeySize => m_sessionKeySize;

	internal KyberEngine Engine => m_engine;

	private KyberParameters(string name, int k, int sessionKeySize, bool usingAes)
	{
		m_name = name;
		m_sessionKeySize = sessionKeySize;
		m_engine = new KyberEngine(k, usingAes);
	}
}
