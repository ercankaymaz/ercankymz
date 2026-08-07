// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Rfc8032.Scalar25519
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.Raw;
using System;

#nullable disable
namespace Org.BouncyCastle.Math.EC.Rfc8032;

internal static class Scalar25519
{
  internal const int Size = 8;
  private const long M08L = 255 /*0xFF*/;
  private const long M28L = 268435455 /*0x0FFFFFFF*/;
  private const long M32L = 4294967295 /*0xFFFFFFFF*/;
  private const int TargetLength = 254;
  private static readonly uint[] L = new uint[8]
  {
    1559614445U,
    1477600026U,
    2734136534U,
    350157278U,
    0U,
    0U,
    0U,
    268435456U /*0x10000000*/
  };
  private static readonly uint[] LSq = new uint[16 /*0x10*/]
  {
    2870118761U,
    3807245957U,
    580428573U,
    1745064566U,
    3524785598U,
    1036971123U,
    461123738U,
    2712901953U,
    1268693629U,
    3405925475U,
    3562992538U,
    43769659U,
    0U,
    0U,
    0U,
    16777216U /*0x01000000*/
  };
  private const int L0 = -50998291;
  private const int L1 = 19280294;
  private const int L2 = 127719000;
  private const int L3 = -6428113;
  private const int L4 = 5343;

  internal static bool CheckVar(byte[] s, uint[] n)
  {
    Scalar25519.Decode(s, n);
    return !Nat256.Gte(n, Scalar25519.L);
  }

  internal static void Decode(byte[] k, uint[] n) => Codec.Decode32(k, 0, n, 0, 8);

  internal static void GetOrderWnafVar(int width, sbyte[] ws)
  {
    Wnaf.GetSignedVar(Scalar25519.L, width, ws);
  }

  internal static void Multiply128Var(uint[] x, uint[] y128, uint[] z)
  {
    uint[] numArray1 = new uint[12];
    Nat256.Mul128(x, y128, numArray1);
    if ((int) y128[3] < 0)
    {
      int num = (int) Nat256.AddTo(Scalar25519.L, 0, numArray1, 4, 0U);
      Nat256.SubFrom(x, 0, numArray1, 4, 0);
    }
    byte[] numArray2 = new byte[64 /*0x40*/];
    Codec.Encode32(numArray1, 0, 12, numArray2, 0);
    Scalar25519.Decode(Scalar25519.Reduce(numArray2), z);
  }

  internal static byte[] Reduce(byte[] n)
  {
    byte[] bs = new byte[64 /*0x40*/];
    long num1 = (long) Codec.Decode32(n, 0) & (long) uint.MaxValue;
    long num2 = (long) (Codec.Decode24(n, 4) << 4) & (long) uint.MaxValue;
    long num3 = (long) Codec.Decode32(n, 7) & (long) uint.MaxValue;
    long num4 = (long) (Codec.Decode24(n, 11) << 4) & (long) uint.MaxValue;
    long num5 = (long) Codec.Decode32(n, 14) & (long) uint.MaxValue;
    long num6 = (long) (Codec.Decode24(n, 18) << 4) & (long) uint.MaxValue;
    long num7 = (long) Codec.Decode32(n, 21) & (long) uint.MaxValue;
    long num8 = (long) (Codec.Decode24(n, 25) << 4) & (long) uint.MaxValue;
    long num9 = (long) Codec.Decode32(n, 28) & (long) uint.MaxValue;
    long num10 = (long) (Codec.Decode24(n, 32 /*0x20*/) << 4) & (long) uint.MaxValue;
    long num11 = (long) Codec.Decode32(n, 35) & (long) uint.MaxValue;
    long num12 = (long) (Codec.Decode24(n, 39) << 4) & (long) uint.MaxValue;
    long num13 = (long) Codec.Decode32(n, 42) & (long) uint.MaxValue;
    long num14 = (long) (Codec.Decode24(n, 46) << 4) & (long) uint.MaxValue;
    long num15 = (long) Codec.Decode32(n, 49) & (long) uint.MaxValue;
    long num16 = (long) (Codec.Decode24(n, 53) << 4) & (long) uint.MaxValue;
    long num17 = (long) Codec.Decode32(n, 56) & (long) uint.MaxValue;
    long num18 = (long) (Codec.Decode24(n, 60) << 4) & (long) uint.MaxValue;
    long num19 = (long) n[63 /*0x3F*/] & (long) byte.MaxValue;
    long num20 = num10 - num19 * -50998291L;
    long num21 = num11 - num19 * 19280294L;
    long num22 = num12 - num19 * 127719000L;
    long num23 = num13 - num19 * -6428113L;
    long num24 = num14 - num19 * 5343L;
    long num25 = num18 + (num17 >> 28);
    long num26 = num17 & 268435455L /*0x0FFFFFFF*/;
    long num27 = num9 - num25 * -50998291L;
    long num28 = num20 - num25 * 19280294L;
    long num29 = num21 - num25 * 127719000L;
    long num30 = num22 - num25 * -6428113L;
    long num31 = num23 - num25 * 5343L;
    long num32 = num8 - num26 * -50998291L;
    long num33 = num27 - num26 * 19280294L;
    long num34 = num28 - num26 * 127719000L;
    long num35 = num29 - num26 * -6428113L;
    long num36 = num30 - num26 * 5343L;
    long num37 = num16 + (num15 >> 28);
    long num38 = num15 & 268435455L /*0x0FFFFFFF*/;
    long num39 = num7 - num37 * -50998291L;
    long num40 = num32 - num37 * 19280294L;
    long num41 = num33 - num37 * 127719000L;
    long num42 = num34 - num37 * -6428113L;
    long num43 = num35 - num37 * 5343L;
    long num44 = num6 - num38 * -50998291L;
    long num45 = num39 - num38 * 19280294L;
    long num46 = num40 - num38 * 127719000L;
    long num47 = num41 - num38 * -6428113L;
    long num48 = num42 - num38 * 5343L;
    long num49 = num24 + (num31 >> 28);
    long num50 = num31 & 268435455L /*0x0FFFFFFF*/;
    long num51 = num5 - num49 * -50998291L;
    long num52 = num44 - num49 * 19280294L;
    long num53 = num45 - num49 * 127719000L;
    long num54 = num46 - num49 * -6428113L;
    long num55 = num47 - num49 * 5343L;
    long num56 = num50 + (num36 >> 28);
    long num57 = num36 & 268435455L /*0x0FFFFFFF*/;
    long num58 = num4 - num56 * -50998291L;
    long num59 = num51 - num56 * 19280294L;
    long num60 = num52 - num56 * 127719000L;
    long num61 = num53 - num56 * -6428113L;
    long num62 = num54 - num56 * 5343L;
    long num63 = num57 + (num43 >> 28);
    long num64 = num43 & 268435455L /*0x0FFFFFFF*/;
    long num65 = num3 - num63 * -50998291L;
    long num66 = num58 - num63 * 19280294L;
    long num67 = num59 - num63 * 127719000L;
    long num68 = num60 - num63 * -6428113L;
    long num69 = num61 - num63 * 5343L;
    long num70 = num64 + (num48 >> 28);
    long num71 = num48 & 268435455L /*0x0FFFFFFF*/;
    long num72 = num2 - num70 * -50998291L;
    long num73 = num65 - num70 * 19280294L;
    long num74 = num66 - num70 * 127719000L;
    long num75 = num67 - num70 * -6428113L;
    long num76 = num68 - num70 * 5343L;
    long num77 = num55 + (num62 >> 28);
    long num78 = num62 & 268435455L /*0x0FFFFFFF*/;
    long num79 = num71 + (num77 >> 28);
    long num80 = num77 & 268435455L /*0x0FFFFFFF*/;
    long num81 = num80 >> 27 & 1L;
    long num82 = num79 + num81;
    long num83 = num1 - num82 * -50998291L;
    long num84 = num72 - num82 * 19280294L;
    long num85 = num73 - num82 * 127719000L;
    long num86 = num74 - num82 * -6428113L;
    long num87 = num75 - num82 * 5343L;
    long num88 = num84 + (num83 >> 28);
    long num89 = num83 & 268435455L /*0x0FFFFFFF*/;
    long num90 = num85 + (num88 >> 28);
    long num91 = num88 & 268435455L /*0x0FFFFFFF*/;
    long num92 = num86 + (num90 >> 28);
    long num93 = num90 & 268435455L /*0x0FFFFFFF*/;
    long num94 = num87 + (num92 >> 28);
    long num95 = num92 & 268435455L /*0x0FFFFFFF*/;
    long num96 = num76 + (num94 >> 28);
    long num97 = num94 & 268435455L /*0x0FFFFFFF*/;
    long num98 = num69 + (num96 >> 28);
    long num99 = num96 & 268435455L /*0x0FFFFFFF*/;
    long num100 = num78 + (num98 >> 28);
    long num101 = num98 & 268435455L /*0x0FFFFFFF*/;
    long num102 = num80 + (num100 >> 28);
    long num103 = num100 & 268435455L /*0x0FFFFFFF*/;
    long num104 = num102 >> 28;
    long num105 = num102 & 268435455L /*0x0FFFFFFF*/;
    long num106 = num104 - num81;
    long num107 = num89 + (num106 & -50998291L);
    long num108 = num91 + (num106 & 19280294L);
    long num109 = num93 + (num106 & 127719000L);
    long num110 = num95 + (num106 & -6428113L);
    long num111 = num97 + (num106 & 5343L);
    long num112 = num108 + (num107 >> 28);
    long num113 = num107 & 268435455L /*0x0FFFFFFF*/;
    long num114 = num109 + (num112 >> 28);
    long num115 = num112 & 268435455L /*0x0FFFFFFF*/;
    long num116 = num110 + (num114 >> 28);
    long num117 = num114 & 268435455L /*0x0FFFFFFF*/;
    long num118 = num111 + (num116 >> 28);
    long num119 = num116 & 268435455L /*0x0FFFFFFF*/;
    long num120 = num99 + (num118 >> 28);
    long num121 = num118 & 268435455L /*0x0FFFFFFF*/;
    long num122 = num101 + (num120 >> 28);
    long num123 = num120 & 268435455L /*0x0FFFFFFF*/;
    long num124 = num103 + (num122 >> 28);
    long num125 = num122 & 268435455L /*0x0FFFFFFF*/;
    long n1 = num105 + (num124 >> 28);
    long num126 = num124 & 268435455L /*0x0FFFFFFF*/;
    Codec.Encode56((ulong) (num113 | num115 << 28), bs, 0);
    Codec.Encode56((ulong) (num117 | num119 << 28), bs, 7);
    Codec.Encode56((ulong) (num121 | num123 << 28), bs, 14);
    Codec.Encode56((ulong) (num125 | num126 << 28), bs, 21);
    Codec.Encode32((uint) n1, bs, 28);
    return bs;
  }

  internal static void ReduceBasisVar(uint[] k, uint[] z0, uint[] z1)
  {
    uint[] x1 = new uint[16 /*0x10*/];
    Array.Copy((Array) Scalar25519.LSq, (Array) x1, 16 /*0x10*/);
    uint[] y1 = new uint[16 /*0x10*/];
    Nat256.Square(k, y1);
    ++y1[0];
    uint[] numArray = new uint[16 /*0x10*/];
    Nat256.Mul(Scalar25519.L, k, numArray);
    uint[] x2 = new uint[4];
    Array.Copy((Array) Scalar25519.L, (Array) x2, 4);
    uint[] x3 = new uint[4];
    uint[] y2 = new uint[4];
    Array.Copy((Array) k, (Array) y2, 4);
    uint[] y3 = new uint[4]{ 1U, 0U, 0U, 0U };
    int last = 15;
    int bitLengthPositive = ScalarUtilities.GetBitLengthPositive(15, y1);
    while (bitLengthPositive > 254)
    {
      int num = ScalarUtilities.GetBitLength(last, numArray) - bitLengthPositive;
      int s = num & ~(num >> 31 /*0x1F*/);
      if ((int) numArray[last] < 0)
      {
        ScalarUtilities.AddShifted_NP(last, s, x1, y1, numArray);
        ScalarUtilities.AddShifted_UV(3, s, x2, x3, y2, y3);
      }
      else
      {
        ScalarUtilities.SubShifted_NP(last, s, x1, y1, numArray);
        ScalarUtilities.SubShifted_UV(3, s, x2, x3, y2, y3);
      }
      if (ScalarUtilities.LessThan(last, x1, y1))
      {
        ScalarUtilities.Swap(ref x2, ref y2);
        ScalarUtilities.Swap(ref x3, ref y3);
        ScalarUtilities.Swap(ref x1, ref y1);
        last = bitLengthPositive >> 5;
        bitLengthPositive = ScalarUtilities.GetBitLengthPositive(last, y1);
      }
    }
    Array.Copy((Array) y2, (Array) z0, 4);
    Array.Copy((Array) y3, (Array) z1, 4);
  }

  internal static void ToSignedDigits(int bits, uint[] x, uint[] z)
  {
    int num1 = (int) Nat.CAdd(8, ~(int) x[0] & 1, x, Scalar25519.L, z);
    int num2 = (int) Nat.ShiftDownBit(8, z, 1U);
  }
}
