// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Modes.Gcm.GcmUtilities
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Math.Raw;
using Org.BouncyCastle.Utilities;

#nullable disable
namespace Org.BouncyCastle.Crypto.Modes.Gcm;

internal static class GcmUtilities
{
  private const uint E1 = 3774873600 /*0xE1000000*/;
  private const ulong E1UL = 16212958658533785600 /*0xE100000000000000*/;

  internal static void One(out GcmUtilities.FieldElement x)
  {
    x.n0 = 9223372036854775808UL /*0x8000000000000000*/;
    x.n1 = 0UL;
  }

  internal static void AsBytes(ulong x0, ulong x1, byte[] z)
  {
    Pack.UInt64_To_BE(x0, z, 0);
    Pack.UInt64_To_BE(x1, z, 8);
  }

  internal static void AsBytes(ref GcmUtilities.FieldElement x, byte[] z)
  {
    GcmUtilities.AsBytes(x.n0, x.n1, z);
  }

  internal static void AsFieldElement(byte[] x, out GcmUtilities.FieldElement z)
  {
    z.n0 = Pack.BE_To_UInt64(x, 0);
    z.n1 = Pack.BE_To_UInt64(x, 8);
  }

  internal static void DivideP(ref GcmUtilities.FieldElement x, out GcmUtilities.FieldElement z)
  {
    ulong n0 = x.n0;
    ulong n1 = x.n1;
    ulong num1 = n0 >> 63 /*0x3F*/;
    ulong num2 = n0 ^ num1 & 16212958658533785600UL /*0xE100000000000000*/;
    z.n0 = num2 << 1 | n1 >> 63 /*0x3F*/;
    z.n1 = (ulong) ((long) n1 << 1 | -(long) num1);
  }

  internal static void Multiply(byte[] x, byte[] y)
  {
    GcmUtilities.FieldElement z1;
    GcmUtilities.AsFieldElement(x, out z1);
    GcmUtilities.FieldElement z2;
    GcmUtilities.AsFieldElement(y, out z2);
    GcmUtilities.Multiply(ref z1, ref z2);
    GcmUtilities.AsBytes(ref z1, x);
  }

  internal static void Multiply(ref GcmUtilities.FieldElement x, ref GcmUtilities.FieldElement y)
  {
    long n0_1 = (long) x.n0;
    ulong n1_1 = x.n1;
    ulong n0_2 = y.n0;
    ulong n1_2 = y.n1;
    ulong x1 = Longs.Reverse((ulong) n0_1);
    ulong x2 = Longs.Reverse(n1_1);
    ulong y1 = Longs.Reverse(n0_2);
    ulong y2 = Longs.Reverse(n1_2);
    ulong num1 = Longs.Reverse(GcmUtilities.ImplMul64(x1, y1));
    ulong num2 = GcmUtilities.ImplMul64((ulong) n0_1, n0_2) << 1;
    ulong num3 = Longs.Reverse(GcmUtilities.ImplMul64(x2, y2));
    ulong num4 = GcmUtilities.ImplMul64(n1_1, n1_2) << 1;
    ulong num5 = Longs.Reverse(GcmUtilities.ImplMul64(x1 ^ x2, y1 ^ y2));
    ulong num6 = GcmUtilities.ImplMul64((ulong) n0_1 ^ n1_1, n0_2 ^ n1_2) << 1;
    ulong num7 = num1;
    ulong num8 = num2 ^ num1 ^ num3 ^ num5;
    ulong num9 = num3 ^ num2 ^ num4 ^ num6;
    ulong num10 = num4;
    ulong num11 = num8 ^ num10 ^ num10 >> 1 ^ num10 >> 2 ^ num10 >> 7;
    ulong num12 = num9 ^ (ulong) ((long) num10 << 62 ^ (long) num10 << 57);
    ulong num13 = num7 ^ num12 ^ num12 >> 1 ^ num12 >> 2 ^ num12 >> 7;
    ulong num14 = num11 ^ (ulong) ((long) num12 << 63 /*0x3F*/ ^ (long) num12 << 62 ^ (long) num12 << 57);
    x.n0 = num13;
    x.n1 = num14;
  }

  internal static void MultiplyP7(ref GcmUtilities.FieldElement x)
  {
    ulong n0 = x.n0;
    ulong n1 = x.n1;
    ulong num = n1 << 57;
    x.n0 = n0 >> 7 ^ num ^ num >> 1 ^ num >> 2 ^ num >> 7;
    x.n1 = n1 >> 7 | n0 << 57;
  }

  internal static void MultiplyP8(ref GcmUtilities.FieldElement x)
  {
    ulong n0 = x.n0;
    ulong n1 = x.n1;
    ulong num = n1 << 56;
    x.n0 = n0 >> 8 ^ num ^ num >> 1 ^ num >> 2 ^ num >> 7;
    x.n1 = n1 >> 8 | n0 << 56;
  }

  internal static void MultiplyP8(ref GcmUtilities.FieldElement x, out GcmUtilities.FieldElement y)
  {
    ulong n0 = x.n0;
    ulong n1 = x.n1;
    ulong num = n1 << 56;
    y.n0 = n0 >> 8 ^ num ^ num >> 1 ^ num >> 2 ^ num >> 7;
    y.n1 = n1 >> 8 | n0 << 56;
  }

  internal static void MultiplyP16(ref GcmUtilities.FieldElement x)
  {
    ulong n0 = x.n0;
    ulong n1 = x.n1;
    ulong num = n1 << 48 /*0x30*/;
    x.n0 = n0 >> 16 /*0x10*/ ^ num ^ num >> 1 ^ num >> 2 ^ num >> 7;
    x.n1 = n1 >> 16 /*0x10*/ | n0 << 48 /*0x30*/;
  }

  internal static void Square(ref GcmUtilities.FieldElement x)
  {
    ulong low1;
    long num1 = (long) Interleave.Expand64To128Rev(x.n0, out low1);
    ulong low2;
    ulong num2 = Interleave.Expand64To128Rev(x.n1, out low2);
    long num3 = (long) num2;
    ulong num4 = (ulong) (num1 ^ num3) ^ num2 >> 1 ^ num2 >> 2 ^ num2 >> 7;
    ulong num5 = (ulong) ((long) low2 ^ (long) num2 << 62 ^ (long) num2 << 57);
    x.n0 = low1 ^ num5 ^ num5 >> 1 ^ num5 >> 2 ^ num5 >> 7;
    x.n1 = (ulong) ((long) num4 ^ (long) low2 << 62 ^ (long) low2 << 57);
  }

  internal static void Xor(byte[] x, byte[] y)
  {
    int index1 = 0;
    do
    {
      x[index1] ^= y[index1];
      int index2 = index1 + 1;
      x[index2] ^= y[index2];
      int index3 = index2 + 1;
      x[index3] ^= y[index3];
      int index4 = index3 + 1;
      x[index4] ^= y[index4];
      index1 = index4 + 1;
    }
    while (index1 < 16 /*0x10*/);
  }

  internal static void Xor(byte[] x, byte[] y, int yOff)
  {
    int index1 = 0;
    do
    {
      x[index1] ^= y[yOff + index1];
      int index2 = index1 + 1;
      x[index2] ^= y[yOff + index2];
      int index3 = index2 + 1;
      x[index3] ^= y[yOff + index3];
      int index4 = index3 + 1;
      x[index4] ^= y[yOff + index4];
      index1 = index4 + 1;
    }
    while (index1 < 16 /*0x10*/);
  }

  internal static void Xor(byte[] x, byte[] y, int yOff, int yLen)
  {
    while (--yLen >= 0)
      x[yLen] ^= y[yOff + yLen];
  }

  internal static void Xor(byte[] x, int xOff, byte[] y, int yOff, int len)
  {
    while (--len >= 0)
      x[xOff + len] ^= y[yOff + len];
  }

  internal static void Xor(ref GcmUtilities.FieldElement x, ref GcmUtilities.FieldElement y)
  {
    x.n0 ^= y.n0;
    x.n1 ^= y.n1;
  }

  internal static void Xor(
    ref GcmUtilities.FieldElement x,
    ref GcmUtilities.FieldElement y,
    out GcmUtilities.FieldElement z)
  {
    z.n0 = x.n0 ^ y.n0;
    z.n1 = x.n1 ^ y.n1;
  }

  private static ulong ImplMul64(ulong x, ulong y)
  {
    long num1 = (long) x & 1229782938247303441L /*0x1111111111111111*/;
    ulong num2 = x & 2459565876494606882UL /*0x2222222222222222*/;
    ulong num3 = x & 4919131752989213764UL /*0x4444444444444444*/;
    ulong num4 = x & 9838263505978427528UL /*0x8888888888888888*/;
    ulong num5 = y & 1229782938247303441UL /*0x1111111111111111*/;
    ulong num6 = y & 2459565876494606882UL /*0x2222222222222222*/;
    ulong num7 = y & 4919131752989213764UL /*0x4444444444444444*/;
    ulong num8 = y & 9838263505978427528UL /*0x8888888888888888*/;
    return (ulong) (num1 * (long) num5 ^ (long) num2 * (long) num8 ^ (long) num3 * (long) num7 ^ (long) num4 * (long) num6) & 1229782938247303441UL /*0x1111111111111111*/ | (ulong) (num1 * (long) num6 ^ (long) num2 * (long) num5 ^ (long) num3 * (long) num8 ^ (long) num4 * (long) num7) & 2459565876494606882UL /*0x2222222222222222*/ | (ulong) (num1 * (long) num7 ^ (long) num2 * (long) num6 ^ (long) num3 * (long) num5 ^ (long) num4 * (long) num8) & 4919131752989213764UL /*0x4444444444444444*/ | (ulong) (num1 * (long) num8 ^ (long) num2 * (long) num7 ^ (long) num3 * (long) num6 ^ (long) num4 * (long) num5) & 9838263505978427528UL /*0x8888888888888888*/;
  }

  internal struct FieldElement
  {
    internal ulong n0;
    internal ulong n1;
  }
}
