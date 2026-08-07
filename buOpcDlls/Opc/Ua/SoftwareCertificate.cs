// Decompiled with JetBrains decompiler
// Type: Opc.Ua.SoftwareCertificate
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public class SoftwareCertificate
{
  private X509Certificate2 m_signedCertificate;

  public X509Certificate2 SignedCertificate
  {
    get => this.m_signedCertificate;
    set => this.m_signedCertificate = value;
  }

  public static ServiceResult Validate(
    CertificateValidator validator,
    byte[] signedCertificate,
    out SoftwareCertificate softwareCertificate)
  {
    softwareCertificate = (SoftwareCertificate) null;
    try
    {
      X509Certificate2 certificate = CertificateFactory.Create(signedCertificate, true);
      validator.Validate(certificate);
    }
    catch (Exception ex)
    {
      object[] objArray = Array.Empty<object>();
      return ServiceResult.Create(ex, 2147942400U /*0x80070000*/, "Could not decode software certificate body.", objArray);
    }
    return ServiceResult.Create(2148663296U /*0x80120000*/, "Could not find extension containing the software certficate.");
  }
}
