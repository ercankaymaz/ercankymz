// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Bike.BikeRing
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Math.Raw;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Bike;

internal sealed class BikeRing
{
  private const int PermutationCutoff = 64 /*0x40*/;
  private readonly int m_bits;
  private readonly int m_size;
  private readonly int m_sizeExt;
  private readonly Dictionary<int, int> m_halfPowers = new Dictionary<int, int>();

  internal BikeRing(int r)
  {
    this.m_bits = ((long) r & 4294901761L) == 1L ? r : throw new ArgumentException();
    this.m_size = r + 63 /*0x3F*/ >> 6;
    this.m_sizeExt = this.m_size * 2;
    uint r32 = Mod.Inverse32((uint) -r);
    foreach (int num in BikeRing.EnumerateSquarePowersInv(r))
    {
      if (num >= 64 /*0x40*/ && !this.m_halfPowers.ContainsKey(num))
        this.m_halfPowers[num] = BikeRing.GenerateHalfPower((uint) r, r32, num);
    }
  }

  internal void Add(ulong[] x, ulong[] y, ulong[] z) => Nat.Xor64(this.Size, x, y, z);

  internal void AddTo(ulong[] x, ulong[] z) => Nat.XorTo64(this.Size, x, z);

  internal void Copy(ulong[] x, ulong[] z)
  {
    for (int index = 0; index < this.Size; ++index)
      z[index] = x[index];
  }

  internal ulong[] Create() => new ulong[this.Size];

  internal ulong[] CreateExt() => new ulong[this.SizeExt];

  internal void DecodeBytes(byte[] bs, ulong[] z)
  {
    int length = (this.m_bits & 63 /*0x3F*/) + 7 >> 3;
    Pack.LE_To_UInt64(bs, 0, z, 0, this.Size - 1);
    byte[] numArray = new byte[8];
    Array.Copy((Array) bs, this.Size - 1 << 3, (Array) numArray, 0, length);
    z[this.Size - 1] = Pack.LE_To_UInt64(numArray);
  }

  internal byte[] EncodeBitsTransposed(ulong[] x)
  {
    byte[] numArray = new byte[this.m_bits];
    numArray[0] = (byte) (x[0] & 1UL);
    for (int index = 1; index < this.m_bits; ++index)
      numArray[this.m_bits - index] = (byte) (x[index >> 6] >> index & 1UL);
    return numArray;
  }

  internal void EncodeBytes(ulong[] x, byte[] bs)
  {
    int length = (this.m_bits & 63 /*0x3F*/) + 7 >> 3;
    Pack.UInt64_To_LE(x, 0, this.Size - 1, bs, 0);
    byte[] numArray = new byte[8];
    Pack.UInt64_To_LE(x[this.Size - 1], numArray);
    Array.Copy((Array) numArray, 0, (Array) bs, this.Size - 1 << 3, length);
  }

  internal void Inv(ulong[] a, ulong[] z)
  {
    ulong[] numArray1 = this.Create();
    ulong[] numArray2 = this.Create();
    ulong[] numArray3 = this.Create();
    this.Copy(a, numArray1);
    this.Copy(a, numArray3);
    int i = this.m_bits - 2;
    int num = 32 /*0x20*/ - Integers.NumberOfLeadingZeros(i);
    for (int index = 1; index < num; ++index)
    {
      this.SquareN(numArray1, 1 << index - 1, numArray2);
      this.Multiply(numArray1, numArray2, numArray1);
      if ((i & 1 << index) != 0)
      {
        int n = i & (1 << index) - 1;
        this.SquareN(numArray1, n, numArray2);
        this.Multiply(numArray3, numArray2, numArray3);
      }
    }
    this.Square(numArray3, z);
  }

  internal void Multiply(ulong[] x, ulong[] y, ulong[] z) => this.Multiply(x, 0, y, 0, z);

  internal void Multiply(ulong[] x, int xOff, ulong[] y, int yOff, ulong[] z)
  {
    ulong[] ext = this.CreateExt();
    this.ImplMultiplyAcc(x, xOff, y, yOff, ext);
    this.Reduce(ext, z);
  }

  internal void Reduce(ulong[] tt, ulong[] z)
  {
    int bits = 64 /*0x40*/ - (this.m_bits & 63 /*0x3F*/);
    ulong num1 = ulong.MaxValue >> bits;
    long num2 = (long) Nat.ShiftUpBits64(this.Size, tt, this.Size, bits, tt[this.Size - 1], z, 0);
    this.AddTo(tt, z);
    z[this.Size - 1] &= num1;
  }

  internal int Size => this.m_size;

  internal int SizeExt => this.m_sizeExt;

  internal void Square(ulong[] x, ulong[] z)
  {
    ulong[] ext = this.CreateExt();
    this.ImplSquare(x, ext);
    this.Reduce(ext, z);
  }

  internal void SquareN(ulong[] x, int n, ulong[] z)
  {
    if (n >= 64 /*0x40*/)
    {
      this.ImplPermute(x, n, z);
    }
    else
    {
      ulong[] ext = this.CreateExt();
      this.ImplSquare(x, ext);
      this.Reduce(ext, z);
      while (--n > 0)
      {
        this.ImplSquare(z, ext);
        this.Reduce(ext, z);
      }
    }
  }

  private static int ImplModAdd(int m, int x, int y)
  {
    int num = x + y - m;
    return num + (num >> 31 /*0x1F*/ & m);
  }

  private void ImplMultiplyAcc(ulong[] x, int xOff, ulong[] y, int yOff, ulong[] zz)
  {
    long num1 = (long) x[xOff + this.Size - 1];
    long num2 = (long) y[yOff + this.Size - 1];
    long num3 = (long) zz[this.SizeExt - 1];
    ulong[] u = new ulong[16 /*0x10*/];
    for (int index = 0; index < this.Size; ++index)
      BikeRing.ImplMulwAcc(u, x[xOff + index], y[yOff + index], zz, index << 1);
    ulong num4 = zz[0];
    ulong num5 = zz[1];
    for (int index = 1; index < this.Size; ++index)
    {
      num4 ^= zz[index << 1];
      zz[index] = num4 ^ num5;
      num5 ^= zz[(index << 1) + 1];
    }
    ulong y1 = num4 ^ num5;
    Nat.Xor64(this.Size, zz, 0, y1, zz, this.Size);
    int val1 = this.Size - 1;
    for (int index1 = 1; index1 < val1 * 2; ++index1)
    {
      int num6 = System.Math.Min(val1, index1);
      for (int index2 = index1 - num6; index2 < num6; --num6)
      {
        BikeRing.ImplMulwAcc(u, x[xOff + index2] ^ x[xOff + num6], y[yOff + index2] ^ y[yOff + num6], zz, index1);
        ++index2;
      }
    }
  }

  private void ImplPermute(ulong[] x, int n, ulong[] z)
  {
    int bits = this.m_bits;
    int halfPower = this.m_halfPowers[n];
    int num1 = BikeRing.ImplModAdd(bits, halfPower, halfPower);
    int num2 = BikeRing.ImplModAdd(bits, num1, num1);
    int y = BikeRing.ImplModAdd(bits, num2, num2);
    int x1 = bits - y;
    int x2 = BikeRing.ImplModAdd(bits, x1, halfPower);
    int x3 = BikeRing.ImplModAdd(bits, x1, num1);
    int x4 = BikeRing.ImplModAdd(bits, x2, num1);
    int x5 = BikeRing.ImplModAdd(bits, x1, num2);
    int x6 = BikeRing.ImplModAdd(bits, x2, num2);
    int x7 = BikeRing.ImplModAdd(bits, x3, num2);
    int x8 = BikeRing.ImplModAdd(bits, x4, num2);
    for (int index1 = 0; index1 < this.Size; ++index1)
    {
      ulong num3 = 0;
      for (int index2 = 0; index2 < 64 /*0x40*/; index2 += 8)
      {
        x1 = BikeRing.ImplModAdd(bits, x1, y);
        x2 = BikeRing.ImplModAdd(bits, x2, y);
        x3 = BikeRing.ImplModAdd(bits, x3, y);
        x4 = BikeRing.ImplModAdd(bits, x4, y);
        x5 = BikeRing.ImplModAdd(bits, x5, y);
        x6 = BikeRing.ImplModAdd(bits, x6, y);
        x7 = BikeRing.ImplModAdd(bits, x7, y);
        x8 = BikeRing.ImplModAdd(bits, x8, y);
        num3 = num3 | (ulong) (((long) (x[x1 >> 6] >> x1) & 1L) << index2) | (ulong) (((long) (x[x2 >> 6] >> x2) & 1L) << index2 + 1) | (ulong) (((long) (x[x3 >> 6] >> x3) & 1L) << index2 + 2) | (ulong) (((long) (x[x4 >> 6] >> x4) & 1L) << index2 + 3) | (ulong) (((long) (x[x5 >> 6] >> x5) & 1L) << index2 + 4) | (ulong) (((long) (x[x6 >> 6] >> x6) & 1L) << index2 + 5) | (ulong) (((long) (x[x7 >> 6] >> x7) & 1L) << index2 + 6) | (ulong) (((long) (x[x8 >> 6] >> x8) & 1L) << index2 + 7);
      }
      z[index1] = num3;
    }
    z[this.Size - 1] &= ulong.MaxValue >> -bits;
  }

  private static IEnumerable<int> EnumerateSquarePowersInv(int r)
  {
    int rSub2 = r - 2;
    int bits = 32 /*0x20*/ - Integers.NumberOfLeadingZeros(rSub2);
    for (int i = 1; i < bits; ++i)
    {
      yield return 1 << i - 1;
      if ((rSub2 & 1 << i) != 0)
        yield return rSub2 & (1 << i) - 1;
    }
  }

  private static int GenerateHalfPower(uint r, uint r32, int n)
  {
    uint halfPower = 1;
    int num1;
    for (num1 = n; num1 >= 32 /*0x20*/; num1 -= 32 /*0x20*/)
      halfPower = (uint) ((ulong) (r32 * halfPower) * (ulong) r + (ulong) halfPower >> 32 /*0x20*/);
    if (num1 > 0)
    {
      uint num2 = uint.MaxValue >> -num1;
      halfPower = (uint) ((ulong) (r32 * halfPower & num2) * (ulong) r + (ulong) halfPower >> num1);
    }
    return (int) halfPower;
  }

  private static void ImplMulwAcc(ulong[] u, ulong x, ulong y, ulong[] z, int zOff)
  {
    u[1] = y;
    for (int index = 2; index < 16 /*0x10*/; index += 2)
    {
      u[index] = u[index >> 1] << 1;
      u[index + 1] = u[index] ^ y;
    }
    uint num1 = (uint) x;
    ulong num2 = 0;
    ulong num3 = u[(int) num1 & 15] ^ u[(int) (num1 >> 4) & 15] << 4;
    int num4 = 56;
    do
    {
      uint num5 = (uint) (x >> num4);
      ulong num6 = u[(int) num5 & 15] ^ u[(int) (num5 >> 4) & 15] << 4;
      num3 ^= num6 << num4;
      num2 ^= num6 >> -num4;
    }
    while ((num4 -= 8) > 0);
    for (int index = 0; index < 7; ++index)
    {
      x = (x & 18374403900871474942UL /*0xFEFEFEFEFEFEFEFE*/) >> 1;
      num2 ^= x & (ulong) ((long) y << index >> 63 /*0x3F*/);
    }
    z[zOff] ^= num3;
    z[zOff + 1] ^= num2;
  }

  private void ImplSquare(ulong[] x, ulong[] zz)
  {
    Interleave.Expand64To128(x, 0, this.Size, zz, 0);
  }
}
