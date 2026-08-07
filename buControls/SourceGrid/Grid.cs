// Decompiled with JetBrains decompiler
// Type: SourceGrid.Grid
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using DevAge.Drawing;
using ns7;
using SourceGrid.Cells;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace SourceGrid;

[ToolboxItem(true)]
public class Grid : GridVirtual
{
  internal ISpannedCellRangesController ispannedCellRangesController_0 = (ISpannedCellRangesController) null;
  private CellOptimizeMode cellOptimizeMode_0 = CellOptimizeMode.ForRows;
  private bool bool_8 = false;
  [Obsolete]
  private static int int_11 = 100;
  private RangeCollection rangeCollection_0 = new RangeCollection();
  private bool bool_9 = false;

  protected override AccessibleObject CreateAccessibilityInstance()
  {
    return (AccessibleObject) new Grid.GridAccessibleObject(this);
  }

  public override bool EnableSort { get; set; }

  public ISpannedCellRangesController SpannedCellReferences => this.ispannedCellRangesController_0;

  public Grid()
  {
    this.SuspendLayout();
    this.Name = nameof (Grid);
    this.ispannedCellRangesController_0 = (ISpannedCellRangesController) new SpannedCellRangesController(this, (ISpannedRangesCollection) new QuadTreeRangesList(Range.From(new Position(0, 0), 4, 4)));
    this.ResumeLayout(false);
  }

  protected override RowsBase CreateRowsObject() => (RowsBase) new GridRows(this);

  protected override ColumnsBase CreateColumnsObject() => (ColumnsBase) new GridColumns(this);

  [DefaultValue(0)]
  public int ColumnsCount
  {
    get => this.Columns.Count;
    set => this.Columns.SetCount(value);
  }

  [DefaultValue(0)]
  public int RowsCount
  {
    get => this.Rows.Count;
    set => this.Rows.SetCount(value);
  }

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public GridRows Rows => (GridRows) base.Rows;

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public GridColumns Columns => (GridColumns) base.Columns;

  public CellOptimizeMode OptimizeMode
  {
    get => this.cellOptimizeMode_0;
    set => this.cellOptimizeMode_0 = value;
  }

  [DefaultValue(false)]
  public bool AllowOverlappingCells
  {
    get => this.bool_8;
    set => this.bool_8 = value;
  }

  public virtual void SetCell(int p_iRow, int p_iCol, ICellVirtual p_Cell)
  {
    if (p_Cell is ICell)
    {
      Class39.smethod_477((ICell) p_Cell, p_iCol, p_iRow, this);
    }
    else
    {
      if (p_Cell != null)
        throw new SourceGridException("Expected ICell class");
      Class39.smethod_477((ICell) null, p_iCol, p_iRow, this);
    }
  }

  public void SetCell(Position p_Position, ICellVirtual p_Cell)
  {
    this.SetCell(p_Position.Row, p_Position.Column, p_Cell);
  }

  public override ICellVirtual GetCell(int p_iRow, int p_iCol)
  {
    return (ICellVirtual) this[p_iRow, p_iCol];
  }

  public ICell this[Position position]
  {
    get
    {
      ICell cell = Class39.smethod_834(this, position);
      return cell == null ? Class39.smethod_34(this, position) : cell;
    }
    set
    {
      int row = position.Row;
      int column = position.Column;
      Class39.smethod_477(value, column, row, this);
    }
  }

  public ICell this[int row, int col]
  {
    get => this[new Position(row, col)];
    set => this[new Position(row, col)] = value;
  }

  internal void method_1(int int_12, int int_13, ICell icell_0)
  {
    List<Range> ranges = this.ispannedCellRangesController_0.SpannedRangesCollection.GetRanges(new Range(int_12, int_13, int_12 + icell_0.RowSpan - 1, int_13 + icell_0.ColumnSpan - 1));
    if (ranges.Count == 0)
      return;
    Position position = new Position(int_12, int_13);
    foreach (Range range in ranges)
    {
      if (!position.Equals(range.Start))
      {
        ICell cell = this[range.Start];
        if (cell == null)
          throw new ArgumentException("internal error. please report this bug to developers");
        throw new OverlappingCellException($"Given cell at position ({int_12}, {int_13}), intersects with another cell at position ({cell.Row.Index}, {cell.Column.Index}) '{cell.DisplayText}'");
      }
    }
  }

  public void OccupySpannedArea(int row, int col, ICell p_cell)
  {
    if (p_cell == null)
      throw new ArgumentNullException();
    Class39.smethod_128(this, row, col, p_cell);
    this.ispannedCellRangesController_0.UpdateOrAdd(p_cell.Range);
  }

  public void UpdateSpannedArea(int row, int col, ICell p_cell)
  {
    if (p_cell == null)
      throw new ArgumentNullException();
    if ((p_cell.RowSpan != 1 ? 0 : (p_cell.ColumnSpan == 1 ? 1 : 0)) != 0)
      throw new ArgumentException("Cell is not spanned! Can not update it!. You should delete it manually, and ensure that foreach statement will not be broken");
    Class39.smethod_128(this, row, col, p_cell);
    this.ispannedCellRangesController_0.Update(p_cell.Range);
  }

  public void Redim(int p_Rows, int p_Cols)
  {
    this.SuspendLayout();
    this.RowsCount = p_Rows;
    this.ColumnsCount = p_Cols;
    this.ResumeLayout();
    Class39.smethod_359(this);
  }

  [Obsolete("This property is not needed anymore. It has completely no effect")]
  public static int MaxSpan
  {
    get => Grid.int_11;
    set => Grid.int_11 = value;
  }

  public override Range RangeToCellRange(Range range)
  {
    int column1 = range.Start.Column;
    int column2 = range.End.Column;
    int row1 = range.Start.Row;
    int row2 = range.End.Row;
    for (int column3 = range.Start.Column; column3 <= range.End.Column; ++column3)
    {
      for (int row3 = range.Start.Row; row3 <= range.End.Row; ++row3)
      {
        Position position = new Position(row3, column3);
        Range range1 = this.PositionToCellRange(position);
        if (range1.IsEmpty())
          range1 = new Range(position, position);
        if (range1.Start.Column < column1)
          column1 = range1.Start.Column;
        if (range1.End.Column > column2)
          column2 = range1.End.Column;
        if (range1.Start.Row < row1)
          row1 = range1.Start.Row;
        if (range1.End.Row > row2)
          row2 = range1.End.Row;
      }
    }
    return new Range(row1, column1, row2, column2);
  }

  public override Range PositionToCellRange(Position pPosition)
  {
    Range cellRange;
    if (pPosition.IsEmpty())
    {
      cellRange = Range.Empty;
    }
    else
    {
      ICell cell = this[pPosition.Row, pPosition.Column];
      cellRange = cell != null ? cell.Range : Range.Empty;
    }
    return cellRange;
  }

  public virtual void InvalidateCell(ICell p_Cell)
  {
    if (p_Cell == null)
      return;
    this.InvalidateRange(p_Cell.Range);
  }

  public override void InvalidateCell(Position p_Position)
  {
    ICell cell = this[p_Position.Row, p_Position.Column];
    if ((cell == null ? 1 : (cell.Range.ColumnsCount != 1 ? 0 : (cell.Range.RowsCount == 1 ? 1 : 0))) != 0)
      base.InvalidateCell(p_Position);
    else
      this.InvalidateRange(cell.Range);
  }

  protected override void OnRangePaint(RangePaintEventArgs e)
  {
    this.rangeCollection_0.Clear();
    base.OnRangePaint(e);
  }

  protected override void PaintCell(
    GraphicsCache graphics,
    CellContext cellContext,
    RectangleF drawRectangle)
  {
    Range cellRange = this.PositionToCellRange(cellContext.Position);
    if ((cellRange.ColumnsCount != 1 ? 0 : (cellRange.RowsCount == 1 ? 1 : 0)) != 0)
    {
      base.PaintCell(graphics, cellContext, drawRectangle);
    }
    else
    {
      if (this.rangeCollection_0.Contains(cellRange))
        return;
      Rectangle rectangle = this.RangeToRectangle(cellRange);
      base.PaintCell(graphics, cellContext, (RectangleF) rectangle);
      this.rangeCollection_0.Add(cellRange);
    }
  }

  [DefaultValue(false)]
  public bool CustomSort
  {
    get => this.bool_9;
    set => this.bool_9 = value;
  }

  protected override void OnSortingRangeRows(SortRangeRowsEventArgs e)
  {
    base.OnSortingRangeRows(e);
    if (this.CustomSort)
      return;
    int keyColumn1 = e.KeyColumn;
    Range range = e.Range;
    int column1 = range.End.Column;
    int num1;
    if (keyColumn1 > column1)
    {
      int keyColumn2 = e.KeyColumn;
      range = e.Range;
      int column2 = range.Start.Column;
      num1 = keyColumn2 < column2 ? 1 : 0;
    }
    else
      num1 = 0;
    if (num1 != 0)
      throw new ArgumentException("Invalid range", "e.KeyColumn");
    IComparer comparer = e.CellComparer ?? (IComparer) new ValueCellComparer();
    range = e.Range;
    if (range.ColumnsCount == this.ColumnsCount)
    {
      range = e.Range;
      Position position1 = range.End;
      int row1 = position1.Row;
      range = e.Range;
      position1 = range.Start;
      int row2 = position1.Row;
      RowInfo[] items = new RowInfo[row1 - row2 + 1];
      range = e.Range;
      Position position2 = range.End;
      int row3 = position2.Row;
      range = e.Range;
      position2 = range.Start;
      int row4 = position2.Row;
      ICell[] keys = new ICell[row3 - row4 + 1];
      int index1 = 0;
      range = e.Range;
      position2 = range.Start;
      int row5 = position2.Row;
      while (true)
      {
        int num2 = row5;
        range = e.Range;
        position2 = range.End;
        int row6 = position2.Row;
        if (num2 <= row6)
        {
          keys[index1] = this[row5, e.KeyColumn];
          items[index1] = (RowInfo) this.Rows[row5];
          ++index1;
          ++row5;
        }
        else
          break;
      }
      Array.Sort((Array) keys, (Array) items, 0, keys.Length, comparer);
      if (e.Ascending)
      {
        for (int index2 = 0; index2 < items.Length; ++index2)
        {
          GridRows rows = this.Rows;
          int index3 = items[index2].Index;
          range = e.Range;
          position2 = range.Start;
          int p_RowIndex2 = position2.Row + index2;
          rows.Swap(index3, p_RowIndex2);
        }
      }
      else
      {
        for (int index4 = items.Length - 1; index4 >= 0; --index4)
        {
          GridRows rows = this.Rows;
          int index5 = items[index4].Index;
          range = e.Range;
          position2 = range.End;
          int p_RowIndex2 = position2.Row - index4;
          rows.Swap(index5, p_RowIndex2);
        }
      }
    }
    else
    {
      range = e.Range;
      Position position3 = range.End;
      int row7 = position3.Row;
      range = e.Range;
      position3 = range.Start;
      int row8 = position3.Row;
      ICell[][] items = new ICell[row7 - row8 + 1][];
      range = e.Range;
      Position position4 = range.End;
      int row9 = position4.Row;
      range = e.Range;
      position4 = range.Start;
      int row10 = position4.Row;
      ICell[] keys = new ICell[row9 - row10 + 1];
      int index6 = 0;
      range = e.Range;
      position4 = range.Start;
      int row11 = position4.Row;
      while (true)
      {
        int num3 = row11;
        range = e.Range;
        position4 = range.End;
        int row12 = position4.Row;
        if (num3 <= row12)
        {
          keys[index6] = this[row11, e.KeyColumn];
          int index7 = 0;
          ICell[][] cellArray1 = items;
          int index8 = index6;
          range = e.Range;
          position4 = range.End;
          int column3 = position4.Column;
          range = e.Range;
          position4 = range.Start;
          int column4 = position4.Column;
          ICell[] cellArray2 = new ICell[column3 - column4 + 1];
          cellArray1[index8] = cellArray2;
          range = e.Range;
          position4 = range.Start;
          int column5 = position4.Column;
          while (true)
          {
            int num4 = column5;
            range = e.Range;
            position4 = range.End;
            int column6 = position4.Column;
            if (num4 <= column6)
            {
              items[index6][index7] = this[row11, column5];
              ++index7;
              ++column5;
            }
            else
              break;
          }
          ++index6;
          ++row11;
        }
        else
          break;
      }
      Array.Sort((Array) keys, (Array) items, 0, keys.Length, comparer);
      int index9 = 0;
      if (e.Ascending)
      {
        range = e.Range;
        position4 = range.Start;
        int row13 = position4.Row;
        while (true)
        {
          int num5 = row13;
          range = e.Range;
          position4 = range.End;
          int row14 = position4.Row;
          if (num5 <= row14)
          {
            int index10 = 0;
            range = e.Range;
            position4 = range.Start;
            int column7 = position4.Column;
            while (true)
            {
              int num6 = column7;
              range = e.Range;
              position4 = range.End;
              int column8 = position4.Column;
              if (num6 <= column8)
              {
                Class39.smethod_256(row13, this, column7);
                ICell cell = items[index9][index10];
                int num7;
                if (cell != null && cell.Grid != null)
                {
                  range = cell.Range;
                  position4 = range.Start;
                  if (position4.Row >= 0)
                  {
                    range = cell.Range;
                    position4 = range.Start;
                    num7 = position4.Column >= 0 ? 1 : 0;
                    goto label_32;
                  }
                }
                num7 = 0;
label_32:
                if (num7 != 0)
                {
                  range = cell.Range;
                  position4 = range.Start;
                  Grid grid_0 = this;
                  int row15 = position4.Row;
                  range = cell.Range;
                  position4 = range.Start;
                  int int_0 = row15;
                  int column9 = position4.Column;
                  Class39.smethod_256(int_0, grid_0, column9);
                }
                this[row13, column7] = cell;
                ++index10;
                ++column7;
              }
              else
                break;
            }
            ++index9;
            ++row13;
          }
          else
            break;
        }
      }
      else
      {
        range = e.Range;
        position4 = range.End;
        int row16 = position4.Row;
        while (true)
        {
          int num8 = row16;
          range = e.Range;
          position4 = range.Start;
          int row17 = position4.Row;
          if (num8 >= row17)
          {
            int index11 = 0;
            range = e.Range;
            position4 = range.Start;
            int column10 = position4.Column;
            while (true)
            {
              int num9 = column10;
              range = e.Range;
              position4 = range.End;
              int column11 = position4.Column;
              if (num9 <= column11)
              {
                Class39.smethod_256(row16, this, column10);
                ICell cell = items[index9][index11];
                int num10;
                if (cell != null && cell.Grid != null)
                {
                  range = cell.Range;
                  position4 = range.Start;
                  if (position4.Row >= 0)
                  {
                    range = cell.Range;
                    position4 = range.Start;
                    num10 = position4.Column >= 0 ? 1 : 0;
                    goto label_45;
                  }
                }
                num10 = 0;
label_45:
                if (num10 != 0)
                {
                  range = cell.Range;
                  position4 = range.Start;
                  Grid grid_0 = this;
                  int row18 = position4.Row;
                  range = cell.Range;
                  position4 = range.Start;
                  int int_0 = row18;
                  int column12 = position4.Column;
                  Class39.smethod_256(int_0, grid_0, column12);
                }
                this[row16, column10] = cell;
                ++index11;
                ++column10;
              }
              else
                break;
            }
            ++index9;
            --row16;
          }
          else
            break;
        }
      }
    }
  }

  public class GridAccessibleObject : Control.ControlAccessibleObject
  {
    private Grid owner;

    public GridAccessibleObject(Grid owner)
      : base((Control) owner)
    {
      this.owner = owner;
    }

    public override AccessibleRole Role => AccessibleRole.Table;

    public override string Name => this.owner.Name;

    public override AccessibleObject GetChild(int index)
    {
      return (AccessibleObject) new Grid.GridRowAccessibleObject(this.owner.Rows[index], this);
    }

    public override int GetChildCount() => this.owner.RowsCount;
  }

  public class GridRowAccessibleObject : AccessibleObject
  {
    private GridRow gridRow;
    private Grid.GridAccessibleObject parent;

    public GridRowAccessibleObject(GridRow gridRow, Grid.GridAccessibleObject parent)
    {
      this.gridRow = gridRow;
      this.parent = parent;
    }

    public override Rectangle Bounds
    {
      get
      {
        Rectangle bounds;
        if (!this.gridRow.Visible)
        {
          bounds = Rectangle.Empty;
        }
        else
        {
          int num1 = 0;
          if (this.gridRow.Grid.VerticalScroll.Enabled)
            num1 = this.gridRow.Grid.VScrollBar.Value;
          if (this.gridRow.Index < num1)
          {
            bounds = Rectangle.Empty;
          }
          else
          {
            int height = this.gridRow.Height;
            int num2 = 0;
            if (this.gridRow.Grid.HorizontalScroll.Enabled)
              num2 = this.gridRow.Grid.HScrollBar.Value;
            int width = 0;
            for (int p = num2; p < this.gridRow.Grid.Columns.Count; ++p)
            {
              GridColumns columns = (GridColumns) this.gridRow.Grid.Columns;
              width += columns[p].Width;
            }
            int x = this.parent.Bounds.X;
            int top = this.parent.Bounds.Top;
            for (int index = num1; index < this.gridRow.Index; ++index)
            {
              GridRows rows = (GridRows) this.gridRow.Grid.Rows;
              top += rows[index].Height;
            }
            Rectangle rect = new Rectangle(x, top, width, height);
            bounds = !this.parent.Bounds.IntersectsWith(rect) ? Rectangle.Empty : rect;
          }
        }
        return bounds;
      }
    }

    public override string Name => "Row " + this.gridRow.Index.ToString();

    public override AccessibleRole Role => AccessibleRole.Row;

    public override AccessibleObject Parent => (AccessibleObject) this.parent;

    public override AccessibleObject GetChild(int index)
    {
      ICellVirtual[] cellsAtRow = this.gridRow.Grid.GetCellsAtRow(this.gridRow.Index);
      AccessibleObject child;
      if (index < cellsAtRow.Length)
      {
        Cell cell = (Cell) cellsAtRow[index];
        child = cell != null ? (AccessibleObject) new Grid.GridRowCellAccessibleObject(cell, this) : (AccessibleObject) null;
      }
      else
        child = (AccessibleObject) new Grid.GridRowCellAccessibleObject((Cell) cellsAtRow[cellsAtRow.Length - 1], this);
      return child;
    }

    public override int GetChildCount()
    {
      return this.gridRow.Grid.GetCellsAtRow(this.gridRow.Index).Length;
    }
  }

  public class GridRowCellAccessibleObject : AccessibleObject
  {
    private Cell cell;
    private Grid.GridRowAccessibleObject parent;

    public GridRowCellAccessibleObject(Cell cell, Grid.GridRowAccessibleObject parent)
    {
      this.cell = cell;
      this.parent = parent;
    }

    public override Rectangle Bounds
    {
      get
      {
        Rectangle bounds;
        if (this.parent.Bounds == Rectangle.Empty)
        {
          bounds = Rectangle.Empty;
        }
        else
        {
          int num = 0;
          if (this.cell.Grid.HorizontalScroll.Enabled)
            num = this.cell.Grid.HScrollBar.Value;
          if (this.cell.Column.Index < num)
          {
            bounds = Rectangle.Empty;
          }
          else
          {
            int width = this.cell.Column.Width;
            int height = this.cell.Row.Height;
            int x = this.parent.Bounds.X;
            for (int p = num; p < this.cell.Column.Index; ++p)
            {
              GridColumns columns = this.cell.Grid.Columns;
              x += columns[p].Width;
            }
            int y = this.parent.Bounds.Y;
            Rectangle rect = new Rectangle(x, y, width, height);
            bounds = !this.parent.Bounds.IntersectsWith(rect) ? Rectangle.Empty : rect;
          }
        }
        return bounds;
      }
    }

    public override AccessibleRole Role => AccessibleRole.Cell;

    public override string Name
    {
      get
      {
        return this.cell.DisplayText == null ? "Column " + this.cell.Column.Index.ToString() : this.cell.DisplayText;
      }
    }

    public override string Value
    {
      get => this.cell.DisplayText;
      set => this.cell.Value = (object) value;
    }

    public override AccessibleObject Parent => (AccessibleObject) this.parent;
  }
}
