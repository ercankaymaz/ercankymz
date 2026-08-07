// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Sike.SikeKeyGenerationParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Sike;

[Obsolete("Will be removed")]
public sealed class SikeKeyGenerationParameters : KeyGenerationParameters
{
  private readonly SikeParameters m_parameters;

  public SikeKeyGenerationParameters(SecureRandom random, SikeParameters sikeParameters)
    : base(random, 256 /*0x0100*/)
  {
    this.m_parameters = sikeParameters;
  }

  public SikeParameters Parameters => this.m_parameters;
}
