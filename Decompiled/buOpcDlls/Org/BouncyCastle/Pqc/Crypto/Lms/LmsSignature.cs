using System;
using System.IO;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.IO;

namespace Org.BouncyCastle.Pqc.Crypto.Lms;

public class LmsSignature : IEncodable
{
	private int q;

	private LMOtsSignature otsSignature;

	private LMSigParameters parameter;

	private byte[][] y;

	public int Q => q;

	public LMOtsSignature OtsSignature => otsSignature;

	public LMSigParameters SigParameters => parameter;

	public byte[][] Y => y;

	public LmsSignature(int q, LMOtsSignature otsSignature, LMSigParameters parameter, byte[][] y)
	{
		this.q = q;
		this.otsSignature = otsSignature;
		this.parameter = parameter;
		this.y = y;
	}

	public static LmsSignature GetInstance(object src)
	{
		if (src is LmsSignature result)
		{
			return result;
		}
		if (src is BinaryReader binaryReader)
		{
			int num = BinaryReaders.ReadInt32BigEndian(binaryReader);
			LMOtsSignature instance = LMOtsSignature.GetInstance(src);
			LMSigParameters parametersByID = LMSigParameters.GetParametersByID(BinaryReaders.ReadInt32BigEndian(binaryReader));
			byte[][] array = new byte[parametersByID.H][];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = new byte[parametersByID.M];
				binaryReader.Read(array[i], 0, array[i].Length);
			}
			return new LmsSignature(num, instance, parametersByID, array);
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

	public override bool Equals(object o)
	{
		if (this == o)
		{
			return true;
		}
		if (o == null || GetType() != o.GetType())
		{
			return false;
		}
		LmsSignature lmsSignature = (LmsSignature)o;
		if (q != lmsSignature.q)
		{
			return false;
		}
		if ((otsSignature != null) ? (!otsSignature.Equals(lmsSignature.otsSignature)) : (lmsSignature.otsSignature != null))
		{
			return false;
		}
		if ((parameter != null) ? (!parameter.Equals(lmsSignature.parameter)) : (lmsSignature.parameter != null))
		{
			return false;
		}
		return Compare2DArrays(y, lmsSignature.y);
	}

	private bool Compare2DArrays(byte[][] a, byte[][] b)
	{
		for (int i = 0; i < a.Length; i++)
		{
			for (int j = 0; j < a[0].Length; j++)
			{
				if (!a[i][j].Equals(b[i][j]))
				{
					return false;
				}
			}
		}
		return true;
	}

	public override int GetHashCode()
	{
		int num = q;
		num = 31 * num + ((otsSignature != null) ? otsSignature.GetHashCode() : 0);
		return 31 * num + ((parameter != null) ? parameter.GetHashCode() : 0);
	}

	public byte[] GetEncoded()
	{
		return Composer.Compose().U32Str(q).Bytes(otsSignature.GetEncoded())
			.U32Str(parameter.ID)
			.Bytes2(y)
			.Build();
	}
}
