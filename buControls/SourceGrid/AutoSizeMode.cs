// Decompiled with JetBrains decompiler
// Type: SourceGrid.AutoSizeMode
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;

#nullable disable
namespace SourceGrid;

[Flags]
public enum AutoSizeMode
{
  None = 0,
  EnableAutoSize = 1,
  EnableAutoSizeView = 9,
  EnableStretch = 2,
  MinimumSize = 4,
  Default = EnableStretch | EnableAutoSize, // 0x00000003
}
