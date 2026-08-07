// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Advanced.PdfFontDescriptorFlags
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;

#nullable disable
namespace PdfSharp.Pdf.Advanced;

[Flags]
internal enum PdfFontDescriptorFlags
{
  FixedPitch = 1,
  Serif = 2,
  Symbolic = 4,
  Script = 8,
  Nonsymbolic = 32, // 0x00000020
  Italic = 64, // 0x00000040
  AllCap = 65536, // 0x00010000
  SmallCap = 131072, // 0x00020000
  ForceBold = 262144, // 0x00040000
}
