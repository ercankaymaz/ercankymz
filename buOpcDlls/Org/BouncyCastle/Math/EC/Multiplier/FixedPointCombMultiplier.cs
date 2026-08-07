// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Multiplier.FixedPointCombMultiplier
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.Raw;
using System;

#nullable disable
namespace Org.BouncyCastle.Math.EC.Multiplier;

public class FixedPointCombMultiplier : AbstractECMultiplier
{
  protected override ECPoint MultiplyPositive(ECPoint p, BigInteger k)
  {
    ECCurve curve = p.Curve;
    int combSize = FixedPointUtilities.GetCombSize(curve);
    if (k.BitLength > combSize)
      throw new InvalidOperationException("fixed-point comb doesn't support scalars larger than the curve order");
    FixedPointPreCompInfo pointPreCompInfo = FixedPointUtilities.Precompute(p);
    ECLookupTable lookupTable = pointPreCompInfo.LookupTable;
    int width = pointPreCompInfo.Width;
    int num1 = (combSize + width - 1) / width;
    int bits = num1 * width;
    uint[] numArray = Nat.FromBigInteger(bits, k);
    ECPoint ecPoint = curve.Infinity;
    for (int index1 = 1; index1 <= num1; ++index1)
    {
      uint index2 = 0;
      for (int index3 = bits - index1; index3 >= 0; index3 -= num1)
      {
        uint num2 = numArray[index3 >> 5] >> index3;
        index2 = (index2 ^ num2 >> 1) << 1 ^ num2;
      }
      ECPoint b = lookupTable.Lookup((int) index2);
      ecPoint = ecPoint.TwicePlus(b);
    }
    return ecPoint.Add(pointPreCompInfo.Offset);
  }
}
