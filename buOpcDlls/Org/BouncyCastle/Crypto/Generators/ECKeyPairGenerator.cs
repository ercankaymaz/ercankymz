// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Generators.ECKeyPairGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Sec;
using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Crypto.EC;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Math.EC;
using Org.BouncyCastle.Math.EC.Multiplier;
using Org.BouncyCastle.Security;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Generators;

public class ECKeyPairGenerator : IAsymmetricCipherKeyPairGenerator
{
  private readonly string algorithm;
  private ECDomainParameters parameters;
  private DerObjectIdentifier publicKeyParamSet;
  private SecureRandom random;

  public ECKeyPairGenerator()
    : this("EC")
  {
  }

  public ECKeyPairGenerator(string algorithm)
  {
    this.algorithm = algorithm != null ? ECKeyParameters.VerifyAlgorithmName(algorithm) : throw new ArgumentNullException(nameof (algorithm));
  }

  public void Init(KeyGenerationParameters parameters)
  {
    if (parameters is ECKeyGenerationParameters)
    {
      ECKeyGenerationParameters generationParameters = (ECKeyGenerationParameters) parameters;
      this.publicKeyParamSet = generationParameters.PublicKeyParamSet;
      this.parameters = generationParameters.DomainParameters;
    }
    else
    {
      DerObjectIdentifier oid;
      switch (parameters.Strength)
      {
        case 192 /*0xC0*/:
          oid = X9ObjectIdentifiers.Prime192v1;
          break;
        case 224 /*0xE0*/:
          oid = SecObjectIdentifiers.SecP224r1;
          break;
        case 239:
          oid = X9ObjectIdentifiers.Prime239v1;
          break;
        case 256 /*0x0100*/:
          oid = X9ObjectIdentifiers.Prime256v1;
          break;
        case 384:
          oid = SecObjectIdentifiers.SecP384r1;
          break;
        case 521:
          oid = SecObjectIdentifiers.SecP521r1;
          break;
        default:
          throw new InvalidParameterException("unknown key size.");
      }
      X9ECParameters ecCurveByOid = ECKeyPairGenerator.FindECCurveByOid(oid);
      this.publicKeyParamSet = oid;
      this.parameters = new ECDomainParameters(ecCurveByOid.Curve, ecCurveByOid.G, ecCurveByOid.N, ecCurveByOid.H, ecCurveByOid.GetSeed());
    }
    this.random = parameters.Random;
    if (this.random != null)
      return;
    this.random = CryptoServicesRegistrar.GetSecureRandom();
  }

  public AsymmetricCipherKeyPair GenerateKeyPair()
  {
    BigInteger n = this.parameters.N;
    int num = n.BitLength >> 2;
    BigInteger bigInteger;
    do
    {
      bigInteger = new BigInteger(n.BitLength, (Random) this.random);
    }
    while (bigInteger.CompareTo(BigInteger.One) < 0 || bigInteger.CompareTo(n) >= 0 || WNafUtilities.GetNafWeight(bigInteger) < num);
    ECPoint q = this.CreateBasePointMultiplier().Multiply(this.parameters.G, bigInteger);
    return this.publicKeyParamSet != null ? new AsymmetricCipherKeyPair((AsymmetricKeyParameter) new ECPublicKeyParameters(this.algorithm, q, this.publicKeyParamSet), (AsymmetricKeyParameter) new ECPrivateKeyParameters(this.algorithm, bigInteger, this.publicKeyParamSet)) : new AsymmetricCipherKeyPair((AsymmetricKeyParameter) new ECPublicKeyParameters(this.algorithm, q, this.parameters), (AsymmetricKeyParameter) new ECPrivateKeyParameters(this.algorithm, bigInteger, this.parameters));
  }

  protected virtual ECMultiplier CreateBasePointMultiplier()
  {
    return (ECMultiplier) new FixedPointCombMultiplier();
  }

  internal static X9ECParameters FindECCurveByName(string name)
  {
    return CustomNamedCurves.GetByName(name) ?? ECNamedCurveTable.GetByName(name);
  }

  internal static X9ECParametersHolder FindECCurveByNameLazy(string name)
  {
    return CustomNamedCurves.GetByNameLazy(name) ?? ECNamedCurveTable.GetByNameLazy(name);
  }

  internal static X9ECParameters FindECCurveByOid(DerObjectIdentifier oid)
  {
    return CustomNamedCurves.GetByOid(oid) ?? ECNamedCurveTable.GetByOid(oid);
  }

  internal static X9ECParametersHolder FindECCurveByOidLazy(DerObjectIdentifier oid)
  {
    return CustomNamedCurves.GetByOidLazy(oid) ?? ECNamedCurveTable.GetByOidLazy(oid);
  }

  internal static ECPublicKeyParameters GetCorrespondingPublicKey(ECPrivateKeyParameters privKey)
  {
    ECDomainParameters parameters = privKey.Parameters;
    ECPoint q = new FixedPointCombMultiplier().Multiply(parameters.G, privKey.D);
    return privKey.PublicKeyParamSet != null ? new ECPublicKeyParameters(privKey.AlgorithmName, q, privKey.PublicKeyParamSet) : new ECPublicKeyParameters(privKey.AlgorithmName, q, parameters);
  }
}
