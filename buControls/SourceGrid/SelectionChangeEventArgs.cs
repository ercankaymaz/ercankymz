// Decompiled with JetBrains decompiler
// Type: SourceGrid.SelectionChangeEventArgs
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;

#nullable disable
namespace SourceGrid;

public class SelectionChangeEventArgs : EventArgs
{
  private Range p_Range;
  private SelectionChangeEventType p_Type;

  public SelectionChangeEventArgs(SelectionChangeEventType p_Type, Range p_Range)
  {
    this.p_Type = p_Type;
    this.p_Range = p_Range;
  }

  public Range Range => this.p_Range;

  public SelectionChangeEventType EventType => this.p_Type;
}
