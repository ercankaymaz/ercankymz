// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Crystals.Kyber.Ntt
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Crystals.Kyber;

internal static class Ntt
{
  internal static readonly short[] Zetas = new short[128 /*0x80*/]
  {
    (short) 2285,
    (short) 2571,
    (short) 2970,
    (short) 1812,
    (short) 1493,
    (short) 1422,
    (short) 287,
    (short) 202,
    (short) 3158,
    (short) 622,
    (short) 1577,
    (short) 182,
    (short) 962,
    (short) 2127,
    (short) 1855,
    (short) 1468,
    (short) 573,
    (short) 2004,
    (short) 264,
    (short) 383,
    (short) 2500,
    (short) 1458,
    (short) 1727,
    (short) 3199,
    (short) 2648,
    (short) 1017,
    (short) 732,
    (short) 608,
    (short) 1787,
    (short) 411,
    (short) 3124,
    (short) 1758,
    (short) 1223,
    (short) 652,
    (short) 2777,
    (short) 1015,
    (short) 2036,
    (short) 1491,
    (short) 3047,
    (short) 1785,
    (short) 516,
    (short) 3321,
    (short) 3009,
    (short) 2663,
    (short) 1711,
    (short) 2167,
    (short) 126,
    (short) 1469,
    (short) 2476,
    (short) 3239,
    (short) 3058,
    (short) 830,
    (short) 107,
    (short) 1908,
    (short) 3082,
    (short) 2378,
    (short) 2931,
    (short) 961,
    (short) 1821,
    (short) 2604,
    (short) 448,
    (short) 2264,
    (short) 677,
    (short) 2054,
    (short) 2226,
    (short) 430,
    (short) 555,
    (short) 843,
    (short) 2078,
    (short) 871,
    (short) 1550,
    (short) 105,
    (short) 422,
    (short) 587,
    (short) 177,
    (short) 3094,
    (short) 3038,
    (short) 2869,
    (short) 1574,
    (short) 1653,
    (short) 3083,
    (short) 778,
    (short) 1159,
    (short) 3182,
    (short) 2552,
    (short) 1483,
    (short) 2727,
    (short) 1119,
    (short) 1739,
    (short) 644,
    (short) 2457,
    (short) 349,
    (short) 418,
    (short) 329,
    (short) 3173,
    (short) 3254,
    (short) 817,
    (short) 1097,
    (short) 603,
    (short) 610,
    (short) 1322,
    (short) 2044,
    (short) 1864,
    (short) 384,
    (short) 2114,
    (short) 3193,
    (short) 1218,
    (short) 1994,
    (short) 2455,
    (short) 220,
    (short) 2142,
    (short) 1670,
    (short) 2144,
    (short) 1799,
    (short) 2051,
    (short) 794,
    (short) 1819,
    (short) 2475,
    (short) 2459,
    (short) 478,
    (short) 3221,
    (short) 3021,
    (short) 996,
    (short) 991,
    (short) 958,
    (short) 1869,
    (short) 1522,
    (short) 1628
  };
  internal static readonly short[] ZetasInv = new short[128 /*0x80*/]
  {
    (short) 1701,
    (short) 1807,
    (short) 1460,
    (short) 2371,
    (short) 2338,
    (short) 2333,
    (short) 308,
    (short) 108,
    (short) 2851,
    (short) 870,
    (short) 854,
    (short) 1510,
    (short) 2535,
    (short) 1278,
    (short) 1530,
    (short) 1185,
    (short) 1659,
    (short) 1187,
    (short) 3109,
    (short) 874,
    (short) 1335,
    (short) 2111,
    (short) 136,
    (short) 1215,
    (short) 2945,
    (short) 1465,
    (short) 1285,
    (short) 2007,
    (short) 2719,
    (short) 2726,
    (short) 2232,
    (short) 2512,
    (short) 75,
    (short) 156,
    (short) 3000,
    (short) 2911,
    (short) 2980,
    (short) 872,
    (short) 2685,
    (short) 1590,
    (short) 2210,
    (short) 602,
    (short) 1846,
    (short) 777,
    (short) 147,
    (short) 2170,
    (short) 2551,
    (short) 246,
    (short) 1676,
    (short) 1755,
    (short) 460,
    (short) 291,
    (short) 235,
    (short) 3152,
    (short) 2742,
    (short) 2907,
    (short) 3224,
    (short) 1779,
    (short) 2458,
    (short) 1251,
    (short) 2486,
    (short) 2774,
    (short) 2899,
    (short) 1103,
    (short) 1275,
    (short) 2652,
    (short) 1065,
    (short) 2881,
    (short) 725,
    (short) 1508,
    (short) 2368,
    (short) 398,
    (short) 951,
    (short) 247,
    (short) 1421,
    (short) 3222,
    (short) 2499,
    (short) 271,
    (short) 90,
    (short) 853,
    (short) 1860,
    (short) 3203,
    (short) 1162,
    (short) 1618,
    (short) 666,
    (short) 320,
    (short) 8,
    (short) 2813,
    (short) 1544,
    (short) 282,
    (short) 1838,
    (short) 1293,
    (short) 2314,
    (short) 552,
    (short) 2677,
    (short) 2106,
    (short) 1571,
    (short) 205,
    (short) 2918,
    (short) 1542,
    (short) 2721,
    (short) 2597,
    (short) 2312,
    (short) 681,
    (short) 130,
    (short) 1602,
    (short) 1871,
    (short) 829,
    (short) 2946,
    (short) 3065,
    (short) 1325,
    (short) 2756,
    (short) 1861,
    (short) 1474,
    (short) 1202,
    (short) 2367,
    (short) 3147,
    (short) 1752,
    (short) 2707,
    (short) 171,
    (short) 3127,
    (short) 3042,
    (short) 1907,
    (short) 1836,
    (short) 1517,
    (short) 359,
    (short) 758,
    (short) 1441
  };

  private static short FactorQMulMont(short a, short b)
  {
    return Reduce.MontgomeryReduce((int) a * (int) b);
  }

  internal static void NTT(short[] r)
  {
    int num1 = 1;
    int index1;
    for (int index2 = 128 /*0x80*/; index2 >= 2; index2 >>= 1)
    {
      for (int index3 = 0; index3 < 256 /*0x0100*/; index3 = index1 + index2)
      {
        short zeta = Ntt.Zetas[num1++];
        for (index1 = index3; index1 < index3 + index2; ++index1)
        {
          short num2 = Ntt.FactorQMulMont(zeta, r[index1 + index2]);
          r[index1 + index2] = (short) ((int) r[index1] - (int) num2);
          r[index1] = (short) ((int) r[index1] + (int) num2);
        }
      }
    }
  }

  internal static void InvNTT(short[] r)
  {
    int num1 = 0;
    int index1;
    for (int index2 = 2; index2 <= 128 /*0x80*/; index2 <<= 1)
    {
      for (int index3 = 0; index3 < 256 /*0x0100*/; index3 = index1 + index2)
      {
        short a = Ntt.ZetasInv[num1++];
        for (index1 = index3; index1 < index3 + index2; ++index1)
        {
          short num2 = r[index1];
          r[index1] = Reduce.BarrettReduce((short) ((int) num2 + (int) r[index1 + index2]));
          r[index1 + index2] = (short) ((int) num2 - (int) r[index1 + index2]);
          r[index1 + index2] = Ntt.FactorQMulMont(a, r[index1 + index2]);
        }
      }
    }
    for (int index4 = 0; index4 < 256 /*0x0100*/; ++index4)
      r[index4] = Ntt.FactorQMulMont(r[index4], Ntt.ZetasInv[(int) sbyte.MaxValue]);
  }

  internal static void BaseMult(
    short[] r,
    int off,
    short a0,
    short a1,
    short b0,
    short b1,
    short zeta)
  {
    short num1 = (short) ((int) Ntt.FactorQMulMont(Ntt.FactorQMulMont(a1, b1), zeta) + (int) Ntt.FactorQMulMont(a0, b0));
    r[off] = num1;
    short num2 = (short) ((int) Ntt.FactorQMulMont(a0, b1) + (int) Ntt.FactorQMulMont(a1, b0));
    r[off + 1] = num2;
  }
}
