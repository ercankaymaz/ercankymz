// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Models.SortableHeader
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using DevAge.Drawing;
using System.Collections;

#nullable disable
namespace SourceGrid.Cells.Models;

public class SortableHeader : IModel, ISortableHeader
{
  private SortStatus sortStatus_0 = new SortStatus(HeaderSortStyle.None, (IComparer) null);

  public SortStatus GetSortStatus(CellContext cellContext) => this.sortStatus_0;

  public void SetSortMode(CellContext cellContext, HeaderSortStyle pStyle)
  {
    this.sortStatus_0.Style = pStyle;
  }

  public SortStatus SortStatus
  {
    get => this.sortStatus_0;
    set => this.sortStatus_0 = value;
  }
}
