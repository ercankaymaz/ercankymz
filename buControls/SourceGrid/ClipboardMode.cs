// Decompiled with JetBrains decompiler
// Type: SourceGrid.ClipboardMode
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;

#nullable disable
namespace SourceGrid;

[Flags]
public enum ClipboardMode
{
  None = 0,
  Copy = 1,
  Cut = 2,
  Paste = 4,
  Delete = 8,
  All = Delete | Paste | Cut | Copy, // 0x0000000F
}
