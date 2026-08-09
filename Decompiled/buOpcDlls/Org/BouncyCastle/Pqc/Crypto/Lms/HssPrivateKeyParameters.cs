using System;
using System.Collections.Generic;
using System.IO;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.IO;

namespace Org.BouncyCastle.Pqc.Crypto.Lms;

public class HssPrivateKeyParameters : LmsKeyParameters, ILmsContextBasedSigner
{
	private int l;

	private bool isShard;

	private IList<LmsPrivateKeyParameters> keys;

	private IList<LmsSignature> sig;

	private long indexLimit;

	private long index;

	private HssPublicKeyParameters publicKey;

	public int L => l;

	public long IndexLimit => indexLimit;

	public HssPrivateKeyParameters(int l, IList<LmsPrivateKeyParameters> keys, IList<LmsSignature> sig, long index, long indexLimit)
		: base(isPrivateKey: true)
	{
		this.l = l;
		this.keys = new List<LmsPrivateKeyParameters>(keys);
		this.sig = new List<LmsSignature>(sig);
		this.index = index;
		this.indexLimit = indexLimit;
		isShard = false;
		ResetKeyToIndex();
	}

	private HssPrivateKeyParameters(int l, IList<LmsPrivateKeyParameters> keys, IList<LmsSignature> sig, long index, long indexLimit, bool isShard)
		: base(isPrivateKey: true)
	{
		this.l = l;
		this.keys = new List<LmsPrivateKeyParameters>(keys);
		this.sig = new List<LmsSignature>(sig);
		this.index = index;
		this.indexLimit = indexLimit;
		this.isShard = isShard;
	}

	public static HssPrivateKeyParameters GetInstance(byte[] privEnc, byte[] pubEnc)
	{
		HssPrivateKeyParameters instance = GetInstance(privEnc);
		instance.publicKey = HssPublicKeyParameters.GetInstance(pubEnc);
		return instance;
	}

	public static HssPrivateKeyParameters GetInstance(object src)
	{
		if (src is HssPrivateKeyParameters result)
		{
			return result;
		}
		if (src is BinaryReader binaryReader)
		{
			if (BinaryReaders.ReadInt32BigEndian(binaryReader) != 0)
			{
				throw new Exception("unknown version for HSS private key");
			}
			int num = BinaryReaders.ReadInt32BigEndian(binaryReader);
			long num2 = BinaryReaders.ReadInt64BigEndian(binaryReader);
			long num3 = BinaryReaders.ReadInt64BigEndian(binaryReader);
			bool flag = binaryReader.ReadBoolean();
			List<LmsPrivateKeyParameters> list = new List<LmsPrivateKeyParameters>();
			List<LmsSignature> list2 = new List<LmsSignature>();
			for (int i = 0; i < num; i++)
			{
				list.Add(LmsPrivateKeyParameters.GetInstance(src));
			}
			for (int j = 0; j < num - 1; j++)
			{
				list2.Add(LmsSignature.GetInstance(src));
			}
			return new HssPrivateKeyParameters(num, list, list2, num2, num3, flag);
		}
		if (src is byte[] buffer)
		{
			BinaryReader binaryReader2 = null;
			try
			{
				binaryReader2 = new BinaryReader(new MemoryStream(buffer));
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

	public long GetIndex()
	{
		lock (this)
		{
			return index;
		}
	}

	public LmsParameters[] GetLmsParameters()
	{
		lock (this)
		{
			int count = keys.Count;
			LmsParameters[] array = new LmsParameters[count];
			for (int i = 0; i < count; i++)
			{
				LmsPrivateKeyParameters lmsPrivateKeyParameters = keys[i];
				array[i] = new LmsParameters(lmsPrivateKeyParameters.GetSigParameters(), lmsPrivateKeyParameters.GetOtsParameters());
			}
			return array;
		}
	}

	internal void IncIndex()
	{
		lock (this)
		{
			index++;
		}
	}

	private static HssPrivateKeyParameters MakeCopy(HssPrivateKeyParameters privateKeyParameters)
	{
		return GetInstance(privateKeyParameters.GetEncoded());
	}

	protected void UpdateHierarchy(IList<LmsPrivateKeyParameters> newKeys, IList<LmsSignature> newSig)
	{
		lock (this)
		{
			keys = new List<LmsPrivateKeyParameters>(newKeys);
			sig = new List<LmsSignature>(newSig);
		}
	}

	public bool IsShard()
	{
		return isShard;
	}

	public long GetUsagesRemaining()
	{
		return indexLimit - index;
	}

	private LmsPrivateKeyParameters GetRootKey()
	{
		return keys[0];
	}

	public HssPrivateKeyParameters ExtractKeyShard(int usageCount)
	{
		lock (this)
		{
			if (GetUsagesRemaining() < usageCount)
			{
				throw new ArgumentException("usageCount exceeds usages remaining in current leaf");
			}
			long num = index + usageCount;
			long num2 = index;
			index += usageCount;
			List<LmsPrivateKeyParameters> list = new List<LmsPrivateKeyParameters>(GetKeys());
			List<LmsSignature> list2 = new List<LmsSignature>(GetSig());
			HssPrivateKeyParameters result = MakeCopy(new HssPrivateKeyParameters(l, list, list2, num2, num, isShard: true));
			ResetKeyToIndex();
			return result;
		}
	}

	public IList<LmsPrivateKeyParameters> GetKeys()
	{
		lock (this)
		{
			return keys;
		}
	}

	internal IList<LmsSignature> GetSig()
	{
		lock (this)
		{
			return sig;
		}
	}

	private void ResetKeyToIndex()
	{
		IList<LmsPrivateKeyParameters> list = GetKeys();
		long[] array = new long[list.Count];
		long num = GetIndex();
		for (int num2 = list.Count - 1; num2 >= 0; num2--)
		{
			LMSigParameters sigParameters = list[num2].GetSigParameters();
			int num3 = (1 << sigParameters.H) - 1;
			array[num2] = num & num3;
			num >>= sigParameters.H;
		}
		bool flag = false;
		LmsPrivateKeyParameters rootKey = GetRootKey();
		if (keys[0].GetIndex() - 1 != array[0])
		{
			keys[0] = Lms.GenerateKeys(rootKey.GetSigParameters(), rootKey.GetOtsParameters(), (int)array[0], rootKey.GetI(), rootKey.GetMasterSecret());
			flag = true;
		}
		for (int i = 1; i < array.Length; i++)
		{
			LmsPrivateKeyParameters lmsPrivateKeyParameters = keys[i - 1];
			byte[] array2 = new byte[16];
			byte[] array3 = new byte[32];
			SeedDerive seedDerive = new SeedDerive(lmsPrivateKeyParameters.GetI(), lmsPrivateKeyParameters.GetMasterSecret(), DigestUtilities.GetDigest(lmsPrivateKeyParameters.GetOtsParameters().DigestOid));
			seedDerive.Q = (int)array[i - 1];
			seedDerive.J = -2;
			seedDerive.DeriveSeed(incJ: true, array3, 0);
			byte[] array4 = new byte[32];
			seedDerive.DeriveSeed(incJ: false, array4, 0);
			Array.Copy(array4, 0, array2, 0, array2.Length);
			bool flag2 = ((i < array.Length - 1) ? (array[i] == keys[i].GetIndex() - 1) : (array[i] == keys[i].GetIndex()));
			if (!Arrays.AreEqual(array2, keys[i].GetI()) || !Arrays.AreEqual(array3, keys[i].GetMasterSecret()))
			{
				keys[i] = Lms.GenerateKeys(list[i].GetSigParameters(), list[i].GetOtsParameters(), (int)array[i], array2, array3);
				sig[i - 1] = Lms.GenerateSign(keys[i - 1], keys[i].GetPublicKey().ToByteArray());
				flag = true;
			}
			else if (!flag2)
			{
				keys[i] = Lms.GenerateKeys(list[i].GetSigParameters(), list[i].GetOtsParameters(), (int)array[i], array2, array3);
				flag = true;
			}
		}
		if (flag)
		{
			UpdateHierarchy(keys, sig);
		}
	}

	public HssPublicKeyParameters GetPublicKey()
	{
		lock (this)
		{
			return new HssPublicKeyParameters(l, GetRootKey().GetPublicKey());
		}
	}

	internal void ReplaceConsumedKey(int d)
	{
		SeedDerive derivationFunction = keys[d - 1].GetCurrentOtsKey().GetDerivationFunction();
		derivationFunction.J = -2;
		byte[] array = new byte[32];
		derivationFunction.DeriveSeed(incJ: true, array, 0);
		byte[] array2 = new byte[32];
		derivationFunction.DeriveSeed(incJ: false, array2, 0);
		byte[] array3 = new byte[16];
		Array.Copy(array2, 0, array3, 0, array3.Length);
		List<LmsPrivateKeyParameters> list = new List<LmsPrivateKeyParameters>(keys);
		LmsPrivateKeyParameters lmsPrivateKeyParameters = keys[d];
		list[d] = Lms.GenerateKeys(lmsPrivateKeyParameters.GetSigParameters(), lmsPrivateKeyParameters.GetOtsParameters(), 0, array3, array);
		List<LmsSignature> list2 = new List<LmsSignature>(sig);
		list2[d - 1] = Lms.GenerateSign(list[d - 1], list[d].GetPublicKey().ToByteArray());
		keys = new List<LmsPrivateKeyParameters>(list);
		sig = new List<LmsSignature>(list2);
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
		HssPrivateKeyParameters hssPrivateKeyParameters = (HssPrivateKeyParameters)o;
		if (l != hssPrivateKeyParameters.l)
		{
			return false;
		}
		if (isShard != hssPrivateKeyParameters.isShard)
		{
			return false;
		}
		if (indexLimit != hssPrivateKeyParameters.indexLimit)
		{
			return false;
		}
		if (index != hssPrivateKeyParameters.index)
		{
			return false;
		}
		if (!CompareLists(keys, hssPrivateKeyParameters.keys))
		{
			return false;
		}
		return CompareLists(sig, hssPrivateKeyParameters.sig);
	}

	private bool CompareLists<T>(IList<T> arr1, IList<T> arr2)
	{
		for (int i = 0; i < arr1.Count && i < arr2.Count; i++)
		{
			if (!object.Equals(arr1[i], arr2[i]))
			{
				return false;
			}
		}
		return true;
	}

	public override byte[] GetEncoded()
	{
		lock (this)
		{
			Composer composer = Composer.Compose().U32Str(0).U32Str(l)
				.U64Str(index)
				.U64Str(indexLimit)
				.Boolean(isShard);
			foreach (LmsPrivateKeyParameters key in keys)
			{
				composer.Bytes(key);
			}
			foreach (LmsSignature item in sig)
			{
				composer.Bytes(item);
			}
			return composer.Build();
		}
	}

	public override int GetHashCode()
	{
		int num = l;
		num = 31 * num + (isShard ? 1 : 0);
		num = 31 * num + keys.GetHashCode();
		num = 31 * num + sig.GetHashCode();
		num = 31 * num + (int)(indexLimit ^ (indexLimit >> 32));
		return 31 * num + (int)(index ^ (index >> 32));
	}

	protected object Clone()
	{
		return MakeCopy(this);
	}

	public LmsContext GenerateLmsContext()
	{
		int num = L;
		LmsPrivateKeyParameters lmsPrivateKeyParameters;
		LmsSignedPubKey[] array;
		lock (this)
		{
			Hss.RangeTestKeys(this);
			IList<LmsPrivateKeyParameters> list = GetKeys();
			IList<LmsSignature> list2 = GetSig();
			lmsPrivateKeyParameters = GetKeys()[num - 1];
			int i = 0;
			array = new LmsSignedPubKey[num - 1];
			for (; i < num - 1; i++)
			{
				array[i] = new LmsSignedPubKey(list2[i], list[i + 1].GetPublicKey());
			}
			IncIndex();
		}
		return lmsPrivateKeyParameters.GenerateLmsContext().WithSignedPublicKeys(array);
	}

	public byte[] GenerateSignature(LmsContext context)
	{
		try
		{
			return Hss.GenerateSignature(L, context).GetEncoded();
		}
		catch (IOException ex)
		{
			throw new Exception("unable to encode signature: " + ex.Message, ex);
		}
	}
}
