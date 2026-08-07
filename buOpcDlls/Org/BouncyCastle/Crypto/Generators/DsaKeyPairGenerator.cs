// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Generators.DsaKeyPairGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Math.EC.Multiplier;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Generators;

public class DsaKeyPairGenerator : IAsymmetricCipherKeyPairGenerator
{
  private static readonly BigInteger One = BigInteger.One;
  private DsaKeyGenerationParameters param;

  public void Init(KeyGenerationParameters parameters)
  {
    this.param = parameters != null ? (DsaKeyGenerationParameters) parameters : throw new ArgumentNullException(nameof (parameters));
  }

  public AsymmetricCipherKeyPair GenerateKeyPair()
  {
    DsaParameters parameters = this.param.Parameters;
    BigInteger privateKey = DsaKeyPairGenerator.GeneratePrivateKey(parameters.Q, this.param.Random);
    return new AsymmetricCipherKeyPair((AsymmetricKeyParameter) new DsaPublicKeyParameters(DsaKeyPairGenerator.CalculatePublicKey(parameters.P, parameters.G, privateKey), parameters), (AsymmetricKeyParameter) new DsaPrivateKeyParameters(privateKey, parameters));
  }

  private static BigInteger GeneratePrivateKey(BigInteger q, SecureRandom random)
  {
    int num = q.BitLength >> 2;
    BigInteger randomInRange;
    do
    {
      randomInRange = BigIntegers.CreateRandomInRange(DsaKeyPairGenerator.One, q.Subtract(DsaKeyPairGenerator.One), random);
    }
    while (WNafUtilities.GetNafWeight(randomInRange) < num);
    return randomInRange;
  }

  private static BigInteger CalculatePublicKey(BigInteger p, BigInteger g, BigInteger x)
  {
    return g.ModPow(x, p);
  }
}
