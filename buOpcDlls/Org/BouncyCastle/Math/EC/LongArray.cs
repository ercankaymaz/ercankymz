// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.LongArray
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.Raw;
using Org.BouncyCastle.Utilities;
using System;
using System.Text;

#nullable disable
namespace Org.BouncyCastle.Math.EC;

internal struct LongArray
{
  private ulong[] m_data;

  internal static bool AreAliased(ref LongArray a, ref LongArray b) => a.m_data == b.m_data;

  internal LongArray(int intLen) => this.m_data = new ulong[intLen];

  internal LongArray(ulong[] data) => this.m_data = data;

  internal LongArray(ulong[] data, int off, int len)
  {
    if (off == 0 && len == data.Length)
    {
      this.m_data = data;
    }
    else
    {
      this.m_data = new ulong[len];
      Array.Copy((Array) data, off, (Array) this.m_data, 0, len);
    }
  }

  internal LongArray(BigInteger bigInt)
  {
    if (bigInt == null || bigInt.SignValue < 0)
      throw new ArgumentException("invalid F2m field value", nameof (bigInt));
    if (bigInt.SignValue == 0)
    {
      this.m_data = new ulong[1];
    }
    else
    {
      byte[] byteArray = bigInt.ToByteArray();
      int length1 = byteArray.Length;
      int num1 = 0;
      if (byteArray[0] == (byte) 0)
      {
        --length1;
        num1 = 1;
      }
      int length2 = (length1 + 7) / 8;
      this.m_data = new ulong[length2];
      int index1 = length2 - 1;
      int num2 = length1 % 8 + num1;
      ulong num3 = 0;
      int index2 = num1;
      if (num1 < num2)
      {
        for (; index2 < num2; ++index2)
          num3 = num3 << 8 | (ulong) byteArray[index2];
        this.m_data[index1--] = num3;
      }
      for (; index1 >= 0; --index1)
      {
        ulong num4 = 0;
        for (int index3 = 0; index3 < 8; ++index3)
          num4 = num4 << 8 | (ulong) byteArray[index2++];
        this.m_data[index1] = num4;
      }
    }
  }

  internal void CopyTo(ulong[] z, int zOff)
  {
    Array.Copy((Array) this.m_data, 0, (Array) z, zOff, this.m_data.Length);
  }

  internal bool IsOne()
  {
    ulong[] data = this.m_data;
    int length = data.Length;
    if (length < 1 || data[0] != 1UL)
      return false;
    for (int index = 1; index < length; ++index)
    {
      if (data[index] != 0UL)
        return false;
    }
    return true;
  }

  internal bool IsZero()
  {
    foreach (ulong num in this.m_data)
    {
      if (num != 0UL)
        return false;
    }
    return true;
  }

  internal int GetUsedLength() => this.GetUsedLengthFrom(this.m_data.Length);

  internal int GetUsedLengthFrom(int from)
  {
    ulong[] data = this.m_data;
    from = System.Math.Min(from, data.Length);
    if (from < 1)
      return 0;
    if (data[0] != 0UL)
    {
      do
        ;
      while (data[--from] == 0UL);
      return from + 1;
    }
    while (data[--from] == 0UL)
    {
      if (from <= 0)
        return 0;
    }
    return from + 1;
  }

  internal int Degree()
  {
    int length = this.m_data.Length;
    while (length != 0)
    {
      ulong w = this.m_data[--length];
      if (w != 0UL)
        return (length << 6) + LongArray.BitLength(w);
    }
    return 0;
  }

  private int DegreeFrom(int limit)
  {
    int num = limit + 62 >>> 6;
    while (num != 0)
    {
      ulong w = this.m_data[--num];
      if (w != 0UL)
        return (num << 6) + LongArray.BitLength(w);
    }
    return 0;
  }

  private static int BitLength(ulong w) => 64 /*0x40*/ - Longs.NumberOfLeadingZeros((long) w);

  private ulong[] ResizedData(int newLen)
  {
    ulong[] destinationArray = new ulong[newLen];
    Array.Copy((Array) this.m_data, 0, (Array) destinationArray, 0, System.Math.Min(this.m_data.Length, newLen));
    return destinationArray;
  }

  internal BigInteger ToBigInteger()
  {
    int usedLength = this.GetUsedLength();
    if (usedLength == 0)
      return BigInteger.Zero;
    ulong num1 = this.m_data[usedLength - 1];
    byte[] numArray = new byte[8];
    int num2 = 0;
    bool flag = false;
    for (int index = 7; index >= 0; --index)
    {
      byte num3 = (byte) (num1 >> 8 * index);
      if (flag || num3 != (byte) 0)
      {
        flag = true;
        numArray[num2++] = num3;
      }
    }
    byte[] bytes = new byte[8 * (usedLength - 1) + num2];
    for (int index = 0; index < num2; ++index)
      bytes[index] = numArray[index];
    for (int index1 = usedLength - 2; index1 >= 0; --index1)
    {
      ulong num4 = this.m_data[index1];
      for (int index2 = 7; index2 >= 0; --index2)
        bytes[num2++] = (byte) (num4 >> 8 * index2);
    }
    return new BigInteger(1, bytes);
  }

  private static ulong ShiftUp(ulong[] x, int xOff, int count, int shift)
  {
    int num1 = 64 /*0x40*/ - shift;
    ulong num2 = 0;
    for (int index = 0; index < count; ++index)
    {
      ulong num3 = x[xOff + index];
      x[xOff + index] = num3 << shift | num2;
      num2 = num3 >> num1;
    }
    return num2;
  }

  private static ulong ShiftUp(ulong[] x, int xOff, ulong[] z, int zOff, int count, int shift)
  {
    int num1 = 64 /*0x40*/ - shift;
    ulong num2 = 0;
    for (int index = 0; index < count; ++index)
    {
      ulong num3 = x[xOff + index];
      z[zOff + index] = num3 << shift | num2;
      num2 = num3 >> num1;
    }
    return num2;
  }

  internal LongArray AddOne()
  {
    if (this.m_data.Length == 0)
      return new LongArray(new ulong[1]{ 1UL });
    ulong[] data = this.ResizedData(System.Math.Max(1, this.GetUsedLength()));
    data[0] ^= 1UL;
    return new LongArray(data);
  }

  private void AddShiftedByBitsSafe(LongArray other, int otherDegree, int bits)
  {
    int count = otherDegree + 63 /*0x3F*/ >>> 6;
    int xOff = bits >>> 6;
    int shift = bits & 63 /*0x3F*/;
    if (shift == 0)
    {
      LongArray.Add(this.m_data, xOff, other.m_data, 0, count);
    }
    else
    {
      ulong num = LongArray.AddShiftedUp(this.m_data, xOff, other.m_data, 0, count, shift);
      if (num == 0UL)
        return;
      this.m_data[count + xOff] ^= num;
    }
  }

  private static ulong AddShiftedUp(
    ulong[] x,
    int xOff,
    ulong[] y,
    int yOff,
    int count,
    int shift)
  {
    int num1 = 64 /*0x40*/ - shift;
    ulong num2 = 0;
    for (int index = 0; index < count; ++index)
    {
      ulong num3 = y[yOff + index];
      x[xOff + index] ^= num3 << shift | num2;
      num2 = num3 >> num1;
    }
    return num2;
  }

  private static ulong AddShiftedDown(
    ulong[] x,
    int xOff,
    ulong[] y,
    int yOff,
    int count,
    int shift)
  {
    int num1 = 64 /*0x40*/ - shift;
    ulong num2 = 0;
    int num3 = count;
    while (--num3 >= 0)
    {
      ulong num4 = y[yOff + num3];
      x[xOff + num3] ^= num4 >> shift | num2;
      num2 = num4 << num1;
    }
    return num2;
  }

  internal void AddShiftedByWords(LongArray other, int words)
  {
    int usedLength = other.GetUsedLength();
    if (usedLength == 0)
      return;
    int newLen = usedLength + words;
    if (newLen > this.m_data.Length)
      this.m_data = this.ResizedData(newLen);
    LongArray.Add(this.m_data, words, other.m_data, 0, usedLength);
  }

  private static void Add(ulong[] x, int xOff, ulong[] y, int yOff, int count)
  {
    Nat.XorTo64(count, y, yOff, x, xOff);
  }

  private static void Add(
    ulong[] x,
    int xOff,
    ulong[] y,
    int yOff,
    ulong[] z,
    int zOff,
    int count)
  {
    Nat.Xor64(count, x, xOff, y, yOff, z, zOff);
  }

  private static void AddBoth(
    ulong[] x,
    int xOff,
    ulong[] y1,
    int y1Off,
    ulong[] y2,
    int y2Off,
    int count)
  {
    for (int index = 0; index < count; ++index)
      x[xOff + index] ^= y1[y1Off + index] ^ y2[y2Off + index];
  }

  private static void FlipWord(ulong[] buf, int off, int bit, ulong word)
  {
    int index = off + (bit >>> 6);
    int num1 = bit & 63 /*0x3F*/;
    if (num1 == 0)
    {
      buf[index] ^= word;
    }
    else
    {
      buf[index] ^= word << num1;
      word >>= 64 /*0x40*/ - num1;
      if (word == 0UL)
        return;
      int num2;
      buf[num2 = index + 1] ^= word;
    }
  }

  internal bool TestBitZero() => this.m_data.Length != 0 && (this.m_data[0] & 1UL) > 0UL;

  private static bool TestBit(ulong[] buf, int off, int n)
  {
    int num1 = n >>> 6;
    ulong num2 = (ulong) (1L << n);
    return (buf[off + num1] & num2) > 0UL;
  }

  private static void FlipBit(ulong[] buf, int off, int n)
  {
    int num1 = n >>> 6;
    ulong num2 = (ulong) (1L << n);
    buf[off + num1] ^= num2;
  }

  private static void MultiplyWord(ulong a, ulong[] b, int bLen, ulong[] c, int cOff)
  {
    if (((long) a & 1L) != 0L)
      LongArray.Add(c, cOff, b, 0, bLen);
    int shift = 1;
    while ((a >>= 1) != 0UL)
    {
      if (((long) a & 1L) != 0L)
      {
        ulong num = LongArray.AddShiftedUp(c, cOff, b, 0, bLen, shift);
        if (num != 0UL)
          c[cOff + bLen] ^= num;
      }
      ++shift;
    }
  }

  internal LongArray ModMultiplyLD(LongArray other, int m, int[] ks)
  {
    int num1 = this.Degree();
    if (num1 == 0)
      return this;
    int num2 = other.Degree();
    if (num2 == 0)
      return other;
    LongArray longArray1 = this;
    LongArray longArray2 = other;
    if (num1 > num2)
    {
      longArray1 = other;
      longArray2 = this;
      int num3 = num1;
      num1 = num2;
      num2 = num3;
    }
    int num4 = num1 + 63 /*0x3F*/ >>> 6;
    int num5 = num2 + 63 /*0x3F*/ >>> 6;
    int length = num1 + num2 + 62 >>> 6;
    if (num4 == 1)
    {
      ulong a = longArray1.m_data[0];
      if (a == 1UL)
        return longArray2;
      ulong[] numArray = new ulong[length];
      LongArray.MultiplyWord(a, longArray2.m_data, num5, numArray, 0);
      return LongArray.ReduceResult(numArray, 0, length, m, ks);
    }
    int num6 = num2 + 7 + 63 /*0x3F*/ >>> 6;
    int[] numArray1 = new int[16 /*0x10*/];
    ulong[] numArray2 = new ulong[num6 << 4];
    int num7 = num6;
    numArray1[1] = num7;
    Array.Copy((Array) longArray2.m_data, 0, (Array) numArray2, num7, num5);
    for (int index = 2; index < 16 /*0x10*/; ++index)
    {
      numArray1[index] = (num7 += num6);
      if ((index & 1) == 0)
      {
        long num8 = (long) LongArray.ShiftUp(numArray2, num7 >>> 1, numArray2, num7, num6, 1);
      }
      else
        LongArray.Add(numArray2, num6, numArray2, num7 - num6, numArray2, num7, num6);
    }
    ulong[] numArray3 = new ulong[numArray2.Length];
    long num9 = (long) LongArray.ShiftUp(numArray2, 0, numArray3, 0, numArray2.Length, 4);
    ulong[] data = longArray1.m_data;
    ulong[] numArray4 = new ulong[length];
    uint num10 = 15;
    for (int index1 = 56; index1 >= 0; index1 -= 8)
    {
      for (int index2 = 1; index2 < num4; index2 += 2)
      {
        int num11 = (int) (uint) (data[index2] >> index1);
        uint index3 = (uint) num11 & num10;
        uint index4 = (uint) (num11 >>> 4) & num10;
        LongArray.AddBoth(numArray4, index2 - 1, numArray2, numArray1[(int) index3], numArray3, numArray1[(int) index4], num6);
      }
      long num12 = (long) LongArray.ShiftUp(numArray4, 0, length, 8);
    }
    for (int index5 = 56; index5 >= 0; index5 -= 8)
    {
      for (int xOff = 0; xOff < num4; xOff += 2)
      {
        int num13 = (int) (uint) (data[xOff] >> index5);
        uint index6 = (uint) num13 & num10;
        uint index7 = (uint) (num13 >>> 4) & num10;
        LongArray.AddBoth(numArray4, xOff, numArray2, numArray1[(int) index6], numArray3, numArray1[(int) index7], num6);
      }
      if (index5 > 0)
      {
        long num14 = (long) LongArray.ShiftUp(numArray4, 0, length, 8);
      }
    }
    return LongArray.ReduceResult(numArray4, 0, length, m, ks);
  }

  internal LongArray ModMultiply(LongArray other, int m, int[] ks)
  {
    int num1 = this.Degree();
    if (num1 == 0)
      return this;
    int num2 = other.Degree();
    if (num2 == 0)
      return other;
    LongArray longArray1 = this;
    LongArray longArray2 = other;
    if (num1 > num2)
    {
      longArray1 = other;
      longArray2 = this;
      int num3 = num1;
      num1 = num2;
      num2 = num3;
    }
    int num4 = num1 + 63 /*0x3F*/ >>> 6;
    int num5 = num2 + 63 /*0x3F*/ >>> 6;
    int length1 = num1 + num2 + 62 >>> 6;
    if (num4 == 1)
    {
      ulong a = longArray1.m_data[0];
      if (a == 1UL)
        return longArray2;
      ulong[] numArray = new ulong[length1];
      LongArray.MultiplyWord(a, longArray2.m_data, num5, numArray, 0);
      return LongArray.ReduceResult(numArray, 0, length1, m, ks);
    }
    int num6 = num2 + 7 + 63 /*0x3F*/ >>> 6;
    int[] numArray1 = new int[16 /*0x10*/];
    ulong[] numArray2 = new ulong[num6 << 4];
    int num7 = num6;
    numArray1[1] = num7;
    Array.Copy((Array) longArray2.m_data, 0, (Array) numArray2, num7, num5);
    for (int index = 2; index < 16 /*0x10*/; ++index)
    {
      num7 += num6;
      numArray1[index] = num7;
      if ((index & 1) == 0)
      {
        long num8 = (long) LongArray.ShiftUp(numArray2, num7 >>> 1, numArray2, num7, num6, 1);
      }
      else
        LongArray.Add(numArray2, num6, numArray2, num7 - num6, numArray2, num7, num6);
    }
    ulong[] numArray3 = new ulong[numArray2.Length];
    long num9 = (long) LongArray.ShiftUp(numArray2, 0, numArray3, 0, numArray2.Length, 4);
    ulong[] data = longArray1.m_data;
    ulong[] numArray4 = new ulong[length1 << 3];
    uint num10 = 15;
    for (int index1 = 0; index1 < num4; ++index1)
    {
      ulong num11 = data[index1];
      int xOff = index1;
      while (true)
      {
        uint index2 = (uint) num11 & num10;
        ulong num12 = num11 >> 4;
        uint index3 = (uint) num12 & num10;
        num11 = num12 >> 4;
        LongArray.AddBoth(numArray4, xOff, numArray2, numArray1[(int) index2], numArray3, numArray1[(int) index3], num6);
        if (num11 != 0UL)
          xOff += length1;
        else
          break;
      }
    }
    int length2 = numArray4.Length;
    while ((length2 -= length1) != 0)
    {
      long num13 = (long) LongArray.AddShiftedUp(numArray4, length2 - length1, numArray4, length2, length1, 8);
    }
    return LongArray.ReduceResult(numArray4, 0, length1, m, ks);
  }

  internal LongArray Multiply(LongArray other, int m, int[] ks)
  {
    int num1 = this.Degree();
    if (num1 == 0)
      return this;
    int num2 = other.Degree();
    if (num2 == 0)
      return other;
    LongArray longArray1 = this;
    LongArray longArray2 = other;
    if (num1 > num2)
    {
      longArray1 = other;
      longArray2 = this;
      int num3 = num1;
      num1 = num2;
      num2 = num3;
    }
    int num4 = num1 + 63 /*0x3F*/ >>> 6;
    int num5 = num2 + 63 /*0x3F*/ >>> 6;
    int length1 = num1 + num2 + 62 >>> 6;
    if (num4 == 1)
    {
      ulong a = longArray1.m_data[0];
      if (a == 1UL)
        return longArray2;
      ulong[] numArray = new ulong[length1];
      LongArray.MultiplyWord(a, longArray2.m_data, num5, numArray, 0);
      return new LongArray(numArray, 0, length1);
    }
    int num6 = num2 + 7 + 63 /*0x3F*/ >>> 6;
    int[] numArray1 = new int[16 /*0x10*/];
    ulong[] numArray2 = new ulong[num6 << 4];
    int num7 = num6;
    numArray1[1] = num7;
    Array.Copy((Array) longArray2.m_data, 0, (Array) numArray2, num7, num5);
    for (int index = 2; index < 16 /*0x10*/; ++index)
    {
      num7 += num6;
      numArray1[index] = num7;
      if ((index & 1) == 0)
      {
        long num8 = (long) LongArray.ShiftUp(numArray2, num7 >>> 1, numArray2, num7, num6, 1);
      }
      else
        LongArray.Add(numArray2, num6, numArray2, num7 - num6, numArray2, num7, num6);
    }
    ulong[] numArray3 = new ulong[numArray2.Length];
    long num9 = (long) LongArray.ShiftUp(numArray2, 0, numArray3, 0, numArray2.Length, 4);
    ulong[] data = longArray1.m_data;
    ulong[] numArray4 = new ulong[length1 << 3];
    uint num10 = 15;
    for (int index1 = 0; index1 < num4; ++index1)
    {
      ulong num11 = data[index1];
      int xOff = index1;
      while (true)
      {
        uint index2 = (uint) num11 & num10;
        ulong num12 = num11 >> 4;
        uint index3 = (uint) num12 & num10;
        num11 = num12 >> 4;
        LongArray.AddBoth(numArray4, xOff, numArray2, numArray1[(int) index2], numArray3, numArray1[(int) index3], num6);
        if (num11 != 0UL)
          xOff += length1;
        else
          break;
      }
    }
    int length2 = numArray4.Length;
    while ((length2 -= length1) != 0)
    {
      long num13 = (long) LongArray.AddShiftedUp(numArray4, length2 - length1, numArray4, length2, length1, 8);
    }
    return new LongArray(numArray4, 0, length1);
  }

  internal void Reduce(int m, int[] ks)
  {
    ulong[] data = this.m_data;
    int length = LongArray.ReduceInPlace(data, 0, data.Length, m, ks);
    if (length >= data.Length)
      return;
    this.m_data = new ulong[length];
    Array.Copy((Array) data, 0, (Array) this.m_data, 0, length);
  }

  private static LongArray ReduceResult(ulong[] buf, int off, int len, int m, int[] ks)
  {
    int len1 = LongArray.ReduceInPlace(buf, off, len, m, ks);
    return new LongArray(buf, off, len1);
  }

  private static int ReduceInPlace(ulong[] buf, int off, int len, int m, int[] ks)
  {
    int num1 = m + 63 /*0x3F*/ >> 6;
    if (len < num1)
      return len;
    int BitLength = System.Math.Min(len << 6, (m << 1) - 1);
    int num2;
    for (num2 = (len << 6) - BitLength; num2 >= 64 /*0x40*/; num2 -= 64 /*0x40*/)
      --len;
    int length = ks.Length;
    int k1 = ks[length - 1];
    int k2 = length > 1 ? ks[length - 2] : 0;
    int toBit = System.Math.Max(m, k1 + 64 /*0x40*/);
    int num3 = num2 + System.Math.Min(BitLength - toBit, m - k2) >> 6;
    if (num3 > 1)
    {
      int words = len - num3;
      LongArray.ReduceVectorWise(buf, off, len, words, m, ks);
      while (len > words)
        buf[off + --len] = 0UL;
      BitLength = words << 6;
    }
    if (BitLength > toBit)
    {
      LongArray.ReduceWordWise(buf, off, len, toBit, m, ks);
      BitLength = toBit;
    }
    if (BitLength > m)
      LongArray.ReduceBitWise(buf, off, BitLength, m, ks);
    return num1;
  }

  private static void ReduceBitWise(ulong[] buf, int off, int BitLength, int m, int[] ks)
  {
    while (--BitLength >= m)
    {
      if (LongArray.TestBit(buf, off, BitLength))
        LongArray.ReduceBit(buf, off, BitLength, m, ks);
    }
  }

  private static void ReduceBit(ulong[] buf, int off, int bit, int m, int[] ks)
  {
    LongArray.FlipBit(buf, off, bit);
    int n = bit - m;
    int length = ks.Length;
    while (--length >= 0)
      LongArray.FlipBit(buf, off, ks[length] + n);
    LongArray.FlipBit(buf, off, n);
  }

  private static void ReduceWordWise(ulong[] buf, int off, int len, int toBit, int m, int[] ks)
  {
    int num1 = toBit >>> 6;
    while (--len > num1)
    {
      ulong word = buf[off + len];
      if (word != 0UL)
      {
        buf[off + len] = 0UL;
        LongArray.ReduceWord(buf, off, len << 6, word, m, ks);
      }
    }
    int num2 = toBit & 63 /*0x3F*/;
    ulong word1 = buf[off + num1] >> num2;
    if (word1 == 0UL)
      return;
    buf[off + num1] ^= word1 << num2;
    LongArray.ReduceWord(buf, off, toBit, word1, m, ks);
  }

  private static void ReduceWord(ulong[] buf, int off, int bit, ulong word, int m, int[] ks)
  {
    int bit1 = bit - m;
    int length = ks.Length;
    while (--length >= 0)
      LongArray.FlipWord(buf, off, bit1 + ks[length], word);
    LongArray.FlipWord(buf, off, bit1, word);
  }

  private static void ReduceVectorWise(
    ulong[] buf,
    int off,
    int len,
    int words,
    int m,
    int[] ks)
  {
    int bits = (words << 6) - m;
    int length = ks.Length;
    while (--length >= 0)
      LongArray.FlipVector(buf, off, buf, off + words, len - words, bits + ks[length]);
    LongArray.FlipVector(buf, off, buf, off + words, len - words, bits);
  }

  private static void FlipVector(ulong[] x, int xOff, ulong[] y, int yOff, int yLen, int bits)
  {
    xOff += bits >>> 6;
    bits &= 63 /*0x3F*/;
    if (bits == 0)
    {
      LongArray.Add(x, xOff, y, yOff, yLen);
    }
    else
    {
      ulong num = LongArray.AddShiftedDown(x, xOff + 1, y, yOff, yLen, 64 /*0x40*/ - bits);
      x[xOff] ^= num;
    }
  }

  internal LongArray ModSquare(int m, int[] ks)
  {
    int usedLength = this.GetUsedLength();
    if (usedLength == 0)
      return this;
    ulong[] numArray = new ulong[usedLength << 1];
    Interleave.Expand64To128(this.m_data, 0, usedLength, numArray, 0);
    return new LongArray(numArray, 0, LongArray.ReduceInPlace(numArray, 0, numArray.Length, m, ks));
  }

  internal LongArray ModSquareN(int n, int m, int[] ks)
  {
    int num = this.GetUsedLength();
    if (num == 0)
      return this;
    ulong[] numArray = new ulong[m + 63 /*0x3F*/ >> 6 << 1];
    Array.Copy((Array) this.m_data, 0, (Array) numArray, 0, num);
    while (--n >= 0)
    {
      Interleave.Expand64To128(numArray, 0, num, numArray, 0);
      num = LongArray.ReduceInPlace(numArray, 0, numArray.Length, m, ks);
    }
    return new LongArray(numArray, 0, num);
  }

  internal LongArray Square(int m, int[] ks)
  {
    int usedLength = this.GetUsedLength();
    if (usedLength == 0)
      return this;
    ulong[] numArray = new ulong[usedLength << 1];
    Interleave.Expand64To128(this.m_data, 0, usedLength, numArray, 0);
    return new LongArray(numArray, 0, numArray.Length);
  }

  internal LongArray ModInverse(int m, int[] ks)
  {
    int num1 = this.Degree();
    switch (num1)
    {
      case 0:
        throw new InvalidOperationException();
      case 1:
        return this;
      default:
        LongArray longArray1 = this.Copy();
        int intLen = m + 63 /*0x3F*/ >> 6;
        LongArray longArray2 = new LongArray(intLen);
        LongArray.ReduceBit(longArray2.m_data, 0, m, m, ks);
        LongArray longArray3 = new LongArray(intLen);
        longArray3.m_data[0] = 1UL;
        LongArray longArray4 = new LongArray(intLen);
        int[] numArray1 = new int[2]{ num1, m + 1 };
        LongArray[] longArrayArray1 = new LongArray[2]
        {
          longArray1,
          longArray2
        };
        int[] numArray2 = new int[2]{ 1, 0 };
        LongArray[] longArrayArray2 = new LongArray[2]
        {
          longArray3,
          longArray4
        };
        int index = 1;
        int limit1 = numArray1[1];
        int limit2 = numArray2[1];
        int bits = limit1 - numArray1[0];
        while (true)
        {
          if (bits < 0)
            goto label_10;
label_4:
          longArrayArray1[index].AddShiftedByBitsSafe(longArrayArray1[1 - index], numArray1[1 - index], bits);
          int num2 = longArrayArray1[index].DegreeFrom(limit1);
          if (num2 != 0)
          {
            int otherDegree = numArray2[1 - index];
            longArrayArray2[index].AddShiftedByBitsSafe(longArrayArray2[1 - index], otherDegree, bits);
            int num3 = otherDegree + bits;
            if (num3 > limit2)
              limit2 = num3;
            else if (num3 == limit2)
              limit2 = longArrayArray2[index].DegreeFrom(limit2);
            bits += num2 - limit1;
            limit1 = num2;
            continue;
          }
          break;
label_10:
          bits = -bits;
          numArray1[index] = limit1;
          numArray2[index] = limit2;
          index = 1 - index;
          limit1 = numArray1[index];
          limit2 = numArray2[index];
          goto label_4;
        }
        return longArrayArray2[1 - index];
    }
  }

  public override bool Equals(object obj) => obj is LongArray other && this.Equals(ref other);

  internal bool Equals(ref LongArray other)
  {
    if (LongArray.AreAliased(ref this, ref other))
      return true;
    int usedLength = this.GetUsedLength();
    if (other.GetUsedLength() != usedLength)
      return false;
    for (int index = 0; index < usedLength; ++index)
    {
      if ((long) this.m_data[index] != (long) other.m_data[index])
        return false;
    }
    return true;
  }

  public override int GetHashCode()
  {
    int usedLength = this.GetUsedLength();
    int hashCode = 1;
    for (int index = 0; index < usedLength; ++index)
    {
      ulong num = this.m_data[index];
      hashCode = (hashCode * 31 /*0x1F*/ ^ (int) num) * 31 /*0x1F*/ ^ (int) (num >> 32 /*0x20*/);
    }
    return hashCode;
  }

  public LongArray Copy() => new LongArray(Arrays.Clone(this.m_data));

  public override string ToString()
  {
    int usedLength = this.GetUsedLength();
    if (usedLength == 0)
      return "0";
    StringBuilder stringBuilder = new StringBuilder(usedLength * 64 /*0x40*/);
    int index;
    stringBuilder.Append(Convert.ToString((long) this.m_data[index = usedLength - 1], 2));
    while (--index >= 0)
    {
      string str = Convert.ToString((long) this.m_data[index], 2);
      int length = str.Length;
      if (length < 64 /*0x40*/)
        stringBuilder.Append('0', 64 /*0x40*/ - length);
      stringBuilder.Append(str);
    }
    return stringBuilder.ToString();
  }
}
