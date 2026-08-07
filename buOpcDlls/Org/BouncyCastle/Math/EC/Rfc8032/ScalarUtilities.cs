// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Rfc8032.ScalarUtilities
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;

#nullable disable
namespace Org.BouncyCastle.Math.EC.Rfc8032;

internal static class ScalarUtilities
{
  internal static void AddShifted_NP(int last, int s, uint[] Nu, uint[] Nv, uint[] _p)
  {
    int num1 = s >> 5;
    int num2 = s & 31 /*0x1F*/;
    ulong num3 = 0;
    ulong num4 = 0;
    if (num2 == 0)
    {
      for (int index = num1; index <= last; ++index)
      {
        ulong num5 = num4 + (ulong) Nu[index] + (ulong) _p[index - num1];
        ulong num6 = num3 + (ulong) _p[index] + (ulong) Nv[index - num1];
        _p[index] = (uint) num6;
        num3 = num6 >> 32 /*0x20*/;
        ulong num7 = num5 + (ulong) _p[index - num1];
        Nu[index] = (uint) num7;
        num4 = num7 >> 32 /*0x20*/;
      }
    }
    else
    {
      uint num8 = 0;
      uint num9 = 0;
      uint num10 = 0;
      for (int index = num1; index <= last; ++index)
      {
        int num11 = (int) _p[index - num1];
        uint num12 = (uint) (num11 << num2) | num8 >> -num2;
        num8 = (uint) num11;
        ulong num13 = num4 + (ulong) Nu[index] + (ulong) num12;
        int num14 = (int) Nv[index - num1];
        uint num15 = (uint) (num14 << num2) | num10 >> -num2;
        num10 = (uint) num14;
        ulong num16 = num3 + (ulong) _p[index] + (ulong) num15;
        _p[index] = (uint) num16;
        num3 = num16 >> 32 /*0x20*/;
        int num17 = (int) _p[index - num1];
        uint num18 = (uint) (num17 << num2) | num9 >> -num2;
        num9 = (uint) num17;
        ulong num19 = num13 + (ulong) num18;
        Nu[index] = (uint) num19;
        num4 = num19 >> 32 /*0x20*/;
      }
    }
  }

  internal static void AddShifted_UV(
    int last,
    int s,
    uint[] u0,
    uint[] u1,
    uint[] v0,
    uint[] v1)
  {
    int num1 = s >> 5;
    int num2 = s & 31 /*0x1F*/;
    ulong num3 = 0;
    ulong num4 = 0;
    if (num2 == 0)
    {
      for (int index = num1; index <= last; ++index)
      {
        ulong num5 = num3 + (ulong) u0[index];
        ulong num6 = num4 + (ulong) u1[index];
        ulong num7 = num5 + (ulong) v0[index - num1];
        ulong num8 = num6 + (ulong) v1[index - num1];
        u0[index] = (uint) num7;
        num3 = num7 >> 32 /*0x20*/;
        u1[index] = (uint) num8;
        num4 = num8 >> 32 /*0x20*/;
      }
    }
    else
    {
      uint num9 = 0;
      uint num10 = 0;
      for (int index = num1; index <= last; ++index)
      {
        int num11 = (int) v0[index - num1];
        uint num12 = v1[index - num1];
        uint num13 = (uint) (num11 << num2) | num9 >> -num2;
        uint num14 = num12 << num2 | num10 >> -num2;
        num9 = (uint) num11;
        num10 = num12;
        ulong num15 = num3 + (ulong) u0[index];
        ulong num16 = num4 + (ulong) u1[index];
        ulong num17 = num15 + (ulong) num13;
        ulong num18 = num16 + (ulong) num14;
        u0[index] = (uint) num17;
        num3 = num17 >> 32 /*0x20*/;
        u1[index] = (uint) num18;
        num4 = num18 >> 32 /*0x20*/;
      }
    }
  }

  internal static int GetBitLength(int last, uint[] x)
  {
    int index = last;
    uint num = x[index] >> 31 /*0x1F*/;
    while (index > 0 && (int) x[index] == (int) num)
      --index;
    return index * 32 /*0x20*/ + 32 /*0x20*/ - Integers.NumberOfLeadingZeros((int) x[index] ^ (int) num);
  }

  internal static int GetBitLengthPositive(int last, uint[] x)
  {
    int index = last;
    while (index > 0 && x[index] == 0U)
      --index;
    return index * 32 /*0x20*/ + 32 /*0x20*/ - Integers.NumberOfLeadingZeros((int) x[index]);
  }

  internal static bool LessThan(int last, uint[] x, uint[] y)
  {
    int index = last;
    while (x[index] >= y[index])
    {
      if (x[index] > y[index] || --index < 0)
        return false;
    }
    return true;
  }

  internal static void SubShifted_NP(int last, int s, uint[] Nu, uint[] Nv, uint[] _p)
  {
    int num1 = s >> 5;
    int num2 = s & 31 /*0x1F*/;
    long num3 = 0;
    long num4 = 0;
    if (num2 == 0)
    {
      for (int index = num1; index <= last; ++index)
      {
        long num5 = num4 + (long) Nu[index] - (long) _p[index - num1];
        long num6 = num3 + (long) _p[index] - (long) Nv[index - num1];
        _p[index] = (uint) num6;
        num3 = num6 >> 32 /*0x20*/;
        long num7 = num5 - (long) _p[index - num1];
        Nu[index] = (uint) num7;
        num4 = num7 >> 32 /*0x20*/;
      }
    }
    else
    {
      uint num8 = 0;
      uint num9 = 0;
      uint num10 = 0;
      for (int index = num1; index <= last; ++index)
      {
        int num11 = (int) _p[index - num1];
        uint num12 = (uint) (num11 << num2) | num8 >> -num2;
        num8 = (uint) num11;
        long num13 = num4 + (long) Nu[index] - (long) num12;
        int num14 = (int) Nv[index - num1];
        uint num15 = (uint) (num14 << num2) | num10 >> -num2;
        num10 = (uint) num14;
        long num16 = num3 + (long) _p[index] - (long) num15;
        _p[index] = (uint) num16;
        num3 = num16 >> 32 /*0x20*/;
        int num17 = (int) _p[index - num1];
        uint num18 = (uint) (num17 << num2) | num9 >> -num2;
        num9 = (uint) num17;
        long num19 = num13 - (long) num18;
        Nu[index] = (uint) num19;
        num4 = num19 >> 32 /*0x20*/;
      }
    }
  }

  internal static void SubShifted_UV(
    int last,
    int s,
    uint[] u0,
    uint[] u1,
    uint[] v0,
    uint[] v1)
  {
    int num1 = s >> 5;
    int num2 = s & 31 /*0x1F*/;
    long num3 = 0;
    long num4 = 0;
    if (num2 == 0)
    {
      for (int index = num1; index <= last; ++index)
      {
        long num5 = num3 + (long) u0[index];
        long num6 = num4 + (long) u1[index];
        long num7 = num5 - (long) v0[index - num1];
        long num8 = num6 - (long) v1[index - num1];
        u0[index] = (uint) num7;
        num3 = num7 >> 32 /*0x20*/;
        u1[index] = (uint) num8;
        num4 = num8 >> 32 /*0x20*/;
      }
    }
    else
    {
      uint num9 = 0;
      uint num10 = 0;
      for (int index = num1; index <= last; ++index)
      {
        int num11 = (int) v0[index - num1];
        uint num12 = v1[index - num1];
        uint num13 = (uint) (num11 << num2) | num9 >> -num2;
        uint num14 = num12 << num2 | num10 >> -num2;
        num9 = (uint) num11;
        num10 = num12;
        long num15 = num3 + (long) u0[index];
        long num16 = num4 + (long) u1[index];
        long num17 = num15 - (long) num13;
        long num18 = num16 - (long) num14;
        u0[index] = (uint) num17;
        num3 = num17 >> 32 /*0x20*/;
        u1[index] = (uint) num18;
        num4 = num18 >> 32 /*0x20*/;
      }
    }
  }

  internal static void Swap(ref uint[] x, ref uint[] y)
  {
    uint[] numArray = x;
    x = y;
    y = numArray;
  }
}
