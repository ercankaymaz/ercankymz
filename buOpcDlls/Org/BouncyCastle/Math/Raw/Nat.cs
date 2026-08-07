// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.Raw.Nat
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Math.Raw;

internal static class Nat
{
  private const ulong M = 4294967295 /*0xFFFFFFFF*/;

  public static uint Add(int len, uint[] x, uint[] y, uint[] z)
  {
    ulong num1 = 0;
    for (int index = 0; index < len; ++index)
    {
      ulong num2 = num1 + ((ulong) x[index] + (ulong) y[index]);
      z[index] = (uint) num2;
      num1 = num2 >> 32 /*0x20*/;
    }
    return (uint) num1;
  }

  public static uint Add33At(int len, uint x, uint[] z, int zPos)
  {
    ulong num1 = (ulong) z[zPos] + (ulong) x;
    z[zPos] = (uint) num1;
    ulong num2 = (num1 >> 32 /*0x20*/) + ((ulong) z[zPos + 1] + 1UL);
    z[zPos + 1] = (uint) num2;
    return num2 >> 32 /*0x20*/ != 0UL ? Nat.IncAt(len, z, zPos + 2) : 0U;
  }

  public static uint Add33At(int len, uint x, uint[] z, int zOff, int zPos)
  {
    ulong num1 = (ulong) z[zOff + zPos] + (ulong) x;
    z[zOff + zPos] = (uint) num1;
    ulong num2 = (num1 >> 32 /*0x20*/) + ((ulong) z[zOff + zPos + 1] + 1UL);
    z[zOff + zPos + 1] = (uint) num2;
    return num2 >> 32 /*0x20*/ != 0UL ? Nat.IncAt(len, z, zOff, zPos + 2) : 0U;
  }

  public static uint Add33To(int len, uint x, uint[] z)
  {
    ulong num1 = (ulong) z[0] + (ulong) x;
    z[0] = (uint) num1;
    ulong num2 = (num1 >> 32 /*0x20*/) + ((ulong) z[1] + 1UL);
    z[1] = (uint) num2;
    return num2 >> 32 /*0x20*/ != 0UL ? Nat.IncAt(len, z, 2) : 0U;
  }

  public static uint Add33To(int len, uint x, uint[] z, int zOff)
  {
    ulong num1 = (ulong) z[zOff] + (ulong) x;
    z[zOff] = (uint) num1;
    ulong num2 = (num1 >> 32 /*0x20*/) + ((ulong) z[zOff + 1] + 1UL);
    z[zOff + 1] = (uint) num2;
    return num2 >> 32 /*0x20*/ != 0UL ? Nat.IncAt(len, z, zOff, 2) : 0U;
  }

  public static uint AddBothTo(int len, uint[] x, uint[] y, uint[] z)
  {
    ulong num1 = 0;
    for (int index = 0; index < len; ++index)
    {
      ulong num2 = num1 + ((ulong) x[index] + (ulong) y[index] + (ulong) z[index]);
      z[index] = (uint) num2;
      num1 = num2 >> 32 /*0x20*/;
    }
    return (uint) num1;
  }

  public static uint AddBothTo(
    int len,
    uint[] x,
    int xOff,
    uint[] y,
    int yOff,
    uint[] z,
    int zOff)
  {
    ulong num1 = 0;
    for (int index = 0; index < len; ++index)
    {
      ulong num2 = num1 + ((ulong) x[xOff + index] + (ulong) y[yOff + index] + (ulong) z[zOff + index]);
      z[zOff + index] = (uint) num2;
      num1 = num2 >> 32 /*0x20*/;
    }
    return (uint) num1;
  }

  public static uint AddDWordAt(int len, ulong x, uint[] z, int zPos)
  {
    ulong num1 = (ulong) z[zPos] + (x & (ulong) uint.MaxValue);
    z[zPos] = (uint) num1;
    ulong num2 = (num1 >> 32 /*0x20*/) + ((ulong) z[zPos + 1] + (x >> 32 /*0x20*/));
    z[zPos + 1] = (uint) num2;
    return num2 >> 32 /*0x20*/ != 0UL ? Nat.IncAt(len, z, zPos + 2) : 0U;
  }

  public static uint AddDWordAt(int len, ulong x, uint[] z, int zOff, int zPos)
  {
    ulong num1 = (ulong) z[zOff + zPos] + (x & (ulong) uint.MaxValue);
    z[zOff + zPos] = (uint) num1;
    ulong num2 = (num1 >> 32 /*0x20*/) + ((ulong) z[zOff + zPos + 1] + (x >> 32 /*0x20*/));
    z[zOff + zPos + 1] = (uint) num2;
    return num2 >> 32 /*0x20*/ != 0UL ? Nat.IncAt(len, z, zOff, zPos + 2) : 0U;
  }

  public static uint AddDWordTo(int len, ulong x, uint[] z)
  {
    ulong num1 = (ulong) z[0] + (x & (ulong) uint.MaxValue);
    z[0] = (uint) num1;
    ulong num2 = (num1 >> 32 /*0x20*/) + ((ulong) z[1] + (x >> 32 /*0x20*/));
    z[1] = (uint) num2;
    return num2 >> 32 /*0x20*/ != 0UL ? Nat.IncAt(len, z, 2) : 0U;
  }

  public static uint AddDWordTo(int len, ulong x, uint[] z, int zOff)
  {
    ulong num1 = (ulong) z[zOff] + (x & (ulong) uint.MaxValue);
    z[zOff] = (uint) num1;
    ulong num2 = (num1 >> 32 /*0x20*/) + ((ulong) z[zOff + 1] + (x >> 32 /*0x20*/));
    z[zOff + 1] = (uint) num2;
    return num2 >> 32 /*0x20*/ != 0UL ? Nat.IncAt(len, z, zOff, 2) : 0U;
  }

  public static uint AddTo(int len, uint[] x, uint[] z)
  {
    ulong num1 = 0;
    for (int index = 0; index < len; ++index)
    {
      ulong num2 = num1 + ((ulong) x[index] + (ulong) z[index]);
      z[index] = (uint) num2;
      num1 = num2 >> 32 /*0x20*/;
    }
    return (uint) num1;
  }

  public static uint AddTo(int len, uint[] x, int xOff, uint[] z, int zOff)
  {
    ulong num1 = 0;
    for (int index = 0; index < len; ++index)
    {
      ulong num2 = num1 + ((ulong) x[xOff + index] + (ulong) z[zOff + index]);
      z[zOff + index] = (uint) num2;
      num1 = num2 >> 32 /*0x20*/;
    }
    return (uint) num1;
  }

  public static uint AddTo(int len, uint[] x, int xOff, uint[] z, int zOff, uint cIn)
  {
    ulong num1 = (ulong) cIn;
    for (int index = 0; index < len; ++index)
    {
      ulong num2 = num1 + ((ulong) x[xOff + index] + (ulong) z[zOff + index]);
      z[zOff + index] = (uint) num2;
      num1 = num2 >> 32 /*0x20*/;
    }
    return (uint) num1;
  }

  public static uint AddToEachOther(int len, uint[] u, int uOff, uint[] v, int vOff)
  {
    ulong eachOther = 0;
    for (int index = 0; index < len; ++index)
    {
      ulong num = eachOther + ((ulong) u[uOff + index] + (ulong) v[vOff + index]);
      u[uOff + index] = (uint) num;
      v[vOff + index] = (uint) num;
      eachOther = num >> 32 /*0x20*/;
    }
    return (uint) eachOther;
  }

  public static uint AddWordAt(int len, uint x, uint[] z, int zPos)
  {
    ulong num = (ulong) x + (ulong) z[zPos];
    z[zPos] = (uint) num;
    return num >> 32 /*0x20*/ != 0UL ? Nat.IncAt(len, z, zPos + 1) : 0U;
  }

  public static uint AddWordAt(int len, uint x, uint[] z, int zOff, int zPos)
  {
    ulong num = (ulong) x + (ulong) z[zOff + zPos];
    z[zOff + zPos] = (uint) num;
    return num >> 32 /*0x20*/ != 0UL ? Nat.IncAt(len, z, zOff, zPos + 1) : 0U;
  }

  public static uint AddWordTo(int len, uint x, uint[] z)
  {
    ulong num = (ulong) x + (ulong) z[0];
    z[0] = (uint) num;
    return num >> 32 /*0x20*/ != 0UL ? Nat.IncAt(len, z, 1) : 0U;
  }

  public static uint AddWordTo(int len, uint x, uint[] z, int zOff)
  {
    ulong num = (ulong) x + (ulong) z[zOff];
    z[zOff] = (uint) num;
    return num >> 32 /*0x20*/ != 0UL ? Nat.IncAt(len, z, zOff, 1) : 0U;
  }

  public static uint CAdd(int len, int mask, uint[] x, uint[] y, uint[] z)
  {
    uint num1 = (uint) -(mask & 1);
    ulong num2 = 0;
    for (int index = 0; index < len; ++index)
    {
      ulong num3 = num2 + ((ulong) x[index] + (ulong) (y[index] & num1));
      z[index] = (uint) num3;
      num2 = num3 >> 32 /*0x20*/;
    }
    return (uint) num2;
  }

  public static void CMov(int len, int mask, uint[] x, int xOff, uint[] z, int zOff)
  {
    uint num1 = (uint) -(mask & 1);
    for (int index = 0; index < len; ++index)
    {
      uint num2 = z[zOff + index];
      uint num3 = num2 ^ x[xOff + index];
      uint num4 = num2 ^ num3 & num1;
      z[zOff + index] = num4;
    }
  }

  public static int Compare(int len, uint[] x, uint[] y)
  {
    for (int index = len - 1; index >= 0; --index)
    {
      uint num1 = x[index];
      uint num2 = y[index];
      if (num1 < num2)
        return -1;
      if (num1 > num2)
        return 1;
    }
    return 0;
  }

  public static int Compare(int len, uint[] x, int xOff, uint[] y, int yOff)
  {
    for (int index = len - 1; index >= 0; --index)
    {
      uint num1 = x[xOff + index];
      uint num2 = y[yOff + index];
      if (num1 < num2)
        return -1;
      if (num1 > num2)
        return 1;
    }
    return 0;
  }

  public static uint[] Copy(int len, uint[] x)
  {
    uint[] destinationArray = new uint[len];
    Array.Copy((Array) x, 0, (Array) destinationArray, 0, len);
    return destinationArray;
  }

  public static void Copy(int len, uint[] x, uint[] z)
  {
    Array.Copy((Array) x, 0, (Array) z, 0, len);
  }

  public static void Copy(int len, uint[] x, int xOff, uint[] z, int zOff)
  {
    Array.Copy((Array) x, xOff, (Array) z, zOff, len);
  }

  public static ulong[] Copy64(int len, ulong[] x)
  {
    ulong[] destinationArray = new ulong[len];
    Array.Copy((Array) x, 0, (Array) destinationArray, 0, len);
    return destinationArray;
  }

  public static void Copy64(int len, ulong[] x, ulong[] z)
  {
    Array.Copy((Array) x, 0, (Array) z, 0, len);
  }

  public static void Copy64(int len, ulong[] x, int xOff, ulong[] z, int zOff)
  {
    Array.Copy((Array) x, xOff, (Array) z, zOff, len);
  }

  public static uint[] Create(int len) => new uint[len];

  public static ulong[] Create64(int len) => new ulong[len];

  public static int CSub(int len, int mask, uint[] x, uint[] y, uint[] z)
  {
    long num1 = (long) (uint) -(mask & 1);
    long num2 = 0;
    for (int index = 0; index < len; ++index)
    {
      long num3 = num2 + ((long) x[index] - ((long) y[index] & num1));
      z[index] = (uint) num3;
      num2 = num3 >> 32 /*0x20*/;
    }
    return (int) num2;
  }

  public static int CSub(
    int len,
    int mask,
    uint[] x,
    int xOff,
    uint[] y,
    int yOff,
    uint[] z,
    int zOff)
  {
    long num1 = (long) (uint) -(mask & 1);
    long num2 = 0;
    for (int index = 0; index < len; ++index)
    {
      long num3 = num2 + ((long) x[xOff + index] - ((long) y[yOff + index] & num1));
      z[zOff + index] = (uint) num3;
      num2 = num3 >> 32 /*0x20*/;
    }
    return (int) num2;
  }

  public static int Dec(int len, uint[] z)
  {
    for (int index = 0; index < len; ++index)
    {
      if (--z[index] != uint.MaxValue)
        return 0;
    }
    return -1;
  }

  public static int Dec(int len, uint[] x, uint[] z)
  {
    int index = 0;
    while (index < len)
    {
      uint num = x[index] - 1U;
      z[index] = num;
      ++index;
      if (num != uint.MaxValue)
      {
        for (; index < len; ++index)
          z[index] = x[index];
        return 0;
      }
    }
    return -1;
  }

  public static int DecAt(int len, uint[] z, int zPos)
  {
    for (int index = zPos; index < len; ++index)
    {
      if (--z[index] != uint.MaxValue)
        return 0;
    }
    return -1;
  }

  public static int DecAt(int len, uint[] z, int zOff, int zPos)
  {
    for (int index = zPos; index < len; ++index)
    {
      if (--z[zOff + index] != uint.MaxValue)
        return 0;
    }
    return -1;
  }

  public static bool Eq(int len, uint[] x, uint[] y)
  {
    for (int index = len - 1; index >= 0; --index)
    {
      if ((int) x[index] != (int) y[index])
        return false;
    }
    return true;
  }

  public static uint EqualTo(int len, uint[] x, uint y)
  {
    uint num = x[0] ^ y;
    for (int index = 1; index < len; ++index)
      num |= x[index];
    return (uint) ((int) (num >> 1 | num & 1U) - 1 >> 31 /*0x1F*/);
  }

  public static uint EqualTo(int len, uint[] x, int xOff, uint y)
  {
    uint num = x[xOff] ^ y;
    for (int index = 1; index < len; ++index)
      num |= x[xOff + index];
    return (uint) ((int) (num >> 1 | num & 1U) - 1 >> 31 /*0x1F*/);
  }

  public static uint EqualTo(int len, uint[] x, uint[] y)
  {
    uint num = 0;
    for (int index = 0; index < len; ++index)
      num |= x[index] ^ y[index];
    return (uint) ((int) (num >> 1 | num & 1U) - 1 >> 31 /*0x1F*/);
  }

  public static uint EqualTo(int len, uint[] x, int xOff, uint[] y, int yOff)
  {
    uint num = 0;
    for (int index = 0; index < len; ++index)
      num |= x[xOff + index] ^ y[yOff + index];
    return (uint) ((int) (num >> 1 | num & 1U) - 1 >> 31 /*0x1F*/);
  }

  public static uint EqualToZero(int len, uint[] x)
  {
    uint num = 0;
    for (int index = 0; index < len; ++index)
      num |= x[index];
    return (uint) ((int) (num >> 1 | num & 1U) - 1 >> 31 /*0x1F*/);
  }

  public static uint EqualToZero(int len, uint[] x, int xOff)
  {
    uint num = 0;
    for (int index = 0; index < len; ++index)
      num |= x[xOff + index];
    return (uint) ((int) (num >> 1 | num & 1U) - 1 >> 31 /*0x1F*/);
  }

  public static uint[] FromBigInteger(int bits, BigInteger x)
  {
    if (x.SignValue < 0 || x.BitLength > bits)
      throw new ArgumentException();
    int lengthForBits = Nat.GetLengthForBits(bits);
    uint[] numArray = Nat.Create(lengthForBits);
    numArray[0] = (uint) x.IntValue;
    for (int index = 1; index < lengthForBits; ++index)
    {
      x = x.ShiftRight(32 /*0x20*/);
      numArray[index] = (uint) x.IntValue;
    }
    return numArray;
  }

  public static ulong[] FromBigInteger64(int bits, BigInteger x)
  {
    if (x.SignValue < 0 || x.BitLength > bits)
      throw new ArgumentException();
    int lengthForBits64 = Nat.GetLengthForBits64(bits);
    ulong[] numArray = Nat.Create64(lengthForBits64);
    numArray[0] = (ulong) x.LongValue;
    for (int index = 1; index < lengthForBits64; ++index)
    {
      x = x.ShiftRight(64 /*0x40*/);
      numArray[index] = (ulong) x.LongValue;
    }
    return numArray;
  }

  public static uint GetBit(uint[] x, int bit)
  {
    if (bit == 0)
      return x[0] & 1U;
    int index = bit >> 5;
    if (index < 0 || index >= x.Length)
      return 0;
    int num = bit & 31 /*0x1F*/;
    return x[index] >> num & 1U;
  }

  public static int GetLengthForBits(int bits)
  {
    if (bits < 1)
      throw new ArgumentException();
    return bits + 31 /*0x1F*/ >>> 5;
  }

  public static int GetLengthForBits64(int bits)
  {
    if (bits < 1)
      throw new ArgumentException();
    return bits + 63 /*0x3F*/ >>> 6;
  }

  public static bool Gte(int len, uint[] x, uint[] y)
  {
    for (int index = len - 1; index >= 0; --index)
    {
      uint num1 = x[index];
      uint num2 = y[index];
      if (num1 < num2)
        return false;
      if (num1 > num2)
        return true;
    }
    return true;
  }

  public static uint Inc(int len, uint[] z)
  {
    for (int index = 0; index < len; ++index)
    {
      if (++z[index] != 0U)
        return 0;
    }
    return 1;
  }

  public static uint Inc(int len, uint[] x, uint[] z)
  {
    int index = 0;
    while (index < len)
    {
      uint num = x[index] + 1U;
      z[index] = num;
      ++index;
      if (num != 0U)
      {
        for (; index < len; ++index)
          z[index] = x[index];
        return 0;
      }
    }
    return 1;
  }

  public static uint IncAt(int len, uint[] z, int zPos)
  {
    for (int index = zPos; index < len; ++index)
    {
      if (++z[index] != 0U)
        return 0;
    }
    return 1;
  }

  public static uint IncAt(int len, uint[] z, int zOff, int zPos)
  {
    for (int index = zPos; index < len; ++index)
    {
      if (++z[zOff + index] != 0U)
        return 0;
    }
    return 1;
  }

  public static bool IsOne(int len, uint[] x)
  {
    if (x[0] != 1U)
      return false;
    for (int index = 1; index < len; ++index)
    {
      if (x[index] != 0U)
        return false;
    }
    return true;
  }

  public static bool IsZero(int len, uint[] x)
  {
    if (x[0] != 0U)
      return false;
    for (int index = 1; index < len; ++index)
    {
      if (x[index] != 0U)
        return false;
    }
    return true;
  }

  public static int LessThan(int len, uint[] x, uint[] y)
  {
    long num = 0;
    for (int index = 0; index < len; ++index)
      num = num + ((long) x[index] - (long) y[index]) >> 32 /*0x20*/;
    return (int) num;
  }

  public static int LessThan(int len, uint[] x, int xOff, uint[] y, int yOff)
  {
    long num = 0;
    for (int index = 0; index < len; ++index)
      num = num + ((long) x[xOff + index] - (long) y[yOff + index]) >> 32 /*0x20*/;
    return (int) num;
  }

  public static void Mul(int len, uint[] x, uint[] y, uint[] zz)
  {
    zz[len] = Nat.MulWord(len, x[0], y, zz);
    for (int zOff = 1; zOff < len; ++zOff)
      zz[zOff + len] = Nat.MulWordAddTo(len, x[zOff], y, 0, zz, zOff);
  }

  public static void Mul(int len, uint[] x, int xOff, uint[] y, int yOff, uint[] zz, int zzOff)
  {
    zz[zzOff + len] = Nat.MulWord(len, x[xOff], y, yOff, zz, zzOff);
    for (int index = 1; index < len; ++index)
      zz[zzOff + index + len] = Nat.MulWordAddTo(len, x[xOff + index], y, yOff, zz, zzOff + index);
  }

  public static void Mul(
    uint[] x,
    int xOff,
    int xLen,
    uint[] y,
    int yOff,
    int yLen,
    uint[] zz,
    int zzOff)
  {
    zz[zzOff + yLen] = Nat.MulWord(yLen, x[xOff], y, yOff, zz, zzOff);
    for (int index = 1; index < xLen; ++index)
      zz[zzOff + index + yLen] = Nat.MulWordAddTo(yLen, x[xOff + index], y, yOff, zz, zzOff + index);
  }

  public static uint MulAddTo(int len, uint[] x, uint[] y, uint[] zz)
  {
    ulong num1 = 0;
    for (int zOff = 0; zOff < len; ++zOff)
    {
      ulong num2 = num1 + ((ulong) Nat.MulWordAddTo(len, x[zOff], y, 0, zz, zOff) & (ulong) uint.MaxValue) + ((ulong) zz[zOff + len] & (ulong) uint.MaxValue);
      zz[zOff + len] = (uint) num2;
      num1 = num2 >> 32 /*0x20*/;
    }
    return (uint) num1;
  }

  public static uint MulAddTo(
    int len,
    uint[] x,
    int xOff,
    uint[] y,
    int yOff,
    uint[] zz,
    int zzOff)
  {
    ulong num1 = 0;
    for (int index = 0; index < len; ++index)
    {
      ulong num2 = num1 + ((ulong) Nat.MulWordAddTo(len, x[xOff + index], y, yOff, zz, zzOff) & (ulong) uint.MaxValue) + ((ulong) zz[zzOff + len] & (ulong) uint.MaxValue);
      zz[zzOff + len] = (uint) num2;
      num1 = num2 >> 32 /*0x20*/;
      ++zzOff;
    }
    return (uint) num1;
  }

  public static uint Mul31BothAdd(
    int len,
    uint a,
    uint[] x,
    uint b,
    uint[] y,
    uint[] z,
    int zOff)
  {
    ulong num1 = 0;
    ulong num2 = (ulong) a;
    ulong num3 = (ulong) b;
    int index = 0;
    do
    {
      ulong num4 = num1 + ((ulong) ((long) num2 * (long) x[index] + (long) num3 * (long) y[index]) + (ulong) z[zOff + index]);
      z[zOff + index] = (uint) num4;
      num1 = num4 >> 32 /*0x20*/;
    }
    while (++index < len);
    return (uint) num1;
  }

  public static uint MulWord(int len, uint x, uint[] y, uint[] z)
  {
    ulong num1 = 0;
    ulong num2 = (ulong) x;
    int index = 0;
    do
    {
      ulong num3 = num1 + num2 * (ulong) y[index];
      z[index] = (uint) num3;
      num1 = num3 >> 32 /*0x20*/;
    }
    while (++index < len);
    return (uint) num1;
  }

  public static uint MulWord(int len, uint x, uint[] y, int yOff, uint[] z, int zOff)
  {
    ulong num1 = 0;
    ulong num2 = (ulong) x;
    int num3 = 0;
    do
    {
      ulong num4 = num1 + num2 * (ulong) y[yOff + num3];
      z[zOff + num3] = (uint) num4;
      num1 = num4 >> 32 /*0x20*/;
    }
    while (++num3 < len);
    return (uint) num1;
  }

  public static uint MulWordAddTo(int len, uint x, uint[] y, int yOff, uint[] z, int zOff)
  {
    ulong num1 = 0;
    ulong num2 = (ulong) x;
    int num3 = 0;
    do
    {
      ulong num4 = num1 + (num2 * (ulong) y[yOff + num3] + (ulong) z[zOff + num3]);
      z[zOff + num3] = (uint) num4;
      num1 = num4 >> 32 /*0x20*/;
    }
    while (++num3 < len);
    return (uint) num1;
  }

  public static uint MulWordDwordAddAt(int len, uint x, ulong y, uint[] z, int zPos)
  {
    ulong num1 = (ulong) x;
    ulong num2 = (ulong) (0L + ((long) num1 * (long) (uint) y + (long) z[zPos]));
    z[zPos] = (uint) num2;
    ulong num3 = (num2 >> 32 /*0x20*/) + (num1 * (y >> 32 /*0x20*/) + (ulong) z[zPos + 1]);
    z[zPos + 1] = (uint) num3;
    ulong num4 = (num3 >> 32 /*0x20*/) + (ulong) z[zPos + 2];
    z[zPos + 2] = (uint) num4;
    return num4 >> 32 /*0x20*/ != 0UL ? Nat.IncAt(len, z, zPos + 3) : 0U;
  }

  public static int Negate(int len, uint[] x, uint[] z)
  {
    long num1 = 0;
    for (int index = 0; index < len; ++index)
    {
      long num2 = num1 - (long) x[index];
      z[index] = (uint) num2;
      num1 = num2 >> 32 /*0x20*/;
    }
    return (int) num1;
  }

  public static uint ShiftDownBit(int len, uint[] z, uint c)
  {
    int index = len;
    while (--index >= 0)
    {
      uint num = z[index];
      z[index] = num >> 1 | c << 31 /*0x1F*/;
      c = num;
    }
    return c << 31 /*0x1F*/;
  }

  public static uint ShiftDownBit(int len, uint[] z, int zOff, uint c)
  {
    int num1 = len;
    while (--num1 >= 0)
    {
      uint num2 = z[zOff + num1];
      z[zOff + num1] = num2 >> 1 | c << 31 /*0x1F*/;
      c = num2;
    }
    return c << 31 /*0x1F*/;
  }

  public static uint ShiftDownBit(int len, uint[] x, uint c, uint[] z)
  {
    int index = len;
    while (--index >= 0)
    {
      uint num = x[index];
      z[index] = num >> 1 | c << 31 /*0x1F*/;
      c = num;
    }
    return c << 31 /*0x1F*/;
  }

  public static uint ShiftDownBit(int len, uint[] x, int xOff, uint c, uint[] z, int zOff)
  {
    int num1 = len;
    while (--num1 >= 0)
    {
      uint num2 = x[xOff + num1];
      z[zOff + num1] = num2 >> 1 | c << 31 /*0x1F*/;
      c = num2;
    }
    return c << 31 /*0x1F*/;
  }

  public static uint ShiftDownBits(int len, uint[] z, int bits, uint c)
  {
    int index = len;
    while (--index >= 0)
    {
      uint num = z[index];
      z[index] = num >> bits | c << -bits;
      c = num;
    }
    return c << -bits;
  }

  public static uint ShiftDownBits(int len, uint[] z, int zOff, int bits, uint c)
  {
    int num1 = len;
    while (--num1 >= 0)
    {
      uint num2 = z[zOff + num1];
      z[zOff + num1] = num2 >> bits | c << -bits;
      c = num2;
    }
    return c << -bits;
  }

  public static uint ShiftDownBits(int len, uint[] x, int bits, uint c, uint[] z)
  {
    int index = len;
    while (--index >= 0)
    {
      uint num = x[index];
      z[index] = num >> bits | c << -bits;
      c = num;
    }
    return c << -bits;
  }

  public static uint ShiftDownBits(
    int len,
    uint[] x,
    int xOff,
    int bits,
    uint c,
    uint[] z,
    int zOff)
  {
    int num1 = len;
    while (--num1 >= 0)
    {
      uint num2 = x[xOff + num1];
      z[zOff + num1] = num2 >> bits | c << -bits;
      c = num2;
    }
    return c << -bits;
  }

  public static ulong ShiftDownBits64(int len, ulong[] z, int zOff, int bits, ulong c)
  {
    int num1 = len;
    while (--num1 >= 0)
    {
      ulong num2 = z[zOff + num1];
      z[zOff + num1] = num2 >> bits | c << -bits;
      c = num2;
    }
    return c << -bits;
  }

  public static uint ShiftDownWord(int len, uint[] z, uint c)
  {
    int index = len;
    while (--index >= 0)
    {
      int num = (int) z[index];
      z[index] = c;
      c = (uint) num;
    }
    return c;
  }

  public static uint ShiftUpBit(int len, uint[] z, uint c)
  {
    int index1 = 0;
    for (int index2 = len - 4; index1 <= index2; index1 += 4)
    {
      uint num1 = z[index1];
      uint num2 = z[index1 + 1];
      uint num3 = z[index1 + 2];
      uint num4 = z[index1 + 3];
      z[index1] = num1 << 1 | c >> 31 /*0x1F*/;
      z[index1 + 1] = num2 << 1 | num1 >> 31 /*0x1F*/;
      z[index1 + 2] = num3 << 1 | num2 >> 31 /*0x1F*/;
      z[index1 + 3] = num4 << 1 | num3 >> 31 /*0x1F*/;
      c = num4;
    }
    for (; index1 < len; ++index1)
    {
      uint num = z[index1];
      z[index1] = num << 1 | c >> 31 /*0x1F*/;
      c = num;
    }
    return c >> 31 /*0x1F*/;
  }

  public static uint ShiftUpBit(int len, uint[] z, int zOff, uint c)
  {
    int num1 = 0;
    for (int index = len - 4; num1 <= index; num1 += 4)
    {
      uint num2 = z[zOff + num1];
      uint num3 = z[zOff + num1 + 1];
      uint num4 = z[zOff + num1 + 2];
      uint num5 = z[zOff + num1 + 3];
      z[zOff + num1] = num2 << 1 | c >> 31 /*0x1F*/;
      z[zOff + num1 + 1] = num3 << 1 | num2 >> 31 /*0x1F*/;
      z[zOff + num1 + 2] = num4 << 1 | num3 >> 31 /*0x1F*/;
      z[zOff + num1 + 3] = num5 << 1 | num4 >> 31 /*0x1F*/;
      c = num5;
    }
    for (; num1 < len; ++num1)
    {
      uint num6 = z[zOff + num1];
      z[zOff + num1] = num6 << 1 | c >> 31 /*0x1F*/;
      c = num6;
    }
    return c >> 31 /*0x1F*/;
  }

  public static uint ShiftUpBit(int len, uint[] x, uint c, uint[] z)
  {
    int index1 = 0;
    for (int index2 = len - 4; index1 <= index2; index1 += 4)
    {
      uint num1 = x[index1];
      uint num2 = x[index1 + 1];
      uint num3 = x[index1 + 2];
      uint num4 = x[index1 + 3];
      z[index1] = num1 << 1 | c >> 31 /*0x1F*/;
      z[index1 + 1] = num2 << 1 | num1 >> 31 /*0x1F*/;
      z[index1 + 2] = num3 << 1 | num2 >> 31 /*0x1F*/;
      z[index1 + 3] = num4 << 1 | num3 >> 31 /*0x1F*/;
      c = num4;
    }
    for (; index1 < len; ++index1)
    {
      uint num = x[index1];
      z[index1] = num << 1 | c >> 31 /*0x1F*/;
      c = num;
    }
    return c >> 31 /*0x1F*/;
  }

  public static uint ShiftUpBit(int len, uint[] x, int xOff, uint c, uint[] z, int zOff)
  {
    int num1 = 0;
    for (int index = len - 4; num1 <= index; num1 += 4)
    {
      uint num2 = x[xOff + num1];
      uint num3 = x[xOff + num1 + 1];
      uint num4 = x[xOff + num1 + 2];
      uint num5 = x[xOff + num1 + 3];
      z[zOff + num1] = num2 << 1 | c >> 31 /*0x1F*/;
      z[zOff + num1 + 1] = num3 << 1 | num2 >> 31 /*0x1F*/;
      z[zOff + num1 + 2] = num4 << 1 | num3 >> 31 /*0x1F*/;
      z[zOff + num1 + 3] = num5 << 1 | num4 >> 31 /*0x1F*/;
      c = num5;
    }
    for (; num1 < len; ++num1)
    {
      uint num6 = x[xOff + num1];
      z[zOff + num1] = num6 << 1 | c >> 31 /*0x1F*/;
      c = num6;
    }
    return c >> 31 /*0x1F*/;
  }

  public static ulong ShiftUpBit64(int len, ulong[] x, ulong c, ulong[] z)
  {
    int index1 = 0;
    for (int index2 = len - 4; index1 <= index2; index1 += 4)
    {
      ulong num1 = x[index1];
      ulong num2 = x[index1 + 1];
      ulong num3 = x[index1 + 2];
      ulong num4 = x[index1 + 3];
      z[index1] = num1 << 1 | c >> 63 /*0x3F*/;
      z[index1 + 1] = num2 << 1 | num1 >> 63 /*0x3F*/;
      z[index1 + 2] = num3 << 1 | num2 >> 63 /*0x3F*/;
      z[index1 + 3] = num4 << 1 | num3 >> 63 /*0x3F*/;
      c = num4;
    }
    for (; index1 < len; ++index1)
    {
      ulong num = x[index1];
      z[index1] = num << 1 | c >> 63 /*0x3F*/;
      c = num;
    }
    return c >> 63 /*0x3F*/;
  }

  public static ulong ShiftUpBit64(int len, ulong[] x, int xOff, ulong c, ulong[] z, int zOff)
  {
    int num1 = 0;
    for (int index = len - 4; num1 <= index; num1 += 4)
    {
      ulong num2 = x[xOff + num1];
      ulong num3 = x[xOff + num1 + 1];
      ulong num4 = x[xOff + num1 + 2];
      ulong num5 = x[xOff + num1 + 3];
      z[zOff + num1] = num2 << 1 | c >> 63 /*0x3F*/;
      z[zOff + num1 + 1] = num3 << 1 | num2 >> 63 /*0x3F*/;
      z[zOff + num1 + 2] = num4 << 1 | num3 >> 63 /*0x3F*/;
      z[zOff + num1 + 3] = num5 << 1 | num4 >> 63 /*0x3F*/;
      c = num5;
    }
    for (; num1 < len; ++num1)
    {
      ulong num6 = x[xOff + num1];
      z[zOff + num1] = num6 << 1 | c >> 63 /*0x3F*/;
      c = num6;
    }
    return c >> 63 /*0x3F*/;
  }

  public static uint ShiftUpBits(int len, uint[] z, int bits, uint c)
  {
    int index1 = 0;
    for (int index2 = len - 4; index1 <= index2; index1 += 4)
    {
      uint num1 = z[index1];
      uint num2 = z[index1 + 1];
      uint num3 = z[index1 + 2];
      uint num4 = z[index1 + 3];
      z[index1] = num1 << bits | c >> -bits;
      z[index1 + 1] = num2 << bits | num1 >> -bits;
      z[index1 + 2] = num3 << bits | num2 >> -bits;
      z[index1 + 3] = num4 << bits | num3 >> -bits;
      c = num4;
    }
    for (; index1 < len; ++index1)
    {
      uint num = z[index1];
      z[index1] = num << bits | c >> -bits;
      c = num;
    }
    return c >> -bits;
  }

  public static uint ShiftUpBits(int len, uint[] z, int zOff, int bits, uint c)
  {
    int num1 = 0;
    for (int index = len - 4; num1 <= index; num1 += 4)
    {
      uint num2 = z[zOff + num1];
      uint num3 = z[zOff + num1 + 1];
      uint num4 = z[zOff + num1 + 2];
      uint num5 = z[zOff + num1 + 3];
      z[zOff + num1] = num2 << bits | c >> -bits;
      z[zOff + num1 + 1] = num3 << bits | num2 >> -bits;
      z[zOff + num1 + 2] = num4 << bits | num3 >> -bits;
      z[zOff + num1 + 3] = num5 << bits | num4 >> -bits;
      c = num5;
    }
    for (; num1 < len; ++num1)
    {
      uint num6 = z[zOff + num1];
      z[zOff + num1] = num6 << bits | c >> -bits;
      c = num6;
    }
    return c >> -bits;
  }

  public static uint ShiftUpBits(int len, uint[] x, int bits, uint c, uint[] z)
  {
    int index1 = 0;
    for (int index2 = len - 4; index1 <= index2; index1 += 4)
    {
      uint num1 = x[index1];
      uint num2 = x[index1 + 1];
      uint num3 = x[index1 + 2];
      uint num4 = x[index1 + 3];
      z[index1] = num1 << bits | c >> -bits;
      z[index1 + 1] = num2 << bits | num1 >> -bits;
      z[index1 + 2] = num3 << bits | num2 >> -bits;
      z[index1 + 3] = num4 << bits | num3 >> -bits;
      c = num4;
    }
    for (; index1 < len; ++index1)
    {
      uint num = x[index1];
      z[index1] = num << bits | c >> -bits;
      c = num;
    }
    return c >> -bits;
  }

  public static uint ShiftUpBits(
    int len,
    uint[] x,
    int xOff,
    int bits,
    uint c,
    uint[] z,
    int zOff)
  {
    int num1 = 0;
    for (int index = len - 4; num1 <= index; num1 += 4)
    {
      uint num2 = x[xOff + num1];
      uint num3 = x[xOff + num1 + 1];
      uint num4 = x[xOff + num1 + 2];
      uint num5 = x[xOff + num1 + 3];
      z[zOff + num1] = num2 << bits | c >> -bits;
      z[zOff + num1 + 1] = num3 << bits | num2 >> -bits;
      z[zOff + num1 + 2] = num4 << bits | num3 >> -bits;
      z[zOff + num1 + 3] = num5 << bits | num4 >> -bits;
      c = num5;
    }
    for (; num1 < len; ++num1)
    {
      uint num6 = x[xOff + num1];
      z[zOff + num1] = num6 << bits | c >> -bits;
      c = num6;
    }
    return c >> -bits;
  }

  public static ulong ShiftUpBits64(int len, ulong[] z, int bits, ulong c)
  {
    int index1 = 0;
    for (int index2 = len - 4; index1 <= index2; index1 += 4)
    {
      ulong num1 = z[index1];
      ulong num2 = z[index1 + 1];
      ulong num3 = z[index1 + 2];
      ulong num4 = z[index1 + 3];
      z[index1] = num1 << bits | c >> -bits;
      z[index1 + 1] = num2 << bits | num1 >> -bits;
      z[index1 + 2] = num3 << bits | num2 >> -bits;
      z[index1 + 3] = num4 << bits | num3 >> -bits;
      c = num4;
    }
    for (; index1 < len; ++index1)
    {
      ulong num = z[index1];
      z[index1] = num << bits | c >> -bits;
      c = num;
    }
    return c >> -bits;
  }

  public static ulong ShiftUpBits64(int len, ulong[] z, int zOff, int bits, ulong c)
  {
    int num1 = 0;
    for (int index = len - 4; num1 <= index; num1 += 4)
    {
      ulong num2 = z[zOff + num1];
      ulong num3 = z[zOff + num1 + 1];
      ulong num4 = z[zOff + num1 + 2];
      ulong num5 = z[zOff + num1 + 3];
      z[zOff + num1] = num2 << bits | c >> -bits;
      z[zOff + num1 + 1] = num3 << bits | num2 >> -bits;
      z[zOff + num1 + 2] = num4 << bits | num3 >> -bits;
      z[zOff + num1 + 3] = num5 << bits | num4 >> -bits;
      c = num5;
    }
    for (; num1 < len; ++num1)
    {
      ulong num6 = z[zOff + num1];
      z[zOff + num1] = num6 << bits | c >> -bits;
      c = num6;
    }
    return c >> -bits;
  }

  public static ulong ShiftUpBits64(int len, ulong[] x, int bits, ulong c, ulong[] z)
  {
    int index1 = 0;
    for (int index2 = len - 4; index1 <= index2; index1 += 4)
    {
      ulong num1 = x[index1];
      ulong num2 = x[index1 + 1];
      ulong num3 = x[index1 + 2];
      ulong num4 = x[index1 + 3];
      z[index1] = num1 << bits | c >> -bits;
      z[index1 + 1] = num2 << bits | num1 >> -bits;
      z[index1 + 2] = num3 << bits | num2 >> -bits;
      z[index1 + 3] = num4 << bits | num3 >> -bits;
      c = num4;
    }
    for (; index1 < len; ++index1)
    {
      ulong num = x[index1];
      z[index1] = num << bits | c >> -bits;
      c = num;
    }
    return c >> -bits;
  }

  public static ulong ShiftUpBits64(
    int len,
    ulong[] x,
    int xOff,
    int bits,
    ulong c,
    ulong[] z,
    int zOff)
  {
    int num1 = 0;
    for (int index = len - 4; num1 <= index; num1 += 4)
    {
      ulong num2 = x[xOff + num1];
      ulong num3 = x[xOff + num1 + 1];
      ulong num4 = x[xOff + num1 + 2];
      ulong num5 = x[xOff + num1 + 3];
      z[zOff + num1] = num2 << bits | c >> -bits;
      z[zOff + num1 + 1] = num3 << bits | num2 >> -bits;
      z[zOff + num1 + 2] = num4 << bits | num3 >> -bits;
      z[zOff + num1 + 3] = num5 << bits | num4 >> -bits;
      c = num5;
    }
    for (; num1 < len; ++num1)
    {
      ulong num6 = x[xOff + num1];
      z[zOff + num1] = num6 << bits | c >> -bits;
      c = num6;
    }
    return c >> -bits;
  }

  public static void Square(int len, uint[] x, uint[] zz)
  {
    int len1 = len << 1;
    uint num1 = 0;
    int num2 = len;
    int num3 = len1;
    do
    {
      long num4 = (long) x[--num2];
      ulong num5 = (ulong) (num4 * num4);
      int num6;
      zz[num6 = num3 - 1] = num1 << 31 /*0x1F*/ | (uint) (num5 >> 33);
      zz[num3 = num6 - 1] = (uint) (num5 >> 1);
      num1 = (uint) num5;
    }
    while (num2 > 0);
    ulong num7 = 0;
    int index1 = 2;
    for (int xPos = 1; xPos < len; ++xPos)
    {
      ulong num8 = num7 + (ulong) Nat.SquareWordAddTo(x, xPos, zz) + (ulong) zz[index1];
      uint[] numArray1 = zz;
      int index2 = index1;
      int index3 = index2 + 1;
      int num9 = (int) (uint) num8;
      numArray1[index2] = (uint) num9;
      ulong num10 = (num8 >> 32 /*0x20*/) + (ulong) zz[index3];
      uint[] numArray2 = zz;
      int index4 = index3;
      index1 = index4 + 1;
      int num11 = (int) (uint) num10;
      numArray2[index4] = (uint) num11;
      num7 = num10 >> 32 /*0x20*/;
    }
    int num12 = (int) Nat.ShiftUpBit(len1, zz, x[0] << 31 /*0x1F*/);
  }

  public static void Square(int len, uint[] x, int xOff, uint[] zz, int zzOff)
  {
    int len1 = len << 1;
    uint num1 = 0;
    int num2 = len;
    int num3 = len1;
    do
    {
      long num4 = (long) x[xOff + --num2];
      ulong num5 = (ulong) (num4 * num4);
      int num6;
      zz[zzOff + (num6 = num3 - 1)] = num1 << 31 /*0x1F*/ | (uint) (num5 >> 33);
      zz[zzOff + (num3 = num6 - 1)] = (uint) (num5 >> 1);
      num1 = (uint) num5;
    }
    while (num2 > 0);
    ulong num7 = 0;
    int index1 = zzOff + 2;
    for (int xPos = 1; xPos < len; ++xPos)
    {
      ulong num8 = num7 + (ulong) Nat.SquareWordAddTo(x, xOff, xPos, zz, zzOff) + (ulong) zz[index1];
      uint[] numArray1 = zz;
      int index2 = index1;
      int index3 = index2 + 1;
      int num9 = (int) (uint) num8;
      numArray1[index2] = (uint) num9;
      ulong num10 = (num8 >> 32 /*0x20*/) + (ulong) zz[index3];
      uint[] numArray2 = zz;
      int index4 = index3;
      index1 = index4 + 1;
      int num11 = (int) (uint) num10;
      numArray2[index4] = (uint) num11;
      num7 = num10 >> 32 /*0x20*/;
    }
    int num12 = (int) Nat.ShiftUpBit(len1, zz, zzOff, x[xOff] << 31 /*0x1F*/);
  }

  public static uint SquareWordAddTo(uint[] x, int xPos, uint[] z)
  {
    ulong num1 = 0;
    ulong num2 = (ulong) x[xPos];
    int index = 0;
    do
    {
      ulong num3 = num1 + (num2 * (ulong) x[index] + (ulong) z[xPos + index]);
      z[xPos + index] = (uint) num3;
      num1 = num3 >> 32 /*0x20*/;
    }
    while (++index < xPos);
    return (uint) num1;
  }

  public static uint SquareWordAddTo(uint[] x, int xOff, int xPos, uint[] z, int zOff)
  {
    ulong num1 = 0;
    ulong num2 = (ulong) x[xOff + xPos];
    int num3 = 0;
    do
    {
      ulong num4 = num1 + (ulong) ((long) num2 * ((long) x[xOff + num3] & (long) uint.MaxValue) + ((long) z[xPos + zOff] & (long) uint.MaxValue));
      z[xPos + zOff] = (uint) num4;
      num1 = num4 >> 32 /*0x20*/;
      ++zOff;
    }
    while (++num3 < xPos);
    return (uint) num1;
  }

  public static int Sub(int len, uint[] x, uint[] y, uint[] z)
  {
    long num1 = 0;
    for (int index = 0; index < len; ++index)
    {
      long num2 = num1 + ((long) x[index] - (long) y[index]);
      z[index] = (uint) num2;
      num1 = num2 >> 32 /*0x20*/;
    }
    return (int) num1;
  }

  public static int Sub(int len, uint[] x, int xOff, uint[] y, int yOff, uint[] z, int zOff)
  {
    long num1 = 0;
    for (int index = 0; index < len; ++index)
    {
      long num2 = num1 + ((long) x[xOff + index] - (long) y[yOff + index]);
      z[zOff + index] = (uint) num2;
      num1 = num2 >> 32 /*0x20*/;
    }
    return (int) num1;
  }

  public static int Sub33At(int len, uint x, uint[] z, int zPos)
  {
    long num1 = (long) z[zPos] - (long) x;
    z[zPos] = (uint) num1;
    long num2 = (num1 >> 32 /*0x20*/) + ((long) z[zPos + 1] - 1L);
    z[zPos + 1] = (uint) num2;
    return num2 >> 32 /*0x20*/ != 0L ? Nat.DecAt(len, z, zPos + 2) : 0;
  }

  public static int Sub33At(int len, uint x, uint[] z, int zOff, int zPos)
  {
    long num1 = (long) z[zOff + zPos] - (long) x;
    z[zOff + zPos] = (uint) num1;
    long num2 = (num1 >> 32 /*0x20*/) + ((long) z[zOff + zPos + 1] - 1L);
    z[zOff + zPos + 1] = (uint) num2;
    return num2 >> 32 /*0x20*/ != 0L ? Nat.DecAt(len, z, zOff, zPos + 2) : 0;
  }

  public static int Sub33From(int len, uint x, uint[] z)
  {
    long num1 = (long) z[0] - (long) x;
    z[0] = (uint) num1;
    long num2 = (num1 >> 32 /*0x20*/) + ((long) z[1] - 1L);
    z[1] = (uint) num2;
    return num2 >> 32 /*0x20*/ != 0L ? Nat.DecAt(len, z, 2) : 0;
  }

  public static int Sub33From(int len, uint x, uint[] z, int zOff)
  {
    long num1 = (long) z[zOff] - (long) x;
    z[zOff] = (uint) num1;
    long num2 = (num1 >> 32 /*0x20*/) + ((long) z[zOff + 1] - 1L);
    z[zOff + 1] = (uint) num2;
    return num2 >> 32 /*0x20*/ != 0L ? Nat.DecAt(len, z, zOff, 2) : 0;
  }

  public static int SubBothFrom(int len, uint[] x, uint[] y, uint[] z)
  {
    long num1 = 0;
    for (int index = 0; index < len; ++index)
    {
      long num2 = num1 + ((long) z[index] - (long) x[index] - (long) y[index]);
      z[index] = (uint) num2;
      num1 = num2 >> 32 /*0x20*/;
    }
    return (int) num1;
  }

  public static int SubBothFrom(
    int len,
    uint[] x,
    int xOff,
    uint[] y,
    int yOff,
    uint[] z,
    int zOff)
  {
    long num1 = 0;
    for (int index = 0; index < len; ++index)
    {
      long num2 = num1 + ((long) z[zOff + index] - (long) x[xOff + index] - (long) y[yOff + index]);
      z[zOff + index] = (uint) num2;
      num1 = num2 >> 32 /*0x20*/;
    }
    return (int) num1;
  }

  public static int SubDWordAt(int len, ulong x, uint[] z, int zPos)
  {
    long num1 = (long) z[zPos] - ((long) x & (long) uint.MaxValue);
    z[zPos] = (uint) num1;
    long num2 = (num1 >> 32 /*0x20*/) + ((long) z[zPos + 1] - (long) (x >> 32 /*0x20*/));
    z[zPos + 1] = (uint) num2;
    return num2 >> 32 /*0x20*/ != 0L ? Nat.DecAt(len, z, zPos + 2) : 0;
  }

  public static int SubDWordAt(int len, ulong x, uint[] z, int zOff, int zPos)
  {
    long num1 = (long) z[zOff + zPos] - ((long) x & (long) uint.MaxValue);
    z[zOff + zPos] = (uint) num1;
    long num2 = (num1 >> 32 /*0x20*/) + ((long) z[zOff + zPos + 1] - (long) (x >> 32 /*0x20*/));
    z[zOff + zPos + 1] = (uint) num2;
    return num2 >> 32 /*0x20*/ != 0L ? Nat.DecAt(len, z, zOff, zPos + 2) : 0;
  }

  public static int SubDWordFrom(int len, ulong x, uint[] z)
  {
    long num1 = (long) z[0] - ((long) x & (long) uint.MaxValue);
    z[0] = (uint) num1;
    long num2 = (num1 >> 32 /*0x20*/) + ((long) z[1] - (long) (x >> 32 /*0x20*/));
    z[1] = (uint) num2;
    return num2 >> 32 /*0x20*/ != 0L ? Nat.DecAt(len, z, 2) : 0;
  }

  public static int SubDWordFrom(int len, ulong x, uint[] z, int zOff)
  {
    long num1 = (long) z[zOff] - ((long) x & (long) uint.MaxValue);
    z[zOff] = (uint) num1;
    long num2 = (num1 >> 32 /*0x20*/) + ((long) z[zOff + 1] - (long) (x >> 32 /*0x20*/));
    z[zOff + 1] = (uint) num2;
    return num2 >> 32 /*0x20*/ != 0L ? Nat.DecAt(len, z, zOff, 2) : 0;
  }

  public static int SubFrom(int len, uint[] x, uint[] z)
  {
    long num1 = 0;
    for (int index = 0; index < len; ++index)
    {
      long num2 = num1 + ((long) z[index] - (long) x[index]);
      z[index] = (uint) num2;
      num1 = num2 >> 32 /*0x20*/;
    }
    return (int) num1;
  }

  public static int SubFrom(int len, uint[] x, int xOff, uint[] z, int zOff)
  {
    long num1 = 0;
    for (int index = 0; index < len; ++index)
    {
      long num2 = num1 + ((long) z[zOff + index] - (long) x[xOff + index]);
      z[zOff + index] = (uint) num2;
      num1 = num2 >> 32 /*0x20*/;
    }
    return (int) num1;
  }

  public static int SubWordAt(int len, uint x, uint[] z, int zPos)
  {
    long num = (long) z[zPos] - (long) x;
    z[zPos] = (uint) num;
    return num >> 32 /*0x20*/ != 0L ? Nat.DecAt(len, z, zPos + 1) : 0;
  }

  public static int SubWordAt(int len, uint x, uint[] z, int zOff, int zPos)
  {
    long num = (long) z[zOff + zPos] - (long) x;
    z[zOff + zPos] = (uint) num;
    return num >> 32 /*0x20*/ != 0L ? Nat.DecAt(len, z, zOff, zPos + 1) : 0;
  }

  public static int SubWordFrom(int len, uint x, uint[] z)
  {
    long num = (long) z[0] - (long) x;
    z[0] = (uint) num;
    return num >> 32 /*0x20*/ != 0L ? Nat.DecAt(len, z, 1) : 0;
  }

  public static int SubWordFrom(int len, uint x, uint[] z, int zOff)
  {
    long num = (long) z[zOff] - (long) x;
    z[zOff] = (uint) num;
    return num >> 32 /*0x20*/ != 0L ? Nat.DecAt(len, z, zOff, 1) : 0;
  }

  public static BigInteger ToBigInteger(int len, uint[] x)
  {
    byte[] numArray = new byte[len << 2];
    int index = len;
    int off = 0;
    while (--index >= 0)
    {
      Pack.UInt32_To_BE(x[index], numArray, off);
      off += 4;
    }
    return new BigInteger(1, numArray);
  }

  public static void Xor(int len, uint[] x, uint[] y, uint[] z)
  {
    for (int index = 0; index < len; ++index)
      z[index] = x[index] ^ y[index];
  }

  public static void Xor(int len, uint[] x, int xOff, uint[] y, int yOff, uint[] z, int zOff)
  {
    for (int index = 0; index < len; ++index)
      z[zOff + index] = x[xOff + index] ^ y[yOff + index];
  }

  public static void Xor64(int len, ulong[] x, ulong y, ulong[] z)
  {
    for (int index = 0; index < len; ++index)
      z[index] = x[index] ^ y;
  }

  public static void Xor64(int len, ulong[] x, int xOff, ulong y, ulong[] z, int zOff)
  {
    for (int index = 0; index < len; ++index)
      z[zOff + index] = x[xOff + index] ^ y;
  }

  public static void Xor64(int len, ulong[] x, ulong[] y, ulong[] z)
  {
    for (int index = 0; index < len; ++index)
      z[index] = x[index] ^ y[index];
  }

  public static void Xor64(
    int len,
    ulong[] x,
    int xOff,
    ulong[] y,
    int yOff,
    ulong[] z,
    int zOff)
  {
    for (int index = 0; index < len; ++index)
      z[zOff + index] = x[xOff + index] ^ y[yOff + index];
  }

  public static void XorTo(int len, uint[] x, uint[] z)
  {
    for (int index = 0; index < len; ++index)
      z[index] ^= x[index];
  }

  public static void XorTo(int len, uint[] x, int xOff, uint[] z, int zOff)
  {
    for (int index = 0; index < len; ++index)
      z[zOff + index] ^= x[xOff + index];
  }

  public static void XorTo64(int len, ulong[] x, ulong[] z)
  {
    for (int index = 0; index < len; ++index)
      z[index] ^= x[index];
  }

  public static void XorTo64(int len, ulong[] x, int xOff, ulong[] z, int zOff)
  {
    for (int index = 0; index < len; ++index)
      z[zOff + index] ^= x[xOff + index];
  }

  public static void Zero(int len, uint[] z)
  {
    for (int index = 0; index < len; ++index)
      z[index] = 0U;
  }

  public static void Zero64(int len, ulong[] z)
  {
    for (int index = 0; index < len; ++index)
      z[index] = 0UL;
  }
}
