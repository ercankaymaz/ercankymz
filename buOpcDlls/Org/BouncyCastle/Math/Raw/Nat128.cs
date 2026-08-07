// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.Raw.Nat128
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Utilities;

#nullable disable
namespace Org.BouncyCastle.Math.Raw;

internal static class Nat128
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
    return (uint) (num4 >> 32 /*0x20*/);
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
    return (uint) (num4 >> 32 /*0x20*/);
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
    return (uint) (num4 >> 32 /*0x20*/);
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
    return (uint) (num4 >> 32 /*0x20*/);
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
    return (uint) (num4 >> 32 /*0x20*/);
  }

  public static void Copy(uint[] x, uint[] z)
  {
    z[0] = x[0];
    z[1] = x[1];
    z[2] = x[2];
    z[3] = x[3];
  }

  public static void Copy(uint[] x, int xOff, uint[] z, int zOff)
  {
    z[zOff] = x[xOff];
    z[zOff + 1] = x[xOff + 1];
    z[zOff + 2] = x[xOff + 2];
    z[zOff + 3] = x[xOff + 3];
  }

  public static void Copy64(ulong[] x, ulong[] z)
  {
    z[0] = x[0];
    z[1] = x[1];
  }

  public static void Copy64(ulong[] x, int xOff, ulong[] z, int zOff)
  {
    z[zOff] = x[xOff];
    z[zOff + 1] = x[xOff + 1];
  }

  public static uint[] Create() => new uint[4];

  public static ulong[] Create64() => new ulong[2];

  public static uint[] CreateExt() => new uint[8];

  public static ulong[] CreateExt64() => new ulong[4];

  public static bool Diff(uint[] x, int xOff, uint[] y, int yOff, uint[] z, int zOff)
  {
    int num = Nat128.Gte(x, xOff, y, yOff) ? 1 : 0;
    if (num != 0)
    {
      Nat128.Sub(x, xOff, y, yOff, z, zOff);
      return num != 0;
    }
    Nat128.Sub(y, yOff, x, xOff, z, zOff);
    return num != 0;
  }

  public static bool Eq(uint[] x, uint[] y)
  {
    for (int index = 3; index >= 0; --index)
    {
      if ((int) x[index] != (int) y[index])
        return false;
    }
    return true;
  }

  public static bool Eq64(ulong[] x, ulong[] y)
  {
    for (int index = 1; index >= 0; --index)
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
    if ((bit & (int) sbyte.MaxValue) != bit)
      return 0;
    int index = bit >> 5;
    int num = bit & 31 /*0x1F*/;
    return x[index] >> num & 1U;
  }

  public static bool Gte(uint[] x, uint[] y)
  {
    for (int index = 3; index >= 0; --index)
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
    for (int index = 3; index >= 0; --index)
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
    for (int index = 1; index < 4; ++index)
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
    for (int index = 1; index < 2; ++index)
    {
      if (x[index] != 0UL)
        return false;
    }
    return true;
  }

  public static bool IsZero(uint[] x)
  {
    for (int index = 0; index < 4; ++index)
    {
      if (x[index] != 0U)
        return false;
    }
    return true;
  }

  public static bool IsZero64(ulong[] x)
  {
    for (int index = 0; index < 2; ++index)
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
    ulong num5 = (ulong) x[0];
    ulong num6 = (ulong) (0L + (long) num5 * (long) num1);
    zz[0] = (uint) num6;
    ulong num7 = (num6 >> 32 /*0x20*/) + num5 * num2;
    zz[1] = (uint) num7;
    ulong num8 = (num7 >> 32 /*0x20*/) + num5 * num3;
    zz[2] = (uint) num8;
    ulong num9 = (num8 >> 32 /*0x20*/) + num5 * num4;
    zz[3] = (uint) num9;
    ulong num10 = num9 >> 32 /*0x20*/;
    zz[4] = (uint) num10;
    for (int index = 1; index < 4; ++index)
    {
      ulong num11 = (ulong) x[index];
      ulong num12 = (ulong) (0L + ((long) num11 * (long) num1 + (long) zz[index]));
      zz[index] = (uint) num12;
      ulong num13 = (num12 >> 32 /*0x20*/) + (num11 * num2 + (ulong) zz[index + 1]);
      zz[index + 1] = (uint) num13;
      ulong num14 = (num13 >> 32 /*0x20*/) + (num11 * num3 + (ulong) zz[index + 2]);
      zz[index + 2] = (uint) num14;
      ulong num15 = (num14 >> 32 /*0x20*/) + (num11 * num4 + (ulong) zz[index + 3]);
      zz[index + 3] = (uint) num15;
      ulong num16 = num15 >> 32 /*0x20*/;
      zz[index + 4] = (uint) num16;
    }
  }

  public static void Mul(uint[] x, int xOff, uint[] y, int yOff, uint[] zz, int zzOff)
  {
    ulong num1 = (ulong) y[yOff];
    ulong num2 = (ulong) y[yOff + 1];
    ulong num3 = (ulong) y[yOff + 2];
    ulong num4 = (ulong) y[yOff + 3];
    ulong num5 = (ulong) x[xOff];
    ulong num6 = (ulong) (0L + (long) num5 * (long) num1);
    zz[zzOff] = (uint) num6;
    ulong num7 = (num6 >> 32 /*0x20*/) + num5 * num2;
    zz[zzOff + 1] = (uint) num7;
    ulong num8 = (num7 >> 32 /*0x20*/) + num5 * num3;
    zz[zzOff + 2] = (uint) num8;
    ulong num9 = (num8 >> 32 /*0x20*/) + num5 * num4;
    zz[zzOff + 3] = (uint) num9;
    ulong num10 = num9 >> 32 /*0x20*/;
    zz[zzOff + 4] = (uint) num10;
    for (int index = 1; index < 4; ++index)
    {
      ++zzOff;
      ulong num11 = (ulong) x[xOff + index];
      ulong num12 = (ulong) (0L + ((long) num11 * (long) num1 + (long) zz[zzOff]));
      zz[zzOff] = (uint) num12;
      ulong num13 = (num12 >> 32 /*0x20*/) + (num11 * num2 + (ulong) zz[zzOff + 1]);
      zz[zzOff + 1] = (uint) num13;
      ulong num14 = (num13 >> 32 /*0x20*/) + (num11 * num3 + (ulong) zz[zzOff + 2]);
      zz[zzOff + 2] = (uint) num14;
      ulong num15 = (num14 >> 32 /*0x20*/) + (num11 * num4 + (ulong) zz[zzOff + 3]);
      zz[zzOff + 3] = (uint) num15;
      ulong num16 = num15 >> 32 /*0x20*/;
      zz[zzOff + 4] = (uint) num16;
    }
  }

  public static uint MulAddTo(uint[] x, uint[] y, uint[] zz)
  {
    ulong num1 = (ulong) y[0];
    ulong num2 = (ulong) y[1];
    ulong num3 = (ulong) y[2];
    ulong num4 = (ulong) y[3];
    ulong num5 = 0;
    for (int index = 0; index < 4; ++index)
    {
      ulong num6 = (ulong) x[index];
      ulong num7 = (ulong) (0L + ((long) num6 * (long) num1 + (long) zz[index]));
      zz[index] = (uint) num7;
      ulong num8 = (num7 >> 32 /*0x20*/) + (num6 * num2 + (ulong) zz[index + 1]);
      zz[index + 1] = (uint) num8;
      ulong num9 = (num8 >> 32 /*0x20*/) + (num6 * num3 + (ulong) zz[index + 2]);
      zz[index + 2] = (uint) num9;
      ulong num10 = (num9 >> 32 /*0x20*/) + (num6 * num4 + (ulong) zz[index + 3]);
      zz[index + 3] = (uint) num10;
      ulong num11 = num10 >> 32 /*0x20*/;
      ulong num12 = num5 + (num11 + (ulong) zz[index + 4]);
      zz[index + 4] = (uint) num12;
      num5 = num12 >> 32 /*0x20*/;
    }
    return (uint) num5;
  }

  public static uint MulAddTo(uint[] x, int xOff, uint[] y, int yOff, uint[] zz, int zzOff)
  {
    ulong num1 = (ulong) y[yOff];
    ulong num2 = (ulong) y[yOff + 1];
    ulong num3 = (ulong) y[yOff + 2];
    ulong num4 = (ulong) y[yOff + 3];
    ulong num5 = 0;
    for (int index = 0; index < 4; ++index)
    {
      ulong num6 = (ulong) x[xOff + index];
      ulong num7 = (ulong) (0L + ((long) num6 * (long) num1 + (long) zz[zzOff]));
      zz[zzOff] = (uint) num7;
      ulong num8 = (num7 >> 32 /*0x20*/) + (num6 * num2 + (ulong) zz[zzOff + 1]);
      zz[zzOff + 1] = (uint) num8;
      ulong num9 = (num8 >> 32 /*0x20*/) + (num6 * num3 + (ulong) zz[zzOff + 2]);
      zz[zzOff + 2] = (uint) num9;
      ulong num10 = (num9 >> 32 /*0x20*/) + (num6 * num4 + (ulong) zz[zzOff + 3]);
      zz[zzOff + 3] = (uint) num10;
      ulong num11 = num10 >> 32 /*0x20*/;
      ulong num12 = num5 + (num11 + (ulong) zz[zzOff + 4]);
      zz[zzOff + 4] = (uint) num12;
      num5 = num12 >> 32 /*0x20*/;
      ++zzOff;
    }
    return (uint) num5;
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
    return (num12 >> 32 /*0x20*/) + num11;
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
    return (uint) (num5 >> 32 /*0x20*/);
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
    return (uint) (num8 >> 32 /*0x20*/);
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
    return num4 >> 32 /*0x20*/ != 0UL ? Nat.IncAt(4, z, zOff, 3) : 0U;
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
    return num4 >> 32 /*0x20*/ != 0UL ? Nat.IncAt(4, z, zOff, 3) : 0U;
  }

  public static uint MulWordsAdd(uint x, uint y, uint[] z, int zOff)
  {
    ulong num1 = (ulong) x;
    ulong num2 = (ulong) (0L + ((long) y * (long) num1 + (long) z[zOff]));
    z[zOff] = (uint) num2;
    ulong num3 = (num2 >> 32 /*0x20*/) + (ulong) z[zOff + 1];
    z[zOff + 1] = (uint) num3;
    return num3 >> 32 /*0x20*/ != 0UL ? Nat.IncAt(4, z, zOff, 2) : 0U;
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
    while (++index < 4);
    return (uint) num1;
  }

  public static void Square(uint[] x, uint[] zz)
  {
    ulong num1 = (ulong) x[0];
    uint num2 = 0;
    int num3 = 3;
    int num4 = 8;
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
    ulong num36 = num29 + (num35 >> 32 /*0x20*/);
    uint num37 = (uint) num34;
    zz[4] = num37 << 1 | num33;
    uint num38 = num37 >> 31 /*0x1F*/;
    uint num39 = (uint) num35;
    zz[5] = num39 << 1 | num38;
    uint num40 = num39 >> 31 /*0x1F*/;
    uint num41 = (uint) num36;
    zz[6] = num41 << 1 | num40;
    uint num42 = num41 >> 31 /*0x1F*/;
    uint num43 = zz[7] + (uint) (num36 >> 32 /*0x20*/);
    zz[7] = num43 << 1 | num42;
  }

  public static void Square(uint[] x, int xOff, uint[] zz, int zzOff)
  {
    ulong num1 = (ulong) x[xOff];
    uint num2 = 0;
    int num3 = 3;
    int num4 = 8;
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
    ulong num36 = num29 + (num35 >> 32 /*0x20*/);
    uint num37 = (uint) num34;
    zz[zzOff + 4] = num37 << 1 | num33;
    uint num38 = num37 >> 31 /*0x1F*/;
    uint num39 = (uint) num35;
    zz[zzOff + 5] = num39 << 1 | num38;
    uint num40 = num39 >> 31 /*0x1F*/;
    uint num41 = (uint) num36;
    zz[zzOff + 6] = num41 << 1 | num40;
    uint num42 = num41 >> 31 /*0x1F*/;
    uint num43 = zz[zzOff + 7] + (uint) (num36 >> 32 /*0x20*/);
    zz[zzOff + 7] = num43 << 1 | num42;
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
    return (int) (num4 >> 32 /*0x20*/);
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
    return (int) (num4 >> 32 /*0x20*/);
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
    return (int) (num4 >> 32 /*0x20*/);
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
    return (int) (num4 >> 32 /*0x20*/);
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
    return (int) (num4 >> 32 /*0x20*/);
  }

  public static BigInteger ToBigInteger(uint[] x)
  {
    byte[] numArray = new byte[16 /*0x10*/];
    for (int index = 0; index < 4; ++index)
    {
      uint n = x[index];
      if (n != 0U)
        Pack.UInt32_To_BE(n, numArray, 3 - index << 2);
    }
    return new BigInteger(1, numArray);
  }

  public static BigInteger ToBigInteger64(ulong[] x)
  {
    byte[] numArray = new byte[16 /*0x10*/];
    for (int index = 0; index < 2; ++index)
    {
      ulong n = x[index];
      if (n != 0UL)
        Pack.UInt64_To_BE(n, numArray, 1 - index << 3);
    }
    return new BigInteger(1, numArray);
  }

  public static void Zero(uint[] z)
  {
    z[0] = 0U;
    z[1] = 0U;
    z[2] = 0U;
    z[3] = 0U;
  }
}
