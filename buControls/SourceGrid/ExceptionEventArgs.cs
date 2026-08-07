// Decompiled with JetBrains decompiler
// Type: SourceGrid.ExceptionEventArgs
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;

#nullable disable
namespace SourceGrid;

public class ExceptionEventArgs : EventArgs
{
  private Exception p_Exception;
  private bool bool_0 = false;

  public ExceptionEventArgs(Exception p_Exception) => this.p_Exception = p_Exception;

  public Exception Exception => this.p_Exception;

  public bool Handled
  {
    get => this.bool_0;
    set => this.bool_0 = value;
  }
}
