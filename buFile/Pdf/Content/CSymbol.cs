// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Content.CSymbol
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

#nullable disable
namespace PdfSharp.Pdf.Content;

public enum CSymbol
{
  Error = -1, // 0xFFFFFFFF
  None = 0,
  Comment = 1,
  Integer = 2,
  Real = 3,
  String = 4,
  HexString = 5,
  UnicodeString = 6,
  UnicodeHexString = 7,
  Name = 8,
  Operator = 9,
  BeginArray = 10, // 0x0000000A
  EndArray = 11, // 0x0000000B
  Dictionary = 12, // 0x0000000C
  Eof = 13, // 0x0000000D
}
