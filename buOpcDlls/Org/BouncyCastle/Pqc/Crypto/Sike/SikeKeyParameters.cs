// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Sike.SikeKeyParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Sike;

[Obsolete("Will be removed")]
public abstract class SikeKeyParameters : AsymmetricKeyParameter
{
  private readonly SikeParameters m_parameters;

  internal SikeKeyParameters(bool isPrivate, SikeParameters parameters)
    : base(isPrivate)
  {
    this.m_parameters = parameters;
  }

  public SikeParameters Parameters => this.m_parameters;
}
