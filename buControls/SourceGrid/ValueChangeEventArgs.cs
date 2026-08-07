// Decompiled with JetBrains decompiler
// Type: SourceGrid.ValueChangeEventArgs
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;

#nullable disable
namespace SourceGrid;

public class ValueChangeEventArgs : EventArgs
{
  public ValueChangeEventArgs(object oldValue, object newValue)
  {
    this.NewValue = newValue;
    this.OldValue = oldValue;
  }

  public object NewValue { get; set; }

  public object OldValue { get; set; }
}
