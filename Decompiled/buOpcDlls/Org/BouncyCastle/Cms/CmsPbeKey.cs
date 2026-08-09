using System;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Utilities;

namespace Org.BouncyCastle.Cms;

public abstract class CmsPbeKey : ICipherParameters
{
	internal readonly char[] password;

	internal readonly byte[] salt;

	internal readonly int iterationCount;

	public byte[] Salt => Arrays.Clone(salt);

	public int IterationCount => iterationCount;

	public string Algorithm => "PKCS5S2";

	public string Format => "RAW";

	public CmsPbeKey(char[] password, byte[] salt, int iterationCount)
	{
		this.password = (char[])password.Clone();
		this.salt = Arrays.Clone(salt);
		this.iterationCount = iterationCount;
	}

	public CmsPbeKey(char[] password, AlgorithmIdentifier keyDerivationAlgorithm)
	{
		if (!keyDerivationAlgorithm.Algorithm.Equals(PkcsObjectIdentifiers.IdPbkdf2))
		{
			throw new ArgumentException("Unsupported key derivation algorithm: " + keyDerivationAlgorithm.Algorithm);
		}
		Pbkdf2Params instance = Pbkdf2Params.GetInstance(keyDerivationAlgorithm.Parameters.ToAsn1Object());
		this.password = (char[])password.Clone();
		salt = instance.GetSalt();
		iterationCount = instance.IterationCount.IntValue;
	}

	~CmsPbeKey()
	{
		Array.Clear(password, 0, password.Length);
	}

	public byte[] GetEncoded()
	{
		return null;
	}

	internal abstract KeyParameter GetEncoded(string algorithmOid);
}
