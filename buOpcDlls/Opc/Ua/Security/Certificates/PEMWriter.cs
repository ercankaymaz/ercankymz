// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Security.Certificates.PEMWriter
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Pkcs;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

#nullable disable
namespace Opc.Ua.Security.Certificates;

[ComVisible(true)]
public static class PEMWriter
{
  public static byte[] ExportPrivateKeyAsPEM(X509Certificate2 certificate, string password = null)
  {
    if (!string.IsNullOrEmpty(password))
      throw new ArgumentException("Export with password not supported on this platform.", nameof (password));
    return PEMWriter.EncodeAsPEM(PrivateKeyInfoFactory.CreatePrivateKeyInfo((AsymmetricKeyParameter) Opc.Ua.Security.Certificates.BouncyCastle.X509Utils.GetPrivateKeyParameter(certificate)).ToAsn1Object().GetDerEncoded(), "PRIVATE KEY");
  }

  public static byte[] ExportCRLAsPEM(byte[] crl) => PEMWriter.EncodeAsPEM(crl, "X509 CRL");

  public static byte[] ExportCSRAsPEM(byte[] csr)
  {
    return PEMWriter.EncodeAsPEM(csr, "CERTIFICATE REQUEST");
  }

  public static byte[] ExportCertificateAsPEM(X509Certificate2 certificate)
  {
    return PEMWriter.EncodeAsPEM(certificate.RawData, "CERTIFICATE");
  }

  private static byte[] EncodeAsPEM(byte[] content, string contentType)
  {
    if (content == null)
      throw new ArgumentNullException(nameof (content));
    if (string.IsNullOrEmpty(contentType))
      throw new ArgumentNullException(nameof (contentType));
    string str = Convert.ToBase64String(content);
    using (TextWriter textWriter = (TextWriter) new StringWriter())
    {
      textWriter.WriteLine("-----BEGIN {0}-----", (object) contentType);
      for (; str.Length > 64 /*0x40*/; str = str.Substring(64 /*0x40*/))
        textWriter.WriteLine(str.Substring(0, 64 /*0x40*/));
      textWriter.WriteLine(str);
      textWriter.WriteLine("-----END {0}-----", (object) contentType);
      return Encoding.ASCII.GetBytes(textWriter.ToString());
    }
  }
}
