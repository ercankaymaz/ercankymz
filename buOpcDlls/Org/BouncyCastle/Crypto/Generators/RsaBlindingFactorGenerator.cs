// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Generators.RsaBlindingFactorGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Generators;

public class RsaBlindingFactorGenerator
{
  private RsaKeyParameters key;
  private SecureRandom random;

  public void Init(ICipherParameters param)
  {
    if (param is ParametersWithRandom parametersWithRandom)
    {
      this.key = (RsaKeyParameters) parametersWithRandom.Parameters;
      this.random = parametersWithRandom.Random;
    }
    else
    {
      this.key = (RsaKeyParameters) param;
      this.random = CryptoServicesRegistrar.GetSecureRandom();
    }
    if (this.key.IsPrivate)
      throw new ArgumentException("generator requires RSA public key");
  }

  public BigInteger GenerateBlindingFactor()
  {
    BigInteger bigInteger1 = this.key != null ? this.key.Modulus : throw new InvalidOperationException("generator not initialised");
    int sizeInBits = bigInteger1.BitLength - 1;
    BigInteger blindingFactor;
    BigInteger bigInteger2;
    do
    {
      blindingFactor = new BigInteger(sizeInBits, (Random) this.random);
      bigInteger2 = blindingFactor.Gcd(bigInteger1);
    }
    while (blindingFactor.SignValue == 0 || blindingFactor.Equals(BigInteger.One) || !bigInteger2.Equals(BigInteger.One));
    return blindingFactor;
  }
}
