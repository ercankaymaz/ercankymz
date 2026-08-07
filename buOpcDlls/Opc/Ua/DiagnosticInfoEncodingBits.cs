// Decompiled with JetBrains decompiler
// Type: Opc.Ua.DiagnosticInfoEncodingBits
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Opc.Ua;

[Flags]
internal enum DiagnosticInfoEncodingBits
{
  SymbolicId = 1,
  NamespaceUri = 2,
  LocalizedText = 4,
  Locale = 8,
  AdditionalInfo = 16, // 0x00000010
  InnerStatusCode = 32, // 0x00000020
  InnerDiagnosticInfo = 64, // 0x00000040
}
