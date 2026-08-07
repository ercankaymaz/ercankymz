// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Falcon.FalconKeyParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Falcon;

public abstract class FalconKeyParameters : AsymmetricKeyParameter
{
  private readonly FalconParameters m_parameters;

  internal FalconKeyParameters(bool isprivate, FalconParameters parameters)
    : base(isprivate)
  {
    this.m_parameters = parameters;
  }

  public FalconParameters Parameters => this.m_parameters;
}
