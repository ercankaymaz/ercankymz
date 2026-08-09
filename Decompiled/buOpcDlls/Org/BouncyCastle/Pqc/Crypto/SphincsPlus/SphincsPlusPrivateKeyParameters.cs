using System;
using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Utilities;

namespace Org.BouncyCastle.Pqc.Crypto.SphincsPlus;

public sealed class SphincsPlusPrivateKeyParameters : SphincsPlusKeyParameters
{
	internal readonly SK m_sk;

	internal readonly PK m_pk;

	public SphincsPlusPrivateKeyParameters(SphincsPlusParameters parameters, byte[] skpkEncoded)
		: base(isPrivate: true, parameters)
	{
		int n = parameters.N;
		if (skpkEncoded.Length != 4 * n)
		{
			throw new ArgumentException("private key encoding does not match parameters");
		}
		m_sk = new SK(Arrays.CopyOfRange(skpkEncoded, 0, n), Arrays.CopyOfRange(skpkEncoded, n, 2 * n));
		m_pk = new PK(Arrays.CopyOfRange(skpkEncoded, 2 * n, 3 * n), Arrays.CopyOfRange(skpkEncoded, 3 * n, 4 * n));
	}

	internal SphincsPlusPrivateKeyParameters(SphincsPlusParameters parameters, SK sk, PK pk)
		: base(isPrivate: true, parameters)
	{
		m_sk = sk;
		m_pk = pk;
	}

	public byte[] GetSeed()
	{
		return Arrays.Clone(m_sk.seed);
	}

	public byte[] GetPrf()
	{
		return Arrays.Clone(m_sk.prf);
	}

	public byte[] GetPublicSeed()
	{
		return Arrays.Clone(m_pk.seed);
	}

	public byte[] GetPublicKey()
	{
		return Arrays.Concatenate(m_pk.seed, m_pk.root);
	}

	public byte[] GetEncoded()
	{
		byte[] array = Pack.UInt32_To_BE((uint)SphincsPlusParameters.GetID(base.Parameters));
		return Arrays.ConcatenateAll(array, m_sk.seed, m_sk.prf, m_pk.seed, m_pk.root);
	}

	public byte[] GetEncodedPublicKey()
	{
		byte[] array = Pack.UInt32_To_BE((uint)SphincsPlusParameters.GetID(base.Parameters));
		return Arrays.ConcatenateAll(array, m_pk.seed, m_pk.root);
	}
}
