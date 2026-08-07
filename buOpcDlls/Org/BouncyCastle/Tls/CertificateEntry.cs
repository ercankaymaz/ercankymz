// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.CertificateEntry
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Tls.Crypto;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Tls;

public sealed class CertificateEntry
{
  private readonly TlsCertificate m_certificate;
  private readonly IDictionary<int, byte[]> m_extensions;

  public CertificateEntry(TlsCertificate certificate, IDictionary<int, byte[]> extensions)
  {
    this.m_certificate = certificate != null ? certificate : throw new ArgumentNullException(nameof (certificate));
    this.m_extensions = extensions;
  }

  public TlsCertificate Certificate => this.m_certificate;

  public IDictionary<int, byte[]> Extensions => this.m_extensions;
}
