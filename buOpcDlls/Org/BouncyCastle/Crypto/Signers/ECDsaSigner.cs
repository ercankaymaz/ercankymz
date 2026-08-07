// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Signers.ECDsaSigner
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Math.EC;
using Org.BouncyCastle.Math.EC.Multiplier;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;

#nullable disable
namespace Org.BouncyCastle.Crypto.Signers;

public class ECDsaSigner : IDsa
{
  private static readonly BigInteger Eight = BigInteger.ValueOf(8L);
  protected readonly IDsaKCalculator kCalculator;
  protected ECKeyParameters key;
  protected SecureRandom random;

  public ECDsaSigner() => this.kCalculator = (IDsaKCalculator) new RandomDsaKCalculator();

  public ECDsaSigner(IDsaKCalculator kCalculator) => this.kCalculator = kCalculator;

  public virtual string AlgorithmName => "ECDSA";

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
      this.key = parameters is ECPrivateKeyParameters privateKeyParameters ? (ECKeyParameters) privateKeyParameters : throw new InvalidKeyException("EC private key required for signing");
    }
    else
      this.key = parameters is ECPublicKeyParameters publicKeyParameters ? (ECKeyParameters) publicKeyParameters : throw new InvalidKeyException("EC public key required for verification");
    this.random = this.InitSecureRandom(forSigning && !this.kCalculator.IsDeterministic, provided);
  }

  public virtual BigInteger Order => this.key.Parameters.N;

  public virtual BigInteger[] GenerateSignature(byte[] message)
  {
    ECDomainParameters parameters = this.key.Parameters;
    BigInteger n = parameters.N;
    BigInteger e = this.CalculateE(n, message);
    BigInteger d = ((ECPrivateKeyParameters) this.key).D;
    if (this.kCalculator.IsDeterministic)
      this.kCalculator.Init(n, d, message);
    else
      this.kCalculator.Init(n, this.random);
    ECMultiplier basePointMultiplier = this.CreateBasePointMultiplier();
    BigInteger val;
    BigInteger bigInteger1;
    do
    {
      BigInteger bigInteger2;
      do
      {
        bigInteger2 = this.kCalculator.NextK();
        val = basePointMultiplier.Multiply(parameters.G, bigInteger2).Normalize().AffineXCoord.ToBigInteger().Mod(n);
      }
      while (val.SignValue == 0);
      bigInteger1 = BigIntegers.ModOddInverse(n, bigInteger2).Multiply(e.Add(d.Multiply(val))).Mod(n);
    }
    while (bigInteger1.SignValue == 0);
    return new BigInteger[2]{ val, bigInteger1 };
  }

  public virtual bool VerifySignature(byte[] message, BigInteger r, BigInteger s)
  {
    BigInteger n = this.key.Parameters.N;
    if (r.SignValue < 1 || s.SignValue < 1 || r.CompareTo(n) >= 0 || s.CompareTo(n) >= 0)
      return false;
    BigInteger e = this.CalculateE(n, message);
    BigInteger val1 = BigIntegers.ModOddInverseVar(n, s);
    BigInteger val2 = val1;
    BigInteger bigInteger1 = e.Multiply(val2).Mod(n);
    BigInteger bigInteger2 = r.Multiply(val1).Mod(n);
    ECPoint g = this.key.Parameters.G;
    ECPoint q = ((ECPublicKeyParameters) this.key).Q;
    BigInteger a = bigInteger1;
    ECPoint Q = q;
    BigInteger b = bigInteger2;
    ECPoint p = ECAlgorithms.SumOfTwoMultiplies(g, a, Q, b);
    if (p.IsInfinity)
      return false;
    ECCurve curve = p.Curve;
    if (curve != null)
    {
      BigInteger cofactor = curve.Cofactor;
      if (cofactor != null && cofactor.CompareTo(ECDsaSigner.Eight) <= 0)
      {
        ECFieldElement denominator = this.GetDenominator(curve.CoordinateSystem, p);
        if (denominator != null && !denominator.IsZero)
        {
          ECFieldElement xcoord = p.XCoord;
          for (; curve.IsValidFieldElement(r); r = r.Add(n))
          {
            if (curve.FromBigInteger(r).Multiply(denominator).Equals(xcoord))
              return true;
          }
          return false;
        }
      }
    }
    return p.Normalize().AffineXCoord.ToBigInteger().Mod(n).Equals(r);
  }

  protected virtual BigInteger CalculateE(BigInteger n, byte[] message)
  {
    int num = message.Length * 8;
    BigInteger e = new BigInteger(1, message);
    if (n.BitLength < num)
      e = e.ShiftRight(num - n.BitLength);
    return e;
  }

  protected virtual ECMultiplier CreateBasePointMultiplier()
  {
    return (ECMultiplier) new FixedPointCombMultiplier();
  }

  protected virtual ECFieldElement GetDenominator(int coordinateSystem, ECPoint p)
  {
    switch (coordinateSystem)
    {
      case 1:
      case 6:
      case 7:
        return p.GetZCoord(0);
      case 2:
      case 3:
      case 4:
        return p.GetZCoord(0).Square();
      default:
        return (ECFieldElement) null;
    }
  }

  protected virtual SecureRandom InitSecureRandom(bool needed, SecureRandom provided)
  {
    return needed ? CryptoServicesRegistrar.GetSecureRandom(provided) : (SecureRandom) null;
  }
}
