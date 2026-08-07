// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Lms.HssKeyPairGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Lms;

public sealed class HssKeyPairGenerator : IAsymmetricCipherKeyPairGenerator
{
  private HssKeyGenerationParameters m_parameters;

  public void Init(KeyGenerationParameters parameters)
  {
    this.m_parameters = (HssKeyGenerationParameters) parameters;
  }

  public AsymmetricCipherKeyPair GenerateKeyPair()
  {
    HssPrivateKeyParameters hssKeyPair = Hss.GenerateHssKeyPair(this.m_parameters);
    return new AsymmetricCipherKeyPair((AsymmetricKeyParameter) hssKeyPair.GetPublicKey(), (AsymmetricKeyParameter) hssKeyPair);
  }
}
