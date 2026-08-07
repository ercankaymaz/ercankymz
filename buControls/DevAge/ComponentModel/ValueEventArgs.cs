// Decompiled with JetBrains decompiler
// Type: DevAge.ComponentModel.ValueEventArgs
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;

#nullable disable
namespace DevAge.ComponentModel;

public class ValueEventArgs : EventArgs
{
  private object p_Value;

  public ValueEventArgs(object p_Value) => this.p_Value = p_Value;

  public object Value
  {
    get => this.p_Value;
    set => this.p_Value = value;
  }
}
