// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Lms.LmsPrivateKeyParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.IO;
using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Lms;

public sealed class LmsPrivateKeyParameters : LmsKeyParameters, ILmsContextBasedSigner
{
  private static LmsPrivateKeyParameters.CacheKey T1 = new LmsPrivateKeyParameters.CacheKey(1);
  private static LmsPrivateKeyParameters.CacheKey[] internedKeys = new LmsPrivateKeyParameters.CacheKey[129];
  private byte[] I;
  private LMSigParameters parameters;
  private LMOtsParameters otsParameters;
  private int maxQ;
  private byte[] masterSecret;
  private Dictionary<LmsPrivateKeyParameters.CacheKey, byte[]> tCache;
  private int maxCacheR;
  private IDigest tDigest;
  private int q;
  private readonly bool m_isPlaceholder;
  private LmsPublicKeyParameters publicKey;

  static LmsPrivateKeyParameters()
  {
    LmsPrivateKeyParameters.internedKeys[1] = LmsPrivateKeyParameters.T1;
    for (int index = 2; index < LmsPrivateKeyParameters.internedKeys.Length; ++index)
      LmsPrivateKeyParameters.internedKeys[index] = new LmsPrivateKeyParameters.CacheKey(index);
  }

  public LmsPrivateKeyParameters(
    LMSigParameters lmsParameter,
    LMOtsParameters otsParameters,
    int q,
    byte[] I,
    int maxQ,
    byte[] masterSecret)
    : this(lmsParameter, otsParameters, q, I, maxQ, masterSecret, false)
  {
  }

  internal LmsPrivateKeyParameters(
    LMSigParameters lmsParameter,
    LMOtsParameters otsParameters,
    int q,
    byte[] I,
    int maxQ,
    byte[] masterSecret,
    bool isPlaceholder)
    : base(true)
  {
    this.parameters = lmsParameter;
    this.otsParameters = otsParameters;
    this.q = q;
    this.I = Arrays.Clone(I);
    this.maxQ = maxQ;
    this.masterSecret = Arrays.Clone(masterSecret);
    this.maxCacheR = 1 << this.parameters.H + 1;
    this.tCache = new Dictionary<LmsPrivateKeyParameters.CacheKey, byte[]>();
    this.tDigest = DigestUtilities.GetDigest(lmsParameter.DigestOid);
    this.m_isPlaceholder = isPlaceholder;
  }

  private LmsPrivateKeyParameters(LmsPrivateKeyParameters parent, int q, int maxQ)
    : base(true)
  {
    this.parameters = parent.parameters;
    this.otsParameters = parent.otsParameters;
    this.q = q;
    this.I = parent.I;
    this.maxQ = maxQ;
    this.masterSecret = parent.masterSecret;
    this.maxCacheR = 1 << this.parameters.H;
    this.tCache = parent.tCache;
    this.tDigest = DigestUtilities.GetDigest(this.parameters.DigestOid);
    this.publicKey = parent.publicKey;
  }

  public static LmsPrivateKeyParameters GetInstance(byte[] privEnc, byte[] pubEnc)
  {
    LmsPrivateKeyParameters instance = LmsPrivateKeyParameters.GetInstance((object) privEnc);
    instance.publicKey = LmsPublicKeyParameters.GetInstance((object) pubEnc);
    return instance;
  }

  public static LmsPrivateKeyParameters GetInstance(object src)
  {
    switch (src)
    {
      case LmsPrivateKeyParameters instance:
        return instance;
      case BinaryReader binaryReader:
        LMSigParameters lmsParameter = BinaryReaders.ReadInt32BigEndian(binaryReader) == 0 ? LMSigParameters.GetParametersByID(BinaryReaders.ReadInt32BigEndian(binaryReader)) : throw new Exception("unknown version for LMS private key");
        LMOtsParameters parametersById = LMOtsParameters.GetParametersByID(BinaryReaders.ReadInt32BigEndian(binaryReader));
        byte[] numArray1 = BinaryReaders.ReadBytesFully(binaryReader, 16 /*0x10*/);
        int num1 = BinaryReaders.ReadInt32BigEndian(binaryReader);
        int num2 = BinaryReaders.ReadInt32BigEndian(binaryReader);
        int count = BinaryReaders.ReadInt32BigEndian(binaryReader);
        byte[] numArray2 = count >= 0 ? BinaryReaders.ReadBytesFully(binaryReader, count) : throw new Exception("secret length less than zero");
        LMOtsParameters otsParameters = parametersById;
        int q = num1;
        byte[] I = numArray1;
        int maxQ = num2;
        byte[] masterSecret = numArray2;
        return new LmsPrivateKeyParameters(lmsParameter, otsParameters, q, I, maxQ, masterSecret);
      case byte[] buffer:
        BinaryReader src1 = (BinaryReader) null;
        try
        {
          src1 = new BinaryReader((Stream) new MemoryStream(buffer, false));
          return LmsPrivateKeyParameters.GetInstance((object) src1);
        }
        finally
        {
          src1?.Close();
        }
      case MemoryStream inStr:
        return LmsPrivateKeyParameters.GetInstance((object) Streams.ReadAll(inStr));
      default:
        throw new ArgumentException($"cannot parse {src}");
    }
  }

  internal LMOtsPrivateKey GetCurrentOtsKey()
  {
    lock (this)
    {
      if (this.q >= this.maxQ)
        throw new Exception("ots private keys expired");
      return new LMOtsPrivateKey(this.otsParameters, this.I, this.q, this.masterSecret);
    }
  }

  public int GetIndex()
  {
    lock (this)
      return this.q;
  }

  internal void IncIndex()
  {
    lock (this)
      ++this.q;
  }

  public LmsContext GenerateLmsContext()
  {
    int h = this.GetSigParameters().H;
    int index1 = this.GetIndex();
    LMOtsPrivateKey nextOtsPrivateKey = this.GetNextOtsPrivateKey();
    int index2 = 0;
    int num = (1 << h) + index1;
    byte[][] path = new byte[h][];
    for (; index2 < h; ++index2)
    {
      int r = num / (1 << index2) ^ 1;
      path[index2] = this.FindT(r);
    }
    return nextOtsPrivateKey.GetSignatureContext(this.GetSigParameters(), path);
  }

  public byte[] GenerateSignature(LmsContext context)
  {
    try
    {
      return Org.BouncyCastle.Pqc.Crypto.Lms.Lms.GenerateSign(context).GetEncoded();
    }
    catch (IOException ex)
    {
      throw new Exception("unable to encode signature: " + ex.Message, (Exception) ex);
    }
  }

  internal LMOtsPrivateKey GetNextOtsPrivateKey()
  {
    if (this.m_isPlaceholder)
      throw new Exception("placeholder only");
    lock (this)
    {
      if (this.q >= this.maxQ)
        throw new Exception("ots private key exhausted");
      LMOtsPrivateKey nextOtsPrivateKey = new LMOtsPrivateKey(this.otsParameters, this.I, this.q, this.masterSecret);
      this.IncIndex();
      return nextOtsPrivateKey;
    }
  }

  public LmsPrivateKeyParameters ExtractKeyShard(int usageCount)
  {
    lock (this)
    {
      if (this.q + usageCount >= this.maxQ)
        throw new ArgumentException("usageCount exceeds usages remaining");
      LmsPrivateKeyParameters keyShard = new LmsPrivateKeyParameters(this, this.q, this.q + usageCount);
      this.q += usageCount;
      return keyShard;
    }
  }

  public LMSigParameters GetSigParameters() => this.parameters;

  public LMOtsParameters GetOtsParameters() => this.otsParameters;

  public byte[] GetI() => Arrays.Clone(this.I);

  public byte[] GetMasterSecret() => Arrays.Clone(this.masterSecret);

  public long GetUsagesRemaining() => (long) (this.maxQ - this.q);

  public LmsPublicKeyParameters GetPublicKey()
  {
    if (this.m_isPlaceholder)
      throw new Exception("placeholder only");
    lock (this)
    {
      if (this.publicKey == null)
        this.publicKey = new LmsPublicKeyParameters(this.parameters, this.otsParameters, this.FindT(LmsPrivateKeyParameters.T1), this.I);
      return this.publicKey;
    }
  }

  internal byte[] FindT(int r)
  {
    return r < this.maxCacheR ? this.FindT(r < LmsPrivateKeyParameters.internedKeys.Length ? LmsPrivateKeyParameters.internedKeys[r] : new LmsPrivateKeyParameters.CacheKey(r)) : this.CalcT(r);
  }

  private byte[] FindT(LmsPrivateKeyParameters.CacheKey key)
  {
    lock (this.tCache)
    {
      byte[] numArray;
      return this.tCache.TryGetValue(key, out numArray) ? numArray : (this.tCache[key] = this.CalcT(key.index));
    }
  }

  private byte[] CalcT(int r)
  {
    int num = 1 << this.GetSigParameters().H;
    if (r >= num)
    {
      LmsUtilities.ByteArray(this.GetI(), this.tDigest);
      LmsUtilities.U32Str(r, this.tDigest);
      LmsUtilities.U16Str((short) Org.BouncyCastle.Pqc.Crypto.Lms.Lms.D_LEAF, this.tDigest);
      LmsUtilities.ByteArray(LMOts.LmsOtsGeneratePublicKey(this.GetOtsParameters(), this.GetI(), r - num, this.GetMasterSecret()), this.tDigest);
      byte[] output = new byte[this.tDigest.GetDigestSize()];
      this.tDigest.DoFinal(output, 0);
      return output;
    }
    byte[] t1 = this.FindT(2 * r);
    byte[] t2 = this.FindT(2 * r + 1);
    LmsUtilities.ByteArray(this.GetI(), this.tDigest);
    LmsUtilities.U32Str(r, this.tDigest);
    LmsUtilities.U16Str((short) Org.BouncyCastle.Pqc.Crypto.Lms.Lms.D_INTR, this.tDigest);
    LmsUtilities.ByteArray(t1, this.tDigest);
    IDigest tDigest = this.tDigest;
    LmsUtilities.ByteArray(t2, tDigest);
    byte[] output1 = new byte[this.tDigest.GetDigestSize()];
    this.tDigest.DoFinal(output1, 0);
    return output1;
  }

  public override bool Equals(object o)
  {
    if (this == o)
      return true;
    if (o == null || this.GetType() != o.GetType())
      return false;
    LmsPrivateKeyParameters privateKeyParameters = (LmsPrivateKeyParameters) o;
    if (this.q != privateKeyParameters.q || this.maxQ != privateKeyParameters.maxQ || !Arrays.AreEqual(this.I, privateKeyParameters.I) || (this.parameters != null ? (!this.parameters.Equals((object) privateKeyParameters.parameters) ? 1 : 0) : (privateKeyParameters.parameters != null ? 1 : 0)) != 0 || (this.otsParameters != null ? (!this.otsParameters.Equals((object) privateKeyParameters.otsParameters) ? 1 : 0) : (privateKeyParameters.otsParameters != null ? 1 : 0)) != 0 || !Arrays.AreEqual(this.masterSecret, privateKeyParameters.masterSecret))
      return false;
    return this.publicKey == null || privateKeyParameters.publicKey == null || this.publicKey.Equals((object) privateKeyParameters.publicKey);
  }

  public override int GetHashCode()
  {
    return 31 /*0x1F*/ * (31 /*0x1F*/ * (31 /*0x1F*/ * (31 /*0x1F*/ * (31 /*0x1F*/ * (31 /*0x1F*/ * this.q + Arrays.GetHashCode(this.I)) + (this.parameters != null ? this.parameters.GetHashCode() : 0)) + (this.otsParameters != null ? this.otsParameters.GetHashCode() : 0)) + this.maxQ) + Arrays.GetHashCode(this.masterSecret)) + (this.publicKey != null ? this.publicKey.GetHashCode() : 0);
  }

  public override byte[] GetEncoded()
  {
    return Composer.Compose().U32Str(0).U32Str(this.parameters.ID).U32Str(this.otsParameters.ID).Bytes(this.I).U32Str(this.q).U32Str(this.maxQ).U32Str(this.masterSecret.Length).Bytes(this.masterSecret).Build();
  }

  private class CacheKey
  {
    internal int index;

    public CacheKey(int index) => this.index = index;

    public override int GetHashCode() => this.index;

    public override bool Equals(object o)
    {
      return o is LmsPrivateKeyParameters.CacheKey && ((LmsPrivateKeyParameters.CacheKey) o).index == this.index;
    }
  }
}
