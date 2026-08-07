// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Generators.Gost3410KeyPairGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.CryptoPro;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Math.EC.Multiplier;
using Org.BouncyCastle.Security;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Generators;

public class Gost3410KeyPairGenerator : IAsymmetricCipherKeyPairGenerator
{
  private Gost3410KeyGenerationParameters param;

  public void Init(KeyGenerationParameters parameters)
  {
    if (parameters is Gost3410KeyGenerationParameters)
    {
      this.param = (Gost3410KeyGenerationParameters) parameters;
    }
    else
    {
      Gost3410KeyGenerationParameters generationParameters = new Gost3410KeyGenerationParameters(parameters.Random, CryptoProObjectIdentifiers.GostR3410x94CryptoProA);
      int strength = parameters.Strength;
      int num = generationParameters.Parameters.P.BitLength - 1;
      this.param = generationParameters;
    }
  }

  public AsymmetricCipherKeyPair GenerateKeyPair()
  {
    SecureRandom random = this.param.Random;
    Gost3410Parameters parameters = this.param.Parameters;
    BigInteger q = parameters.Q;
    int num = 64 /*0x40*/;
    BigInteger bigInteger;
    do
    {
      bigInteger = new BigInteger(256 /*0x0100*/, (Random) random);
    }
    while (bigInteger.SignValue < 1 || bigInteger.CompareTo(q) >= 0 || WNafUtilities.GetNafWeight(bigInteger) < num);
    BigInteger p = parameters.P;
    BigInteger y = parameters.A.ModPow(bigInteger, p);
    return this.param.PublicKeyParamSet != null ? new AsymmetricCipherKeyPair((AsymmetricKeyParameter) new Gost3410PublicKeyParameters(y, this.param.PublicKeyParamSet), (AsymmetricKeyParameter) new Gost3410PrivateKeyParameters(bigInteger, this.param.PublicKeyParamSet)) : new AsymmetricCipherKeyPair((AsymmetricKeyParameter) new Gost3410PublicKeyParameters(y, parameters), (AsymmetricKeyParameter) new Gost3410PrivateKeyParameters(bigInteger, parameters));
  }
}
