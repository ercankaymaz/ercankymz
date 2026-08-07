// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Security.PdfUserAccessPermission
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;

#nullable disable
namespace PdfSharp.Pdf.Security;

[Flags]
internal enum PdfUserAccessPermission
{
  PermitAll = -3, // 0xFFFFFFFD
  PermitPrint = 4,
  PermitModifyDocument = 8,
  PermitExtractContent = 16, // 0x00000010
  PermitAnnotations = 32, // 0x00000020
  PermitFormsFill = 256, // 0x00000100
  PermitAccessibilityExtractContent = 512, // 0x00000200
  PermitAssembleDocument = 1024, // 0x00000400
  PermitFullQualityPrint = 2048, // 0x00000800
}
