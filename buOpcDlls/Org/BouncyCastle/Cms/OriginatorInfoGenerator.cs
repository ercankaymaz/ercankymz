// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Cms.OriginatorInfoGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cms;
using Org.BouncyCastle.Utilities.Collections;
using Org.BouncyCastle.X509;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Cms;

public class OriginatorInfoGenerator
{
  private readonly List<Asn1Encodable> origCerts;
  private readonly List<Asn1Encodable> origCrls;

  public OriginatorInfoGenerator(X509Certificate origCert)
  {
    this.origCerts = new List<Asn1Encodable>()
    {
      (Asn1Encodable) origCert.CertificateStructure
    };
    this.origCrls = (List<Asn1Encodable>) null;
  }

  public OriginatorInfoGenerator(IStore<X509Certificate> x509Certs)
    : this(x509Certs, (IStore<X509Crl>) null, (IStore<X509V2AttributeCertificate>) null, (IStore<OtherRevocationInfoFormat>) null)
  {
  }

  public OriginatorInfoGenerator(IStore<X509Certificate> x509Certs, IStore<X509Crl> x509Crls)
    : this(x509Certs, x509Crls, (IStore<X509V2AttributeCertificate>) null, (IStore<OtherRevocationInfoFormat>) null)
  {
  }

  public OriginatorInfoGenerator(
    IStore<X509Certificate> x509Certs,
    IStore<X509Crl> x509Crls,
    IStore<X509V2AttributeCertificate> x509AttrCerts,
    IStore<OtherRevocationInfoFormat> otherRevocationInfos)
  {
    List<Asn1Encodable> asn1EncodableList1 = (List<Asn1Encodable>) null;
    if (x509Certs != null || x509AttrCerts != null)
    {
      asn1EncodableList1 = new List<Asn1Encodable>();
      if (x509Certs != null)
        asn1EncodableList1.AddRange((IEnumerable<Asn1Encodable>) CmsUtilities.GetCertificatesFromStore(x509Certs));
      if (x509AttrCerts != null)
        asn1EncodableList1.AddRange((IEnumerable<Asn1Encodable>) CmsUtilities.GetAttributeCertificatesFromStore(x509AttrCerts));
    }
    List<Asn1Encodable> asn1EncodableList2 = (List<Asn1Encodable>) null;
    if (x509Crls != null || otherRevocationInfos != null)
    {
      asn1EncodableList2 = new List<Asn1Encodable>();
      if (x509Crls != null)
        asn1EncodableList2.AddRange((IEnumerable<Asn1Encodable>) CmsUtilities.GetCrlsFromStore(x509Crls));
      if (otherRevocationInfos != null)
        asn1EncodableList2.AddRange((IEnumerable<Asn1Encodable>) CmsUtilities.GetOtherRevocationInfosFromStore(otherRevocationInfos));
    }
    this.origCerts = asn1EncodableList1;
    this.origCrls = asn1EncodableList2;
  }

  public virtual OriginatorInfo Generate()
  {
    return new OriginatorInfo(this.origCerts == null ? (Asn1Set) null : CmsUtilities.CreateDerSetFromList((IEnumerable<Asn1Encodable>) this.origCerts), this.origCrls == null ? (Asn1Set) null : CmsUtilities.CreateDerSetFromList((IEnumerable<Asn1Encodable>) this.origCrls));
  }
}
