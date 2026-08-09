using System;
using System.IO;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.IO;

namespace Org.BouncyCastle.Pqc.Crypto.Lms;

public sealed class LMOtsPublicKey
{
	private readonly LMOtsParameters m_parameters;

	private readonly byte[] m_I;

	private readonly int m_q;

	private readonly byte[] m_K;

	public LMOtsParameters Parameters => m_parameters;

	public byte[] I => m_I;

	public int Q => m_q;

	public byte[] K => m_K;

	public LMOtsPublicKey(LMOtsParameters parameters, byte[] i, int q, byte[] k)
	{
		m_parameters = parameters;
		m_I = i;
		m_q = q;
		m_K = k;
	}

	public static LMOtsPublicKey GetInstance(object src)
	{
		if (src is LMOtsPublicKey result)
		{
			return result;
		}
		if (src is BinaryReader binaryReader)
		{
			LMOtsParameters parametersByID = LMOtsParameters.GetParametersByID(BinaryReaders.ReadInt32BigEndian(binaryReader));
			byte[] i = BinaryReaders.ReadBytesFully(binaryReader, 16);
			int q = BinaryReaders.ReadInt32BigEndian(binaryReader);
			byte[] k = BinaryReaders.ReadBytesFully(binaryReader, parametersByID.N);
			return new LMOtsPublicKey(parametersByID, i, q, k);
		}
		if (src is byte[] buffer)
		{
			BinaryReader binaryReader2 = null;
			try
			{
				binaryReader2 = new BinaryReader(new MemoryStream(buffer, writable: false));
				return GetInstance(binaryReader2);
			}
			finally
			{
				binaryReader2?.Close();
			}
		}
		if (src is MemoryStream inStr)
		{
			return GetInstance(Streams.ReadAll(inStr));
		}
		throw new Exception($"cannot parse {src}");
	}

	public override bool Equals(object obj)
	{
		if (this == obj)
		{
			return true;
		}
		if (!(obj is LMOtsPublicKey lMOtsPublicKey))
		{
			return false;
		}
		if (m_q == lMOtsPublicKey.m_q && object.Equals(m_parameters, lMOtsPublicKey.m_parameters) && Arrays.AreEqual(m_I, lMOtsPublicKey.m_I))
		{
			return Arrays.AreEqual(m_K, lMOtsPublicKey.m_K);
		}
		return false;
	}

	public override int GetHashCode()
	{
		int hashCode = Objects.GetHashCode(m_parameters);
		hashCode = 31 * hashCode + Arrays.GetHashCode(m_I);
		hashCode = 31 * hashCode + m_q;
		return 31 * hashCode + Arrays.GetHashCode(m_K);
	}

	public byte[] GetEncoded()
	{
		return Composer.Compose().U32Str(m_parameters.ID).Bytes(m_I)
			.U32Str(m_q)
			.Bytes(m_K)
			.Build();
	}

	internal LmsContext CreateOtsContext(LMOtsSignature signature)
	{
		IDigest digest = DigestUtilities.GetDigest(m_parameters.DigestOid);
		LmsUtilities.ByteArray(m_I, digest);
		LmsUtilities.U32Str(m_q, digest);
		LmsUtilities.U16Str((short)LMOts.D_MESG, digest);
		LmsUtilities.ByteArray(signature.C, digest);
		return new LmsContext(this, signature, digest);
	}

	internal LmsContext CreateOtsContext(LmsSignature signature)
	{
		IDigest digest = DigestUtilities.GetDigest(m_parameters.DigestOid);
		LmsUtilities.ByteArray(m_I, digest);
		LmsUtilities.U32Str(m_q, digest);
		LmsUtilities.U16Str((short)LMOts.D_MESG, digest);
		LmsUtilities.ByteArray(signature.OtsSignature.C, digest);
		return new LmsContext(this, signature, digest);
	}
}
