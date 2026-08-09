using System;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Utilities;

namespace Org.BouncyCastle.Crypto.Engines;

public class Rfc3394WrapEngine : IWrapper
{
	private readonly IBlockCipher engine;

	private readonly bool wrapCipherMode;

	private KeyParameter param;

	private bool forWrapping;

	private byte[] iv = new byte[8] { 166, 166, 166, 166, 166, 166, 166, 166 };

	public virtual string AlgorithmName => engine.AlgorithmName;

	public Rfc3394WrapEngine(IBlockCipher engine)
		: this(engine, useReverseDirection: false)
	{
	}

	public Rfc3394WrapEngine(IBlockCipher engine, bool useReverseDirection)
	{
		this.engine = engine;
		wrapCipherMode = !useReverseDirection;
	}

	public virtual void Init(bool forWrapping, ICipherParameters parameters)
	{
		this.forWrapping = forWrapping;
		if (parameters is ParametersWithRandom parametersWithRandom)
		{
			parameters = parametersWithRandom.Parameters;
		}
		if (parameters is KeyParameter keyParameter)
		{
			param = keyParameter;
		}
		else if (parameters is ParametersWithIV parametersWithIV)
		{
			byte[] iV = parametersWithIV.GetIV();
			if (iV.Length != 8)
			{
				throw new ArgumentException("IV length not equal to 8", "parameters");
			}
			iv = iV;
			param = (KeyParameter)parametersWithIV.Parameters;
		}
	}

	public virtual byte[] Wrap(byte[] input, int inOff, int inLen)
	{
		if (!forWrapping)
		{
			throw new InvalidOperationException("not set for wrapping");
		}
		if (inLen < 8)
		{
			throw new DataLengthException("wrap data must be at least 8 bytes");
		}
		int num = inLen / 8;
		if (num * 8 != inLen)
		{
			throw new DataLengthException("wrap data must be a multiple of 8 bytes");
		}
		engine.Init(wrapCipherMode, param);
		byte[] array = new byte[inLen + iv.Length];
		Array.Copy(iv, 0, array, 0, iv.Length);
		Array.Copy(input, inOff, array, iv.Length, inLen);
		if (num == 1)
		{
			engine.ProcessBlock(array, 0, array, 0);
		}
		else
		{
			byte[] array2 = new byte[8 + iv.Length];
			for (int i = 0; i != 6; i++)
			{
				for (int j = 1; j <= num; j++)
				{
					Array.Copy(array, 0, array2, 0, iv.Length);
					Array.Copy(array, 8 * j, array2, iv.Length, 8);
					engine.ProcessBlock(array2, 0, array2, 0);
					int num2 = num * i + j;
					int num3 = 1;
					while (num2 != 0)
					{
						byte b = (byte)num2;
						array2[iv.Length - num3] ^= b;
						num2 >>>= 8;
						num3++;
					}
					Array.Copy(array2, 0, array, 0, 8);
					Array.Copy(array2, 8, array, 8 * j, 8);
				}
			}
		}
		return array;
	}

	public virtual byte[] Unwrap(byte[] input, int inOff, int inLen)
	{
		if (forWrapping)
		{
			throw new InvalidOperationException("not set for unwrapping");
		}
		if (inLen < 16)
		{
			throw new InvalidCipherTextException("unwrap data too short");
		}
		int num = inLen / 8;
		if (num * 8 != inLen)
		{
			throw new InvalidCipherTextException("unwrap data must be a multiple of 8 bytes");
		}
		engine.Init(!wrapCipherMode, param);
		byte[] array = new byte[inLen - iv.Length];
		byte[] array2 = new byte[iv.Length];
		byte[] array3 = new byte[8 + iv.Length];
		num--;
		if (num == 1)
		{
			engine.ProcessBlock(input, inOff, array3, 0);
			Array.Copy(array3, 0, array2, 0, iv.Length);
			Array.Copy(array3, iv.Length, array, 0, 8);
		}
		else
		{
			Array.Copy(input, inOff, array2, 0, iv.Length);
			Array.Copy(input, inOff + iv.Length, array, 0, inLen - iv.Length);
			for (int num2 = 5; num2 >= 0; num2--)
			{
				for (int num3 = num; num3 >= 1; num3--)
				{
					Array.Copy(array2, 0, array3, 0, iv.Length);
					Array.Copy(array, 8 * (num3 - 1), array3, iv.Length, 8);
					int num4 = num * num2 + num3;
					int num5 = 1;
					while (num4 != 0)
					{
						byte b = (byte)num4;
						array3[iv.Length - num5] ^= b;
						num4 >>>= 8;
						num5++;
					}
					engine.ProcessBlock(array3, 0, array3, 0);
					Array.Copy(array3, 0, array2, 0, 8);
					Array.Copy(array3, 8, array, 8 * (num3 - 1), 8);
				}
			}
		}
		if (!Arrays.FixedTimeEquals(array2, iv))
		{
			throw new InvalidCipherTextException("checksum failed");
		}
		return array;
	}
}
