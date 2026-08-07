// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.Raw.Nat192
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Utilities;

#nullable disable
namespace Org.BouncyCastle.Math.Raw;

internal static class Nat192
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
    return (uint) (num6 >> 32 /*0x20*/);
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
    return (uint) (num6 >> 32 /*0x20*/);
  }

  public static uint AddTo(uint[] x, uint[] z)
  {
    ulong num1 = (ulong) (0L + ((long) x[0] + (long) z[0]));
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
    return (uint) (num6 >> 32 /*0x20*/);
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
    return (uint) (num6 >> 32 /*0x20*/);
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
    return (uint) (num6 >> 32 /*0x20*/);
  }

  public static void Copy(uint[] x, uint[] z)
  {
    z[0] = x[0];
    z[1] = x[1];
    z[2] = x[2];
    z[3] = x[3];
    z[4] = x[4];
    z[5] = x[5];
  }

  public static void Copy(uint[] x, int xOff, uint[] z, int zOff)
  {
    z[zOff] = x[xOff];
    z[zOff + 1] = x[xOff + 1];
    z[zOff + 2] = x[xOff + 2];
    z[zOff + 3] = x[xOff + 3];
    z[zOff + 4] = x[xOff + 4];
    z[zOff + 5] = x[xOff + 5];
  }

  public static void Copy64(ulong[] x, ulong[] z)
  {
    z[0] = x[0];
    z[1] = x[1];
    z[2] = x[2];
  }

  public static void Copy64(ulong[] x, int xOff, ulong[] z, int zOff)
  {
    z[zOff] = x[xOff];
    z[zOff + 1] = x[xOff + 1];
    z[zOff + 2] = x[xOff + 2];
  }

  public static uint[] Create() => new uint[6];

  public static ulong[] Create64() => new ulong[3];

  public static uint[] CreateExt() => new uint[12];

  public static ulong[] CreateExt64() => new ulong[6];

  public static bool Diff(uint[] x, int xOff, uint[] y, int yOff, uint[] z, int zOff)
  {
    int num = Nat192.Gte(x, xOff, y, yOff) ? 1 : 0;
    if (num != 0)
    {
      Nat192.Sub(x, xOff, y, yOff, z, zOff);
      return num != 0;
    }
    Nat192.Sub(y, yOff, x, xOff, z, zOff);
    return num != 0;
  }

  public static bool Eq(uint[] x, uint[] y)
  {
    for (int index = 5; index >= 0; --index)
    {
      if ((int) x[index] != (int) y[index])
        return false;
    }
    return true;
  }

  public static bool Eq64(ulong[] x, ulong[] y)
  {
    for (int index = 2; index >= 0; --index)
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
    int index = bit >> 5;
    if (index < 0 || index >= 6)
      return 0;
    int num = bit & 31 /*0x1F*/;
    return x[index] >> num & 1U;
  }

  public static bool Gte(uint[] x, uint[] y)
  {
    for (int index = 5; index >= 0; --index)
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
    for (int index = 5; index >= 0; --index)
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
    for (int index = 1; index < 6; ++index)
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
    for (int index = 1; index < 3; ++index)
    {
      if (x[index] != 0UL)
        return false;
    }
    return true;
  }

  public static bool IsZero(uint[] x)
  {
    for (int index = 0; index < 6; ++index)
    {
      if (x[index] != 0U)
        return false;
    }
    return true;
  }

  public static bool IsZero64(ulong[] x)
  {
    for (int index = 0; index < 3; ++index)
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
    ulong num7 = (ulong) x[0];
    ulong num8 = (ulong) (0L + (long) num7 * (long) num1);
    zz[0] = (uint) num8;
    ulong num9 = (num8 >> 32 /*0x20*/) + num7 * num2;
    zz[1] = (uint) num9;
    ulong num10 = (num9 >> 32 /*0x20*/) + num7 * num3;
    zz[2] = (uint) num10;
    ulong num11 = (num10 >> 32 /*0x20*/) + num7 * num4;
    zz[3] = (uint) num11;
    ulong num12 = (num11 >> 32 /*0x20*/) + num7 * num5;
    zz[4] = (uint) num12;
    ulong num13 = (num12 >> 32 /*0x20*/) + num7 * num6;
    zz[5] = (uint) num13;
    ulong num14 = num13 >> 32 /*0x20*/;
    zz[6] = (uint) num14;
    for (int index = 1; index < 6; ++index)
    {
      ulong num15 = (ulong) x[index];
      ulong num16 = (ulong) (0L + ((long) num15 * (long) num1 + (long) zz[index]));
      zz[index] = (uint) num16;
      ulong num17 = (num16 >> 32 /*0x20*/) + (num15 * num2 + (ulong) zz[index + 1]);
      zz[index + 1] = (uint) num17;
      ulong num18 = (num17 >> 32 /*0x20*/) + (num15 * num3 + (ulong) zz[index + 2]);
      zz[index + 2] = (uint) num18;
      ulong num19 = (num18 >> 32 /*0x20*/) + (num15 * num4 + (ulong) zz[index + 3]);
      zz[index + 3] = (uint) num19;
      ulong num20 = (num19 >> 32 /*0x20*/) + (num15 * num5 + (ulong) zz[index + 4]);
      zz[index + 4] = (uint) num20;
      ulong num21 = (num20 >> 32 /*0x20*/) + (num15 * num6 + (ulong) zz[index + 5]);
      zz[index + 5] = (uint) num21;
      ulong num22 = num21 >> 32 /*0x20*/;
      zz[index + 6] = (uint) num22;
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
    ulong num7 = (ulong) x[xOff];
    ulong num8 = (ulong) (0L + (long) num7 * (long) num1);
    zz[zzOff] = (uint) num8;
    ulong num9 = (num8 >> 32 /*0x20*/) + num7 * num2;
    zz[zzOff + 1] = (uint) num9;
    ulong num10 = (num9 >> 32 /*0x20*/) + num7 * num3;
    zz[zzOff + 2] = (uint) num10;
    ulong num11 = (num10 >> 32 /*0x20*/) + num7 * num4;
    zz[zzOff + 3] = (uint) num11;
    ulong num12 = (num11 >> 32 /*0x20*/) + num7 * num5;
    zz[zzOff + 4] = (uint) num12;
    ulong num13 = (num12 >> 32 /*0x20*/) + num7 * num6;
    zz[zzOff + 5] = (uint) num13;
    ulong num14 = num13 >> 32 /*0x20*/;
    zz[zzOff + 6] = (uint) num14;
    for (int index = 1; index < 6; ++index)
    {
      ++zzOff;
      ulong num15 = (ulong) x[xOff + index];
      ulong num16 = (ulong) (0L + ((long) num15 * (long) num1 + (long) zz[zzOff]));
      zz[zzOff] = (uint) num16;
      ulong num17 = (num16 >> 32 /*0x20*/) + (num15 * num2 + (ulong) zz[zzOff + 1]);
      zz[zzOff + 1] = (uint) num17;
      ulong num18 = (num17 >> 32 /*0x20*/) + (num15 * num3 + (ulong) zz[zzOff + 2]);
      zz[zzOff + 2] = (uint) num18;
      ulong num19 = (num18 >> 32 /*0x20*/) + (num15 * num4 + (ulong) zz[zzOff + 3]);
      zz[zzOff + 3] = (uint) num19;
      ulong num20 = (num19 >> 32 /*0x20*/) + (num15 * num5 + (ulong) zz[zzOff + 4]);
      zz[zzOff + 4] = (uint) num20;
      ulong num21 = (num20 >> 32 /*0x20*/) + (num15 * num6 + (ulong) zz[zzOff + 5]);
      zz[zzOff + 5] = (uint) num21;
      ulong num22 = num21 >> 32 /*0x20*/;
      zz[zzOff + 6] = (uint) num22;
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
    ulong num7 = 0;
    for (int index = 0; index < 6; ++index)
    {
      ulong num8 = (ulong) x[index];
      ulong num9 = (ulong) (0L + ((long) num8 * (long) num1 + (long) zz[index]));
      zz[index] = (uint) num9;
      ulong num10 = (num9 >> 32 /*0x20*/) + (num8 * num2 + (ulong) zz[index + 1]);
      zz[index + 1] = (uint) num10;
      ulong num11 = (num10 >> 32 /*0x20*/) + (num8 * num3 + (ulong) zz[index + 2]);
      zz[index + 2] = (uint) num11;
      ulong num12 = (num11 >> 32 /*0x20*/) + (num8 * num4 + (ulong) zz[index + 3]);
      zz[index + 3] = (uint) num12;
      ulong num13 = (num12 >> 32 /*0x20*/) + (num8 * num5 + (ulong) zz[index + 4]);
      zz[index + 4] = (uint) num13;
      ulong num14 = (num13 >> 32 /*0x20*/) + (num8 * num6 + (ulong) zz[index + 5]);
      zz[index + 5] = (uint) num14;
      ulong num15 = num14 >> 32 /*0x20*/;
      ulong num16 = num7 + (num15 + (ulong) zz[index + 6]);
      zz[index + 6] = (uint) num16;
      num7 = num16 >> 32 /*0x20*/;
    }
    return (uint) num7;
  }

  public static uint MulAddTo(uint[] x, int xOff, uint[] y, int yOff, uint[] zz, int zzOff)
  {
    ulong num1 = (ulong) y[yOff];
    ulong num2 = (ulong) y[yOff + 1];
    ulong num3 = (ulong) y[yOff + 2];
    ulong num4 = (ulong) y[yOff + 3];
    ulong num5 = (ulong) y[yOff + 4];
    ulong num6 = (ulong) y[yOff + 5];
    ulong num7 = 0;
    for (int index = 0; index < 6; ++index)
    {
      ulong num8 = (ulong) x[xOff + index];
      ulong num9 = (ulong) (0L + ((long) num8 * (long) num1 + (long) zz[zzOff]));
      zz[zzOff] = (uint) num9;
      ulong num10 = (num9 >> 32 /*0x20*/) + (num8 * num2 + (ulong) zz[zzOff + 1]);
      zz[zzOff + 1] = (uint) num10;
      ulong num11 = (num10 >> 32 /*0x20*/) + (num8 * num3 + (ulong) zz[zzOff + 2]);
      zz[zzOff + 2] = (uint) num11;
      ulong num12 = (num11 >> 32 /*0x20*/) + (num8 * num4 + (ulong) zz[zzOff + 3]);
      zz[zzOff + 3] = (uint) num12;
      ulong num13 = (num12 >> 32 /*0x20*/) + (num8 * num5 + (ulong) zz[zzOff + 4]);
      zz[zzOff + 4] = (uint) num13;
      ulong num14 = (num13 >> 32 /*0x20*/) + (num8 * num6 + (ulong) zz[zzOff + 5]);
      zz[zzOff + 5] = (uint) num14;
      ulong num15 = num14 >> 32 /*0x20*/;
      ulong num16 = num7 + (num15 + (ulong) zz[zzOff + 6]);
      zz[zzOff + 6] = (uint) num16;
      num7 = num16 >> 32 /*0x20*/;
      ++zzOff;
    }
    return (uint) num7;
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
    return (num18 >> 32 /*0x20*/) + num17;
  }

  public static uint MulWordAddExt(uint x, uint[] yy, int yyOff, uint[] zz, int zzOff)
  {
    ulong num1 = (ulong) x;
    ulong num2 = (ulong) (0L + ((long) num1 * (long) yy[yyOff] + (long) zz[zzOff]));
    zz[zzOff] = (uint) num2;
    ulong num3 = (num2 >> 32 /*0x20*/) + (num1 * (ulong) yy[yyOff + 1] + (ulong) zz[zzOff + 1]);
    zz[zzOff + 1] = (uint) num3;
    ulong num4 = (num3 >> 32 /*0x20*/) + (num1 * (ulong) yy[yyOff + 2] + (ulong) zz[zzOff + 2]);
    zz[zzOff + 2] = (uint) num4;
    ulong num5 = (num4 >> 32 /*0x20*/) + (num1 * (ulong) yy[yyOff + 3] + (ulong) zz[zzOff + 3]);
    zz[zzOff + 3] = (uint) num5;
    ulong num6 = (num5 >> 32 /*0x20*/) + (num1 * (ulong) yy[yyOff + 4] + (ulong) zz[zzOff + 4]);
    zz[zzOff + 4] = (uint) num6;
    ulong num7 = (num6 >> 32 /*0x20*/) + (num1 * (ulong) yy[yyOff + 5] + (ulong) zz[zzOff + 5]);
    zz[zzOff + 5] = (uint) num7;
    return (uint) (num7 >> 32 /*0x20*/);
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
    return num8 >> 32 /*0x20*/ != 0UL ? Nat.IncAt(6, z, zOff, 4) : 0U;
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
    return num4 >> 32 /*0x20*/ != 0UL ? Nat.IncAt(6, z, zOff, 3) : 0U;
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
    return num4 >> 32 /*0x20*/ != 0UL ? Nat.IncAt(6, z, zOff, 3) : 0U;
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
    while (++index < 6);
    return (uint) num1;
  }

  public static void Square(uint[] x, uint[] zz)
  {
    ulong num1 = (ulong) x[0];
    uint num2 = 0;
    int num3 = 5;
    int num4 = 12;
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
    ulong num64 = num56 + ((num63 >> 32 /*0x20*/) + num54 * num26);
    ulong num65 = num58 + ((num64 >> 32 /*0x20*/) + num54 * num39);
    ulong num66 = num57 + (num65 >> 32 /*0x20*/);
    uint num67 = (uint) num62;
    zz[6] = num67 << 1 | num61;
    uint num68 = num67 >> 31 /*0x1F*/;
    uint num69 = (uint) num63;
    zz[7] = num69 << 1 | num68;
    uint num70 = num69 >> 31 /*0x1F*/;
    uint num71 = (uint) num64;
    zz[8] = num71 << 1 | num70;
    uint num72 = num71 >> 31 /*0x1F*/;
    uint num73 = (uint) num65;
    zz[9] = num73 << 1 | num72;
    uint num74 = num73 >> 31 /*0x1F*/;
    uint num75 = (uint) num66;
    zz[10] = num75 << 1 | num74;
    uint num76 = num75 >> 31 /*0x1F*/;
    uint num77 = zz[11] + (uint) (num66 >> 32 /*0x20*/);
    zz[11] = num77 << 1 | num76;
  }

  public static void Square(uint[] x, int xOff, uint[] zz, int zzOff)
  {
    ulong num1 = (ulong) x[xOff];
    uint num2 = 0;
    int num3 = 5;
    int num4 = 12;
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
    ulong num64 = num56 + ((num63 >> 32 /*0x20*/) + num54 * num26);
    ulong num65 = num58 + ((num64 >> 32 /*0x20*/) + num54 * num39);
    ulong num66 = num57 + (num65 >> 32 /*0x20*/);
    uint num67 = (uint) num62;
    zz[zzOff + 6] = num67 << 1 | num61;
    uint num68 = num67 >> 31 /*0x1F*/;
    uint num69 = (uint) num63;
    zz[zzOff + 7] = num69 << 1 | num68;
    uint num70 = num69 >> 31 /*0x1F*/;
    uint num71 = (uint) num64;
    zz[zzOff + 8] = num71 << 1 | num70;
    uint num72 = num71 >> 31 /*0x1F*/;
    uint num73 = (uint) num65;
    zz[zzOff + 9] = num73 << 1 | num72;
    uint num74 = num73 >> 31 /*0x1F*/;
    uint num75 = (uint) num66;
    zz[zzOff + 10] = num75 << 1 | num74;
    uint num76 = num75 >> 31 /*0x1F*/;
    uint num77 = zz[zzOff + 11] + (uint) (num66 >> 32 /*0x20*/);
    zz[zzOff + 11] = num77 << 1 | num76;
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
    return (int) (num6 >> 32 /*0x20*/);
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
    return (int) (num6 >> 32 /*0x20*/);
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
    return (int) (num6 >> 32 /*0x20*/);
  }

  public static int SubFrom(uint[] x, uint[] z)
  {
    long num1 = 0L + ((long) z[0] - (long) x[0]);
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
    return (int) (num6 >> 32 /*0x20*/);
  }

  public static int SubFrom(uint[] x, int xOff, uint[] z, int zOff)
  {
    long num1 = 0L + ((long) z[zOff] - (long) x[xOff]);
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
    return (int) (num6 >> 32 /*0x20*/);
  }

  public static BigInteger ToBigInteger(uint[] x)
  {
    byte[] numArray = new byte[24];
    for (int index = 0; index < 6; ++index)
    {
      uint n = x[index];
      if (n != 0U)
        Pack.UInt32_To_BE(n, numArray, 5 - index << 2);
    }
    return new BigInteger(1, numArray);
  }

  public static BigInteger ToBigInteger64(ulong[] x)
  {
    byte[] numArray = new byte[24];
    for (int index = 0; index < 3; ++index)
    {
      ulong n = x[index];
      if (n != 0UL)
        Pack.UInt64_To_BE(n, numArray, 2 - index << 3);
    }
    return new BigInteger(1, numArray);
  }

  public static void Zero(uint[] z)
  {
    z[0] = 0U;
    z[1] = 0U;
    z[2] = 0U;
    z[3] = 0U;
    z[4] = 0U;
    z[5] = 0U;
  }
}
