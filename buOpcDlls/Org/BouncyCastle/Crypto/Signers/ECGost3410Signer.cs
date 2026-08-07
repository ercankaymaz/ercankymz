// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Signers.ECGost3410Signer
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Math.EC;
using Org.BouncyCastle.Math.EC.Multiplier;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Signers;

public class ECGost3410Signer : IDsa
{
  private ECKeyParameters key;
  private SecureRandom random;
  private bool forSigning;

  public virtual string AlgorithmName => this.key.AlgorithmName;

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
      this.key = parameters is ECPrivateKeyParameters privateKeyParameters ? (ECKeyParameters) privateKeyParameters : throw new InvalidKeyException("EC private key required for signing");
    }
    else
      this.key = parameters is ECPublicKeyParameters publicKeyParameters ? (ECKeyParameters) publicKeyParameters : throw new InvalidKeyException("EC public key required for verification");
  }

  public virtual BigInteger Order => this.key.Parameters.N;

  public virtual BigInteger[] GenerateSignature(byte[] message)
  {
    if (!this.forSigning)
      throw new InvalidOperationException("not initialized for signing");
    BigInteger val1 = new BigInteger(1, Arrays.Reverse(message));
    ECDomainParameters parameters = this.key.Parameters;
    BigInteger n = parameters.N;
    BigInteger d = ((ECPrivateKeyParameters) this.key).D;
    ECMultiplier basePointMultiplier = this.CreateBasePointMultiplier();
    BigInteger val2;
    BigInteger bigInteger;
    do
    {
      BigInteger randomBigInteger;
      do
      {
        do
        {
          randomBigInteger = BigIntegers.CreateRandomBigInteger(n.BitLength, this.random);
        }
        while (randomBigInteger.SignValue == 0);
        val2 = basePointMultiplier.Multiply(parameters.G, randomBigInteger).Normalize().AffineXCoord.ToBigInteger().Mod(n);
      }
      while (val2.SignValue == 0);
      bigInteger = randomBigInteger.Multiply(val1).Add(d.Multiply(val2)).Mod(n);
    }
    while (bigInteger.SignValue == 0);
    return new BigInteger[2]{ val2, bigInteger };
  }

  public virtual bool VerifySignature(byte[] message, BigInteger r, BigInteger s)
  {
    if (this.forSigning)
      throw new InvalidOperationException("not initialized for verification");
    BigInteger X = new BigInteger(1, Arrays.Reverse(message));
    BigInteger n = this.key.Parameters.N;
    if (r.CompareTo(BigInteger.One) < 0 || r.CompareTo(n) >= 0 || s.CompareTo(BigInteger.One) < 0 || s.CompareTo(n) >= 0)
      return false;
    BigInteger val = BigIntegers.ModOddInverseVar(n, X);
    BigInteger bigInteger1 = s.Multiply(val).Mod(n);
    BigInteger bigInteger2 = n.Subtract(r).Multiply(val).Mod(n);
    ECPoint g = this.key.Parameters.G;
    ECPoint q = ((ECPublicKeyParameters) this.key).Q;
    BigInteger a = bigInteger1;
    ECPoint Q = q;
    BigInteger b = bigInteger2;
    ECPoint ecPoint = ECAlgorithms.SumOfTwoMultiplies(g, a, Q, b).Normalize();
    return !ecPoint.IsInfinity && ecPoint.AffineXCoord.ToBigInteger().Mod(n).Equals(r);
  }

  protected virtual ECMultiplier CreateBasePointMultiplier()
  {
    return (ECMultiplier) new FixedPointCombMultiplier();
  }
}
