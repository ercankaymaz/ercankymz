using System;
using System.IO;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.IO;

namespace Org.BouncyCastle.Pqc.Crypto.Lms;

public sealed class LmsPublicKeyParameters : LmsKeyParameters, ILmsContextBasedVerifier
{
	private LMSigParameters parameterSet;

	private LMOtsParameters lmOtsType;

	private byte[] I;

	private byte[] T1;

	public LmsPublicKeyParameters(LMSigParameters parameterSet, LMOtsParameters lmOtsType, byte[] T1, byte[] I)
		: base(isPrivateKey: false)
	{
		this.parameterSet = parameterSet;
		this.lmOtsType = lmOtsType;
		this.I = Arrays.Clone(I);
		this.T1 = Arrays.Clone(T1);
	}

	public static LmsPublicKeyParameters GetInstance(object src)
	{
		if (src is LmsPublicKeyParameters result)
		{
			return result;
		}
		if (src is BinaryReader binaryReader)
		{
			LMSigParameters parametersByID = LMSigParameters.GetParametersByID(BinaryReaders.ReadInt32BigEndian(binaryReader));
			LMOtsParameters parametersByID2 = LMOtsParameters.GetParametersByID(BinaryReaders.ReadInt32BigEndian(binaryReader));
			byte[] i = BinaryReaders.ReadBytesFully(binaryReader, 16);
			byte[] t = BinaryReaders.ReadBytesFully(binaryReader, parametersByID.M);
			return new LmsPublicKeyParameters(parametersByID, parametersByID2, t, i);
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

	public override byte[] GetEncoded()
	{
		return ToByteArray();
	}

	public LMSigParameters GetSigParameters()
	{
		return parameterSet;
	}

	public LMOtsParameters GetOtsParameters()
	{
		return lmOtsType;
	}

	public LmsParameters GetLmsParameters()
	{
		return new LmsParameters(GetSigParameters(), GetOtsParameters());
	}

	public byte[] GetT1()
	{
		return Arrays.Clone(T1);
	}

	internal bool MatchesT1(byte[] sig)
	{
		return Arrays.FixedTimeEquals(T1, sig);
	}

	public byte[] GetI()
	{
		return Arrays.Clone(I);
	}

	private byte[] RefI()
	{
		return I;
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
		LmsPublicKeyParameters lmsPublicKeyParameters = (LmsPublicKeyParameters)o;
		if (!parameterSet.Equals(lmsPublicKeyParameters.parameterSet))
		{
			return false;
		}
		if (!lmOtsType.Equals(lmsPublicKeyParameters.lmOtsType))
		{
			return false;
		}
		if (!Arrays.AreEqual(I, lmsPublicKeyParameters.I))
		{
			return false;
		}
		return Arrays.AreEqual(T1, lmsPublicKeyParameters.T1);
	}

	public override int GetHashCode()
	{
		int hashCode = parameterSet.GetHashCode();
		hashCode = 31 * hashCode + lmOtsType.GetHashCode();
		hashCode = 31 * hashCode + Arrays.GetHashCode(I);
		return 31 * hashCode + Arrays.GetHashCode(T1);
	}

	internal byte[] ToByteArray()
	{
		return Composer.Compose().U32Str(parameterSet.ID).U32Str(lmOtsType.ID)
			.Bytes(I)
			.Bytes(T1)
			.Build();
	}

	public LmsContext GenerateLmsContext(byte[] signature)
	{
		try
		{
			return GenerateOtsContext(LmsSignature.GetInstance(signature));
		}
		catch (IOException ex)
		{
			throw new IOException("cannot parse signature: " + ex.Message);
		}
	}

	internal LmsContext GenerateOtsContext(LmsSignature S)
	{
		int iD = GetOtsParameters().ID;
		if (S.OtsSignature.ParamType.ID != iD)
		{
			throw new ArgumentException("ots type from lsm signature does not match ots signature type from embedded ots signature");
		}
		return new LMOtsPublicKey(LMOtsParameters.GetParametersByID(iD), I, S.Q, null).CreateOtsContext(S);
	}

	public bool Verify(LmsContext context)
	{
		return Lms.VerifySignature(this, context);
	}
}
