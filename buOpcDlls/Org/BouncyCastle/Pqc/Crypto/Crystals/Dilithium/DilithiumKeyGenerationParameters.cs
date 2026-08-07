// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Crystals.Dilithium.DilithiumKeyGenerationParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Crystals.Dilithium;

public class DilithiumKeyGenerationParameters : KeyGenerationParameters
{
  private DilithiumParameters parameters;

  public DilithiumKeyGenerationParameters(SecureRandom random, DilithiumParameters parameters)
    : base(random, (int) byte.MaxValue)
  {
    this.parameters = parameters;
  }

  public DilithiumParameters Parameters => this.parameters;
}
