// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Virtual.RowHeader
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using SourceGrid.Cells.Controllers;
using SourceGrid.Cells.Views;

#nullable disable
namespace SourceGrid.Cells.Virtual;

public class RowHeader : CellVirtual
{
  public RowHeader()
  {
    this.View = (IView) SourceGrid.Cells.Views.RowHeader.Default;
    this.AddController((IController) Unselectable.Default);
    this.AddController((IController) MouseInvalidate.Default);
    this.ResizeEnabled = true;
  }

  public bool ResizeEnabled
  {
    get => this.FindController(typeof (Resizable)) == Resizable.ResizeHeight;
    set
    {
      if (value == this.ResizeEnabled)
        return;
      if (value)
        this.AddController((IController) Resizable.ResizeHeight);
      else
        this.RemoveController((IController) Resizable.ResizeHeight);
    }
  }
}
