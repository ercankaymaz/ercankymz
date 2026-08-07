// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Controllers.MouseSelection
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace SourceGrid.Cells.Controllers;

public class MouseSelection : ControllerBase
{
  public static MouseSelection Default = new MouseSelection();
  internal Timer timer_0;
  internal GridVirtual gridVirtual_0;
  internal CellContext cellContext_0 = CellContext.Empty;
  internal MouseEventArgs mouseEventArgs_0 = (MouseEventArgs) null;

  public MouseButtons MouseButtons { get; set; }

  public MouseSelection() => this.MouseButtons = MouseButtons.Left;

  public override void OnMouseDown(CellContext sender, MouseEventArgs e)
  {
    base.OnMouseDown(sender, e);
    if ((e.Button & this.MouseButtons) == MouseButtons.None)
      return;
    GridVirtual grid = sender.Grid;
    bool flag1 = (Control.ModifierKeys & Keys.Control) == Keys.Control && (grid.SpecialKeys & GridSpecialKeys.Control) == GridSpecialKeys.Control;
    if ((((Control.ModifierKeys & Keys.Shift) != Keys.Shift ? 0 : ((grid.SpecialKeys & GridSpecialKeys.Shift) == GridSpecialKeys.Shift ? 1 : 0)) == 0 ? 1 : (!grid.Selection.EnableMultiSelection ? 1 : 0)) != 0)
    {
      bool flag2 = grid.Selection.EnableMultiSelection & flag1;
      if ((!flag1 || !grid.Selection.IsSelectedCell(sender.Position) ? 0 : (grid.Selection.ActivePosition != sender.Position ? 1 : 0)) != 0)
        grid.Selection.SelectCell(sender.Position, false);
      else
        grid.Selection.Focus(sender.Position, !flag2);
    }
    else
    {
      grid.Selection.ResetSelection(true);
      Range range = new Range(grid.Selection.ActivePosition, sender.Position);
      grid.Selection.SelectRange(range, true);
    }
    if (!grid.GetScrollableArea().Contains(e.Location))
      return;
    Class39.smethod_493(this, grid);
  }

  public override void OnMouseUp(CellContext sender, MouseEventArgs e)
  {
    base.OnMouseUp(sender, e);
    if (e.Button != MouseButtons.Left)
      return;
    sender.Grid.MouseSelectionFinish();
    Class39.smethod_284(this);
  }

  public override void OnMouseMove(CellContext sender, MouseEventArgs e)
  {
    if ((this.gridVirtual_0 == null ? 0 : (this.mouseEventArgs_0 != null ? 1 : 0)) != 0)
    {
      this.cellContext_0 = CellContext.Empty;
      this.mouseEventArgs_0 = (MouseEventArgs) null;
    }
    base.OnMouseMove(sender, e);
    if ((!sender.Grid.Selection.EnableMultiSelection || sender.Grid.MouseDownPosition.IsEmpty() ? 1 : (sender.Grid.MouseDownPosition != sender.Grid.Selection.ActivePosition ? 1 : 0)) != 0)
      return;
    int? visibleScrollableRow1 = sender.Grid.Rows.LastVisibleScrollableRow;
    int? scrollableColumn1 = sender.Grid.Columns.LastVisibleScrollableColumn;
    int? visibleScrollableRow2 = sender.Grid.Rows.FirstVisibleScrollableRow;
    int? scrollableColumn2 = sender.Grid.Columns.FirstVisibleScrollableColumn;
    int? nullable1 = sender.Grid.Rows.RowAtPoint(e.Y);
    int? nullable2 = sender.Grid.Columns.ColumnAtPoint(e.X);
    if (!nullable1.HasValue)
      nullable1 = e.Y >= 0 ? visibleScrollableRow1 : visibleScrollableRow2;
    if (!nullable2.HasValue)
      nullable2 = e.X >= 0 ? scrollableColumn1 : scrollableColumn2;
    if ((!nullable2.HasValue ? 1 : (!nullable1.HasValue ? 1 : 0)) != 0)
      return;
    if ((!visibleScrollableRow1.HasValue ? 0 : (nullable1.Value > visibleScrollableRow1.Value ? 1 : 0)) != 0)
      nullable1 = visibleScrollableRow1;
    if ((!scrollableColumn1.HasValue ? 0 : (nullable2.Value > scrollableColumn1.Value ? 1 : 0)) != 0)
      nullable2 = scrollableColumn1;
    int? nullable3;
    int num1;
    if (visibleScrollableRow2.HasValue)
    {
      nullable3 = nullable1;
      int num2 = visibleScrollableRow2.Value;
      num1 = nullable3.GetValueOrDefault() < num2 & nullable3.HasValue ? 1 : 0;
    }
    else
      num1 = 0;
    if (num1 != 0)
      nullable1 = visibleScrollableRow2;
    int num3;
    if (scrollableColumn2.HasValue)
    {
      nullable3 = nullable2;
      int num4 = scrollableColumn2.Value;
      num3 = nullable3.GetValueOrDefault() < num4 & nullable3.HasValue ? 1 : 0;
    }
    else
      num3 = 0;
    if (num3 != 0)
      nullable2 = scrollableColumn2;
    Position position = new Position(nullable1.Value, nullable2.Value);
    if (sender.Grid.GetPositionType(position) != sender.Grid.GetPositionType(sender.Grid.Selection.ActivePosition))
      return;
    sender.Grid.ChangeMouseSelectionCorner(position);
    if (this.gridVirtual_0 == null)
      return;
    this.cellContext_0 = sender;
    this.mouseEventArgs_0 = e;
  }

  public override void OnDoubleClick(CellContext sender, EventArgs e)
  {
    base.OnDoubleClick(sender, e);
    Class39.smethod_284(this);
  }

  internal void method_0(object sender, EventArgs e)
  {
    if (this.gridVirtual_0 == null)
      return;
    if (this.gridVirtual_0.IsDisposed)
      Class39.smethod_284(this);
    else if (!this.gridVirtual_0.Focused)
    {
      Class39.smethod_284(this);
    }
    else
    {
      Point client = this.gridVirtual_0.PointToClient(Control.MousePosition);
      this.gridVirtual_0.ScrollOnPoint(client);
      if (this.mouseEventArgs_0 == null)
        return;
      this.OnMouseMove(this.cellContext_0, new MouseEventArgs(this.mouseEventArgs_0.Button, this.mouseEventArgs_0.Clicks, client.X, client.Y, this.mouseEventArgs_0.Delta));
    }
  }
}
