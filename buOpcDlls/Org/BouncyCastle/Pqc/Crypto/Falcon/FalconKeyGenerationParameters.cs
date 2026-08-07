// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Falcon.FalconKeyGenerationParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Falcon;

public class FalconKeyGenerationParameters : KeyGenerationParameters
{
  private FalconParameters parameters;

  public FalconKeyGenerationParameters(SecureRandom random, FalconParameters parameters)
    : base(random, 320)
  {
    this.parameters = parameters;
  }

  public FalconParameters Parameters => this.parameters;
}
