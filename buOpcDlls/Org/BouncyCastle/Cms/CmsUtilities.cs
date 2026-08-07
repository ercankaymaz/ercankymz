// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Cms.CmsUtilities
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cms;
using Org.BouncyCastle.Asn1.Ocsp;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Utilities.Collections;
using Org.BouncyCastle.Utilities.IO;
using Org.BouncyCastle.X509;
using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Cms;

internal static class CmsUtilities
{
  internal static int MaximumMemory => int.MaxValue;

  internal static ContentInfo ReadContentInfo(byte[] input)
  {
    using (Asn1InputStream asn1In = new Asn1InputStream(input))
      return CmsUtilities.ReadContentInfo(asn1In);
  }

  internal static ContentInfo ReadContentInfo(Stream input)
  {
    using (Asn1InputStream asn1In = new Asn1InputStream(input, CmsUtilities.MaximumMemory, true))
      return CmsUtilities.ReadContentInfo(asn1In);
  }

  private static ContentInfo ReadContentInfo(Asn1InputStream asn1In)
  {
    try
    {
      return ContentInfo.GetInstance((object) asn1In.ReadObject());
    }
    catch (IOException ex)
    {
      throw new CmsException("IOException reading content.", (Exception) ex);
    }
    catch (InvalidCastException ex)
    {
      throw new CmsException("Malformed content.", (Exception) ex);
    }
    catch (ArgumentException ex)
    {
      throw new CmsException("Malformed content.", (Exception) ex);
    }
  }

  internal static byte[] StreamToByteArray(Stream inStream) => Streams.ReadAll(inStream);

  internal static byte[] StreamToByteArray(Stream inStream, int limit)
  {
    return Streams.ReadAllLimited(inStream, limit);
  }

  internal static List<Asn1TaggedObject> GetAttributeCertificatesFromStore(
    IStore<X509V2AttributeCertificate> attrCertStore)
  {
    List<Asn1TaggedObject> certificatesFromStore = new List<Asn1TaggedObject>();
    if (attrCertStore != null)
    {
      foreach (X509V2AttributeCertificate enumerateMatch in attrCertStore.EnumerateMatches((ISelector<X509V2AttributeCertificate>) null))
        certificatesFromStore.Add((Asn1TaggedObject) new DerTaggedObject(false, 2, (Asn1Encodable) enumerateMatch.AttributeCertificate));
    }
    return certificatesFromStore;
  }

  internal static List<X509CertificateStructure> GetCertificatesFromStore(
    IStore<X509Certificate> certStore)
  {
    List<X509CertificateStructure> certificatesFromStore = new List<X509CertificateStructure>();
    if (certStore != null)
    {
      foreach (X509Certificate enumerateMatch in certStore.EnumerateMatches((ISelector<X509Certificate>) null))
        certificatesFromStore.Add(enumerateMatch.CertificateStructure);
    }
    return certificatesFromStore;
  }

  internal static List<CertificateList> GetCrlsFromStore(IStore<X509Crl> crlStore)
  {
    List<CertificateList> crlsFromStore = new List<CertificateList>();
    if (crlStore != null)
    {
      foreach (X509Crl enumerateMatch in crlStore.EnumerateMatches((ISelector<X509Crl>) null))
        crlsFromStore.Add(enumerateMatch.CertificateList);
    }
    return crlsFromStore;
  }

  internal static List<Asn1TaggedObject> GetOtherRevocationInfosFromStore(
    IStore<OtherRevocationInfoFormat> otherRevocationInfoStore)
  {
    List<Asn1TaggedObject> revocationInfosFromStore = new List<Asn1TaggedObject>();
    if (otherRevocationInfoStore != null)
    {
      foreach (OtherRevocationInfoFormat enumerateMatch in otherRevocationInfoStore.EnumerateMatches((ISelector<OtherRevocationInfoFormat>) null))
      {
        CmsUtilities.ValidateOtherRevocationInfo(enumerateMatch);
        revocationInfosFromStore.Add((Asn1TaggedObject) new DerTaggedObject(false, 1, (Asn1Encodable) enumerateMatch));
      }
    }
    return revocationInfosFromStore;
  }

  internal static List<DerTaggedObject> GetOtherRevocationInfosFromStore(
    IStore<Asn1Encodable> otherRevInfoStore,
    DerObjectIdentifier otherRevInfoFormat)
  {
    List<DerTaggedObject> revocationInfosFromStore = new List<DerTaggedObject>();
    if (otherRevInfoStore != null && otherRevInfoFormat != null)
    {
      foreach (Asn1Encodable enumerateMatch in otherRevInfoStore.EnumerateMatches((ISelector<Asn1Encodable>) null))
      {
        OtherRevocationInfoFormat otherRevocationInfo = new OtherRevocationInfoFormat(otherRevInfoFormat, enumerateMatch);
        CmsUtilities.ValidateOtherRevocationInfo(otherRevocationInfo);
        revocationInfosFromStore.Add(new DerTaggedObject(false, 1, (Asn1Encodable) otherRevocationInfo));
      }
    }
    return revocationInfosFromStore;
  }

  internal static Asn1Set CreateBerSetFromList(IEnumerable<Asn1Encodable> elements)
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector();
    foreach (Asn1Encodable element in elements)
      elementVector.Add(element);
    return (Asn1Set) BerSet.FromVector(elementVector);
  }

  internal static Asn1Set CreateDerSetFromList(IEnumerable<Asn1Encodable> elements)
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector();
    foreach (Asn1Encodable element in elements)
      elementVector.Add(element);
    return (Asn1Set) DerSet.FromVector(elementVector);
  }

  internal static TbsCertificateStructure GetTbsCertificateStructure(X509Certificate cert)
  {
    return cert.CertificateStructure.TbsCertificate;
  }

  internal static IssuerAndSerialNumber GetIssuerAndSerialNumber(X509Certificate cert)
  {
    TbsCertificateStructure certificateStructure = CmsUtilities.GetTbsCertificateStructure(cert);
    return new IssuerAndSerialNumber(certificateStructure.Issuer, certificateStructure.SerialNumber.Value);
  }

  internal static Org.BouncyCastle.Asn1.Cms.AttributeTable ParseAttributeTable(Asn1SetParser parser)
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector();
    IAsn1Convertible asn1Convertible;
    while ((asn1Convertible = parser.ReadObject()) != null)
    {
      Asn1SequenceParser asn1SequenceParser = (Asn1SequenceParser) asn1Convertible;
      elementVector.Add((Asn1Encodable) asn1SequenceParser.ToAsn1Object());
    }
    return new Org.BouncyCastle.Asn1.Cms.AttributeTable((Asn1Set) new DerSet(elementVector));
  }

  internal static void ValidateOtherRevocationInfo(OtherRevocationInfoFormat otherRevocationInfo)
  {
    if (CmsObjectIdentifiers.id_ri_ocsp_response.Equals((Asn1Object) otherRevocationInfo.InfoFormat) && OcspResponse.GetInstance((object) otherRevocationInfo.Info).ResponseStatus.IntValueExact != 0)
      throw new ArgumentException("cannot add unsuccessful OCSP response to CMS SignedData");
  }
}
