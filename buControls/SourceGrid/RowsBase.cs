// Decompiled with JetBrains decompiler
// Type: SourceGrid.RowsBase
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using SourceGrid.Cells;
using System;
using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace SourceGrid;

public abstract class RowsBase : IRows
{
  private GridVirtual grid;
  protected IHiddenRowCoordinator m_HiddenRowsCoordinator = (IHiddenRowCoordinator) null;
  private int int_0 = 0;

  public event RowVisibilityChangedHandler RowVisibilityChanged;

  protected virtual void OnRowVisibilityChanged(int rowIndex, bool becameVisible)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.rowVisibilityChangedHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.rowVisibilityChangedHandler_0(rowIndex, becameVisible);
  }

  public IHiddenRowCoordinator HiddenRowsCoordinator => this.m_HiddenRowsCoordinator;

  public RowsBase(GridVirtual grid)
  {
    this.grid = grid;
    this.m_HiddenRowsCoordinator = (IHiddenRowCoordinator) new StandardHiddenRowCoordinator(this);
  }

  public GridVirtual Grid => this.grid;

  public abstract int Count { get; }

  public abstract int GetHeight(int row);

  public abstract void SetHeight(int row, int height);

  public abstract AutoSizeMode GetAutoSizeMode(int row);

  public List<int> RowsInsideRegion(int y, int height)
  {
    return this.RowsInsideRegion(y, height, true, true);
  }

  public List<int> RowsInsideRegion(int y, int height, bool returnsPartial, bool returnsFixedRows)
  {
    int num1 = y + height;
    List<int> intList = new List<int>();
    for (int row = 0; (row >= this.Grid.FixedRows ? 0 : (row < this.Count ? 1 : 0)) != 0; ++row)
    {
      int top = this.GetTop(row);
      int num2 = top + this.GetHeight(row);
      if ((num1 < top || y > num2 ? 0 : (returnsPartial ? 1 : (num2 > num1 ? 0 : (top >= y ? 1 : 0)))) != 0 && returnsFixedRows)
        intList.Add(row);
      if (num2 > num1)
        break;
    }
    int? visibleScrollableRow = this.FirstVisibleScrollableRow;
    if (visibleScrollableRow.HasValue)
    {
      for (int row = visibleScrollableRow.Value; row < this.Count; ++row)
      {
        int top = this.GetTop(row);
        int num3 = top + this.GetHeight(row);
        if ((num1 < top || y > num3 ? 0 : (returnsPartial ? 1 : (num3 > num1 ? 0 : (top >= y ? 1 : 0)))) != 0)
          intList.Add(row);
        if (num3 > num1)
          break;
      }
    }
    return intList;
  }

  public int? RowAtPoint(int y)
  {
    List<int> intList = this.RowsInsideRegion(y, 1);
    return intList.Count != 0 ? new int?(intList[0]) : new int?();
  }

  public int? FirstVisibleScrollableRow
  {
    get
    {
      int num = this.HiddenRowsCoordinator.ConvertScrollbarValueToRowIndex(this.Grid.CustomScrollPosition.Y) + this.Grid.FixedRows;
      return num < this.Count ? new int?(num) : new int?();
    }
  }

  public int? LastVisibleScrollableRow
  {
    get
    {
      int? visibleScrollableRow1 = this.FirstVisibleScrollableRow;
      int? visibleScrollableRow2;
      if (!visibleScrollableRow1.HasValue)
      {
        visibleScrollableRow2 = new int?();
      }
      else
      {
        Rectangle scrollableArea = this.Grid.GetScrollableArea();
        int top = this.GetTop(visibleScrollableRow1.Value);
        int row;
        for (row = visibleScrollableRow1.Value; row < this.Count; ++row)
        {
          top += this.GetHeight(row);
          if (top >= scrollableArea.Bottom)
          {
            visibleScrollableRow2 = new int?(row);
            goto label_8;
          }
        }
        visibleScrollableRow2 = new int?(row - 1);
      }
label_8:
      return visibleScrollableRow2;
    }
  }

  public void AutoSizeRow(int row)
  {
    int StartCol = 0;
    int EndCol = this.Grid.Columns.Count - 1;
    if ((this.GetAutoSizeMode(row) & AutoSizeMode.EnableAutoSizeView) == AutoSizeMode.EnableAutoSizeView)
    {
      if (!this.Grid.GetVisibleRows(true).Contains(row))
        return;
      List<int> visibleColumns = this.Grid.GetVisibleColumns(true);
      visibleColumns.Sort();
      if (visibleColumns.Count == 0)
        return;
      StartCol = visibleColumns[0];
      EndCol = visibleColumns[visibleColumns.Count - 1];
    }
    this.AutoSizeRow(row, true, StartCol, EndCol);
  }

  public void AutoSizeRow(int row, bool useColumnWidth, int StartCol, int EndCol)
  {
    if (((this.GetAutoSizeMode(row) & AutoSizeMode.EnableAutoSize) != AutoSizeMode.EnableAutoSize ? 0 : (this.IsRowVisible(row) ? 1 : 0)) == 0)
      return;
    this.SetHeight(row, this.MeasureRowHeight(row, useColumnWidth, StartCol, EndCol));
  }

  public int MeasureRowHeight(int row, bool useColumnWidth, int StartCol, int EndCol)
  {
    int num1 = this.Grid.MinimumHeight;
    int num2;
    if ((this.GetAutoSizeMode(row) & AutoSizeMode.MinimumSize) == AutoSizeMode.MinimumSize)
    {
      num2 = num1;
    }
    else
    {
      for (int index = StartCol; index <= EndCol; ++index)
      {
        ICellVirtual cell = this.Grid.GetCell(row, index);
        if (cell != null)
        {
          Position pPosition = new Position(row, index);
          Size empty = Size.Empty;
          if (useColumnWidth)
            empty.Width = this.Grid.RangeToSize(this.Grid.PositionToCellRange(pPosition)).Width;
          Size size = new CellContext(this.Grid, pPosition, cell).Measure(empty);
          if (size.Height > num1)
            num1 = size.Height;
        }
      }
      num2 = num1;
    }
    return num2;
  }

  public void AutoSize(bool useColumnWidth)
  {
    this.AutoSize(useColumnWidth, 0, this.Grid.Columns.Count - 1);
  }

  public void AutoSize(bool useColumnWidth, int StartCol, int EndCol)
  {
    this.SuspendLayout();
    for (int row = 0; row < this.Count; ++row)
      this.AutoSizeRow(row, useColumnWidth, StartCol, EndCol);
    this.ResumeLayout();
  }

  public virtual void StretchToFit()
  {
    this.SuspendLayout();
    Rectangle displayRectangle = this.Grid.DisplayRectangle;
    if ((this.Count <= 0 ? 0 : (displayRectangle.Height > 0 ? 1 : 0)) != 0 && this.RowsInsideRegion(displayRectangle.Y, displayRectangle.Height).Count >= this.Count)
    {
      int? nullable = new int?(this.GetBottom(this.Count - 1));
      if ((!nullable.HasValue ? 0 : (displayRectangle.Height > nullable.Value ? 1 : 0)) != 0)
      {
        int num1 = 0;
        for (int row = 0; row < this.Count; ++row)
        {
          if (((this.GetAutoSizeMode(row) & AutoSizeMode.EnableStretch) != AutoSizeMode.EnableStretch ? 0 : (this.IsRowVisible(row) ? 1 : 0)) != 0)
            ++num1;
        }
        if (num1 > 0)
        {
          int num2 = (displayRectangle.Height - nullable.Value) / num1;
          for (int row = 0; row < this.Count; ++row)
          {
            if (((this.GetAutoSizeMode(row) & AutoSizeMode.EnableStretch) != AutoSizeMode.EnableStretch ? 0 : (this.IsRowVisible(row) ? 1 : 0)) != 0)
              this.SetHeight(row, this.GetHeight(row) + num2);
          }
        }
      }
    }
    this.ResumeLayout();
  }

  public Range GetRange(int row) => new Range(row, 0, row, this.Grid.Columns.Count - 1);

  public void SuspendLayout() => ++this.int_0;

  public void ResumeLayout()
  {
    if (this.int_0 > 0)
      --this.int_0;
    this.PerformLayout();
  }

  public void PerformLayout()
  {
    if (this.int_0 != 0)
      return;
    this.OnLayout();
  }

  protected virtual void OnLayout() => this.Grid.OnCellsAreaChanged();

  public void RowsChanged() => this.PerformLayout();

  public int GetAbsoluteTop(int row)
  {
    if (row < 0)
      throw new ArgumentException("Must be a valid index");
    int absoluteTop = 0;
    for (int row1 = 0; row1 < row; ++row1)
      absoluteTop += this.GetHeight(row1);
    return absoluteTop;
  }

  public int GetAbsoluteBottom(int row) => this.GetAbsoluteTop(row) + this.GetHeight(row);

  public int GetTop(int row)
  {
    if (row < 0)
      throw new ArgumentNullException("Row is less than 0");
    int num1 = Math.Min(this.Grid.FixedRows, this.Count);
    int num2 = 0;
    int top;
    for (int row1 = 0; row1 < num1; ++row1)
    {
      if (row1 != row)
      {
        num2 += this.GetHeight(row1);
      }
      else
      {
        top = num2;
        goto label_16;
      }
    }
    int? nullable1 = this.FirstVisibleScrollableRow;
    if (!nullable1.HasValue)
      nullable1 = new int?(this.Count);
    int? nullable2 = nullable1;
    int num3 = row;
    if (nullable2.GetValueOrDefault() == num3 & nullable2.HasValue)
    {
      top = num2;
    }
    else
    {
      nullable2 = nullable1;
      int num4 = row;
      if (nullable2.GetValueOrDefault() < num4 & nullable2.HasValue)
      {
        top = num2 + Class39.smethod_509(nullable1.Value, row, this);
      }
      else
      {
        nullable2 = nullable1;
        int num5 = row;
        if (!(nullable2.GetValueOrDefault() > num5 & nullable2.HasValue))
          throw new IndexOutOfRangeException($"row value is {row}");
        top = num2 + Class39.smethod_683(nullable1.Value, row, this);
      }
    }
label_16:
    return top;
  }

  public int GetBottom(int row) => this.GetTop(row) + this.GetHeight(row);

  public void ShowRow(int row) => this.ShowRow(row, true);

  public void ShowRow(int row, bool isVisible)
  {
    if ((!isVisible ? 0 : (!this.IsRowVisible(row) ? 1 : 0)) != 0)
    {
      this.SetHeight(row, this.Grid.DefaultHeight);
      this.OnRowVisibilityChanged(row, isVisible);
    }
    else
    {
      if ((isVisible ? 0 : (this.IsRowVisible(row) ? 1 : 0)) == 0)
        return;
      this.SetHeight(row, 0);
      this.OnRowVisibilityChanged(row, isVisible);
    }
  }

  public void HideRow(int row) => this.ShowRow(row, false);

  public bool IsRowVisible(int row) => this.GetHeight(row) > 0;
}
