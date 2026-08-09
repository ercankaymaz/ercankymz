using System;
using System.Security.Cryptography;

namespace Org.BouncyCastle.Crypto.Prng;

public sealed class CryptoApiRandomGenerator : IRandomGenerator, IDisposable
{
	private readonly RandomNumberGenerator m_randomNumberGenerator;

	public CryptoApiRandomGenerator()
		: this(RandomNumberGenerator.Create())
	{
	}

	public CryptoApiRandomGenerator(RandomNumberGenerator randomNumberGenerator)
	{
		m_randomNumberGenerator = randomNumberGenerator ?? throw new ArgumentNullException("randomNumberGenerator");
	}

	public void AddSeedMaterial(byte[] seed)
	{
	}

	public void AddSeedMaterial(long seed)
	{
	}

	public void NextBytes(byte[] bytes)
	{
		m_randomNumberGenerator.GetBytes(bytes);
	}

	public void NextBytes(byte[] bytes, int start, int len)
	{
		if (start < 0)
		{
			throw new ArgumentException("Start offset cannot be negative", "start");
		}
		if (start > bytes.Length - len)
		{
			throw new ArgumentException("Byte array too small for requested offset and length");
		}
		if (bytes.Length == len && start == 0)
		{
			NextBytes(bytes);
			return;
		}
		byte[] array = new byte[len];
		NextBytes(array);
		array.CopyTo(bytes, start);
	}

	public void Dispose()
	{
		m_randomNumberGenerator.Dispose();
		GC.SuppressFinalize(this);
	}
}
