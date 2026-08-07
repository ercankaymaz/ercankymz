// Decompiled with JetBrains decompiler
// Type: DevAge.ComponentModel.ConvertingObjectEventArgs
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;

#nullable disable
namespace DevAge.ComponentModel;

public class ConvertingObjectEventArgs : EventArgs
{
  private object p_Value;
  private Type p_DestinationType;
  private ConvertingStatus convertingStatus_0 = ConvertingStatus.Converting;

  public ConvertingObjectEventArgs(object p_Value, Type p_DestinationType)
  {
    this.p_Value = p_Value;
    this.p_DestinationType = p_DestinationType;
  }

  public object Value
  {
    get => this.p_Value;
    set => this.p_Value = value;
  }

  public Type DestinationType => this.p_DestinationType;

  public ConvertingStatus ConvertingStatus
  {
    get => this.convertingStatus_0;
    set => this.convertingStatus_0 = value;
  }
}
