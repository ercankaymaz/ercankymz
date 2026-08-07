// Decompiled with JetBrains decompiler
// Type: SourceGrid.SpannedCellRangesController
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using SourceGrid.Cells;
using System;
using System.Collections.Generic;

#nullable disable
namespace SourceGrid;

public class SpannedCellRangesController : ISpannedCellRangesController
{
  private Grid grid = (Grid) null;

  public ISpannedRangesCollection SpannedRangesCollection { get; private set; }

  public Grid Grid => this.grid;

  public void UpdateOrAdd(Range newRange)
  {
    if (newRange.Equals(Range.Empty))
      throw new ArgumentException("Range can not be empty");
    if (!this.SpannedRangesCollection.FindRangeWithStart(newRange.Start).HasValue)
      this.SpannedRangesCollection.Add(newRange);
    else
      this.SpannedRangesCollection.Update(Range.FromPosition(newRange.Start), newRange);
  }

  public void Update(Range newRange)
  {
    this.SpannedRangesCollection.Update((this.SpannedRangesCollection.FindRangeWithStart(newRange.Start) ?? throw new ArgumentException($"Could not find a spanned cell range with the same starting point as {newRange.Start}")).Value, newRange);
  }

  public SpannedCellRangesController(Grid grid, ISpannedRangesCollection spannedRangeCollection)
    : this(grid)
  {
    this.SpannedRangesCollection = spannedRangeCollection;
  }

  public SpannedCellRangesController(Grid grid)
  {
    this.grid = grid;
    this.SpannedRangesCollection = (ISpannedRangesCollection) new SpannedRangesList();
  }

  public void MoveLeftSpannedRanges(int startIndex, int moveCount)
  {
    foreach (Range oldRange in this.SpannedRangesCollection.ToArray())
    {
      Position position = oldRange.Start;
      if (position.Column > startIndex)
      {
        Range newRange;
        ref Range local = ref newRange;
        position = oldRange.Start;
        int row1 = position.Row;
        position = oldRange.Start;
        int p_StartCol = position.Column - moveCount;
        position = oldRange.End;
        int row2 = position.Row;
        position = oldRange.End;
        int p_EndCol = position.Column - moveCount;
        local = new Range(row1, p_StartCol, row2, p_EndCol);
        this.SpannedRangesCollection.Update(oldRange, newRange);
      }
    }
  }

  public void MoveUpSpannedRanges(int startIndex, int moveCount)
  {
    foreach (Range oldRange in this.SpannedRangesCollection.ToArray())
    {
      if (oldRange.Start.Row > startIndex)
      {
        Range newRange = new Range(oldRange.Start.Row - moveCount, oldRange.Start.Column, oldRange.End.Row - moveCount, oldRange.End.Column);
        this.SpannedRangesCollection.Update(oldRange, newRange);
      }
    }
  }

  public void Swap(int rowIndex1, int rowIndex2)
  {
    Range range1 = new Range(rowIndex1, 0, rowIndex1, int.MaxValue);
    Range range2 = new Range(rowIndex2, 0, rowIndex2, int.MaxValue);
    List<Range> ranges1 = this.SpannedRangesCollection.GetRanges(range1);
    List<Range> ranges2 = this.SpannedRangesCollection.GetRanges(range2);
    foreach (Range oldRange in ranges1)
    {
      if (oldRange.RowsCount > 1)
        throw new SourceGridException("Can not swap rows if they contain spanned ranged which extend more than one row");
      Range newRange;
      ref Range local = ref newRange;
      int p_StartRow = rowIndex2;
      Position position = oldRange.Start;
      int column1 = position.Column;
      int p_EndRow = rowIndex2;
      position = oldRange.End;
      int column2 = position.Column;
      local = new Range(p_StartRow, column1, p_EndRow, column2);
      this.SpannedRangesCollection.Update(oldRange, newRange);
    }
    foreach (Range oldRange in ranges2)
    {
      if (oldRange.RowsCount > 1)
        throw new SourceGridException("Can not swap rows if they contain spanned ranged which extend more than one row");
      Range newRange;
      ref Range local = ref newRange;
      int p_StartRow = rowIndex1;
      Position position = oldRange.Start;
      int column3 = position.Column;
      int p_EndRow = rowIndex1;
      position = oldRange.End;
      int column4 = position.Column;
      local = new Range(p_StartRow, column3, p_EndRow, column4);
      this.SpannedRangesCollection.Update(oldRange, newRange);
    }
  }

  public void MoveDownSpannedRanges(int startIndex, int moveCount)
  {
    foreach (Range oldRange in this.SpannedRangesCollection.ToArray())
    {
      Position position = oldRange.Start;
      if (position.Row >= startIndex)
      {
        Range newRange;
        ref Range local = ref newRange;
        position = oldRange.Start;
        int p_StartRow = position.Row + moveCount;
        position = oldRange.Start;
        int column1 = position.Column;
        position = oldRange.End;
        int p_EndRow = position.Row + moveCount;
        position = oldRange.End;
        int column2 = position.Column;
        local = new Range(p_StartRow, column1, p_EndRow, column2);
        this.SpannedRangesCollection.Update(oldRange, newRange);
      }
    }
  }

  public void MoveRightSpannedRanges(int startIndex, int moveCount)
  {
    foreach (Range oldRange in this.SpannedRangesCollection.ToArray())
    {
      if (oldRange.Start.Column >= startIndex)
      {
        Range newRange = new Range(oldRange.Start.Row, oldRange.Start.Column + moveCount, oldRange.End.Row, oldRange.End.Column + moveCount);
        this.SpannedRangesCollection.Update(oldRange, newRange);
      }
    }
  }

  public void RemoveSpannedCellReferencesInRows(int startIndex, int count)
  {
    foreach (Range range in this.SpannedRangesCollection.ToArray())
    {
      Position start = range.Start;
      int num;
      if (start.Row >= startIndex)
      {
        start = range.Start;
        num = start.Row < startIndex + count ? 1 : 0;
      }
      else
        num = 0;
      if (num != 0)
        this.SpannedRangesCollection.Remove(range);
    }
  }

  public void RemoveSpannedCellReferencesInColumns(int startIndex, int count)
  {
    foreach (Range range in this.SpannedRangesCollection.ToArray())
    {
      Position start = range.Start;
      int num;
      if (start.Column >= startIndex)
      {
        start = range.Start;
        num = start.Column < startIndex + count ? 1 : 0;
      }
      else
        num = 0;
      if (num != 0)
        this.SpannedRangesCollection.Remove(range);
    }
  }

  public void ExpandSpannedColumns(int startIndex, int count)
  {
    foreach (Range range in this.SpannedRangesCollection.ToArray())
    {
      Position position = range.Start;
      int num1;
      if (position.Column >= startIndex)
      {
        position = range.Start;
        num1 = position.Column <= startIndex + count - 1 ? 1 : 0;
      }
      else
        num1 = 0;
      bool flag1 = num1 != 0;
      position = range.End;
      int num2;
      if (position.Column >= startIndex)
      {
        position = range.End;
        num2 = position.Column <= startIndex + count - 1 ? 1 : 0;
      }
      else
        num2 = 0;
      bool flag2 = num2 != 0;
      if (flag1 | flag2)
        this.grid[range.Start].ColumnSpan += count;
    }
  }

  public void ExpandSpannedRows(int startIndex, int count)
  {
    foreach (Range range in this.SpannedRangesCollection.ToArray())
    {
      Position position = range.Start;
      int num1;
      if (position.Row >= startIndex)
      {
        position = range.Start;
        num1 = position.Row <= startIndex + count - 1 ? 1 : 0;
      }
      else
        num1 = 0;
      bool flag1 = num1 != 0;
      position = range.End;
      int num2;
      if (position.Row >= startIndex)
      {
        position = range.End;
        num2 = position.Row <= startIndex + count - 1 ? 1 : 0;
      }
      else
        num2 = 0;
      bool flag2 = num2 != 0;
      if (flag1 | flag2)
        this.grid[range.Start].RowSpan += count;
    }
  }

  public void ShrinkOrRemoveSpannedRows(int startIndex, int count)
  {
    Range p_Range = new Range(startIndex, 0, startIndex + count - 1, 1000);
    foreach (Range range in this.SpannedRangesCollection.ToArray())
    {
      if (!range.Intersect(p_Range).IsEmpty())
      {
        ICell cell = this.grid[range.Start];
        int num = cell.RowSpan - count;
        if ((num > 1 ? 0 : (cell.ColumnSpan <= 1 ? 1 : 0)) != 0)
        {
          cell.RowSpan = 1;
          this.SpannedRangesCollection.Remove(range);
        }
        else
          cell.RowSpan = num;
      }
    }
  }

  public void ShrinkOrRemoveSpannedColumns(int startIndex, int count)
  {
    Range p_Range = new Range(0, startIndex, 1000, startIndex + count - 1);
    foreach (Range range in this.SpannedRangesCollection.ToArray())
    {
      if (!range.Intersect(p_Range).IsEmpty())
      {
        ICell cell = this.grid[range.Start];
        int num = cell.ColumnSpan - count;
        if ((num > 1 ? 0 : (cell.ColumnSpan <= 1 ? 1 : 0)) != 0)
        {
          cell.ColumnSpan = 1;
          this.SpannedRangesCollection.Remove(range);
        }
        else
          cell.ColumnSpan = num;
      }
    }
  }
}
