// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Bike.BikeKeyGenerationParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Bike;

public sealed class BikeKeyGenerationParameters : KeyGenerationParameters
{
  private readonly BikeParameters m_parameters;

  public BikeKeyGenerationParameters(SecureRandom random, BikeParameters parameters)
    : base(random, 256 /*0x0100*/)
  {
    this.m_parameters = parameters;
  }

  public BikeParameters Parameters => this.m_parameters;
}
