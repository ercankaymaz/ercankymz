// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Picnic.PicnicKeyPairGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Picnic;

public class PicnicKeyPairGenerator : IAsymmetricCipherKeyPairGenerator
{
  private SecureRandom random;
  private PicnicParameters parameters;

  public void Init(KeyGenerationParameters param)
  {
    this.random = param.Random;
    this.parameters = ((PicnicKeyGenerationParameters) param).Parameters;
  }

  public AsymmetricCipherKeyPair GenerateKeyPair()
  {
    PicnicEngine engine = this.parameters.GetEngine();
    byte[] numArray1 = new byte[engine.GetSecretKeySize()];
    byte[] numArray2 = new byte[engine.GetPublicKeySize()];
    engine.crypto_sign_keypair(numArray2, numArray1, this.random);
    return new AsymmetricCipherKeyPair((AsymmetricKeyParameter) new PicnicPublicKeyParameters(this.parameters, numArray2), (AsymmetricKeyParameter) new PicnicPrivateKeyParameters(this.parameters, numArray1));
  }
}
