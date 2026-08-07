// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Endo.GlvTypeBEndomorphism
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Math.EC.Endo;

public class GlvTypeBEndomorphism : GlvEndomorphism, ECEndomorphism
{
  protected readonly GlvTypeBParameters m_parameters;
  protected readonly ECPointMap m_pointMap;

  public GlvTypeBEndomorphism(ECCurve curve, GlvTypeBParameters parameters)
  {
    this.m_parameters = parameters;
    this.m_pointMap = (ECPointMap) new ScaleXPointMap(curve.FromBigInteger(parameters.Beta));
  }

  public virtual BigInteger[] DecomposeScalar(BigInteger k)
  {
    return EndoUtilities.DecomposeScalar(this.m_parameters.SplitParams, k);
  }

  public virtual ECPointMap PointMap => this.m_pointMap;

  public virtual bool HasEfficientPointMap => true;
}
