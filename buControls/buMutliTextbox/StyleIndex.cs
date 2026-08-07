// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.StyleIndex
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;

#nullable disable
namespace buMutliTextbox;

[Flags]
public enum StyleIndex : ushort
{
  None = 0,
  Style0 = 1,
  Style1 = 2,
  Style2 = 4,
  Style3 = 8,
  Style4 = 16, // 0x0010
  Style5 = 32, // 0x0020
  Style6 = 64, // 0x0040
  Style7 = 128, // 0x0080
  Style8 = 256, // 0x0100
  Style9 = 512, // 0x0200
  Style10 = 1024, // 0x0400
  Style11 = 2048, // 0x0800
  Style12 = 4096, // 0x1000
  Style13 = 8192, // 0x2000
  Style14 = 16384, // 0x4000
  Style15 = 32768, // 0x8000
  All = Style15 | Style14 | Style13 | Style12 | Style11 | Style10 | Style9 | Style8 | Style7 | Style6 | Style5 | Style4 | Style3 | Style2 | Style1 | Style0, // 0xFFFF
}
