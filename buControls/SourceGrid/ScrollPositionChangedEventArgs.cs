// Decompiled with JetBrains decompiler
// Type: SourceGrid.ScrollPositionChangedEventArgs
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;

#nullable disable
namespace SourceGrid;

public class ScrollPositionChangedEventArgs : EventArgs
{
  private int p_NewValue;
  private int p_OldValue;

  public int NewValue => this.p_NewValue;

  public int OldValue => this.p_OldValue;

  public int Delta => this.p_OldValue - this.p_NewValue;

  public ScrollPositionChangedEventArgs(int p_NewValue, int p_OldValue)
  {
    this.p_NewValue = p_NewValue;
    this.p_OldValue = p_OldValue;
  }
}
