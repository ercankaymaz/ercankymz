// Decompiled with JetBrains decompiler
// Type: SourceGrid.EditableMode
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;

#nullable disable
namespace SourceGrid;

[Flags]
public enum EditableMode
{
  None = 0,
  F2Key = 1,
  DoubleClick = 2,
  SingleClick = 4,
  AnyKey = 9,
  Focus = 16, // 0x00000010
  Default = AnyKey | DoubleClick, // 0x0000000B
}
