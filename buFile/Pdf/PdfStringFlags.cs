// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.PdfStringFlags
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;

#nullable disable
namespace PdfSharp.Pdf;

[Flags]
internal enum PdfStringFlags
{
  RawEncoding = 0,
  StandardEncoding = 1,
  PDFDocEncoding = 2,
  WinAnsiEncoding = PDFDocEncoding | StandardEncoding, // 0x00000003
  MacRomanEncoding = 4,
  MacExpertEncoding = MacRomanEncoding | StandardEncoding, // 0x00000005
  Unicode = MacRomanEncoding | PDFDocEncoding, // 0x00000006
  EncodingMask = 15, // 0x0000000F
  HexLiteral = 128, // 0x00000080
}
