// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Crmf.CertTemplate
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Crmf;

public class CertTemplate : Asn1Encodable
{
  private readonly Asn1Sequence seq;
  private readonly DerInteger version;
  private readonly DerInteger serialNumber;
  private readonly AlgorithmIdentifier signingAlg;
  private readonly X509Name issuer;
  private readonly OptionalValidity validity;
  private readonly X509Name subject;
  private readonly SubjectPublicKeyInfo publicKey;
  private readonly DerBitString issuerUID;
  private readonly DerBitString subjectUID;
  private readonly X509Extensions extensions;

  private CertTemplate(Asn1Sequence seq)
  {
    this.seq = seq;
    foreach (Asn1TaggedObject taggedObject in seq)
    {
      switch (taggedObject.TagNo)
      {
        case 0:
          this.version = DerInteger.GetInstance(taggedObject, false);
          continue;
        case 1:
          this.serialNumber = DerInteger.GetInstance(taggedObject, false);
          continue;
        case 2:
          this.signingAlg = AlgorithmIdentifier.GetInstance(taggedObject, false);
          continue;
        case 3:
          this.issuer = X509Name.GetInstance(taggedObject, true);
          continue;
        case 4:
          this.validity = OptionalValidity.GetInstance((object) Asn1Sequence.GetInstance(taggedObject, false));
          continue;
        case 5:
          this.subject = X509Name.GetInstance(taggedObject, true);
          continue;
        case 6:
          this.publicKey = SubjectPublicKeyInfo.GetInstance(taggedObject, false);
          continue;
        case 7:
          this.issuerUID = DerBitString.GetInstance(taggedObject, false);
          continue;
        case 8:
          this.subjectUID = DerBitString.GetInstance(taggedObject, false);
          continue;
        case 9:
          this.extensions = X509Extensions.GetInstance(taggedObject, false);
          continue;
        default:
          throw new ArgumentException("unknown tag: " + taggedObject.TagNo.ToString(), nameof (seq));
      }
    }
  }

  public static CertTemplate GetInstance(object obj)
  {
    if (obj is CertTemplate)
      return (CertTemplate) obj;
    return obj != null ? new CertTemplate(Asn1Sequence.GetInstance(obj)) : (CertTemplate) null;
  }

  public virtual int Version => this.version.IntValueExact;

  public virtual DerInteger SerialNumber => this.serialNumber;

  public virtual AlgorithmIdentifier SigningAlg => this.signingAlg;

  public virtual X509Name Issuer => this.issuer;

  public virtual OptionalValidity Validity => this.validity;

  public virtual X509Name Subject => this.subject;

  public virtual SubjectPublicKeyInfo PublicKey => this.publicKey;

  public virtual DerBitString IssuerUID => this.issuerUID;

  public virtual DerBitString SubjectUID => this.subjectUID;

  public virtual X509Extensions Extensions => this.extensions;

  public override Asn1Object ToAsn1Object() => (Asn1Object) this.seq;
}
