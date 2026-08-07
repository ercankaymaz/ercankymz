// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Controllers.StandardBehavior
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace SourceGrid.Cells.Controllers;

public class StandardBehavior : ControllerBase
{
  public static readonly StandardBehavior Default = new StandardBehavior();

  public override void OnKeyDown(CellContext sender, KeyEventArgs e)
  {
    base.OnKeyDown(sender, e);
    if ((e.KeyCode != Keys.F2 || sender.Cell.Editor == null ? 0 : ((sender.Cell.Editor.EditableMode & EditableMode.F2Key) == EditableMode.F2Key ? 1 : 0)) == 0)
      return;
    e.Handled = true;
    sender.StartEdit();
  }

  public override void OnKeyPress(CellContext sender, KeyPressEventArgs e)
  {
    base.OnKeyPress(sender, e);
    if ((sender.Cell.Editor == null || (sender.Cell.Editor.EditableMode & EditableMode.AnyKey) != EditableMode.AnyKey || sender.IsEditing() ? 0 : (!char.IsControl(e.KeyChar) ? 1 : 0)) == 0)
      return;
    e.Handled = true;
    sender.StartEdit();
    sender.Cell.Editor.SendCharToEditor(e.KeyChar);
  }

  public override void OnDoubleClick(CellContext sender, EventArgs e)
  {
    base.OnDoubleClick(sender, e);
    if ((sender.Cell.Editor == null || (sender.Cell.Editor.EditableMode & EditableMode.DoubleClick) != EditableMode.DoubleClick ? 0 : (sender.Grid.Selection.ActivePosition == sender.Position ? 1 : 0)) == 0)
      return;
    sender.StartEdit();
  }

  public override void OnClick(CellContext sender, EventArgs e)
  {
    base.OnClick(sender, e);
    if ((sender.Cell.Editor == null || (sender.Cell.Editor.EditableMode & EditableMode.SingleClick) != EditableMode.SingleClick ? 0 : (sender.Grid.Selection.ActivePosition == sender.Position ? 1 : 0)) == 0)
      return;
    sender.StartEdit();
  }

  public override void OnFocusEntered(CellContext sender, EventArgs e)
  {
    base.OnFocusEntered(sender, e);
    sender.Grid.ShowCell(sender.Position, false);
    if ((sender.Cell.Editor == null ? 0 : ((sender.Cell.Editor.EditableMode & EditableMode.Focus) == EditableMode.Focus ? 1 : 0)) != 0)
      sender.StartEdit();
    if (sender.Grid == null)
      return;
    sender.Grid.InvalidateCell(sender.Position);
  }

  public override void OnFocusLeft(CellContext sender, EventArgs e)
  {
    base.OnFocusLeft(sender, e);
    if (sender.Grid == null)
      return;
    sender.Grid.InvalidateCell(sender.Position);
  }

  public override void OnValueChanged(CellContext sender, EventArgs e)
  {
    base.OnValueChanged(sender, e);
    if (sender.Grid == null)
      return;
    sender.Grid.InvalidateCell(sender.Position);
  }

  public override void OnEditEnded(CellContext sender, EventArgs e)
  {
    base.OnEditEnded(sender, e);
    sender.Grid.Selection.Invalidate();
  }

  public override void OnEditStarting(CellContext sender, CancelEventArgs e)
  {
    base.OnEditStarting(sender, e);
    sender.Grid.Selection.Invalidate();
  }

  public override bool CanReceiveFocus(CellContext sender, EventArgs e)
  {
    return sender.Grid.Columns.IsColumnVisible(sender.Position.Column) && sender.Grid.Rows.IsRowVisible(sender.Position.Row) && base.CanReceiveFocus(sender, e);
  }
}
