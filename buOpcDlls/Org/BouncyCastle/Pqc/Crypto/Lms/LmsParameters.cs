// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Lms.LmsParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Lms;

public sealed class LmsParameters
{
  private readonly LMSigParameters m_lmSigParameters;
  private readonly LMOtsParameters m_lmOtsParameters;

  public LmsParameters(LMSigParameters lmSigParameters, LMOtsParameters lmOtsParameters)
  {
    this.m_lmSigParameters = lmSigParameters;
    this.m_lmOtsParameters = lmOtsParameters;
  }

  public LMSigParameters LMSigParameters => this.m_lmSigParameters;

  public LMOtsParameters LMOtsParameters => this.m_lmOtsParameters;
}
