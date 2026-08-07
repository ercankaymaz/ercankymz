// Decompiled with JetBrains decompiler
// Type: SourceGrid.Selection.SelectionBase
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using DevAge.Drawing;
using ns7;
using SourceGrid.Cells;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

#nullable disable
namespace SourceGrid.Selection;

public abstract class SelectionBase : IGridSelection
{
  private GridVirtual gridVirtual_0;
  internal Position position_0 = Position.Empty;
  private Color color_0 = Color.Transparent;
  private FocusStyle focusStyle_0 = FocusStyle.Default;
  private bool bool_0 = true;
  private Color color_1 = Color.FromArgb(75, Color.FromKnownColor(KnownColor.Highlight));
  private RectangleBorder rectangleBorder_0 = new RectangleBorder(new BorderLine(Color.Black, 2f));

  public virtual void BindToGrid(GridVirtual p_grid) => this.gridVirtual_0 = p_grid;

  public virtual void UnBindToGrid() => this.gridVirtual_0 = (GridVirtual) null;

  public GridVirtual Grid => this.gridVirtual_0;

  public Position ActivePosition
  {
    get => this.position_0;
    protected set => this.position_0 = value;
  }

  private bool method_0()
  {
    return !this.ActivePosition.IsEmpty() && this.Grid != null && this.Grid.CompleteRange.Contains(this.ActivePosition);
  }

  public bool Focus(Position pCellToActivate, bool pResetSelection)
  {
    bool flag1 = false;
    if (!pCellToActivate.IsEmpty() & pResetSelection)
      flag1 = true;
    bool flag2;
    if (pCellToActivate != this.ActivePosition)
    {
      ICellVirtual cell = this.Grid.GetCell(pCellToActivate);
      CellContext sender1 = new CellContext(this.Grid, pCellToActivate, cell);
      ChangeActivePositionEventArgs e1 = new ChangeActivePositionEventArgs(this.ActivePosition, pCellToActivate);
      if (cell != null)
      {
        this.Grid.Controller.OnFocusEntering(sender1, (CancelEventArgs) e1);
        if (e1.Cancel)
        {
          flag2 = false;
          goto label_25;
        }
        if (!this.Grid.Controller.CanReceiveFocus(sender1, (EventArgs) e1))
        {
          flag2 = false;
          goto label_25;
        }
      }
      if (cell != null && !this.Grid.Focus(false))
      {
        flag2 = false;
      }
      else
      {
        RangeRegion removedRange = (RangeRegion) null;
        if (this.method_0())
        {
          removedRange = new RangeRegion(this.ActivePosition);
          CellContext sender2 = new CellContext(this.Grid, this.ActivePosition, this.Grid.GetCell(this.ActivePosition));
          ChangeActivePositionEventArgs e2 = new ChangeActivePositionEventArgs(this.ActivePosition, pCellToActivate);
          this.Grid.Controller.OnFocusLeaving(sender2, (CancelEventArgs) e2);
          if (e2.Cancel)
          {
            flag2 = false;
            goto label_25;
          }
          this.OnCellLostFocus(e2);
          if (e2.Cancel)
          {
            flag2 = false;
            goto label_25;
          }
        }
        else
          this.position_0 = Position.Empty;
        if (flag1)
          this.ResetSelection(false);
        bool flag3;
        if (cell != null)
        {
          this.OnCellGotFocus(e1);
          flag3 = !e1.Cancel;
        }
        else
          flag3 = true;
        this.OnSelectionChanged(new RangeRegionChangedEventArgs(new RangeRegion(pCellToActivate), removedRange));
        flag2 = flag3;
      }
    }
    else if (!pCellToActivate.IsEmpty())
    {
      Class39.smethod_255(this);
      flag2 = this.Grid.ContainsFocus || this.Grid.Focus();
    }
    else
      flag2 = true;
label_25:
    return flag2;
  }

  public virtual bool FocusFirstCell(bool pResetSelection)
  {
    Position pCellToActivate = this.method_1(this.GetSelectionRegion().GetCellsPositions());
    if (pCellToActivate.IsEmpty())
      pCellToActivate = this.method_2();
    return !pCellToActivate.IsEmpty() && this.Focus(pCellToActivate, pResetSelection);
  }

  public bool FocusColumn(int column)
  {
    bool flag;
    if (this.Grid.Columns.Count > column)
    {
      for (int row = 0; row < this.Grid.Rows.Count; ++row)
      {
        Position position = new Position(row, column);
        if (this.Grid.Controller.CanReceiveFocus(new CellContext(this.Grid, position), EventArgs.Empty))
        {
          flag = this.Focus(position, true);
          goto label_8;
        }
      }
      flag = this.Focus(Position.Empty, true);
    }
    else
      flag = this.Focus(Position.Empty, true);
label_8:
    return flag;
  }

  public bool FocusRow(int row)
  {
    bool flag;
    if (this.Grid.Rows.Count > row)
    {
      for (int col = 0; col < this.Grid.Columns.Count; ++col)
      {
        Position position = new Position(row, col);
        if (this.Grid.Controller.CanReceiveFocus(new CellContext(this.Grid, position), EventArgs.Empty))
        {
          flag = this.Focus(position, true);
          goto label_8;
        }
      }
      flag = this.Focus(Position.Empty, true);
    }
    else
      flag = this.Focus(Position.Empty, true);
label_8:
    return flag;
  }

  private Position method_1(PositionCollection positionCollection_0)
  {
    Position position1;
    foreach (Position position2 in (List<Position>) positionCollection_0)
    {
      if (this.CanReceiveFocus(position2))
      {
        position1 = position2;
        goto label_7;
      }
    }
    position1 = Position.Empty;
label_7:
    return position1;
  }

  private Position method_2()
  {
    Position position1;
    for (int fixedRows = this.Grid.FixedRows; fixedRows < this.Grid.Rows.Count; ++fixedRows)
    {
      for (int fixedColumns = this.Grid.FixedColumns; fixedColumns < this.Grid.Columns.Count; ++fixedColumns)
      {
        Position position2 = new Position(fixedRows, fixedColumns);
        if (this.CanReceiveFocus(position2))
        {
          position1 = position2;
          goto label_9;
        }
      }
    }
    position1 = Position.Empty;
label_9:
    return position1;
  }

  public Color FocusBackColor
  {
    get => this.color_0;
    set
    {
      this.color_0 = value;
      this.Invalidate();
    }
  }

  public FocusStyle FocusStyle
  {
    get => this.focusStyle_0;
    set => this.focusStyle_0 = value;
  }

  public bool CanReceiveFocus(Position position)
  {
    bool focus;
    if (this.Grid.CompleteRange.Contains(position))
    {
      ICellVirtual cell = this.Grid.GetCell(position);
      focus = cell != null && this.Grid.Controller.CanReceiveFocus(new CellContext(this.Grid, position, cell), EventArgs.Empty);
    }
    else
      focus = false;
    return focus;
  }

  public event ChangeActivePositionEventHandler CellGotFocus;

  public event ChangeActivePositionEventHandler CellLostFocus;

  public event RowCancelEventHandler FocusRowLeaving;

  public event RowEventHandler FocusRowEntered;

  public event ColumnCancelEventHandler FocusColumnLeaving;

  public event ColumnEventHandler FocusColumnEntered;

  protected virtual void OnFocusRowLeaving(RowCancelEventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.rowCancelEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.rowCancelEventHandler_0((object) this, e);
  }

  protected virtual void OnFocusRowEntered(RowEventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.rowEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.rowEventHandler_0((object) this, e);
  }

  protected virtual void OnFocusColumnLeaving(ColumnCancelEventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.columnCancelEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.columnCancelEventHandler_0((object) this, e);
  }

  protected virtual void OnFocusColumnEntered(ColumnEventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.columnEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.columnEventHandler_0((object) this, e);
  }

  protected virtual void OnCellGotFocus(ChangeActivePositionEventArgs e)
  {
    if (!this.Grid.CompleteRange.Contains(e.NewFocusPosition))
      e.Cancel = true;
    if (e.Cancel)
      return;
    // ISSUE: reference to a compiler-generated field
    if (this.changeActivePositionEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.changeActivePositionEventHandler_0(this, e);
    }
    if (e.Cancel)
      return;
    this.position_0 = e.NewFocusPosition;
    this.SelectCell(this.position_0, true);
    this.Invalidate();
    this.Grid.Controller.OnFocusEntered(new CellContext(this.Grid, e.NewFocusPosition), EventArgs.Empty);
    int row1 = e.NewFocusPosition.Row;
    Position position = e.OldFocusPosition;
    int row2 = position.Row;
    if (row1 != row2)
    {
      position = this.ActivePosition;
      this.OnFocusRowEntered(new RowEventArgs(position.Row));
    }
    position = e.NewFocusPosition;
    int column1 = position.Column;
    position = e.OldFocusPosition;
    int column2 = position.Column;
    if (column1 == column2)
      return;
    position = this.ActivePosition;
    this.OnFocusColumnEntered(new ColumnEventArgs(position.Column));
  }

  protected virtual void OnCellLostFocus(ChangeActivePositionEventArgs e)
  {
    if (e.Cancel)
      return;
    // ISSUE: reference to a compiler-generated field
    if (this.changeActivePositionEventHandler_1 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.changeActivePositionEventHandler_1(this, e);
    }
    if (e.Cancel)
      return;
    int row1 = this.ActivePosition.Row;
    Position position = this.ActivePosition;
    int num1;
    if (!position.IsEmpty())
    {
      int num2 = row1;
      position = e.NewFocusPosition;
      int row2 = position.Row;
      num1 = num2 != row2 ? 1 : 0;
    }
    else
      num1 = 0;
    if (num1 != 0)
    {
      int currentFocusedRow = row1;
      position = e.NewFocusPosition;
      int row3 = position.Row;
      RowCancelEventArgs e1 = new RowCancelEventArgs(currentFocusedRow, row3);
      this.OnFocusRowLeaving(e1);
      if (e1.Cancel)
      {
        e.Cancel = true;
        return;
      }
    }
    position = this.ActivePosition;
    int column1 = position.Column;
    position = this.ActivePosition;
    int num3;
    if (!position.IsEmpty())
    {
      int num4 = column1;
      position = e.NewFocusPosition;
      int column2 = position.Column;
      num3 = num4 != column2 ? 1 : 0;
    }
    else
      num3 = 0;
    if (num3 != 0)
    {
      int currentFocusedColumn = column1;
      position = e.NewFocusPosition;
      int column3 = position.Column;
      ColumnCancelEventArgs e2 = new ColumnCancelEventArgs(currentFocusedColumn, column3);
      this.OnFocusColumnLeaving(e2);
      if (e2.Cancel)
      {
        e.Cancel = true;
        return;
      }
    }
    this.position_0 = Position.Empty;
    this.Grid.Controller.OnFocusLeft(new CellContext(this.Grid, e.OldFocusPosition), EventArgs.Empty);
  }

  public bool MoveActiveCell(int rowShift, int colShift)
  {
    return this.MoveActiveCell(this.ActivePosition, rowShift, colShift);
  }

  public bool MoveActiveCell(int rowShift, int colShift, bool resetSelection)
  {
    return this.MoveActiveCell(this.ActivePosition, rowShift, colShift, resetSelection);
  }

  public bool MoveActiveCell(Position start, int rowShift, int colShift)
  {
    return this.MoveActiveCell(start, rowShift, colShift, true);
  }

  public bool MoveActiveCell(Position start, int rowShift, int colShift, bool resetSelection)
  {
    Position position = Position.Empty;
    bool flag;
    if (start.IsEmpty())
    {
      position = new Position(0, 0);
      if (this.CanReceiveFocus(position))
      {
        flag = this.Focus(position, true);
        goto label_12;
      }
      start = position;
      position = Position.Empty;
    }
    int row1 = start.Row;
    int column = start.Column;
    int row2 = row1 + rowShift;
    for (int col = column + colShift; (!position.IsEmpty() || row2 >= this.Grid.Rows.Count || col >= this.Grid.Columns.Count || row2 < 0 ? 0 : (col >= 0 ? 1 : 0)) != 0; col += colShift)
    {
      position = new Position(row2, col);
      if (this.Grid.PositionToStartPosition(position) == start)
        position = Position.Empty;
      else if (!this.CanReceiveFocus(position))
        position = Position.Empty;
      row2 += rowShift;
    }
    flag = !position.IsEmpty() && this.Focus(position, resetSelection);
label_12:
    return flag;
  }

  public bool MoveActiveCell(int rowShift1, int colShift1, int rowShift2, int colShift2)
  {
    return this.MoveActiveCell(this.ActivePosition, rowShift1, colShift1, rowShift2, colShift2);
  }

  public bool MoveActiveCell(
    Position start,
    int rowShift1,
    int colShift1,
    int rowShift2,
    int colShift2)
  {
    bool flag;
    if (this.MoveActiveCell(start, rowShift1, colShift1))
    {
      flag = true;
    }
    else
    {
      Position position = Position.Empty;
      if (start.IsEmpty())
      {
        position = new Position(0, 0);
        if (this.CanReceiveFocus(position))
        {
          flag = this.Focus(position, true);
          goto label_19;
        }
        start = position;
      }
      int row;
      switch (rowShift2)
      {
        case int.MinValue:
          row = 0;
          break;
        case int.MaxValue:
          row = this.Grid.Rows.Count - 1;
          break;
        default:
          row = start.Row + rowShift2;
          break;
      }
      int col;
      switch (colShift2)
      {
        case int.MinValue:
          col = 0;
          break;
        case int.MaxValue:
          col = this.Grid.Columns.Count - 1;
          break;
        default:
          col = start.Column + colShift2;
          break;
      }
      position = new Position(row, col);
      if ((position == start ? 1 : (!this.Grid.CompleteRange.Contains(position) ? 1 : 0)) != 0)
        flag = false;
      else if (this.CanReceiveFocus(position))
      {
        flag = this.Focus(position, true);
      }
      else
      {
        start = position;
        flag = this.MoveActiveCell(start, rowShift1, colShift1, rowShift2, colShift2);
      }
    }
label_19:
    return flag;
  }

  public virtual void Invalidate()
  {
    foreach (Range range in this.GetSelectionRegion())
      this.Grid.InvalidateRange(range);
  }

  public bool EnableMultiSelection
  {
    get => this.bool_0;
    set => this.bool_0 = value;
  }

  public Color BackColor
  {
    get => this.color_1;
    set
    {
      this.color_1 = value;
      this.Invalidate();
    }
  }

  public RectangleBorder Border
  {
    get => this.rectangleBorder_0;
    set
    {
      this.rectangleBorder_0 = value;
      this.Invalidate();
    }
  }

  public abstract bool IsSelectedColumn(int column);

  public abstract void SelectColumn(int column, bool select);

  public abstract bool IsSelectedRow(int row);

  public abstract void SelectRow(int row, bool select);

  public abstract bool IsSelectedCell(Position position);

  public abstract void SelectCell(Position position, bool select);

  public abstract bool IsSelectedRange(Range range);

  public abstract void SelectRange(Range range, bool select);

  protected abstract void OnResetSelection();

  public void ResetSelection(bool mantainFocus)
  {
    if ((mantainFocus ? 0 : (!this.ActivePosition.IsEmpty() ? 1 : 0)) != 0)
      this.Focus(Position.Empty, false);
    this.OnResetSelection();
    if ((!mantainFocus ? 0 : (!this.ActivePosition.IsEmpty() ? 1 : 0)) == 0)
      return;
    this.SelectCell(this.ActivePosition, true);
  }

  public abstract bool IsEmpty();

  public abstract RangeRegion GetSelectionRegion();

  public abstract bool IntersectsWith(Range rng);

  protected Range ValidateRange(Range rng) => this.Grid.CompleteRange.Intersect(rng);

  public event RangeRegionChangedEventHandler SelectionChanged;

  protected virtual void OnSelectionChanged(RangeRegionChangedEventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.rangeRegionChangedEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.rangeRegionChangedEventHandler_0((object) this, e);
    }
    if (e.AddedRange != null)
    {
      foreach (Range range in e.AddedRange)
        this.Grid.InvalidateRange(range);
    }
    if (e.RemovedRange == null)
      return;
    foreach (Range range in e.RemovedRange)
      this.Grid.InvalidateRange(range);
  }
}
