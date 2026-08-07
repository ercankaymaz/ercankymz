// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Security.Certificates.IX509CRL
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

#nullable disable
namespace Opc.Ua.Security.Certificates;

[ComVisible(true)]
public interface IX509CRL
{
  X500DistinguishedName IssuerName { get; }

  string Issuer { get; }

  DateTime ThisUpdate { get; }

  DateTime NextUpdate { get; }

  HashAlgorithmName HashAlgorithmName { get; }

  IList<RevokedCertificate> RevokedCertificates { get; }

  X509ExtensionCollection CrlExtensions { get; }

  byte[] RawData { get; }
}
