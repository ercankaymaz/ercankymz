// Decompiled with JetBrains decompiler
// Type: SourceGrid.ContextMenuStyle
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;

#nullable disable
namespace SourceGrid;

[Flags]
public enum ContextMenuStyle
{
  None = 0,
  ColumnResize = 1,
  RowResize = 2,
  AutoSize = 4,
  ClearSelection = 8,
  CopyPasteSelection = 16, // 0x00000010
  CellContextMenu = 32, // 0x00000020
}
