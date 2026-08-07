// Decompiled with JetBrains decompiler
// Type: PdfSharp.Drawing.Pdf.DirtyFlags
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;

#nullable disable
namespace PdfSharp.Drawing.Pdf;

[Flags]
internal enum DirtyFlags
{
  Ctm = 1,
  ClipPath = 2,
  LineWidth = 16, // 0x00000010
  LineJoin = 32, // 0x00000020
  MiterLimit = 64, // 0x00000040
  StrokeFill = MiterLimit | LineJoin | LineWidth, // 0x00000070
}
