// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Saber.SaberKeyGenerationParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Saber;

public sealed class SaberKeyGenerationParameters : KeyGenerationParameters
{
  private SaberParameters parameters;

  public SaberKeyGenerationParameters(SecureRandom random, SaberParameters saberParameters)
    : base(random, 256 /*0x0100*/)
  {
    this.parameters = saberParameters;
  }

  public SaberParameters Parameters => this.parameters;
}
