// Decompiled with JetBrains decompiler
// Type: SourceGrid.GridSpecialKeys
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;

#nullable disable
namespace SourceGrid;

[Flags]
public enum GridSpecialKeys
{
  None = 0,
  Arrows = 16, // 0x00000010
  Tab = 32, // 0x00000020
  PageDownUp = 64, // 0x00000040
  Enter = 128, // 0x00000080
  Escape = 256, // 0x00000100
  Control = 512, // 0x00000200
  Shift = 1024, // 0x00000400
  Default = Shift | Control | Escape | Enter | PageDownUp | Tab | Arrows, // 0x000007F0
}
