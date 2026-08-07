// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Agreement.DHAgreement
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Agreement;

public class DHAgreement
{
  private DHPrivateKeyParameters key;
  private DHParameters dhParams;
  private BigInteger privateValue;
  private SecureRandom random;

  public void Init(ICipherParameters parameters)
  {
    AsymmetricKeyParameter asymmetricKeyParameter;
    if (parameters is ParametersWithRandom parametersWithRandom)
    {
      this.random = parametersWithRandom.Random;
      asymmetricKeyParameter = (AsymmetricKeyParameter) parametersWithRandom.Parameters;
    }
    else
    {
      this.random = CryptoServicesRegistrar.GetSecureRandom();
      asymmetricKeyParameter = (AsymmetricKeyParameter) parameters;
    }
    this.key = asymmetricKeyParameter is DHPrivateKeyParameters privateKeyParameters ? privateKeyParameters : throw new ArgumentException("DHEngine expects DHPrivateKeyParameters");
    this.dhParams = privateKeyParameters.Parameters;
  }

  public BigInteger CalculateMessage()
  {
    DHKeyPairGenerator keyPairGenerator = new DHKeyPairGenerator();
    keyPairGenerator.Init((KeyGenerationParameters) new DHKeyGenerationParameters(this.random, this.dhParams));
    AsymmetricCipherKeyPair keyPair = keyPairGenerator.GenerateKeyPair();
    this.privateValue = ((DHPrivateKeyParameters) keyPair.Private).X;
    return ((DHPublicKeyParameters) keyPair.Public).Y;
  }

  public BigInteger CalculateAgreement(DHPublicKeyParameters pub, BigInteger message)
  {
    if (pub == null)
      throw new ArgumentNullException(nameof (pub));
    if (message == null)
      throw new ArgumentNullException(nameof (message));
    if (!pub.Parameters.Equals((object) this.dhParams))
      throw new ArgumentException("Diffie-Hellman public key has wrong parameters.");
    BigInteger p = this.dhParams.P;
    BigInteger y = pub.Y;
    if (y == null || y.CompareTo(BigInteger.One) <= 0 || y.CompareTo(p.Subtract(BigInteger.One)) >= 0)
      throw new ArgumentException("Diffie-Hellman public key is weak");
    BigInteger val = y.ModPow(this.privateValue, p);
    if (val.Equals(BigInteger.One))
      throw new InvalidOperationException("Shared key can't be 1");
    return message.ModPow(this.key.X, p).Multiply(val).Mod(p);
  }
}
