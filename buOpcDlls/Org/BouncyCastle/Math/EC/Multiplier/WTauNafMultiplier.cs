// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Multiplier.WTauNafMultiplier
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.EC.Abc;
using System;

#nullable disable
namespace Org.BouncyCastle.Math.EC.Multiplier;

public class WTauNafMultiplier : AbstractECMultiplier
{
  internal static readonly string PRECOMP_NAME = "bc_wtnaf";

  protected override ECPoint MultiplyPositive(ECPoint point, BigInteger k)
  {
    AbstractF2mCurve curve = point is AbstractF2mPoint p ? (AbstractF2mCurve) p.Curve : throw new ArgumentException("Only AbstractF2mPoint can be used in WTauNafMultiplier");
    sbyte intValue = (sbyte) curve.A.ToBigInteger().IntValue;
    sbyte mu = Tnaf.GetMu((int) intValue);
    ZTauElement lambda = Tnaf.PartModReduction(curve, k, intValue, mu, (sbyte) 10);
    return (ECPoint) this.MultiplyWTnaf(p, lambda, intValue, mu);
  }

  private AbstractF2mPoint MultiplyWTnaf(
    AbstractF2mPoint p,
    ZTauElement lambda,
    sbyte a,
    sbyte mu)
  {
    ZTauElement[] alpha = a == (sbyte) 0 ? Tnaf.Alpha0 : Tnaf.Alpha1;
    BigInteger tw = Tnaf.GetTw(mu, 4);
    sbyte[] u = Tnaf.TauAdicWNaf(mu, lambda, 4, tw.IntValue, alpha);
    return WTauNafMultiplier.MultiplyFromWTnaf(p, u);
  }

  private static AbstractF2mPoint MultiplyFromWTnaf(AbstractF2mPoint p, sbyte[] u)
  {
    AbstractF2mCurve curve = (AbstractF2mCurve) p.Curve;
    sbyte intValue = (sbyte) curve.A.ToBigInteger().IntValue;
    WTauNafMultiplier.WTauNafCallback callback = new WTauNafMultiplier.WTauNafCallback(p, intValue);
    AbstractF2mPoint[] preComp = ((WTauNafPreCompInfo) curve.Precompute((ECPoint) p, WTauNafMultiplier.PRECOMP_NAME, (IPreCompCallback) callback)).PreComp;
    AbstractF2mPoint[] abstractF2mPointArray = new AbstractF2mPoint[preComp.Length];
    for (int index = 0; index < preComp.Length; ++index)
      abstractF2mPointArray[index] = (AbstractF2mPoint) preComp[index].Negate();
    AbstractF2mPoint abstractF2mPoint1 = (AbstractF2mPoint) p.Curve.Infinity;
    int pow = 0;
    for (int index = u.Length - 1; index >= 0; --index)
    {
      ++pow;
      int num = (int) u[index];
      if (num != 0)
      {
        AbstractF2mPoint abstractF2mPoint2 = abstractF2mPoint1.TauPow(pow);
        pow = 0;
        ECPoint b = num > 0 ? (ECPoint) preComp[num >> 1] : (ECPoint) abstractF2mPointArray[-num >> 1];
        abstractF2mPoint1 = (AbstractF2mPoint) abstractF2mPoint2.Add(b);
      }
    }
    if (pow > 0)
      abstractF2mPoint1 = abstractF2mPoint1.TauPow(pow);
    return abstractF2mPoint1;
  }

  private class WTauNafCallback : IPreCompCallback
  {
    private readonly AbstractF2mPoint m_p;
    private readonly sbyte m_a;

    internal WTauNafCallback(AbstractF2mPoint p, sbyte a)
    {
      this.m_p = p;
      this.m_a = a;
    }

    public PreCompInfo Precompute(PreCompInfo existing)
    {
      if (existing is WTauNafPreCompInfo)
        return existing;
      return (PreCompInfo) new WTauNafPreCompInfo()
      {
        PreComp = Tnaf.GetPreComp(this.m_p, this.m_a)
      };
    }
  }
}
