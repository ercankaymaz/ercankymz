// Decompiled with JetBrains decompiler
// Type: SourceGrid.IndexRangeEventArgs
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;

#nullable disable
namespace SourceGrid;

public class IndexRangeEventArgs : EventArgs
{
  private int p_iStartIndex;
  private int p_iCount;

  public IndexRangeEventArgs(int p_iStartIndex, int p_iCount)
  {
    this.p_iStartIndex = p_iStartIndex;
    this.p_iCount = p_iCount;
  }

  public int StartIndex => this.p_iStartIndex;

  public int Count => this.p_iCount;
}
