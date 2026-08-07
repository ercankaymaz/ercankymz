// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Endo.EndoUtilities
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.EC.Multiplier;

#nullable disable
namespace Org.BouncyCastle.Math.EC.Endo;

public abstract class EndoUtilities
{
  public static readonly string PRECOMP_NAME = "bc_endo";

  public static BigInteger[] DecomposeScalar(ScalarSplitParameters p, BigInteger k)
  {
    int bits = p.Bits;
    BigInteger b1 = EndoUtilities.CalculateB(k, p.G1, bits);
    BigInteger b2 = EndoUtilities.CalculateB(k, p.G2, bits);
    return new BigInteger[2]
    {
      k.Subtract(b1.Multiply(p.V1A).Add(b2.Multiply(p.V2A))),
      b1.Multiply(p.V1B).Add(b2.Multiply(p.V2B)).Negate()
    };
  }

  public static ECPoint MapPoint(ECEndomorphism endomorphism, ECPoint p)
  {
    return ((EndoPreCompInfo) p.Curve.Precompute(p, EndoUtilities.PRECOMP_NAME, (IPreCompCallback) new EndoUtilities.MapPointCallback(endomorphism, p))).MappedPoint;
  }

  private static BigInteger CalculateB(BigInteger k, BigInteger g, int t)
  {
    int num1 = g.SignValue < 0 ? 1 : 0;
    BigInteger bigInteger1 = k.Multiply(g.Abs());
    int num2 = bigInteger1.TestBit(t - 1) ? 1 : 0;
    BigInteger bigInteger2 = bigInteger1.ShiftRight(t);
    if (num2 != 0)
      bigInteger2 = bigInteger2.Add(BigInteger.One);
    return num1 == 0 ? bigInteger2 : bigInteger2.Negate();
  }

  private class MapPointCallback : IPreCompCallback
  {
    private readonly ECEndomorphism m_endomorphism;
    private readonly ECPoint m_point;

    internal MapPointCallback(ECEndomorphism endomorphism, ECPoint point)
    {
      this.m_endomorphism = endomorphism;
      this.m_point = point;
    }

    public PreCompInfo Precompute(PreCompInfo existing)
    {
      EndoPreCompInfo existingEndo = existing as EndoPreCompInfo;
      if (this.CheckExisting(existingEndo, this.m_endomorphism))
        return (PreCompInfo) existingEndo;
      ECPoint ecPoint = this.m_endomorphism.PointMap.Map(this.m_point);
      return (PreCompInfo) new EndoPreCompInfo()
      {
        Endomorphism = this.m_endomorphism,
        MappedPoint = ecPoint
      };
    }

    private bool CheckExisting(EndoPreCompInfo existingEndo, ECEndomorphism endomorphism)
    {
      return existingEndo != null && existingEndo.Endomorphism == endomorphism && existingEndo.MappedPoint != null;
    }
  }
}
