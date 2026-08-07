// Decompiled with JetBrains decompiler
// Type: SourceGrid.Exporter.ExportHTMLMode
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;

#nullable disable
namespace SourceGrid.Exporter;

[Flags]
public enum ExportHTMLMode
{
  None = 0,
  HTMLAndBody = 1,
  GridBackColor = 2,
  CellBackColor = 4,
  RectangleBorder = 8,
  CellForeColor = 16, // 0x00000010
  CellImages = 32, // 0x00000020
  Default = CellImages | CellForeColor | RectangleBorder | CellBackColor | GridBackColor | HTMLAndBody, // 0x0000003F
}
