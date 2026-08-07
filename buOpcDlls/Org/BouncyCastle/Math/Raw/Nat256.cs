// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.Raw.Nat256
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Utilities;

#nullable disable
namespace Org.BouncyCastle.Math.Raw;

internal static class Nat256
{
  private const ulong M = 4294967295 /*0xFFFFFFFF*/;

  public static uint Add(uint[] x, uint[] y, uint[] z)
  {
    ulong num1 = (ulong) (0L + ((long) x[0] + (long) y[0]));
    z[0] = (uint) num1;
    ulong num2 = (num1 >> 32 /*0x20*/) + ((ulong) x[1] + (ulong) y[1]);
    z[1] = (uint) num2;
    ulong num3 = (num2 >> 32 /*0x20*/) + ((ulong) x[2] + (ulong) y[2]);
    z[2] = (uint) num3;
    ulong num4 = (num3 >> 32 /*0x20*/) + ((ulong) x[3] + (ulong) y[3]);
    z[3] = (uint) num4;
    ulong num5 = (num4 >> 32 /*0x20*/) + ((ulong) x[4] + (ulong) y[4]);
    z[4] = (uint) num5;
    ulong num6 = (num5 >> 32 /*0x20*/) + ((ulong) x[5] + (ulong) y[5]);
    z[5] = (uint) num6;
    ulong num7 = (num6 >> 32 /*0x20*/) + ((ulong) x[6] + (ulong) y[6]);
    z[6] = (uint) num7;
    ulong num8 = (num7 >> 32 /*0x20*/) + ((ulong) x[7] + (ulong) y[7]);
    z[7] = (uint) num8;
    return (uint) (num8 >> 32 /*0x20*/);
  }

  public static uint Add(uint[] x, int xOff, uint[] y, int yOff, uint[] z, int zOff)
  {
    ulong num1 = (ulong) (0L + ((long) x[xOff] + (long) y[yOff]));
    z[zOff] = (uint) num1;
    ulong num2 = (num1 >> 32 /*0x20*/) + ((ulong) x[xOff + 1] + (ulong) y[yOff + 1]);
    z[zOff + 1] = (uint) num2;
    ulong num3 = (num2 >> 32 /*0x20*/) + ((ulong) x[xOff + 2] + (ulong) y[yOff + 2]);
    z[zOff + 2] = (uint) num3;
    ulong num4 = (num3 >> 32 /*0x20*/) + ((ulong) x[xOff + 3] + (ulong) y[yOff + 3]);
    z[zOff + 3] = (uint) num4;
    ulong num5 = (num4 >> 32 /*0x20*/) + ((ulong) x[xOff + 4] + (ulong) y[yOff + 4]);
    z[zOff + 4] = (uint) num5;
    ulong num6 = (num5 >> 32 /*0x20*/) + ((ulong) x[xOff + 5] + (ulong) y[yOff + 5]);
    z[zOff + 5] = (uint) num6;
    ulong num7 = (num6 >> 32 /*0x20*/) + ((ulong) x[xOff + 6] + (ulong) y[yOff + 6]);
    z[zOff + 6] = (uint) num7;
    ulong num8 = (num7 >> 32 /*0x20*/) + ((ulong) x[xOff + 7] + (ulong) y[yOff + 7]);
    z[zOff + 7] = (uint) num8;
    return (uint) (num8 >> 32 /*0x20*/);
  }

  public static uint AddBothTo(uint[] x, uint[] y, uint[] z)
  {
    ulong num1 = (ulong) (0L + ((long) x[0] + (long) y[0] + (long) z[0]));
    z[0] = (uint) num1;
    ulong num2 = (num1 >> 32 /*0x20*/) + ((ulong) x[1] + (ulong) y[1] + (ulong) z[1]);
    z[1] = (uint) num2;
    ulong num3 = (num2 >> 32 /*0x20*/) + ((ulong) x[2] + (ulong) y[2] + (ulong) z[2]);
    z[2] = (uint) num3;
    ulong num4 = (num3 >> 32 /*0x20*/) + ((ulong) x[3] + (ulong) y[3] + (ulong) z[3]);
    z[3] = (uint) num4;
    ulong num5 = (num4 >> 32 /*0x20*/) + ((ulong) x[4] + (ulong) y[4] + (ulong) z[4]);
    z[4] = (uint) num5;
    ulong num6 = (num5 >> 32 /*0x20*/) + ((ulong) x[5] + (ulong) y[5] + (ulong) z[5]);
    z[5] = (uint) num6;
    ulong num7 = (num6 >> 32 /*0x20*/) + ((ulong) x[6] + (ulong) y[6] + (ulong) z[6]);
    z[6] = (uint) num7;
    ulong num8 = (num7 >> 32 /*0x20*/) + ((ulong) x[7] + (ulong) y[7] + (ulong) z[7]);
    z[7] = (uint) num8;
    return (uint) (num8 >> 32 /*0x20*/);
  }

  public static uint AddBothTo(uint[] x, int xOff, uint[] y, int yOff, uint[] z, int zOff)
  {
    ulong num1 = (ulong) (0L + ((long) x[xOff] + (long) y[yOff] + (long) z[zOff]));
    z[zOff] = (uint) num1;
    ulong num2 = (num1 >> 32 /*0x20*/) + ((ulong) x[xOff + 1] + (ulong) y[yOff + 1] + (ulong) z[zOff + 1]);
    z[zOff + 1] = (uint) num2;
    ulong num3 = (num2 >> 32 /*0x20*/) + ((ulong) x[xOff + 2] + (ulong) y[yOff + 2] + (ulong) z[zOff + 2]);
    z[zOff + 2] = (uint) num3;
    ulong num4 = (num3 >> 32 /*0x20*/) + ((ulong) x[xOff + 3] + (ulong) y[yOff + 3] + (ulong) z[zOff + 3]);
    z[zOff + 3] = (uint) num4;
    ulong num5 = (num4 >> 32 /*0x20*/) + ((ulong) x[xOff + 4] + (ulong) y[yOff + 4] + (ulong) z[zOff + 4]);
    z[zOff + 4] = (uint) num5;
    ulong num6 = (num5 >> 32 /*0x20*/) + ((ulong) x[xOff + 5] + (ulong) y[yOff + 5] + (ulong) z[zOff + 5]);
    z[zOff + 5] = (uint) num6;
    ulong num7 = (num6 >> 32 /*0x20*/) + ((ulong) x[xOff + 6] + (ulong) y[yOff + 6] + (ulong) z[zOff + 6]);
    z[zOff + 6] = (uint) num7;
    ulong num8 = (num7 >> 32 /*0x20*/) + ((ulong) x[xOff + 7] + (ulong) y[yOff + 7] + (ulong) z[zOff + 7]);
    z[zOff + 7] = (uint) num8;
    return (uint) (num8 >> 32 /*0x20*/);
  }

  public static uint AddTo(uint[] x, uint[] z, uint cIn)
  {
    ulong num1 = (ulong) cIn + ((ulong) x[0] + (ulong) z[0]);
    z[0] = (uint) num1;
    ulong num2 = (num1 >> 32 /*0x20*/) + ((ulong) x[1] + (ulong) z[1]);
    z[1] = (uint) num2;
    ulong num3 = (num2 >> 32 /*0x20*/) + ((ulong) x[2] + (ulong) z[2]);
    z[2] = (uint) num3;
    ulong num4 = (num3 >> 32 /*0x20*/) + ((ulong) x[3] + (ulong) z[3]);
    z[3] = (uint) num4;
    ulong num5 = (num4 >> 32 /*0x20*/) + ((ulong) x[4] + (ulong) z[4]);
    z[4] = (uint) num5;
    ulong num6 = (num5 >> 32 /*0x20*/) + ((ulong) x[5] + (ulong) z[5]);
    z[5] = (uint) num6;
    ulong num7 = (num6 >> 32 /*0x20*/) + ((ulong) x[6] + (ulong) z[6]);
    z[6] = (uint) num7;
    ulong num8 = (num7 >> 32 /*0x20*/) + ((ulong) x[7] + (ulong) z[7]);
    z[7] = (uint) num8;
    return (uint) (num8 >> 32 /*0x20*/);
  }

  public static uint AddTo(uint[] x, int xOff, uint[] z, int zOff, uint cIn)
  {
    ulong num1 = (ulong) cIn + ((ulong) x[xOff] + (ulong) z[zOff]);
    z[zOff] = (uint) num1;
    ulong num2 = (num1 >> 32 /*0x20*/) + ((ulong) x[xOff + 1] + (ulong) z[zOff + 1]);
    z[zOff + 1] = (uint) num2;
    ulong num3 = (num2 >> 32 /*0x20*/) + ((ulong) x[xOff + 2] + (ulong) z[zOff + 2]);
    z[zOff + 2] = (uint) num3;
    ulong num4 = (num3 >> 32 /*0x20*/) + ((ulong) x[xOff + 3] + (ulong) z[zOff + 3]);
    z[zOff + 3] = (uint) num4;
    ulong num5 = (num4 >> 32 /*0x20*/) + ((ulong) x[xOff + 4] + (ulong) z[zOff + 4]);
    z[zOff + 4] = (uint) num5;
    ulong num6 = (num5 >> 32 /*0x20*/) + ((ulong) x[xOff + 5] + (ulong) z[zOff + 5]);
    z[zOff + 5] = (uint) num6;
    ulong num7 = (num6 >> 32 /*0x20*/) + ((ulong) x[xOff + 6] + (ulong) z[zOff + 6]);
    z[zOff + 6] = (uint) num7;
    ulong num8 = (num7 >> 32 /*0x20*/) + ((ulong) x[xOff + 7] + (ulong) z[zOff + 7]);
    z[zOff + 7] = (uint) num8;
    return (uint) (num8 >> 32 /*0x20*/);
  }

  public static uint AddToEachOther(uint[] u, int uOff, uint[] v, int vOff)
  {
    ulong num1 = (ulong) (0L + ((long) u[uOff] + (long) v[vOff]));
    u[uOff] = (uint) num1;
    v[vOff] = (uint) num1;
    ulong num2 = (num1 >> 32 /*0x20*/) + ((ulong) u[uOff + 1] + (ulong) v[vOff + 1]);
    u[uOff + 1] = (uint) num2;
    v[vOff + 1] = (uint) num2;
    ulong num3 = (num2 >> 32 /*0x20*/) + ((ulong) u[uOff + 2] + (ulong) v[vOff + 2]);
    u[uOff + 2] = (uint) num3;
    v[vOff + 2] = (uint) num3;
    ulong num4 = (num3 >> 32 /*0x20*/) + ((ulong) u[uOff + 3] + (ulong) v[vOff + 3]);
    u[uOff + 3] = (uint) num4;
    v[vOff + 3] = (uint) num4;
    ulong num5 = (num4 >> 32 /*0x20*/) + ((ulong) u[uOff + 4] + (ulong) v[vOff + 4]);
    u[uOff + 4] = (uint) num5;
    v[vOff + 4] = (uint) num5;
    ulong num6 = (num5 >> 32 /*0x20*/) + ((ulong) u[uOff + 5] + (ulong) v[vOff + 5]);
    u[uOff + 5] = (uint) num6;
    v[vOff + 5] = (uint) num6;
    ulong num7 = (num6 >> 32 /*0x20*/) + ((ulong) u[uOff + 6] + (ulong) v[vOff + 6]);
    u[uOff + 6] = (uint) num7;
    v[vOff + 6] = (uint) num7;
    ulong num8 = (num7 >> 32 /*0x20*/) + ((ulong) u[uOff + 7] + (ulong) v[vOff + 7]);
    u[uOff + 7] = (uint) num8;
    v[vOff + 7] = (uint) num8;
    return (uint) (num8 >> 32 /*0x20*/);
  }

  public static void Copy(uint[] x, uint[] z)
  {
    z[0] = x[0];
    z[1] = x[1];
    z[2] = x[2];
    z[3] = x[3];
    z[4] = x[4];
    z[5] = x[5];
    z[6] = x[6];
    z[7] = x[7];
  }

  public static void Copy(uint[] x, int xOff, uint[] z, int zOff)
  {
    z[zOff] = x[xOff];
    z[zOff + 1] = x[xOff + 1];
    z[zOff + 2] = x[xOff + 2];
    z[zOff + 3] = x[xOff + 3];
    z[zOff + 4] = x[xOff + 4];
    z[zOff + 5] = x[xOff + 5];
    z[zOff + 6] = x[xOff + 6];
    z[zOff + 7] = x[xOff + 7];
  }

  public static void Copy64(ulong[] x, ulong[] z)
  {
    z[0] = x[0];
    z[1] = x[1];
    z[2] = x[2];
    z[3] = x[3];
  }

  public static void Copy64(ulong[] x, int xOff, ulong[] z, int zOff)
  {
    z[zOff] = x[xOff];
    z[zOff + 1] = x[xOff + 1];
    z[zOff + 2] = x[xOff + 2];
    z[zOff + 3] = x[xOff + 3];
  }

  public static uint[] Create() => new uint[8];

  public static ulong[] Create64() => new ulong[4];

  public static uint[] CreateExt() => new uint[16 /*0x10*/];

  public static ulong[] CreateExt64() => new ulong[8];

  public static bool Diff(uint[] x, int xOff, uint[] y, int yOff, uint[] z, int zOff)
  {
    int num = Nat256.Gte(x, xOff, y, yOff) ? 1 : 0;
    if (num != 0)
    {
      Nat256.Sub(x, xOff, y, yOff, z, zOff);
      return num != 0;
    }
    Nat256.Sub(y, yOff, x, xOff, z, zOff);
    return num != 0;
  }

  public static bool Eq(uint[] x, uint[] y)
  {
    for (int index = 7; index >= 0; --index)
    {
      if ((int) x[index] != (int) y[index])
        return false;
    }
    return true;
  }

  public static bool Eq64(ulong[] x, ulong[] y)
  {
    for (int index = 3; index >= 0; --index)
    {
      if ((long) x[index] != (long) y[index])
        return false;
    }
    return true;
  }

  public static uint GetBit(uint[] x, int bit)
  {
    if (bit == 0)
      return x[0] & 1U;
    if ((bit & (int) byte.MaxValue) != bit)
      return 0;
    int index = bit >> 5;
    int num = bit & 31 /*0x1F*/;
    return x[index] >> num & 1U;
  }

  public static bool Gte(uint[] x, uint[] y)
  {
    for (int index = 7; index >= 0; --index)
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

  public static bool Gte(uint[] x, int xOff, uint[] y, int yOff)
  {
    for (int index = 7; index >= 0; --index)
    {
      uint num1 = x[xOff + index];
      uint num2 = y[yOff + index];
      if (num1 < num2)
        return false;
      if (num1 > num2)
        return true;
    }
    return true;
  }

  public static bool IsOne(uint[] x)
  {
    if (x[0] != 1U)
      return false;
    for (int index = 1; index < 8; ++index)
    {
      if (x[index] != 0U)
        return false;
    }
    return true;
  }

  public static bool IsOne64(ulong[] x)
  {
    if (x[0] != 1UL)
      return false;
    for (int index = 1; index < 4; ++index)
    {
      if (x[index] != 0UL)
        return false;
    }
    return true;
  }

  public static bool IsZero(uint[] x)
  {
    for (int index = 0; index < 8; ++index)
    {
      if (x[index] != 0U)
        return false;
    }
    return true;
  }

  public static bool IsZero64(ulong[] x)
  {
    for (int index = 0; index < 4; ++index)
    {
      if (x[index] != 0UL)
        return false;
    }
    return true;
  }

  public static void Mul(uint[] x, uint[] y, uint[] zz)
  {
    ulong num1 = (ulong) y[0];
    ulong num2 = (ulong) y[1];
    ulong num3 = (ulong) y[2];
    ulong num4 = (ulong) y[3];
    ulong num5 = (ulong) y[4];
    ulong num6 = (ulong) y[5];
    ulong num7 = (ulong) y[6];
    ulong num8 = (ulong) y[7];
    ulong num9 = (ulong) x[0];
    ulong num10 = (ulong) (0L + (long) num9 * (long) num1);
    zz[0] = (uint) num10;
    ulong num11 = (num10 >> 32 /*0x20*/) + num9 * num2;
    zz[1] = (uint) num11;
    ulong num12 = (num11 >> 32 /*0x20*/) + num9 * num3;
    zz[2] = (uint) num12;
    ulong num13 = (num12 >> 32 /*0x20*/) + num9 * num4;
    zz[3] = (uint) num13;
    ulong num14 = (num13 >> 32 /*0x20*/) + num9 * num5;
    zz[4] = (uint) num14;
    ulong num15 = (num14 >> 32 /*0x20*/) + num9 * num6;
    zz[5] = (uint) num15;
    ulong num16 = (num15 >> 32 /*0x20*/) + num9 * num7;
    zz[6] = (uint) num16;
    ulong num17 = (num16 >> 32 /*0x20*/) + num9 * num8;
    zz[7] = (uint) num17;
    ulong num18 = num17 >> 32 /*0x20*/;
    zz[8] = (uint) num18;
    for (int index = 1; index < 8; ++index)
    {
      ulong num19 = (ulong) x[index];
      ulong num20 = (ulong) (0L + ((long) num19 * (long) num1 + (long) zz[index]));
      zz[index] = (uint) num20;
      ulong num21 = (num20 >> 32 /*0x20*/) + (num19 * num2 + (ulong) zz[index + 1]);
      zz[index + 1] = (uint) num21;
      ulong num22 = (num21 >> 32 /*0x20*/) + (num19 * num3 + (ulong) zz[index + 2]);
      zz[index + 2] = (uint) num22;
      ulong num23 = (num22 >> 32 /*0x20*/) + (num19 * num4 + (ulong) zz[index + 3]);
      zz[index + 3] = (uint) num23;
      ulong num24 = (num23 >> 32 /*0x20*/) + (num19 * num5 + (ulong) zz[index + 4]);
      zz[index + 4] = (uint) num24;
      ulong num25 = (num24 >> 32 /*0x20*/) + (num19 * num6 + (ulong) zz[index + 5]);
      zz[index + 5] = (uint) num25;
      ulong num26 = (num25 >> 32 /*0x20*/) + (num19 * num7 + (ulong) zz[index + 6]);
      zz[index + 6] = (uint) num26;
      ulong num27 = (num26 >> 32 /*0x20*/) + (num19 * num8 + (ulong) zz[index + 7]);
      zz[index + 7] = (uint) num27;
      ulong num28 = num27 >> 32 /*0x20*/;
      zz[index + 8] = (uint) num28;
    }
  }

  public static void Mul(uint[] x, int xOff, uint[] y, int yOff, uint[] zz, int zzOff)
  {
    ulong num1 = (ulong) y[yOff];
    ulong num2 = (ulong) y[yOff + 1];
    ulong num3 = (ulong) y[yOff + 2];
    ulong num4 = (ulong) y[yOff + 3];
    ulong num5 = (ulong) y[yOff + 4];
    ulong num6 = (ulong) y[yOff + 5];
    ulong num7 = (ulong) y[yOff + 6];
    ulong num8 = (ulong) y[yOff + 7];
    ulong num9 = (ulong) x[xOff];
    ulong num10 = (ulong) (0L + (long) num9 * (long) num1);
    zz[zzOff] = (uint) num10;
    ulong num11 = (num10 >> 32 /*0x20*/) + num9 * num2;
    zz[zzOff + 1] = (uint) num11;
    ulong num12 = (num11 >> 32 /*0x20*/) + num9 * num3;
    zz[zzOff + 2] = (uint) num12;
    ulong num13 = (num12 >> 32 /*0x20*/) + num9 * num4;
    zz[zzOff + 3] = (uint) num13;
    ulong num14 = (num13 >> 32 /*0x20*/) + num9 * num5;
    zz[zzOff + 4] = (uint) num14;
    ulong num15 = (num14 >> 32 /*0x20*/) + num9 * num6;
    zz[zzOff + 5] = (uint) num15;
    ulong num16 = (num15 >> 32 /*0x20*/) + num9 * num7;
    zz[zzOff + 6] = (uint) num16;
    ulong num17 = (num16 >> 32 /*0x20*/) + num9 * num8;
    zz[zzOff + 7] = (uint) num17;
    ulong num18 = num17 >> 32 /*0x20*/;
    zz[zzOff + 8] = (uint) num18;
    for (int index = 1; index < 8; ++index)
    {
      ++zzOff;
      ulong num19 = (ulong) x[xOff + index];
      ulong num20 = (ulong) (0L + ((long) num19 * (long) num1 + (long) zz[zzOff]));
      zz[zzOff] = (uint) num20;
      ulong num21 = (num20 >> 32 /*0x20*/) + (num19 * num2 + (ulong) zz[zzOff + 1]);
      zz[zzOff + 1] = (uint) num21;
      ulong num22 = (num21 >> 32 /*0x20*/) + (num19 * num3 + (ulong) zz[zzOff + 2]);
      zz[zzOff + 2] = (uint) num22;
      ulong num23 = (num22 >> 32 /*0x20*/) + (num19 * num4 + (ulong) zz[zzOff + 3]);
      zz[zzOff + 3] = (uint) num23;
      ulong num24 = (num23 >> 32 /*0x20*/) + (num19 * num5 + (ulong) zz[zzOff + 4]);
      zz[zzOff + 4] = (uint) num24;
      ulong num25 = (num24 >> 32 /*0x20*/) + (num19 * num6 + (ulong) zz[zzOff + 5]);
      zz[zzOff + 5] = (uint) num25;
      ulong num26 = (num25 >> 32 /*0x20*/) + (num19 * num7 + (ulong) zz[zzOff + 6]);
      zz[zzOff + 6] = (uint) num26;
      ulong num27 = (num26 >> 32 /*0x20*/) + (num19 * num8 + (ulong) zz[zzOff + 7]);
      zz[zzOff + 7] = (uint) num27;
      ulong num28 = num27 >> 32 /*0x20*/;
      zz[zzOff + 8] = (uint) num28;
    }
  }

  public static void Mul128(uint[] x, uint[] y128, uint[] zz)
  {
    ulong num1 = (ulong) x[0];
    ulong num2 = (ulong) x[1];
    ulong num3 = (ulong) x[2];
    ulong num4 = (ulong) x[3];
    ulong num5 = (ulong) x[4];
    ulong num6 = (ulong) x[5];
    ulong num7 = (ulong) x[6];
    ulong num8 = (ulong) x[7];
    ulong num9 = (ulong) y128[0];
    ulong num10 = (ulong) (0L + (long) num9 * (long) num1);
    zz[0] = (uint) num10;
    ulong num11 = (num10 >> 32 /*0x20*/) + num9 * num2;
    zz[1] = (uint) num11;
    ulong num12 = (num11 >> 32 /*0x20*/) + num9 * num3;
    zz[2] = (uint) num12;
    ulong num13 = (num12 >> 32 /*0x20*/) + num9 * num4;
    zz[3] = (uint) num13;
    ulong num14 = (num13 >> 32 /*0x20*/) + num9 * num5;
    zz[4] = (uint) num14;
    ulong num15 = (num14 >> 32 /*0x20*/) + num9 * num6;
    zz[5] = (uint) num15;
    ulong num16 = (num15 >> 32 /*0x20*/) + num9 * num7;
    zz[6] = (uint) num16;
    ulong num17 = (num16 >> 32 /*0x20*/) + num9 * num8;
    zz[7] = (uint) num17;
    ulong num18 = num17 >> 32 /*0x20*/;
    zz[8] = (uint) num18;
    for (int index = 1; index < 4; ++index)
    {
      ulong num19 = (ulong) y128[index];
      ulong num20 = (ulong) (0L + ((long) num19 * (long) num1 + (long) zz[index]));
      zz[index] = (uint) num20;
      ulong num21 = (num20 >> 32 /*0x20*/) + (num19 * num2 + (ulong) zz[index + 1]);
      zz[index + 1] = (uint) num21;
      ulong num22 = (num21 >> 32 /*0x20*/) + (num19 * num3 + (ulong) zz[index + 2]);
      zz[index + 2] = (uint) num22;
      ulong num23 = (num22 >> 32 /*0x20*/) + (num19 * num4 + (ulong) zz[index + 3]);
      zz[index + 3] = (uint) num23;
      ulong num24 = (num23 >> 32 /*0x20*/) + (num19 * num5 + (ulong) zz[index + 4]);
      zz[index + 4] = (uint) num24;
      ulong num25 = (num24 >> 32 /*0x20*/) + (num19 * num6 + (ulong) zz[index + 5]);
      zz[index + 5] = (uint) num25;
      ulong num26 = (num25 >> 32 /*0x20*/) + (num19 * num7 + (ulong) zz[index + 6]);
      zz[index + 6] = (uint) num26;
      ulong num27 = (num26 >> 32 /*0x20*/) + (num19 * num8 + (ulong) zz[index + 7]);
      zz[index + 7] = (uint) num27;
      ulong num28 = num27 >> 32 /*0x20*/;
      zz[index + 8] = (uint) num28;
    }
  }

  public static uint MulAddTo(uint[] x, uint[] y, uint[] zz)
  {
    ulong num1 = (ulong) y[0];
    ulong num2 = (ulong) y[1];
    ulong num3 = (ulong) y[2];
    ulong num4 = (ulong) y[3];
    ulong num5 = (ulong) y[4];
    ulong num6 = (ulong) y[5];
    ulong num7 = (ulong) y[6];
    ulong num8 = (ulong) y[7];
    ulong num9 = 0;
    for (int index = 0; index < 8; ++index)
    {
      ulong num10 = (ulong) x[index];
      ulong num11 = (ulong) (0L + ((long) num10 * (long) num1 + (long) zz[index]));
      zz[index] = (uint) num11;
      ulong num12 = (num11 >> 32 /*0x20*/) + (num10 * num2 + (ulong) zz[index + 1]);
      zz[index + 1] = (uint) num12;
      ulong num13 = (num12 >> 32 /*0x20*/) + (num10 * num3 + (ulong) zz[index + 2]);
      zz[index + 2] = (uint) num13;
      ulong num14 = (num13 >> 32 /*0x20*/) + (num10 * num4 + (ulong) zz[index + 3]);
      zz[index + 3] = (uint) num14;
      ulong num15 = (num14 >> 32 /*0x20*/) + (num10 * num5 + (ulong) zz[index + 4]);
      zz[index + 4] = (uint) num15;
      ulong num16 = (num15 >> 32 /*0x20*/) + (num10 * num6 + (ulong) zz[index + 5]);
      zz[index + 5] = (uint) num16;
      ulong num17 = (num16 >> 32 /*0x20*/) + (num10 * num7 + (ulong) zz[index + 6]);
      zz[index + 6] = (uint) num17;
      ulong num18 = (num17 >> 32 /*0x20*/) + (num10 * num8 + (ulong) zz[index + 7]);
      zz[index + 7] = (uint) num18;
      ulong num19 = num18 >> 32 /*0x20*/;
      ulong num20 = num9 + (num19 + (ulong) zz[index + 8]);
      zz[index + 8] = (uint) num20;
      num9 = num20 >> 32 /*0x20*/;
    }
    return (uint) num9;
  }

  public static uint MulAddTo(uint[] x, int xOff, uint[] y, int yOff, uint[] zz, int zzOff)
  {
    ulong num1 = (ulong) y[yOff];
    ulong num2 = (ulong) y[yOff + 1];
    ulong num3 = (ulong) y[yOff + 2];
    ulong num4 = (ulong) y[yOff + 3];
    ulong num5 = (ulong) y[yOff + 4];
    ulong num6 = (ulong) y[yOff + 5];
    ulong num7 = (ulong) y[yOff + 6];
    ulong num8 = (ulong) y[yOff + 7];
    ulong num9 = 0;
    for (int index = 0; index < 8; ++index)
    {
      ulong num10 = (ulong) x[xOff + index];
      ulong num11 = (ulong) (0L + ((long) num10 * (long) num1 + (long) zz[zzOff]));
      zz[zzOff] = (uint) num11;
      ulong num12 = (num11 >> 32 /*0x20*/) + (num10 * num2 + (ulong) zz[zzOff + 1]);
      zz[zzOff + 1] = (uint) num12;
      ulong num13 = (num12 >> 32 /*0x20*/) + (num10 * num3 + (ulong) zz[zzOff + 2]);
      zz[zzOff + 2] = (uint) num13;
      ulong num14 = (num13 >> 32 /*0x20*/) + (num10 * num4 + (ulong) zz[zzOff + 3]);
      zz[zzOff + 3] = (uint) num14;
      ulong num15 = (num14 >> 32 /*0x20*/) + (num10 * num5 + (ulong) zz[zzOff + 4]);
      zz[zzOff + 4] = (uint) num15;
      ulong num16 = (num15 >> 32 /*0x20*/) + (num10 * num6 + (ulong) zz[zzOff + 5]);
      zz[zzOff + 5] = (uint) num16;
      ulong num17 = (num16 >> 32 /*0x20*/) + (num10 * num7 + (ulong) zz[zzOff + 6]);
      zz[zzOff + 6] = (uint) num17;
      ulong num18 = (num17 >> 32 /*0x20*/) + (num10 * num8 + (ulong) zz[zzOff + 7]);
      zz[zzOff + 7] = (uint) num18;
      ulong num19 = num18 >> 32 /*0x20*/;
      ulong num20 = num9 + (num19 + (ulong) zz[zzOff + 8]);
      zz[zzOff + 8] = (uint) num20;
      num9 = num20 >> 32 /*0x20*/;
      ++zzOff;
    }
    return (uint) num9;
  }

  public static ulong Mul33Add(
    uint w,
    uint[] x,
    int xOff,
    uint[] y,
    int yOff,
    uint[] z,
    int zOff)
  {
    ulong num1 = (ulong) w;
    ulong num2 = (ulong) x[xOff];
    ulong num3 = (ulong) (0L + ((long) num1 * (long) num2 + (long) y[yOff]));
    z[zOff] = (uint) num3;
    ulong num4 = num3 >> 32 /*0x20*/;
    ulong num5 = (ulong) x[xOff + 1];
    ulong num6 = num4 + (num1 * num5 + num2 + (ulong) y[yOff + 1]);
    z[zOff + 1] = (uint) num6;
    ulong num7 = num6 >> 32 /*0x20*/;
    ulong num8 = (ulong) x[xOff + 2];
    ulong num9 = num7 + (num1 * num8 + num5 + (ulong) y[yOff + 2]);
    z[zOff + 2] = (uint) num9;
    ulong num10 = num9 >> 32 /*0x20*/;
    ulong num11 = (ulong) x[xOff + 3];
    ulong num12 = num10 + (num1 * num11 + num8 + (ulong) y[yOff + 3]);
    z[zOff + 3] = (uint) num12;
    ulong num13 = num12 >> 32 /*0x20*/;
    ulong num14 = (ulong) x[xOff + 4];
    ulong num15 = num13 + (num1 * num14 + num11 + (ulong) y[yOff + 4]);
    z[zOff + 4] = (uint) num15;
    ulong num16 = num15 >> 32 /*0x20*/;
    ulong num17 = (ulong) x[xOff + 5];
    ulong num18 = num16 + (num1 * num17 + num14 + (ulong) y[yOff + 5]);
    z[zOff + 5] = (uint) num18;
    ulong num19 = num18 >> 32 /*0x20*/;
    ulong num20 = (ulong) x[xOff + 6];
    ulong num21 = num19 + (num1 * num20 + num17 + (ulong) y[yOff + 6]);
    z[zOff + 6] = (uint) num21;
    ulong num22 = num21 >> 32 /*0x20*/;
    ulong num23 = (ulong) x[xOff + 7];
    ulong num24 = num22 + (num1 * num23 + num20 + (ulong) y[yOff + 7]);
    z[zOff + 7] = (uint) num24;
    return (num24 >> 32 /*0x20*/) + num23;
  }

  public static uint MulByWord(uint x, uint[] z)
  {
    ulong num1 = (ulong) x;
    ulong num2 = (ulong) (0L + (long) num1 * (long) z[0]);
    z[0] = (uint) num2;
    ulong num3 = (num2 >> 32 /*0x20*/) + num1 * (ulong) z[1];
    z[1] = (uint) num3;
    ulong num4 = (num3 >> 32 /*0x20*/) + num1 * (ulong) z[2];
    z[2] = (uint) num4;
    ulong num5 = (num4 >> 32 /*0x20*/) + num1 * (ulong) z[3];
    z[3] = (uint) num5;
    ulong num6 = (num5 >> 32 /*0x20*/) + num1 * (ulong) z[4];
    z[4] = (uint) num6;
    ulong num7 = (num6 >> 32 /*0x20*/) + num1 * (ulong) z[5];
    z[5] = (uint) num7;
    ulong num8 = (num7 >> 32 /*0x20*/) + num1 * (ulong) z[6];
    z[6] = (uint) num8;
    ulong num9 = (num8 >> 32 /*0x20*/) + num1 * (ulong) z[7];
    z[7] = (uint) num9;
    return (uint) (num9 >> 32 /*0x20*/);
  }

  public static uint MulByWordAddTo(uint x, uint[] y, uint[] z)
  {
    ulong num1 = (ulong) x;
    ulong num2 = (ulong) (0L + ((long) num1 * (long) z[0] + (long) y[0]));
    z[0] = (uint) num2;
    ulong num3 = (num2 >> 32 /*0x20*/) + (num1 * (ulong) z[1] + (ulong) y[1]);
    z[1] = (uint) num3;
    ulong num4 = (num3 >> 32 /*0x20*/) + (num1 * (ulong) z[2] + (ulong) y[2]);
    z[2] = (uint) num4;
    ulong num5 = (num4 >> 32 /*0x20*/) + (num1 * (ulong) z[3] + (ulong) y[3]);
    z[3] = (uint) num5;
    ulong num6 = (num5 >> 32 /*0x20*/) + (num1 * (ulong) z[4] + (ulong) y[4]);
    z[4] = (uint) num6;
    ulong num7 = (num6 >> 32 /*0x20*/) + (num1 * (ulong) z[5] + (ulong) y[5]);
    z[5] = (uint) num7;
    ulong num8 = (num7 >> 32 /*0x20*/) + (num1 * (ulong) z[6] + (ulong) y[6]);
    z[6] = (uint) num8;
    ulong num9 = (num8 >> 32 /*0x20*/) + (num1 * (ulong) z[7] + (ulong) y[7]);
    z[7] = (uint) num9;
    return (uint) (num9 >> 32 /*0x20*/);
  }

  public static uint MulWordAddTo(uint x, uint[] y, int yOff, uint[] z, int zOff)
  {
    ulong num1 = (ulong) x;
    ulong num2 = (ulong) (0L + ((long) num1 * (long) y[yOff] + (long) z[zOff]));
    z[zOff] = (uint) num2;
    ulong num3 = (num2 >> 32 /*0x20*/) + (num1 * (ulong) y[yOff + 1] + (ulong) z[zOff + 1]);
    z[zOff + 1] = (uint) num3;
    ulong num4 = (num3 >> 32 /*0x20*/) + (num1 * (ulong) y[yOff + 2] + (ulong) z[zOff + 2]);
    z[zOff + 2] = (uint) num4;
    ulong num5 = (num4 >> 32 /*0x20*/) + (num1 * (ulong) y[yOff + 3] + (ulong) z[zOff + 3]);
    z[zOff + 3] = (uint) num5;
    ulong num6 = (num5 >> 32 /*0x20*/) + (num1 * (ulong) y[yOff + 4] + (ulong) z[zOff + 4]);
    z[zOff + 4] = (uint) num6;
    ulong num7 = (num6 >> 32 /*0x20*/) + (num1 * (ulong) y[yOff + 5] + (ulong) z[zOff + 5]);
    z[zOff + 5] = (uint) num7;
    ulong num8 = (num7 >> 32 /*0x20*/) + (num1 * (ulong) y[yOff + 6] + (ulong) z[zOff + 6]);
    z[zOff + 6] = (uint) num8;
    ulong num9 = (num8 >> 32 /*0x20*/) + (num1 * (ulong) y[yOff + 7] + (ulong) z[zOff + 7]);
    z[zOff + 7] = (uint) num9;
    return (uint) (num9 >> 32 /*0x20*/);
  }

  public static uint Mul33DWordAdd(uint x, ulong y, uint[] z, int zOff)
  {
    ulong num1 = (ulong) x;
    ulong num2 = y & (ulong) uint.MaxValue;
    ulong num3 = (ulong) (0L + ((long) num1 * (long) num2 + (long) z[zOff]));
    z[zOff] = (uint) num3;
    ulong num4 = num3 >> 32 /*0x20*/;
    ulong num5 = y >> 32 /*0x20*/;
    ulong num6 = num4 + (num1 * num5 + num2 + (ulong) z[zOff + 1]);
    z[zOff + 1] = (uint) num6;
    ulong num7 = (num6 >> 32 /*0x20*/) + (num5 + (ulong) z[zOff + 2]);
    z[zOff + 2] = (uint) num7;
    ulong num8 = (num7 >> 32 /*0x20*/) + (ulong) z[zOff + 3];
    z[zOff + 3] = (uint) num8;
    return num8 >> 32 /*0x20*/ != 0UL ? Nat.IncAt(8, z, zOff, 4) : 0U;
  }

  public static uint Mul33WordAdd(uint x, uint y, uint[] z, int zOff)
  {
    ulong num1 = (ulong) y;
    ulong num2 = (ulong) (0L + ((long) num1 * (long) x + (long) z[zOff]));
    z[zOff] = (uint) num2;
    ulong num3 = (num2 >> 32 /*0x20*/) + (num1 + (ulong) z[zOff + 1]);
    z[zOff + 1] = (uint) num3;
    ulong num4 = (num3 >> 32 /*0x20*/) + (ulong) z[zOff + 2];
    z[zOff + 2] = (uint) num4;
    return num4 >> 32 /*0x20*/ != 0UL ? Nat.IncAt(8, z, zOff, 3) : 0U;
  }

  public static uint MulWordDwordAdd(uint x, ulong y, uint[] z, int zOff)
  {
    ulong num1 = (ulong) x;
    ulong num2 = (ulong) (0L + ((long) num1 * (long) y + (long) z[zOff]));
    z[zOff] = (uint) num2;
    ulong num3 = (num2 >> 32 /*0x20*/) + (num1 * (y >> 32 /*0x20*/) + (ulong) z[zOff + 1]);
    z[zOff + 1] = (uint) num3;
    ulong num4 = (num3 >> 32 /*0x20*/) + (ulong) z[zOff + 2];
    z[zOff + 2] = (uint) num4;
    return num4 >> 32 /*0x20*/ != 0UL ? Nat.IncAt(8, z, zOff, 3) : 0U;
  }

  public static uint MulWord(uint x, uint[] y, uint[] z, int zOff)
  {
    ulong num1 = 0;
    ulong num2 = (ulong) x;
    int index = 0;
    do
    {
      ulong num3 = num1 + num2 * (ulong) y[index];
      z[zOff + index] = (uint) num3;
      num1 = num3 >> 32 /*0x20*/;
    }
    while (++index < 8);
    return (uint) num1;
  }

  public static void Square(uint[] x, uint[] zz)
  {
    ulong num1 = (ulong) x[0];
    uint num2 = 0;
    int num3 = 7;
    int num4 = 16 /*0x10*/;
    do
    {
      long num5 = (long) x[num3--];
      ulong num6 = (ulong) (num5 * num5);
      int num7;
      zz[num7 = num4 - 1] = num2 << 31 /*0x1F*/ | (uint) (num6 >> 33);
      zz[num4 = num7 - 1] = (uint) (num6 >> 1);
      num2 = (uint) num6;
    }
    while (num3 > 0);
    ulong num8 = num1 * num1;
    ulong num9 = (ulong) (num2 << 31 /*0x1F*/) | num8 >> 33;
    zz[0] = (uint) num8;
    uint num10 = (uint) (num8 >> 32 /*0x20*/) & 1U;
    ulong num11 = (ulong) x[1];
    ulong num12 = (ulong) zz[2];
    ulong num13 = num9 + num11 * num1;
    uint num14 = (uint) num13;
    zz[1] = num14 << 1 | num10;
    uint num15 = num14 >> 31 /*0x1F*/;
    ulong num16 = num12 + (num13 >> 32 /*0x20*/);
    ulong num17 = (ulong) x[2];
    ulong num18 = (ulong) zz[3];
    ulong num19 = (ulong) zz[4];
    ulong num20 = num16 + num17 * num1;
    uint num21 = (uint) num20;
    zz[2] = num21 << 1 | num15;
    uint num22 = num21 >> 31 /*0x1F*/;
    ulong num23 = num18 + ((num20 >> 32 /*0x20*/) + num17 * num11);
    ulong num24 = num19 + (num23 >> 32 /*0x20*/);
    ulong num25 = num23 & (ulong) uint.MaxValue;
    ulong num26 = (ulong) x[3];
    ulong num27 = (ulong) zz[5] + (num24 >> 32 /*0x20*/);
    ulong num28 = num24 & (ulong) uint.MaxValue;
    ulong num29 = (ulong) zz[6] + (num27 >> 32 /*0x20*/);
    ulong num30 = num27 & (ulong) uint.MaxValue;
    ulong num31 = num25 + num26 * num1;
    uint num32 = (uint) num31;
    zz[3] = num32 << 1 | num22;
    uint num33 = num32 >> 31 /*0x1F*/;
    ulong num34 = num28 + ((num31 >> 32 /*0x20*/) + num26 * num11);
    ulong num35 = num30 + ((num34 >> 32 /*0x20*/) + num26 * num17);
    ulong num36 = num34 & (ulong) uint.MaxValue;
    ulong num37 = num29 + (num35 >> 32 /*0x20*/);
    ulong num38 = num35 & (ulong) uint.MaxValue;
    ulong num39 = (ulong) x[4];
    ulong num40 = (ulong) zz[7] + (num37 >> 32 /*0x20*/);
    ulong num41 = num37 & (ulong) uint.MaxValue;
    ulong num42 = (ulong) zz[8] + (num40 >> 32 /*0x20*/);
    ulong num43 = num40 & (ulong) uint.MaxValue;
    ulong num44 = num36 + num39 * num1;
    uint num45 = (uint) num44;
    zz[4] = num45 << 1 | num33;
    uint num46 = num45 >> 31 /*0x1F*/;
    ulong num47 = num38 + ((num44 >> 32 /*0x20*/) + num39 * num11);
    ulong num48 = num41 + ((num47 >> 32 /*0x20*/) + num39 * num17);
    ulong num49 = num47 & (ulong) uint.MaxValue;
    ulong num50 = num43 + ((num48 >> 32 /*0x20*/) + num39 * num26);
    ulong num51 = num48 & (ulong) uint.MaxValue;
    ulong num52 = num42 + (num50 >> 32 /*0x20*/);
    ulong num53 = num50 & (ulong) uint.MaxValue;
    ulong num54 = (ulong) x[5];
    ulong num55 = (ulong) zz[9] + (num52 >> 32 /*0x20*/);
    ulong num56 = num52 & (ulong) uint.MaxValue;
    ulong num57 = (ulong) zz[10] + (num55 >> 32 /*0x20*/);
    ulong num58 = num55 & (ulong) uint.MaxValue;
    ulong num59 = num49 + num54 * num1;
    uint num60 = (uint) num59;
    zz[5] = num60 << 1 | num46;
    uint num61 = num60 >> 31 /*0x1F*/;
    ulong num62 = num51 + ((num59 >> 32 /*0x20*/) + num54 * num11);
    ulong num63 = num53 + ((num62 >> 32 /*0x20*/) + num54 * num17);
    ulong num64 = num62 & (ulong) uint.MaxValue;
    ulong num65 = num56 + ((num63 >> 32 /*0x20*/) + num54 * num26);
    ulong num66 = num63 & (ulong) uint.MaxValue;
    ulong num67 = num58 + ((num65 >> 32 /*0x20*/) + num54 * num39);
    ulong num68 = num65 & (ulong) uint.MaxValue;
    ulong num69 = num57 + (num67 >> 32 /*0x20*/);
    ulong num70 = num67 & (ulong) uint.MaxValue;
    ulong num71 = (ulong) x[6];
    ulong num72 = (ulong) zz[11] + (num69 >> 32 /*0x20*/);
    ulong num73 = num69 & (ulong) uint.MaxValue;
    ulong num74 = (ulong) zz[12] + (num72 >> 32 /*0x20*/);
    ulong num75 = num72 & (ulong) uint.MaxValue;
    ulong num76 = num64 + num71 * num1;
    uint num77 = (uint) num76;
    zz[6] = num77 << 1 | num61;
    uint num78 = num77 >> 31 /*0x1F*/;
    ulong num79 = num66 + ((num76 >> 32 /*0x20*/) + num71 * num11);
    ulong num80 = num68 + ((num79 >> 32 /*0x20*/) + num71 * num17);
    ulong num81 = num79 & (ulong) uint.MaxValue;
    ulong num82 = num70 + ((num80 >> 32 /*0x20*/) + num71 * num26);
    ulong num83 = num80 & (ulong) uint.MaxValue;
    ulong num84 = num73 + ((num82 >> 32 /*0x20*/) + num71 * num39);
    ulong num85 = num82 & (ulong) uint.MaxValue;
    ulong num86 = num75 + ((num84 >> 32 /*0x20*/) + num71 * num54);
    ulong num87 = num84 & (ulong) uint.MaxValue;
    ulong num88 = num74 + (num86 >> 32 /*0x20*/);
    ulong num89 = num86 & (ulong) uint.MaxValue;
    ulong num90 = (ulong) x[7];
    ulong num91 = (ulong) zz[13] + (num88 >> 32 /*0x20*/);
    ulong num92 = num88 & (ulong) uint.MaxValue;
    ulong num93 = (ulong) zz[14] + (num91 >> 32 /*0x20*/);
    ulong num94 = num91 & (ulong) uint.MaxValue;
    ulong num95 = num81 + num90 * num1;
    uint num96 = (uint) num95;
    zz[7] = num96 << 1 | num78;
    uint num97 = num96 >> 31 /*0x1F*/;
    ulong num98 = num83 + ((num95 >> 32 /*0x20*/) + num90 * num11);
    ulong num99 = num85 + ((num98 >> 32 /*0x20*/) + num90 * num17);
    ulong num100 = num87 + ((num99 >> 32 /*0x20*/) + num90 * num26);
    ulong num101 = num89 + ((num100 >> 32 /*0x20*/) + num90 * num39);
    ulong num102 = num92 + ((num101 >> 32 /*0x20*/) + num90 * num54);
    ulong num103 = num94 + ((num102 >> 32 /*0x20*/) + num90 * num71);
    ulong num104 = num93 + (num103 >> 32 /*0x20*/);
    uint num105 = (uint) num98;
    zz[8] = num105 << 1 | num97;
    uint num106 = num105 >> 31 /*0x1F*/;
    uint num107 = (uint) num99;
    zz[9] = num107 << 1 | num106;
    uint num108 = num107 >> 31 /*0x1F*/;
    uint num109 = (uint) num100;
    zz[10] = num109 << 1 | num108;
    uint num110 = num109 >> 31 /*0x1F*/;
    uint num111 = (uint) num101;
    zz[11] = num111 << 1 | num110;
    uint num112 = num111 >> 31 /*0x1F*/;
    uint num113 = (uint) num102;
    zz[12] = num113 << 1 | num112;
    uint num114 = num113 >> 31 /*0x1F*/;
    uint num115 = (uint) num103;
    zz[13] = num115 << 1 | num114;
    uint num116 = num115 >> 31 /*0x1F*/;
    uint num117 = (uint) num104;
    zz[14] = num117 << 1 | num116;
    uint num118 = num117 >> 31 /*0x1F*/;
    uint num119 = zz[15] + (uint) (num104 >> 32 /*0x20*/);
    zz[15] = num119 << 1 | num118;
  }

  public static void Square(uint[] x, int xOff, uint[] zz, int zzOff)
  {
    ulong num1 = (ulong) x[xOff];
    uint num2 = 0;
    int num3 = 7;
    int num4 = 16 /*0x10*/;
    do
    {
      long num5 = (long) x[xOff + num3--];
      ulong num6 = (ulong) (num5 * num5);
      int num7;
      zz[zzOff + (num7 = num4 - 1)] = num2 << 31 /*0x1F*/ | (uint) (num6 >> 33);
      zz[zzOff + (num4 = num7 - 1)] = (uint) (num6 >> 1);
      num2 = (uint) num6;
    }
    while (num3 > 0);
    ulong num8 = num1 * num1;
    ulong num9 = (ulong) (num2 << 31 /*0x1F*/) | num8 >> 33;
    zz[zzOff] = (uint) num8;
    uint num10 = (uint) (num8 >> 32 /*0x20*/) & 1U;
    ulong num11 = (ulong) x[xOff + 1];
    ulong num12 = (ulong) zz[zzOff + 2];
    ulong num13 = num9 + num11 * num1;
    uint num14 = (uint) num13;
    zz[zzOff + 1] = num14 << 1 | num10;
    uint num15 = num14 >> 31 /*0x1F*/;
    ulong num16 = num12 + (num13 >> 32 /*0x20*/);
    ulong num17 = (ulong) x[xOff + 2];
    ulong num18 = (ulong) zz[zzOff + 3];
    ulong num19 = (ulong) zz[zzOff + 4];
    ulong num20 = num16 + num17 * num1;
    uint num21 = (uint) num20;
    zz[zzOff + 2] = num21 << 1 | num15;
    uint num22 = num21 >> 31 /*0x1F*/;
    ulong num23 = num18 + ((num20 >> 32 /*0x20*/) + num17 * num11);
    ulong num24 = num19 + (num23 >> 32 /*0x20*/);
    ulong num25 = num23 & (ulong) uint.MaxValue;
    ulong num26 = (ulong) x[xOff + 3];
    ulong num27 = (ulong) zz[zzOff + 5] + (num24 >> 32 /*0x20*/);
    ulong num28 = num24 & (ulong) uint.MaxValue;
    ulong num29 = (ulong) zz[zzOff + 6] + (num27 >> 32 /*0x20*/);
    ulong num30 = num27 & (ulong) uint.MaxValue;
    ulong num31 = num25 + num26 * num1;
    uint num32 = (uint) num31;
    zz[zzOff + 3] = num32 << 1 | num22;
    uint num33 = num32 >> 31 /*0x1F*/;
    ulong num34 = num28 + ((num31 >> 32 /*0x20*/) + num26 * num11);
    ulong num35 = num30 + ((num34 >> 32 /*0x20*/) + num26 * num17);
    ulong num36 = num34 & (ulong) uint.MaxValue;
    ulong num37 = num29 + (num35 >> 32 /*0x20*/);
    ulong num38 = num35 & (ulong) uint.MaxValue;
    ulong num39 = (ulong) x[xOff + 4];
    ulong num40 = (ulong) zz[zzOff + 7] + (num37 >> 32 /*0x20*/);
    ulong num41 = num37 & (ulong) uint.MaxValue;
    ulong num42 = (ulong) zz[zzOff + 8] + (num40 >> 32 /*0x20*/);
    ulong num43 = num40 & (ulong) uint.MaxValue;
    ulong num44 = num36 + num39 * num1;
    uint num45 = (uint) num44;
    zz[zzOff + 4] = num45 << 1 | num33;
    uint num46 = num45 >> 31 /*0x1F*/;
    ulong num47 = num38 + ((num44 >> 32 /*0x20*/) + num39 * num11);
    ulong num48 = num41 + ((num47 >> 32 /*0x20*/) + num39 * num17);
    ulong num49 = num47 & (ulong) uint.MaxValue;
    ulong num50 = num43 + ((num48 >> 32 /*0x20*/) + num39 * num26);
    ulong num51 = num48 & (ulong) uint.MaxValue;
    ulong num52 = num42 + (num50 >> 32 /*0x20*/);
    ulong num53 = num50 & (ulong) uint.MaxValue;
    ulong num54 = (ulong) x[xOff + 5];
    ulong num55 = (ulong) zz[zzOff + 9] + (num52 >> 32 /*0x20*/);
    ulong num56 = num52 & (ulong) uint.MaxValue;
    ulong num57 = (ulong) zz[zzOff + 10] + (num55 >> 32 /*0x20*/);
    ulong num58 = num55 & (ulong) uint.MaxValue;
    ulong num59 = num49 + num54 * num1;
    uint num60 = (uint) num59;
    zz[zzOff + 5] = num60 << 1 | num46;
    uint num61 = num60 >> 31 /*0x1F*/;
    ulong num62 = num51 + ((num59 >> 32 /*0x20*/) + num54 * num11);
    ulong num63 = num53 + ((num62 >> 32 /*0x20*/) + num54 * num17);
    ulong num64 = num62 & (ulong) uint.MaxValue;
    ulong num65 = num56 + ((num63 >> 32 /*0x20*/) + num54 * num26);
    ulong num66 = num63 & (ulong) uint.MaxValue;
    ulong num67 = num58 + ((num65 >> 32 /*0x20*/) + num54 * num39);
    ulong num68 = num65 & (ulong) uint.MaxValue;
    ulong num69 = num57 + (num67 >> 32 /*0x20*/);
    ulong num70 = num67 & (ulong) uint.MaxValue;
    ulong num71 = (ulong) x[xOff + 6];
    ulong num72 = (ulong) zz[zzOff + 11] + (num69 >> 32 /*0x20*/);
    ulong num73 = num69 & (ulong) uint.MaxValue;
    ulong num74 = (ulong) zz[zzOff + 12] + (num72 >> 32 /*0x20*/);
    ulong num75 = num72 & (ulong) uint.MaxValue;
    ulong num76 = num64 + num71 * num1;
    uint num77 = (uint) num76;
    zz[zzOff + 6] = num77 << 1 | num61;
    uint num78 = num77 >> 31 /*0x1F*/;
    ulong num79 = num66 + ((num76 >> 32 /*0x20*/) + num71 * num11);
    ulong num80 = num68 + ((num79 >> 32 /*0x20*/) + num71 * num17);
    ulong num81 = num79 & (ulong) uint.MaxValue;
    ulong num82 = num70 + ((num80 >> 32 /*0x20*/) + num71 * num26);
    ulong num83 = num80 & (ulong) uint.MaxValue;
    ulong num84 = num73 + ((num82 >> 32 /*0x20*/) + num71 * num39);
    ulong num85 = num82 & (ulong) uint.MaxValue;
    ulong num86 = num75 + ((num84 >> 32 /*0x20*/) + num71 * num54);
    ulong num87 = num84 & (ulong) uint.MaxValue;
    ulong num88 = num74 + (num86 >> 32 /*0x20*/);
    ulong num89 = num86 & (ulong) uint.MaxValue;
    ulong num90 = (ulong) x[xOff + 7];
    ulong num91 = (ulong) zz[zzOff + 13] + (num88 >> 32 /*0x20*/);
    ulong num92 = num88 & (ulong) uint.MaxValue;
    ulong num93 = (ulong) zz[zzOff + 14] + (num91 >> 32 /*0x20*/);
    ulong num94 = num91 & (ulong) uint.MaxValue;
    ulong num95 = num81 + num90 * num1;
    uint num96 = (uint) num95;
    zz[zzOff + 7] = num96 << 1 | num78;
    uint num97 = num96 >> 31 /*0x1F*/;
    ulong num98 = num83 + ((num95 >> 32 /*0x20*/) + num90 * num11);
    ulong num99 = num85 + ((num98 >> 32 /*0x20*/) + num90 * num17);
    ulong num100 = num87 + ((num99 >> 32 /*0x20*/) + num90 * num26);
    ulong num101 = num89 + ((num100 >> 32 /*0x20*/) + num90 * num39);
    ulong num102 = num92 + ((num101 >> 32 /*0x20*/) + num90 * num54);
    ulong num103 = num94 + ((num102 >> 32 /*0x20*/) + num90 * num71);
    ulong num104 = num93 + (num103 >> 32 /*0x20*/);
    uint num105 = (uint) num98;
    zz[zzOff + 8] = num105 << 1 | num97;
    uint num106 = num105 >> 31 /*0x1F*/;
    uint num107 = (uint) num99;
    zz[zzOff + 9] = num107 << 1 | num106;
    uint num108 = num107 >> 31 /*0x1F*/;
    uint num109 = (uint) num100;
    zz[zzOff + 10] = num109 << 1 | num108;
    uint num110 = num109 >> 31 /*0x1F*/;
    uint num111 = (uint) num101;
    zz[zzOff + 11] = num111 << 1 | num110;
    uint num112 = num111 >> 31 /*0x1F*/;
    uint num113 = (uint) num102;
    zz[zzOff + 12] = num113 << 1 | num112;
    uint num114 = num113 >> 31 /*0x1F*/;
    uint num115 = (uint) num103;
    zz[zzOff + 13] = num115 << 1 | num114;
    uint num116 = num115 >> 31 /*0x1F*/;
    uint num117 = (uint) num104;
    zz[zzOff + 14] = num117 << 1 | num116;
    uint num118 = num117 >> 31 /*0x1F*/;
    uint num119 = zz[zzOff + 15] + (uint) (num104 >> 32 /*0x20*/);
    zz[zzOff + 15] = num119 << 1 | num118;
  }

  public static int Sub(uint[] x, uint[] y, uint[] z)
  {
    long num1 = 0L + ((long) x[0] - (long) y[0]);
    z[0] = (uint) num1;
    long num2 = (num1 >> 32 /*0x20*/) + ((long) x[1] - (long) y[1]);
    z[1] = (uint) num2;
    long num3 = (num2 >> 32 /*0x20*/) + ((long) x[2] - (long) y[2]);
    z[2] = (uint) num3;
    long num4 = (num3 >> 32 /*0x20*/) + ((long) x[3] - (long) y[3]);
    z[3] = (uint) num4;
    long num5 = (num4 >> 32 /*0x20*/) + ((long) x[4] - (long) y[4]);
    z[4] = (uint) num5;
    long num6 = (num5 >> 32 /*0x20*/) + ((long) x[5] - (long) y[5]);
    z[5] = (uint) num6;
    long num7 = (num6 >> 32 /*0x20*/) + ((long) x[6] - (long) y[6]);
    z[6] = (uint) num7;
    long num8 = (num7 >> 32 /*0x20*/) + ((long) x[7] - (long) y[7]);
    z[7] = (uint) num8;
    return (int) (num8 >> 32 /*0x20*/);
  }

  public static int Sub(uint[] x, int xOff, uint[] y, int yOff, uint[] z, int zOff)
  {
    long num1 = 0L + ((long) x[xOff] - (long) y[yOff]);
    z[zOff] = (uint) num1;
    long num2 = (num1 >> 32 /*0x20*/) + ((long) x[xOff + 1] - (long) y[yOff + 1]);
    z[zOff + 1] = (uint) num2;
    long num3 = (num2 >> 32 /*0x20*/) + ((long) x[xOff + 2] - (long) y[yOff + 2]);
    z[zOff + 2] = (uint) num3;
    long num4 = (num3 >> 32 /*0x20*/) + ((long) x[xOff + 3] - (long) y[yOff + 3]);
    z[zOff + 3] = (uint) num4;
    long num5 = (num4 >> 32 /*0x20*/) + ((long) x[xOff + 4] - (long) y[yOff + 4]);
    z[zOff + 4] = (uint) num5;
    long num6 = (num5 >> 32 /*0x20*/) + ((long) x[xOff + 5] - (long) y[yOff + 5]);
    z[zOff + 5] = (uint) num6;
    long num7 = (num6 >> 32 /*0x20*/) + ((long) x[xOff + 6] - (long) y[yOff + 6]);
    z[zOff + 6] = (uint) num7;
    long num8 = (num7 >> 32 /*0x20*/) + ((long) x[xOff + 7] - (long) y[yOff + 7]);
    z[zOff + 7] = (uint) num8;
    return (int) (num8 >> 32 /*0x20*/);
  }

  public static int SubBothFrom(uint[] x, uint[] y, uint[] z)
  {
    long num1 = 0L + ((long) z[0] - (long) x[0] - (long) y[0]);
    z[0] = (uint) num1;
    long num2 = (num1 >> 32 /*0x20*/) + ((long) z[1] - (long) x[1] - (long) y[1]);
    z[1] = (uint) num2;
    long num3 = (num2 >> 32 /*0x20*/) + ((long) z[2] - (long) x[2] - (long) y[2]);
    z[2] = (uint) num3;
    long num4 = (num3 >> 32 /*0x20*/) + ((long) z[3] - (long) x[3] - (long) y[3]);
    z[3] = (uint) num4;
    long num5 = (num4 >> 32 /*0x20*/) + ((long) z[4] - (long) x[4] - (long) y[4]);
    z[4] = (uint) num5;
    long num6 = (num5 >> 32 /*0x20*/) + ((long) z[5] - (long) x[5] - (long) y[5]);
    z[5] = (uint) num6;
    long num7 = (num6 >> 32 /*0x20*/) + ((long) z[6] - (long) x[6] - (long) y[6]);
    z[6] = (uint) num7;
    long num8 = (num7 >> 32 /*0x20*/) + ((long) z[7] - (long) x[7] - (long) y[7]);
    z[7] = (uint) num8;
    return (int) (num8 >> 32 /*0x20*/);
  }

  public static int SubFrom(uint[] x, uint[] z, int cIn)
  {
    long num1 = (long) cIn + ((long) z[0] - (long) x[0]);
    z[0] = (uint) num1;
    long num2 = (num1 >> 32 /*0x20*/) + ((long) z[1] - (long) x[1]);
    z[1] = (uint) num2;
    long num3 = (num2 >> 32 /*0x20*/) + ((long) z[2] - (long) x[2]);
    z[2] = (uint) num3;
    long num4 = (num3 >> 32 /*0x20*/) + ((long) z[3] - (long) x[3]);
    z[3] = (uint) num4;
    long num5 = (num4 >> 32 /*0x20*/) + ((long) z[4] - (long) x[4]);
    z[4] = (uint) num5;
    long num6 = (num5 >> 32 /*0x20*/) + ((long) z[5] - (long) x[5]);
    z[5] = (uint) num6;
    long num7 = (num6 >> 32 /*0x20*/) + ((long) z[6] - (long) x[6]);
    z[6] = (uint) num7;
    long num8 = (num7 >> 32 /*0x20*/) + ((long) z[7] - (long) x[7]);
    z[7] = (uint) num8;
    return (int) (num8 >> 32 /*0x20*/);
  }

  public static int SubFrom(uint[] x, int xOff, uint[] z, int zOff, int cIn)
  {
    long num1 = (long) cIn + ((long) z[zOff] - (long) x[xOff]);
    z[zOff] = (uint) num1;
    long num2 = (num1 >> 32 /*0x20*/) + ((long) z[zOff + 1] - (long) x[xOff + 1]);
    z[zOff + 1] = (uint) num2;
    long num3 = (num2 >> 32 /*0x20*/) + ((long) z[zOff + 2] - (long) x[xOff + 2]);
    z[zOff + 2] = (uint) num3;
    long num4 = (num3 >> 32 /*0x20*/) + ((long) z[zOff + 3] - (long) x[xOff + 3]);
    z[zOff + 3] = (uint) num4;
    long num5 = (num4 >> 32 /*0x20*/) + ((long) z[zOff + 4] - (long) x[xOff + 4]);
    z[zOff + 4] = (uint) num5;
    long num6 = (num5 >> 32 /*0x20*/) + ((long) z[zOff + 5] - (long) x[xOff + 5]);
    z[zOff + 5] = (uint) num6;
    long num7 = (num6 >> 32 /*0x20*/) + ((long) z[zOff + 6] - (long) x[xOff + 6]);
    z[zOff + 6] = (uint) num7;
    long num8 = (num7 >> 32 /*0x20*/) + ((long) z[zOff + 7] - (long) x[xOff + 7]);
    z[zOff + 7] = (uint) num8;
    return (int) (num8 >> 32 /*0x20*/);
  }

  public static BigInteger ToBigInteger(uint[] x)
  {
    byte[] numArray = new byte[32 /*0x20*/];
    for (int index = 0; index < 8; ++index)
    {
      uint n = x[index];
      if (n != 0U)
        Pack.UInt32_To_BE(n, numArray, 7 - index << 2);
    }
    return new BigInteger(1, numArray);
  }

  public static BigInteger ToBigInteger64(ulong[] x)
  {
    byte[] numArray = new byte[32 /*0x20*/];
    for (int index = 0; index < 4; ++index)
    {
      ulong n = x[index];
      if (n != 0UL)
        Pack.UInt64_To_BE(n, numArray, 3 - index << 3);
    }
    return new BigInteger(1, numArray);
  }

  public static void Xor(uint[] x, int xOff, uint[] y, int yOff, uint[] z, int zOff)
  {
    for (int index = 0; index < 8; index += 4)
    {
      z[zOff + index] = x[xOff + index] ^ y[yOff + index];
      z[zOff + index + 1] = x[xOff + index + 1] ^ y[yOff + index + 1];
      z[zOff + index + 2] = x[xOff + index + 2] ^ y[yOff + index + 2];
      z[zOff + index + 3] = x[xOff + index + 3] ^ y[yOff + index + 3];
    }
  }

  public static void Zero(uint[] z)
  {
    z[0] = 0U;
    z[1] = 0U;
    z[2] = 0U;
    z[3] = 0U;
    z[4] = 0U;
    z[5] = 0U;
    z[6] = 0U;
    z[7] = 0U;
  }
}
