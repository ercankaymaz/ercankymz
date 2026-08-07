// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cmp.CmpCertificate
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cmp;

public class CmpCertificate : Asn1Encodable, IAsn1Choice
{
  private readonly X509CertificateStructure m_x509v3PKCert;
  private readonly int m_otherTag;
  private readonly Asn1Encodable m_otherObject;

  public static CmpCertificate GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
        return (CmpCertificate) null;
      case CmpCertificate instance:
        return instance;
      case X509CertificateStructure x509v3PKCert:
        return new CmpCertificate(x509v3PKCert);
      case Asn1TaggedObject taggedObject2:
        return new CmpCertificate(taggedObject2);
      default:
        Asn1Object asn1Object = (Asn1Object) null;
        if (obj is IAsn1Convertible asn1Convertible)
          asn1Object = asn1Convertible.ToAsn1Object();
        else if (obj is byte[] data)
          asn1Object = Asn1Object.FromByteArray(data);
        return asn1Object is Asn1TaggedObject taggedObject1 ? new CmpCertificate(taggedObject1) : new CmpCertificate(X509CertificateStructure.GetInstance((object) asn1Object ?? obj));
    }
  }

  public static CmpCertificate GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return Asn1Utilities.GetInstanceFromChoice<CmpCertificate>(taggedObject, declaredExplicit, new Func<object, CmpCertificate>(CmpCertificate.GetInstance));
  }

  [Obsolete("Use 'GetInstance' from tagged object instead")]
  public CmpCertificate(int type, Asn1Encodable otherCert)
  {
    this.m_otherTag = type;
    this.m_otherObject = otherCert;
  }

  internal CmpCertificate(Asn1TaggedObject taggedObject)
  {
    if (!taggedObject.HasContextTag(1))
      throw new ArgumentException("Invalid CHOICE element", nameof (taggedObject));
    AttributeCertificate.GetInstance(taggedObject, true);
    this.m_otherTag = taggedObject.TagNo;
    this.m_otherObject = taggedObject.GetExplicitBaseObject();
  }

  internal CmpCertificate(CmpCertificate other)
  {
    this.m_x509v3PKCert = other.m_x509v3PKCert;
    this.m_otherTag = other.m_otherTag;
    this.m_otherObject = other.m_otherObject;
  }

  public CmpCertificate(X509CertificateStructure x509v3PKCert)
  {
    this.m_x509v3PKCert = x509v3PKCert.Version == 3 ? x509v3PKCert : throw new ArgumentException("only version 3 certificates allowed", nameof (x509v3PKCert));
  }

  public virtual bool IsX509v3PKCert => this.m_x509v3PKCert != null;

  public virtual X509CertificateStructure X509v3PKCert => this.m_x509v3PKCert;

  public virtual int OtherCertTag => this.m_otherTag;

  public virtual Asn1Encodable OtherCert => this.m_otherObject;

  public override Asn1Object ToAsn1Object()
  {
    if (this.m_otherObject != null)
      return (Asn1Object) new DerTaggedObject(true, this.m_otherTag, this.m_otherObject);
    return this.m_x509v3PKCert != null ? this.m_x509v3PKCert.ToAsn1Object() : throw new InvalidOperationException();
  }
}
