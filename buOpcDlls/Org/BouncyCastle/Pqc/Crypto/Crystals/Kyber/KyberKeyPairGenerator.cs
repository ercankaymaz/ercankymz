// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Crystals.Kyber.KyberKeyPairGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Crystals.Kyber;

public class KyberKeyPairGenerator : IAsymmetricCipherKeyPairGenerator
{
  private KyberParameters KyberParams;
  private SecureRandom random;

  private void Initialize(KeyGenerationParameters param)
  {
    this.KyberParams = ((KyberKeyGenerationParameters) param).Parameters;
    this.random = param.Random;
  }

  private AsymmetricCipherKeyPair GenKeyPair()
  {
    KyberEngine engine = this.KyberParams.Engine;
    engine.Init(this.random);
    byte[] t;
    byte[] rho;
    byte[] s;
    byte[] hpk;
    byte[] nonce;
    engine.GenerateKemKeyPair(out t, out rho, out s, out hpk, out nonce);
    return new AsymmetricCipherKeyPair((AsymmetricKeyParameter) new KyberPublicKeyParameters(this.KyberParams, t, rho), (AsymmetricKeyParameter) new KyberPrivateKeyParameters(this.KyberParams, s, hpk, nonce, t, rho));
  }

  public void Init(KeyGenerationParameters param) => this.Initialize(param);

  public AsymmetricCipherKeyPair GenerateKeyPair() => this.GenKeyPair();
}
