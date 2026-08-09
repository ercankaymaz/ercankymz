using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Utilities;

namespace Org.BouncyCastle.Crypto.Agreement.Kdf;

public sealed class ECDHKekGenerator : IDerivationFunction
{
	private readonly IDerivationFunction m_kdf;

	private DerObjectIdentifier algorithm;

	private int keySize;

	private byte[] z;

	public IDigest Digest => m_kdf.Digest;

	public ECDHKekGenerator(IDigest digest)
	{
		m_kdf = new Kdf2BytesGenerator(digest);
	}

	public void Init(IDerivationParameters param)
	{
		DHKdfParameters dHKdfParameters = (DHKdfParameters)param;
		algorithm = dHKdfParameters.Algorithm;
		keySize = dHKdfParameters.KeySize;
		z = dHKdfParameters.GetZ();
	}

	public int GenerateBytes(byte[] outBytes, int outOff, int length)
	{
		Check.OutputLength(outBytes, outOff, length, "output buffer too small");
		DerSequence derSequence = new DerSequence(new AlgorithmIdentifier(algorithm, DerNull.Instance), new DerTaggedObject(isExplicit: true, 2, new DerOctetString(Pack.UInt32_To_BE((uint)keySize))));
		m_kdf.Init(new KdfParameters(z, derSequence.GetDerEncoded()));
		return m_kdf.GenerateBytes(outBytes, outOff, length);
	}
}
