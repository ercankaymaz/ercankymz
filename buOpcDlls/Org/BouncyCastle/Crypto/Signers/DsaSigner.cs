// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Signers.DsaSigner
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;

#nullable disable
namespace Org.BouncyCastle.Crypto.Signers;

public class DsaSigner : IDsa
{
  protected readonly IDsaKCalculator kCalculator;
  protected DsaKeyParameters key;
  protected SecureRandom random;

  public DsaSigner() => this.kCalculator = (IDsaKCalculator) new RandomDsaKCalculator();

  public DsaSigner(IDsaKCalculator kCalculator) => this.kCalculator = kCalculator;

  public virtual string AlgorithmName => "DSA";

  public virtual void Init(bool forSigning, ICipherParameters parameters)
  {
    SecureRandom provided = (SecureRandom) null;
    if (forSigning)
    {
      if (parameters is ParametersWithRandom parametersWithRandom)
      {
        provided = parametersWithRandom.Random;
        parameters = parametersWithRandom.Parameters;
      }
      this.key = parameters is DsaPrivateKeyParameters privateKeyParameters ? (DsaKeyParameters) privateKeyParameters : throw new InvalidKeyException("DSA private key required for signing");
    }
    else
      this.key = parameters is DsaPublicKeyParameters publicKeyParameters ? (DsaKeyParameters) publicKeyParameters : throw new InvalidKeyException("DSA public key required for verification");
    this.random = this.InitSecureRandom(forSigning && !this.kCalculator.IsDeterministic, provided);
  }

  public virtual BigInteger Order => this.key.Parameters.Q;

  public virtual BigInteger[] GenerateSignature(byte[] message)
  {
    DsaParameters parameters = this.key.Parameters;
    BigInteger q = parameters.Q;
    BigInteger e = this.CalculateE(q, message);
    BigInteger x = ((DsaPrivateKeyParameters) this.key).X;
    if (this.kCalculator.IsDeterministic)
      this.kCalculator.Init(q, x, message);
    else
      this.kCalculator.Init(q, this.random);
    BigInteger bigInteger1 = this.kCalculator.NextK();
    BigInteger val = parameters.G.ModPow(bigInteger1, parameters.P).Mod(q);
    BigInteger bigInteger2 = BigIntegers.ModOddInverse(q, bigInteger1).Multiply(e.Add(x.Multiply(val))).Mod(q);
    return new BigInteger[2]{ val, bigInteger2 };
  }

  public virtual bool VerifySignature(byte[] message, BigInteger r, BigInteger s)
  {
    DsaParameters parameters = this.key.Parameters;
    BigInteger q = parameters.Q;
    BigInteger e1 = this.CalculateE(q, message);
    if (r.SignValue <= 0 || q.CompareTo(r) <= 0 || s.SignValue <= 0 || q.CompareTo(s) <= 0)
      return false;
    BigInteger val = BigIntegers.ModOddInverseVar(q, s);
    BigInteger e2 = e1.Multiply(val).Mod(q);
    BigInteger e3 = r.Multiply(val).Mod(q);
    BigInteger p = parameters.P;
    return parameters.G.ModPow(e2, p).Multiply(((DsaPublicKeyParameters) this.key).Y.ModPow(e3, p)).Mod(p).Mod(q).Equals(r);
  }

  protected virtual BigInteger CalculateE(BigInteger n, byte[] message)
  {
    int length = System.Math.Min(message.Length, n.BitLength / 8);
    return new BigInteger(1, message, 0, length);
  }

  protected virtual SecureRandom InitSecureRandom(bool needed, SecureRandom provided)
  {
    return needed ? CryptoServicesRegistrar.GetSecureRandom(provided) : (SecureRandom) null;
  }
}
