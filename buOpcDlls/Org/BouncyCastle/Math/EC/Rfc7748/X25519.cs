// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Rfc7748.X25519
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.EC.Rfc8032;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Math.EC.Rfc7748;

public static class X25519
{
  public const int PointSize = 32 /*0x20*/;
  public const int ScalarSize = 32 /*0x20*/;
  private const int C_A = 486662;
  private const int C_A24 = 121666;

  public static bool CalculateAgreement(
    byte[] k,
    int kOff,
    byte[] u,
    int uOff,
    byte[] r,
    int rOff)
  {
    X25519.ScalarMult(k, kOff, u, uOff, r, rOff);
    return !Arrays.AreAllZeroes(r, rOff, 32 /*0x20*/);
  }

  private static uint Decode32(byte[] bs, int off)
  {
    return (uint) ((int) bs[off] | (int) bs[++off] << 8 | (int) bs[++off] << 16 /*0x10*/ | (int) bs[++off] << 24);
  }

  private static void DecodeScalar(byte[] k, int kOff, uint[] n)
  {
    for (int index = 0; index < 8; ++index)
      n[index] = X25519.Decode32(k, kOff + index * 4);
    n[0] &= 4294967288U;
    n[7] &= (uint) int.MaxValue;
    n[7] |= 1073741824U /*0x40000000*/;
  }

  public static void GeneratePrivateKey(SecureRandom random, byte[] k)
  {
    if (k.Length != 32 /*0x20*/)
      throw new ArgumentException(nameof (k));
    random.NextBytes(k);
    k[0] &= (byte) 248;
    k[31 /*0x1F*/] &= (byte) 127 /*0x7F*/;
    k[31 /*0x1F*/] |= (byte) 64 /*0x40*/;
  }

  public static void GeneratePublicKey(byte[] k, int kOff, byte[] r, int rOff)
  {
    X25519.ScalarMultBase(k, kOff, r, rOff);
  }

  private static void PointDouble(int[] x, int[] z)
  {
    int[] numArray1 = X25519Field.Create();
    int[] numArray2 = X25519Field.Create();
    X25519Field.Apm(x, z, numArray1, numArray2);
    X25519Field.Sqr(numArray1, numArray1);
    X25519Field.Sqr(numArray2, numArray2);
    X25519Field.Mul(numArray1, numArray2, x);
    X25519Field.Sub(numArray1, numArray2, numArray1);
    X25519Field.Mul(numArray1, 121666, z);
    X25519Field.Add(z, numArray2, z);
    X25519Field.Mul(z, numArray1, z);
  }

  public static void Precompute() => Ed25519.Precompute();

  public static void ScalarMult(byte[] k, int kOff, byte[] u, int uOff, byte[] r, int rOff)
  {
    uint[] n = new uint[8];
    X25519.DecodeScalar(k, kOff, n);
    int[] numArray1 = X25519Field.Create();
    X25519Field.Decode(u, uOff, numArray1);
    int[] numArray2 = X25519Field.Create();
    X25519Field.Copy(numArray1, 0, numArray2, 0);
    int[] numArray3 = X25519Field.Create();
    numArray3[0] = 1;
    int[] numArray4 = X25519Field.Create();
    numArray4[0] = 1;
    int[] numArray5 = X25519Field.Create();
    int[] numArray6 = X25519Field.Create();
    int[] numArray7 = X25519Field.Create();
    int num1 = 254;
    int num2 = 1;
    do
    {
      X25519Field.Apm(numArray4, numArray5, numArray6, numArray4);
      X25519Field.Apm(numArray2, numArray3, numArray5, numArray2);
      X25519Field.Mul(numArray6, numArray2, numArray6);
      X25519Field.Mul(numArray4, numArray5, numArray4);
      X25519Field.Sqr(numArray5, numArray5);
      X25519Field.Sqr(numArray2, numArray2);
      X25519Field.Sub(numArray5, numArray2, numArray7);
      X25519Field.Mul(numArray7, 121666, numArray3);
      X25519Field.Add(numArray3, numArray2, numArray3);
      X25519Field.Mul(numArray3, numArray7, numArray3);
      X25519Field.Mul(numArray2, numArray5, numArray2);
      X25519Field.Apm(numArray6, numArray4, numArray4, numArray5);
      X25519Field.Sqr(numArray4, numArray4);
      X25519Field.Sqr(numArray5, numArray5);
      X25519Field.Mul(numArray5, numArray1, numArray5);
      --num1;
      int index = num1 >> 5;
      int num3 = num1 & 31 /*0x1F*/;
      int num4 = (int) (n[index] >> num3) & 1;
      int swap = num2 ^ num4;
      X25519Field.CSwap(swap, numArray2, numArray4);
      X25519Field.CSwap(swap, numArray3, numArray5);
      num2 = num4;
    }
    while (num1 >= 3);
    for (int index = 0; index < 3; ++index)
      X25519.PointDouble(numArray2, numArray3);
    X25519Field.Inv(numArray3, numArray3);
    X25519Field.Mul(numArray2, numArray3, numArray2);
    X25519Field.Normalize(numArray2);
    X25519Field.Encode(numArray2, r, rOff);
  }

  public static void ScalarMultBase(byte[] k, int kOff, byte[] r, int rOff)
  {
    int[] numArray1 = X25519Field.Create();
    int[] numArray2 = X25519Field.Create();
    Ed25519.ScalarMultBaseYZ(k, kOff, numArray1, numArray2);
    X25519Field.Apm(numArray2, numArray1, numArray1, numArray2);
    X25519Field.Inv(numArray2, numArray2);
    X25519Field.Mul(numArray1, numArray2, numArray1);
    X25519Field.Normalize(numArray1);
    X25519Field.Encode(numArray1, r, rOff);
  }
}
