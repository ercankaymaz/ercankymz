// Decompiled with JetBrains decompiler
// Type: SourceGrid.ColumnsBase
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using SourceGrid.Cells;
using System;
using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace SourceGrid;

public abstract class ColumnsBase
{
  private GridVirtual grid;
  private int int_0 = 0;

  public ColumnsBase(GridVirtual grid) => this.grid = grid;

  public GridVirtual Grid => this.grid;

  public abstract int Count { get; }

  public abstract int GetWidth(int column);

  public abstract void SetWidth(int column, int width);

  public abstract AutoSizeMode GetAutoSizeMode(int column);

  public void AutoSizeColumn(int column) => this.AutoSizeColumn(column, true);

  public void AutoSizeColumn(int column, bool useRowHeight)
  {
    int StartRow = 0;
    int EndRow = this.Grid.Rows.Count - 1;
    if ((this.GetAutoSizeMode(column) & AutoSizeMode.EnableAutoSizeView) == AutoSizeMode.EnableAutoSizeView)
    {
      if (!this.Grid.GetVisibleColumns(true).Contains(column))
        return;
      List<int> visibleRows = this.Grid.GetVisibleRows(true);
      visibleRows.Sort();
      if (visibleRows.Count == 0)
        return;
      StartRow = visibleRows[0];
      EndRow = visibleRows[visibleRows.Count - 1];
    }
    this.AutoSizeColumn(column, useRowHeight, StartRow, EndRow);
  }

  public void AutoSizeColumn(int column, bool useRowHeight, int StartRow, int EndRow)
  {
    if (((this.GetAutoSizeMode(column) & AutoSizeMode.EnableAutoSize) != AutoSizeMode.EnableAutoSize ? 0 : (this.IsColumnVisible(column) ? 1 : 0)) == 0)
      return;
    this.SetWidth(column, this.MeasureColumnWidth(column, useRowHeight, StartRow, EndRow));
  }

  public int MeasureColumnWidth(int column, bool useRowHeight, int StartRow, int EndRow)
  {
    int num1 = this.Grid.MinimumWidth;
    int num2;
    if ((this.GetAutoSizeMode(column) & AutoSizeMode.MinimumSize) == AutoSizeMode.MinimumSize)
    {
      num2 = num1;
    }
    else
    {
      for (int index = StartRow; index <= EndRow; ++index)
      {
        ICellVirtual cell = this.Grid.GetCell(index, column);
        if (cell != null)
        {
          Position pPosition = new Position(index, column);
          Size empty = Size.Empty;
          if (useRowHeight)
            empty.Height = this.Grid.RangeToSize(this.Grid.PositionToCellRange(pPosition)).Height;
          Size size = new CellContext(this.Grid, pPosition, cell).Measure(empty);
          if (size.Width > num1)
            num1 = size.Width;
        }
      }
      num2 = num1;
    }
    return num2;
  }

  public void AutoSize(bool useRowHeight)
  {
    this.SuspendLayout();
    for (int column = 0; column < this.Count; ++column)
      this.AutoSizeColumn(column, useRowHeight);
    this.ResumeLayout();
  }

  public void AutoSize(bool useRowHeight, int StartRow, int EndRow)
  {
    this.SuspendLayout();
    for (int column = 0; column < this.Count; ++column)
      this.AutoSizeColumn(column, useRowHeight, StartRow, EndRow);
    this.ResumeLayout();
  }

  public virtual void StretchToFit()
  {
    this.SuspendLayout();
    Rectangle displayRectangle = this.Grid.DisplayRectangle;
    if ((this.Count <= 0 ? 0 : (displayRectangle.Width > 0 ? 1 : 0)) != 0 && this.ColumnsInsideRegion(displayRectangle.X, displayRectangle.Width).Count >= this.Count)
    {
      int? nullable = new int?(this.GetRight(this.Count - 1));
      if ((!nullable.HasValue ? 0 : (displayRectangle.Width > nullable.Value ? 1 : 0)) != 0)
      {
        int num1 = 0;
        for (int column = 0; column < this.Count; ++column)
        {
          if (((this.GetAutoSizeMode(column) & AutoSizeMode.EnableStretch) != AutoSizeMode.EnableStretch ? 0 : (this.IsColumnVisible(column) ? 1 : 0)) != 0)
            ++num1;
        }
        if (num1 > 0)
        {
          int num2 = (displayRectangle.Width - nullable.Value) / num1;
          for (int column = 0; column < this.Count; ++column)
          {
            if (((this.GetAutoSizeMode(column) & AutoSizeMode.EnableStretch) != AutoSizeMode.EnableStretch ? 0 : (this.IsColumnVisible(column) ? 1 : 0)) != 0)
              this.SetWidth(column, this.GetWidth(column) + num2);
          }
        }
      }
    }
    this.ResumeLayout();
  }

  public List<int> ColumnsInsideRegion(int x, int width)
  {
    return this.ColumnsInsideRegion(x, width, true, true);
  }

  public List<int> ColumnsInsideRegion(
    int x,
    int width,
    bool returnsPartial,
    bool returnsFixedColumns)
  {
    int num1 = x + width;
    List<int> intList = new List<int>();
    for (int column = 0; (column >= this.Grid.FixedColumns ? 0 : (column < this.Count ? 1 : 0)) != 0; ++column)
    {
      int left = this.GetLeft(column);
      int num2 = left + this.GetWidth(column);
      if ((num1 < left || x > num2 ? 0 : (returnsPartial ? 1 : (num2 > num1 ? 0 : (left >= x ? 1 : 0)))) != 0 && returnsFixedColumns)
        intList.Add(column);
      if (num2 > num1)
        break;
    }
    int? scrollableColumn = this.FirstVisibleScrollableColumn;
    if (scrollableColumn.HasValue)
    {
      for (int column = scrollableColumn.Value; column < this.Count; ++column)
      {
        int left = this.GetLeft(column);
        int num3 = left + this.GetWidth(column);
        if ((num1 < left || x > num3 ? 0 : (returnsPartial ? 1 : (num3 > num1 ? 0 : (left >= x ? 1 : 0)))) != 0)
          intList.Add(column);
        if (num3 > num1)
          break;
      }
    }
    return intList;
  }

  public int? ColumnAtPoint(int x)
  {
    List<int> intList = this.ColumnsInsideRegion(x, 1);
    return intList.Count != 0 ? new int?(intList[0]) : new int?();
  }

  public int? FirstVisibleScrollableColumn
  {
    get
    {
      int num = this.Grid.CustomScrollPosition.X + this.Grid.FixedColumns;
      return num < this.Count ? new int?(num) : new int?();
    }
  }

  public int? LastVisibleScrollableColumn
  {
    get
    {
      int? scrollableColumn1 = this.FirstVisibleScrollableColumn;
      int? scrollableColumn2;
      if (!scrollableColumn1.HasValue)
      {
        scrollableColumn2 = new int?();
      }
      else
      {
        Rectangle scrollableArea = this.Grid.GetScrollableArea();
        int left = this.GetLeft(scrollableColumn1.Value);
        int column;
        for (column = scrollableColumn1.Value; column < this.Count; ++column)
        {
          left += this.GetWidth(column);
          if (left >= scrollableArea.Right)
          {
            scrollableColumn2 = new int?(column);
            goto label_8;
          }
        }
        scrollableColumn2 = new int?(column - 1);
      }
label_8:
      return scrollableColumn2;
    }
  }

  public Range GetRange(int column) => new Range(0, column, this.Grid.Rows.Count - 1, column);

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

  public void ColumnsChanged() => this.PerformLayout();

  public int GetAbsoluteLeft(int column)
  {
    if (column < 0)
      throw new ArgumentException("Must be a valid index");
    int absoluteLeft = 0;
    for (int column1 = 0; column1 < column; ++column1)
      absoluteLeft += this.GetWidth(column1);
    return absoluteLeft;
  }

  public int GetAbsoluteRight(int column) => this.GetAbsoluteLeft(column) + this.GetWidth(column);

  public int GetLeft(int column)
  {
    int num1 = Math.Min(this.Grid.FixedColumns, this.Count);
    int num2 = 0;
    int left;
    for (int column1 = 0; column1 < num1; ++column1)
    {
      if (column1 != column)
      {
        num2 += this.GetWidth(column1);
      }
      else
      {
        left = num2;
        goto label_22;
      }
    }
    int? nullable1 = this.FirstVisibleScrollableColumn;
    if (!nullable1.HasValue)
      nullable1 = new int?(this.Count);
    int? nullable2 = nullable1;
    int num3 = column;
    if (nullable2.GetValueOrDefault() == num3 & nullable2.HasValue)
    {
      left = num2;
    }
    else
    {
      nullable2 = nullable1;
      int num4 = column;
      if (nullable2.GetValueOrDefault() < num4 & nullable2.HasValue)
      {
        for (int column2 = nullable1.Value; column2 < this.Count; ++column2)
        {
          if (column2 != column)
          {
            num2 += this.GetWidth(column2);
          }
          else
          {
            left = num2;
            goto label_22;
          }
        }
      }
      else
      {
        nullable2 = nullable1;
        int num5 = column;
        if (nullable2.GetValueOrDefault() > num5 & nullable2.HasValue)
        {
          for (int column3 = nullable1.Value - 1; column3 >= 0; --column3)
          {
            num2 -= this.GetWidth(column3);
            if (column3 == column)
            {
              left = num2;
              goto label_22;
            }
          }
        }
      }
      throw new IndexOutOfRangeException();
    }
label_22:
    return left;
  }

  public int GetRight(int column) => this.GetLeft(column) + this.GetWidth(column);

  public abstract void ShowColumn(int column);

  public abstract void HideColumn(int column);

  public abstract bool IsColumnVisible(int column);
}
