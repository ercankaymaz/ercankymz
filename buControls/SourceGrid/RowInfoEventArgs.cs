// Decompiled with JetBrains decompiler
// Type: SourceGrid.RowInfoEventArgs
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;

#nullable disable
namespace SourceGrid;

public class RowInfoEventArgs : EventArgs
{
  private RowInfo p_RowInfo;

  public RowInfoEventArgs(RowInfo p_RowInfo) => this.p_RowInfo = p_RowInfo;

  public RowInfo Row => this.p_RowInfo;
}
