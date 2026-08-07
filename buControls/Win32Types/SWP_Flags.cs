// Decompiled with JetBrains decompiler
// Type: Win32Types.SWP_Flags
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;

#nullable disable
namespace Win32Types;

[Flags]
internal enum SWP_Flags
{
  SWP_NOSIZE = 1,
  SWP_NOMOVE = 2,
  SWP_NOZORDER = 4,
  SWP_NOACTIVATE = 16, // 0x00000010
  SWP_FRAMECHANGED = 32, // 0x00000020
  SWP_SHOWWINDOW = 64, // 0x00000040
  SWP_HIDEWINDOW = 128, // 0x00000080
  SWP_NOOWNERZORDER = 512, // 0x00000200
  SWP_DRAWFRAME = SWP_FRAMECHANGED, // 0x00000020
  SWP_NOREPOSITION = SWP_NOOWNERZORDER, // 0x00000200
}
