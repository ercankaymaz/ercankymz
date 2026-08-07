// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.Raw.Mod
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Math.Raw;

internal static class Mod
{
  private const int M30 = 1073741823 /*0x3FFFFFFF*/;
  private const ulong M32UL = 4294967295 /*0xFFFFFFFF*/;

  public static void CheckedModOddInverse(uint[] m, uint[] x, uint[] z)
  {
    if (Mod.ModOddInverse(m, x, z) == 0U)
      throw new ArithmeticException("Inverse does not exist.");
  }

  public static void CheckedModOddInverseVar(uint[] m, uint[] x, uint[] z)
  {
    if (!Mod.ModOddInverseVar(m, x, z))
      throw new ArithmeticException("Inverse does not exist.");
  }

  public static uint Inverse32(uint d)
  {
    uint num1 = d;
    uint num2 = num1 * (uint) (2 - (int) d * (int) num1);
    uint num3 = num2 * (uint) (2 - (int) d * (int) num2);
    uint num4 = num3 * (uint) (2 - (int) d * (int) num3);
    return num4 * (uint) (2 - (int) d * (int) num4);
  }

  public static ulong Inverse64(ulong d)
  {
    ulong num1 = d;
    ulong num2 = num1 * (ulong) (2L - (long) d * (long) num1);
    ulong num3 = num2 * (ulong) (2L - (long) d * (long) num2);
    ulong num4 = num3 * (ulong) (2L - (long) d * (long) num3);
    ulong num5 = num4 * (ulong) (2L - (long) d * (long) num4);
    return num5 * (ulong) (2L - (long) d * (long) num5);
  }

  public static uint ModOddInverse(uint[] m, uint[] x, uint[] z)
  {
    int length1 = m.Length;
    int bits = (length1 << 5) - Integers.NumberOfLeadingZeros((int) m[length1 - 1]);
    int length2 = (bits + 29) / 30;
    int[] t = new int[4];
    int[] numArray1 = new int[length2];
    int[] E = new int[length2];
    int[] numArray2 = new int[length2];
    int[] numArray3 = new int[length2];
    int[] numArray4 = new int[length2];
    E[0] = 1;
    Mod.Encode30(bits, x, 0, numArray3, 0);
    Mod.Encode30(bits, m, 0, numArray4, 0);
    Array.Copy((Array) numArray4, 0, (Array) numArray2, 0, length2);
    int delta = 0;
    int m0Inv32 = (int) Mod.Inverse32((uint) numArray4[0]);
    int maximumDivsteps = Mod.GetMaximumDivsteps(bits);
    for (int index = 0; index < maximumDivsteps; index += 30)
    {
      delta = Mod.Divsteps30(delta, numArray2[0], numArray3[0], t);
      Mod.UpdateDE30(length2, numArray1, E, t, m0Inv32, numArray4);
      Mod.UpdateFG30(length2, numArray2, numArray3, t);
    }
    int num = numArray2[length2 - 1] >> 31 /*0x1F*/;
    Mod.CNegate30(length2, num, numArray2);
    Mod.CNormalize30(length2, num, numArray1, numArray4);
    Mod.Decode30(bits, numArray1, 0, z, 0);
    return (uint) (Mod.EqualTo(length2, numArray2, 1) & Mod.EqualToZero(length2, numArray3));
  }

  public static bool ModOddInverseVar(uint[] m, uint[] x, uint[] z)
  {
    int length1 = m.Length;
    int bits = (length1 << 5) - Integers.NumberOfLeadingZeros((int) m[length1 - 1]);
    int length2 = (bits + 29) / 30;
    int[] t = new int[4];
    int[] numArray1 = new int[length2];
    int[] E = new int[length2];
    int[] numArray2 = new int[length2];
    int[] numArray3 = new int[length2];
    int[] numArray4 = new int[length2];
    E[0] = 1;
    Mod.Encode30(bits, x, 0, numArray3, 0);
    Mod.Encode30(bits, m, 0, numArray4, 0);
    Array.Copy((Array) numArray4, 0, (Array) numArray2, 0, length2);
    int eta = -1 - (Integers.NumberOfLeadingZeros(numArray3[length2 - 1] | 1) - (length2 * 30 + 2 - bits));
    int len30 = length2;
    int num1 = length2;
    int m0Inv32 = (int) Mod.Inverse32((uint) numArray4[0]);
    int maximumDivsteps = Mod.GetMaximumDivsteps(bits);
    int num2 = 0;
    while (!Mod.EqualToZeroVar_Unlikely(num1, numArray3))
    {
      if (num2 >= maximumDivsteps)
        return false;
      num2 += 30;
      eta = Mod.Divsteps30Var(eta, numArray2[0], numArray3[0], t);
      Mod.UpdateDE30(len30, numArray1, E, t, m0Inv32, numArray4);
      Mod.UpdateFG30(num1, numArray2, numArray3, t);
      int num3 = numArray2[num1 - 1];
      int num4 = numArray3[num1 - 1];
      if ((num1 - 2 >> 31 /*0x1F*/ | num3 ^ num3 >> 31 /*0x1F*/ | num4 ^ num4 >> 31 /*0x1F*/) == 0)
      {
        numArray2[num1 - 2] |= num3 << 30;
        numArray3[num1 - 2] |= num4 << 30;
        --num1;
      }
    }
    int num5 = numArray2[num1 - 1] >> 31 /*0x1F*/;
    int num6 = numArray1[len30 - 1] >> 31 /*0x1F*/;
    if (num6 < 0)
      num6 = Mod.Add30(len30, numArray1, numArray4);
    if (num5 < 0)
    {
      num6 = Mod.Negate30(len30, numArray1);
      Mod.Negate30(num1, numArray2);
    }
    if (!Mod.EqualToOneVar_Expected(num1, numArray2))
      return false;
    if (num6 < 0)
      Mod.Add30(len30, numArray1, numArray4);
    Mod.Decode30(bits, numArray1, 0, z, 0);
    return true;
  }

  public static uint[] Random(SecureRandom random, uint[] p)
  {
    int length = p.Length;
    uint[] numArray1 = Nat.Create(length);
    uint num1 = p[length - 1];
    uint num2 = num1 | num1 >> 1;
    uint num3 = num2 | num2 >> 2;
    uint num4 = num3 | num3 >> 4;
    uint num5 = num4 | num4 >> 8;
    uint num6 = num5 | num5 >> 16 /*0x10*/;
    byte[] numArray2 = new byte[length << 2];
    do
    {
      random.NextBytes(numArray2);
      Pack.BE_To_UInt32(numArray2, 0, numArray1);
      numArray1[length - 1] &= num6;
    }
    while (Nat.Gte(length, numArray1, p));
    return numArray1;
  }

  private static int Add30(int len30, int[] D, int[] M)
  {
    int num1 = 0;
    int index1 = len30 - 1;
    for (int index2 = 0; index2 < index1; ++index2)
    {
      int num2 = num1 + (D[index2] + M[index2]);
      D[index2] = num2 & 1073741823 /*0x3FFFFFFF*/;
      num1 = num2 >> 30;
    }
    int num3 = num1 + (D[index1] + M[index1]);
    D[index1] = num3;
    return num3 >> 30;
  }

  private static void CNegate30(int len30, int cond, int[] D)
  {
    int num1 = 0;
    int index1 = len30 - 1;
    for (int index2 = 0; index2 < index1; ++index2)
    {
      int num2 = num1 + ((D[index2] ^ cond) - cond);
      D[index2] = num2 & 1073741823 /*0x3FFFFFFF*/;
      num1 = num2 >> 30;
    }
    int num3 = num1 + ((D[index1] ^ cond) - cond);
    D[index1] = num3;
  }

  private static void CNormalize30(int len30, int condNegate, int[] D, int[] M)
  {
    int index1 = len30 - 1;
    int num1 = 0;
    int num2 = D[index1] >> 31 /*0x1F*/;
    for (int index2 = 0; index2 < index1; ++index2)
    {
      int num3 = (D[index2] + (M[index2] & num2) ^ condNegate) - condNegate;
      int num4 = num1 + num3;
      D[index2] = num4 & 1073741823 /*0x3FFFFFFF*/;
      num1 = num4 >> 30;
    }
    int num5 = (D[index1] + (M[index1] & num2) ^ condNegate) - condNegate;
    int num6 = num1 + num5;
    D[index1] = num6;
    int num7 = 0;
    int num8 = D[index1] >> 31 /*0x1F*/;
    for (int index3 = 0; index3 < index1; ++index3)
    {
      int num9 = D[index3] + (M[index3] & num8);
      int num10 = num7 + num9;
      D[index3] = num10 & 1073741823 /*0x3FFFFFFF*/;
      num7 = num10 >> 30;
    }
    int num11 = D[index1] + (M[index1] & num8);
    int num12 = num7 + num11;
    D[index1] = num12;
  }

  private static void Decode30(int bits, int[] x, int xOff, uint[] z, int zOff)
  {
    int num1 = 0;
    ulong num2 = 0;
    for (; bits > 0; bits -= 32 /*0x20*/)
    {
      for (; num1 < System.Math.Min(32 /*0x20*/, bits); num1 += 30)
        num2 |= (ulong) x[xOff++] << num1;
      z[zOff++] = (uint) num2;
      num2 >>= 32 /*0x20*/;
      num1 -= 32 /*0x20*/;
    }
  }

  private static int Divsteps30(int delta, int f0, int g0, int[] t)
  {
    int num1 = 1073741824 /*0x40000000*/;
    int num2 = 0;
    int num3 = 0;
    int num4 = 1073741824 /*0x40000000*/;
    int num5 = f0;
    int num6 = g0;
    for (int index = 0; index < 30; ++index)
    {
      int num7 = delta >> 31 /*0x1F*/;
      int num8 = -(num6 & 1);
      int num9 = num5 ^ num7;
      int num10 = num1 ^ num7;
      int num11 = num2 ^ num7;
      int num12 = num6 - (num9 & num8);
      int num13 = num3 - (num10 & num8);
      int num14 = num4 - (num11 & num8);
      int num15 = num8 & ~num7;
      delta = (delta ^ num15) - (num15 - 1);
      num5 += num12 & num15;
      num1 += num13 & num15;
      num2 += num14 & num15;
      num6 = num12 >> 1;
      num3 = num13 >> 1;
      num4 = num14 >> 1;
    }
    t[0] = num1;
    t[1] = num2;
    t[2] = num3;
    t[3] = num4;
    return delta;
  }

  private static int Divsteps30Var(int eta, int f0, int g0, int[] t)
  {
    int num1 = 1;
    int num2 = 0;
    int num3 = 0;
    int num4 = 1;
    int num5 = f0;
    int num6 = g0;
    int num7 = 30;
    while (true)
    {
      int num8 = Integers.NumberOfTrailingZeros(num6 | -1 << num7);
      int num9 = num6 >> num8;
      num1 <<= num8;
      num2 <<= num8;
      eta -= num8;
      num7 -= num8;
      if (num7 > 0)
      {
        int num10;
        if (eta < 0)
        {
          eta = -eta;
          int num11 = num5;
          num5 = num9;
          num9 = -num11;
          int num12 = num1;
          num1 = num3;
          num3 = -num12;
          int num13 = num2;
          num2 = num4;
          num4 = -num13;
          int num14 = (int) (uint.MaxValue >> 32 /*0x20*/ - (eta + 1 > num7 ? num7 : eta + 1)) & 63 /*0x3F*/;
          num10 = num5 * num9 * (num5 * num5 - 2) & num14;
        }
        else
        {
          int num15 = (int) (uint.MaxValue >> 32 /*0x20*/ - (eta + 1 > num7 ? num7 : eta + 1)) & 15;
          num10 = -(num5 + ((num5 + 1 & 4) << 1)) * num9 & num15;
        }
        num6 = num9 + num5 * num10;
        num3 += num1 * num10;
        num4 += num2 * num10;
      }
      else
        break;
    }
    t[0] = num1;
    t[1] = num2;
    t[2] = num3;
    t[3] = num4;
    return eta;
  }

  private static void Encode30(int bits, uint[] x, int xOff, int[] z, int zOff)
  {
    int num1 = 0;
    ulong num2 = 0;
    for (; bits > 0; bits -= 30)
    {
      if (num1 < System.Math.Min(30, bits))
      {
        num2 |= (ulong) (((long) x[xOff++] & (long) uint.MaxValue) << num1);
        num1 += 32 /*0x20*/;
      }
      z[zOff++] = (int) num2 & 1073741823 /*0x3FFFFFFF*/;
      num2 >>= 30;
      num1 -= 30;
    }
  }

  private static int EqualTo(int len, int[] x, int y)
  {
    int num = x[0] ^ y;
    for (int index = 1; index < len; ++index)
      num |= x[index];
    return (num >>> 1 | num & 1) - 1 >> 31 /*0x1F*/;
  }

  private static bool EqualToOneVar_Expected(int len, int[] x)
  {
    int num = x[0] ^ 1;
    for (int index = 1; index < len; ++index)
      num |= x[index];
    return num == 0;
  }

  private static int EqualToZero(int len, int[] x)
  {
    int num = 0;
    for (int index = 0; index < len; ++index)
      num |= x[index];
    return (num >>> 1 | num & 1) - 1 >> 31 /*0x1F*/;
  }

  private static bool EqualToZeroVar_Unlikely(int len, int[] x)
  {
    int num = x[0];
    if (num != 0)
      return false;
    for (int index = 1; index < len; ++index)
      num |= x[index];
    return num == 0;
  }

  private static int GetMaximumDivsteps(int bits)
  {
    return (49 * bits + (bits < 46 ? 80 /*0x50*/ : 47)) / 17;
  }

  private static int Negate30(int len30, int[] D)
  {
    int num1 = 0;
    int index1 = len30 - 1;
    for (int index2 = 0; index2 < index1; ++index2)
    {
      int num2 = num1 - D[index2];
      D[index2] = num2 & 1073741823 /*0x3FFFFFFF*/;
      num1 = num2 >> 30;
    }
    int num3 = num1 - D[index1];
    D[index1] = num3;
    return num3 >> 30;
  }

  private static void UpdateDE30(int len30, int[] D, int[] E, int[] t, int m0Inv32, int[] M)
  {
    int num1 = t[0];
    int num2 = t[1];
    int num3 = t[2];
    int num4 = t[3];
    int num5 = D[len30 - 1] >> 31 /*0x1F*/;
    int num6 = E[len30 - 1] >> 31 /*0x1F*/;
    int num7 = (num1 & num5) + (num2 & num6);
    int num8 = (num3 & num5) + (num4 & num6);
    int num9 = M[0];
    int num10 = D[0];
    int num11 = E[0];
    long num12 = (long) num1 * (long) num10 + (long) num2 * (long) num11;
    long num13 = (long) num3 * (long) num10 + (long) num4 * (long) num11;
    int num14 = num7 - (m0Inv32 * (int) num12 + num7 & 1073741823 /*0x3FFFFFFF*/);
    int num15 = num8 - (m0Inv32 * (int) num13 + num8 & 1073741823 /*0x3FFFFFFF*/);
    long num16 = num12 + (long) num9 * (long) num14;
    long num17 = num13 + (long) num9 * (long) num15;
    long num18 = num16 >> 30;
    long num19 = num17 >> 30;
    for (int index = 1; index < len30; ++index)
    {
      int num20 = M[index];
      int num21 = D[index];
      int num22 = E[index];
      long num23 = num18 + ((long) num1 * (long) num21 + (long) num2 * (long) num22 + (long) num20 * (long) num14);
      long num24 = num19 + ((long) num3 * (long) num21 + (long) num4 * (long) num22 + (long) num20 * (long) num15);
      D[index - 1] = (int) num23 & 1073741823 /*0x3FFFFFFF*/;
      num18 = num23 >> 30;
      E[index - 1] = (int) num24 & 1073741823 /*0x3FFFFFFF*/;
      num19 = num24 >> 30;
    }
    D[len30 - 1] = (int) num18;
    E[len30 - 1] = (int) num19;
  }

  private static void UpdateFG30(int len30, int[] F, int[] G, int[] t)
  {
    int num1 = t[0];
    int num2 = t[1];
    int num3 = t[2];
    int num4 = t[3];
    int num5 = F[0];
    int num6 = G[0];
    long num7 = (long) num1 * (long) num5 + (long) num2 * (long) num6;
    long num8 = (long) num3 * (long) num5 + (long) num4 * (long) num6;
    long num9 = num7 >> 30;
    long num10 = num8 >> 30;
    for (int index = 1; index < len30; ++index)
    {
      int num11 = F[index];
      int num12 = G[index];
      long num13 = num9 + ((long) num1 * (long) num11 + (long) num2 * (long) num12);
      long num14 = num10 + ((long) num3 * (long) num11 + (long) num4 * (long) num12);
      F[index - 1] = (int) num13 & 1073741823 /*0x3FFFFFFF*/;
      num9 = num13 >> 30;
      G[index - 1] = (int) num14 & 1073741823 /*0x3FFFFFFF*/;
      num10 = num14 >> 30;
    }
    F[len30 - 1] = (int) num9;
    G[len30 - 1] = (int) num10;
  }
}
