// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.AttributeCertificate
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class AttributeCertificate : Asn1Encodable
{
  private readonly AttributeCertificateInfo acinfo;
  private readonly AlgorithmIdentifier signatureAlgorithm;
  private readonly DerBitString signatureValue;

  public static AttributeCertificate GetInstance(object obj)
  {
    if (obj == null)
      return (AttributeCertificate) null;
    return obj is AttributeCertificate attributeCertificate ? attributeCertificate : new AttributeCertificate(Asn1Sequence.GetInstance(obj));
  }

  public static AttributeCertificate GetInstance(
    Asn1TaggedObject taggedObject,
    bool declaredExplicit)
  {
    return new AttributeCertificate(Asn1Sequence.GetInstance(taggedObject, declaredExplicit));
  }

  public AttributeCertificate(
    AttributeCertificateInfo acinfo,
    AlgorithmIdentifier signatureAlgorithm,
    DerBitString signatureValue)
  {
    this.acinfo = acinfo;
    this.signatureAlgorithm = signatureAlgorithm;
    this.signatureValue = signatureValue;
  }

  private AttributeCertificate(Asn1Sequence seq)
  {
    this.acinfo = seq.Count == 3 ? AttributeCertificateInfo.GetInstance((object) seq[0]) : throw new ArgumentException("Bad sequence size: " + seq.Count.ToString());
    this.signatureAlgorithm = AlgorithmIdentifier.GetInstance((object) seq[1]);
    this.signatureValue = DerBitString.GetInstance((object) seq[2]);
  }

  public AttributeCertificateInfo ACInfo => this.acinfo;

  public AlgorithmIdentifier SignatureAlgorithm => this.signatureAlgorithm;

  public DerBitString SignatureValue => this.signatureValue;

  public byte[] GetSignatureOctets() => this.signatureValue.GetOctets();

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence(new Asn1Encodable[3]
    {
      (Asn1Encodable) this.acinfo,
      (Asn1Encodable) this.signatureAlgorithm,
      (Asn1Encodable) this.signatureValue
    });
  }
}
