// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Saber.SaberKeyPairGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Saber;

public class SaberKeyPairGenerator : IAsymmetricCipherKeyPairGenerator
{
  private SaberKeyGenerationParameters saberParams;
  private int l;
  private SecureRandom random;

  private void Initialize(KeyGenerationParameters param)
  {
    this.saberParams = (SaberKeyGenerationParameters) param;
    this.random = param.Random;
    this.l = this.saberParams.Parameters.L;
  }

  private AsymmetricCipherKeyPair GenKeyPair()
  {
    SaberEngine engine = this.saberParams.Parameters.Engine;
    byte[] numArray1 = new byte[engine.GetPrivateKeySize()];
    byte[] numArray2 = new byte[engine.GetPublicKeySize()];
    engine.crypto_kem_keypair(numArray2, numArray1, this.random);
    return new AsymmetricCipherKeyPair((AsymmetricKeyParameter) new SaberPublicKeyParameters(this.saberParams.Parameters, numArray2), (AsymmetricKeyParameter) new SaberPrivateKeyParameters(this.saberParams.Parameters, numArray1));
  }

  public void Init(KeyGenerationParameters param) => this.Initialize(param);

  public AsymmetricCipherKeyPair GenerateKeyPair() => this.GenKeyPair();
}
