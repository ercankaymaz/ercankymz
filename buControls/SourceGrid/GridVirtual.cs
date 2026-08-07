// Decompiled with JetBrains decompiler
// Type: SourceGrid.GridVirtual
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using DevAge.Drawing;
using DevAge.Windows.Forms;
using ns7;
using SourceGrid.Cells;
using SourceGrid.Cells.Controllers;
using SourceGrid.Decorators;
using SourceGrid.Selection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

#nullable disable
namespace SourceGrid;

[ToolboxItem(false)]
public abstract class GridVirtual : CustomScrollControl
{
  private int int_5 = 20;
  private int int_6 = 50;
  private int int_7 = 0;
  private int int_8 = 0;
  private bool bool_0 = false;
  private bool bool_1 = false;
  private Position position_0 = Position.Empty;
  private IGridSelection igridSelection_0;
  private GridSelectionMode gridSelectionMode_0;
  protected Position m_MouseDownPosition = Position.Empty;
  protected Position m_MouseCellPosition = Position.Empty;
  private Range range_0 = Range.Empty;
  private Range range_1 = Range.Empty;
  private Position position_1;
  private bool bool_2 = true;
  private GridSpecialKeys gridSpecialKeys_0 = GridSpecialKeys.Default;
  private bool bool_3 = true;
  private Position position_2;
  private bool bool_4 = true;
  private LinkedControlsList linkedControlsList_0;
  private int int_9 = 0;
  private int int_10 = 0;
  private RowsBase rowsBase_0;
  private ColumnsBase columnsBase_0;
  private bool bool_5 = false;
  private ToolTip toolTip_0;
  private DecoratorList decoratorList_0 = new DecoratorList();
  private ControllerContainer controllerContainer_0 = new ControllerContainer();
  private ClipboardMode clipboardMode_0 = ClipboardMode.None;
  private bool bool_6 = false;

  public GridVirtual()
  {
    this.SetStyle(ControlStyles.Selectable, true);
    this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
    this.SetStyle(ControlStyles.DoubleBuffer, true);
    this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
    this.SetStyle(ControlStyles.ContainerControl, true);
    this.TabStop = true;
    this.EnableSort = true;
    this.rowsBase_0 = this.CreateRowsObject();
    this.columnsBase_0 = this.CreateColumnsObject();
    this.SelectionMode = GridSelectionMode.Cell;
    this.Controller.AddController((IController) StandardBehavior.Default);
    this.Controller.AddController((IController) MouseSelection.Default);
    this.Controller.AddController((IController) CellEventDispatcher.Default);
    this.linkedControlsList_0 = new LinkedControlsList((Control) this);
    this.toolTip_0 = new ToolTip();
    this.ToolTipText = "";
  }

  protected abstract RowsBase CreateRowsObject();

  protected abstract ColumnsBase CreateColumnsObject();

  protected override void Dispose(bool disposing)
  {
    if (disposing)
      ;
    base.Dispose(disposing);
  }

  [DefaultValue(20)]
  public int DefaultHeight
  {
    get => this.int_5;
    set => this.int_5 = value;
  }

  [DefaultValue(50)]
  public int DefaultWidth
  {
    get => this.int_6;
    set => this.int_6 = value;
  }

  [DefaultValue(0)]
  public int MinimumHeight
  {
    get => this.int_7;
    set => this.int_7 = value;
  }

  [DefaultValue(0)]
  public int MinimumWidth
  {
    get => this.int_8;
    set => this.int_8 = value;
  }

  public virtual void AutoSizeCells(Range p_RangeToAutoSize)
  {
    this.SuspendLayout();
    if (!p_RangeToAutoSize.IsEmpty())
    {
      this.Rows.SuspendLayout();
      this.Columns.SuspendLayout();
      try
      {
        int column1 = p_RangeToAutoSize.End.Column;
        Position position;
        while (true)
        {
          int num = column1;
          position = p_RangeToAutoSize.Start;
          int column2 = position.Column;
          if (num >= column2)
          {
            ColumnsBase columns = this.Columns;
            int column3 = column1;
            position = p_RangeToAutoSize.Start;
            int row1 = position.Row;
            position = p_RangeToAutoSize.End;
            int row2 = position.Row;
            columns.AutoSizeColumn(column3, false, row1, row2);
            --column1;
          }
          else
            break;
        }
        position = p_RangeToAutoSize.End;
        int row3 = position.Row;
        while (true)
        {
          int num = row3;
          position = p_RangeToAutoSize.Start;
          int row4 = position.Row;
          if (num >= row4)
          {
            RowsBase rows = this.Rows;
            int row5 = row3;
            position = p_RangeToAutoSize.Start;
            int column4 = position.Column;
            position = p_RangeToAutoSize.End;
            int column5 = position.Column;
            rows.AutoSizeRow(row5, false, column4, column5);
            --row3;
          }
          else
            break;
        }
      }
      finally
      {
        this.Rows.ResumeLayout();
        this.Columns.ResumeLayout();
      }
      if (this.AutoStretchColumnsToFitWidth)
        this.Columns.StretchToFit();
      if (this.AutoStretchRowsToFitHeight)
        this.Rows.StretchToFit();
    }
    this.ResumeLayout(false);
  }

  public virtual void AutoSizeCells() => this.AutoSizeCells(this.CompleteRange);

  [DefaultValue(false)]
  public bool AutoStretchColumnsToFitWidth
  {
    get => this.bool_0;
    set => this.bool_0 = value;
  }

  [DefaultValue(false)]
  public bool AutoStretchRowsToFitHeight
  {
    get => this.bool_1;
    set => this.bool_1 = value;
  }

  public virtual void CheckPositions()
  {
    Range completeRange = this.CompleteRange;
    if ((this.m_MouseCellPosition.IsEmpty() ? 0 : (!this.CompleteRange.Contains(this.m_MouseCellPosition) ? 1 : 0)) != 0)
      this.m_MouseCellPosition = Position.Empty;
    if ((this.m_MouseDownPosition.IsEmpty() ? 0 : (!this.CompleteRange.Contains(this.m_MouseDownPosition) ? 1 : 0)) != 0)
      this.m_MouseDownPosition = Position.Empty;
    if ((this.position_0.IsEmpty() ? 0 : (!this.CompleteRange.Contains(this.position_0) ? 1 : 0)) != 0)
      this.position_0 = Position.Empty;
    RangeRegion rangeRegion = new RangeRegion(completeRange);
    if ((this.Selection.ActivePosition.IsEmpty() || completeRange.Contains(this.Selection.ActivePosition) ? (this.Selection.IsEmpty() ? 0 : (!rangeRegion.Contains(this.Selection.GetSelectionRegion()) ? 1 : 0)) : 1) == 0)
      return;
    this.Selection.ResetSelection(false);
  }

  public Rectangle PositionToRectangle(Position position)
  {
    return this.RangeToRectangle(this.PositionToCellRange(position));
  }

  public virtual Position PositionAtPoint(Point point)
  {
    int? nullable1 = this.Rows.RowAtPoint(point.Y);
    Position position;
    if (!nullable1.HasValue)
    {
      position = Position.Empty;
    }
    else
    {
      int? nullable2 = this.Columns.ColumnAtPoint(point.X);
      position = nullable2.HasValue ? this.PositionToStartPosition(new Position(nullable1.Value, nullable2.Value)) : Position.Empty;
    }
    return position;
  }

  public Size RangeToSize(Range range)
  {
    Size size;
    if (range.IsEmpty())
    {
      size = Size.Empty;
    }
    else
    {
      int width = 0;
      Position position = range.Start;
      int column1 = position.Column;
      while (true)
      {
        int num = column1;
        position = range.End;
        int column2 = position.Column;
        if (num <= column2)
        {
          width += this.Columns.GetWidth(column1);
          ++column1;
        }
        else
          break;
      }
      int height = 0;
      position = range.Start;
      int row1 = position.Row;
      while (true)
      {
        int num = row1;
        position = range.End;
        int row2 = position.Row;
        if (num <= row2)
        {
          height += this.Rows.GetHeight(row1);
          ++row1;
        }
        else
          break;
      }
      size = new Size(width, height);
    }
    return size;
  }

  public Rectangle RangeToRectangle(Range range)
  {
    Rectangle rectangle;
    if (range.IsEmpty())
    {
      rectangle = Rectangle.Empty;
    }
    else
    {
      if (range.Start.Column < 0)
        throw new ArgumentOutOfRangeException($"range.Start.Column was less than zero: {range.Start.Column}");
      ColumnsBase columns = this.Columns;
      Position start = range.Start;
      int column = start.Column;
      int left = columns.GetLeft(column);
      start = range.Start;
      if (start.Row < 0)
      {
        start = range.Start;
        throw new ArgumentOutOfRangeException($"range.Start.Row was less than zero: {start.Row}");
      }
      RowsBase rows = this.Rows;
      start = range.Start;
      int row = start.Row;
      int top = rows.GetTop(row);
      Size size = this.RangeToSize(range);
      rectangle = !size.IsEmpty ? new Rectangle(new Point(left, top), size) : Rectangle.Empty;
    }
    return rectangle;
  }

  public Range RangeAtArea(CellPositionType areaType)
  {
    switch (areaType)
    {
      case CellPositionType.FixedTopLeft:
        return (this.FixedRows <= 0 || this.Rows.Count < this.FixedRows || this.FixedColumns <= 0 ? 0 : (this.Columns.Count >= this.FixedColumns ? 1 : 0)) != 0 ? new Range(0, 0, this.FixedRows - 1, this.FixedColumns - 1) : Range.Empty;
      case CellPositionType.FixedTop:
        int num1 = this.FixedRows;
        if (num1 > this.Rows.Count)
          num1 = this.Rows.Count;
        if (num1 <= 0)
          return Range.Empty;
        int? scrollableColumn1 = this.Columns.FirstVisibleScrollableColumn;
        int? scrollableColumn2 = this.Columns.LastVisibleScrollableColumn;
        return (!scrollableColumn1.HasValue ? 1 : (!scrollableColumn2.HasValue ? 1 : 0)) != 0 ? Range.Empty : new Range(0, scrollableColumn1.Value, num1 - 1, scrollableColumn2.Value);
      case CellPositionType.FixedLeft:
        int num2 = this.FixedColumns;
        if (num2 > this.Columns.Count)
          num2 = this.Columns.Count;
        if (num2 <= 0)
          return Range.Empty;
        int? visibleScrollableRow1 = this.Rows.FirstVisibleScrollableRow;
        int? visibleScrollableRow2 = this.Rows.LastVisibleScrollableRow;
        return (!visibleScrollableRow1.HasValue ? 1 : (!visibleScrollableRow2.HasValue ? 1 : 0)) != 0 ? Range.Empty : new Range(visibleScrollableRow1.Value, 0, visibleScrollableRow2.Value, num2 - 1);
      case CellPositionType.Scrollable:
        int? visibleScrollableRow3 = this.Rows.FirstVisibleScrollableRow;
        int? visibleScrollableRow4 = this.Rows.LastVisibleScrollableRow;
        int? scrollableColumn3 = this.Columns.FirstVisibleScrollableColumn;
        int? scrollableColumn4 = this.Columns.LastVisibleScrollableColumn;
        return (!visibleScrollableRow3.HasValue || !scrollableColumn3.HasValue || !visibleScrollableRow4.HasValue ? 1 : (!scrollableColumn4.HasValue ? 1 : 0)) != 0 ? Range.Empty : new Range(visibleScrollableRow3.Value, scrollableColumn3.Value, visibleScrollableRow4.Value, scrollableColumn4.Value);
      default:
        throw new SourceGridException("Invalid areaType");
    }
  }

  private IEnumerable<Range> method_0()
  {
    Range range = this.RangeAtArea(CellPositionType.FixedTopLeft);
    if (!range.IsEmpty())
      yield return range;
    range = this.RangeAtArea(CellPositionType.FixedTop);
    if (!range.IsEmpty())
      yield return range;
    range = this.RangeAtArea(CellPositionType.FixedLeft);
    if (!range.IsEmpty())
      yield return range;
    range = this.RangeAtArea(CellPositionType.Scrollable);
    if (!range.IsEmpty())
      yield return range;
  }

  public List<int> GetVisibleRows(bool returnsPartial)
  {
    return this.GetVisibleRows(this.DisplayRectangle, returnsPartial);
  }

  public List<int> GetVisibleRows(Rectangle displayRectangle, bool returnsPartial)
  {
    List<int> intList = this.Rows.RowsInsideRegion(displayRectangle.Y, displayRectangle.Height, returnsPartial, true);
    List<int> visibleRows = new List<int>(intList.Count);
    foreach (int row in intList)
    {
      if (this.Rows.IsRowVisible(row))
        visibleRows.Add(row);
    }
    return visibleRows;
  }

  public List<int> GetVisibleColumns(bool returnsPartial)
  {
    return this.GetVisibleColumns(this.DisplayRectangle, returnsPartial);
  }

  public List<int> GetVisibleColumns(Rectangle displayRectangle, bool returnsPartial)
  {
    return this.Columns.ColumnsInsideRegion(displayRectangle.X, displayRectangle.Width, returnsPartial, true);
  }

  protected override int GetScrollRows(int displayHeight)
  {
    int scrollRows;
    if (displayHeight < 0)
    {
      scrollRows = 0;
    }
    else
    {
      int num1 = 0;
      int num2 = 0;
      for (int row = 0; row < this.ActualFixedRows; ++row)
        displayHeight -= this.Rows.GetHeight(row);
      for (int index = this.Rows.Count - 1; index >= this.ActualFixedRows; --index)
      {
        if (this.Rows.IsRowVisible(index))
        {
          num1 += this.Rows.GetHeight(index);
          if (num1 <= displayHeight)
          {
            ++num2;
          }
          else
          {
            scrollRows = this.Rows.Count - num2 - Class39.smethod_228(this, index);
            goto label_13;
          }
        }
      }
      scrollRows = 0;
    }
label_13:
    return scrollRows;
  }

  protected override int GetActualFixedRows() => this.ActualFixedRows;

  protected override int GetScrollColumns(int displayWidth)
  {
    int scrollColumns;
    if (displayWidth < 0)
    {
      scrollColumns = 0;
    }
    else
    {
      int num1 = 0;
      int num2 = 0;
      for (int column = 0; column < this.ActualFixedColumns; ++column)
        displayWidth -= this.Columns.GetWidth(column);
      for (int column = this.Columns.Count - 1; column >= this.ActualFixedColumns; --column)
      {
        num1 += this.Columns.GetWidth(column);
        if (num1 <= displayWidth)
        {
          ++num2;
        }
        else
        {
          scrollColumns = this.Columns.Count - num2;
          goto label_11;
        }
      }
      scrollColumns = 0;
    }
label_11:
    return scrollColumns;
  }

  public bool IsCellVisible(Position position, bool partial)
  {
    return !this.GetScrollPositionToShowCell(position, partial, out Point _);
  }

  protected virtual bool GetScrollPositionToShowCell(
    Position position,
    bool partial,
    out Point newScrollPosition)
  {
    Rectangle displayRectangle = this.DisplayRectangle;
    List<int> visibleRows = this.GetVisibleRows(partial);
    List<int> visibleColumns = this.GetVisibleColumns(partial);
    bool positionToShowCell;
    if ((!visibleRows.Contains(position.Row) ? 0 : (visibleColumns.Contains(position.Column) ? 1 : 0)) != 0)
    {
      newScrollPosition = this.CustomScrollPosition;
      positionToShowCell = false;
    }
    else
    {
      CellPositionType positionType = this.GetPositionType(position);
      bool flag1 = false;
      if ((positionType == CellPositionType.FixedTop ? 1 : (positionType == CellPositionType.FixedTopLeft ? 1 : 0)) != 0)
        flag1 = true;
      bool flag2 = false;
      if ((positionType == CellPositionType.FixedLeft ? 1 : (positionType == CellPositionType.FixedTopLeft ? 1 : 0)) != 0)
        flag2 = true;
      int x;
      if (visibleColumns.Contains(position.Column))
      {
        x = this.CustomScrollPosition.X;
      }
      else
      {
        x = !flag2 ? position.Column - this.FixedColumns : 0;
        int scrollColumns = this.GetScrollColumns(displayRectangle.Width);
        if (x > scrollColumns)
          x = scrollColumns;
      }
      int y;
      if (visibleRows.Contains(position.Row))
        y = Class39.smethod_214(this, this.CustomScrollPosition.Y);
      else if (this.CustomScrollPosition.Y + this.ActualFixedRows > position.Row)
      {
        int int_0 = !flag1 ? position.Row - this.FixedRows : 0;
        int scrollRows = this.GetScrollRows(displayRectangle.Height);
        if (int_0 > scrollRows)
          int_0 = scrollRows;
        y = Class39.smethod_214(this, int_0);
      }
      else
        y = Class39.smethod_214(this, Class39.smethod_798(this, position.Row) - this.ActualFixedRows);
      newScrollPosition = new Point(x, y);
      positionToShowCell = true;
    }
    return positionToShowCell;
  }

  public bool ShowCell(Position p_Position, bool ignorePartial)
  {
    Point newScrollPosition;
    bool flag;
    if (this.GetScrollPositionToShowCell(p_Position, ignorePartial, out newScrollPosition))
    {
      this.CustomScrollPosition = newScrollPosition;
      if ((this.FixedRows > 0 ? 1 : (this.FixedColumns > 0 ? 1 : 0)) != 0)
        this.Invalidate();
      flag = false;
    }
    else
      flag = true;
    return flag;
  }

  public virtual void InvalidateCell(Position position)
  {
    this.InvalidateRange(new Range(position));
  }

  public void InvalidateRange(Range range)
  {
    if (range.IsEmpty())
      return;
    CellPositionType[] cellPositionTypeArray = new CellPositionType[4]
    {
      CellPositionType.FixedLeft,
      CellPositionType.FixedTop,
      CellPositionType.FixedTopLeft,
      CellPositionType.Scrollable
    };
    foreach (CellPositionType areaType in cellPositionTypeArray)
    {
      Range p_Range2 = this.RangeAtArea(areaType);
      Range range1 = Range.Intersect(range, p_Range2);
      if (!range1.IsEmpty())
      {
        Rectangle rectangle = this.RangeToRectangle(range1);
        if (!rectangle.IsEmpty)
          this.Invalidate(rectangle, true);
      }
    }
  }

  public Range RangeAtAreaExpanded(CellPositionType areaType)
  {
    Range range = this.RangeAtArea(areaType);
    if (!range.IsEmpty())
    {
      Position start = range.Start;
      int num1;
      if (start.Row <= 0)
      {
        num1 = 0;
      }
      else
      {
        start = range.Start;
        num1 = start.Row - 1;
      }
      int row = num1;
      start = range.Start;
      int num2;
      if (start.Column <= 0)
      {
        num2 = 0;
      }
      else
      {
        start = range.Start;
        num2 = start.Column - 1;
      }
      int col = num2;
      range = new Range(new Position(row, col), range.End);
    }
    return range;
  }

  public void ScrollOnPoint(Point mousePoint)
  {
    Rectangle scrollableArea = this.GetScrollableArea();
    int? nullable = this.Columns.LastVisibleScrollableColumn;
    if ((mousePoint.X <= scrollableArea.Right ? 0 : (!nullable.HasValue || nullable.Value < this.Columns.Count - 1 ? 1 : (this.Columns.GetRight(nullable.Value) > scrollableArea.Right ? 1 : 0))) != 0)
      this.CustomScrollLineRight();
    nullable = this.Rows.LastVisibleScrollableRow;
    if ((mousePoint.Y <= scrollableArea.Bottom ? 0 : (!nullable.HasValue || nullable.Value < this.Rows.Count - 1 ? 1 : (this.Rows.GetBottom(nullable.Value) > scrollableArea.Bottom ? 1 : 0))) != 0)
      this.CustomScrollLineDown();
    if (mousePoint.X < scrollableArea.Left)
      this.CustomScrollLineLeft();
    if (mousePoint.Y >= scrollableArea.Top)
      return;
    this.CustomScrollLineUp();
  }

  protected override void InvalidateScrollableArea() => this.Invalidate(true);

  public Rectangle GetScrollableArea()
  {
    Rectangle displayRectangle = this.DisplayRectangle;
    int actualFixedRows = this.ActualFixedRows;
    int actualFixedColumns = this.ActualFixedColumns;
    displayRectangle.Y = actualFixedRows <= 0 ? 0 : this.Rows.GetAbsoluteBottom(actualFixedRows - 1);
    displayRectangle.Height -= displayRectangle.Y;
    displayRectangle.X = actualFixedColumns <= 0 ? 0 : this.Columns.GetAbsoluteRight(actualFixedColumns - 1);
    displayRectangle.Width -= displayRectangle.X;
    return displayRectangle;
  }

  public Rectangle GetFixedTopLeftArea()
  {
    Rectangle scrollableArea = this.GetScrollableArea();
    return new Rectangle(0, 0, scrollableArea.Left, scrollableArea.Top);
  }

  public Rectangle GetFixedTopArea()
  {
    Rectangle scrollableArea = this.GetScrollableArea();
    return new Rectangle(scrollableArea.Left, 0, scrollableArea.Width, scrollableArea.Top);
  }

  public Rectangle GetFixedLeftArea()
  {
    Rectangle scrollableArea = this.GetScrollableArea();
    return new Rectangle(0, scrollableArea.Top, scrollableArea.Left, scrollableArea.Height);
  }

  public virtual Range RangeToCellRange(Range range) => new Range(range.Start, range.End);

  public Position PositionToStartPosition(Position p_Position)
  {
    return this.PositionToCellRange(p_Position).Start;
  }

  public virtual Range PositionToCellRange(Position pPosition)
  {
    return !pPosition.IsEmpty() ? (this.GetCell(pPosition.Row, pPosition.Column) != null ? new Range(pPosition) : Range.Empty) : Range.Empty;
  }

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public Position DragCellPosition => this.position_0;

  public virtual void ChangeDragCell(CellContext cell, DragEventArgs pDragEventArgs)
  {
    if (!(cell.Position != this.position_0))
      return;
    if (!this.position_0.IsEmpty())
      this.Controller.OnDragLeave(new CellContext(this, this.position_0, this.GetCell(this.position_0)), (EventArgs) pDragEventArgs);
    if (!cell.Position.IsEmpty())
      this.Controller.OnDragEnter(cell, pDragEventArgs);
    this.position_0 = cell.Position;
  }

  protected virtual SelectionBase CreateSelectionObject()
  {
    SelectionBase selectionObject;
    switch (this.SelectionMode)
    {
      case GridSelectionMode.Cell:
        selectionObject = (SelectionBase) new FreeSelection();
        break;
      case GridSelectionMode.Row:
        selectionObject = (SelectionBase) new RowSelection();
        break;
      case GridSelectionMode.Column:
        selectionObject = (SelectionBase) new ColumnSelection();
        break;
      default:
        throw new ArgumentException("SelectionMode not valid", "SelectionMode");
    }
    return selectionObject;
  }

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public IGridSelection Selection
  {
    get => this.igridSelection_0;
    protected set
    {
      if (this.igridSelection_0 != null)
        this.igridSelection_0.UnBindToGrid();
      this.igridSelection_0 = value;
      if (this.igridSelection_0 == null)
        return;
      this.igridSelection_0.BindToGrid(this);
    }
  }

  public GridSelectionMode SelectionMode
  {
    get => this.gridSelectionMode_0;
    set
    {
      this.gridSelectionMode_0 = value;
      this.Selection = (IGridSelection) this.CreateSelectionObject();
      this.Invalidate(true);
    }
  }

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public Position MouseDownPosition => this.m_MouseDownPosition;

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public Position MouseCellPosition => this.m_MouseCellPosition;

  public virtual void ChangeMouseCell(Position p_Cell)
  {
    if (!(this.m_MouseCellPosition != p_Cell))
      return;
    if ((this.m_MouseCellPosition.IsEmpty() ? 0 : (this.m_MouseCellPosition != this.m_MouseDownPosition ? 1 : 0)) != 0)
      this.Controller.OnMouseLeave(new CellContext(this, this.m_MouseCellPosition), EventArgs.Empty);
    this.m_MouseCellPosition = p_Cell;
    if (this.m_MouseCellPosition.IsEmpty())
      return;
    this.Controller.OnMouseEnter(new CellContext(this, this.m_MouseCellPosition), EventArgs.Empty);
  }

  public virtual void ChangeMouseDownCell(Position p_MouseDownCell, Position p_MouseCell)
  {
    this.m_MouseDownPosition = p_MouseDownCell;
    this.ChangeMouseCell(p_MouseCell);
  }

  protected virtual void OnMouseSelectionFinish(RangeEventArgs e) => this.range_0 = Range.Empty;

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public virtual Range MouseSelectionRange => this.range_1;

  protected virtual void OnUndoMouseSelection(RangeEventArgs e)
  {
    this.Selection.SelectRange(e.Range, false);
  }

  protected virtual void OnApplyMouseSelection(RangeEventArgs e)
  {
    this.Selection.SelectRange(e.Range, true);
  }

  protected virtual void OnMouseSelectionChange(EventArgs e)
  {
    Range mouseSelectionRange = this.MouseSelectionRange;
    this.OnUndoMouseSelection(new RangeEventArgs(this.range_0));
    this.OnApplyMouseSelection(new RangeEventArgs(mouseSelectionRange));
    this.range_0 = mouseSelectionRange;
  }

  public void MouseSelectionFinish()
  {
    if (this.range_1 != Range.Empty)
      this.OnMouseSelectionFinish(new RangeEventArgs(this.range_0));
    this.range_1 = Range.Empty;
  }

  public virtual void ChangeMouseSelectionCorner(Position p_Corner)
  {
    Range range = new Range(this.Selection.ActivePosition, p_Corner);
    bool flag = false;
    if (this.range_1 != range)
    {
      this.range_1 = range;
      flag = true;
    }
    if (!flag)
      return;
    this.OnMouseSelectionChange(EventArgs.Empty);
  }

  protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
  {
    if (keyData == (Keys.ShiftKey | Keys.Shift))
      this.position_1 = this.Selection.ActivePosition;
    bool flag;
    if ((keyData == Keys.Return || keyData == Keys.Escape || keyData == Keys.Tab || keyData == (Keys.Tab | Keys.Shift) ? (this.OverrideCommonCmdKey ? 1 : 0) : 0) != 0)
    {
      KeyEventArgs e = new KeyEventArgs(keyData);
      this.OnKeyDown(e);
      flag = e.Handled || base.ProcessCmdKey(ref msg, keyData);
    }
    else
      flag = base.ProcessCmdKey(ref msg, keyData);
    return flag;
  }

  [DefaultValue(true)]
  public bool OverrideCommonCmdKey
  {
    get => this.bool_2;
    set => this.bool_2 = value;
  }

  [DefaultValue(GridSpecialKeys.Default)]
  public GridSpecialKeys SpecialKeys
  {
    get => this.gridSpecialKeys_0;
    set => this.gridSpecialKeys_0 = value;
  }

  [DefaultValue(true)]
  public bool AcceptsInputChar
  {
    get => this.bool_3;
    set => this.bool_3 = value;
  }

  public virtual void ProcessSpecialGridKey(KeyEventArgs e)
  {
    if (e.Handled)
      return;
    bool flag1 = false;
    bool flag2 = false;
    bool flag3 = false;
    if ((this.SpecialKeys & GridSpecialKeys.Arrows) == GridSpecialKeys.Arrows)
      flag3 = true;
    if ((this.SpecialKeys & GridSpecialKeys.PageDownUp) == GridSpecialKeys.PageDownUp)
      flag1 = true;
    if ((this.SpecialKeys & GridSpecialKeys.Tab) == GridSpecialKeys.Tab)
      flag2 = true;
    bool flag4 = false;
    if ((this.SpecialKeys & GridSpecialKeys.Escape) == GridSpecialKeys.Escape)
      flag4 = true;
    bool flag5 = false;
    if ((this.SpecialKeys & GridSpecialKeys.Enter) == GridSpecialKeys.Enter)
      flag5 = true;
    if (e.KeyCode == Keys.Escape & flag4)
    {
      CellContext cellContext = new CellContext(this, this.Selection.ActivePosition);
      if ((cellContext.Cell == null ? 0 : (cellContext.IsEditing() ? 1 : 0)) != 0 && cellContext.EndEdit(true))
        e.Handled = true;
    }
    if (e.KeyCode == Keys.Return & flag5)
    {
      CellContext cellContext = new CellContext(this, this.Selection.ActivePosition);
      if ((cellContext.Cell == null ? 0 : (cellContext.IsEditing() ? 1 : 0)) != 0)
      {
        cellContext.EndEdit(false);
        e.Handled = true;
      }
    }
    if (e.KeyCode == Keys.Tab & flag2)
    {
      CellContext cellContext = new CellContext(this, this.Selection.ActivePosition);
      if ((cellContext.Cell == null ? 0 : (cellContext.IsEditing() ? 1 : 0)) != 0 && !cellContext.EndEdit(false))
      {
        e.Handled = true;
        return;
      }
    }
    bool flag6;
    bool resetSelection = !(flag6 = e.Modifiers == Keys.Shift);
    if (e.KeyCode == Keys.Down & flag3)
    {
      this.Selection.MoveActiveCell(1, 0, resetSelection);
      e.Handled = true;
    }
    else if (e.KeyCode == Keys.Up & flag3)
    {
      this.Selection.MoveActiveCell(-1, 0, resetSelection);
      e.Handled = true;
    }
    else if (e.KeyCode == Keys.Right & flag3)
    {
      this.Selection.MoveActiveCell(0, 1, resetSelection);
      e.Handled = true;
    }
    else if (e.KeyCode == Keys.Left & flag3)
    {
      this.Selection.MoveActiveCell(0, -1, resetSelection);
      e.Handled = true;
    }
    else if (e.KeyCode == Keys.Tab & flag2)
    {
      if (e.Modifiers == Keys.Shift)
      {
        if (!this.Selection.MoveActiveCell(0, -1, -1, int.MaxValue))
          this.FindForm().SelectNextControl((Control) this, false, true, true, true);
        e.Handled = true;
      }
      else
      {
        if (!this.Selection.MoveActiveCell(0, 1, 1, int.MinValue))
          this.FindForm().SelectNextControl((Control) this, true, true, true, true);
        e.Handled = true;
      }
    }
    else if (((e.KeyCode == Keys.Prior ? 1 : (e.KeyCode == Keys.Next ? 1 : 0)) & (flag1 ? 1 : 0)) != 0)
    {
      if (e.KeyCode == Keys.Next)
        this.CustomScrollPageDown();
      else if (e.KeyCode == Keys.Prior)
        this.CustomScrollPageUp();
      e.Handled = true;
    }
    if (flag6)
    {
      this.Selection.ResetSelection(true);
      this.Selection.SelectRange(new Range(this.position_1, this.Selection.ActivePosition), true);
    }
    RangeRegion selRegion = this.ClipboardUseOnlyActivePosition ? new RangeRegion(this.Selection.ActivePosition) : this.Selection.GetSelectionRegion();
    if ((!e.Control ? 0 : (e.KeyCode == Keys.V ? 1 : 0)) != 0)
    {
      this.PerformPaste(selRegion);
      e.Handled = true;
    }
    else if ((!e.Control ? 0 : (e.KeyCode == Keys.C ? 1 : 0)) != 0)
    {
      this.PerformCopy(selRegion);
      e.Handled = true;
    }
    else if ((!e.Control ? 0 : (e.KeyCode == Keys.X ? 1 : 0)) != 0)
    {
      this.PerformCut(selRegion);
      e.Handled = true;
    }
    else
    {
      if (e.KeyCode != Keys.Delete)
        return;
      this.PerformDelete(selRegion);
      e.Handled = true;
    }
  }

  public void PerformCut(RangeRegion selRegion)
  {
    if (((this.ClipboardMode & ClipboardMode.Cut) != ClipboardMode.Cut ? 1 : (selRegion.IsEmpty() ? 1 : 0)) != 0)
      return;
    RangeData.ClipboardSetData(RangeData.LoadData(this, selRegion[0], CutMode.CutImmediately));
  }

  public void PerformPaste(RangeRegion selRegion)
  {
    if (((this.ClipboardMode & ClipboardMode.Paste) != ClipboardMode.Paste ? 1 : (selRegion.IsEmpty() ? 1 : 0)) != 0)
      return;
    RangeData data = RangeData.ClipboardGetData();
    if (data == null)
      return;
    Range range1 = selRegion[0];
    Range sourceRange = data.SourceRange;
    Range range2;
    ref Range local = ref range2;
    Position position = range1.Start;
    int row1 = position.Row;
    position = range1.Start;
    int column1 = position.Column;
    Position p_Start = new Position(row1, column1);
    position = range1.Start;
    int row2 = position.Row;
    position = sourceRange.End;
    int row3 = position.Row;
    position = sourceRange.Start;
    int row4 = position.Row;
    int num1 = row3 - row4;
    int row5 = row2 + num1;
    position = range1.Start;
    int column2 = position.Column;
    position = sourceRange.End;
    int column3 = position.Column;
    position = sourceRange.Start;
    int column4 = position.Column;
    int num2 = column3 - column4;
    int col = column2 + num2;
    Position p_End = new Position(row5, col);
    local = new Range(p_Start, p_End);
    data.WriteData(this, range1.Start);
    this.Selection.ResetSelection(true);
    this.Selection.SelectRange(range2, true);
  }

  public void PerformCopy(RangeRegion selRegion)
  {
    if (((this.ClipboardMode & ClipboardMode.Copy) != ClipboardMode.Copy ? 1 : (selRegion.IsEmpty() ? 1 : 0)) != 0)
      return;
    RangeData.ClipboardSetData(RangeData.LoadData(this, selRegion[0], CutMode.None));
  }

  public void PerformDelete(RangeRegion selRegion)
  {
    if (((this.ClipboardMode & ClipboardMode.Delete) != ClipboardMode.Delete ? 1 : (selRegion.IsEmpty() ? 1 : 0)) != 0)
      return;
    this.ClearValues(selRegion);
  }

  protected override bool IsInputKey(Keys keyData)
  {
    bool flag;
    if (this.OverrideCommonCmdKey)
    {
      if ((this.SpecialKeys & GridSpecialKeys.Arrows) == GridSpecialKeys.Arrows)
      {
        switch (keyData)
        {
          case Keys.Left:
          case Keys.Up:
          case Keys.Right:
          case Keys.Down:
          case Keys.Left | Keys.Shift:
          case Keys.Up | Keys.Shift:
          case Keys.Right | Keys.Shift:
          case Keys.Down | Keys.Shift:
            flag = true;
            goto label_8;
        }
      }
      if ((this.SpecialKeys & GridSpecialKeys.Tab) == GridSpecialKeys.Tab)
      {
        switch (keyData)
        {
          case Keys.Tab:
          case Keys.Tab | Keys.Shift:
            flag = true;
            goto label_8;
        }
      }
    }
    flag = base.IsInputKey(keyData);
label_8:
    return flag;
  }

  protected override bool IsInputChar(char charCode) => this.AcceptsInputChar;

  protected override void OnPaint(PaintEventArgs e)
  {
    base.OnPaint(e);
    using (GraphicsCache graphicsCache = new GraphicsCache(e.Graphics, e.ClipRectangle))
    {
      foreach (Range drawingRange in this.method_0())
        this.OnRangePaint(new RangePaintEventArgs(this, graphicsCache, drawingRange));
    }
  }

  public event RangePaintEventHandler RangePaint;

  protected virtual void OnRangePaint(RangePaintEventArgs e)
  {
    Rectangle rectangle1 = this.RangeToRectangle(e.DrawingRange);
    GraphicsState gstate = e.GraphicsCache.Graphics.Save();
    try
    {
      e.GraphicsCache.Graphics.SetClip(rectangle1);
      int top = rectangle1.Top;
      IHiddenRowCoordinator hiddenRowsCoordinator = this.rowsBase_0.HiddenRowsCoordinator;
      Range drawingRange = e.DrawingRange;
      Position position1 = drawingRange.Start;
      int row1 = position1.Row;
      drawingRange = e.DrawingRange;
      position1 = drawingRange.End;
      int row2 = position1.Row;
      drawingRange = e.DrawingRange;
      position1 = drawingRange.Start;
      int row3 = position1.Row;
      int numberOfRowsToProduce = row2 - row3;
      foreach (int loopVisibleRow in hiddenRowsCoordinator.LoopVisibleRows(row1, numberOfRowsToProduce))
      {
        int height = this.Rows.IsRowVisible(loopVisibleRow) ? this.Rows.GetHeight(loopVisibleRow) : throw new SourceGridException("Incorrect internal state. This rows must have been visible");
        int left = rectangle1.Left;
        drawingRange = e.DrawingRange;
        position1 = drawingRange.Start;
        int column1 = position1.Column;
        while (true)
        {
          int num1 = column1;
          drawingRange = e.DrawingRange;
          position1 = drawingRange.End;
          int column2 = position1.Column;
          if (num1 <= column2)
          {
            int width = this.Columns.GetWidth(column1);
            if (this.Columns.IsColumnVisible(column1))
            {
              Position position2 = new Position(loopVisibleRow, column1);
              ICellVirtual cell = this.GetCell(position2);
              if (cell != null)
              {
                Rectangle rectangle2 = new Rectangle(left, top, width, height);
                Rectangle clipRectangle = e.GraphicsCache.ClipRectangle;
                int num2;
                if (!clipRectangle.IsEmpty)
                {
                  clipRectangle = e.GraphicsCache.ClipRectangle;
                  num2 = clipRectangle.IntersectsWith(rectangle2) ? 1 : 0;
                }
                else
                  num2 = 1;
                if (num2 != 0)
                {
                  CellContext cellContext = new CellContext(this, position2, cell);
                  this.PaintCell(e.GraphicsCache, cellContext, (RectangleF) rectangle2);
                }
              }
              left += width;
            }
            ++column1;
          }
          else
            break;
        }
        top += height;
      }
      foreach (DecoratorBase decorator in (List<DecoratorBase>) this.Decorators)
      {
        if (decorator.IntersectWith(e.DrawingRange))
          decorator.Draw(e);
      }
      // ISSUE: reference to a compiler-generated field
      if (this.rangePaintEventHandler_0 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.rangePaintEventHandler_0(this, e);
    }
    finally
    {
      e.GraphicsCache.Graphics.Restore(gstate);
    }
  }

  protected virtual void PaintCell(
    GraphicsCache graphics,
    CellContext cellContext,
    RectangleF drawRectangle)
  {
    if (((double) drawRectangle.Width <= 0.0 || (double) drawRectangle.Height <= 0.0 ? 0 : (cellContext.CanBeDrawn() ? 1 : 0)) == 0)
      return;
    cellContext.Cell.View.DrawCell(cellContext, graphics, drawRectangle);
  }

  protected override void OnMouseMove(MouseEventArgs e)
  {
    base.OnMouseMove(e);
    Position position = this.PositionAtPoint(new Point(e.X, e.Y));
    ICellVirtual cell1 = this.GetCell(position);
    if (!this.MouseDownPosition.IsEmpty())
    {
      ICellVirtual cell2 = this.GetCell(this.MouseDownPosition);
      if (cell2 == null)
        return;
      this.Controller.OnMouseMove(new CellContext(this, this.MouseDownPosition, cell2), e);
    }
    else
    {
      this.ChangeMouseCell(position);
      if ((position.IsEmpty() ? 0 : (cell1 != null ? 1 : 0)) == 0)
        return;
      this.Controller.OnMouseMove(new CellContext(this, position, cell1), e);
    }
  }

  protected override void OnMouseLeave(EventArgs e)
  {
    base.OnMouseLeave(e);
    this.ChangeMouseCell(Position.Empty);
  }

  protected override void OnMouseDown(MouseEventArgs e)
  {
    base.OnMouseDown(e);
    if (!this.Selection.ActivePosition.IsEmpty())
    {
      CellContext cellContext = new CellContext(this, this.Selection.ActivePosition);
      if ((cellContext.Cell == null ? 0 : (cellContext.IsEditing() ? 1 : 0)) != 0 && !cellContext.EndEdit(false))
        return;
    }
    Position position = this.PositionAtPoint(new Point(e.X, e.Y));
    if (!position.IsEmpty())
    {
      ICellVirtual cell = this.GetCell(position);
      if (cell == null)
        return;
      this.ChangeMouseDownCell(position, position);
      this.Controller.OnMouseDown(new CellContext(this, position, cell), e);
    }
    else
      this.ChangeMouseDownCell(Position.Empty, Position.Empty);
  }

  protected override void OnMouseUp(MouseEventArgs e)
  {
    base.OnMouseUp(e);
    if (this.MouseDownPosition.IsEmpty())
      return;
    ICellVirtual cell = this.GetCell(this.MouseDownPosition);
    if (cell != null)
      this.Controller.OnMouseUp(new CellContext(this, this.MouseDownPosition, cell), e);
    this.ChangeMouseDownCell(Position.Empty, this.PositionAtPoint(new Point(e.X, e.Y)));
  }

  protected override void OnMouseClick(MouseEventArgs e)
  {
    base.OnMouseClick(e);
    Position position = this.PositionAtPoint(this.PointToClient(Control.MousePosition));
    if ((this.MouseDownPosition.IsEmpty() ? 0 : (this.MouseDownPosition == position ? 1 : 0)) == 0)
      return;
    ICellVirtual cell = this.GetCell(this.MouseDownPosition);
    if (cell == null)
      return;
    this.Controller.OnClick(new CellContext(this, this.MouseDownPosition, cell), (EventArgs) e);
  }

  protected override void OnDoubleClick(EventArgs e) => base.OnDoubleClick(e);

  protected override void OnMouseDoubleClick(MouseEventArgs e)
  {
    Class39.smethod_304(this.PositionAtPoint(this.PointToClient(Control.MousePosition)), this, (EventArgs) e);
    base.OnMouseDoubleClick(e);
  }

  protected override void OnMouseWheel(MouseEventArgs e)
  {
    base.OnMouseWheel(e);
    this.CustomScrollWheel(e.Delta);
  }

  protected override void OnKeyDown(KeyEventArgs e)
  {
    base.OnKeyDown(e);
    this.position_2 = this.Selection.ActivePosition;
    if (!this.position_2.IsEmpty())
    {
      ICellVirtual cell = this.GetCell(this.position_2);
      if (cell != null)
        this.Controller.OnKeyDown(new CellContext(this, this.position_2, cell), e);
    }
    if (e.Handled)
      return;
    this.ProcessSpecialGridKey(e);
  }

  protected override void OnKeyUp(KeyEventArgs e)
  {
    base.OnKeyUp(e);
    if (this.position_2.IsEmpty())
      return;
    ICellVirtual cell = this.GetCell(this.position_2);
    if (cell == null)
      return;
    this.Controller.OnKeyUp(new CellContext(this, this.position_2, cell), e);
  }

  protected override void OnKeyPress(KeyPressEventArgs e)
  {
    base.OnKeyPress(e);
    if ((this.position_2.IsEmpty() || e.KeyChar == '\t' || e.KeyChar == '\r' || e.KeyChar == '\u0003' || e.KeyChar == '\u0016' ? 1 : (e.KeyChar == '\u0018' ? 1 : 0)) != 0)
      return;
    ICellVirtual cell = this.GetCell(this.position_2);
    if (cell == null)
      return;
    this.Controller.OnKeyPress(new CellContext(this, this.position_2, cell), e);
  }

  public virtual bool Focus(bool selectFirstCell)
  {
    try
    {
      this.bool_4 = selectFirstCell;
      return this.Focus();
    }
    finally
    {
      this.bool_4 = true;
    }
  }

  protected override void OnEnter(EventArgs e)
  {
    base.OnEnter(e);
    if (((this.Selection.FocusStyle & FocusStyle.FocusFirstCellOnEnter) != FocusStyle.FocusFirstCellOnEnter || !this.bool_4 ? 0 : (this.Selection.ActivePosition.IsEmpty() ? 1 : 0)) == 0)
      return;
    this.Selection.FocusFirstCell(false);
  }

  protected override void OnValidated(EventArgs e)
  {
    base.OnValidated(e);
    if ((this.Selection.FocusStyle & FocusStyle.RemoveFocusCellOnLeave) == FocusStyle.RemoveFocusCellOnLeave)
      this.Selection.Focus(Position.Empty, false);
    if ((this.Selection.FocusStyle & FocusStyle.RemoveSelectionOnLeave) != FocusStyle.RemoveSelectionOnLeave)
      return;
    this.Selection.ResetSelection(true);
  }

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public LinkedControlsList LinkedControls => this.linkedControlsList_0;

  protected override void OnHScrollPositionChanged(ScrollPositionChangedEventArgs e)
  {
    base.OnHScrollPositionChanged(e);
    this.ArrangeLinkedControls();
  }

  protected override void OnVScrollPositionChanged(ScrollPositionChangedEventArgs e)
  {
    base.OnVScrollPositionChanged(e);
    this.ArrangeLinkedControls();
  }

  public virtual void ArrangeLinkedControls()
  {
    this.SuspendLayout();
    foreach (LinkedControlValue linkedControlValue in this.linkedControlsList_0)
    {
      Position position = linkedControlValue.Position;
      if (!position.IsEmpty())
      {
        Control control = linkedControlValue.Control;
        ICellVirtual cell = this.GetCell(linkedControlValue.Position);
        Rectangle rectangle1 = this.PositionToRectangle(linkedControlValue.Position);
        if ((cell == null ? 0 : (linkedControlValue.UseCellBorder ? 1 : 0)) != 0)
          rectangle1 = Rectangle.Round(cell.View.Border.GetContentRectangle((RectangleF) rectangle1));
        control.Bounds = rectangle1;
        position = linkedControlValue.Position;
        int num;
        if (position.Row >= this.FixedRows)
        {
          position = linkedControlValue.Position;
          num = position.Column >= this.FixedColumns ? 1 : 0;
        }
        else
          num = 0;
        if (num != 0)
        {
          Rectangle rectangle2 = this.RangeToRectangle(this.RangeAtArea(CellPositionType.Scrollable));
          control.Visible = !Rectangle.Intersect(rectangle1, rectangle2).IsEmpty;
        }
      }
    }
    this.ResumeLayout(false);
  }

  protected override void OnResize(EventArgs e)
  {
    base.OnResize(e);
    this.SuspendLayout();
    Class39.smethod_698(this);
    Class39.smethod_57(this);
    this.ResumeLayout(true);
  }

  public virtual void OnCellsAreaChanged()
  {
    this.SuspendLayout();
    Class39.smethod_698(this);
    this.CheckPositions();
    this.ArrangeLinkedControls();
    this.ResumeLayout(true);
  }

  public abstract bool EnableSort { get; set; }

  public void SortRangeRows(
    IRangeLoader p_RangeToSort,
    int keyColumn,
    bool p_bAsc,
    IComparer p_CellComparer)
  {
    this.SortRangeRows(p_RangeToSort.GetRange(this), keyColumn, p_bAsc, p_CellComparer);
  }

  public void SortRangeRows(
    Range p_Range,
    int keyColumn,
    bool p_bAscending,
    IComparer p_CellComparer)
  {
    SortRangeRowsEventArgs e = new SortRangeRowsEventArgs(p_Range, keyColumn, p_bAscending, p_CellComparer);
    // ISSUE: reference to a compiler-generated field
    if (this.sortRangeRowsEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.sortRangeRowsEventHandler_0((object) this, e);
    }
    this.OnSortingRangeRows(e);
    // ISSUE: reference to a compiler-generated field
    if (this.sortRangeRowsEventHandler_1 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.sortRangeRowsEventHandler_1((object) this, e);
    }
    this.OnSortedRangeRows(e);
  }

  [Browsable(true)]
  public event SortRangeRowsEventHandler SortingRangeRows;

  [Browsable(true)]
  public event SortRangeRowsEventHandler SortedRangeRows;

  protected virtual void OnSortingRangeRows(SortRangeRowsEventArgs e)
  {
  }

  protected virtual void OnSortedRangeRows(SortRangeRowsEventArgs e)
  {
  }

  public abstract ICellVirtual GetCell(int p_iRow, int p_iCol);

  public ICellVirtual GetCell(Position p_Position)
  {
    return !p_Position.IsEmpty() ? this.GetCell(p_Position.Row, p_Position.Column) : (ICellVirtual) null;
  }

  public virtual ICellVirtual[] GetCellsAtRow(int p_RowIndex)
  {
    ICellVirtual[] cellsAtRow = new ICellVirtual[this.Columns.Count];
    for (int p_iCol = 0; p_iCol < this.Columns.Count; ++p_iCol)
      cellsAtRow[p_iCol] = this.GetCell(p_RowIndex, p_iCol);
    return cellsAtRow;
  }

  public virtual ICellVirtual[] GetCellsAtColumn(int p_ColumnIndex)
  {
    ICellVirtual[] cellsAtColumn = new ICellVirtual[this.Rows.Count];
    for (int p_iRow = 0; p_iRow < this.Rows.Count; ++p_iRow)
      cellsAtColumn[p_iRow] = this.GetCell(p_iRow, p_ColumnIndex);
    return cellsAtColumn;
  }

  [DefaultValue(0)]
  public int FixedRows
  {
    get => this.int_9;
    set
    {
      if (this.int_9 == value)
        return;
      this.int_9 = value;
      this.OnCellsAreaChanged();
    }
  }

  public int ActualFixedRows
  {
    get => this.FixedRows <= this.Rows.Count ? this.FixedRows : this.Rows.Count;
  }

  [DefaultValue(0)]
  public int FixedColumns
  {
    get => this.int_10;
    set
    {
      if (this.int_10 == value)
        return;
      this.int_10 = value;
      this.OnCellsAreaChanged();
    }
  }

  public int ActualFixedColumns
  {
    get => this.FixedColumns <= this.Columns.Count ? this.FixedColumns : this.Columns.Count;
  }

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public RowsBase Rows => this.rowsBase_0;

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public ColumnsBase Columns => this.columnsBase_0;

  public CellPositionType GetPositionType(Position position)
  {
    return !position.IsEmpty() ? ((position.Row >= this.FixedRows ? 0 : (position.Column < this.FixedColumns ? 1 : 0)) == 0 ? (position.Row >= this.FixedRows ? (position.Column >= this.FixedColumns ? CellPositionType.Scrollable : CellPositionType.FixedLeft) : CellPositionType.FixedTop) : CellPositionType.FixedTopLeft) : CellPositionType.Empty;
  }

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public Range CompleteRange
  {
    get
    {
      return (this.Rows.Count <= 0 ? 0 : (this.Columns.Count > 0 ? 1 : 0)) == 0 ? Range.Empty : new Range(0, 0, this.Rows.Count - 1, this.Columns.Count - 1);
    }
  }

  public event ExceptionEventHandler UserException;

  public virtual void OnUserException(ExceptionEventArgs e)
  {
    Debug.WriteLine("Exception on editing cell: " + e.Exception.ToString());
    // ISSUE: reference to a compiler-generated field
    if (this.exceptionEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.exceptionEventHandler_0((object) this, e);
    }
    if (e.Handled)
      return;
    ErrorDialog.Show((IWin32Window) this, e.Exception, "Error");
    e.Handled = true;
  }

  [Description("Change the right-to-left layout.")]
  [DefaultValue(false)]
  [Localizable(true)]
  [Category("Appearance")]
  [Browsable(true)]
  public bool Mirrored
  {
    get => this.bool_5;
    set
    {
      if (this.bool_5 == value)
        return;
      this.bool_5 = value;
      this.OnRightToLeftChanged(EventArgs.Empty);
    }
  }

  protected override CreateParams CreateParams
  {
    get
    {
      CreateParams createParams = base.CreateParams;
      if (this.Mirrored)
        createParams.ExStyle |= 4194304 /*0x400000*/;
      return createParams;
    }
  }

  [Browsable(false)]
  [DefaultValue(RightToLeft.No)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public override RightToLeft RightToLeft
  {
    get => RightToLeft.No;
    set
    {
    }
  }

  public virtual void ClearValues(RangeRegion region)
  {
    foreach (Position cellsPosition in (List<Position>) region.GetCellsPositions())
    {
      CellContext cellContext = new CellContext(this, cellsPosition);
      if (cellContext.Cell != null && cellContext.Cell.Editor != null)
        cellContext.Cell.Editor.ClearCell(cellContext);
    }
  }

  public string ToolTipText
  {
    get => this.toolTip_0.GetToolTip((Control) this);
    set => this.toolTip_0.SetToolTip((Control) this, value);
  }

  public ToolTip ToolTip => this.toolTip_0;

  public DecoratorList Decorators => this.decoratorList_0;

  public ControllerContainer Controller => this.controllerContainer_0;

  [DefaultValue(ClipboardMode.None)]
  public ClipboardMode ClipboardMode
  {
    get => this.clipboardMode_0;
    set => this.clipboardMode_0 = value;
  }

  [DefaultValue(false)]
  public bool ClipboardUseOnlyActivePosition
  {
    get => this.bool_6;
    set => this.bool_6 = value;
  }

  public override void CustomScrollPageDown()
  {
    bool flag = false;
    int int_0_1 = 0;
    int num1 = 0;
    Range cellRange = this.PositionToCellRange(this.Selection.ActivePosition);
    if (cellRange.IsEmpty())
    {
      this.Selection.MoveActiveCell(1, 0);
    }
    else
    {
      List<int> visibleRows = this.GetVisibleRows(false);
      if (visibleRows.Count <= this.ActualFixedRows + 1)
      {
        this.Selection.MoveActiveCell(1, 0);
      }
      else
      {
        int int_0_2 = visibleRows[this.ActualFixedRows];
        int num2 = visibleRows[visibleRows.Count - 1];
        Position position = cellRange.Start;
        if (Class39.smethod_308(this, position.Row))
        {
          int p_Row = Class39.smethod_131(int_0_2, num2, this);
          if (cellRange.ContainsRow(p_Row))
          {
            if (Class39.smethod_23(this, num2) != -1)
            {
              flag = true;
              int_0_1 = num2;
              int num3 = Class39.smethod_448(int_0_1, this);
              num1 = Class39.smethod_131(int_0_1, num3, this);
              if (num1 == -1)
              {
                num1 = Class39.smethod_23(this, num3);
                int_0_1 = Class39.smethod_798(this, num1);
              }
            }
            else
            {
              this.Selection.MoveActiveCell(1, 0);
              return;
            }
          }
          else
          {
            Position pCellToActivate;
            ref Position local = ref pCellToActivate;
            int row = p_Row;
            position = this.Selection.ActivePosition;
            int column = position.Column;
            local = new Position(row, column);
            this.Selection.Focus(pCellToActivate, true);
          }
        }
        else
        {
          flag = true;
          position = cellRange.Start;
          int_0_1 = position.Row;
          int int_1 = Class39.smethod_448(int_0_1, this);
          num1 = Class39.smethod_131(int_0_1, int_1, this);
        }
        if (!flag)
          return;
        int int_3 = 0;
        int int_2 = 0;
        Class39.smethod_291(int_0_1, num1, this, out int_2, ref int_3);
        this.CustomScrollPageToLine(Class39.smethod_214(this, int_3) - this.ActualFixedRows);
        if (cellRange.ContainsRow(int_2))
          return;
        Position pCellToActivate1;
        ref Position local1 = ref pCellToActivate1;
        int row1 = int_2;
        position = this.Selection.ActivePosition;
        int column1 = position.Column;
        local1 = new Position(row1, column1);
        this.Selection.Focus(pCellToActivate1, true);
      }
    }
  }

  public override void CustomScrollPageUp()
  {
    bool flag = false;
    int num1 = 0;
    int int_0_1 = 0;
    int row1 = this.Selection.ActivePosition.Row;
    if (row1 == -1)
    {
      this.Selection.MoveActiveCell(-1, 0);
    }
    else
    {
      List<int> visibleRows = this.GetVisibleRows(false);
      if (visibleRows.Count <= this.ActualFixedRows + 1)
      {
        this.Selection.MoveActiveCell(-1, 0);
      }
      else
      {
        int num2 = visibleRows[this.ActualFixedRows];
        int int_0_2 = visibleRows[visibleRows.Count - 1];
        if (row1 == num2 && row1 > this.ActualFixedRows)
        {
          int height = this.DisplayRectangle.Height;
          for (int row2 = 0; row2 < this.ActualFixedRows; ++row2)
            height -= this.Rows.GetHeight(row2);
          if (height <= this.Rows.GetHeight(row1 - 1))
          {
            this.Selection.MoveActiveCell(-1, 0);
            return;
          }
        }
        if (Class39.smethod_308(this, row1))
        {
          int row3 = Class39.smethod_485(int_0_2, this, num2);
          if (row3 == row1)
          {
            if (Class39.smethod_545(num2, this) != -1)
            {
              flag = true;
              int int_0_3 = num2;
              num1 = Class39.smethod_798(this, int_0_3);
              int_0_1 = Class39.smethod_485(int_0_3, this, num1);
              if (int_0_1 == -1)
              {
                int_0_1 = Class39.smethod_545(num1, this);
                num1 = int_0_1;
              }
            }
            else
            {
              this.Selection.MoveActiveCell(-1, 0);
              return;
            }
          }
          else
            this.Selection.Focus(new Position(row3, this.Selection.ActivePosition.Column), true);
        }
        else
        {
          flag = true;
          int int_0_4 = row1;
          num1 = Class39.smethod_798(this, int_0_4);
          int_0_1 = Class39.smethod_485(int_0_4, this, num1);
        }
        if (!flag)
          return;
        int int_3 = 0;
        int int_2 = 0;
        Class39.smethod_830(int_0_1, num1, out int_2, out int_3, this);
        this.CustomScrollPageToLine(Class39.smethod_214(this, int_3) - this.ActualFixedRows);
        if (int_2 == row1)
          return;
        this.Selection.Focus(new Position(int_2, this.Selection.ActivePosition.Column), true);
      }
    }
  }
}
