// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Virtual.ColumnHeader
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using SourceGrid.Cells.Controllers;
using SourceGrid.Cells.Models;
using SourceGrid.Cells.Views;

#nullable disable
namespace SourceGrid.Cells.Virtual;

public class ColumnHeader : CellVirtual
{
  public ColumnHeader()
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
}
