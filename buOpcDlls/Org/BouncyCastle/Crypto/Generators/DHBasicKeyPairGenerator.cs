// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Generators.DHBasicKeyPairGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;

#nullable disable
namespace Org.BouncyCastle.Crypto.Generators;

public class DHBasicKeyPairGenerator : IAsymmetricCipherKeyPairGenerator
{
  private DHKeyGenerationParameters param;

  public virtual void Init(KeyGenerationParameters parameters)
  {
    this.param = (DHKeyGenerationParameters) parameters;
  }

  public virtual AsymmetricCipherKeyPair GenerateKeyPair()
  {
    DHKeyGeneratorHelper instance = DHKeyGeneratorHelper.Instance;
    DHParameters parameters = this.param.Parameters;
    BigInteger x = instance.CalculatePrivate(parameters, this.param.Random);
    return new AsymmetricCipherKeyPair((AsymmetricKeyParameter) new DHPublicKeyParameters(instance.CalculatePublic(parameters, x), parameters), (AsymmetricKeyParameter) new DHPrivateKeyParameters(x, parameters));
  }
}
