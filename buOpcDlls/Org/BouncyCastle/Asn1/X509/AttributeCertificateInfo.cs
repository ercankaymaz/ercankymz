// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.AttributeCertificateInfo
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class AttributeCertificateInfo : Asn1Encodable
{
  internal readonly DerInteger version;
  internal readonly Holder holder;
  internal readonly AttCertIssuer issuer;
  internal readonly AlgorithmIdentifier signature;
  internal readonly DerInteger serialNumber;
  internal readonly AttCertValidityPeriod attrCertValidityPeriod;
  internal readonly Asn1Sequence attributes;
  internal readonly DerBitString issuerUniqueID;
  internal readonly X509Extensions extensions;

  public static AttributeCertificateInfo GetInstance(Asn1TaggedObject obj, bool isExplicit)
  {
    return AttributeCertificateInfo.GetInstance((object) Asn1Sequence.GetInstance(obj, isExplicit));
  }

  public static AttributeCertificateInfo GetInstance(object obj)
  {
    switch (obj)
    {
      case AttributeCertificateInfo _:
        return (AttributeCertificateInfo) obj;
      case Asn1Sequence _:
        return new AttributeCertificateInfo((Asn1Sequence) obj);
      default:
        throw new ArgumentException("unknown object in factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  private AttributeCertificateInfo(Asn1Sequence seq)
  {
    if (seq.Count < 6 || seq.Count > 9)
      throw new ArgumentException("Bad sequence size: " + seq.Count.ToString());
    int index1;
    if (seq[0] is DerInteger)
    {
      this.version = DerInteger.GetInstance((object) seq[0]);
      index1 = 1;
    }
    else
    {
      this.version = new DerInteger(0);
      index1 = 0;
    }
    this.holder = Holder.GetInstance((object) seq[index1]);
    this.issuer = AttCertIssuer.GetInstance((object) seq[index1 + 1]);
    this.signature = AlgorithmIdentifier.GetInstance((object) seq[index1 + 2]);
    this.serialNumber = DerInteger.GetInstance((object) seq[index1 + 3]);
    this.attrCertValidityPeriod = AttCertValidityPeriod.GetInstance((object) seq[index1 + 4]);
    this.attributes = Asn1Sequence.GetInstance((object) seq[index1 + 5]);
    for (int index2 = index1 + 6; index2 < seq.Count; ++index2)
    {
      switch (seq[index2])
      {
        case DerBitString derBitString:
          this.issuerUniqueID = derBitString;
          break;
        case Asn1Sequence _:
        case X509Extensions _:
          this.extensions = X509Extensions.GetInstance((object) seq[index2]);
          break;
      }
    }
  }

  public DerInteger Version => this.version;

  public Holder Holder => this.holder;

  public AttCertIssuer Issuer => this.issuer;

  public AlgorithmIdentifier Signature => this.signature;

  public DerInteger SerialNumber => this.serialNumber;

  public AttCertValidityPeriod AttrCertValidityPeriod => this.attrCertValidityPeriod;

  public Asn1Sequence Attributes => this.attributes;

  public DerBitString IssuerUniqueID => this.issuerUniqueID;

  public X509Extensions Extensions => this.extensions;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(9);
    if (!this.version.HasValue(0))
      elementVector.Add((Asn1Encodable) this.version);
    elementVector.Add((Asn1Encodable) this.holder, (Asn1Encodable) this.issuer, (Asn1Encodable) this.signature, (Asn1Encodable) this.serialNumber, (Asn1Encodable) this.attrCertValidityPeriod, (Asn1Encodable) this.attributes);
    elementVector.AddOptional((Asn1Encodable) this.issuerUniqueID, (Asn1Encodable) this.extensions);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
