// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Fpe.SP80038G
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Fpe;

internal static class SP80038G
{
  internal static readonly string FPE_DISABLED = "Org.BouncyCastle.Fpe.Disable";
  internal static readonly string FF1_DISABLED = "Org.BouncyCastle.Fpe.Disable_Ff1";
  private static readonly int BLOCK_SIZE = 16 /*0x10*/;
  private static readonly double LOG2 = System.Math.Log(2.0);
  private static readonly double TWO_TO_96 = System.Math.Pow(2.0, 96.0);

  public static byte[] DecryptFF1(
    IBlockCipher cipher,
    int radix,
    byte[] tweak,
    byte[] buf,
    int off,
    int len)
  {
    SP80038G.CheckArgs(cipher, true, radix, buf, off, len);
    int n = len;
    int num1 = n / 2;
    int num2 = n - num1;
    ushort[] A = SP80038G.ToShort(buf, off, num1);
    ushort[] B = SP80038G.ToShort(buf, off + num1, num2);
    return SP80038G.ToByte(SP80038G.DecFF1(cipher, radix, tweak, n, num1, num2, A, B));
  }

  public static ushort[] DecryptFF1w(
    IBlockCipher cipher,
    int radix,
    byte[] tweak,
    ushort[] buf,
    int off,
    int len)
  {
    SP80038G.CheckArgs(cipher, true, radix, buf, off, len);
    int n = len;
    int length1 = n / 2;
    int length2 = n - length1;
    ushort[] numArray1 = new ushort[length1];
    ushort[] numArray2 = new ushort[length2];
    Array.Copy((Array) buf, off, (Array) numArray1, 0, length1);
    Array.Copy((Array) buf, off + length1, (Array) numArray2, 0, length2);
    return SP80038G.DecFF1(cipher, radix, tweak, n, length1, length2, numArray1, numArray2);
  }

  private static ushort[] DecFF1(
    IBlockCipher cipher,
    int radix,
    byte[] T,
    int n,
    int u,
    int v,
    ushort[] A,
    ushort[] B)
  {
    int length = T.Length;
    int bFf1 = SP80038G.CalculateB_FF1(radix, v);
    int d = bFf1 + 7 & -4;
    byte[] pFf1 = SP80038G.CalculateP_FF1(radix, (byte) u, n, length);
    BigInteger bigInteger = BigInteger.ValueOf((long) radix);
    BigInteger[] modUv = SP80038G.CalculateModUV(bigInteger, u, v);
    int m1 = u;
    for (int round = 9; round >= 0; --round)
    {
      BigInteger yFf1 = SP80038G.CalculateY_FF1(cipher, bigInteger, T, bFf1, d, round, pFf1, A);
      m1 = n - m1;
      BigInteger m2 = modUv[round & 1];
      BigInteger x = SP80038G.Num(bigInteger, B).Subtract(yFf1).Mod(m2);
      ushort[] output = B;
      B = A;
      A = output;
      SP80038G.Str(bigInteger, x, m1, output, 0);
    }
    return Arrays.Concatenate(A, B);
  }

  public static byte[] DecryptFF3(
    IBlockCipher cipher,
    int radix,
    byte[] tweak64,
    byte[] buf,
    int off,
    int len)
  {
    SP80038G.CheckArgs(cipher, false, radix, buf, off, len);
    if (tweak64.Length != 8)
      throw new ArgumentException();
    return SP80038G.ImplDecryptFF3(cipher, radix, tweak64, buf, off, len);
  }

  public static byte[] DecryptFF3_1(
    IBlockCipher cipher,
    int radix,
    byte[] tweak56,
    byte[] buf,
    int off,
    int len)
  {
    SP80038G.CheckArgs(cipher, false, radix, buf, off, len);
    byte[] tweak64 = tweak56.Length == 7 ? SP80038G.CalculateTweak64_FF3_1(tweak56) : throw new ArgumentException("tweak should be 56 bits");
    return SP80038G.ImplDecryptFF3(cipher, radix, tweak64, buf, off, len);
  }

  public static ushort[] DecryptFF3_1w(
    IBlockCipher cipher,
    int radix,
    byte[] tweak56,
    ushort[] buf,
    int off,
    int len)
  {
    SP80038G.CheckArgs(cipher, false, radix, buf, off, len);
    byte[] tweak64 = tweak56.Length == 7 ? SP80038G.CalculateTweak64_FF3_1(tweak56) : throw new ArgumentException("tweak should be 56 bits");
    return SP80038G.ImplDecryptFF3w(cipher, radix, tweak64, buf, off, len);
  }

  public static byte[] EncryptFF1(
    IBlockCipher cipher,
    int radix,
    byte[] tweak,
    byte[] buf,
    int off,
    int len)
  {
    SP80038G.CheckArgs(cipher, true, radix, buf, off, len);
    int n = len;
    int num1 = n / 2;
    int num2 = n - num1;
    ushort[] A = SP80038G.ToShort(buf, off, num1);
    ushort[] B = SP80038G.ToShort(buf, off + num1, num2);
    return SP80038G.ToByte(SP80038G.EncFF1(cipher, radix, tweak, n, num1, num2, A, B));
  }

  public static ushort[] EncryptFF1w(
    IBlockCipher cipher,
    int radix,
    byte[] tweak,
    ushort[] buf,
    int off,
    int len)
  {
    SP80038G.CheckArgs(cipher, true, radix, buf, off, len);
    int n = len;
    int length1 = n / 2;
    int length2 = n - length1;
    ushort[] numArray1 = new ushort[length1];
    ushort[] numArray2 = new ushort[length2];
    Array.Copy((Array) buf, off, (Array) numArray1, 0, length1);
    Array.Copy((Array) buf, off + length1, (Array) numArray2, 0, length2);
    return SP80038G.EncFF1(cipher, radix, tweak, n, length1, length2, numArray1, numArray2);
  }

  private static ushort[] EncFF1(
    IBlockCipher cipher,
    int radix,
    byte[] T,
    int n,
    int u,
    int v,
    ushort[] A,
    ushort[] B)
  {
    int length = T.Length;
    int bFf1 = SP80038G.CalculateB_FF1(radix, v);
    int d = bFf1 + 7 & -4;
    byte[] pFf1 = SP80038G.CalculateP_FF1(radix, (byte) u, n, length);
    BigInteger bigInteger = BigInteger.ValueOf((long) radix);
    BigInteger[] modUv = SP80038G.CalculateModUV(bigInteger, u, v);
    int m1 = v;
    for (int round = 0; round < 10; ++round)
    {
      BigInteger yFf1 = SP80038G.CalculateY_FF1(cipher, bigInteger, T, bFf1, d, round, pFf1, B);
      m1 = n - m1;
      BigInteger m2 = modUv[round & 1];
      BigInteger x = SP80038G.Num(bigInteger, A).Add(yFf1).Mod(m2);
      ushort[] output = A;
      A = B;
      B = output;
      SP80038G.Str(bigInteger, x, m1, output, 0);
    }
    return Arrays.Concatenate(A, B);
  }

  public static byte[] EncryptFF3(
    IBlockCipher cipher,
    int radix,
    byte[] tweak64,
    byte[] buf,
    int off,
    int len)
  {
    SP80038G.CheckArgs(cipher, false, radix, buf, off, len);
    if (tweak64.Length != 8)
      throw new ArgumentException();
    return SP80038G.ImplEncryptFF3(cipher, radix, tweak64, buf, off, len);
  }

  public static ushort[] EncryptFF3w(
    IBlockCipher cipher,
    int radix,
    byte[] tweak64,
    ushort[] buf,
    int off,
    int len)
  {
    SP80038G.CheckArgs(cipher, false, radix, buf, off, len);
    if (tweak64.Length != 8)
      throw new ArgumentException();
    return SP80038G.ImplEncryptFF3w(cipher, radix, tweak64, buf, off, len);
  }

  public static ushort[] EncryptFF3_1w(
    IBlockCipher cipher,
    int radix,
    byte[] tweak56,
    ushort[] buf,
    int off,
    int len)
  {
    SP80038G.CheckArgs(cipher, false, radix, buf, off, len);
    byte[] tweak64 = tweak56.Length == 7 ? SP80038G.CalculateTweak64_FF3_1(tweak56) : throw new ArgumentException("tweak should be 56 bits");
    return SP80038G.EncryptFF3w(cipher, radix, tweak64, buf, off, len);
  }

  public static byte[] EncryptFF3_1(
    IBlockCipher cipher,
    int radix,
    byte[] tweak56,
    byte[] buf,
    int off,
    int len)
  {
    SP80038G.CheckArgs(cipher, false, radix, buf, off, len);
    byte[] tweak64 = tweak56.Length == 7 ? SP80038G.CalculateTweak64_FF3_1(tweak56) : throw new ArgumentException("tweak should be 56 bits");
    return SP80038G.EncryptFF3(cipher, radix, tweak64, buf, off, len);
  }

  private static int CalculateB_FF1(int radix, int v)
  {
    int num1 = Integers.NumberOfTrailingZeros(radix);
    int num2 = num1 * v;
    int num3 = radix >> num1;
    if (num3 != 1)
      num2 += BigInteger.ValueOf((long) num3).Pow(v).BitLength;
    return (num2 + 7) / 8;
  }

  private static BigInteger[] CalculateModUV(BigInteger bigRadix, int u, int v)
  {
    BigInteger[] modUv = new BigInteger[2]
    {
      bigRadix.Pow(u),
      null
    };
    modUv[1] = modUv[0];
    if (v != u)
      modUv[1] = modUv[1].Multiply(bigRadix);
    return modUv;
  }

  private static byte[] CalculateP_FF1(int radix, byte uLow, int n, int t)
  {
    byte[] bs = new byte[SP80038G.BLOCK_SIZE];
    bs[0] = (byte) 1;
    bs[1] = (byte) 2;
    bs[2] = (byte) 1;
    bs[3] = (byte) 0;
    bs[4] = (byte) (radix >> 8);
    bs[5] = (byte) radix;
    bs[6] = (byte) 10;
    bs[7] = uLow;
    Pack.UInt32_To_BE((uint) n, bs, 8);
    Pack.UInt32_To_BE((uint) t, bs, 12);
    return bs;
  }

  private static byte[] CalculateTweak64_FF3_1(byte[] tweak56)
  {
    return new byte[8]
    {
      tweak56[0],
      tweak56[1],
      tweak56[2],
      (byte) ((uint) tweak56[3] & 240U /*0xF0*/),
      tweak56[4],
      tweak56[5],
      tweak56[6],
      (byte) ((uint) tweak56[3] << 4)
    };
  }

  private static BigInteger CalculateY_FF1(
    IBlockCipher cipher,
    BigInteger bigRadix,
    byte[] T,
    int b,
    int d,
    int round,
    byte[] P,
    ushort[] AB)
  {
    int length = T.Length;
    int num1 = -(length + b + 1) & 15;
    byte[] numArray1 = new byte[length + num1 + 1 + b];
    Array.Copy((Array) T, 0, (Array) numArray1, 0, length);
    numArray1[length + num1] = (byte) round;
    BigIntegers.AsUnsignedByteArray(SP80038G.Num(bigRadix, AB), numArray1, numArray1.Length - b, b);
    byte[] numArray2 = SP80038G.Prf(cipher, Arrays.Concatenate(P, numArray1));
    byte[] numArray3 = numArray2;
    if (d > SP80038G.BLOCK_SIZE)
    {
      int num2 = (d + SP80038G.BLOCK_SIZE - 1) / SP80038G.BLOCK_SIZE;
      numArray3 = new byte[num2 * SP80038G.BLOCK_SIZE];
      uint uint32 = Pack.BE_To_UInt32(numArray2, SP80038G.BLOCK_SIZE - 4);
      Array.Copy((Array) numArray2, 0, (Array) numArray3, 0, SP80038G.BLOCK_SIZE);
      for (uint index = 1; (long) index < (long) num2; ++index)
      {
        int num3 = (int) ((long) index * (long) SP80038G.BLOCK_SIZE);
        Array.Copy((Array) numArray2, 0, (Array) numArray3, num3, SP80038G.BLOCK_SIZE - 4);
        Pack.UInt32_To_BE(uint32 ^ index, numArray3, num3 + SP80038G.BLOCK_SIZE - 4);
        cipher.ProcessBlock(numArray3, num3, numArray3, num3);
      }
    }
    return new BigInteger(1, numArray3, 0, d);
  }

  private static BigInteger CalculateY_FF3(
    IBlockCipher cipher,
    BigInteger bigRadix,
    byte[] T,
    int wOff,
    uint round,
    ushort[] AB)
  {
    byte[] numArray = new byte[SP80038G.BLOCK_SIZE];
    Pack.UInt32_To_BE(Pack.BE_To_UInt32(T, wOff) ^ round, numArray, 0);
    BigIntegers.AsUnsignedByteArray(SP80038G.Num(bigRadix, AB), numArray, 4, SP80038G.BLOCK_SIZE - 4);
    Array.Reverse((Array) numArray);
    cipher.ProcessBlock(numArray, 0, numArray, 0);
    Array.Reverse((Array) numArray);
    return new BigInteger(1, numArray);
  }

  private static void CheckArgs(
    IBlockCipher cipher,
    bool isFF1,
    int radix,
    ushort[] buf,
    int off,
    int len)
  {
    SP80038G.CheckCipher(cipher);
    if (radix < 2 || radix > 65536 /*0x010000*/)
      throw new ArgumentException();
    SP80038G.CheckData(isFF1, radix, buf, off, len);
  }

  private static void CheckArgs(
    IBlockCipher cipher,
    bool isFF1,
    int radix,
    byte[] buf,
    int off,
    int len)
  {
    SP80038G.CheckCipher(cipher);
    if (radix < 2 || radix > 256 /*0x0100*/)
      throw new ArgumentException();
    SP80038G.CheckData(isFF1, radix, buf, off, len);
  }

  private static void CheckCipher(IBlockCipher cipher)
  {
    if (SP80038G.BLOCK_SIZE != cipher.GetBlockSize())
      throw new ArgumentException();
  }

  private static void CheckData(bool isFF1, int radix, ushort[] buf, int off, int len)
  {
    SP80038G.CheckLength(isFF1, radix, len);
    for (int index = 0; index < len; ++index)
    {
      if (((int) buf[off + index] & (int) ushort.MaxValue) >= radix)
        throw new ArgumentException("input data outside of radix");
    }
  }

  private static void CheckData(bool isFF1, int radix, byte[] buf, int off, int len)
  {
    SP80038G.CheckLength(isFF1, radix, len);
    for (int index = 0; index < len; ++index)
    {
      if (((int) buf[off + index] & (int) byte.MaxValue) >= radix)
        throw new ArgumentException("input data outside of radix");
    }
  }

  private static void CheckLength(bool isFF1, int radix, int len)
  {
    if (len < 2 || System.Math.Pow((double) radix, (double) len) < 1000000.0)
      throw new ArgumentException("input too short");
    if (isFF1)
      return;
    int num = 2 * (int) System.Math.Floor(System.Math.Log(SP80038G.TWO_TO_96) / System.Math.Log((double) radix));
    if (len > num)
      throw new ArgumentException("maximum input length is " + num.ToString());
  }

  private static byte[] ImplDecryptFF3(
    IBlockCipher cipher,
    int radix,
    byte[] tweak64,
    byte[] buf,
    int off,
    int len)
  {
    byte[] T = tweak64;
    int n = len;
    int num1 = n / 2;
    int num2 = n - num1;
    ushort[] A = SP80038G.ToShort(buf, off, num2);
    ushort[] B = SP80038G.ToShort(buf, off + num2, num1);
    return SP80038G.ToByte(SP80038G.DecFF3_1(cipher, radix, T, n, num1, num2, A, B));
  }

  private static ushort[] ImplDecryptFF3w(
    IBlockCipher cipher,
    int radix,
    byte[] tweak64,
    ushort[] buf,
    int off,
    int len)
  {
    byte[] T = tweak64;
    int n = len;
    int length1 = n / 2;
    int length2 = n - length1;
    ushort[] numArray1 = new ushort[length2];
    ushort[] numArray2 = new ushort[length1];
    Array.Copy((Array) buf, off, (Array) numArray1, 0, length2);
    Array.Copy((Array) buf, off + length2, (Array) numArray2, 0, length1);
    return SP80038G.DecFF3_1(cipher, radix, T, n, length1, length2, numArray1, numArray2);
  }

  private static ushort[] DecFF3_1(
    IBlockCipher cipher,
    int radix,
    byte[] T,
    int n,
    int v,
    int u,
    ushort[] A,
    ushort[] B)
  {
    BigInteger bigInteger = BigInteger.ValueOf((long) radix);
    BigInteger[] modUv = SP80038G.CalculateModUV(bigInteger, v, u);
    int m1 = u;
    Array.Reverse((Array) A);
    Array.Reverse((Array) B);
    for (int round = 7; round >= 0; --round)
    {
      m1 = n - m1;
      BigInteger m2 = modUv[1 - (round & 1)];
      int wOff = 4 - (round & 1) * 4;
      BigInteger yFf3 = SP80038G.CalculateY_FF3(cipher, bigInteger, T, wOff, (uint) round, A);
      BigInteger x = SP80038G.Num(bigInteger, B).Subtract(yFf3).Mod(m2);
      ushort[] output = B;
      B = A;
      A = output;
      SP80038G.Str(bigInteger, x, m1, output, 0);
    }
    Array.Reverse((Array) A);
    Array.Reverse((Array) B);
    return Arrays.Concatenate(A, B);
  }

  private static byte[] ImplEncryptFF3(
    IBlockCipher cipher,
    int radix,
    byte[] tweak64,
    byte[] buf,
    int off,
    int len)
  {
    byte[] t = tweak64;
    int n = len;
    int num1 = n / 2;
    int num2 = n - num1;
    ushort[] a = SP80038G.ToShort(buf, off, num2);
    ushort[] b = SP80038G.ToShort(buf, off + num2, num1);
    return SP80038G.ToByte(SP80038G.EncFF3_1(cipher, radix, t, n, num1, num2, a, b));
  }

  private static ushort[] ImplEncryptFF3w(
    IBlockCipher cipher,
    int radix,
    byte[] tweak64,
    ushort[] buf,
    int off,
    int len)
  {
    byte[] t = tweak64;
    int n = len;
    int length1 = n / 2;
    int length2 = n - length1;
    ushort[] numArray1 = new ushort[length2];
    ushort[] numArray2 = new ushort[length1];
    Array.Copy((Array) buf, off, (Array) numArray1, 0, length2);
    Array.Copy((Array) buf, off + length2, (Array) numArray2, 0, length1);
    return SP80038G.EncFF3_1(cipher, radix, t, n, length1, length2, numArray1, numArray2);
  }

  private static ushort[] EncFF3_1(
    IBlockCipher cipher,
    int radix,
    byte[] t,
    int n,
    int v,
    int u,
    ushort[] a,
    ushort[] b)
  {
    BigInteger bigInteger = BigInteger.ValueOf((long) radix);
    BigInteger[] modUv = SP80038G.CalculateModUV(bigInteger, v, u);
    int m1 = v;
    Array.Reverse((Array) a);
    Array.Reverse((Array) b);
    for (uint round = 0; round < 8U; ++round)
    {
      m1 = n - m1;
      BigInteger m2 = modUv[1 - ((int) round & 1)];
      int wOff = 4 - ((int) round & 1) * 4;
      BigInteger yFf3 = SP80038G.CalculateY_FF3(cipher, bigInteger, t, wOff, round, b);
      BigInteger x = SP80038G.Num(bigInteger, a).Add(yFf3).Mod(m2);
      ushort[] output = a;
      a = b;
      b = output;
      SP80038G.Str(bigInteger, x, m1, output, 0);
    }
    Array.Reverse((Array) a);
    Array.Reverse((Array) b);
    return Arrays.Concatenate(a, b);
  }

  private static BigInteger Num(BigInteger R, ushort[] x)
  {
    BigInteger bigInteger = BigInteger.Zero;
    for (int index = 0; index < x.Length; ++index)
      bigInteger = bigInteger.Multiply(R).Add(BigInteger.ValueOf((long) ((int) x[index] & (int) ushort.MaxValue)));
    return bigInteger;
  }

  private static byte[] Prf(IBlockCipher c, byte[] x)
  {
    if (x.Length % SP80038G.BLOCK_SIZE != 0)
      throw new ArgumentException();
    int num = x.Length / SP80038G.BLOCK_SIZE;
    byte[] numArray = new byte[SP80038G.BLOCK_SIZE];
    for (int index = 0; index < num; ++index)
    {
      Bytes.XorTo(SP80038G.BLOCK_SIZE, x, index * SP80038G.BLOCK_SIZE, numArray, 0);
      c.ProcessBlock(numArray, 0, numArray, 0);
    }
    return numArray;
  }

  private static void Str(BigInteger R, BigInteger x, int m, ushort[] output, int off)
  {
    if (x.SignValue < 0)
      throw new ArgumentException();
    for (int index = 1; index <= m; ++index)
    {
      BigInteger[] bigIntegerArray = x.DivideAndRemainder(R);
      output[off + m - index] = (ushort) bigIntegerArray[1].IntValue;
      x = bigIntegerArray[0];
    }
    if (x.SignValue != 0)
      throw new ArgumentException();
  }

  private static byte[] ToByte(ushort[] buf)
  {
    byte[] numArray = new byte[buf.Length];
    for (int index = 0; index != numArray.Length; ++index)
      numArray[index] = (byte) buf[index];
    return numArray;
  }

  private static ushort[] ToShort(byte[] buf, int off, int len)
  {
    ushort[] numArray = new ushort[len];
    for (int index = 0; index != numArray.Length; ++index)
      numArray[index] = (ushort) ((uint) buf[off + index] & (uint) byte.MaxValue);
    return numArray;
  }
}
