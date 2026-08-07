// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Saber.SaberKeyParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Saber;

public abstract class SaberKeyParameters : AsymmetricKeyParameter
{
  private readonly SaberParameters m_parameters;

  internal SaberKeyParameters(bool isPrivate, SaberParameters parameters)
    : base(isPrivate)
  {
    this.m_parameters = parameters;
  }

  public SaberParameters Parameters => this.m_parameters;
}
