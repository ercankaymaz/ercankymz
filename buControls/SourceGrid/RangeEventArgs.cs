// Decompiled with JetBrains decompiler
// Type: SourceGrid.RangeEventArgs
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;

#nullable disable
namespace SourceGrid;

public class RangeEventArgs : EventArgs
{
  private Range p_GridRange;

  public RangeEventArgs(Range p_GridRange) => this.p_GridRange = p_GridRange;

  public Range Range => this.p_GridRange;
}
