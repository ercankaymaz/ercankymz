// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cmp.OobCert
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cmp;

public class OobCert : CmpCertificate
{
  public static OobCert GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
        return (OobCert) null;
      case OobCert instance:
        return instance;
      case CmpCertificate other:
        return new OobCert(other);
      case Asn1TaggedObject taggedObject:
        return new OobCert(taggedObject);
      default:
        return new OobCert(X509CertificateStructure.GetInstance(obj));
    }
  }

  public static OobCert GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return Asn1Utilities.GetInstanceFromChoice<OobCert>(taggedObject, declaredExplicit, new Func<object, OobCert>(OobCert.GetInstance));
  }

  [Obsolete("Use constructor from Asn1TaggedObject instead")]
  public OobCert(int type, Asn1Encodable otherCert)
    : base(type, otherCert)
  {
  }

  internal OobCert(Asn1TaggedObject taggedObject)
    : base(taggedObject)
  {
  }

  internal OobCert(CmpCertificate other)
    : base(other)
  {
  }

  public OobCert(X509CertificateStructure x509v3PKCert)
    : base(x509v3PKCert)
  {
  }
}
