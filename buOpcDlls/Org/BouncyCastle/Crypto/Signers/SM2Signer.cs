// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Signers.SM2Signer
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Math.EC;
using Org.BouncyCastle.Math.EC.Multiplier;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.Encoders;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Signers;

public class SM2Signer : ISigner
{
  private readonly IDsaKCalculator kCalculator = (IDsaKCalculator) new RandomDsaKCalculator();
  private readonly IDigest digest;
  private readonly IDsaEncoding encoding;
  private ECDomainParameters ecParams;
  private ECPoint pubPoint;
  private ECKeyParameters ecKey;
  private byte[] z;

  public SM2Signer()
    : this((IDsaEncoding) StandardDsaEncoding.Instance, (IDigest) new SM3Digest())
  {
  }

  public SM2Signer(IDigest digest)
    : this((IDsaEncoding) StandardDsaEncoding.Instance, digest)
  {
  }

  public SM2Signer(IDsaEncoding encoding)
    : this(encoding, (IDigest) new SM3Digest())
  {
  }

  public SM2Signer(IDsaEncoding encoding, IDigest digest)
  {
    this.encoding = encoding;
    this.digest = digest;
  }

  public virtual string AlgorithmName => "SM2Sign";

  public virtual void Init(bool forSigning, ICipherParameters parameters)
  {
    ICipherParameters cipherParameters;
    byte[] userID;
    if (parameters is ParametersWithID parametersWithId)
    {
      cipherParameters = parametersWithId.Parameters;
      userID = parametersWithId.GetID();
      if (userID.Length >= 8192 /*0x2000*/)
        throw new ArgumentException("SM2 user ID must be less than 2^16 bits long");
    }
    else
    {
      cipherParameters = parameters;
      userID = Hex.DecodeStrict("31323334353637383132333435363738");
    }
    if (forSigning)
    {
      SecureRandom secureRandom = (SecureRandom) null;
      if (cipherParameters is ParametersWithRandom parametersWithRandom)
      {
        this.ecKey = (ECKeyParameters) parametersWithRandom.Parameters;
        this.ecParams = this.ecKey.Parameters;
        secureRandom = parametersWithRandom.Random;
      }
      else
      {
        this.ecKey = (ECKeyParameters) cipherParameters;
        this.ecParams = this.ecKey.Parameters;
      }
      if (!this.kCalculator.IsDeterministic)
        secureRandom = CryptoServicesRegistrar.GetSecureRandom(secureRandom);
      this.kCalculator.Init(this.ecParams.N, secureRandom);
      this.pubPoint = this.CreateBasePointMultiplier().Multiply(this.ecParams.G, ((ECPrivateKeyParameters) this.ecKey).D).Normalize();
    }
    else
    {
      this.ecKey = (ECKeyParameters) cipherParameters;
      this.ecParams = this.ecKey.Parameters;
      this.pubPoint = ((ECPublicKeyParameters) this.ecKey).Q;
    }
    this.digest.Reset();
    this.z = this.GetZ(userID);
    this.digest.BlockUpdate(this.z, 0, this.z.Length);
  }

  public virtual void Update(byte b) => this.digest.Update(b);

  public virtual void BlockUpdate(byte[] input, int inOff, int inLen)
  {
    this.digest.BlockUpdate(input, inOff, inLen);
  }

  public virtual int GetMaxSignatureSize() => this.encoding.GetMaxEncodingSize(this.ecParams.N);

  public virtual byte[] GenerateSignature()
  {
    byte[] message = DigestUtilities.DoFinal(this.digest);
    BigInteger n = this.ecParams.N;
    BigInteger e = this.CalculateE(n, message);
    BigInteger d = ((ECPrivateKeyParameters) this.ecKey).D;
    ECMultiplier basePointMultiplier = this.CreateBasePointMultiplier();
    BigInteger r;
    BigInteger s;
    do
    {
      BigInteger k;
      do
      {
        k = this.kCalculator.NextK();
        ECPoint ecPoint = basePointMultiplier.Multiply(this.ecParams.G, k).Normalize();
        r = e.Add(ecPoint.AffineXCoord.ToBigInteger()).Mod(n);
      }
      while (r.SignValue == 0 || r.Add(k).Equals(n));
      s = BigIntegers.ModOddInverse(n, d.Add(BigIntegers.One)).Multiply(k.Subtract(r.Multiply(d)).Mod(n)).Mod(n);
    }
    while (s.SignValue == 0);
    try
    {
      return this.encoding.Encode(this.ecParams.N, r, s);
    }
    catch (Exception ex)
    {
      throw new CryptoException("unable to encode signature: " + ex.Message, ex);
    }
  }

  public virtual bool VerifySignature(byte[] signature)
  {
    try
    {
      BigInteger[] bigIntegerArray = this.encoding.Decode(this.ecParams.N, signature);
      return this.VerifySignature(bigIntegerArray[0], bigIntegerArray[1]);
    }
    catch (Exception ex)
    {
    }
    return false;
  }

  public virtual void Reset()
  {
    if (this.z == null)
      return;
    this.digest.Reset();
    this.digest.BlockUpdate(this.z, 0, this.z.Length);
  }

  private bool VerifySignature(BigInteger r, BigInteger s)
  {
    BigInteger n = this.ecParams.N;
    if (r.CompareTo(BigInteger.One) < 0 || r.CompareTo(n) >= 0 || s.CompareTo(BigInteger.One) < 0 || s.CompareTo(n) >= 0)
      return false;
    byte[] message = DigestUtilities.DoFinal(this.digest);
    BigInteger e = this.CalculateE(n, message);
    BigInteger b = r.Add(s).Mod(n);
    if (b.SignValue == 0)
      return false;
    ECPoint q = ((ECPublicKeyParameters) this.ecKey).Q;
    ECPoint ecPoint = ECAlgorithms.SumOfTwoMultiplies(this.ecParams.G, s, q, b).Normalize();
    return !ecPoint.IsInfinity && r.Equals(e.Add(ecPoint.AffineXCoord.ToBigInteger()).Mod(n));
  }

  private byte[] GetZ(byte[] userID)
  {
    this.AddUserID(this.digest, userID);
    this.AddFieldElement(this.digest, this.ecParams.Curve.A);
    this.AddFieldElement(this.digest, this.ecParams.Curve.B);
    this.AddFieldElement(this.digest, this.ecParams.G.AffineXCoord);
    this.AddFieldElement(this.digest, this.ecParams.G.AffineYCoord);
    this.AddFieldElement(this.digest, this.pubPoint.AffineXCoord);
    this.AddFieldElement(this.digest, this.pubPoint.AffineYCoord);
    return DigestUtilities.DoFinal(this.digest);
  }

  private void AddUserID(IDigest digest, byte[] userID)
  {
    int input = userID.Length * 8;
    digest.Update((byte) (input >> 8));
    digest.Update((byte) input);
    digest.BlockUpdate(userID, 0, userID.Length);
  }

  private void AddFieldElement(IDigest digest, ECFieldElement v)
  {
    byte[] encoded = v.GetEncoded();
    digest.BlockUpdate(encoded, 0, encoded.Length);
  }

  protected virtual BigInteger CalculateE(BigInteger n, byte[] message)
  {
    return new BigInteger(1, message);
  }

  protected virtual ECMultiplier CreateBasePointMultiplier()
  {
    return (ECMultiplier) new FixedPointCombMultiplier();
  }
}
