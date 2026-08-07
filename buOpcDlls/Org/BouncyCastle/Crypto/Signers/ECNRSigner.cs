// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Signers.ECNRSigner
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Math.EC;
using Org.BouncyCastle.Security;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Signers;

public class ECNRSigner : IDsa
{
  private bool forSigning;
  private ECKeyParameters key;
  private SecureRandom random;

  public virtual string AlgorithmName => "ECNR";

  public virtual void Init(bool forSigning, ICipherParameters parameters)
  {
    this.forSigning = forSigning;
    if (forSigning)
    {
      if (parameters is ParametersWithRandom parametersWithRandom)
      {
        this.random = parametersWithRandom.Random;
        parameters = parametersWithRandom.Parameters;
      }
      else
        this.random = CryptoServicesRegistrar.GetSecureRandom();
      this.key = parameters is ECPrivateKeyParameters ? (ECKeyParameters) parameters : throw new InvalidKeyException("EC private key required for signing");
    }
    else
      this.key = parameters is ECPublicKeyParameters ? (ECKeyParameters) parameters : throw new InvalidKeyException("EC public key required for verification");
  }

  public virtual BigInteger Order => this.key.Parameters.N;

  public virtual BigInteger[] GenerateSignature(byte[] message)
  {
    if (!this.forSigning)
      throw new InvalidOperationException("not initialised for signing");
    BigInteger order = this.Order;
    int bitLength1 = order.BitLength;
    BigInteger bigInteger1 = new BigInteger(1, message);
    int bitLength2 = bigInteger1.BitLength;
    ECPrivateKeyParameters key = (ECPrivateKeyParameters) this.key;
    int num = bitLength1;
    if (bitLength2 > num)
      throw new DataLengthException("input too large for ECNR key.");
    AsymmetricCipherKeyPair keyPair;
    BigInteger bigInteger2;
    do
    {
      ECKeyPairGenerator keyPairGenerator = new ECKeyPairGenerator();
      keyPairGenerator.Init((KeyGenerationParameters) new ECKeyGenerationParameters(key.Parameters, this.random));
      keyPair = keyPairGenerator.GenerateKeyPair();
      bigInteger2 = ((ECPublicKeyParameters) keyPair.Public).Q.AffineXCoord.ToBigInteger().Add(bigInteger1).Mod(order);
    }
    while (bigInteger2.SignValue == 0);
    BigInteger d = key.D;
    BigInteger bigInteger3 = ((ECPrivateKeyParameters) keyPair.Private).D.Subtract(bigInteger2.Multiply(d)).Mod(order);
    return new BigInteger[2]{ bigInteger2, bigInteger3 };
  }

  public virtual bool VerifySignature(byte[] message, BigInteger r, BigInteger s)
  {
    if (this.forSigning)
      throw new InvalidOperationException("not initialised for verifying");
    ECPublicKeyParameters key = (ECPublicKeyParameters) this.key;
    BigInteger n = key.Parameters.N;
    int bitLength = n.BitLength;
    BigInteger other = new BigInteger(1, message);
    if (other.BitLength > bitLength)
      throw new DataLengthException("input too large for ECNR key.");
    if (r.CompareTo(BigInteger.One) < 0 || r.CompareTo(n) >= 0 || s.CompareTo(BigInteger.Zero) < 0 || s.CompareTo(n) >= 0)
      return false;
    ECPoint g = key.Parameters.G;
    ECPoint q = key.Q;
    ECPoint ecPoint = ECAlgorithms.SumOfTwoMultiplies(g, s, q, r).Normalize();
    if (ecPoint.IsInfinity)
      return false;
    BigInteger bigInteger = ecPoint.AffineXCoord.ToBigInteger();
    return r.Subtract(bigInteger).Mod(n).Equals(other);
  }
}
