// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Rfc8032.Ed448
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

public static class Ed448
{
  private const int CoordUints = 14;
  private const int PointBytes = 57;
  private const int ScalarUints = 14;
  private const int ScalarBytes = 57;
  public static readonly int PrehashSize = 64 /*0x40*/;
  public static readonly int PublicKeySize = 57;
  public static readonly int SecretKeySize = 57;
  public static readonly int SignatureSize = 114;
  private static readonly byte[] Dom4Prefix = new byte[8]
  {
    (byte) 83,
    (byte) 105,
    (byte) 103,
    (byte) 69,
    (byte) 100,
    (byte) 52,
    (byte) 52,
    (byte) 56
  };
  private static readonly uint[] P = new uint[14]
  {
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    4294967294U,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue
  };
  private static readonly uint[] B_x = new uint[16 /*0x10*/]
  {
    118276190U,
    40534716U,
    9670182U,
    135141552U,
    85017403U,
    259173222U,
    68333082U,
    171784774U,
    174973732U,
    15824510U,
    73756743U,
    57518561U,
    94773951U,
    248652241U,
    107736333U,
    82941708U
  };
  private static readonly uint[] B_y = new uint[16 /*0x10*/]
  {
    36764180U,
    8885695U,
    130592152U,
    20104429U,
    163904957U,
    30304195U,
    121295871U,
    5901357U,
    125344798U,
    171541512U,
    175338348U,
    209069246U,
    3626697U,
    38307682U,
    24032956U,
    110359655U
  };
  private static readonly uint[] B225_x = new uint[16 /*0x10*/]
  {
    110141154U,
    30892124U,
    160820362U,
    264558960U,
    217232225U,
    47722141U,
    19029845U,
    8326902U,
    183409749U,
    170134547U,
    90340180U,
    222600478U,
    61097333U,
    7431335U,
    198491505U,
    102372861U
  };
  private static readonly uint[] B225_y = new uint[16 /*0x10*/]
  {
    221945828U,
    50763449U,
    132637478U,
    109250759U,
    216053960U,
    61612587U,
    50649998U,
    138339097U,
    98949899U,
    248139835U,
    186410297U,
    126520782U,
    47339196U,
    78164062U,
    198835543U,
    169622712U
  };
  private const int C_d = -39081;
  private const int WnafWidth225 = 5;
  private const int WnafWidthBase = 7;
  private const int PrecompBlocks = 5;
  private const int PrecompTeeth = 5;
  private const int PrecompSpacing = 18;
  private const int PrecompRange = 450;
  private const int PrecompPoints = 16 /*0x10*/;
  private const int PrecompMask = 15;
  private static readonly object PrecompLock = new object();
  private static Ed448.PointAffine[] PrecompBaseWnaf = (Ed448.PointAffine[]) null;
  private static Ed448.PointAffine[] PrecompBase225Wnaf = (Ed448.PointAffine[]) null;
  private static uint[] PrecompBaseComb = (uint[]) null;

  private static byte[] CalculateS(byte[] r, byte[] k, byte[] s)
  {
    uint[] numArray1 = new uint[28];
    Scalar448.Decode(r, numArray1);
    uint[] numArray2 = new uint[14];
    Scalar448.Decode(k, numArray2);
    uint[] numArray3 = new uint[14];
    Scalar448.Decode(s, numArray3);
    int num = (int) Nat.MulAddTo(14, numArray2, numArray3, numArray1);
    byte[] numArray4 = new byte[114];
    Codec.Encode32(numArray1, 0, numArray1.Length, numArray4, 0);
    return Scalar448.Reduce(numArray4);
  }

  private static bool CheckContextVar(byte[] ctx) => ctx != null && ctx.Length < 256 /*0x0100*/;

  private static int CheckPoint(ref Ed448.PointAffine p)
  {
    uint[] numArray1 = X448Field.Create();
    uint[] numArray2 = X448Field.Create();
    uint[] numArray3 = X448Field.Create();
    X448Field.Sqr(p.x, numArray2);
    X448Field.Sqr(p.y, numArray3);
    X448Field.Mul(numArray2, numArray3, numArray1);
    X448Field.Add(numArray2, numArray3, numArray2);
    X448Field.Mul(numArray1, 39081U, numArray1);
    X448Field.SubOne(numArray1);
    X448Field.Add(numArray1, numArray2, numArray1);
    X448Field.Normalize(numArray1);
    return X448Field.IsZero(numArray1);
  }

  private static int CheckPoint(Ed448.PointProjective p)
  {
    uint[] numArray1 = X448Field.Create();
    uint[] numArray2 = X448Field.Create();
    uint[] numArray3 = X448Field.Create();
    uint[] numArray4 = X448Field.Create();
    X448Field.Sqr(p.x, numArray2);
    X448Field.Sqr(p.y, numArray3);
    X448Field.Sqr(p.z, numArray4);
    X448Field.Mul(numArray2, numArray3, numArray1);
    X448Field.Add(numArray2, numArray3, numArray2);
    X448Field.Mul(numArray2, numArray4, numArray2);
    X448Field.Sqr(numArray4, numArray4);
    X448Field.Mul(numArray1, 39081U, numArray1);
    X448Field.Sub(numArray1, numArray4, numArray1);
    X448Field.Add(numArray1, numArray2, numArray1);
    X448Field.Normalize(numArray1);
    return X448Field.IsZero(numArray1);
  }

  private static bool CheckPointFullVar(byte[] p)
  {
    if (((int) p[56] & (int) sbyte.MaxValue) != 0)
      return false;
    uint num1;
    uint num2 = (num1 = Codec.Decode32(p, 52)) ^ Ed448.P[13];
    for (int index = 12; index > 0; --index)
    {
      uint num3 = Codec.Decode32(p, index * 4);
      if (num2 == 0U && num3 > Ed448.P[index])
        return false;
      num1 |= num3;
      num2 |= num3 ^ Ed448.P[index];
    }
    uint num4 = Codec.Decode32(p, 0);
    return (num1 != 0U || num4 > 1U) && (num2 != 0U || num4 < Ed448.P[0] - 1U);
  }

  private static bool CheckPointOrderVar(ref Ed448.PointAffine p)
  {
    Ed448.PointProjective r;
    Ed448.Init(out r);
    Ed448.ScalarMultOrderVar(ref p, ref r);
    return Ed448.NormalizeToNeutralElementVar(ref r);
  }

  private static bool CheckPointVar(byte[] p)
  {
    if (((int) p[56] & (int) sbyte.MaxValue) != 0)
      return false;
    if (Codec.Decode32(p, 52) < Ed448.P[13])
      return true;
    int num = p[28] == byte.MaxValue ? 7 : 0;
    for (int index = 12; index >= num; --index)
    {
      if (Codec.Decode32(p, index * 4) < Ed448.P[index])
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

  public static IXof CreatePrehash() => Ed448.CreateXof();

  private static IXof CreateXof() => (IXof) new ShakeDigest(256 /*0x0100*/);

  private static bool DecodePointVar(byte[] p, bool negate, ref Ed448.PointAffine r)
  {
    int num = ((int) p[56] & 128 /*0x80*/) >> 7;
    X448Field.Decode(p, r.y);
    uint[] numArray1 = X448Field.Create();
    uint[] numArray2 = X448Field.Create();
    X448Field.Sqr(r.y, numArray1);
    X448Field.Mul(numArray1, 39081U, numArray2);
    X448Field.Negate(numArray1, numArray1);
    X448Field.AddOne(numArray1);
    X448Field.AddOne(numArray2);
    if (!X448Field.SqrtRatioVar(numArray1, numArray2, r.x))
      return false;
    X448Field.Normalize(r.x);
    if (num == 1 && X448Field.IsZeroVar(r.x))
      return false;
    if (negate ^ (long) num != (long) (r.x[0] & 1U))
    {
      X448Field.Negate(r.x, r.x);
      X448Field.Normalize(r.x);
    }
    return true;
  }

  private static void Dom4(IXof d, byte phflag, byte[] ctx)
  {
    int length = Ed448.Dom4Prefix.Length;
    byte[] input = new byte[length + 2 + ctx.Length];
    Ed448.Dom4Prefix.CopyTo((Array) input, 0);
    input[length] = phflag;
    input[length + 1] = (byte) ctx.Length;
    ctx.CopyTo((Array) input, length + 2);
    d.BlockUpdate(input, 0, input.Length);
  }

  private static void EncodePoint(ref Ed448.PointAffine p, byte[] r, int rOff)
  {
    X448Field.Encode(p.y, r, rOff);
    r[rOff + 57 - 1] = (byte) (((int) p.x[0] & 1) << 7);
  }

  public static void EncodePublicPoint(Ed448.PublicPoint publicPoint, byte[] pk, int pkOff)
  {
    X448Field.Encode(publicPoint.m_data, 16 /*0x10*/, pk, pkOff);
    pk[pkOff + 57 - 1] = (byte) (((int) publicPoint.m_data[0] & 1) << 7);
  }

  private static int EncodeResult(ref Ed448.PointProjective p, byte[] r, int rOff)
  {
    Ed448.PointAffine r1;
    Ed448.Init(out r1);
    Ed448.NormalizeToAffine(ref p, ref r1);
    int num = Ed448.CheckPoint(ref r1);
    Ed448.EncodePoint(ref r1, r, rOff);
    return num;
  }

  private static Ed448.PublicPoint ExportPoint(ref Ed448.PointAffine p)
  {
    uint[] numArray = new uint[32 /*0x20*/];
    X448Field.Copy(p.x, 0, numArray, 0);
    X448Field.Copy(p.y, 0, numArray, 16 /*0x10*/);
    return new Ed448.PublicPoint(numArray);
  }

  public static void GeneratePrivateKey(SecureRandom random, byte[] k)
  {
    if (k.Length != Ed448.SecretKeySize)
      throw new ArgumentException(nameof (k));
    random.NextBytes(k);
  }

  public static void GeneratePublicKey(byte[] sk, int skOff, byte[] pk, int pkOff)
  {
    IXof xof = Ed448.CreateXof();
    byte[] numArray1 = new byte[114];
    xof.BlockUpdate(sk, skOff, Ed448.SecretKeySize);
    xof.OutputFinal(numArray1, 0, numArray1.Length);
    byte[] numArray2 = new byte[57];
    Ed448.PruneScalar(numArray1, 0, numArray2);
    Ed448.ScalarMultBaseEncoded(numArray2, pk, pkOff);
  }

  public static Ed448.PublicPoint GeneratePublicKey(byte[] sk, int skOff)
  {
    IXof xof = Ed448.CreateXof();
    byte[] numArray1 = new byte[114];
    xof.BlockUpdate(sk, skOff, Ed448.SecretKeySize);
    xof.OutputFinal(numArray1, 0, numArray1.Length);
    byte[] numArray2 = new byte[57];
    Ed448.PruneScalar(numArray1, 0, numArray2);
    Ed448.PointProjective r1;
    Ed448.Init(out r1);
    Ed448.ScalarMultBase(numArray2, ref r1);
    Ed448.PointAffine r2;
    Ed448.Init(out r2);
    Ed448.NormalizeToAffine(ref r1, ref r2);
    return Ed448.CheckPoint(ref r2) != 0 ? Ed448.ExportPoint(ref r2) : throw new InvalidOperationException();
  }

  private static uint GetWindow4(uint[] x, int n)
  {
    int index = n >>> 3;
    int num = (n & 7) << 2;
    return x[index] >> num & 15U;
  }

  private static void ImplSign(
    IXof d,
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
    Ed448.Dom4(d, phflag, ctx);
    d.BlockUpdate(h, 57, 57);
    d.BlockUpdate(m, mOff, mLen);
    d.OutputFinal(h, 0, h.Length);
    byte[] numArray1 = Scalar448.Reduce(h);
    byte[] numArray2 = new byte[57];
    Ed448.ScalarMultBaseEncoded(numArray1, numArray2, 0);
    Ed448.Dom4(d, phflag, ctx);
    d.BlockUpdate(numArray2, 0, 57);
    d.BlockUpdate(pk, pkOff, 57);
    d.BlockUpdate(m, mOff, mLen);
    d.OutputFinal(h, 0, h.Length);
    byte[] s1 = Ed448.CalculateS(numArray1, Scalar448.Reduce(h), s);
    Array.Copy((Array) numArray2, 0, (Array) sig, sigOff, 57);
    byte[] destinationArray = sig;
    int destinationIndex = sigOff + 57;
    Array.Copy((Array) s1, 0, (Array) destinationArray, destinationIndex, 57);
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
    if (!Ed448.CheckContextVar(ctx))
      throw new ArgumentException(nameof (ctx));
    IXof xof = Ed448.CreateXof();
    byte[] numArray1 = new byte[114];
    xof.BlockUpdate(sk, skOff, Ed448.SecretKeySize);
    xof.OutputFinal(numArray1, 0, numArray1.Length);
    byte[] numArray2 = new byte[57];
    Ed448.PruneScalar(numArray1, 0, numArray2);
    byte[] numArray3 = new byte[57];
    Ed448.ScalarMultBaseEncoded(numArray2, numArray3, 0);
    Ed448.ImplSign(xof, numArray1, numArray2, numArray3, 0, ctx, phflag, m, mOff, mLen, sig, sigOff);
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
    if (!Ed448.CheckContextVar(ctx))
      throw new ArgumentException(nameof (ctx));
    IXof xof = Ed448.CreateXof();
    byte[] numArray1 = new byte[114];
    xof.BlockUpdate(sk, skOff, Ed448.SecretKeySize);
    xof.OutputFinal(numArray1, 0, numArray1.Length);
    byte[] numArray2 = new byte[57];
    Ed448.PruneScalar(numArray1, 0, numArray2);
    Ed448.ImplSign(xof, numArray1, numArray2, pk, pkOff, ctx, phflag, m, mOff, mLen, sig, sigOff);
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
    if (!Ed448.CheckContextVar(ctx))
      throw new ArgumentException(nameof (ctx));
    byte[] numArray1 = Ed448.Copy(sig, sigOff, 57);
    byte[] s = Ed448.Copy(sig, sigOff + 57, 57);
    byte[] numArray2 = Ed448.Copy(pk, pkOff, Ed448.PublicKeySize);
    if (!Ed448.CheckPointVar(numArray1))
      return false;
    uint[] numArray3 = new uint[14];
    if (!Scalar448.CheckVar(s, numArray3) || !Ed448.CheckPointFullVar(numArray2))
      return false;
    Ed448.PointAffine r1;
    Ed448.Init(out r1);
    if (!Ed448.DecodePointVar(numArray1, true, ref r1))
      return false;
    Ed448.PointAffine r2;
    Ed448.Init(out r2);
    if (!Ed448.DecodePointVar(numArray2, true, ref r2))
      return false;
    IXof xof = Ed448.CreateXof();
    byte[] numArray4 = new byte[114];
    Ed448.Dom4(xof, phflag, ctx);
    xof.BlockUpdate(numArray1, 0, 57);
    xof.BlockUpdate(numArray2, 0, 57);
    xof.BlockUpdate(m, mOff, mLen);
    xof.OutputFinal(numArray4, 0, numArray4.Length);
    byte[] k1 = Scalar448.Reduce(numArray4);
    uint[] k2 = new uint[14];
    uint[] n = k2;
    Scalar448.Decode(k1, n);
    uint[] numArray5 = new uint[8];
    uint[] numArray6 = new uint[8];
    Scalar448.ReduceBasisVar(k2, numArray5, numArray6);
    Scalar448.Multiply225Var(numArray3, numArray6, numArray3);
    Ed448.PointProjective r3;
    Ed448.Init(out r3);
    Ed448.ScalarMultStraus225Var(numArray3, numArray5, ref r2, numArray6, ref r1, ref r3);
    return Ed448.NormalizeToNeutralElementVar(ref r3);
  }

  private static bool ImplVerify(
    byte[] sig,
    int sigOff,
    Ed448.PublicPoint publicPoint,
    byte[] ctx,
    byte phflag,
    byte[] m,
    int mOff,
    int mLen)
  {
    if (!Ed448.CheckContextVar(ctx))
      throw new ArgumentException(nameof (ctx));
    byte[] numArray1 = Ed448.Copy(sig, sigOff, 57);
    byte[] s = Ed448.Copy(sig, sigOff + 57, 57);
    if (!Ed448.CheckPointVar(numArray1))
      return false;
    uint[] numArray2 = new uint[14];
    if (!Scalar448.CheckVar(s, numArray2))
      return false;
    Ed448.PointAffine r1;
    Ed448.Init(out r1);
    if (!Ed448.DecodePointVar(numArray1, true, ref r1))
      return false;
    Ed448.PointAffine r2;
    Ed448.Init(out r2);
    X448Field.Negate(publicPoint.m_data, r2.x);
    X448Field.Copy(publicPoint.m_data, 16 /*0x10*/, r2.y, 0);
    byte[] numArray3 = new byte[Ed448.PublicKeySize];
    Ed448.EncodePublicPoint(publicPoint, numArray3, 0);
    IXof xof = Ed448.CreateXof();
    byte[] numArray4 = new byte[114];
    Ed448.Dom4(xof, phflag, ctx);
    xof.BlockUpdate(numArray1, 0, 57);
    xof.BlockUpdate(numArray3, 0, 57);
    xof.BlockUpdate(m, mOff, mLen);
    xof.OutputFinal(numArray4, 0, numArray4.Length);
    byte[] k1 = Scalar448.Reduce(numArray4);
    uint[] k2 = new uint[14];
    uint[] n = k2;
    Scalar448.Decode(k1, n);
    uint[] numArray5 = new uint[8];
    uint[] numArray6 = new uint[8];
    Scalar448.ReduceBasisVar(k2, numArray5, numArray6);
    Scalar448.Multiply225Var(numArray2, numArray6, numArray2);
    Ed448.PointProjective r3;
    Ed448.Init(out r3);
    Ed448.ScalarMultStraus225Var(numArray2, numArray5, ref r2, numArray6, ref r1, ref r3);
    return Ed448.NormalizeToNeutralElementVar(ref r3);
  }

  private static void Init(out Ed448.PointAffine r)
  {
    r.x = X448Field.Create();
    r.y = X448Field.Create();
  }

  private static void Init(out Ed448.PointProjective r)
  {
    r.x = X448Field.Create();
    r.y = X448Field.Create();
    r.z = X448Field.Create();
  }

  private static void Init(out Ed448.PointTemp r)
  {
    r.r0 = X448Field.Create();
    r.r1 = X448Field.Create();
    r.r2 = X448Field.Create();
    r.r3 = X448Field.Create();
    r.r4 = X448Field.Create();
    r.r5 = X448Field.Create();
    r.r6 = X448Field.Create();
    r.r7 = X448Field.Create();
  }

  private static void InvertZs(Ed448.PointProjective[] points)
  {
    int length = points.Length;
    uint[] table = X448Field.CreateTable(length);
    uint[] numArray1 = X448Field.Create();
    X448Field.Copy(points[0].z, 0, numArray1, 0);
    X448Field.Copy(numArray1, 0, table, 0);
    int index1 = 0;
    while (++index1 < length)
    {
      X448Field.Mul(numArray1, points[index1].z, numArray1);
      X448Field.Copy(numArray1, 0, table, index1 * 16 /*0x10*/);
    }
    X448Field.InvVar(numArray1, numArray1);
    int num = index1 - 1;
    uint[] numArray2 = X448Field.Create();
    while (num > 0)
    {
      int index2 = num--;
      X448Field.Copy(table, num * 16 /*0x10*/, numArray2, 0);
      X448Field.Mul(numArray2, numArray1, numArray2);
      X448Field.Mul(numArray1, points[index2].z, numArray1);
      X448Field.Copy(numArray2, 0, points[index2].z, 0);
    }
    X448Field.Copy(numArray1, 0, points[0].z, 0);
  }

  private static bool IsNeutralElementVar(uint[] x, uint[] y, uint[] z)
  {
    return X448Field.IsZeroVar(x) && X448Field.AreEqualVar(y, z);
  }

  private static void NormalizeToAffine(ref Ed448.PointProjective p, ref Ed448.PointAffine r)
  {
    X448Field.Inv(p.z, r.y);
    X448Field.Mul(r.y, p.x, r.x);
    X448Field.Mul(r.y, p.y, r.y);
    X448Field.Normalize(r.x);
    X448Field.Normalize(r.y);
  }

  private static bool NormalizeToNeutralElementVar(ref Ed448.PointProjective p)
  {
    X448Field.Normalize(p.x);
    X448Field.Normalize(p.y);
    X448Field.Normalize(p.z);
    return Ed448.IsNeutralElementVar(p.x, p.y, p.z);
  }

  private static void PointAdd(
    ref Ed448.PointAffine p,
    ref Ed448.PointProjective r,
    ref Ed448.PointTemp t)
  {
    uint[] r1 = t.r1;
    uint[] r2 = t.r2;
    uint[] r3 = t.r3;
    uint[] r4 = t.r4;
    uint[] r5 = t.r5;
    uint[] r6 = t.r6;
    uint[] r7 = t.r7;
    X448Field.Sqr(r.z, r1);
    X448Field.Mul(p.x, r.x, r2);
    X448Field.Mul(p.y, r.y, r3);
    X448Field.Mul(r2, r3, r4);
    X448Field.Mul(r4, 39081U, r4);
    X448Field.Add(r1, r4, r5);
    X448Field.Sub(r1, r4, r6);
    X448Field.Add(p.y, p.x, r7);
    X448Field.Add(r.y, r.x, r4);
    X448Field.Mul(r7, r4, r7);
    X448Field.Add(r3, r2, r1);
    X448Field.Sub(r3, r2, r4);
    X448Field.Carry(r1);
    X448Field.Sub(r7, r1, r7);
    X448Field.Mul(r7, r.z, r7);
    X448Field.Mul(r4, r.z, r4);
    X448Field.Mul(r5, r7, r.x);
    X448Field.Mul(r4, r6, r.y);
    X448Field.Mul(r5, r6, r.z);
  }

  private static void PointAdd(
    ref Ed448.PointProjective p,
    ref Ed448.PointProjective r,
    ref Ed448.PointTemp t)
  {
    uint[] r0 = t.r0;
    uint[] r1 = t.r1;
    uint[] r2 = t.r2;
    uint[] r3 = t.r3;
    uint[] r4 = t.r4;
    uint[] r5 = t.r5;
    uint[] r6 = t.r6;
    uint[] r7 = t.r7;
    X448Field.Mul(p.z, r.z, r0);
    X448Field.Sqr(r0, r1);
    X448Field.Mul(p.x, r.x, r2);
    X448Field.Mul(p.y, r.y, r3);
    X448Field.Mul(r2, r3, r4);
    X448Field.Mul(r4, 39081U, r4);
    X448Field.Add(r1, r4, r5);
    X448Field.Sub(r1, r4, r6);
    X448Field.Add(p.y, p.x, r7);
    X448Field.Add(r.y, r.x, r4);
    X448Field.Mul(r7, r4, r7);
    X448Field.Add(r3, r2, r1);
    X448Field.Sub(r3, r2, r4);
    X448Field.Carry(r1);
    X448Field.Sub(r7, r1, r7);
    X448Field.Mul(r7, r0, r7);
    X448Field.Mul(r4, r0, r4);
    X448Field.Mul(r5, r7, r.x);
    X448Field.Mul(r4, r6, r.y);
    X448Field.Mul(r5, r6, r.z);
  }

  private static void PointAddVar(
    bool negate,
    ref Ed448.PointAffine p,
    ref Ed448.PointProjective r,
    ref Ed448.PointTemp t)
  {
    uint[] r1 = t.r1;
    uint[] r2 = t.r2;
    uint[] r3 = t.r3;
    uint[] r4 = t.r4;
    uint[] r5 = t.r5;
    uint[] r6 = t.r6;
    uint[] r7 = t.r7;
    uint[] z1;
    uint[] z2;
    uint[] z3;
    uint[] z4;
    if (negate)
    {
      z1 = r4;
      z2 = r1;
      z3 = r6;
      z4 = r5;
      X448Field.Sub(p.y, p.x, r7);
    }
    else
    {
      z1 = r1;
      z2 = r4;
      z3 = r5;
      z4 = r6;
      X448Field.Add(p.y, p.x, r7);
    }
    X448Field.Sqr(r.z, r1);
    X448Field.Mul(p.x, r.x, r2);
    X448Field.Mul(p.y, r.y, r3);
    X448Field.Mul(r2, r3, r4);
    X448Field.Mul(r4, 39081U, r4);
    X448Field.Add(r1, r4, z3);
    X448Field.Sub(r1, r4, z4);
    X448Field.Add(r.y, r.x, r4);
    X448Field.Mul(r7, r4, r7);
    X448Field.Add(r3, r2, z1);
    X448Field.Sub(r3, r2, z2);
    X448Field.Carry(z1);
    X448Field.Sub(r7, r1, r7);
    X448Field.Mul(r7, r.z, r7);
    X448Field.Mul(r4, r.z, r4);
    X448Field.Mul(r5, r7, r.x);
    X448Field.Mul(r4, r6, r.y);
    X448Field.Mul(r5, r6, r.z);
  }

  private static void PointAddVar(
    bool negate,
    ref Ed448.PointProjective p,
    ref Ed448.PointProjective r,
    ref Ed448.PointTemp t)
  {
    uint[] r0 = t.r0;
    uint[] r1 = t.r1;
    uint[] r2 = t.r2;
    uint[] r3 = t.r3;
    uint[] r4 = t.r4;
    uint[] r5 = t.r5;
    uint[] r6 = t.r6;
    uint[] r7 = t.r7;
    uint[] z1;
    uint[] z2;
    uint[] z3;
    uint[] z4;
    if (negate)
    {
      z1 = r4;
      z2 = r1;
      z3 = r6;
      z4 = r5;
      X448Field.Sub(p.y, p.x, r7);
    }
    else
    {
      z1 = r1;
      z2 = r4;
      z3 = r5;
      z4 = r6;
      X448Field.Add(p.y, p.x, r7);
    }
    X448Field.Mul(p.z, r.z, r0);
    X448Field.Sqr(r0, r1);
    X448Field.Mul(p.x, r.x, r2);
    X448Field.Mul(p.y, r.y, r3);
    X448Field.Mul(r2, r3, r4);
    X448Field.Mul(r4, 39081U, r4);
    X448Field.Add(r1, r4, z3);
    X448Field.Sub(r1, r4, z4);
    X448Field.Add(r.y, r.x, r4);
    X448Field.Mul(r7, r4, r7);
    X448Field.Add(r3, r2, z1);
    X448Field.Sub(r3, r2, z2);
    X448Field.Carry(z1);
    X448Field.Sub(r7, r1, r7);
    X448Field.Mul(r7, r0, r7);
    X448Field.Mul(r4, r0, r4);
    X448Field.Mul(r5, r7, r.x);
    X448Field.Mul(r4, r6, r.y);
    X448Field.Mul(r5, r6, r.z);
  }

  private static void PointCopy(ref Ed448.PointAffine p, ref Ed448.PointProjective r)
  {
    X448Field.Copy(p.x, 0, r.x, 0);
    X448Field.Copy(p.y, 0, r.y, 0);
    X448Field.One(r.z);
  }

  private static void PointCopy(ref Ed448.PointProjective p, ref Ed448.PointProjective r)
  {
    X448Field.Copy(p.x, 0, r.x, 0);
    X448Field.Copy(p.y, 0, r.y, 0);
    X448Field.Copy(p.z, 0, r.z, 0);
  }

  private static void PointDouble(ref Ed448.PointProjective r, ref Ed448.PointTemp t)
  {
    uint[] r1 = t.r1;
    uint[] r2 = t.r2;
    uint[] r3 = t.r3;
    uint[] r4 = t.r4;
    uint[] r7 = t.r7;
    uint[] r0 = t.r0;
    X448Field.Add(r.x, r.y, r1);
    X448Field.Sqr(r1, r1);
    X448Field.Sqr(r.x, r2);
    X448Field.Sqr(r.y, r3);
    X448Field.Add(r2, r3, r4);
    X448Field.Carry(r4);
    X448Field.Sqr(r.z, r7);
    X448Field.Add(r7, r7, r7);
    X448Field.Carry(r7);
    X448Field.Sub(r4, r7, r0);
    X448Field.Sub(r1, r4, r1);
    X448Field.Sub(r2, r3, r2);
    X448Field.Mul(r1, r0, r.x);
    X448Field.Mul(r4, r2, r.y);
    X448Field.Mul(r4, r0, r.z);
  }

  private static void PointLookup(int block, int index, ref Ed448.PointAffine p)
  {
    int xOff1 = block * 16 /*0x10*/ * 2 * 16 /*0x10*/;
    for (int index1 = 0; index1 < 16 /*0x10*/; ++index1)
    {
      int cond = (index1 ^ index) - 1 >> 31 /*0x1F*/;
      X448Field.CMov(cond, Ed448.PrecompBaseComb, xOff1, p.x, 0);
      int xOff2 = xOff1 + 16 /*0x10*/;
      X448Field.CMov(cond, Ed448.PrecompBaseComb, xOff2, p.y, 0);
      xOff1 = xOff2 + 16 /*0x10*/;
    }
  }

  private static void PointLookup(uint[] x, int n, uint[] table, ref Ed448.PointProjective r)
  {
    int window4 = (int) Ed448.GetWindow4(x, n);
    int negate = window4 >>> 3 ^ 1;
    int num1 = (window4 ^ -negate) & 7;
    int num2 = 0;
    int xOff1 = 0;
    for (; num2 < 8; ++num2)
    {
      int cond = (num2 ^ num1) - 1 >> 31 /*0x1F*/;
      X448Field.CMov(cond, table, xOff1, r.x, 0);
      int xOff2 = xOff1 + 16 /*0x10*/;
      X448Field.CMov(cond, table, xOff2, r.y, 0);
      int xOff3 = xOff2 + 16 /*0x10*/;
      X448Field.CMov(cond, table, xOff3, r.z, 0);
      xOff1 = xOff3 + 16 /*0x10*/;
    }
    X448Field.CNegate(negate, r.x);
  }

  private static void PointLookup15(uint[] table, ref Ed448.PointProjective r)
  {
    X448Field.Copy(table, 336, r.x, 0);
    X448Field.Copy(table, 352, r.y, 0);
    X448Field.Copy(table, 368, r.z, 0);
  }

  private static uint[] PointPrecompute(
    ref Ed448.PointProjective p,
    int count,
    ref Ed448.PointTemp t)
  {
    Ed448.PointProjective r1;
    Ed448.Init(out r1);
    Ed448.PointCopy(ref p, ref r1);
    Ed448.PointProjective r2;
    Ed448.Init(out r2);
    Ed448.PointCopy(ref r1, ref r2);
    Ed448.PointDouble(ref r2, ref t);
    uint[] table = X448Field.CreateTable(count * 3);
    int zOff1 = 0;
    int num = 0;
    while (true)
    {
      X448Field.Copy(r1.x, 0, table, zOff1);
      int zOff2 = zOff1 + 16 /*0x10*/;
      X448Field.Copy(r1.y, 0, table, zOff2);
      int zOff3 = zOff2 + 16 /*0x10*/;
      X448Field.Copy(r1.z, 0, table, zOff3);
      zOff1 = zOff3 + 16 /*0x10*/;
      if (++num != count)
        Ed448.PointAdd(ref r2, ref r1, ref t);
      else
        break;
    }
    return table;
  }

  private static void PointPrecompute(
    ref Ed448.PointAffine p,
    Ed448.PointProjective[] points,
    int pointsOff,
    int pointsLen,
    ref Ed448.PointTemp t)
  {
    Ed448.PointProjective r;
    Ed448.Init(out r);
    Ed448.PointCopy(ref p, ref r);
    Ed448.PointDouble(ref r, ref t);
    Ed448.Init(out points[pointsOff]);
    Ed448.PointCopy(ref p, ref points[pointsOff]);
    for (int index = 1; index < pointsLen; ++index)
    {
      Ed448.Init(out points[pointsOff + index]);
      Ed448.PointCopy(ref points[pointsOff + index - 1], ref points[pointsOff + index]);
      Ed448.PointAdd(ref r, ref points[pointsOff + index], ref t);
    }
  }

  private static void PointSetNeutral(ref Ed448.PointProjective p)
  {
    X448Field.Zero(p.x);
    X448Field.One(p.y);
    X448Field.One(p.z);
  }

  public static void Precompute()
  {
    lock (Ed448.PrecompLock)
    {
      if (Ed448.PrecompBaseComb != null)
        return;
      int length = 32 /*0x20*/;
      int num1 = 80 /*0x50*/;
      int num2 = 144 /*0x90*/;
      Ed448.PointProjective[] points = new Ed448.PointProjective[144 /*0x90*/];
      Ed448.PointTemp r1;
      Ed448.Init(out r1);
      Ed448.PointAffine r2;
      Ed448.Init(out r2);
      X448Field.Copy(Ed448.B_x, 0, r2.x, 0);
      X448Field.Copy(Ed448.B_y, 0, r2.y, 0);
      Ed448.PointPrecompute(ref r2, points, 0, 32 /*0x20*/, ref r1);
      Ed448.PointAffine r3;
      Ed448.Init(out r3);
      X448Field.Copy(Ed448.B225_x, 0, r3.x, 0);
      X448Field.Copy(Ed448.B225_y, 0, r3.y, 0);
      Ed448.PointPrecompute(ref r3, points, 32 /*0x20*/, 32 /*0x20*/, ref r1);
      Ed448.PointProjective r4;
      Ed448.Init(out r4);
      Ed448.PointCopy(ref r2, ref r4);
      int index1 = 64 /*0x40*/;
      Ed448.PointProjective[] pointProjectiveArray = new Ed448.PointProjective[5];
      for (int index2 = 0; index2 < 5; ++index2)
        Ed448.Init(out pointProjectiveArray[index2]);
      for (int index3 = 0; index3 < 5; ++index3)
      {
        ref Ed448.PointProjective local = ref points[index1++];
        Ed448.Init(out local);
        for (int index4 = 0; index4 < 5; ++index4)
        {
          if (index4 == 0)
            Ed448.PointCopy(ref r4, ref local);
          else
            Ed448.PointAdd(ref r4, ref local, ref r1);
          Ed448.PointDouble(ref r4, ref r1);
          Ed448.PointCopy(ref r4, ref pointProjectiveArray[index4]);
          if (index3 + index4 != 8)
          {
            for (int index5 = 1; index5 < 18; ++index5)
              Ed448.PointDouble(ref r4, ref r1);
          }
        }
        X448Field.Negate(local.x, local.x);
        for (int index6 = 0; index6 < 4; ++index6)
        {
          int num3 = 1 << index6;
          int num4 = 0;
          while (num4 < num3)
          {
            Ed448.Init(out points[index1]);
            Ed448.PointCopy(ref points[index1 - num3], ref points[index1]);
            Ed448.PointAdd(ref pointProjectiveArray[index6], ref points[index1], ref r1);
            ++num4;
            ++index1;
          }
        }
      }
      Ed448.InvertZs(points);
      Ed448.PrecompBaseWnaf = new Ed448.PointAffine[length];
      for (int index7 = 0; index7 < length; ++index7)
      {
        ref Ed448.PointProjective local1 = ref points[index7];
        ref Ed448.PointAffine local2 = ref Ed448.PrecompBaseWnaf[index7];
        Ed448.Init(out local2);
        X448Field.Mul(local1.x, local1.z, local2.x);
        X448Field.Normalize(local2.x);
        X448Field.Mul(local1.y, local1.z, local2.y);
        X448Field.Normalize(local2.y);
      }
      Ed448.PrecompBase225Wnaf = new Ed448.PointAffine[length];
      for (int index8 = 0; index8 < length; ++index8)
      {
        ref Ed448.PointProjective local3 = ref points[length + index8];
        ref Ed448.PointAffine local4 = ref Ed448.PrecompBase225Wnaf[index8];
        Ed448.Init(out local4);
        X448Field.Mul(local3.x, local3.z, local4.x);
        X448Field.Normalize(local4.x);
        X448Field.Mul(local3.y, local3.z, local4.y);
        X448Field.Normalize(local4.y);
      }
      Ed448.PrecompBaseComb = X448Field.CreateTable(num1 * 2);
      int zOff1 = 0;
      for (int index9 = length * 2; index9 < num2; ++index9)
      {
        ref Ed448.PointProjective local = ref points[index9];
        X448Field.Mul(local.x, local.z, local.x);
        X448Field.Normalize(local.x);
        X448Field.Mul(local.y, local.z, local.y);
        X448Field.Normalize(local.y);
        X448Field.Copy(local.x, 0, Ed448.PrecompBaseComb, zOff1);
        int zOff2 = zOff1 + 16 /*0x10*/;
        X448Field.Copy(local.y, 0, Ed448.PrecompBaseComb, zOff2);
        zOff1 = zOff2 + 16 /*0x10*/;
      }
    }
  }

  private static void PruneScalar(byte[] n, int nOff, byte[] r)
  {
    Array.Copy((Array) n, nOff, (Array) r, 0, 56);
    r[0] &= (byte) 252;
    r[55] |= (byte) 128 /*0x80*/;
    r[56] = (byte) 0;
  }

  private static void ScalarMult(
    byte[] k,
    ref Ed448.PointProjective p,
    ref Ed448.PointProjective r)
  {
    uint[] numArray = new uint[15];
    Scalar448.Decode(k, numArray);
    Scalar448.ToSignedDigits(449, numArray, numArray);
    Ed448.PointProjective r1;
    Ed448.Init(out r1);
    Ed448.PointTemp r2;
    Ed448.Init(out r2);
    uint[] table = Ed448.PointPrecompute(ref p, 8, ref r2);
    Ed448.PointLookup15(table, ref r);
    Ed448.PointAdd(ref p, ref r, ref r2);
    int n = 111;
label_4:
    Ed448.PointLookup(numArray, n, table, ref r1);
    Ed448.PointAdd(ref r1, ref r, ref r2);
    if (--n < 0)
      return;
    for (int index = 0; index < 4; ++index)
      Ed448.PointDouble(ref r, ref r2);
    goto label_4;
  }

  private static void ScalarMultBase(byte[] k, ref Ed448.PointProjective r)
  {
    Ed448.Precompute();
    uint[] numArray = new uint[15];
    Scalar448.Decode(k, numArray);
    Scalar448.ToSignedDigits(450, numArray, numArray);
    Ed448.PointAffine r1;
    Ed448.Init(out r1);
    Ed448.PointTemp r2;
    Ed448.Init(out r2);
    Ed448.PointSetNeutral(ref r);
    int num1 = 17;
    while (true)
    {
      int num2 = num1;
      for (int block = 0; block < 5; ++block)
      {
        uint num3 = 0;
        for (int index = 0; index < 5; ++index)
        {
          uint num4 = numArray[num2 >> 5] >> num2;
          num3 = num3 & (uint) ~(1 << index) ^ num4 << index;
          num2 += 18;
        }
        int negate = (int) (num3 >> 4) & 1;
        int index1 = ((int) num3 ^ -negate) & 15;
        Ed448.PointLookup(block, index1, ref r1);
        X448Field.CNegate(negate, r1.x);
        Ed448.PointAdd(ref r1, ref r, ref r2);
      }
      if (--num1 >= 0)
        Ed448.PointDouble(ref r, ref r2);
      else
        break;
    }
  }

  private static void ScalarMultBaseEncoded(byte[] k, byte[] r, int rOff)
  {
    Ed448.PointProjective r1;
    Ed448.Init(out r1);
    Ed448.ScalarMultBase(k, ref r1);
    if (Ed448.EncodeResult(ref r1, r, rOff) == 0)
      throw new InvalidOperationException();
  }

  internal static void ScalarMultBaseXY(byte[] k, int kOff, uint[] x, uint[] y)
  {
    byte[] numArray = new byte[57];
    Ed448.PruneScalar(k, kOff, numArray);
    Ed448.PointProjective r;
    Ed448.Init(out r);
    Ed448.ScalarMultBase(numArray, ref r);
    if (Ed448.CheckPoint(r) == 0)
      throw new InvalidOperationException();
    X448Field.Copy(r.x, 0, x, 0);
    X448Field.Copy(r.y, 0, y, 0);
  }

  private static void ScalarMultOrderVar(ref Ed448.PointAffine p, ref Ed448.PointProjective r)
  {
    sbyte[] ws = new sbyte[447];
    Scalar448.GetOrderWnafVar(5, ws);
    Ed448.PointProjective[] points = new Ed448.PointProjective[8];
    Ed448.PointTemp r1;
    Ed448.Init(out r1);
    Ed448.PointPrecompute(ref p, points, 0, 8, ref r1);
    Ed448.PointSetNeutral(ref r);
    int index1 = 446;
    while (true)
    {
      int num = (int) ws[index1];
      if (num != 0)
        goto label_3;
label_1:
      if (--index1 >= 0)
      {
        Ed448.PointDouble(ref r, ref r1);
        continue;
      }
      break;
label_3:
      int index2 = num >> 1 ^ num >> 31 /*0x1F*/;
      Ed448.PointAddVar(num < 0, ref points[index2], ref r, ref r1);
      goto label_1;
    }
  }

  private static void ScalarMultStraus225Var(
    uint[] nb,
    uint[] np,
    ref Ed448.PointAffine p,
    uint[] nq,
    ref Ed448.PointAffine q,
    ref Ed448.PointProjective r)
  {
    Ed448.Precompute();
    sbyte[] ws1 = new sbyte[450];
    sbyte[] ws2 = new sbyte[225];
    sbyte[] ws3 = new sbyte[225];
    Wnaf.GetSignedVar(nb, 7, ws1);
    Wnaf.GetSignedVar(np, 5, ws2);
    Wnaf.GetSignedVar(nq, 5, ws3);
    Ed448.PointProjective[] points1 = new Ed448.PointProjective[8];
    Ed448.PointProjective[] points2 = new Ed448.PointProjective[8];
    Ed448.PointTemp r1;
    Ed448.Init(out r1);
    Ed448.PointPrecompute(ref p, points1, 0, 8, ref r1);
    Ed448.PointPrecompute(ref q, points2, 0, 8, ref r1);
    Ed448.PointSetNeutral(ref r);
    int index1 = 225;
    while (--index1 >= 0)
    {
      int num1 = (int) ws1[index1];
      if (num1 != 0)
      {
        int index2 = num1 >> 1 ^ num1 >> 31 /*0x1F*/;
        Ed448.PointAddVar(num1 < 0, ref Ed448.PrecompBaseWnaf[index2], ref r, ref r1);
      }
      int num2 = (int) ws1[225 + index1];
      if (num2 != 0)
      {
        int index3 = num2 >> 1 ^ num2 >> 31 /*0x1F*/;
        Ed448.PointAddVar(num2 < 0, ref Ed448.PrecompBase225Wnaf[index3], ref r, ref r1);
      }
      int num3 = (int) ws2[index1];
      if (num3 != 0)
      {
        int index4 = num3 >> 1 ^ num3 >> 31 /*0x1F*/;
        Ed448.PointAddVar(num3 < 0, ref points1[index4], ref r, ref r1);
      }
      int num4 = (int) ws3[index1];
      if (num4 != 0)
      {
        int index5 = num4 >> 1 ^ num4 >> 31 /*0x1F*/;
        Ed448.PointAddVar(num4 < 0, ref points2[index5], ref r, ref r1);
      }
      Ed448.PointDouble(ref r, ref r1);
    }
    Ed448.PointDouble(ref r, ref r1);
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
    Ed448.ImplSign(sk, skOff, ctx, (byte) 0, m, mOff, mLen, sig, sigOff);
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
    Ed448.ImplSign(sk, skOff, pk, pkOff, ctx, (byte) 0, m, mOff, mLen, sig, sigOff);
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
    Ed448.ImplSign(sk, skOff, ctx, (byte) 1, ph, phOff, Ed448.PrehashSize, sig, sigOff);
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
    Ed448.ImplSign(sk, skOff, pk, pkOff, ctx, (byte) 1, ph, phOff, Ed448.PrehashSize, sig, sigOff);
  }

  public static void SignPrehash(
    byte[] sk,
    int skOff,
    byte[] ctx,
    IXof ph,
    byte[] sig,
    int sigOff)
  {
    byte[] numArray = new byte[Ed448.PrehashSize];
    if (Ed448.PrehashSize != ph.OutputFinal(numArray, 0, Ed448.PrehashSize))
      throw new ArgumentException(nameof (ph));
    Ed448.ImplSign(sk, skOff, ctx, (byte) 1, numArray, 0, numArray.Length, sig, sigOff);
  }

  public static void SignPrehash(
    byte[] sk,
    int skOff,
    byte[] pk,
    int pkOff,
    byte[] ctx,
    IXof ph,
    byte[] sig,
    int sigOff)
  {
    byte[] numArray = new byte[Ed448.PrehashSize];
    if (Ed448.PrehashSize != ph.OutputFinal(numArray, 0, Ed448.PrehashSize))
      throw new ArgumentException(nameof (ph));
    Ed448.ImplSign(sk, skOff, pk, pkOff, ctx, (byte) 1, numArray, 0, numArray.Length, sig, sigOff);
  }

  public static bool ValidatePublicKeyFull(byte[] pk, int pkOff)
  {
    byte[] p = Ed448.Copy(pk, pkOff, Ed448.PublicKeySize);
    if (!Ed448.CheckPointFullVar(p))
      return false;
    Ed448.PointAffine r;
    Ed448.Init(out r);
    return Ed448.DecodePointVar(p, false, ref r) && Ed448.CheckPointOrderVar(ref r);
  }

  public static Ed448.PublicPoint ValidatePublicKeyFullExport(byte[] pk, int pkOff)
  {
    byte[] p = Ed448.Copy(pk, pkOff, Ed448.PublicKeySize);
    if (!Ed448.CheckPointFullVar(p))
      return (Ed448.PublicPoint) null;
    Ed448.PointAffine r;
    Ed448.Init(out r);
    if (!Ed448.DecodePointVar(p, false, ref r))
      return (Ed448.PublicPoint) null;
    return !Ed448.CheckPointOrderVar(ref r) ? (Ed448.PublicPoint) null : Ed448.ExportPoint(ref r);
  }

  public static bool ValidatePublicKeyPartial(byte[] pk, int pkOff)
  {
    byte[] p = Ed448.Copy(pk, pkOff, Ed448.PublicKeySize);
    if (!Ed448.CheckPointFullVar(p))
      return false;
    Ed448.PointAffine r;
    Ed448.Init(out r);
    return Ed448.DecodePointVar(p, false, ref r);
  }

  public static Ed448.PublicPoint ValidatePublicKeyPartialExport(byte[] pk, int pkOff)
  {
    byte[] p = Ed448.Copy(pk, pkOff, Ed448.PublicKeySize);
    if (!Ed448.CheckPointFullVar(p))
      return (Ed448.PublicPoint) null;
    Ed448.PointAffine r;
    Ed448.Init(out r);
    return !Ed448.DecodePointVar(p, false, ref r) ? (Ed448.PublicPoint) null : Ed448.ExportPoint(ref r);
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
    return Ed448.ImplVerify(sig, sigOff, pk, pkOff, ctx, (byte) 0, m, mOff, mLen);
  }

  public static bool Verify(
    byte[] sig,
    int sigOff,
    Ed448.PublicPoint publicPoint,
    byte[] ctx,
    byte[] m,
    int mOff,
    int mLen)
  {
    return Ed448.ImplVerify(sig, sigOff, publicPoint, ctx, (byte) 0, m, mOff, mLen);
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
    return Ed448.ImplVerify(sig, sigOff, pk, pkOff, ctx, (byte) 1, ph, phOff, Ed448.PrehashSize);
  }

  public static bool VerifyPrehash(
    byte[] sig,
    int sigOff,
    Ed448.PublicPoint publicPoint,
    byte[] ctx,
    byte[] ph,
    int phOff)
  {
    return Ed448.ImplVerify(sig, sigOff, publicPoint, ctx, (byte) 1, ph, phOff, Ed448.PrehashSize);
  }

  public static bool VerifyPrehash(
    byte[] sig,
    int sigOff,
    byte[] pk,
    int pkOff,
    byte[] ctx,
    IXof ph)
  {
    byte[] numArray = new byte[Ed448.PrehashSize];
    if (Ed448.PrehashSize != ph.OutputFinal(numArray, 0, Ed448.PrehashSize))
      throw new ArgumentException(nameof (ph));
    return Ed448.ImplVerify(sig, sigOff, pk, pkOff, ctx, (byte) 1, numArray, 0, numArray.Length);
  }

  public static bool VerifyPrehash(
    byte[] sig,
    int sigOff,
    Ed448.PublicPoint publicPoint,
    byte[] ctx,
    IXof ph)
  {
    byte[] numArray = new byte[Ed448.PrehashSize];
    if (Ed448.PrehashSize != ph.OutputFinal(numArray, 0, Ed448.PrehashSize))
      throw new ArgumentException(nameof (ph));
    return Ed448.ImplVerify(sig, sigOff, publicPoint, ctx, (byte) 1, numArray, 0, numArray.Length);
  }

  public enum Algorithm
  {
    Ed448,
    Ed448ph,
  }

  public sealed class PublicPoint
  {
    internal readonly uint[] m_data;

    internal PublicPoint(uint[] data) => this.m_data = data;
  }

  private struct PointAffine
  {
    internal uint[] x;
    internal uint[] y;
  }

  private struct PointProjective
  {
    internal uint[] x;
    internal uint[] y;
    internal uint[] z;
  }

  private struct PointTemp
  {
    internal uint[] r0;
    internal uint[] r1;
    internal uint[] r2;
    internal uint[] r3;
    internal uint[] r4;
    internal uint[] r5;
    internal uint[] r6;
    internal uint[] r7;
  }
}
