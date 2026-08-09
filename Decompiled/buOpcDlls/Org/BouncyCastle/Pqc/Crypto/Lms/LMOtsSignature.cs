using System;
using System.IO;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.IO;

namespace Org.BouncyCastle.Pqc.Crypto.Lms;

public sealed class LMOtsSignature : IEncodable
{
	private readonly LMOtsParameters m_paramType;

	private readonly byte[] m_C;

	private readonly byte[] m_y;

	public LMOtsParameters ParamType => m_paramType;

	public byte[] C => m_C;

	public byte[] Y => m_y;

	public LMOtsSignature(LMOtsParameters paramType, byte[] c, byte[] y)
	{
		m_paramType = paramType;
		m_C = c;
		m_y = y;
	}

	public static LMOtsSignature GetInstance(object src)
	{
		if (src is LMOtsSignature result)
		{
			return result;
		}
		if (src is BinaryReader binaryReader)
		{
			LMOtsParameters parametersByID = LMOtsParameters.GetParametersByID(BinaryReaders.ReadInt32BigEndian(binaryReader));
			byte[] c = BinaryReaders.ReadBytesFully(binaryReader, parametersByID.N);
			byte[] y = BinaryReaders.ReadBytesFully(binaryReader, parametersByID.P * parametersByID.N);
			return new LMOtsSignature(parametersByID, c, y);
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
		if (!(obj is LMOtsSignature lMOtsSignature))
		{
			return false;
		}
		if (object.Equals(m_paramType, lMOtsSignature.m_paramType) && Arrays.AreEqual(m_C, lMOtsSignature.m_C))
		{
			return Arrays.AreEqual(m_y, lMOtsSignature.m_y);
		}
		return false;
	}

	public override int GetHashCode()
	{
		int hashCode = Objects.GetHashCode(m_paramType);
		hashCode = 31 * hashCode + Arrays.GetHashCode(m_C);
		return 31 * hashCode + Arrays.GetHashCode(m_y);
	}

	public byte[] GetEncoded()
	{
		return Composer.Compose().U32Str(m_paramType.ID).Bytes(m_C)
			.Bytes(m_y)
			.Build();
	}
}
