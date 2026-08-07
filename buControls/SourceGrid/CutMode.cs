// Decompiled with JetBrains decompiler
// Type: SourceGrid.CutMode
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;

#nullable disable
namespace SourceGrid;

public enum CutMode
{
  None,
  [Obsolete("If you want to cut data before paste, then do so explicitly from code before pasting data")] CutOnPaste,
  CutImmediately,
}
