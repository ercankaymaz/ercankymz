// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Security.Certificates.IX509Certificate
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

#nullable disable
namespace Opc.Ua.Security.Certificates;

[ComVisible(true)]
public interface IX509Certificate
{
  X500DistinguishedName SubjectName { get; }

  X500DistinguishedName IssuerName { get; }

  DateTime NotBefore { get; }

  DateTime NotAfter { get; }

  string SerialNumber { get; }

  byte[] GetSerialNumber();

  HashAlgorithmName HashAlgorithmName { get; }

  X509ExtensionCollection Extensions { get; }
}
