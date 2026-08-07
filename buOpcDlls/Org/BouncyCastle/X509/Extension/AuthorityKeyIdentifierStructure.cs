// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.X509.Extension.AuthorityKeyIdentifierStructure
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Security.Certificates;
using System;

#nullable disable
namespace Org.BouncyCastle.X509.Extension;

public class AuthorityKeyIdentifierStructure : AuthorityKeyIdentifier
{
  public AuthorityKeyIdentifierStructure(Asn1OctetString encodedValue)
    : base((Asn1Sequence) X509ExtensionUtilities.FromExtensionValue(encodedValue))
  {
  }

  private static Asn1Sequence FromCertificate(X509Certificate certificate)
  {
    try
    {
      GeneralName name = new GeneralName(PrincipalUtilities.GetIssuerX509Principal(certificate));
      if (certificate.Version == 3)
      {
        Asn1OctetString extensionValue = certificate.GetExtensionValue(X509Extensions.SubjectKeyIdentifier);
        if (extensionValue != null)
          return (Asn1Sequence) new AuthorityKeyIdentifier(((Asn1OctetString) X509ExtensionUtilities.FromExtensionValue(extensionValue)).GetOctets(), new GeneralNames(name), certificate.SerialNumber).ToAsn1Object();
      }
      return (Asn1Sequence) new AuthorityKeyIdentifier(SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(certificate.GetPublicKey()), new GeneralNames(name), certificate.SerialNumber).ToAsn1Object();
    }
    catch (Exception ex)
    {
      throw new CertificateParsingException("Exception extracting certificate details", ex);
    }
  }

  private static Asn1Sequence FromKey(AsymmetricKeyParameter pubKey)
  {
    try
    {
      return (Asn1Sequence) new AuthorityKeyIdentifier(SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(pubKey)).ToAsn1Object();
    }
    catch (Exception ex)
    {
      throw new InvalidKeyException("can't process key: " + ex?.ToString());
    }
  }

  public AuthorityKeyIdentifierStructure(X509Certificate certificate)
    : base(AuthorityKeyIdentifierStructure.FromCertificate(certificate))
  {
  }

  public AuthorityKeyIdentifierStructure(AsymmetricKeyParameter pubKey)
    : base(AuthorityKeyIdentifierStructure.FromKey(pubKey))
  {
  }
}
