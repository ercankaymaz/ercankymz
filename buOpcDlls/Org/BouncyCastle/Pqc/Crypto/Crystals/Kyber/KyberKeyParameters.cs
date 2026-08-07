// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Crystals.Kyber.KyberKeyParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Crystals.Kyber;

public abstract class KyberKeyParameters : AsymmetricKeyParameter
{
  private readonly KyberParameters m_parameters;

  internal KyberKeyParameters(bool isPrivate, KyberParameters parameters)
    : base(isPrivate)
  {
    this.m_parameters = parameters;
  }

  public KyberParameters Parameters => this.m_parameters;
}
