// Decompiled with JetBrains decompiler
// Type: SourceGrid.FocusStyle
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;

#nullable disable
namespace SourceGrid;

[Flags]
public enum FocusStyle
{
  None = 0,
  RemoveFocusCellOnLeave = 1,
  RemoveSelectionOnLeave = 2,
  FocusFirstCellOnEnter = 4,
  Default = FocusFirstCellOnEnter | RemoveFocusCellOnLeave, // 0x00000005
}
