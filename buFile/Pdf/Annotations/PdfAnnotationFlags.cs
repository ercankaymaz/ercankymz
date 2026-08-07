// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Annotations.PdfAnnotationFlags
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;

#nullable disable
namespace PdfSharp.Pdf.Annotations;

[Flags]
public enum PdfAnnotationFlags
{
  Invisible = 1,
  Hidden = 2,
  Print = 4,
  NoZoom = 8,
  NoRotate = 16, // 0x00000010
  NoView = 32, // 0x00000020
  ReadOnly = 64, // 0x00000040
  Locked = 128, // 0x00000080
  ToggleNoView = 256, // 0x00000100
}
