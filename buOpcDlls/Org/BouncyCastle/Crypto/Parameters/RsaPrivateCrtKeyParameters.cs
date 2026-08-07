// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.RsaPrivateCrtKeyParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Math;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public class RsaPrivateCrtKeyParameters : RsaKeyParameters
{
  private readonly BigInteger e;
  private readonly BigInteger p;
  private readonly BigInteger q;
  private readonly BigInteger dP;
  private readonly BigInteger dQ;
  private readonly BigInteger qInv;

  public RsaPrivateCrtKeyParameters(
    BigInteger modulus,
    BigInteger publicExponent,
    BigInteger privateExponent,
    BigInteger p,
    BigInteger q,
    BigInteger dP,
    BigInteger dQ,
    BigInteger qInv)
    : base(true, modulus, privateExponent)
  {
    RsaPrivateCrtKeyParameters.ValidateValue(publicExponent, nameof (publicExponent), "exponent");
    RsaPrivateCrtKeyParameters.ValidateValue(p, nameof (p), "P value");
    RsaPrivateCrtKeyParameters.ValidateValue(q, nameof (q), "Q value");
    RsaPrivateCrtKeyParameters.ValidateValue(dP, nameof (dP), "DP value");
    RsaPrivateCrtKeyParameters.ValidateValue(dQ, nameof (dQ), "DQ value");
    RsaPrivateCrtKeyParameters.ValidateValue(qInv, nameof (qInv), "InverseQ value");
    this.e = publicExponent;
    this.p = p;
    this.q = q;
    this.dP = dP;
    this.dQ = dQ;
    this.qInv = qInv;
  }

  public RsaPrivateCrtKeyParameters(RsaPrivateKeyStructure rsaPrivateKey)
    : this(rsaPrivateKey.Modulus, rsaPrivateKey.PublicExponent, rsaPrivateKey.PrivateExponent, rsaPrivateKey.Prime1, rsaPrivateKey.Prime2, rsaPrivateKey.Exponent1, rsaPrivateKey.Exponent2, rsaPrivateKey.Coefficient)
  {
  }

  public BigInteger PublicExponent => this.e;

  public BigInteger P => this.p;

  public BigInteger Q => this.q;

  public BigInteger DP => this.dP;

  public BigInteger DQ => this.dQ;

  public BigInteger QInv => this.qInv;

  public override bool Equals(object obj)
  {
    if (obj == this)
      return true;
    return obj is RsaPrivateCrtKeyParameters crtKeyParameters && crtKeyParameters.DP.Equals(this.dP) && crtKeyParameters.DQ.Equals(this.dQ) && crtKeyParameters.Exponent.Equals(this.Exponent) && crtKeyParameters.Modulus.Equals(this.Modulus) && crtKeyParameters.P.Equals(this.p) && crtKeyParameters.Q.Equals(this.q) && crtKeyParameters.PublicExponent.Equals(this.e) && crtKeyParameters.QInv.Equals(this.qInv);
  }

  public override int GetHashCode()
  {
    return this.DP.GetHashCode() ^ this.DQ.GetHashCode() ^ this.Exponent.GetHashCode() ^ this.Modulus.GetHashCode() ^ this.P.GetHashCode() ^ this.Q.GetHashCode() ^ this.PublicExponent.GetHashCode() ^ this.QInv.GetHashCode();
  }

  private static void ValidateValue(BigInteger x, string name, string desc)
  {
    if (x == null)
      throw new ArgumentNullException(name);
    if (x.SignValue <= 0)
      throw new ArgumentException("Not a valid RSA " + desc, name);
  }
}
