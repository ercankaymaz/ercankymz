// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Endo.GlvTypeAParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Math.EC.Endo;

public class GlvTypeAParameters
{
  protected readonly BigInteger m_i;
  protected readonly BigInteger m_lambda;
  protected readonly ScalarSplitParameters m_splitParams;

  public GlvTypeAParameters(BigInteger i, BigInteger lambda, ScalarSplitParameters splitParams)
  {
    this.m_i = i;
    this.m_lambda = lambda;
    this.m_splitParams = splitParams;
  }

  public virtual BigInteger I => this.m_i;

  public virtual BigInteger Lambda => this.m_lambda;

  public virtual ScalarSplitParameters SplitParams => this.m_splitParams;
}
