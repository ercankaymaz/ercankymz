// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Generators.X448KeyPairGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;

#nullable disable
namespace Org.BouncyCastle.Crypto.Generators;

public class X448KeyPairGenerator : IAsymmetricCipherKeyPairGenerator
{
  private SecureRandom random;

  public virtual void Init(KeyGenerationParameters parameters) => this.random = parameters.Random;

  public virtual AsymmetricCipherKeyPair GenerateKeyPair()
  {
    X448PrivateKeyParameters privateParameter = new X448PrivateKeyParameters(this.random);
    return new AsymmetricCipherKeyPair((AsymmetricKeyParameter) privateParameter.GeneratePublicKey(), (AsymmetricKeyParameter) privateParameter);
  }
}
