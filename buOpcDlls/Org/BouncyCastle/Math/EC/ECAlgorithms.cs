// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.ECAlgorithms
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.EC.Endo;
using Org.BouncyCastle.Math.EC.Multiplier;
using Org.BouncyCastle.Math.Field;
using Org.BouncyCastle.Math.Raw;
using System;

#nullable disable
namespace Org.BouncyCastle.Math.EC;

public class ECAlgorithms
{
  public static bool IsF2mCurve(ECCurve c) => ECAlgorithms.IsF2mField(c.Field);

  public static bool IsF2mField(IFiniteField field)
  {
    return field.Dimension > 1 && field.Characteristic.Equals(BigInteger.Two) && field is IPolynomialExtensionField;
  }

  public static bool IsFpCurve(ECCurve c) => ECAlgorithms.IsFpField(c.Field);

  public static bool IsFpField(IFiniteField field) => field.Dimension == 1;

  public static ECPoint SumOfMultiplies(ECPoint[] ps, BigInteger[] ks)
  {
    if (ps == null || ks == null || ps.Length != ks.Length || ps.Length < 1)
      throw new ArgumentException("point and scalar arrays should be non-null, and of equal, non-zero, length");
    int length = ps.Length;
    switch (length)
    {
      case 1:
        return ps[0].Multiply(ks[0]);
      case 2:
        return ECAlgorithms.SumOfTwoMultiplies(ps[0], ks[0], ps[1], ks[1]);
      default:
        ECPoint p = ps[0];
        ECCurve curve = p.Curve;
        ECPoint[] ps1 = new ECPoint[length];
        ps1[0] = p;
        for (int index = 1; index < length; ++index)
          ps1[index] = ECAlgorithms.ImportPoint(curve, ps[index]);
        return curve.GetEndomorphism() is GlvEndomorphism endomorphism ? ECAlgorithms.ImplCheckResult(ECAlgorithms.ImplSumOfMultipliesGlv(ps1, ks, endomorphism)) : ECAlgorithms.ImplCheckResult(ECAlgorithms.ImplSumOfMultiplies(ps1, ks));
    }
  }

  public static ECPoint SumOfTwoMultiplies(ECPoint P, BigInteger a, ECPoint Q, BigInteger b)
  {
    ECCurve curve = P.Curve;
    Q = ECAlgorithms.ImportPoint(curve, Q);
    if (curve is AbstractF2mCurve abstractF2mCurve && abstractF2mCurve.IsKoblitz)
      return ECAlgorithms.ImplCheckResult(P.Multiply(a).Add(Q.Multiply(b)));
    if (!(curve.GetEndomorphism() is GlvEndomorphism endomorphism))
      return ECAlgorithms.ImplCheckResult(ECAlgorithms.ImplShamirsTrickWNaf(P, a, Q, b));
    return ECAlgorithms.ImplCheckResult(ECAlgorithms.ImplSumOfMultipliesGlv(new ECPoint[2]
    {
      P,
      Q
    }, new BigInteger[2]{ a, b }, endomorphism));
  }

  public static ECPoint ShamirsTrick(ECPoint P, BigInteger k, ECPoint Q, BigInteger l)
  {
    Q = ECAlgorithms.ImportPoint(P.Curve, Q);
    return ECAlgorithms.ImplCheckResult(ECAlgorithms.ImplShamirsTrickJsf(P, k, Q, l));
  }

  public static ECPoint ImportPoint(ECCurve c, ECPoint p)
  {
    ECCurve curve = p.Curve;
    return c.Equals(curve) ? c.ImportPoint(p) : throw new ArgumentException("Point must be on the same curve");
  }

  public static void MontgomeryTrick(ECFieldElement[] zs, int off, int len)
  {
    ECAlgorithms.MontgomeryTrick(zs, off, len, (ECFieldElement) null);
  }

  public static void MontgomeryTrick(ECFieldElement[] zs, int off, int len, ECFieldElement scale)
  {
    ECFieldElement[] ecFieldElementArray = new ECFieldElement[len];
    ecFieldElementArray[0] = zs[off];
    int index1 = 0;
    while (++index1 < len)
      ecFieldElementArray[index1] = ecFieldElementArray[index1 - 1].Multiply(zs[off + index1]);
    int index2 = index1 - 1;
    if (scale != null)
      ecFieldElementArray[index2] = ecFieldElementArray[index2].Multiply(scale);
    ECFieldElement b = ecFieldElementArray[index2].Invert();
    while (index2 > 0)
    {
      int index3 = off + index2--;
      ECFieldElement z = zs[index3];
      zs[index3] = ecFieldElementArray[index2].Multiply(b);
      b = b.Multiply(z);
    }
    zs[off] = b;
  }

  public static ECPoint ReferenceMultiply(ECPoint p, BigInteger k)
  {
    BigInteger bigInteger = k.Abs();
    ECPoint ecPoint = p.Curve.Infinity;
    int bitLength = bigInteger.BitLength;
    if (bitLength > 0)
    {
      if (bigInteger.TestBit(0))
        ecPoint = p;
      for (int n = 1; n < bitLength; ++n)
      {
        p = p.Twice();
        if (bigInteger.TestBit(n))
          ecPoint = ecPoint.Add(p);
      }
    }
    return k.SignValue >= 0 ? ecPoint : ecPoint.Negate();
  }

  public static ECPoint ValidatePoint(ECPoint p)
  {
    return p.IsValid() ? p : throw new InvalidOperationException("Invalid point");
  }

  public static ECPoint CleanPoint(ECCurve c, ECPoint p)
  {
    ECCurve curve = p.Curve;
    return c.Equals(curve) ? c.DecodePoint(p.GetEncoded(false)) : throw new ArgumentException("Point must be on the same curve", nameof (p));
  }

  internal static ECPoint ImplCheckResult(ECPoint p)
  {
    return p.IsValidPartial() ? p : throw new InvalidOperationException("Invalid result");
  }

  internal static ECPoint ImplShamirsTrickJsf(ECPoint P, BigInteger k, ECPoint Q, BigInteger l)
  {
    ECCurve curve = P.Curve;
    ECPoint infinity = curve.Infinity;
    ECPoint ecPoint1 = P.Add(Q);
    ECPoint ecPoint2 = P.Subtract(Q);
    ECPoint[] points = new ECPoint[4]
    {
      Q,
      ecPoint2,
      P,
      ecPoint1
    };
    curve.NormalizeAll(points);
    ECPoint[] ecPointArray = new ECPoint[9]
    {
      points[3].Negate(),
      points[2].Negate(),
      points[1].Negate(),
      points[0].Negate(),
      infinity,
      points[0],
      points[1],
      points[2],
      points[3]
    };
    byte[] jsf = WNafUtilities.GenerateJsf(k, l);
    ECPoint ecPoint3 = infinity;
    int length = jsf.Length;
    while (--length >= 0)
    {
      int num = (int) jsf[length];
      int index = 4 + (num << 24 >> 28) * 3 + (num << 28 >> 28);
      ecPoint3 = ecPoint3.TwicePlus(ecPointArray[index]);
    }
    return ecPoint3;
  }

  internal static ECPoint ImplShamirsTrickWNaf(ECPoint P, BigInteger k, ECPoint Q, BigInteger l)
  {
    bool flag1 = k.SignValue < 0;
    bool flag2 = l.SignValue < 0;
    BigInteger k1 = k.Abs();
    BigInteger bigInteger = l.Abs();
    int windowSize1 = WNafUtilities.GetWindowSize(k1.BitLength, 8);
    int windowSize2 = WNafUtilities.GetWindowSize(bigInteger.BitLength, 8);
    WNafPreCompInfo wnafPreCompInfo1 = WNafUtilities.Precompute(P, windowSize1, true);
    WNafPreCompInfo wnafPreCompInfo2 = WNafUtilities.Precompute(Q, windowSize2, true);
    int combSize = FixedPointUtilities.GetCombSize(P.Curve);
    if (!flag1 && !flag2 && k.BitLength <= combSize && l.BitLength <= combSize && wnafPreCompInfo1.IsPromoted && wnafPreCompInfo2.IsPromoted)
      return ECAlgorithms.ImplShamirsTrickFixedPoint(P, k, Q, l);
    int width1 = System.Math.Min(8, wnafPreCompInfo1.Width);
    int width2 = System.Math.Min(8, wnafPreCompInfo2.Width);
    ECPoint[] preCompP = flag1 ? wnafPreCompInfo1.PreCompNeg : wnafPreCompInfo1.PreComp;
    ECPoint[] preCompQ = flag2 ? wnafPreCompInfo2.PreCompNeg : wnafPreCompInfo2.PreComp;
    ECPoint[] preCompNegP = flag1 ? wnafPreCompInfo1.PreComp : wnafPreCompInfo1.PreCompNeg;
    ECPoint[] preCompNegQ = flag2 ? wnafPreCompInfo2.PreComp : wnafPreCompInfo2.PreCompNeg;
    byte[] windowNaf1 = WNafUtilities.GenerateWindowNaf(width1, k1);
    BigInteger k2 = bigInteger;
    byte[] windowNaf2 = WNafUtilities.GenerateWindowNaf(width2, k2);
    return ECAlgorithms.ImplShamirsTrickWNaf(preCompP, preCompNegP, windowNaf1, preCompQ, preCompNegQ, windowNaf2);
  }

  internal static ECPoint ImplShamirsTrickWNaf(
    ECEndomorphism endomorphism,
    ECPoint P,
    BigInteger k,
    BigInteger l)
  {
    bool flag1 = k.SignValue < 0;
    bool flag2 = l.SignValue < 0;
    k = k.Abs();
    l = l.Abs();
    int windowSize = WNafUtilities.GetWindowSize(System.Math.Max(k.BitLength, l.BitLength), 8);
    WNafPreCompInfo fromWNaf = WNafUtilities.Precompute(P, windowSize, true);
    WNafPreCompInfo wnafPreCompInfo = WNafUtilities.PrecomputeWithPointMap(EndoUtilities.MapPoint(endomorphism, P), endomorphism.PointMap, fromWNaf, true);
    int width1 = System.Math.Min(8, fromWNaf.Width);
    int width2 = System.Math.Min(8, wnafPreCompInfo.Width);
    ECPoint[] preCompP = flag1 ? fromWNaf.PreCompNeg : fromWNaf.PreComp;
    ECPoint[] preCompQ = flag2 ? wnafPreCompInfo.PreCompNeg : wnafPreCompInfo.PreComp;
    ECPoint[] preCompNegP = flag1 ? fromWNaf.PreComp : fromWNaf.PreCompNeg;
    ECPoint[] preCompNegQ = flag2 ? wnafPreCompInfo.PreComp : wnafPreCompInfo.PreCompNeg;
    byte[] windowNaf1 = WNafUtilities.GenerateWindowNaf(width1, k);
    BigInteger k1 = l;
    byte[] windowNaf2 = WNafUtilities.GenerateWindowNaf(width2, k1);
    return ECAlgorithms.ImplShamirsTrickWNaf(preCompP, preCompNegP, windowNaf1, preCompQ, preCompNegQ, windowNaf2);
  }

  private static ECPoint ImplShamirsTrickWNaf(
    ECPoint[] preCompP,
    ECPoint[] preCompNegP,
    byte[] wnafP,
    ECPoint[] preCompQ,
    ECPoint[] preCompNegQ,
    byte[] wnafQ)
  {
    int num1 = System.Math.Max(wnafP.Length, wnafQ.Length);
    ECPoint infinity = preCompP[0].Curve.Infinity;
    ECPoint ecPoint = infinity;
    int e = 0;
    for (int index = num1 - 1; index >= 0; --index)
    {
      int num2 = index < wnafP.Length ? (int) (sbyte) wnafP[index] : 0;
      int num3 = index < wnafQ.Length ? (int) (sbyte) wnafQ[index] : 0;
      if ((num2 | num3) == 0)
      {
        ++e;
      }
      else
      {
        ECPoint b = infinity;
        if (num2 != 0)
        {
          int num4 = System.Math.Abs(num2);
          ECPoint[] ecPointArray = num2 < 0 ? preCompNegP : preCompP;
          b = b.Add(ecPointArray[num4 >> 1]);
        }
        if (num3 != 0)
        {
          int num5 = System.Math.Abs(num3);
          ECPoint[] ecPointArray = num3 < 0 ? preCompNegQ : preCompQ;
          b = b.Add(ecPointArray[num5 >> 1]);
        }
        if (e > 0)
        {
          ecPoint = ecPoint.TimesPow2(e);
          e = 0;
        }
        ecPoint = ecPoint.TwicePlus(b);
      }
    }
    if (e > 0)
      ecPoint = ecPoint.TimesPow2(e);
    return ecPoint;
  }

  internal static ECPoint ImplSumOfMultiplies(ECPoint[] ps, BigInteger[] ks)
  {
    int length = ps.Length;
    bool[] negs = new bool[length];
    WNafPreCompInfo[] infos = new WNafPreCompInfo[length];
    byte[][] wnafs = new byte[length][];
    for (int index = 0; index < length; ++index)
    {
      BigInteger k1 = ks[index];
      negs[index] = k1.SignValue < 0;
      BigInteger k2 = k1.Abs();
      int windowSize = WNafUtilities.GetWindowSize(k2.BitLength, 8);
      WNafPreCompInfo wnafPreCompInfo = WNafUtilities.Precompute(ps[index], windowSize, true);
      int width = System.Math.Min(8, wnafPreCompInfo.Width);
      infos[index] = wnafPreCompInfo;
      wnafs[index] = WNafUtilities.GenerateWindowNaf(width, k2);
    }
    return ECAlgorithms.ImplSumOfMultiplies(negs, infos, wnafs);
  }

  internal static ECPoint ImplSumOfMultipliesGlv(
    ECPoint[] ps,
    BigInteger[] ks,
    GlvEndomorphism glvEndomorphism)
  {
    BigInteger order = ps[0].Curve.Order;
    int length = ps.Length;
    BigInteger[] ks1 = new BigInteger[length << 1];
    int index1 = 0;
    int num1 = 0;
    for (; index1 < length; ++index1)
    {
      BigInteger[] bigIntegerArray1 = glvEndomorphism.DecomposeScalar(ks[index1].Mod(order));
      BigInteger[] bigIntegerArray2 = ks1;
      int index2 = num1;
      int num2 = index2 + 1;
      BigInteger bigInteger1 = bigIntegerArray1[0];
      bigIntegerArray2[index2] = bigInteger1;
      BigInteger[] bigIntegerArray3 = ks1;
      int index3 = num2;
      num1 = index3 + 1;
      BigInteger bigInteger2 = bigIntegerArray1[1];
      bigIntegerArray3[index3] = bigInteger2;
    }
    if (glvEndomorphism.HasEfficientPointMap)
      return ECAlgorithms.ImplSumOfMultiplies((ECEndomorphism) glvEndomorphism, ps, ks1);
    ECPoint[] ps1 = new ECPoint[length << 1];
    int index4 = 0;
    int num3 = 0;
    for (; index4 < length; ++index4)
    {
      ECPoint p = ps[index4];
      ECPoint ecPoint1 = EndoUtilities.MapPoint((ECEndomorphism) glvEndomorphism, p);
      ECPoint[] ecPointArray1 = ps1;
      int index5 = num3;
      int num4 = index5 + 1;
      ECPoint ecPoint2 = p;
      ecPointArray1[index5] = ecPoint2;
      ECPoint[] ecPointArray2 = ps1;
      int index6 = num4;
      num3 = index6 + 1;
      ECPoint ecPoint3 = ecPoint1;
      ecPointArray2[index6] = ecPoint3;
    }
    return ECAlgorithms.ImplSumOfMultiplies(ps1, ks1);
  }

  internal static ECPoint ImplSumOfMultiplies(
    ECEndomorphism endomorphism,
    ECPoint[] ps,
    BigInteger[] ks)
  {
    int length1 = ps.Length;
    int length2 = length1 << 1;
    bool[] negs = new bool[length2];
    WNafPreCompInfo[] infos = new WNafPreCompInfo[length2];
    byte[][] wnafs = new byte[length2][];
    ECPointMap pointMap = endomorphism.PointMap;
    for (int index1 = 0; index1 < length1; ++index1)
    {
      int index2 = index1 << 1;
      int index3 = index2 + 1;
      BigInteger k1 = ks[index2];
      negs[index2] = k1.SignValue < 0;
      BigInteger k2 = k1.Abs();
      BigInteger k3 = ks[index3];
      negs[index3] = k3.SignValue < 0;
      BigInteger k4 = k3.Abs();
      int windowSize = WNafUtilities.GetWindowSize(System.Math.Max(k2.BitLength, k4.BitLength), 8);
      ECPoint p = ps[index1];
      WNafPreCompInfo fromWNaf = WNafUtilities.Precompute(p, windowSize, true);
      WNafPreCompInfo wnafPreCompInfo = WNafUtilities.PrecomputeWithPointMap(EndoUtilities.MapPoint(endomorphism, p), pointMap, fromWNaf, true);
      int width1 = System.Math.Min(8, fromWNaf.Width);
      int width2 = System.Math.Min(8, wnafPreCompInfo.Width);
      infos[index2] = fromWNaf;
      infos[index3] = wnafPreCompInfo;
      wnafs[index2] = WNafUtilities.GenerateWindowNaf(width1, k2);
      wnafs[index3] = WNafUtilities.GenerateWindowNaf(width2, k4);
    }
    return ECAlgorithms.ImplSumOfMultiplies(negs, infos, wnafs);
  }

  private static ECPoint ImplSumOfMultiplies(bool[] negs, WNafPreCompInfo[] infos, byte[][] wnafs)
  {
    int val1 = 0;
    int length = wnafs.Length;
    for (int index = 0; index < length; ++index)
      val1 = System.Math.Max(val1, wnafs[index].Length);
    ECPoint infinity = infos[0].PreComp[0].Curve.Infinity;
    ECPoint ecPoint = infinity;
    int e = 0;
    for (int index1 = val1 - 1; index1 >= 0; --index1)
    {
      ECPoint b = infinity;
      for (int index2 = 0; index2 < length; ++index2)
      {
        byte[] wnaf = wnafs[index2];
        int num1 = index1 < wnaf.Length ? (int) (sbyte) wnaf[index1] : 0;
        if (num1 != 0)
        {
          int num2 = System.Math.Abs(num1);
          WNafPreCompInfo info = infos[index2];
          ECPoint[] ecPointArray = num1 < 0 == negs[index2] ? info.PreComp : info.PreCompNeg;
          b = b.Add(ecPointArray[num2 >> 1]);
        }
      }
      if (b == infinity)
      {
        ++e;
      }
      else
      {
        if (e > 0)
        {
          ecPoint = ecPoint.TimesPow2(e);
          e = 0;
        }
        ecPoint = ecPoint.TwicePlus(b);
      }
    }
    if (e > 0)
      ecPoint = ecPoint.TimesPow2(e);
    return ecPoint;
  }

  private static ECPoint ImplShamirsTrickFixedPoint(
    ECPoint p,
    BigInteger k,
    ECPoint q,
    BigInteger l)
  {
    ECCurve curve = p.Curve;
    int combSize = FixedPointUtilities.GetCombSize(curve);
    if (k.BitLength > combSize || l.BitLength > combSize)
      throw new InvalidOperationException("fixed-point comb doesn't support scalars larger than the curve order");
    FixedPointPreCompInfo pointPreCompInfo1 = FixedPointUtilities.Precompute(p);
    FixedPointPreCompInfo pointPreCompInfo2 = FixedPointUtilities.Precompute(q);
    ECLookupTable lookupTable1 = pointPreCompInfo1.LookupTable;
    ECLookupTable lookupTable2 = pointPreCompInfo2.LookupTable;
    int width1 = pointPreCompInfo1.Width;
    int width2 = pointPreCompInfo2.Width;
    if (width1 != width2)
    {
      FixedPointCombMultiplier pointCombMultiplier = new FixedPointCombMultiplier();
      return pointCombMultiplier.Multiply(p, k).Add(pointCombMultiplier.Multiply(q, l));
    }
    int num1 = width1;
    int num2 = (combSize + num1 - 1) / num1;
    int bits = num2 * num1;
    uint[] numArray1 = Nat.FromBigInteger(bits, k);
    uint[] numArray2 = Nat.FromBigInteger(bits, l);
    ECPoint ecPoint = curve.Infinity;
    for (int index1 = 1; index1 <= num2; ++index1)
    {
      uint index2 = 0;
      uint index3 = 0;
      for (int index4 = bits - index1; index4 >= 0; index4 -= num2)
      {
        uint num3 = numArray1[index4 >> 5] >> index4;
        index2 = (index2 ^ num3 >> 1) << 1 ^ num3;
        uint num4 = numArray2[index4 >> 5] >> index4;
        index3 = (index3 ^ num4 >> 1) << 1 ^ num4;
      }
      ECPoint b = lookupTable1.LookupVar((int) index2).Add(lookupTable2.LookupVar((int) index3));
      ecPoint = ecPoint.TwicePlus(b);
    }
    return ecPoint.Add(pointPreCompInfo1.Offset).Add(pointPreCompInfo2.Offset);
  }
}
