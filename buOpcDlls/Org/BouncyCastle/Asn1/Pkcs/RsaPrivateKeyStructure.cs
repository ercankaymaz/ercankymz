// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Pkcs.RsaPrivateKeyStructure
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Pkcs;

public class RsaPrivateKeyStructure : Asn1Encodable
{
  private readonly BigInteger modulus;
  private readonly BigInteger publicExponent;
  private readonly BigInteger privateExponent;
  private readonly BigInteger prime1;
  private readonly BigInteger prime2;
  private readonly BigInteger exponent1;
  private readonly BigInteger exponent2;
  private readonly BigInteger coefficient;

  public static RsaPrivateKeyStructure GetInstance(Asn1TaggedObject obj, bool isExplicit)
  {
    return RsaPrivateKeyStructure.GetInstance((object) Asn1Sequence.GetInstance(obj, isExplicit));
  }

  public static RsaPrivateKeyStructure GetInstance(object obj)
  {
    if (obj == null)
      return (RsaPrivateKeyStructure) null;
    return obj is RsaPrivateKeyStructure ? (RsaPrivateKeyStructure) obj : new RsaPrivateKeyStructure(Asn1Sequence.GetInstance(obj));
  }

  public RsaPrivateKeyStructure(
    BigInteger modulus,
    BigInteger publicExponent,
    BigInteger privateExponent,
    BigInteger prime1,
    BigInteger prime2,
    BigInteger exponent1,
    BigInteger exponent2,
    BigInteger coefficient)
  {
    this.modulus = modulus;
    this.publicExponent = publicExponent;
    this.privateExponent = privateExponent;
    this.prime1 = prime1;
    this.prime2 = prime2;
    this.exponent1 = exponent1;
    this.exponent2 = exponent2;
    this.coefficient = coefficient;
  }

  private RsaPrivateKeyStructure(Asn1Sequence seq)
  {
    if (((DerInteger) seq[0]).Value.IntValue != 0)
      throw new ArgumentException("wrong version for RSA private key");
    this.modulus = ((DerInteger) seq[1]).Value;
    this.publicExponent = ((DerInteger) seq[2]).Value;
    this.privateExponent = ((DerInteger) seq[3]).Value;
    this.prime1 = ((DerInteger) seq[4]).Value;
    this.prime2 = ((DerInteger) seq[5]).Value;
    this.exponent1 = ((DerInteger) seq[6]).Value;
    this.exponent2 = ((DerInteger) seq[7]).Value;
    this.coefficient = ((DerInteger) seq[8]).Value;
  }

  public BigInteger Modulus => this.modulus;

  public BigInteger PublicExponent => this.publicExponent;

  public BigInteger PrivateExponent => this.privateExponent;

  public BigInteger Prime1 => this.prime1;

  public BigInteger Prime2 => this.prime2;

  public BigInteger Exponent1 => this.exponent1;

  public BigInteger Exponent2 => this.exponent2;

  public BigInteger Coefficient => this.coefficient;

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence(new Asn1Encodable[9]
    {
      (Asn1Encodable) new DerInteger(0),
      (Asn1Encodable) new DerInteger(this.Modulus),
      (Asn1Encodable) new DerInteger(this.PublicExponent),
      (Asn1Encodable) new DerInteger(this.PrivateExponent),
      (Asn1Encodable) new DerInteger(this.Prime1),
      (Asn1Encodable) new DerInteger(this.Prime2),
      (Asn1Encodable) new DerInteger(this.Exponent1),
      (Asn1Encodable) new DerInteger(this.Exponent2),
      (Asn1Encodable) new DerInteger(this.Coefficient)
    });
  }
}
