// Decompiled with JetBrains decompiler
// Type: Opc.Ua.DiagnosticsMasks
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[Flags]
[ComVisible(true)]
public enum DiagnosticsMasks : uint
{
  None = 0,
  ServiceSymbolicId = 1,
  ServiceLocalizedText = 2,
  ServiceAdditionalInfo = 4,
  ServiceInnerStatusCode = 8,
  ServiceInnerDiagnostics = 16, // 0x00000010
  ServiceSymbolicIdAndText = ServiceLocalizedText | ServiceSymbolicId, // 0x00000003
  ServiceNoInnerStatus = ServiceSymbolicIdAndText | ServiceInnerStatusCode | ServiceAdditionalInfo, // 0x0000000F
  ServiceAll = ServiceNoInnerStatus | ServiceInnerDiagnostics, // 0x0000001F
  OperationSymbolicId = 32, // 0x00000020
  OperationLocalizedText = 64, // 0x00000040
  OperationAdditionalInfo = 128, // 0x00000080
  OperationInnerStatusCode = 256, // 0x00000100
  OperationInnerDiagnostics = 512, // 0x00000200
  OperationSymbolicIdAndText = OperationLocalizedText | OperationSymbolicId, // 0x00000060
  OperationNoInnerStatus = OperationSymbolicIdAndText | OperationAdditionalInfo, // 0x000000E0
  OperationAll = OperationNoInnerStatus | OperationInnerDiagnostics | OperationInnerStatusCode, // 0x000003E0
  SymbolicId = OperationSymbolicId | ServiceSymbolicId, // 0x00000021
  LocalizedText = OperationLocalizedText | ServiceLocalizedText, // 0x00000042
  AdditionalInfo = OperationAdditionalInfo | ServiceAdditionalInfo, // 0x00000084
  InnerStatusCode = OperationInnerStatusCode | ServiceInnerStatusCode, // 0x00000108
  InnerDiagnostics = OperationInnerDiagnostics | ServiceInnerDiagnostics, // 0x00000210
  SymbolicIdAndText = LocalizedText | SymbolicId, // 0x00000063
  NoInnerStatus = SymbolicIdAndText | AdditionalInfo | ServiceInnerStatusCode, // 0x000000EF
  All = NoInnerStatus | InnerDiagnostics | OperationInnerStatusCode, // 0x000003FF
  UserPermissionAdditionalInfo = 2147483648, // 0x80000000
}
