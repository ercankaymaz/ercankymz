using System;
using System.Collections.Generic;
using System.IO;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.IO;

namespace Org.BouncyCastle.Pqc.Crypto.Lms;

public sealed class LmsPrivateKeyParameters : LmsKeyParameters, ILmsContextBasedSigner
{
	private class CacheKey
	{
		internal int index;

		public CacheKey(int index)
		{
			this.index = index;
		}

		public override int GetHashCode()
		{
			return index;
		}

		public override bool Equals(object o)
		{
			if (o is CacheKey)
			{
				return ((CacheKey)o).index == index;
			}
			return false;
		}
	}

	private static CacheKey T1;

	private static CacheKey[] internedKeys;

	private byte[] I;

	private LMSigParameters parameters;

	private LMOtsParameters otsParameters;

	private int maxQ;

	private byte[] masterSecret;

	private Dictionary<CacheKey, byte[]> tCache;

	private int maxCacheR;

	private IDigest tDigest;

	private int q;

	private readonly bool m_isPlaceholder;

	private LmsPublicKeyParameters publicKey;

	static LmsPrivateKeyParameters()
	{
		T1 = new CacheKey(1);
		internedKeys = new CacheKey[129];
		internedKeys[1] = T1;
		for (int i = 2; i < internedKeys.Length; i++)
		{
			internedKeys[i] = new CacheKey(i);
		}
	}

	public LmsPrivateKeyParameters(LMSigParameters lmsParameter, LMOtsParameters otsParameters, int q, byte[] I, int maxQ, byte[] masterSecret)
		: this(lmsParameter, otsParameters, q, I, maxQ, masterSecret, isPlaceholder: false)
	{
	}

	internal LmsPrivateKeyParameters(LMSigParameters lmsParameter, LMOtsParameters otsParameters, int q, byte[] I, int maxQ, byte[] masterSecret, bool isPlaceholder)
		: base(isPrivateKey: true)
	{
		parameters = lmsParameter;
		this.otsParameters = otsParameters;
		this.q = q;
		this.I = Arrays.Clone(I);
		this.maxQ = maxQ;
		this.masterSecret = Arrays.Clone(masterSecret);
		maxCacheR = 1 << parameters.H + 1;
		tCache = new Dictionary<CacheKey, byte[]>();
		tDigest = DigestUtilities.GetDigest(lmsParameter.DigestOid);
		m_isPlaceholder = isPlaceholder;
	}

	private LmsPrivateKeyParameters(LmsPrivateKeyParameters parent, int q, int maxQ)
		: base(isPrivateKey: true)
	{
		parameters = parent.parameters;
		otsParameters = parent.otsParameters;
		this.q = q;
		I = parent.I;
		this.maxQ = maxQ;
		masterSecret = parent.masterSecret;
		maxCacheR = 1 << parameters.H;
		tCache = parent.tCache;
		tDigest = DigestUtilities.GetDigest(parameters.DigestOid);
		publicKey = parent.publicKey;
	}

	public static LmsPrivateKeyParameters GetInstance(byte[] privEnc, byte[] pubEnc)
	{
		LmsPrivateKeyParameters instance = GetInstance(privEnc);
		instance.publicKey = LmsPublicKeyParameters.GetInstance(pubEnc);
		return instance;
	}

	public static LmsPrivateKeyParameters GetInstance(object src)
	{
		if (src is LmsPrivateKeyParameters result)
		{
			return result;
		}
		if (src is BinaryReader binaryReader)
		{
			if (BinaryReaders.ReadInt32BigEndian(binaryReader) != 0)
			{
				throw new Exception("unknown version for LMS private key");
			}
			LMSigParameters parametersByID = LMSigParameters.GetParametersByID(BinaryReaders.ReadInt32BigEndian(binaryReader));
			LMOtsParameters parametersByID2 = LMOtsParameters.GetParametersByID(BinaryReaders.ReadInt32BigEndian(binaryReader));
			byte[] i = BinaryReaders.ReadBytesFully(binaryReader, 16);
			int num = BinaryReaders.ReadInt32BigEndian(binaryReader);
			int num2 = BinaryReaders.ReadInt32BigEndian(binaryReader);
			int num3 = BinaryReaders.ReadInt32BigEndian(binaryReader);
			if (num3 < 0)
			{
				throw new Exception("secret length less than zero");
			}
			byte[] array = BinaryReaders.ReadBytesFully(binaryReader, num3);
			return new LmsPrivateKeyParameters(parametersByID, parametersByID2, num, i, num2, array);
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
		throw new ArgumentException($"cannot parse {src}");
	}

	internal LMOtsPrivateKey GetCurrentOtsKey()
	{
		lock (this)
		{
			if (q >= maxQ)
			{
				throw new Exception("ots private keys expired");
			}
			return new LMOtsPrivateKey(otsParameters, I, q, masterSecret);
		}
	}

	public int GetIndex()
	{
		lock (this)
		{
			return q;
		}
	}

	internal void IncIndex()
	{
		lock (this)
		{
			q++;
		}
	}

	public LmsContext GenerateLmsContext()
	{
		int h = GetSigParameters().H;
		int index = GetIndex();
		LMOtsPrivateKey nextOtsPrivateKey = GetNextOtsPrivateKey();
		int i = 0;
		int num = (1 << h) + index;
		byte[][] array = new byte[h][];
		for (; i < h; i++)
		{
			int r = (num / (1 << i)) ^ 1;
			array[i] = FindT(r);
		}
		return nextOtsPrivateKey.GetSignatureContext(GetSigParameters(), array);
	}

	public byte[] GenerateSignature(LmsContext context)
	{
		try
		{
			return Lms.GenerateSign(context).GetEncoded();
		}
		catch (IOException ex)
		{
			throw new Exception("unable to encode signature: " + ex.Message, ex);
		}
	}

	internal LMOtsPrivateKey GetNextOtsPrivateKey()
	{
		if (m_isPlaceholder)
		{
			throw new Exception("placeholder only");
		}
		lock (this)
		{
			if (q >= maxQ)
			{
				throw new Exception("ots private key exhausted");
			}
			LMOtsPrivateKey result = new LMOtsPrivateKey(otsParameters, I, q, masterSecret);
			IncIndex();
			return result;
		}
	}

	public LmsPrivateKeyParameters ExtractKeyShard(int usageCount)
	{
		lock (this)
		{
			if (q + usageCount >= maxQ)
			{
				throw new ArgumentException("usageCount exceeds usages remaining");
			}
			LmsPrivateKeyParameters result = new LmsPrivateKeyParameters(this, q, q + usageCount);
			q += usageCount;
			return result;
		}
	}

	public LMSigParameters GetSigParameters()
	{
		return parameters;
	}

	public LMOtsParameters GetOtsParameters()
	{
		return otsParameters;
	}

	public byte[] GetI()
	{
		return Arrays.Clone(I);
	}

	public byte[] GetMasterSecret()
	{
		return Arrays.Clone(masterSecret);
	}

	public long GetUsagesRemaining()
	{
		return maxQ - q;
	}

	public LmsPublicKeyParameters GetPublicKey()
	{
		if (m_isPlaceholder)
		{
			throw new Exception("placeholder only");
		}
		lock (this)
		{
			if (publicKey == null)
			{
				publicKey = new LmsPublicKeyParameters(parameters, otsParameters, FindT(T1), I);
			}
			return publicKey;
		}
	}

	internal byte[] FindT(int r)
	{
		if (r < maxCacheR)
		{
			return FindT((r < internedKeys.Length) ? internedKeys[r] : new CacheKey(r));
		}
		return CalcT(r);
	}

	private byte[] FindT(CacheKey key)
	{
		lock (tCache)
		{
			if (tCache.TryGetValue(key, out var value))
			{
				return value;
			}
			return tCache[key] = CalcT(key.index);
		}
	}

	private byte[] CalcT(int r)
	{
		int h = GetSigParameters().H;
		int num = 1 << h;
		byte[] array;
		if (r >= num)
		{
			LmsUtilities.ByteArray(GetI(), tDigest);
			LmsUtilities.U32Str(r, tDigest);
			LmsUtilities.U16Str((short)Lms.D_LEAF, tDigest);
			LmsUtilities.ByteArray(LMOts.LmsOtsGeneratePublicKey(GetOtsParameters(), GetI(), r - num, GetMasterSecret()), tDigest);
			array = new byte[tDigest.GetDigestSize()];
			tDigest.DoFinal(array, 0);
			return array;
		}
		byte[] array2 = FindT(2 * r);
		byte[] array3 = FindT(2 * r + 1);
		LmsUtilities.ByteArray(GetI(), tDigest);
		LmsUtilities.U32Str(r, tDigest);
		LmsUtilities.U16Str((short)Lms.D_INTR, tDigest);
		LmsUtilities.ByteArray(array2, tDigest);
		LmsUtilities.ByteArray(array3, tDigest);
		array = new byte[tDigest.GetDigestSize()];
		tDigest.DoFinal(array, 0);
		return array;
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
		LmsPrivateKeyParameters lmsPrivateKeyParameters = (LmsPrivateKeyParameters)o;
		if (q != lmsPrivateKeyParameters.q)
		{
			return false;
		}
		if (maxQ != lmsPrivateKeyParameters.maxQ)
		{
			return false;
		}
		if (!Arrays.AreEqual(I, lmsPrivateKeyParameters.I))
		{
			return false;
		}
		if ((parameters != null) ? (!parameters.Equals(lmsPrivateKeyParameters.parameters)) : (lmsPrivateKeyParameters.parameters != null))
		{
			return false;
		}
		if ((otsParameters != null) ? (!otsParameters.Equals(lmsPrivateKeyParameters.otsParameters)) : (lmsPrivateKeyParameters.otsParameters != null))
		{
			return false;
		}
		if (!Arrays.AreEqual(masterSecret, lmsPrivateKeyParameters.masterSecret))
		{
			return false;
		}
		if (publicKey != null && lmsPrivateKeyParameters.publicKey != null)
		{
			return publicKey.Equals(lmsPrivateKeyParameters.publicKey);
		}
		return true;
	}

	public override int GetHashCode()
	{
		int num = q;
		num = 31 * num + Arrays.GetHashCode(I);
		num = 31 * num + ((parameters != null) ? parameters.GetHashCode() : 0);
		num = 31 * num + ((otsParameters != null) ? otsParameters.GetHashCode() : 0);
		num = 31 * num + maxQ;
		num = 31 * num + Arrays.GetHashCode(masterSecret);
		return 31 * num + ((publicKey != null) ? publicKey.GetHashCode() : 0);
	}

	public override byte[] GetEncoded()
	{
		return Composer.Compose().U32Str(0).U32Str(parameters.ID)
			.U32Str(otsParameters.ID)
			.Bytes(I)
			.U32Str(q)
			.U32Str(maxQ)
			.U32Str(masterSecret.Length)
			.Bytes(masterSecret)
			.Build();
	}
}
