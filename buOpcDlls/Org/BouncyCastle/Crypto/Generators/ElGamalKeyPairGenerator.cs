// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Generators.ElGamalKeyPairGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;

#nullable disable
namespace Org.BouncyCastle.Crypto.Generators;

public class ElGamalKeyPairGenerator : IAsymmetricCipherKeyPairGenerator
{
  private ElGamalKeyGenerationParameters param;

  public void Init(KeyGenerationParameters parameters)
  {
    this.param = (ElGamalKeyGenerationParameters) parameters;
  }

  public AsymmetricCipherKeyPair GenerateKeyPair()
  {
    DHKeyGeneratorHelper instance = DHKeyGeneratorHelper.Instance;
    ElGamalParameters parameters = this.param.Parameters;
    DHParameters dhParams = new DHParameters(parameters.P, parameters.G, (BigInteger) null, 0, parameters.L);
    BigInteger x = instance.CalculatePrivate(dhParams, this.param.Random);
    return new AsymmetricCipherKeyPair((AsymmetricKeyParameter) new ElGamalPublicKeyParameters(instance.CalculatePublic(dhParams, x), parameters), (AsymmetricKeyParameter) new ElGamalPrivateKeyParameters(x, parameters));
  }
}
