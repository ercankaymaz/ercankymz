// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cmp.CertAnnContent
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cmp;

public class CertAnnContent : CmpCertificate
{
  public static CertAnnContent GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
        return (CertAnnContent) null;
      case CertAnnContent instance:
        return instance;
      case CmpCertificate other:
        return new CertAnnContent(other);
      case Asn1TaggedObject taggedObject:
        return new CertAnnContent(taggedObject);
      default:
        return new CertAnnContent(X509CertificateStructure.GetInstance(obj));
    }
  }

  public static CertAnnContent GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return Asn1Utilities.GetInstanceFromChoice<CertAnnContent>(taggedObject, declaredExplicit, new Func<object, CertAnnContent>(CertAnnContent.GetInstance));
  }

  [Obsolete("Use 'GetInstance' from tagged object instead")]
  public CertAnnContent(int type, Asn1Object otherCert)
    : base(type, (Asn1Encodable) otherCert)
  {
  }

  internal CertAnnContent(Asn1TaggedObject taggedObject)
    : base(taggedObject)
  {
  }

  internal CertAnnContent(CmpCertificate other)
    : base(other)
  {
  }

  public CertAnnContent(X509CertificateStructure x509v3PKCert)
    : base(x509v3PKCert)
  {
  }
}
