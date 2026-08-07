// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Security.Certificates.RevokedCertificate
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

#nullable disable
namespace Opc.Ua.Security.Certificates;

[ComVisible(true)]
public class RevokedCertificate
{
  public RevokedCertificate(string serialNumber, CRLReason crlReason)
    : this(serialNumber)
  {
    this.CrlEntryExtensions.Add(X509Extensions.BuildX509CRLReason(crlReason));
  }

  public RevokedCertificate(byte[] serialNumber, CRLReason crlReason)
    : this(serialNumber)
  {
    if (crlReason == CRLReason.Unspecified)
      return;
    this.CrlEntryExtensions.Add(X509Extensions.BuildX509CRLReason(crlReason));
  }

  public RevokedCertificate(string serialNumber)
    : this()
  {
    this.UserCertificate = ((IEnumerable<byte>) serialNumber.FromHexString()).Reverse<byte>().ToArray<byte>();
  }

  public RevokedCertificate(byte[] serialNumber)
    : this()
  {
    this.UserCertificate = serialNumber;
  }

  private RevokedCertificate()
  {
    this.RevocationDate = DateTime.UtcNow;
    this.CrlEntryExtensions = new X509ExtensionCollection();
  }

  public string SerialNumber => this.UserCertificate.ToHexString(true);

  public byte[] UserCertificate { get; }

  public DateTime RevocationDate { get; set; }

  public X509ExtensionCollection CrlEntryExtensions { get; }
}
