// Decompiled with JetBrains decompiler
// Type: DevAge.Windows.Forms.RestoreFlags
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;

#nullable disable
namespace DevAge.Windows.Forms;

[Flags]
public enum RestoreFlags
{
  None = 0,
  WindowState = 1,
  Size = 2,
  Location = 4,
  Minimized = 8,
}
