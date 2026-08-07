// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Security.Certificates.X509Extensions
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

#nullable disable
namespace Opc.Ua.Security.Certificates;

[ComVisible(true)]
public static class X509Extensions
{
  public static T FindExtension<T>(this X509Certificate2 certificate) where T : X509Extension
  {
    return certificate.Extensions.FindExtension<T>();
  }

  public static T FindExtension<T>(this X509ExtensionCollection extensions) where T : X509Extension
  {
    if (extensions == null)
      throw new ArgumentNullException(nameof (extensions));
    lock (extensions.SyncRoot)
    {
      if (typeof (T) == typeof (X509AuthorityKeyIdentifierExtension))
      {
        X509Extension encodedExtension = extensions.Cast<X509Extension>().FirstOrDefault<X509Extension>((Func<X509Extension, bool>) (e => e.Oid.Value == "2.5.29.1" || e.Oid.Value == "2.5.29.35"));
        if (encodedExtension != null)
          return new X509AuthorityKeyIdentifierExtension((AsnEncodedData) encodedExtension, encodedExtension.Critical) as T;
      }
      if (typeof (T) == typeof (X509SubjectAltNameExtension))
      {
        X509Extension encodedExtension = extensions.Cast<X509Extension>().FirstOrDefault<X509Extension>((Func<X509Extension, bool>) (e => e.Oid.Value == "2.5.29.7" || e.Oid.Value == "2.5.29.17"));
        if (encodedExtension != null)
          return new X509SubjectAltNameExtension((AsnEncodedData) encodedExtension, encodedExtension.Critical) as T;
      }
      if (typeof (T) == typeof (X509CrlNumberExtension))
      {
        X509Extension encodedExtension = extensions.Cast<X509Extension>().FirstOrDefault<X509Extension>((Func<X509Extension, bool>) (e => e.Oid.Value == "2.5.29.20"));
        if (encodedExtension != null)
          return new X509CrlNumberExtension((AsnEncodedData) encodedExtension, encodedExtension.Critical) as T;
      }
      return extensions.OfType<T>().FirstOrDefault<T>();
    }
  }

  public static X509Extension BuildX509AuthorityInformationAccess(
    string[] caIssuerUrls,
    string ocspResponder = null)
  {
    if (string.IsNullOrEmpty(ocspResponder) && (caIssuerUrls == null || caIssuerUrls.Length == 0))
      throw new ArgumentNullException(nameof (caIssuerUrls), "One CA Issuer Url or OCSP responder is required for the extension.");
    System.Formats.Asn1.Asn1Tag asn1Tag = new System.Formats.Asn1.Asn1Tag(System.Formats.Asn1.TagClass.ContextSpecific, 6);
    AsnWriter asnWriter = new AsnWriter(System.Formats.Asn1.AsnEncodingRules.DER);
    asnWriter.PushSequence();
    if (caIssuerUrls != null)
    {
      foreach (string caIssuerUrl in caIssuerUrls)
      {
        asnWriter.PushSequence();
        asnWriter.WriteObjectIdentifier("1.3.6.1.5.5.7.48.2");
        asnWriter.WriteCharacterString(System.Formats.Asn1.UniversalTagNumber.IA5String, caIssuerUrl, new System.Formats.Asn1.Asn1Tag?(asn1Tag));
        asnWriter.PopSequence();
      }
    }
    if (!string.IsNullOrEmpty(ocspResponder))
    {
      asnWriter.PushSequence();
      asnWriter.WriteObjectIdentifier("1.3.6.1.5.5.7.48.1");
      asnWriter.WriteCharacterString(System.Formats.Asn1.UniversalTagNumber.IA5String, ocspResponder, new System.Formats.Asn1.Asn1Tag?(asn1Tag));
      asnWriter.PopSequence();
    }
    asnWriter.PopSequence();
    return new X509Extension("1.3.6.1.5.5.7.1.1", asnWriter.Encode(), false);
  }

  public static X509Extension BuildX509CRLDistributionPoints(string distributionPoint)
  {
    return X509Extensions.BuildX509CRLDistributionPoints((IEnumerable<string>) new string[1]
    {
      distributionPoint
    });
  }

  public static X509Extension BuildX509CRLDistributionPoints(IEnumerable<string> distributionPoints)
  {
    System.Formats.Asn1.Asn1Tag asn1Tag1;
    System.Formats.Asn1.Asn1Tag asn1Tag2 = asn1Tag1 = new System.Formats.Asn1.Asn1Tag(System.Formats.Asn1.TagClass.ContextSpecific, 0, true);
    System.Formats.Asn1.Asn1Tag asn1Tag3 = new System.Formats.Asn1.Asn1Tag(System.Formats.Asn1.TagClass.ContextSpecific, 6);
    AsnWriter asnWriter = new AsnWriter(System.Formats.Asn1.AsnEncodingRules.DER);
    asnWriter.PushSequence();
    asnWriter.PushSequence();
    asnWriter.PushSequence(new System.Formats.Asn1.Asn1Tag?(asn1Tag1));
    asnWriter.PushSequence(new System.Formats.Asn1.Asn1Tag?(asn1Tag2));
    foreach (string distributionPoint in distributionPoints)
      asnWriter.WriteCharacterString(System.Formats.Asn1.UniversalTagNumber.IA5String, distributionPoint, new System.Formats.Asn1.Asn1Tag?(asn1Tag3));
    asnWriter.PopSequence(new System.Formats.Asn1.Asn1Tag?(asn1Tag2));
    asnWriter.PopSequence(new System.Formats.Asn1.Asn1Tag?(asn1Tag1));
    asnWriter.PopSequence();
    asnWriter.PopSequence();
    return new X509Extension("2.5.29.31", asnWriter.Encode(), false);
  }

  public static X509Extension ReadExtension(this System.Formats.Asn1.AsnReader reader)
  {
    if (!reader.HasData)
      return (X509Extension) null;
    System.Formats.Asn1.Asn1Tag asn1Tag = new System.Formats.Asn1.Asn1Tag(System.Formats.Asn1.UniversalTagNumber.Boolean);
    System.Formats.Asn1.AsnReader asnReader = reader.ReadSequence();
    string oid = asnReader.ReadObjectIdentifier();
    bool critical = false;
    if (asnReader.PeekTag() == asn1Tag)
      critical = asnReader.ReadBoolean();
    byte[] rawData = asnReader.ReadOctetString();
    asnReader.ThrowIfNotEmpty();
    return new X509Extension(new Oid(oid), rawData, critical);
  }

  public static void WriteExtension(this AsnWriter writer, X509Extension extension)
  {
    System.Formats.Asn1.Asn1Tag sequence = System.Formats.Asn1.Asn1Tag.Sequence;
    writer.PushSequence(new System.Formats.Asn1.Asn1Tag?(sequence));
    writer.WriteObjectIdentifier(extension.Oid.Value);
    if (extension.Critical)
      writer.WriteBoolean(extension.Critical);
    writer.WriteOctetString((System.ReadOnlySpan<byte>) extension.RawData);
    writer.PopSequence(new System.Formats.Asn1.Asn1Tag?(sequence));
  }

  public static X509Extension BuildX509CRLReason(CRLReason reason)
  {
    AsnWriter asnWriter = new AsnWriter(System.Formats.Asn1.AsnEncodingRules.DER);
    asnWriter.WriteEnumeratedValue<CRLReason>(reason);
    return new X509Extension("2.5.29.21", asnWriter.Encode(), false);
  }

  public static X509Extension BuildAuthorityKeyIdentifier(X509Certificate2 issuerCaCertificate)
  {
    return (X509Extension) new X509AuthorityKeyIdentifierExtension(issuerCaCertificate.Extensions.OfType<X509SubjectKeyIdentifierExtension>().Single<X509SubjectKeyIdentifierExtension>().SubjectKeyIdentifier.FromHexString(), issuerCaCertificate.IssuerName, issuerCaCertificate.GetSerialNumber());
  }

  public static X509Extension BuildCRLNumber(BigInteger crlNumber)
  {
    AsnWriter asnWriter = new AsnWriter(System.Formats.Asn1.AsnEncodingRules.DER);
    asnWriter.WriteInteger(crlNumber);
    return new X509Extension("2.5.29.20", asnWriter.Encode(), false);
  }

  public static string PatchExtensionUrl(string extensionUrl, byte[] serialNumber)
  {
    return X509Extensions.PatchExtensionUrl(extensionUrl, serialNumber.ToHexString());
  }

  public static string PatchExtensionUrl(string extensionUrl, string serial)
  {
    return extensionUrl.Replace("%serial%", serial.ToLower());
  }
}
