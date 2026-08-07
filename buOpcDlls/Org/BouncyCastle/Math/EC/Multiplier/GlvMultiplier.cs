// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Multiplier.GlvMultiplier
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.EC.Endo;
using System;

#nullable disable
namespace Org.BouncyCastle.Math.EC.Multiplier;

public class GlvMultiplier : AbstractECMultiplier
{
  protected readonly ECCurve curve;
  protected readonly GlvEndomorphism glvEndomorphism;

  public GlvMultiplier(ECCurve curve, GlvEndomorphism glvEndomorphism)
  {
    this.curve = curve != null && curve.Order != null ? curve : throw new ArgumentException("Need curve with known group order", nameof (curve));
    this.glvEndomorphism = glvEndomorphism;
  }

  protected override ECPoint MultiplyPositive(ECPoint p, BigInteger k)
  {
    if (!this.curve.Equals(p.Curve))
      throw new InvalidOperationException();
    BigInteger order = p.Curve.Order;
    BigInteger[] bigIntegerArray = this.glvEndomorphism.DecomposeScalar(k.Mod(order));
    BigInteger k1 = bigIntegerArray[0];
    BigInteger l = bigIntegerArray[1];
    if (this.glvEndomorphism.HasEfficientPointMap)
      return ECAlgorithms.ImplShamirsTrickWNaf((ECEndomorphism) this.glvEndomorphism, p, k1, l);
    ECPoint Q = EndoUtilities.MapPoint((ECEndomorphism) this.glvEndomorphism, p);
    return ECAlgorithms.ImplShamirsTrickWNaf(p, k1, Q, l);
  }
}
