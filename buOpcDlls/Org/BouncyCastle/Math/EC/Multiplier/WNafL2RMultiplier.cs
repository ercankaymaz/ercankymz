// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Multiplier.WNafL2RMultiplier
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;

#nullable disable
namespace Org.BouncyCastle.Math.EC.Multiplier;

public class WNafL2RMultiplier : AbstractECMultiplier
{
  protected override ECPoint MultiplyPositive(ECPoint p, BigInteger k)
  {
    int windowSize = WNafUtilities.GetWindowSize(k.BitLength);
    WNafPreCompInfo wnafPreCompInfo = WNafUtilities.Precompute(p, windowSize, true);
    ECPoint[] preComp = wnafPreCompInfo.PreComp;
    ECPoint[] preCompNeg = wnafPreCompInfo.PreCompNeg;
    int width = wnafPreCompInfo.Width;
    int[] compactWindowNaf = WNafUtilities.GenerateCompactWindowNaf(width, k);
    ECPoint ecPoint1 = p.Curve.Infinity;
    int length = compactWindowNaf.Length;
    if (length > 1)
    {
      int num1 = compactWindowNaf[--length];
      int num2 = num1 >> 16 /*0x10*/;
      int e = num1 & (int) ushort.MaxValue;
      int i = System.Math.Abs(num2);
      ECPoint[] ecPointArray = num2 < 0 ? preCompNeg : preComp;
      ECPoint ecPoint2;
      if (i << 2 < 1 << width)
      {
        int num3 = 32 /*0x20*/ - Integers.NumberOfLeadingZeros(i);
        int num4 = width - num3;
        int num5 = i ^ 1 << num3 - 1;
        int num6 = (1 << width - 1) - 1;
        int num7 = num4 & 31 /*0x1F*/;
        int num8 = (num5 << num7) + 1;
        ecPoint2 = ecPointArray[num6 >> 1].Add(ecPointArray[num8 >> 1]);
        e -= num4;
      }
      else
        ecPoint2 = ecPointArray[i >> 1];
      ecPoint1 = ecPoint2.TimesPow2(e);
    }
    while (length > 0)
    {
      int num9 = compactWindowNaf[--length];
      int num10 = num9 >> 16 /*0x10*/;
      int e = num9 & (int) ushort.MaxValue;
      int num11 = System.Math.Abs(num10);
      ECPoint b = (num10 < 0 ? preCompNeg : preComp)[num11 >> 1];
      ecPoint1 = ecPoint1.TwicePlus(b).TimesPow2(e);
    }
    return ecPoint1;
  }
}
