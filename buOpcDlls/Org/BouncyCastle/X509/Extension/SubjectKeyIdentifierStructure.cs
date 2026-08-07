// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.X509.Extension.SubjectKeyIdentifierStructure
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security.Certificates;
using System;

#nullable disable
namespace Org.BouncyCastle.X509.Extension;

public class SubjectKeyIdentifierStructure : SubjectKeyIdentifier
{
  public SubjectKeyIdentifierStructure(Asn1OctetString encodedValue)
    : base((Asn1OctetString) X509ExtensionUtilities.FromExtensionValue(encodedValue))
  {
  }

  private static Asn1OctetString FromPublicKey(AsymmetricKeyParameter pubKey)
  {
    try
    {
      return (Asn1OctetString) new SubjectKeyIdentifier(SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(pubKey)).ToAsn1Object();
    }
    catch (Exception ex)
    {
      throw new CertificateParsingException("Exception extracting certificate details: " + ex.ToString());
    }
  }

  public SubjectKeyIdentifierStructure(AsymmetricKeyParameter pubKey)
    : base(SubjectKeyIdentifierStructure.FromPublicKey(pubKey))
  {
  }
}
