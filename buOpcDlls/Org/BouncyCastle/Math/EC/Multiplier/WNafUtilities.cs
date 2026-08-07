// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Multiplier.WNafUtilities
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Math.EC.Multiplier;

public abstract class WNafUtilities
{
  public static readonly string PRECOMP_NAME = "bc_wnaf";
  private static readonly int[] DEFAULT_WINDOW_SIZE_CUTOFFS = new int[6]
  {
    13,
    41,
    121,
    337,
    897,
    2305
  };
  private static readonly int MAX_WIDTH = 16 /*0x10*/;
  private static readonly ECPoint[] EMPTY_POINTS = new ECPoint[0];

  public static void ConfigureBasepoint(ECPoint p)
  {
    ECCurve curve = p.Curve;
    if (curve == null)
      return;
    BigInteger order = curve.Order;
    int bits = order == null ? curve.FieldSize + 1 : order.BitLength;
    int confWidth = System.Math.Min(WNafUtilities.MAX_WIDTH, WNafUtilities.GetWindowSize(bits) + 3);
    curve.Precompute(p, WNafUtilities.PRECOMP_NAME, (IPreCompCallback) new WNafUtilities.ConfigureBasepointCallback(curve, confWidth));
  }

  public static int[] GenerateCompactNaf(BigInteger k)
  {
    if (k.BitLength >> 16 /*0x10*/ != 0)
      throw new ArgumentException("must have bitlength < 2^16", nameof (k));
    if (k.SignValue == 0)
      return Arrays.EmptyInts;
    BigInteger bigInteger1 = k.ShiftLeft(1).Add(k);
    int bitLength = bigInteger1.BitLength;
    int[] a = new int[bitLength >> 1];
    BigInteger bigInteger2 = bigInteger1.Xor(k);
    int num1 = bitLength - 1;
    int num2 = 0;
    int num3 = 0;
    for (int n = 1; n < num1; ++n)
    {
      if (!bigInteger2.TestBit(n))
      {
        ++num3;
      }
      else
      {
        int num4 = k.TestBit(n) ? -1 : 1;
        a[num2++] = num4 << 16 /*0x10*/ | num3;
        num3 = 1;
        ++n;
      }
    }
    int[] numArray = a;
    int index = num2;
    int length = index + 1;
    int num5 = 65536 /*0x010000*/ | num3;
    numArray[index] = num5;
    if (a.Length > length)
      a = WNafUtilities.Trim(a, length);
    return a;
  }

  public static int[] GenerateCompactWindowNaf(int width, BigInteger k)
  {
    if (width == 2)
      return WNafUtilities.GenerateCompactNaf(k);
    if (width < 2 || width > 16 /*0x10*/)
      throw new ArgumentException("must be in the range [2, 16]", nameof (width));
    if (k.BitLength >> 16 /*0x10*/ != 0)
      throw new ArgumentException("must have bitlength < 2^16", nameof (k));
    if (k.SignValue == 0)
      return Arrays.EmptyInts;
    int[] a = new int[k.BitLength / width + 1];
    int num1 = 1 << width;
    int num2 = num1 - 1;
    int num3 = num1 >> 1;
    bool flag = false;
    int length = 0;
    int n = 0;
    while (n <= k.BitLength)
    {
      if (k.TestBit(n) == flag)
      {
        ++n;
      }
      else
      {
        k = k.ShiftRight(n);
        int num4 = k.IntValue & num2;
        if (flag)
          ++num4;
        if (flag = (num4 & num3) != 0)
          num4 -= num1;
        int num5 = length > 0 ? n - 1 : n;
        a[length++] = num4 << 16 /*0x10*/ | num5;
        n = width;
      }
    }
    if (a.Length > length)
      a = WNafUtilities.Trim(a, length);
    return a;
  }

  public static byte[] GenerateJsf(BigInteger g, BigInteger h)
  {
    byte[] a = new byte[System.Math.Max(g.BitLength, h.BitLength) + 1];
    BigInteger bigInteger1 = g;
    BigInteger bigInteger2 = h;
    int length = 0;
    int num1 = 0;
    int num2 = 0;
    int num3 = 0;
    while ((num1 | num2) != 0 || bigInteger1.BitLength > num3 || bigInteger2.BitLength > num3)
    {
      int num4 = (bigInteger1.IntValue >>> num3) + num1 & 7;
      int num5 = (bigInteger2.IntValue >>> num3) + num2 & 7;
      int num6 = num4 & 1;
      if (num6 != 0)
      {
        num6 -= num4 & 2;
        if (num4 + num6 == 4 && (num5 & 3) == 2)
          num6 = -num6;
      }
      int num7 = num5 & 1;
      if (num7 != 0)
      {
        num7 -= num5 & 2;
        if (num5 + num7 == 4 && (num4 & 3) == 2)
          num7 = -num7;
      }
      if (num1 << 1 == 1 + num6)
        num1 ^= 1;
      if (num2 << 1 == 1 + num7)
        num2 ^= 1;
      if (++num3 == 30)
      {
        num3 = 0;
        bigInteger1 = bigInteger1.ShiftRight(30);
        bigInteger2 = bigInteger2.ShiftRight(30);
      }
      a[length++] = (byte) (num6 << 4 | num7 & 15);
    }
    if (a.Length > length)
      a = WNafUtilities.Trim(a, length);
    return a;
  }

  public static byte[] GenerateNaf(BigInteger k)
  {
    if (k.SignValue == 0)
      return Arrays.EmptyBytes;
    BigInteger bigInteger1 = k.ShiftLeft(1).Add(k);
    int length = bigInteger1.BitLength - 1;
    byte[] naf = new byte[length];
    BigInteger bigInteger2 = bigInteger1.Xor(k);
    for (int n = 1; n < length; ++n)
    {
      if (bigInteger2.TestBit(n))
      {
        naf[n - 1] = k.TestBit(n) ? byte.MaxValue : (byte) 1;
        ++n;
      }
    }
    naf[length - 1] = (byte) 1;
    return naf;
  }

  public static byte[] GenerateWindowNaf(int width, BigInteger k)
  {
    if (width == 2)
      return WNafUtilities.GenerateNaf(k);
    if (width < 2 || width > 8)
      throw new ArgumentException("must be in the range [2, 8]", nameof (width));
    if (k.SignValue == 0)
      return Arrays.EmptyBytes;
    byte[] a = new byte[k.BitLength + 1];
    int num1 = 1 << width;
    int num2 = num1 - 1;
    int num3 = num1 >> 1;
    bool flag = false;
    int length = 0;
    int n = 0;
    while (n <= k.BitLength)
    {
      if (k.TestBit(n) == flag)
      {
        ++n;
      }
      else
      {
        k = k.ShiftRight(n);
        int num4 = k.IntValue & num2;
        if (flag)
          ++num4;
        if (flag = (num4 & num3) != 0)
          num4 -= num1;
        int num5 = length + (length > 0 ? n - 1 : n);
        byte[] numArray = a;
        int index = num5;
        length = index + 1;
        int num6 = (int) (byte) num4;
        numArray[index] = (byte) num6;
        n = width;
      }
    }
    if (a.Length > length)
      a = WNafUtilities.Trim(a, length);
    return a;
  }

  public static int GetNafWeight(BigInteger k)
  {
    return k.SignValue == 0 ? 0 : k.ShiftLeft(1).Add(k).Xor(k).BitCount;
  }

  public static WNafPreCompInfo GetWNafPreCompInfo(ECPoint p)
  {
    return WNafUtilities.GetWNafPreCompInfo(p.Curve.GetPreCompInfo(p, WNafUtilities.PRECOMP_NAME));
  }

  public static WNafPreCompInfo GetWNafPreCompInfo(PreCompInfo preCompInfo)
  {
    return preCompInfo as WNafPreCompInfo;
  }

  public static int GetWindowSize(int bits)
  {
    return WNafUtilities.GetWindowSize(bits, WNafUtilities.DEFAULT_WINDOW_SIZE_CUTOFFS, WNafUtilities.MAX_WIDTH);
  }

  public static int GetWindowSize(int bits, int maxWidth)
  {
    return WNafUtilities.GetWindowSize(bits, WNafUtilities.DEFAULT_WINDOW_SIZE_CUTOFFS, maxWidth);
  }

  public static int GetWindowSize(int bits, int[] windowSizeCutoffs)
  {
    return WNafUtilities.GetWindowSize(bits, windowSizeCutoffs, WNafUtilities.MAX_WIDTH);
  }

  public static int GetWindowSize(int bits, int[] windowSizeCutoffs, int maxWidth)
  {
    int index = 0;
    while (index < windowSizeCutoffs.Length && bits >= windowSizeCutoffs[index])
      ++index;
    return System.Math.Max(2, System.Math.Min(maxWidth, index + 2));
  }

  public static WNafPreCompInfo Precompute(ECPoint p, int minWidth, bool includeNegated)
  {
    return (WNafPreCompInfo) p.Curve.Precompute(p, WNafUtilities.PRECOMP_NAME, (IPreCompCallback) new WNafUtilities.PrecomputeCallback(p, minWidth, includeNegated));
  }

  public static WNafPreCompInfo PrecomputeWithPointMap(
    ECPoint p,
    ECPointMap pointMap,
    WNafPreCompInfo fromWNaf,
    bool includeNegated)
  {
    return (WNafPreCompInfo) p.Curve.Precompute(p, WNafUtilities.PRECOMP_NAME, (IPreCompCallback) new WNafUtilities.PrecomputeWithPointMapCallback(p, pointMap, fromWNaf, includeNegated));
  }

  private static byte[] Trim(byte[] a, int length)
  {
    byte[] destinationArray = new byte[length];
    Array.Copy((Array) a, 0, (Array) destinationArray, 0, destinationArray.Length);
    return destinationArray;
  }

  private static int[] Trim(int[] a, int length)
  {
    int[] destinationArray = new int[length];
    Array.Copy((Array) a, 0, (Array) destinationArray, 0, destinationArray.Length);
    return destinationArray;
  }

  private static ECPoint[] ResizeTable(ECPoint[] a, int length)
  {
    ECPoint[] destinationArray = new ECPoint[length];
    Array.Copy((Array) a, 0, (Array) destinationArray, 0, a.Length);
    return destinationArray;
  }

  private class ConfigureBasepointCallback : IPreCompCallback
  {
    private readonly ECCurve m_curve;
    private readonly int m_confWidth;

    internal ConfigureBasepointCallback(ECCurve curve, int confWidth)
    {
      this.m_curve = curve;
      this.m_confWidth = confWidth;
    }

    public PreCompInfo Precompute(PreCompInfo existing)
    {
      if (existing is WNafPreCompInfo wnafPreCompInfo1 && wnafPreCompInfo1.ConfWidth == this.m_confWidth)
      {
        wnafPreCompInfo1.PromotionCountdown = 0;
        return (PreCompInfo) wnafPreCompInfo1;
      }
      WNafPreCompInfo wnafPreCompInfo2 = new WNafPreCompInfo();
      wnafPreCompInfo2.PromotionCountdown = 0;
      wnafPreCompInfo2.ConfWidth = this.m_confWidth;
      if (wnafPreCompInfo1 != null)
      {
        wnafPreCompInfo2.PreComp = wnafPreCompInfo1.PreComp;
        wnafPreCompInfo2.PreCompNeg = wnafPreCompInfo1.PreCompNeg;
        wnafPreCompInfo2.Twice = wnafPreCompInfo1.Twice;
        wnafPreCompInfo2.Width = wnafPreCompInfo1.Width;
      }
      return (PreCompInfo) wnafPreCompInfo2;
    }
  }

  private class MapPointCallback : IPreCompCallback
  {
    private readonly WNafPreCompInfo m_infoP;
    private readonly bool m_includeNegated;
    private readonly ECPointMap m_pointMap;

    internal MapPointCallback(WNafPreCompInfo infoP, bool includeNegated, ECPointMap pointMap)
    {
      this.m_infoP = infoP;
      this.m_includeNegated = includeNegated;
      this.m_pointMap = pointMap;
    }

    public PreCompInfo Precompute(PreCompInfo existing)
    {
      WNafPreCompInfo wnafPreCompInfo = new WNafPreCompInfo();
      wnafPreCompInfo.ConfWidth = this.m_infoP.ConfWidth;
      ECPoint twice = this.m_infoP.Twice;
      if (twice != null)
      {
        ECPoint ecPoint = this.m_pointMap.Map(twice);
        wnafPreCompInfo.Twice = ecPoint;
      }
      ECPoint[] preComp = this.m_infoP.PreComp;
      ECPoint[] ecPointArray1 = new ECPoint[preComp.Length];
      for (int index = 0; index < preComp.Length; ++index)
        ecPointArray1[index] = this.m_pointMap.Map(preComp[index]);
      wnafPreCompInfo.PreComp = ecPointArray1;
      wnafPreCompInfo.Width = this.m_infoP.Width;
      if (this.m_includeNegated)
      {
        ECPoint[] ecPointArray2 = new ECPoint[ecPointArray1.Length];
        for (int index = 0; index < ecPointArray2.Length; ++index)
          ecPointArray2[index] = ecPointArray1[index].Negate();
        wnafPreCompInfo.PreCompNeg = ecPointArray2;
      }
      return (PreCompInfo) wnafPreCompInfo;
    }
  }

  private class PrecomputeCallback : IPreCompCallback
  {
    private readonly ECPoint m_p;
    private readonly int m_minWidth;
    private readonly bool m_includeNegated;

    internal PrecomputeCallback(ECPoint p, int minWidth, bool includeNegated)
    {
      this.m_p = p;
      this.m_minWidth = minWidth;
      this.m_includeNegated = includeNegated;
    }

    public PreCompInfo Precompute(PreCompInfo existing)
    {
      WNafPreCompInfo existingWNaf = existing as WNafPreCompInfo;
      int num1 = System.Math.Max(2, System.Math.Min(WNafUtilities.MAX_WIDTH, this.m_minWidth));
      int reqPreCompLen = 1 << num1 - 2;
      if (this.CheckExisting(existingWNaf, num1, reqPreCompLen, this.m_includeNegated))
      {
        existingWNaf.DecrementPromotionCountdown();
        return (PreCompInfo) existingWNaf;
      }
      WNafPreCompInfo wnafPreCompInfo = new WNafPreCompInfo();
      ECCurve curve = this.m_p.Curve;
      ECPoint[] ecPointArray = (ECPoint[]) null;
      ECPoint[] a = (ECPoint[]) null;
      ECPoint ecPoint1 = (ECPoint) null;
      if (existingWNaf != null)
      {
        int num2 = existingWNaf.DecrementPromotionCountdown();
        wnafPreCompInfo.PromotionCountdown = num2;
        int confWidth = existingWNaf.ConfWidth;
        wnafPreCompInfo.ConfWidth = confWidth;
        ecPointArray = existingWNaf.PreComp;
        a = existingWNaf.PreCompNeg;
        ecPoint1 = existingWNaf.Twice;
      }
      int num3 = System.Math.Min(WNafUtilities.MAX_WIDTH, System.Math.Max(wnafPreCompInfo.ConfWidth, num1));
      int length = 1 << num3 - 2;
      int off = 0;
      if (ecPointArray == null)
        ecPointArray = WNafUtilities.EMPTY_POINTS;
      else
        off = ecPointArray.Length;
      if (off < length)
      {
        ecPointArray = WNafUtilities.ResizeTable(ecPointArray, length);
        if (length == 1)
        {
          ecPointArray[0] = this.m_p.Normalize();
        }
        else
        {
          int num4 = off;
          if (num4 == 0)
          {
            ecPointArray[0] = this.m_p;
            num4 = 1;
          }
          ECFieldElement ecFieldElement = (ECFieldElement) null;
          if (length == 2)
          {
            ecPointArray[1] = this.m_p.ThreeTimes();
          }
          else
          {
            ECPoint b = ecPoint1;
            ECPoint ecPoint2 = ecPointArray[num4 - 1];
            if (b == null)
            {
              b = ecPointArray[0].Twice();
              ecPoint1 = b;
              if (!ecPoint1.IsInfinity && ECAlgorithms.IsFpCurve(curve) && curve.FieldSize >= 64 /*0x40*/)
              {
                switch (curve.CoordinateSystem)
                {
                  case 2:
                  case 3:
                  case 4:
                    ecFieldElement = ecPoint1.GetZCoord(0);
                    b = curve.CreatePoint(ecPoint1.XCoord.ToBigInteger(), ecPoint1.YCoord.ToBigInteger());
                    ECFieldElement scale1 = ecFieldElement.Square();
                    ECFieldElement scale2 = scale1.Multiply(ecFieldElement);
                    ecPoint2 = ecPoint2.ScaleX(scale1).ScaleY(scale2);
                    if (off == 0)
                    {
                      ecPointArray[0] = ecPoint2;
                      break;
                    }
                    break;
                }
              }
            }
            while (num4 < length)
              ecPointArray[num4++] = ecPoint2 = ecPoint2.Add(b);
          }
          curve.NormalizeAll(ecPointArray, off, length - off, ecFieldElement);
        }
      }
      if (this.m_includeNegated)
      {
        int index;
        if (a == null)
        {
          index = 0;
          a = new ECPoint[length];
        }
        else
        {
          index = a.Length;
          if (index < length)
            a = WNafUtilities.ResizeTable(a, length);
        }
        for (; index < length; ++index)
          a[index] = ecPointArray[index].Negate();
      }
      wnafPreCompInfo.PreComp = ecPointArray;
      wnafPreCompInfo.PreCompNeg = a;
      wnafPreCompInfo.Twice = ecPoint1;
      wnafPreCompInfo.Width = num3;
      return (PreCompInfo) wnafPreCompInfo;
    }

    private bool CheckExisting(
      WNafPreCompInfo existingWNaf,
      int width,
      int reqPreCompLen,
      bool includeNegated)
    {
      if (existingWNaf == null || existingWNaf.Width < System.Math.Max(existingWNaf.ConfWidth, width) || !this.CheckTable(existingWNaf.PreComp, reqPreCompLen))
        return false;
      return !includeNegated || this.CheckTable(existingWNaf.PreCompNeg, reqPreCompLen);
    }

    private bool CheckTable(ECPoint[] table, int reqLen) => table != null && table.Length >= reqLen;
  }

  private class PrecomputeWithPointMapCallback : IPreCompCallback
  {
    private readonly ECPoint m_point;
    private readonly ECPointMap m_pointMap;
    private readonly WNafPreCompInfo m_fromWNaf;
    private readonly bool m_includeNegated;

    internal PrecomputeWithPointMapCallback(
      ECPoint point,
      ECPointMap pointMap,
      WNafPreCompInfo fromWNaf,
      bool includeNegated)
    {
      this.m_point = point;
      this.m_pointMap = pointMap;
      this.m_fromWNaf = fromWNaf;
      this.m_includeNegated = includeNegated;
    }

    public PreCompInfo Precompute(PreCompInfo existing)
    {
      WNafPreCompInfo existingWNaf = existing as WNafPreCompInfo;
      int width = this.m_fromWNaf.Width;
      int length = this.m_fromWNaf.PreComp.Length;
      if (this.CheckExisting(existingWNaf, width, length, this.m_includeNegated))
      {
        existingWNaf.DecrementPromotionCountdown();
        return (PreCompInfo) existingWNaf;
      }
      WNafPreCompInfo wnafPreCompInfo = new WNafPreCompInfo();
      wnafPreCompInfo.PromotionCountdown = this.m_fromWNaf.PromotionCountdown;
      ECPoint twice = this.m_fromWNaf.Twice;
      if (twice != null)
      {
        ECPoint ecPoint = this.m_pointMap.Map(twice);
        wnafPreCompInfo.Twice = ecPoint;
      }
      ECPoint[] preComp = this.m_fromWNaf.PreComp;
      ECPoint[] ecPointArray1 = new ECPoint[preComp.Length];
      for (int index = 0; index < preComp.Length; ++index)
        ecPointArray1[index] = this.m_pointMap.Map(preComp[index]);
      wnafPreCompInfo.PreComp = ecPointArray1;
      wnafPreCompInfo.Width = width;
      if (this.m_includeNegated)
      {
        ECPoint[] ecPointArray2 = new ECPoint[ecPointArray1.Length];
        for (int index = 0; index < ecPointArray2.Length; ++index)
          ecPointArray2[index] = ecPointArray1[index].Negate();
        wnafPreCompInfo.PreCompNeg = ecPointArray2;
      }
      return (PreCompInfo) wnafPreCompInfo;
    }

    private bool CheckExisting(
      WNafPreCompInfo existingWNaf,
      int width,
      int reqPreCompLen,
      bool includeNegated)
    {
      if (existingWNaf == null || existingWNaf.Width < width || !this.CheckTable(existingWNaf.PreComp, reqPreCompLen))
        return false;
      return !includeNegated || this.CheckTable(existingWNaf.PreCompNeg, reqPreCompLen);
    }

    private bool CheckTable(ECPoint[] table, int reqLen) => table != null && table.Length >= reqLen;
  }
}
