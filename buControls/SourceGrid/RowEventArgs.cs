// Decompiled with JetBrains decompiler
// Type: SourceGrid.RowEventArgs
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;

#nullable disable
namespace SourceGrid;

public class RowEventArgs : EventArgs
{
  private int pRow;

  public int Row
  {
    get => this.pRow;
    set => this.pRow = value;
  }

  public RowEventArgs(int pRow) => this.pRow = pRow;
}
