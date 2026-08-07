// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Picnic.PicnicKeyGenerationParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Picnic;

public class PicnicKeyGenerationParameters : KeyGenerationParameters
{
  private readonly PicnicParameters m_parameters;

  public PicnicKeyGenerationParameters(SecureRandom random, PicnicParameters parameters)
    : base(random, (int) byte.MaxValue)
  {
    this.m_parameters = parameters;
  }

  public PicnicParameters Parameters => this.m_parameters;
}
