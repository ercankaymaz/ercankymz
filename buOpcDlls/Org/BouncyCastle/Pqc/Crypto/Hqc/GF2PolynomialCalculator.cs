// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Hqc.GF2PolynomialCalculator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Hqc;

internal class GF2PolynomialCalculator
{
  private readonly int _vecNSize64;
  private readonly int _paramN;
  private readonly long _redMask;

  public GF2PolynomialCalculator(int vecNSize64, int paramN, ulong redMask)
  {
    this._vecNSize64 = vecNSize64;
    this._paramN = paramN;
    this._redMask = (long) redMask;
  }

  internal void MultLongs(long[] res, long[] a, long[] b)
  {
    long[] stack = new long[this._vecNSize64 << 3];
    long[] numArray = new long[(this._vecNSize64 << 1) + 1];
    this.karatsuba(numArray, 0, a, 0, b, 0, this._vecNSize64, stack, 0);
    this.reduce(res, numArray);
  }

  private void base_mul(long[] c, int cOffset, long a, long b)
  {
    long[] numArray1 = new long[16 /*0x10*/];
    long[] numArray2 = new long[4];
    numArray1[0] = 0L;
    numArray1[1] = b & 1152921504606846975L /*0x0FFFFFFFFFFFFFFF*/;
    numArray1[2] = numArray1[1] << 1;
    numArray1[3] = numArray1[2] ^ numArray1[1];
    numArray1[4] = numArray1[2] << 1;
    numArray1[5] = numArray1[4] ^ numArray1[1];
    numArray1[6] = numArray1[3] << 1;
    numArray1[7] = numArray1[6] ^ numArray1[1];
    numArray1[8] = numArray1[4] << 1;
    numArray1[9] = numArray1[8] ^ numArray1[1];
    numArray1[10] = numArray1[5] << 1;
    numArray1[11] = numArray1[10] ^ numArray1[1];
    numArray1[12] = numArray1[6] << 1;
    numArray1[13] = numArray1[12] ^ numArray1[1];
    numArray1[14] = numArray1[7] << 1;
    numArray1[15] = numArray1[14] ^ numArray1[1];
    long num1 = 0;
    long num2 = a & 15L;
    for (int index = 0; index < 16 /*0x10*/; ++index)
    {
      long num3 = num2 - (long) index;
      num1 ^= numArray1[index] & -(1L - ((num3 | -num3) >>> 63 /*0x3F*/));
    }
    long num4 = num1;
    long num5 = 0;
    for (byte index1 = 4; index1 < (byte) 64 /*0x40*/; index1 += (byte) 4)
    {
      long num6 = 0;
      long num7 = a >> (int) index1 & 15L;
      for (int index2 = 0; index2 < 16 /*0x10*/; ++index2)
      {
        long num8 = num7 - (long) index2;
        num6 ^= numArray1[index2] & -(1L - ((num8 | -num8) >>> 63 /*0x3F*/));
      }
      num4 ^= num6 << (int) index1;
      num5 ^= num6 >> 64 /*0x40*/ - (int) index1;
    }
    numArray2[0] = -(b >> 60 & 1L);
    numArray2[1] = -(b >> 61 & 1L);
    numArray2[2] = -(b >> 62 & 1L);
    numArray2[3] = -(b >> 63 /*0x3F*/ & 1L);
    long num9 = num4 ^ a << 60 & numArray2[0];
    long num10 = num5 ^ a >>> 4 & numArray2[0];
    long num11 = num9 ^ a << 61 & numArray2[1];
    long num12 = num10 ^ a >>> 3 & numArray2[1];
    long num13 = num11 ^ a << 62 & numArray2[2];
    long num14 = num12 ^ a >>> 2 & numArray2[2];
    long num15 = num13 ^ a << 63 /*0x3F*/ & numArray2[3];
    long num16 = num14 ^ a >>> 1 & numArray2[3];
    c[cOffset] = num15;
    c[1 + cOffset] = num16;
  }

  private void karatsuba_add1(
    long[] alh,
    int alhOffset,
    long[] blh,
    int blhOffset,
    long[] a,
    int aOffset,
    long[] b,
    int bOffset,
    int size_l,
    int size_h)
  {
    for (int index = 0; index < size_h; ++index)
    {
      alh[index + alhOffset] = a[index + aOffset] ^ a[index + size_l + aOffset];
      blh[index + blhOffset] = b[index + bOffset] ^ b[index + size_l + bOffset];
    }
    if (size_h >= size_l)
      return;
    alh[size_h + alhOffset] = a[size_h + aOffset];
    blh[size_h + blhOffset] = b[size_h + bOffset];
  }

  private void karatsuba_add2(
    long[] o,
    int oOffset,
    long[] tmp1,
    int tmp1Offset,
    long[] tmp2,
    int tmp2Offset,
    int size_l,
    int size_h)
  {
    for (int index = 0; index < 2 * size_l; ++index)
      tmp1[index + tmp1Offset] = tmp1[index + tmp1Offset] ^ o[index + oOffset];
    for (int index = 0; index < 2 * size_h; ++index)
      tmp1[index + tmp1Offset] = tmp1[index + tmp1Offset] ^ tmp2[index + tmp2Offset];
    for (int index = 0; index < 2 * size_l; ++index)
      o[index + size_l + oOffset] = o[index + size_l + oOffset] ^ tmp1[index + tmp1Offset];
  }

  private void karatsuba(
    long[] o,
    int oOffset,
    long[] a,
    int aOffset,
    long[] b,
    int bOffset,
    int size,
    long[] stack,
    int stackOffset)
  {
    if (size == 1)
    {
      this.base_mul(o, oOffset, a[aOffset], b[bOffset]);
    }
    else
    {
      int num1 = size / 2;
      int num2 = (size + 1) / 2;
      int num3 = stackOffset;
      int num4 = num3 + num2;
      int num5 = num4 + num2;
      int num6 = oOffset + num2 * 2;
      stackOffset += 4 * num2;
      int aOffset1 = aOffset + num2;
      int bOffset1 = bOffset + num2;
      this.karatsuba(o, oOffset, a, aOffset, b, bOffset, num2, stack, stackOffset);
      this.karatsuba(o, num6, a, aOffset1, b, bOffset1, num1, stack, stackOffset);
      this.karatsuba_add1(stack, num3, stack, num4, a, aOffset, b, bOffset, num2, num1);
      this.karatsuba(stack, num5, stack, num3, stack, num4, num2, stack, stackOffset);
      this.karatsuba_add2(o, oOffset, stack, num5, o, num6, num2, num1);
    }
  }

  private void reduce(long[] o, long[] a)
  {
    for (int index = 0; index < this._vecNSize64; ++index)
    {
      long num1 = a[index + this._vecNSize64 - 1] >>> (this._paramN & 63 /*0x3F*/);
      long num2 = a[index + this._vecNSize64] << (int) (64L /*0x40*/ - ((long) this._paramN & 63L /*0x3F*/));
      o[index] = a[index] ^ num1 ^ num2;
    }
    o[this._vecNSize64 - 1] &= this._redMask;
  }

  internal static void AddLongs(long[] res, long[] a, long[] b)
  {
    for (int index = 0; index < a.Length; ++index)
      res[index] = a[index] ^ b[index];
  }
}
