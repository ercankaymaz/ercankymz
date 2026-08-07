// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Crmf.CertTemplateBuilder
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;

#nullable disable
namespace Org.BouncyCastle.Asn1.Crmf;

public class CertTemplateBuilder
{
  private DerInteger version;
  private DerInteger serialNumber;
  private AlgorithmIdentifier signingAlg;
  private X509Name issuer;
  private OptionalValidity validity;
  private X509Name subject;
  private SubjectPublicKeyInfo publicKey;
  private DerBitString issuerUID;
  private DerBitString subjectUID;
  private X509Extensions extensions;

  public virtual CertTemplateBuilder SetVersion(int ver)
  {
    this.version = new DerInteger(ver);
    return this;
  }

  public virtual CertTemplateBuilder SetSerialNumber(DerInteger ser)
  {
    this.serialNumber = ser;
    return this;
  }

  public virtual CertTemplateBuilder SetSigningAlg(AlgorithmIdentifier aid)
  {
    this.signingAlg = aid;
    return this;
  }

  public virtual CertTemplateBuilder SetIssuer(X509Name name)
  {
    this.issuer = name;
    return this;
  }

  public virtual CertTemplateBuilder SetValidity(OptionalValidity v)
  {
    this.validity = v;
    return this;
  }

  public virtual CertTemplateBuilder SetSubject(X509Name name)
  {
    this.subject = name;
    return this;
  }

  public virtual CertTemplateBuilder SetPublicKey(SubjectPublicKeyInfo spki)
  {
    this.publicKey = spki;
    return this;
  }

  public virtual CertTemplateBuilder SetIssuerUID(DerBitString uid)
  {
    this.issuerUID = uid;
    return this;
  }

  public virtual CertTemplateBuilder SetSubjectUID(DerBitString uid)
  {
    this.subjectUID = uid;
    return this;
  }

  public virtual CertTemplateBuilder SetExtensions(X509Extensions extens)
  {
    this.extensions = extens;
    return this;
  }

  public virtual CertTemplate Build()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(10);
    elementVector.AddOptionalTagged(false, 0, (Asn1Encodable) this.version);
    elementVector.AddOptionalTagged(false, 1, (Asn1Encodable) this.serialNumber);
    elementVector.AddOptionalTagged(false, 2, (Asn1Encodable) this.signingAlg);
    elementVector.AddOptionalTagged(true, 3, (Asn1Encodable) this.issuer);
    elementVector.AddOptionalTagged(false, 4, (Asn1Encodable) this.validity);
    elementVector.AddOptionalTagged(true, 5, (Asn1Encodable) this.subject);
    elementVector.AddOptionalTagged(false, 6, (Asn1Encodable) this.publicKey);
    elementVector.AddOptionalTagged(false, 7, (Asn1Encodable) this.issuerUID);
    elementVector.AddOptionalTagged(false, 8, (Asn1Encodable) this.subjectUID);
    elementVector.AddOptionalTagged(false, 9, (Asn1Encodable) this.extensions);
    return CertTemplate.GetInstance((object) new DerSequence(elementVector));
  }
}
