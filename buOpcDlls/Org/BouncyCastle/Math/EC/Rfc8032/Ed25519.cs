// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Rfc8032.Ed25519
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Math.EC.Rfc7748;
using Org.BouncyCastle.Math.Raw;
using Org.BouncyCastle.Security;
using System;

#nullable disable
namespace Org.BouncyCastle.Math.EC.Rfc8032;

public static class Ed25519
{
  private const int CoordUints = 8;
  private const int PointBytes = 32 /*0x20*/;
  private const int ScalarUints = 8;
  private const int ScalarBytes = 32 /*0x20*/;
  public static readonly int PrehashSize = 64 /*0x40*/;
  public static readonly int PublicKeySize = 32 /*0x20*/;
  public static readonly int SecretKeySize = 32 /*0x20*/;
  public static readonly int SignatureSize = 64 /*0x40*/;
  private static readonly byte[] Dom2Prefix = new byte[32 /*0x20*/]
  {
    (byte) 83,
    (byte) 105,
    (byte) 103,
    (byte) 69,
    (byte) 100,
    (byte) 50,
    (byte) 53,
    (byte) 53,
    (byte) 49,
    (byte) 57,
    (byte) 32 /*0x20*/,
    (byte) 110,
    (byte) 111,
    (byte) 32 /*0x20*/,
    (byte) 69,
    (byte) 100,
    (byte) 50,
    (byte) 53,
    (byte) 53,
    (byte) 49,
    (byte) 57,
    (byte) 32 /*0x20*/,
    (byte) 99,
    (byte) 111,
    (byte) 108,
    (byte) 108,
    (byte) 105,
    (byte) 115,
    (byte) 105,
    (byte) 111,
    (byte) 110,
    (byte) 115
  };
  private static readonly uint[] P = new uint[8]
  {
    4294967277U,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    (uint) int.MaxValue
  };
  private static readonly uint[] Order8_y1 = new uint[8]
  {
    1886001095U,
    1339575613U,
    1980447930U,
    258412557U,
    4199751722U,
    3335272748U,
    2013120334U,
    2047061138U
  };
  private static readonly uint[] Order8_y2 = new uint[8]
  {
    2408966182U,
    2955391682U,
    2314519365U,
    4036554738U,
    95215573U,
    959694547U,
    2281846961U,
    100422509U
  };
  private static readonly int[] B_x = new int[10]
  {
    52811034,
    25909283,
    8072341,
    50637101,
    13785486,
    30858332,
    20483199,
    20966410,
    43936626,
    4379245
  };
  private static readonly int[] B_y = new int[10]
  {
    40265304,
    26843545,
    6710886 /*0x666666*/,
    53687091 /*0x03333333*/,
    13421772 /*0xCCCCCC*/,
    40265318,
    26843545,
    6710886 /*0x666666*/,
    53687091 /*0x03333333*/,
    13421772 /*0xCCCCCC*/
  };
  private static readonly int[] B128_x = new int[10]
  {
    12052516,
    1174424,
    4087752,
    38672185,
    20040971,
    21899680,
    55468344,
    20105554,
    66708015,
    9981791
  };
  private static readonly int[] B128_y = new int[10]
  {
    66430571,
    45040722,
    4842939,
    15895846,
    18981244,
    46308410,
    4697481,
    8903007,
    53646190,
    12474675
  };
  private static readonly int[] C_d = new int[10]
  {
    56195235,
    47411844,
    25868126,
    40503822,
    57364,
    58321048,
    30416477,
    31930572,
    57760639,
    10749657
  };
  private static readonly int[] C_d2 = new int[10]
  {
    45281625,
    27714825,
    18181821,
    13898781,
    114729,
    49533232,
    60832955,
    30306712,
    48412415,
    4722099
  };
  private static readonly int[] C_d4 = new int[10]
  {
    23454386,
    55429651,
    2809210,
    27797563,
    229458,
    31957600,
    54557047,
    27058993,
    29715967,
    9444199
  };
  private const int WnafWidth128 = 4;
  private const int WnafWidthBase = 6;
  private const int PrecompBlocks = 8;
  private const int PrecompTeeth = 4;
  private const int PrecompSpacing = 8;
  private const int PrecompRange = 256 /*0x0100*/;
  private const int PrecompPoints = 8;
  private const int PrecompMask = 7;
  private static readonly object PrecompLock = new object();
  private static Ed25519.PointPrecomp[] PrecompBaseWnaf = (Ed25519.PointPrecomp[]) null;
  private static Ed25519.PointPrecomp[] PrecompBase128Wnaf = (Ed25519.PointPrecomp[]) null;
  private static int[] PrecompBaseComb = (int[]) null;

  private static byte[] CalculateS(byte[] r, byte[] k, byte[] s)
  {
    uint[] numArray1 = new uint[16 /*0x10*/];
    Scalar25519.Decode(r, numArray1);
    uint[] numArray2 = new uint[8];
    Scalar25519.Decode(k, numArray2);
    uint[] numArray3 = new uint[8];
    Scalar25519.Decode(s, numArray3);
    int num = (int) Nat256.MulAddTo(numArray2, numArray3, numArray1);
    byte[] numArray4 = new byte[64 /*0x40*/];
    Codec.Encode32(numArray1, 0, numArray1.Length, numArray4, 0);
    return Scalar25519.Reduce(numArray4);
  }

  private static bool CheckContextVar(byte[] ctx, byte phflag)
  {
    if (ctx == null && phflag == (byte) 0)
      return true;
    return ctx != null && ctx.Length < 256 /*0x0100*/;
  }

  private static int CheckPoint(ref Ed25519.PointAffine p)
  {
    int[] numArray1 = X25519Field.Create();
    int[] numArray2 = X25519Field.Create();
    int[] numArray3 = X25519Field.Create();
    X25519Field.Sqr(p.x, numArray2);
    X25519Field.Sqr(p.y, numArray3);
    X25519Field.Mul(numArray2, numArray3, numArray1);
    X25519Field.Sub(numArray3, numArray2, numArray3);
    X25519Field.Mul(numArray1, Ed25519.C_d, numArray1);
    X25519Field.AddOne(numArray1);
    X25519Field.Sub(numArray1, numArray3, numArray1);
    X25519Field.Normalize(numArray1);
    return X25519Field.IsZero(numArray1);
  }

  private static int CheckPoint(Ed25519.PointAccum p)
  {
    int[] numArray1 = X25519Field.Create();
    int[] numArray2 = X25519Field.Create();
    int[] numArray3 = X25519Field.Create();
    int[] numArray4 = X25519Field.Create();
    X25519Field.Sqr(p.x, numArray2);
    X25519Field.Sqr(p.y, numArray3);
    X25519Field.Sqr(p.z, numArray4);
    X25519Field.Mul(numArray2, numArray3, numArray1);
    X25519Field.Sub(numArray3, numArray2, numArray3);
    X25519Field.Mul(numArray3, numArray4, numArray3);
    X25519Field.Sqr(numArray4, numArray4);
    X25519Field.Mul(numArray1, Ed25519.C_d, numArray1);
    X25519Field.Add(numArray1, numArray4, numArray1);
    X25519Field.Sub(numArray1, numArray3, numArray1);
    X25519Field.Normalize(numArray1);
    return X25519Field.IsZero(numArray1);
  }

  private static bool CheckPointFullVar(byte[] p)
  {
    int num1;
    uint num2 = (uint) (num1 = (int) Codec.Decode32(p, 28) & int.MaxValue);
    uint num3 = (uint) num1 ^ Ed25519.P[7];
    uint num4 = (uint) num1 ^ Ed25519.Order8_y1[7];
    uint num5 = (uint) num1 ^ Ed25519.Order8_y2[7];
    for (int index = 6; index > 0; --index)
    {
      uint num6 = Codec.Decode32(p, index * 4);
      num2 |= num6;
      num3 |= num6 ^ Ed25519.P[index];
      num4 |= num6 ^ Ed25519.Order8_y1[index];
      num5 |= num6 ^ Ed25519.Order8_y2[index];
    }
    uint num7 = Codec.Decode32(p, 0);
    return (num2 != 0U || num7 > 1U) && (num3 != 0U || num7 < Ed25519.P[0] - 1U) && (num4 | num7 ^ Ed25519.Order8_y1[0]) > 0U & (num5 | num7 ^ Ed25519.Order8_y2[0]) > 0U;
  }

  private static bool CheckPointOrderVar(ref Ed25519.PointAffine p)
  {
    Ed25519.PointAccum r;
    Ed25519.Init(out r);
    Ed25519.ScalarMultOrderVar(ref p, ref r);
    return Ed25519.NormalizeToNeutralElementVar(ref r);
  }

  private static bool CheckPointVar(byte[] p)
  {
    if ((Codec.Decode32(p, 28) & (uint) int.MaxValue) < Ed25519.P[7])
      return true;
    for (int index = 6; index >= 0; --index)
    {
      if (Codec.Decode32(p, index * 4) < Ed25519.P[index])
        return true;
    }
    return false;
  }

  private static byte[] Copy(byte[] buf, int off, int len)
  {
    byte[] destinationArray = new byte[len];
    Array.Copy((Array) buf, off, (Array) destinationArray, 0, len);
    return destinationArray;
  }

  private static IDigest CreateDigest()
  {
    Sha512Digest sha512Digest = new Sha512Digest();
    return sha512Digest.GetDigestSize() == 64 /*0x40*/ ? (IDigest) sha512Digest : throw new InvalidOperationException();
  }

  public static IDigest CreatePrehash() => Ed25519.CreateDigest();

  private static bool DecodePointVar(byte[] p, bool negate, ref Ed25519.PointAffine r)
  {
    int num = ((int) p[31 /*0x1F*/] & 128 /*0x80*/) >> 7;
    X25519Field.Decode(p, r.y);
    int[] numArray1 = X25519Field.Create();
    int[] numArray2 = X25519Field.Create();
    X25519Field.Sqr(r.y, numArray1);
    X25519Field.Mul(Ed25519.C_d, numArray1, numArray2);
    X25519Field.SubOne(numArray1);
    X25519Field.AddOne(numArray2);
    if (!X25519Field.SqrtRatioVar(numArray1, numArray2, r.x))
      return false;
    X25519Field.Normalize(r.x);
    if (num == 1 && X25519Field.IsZeroVar(r.x))
      return false;
    if (negate ^ num != (r.x[0] & 1))
    {
      X25519Field.Negate(r.x, r.x);
      X25519Field.Normalize(r.x);
    }
    return true;
  }

  private static void Dom2(IDigest d, byte phflag, byte[] ctx)
  {
    int length = Ed25519.Dom2Prefix.Length;
    byte[] input = new byte[length + 2 + ctx.Length];
    Ed25519.Dom2Prefix.CopyTo((Array) input, 0);
    input[length] = phflag;
    input[length + 1] = (byte) ctx.Length;
    ctx.CopyTo((Array) input, length + 2);
    d.BlockUpdate(input, 0, input.Length);
  }

  private static void EncodePoint(ref Ed25519.PointAffine p, byte[] r, int rOff)
  {
    X25519Field.Encode(p.y, r, rOff);
    r[rOff + 32 /*0x20*/ - 1] |= (byte) ((p.x[0] & 1) << 7);
  }

  public static void EncodePublicPoint(Ed25519.PublicPoint publicPoint, byte[] pk, int pkOff)
  {
    X25519Field.Encode(publicPoint.m_data, 10, pk, pkOff);
    pk[pkOff + 32 /*0x20*/ - 1] |= (byte) ((publicPoint.m_data[0] & 1) << 7);
  }

  private static int EncodeResult(ref Ed25519.PointAccum p, byte[] r, int rOff)
  {
    Ed25519.PointAffine r1;
    Ed25519.Init(out r1);
    Ed25519.NormalizeToAffine(ref p, ref r1);
    int num = Ed25519.CheckPoint(ref r1);
    Ed25519.EncodePoint(ref r1, r, rOff);
    return num;
  }

  private static Ed25519.PublicPoint ExportPoint(ref Ed25519.PointAffine p)
  {
    int[] numArray = new int[20];
    X25519Field.Copy(p.x, 0, numArray, 0);
    X25519Field.Copy(p.y, 0, numArray, 10);
    return new Ed25519.PublicPoint(numArray);
  }

  public static void GeneratePrivateKey(SecureRandom random, byte[] k)
  {
    if (k.Length != Ed25519.SecretKeySize)
      throw new ArgumentException(nameof (k));
    random.NextBytes(k);
  }

  public static void GeneratePublicKey(byte[] sk, int skOff, byte[] pk, int pkOff)
  {
    IDigest digest = Ed25519.CreateDigest();
    byte[] numArray1 = new byte[64 /*0x40*/];
    digest.BlockUpdate(sk, skOff, Ed25519.SecretKeySize);
    digest.DoFinal(numArray1, 0);
    byte[] numArray2 = new byte[32 /*0x20*/];
    Ed25519.PruneScalar(numArray1, 0, numArray2);
    Ed25519.ScalarMultBaseEncoded(numArray2, pk, pkOff);
  }

  public static Ed25519.PublicPoint GeneratePublicKey(byte[] sk, int skOff)
  {
    IDigest digest = Ed25519.CreateDigest();
    byte[] numArray1 = new byte[64 /*0x40*/];
    digest.BlockUpdate(sk, skOff, Ed25519.SecretKeySize);
    digest.DoFinal(numArray1, 0);
    byte[] numArray2 = new byte[32 /*0x20*/];
    Ed25519.PruneScalar(numArray1, 0, numArray2);
    Ed25519.PointAccum r1;
    Ed25519.Init(out r1);
    Ed25519.ScalarMultBase(numArray2, ref r1);
    Ed25519.PointAffine r2;
    Ed25519.Init(out r2);
    Ed25519.NormalizeToAffine(ref r1, ref r2);
    return Ed25519.CheckPoint(ref r2) != 0 ? Ed25519.ExportPoint(ref r2) : throw new InvalidOperationException();
  }

  private static uint GetWindow4(uint[] x, int n)
  {
    int index = n >>> 3;
    int num = (n & 7) << 2;
    return x[index] >> num & 15U;
  }

  private static void GroupCombBits(uint[] n)
  {
    for (int index = 0; index < n.Length; ++index)
      n[index] = Interleave.Shuffle2(n[index]);
  }

  private static void ImplSign(
    IDigest d,
    byte[] h,
    byte[] s,
    byte[] pk,
    int pkOff,
    byte[] ctx,
    byte phflag,
    byte[] m,
    int mOff,
    int mLen,
    byte[] sig,
    int sigOff)
  {
    if (ctx != null)
      Ed25519.Dom2(d, phflag, ctx);
    d.BlockUpdate(h, 32 /*0x20*/, 32 /*0x20*/);
    d.BlockUpdate(m, mOff, mLen);
    d.DoFinal(h, 0);
    byte[] numArray1 = Scalar25519.Reduce(h);
    byte[] numArray2 = new byte[32 /*0x20*/];
    Ed25519.ScalarMultBaseEncoded(numArray1, numArray2, 0);
    if (ctx != null)
      Ed25519.Dom2(d, phflag, ctx);
    d.BlockUpdate(numArray2, 0, 32 /*0x20*/);
    d.BlockUpdate(pk, pkOff, 32 /*0x20*/);
    d.BlockUpdate(m, mOff, mLen);
    d.DoFinal(h, 0);
    byte[] s1 = Ed25519.CalculateS(numArray1, Scalar25519.Reduce(h), s);
    Array.Copy((Array) numArray2, 0, (Array) sig, sigOff, 32 /*0x20*/);
    byte[] destinationArray = sig;
    int destinationIndex = sigOff + 32 /*0x20*/;
    Array.Copy((Array) s1, 0, (Array) destinationArray, destinationIndex, 32 /*0x20*/);
  }

  private static void ImplSign(
    byte[] sk,
    int skOff,
    byte[] ctx,
    byte phflag,
    byte[] m,
    int mOff,
    int mLen,
    byte[] sig,
    int sigOff)
  {
    if (!Ed25519.CheckContextVar(ctx, phflag))
      throw new ArgumentException(nameof (ctx));
    IDigest digest = Ed25519.CreateDigest();
    byte[] numArray1 = new byte[64 /*0x40*/];
    digest.BlockUpdate(sk, skOff, Ed25519.SecretKeySize);
    digest.DoFinal(numArray1, 0);
    byte[] numArray2 = new byte[32 /*0x20*/];
    Ed25519.PruneScalar(numArray1, 0, numArray2);
    byte[] numArray3 = new byte[32 /*0x20*/];
    Ed25519.ScalarMultBaseEncoded(numArray2, numArray3, 0);
    Ed25519.ImplSign(digest, numArray1, numArray2, numArray3, 0, ctx, phflag, m, mOff, mLen, sig, sigOff);
  }

  private static void ImplSign(
    byte[] sk,
    int skOff,
    byte[] pk,
    int pkOff,
    byte[] ctx,
    byte phflag,
    byte[] m,
    int mOff,
    int mLen,
    byte[] sig,
    int sigOff)
  {
    if (!Ed25519.CheckContextVar(ctx, phflag))
      throw new ArgumentException(nameof (ctx));
    IDigest digest = Ed25519.CreateDigest();
    byte[] numArray1 = new byte[64 /*0x40*/];
    digest.BlockUpdate(sk, skOff, Ed25519.SecretKeySize);
    digest.DoFinal(numArray1, 0);
    byte[] numArray2 = new byte[32 /*0x20*/];
    Ed25519.PruneScalar(numArray1, 0, numArray2);
    Ed25519.ImplSign(digest, numArray1, numArray2, pk, pkOff, ctx, phflag, m, mOff, mLen, sig, sigOff);
  }

  private static bool ImplVerify(
    byte[] sig,
    int sigOff,
    byte[] pk,
    int pkOff,
    byte[] ctx,
    byte phflag,
    byte[] m,
    int mOff,
    int mLen)
  {
    if (!Ed25519.CheckContextVar(ctx, phflag))
      throw new ArgumentException(nameof (ctx));
    byte[] numArray1 = Ed25519.Copy(sig, sigOff, 32 /*0x20*/);
    byte[] s = Ed25519.Copy(sig, sigOff + 32 /*0x20*/, 32 /*0x20*/);
    byte[] numArray2 = Ed25519.Copy(pk, pkOff, Ed25519.PublicKeySize);
    if (!Ed25519.CheckPointVar(numArray1))
      return false;
    uint[] numArray3 = new uint[8];
    if (!Scalar25519.CheckVar(s, numArray3) || !Ed25519.CheckPointFullVar(numArray2))
      return false;
    Ed25519.PointAffine r1;
    Ed25519.Init(out r1);
    if (!Ed25519.DecodePointVar(numArray1, true, ref r1))
      return false;
    Ed25519.PointAffine r2;
    Ed25519.Init(out r2);
    if (!Ed25519.DecodePointVar(numArray2, true, ref r2))
      return false;
    IDigest digest = Ed25519.CreateDigest();
    byte[] numArray4 = new byte[64 /*0x40*/];
    if (ctx != null)
      Ed25519.Dom2(digest, phflag, ctx);
    digest.BlockUpdate(numArray1, 0, 32 /*0x20*/);
    digest.BlockUpdate(numArray2, 0, 32 /*0x20*/);
    digest.BlockUpdate(m, mOff, mLen);
    digest.DoFinal(numArray4, 0);
    byte[] k1 = Scalar25519.Reduce(numArray4);
    uint[] k2 = new uint[8];
    uint[] n = k2;
    Scalar25519.Decode(k1, n);
    uint[] numArray5 = new uint[4];
    uint[] numArray6 = new uint[4];
    Scalar25519.ReduceBasisVar(k2, numArray5, numArray6);
    Scalar25519.Multiply128Var(numArray3, numArray6, numArray3);
    Ed25519.PointAccum r3;
    Ed25519.Init(out r3);
    Ed25519.ScalarMultStraus128Var(numArray3, numArray5, ref r2, numArray6, ref r1, ref r3);
    return Ed25519.NormalizeToNeutralElementVar(ref r3);
  }

  private static bool ImplVerify(
    byte[] sig,
    int sigOff,
    Ed25519.PublicPoint publicPoint,
    byte[] ctx,
    byte phflag,
    byte[] m,
    int mOff,
    int mLen)
  {
    if (!Ed25519.CheckContextVar(ctx, phflag))
      throw new ArgumentException(nameof (ctx));
    byte[] numArray1 = Ed25519.Copy(sig, sigOff, 32 /*0x20*/);
    byte[] s = Ed25519.Copy(sig, sigOff + 32 /*0x20*/, 32 /*0x20*/);
    if (!Ed25519.CheckPointVar(numArray1))
      return false;
    uint[] numArray2 = new uint[8];
    if (!Scalar25519.CheckVar(s, numArray2))
      return false;
    Ed25519.PointAffine r1;
    Ed25519.Init(out r1);
    if (!Ed25519.DecodePointVar(numArray1, true, ref r1))
      return false;
    Ed25519.PointAffine r2;
    Ed25519.Init(out r2);
    X25519Field.Negate(publicPoint.m_data, r2.x);
    X25519Field.Copy(publicPoint.m_data, 10, r2.y, 0);
    byte[] numArray3 = new byte[Ed25519.PublicKeySize];
    Ed25519.EncodePublicPoint(publicPoint, numArray3, 0);
    IDigest digest = Ed25519.CreateDigest();
    byte[] numArray4 = new byte[64 /*0x40*/];
    if (ctx != null)
      Ed25519.Dom2(digest, phflag, ctx);
    digest.BlockUpdate(numArray1, 0, 32 /*0x20*/);
    digest.BlockUpdate(numArray3, 0, 32 /*0x20*/);
    digest.BlockUpdate(m, mOff, mLen);
    digest.DoFinal(numArray4, 0);
    byte[] k1 = Scalar25519.Reduce(numArray4);
    uint[] k2 = new uint[8];
    uint[] n = k2;
    Scalar25519.Decode(k1, n);
    uint[] numArray5 = new uint[4];
    uint[] numArray6 = new uint[4];
    Scalar25519.ReduceBasisVar(k2, numArray5, numArray6);
    Scalar25519.Multiply128Var(numArray2, numArray6, numArray2);
    Ed25519.PointAccum r3;
    Ed25519.Init(out r3);
    Ed25519.ScalarMultStraus128Var(numArray2, numArray5, ref r2, numArray6, ref r1, ref r3);
    return Ed25519.NormalizeToNeutralElementVar(ref r3);
  }

  private static void Init(out Ed25519.PointAccum r)
  {
    r.x = X25519Field.Create();
    r.y = X25519Field.Create();
    r.z = X25519Field.Create();
    r.u = X25519Field.Create();
    r.v = X25519Field.Create();
  }

  private static void Init(out Ed25519.PointAffine r)
  {
    r.x = X25519Field.Create();
    r.y = X25519Field.Create();
  }

  private static void Init(out Ed25519.PointExtended r)
  {
    r.x = X25519Field.Create();
    r.y = X25519Field.Create();
    r.z = X25519Field.Create();
    r.t = X25519Field.Create();
  }

  private static void Init(out Ed25519.PointPrecomp r)
  {
    r.ymx_h = X25519Field.Create();
    r.ypx_h = X25519Field.Create();
    r.xyd = X25519Field.Create();
  }

  private static void Init(out Ed25519.PointPrecompZ r)
  {
    r.ymx_h = X25519Field.Create();
    r.ypx_h = X25519Field.Create();
    r.xyd = X25519Field.Create();
    r.z = X25519Field.Create();
  }

  private static void Init(out Ed25519.PointTemp r)
  {
    r.r0 = X25519Field.Create();
    r.r1 = X25519Field.Create();
  }

  private static void InvertDoubleZs(Ed25519.PointExtended[] points)
  {
    int length = points.Length;
    int[] table = X25519Field.CreateTable(length);
    int[] numArray1 = X25519Field.Create();
    X25519Field.Copy(points[0].z, 0, numArray1, 0);
    X25519Field.Copy(numArray1, 0, table, 0);
    int index1 = 0;
    while (++index1 < length)
    {
      X25519Field.Mul(numArray1, points[index1].z, numArray1);
      X25519Field.Copy(numArray1, 0, table, index1 * 10);
    }
    X25519Field.Add(numArray1, numArray1, numArray1);
    X25519Field.InvVar(numArray1, numArray1);
    int num = index1 - 1;
    int[] numArray2 = X25519Field.Create();
    while (num > 0)
    {
      int index2 = num--;
      X25519Field.Copy(table, num * 10, numArray2, 0);
      X25519Field.Mul(numArray2, numArray1, numArray2);
      X25519Field.Mul(numArray1, points[index2].z, numArray1);
      X25519Field.Copy(numArray2, 0, points[index2].z, 0);
    }
    X25519Field.Copy(numArray1, 0, points[0].z, 0);
  }

  private static bool IsNeutralElementVar(int[] x, int[] y, int[] z)
  {
    return X25519Field.IsZeroVar(x) && X25519Field.AreEqualVar(y, z);
  }

  private static void NormalizeToAffine(ref Ed25519.PointAccum p, ref Ed25519.PointAffine r)
  {
    X25519Field.Inv(p.z, r.y);
    X25519Field.Mul(r.y, p.x, r.x);
    X25519Field.Mul(r.y, p.y, r.y);
    X25519Field.Normalize(r.x);
    X25519Field.Normalize(r.y);
  }

  private static bool NormalizeToNeutralElementVar(ref Ed25519.PointAccum p)
  {
    X25519Field.Normalize(p.x);
    X25519Field.Normalize(p.y);
    X25519Field.Normalize(p.z);
    return Ed25519.IsNeutralElementVar(p.x, p.y, p.z);
  }

  private static void PointAdd(
    ref Ed25519.PointExtended p,
    ref Ed25519.PointExtended q,
    ref Ed25519.PointExtended r,
    ref Ed25519.PointTemp t)
  {
    int[] x = r.x;
    int[] y = r.y;
    int[] r0 = t.r0;
    int[] r1 = t.r1;
    int[] numArray1 = x;
    int[] numArray2 = r0;
    int[] numArray3 = r1;
    int[] numArray4 = y;
    X25519Field.Apm(p.y, p.x, y, x);
    X25519Field.Apm(q.y, q.x, r1, r0);
    X25519Field.Mul(x, r0, x);
    X25519Field.Mul(y, r1, y);
    X25519Field.Mul(p.t, q.t, r0);
    X25519Field.Mul(r0, Ed25519.C_d2, r0);
    X25519Field.Add(p.z, p.z, r1);
    X25519Field.Mul(r1, q.z, r1);
    X25519Field.Apm(y, x, numArray4, numArray1);
    X25519Field.Apm(r1, r0, numArray3, numArray2);
    X25519Field.Mul(numArray1, numArray4, r.t);
    X25519Field.Mul(numArray2, numArray3, r.z);
    X25519Field.Mul(numArray1, numArray2, r.x);
    X25519Field.Mul(numArray4, numArray3, r.y);
  }

  private static void PointAdd(
    ref Ed25519.PointPrecomp p,
    ref Ed25519.PointAccum r,
    ref Ed25519.PointTemp t)
  {
    int[] x = r.x;
    int[] y = r.y;
    int[] r0 = t.r0;
    int[] u = r.u;
    int[] numArray1 = x;
    int[] numArray2 = y;
    int[] v = r.v;
    X25519Field.Apm(r.y, r.x, y, x);
    X25519Field.Mul(x, p.ymx_h, x);
    X25519Field.Mul(y, p.ypx_h, y);
    X25519Field.Mul(r.u, r.v, r0);
    X25519Field.Mul(r0, p.xyd, r0);
    X25519Field.Apm(y, x, v, u);
    X25519Field.Apm(r.z, r0, numArray2, numArray1);
    X25519Field.Mul(numArray1, numArray2, r.z);
    X25519Field.Mul(numArray1, u, r.x);
    X25519Field.Mul(numArray2, v, r.y);
  }

  private static void PointAdd(
    ref Ed25519.PointPrecompZ p,
    ref Ed25519.PointAccum r,
    ref Ed25519.PointTemp t)
  {
    int[] x = r.x;
    int[] y = r.y;
    int[] r0 = t.r0;
    int[] z = r.z;
    int[] u = r.u;
    int[] numArray1 = x;
    int[] numArray2 = y;
    int[] v = r.v;
    X25519Field.Apm(r.y, r.x, y, x);
    X25519Field.Mul(x, p.ymx_h, x);
    X25519Field.Mul(y, p.ypx_h, y);
    X25519Field.Mul(r.u, r.v, r0);
    X25519Field.Mul(r0, p.xyd, r0);
    X25519Field.Mul(r.z, p.z, z);
    X25519Field.Apm(y, x, v, u);
    X25519Field.Apm(z, r0, numArray2, numArray1);
    X25519Field.Mul(numArray1, numArray2, r.z);
    X25519Field.Mul(numArray1, u, r.x);
    X25519Field.Mul(numArray2, v, r.y);
  }

  private static void PointAddVar(
    bool negate,
    ref Ed25519.PointPrecomp p,
    ref Ed25519.PointAccum r,
    ref Ed25519.PointTemp t)
  {
    int[] x1 = r.x;
    int[] y = r.y;
    int[] r0 = t.r0;
    int[] u = r.u;
    int[] x2 = x1;
    int[] numArray1 = y;
    int[] v = r.v;
    int[] numArray2;
    int[] numArray3;
    if (negate)
    {
      numArray2 = y;
      numArray3 = x1;
    }
    else
    {
      numArray2 = x1;
      numArray3 = y;
    }
    int[] zm = numArray2;
    int[] zp = numArray3;
    X25519Field.Apm(r.y, r.x, y, x1);
    X25519Field.Mul(numArray2, p.ymx_h, numArray2);
    X25519Field.Mul(numArray3, p.ypx_h, numArray3);
    X25519Field.Mul(r.u, r.v, r0);
    X25519Field.Mul(r0, p.xyd, r0);
    X25519Field.Apm(y, x1, v, u);
    X25519Field.Apm(r.z, r0, zp, zm);
    X25519Field.Mul(x2, numArray1, r.z);
    X25519Field.Mul(x2, u, r.x);
    X25519Field.Mul(numArray1, v, r.y);
  }

  private static void PointAddVar(
    bool negate,
    ref Ed25519.PointPrecompZ p,
    ref Ed25519.PointAccum r,
    ref Ed25519.PointTemp t)
  {
    int[] x1 = r.x;
    int[] y = r.y;
    int[] r0 = t.r0;
    int[] z = r.z;
    int[] u = r.u;
    int[] x2 = x1;
    int[] numArray1 = y;
    int[] v = r.v;
    int[] numArray2;
    int[] numArray3;
    if (negate)
    {
      numArray2 = y;
      numArray3 = x1;
    }
    else
    {
      numArray2 = x1;
      numArray3 = y;
    }
    int[] zm = numArray2;
    int[] zp = numArray3;
    X25519Field.Apm(r.y, r.x, y, x1);
    X25519Field.Mul(numArray2, p.ymx_h, numArray2);
    X25519Field.Mul(numArray3, p.ypx_h, numArray3);
    X25519Field.Mul(r.u, r.v, r0);
    X25519Field.Mul(r0, p.xyd, r0);
    X25519Field.Mul(r.z, p.z, z);
    X25519Field.Apm(y, x1, v, u);
    X25519Field.Apm(z, r0, zp, zm);
    X25519Field.Mul(x2, numArray1, r.z);
    X25519Field.Mul(x2, u, r.x);
    X25519Field.Mul(numArray1, v, r.y);
  }

  private static void PointCopy(ref Ed25519.PointAccum p, ref Ed25519.PointExtended r)
  {
    X25519Field.Copy(p.x, 0, r.x, 0);
    X25519Field.Copy(p.y, 0, r.y, 0);
    X25519Field.Copy(p.z, 0, r.z, 0);
    X25519Field.Mul(p.u, p.v, r.t);
  }

  private static void PointCopy(ref Ed25519.PointAffine p, ref Ed25519.PointExtended r)
  {
    X25519Field.Copy(p.x, 0, r.x, 0);
    X25519Field.Copy(p.y, 0, r.y, 0);
    X25519Field.One(r.z);
    X25519Field.Mul(p.x, p.y, r.t);
  }

  private static void PointCopy(ref Ed25519.PointExtended p, ref Ed25519.PointPrecompZ r)
  {
    X25519Field.Apm(p.y, p.x, r.ypx_h, r.ymx_h);
    X25519Field.Mul(p.t, Ed25519.C_d2, r.xyd);
    X25519Field.Add(p.z, p.z, r.z);
  }

  private static void PointDouble(ref Ed25519.PointAccum r)
  {
    int[] x = r.x;
    int[] y = r.y;
    int[] z = r.z;
    int[] u = r.u;
    int[] numArray1 = x;
    int[] numArray2 = y;
    int[] v = r.v;
    X25519Field.Add(r.x, r.y, u);
    X25519Field.Sqr(r.x, x);
    X25519Field.Sqr(r.y, y);
    X25519Field.Sqr(r.z, z);
    X25519Field.Add(z, z, z);
    X25519Field.Apm(x, y, v, numArray2);
    X25519Field.Sqr(u, u);
    X25519Field.Sub(v, u, u);
    X25519Field.Add(z, numArray2, numArray1);
    X25519Field.Carry(numArray1);
    X25519Field.Mul(numArray1, numArray2, r.z);
    X25519Field.Mul(numArray1, u, r.x);
    X25519Field.Mul(numArray2, v, r.y);
  }

  private static void PointLookup(int block, int index, ref Ed25519.PointPrecomp p)
  {
    int xOff1 = block * 8 * 3 * 10;
    for (int index1 = 0; index1 < 8; ++index1)
    {
      int cond = (index1 ^ index) - 1 >> 31 /*0x1F*/;
      X25519Field.CMov(cond, Ed25519.PrecompBaseComb, xOff1, p.ymx_h, 0);
      int xOff2 = xOff1 + 10;
      X25519Field.CMov(cond, Ed25519.PrecompBaseComb, xOff2, p.ypx_h, 0);
      int xOff3 = xOff2 + 10;
      X25519Field.CMov(cond, Ed25519.PrecompBaseComb, xOff3, p.xyd, 0);
      xOff1 = xOff3 + 10;
    }
  }

  private static void PointLookupZ(uint[] x, int n, int[] table, ref Ed25519.PointPrecompZ r)
  {
    int window4 = (int) Ed25519.GetWindow4(x, n);
    int num1 = window4 >>> 3 ^ 1;
    int num2 = (window4 ^ -num1) & 7;
    int num3 = 0;
    int xOff1 = 0;
    for (; num3 < 8; ++num3)
    {
      int cond = (num3 ^ num2) - 1 >> 31 /*0x1F*/;
      X25519Field.CMov(cond, table, xOff1, r.ymx_h, 0);
      int xOff2 = xOff1 + 10;
      X25519Field.CMov(cond, table, xOff2, r.ypx_h, 0);
      int xOff3 = xOff2 + 10;
      X25519Field.CMov(cond, table, xOff3, r.xyd, 0);
      int xOff4 = xOff3 + 10;
      X25519Field.CMov(cond, table, xOff4, r.z, 0);
      xOff1 = xOff4 + 10;
    }
    X25519Field.CSwap(num1, r.ymx_h, r.ypx_h);
    X25519Field.CNegate(num1, r.xyd);
  }

  private static void PointPrecompute(
    ref Ed25519.PointAffine p,
    Ed25519.PointExtended[] points,
    int pointsOff,
    int pointsLen,
    ref Ed25519.PointTemp t)
  {
    Ed25519.Init(out points[pointsOff]);
    Ed25519.PointCopy(ref p, ref points[pointsOff]);
    Ed25519.PointExtended r;
    Ed25519.Init(out r);
    Ed25519.PointAdd(ref points[pointsOff], ref points[pointsOff], ref r, ref t);
    for (int index = 1; index < pointsLen; ++index)
    {
      Ed25519.Init(out points[pointsOff + index]);
      Ed25519.PointAdd(ref points[pointsOff + index - 1], ref r, ref points[pointsOff + index], ref t);
    }
  }

  private static int[] PointPrecomputeZ(
    ref Ed25519.PointAffine p,
    int count,
    ref Ed25519.PointTemp t)
  {
    Ed25519.PointExtended r1;
    Ed25519.Init(out r1);
    Ed25519.PointCopy(ref p, ref r1);
    Ed25519.PointExtended r2;
    Ed25519.Init(out r2);
    Ed25519.PointAdd(ref r1, ref r1, ref r2, ref t);
    Ed25519.PointPrecompZ r3;
    Ed25519.Init(out r3);
    int[] table = X25519Field.CreateTable(count * 4);
    int zOff1 = 0;
    int num = 0;
    while (true)
    {
      Ed25519.PointCopy(ref r1, ref r3);
      X25519Field.Copy(r3.ymx_h, 0, table, zOff1);
      int zOff2 = zOff1 + 10;
      X25519Field.Copy(r3.ypx_h, 0, table, zOff2);
      int zOff3 = zOff2 + 10;
      X25519Field.Copy(r3.xyd, 0, table, zOff3);
      int zOff4 = zOff3 + 10;
      X25519Field.Copy(r3.z, 0, table, zOff4);
      zOff1 = zOff4 + 10;
      if (++num != count)
        Ed25519.PointAdd(ref r1, ref r2, ref r1, ref t);
      else
        break;
    }
    return table;
  }

  private static void PointPrecomputeZ(
    ref Ed25519.PointAffine p,
    Ed25519.PointPrecompZ[] points,
    int count,
    ref Ed25519.PointTemp t)
  {
    Ed25519.PointExtended r1;
    Ed25519.Init(out r1);
    Ed25519.PointCopy(ref p, ref r1);
    Ed25519.PointExtended r2;
    Ed25519.Init(out r2);
    Ed25519.PointAdd(ref r1, ref r1, ref r2, ref t);
    int index = 0;
    while (true)
    {
      ref Ed25519.PointPrecompZ local = ref points[index];
      Ed25519.Init(out local);
      Ed25519.PointCopy(ref r1, ref local);
      if (++index != count)
        Ed25519.PointAdd(ref r1, ref r2, ref r1, ref t);
      else
        break;
    }
  }

  private static void PointSetNeutral(ref Ed25519.PointAccum p)
  {
    X25519Field.Zero(p.x);
    X25519Field.One(p.y);
    X25519Field.One(p.z);
    X25519Field.Zero(p.u);
    X25519Field.One(p.v);
  }

  public static void Precompute()
  {
    lock (Ed25519.PrecompLock)
    {
      if (Ed25519.PrecompBaseComb != null)
        return;
      int length = 16 /*0x10*/;
      int num1 = 64 /*0x40*/;
      int num2 = 96 /*0x60*/;
      Ed25519.PointExtended[] points = new Ed25519.PointExtended[96 /*0x60*/];
      Ed25519.PointTemp r1;
      Ed25519.Init(out r1);
      Ed25519.PointAffine r2;
      Ed25519.Init(out r2);
      X25519Field.Copy(Ed25519.B_x, 0, r2.x, 0);
      X25519Field.Copy(Ed25519.B_y, 0, r2.y, 0);
      Ed25519.PointPrecompute(ref r2, points, 0, 16 /*0x10*/, ref r1);
      Ed25519.PointAffine r3;
      Ed25519.Init(out r3);
      X25519Field.Copy(Ed25519.B128_x, 0, r3.x, 0);
      X25519Field.Copy(Ed25519.B128_y, 0, r3.y, 0);
      Ed25519.PointPrecompute(ref r3, points, 16 /*0x10*/, 16 /*0x10*/, ref r1);
      Ed25519.PointAccum r4;
      Ed25519.Init(out r4);
      X25519Field.Copy(Ed25519.B_x, 0, r4.x, 0);
      X25519Field.Copy(Ed25519.B_y, 0, r4.y, 0);
      X25519Field.One(r4.z);
      X25519Field.Copy(Ed25519.B_x, 0, r4.u, 0);
      X25519Field.Copy(Ed25519.B_y, 0, r4.v, 0);
      int index1 = 32 /*0x20*/;
      Ed25519.PointExtended[] pointExtendedArray = new Ed25519.PointExtended[4];
      for (int index2 = 0; index2 < 4; ++index2)
        Ed25519.Init(out pointExtendedArray[index2]);
      Ed25519.PointExtended r5;
      Ed25519.Init(out r5);
      for (int index3 = 0; index3 < 8; ++index3)
      {
        ref Ed25519.PointExtended local = ref points[index1++];
        Ed25519.Init(out local);
        for (int index4 = 0; index4 < 4; ++index4)
        {
          if (index4 == 0)
          {
            Ed25519.PointCopy(ref r4, ref local);
          }
          else
          {
            Ed25519.PointCopy(ref r4, ref r5);
            Ed25519.PointAdd(ref local, ref r5, ref local, ref r1);
          }
          Ed25519.PointDouble(ref r4);
          Ed25519.PointCopy(ref r4, ref pointExtendedArray[index4]);
          if (index3 + index4 != 10)
          {
            for (int index5 = 1; index5 < 8; ++index5)
              Ed25519.PointDouble(ref r4);
          }
        }
        X25519Field.Negate(local.x, local.x);
        X25519Field.Negate(local.t, local.t);
        for (int index6 = 0; index6 < 3; ++index6)
        {
          int num3 = 1 << index6;
          int num4 = 0;
          while (num4 < num3)
          {
            Ed25519.Init(out points[index1]);
            Ed25519.PointAdd(ref points[index1 - num3], ref pointExtendedArray[index6], ref points[index1], ref r1);
            ++num4;
            ++index1;
          }
        }
      }
      Ed25519.InvertDoubleZs(points);
      Ed25519.PrecompBaseWnaf = new Ed25519.PointPrecomp[length];
      for (int index7 = 0; index7 < length; ++index7)
      {
        ref Ed25519.PointExtended local1 = ref points[index7];
        ref Ed25519.PointPrecomp local2 = ref Ed25519.PrecompBaseWnaf[index7];
        Ed25519.Init(out local2);
        X25519Field.Mul(local1.x, local1.z, local1.x);
        X25519Field.Mul(local1.y, local1.z, local1.y);
        X25519Field.Apm(local1.y, local1.x, local2.ypx_h, local2.ymx_h);
        X25519Field.Mul(local1.x, local1.y, local2.xyd);
        X25519Field.Mul(local2.xyd, Ed25519.C_d4, local2.xyd);
        X25519Field.Normalize(local2.ymx_h);
        X25519Field.Normalize(local2.ypx_h);
        X25519Field.Normalize(local2.xyd);
      }
      Ed25519.PrecompBase128Wnaf = new Ed25519.PointPrecomp[length];
      for (int index8 = 0; index8 < length; ++index8)
      {
        ref Ed25519.PointExtended local3 = ref points[length + index8];
        ref Ed25519.PointPrecomp local4 = ref Ed25519.PrecompBase128Wnaf[index8];
        Ed25519.Init(out local4);
        X25519Field.Mul(local3.x, local3.z, local3.x);
        X25519Field.Mul(local3.y, local3.z, local3.y);
        X25519Field.Apm(local3.y, local3.x, local4.ypx_h, local4.ymx_h);
        X25519Field.Mul(local3.x, local3.y, local4.xyd);
        X25519Field.Mul(local4.xyd, Ed25519.C_d4, local4.xyd);
        X25519Field.Normalize(local4.ymx_h);
        X25519Field.Normalize(local4.ypx_h);
        X25519Field.Normalize(local4.xyd);
      }
      Ed25519.PrecompBaseComb = X25519Field.CreateTable(num1 * 3);
      Ed25519.PointPrecomp r6;
      Ed25519.Init(out r6);
      int zOff1 = 0;
      for (int index9 = length * 2; index9 < num2; ++index9)
      {
        ref Ed25519.PointExtended local = ref points[index9];
        X25519Field.Mul(local.x, local.z, local.x);
        X25519Field.Mul(local.y, local.z, local.y);
        X25519Field.Apm(local.y, local.x, r6.ypx_h, r6.ymx_h);
        X25519Field.Mul(local.x, local.y, r6.xyd);
        X25519Field.Mul(r6.xyd, Ed25519.C_d4, r6.xyd);
        X25519Field.Normalize(r6.ymx_h);
        X25519Field.Normalize(r6.ypx_h);
        X25519Field.Normalize(r6.xyd);
        X25519Field.Copy(r6.ymx_h, 0, Ed25519.PrecompBaseComb, zOff1);
        int zOff2 = zOff1 + 10;
        X25519Field.Copy(r6.ypx_h, 0, Ed25519.PrecompBaseComb, zOff2);
        int zOff3 = zOff2 + 10;
        X25519Field.Copy(r6.xyd, 0, Ed25519.PrecompBaseComb, zOff3);
        zOff1 = zOff3 + 10;
      }
    }
  }

  private static void PruneScalar(byte[] n, int nOff, byte[] r)
  {
    Array.Copy((Array) n, nOff, (Array) r, 0, 32 /*0x20*/);
    r[0] &= (byte) 248;
    r[31 /*0x1F*/] &= (byte) 127 /*0x7F*/;
    r[31 /*0x1F*/] |= (byte) 64 /*0x40*/;
  }

  private static void ScalarMult(byte[] k, ref Ed25519.PointAffine p, ref Ed25519.PointAccum r)
  {
    uint[] numArray = new uint[8];
    Scalar25519.Decode(k, numArray);
    Scalar25519.ToSignedDigits(256 /*0x0100*/, numArray, numArray);
    Ed25519.PointPrecompZ r1;
    Ed25519.Init(out r1);
    Ed25519.PointTemp r2;
    Ed25519.Init(out r2);
    int[] table = Ed25519.PointPrecomputeZ(ref p, 8, ref r2);
    Ed25519.PointSetNeutral(ref r);
    int n = 63 /*0x3F*/;
label_4:
    Ed25519.PointLookupZ(numArray, n, table, ref r1);
    Ed25519.PointAdd(ref r1, ref r, ref r2);
    if (--n < 0)
      return;
    for (int index = 0; index < 4; ++index)
      Ed25519.PointDouble(ref r);
    goto label_4;
  }

  private static void ScalarMultBase(byte[] k, ref Ed25519.PointAccum r)
  {
    Ed25519.Precompute();
    uint[] numArray = new uint[8];
    Scalar25519.Decode(k, numArray);
    Scalar25519.ToSignedDigits(256 /*0x0100*/, numArray, numArray);
    Ed25519.GroupCombBits(numArray);
    Ed25519.PointPrecomp r1;
    Ed25519.Init(out r1);
    Ed25519.PointTemp r2;
    Ed25519.Init(out r2);
    Ed25519.PointSetNeutral(ref r);
    int negate = 0;
    int num1 = 28;
    while (true)
    {
      for (int block = 0; block < 8; ++block)
      {
        int num2 = (int) (numArray[block] >> num1);
        int num3 = num2 >>> 3 & 1;
        int index = (num2 ^ -num3) & 7;
        Ed25519.PointLookup(block, index, ref r1);
        X25519Field.CNegate(negate ^ num3, r.x);
        X25519Field.CNegate(negate ^ num3, r.u);
        negate = num3;
        Ed25519.PointAdd(ref r1, ref r, ref r2);
      }
      if ((num1 -= 4) >= 0)
        Ed25519.PointDouble(ref r);
      else
        break;
    }
    X25519Field.CNegate(negate, r.x);
    X25519Field.CNegate(negate, r.u);
  }

  private static void ScalarMultBaseEncoded(byte[] k, byte[] r, int rOff)
  {
    Ed25519.PointAccum r1;
    Ed25519.Init(out r1);
    Ed25519.ScalarMultBase(k, ref r1);
    if (Ed25519.EncodeResult(ref r1, r, rOff) == 0)
      throw new InvalidOperationException();
  }

  internal static void ScalarMultBaseYZ(byte[] k, int kOff, int[] y, int[] z)
  {
    byte[] numArray = new byte[32 /*0x20*/];
    Ed25519.PruneScalar(k, kOff, numArray);
    Ed25519.PointAccum r;
    Ed25519.Init(out r);
    Ed25519.ScalarMultBase(numArray, ref r);
    if (Ed25519.CheckPoint(r) == 0)
      throw new InvalidOperationException();
    X25519Field.Copy(r.y, 0, y, 0);
    X25519Field.Copy(r.z, 0, z, 0);
  }

  private static void ScalarMultOrderVar(ref Ed25519.PointAffine p, ref Ed25519.PointAccum r)
  {
    sbyte[] ws = new sbyte[253];
    Scalar25519.GetOrderWnafVar(4, ws);
    Ed25519.PointPrecompZ[] points = new Ed25519.PointPrecompZ[4];
    Ed25519.PointTemp r1;
    Ed25519.Init(out r1);
    Ed25519.PointPrecomputeZ(ref p, points, 4, ref r1);
    Ed25519.PointSetNeutral(ref r);
    int index1 = 252;
    while (true)
    {
      int num = (int) ws[index1];
      if (num != 0)
        goto label_3;
label_1:
      if (--index1 >= 0)
      {
        Ed25519.PointDouble(ref r);
        continue;
      }
      break;
label_3:
      int index2 = num >> 1 ^ num >> 31 /*0x1F*/;
      Ed25519.PointAddVar(num < 0, ref points[index2], ref r, ref r1);
      goto label_1;
    }
  }

  private static void ScalarMultStraus128Var(
    uint[] nb,
    uint[] np,
    ref Ed25519.PointAffine p,
    uint[] nq,
    ref Ed25519.PointAffine q,
    ref Ed25519.PointAccum r)
  {
    Ed25519.Precompute();
    sbyte[] ws1 = new sbyte[256 /*0x0100*/];
    sbyte[] ws2 = new sbyte[128 /*0x80*/];
    sbyte[] ws3 = new sbyte[128 /*0x80*/];
    Wnaf.GetSignedVar(nb, 6, ws1);
    Wnaf.GetSignedVar(np, 4, ws2);
    Wnaf.GetSignedVar(nq, 4, ws3);
    Ed25519.PointPrecompZ[] points1 = new Ed25519.PointPrecompZ[4];
    Ed25519.PointPrecompZ[] points2 = new Ed25519.PointPrecompZ[4];
    Ed25519.PointTemp r1;
    Ed25519.Init(out r1);
    Ed25519.PointPrecomputeZ(ref p, points1, 4, ref r1);
    Ed25519.PointPrecomputeZ(ref q, points2, 4, ref r1);
    Ed25519.PointSetNeutral(ref r);
    int index1 = 128 /*0x80*/;
    while (--index1 >= 0)
    {
      int num1 = (int) ws1[index1];
      if (num1 != 0)
      {
        int index2 = num1 >> 1 ^ num1 >> 31 /*0x1F*/;
        Ed25519.PointAddVar(num1 < 0, ref Ed25519.PrecompBaseWnaf[index2], ref r, ref r1);
      }
      int num2 = (int) ws1[128 /*0x80*/ + index1];
      if (num2 != 0)
      {
        int index3 = num2 >> 1 ^ num2 >> 31 /*0x1F*/;
        Ed25519.PointAddVar(num2 < 0, ref Ed25519.PrecompBase128Wnaf[index3], ref r, ref r1);
      }
      int num3 = (int) ws2[index1];
      if (num3 != 0)
      {
        int index4 = num3 >> 1 ^ num3 >> 31 /*0x1F*/;
        Ed25519.PointAddVar(num3 < 0, ref points1[index4], ref r, ref r1);
      }
      int num4 = (int) ws3[index1];
      if (num4 != 0)
      {
        int index5 = num4 >> 1 ^ num4 >> 31 /*0x1F*/;
        Ed25519.PointAddVar(num4 < 0, ref points2[index5], ref r, ref r1);
      }
      Ed25519.PointDouble(ref r);
    }
    Ed25519.PointDouble(ref r);
    Ed25519.PointDouble(ref r);
  }

  public static void Sign(
    byte[] sk,
    int skOff,
    byte[] m,
    int mOff,
    int mLen,
    byte[] sig,
    int sigOff)
  {
    byte[] ctx = (byte[]) null;
    Ed25519.ImplSign(sk, skOff, ctx, (byte) 0, m, mOff, mLen, sig, sigOff);
  }

  public static void Sign(
    byte[] sk,
    int skOff,
    byte[] pk,
    int pkOff,
    byte[] m,
    int mOff,
    int mLen,
    byte[] sig,
    int sigOff)
  {
    byte[] ctx = (byte[]) null;
    Ed25519.ImplSign(sk, skOff, pk, pkOff, ctx, (byte) 0, m, mOff, mLen, sig, sigOff);
  }

  public static void Sign(
    byte[] sk,
    int skOff,
    byte[] ctx,
    byte[] m,
    int mOff,
    int mLen,
    byte[] sig,
    int sigOff)
  {
    Ed25519.ImplSign(sk, skOff, ctx, (byte) 0, m, mOff, mLen, sig, sigOff);
  }

  public static void Sign(
    byte[] sk,
    int skOff,
    byte[] pk,
    int pkOff,
    byte[] ctx,
    byte[] m,
    int mOff,
    int mLen,
    byte[] sig,
    int sigOff)
  {
    Ed25519.ImplSign(sk, skOff, pk, pkOff, ctx, (byte) 0, m, mOff, mLen, sig, sigOff);
  }

  public static void SignPrehash(
    byte[] sk,
    int skOff,
    byte[] ctx,
    byte[] ph,
    int phOff,
    byte[] sig,
    int sigOff)
  {
    Ed25519.ImplSign(sk, skOff, ctx, (byte) 1, ph, phOff, Ed25519.PrehashSize, sig, sigOff);
  }

  public static void SignPrehash(
    byte[] sk,
    int skOff,
    byte[] pk,
    int pkOff,
    byte[] ctx,
    byte[] ph,
    int phOff,
    byte[] sig,
    int sigOff)
  {
    Ed25519.ImplSign(sk, skOff, pk, pkOff, ctx, (byte) 1, ph, phOff, Ed25519.PrehashSize, sig, sigOff);
  }

  public static void SignPrehash(
    byte[] sk,
    int skOff,
    byte[] ctx,
    IDigest ph,
    byte[] sig,
    int sigOff)
  {
    byte[] numArray = new byte[Ed25519.PrehashSize];
    if (Ed25519.PrehashSize != ph.DoFinal(numArray, 0))
      throw new ArgumentException(nameof (ph));
    Ed25519.ImplSign(sk, skOff, ctx, (byte) 1, numArray, 0, numArray.Length, sig, sigOff);
  }

  public static void SignPrehash(
    byte[] sk,
    int skOff,
    byte[] pk,
    int pkOff,
    byte[] ctx,
    IDigest ph,
    byte[] sig,
    int sigOff)
  {
    byte[] numArray = new byte[Ed25519.PrehashSize];
    if (Ed25519.PrehashSize != ph.DoFinal(numArray, 0))
      throw new ArgumentException(nameof (ph));
    Ed25519.ImplSign(sk, skOff, pk, pkOff, ctx, (byte) 1, numArray, 0, numArray.Length, sig, sigOff);
  }

  public static bool ValidatePublicKeyFull(byte[] pk, int pkOff)
  {
    byte[] p = Ed25519.Copy(pk, pkOff, Ed25519.PublicKeySize);
    if (!Ed25519.CheckPointFullVar(p))
      return false;
    Ed25519.PointAffine r;
    Ed25519.Init(out r);
    return Ed25519.DecodePointVar(p, false, ref r) && Ed25519.CheckPointOrderVar(ref r);
  }

  public static Ed25519.PublicPoint ValidatePublicKeyFullExport(byte[] pk, int pkOff)
  {
    byte[] p = Ed25519.Copy(pk, pkOff, Ed25519.PublicKeySize);
    if (!Ed25519.CheckPointFullVar(p))
      return (Ed25519.PublicPoint) null;
    Ed25519.PointAffine r;
    Ed25519.Init(out r);
    if (!Ed25519.DecodePointVar(p, false, ref r))
      return (Ed25519.PublicPoint) null;
    return !Ed25519.CheckPointOrderVar(ref r) ? (Ed25519.PublicPoint) null : Ed25519.ExportPoint(ref r);
  }

  public static bool ValidatePublicKeyPartial(byte[] pk, int pkOff)
  {
    byte[] p = Ed25519.Copy(pk, pkOff, Ed25519.PublicKeySize);
    if (!Ed25519.CheckPointFullVar(p))
      return false;
    Ed25519.PointAffine r;
    Ed25519.Init(out r);
    return Ed25519.DecodePointVar(p, false, ref r);
  }

  public static Ed25519.PublicPoint ValidatePublicKeyPartialExport(byte[] pk, int pkOff)
  {
    byte[] p = Ed25519.Copy(pk, pkOff, Ed25519.PublicKeySize);
    if (!Ed25519.CheckPointFullVar(p))
      return (Ed25519.PublicPoint) null;
    Ed25519.PointAffine r;
    Ed25519.Init(out r);
    return !Ed25519.DecodePointVar(p, false, ref r) ? (Ed25519.PublicPoint) null : Ed25519.ExportPoint(ref r);
  }

  public static bool Verify(
    byte[] sig,
    int sigOff,
    byte[] pk,
    int pkOff,
    byte[] m,
    int mOff,
    int mLen)
  {
    byte[] ctx = (byte[]) null;
    return Ed25519.ImplVerify(sig, sigOff, pk, pkOff, ctx, (byte) 0, m, mOff, mLen);
  }

  public static bool Verify(
    byte[] sig,
    int sigOff,
    Ed25519.PublicPoint publicPoint,
    byte[] m,
    int mOff,
    int mLen)
  {
    byte[] ctx = (byte[]) null;
    return Ed25519.ImplVerify(sig, sigOff, publicPoint, ctx, (byte) 0, m, mOff, mLen);
  }

  public static bool Verify(
    byte[] sig,
    int sigOff,
    byte[] pk,
    int pkOff,
    byte[] ctx,
    byte[] m,
    int mOff,
    int mLen)
  {
    return Ed25519.ImplVerify(sig, sigOff, pk, pkOff, ctx, (byte) 0, m, mOff, mLen);
  }

  public static bool Verify(
    byte[] sig,
    int sigOff,
    Ed25519.PublicPoint publicPoint,
    byte[] ctx,
    byte[] m,
    int mOff,
    int mLen)
  {
    return Ed25519.ImplVerify(sig, sigOff, publicPoint, ctx, (byte) 0, m, mOff, mLen);
  }

  public static bool VerifyPrehash(
    byte[] sig,
    int sigOff,
    byte[] pk,
    int pkOff,
    byte[] ctx,
    byte[] ph,
    int phOff)
  {
    return Ed25519.ImplVerify(sig, sigOff, pk, pkOff, ctx, (byte) 1, ph, phOff, Ed25519.PrehashSize);
  }

  public static bool VerifyPrehash(
    byte[] sig,
    int sigOff,
    Ed25519.PublicPoint publicPoint,
    byte[] ctx,
    byte[] ph,
    int phOff)
  {
    return Ed25519.ImplVerify(sig, sigOff, publicPoint, ctx, (byte) 1, ph, phOff, Ed25519.PrehashSize);
  }

  public static bool VerifyPrehash(
    byte[] sig,
    int sigOff,
    byte[] pk,
    int pkOff,
    byte[] ctx,
    IDigest ph)
  {
    byte[] numArray = new byte[Ed25519.PrehashSize];
    if (Ed25519.PrehashSize != ph.DoFinal(numArray, 0))
      throw new ArgumentException(nameof (ph));
    return Ed25519.ImplVerify(sig, sigOff, pk, pkOff, ctx, (byte) 1, numArray, 0, numArray.Length);
  }

  public static bool VerifyPrehash(
    byte[] sig,
    int sigOff,
    Ed25519.PublicPoint publicPoint,
    byte[] ctx,
    IDigest ph)
  {
    byte[] numArray = new byte[Ed25519.PrehashSize];
    if (Ed25519.PrehashSize != ph.DoFinal(numArray, 0))
      throw new ArgumentException(nameof (ph));
    return Ed25519.ImplVerify(sig, sigOff, publicPoint, ctx, (byte) 1, numArray, 0, numArray.Length);
  }

  public enum Algorithm
  {
    Ed25519,
    Ed25519ctx,
    Ed25519ph,
  }

  public sealed class PublicPoint
  {
    internal readonly int[] m_data;

    internal PublicPoint(int[] data) => this.m_data = data;
  }

  private struct PointAccum
  {
    internal int[] x;
    internal int[] y;
    internal int[] z;
    internal int[] u;
    internal int[] v;
  }

  private struct PointAffine
  {
    internal int[] x;
    internal int[] y;
  }

  private struct PointExtended
  {
    internal int[] x;
    internal int[] y;
    internal int[] z;
    internal int[] t;
  }

  private struct PointPrecomp
  {
    internal int[] ymx_h;
    internal int[] ypx_h;
    internal int[] xyd;
  }

  private struct PointPrecompZ
  {
    internal int[] ymx_h;
    internal int[] ypx_h;
    internal int[] xyd;
    internal int[] z;
  }

  private struct PointTemp
  {
    internal int[] r0;
    internal int[] r1;
  }
}
