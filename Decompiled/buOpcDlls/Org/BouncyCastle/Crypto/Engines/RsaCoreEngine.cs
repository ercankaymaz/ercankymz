using System;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;

namespace Org.BouncyCastle.Crypto.Engines;

public class RsaCoreEngine : IRsa
{
	private RsaKeyParameters key;

	private bool forEncryption;

	private int bitSize;

	private void CheckInitialised()
	{
		if (key == null)
		{
			throw new InvalidOperationException("RSA engine not initialised");
		}
	}

	public virtual void Init(bool forEncryption, ICipherParameters parameters)
	{
		if (parameters is ParametersWithRandom parametersWithRandom)
		{
			parameters = parametersWithRandom.Parameters;
		}
		if (!(parameters is RsaKeyParameters rsaKeyParameters))
		{
			throw new InvalidKeyException("Not an RSA key");
		}
		key = rsaKeyParameters;
		this.forEncryption = forEncryption;
		bitSize = key.Modulus.BitLength;
	}

	public virtual int GetInputBlockSize()
	{
		CheckInitialised();
		if (forEncryption)
		{
			return (bitSize - 1) / 8;
		}
		return (bitSize + 7) / 8;
	}

	public virtual int GetOutputBlockSize()
	{
		CheckInitialised();
		if (forEncryption)
		{
			return (bitSize + 7) / 8;
		}
		return (bitSize - 1) / 8;
	}

	public virtual BigInteger ConvertInput(byte[] inBuf, int inOff, int inLen)
	{
		CheckInitialised();
		int num = (bitSize + 7) / 8;
		if (inLen > num)
		{
			throw new DataLengthException("input too large for RSA cipher.");
		}
		BigInteger bigInteger = new BigInteger(1, inBuf, inOff, inLen);
		if (bigInteger.CompareTo(key.Modulus) >= 0)
		{
			throw new DataLengthException("input too large for RSA cipher.");
		}
		return bigInteger;
	}

	public virtual byte[] ConvertOutput(BigInteger result)
	{
		CheckInitialised();
		if (!forEncryption)
		{
			return BigIntegers.AsUnsignedByteArray(result);
		}
		return BigIntegers.AsUnsignedByteArray(GetOutputBlockSize(), result);
	}

	public virtual BigInteger ProcessBlock(BigInteger input)
	{
		CheckInitialised();
		if (key is RsaPrivateCrtKeyParameters { P: var p, Q: var q, DP: var dP, DQ: var dQ, QInv: var qInv })
		{
			BigInteger bigInteger = input.Remainder(p).ModPow(dP, p);
			BigInteger bigInteger2 = input.Remainder(q).ModPow(dQ, q);
			return bigInteger.Subtract(bigInteger2).Multiply(qInv).Mod(p)
				.Multiply(q)
				.Add(bigInteger2);
		}
		return input.ModPow(key.Exponent, key.Modulus);
	}
}
