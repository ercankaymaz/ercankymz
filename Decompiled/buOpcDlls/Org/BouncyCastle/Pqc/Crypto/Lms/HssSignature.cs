using System;
using System.IO;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.IO;

namespace Org.BouncyCastle.Pqc.Crypto.Lms;

public sealed class HssSignature : IEncodable
{
	private readonly int m_lMinus1;

	private readonly LmsSignedPubKey[] m_signedPubKey;

	private readonly LmsSignature m_signature;

	public LmsSignature Signature => m_signature;

	public HssSignature(int lMinus1, LmsSignedPubKey[] signedPubKey, LmsSignature signature)
	{
		m_lMinus1 = lMinus1;
		m_signedPubKey = signedPubKey;
		m_signature = signature;
	}

	public static HssSignature GetInstance(object src, int L)
	{
		if (src is HssSignature result)
		{
			return result;
		}
		if (src is BinaryReader binaryReader)
		{
			int num = BinaryReaders.ReadInt32BigEndian(binaryReader);
			if (num != L - 1)
			{
				throw new Exception("nspk exceeded maxNspk");
			}
			LmsSignedPubKey[] array = new LmsSignedPubKey[num];
			if (num != 0)
			{
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = new LmsSignedPubKey(LmsSignature.GetInstance(src), LmsPublicKeyParameters.GetInstance(src));
				}
			}
			LmsSignature instance = LmsSignature.GetInstance(src);
			return new HssSignature(num, array, instance);
		}
		if (src is byte[] buffer)
		{
			BinaryReader binaryReader2 = null;
			try
			{
				binaryReader2 = new BinaryReader(new MemoryStream(buffer));
				return GetInstance(binaryReader2, L);
			}
			finally
			{
				binaryReader2?.Close();
			}
		}
		if (src is MemoryStream inStr)
		{
			return GetInstance(Streams.ReadAll(inStr), L);
		}
		throw new ArgumentException($"cannot parse {src}");
	}

	public int GetLMinus1()
	{
		return m_lMinus1;
	}

	public LmsSignedPubKey[] GetSignedPubKeys()
	{
		return m_signedPubKey;
	}

	public override bool Equals(object other)
	{
		if (this == other)
		{
			return true;
		}
		if (!(other is HssSignature hssSignature))
		{
			return false;
		}
		if (m_lMinus1 != hssSignature.m_lMinus1)
		{
			return false;
		}
		if (m_signedPubKey.Length != hssSignature.m_signedPubKey.Length)
		{
			return false;
		}
		for (int i = 0; i < m_signedPubKey.Length; i++)
		{
			if (!m_signedPubKey[i].Equals(hssSignature.m_signedPubKey[i]))
			{
				return false;
			}
		}
		return object.Equals(m_signature, hssSignature.m_signature);
	}

	public override int GetHashCode()
	{
		int lMinus = m_lMinus1;
		lMinus = 31 * lMinus + m_signedPubKey.GetHashCode();
		return 31 * lMinus + ((m_signature != null) ? m_signature.GetHashCode() : 0);
	}

	public byte[] GetEncoded()
	{
		Composer composer = Composer.Compose();
		composer.U32Str(m_lMinus1);
		if (m_signedPubKey != null)
		{
			LmsSignedPubKey[] signedPubKey = m_signedPubKey;
			foreach (LmsSignedPubKey encodable in signedPubKey)
			{
				composer.Bytes(encodable);
			}
		}
		composer.Bytes(m_signature);
		return composer.Build();
	}
}
