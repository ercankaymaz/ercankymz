// Decompiled with JetBrains decompiler
// Type: Opc.Ua.CertificateValidationOptions
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[Flags]
[ComVisible(true)]
public enum CertificateValidationOptions
{
  Default = 0,
  SuppressCertificateExpired = 1,
  SuppressHostNameInvalid = 2,
  SuppressRevocationStatusUnknown = 8,
  CheckRevocationStatusOnline = 16, // 0x00000010
  CheckRevocationStatusOffine = 32, // 0x00000020
  TreatAsInvalid = 64, // 0x00000040
}
