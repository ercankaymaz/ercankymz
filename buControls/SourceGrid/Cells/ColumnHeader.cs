// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.ColumnHeader
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using DevAge.Drawing;
using SourceGrid.Cells.Controllers;
using SourceGrid.Cells.Models;
using SourceGrid.Cells.Views;
using System.Collections;
using System.Runtime.CompilerServices;

#nullable disable
namespace SourceGrid.Cells;

public class ColumnHeader : Cell
{
  public ColumnHeader()
    : this((object) null)
  {
  }

  public ColumnHeader(object cellValue)
    : base(cellValue)
  {
    this.View = (IView) SourceGrid.Cells.Views.ColumnHeader.Default;
    this.Model.AddModel((IModel) new SourceGrid.Cells.Models.SortableHeader());
    this.AddController((IController) Unselectable.Default);
    this.AddController((IController) MouseInvalidate.Default);
    this.ResizeEnabled = true;
    this.AutomaticSortEnabled = true;
  }

  public bool ResizeEnabled
  {
    get => this.FindController(typeof (Resizable)) == Resizable.ResizeWidth;
    set
    {
      if (value == this.ResizeEnabled)
        return;
      if (value)
        this.AddController((IController) Resizable.ResizeWidth);
      else
        this.RemoveController((IController) Resizable.ResizeWidth);
    }
  }

  public bool AutomaticSortEnabled
  {
    get => this.FindController(typeof (SourceGrid.Cells.Controllers.SortableHeader)) == SourceGrid.Cells.Controllers.SortableHeader.Default;
    set
    {
      if (value == this.AutomaticSortEnabled)
        return;
      if (value)
        this.AddController((IController) SourceGrid.Cells.Controllers.SortableHeader.Default);
      else
        this.RemoveController((IController) SourceGrid.Cells.Controllers.SortableHeader.Default);
    }
  }

  [SpecialName]
  private SourceGrid.Cells.Models.SortableHeader method_2()
  {
    return (SourceGrid.Cells.Models.SortableHeader) this.Model.FindModel(typeof (SourceGrid.Cells.Models.SortableHeader));
  }

  public SortStatus SortStatus
  {
    get => this.method_2().SortStatus;
    set => this.method_2().SortStatus = value;
  }

  public IComparer SortComparer
  {
    get => this.SortStatus.Comparer;
    set => this.SortStatus = new SortStatus(this.SortStatus.Style, value);
  }

  public HeaderSortStyle SortStyle
  {
    get => this.SortStatus.Style;
    set => this.SortStatus = new SortStatus(value, this.SortStatus.Comparer);
  }

  public void Sort(bool ascending)
  {
    ((SourceGrid.Cells.Controllers.SortableHeader) this.FindController(typeof (SourceGrid.Cells.Controllers.SortableHeader)) ?? throw new SourceGridException("No SortableHeader controller found")).SortColumn(new CellContext((GridVirtual) this.Grid, this.Range.Start, (ICellVirtual) this), ascending, this.SortComparer);
  }
}
