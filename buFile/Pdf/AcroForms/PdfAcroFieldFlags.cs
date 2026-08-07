// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.AcroForms.PdfAcroFieldFlags
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;

#nullable disable
namespace PdfSharp.Pdf.AcroForms;

[Flags]
public enum PdfAcroFieldFlags
{
  ReadOnly = 1,
  Required = 2,
  NoExport = 4,
  Pushbutton = 65536, // 0x00010000
  Radio = 32768, // 0x00008000
  NoToggleToOff = 16384, // 0x00004000
  Multiline = 4096, // 0x00001000
  Password = 8192, // 0x00002000
  FileSelect = 1048576, // 0x00100000
  DoNotSpellCheckTextField = 4194304, // 0x00400000
  DoNotScroll = 8388608, // 0x00800000
  Combo = 131072, // 0x00020000
  Edit = 262144, // 0x00040000
  Sort = 524288, // 0x00080000
  MultiSelect = 2097152, // 0x00200000
  DoNotSpellCheckChoiseField = DoNotSpellCheckTextField, // 0x00400000
}
