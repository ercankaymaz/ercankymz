// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.RsaPublicKeyStructure
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class RsaPublicKeyStructure : Asn1Encodable
{
  private BigInteger modulus;
  private BigInteger publicExponent;

  public static RsaPublicKeyStructure GetInstance(Asn1TaggedObject obj, bool explicitly)
  {
    return RsaPublicKeyStructure.GetInstance((object) Asn1Sequence.GetInstance(obj, explicitly));
  }

  public static RsaPublicKeyStructure GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case RsaPublicKeyStructure _:
        return (RsaPublicKeyStructure) obj;
      case Asn1Sequence _:
        return new RsaPublicKeyStructure((Asn1Sequence) obj);
      default:
        throw new ArgumentException("Invalid RsaPublicKeyStructure: " + Platform.GetTypeName(obj));
    }
  }

  public RsaPublicKeyStructure(BigInteger modulus, BigInteger publicExponent)
  {
    if (modulus == null)
      throw new ArgumentNullException(nameof (modulus));
    if (publicExponent == null)
      throw new ArgumentNullException(nameof (publicExponent));
    if (modulus.SignValue <= 0)
      throw new ArgumentException("Not a valid RSA modulus", nameof (modulus));
    if (publicExponent.SignValue <= 0)
      throw new ArgumentException("Not a valid RSA public exponent", nameof (publicExponent));
    this.modulus = modulus;
    this.publicExponent = publicExponent;
  }

  private RsaPublicKeyStructure(Asn1Sequence seq)
  {
    this.modulus = seq.Count == 2 ? DerInteger.GetInstance((object) seq[0]).PositiveValue : throw new ArgumentException("Bad sequence size: " + seq.Count.ToString());
    this.publicExponent = DerInteger.GetInstance((object) seq[1]).PositiveValue;
  }

  public BigInteger Modulus => this.modulus;

  public BigInteger PublicExponent => this.publicExponent;

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence((Asn1Encodable) new DerInteger(this.Modulus), (Asn1Encodable) new DerInteger(this.PublicExponent));
  }
}
