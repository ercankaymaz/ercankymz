// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Multiplier.AbstractECMultiplier
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Math.EC.Multiplier;

public abstract class AbstractECMultiplier : ECMultiplier
{
  public virtual ECPoint Multiply(ECPoint p, BigInteger k)
  {
    int signValue = k.SignValue;
    if (signValue == 0 || p.IsInfinity)
      return p.Curve.Infinity;
    ECPoint ecPoint = this.MultiplyPositive(p, k.Abs());
    return this.CheckResult(signValue > 0 ? ecPoint : ecPoint.Negate());
  }

  protected abstract ECPoint MultiplyPositive(ECPoint p, BigInteger k);

  protected virtual ECPoint CheckResult(ECPoint p) => ECAlgorithms.ImplCheckResult(p);
}
