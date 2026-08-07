// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Controllers.CheckBox
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using SourceGrid.Cells.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

#nullable disable
namespace SourceGrid.Cells.Controllers;

public class CheckBox : ControllerBase
{
  public static readonly CheckBox Default = new CheckBox();
  private MouseButtons mouseButtons_0 = MouseButtons.None;
  private bool p_bAutoChangeValueOfSelectedCells = false;

  public event EventHandler CheckedChanged;

  protected virtual void OnCheckedChanged(EventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.eventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.eventHandler_0((object) this, e);
  }

  public CheckBox()
  {
  }

  public CheckBox(bool p_bAutoChangeValueOfSelectedCells)
  {
    this.p_bAutoChangeValueOfSelectedCells = p_bAutoChangeValueOfSelectedCells;
  }

  public override void OnKeyPress(CellContext sender, KeyPressEventArgs e)
  {
    base.OnKeyPress(sender, e);
    if (e.KeyChar != ' ')
      return;
    this.method_0(sender, (EventArgs) e);
  }

  public override void OnMouseDown(CellContext sender, MouseEventArgs e)
  {
    base.OnMouseDown(sender, e);
    this.mouseButtons_0 = e.Button;
  }

  public override void OnClick(CellContext sender, EventArgs e)
  {
    base.OnClick(sender, e);
    if (this.mouseButtons_0 != MouseButtons.Left)
      return;
    this.method_0(sender, e);
  }

  public bool AutoChangeValueOfSelectedCells => this.p_bAutoChangeValueOfSelectedCells;

  private void method_0(CellContext cellContext_0, EventArgs eventArgs_0)
  {
    ICheckBox model = (ICheckBox) cellContext_0.Cell.Model.FindModel(typeof (ICheckBox));
    CheckBoxStatus checkBoxStatus = model != null ? model.GetCheckBoxStatus(cellContext_0) : throw new SourceGridException("Models.ICheckBox not found");
    if (!checkBoxStatus.CheckEnable)
      return;
    bool bool_0 = true;
    if (checkBoxStatus.Checked.HasValue)
      bool_0 = !checkBoxStatus.Checked.Value;
    cellContext_0.StartEdit();
    try
    {
      model.SetCheckedValue(cellContext_0, new bool?(bool_0));
      cellContext_0.EndEdit(false);
      this.OnCheckedChanged(EventArgs.Empty);
    }
    catch (Exception ex)
    {
      cellContext_0.EndEdit(true);
      throw new Exception(string.Empty, ex);
    }
    if (!this.AutoChangeValueOfSelectedCells)
      return;
    this.method_1(cellContext_0, bool_0);
  }

  private void method_1(CellContext cellContext_0, bool bool_0)
  {
    foreach (Position cellsPosition in (List<Position>) cellContext_0.Grid.Selection.GetSelectionRegion().GetCellsPositions())
    {
      ICellVirtual cell = cellContext_0.Grid.GetCell(cellsPosition);
      ICheckBox model;
      if ((cell == this || cell == null ? 0 : ((model = (ICheckBox) cell.Model.FindModel(typeof (ICheckBox))) != null ? 1 : 0)) != 0)
      {
        CellContext cellContext = new CellContext(cellContext_0.Grid, cellsPosition, cell);
        cellContext.StartEdit();
        try
        {
          model.SetCheckedValue(cellContext, new bool?(bool_0));
          cellContext.EndEdit(false);
        }
        catch (Exception ex)
        {
          cellContext.EndEdit(true);
          throw;
        }
      }
    }
  }
}
