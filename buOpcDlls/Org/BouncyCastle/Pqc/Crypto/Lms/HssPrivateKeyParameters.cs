// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Lms.HssPrivateKeyParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.IO;
using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
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

  public HssPrivateKeyParameters(
    int l,
    IList<LmsPrivateKeyParameters> keys,
    IList<LmsSignature> sig,
    long index,
    long indexLimit)
    : base(true)
  {
    this.l = l;
    this.keys = (IList<LmsPrivateKeyParameters>) new List<LmsPrivateKeyParameters>((IEnumerable<LmsPrivateKeyParameters>) keys);
    this.sig = (IList<LmsSignature>) new List<LmsSignature>((IEnumerable<LmsSignature>) sig);
    this.index = index;
    this.indexLimit = indexLimit;
    this.isShard = false;
    this.ResetKeyToIndex();
  }

  private HssPrivateKeyParameters(
    int l,
    IList<LmsPrivateKeyParameters> keys,
    IList<LmsSignature> sig,
    long index,
    long indexLimit,
    bool isShard)
    : base(true)
  {
    this.l = l;
    this.keys = (IList<LmsPrivateKeyParameters>) new List<LmsPrivateKeyParameters>((IEnumerable<LmsPrivateKeyParameters>) keys);
    this.sig = (IList<LmsSignature>) new List<LmsSignature>((IEnumerable<LmsSignature>) sig);
    this.index = index;
    this.indexLimit = indexLimit;
    this.isShard = isShard;
  }

  public static HssPrivateKeyParameters GetInstance(byte[] privEnc, byte[] pubEnc)
  {
    HssPrivateKeyParameters instance = HssPrivateKeyParameters.GetInstance((object) privEnc);
    instance.publicKey = HssPublicKeyParameters.GetInstance((object) pubEnc);
    return instance;
  }

  public static HssPrivateKeyParameters GetInstance(object src)
  {
    switch (src)
    {
      case HssPrivateKeyParameters instance:
        return instance;
      case BinaryReader binaryReader:
        int l = BinaryReaders.ReadInt32BigEndian(binaryReader) == 0 ? BinaryReaders.ReadInt32BigEndian(binaryReader) : throw new Exception("unknown version for HSS private key");
        long index1 = BinaryReaders.ReadInt64BigEndian(binaryReader);
        long indexLimit = BinaryReaders.ReadInt64BigEndian(binaryReader);
        bool isShard = binaryReader.ReadBoolean();
        List<LmsPrivateKeyParameters> keys = new List<LmsPrivateKeyParameters>();
        List<LmsSignature> sig = new List<LmsSignature>();
        for (int index2 = 0; index2 < l; ++index2)
          keys.Add(LmsPrivateKeyParameters.GetInstance(src));
        for (int index3 = 0; index3 < l - 1; ++index3)
          sig.Add(LmsSignature.GetInstance(src));
        return new HssPrivateKeyParameters(l, (IList<LmsPrivateKeyParameters>) keys, (IList<LmsSignature>) sig, index1, indexLimit, isShard);
      case byte[] buffer:
        BinaryReader src1 = (BinaryReader) null;
        try
        {
          src1 = new BinaryReader((Stream) new MemoryStream(buffer));
          return HssPrivateKeyParameters.GetInstance((object) src1);
        }
        finally
        {
          src1?.Close();
        }
      case MemoryStream inStr:
        return HssPrivateKeyParameters.GetInstance((object) Streams.ReadAll(inStr));
      default:
        throw new Exception($"cannot parse {src}");
    }
  }

  public int L => this.l;

  public long GetIndex()
  {
    lock (this)
      return this.index;
  }

  public LmsParameters[] GetLmsParameters()
  {
    lock (this)
    {
      int count = this.keys.Count;
      LmsParameters[] lmsParameters = new LmsParameters[count];
      for (int index = 0; index < count; ++index)
      {
        LmsPrivateKeyParameters key = this.keys[index];
        lmsParameters[index] = new LmsParameters(key.GetSigParameters(), key.GetOtsParameters());
      }
      return lmsParameters;
    }
  }

  internal void IncIndex()
  {
    lock (this)
      ++this.index;
  }

  private static HssPrivateKeyParameters MakeCopy(HssPrivateKeyParameters privateKeyParameters)
  {
    return HssPrivateKeyParameters.GetInstance((object) privateKeyParameters.GetEncoded());
  }

  protected void UpdateHierarchy(IList<LmsPrivateKeyParameters> newKeys, IList<LmsSignature> newSig)
  {
    lock (this)
    {
      this.keys = (IList<LmsPrivateKeyParameters>) new List<LmsPrivateKeyParameters>((IEnumerable<LmsPrivateKeyParameters>) newKeys);
      this.sig = (IList<LmsSignature>) new List<LmsSignature>((IEnumerable<LmsSignature>) newSig);
    }
  }

  public bool IsShard() => this.isShard;

  public long IndexLimit => this.indexLimit;

  public long GetUsagesRemaining() => this.indexLimit - this.index;

  private LmsPrivateKeyParameters GetRootKey() => this.keys[0];

  public HssPrivateKeyParameters ExtractKeyShard(int usageCount)
  {
    lock (this)
    {
      if (this.GetUsagesRemaining() < (long) usageCount)
        throw new ArgumentException("usageCount exceeds usages remaining in current leaf");
      long indexLimit = this.index + (long) usageCount;
      long index = this.index;
      this.index += (long) usageCount;
      HssPrivateKeyParameters keyShard = HssPrivateKeyParameters.MakeCopy(new HssPrivateKeyParameters(this.l, (IList<LmsPrivateKeyParameters>) new List<LmsPrivateKeyParameters>((IEnumerable<LmsPrivateKeyParameters>) this.GetKeys()), (IList<LmsSignature>) new List<LmsSignature>((IEnumerable<LmsSignature>) this.GetSig()), index, indexLimit, true));
      this.ResetKeyToIndex();
      return keyShard;
    }
  }

  public IList<LmsPrivateKeyParameters> GetKeys()
  {
    lock (this)
      return this.keys;
  }

  internal IList<LmsSignature> GetSig()
  {
    lock (this)
      return this.sig;
  }

  private void ResetKeyToIndex()
  {
    IList<LmsPrivateKeyParameters> keys = this.GetKeys();
    long[] numArray1 = new long[keys.Count];
    long index1 = this.GetIndex();
    for (int index2 = keys.Count - 1; index2 >= 0; --index2)
    {
      LMSigParameters sigParameters = keys[index2].GetSigParameters();
      int num = (1 << sigParameters.H) - 1;
      numArray1[index2] = index1 & (long) num;
      index1 >>= sigParameters.H;
    }
    bool flag1 = false;
    LmsPrivateKeyParameters rootKey = this.GetRootKey();
    if ((long) (this.keys[0].GetIndex() - 1) != numArray1[0])
    {
      this.keys[0] = Org.BouncyCastle.Pqc.Crypto.Lms.Lms.GenerateKeys(rootKey.GetSigParameters(), rootKey.GetOtsParameters(), (int) numArray1[0], rootKey.GetI(), rootKey.GetMasterSecret());
      flag1 = true;
    }
    for (int index3 = 1; index3 < numArray1.Length; ++index3)
    {
      LmsPrivateKeyParameters key = this.keys[index3 - 1];
      byte[] numArray2 = new byte[16 /*0x10*/];
      byte[] numArray3 = new byte[32 /*0x20*/];
      SeedDerive seedDerive = new SeedDerive(key.GetI(), key.GetMasterSecret(), DigestUtilities.GetDigest(key.GetOtsParameters().DigestOid));
      seedDerive.Q = (int) numArray1[index3 - 1];
      seedDerive.J = -2;
      seedDerive.DeriveSeed(true, numArray3, 0);
      byte[] numArray4 = new byte[32 /*0x20*/];
      seedDerive.DeriveSeed(false, numArray4, 0);
      Array.Copy((Array) numArray4, 0, (Array) numArray2, 0, numArray2.Length);
      bool flag2 = index3 < numArray1.Length - 1 ? numArray1[index3] == (long) (this.keys[index3].GetIndex() - 1) : numArray1[index3] == (long) this.keys[index3].GetIndex();
      if ((!Arrays.AreEqual(numArray2, this.keys[index3].GetI()) ? 0 : (Arrays.AreEqual(numArray3, this.keys[index3].GetMasterSecret()) ? 1 : 0)) == 0)
      {
        this.keys[index3] = Org.BouncyCastle.Pqc.Crypto.Lms.Lms.GenerateKeys(keys[index3].GetSigParameters(), keys[index3].GetOtsParameters(), (int) numArray1[index3], numArray2, numArray3);
        this.sig[index3 - 1] = Org.BouncyCastle.Pqc.Crypto.Lms.Lms.GenerateSign(this.keys[index3 - 1], this.keys[index3].GetPublicKey().ToByteArray());
        flag1 = true;
      }
      else if (!flag2)
      {
        this.keys[index3] = Org.BouncyCastle.Pqc.Crypto.Lms.Lms.GenerateKeys(keys[index3].GetSigParameters(), keys[index3].GetOtsParameters(), (int) numArray1[index3], numArray2, numArray3);
        flag1 = true;
      }
    }
    if (!flag1)
      return;
    this.UpdateHierarchy(this.keys, this.sig);
  }

  public HssPublicKeyParameters GetPublicKey()
  {
    lock (this)
      return new HssPublicKeyParameters(this.l, this.GetRootKey().GetPublicKey());
  }

  internal void ReplaceConsumedKey(int d)
  {
    SeedDerive derivationFunction = this.keys[d - 1].GetCurrentOtsKey().GetDerivationFunction();
    derivationFunction.J = -2;
    byte[] numArray1 = new byte[32 /*0x20*/];
    derivationFunction.DeriveSeed(true, numArray1, 0);
    byte[] numArray2 = new byte[32 /*0x20*/];
    derivationFunction.DeriveSeed(false, numArray2, 0);
    byte[] numArray3 = new byte[16 /*0x10*/];
    Array.Copy((Array) numArray2, 0, (Array) numArray3, 0, numArray3.Length);
    List<LmsPrivateKeyParameters> collection1 = new List<LmsPrivateKeyParameters>((IEnumerable<LmsPrivateKeyParameters>) this.keys);
    LmsPrivateKeyParameters key = this.keys[d];
    collection1[d] = Org.BouncyCastle.Pqc.Crypto.Lms.Lms.GenerateKeys(key.GetSigParameters(), key.GetOtsParameters(), 0, numArray3, numArray1);
    List<LmsSignature> collection2 = new List<LmsSignature>((IEnumerable<LmsSignature>) this.sig);
    collection2[d - 1] = Org.BouncyCastle.Pqc.Crypto.Lms.Lms.GenerateSign(collection1[d - 1], collection1[d].GetPublicKey().ToByteArray());
    this.keys = (IList<LmsPrivateKeyParameters>) new List<LmsPrivateKeyParameters>((IEnumerable<LmsPrivateKeyParameters>) collection1);
    this.sig = (IList<LmsSignature>) new List<LmsSignature>((IEnumerable<LmsSignature>) collection2);
  }

  public override bool Equals(object o)
  {
    if (this == o)
      return true;
    if (o == null || this.GetType() != o.GetType())
      return false;
    HssPrivateKeyParameters privateKeyParameters = (HssPrivateKeyParameters) o;
    return this.l == privateKeyParameters.l && this.isShard == privateKeyParameters.isShard && this.indexLimit == privateKeyParameters.indexLimit && this.index == privateKeyParameters.index && this.CompareLists<LmsPrivateKeyParameters>(this.keys, privateKeyParameters.keys) && this.CompareLists<LmsSignature>(this.sig, privateKeyParameters.sig);
  }

  private bool CompareLists<T>(IList<T> arr1, IList<T> arr2)
  {
    for (int index = 0; index < arr1.Count && index < arr2.Count; ++index)
    {
      if (!object.Equals((object) arr1[index], (object) arr2[index]))
        return false;
    }
    return true;
  }

  public override byte[] GetEncoded()
  {
    lock (this)
    {
      Composer composer = Composer.Compose().U32Str(0).U32Str(this.l).U64Str(this.index).U64Str(this.indexLimit).Boolean(this.isShard);
      foreach (LmsPrivateKeyParameters key in (IEnumerable<LmsPrivateKeyParameters>) this.keys)
        composer.Bytes((IEncodable) key);
      foreach (LmsSignature lmsSignature in (IEnumerable<LmsSignature>) this.sig)
        composer.Bytes((IEncodable) lmsSignature);
      return composer.Build();
    }
  }

  public override int GetHashCode()
  {
    return 31 /*0x1F*/ * (31 /*0x1F*/ * (31 /*0x1F*/ * (31 /*0x1F*/ * (31 /*0x1F*/ * this.l + (this.isShard ? 1 : 0)) + this.keys.GetHashCode()) + this.sig.GetHashCode()) + (int) (this.indexLimit ^ this.indexLimit >> 32 /*0x20*/)) + (int) (this.index ^ this.index >> 32 /*0x20*/);
  }

  protected object Clone() => (object) HssPrivateKeyParameters.MakeCopy(this);

  public LmsContext GenerateLmsContext()
  {
    int l = this.L;
    LmsPrivateKeyParameters key;
    LmsSignedPubKey[] signedPubKeys;
    lock (this)
    {
      Hss.RangeTestKeys(this);
      IList<LmsPrivateKeyParameters> keys = this.GetKeys();
      IList<LmsSignature> sig = this.GetSig();
      key = this.GetKeys()[l - 1];
      int index = 0;
      signedPubKeys = new LmsSignedPubKey[l - 1];
      for (; index < l - 1; ++index)
        signedPubKeys[index] = new LmsSignedPubKey(sig[index], keys[index + 1].GetPublicKey());
      this.IncIndex();
    }
    return key.GenerateLmsContext().WithSignedPublicKeys(signedPubKeys);
  }

  public byte[] GenerateSignature(LmsContext context)
  {
    try
    {
      return Hss.GenerateSignature(this.L, context).GetEncoded();
    }
    catch (IOException ex)
    {
      throw new Exception("unable to encode signature: " + ex.Message, (Exception) ex);
    }
  }
}
