// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Sike.SikeKeyPairGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Sike;

[Obsolete("Will be removed")]
public sealed class SikeKeyPairGenerator : IAsymmetricCipherKeyPairGenerator
{
  private SikeKeyGenerationParameters sikeParams;
  private SecureRandom random;

  private void Initialize(KeyGenerationParameters param)
  {
    this.sikeParams = (SikeKeyGenerationParameters) param;
    this.random = param.Random;
  }

  private AsymmetricCipherKeyPair GenKeyPair()
  {
    SikeEngine engine = this.sikeParams.Parameters.GetEngine();
    byte[] numArray1 = new byte[(int) engine.GetPrivateKeySize()];
    byte[] numArray2 = new byte[(int) engine.GetPublicKeySize()];
    engine.crypto_kem_keypair(numArray2, numArray1, this.random);
    return new AsymmetricCipherKeyPair((AsymmetricKeyParameter) new SikePublicKeyParameters(this.sikeParams.Parameters, numArray2), (AsymmetricKeyParameter) new SikePrivateKeyParameters(this.sikeParams.Parameters, numArray1));
  }

  public void Init(KeyGenerationParameters param) => this.Initialize(param);

  public AsymmetricCipherKeyPair GenerateKeyPair() => this.GenKeyPair();
}
