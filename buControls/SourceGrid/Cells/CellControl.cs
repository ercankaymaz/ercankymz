// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.CellControl
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Windows.Forms;

#nullable disable
namespace SourceGrid.Cells;

[Obsolete("I will soon remove this class. If you need to add a user control to the grid I suggest to manually add or remove it using the Grid.LinkedControls collection.")]
public class CellControl : Cell
{
  private Control control;
  private LinkedControlScrollMode scrollMode = LinkedControlScrollMode.BasedOnPosition;
  private bool useCellBorder = true;

  public CellControl(Control control)
    : base((object) null)
  {
    this.control = control;
  }

  public CellControl(Control control, LinkedControlScrollMode scrollMode, bool useCellBorder)
    : this(control)
  {
    this.control = control;
    this.scrollMode = scrollMode;
    this.useCellBorder = useCellBorder;
  }

  public Control Control => this.control;

  public override void BindToGrid(Grid p_grid, Position p_Position)
  {
    base.BindToGrid(p_grid, p_Position);
    this.Grid.LinkedControls.Add(new LinkedControlValue(this.control, this.Range.Start)
    {
      ScrollMode = this.scrollMode,
      UseCellBorder = this.useCellBorder
    });
    this.Grid.ArrangeLinkedControls();
  }

  public override void UnBindToGrid()
  {
    if (this.Grid.LinkedControls.GetByControl(this.control) != null)
      this.Grid.LinkedControls.Remove(this.Grid.LinkedControls.GetByControl(this.control));
    base.UnBindToGrid();
  }
}
