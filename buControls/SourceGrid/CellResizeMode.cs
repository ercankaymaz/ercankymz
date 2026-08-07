// Decompiled with JetBrains decompiler
// Type: SourceGrid.CellResizeMode
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;

#nullable disable
namespace SourceGrid;

[Flags]
public enum CellResizeMode
{
  None = 0,
  Height = 1,
  Width = 2,
  Both = Width | Height, // 0x00000003
}
