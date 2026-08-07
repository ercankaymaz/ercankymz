// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.PdfStringEncoding
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;

#nullable disable
namespace PdfSharp.Pdf;

[Flags]
public enum PdfStringEncoding
{
  RawEncoding = 0,
  StandardEncoding = 1,
  PDFDocEncoding = 2,
  WinAnsiEncoding = PDFDocEncoding | StandardEncoding, // 0x00000003
  MacRomanEncoding = 5,
  MacExpertEncoding = MacRomanEncoding, // 0x00000005
  Unicode = 6,
}
