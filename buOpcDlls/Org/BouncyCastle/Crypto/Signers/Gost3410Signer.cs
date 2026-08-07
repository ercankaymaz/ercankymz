// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Signers.Gost3410Signer
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Signers;

public class Gost3410Signer : IDsa
{
  private Gost3410KeyParameters key;
  private SecureRandom random;

  public virtual string AlgorithmName => "GOST3410";

  public virtual void Init(bool forSigning, ICipherParameters parameters)
  {
    if (forSigning)
    {
      if (parameters is ParametersWithRandom parametersWithRandom)
      {
        this.random = parametersWithRandom.Random;
        parameters = parametersWithRandom.Parameters;
      }
      else
        this.random = CryptoServicesRegistrar.GetSecureRandom();
      this.key = parameters is Gost3410PrivateKeyParameters ? (Gost3410KeyParameters) parameters : throw new InvalidKeyException("GOST3410 private key required for signing");
    }
    else
      this.key = parameters is Gost3410PublicKeyParameters ? (Gost3410KeyParameters) parameters : throw new InvalidKeyException("GOST3410 public key required for signing");
  }

  public virtual BigInteger Order => this.key.Parameters.Q;

  public virtual BigInteger[] GenerateSignature(byte[] message)
  {
    BigInteger val1 = new BigInteger(1, Arrays.Reverse(message));
    Gost3410Parameters parameters = this.key.Parameters;
    BigInteger e;
    do
    {
      e = new BigInteger(parameters.Q.BitLength, (Random) this.random);
    }
    while (e.CompareTo(parameters.Q) >= 0);
    BigInteger val2 = parameters.A.ModPow(e, parameters.P).Mod(parameters.Q);
    BigInteger bigInteger = e.Multiply(val1).Add(((Gost3410PrivateKeyParameters) this.key).X.Multiply(val2)).Mod(parameters.Q);
    return new BigInteger[2]{ val2, bigInteger };
  }

  public virtual bool VerifySignature(byte[] message, BigInteger r, BigInteger s)
  {
    BigInteger bigInteger = new BigInteger(1, Arrays.Reverse(message));
    Gost3410Parameters parameters = this.key.Parameters;
    if (r.SignValue < 0 || parameters.Q.CompareTo(r) <= 0 || s.SignValue < 0 || parameters.Q.CompareTo(s) <= 0)
      return false;
    BigInteger val = bigInteger.ModPow(parameters.Q.Subtract(BigInteger.Two), parameters.Q);
    BigInteger e1 = s.Multiply(val).Mod(parameters.Q);
    BigInteger e2 = parameters.Q.Subtract(r).Multiply(val).Mod(parameters.Q);
    return parameters.A.ModPow(e1, parameters.P).Multiply(((Gost3410PublicKeyParameters) this.key).Y.ModPow(e2, parameters.P)).Mod(parameters.P).Mod(parameters.Q).Equals(r);
  }
}
