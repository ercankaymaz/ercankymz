// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.X509.PrincipalUtilities
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;

#nullable disable
namespace Org.BouncyCastle.X509;

public class PrincipalUtilities
{
  public static X509Name GetIssuerX509Principal(X509Certificate cert)
  {
    return cert.CertificateStructure.TbsCertificate.Issuer;
  }

  public static X509Name GetSubjectX509Principal(X509Certificate cert)
  {
    return cert.CertificateStructure.TbsCertificate.Subject;
  }

  public static X509Name GetIssuerX509Principal(X509Crl crl)
  {
    return crl.CertificateList.TbsCertList.Issuer;
  }
}
