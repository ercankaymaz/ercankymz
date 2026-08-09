using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SourceGrid.Cells;

namespace SourceGrid;

public class SpannedCellRangesController : ISpannedCellRangesController
{
	private Grid grid = null;

	[CompilerGenerated]
	private ISpannedRangesCollection ispannedRangesCollection_0;

	public ISpannedRangesCollection SpannedRangesCollection
	{
		[CompilerGenerated]
		get
		{
			return ispannedRangesCollection_0;
		}
		[CompilerGenerated]
		private set
		{
			ispannedRangesCollection_0 = value;
		}
	}

	public Grid Grid => grid;

	public void UpdateOrAdd(Range newRange)
	{
		if (!newRange.Equals(Range.Empty))
		{
			if (SpannedRangesCollection.FindRangeWithStart(newRange.Start).HasValue)
			{
				SpannedRangesCollection.Update(Range.FromPosition(newRange.Start), newRange);
			}
			else
			{
				SpannedRangesCollection.Add(newRange);
			}
			return;
		}
		throw new ArgumentException("Range can not be empty");
	}

	public void Update(Range newRange)
	{
		Range? range = SpannedRangesCollection.FindRangeWithStart(newRange.Start);
		if (!range.HasValue)
		{
			throw new ArgumentException($"Could not find a spanned cell range with the same starting point as {newRange.Start}");
		}
		SpannedRangesCollection.Update(range.Value, newRange);
	}

	public SpannedCellRangesController(Grid grid, ISpannedRangesCollection spannedRangeCollection)
		: this(grid)
	{
		SpannedRangesCollection = spannedRangeCollection;
	}

	public SpannedCellRangesController(Grid grid)
	{
		this.grid = grid;
		SpannedRangesCollection = new SpannedRangesList();
	}

	public void MoveLeftSpannedRanges(int startIndex, int moveCount)
	{
		Range[] array = SpannedRangesCollection.ToArray();
		for (int i = 0; i < array.Length; i++)
		{
			Range oldRange = array[i];
			if (oldRange.Start.Column > startIndex)
			{
				Range newRange = new Range(oldRange.Start.Row, oldRange.Start.Column - moveCount, oldRange.End.Row, oldRange.End.Column - moveCount);
				SpannedRangesCollection.Update(oldRange, newRange);
			}
		}
	}

	public void MoveUpSpannedRanges(int startIndex, int moveCount)
	{
		Range[] array = SpannedRangesCollection.ToArray();
		for (int i = 0; i < array.Length; i++)
		{
			Range oldRange = array[i];
			if (oldRange.Start.Row > startIndex)
			{
				Range newRange = new Range(oldRange.Start.Row - moveCount, oldRange.Start.Column, oldRange.End.Row - moveCount, oldRange.End.Column);
				SpannedRangesCollection.Update(oldRange, newRange);
			}
		}
	}

	public void Swap(int rowIndex1, int rowIndex2)
	{
		Range range = new Range(rowIndex1, 0, rowIndex1, int.MaxValue);
		Range range2 = new Range(rowIndex2, 0, rowIndex2, int.MaxValue);
		List<Range> ranges = SpannedRangesCollection.GetRanges(range);
		List<Range> ranges2 = SpannedRangesCollection.GetRanges(range2);
		foreach (Range item in ranges)
		{
			if (item.RowsCount <= 1)
			{
				Range newRange = new Range(rowIndex2, item.Start.Column, rowIndex2, item.End.Column);
				SpannedRangesCollection.Update(item, newRange);
				continue;
			}
			throw new SourceGridException("Can not swap rows if they contain spanned ranged which extend more than one row");
		}
		foreach (Range item2 in ranges2)
		{
			if (item2.RowsCount <= 1)
			{
				Range newRange2 = new Range(rowIndex1, item2.Start.Column, rowIndex1, item2.End.Column);
				SpannedRangesCollection.Update(item2, newRange2);
				continue;
			}
			throw new SourceGridException("Can not swap rows if they contain spanned ranged which extend more than one row");
		}
	}

	public void MoveDownSpannedRanges(int startIndex, int moveCount)
	{
		Range[] array = SpannedRangesCollection.ToArray();
		for (int i = 0; i < array.Length; i++)
		{
			Range oldRange = array[i];
			if (oldRange.Start.Row >= startIndex)
			{
				Range newRange = new Range(oldRange.Start.Row + moveCount, oldRange.Start.Column, oldRange.End.Row + moveCount, oldRange.End.Column);
				SpannedRangesCollection.Update(oldRange, newRange);
			}
		}
	}

	public void MoveRightSpannedRanges(int startIndex, int moveCount)
	{
		Range[] array = SpannedRangesCollection.ToArray();
		for (int i = 0; i < array.Length; i++)
		{
			Range oldRange = array[i];
			if (oldRange.Start.Column >= startIndex)
			{
				Range newRange = new Range(oldRange.Start.Row, oldRange.Start.Column + moveCount, oldRange.End.Row, oldRange.End.Column + moveCount);
				SpannedRangesCollection.Update(oldRange, newRange);
			}
		}
	}

	public void RemoveSpannedCellReferencesInRows(int startIndex, int count)
	{
		Range[] array = SpannedRangesCollection.ToArray();
		for (int i = 0; i < array.Length; i++)
		{
			Range range = array[i];
			if (range.Start.Row >= startIndex && range.Start.Row < startIndex + count)
			{
				SpannedRangesCollection.Remove(range);
			}
		}
	}

	public void RemoveSpannedCellReferencesInColumns(int startIndex, int count)
	{
		Range[] array = SpannedRangesCollection.ToArray();
		for (int i = 0; i < array.Length; i++)
		{
			Range range = array[i];
			if (range.Start.Column >= startIndex && range.Start.Column < startIndex + count)
			{
				SpannedRangesCollection.Remove(range);
			}
		}
	}

	public void ExpandSpannedColumns(int startIndex, int count)
	{
		Range[] array = SpannedRangesCollection.ToArray();
		for (int i = 0; i < array.Length; i++)
		{
			Range range = array[i];
			bool flag = range.Start.Column >= startIndex && range.Start.Column <= startIndex + count - 1;
			bool flag2 = range.End.Column >= startIndex && range.End.Column <= startIndex + count - 1;
			if (flag || flag2)
			{
				grid[range.Start].ColumnSpan += count;
			}
		}
	}

	public void ExpandSpannedRows(int startIndex, int count)
	{
		Range[] array = SpannedRangesCollection.ToArray();
		for (int i = 0; i < array.Length; i++)
		{
			Range range = array[i];
			bool flag = range.Start.Row >= startIndex && range.Start.Row <= startIndex + count - 1;
			bool flag2 = range.End.Row >= startIndex && range.End.Row <= startIndex + count - 1;
			if (flag || flag2)
			{
				grid[range.Start].RowSpan += count;
			}
		}
	}

	public void ShrinkOrRemoveSpannedRows(int startIndex, int count)
	{
		Range p_Range = new Range(startIndex, 0, startIndex + count - 1, 1000);
		Range[] array = SpannedRangesCollection.ToArray();
		for (int i = 0; i < array.Length; i++)
		{
			Range range = array[i];
			if (!range.Intersect(p_Range).IsEmpty())
			{
				ICell cell = grid[range.Start];
				int num = cell.RowSpan - count;
				if (num > 1 || cell.ColumnSpan > 1)
				{
					cell.RowSpan = num;
					continue;
				}
				cell.RowSpan = 1;
				SpannedRangesCollection.Remove(range);
			}
		}
	}

	public void ShrinkOrRemoveSpannedColumns(int startIndex, int count)
	{
		Range p_Range = new Range(0, startIndex, 1000, startIndex + count - 1);
		Range[] array = SpannedRangesCollection.ToArray();
		for (int i = 0; i < array.Length; i++)
		{
			Range range = array[i];
			if (!range.Intersect(p_Range).IsEmpty())
			{
				ICell cell = grid[range.Start];
				int num = cell.ColumnSpan - count;
				if (num > 1 || cell.ColumnSpan > 1)
				{
					cell.ColumnSpan = num;
					continue;
				}
				cell.ColumnSpan = 1;
				SpannedRangesCollection.Remove(range);
			}
		}
	}
}
