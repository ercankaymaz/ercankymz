// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X9.X9ECParametersHolder
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.EC;

#nullable disable
namespace Org.BouncyCastle.Asn1.X9;

public abstract class X9ECParametersHolder
{
  private ECCurve m_curve;
  private X9ECParameters m_parameters;

  public ECCurve Curve
  {
    get
    {
      lock (this)
      {
        if (this.m_curve == null)
          this.m_curve = this.CreateCurve();
        return this.m_curve;
      }
    }
  }

  public X9ECParameters Parameters
  {
    get
    {
      lock (this)
      {
        if (this.m_parameters == null)
          this.m_parameters = this.CreateParameters();
        return this.m_parameters;
      }
    }
  }

  protected virtual ECCurve CreateCurve() => this.CreateParameters().Curve;

  protected abstract X9ECParameters CreateParameters();
}
