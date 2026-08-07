// Decompiled with JetBrains decompiler
// Type: SourceGrid.CellContext
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using SourceGrid.Cells;
using System;
using System.ComponentModel;
using System.Drawing;

#nullable disable
namespace SourceGrid;

public struct CellContext
{
  public static readonly CellContext Empty = new CellContext((GridVirtual) null, Position.Empty, (ICellVirtual) null);
  public Position Position;
  public ICellVirtual Cell;
  public GridVirtual Grid;

  public CellContext(GridVirtual pGridVirtual, Position pPosition, ICellVirtual pCell)
  {
    this.Position = pPosition;
    this.Cell = pCell;
    this.Grid = pGridVirtual;
  }

  public CellContext(GridVirtual pGridVirtual, Position pPosition)
  {
    this.Position = pPosition;
    this.Grid = pGridVirtual;
    this.Cell = this.Grid.GetCell(this.Position);
  }

  public Size Measure(Size maxLayoutArea)
  {
    Size size1;
    if (this.Cell == null)
    {
      size1 = Size.Empty;
    }
    else
    {
      if (this.Grid == null)
        throw new SourceGridException("Grid is null");
      Size size2 = this.Cell.View.Measure(this, maxLayoutArea);
      Range cellRange = this.Grid.PositionToCellRange(this.Position);
      size2.Width = (int) Math.Ceiling((double) size2.Width / (double) cellRange.ColumnsCount);
      size2.Height = (int) Math.Ceiling((double) size2.Height / (double) cellRange.RowsCount);
      size1 = size2;
    }
    return size1;
  }

  public void StartEdit()
  {
    if (this.Cell == null)
      throw new SourceGridException("No cell at position " + this.Position.ToString());
    if (this.Grid == null)
      throw new SourceGridException("Grid is null");
    if (this.Cell.Editor == null || !this.Cell.Editor.EnableEdit || this.IsEditing() || !this.Grid.Selection.Focus(this.Position, true))
      return;
    CancelEventArgs e = new CancelEventArgs();
    this.Grid.Controller.OnEditStarting(this, e);
    if (e.Cancel)
      return;
    this.Cell.Editor.vmethod_0(this);
    this.Grid.Controller.OnEditStarted(this, EventArgs.Empty);
  }

  public bool EndEdit(bool cancel)
  {
    bool flag1;
    if (this.Cell == null)
      flag1 = true;
    else if (this.Grid == null)
      flag1 = true;
    else if ((this.Cell.Editor == null ? 0 : (this.Cell.Editor.IsEditing ? 1 : 0)) != 0)
    {
      CellContext editCellContext = this.Cell.Editor.EditCellContext;
      bool flag2;
      if (flag2 = this.Cell.Editor.vmethod_1(cancel))
        this.Grid.Controller.OnEditEnded(editCellContext, EventArgs.Empty);
      flag1 = flag2;
    }
    else
      flag1 = true;
    return flag1;
  }

  public bool IsEditing()
  {
    return this.Cell != null && this.Grid != null && this.Cell.Editor != null && this.Cell.Editor.IsEditing && this.Cell.Editor.EditCellContext == this;
  }

  public bool CanBeDrawn()
  {
    if (this.Cell == null)
      return false;
    return this.Cell.Editor == null || this.Cell.Editor.EnableCellDrawOnEdit || !this.IsEditing();
  }

  public void Invalidate()
  {
    if (this.Cell == null || this.Grid == null)
      return;
    this.Grid.InvalidateCell(this.Position);
  }

  public string DisplayText
  {
    get
    {
      if (this.Cell == null)
        return (string) null;
      try
      {
        object p_Value = this.Cell.Model.ValueModel.GetValue(this);
        if (this.Cell.Editor != null)
          return this.Cell.Editor.ValueToDisplayString(p_Value);
        return p_Value == null ? string.Empty : p_Value.ToString();
      }
      catch (Exception ex)
      {
        return "Error:" + ex.Message;
      }
    }
  }

  public object Value
  {
    get => this.Cell.Model.ValueModel.GetValue(this);
    set => this.Cell.Model.ValueModel.SetValue(this, value);
  }

  public Range CellRange => this.Grid.PositionToCellRange(this.Position);

  public bool IsEmpty() => this.Equals(CellContext.Empty);

  public override int GetHashCode() => this.Position.GetHashCode();

  public bool Equals(CellContext other)
  {
    return this.Position == other.Position && this.Cell == other.Cell && this.Grid == other.Grid;
  }

  public override bool Equals(object obj) => this.Equals((CellContext) obj);

  public static bool operator ==(CellContext Left, CellContext Right) => Left.Equals(Right);

  public static bool operator !=(CellContext Left, CellContext Right) => !Left.Equals(Right);

  public override string ToString() => this.Position.ToString();
}
