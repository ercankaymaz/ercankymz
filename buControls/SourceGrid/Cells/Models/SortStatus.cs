// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Models.SortStatus
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using DevAge.Drawing;
using System.Collections;

#nullable disable
namespace SourceGrid.Cells.Models;

public struct SortStatus(HeaderSortStyle p_Style)
{
  public HeaderSortStyle Style = p_Style;
  public IComparer Comparer = (IComparer) null;

  public SortStatus(HeaderSortStyle p_Style, IComparer p_Comparer)
    : this(p_Style)
  {
    this.Comparer = p_Comparer;
  }
}
