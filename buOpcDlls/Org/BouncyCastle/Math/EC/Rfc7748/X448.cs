// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Rfc7748.X448
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.EC.Rfc8032;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Math.EC.Rfc7748;

public static class X448
{
  public const int PointSize = 56;
  public const int ScalarSize = 56;
  private const uint C_A = 156326;
  private const uint C_A24 = 39082;

  public static bool CalculateAgreement(
    byte[] k,
    int kOff,
    byte[] u,
    int uOff,
    byte[] r,
    int rOff)
  {
    X448.ScalarMult(k, kOff, u, uOff, r, rOff);
    return !Arrays.AreAllZeroes(r, rOff, 56);
  }

  private static uint Decode32(byte[] bs, int off)
  {
    return (uint) ((int) bs[off] | (int) bs[++off] << 8 | (int) bs[++off] << 16 /*0x10*/ | (int) bs[++off] << 24);
  }

  private static void DecodeScalar(byte[] k, int kOff, uint[] n)
  {
    for (int index = 0; index < 14; ++index)
      n[index] = X448.Decode32(k, kOff + index * 4);
    n[0] &= 4294967292U;
    n[13] |= 2147483648U /*0x80000000*/;
  }

  public static void GeneratePrivateKey(SecureRandom random, byte[] k)
  {
    if (k.Length != 56)
      throw new ArgumentException(nameof (k));
    random.NextBytes(k);
    k[0] &= (byte) 252;
    k[55] |= (byte) 128 /*0x80*/;
  }

  public static void GeneratePublicKey(byte[] k, int kOff, byte[] r, int rOff)
  {
    X448.ScalarMultBase(k, kOff, r, rOff);
  }

  private static void PointDouble(uint[] x, uint[] z)
  {
    uint[] numArray1 = X448Field.Create();
    uint[] numArray2 = X448Field.Create();
    X448Field.Add(x, z, numArray1);
    X448Field.Sub(x, z, numArray2);
    X448Field.Sqr(numArray1, numArray1);
    X448Field.Sqr(numArray2, numArray2);
    X448Field.Mul(numArray1, numArray2, x);
    X448Field.Sub(numArray1, numArray2, numArray1);
    X448Field.Mul(numArray1, 39082U, z);
    X448Field.Add(z, numArray2, z);
    X448Field.Mul(z, numArray1, z);
  }

  public static void Precompute() => Ed448.Precompute();

  public static void ScalarMult(byte[] k, int kOff, byte[] u, int uOff, byte[] r, int rOff)
  {
    uint[] n = new uint[14];
    X448.DecodeScalar(k, kOff, n);
    uint[] numArray1 = X448Field.Create();
    X448Field.Decode(u, uOff, numArray1);
    uint[] numArray2 = X448Field.Create();
    X448Field.Copy(numArray1, 0, numArray2, 0);
    uint[] numArray3 = X448Field.Create();
    numArray3[0] = 1U;
    uint[] numArray4 = X448Field.Create();
    numArray4[0] = 1U;
    uint[] numArray5 = X448Field.Create();
    uint[] numArray6 = X448Field.Create();
    uint[] numArray7 = X448Field.Create();
    int num1 = 447;
    int num2 = 1;
    do
    {
      X448Field.Add(numArray4, numArray5, numArray6);
      X448Field.Sub(numArray4, numArray5, numArray4);
      X448Field.Add(numArray2, numArray3, numArray5);
      X448Field.Sub(numArray2, numArray3, numArray2);
      X448Field.Mul(numArray6, numArray2, numArray6);
      X448Field.Mul(numArray4, numArray5, numArray4);
      X448Field.Sqr(numArray5, numArray5);
      X448Field.Sqr(numArray2, numArray2);
      X448Field.Sub(numArray5, numArray2, numArray7);
      X448Field.Mul(numArray7, 39082U, numArray3);
      X448Field.Add(numArray3, numArray2, numArray3);
      X448Field.Mul(numArray3, numArray7, numArray3);
      X448Field.Mul(numArray2, numArray5, numArray2);
      X448Field.Sub(numArray6, numArray4, numArray5);
      X448Field.Add(numArray6, numArray4, numArray4);
      X448Field.Sqr(numArray4, numArray4);
      X448Field.Sqr(numArray5, numArray5);
      X448Field.Mul(numArray5, numArray1, numArray5);
      --num1;
      int index = num1 >> 5;
      int num3 = num1 & 31 /*0x1F*/;
      int num4 = (int) (n[index] >> num3) & 1;
      int swap = num2 ^ num4;
      X448Field.CSwap(swap, numArray2, numArray4);
      X448Field.CSwap(swap, numArray3, numArray5);
      num2 = num4;
    }
    while (num1 >= 2);
    for (int index = 0; index < 2; ++index)
      X448.PointDouble(numArray2, numArray3);
    X448Field.Inv(numArray3, numArray3);
    X448Field.Mul(numArray2, numArray3, numArray2);
    X448Field.Normalize(numArray2);
    X448Field.Encode(numArray2, r, rOff);
  }

  public static void ScalarMultBase(byte[] k, int kOff, byte[] r, int rOff)
  {
    uint[] numArray = X448Field.Create();
    uint[] y = X448Field.Create();
    Ed448.ScalarMultBaseXY(k, kOff, numArray, y);
    X448Field.Inv(numArray, numArray);
    X448Field.Mul(numArray, y, numArray);
    X448Field.Sqr(numArray, numArray);
    X448Field.Normalize(numArray);
    X448Field.Encode(numArray, r, rOff);
  }
}
