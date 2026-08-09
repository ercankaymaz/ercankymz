using System;
using System.Collections.Generic;
using System.Drawing;
using SourceGrid.Cells;

namespace SourceGrid;

public abstract class ColumnsBase
{
	private GridVirtual grid;

	private int int_0 = 0;

	public GridVirtual Grid => grid;

	public abstract int Count { get; }

	public int? FirstVisibleScrollableColumn
	{
		get
		{
			int num = Grid.CustomScrollPosition.X + Grid.FixedColumns;
			if (num < Count)
			{
				return num;
			}
			return null;
		}
	}

	public int? LastVisibleScrollableColumn
	{
		get
		{
			int? firstVisibleScrollableColumn = FirstVisibleScrollableColumn;
			if (firstVisibleScrollableColumn.HasValue)
			{
				Rectangle scrollableArea = Grid.GetScrollableArea();
				int num = GetLeft(firstVisibleScrollableColumn.Value);
				int i;
				for (i = firstVisibleScrollableColumn.Value; i < Count; i++)
				{
					num += GetWidth(i);
					if (num >= scrollableArea.Right)
					{
						return i;
					}
				}
				return i - 1;
			}
			return null;
		}
	}

	public ColumnsBase(GridVirtual grid)
	{
		this.grid = grid;
	}

	public abstract int GetWidth(int column);

	public abstract void SetWidth(int column, int width);

	public abstract AutoSizeMode GetAutoSizeMode(int column);

	public void AutoSizeColumn(int column)
	{
		AutoSizeColumn(column, useRowHeight: true);
	}

	public void AutoSizeColumn(int column, bool useRowHeight)
	{
		int startRow = 0;
		int endRow = Grid.Rows.Count - 1;
		if ((GetAutoSizeMode(column) & AutoSizeMode.EnableAutoSizeView) == AutoSizeMode.EnableAutoSizeView)
		{
			if (!Grid.GetVisibleColumns(returnsPartial: true).Contains(column))
			{
				return;
			}
			List<int> visibleRows = Grid.GetVisibleRows(returnsPartial: true);
			visibleRows.Sort();
			if (visibleRows.Count == 0)
			{
				return;
			}
			startRow = visibleRows[0];
			endRow = visibleRows[visibleRows.Count - 1];
		}
		AutoSizeColumn(column, useRowHeight, startRow, endRow);
	}

	public void AutoSizeColumn(int column, bool useRowHeight, int StartRow, int EndRow)
	{
		if ((GetAutoSizeMode(column) & AutoSizeMode.EnableAutoSize) == AutoSizeMode.EnableAutoSize && IsColumnVisible(column))
		{
			SetWidth(column, MeasureColumnWidth(column, useRowHeight, StartRow, EndRow));
		}
	}

	public int MeasureColumnWidth(int column, bool useRowHeight, int StartRow, int EndRow)
	{
		int num = Grid.MinimumWidth;
		if ((GetAutoSizeMode(column) & AutoSizeMode.MinimumSize) != AutoSizeMode.MinimumSize)
		{
			for (int i = StartRow; i <= EndRow; i++)
			{
				ICellVirtual cell = Grid.GetCell(i, column);
				if (cell != null)
				{
					Position pPosition = new Position(i, column);
					Size empty = Size.Empty;
					if (useRowHeight)
					{
						empty.Height = Grid.RangeToSize(Grid.PositionToCellRange(pPosition)).Height;
					}
					Size size = new CellContext(Grid, pPosition, cell).Measure(empty);
					if (size.Width > num)
					{
						num = size.Width;
					}
				}
			}
			return num;
		}
		return num;
	}

	public void AutoSize(bool useRowHeight)
	{
		SuspendLayout();
		for (int i = 0; i < Count; i++)
		{
			AutoSizeColumn(i, useRowHeight);
		}
		ResumeLayout();
	}

	public void AutoSize(bool useRowHeight, int StartRow, int EndRow)
	{
		SuspendLayout();
		for (int i = 0; i < Count; i++)
		{
			AutoSizeColumn(i, useRowHeight, StartRow, EndRow);
		}
		ResumeLayout();
	}

	public virtual void StretchToFit()
	{
		SuspendLayout();
		Rectangle displayRectangle = Grid.DisplayRectangle;
		if (Count > 0 && displayRectangle.Width > 0)
		{
			List<int> list = ColumnsInsideRegion(displayRectangle.X, displayRectangle.Width);
			if (list.Count >= Count)
			{
				int? num = GetRight(Count - 1);
				if (num.HasValue && displayRectangle.Width > num.Value)
				{
					int num2 = 0;
					for (int i = 0; i < Count; i++)
					{
						if ((GetAutoSizeMode(i) & AutoSizeMode.EnableStretch) == AutoSizeMode.EnableStretch && IsColumnVisible(i))
						{
							num2++;
						}
					}
					if (num2 > 0)
					{
						int num3 = (displayRectangle.Width - num.Value) / num2;
						for (int j = 0; j < Count; j++)
						{
							if ((GetAutoSizeMode(j) & AutoSizeMode.EnableStretch) == AutoSizeMode.EnableStretch && IsColumnVisible(j))
							{
								SetWidth(j, GetWidth(j) + num3);
							}
						}
					}
				}
			}
		}
		ResumeLayout();
	}

	public List<int> ColumnsInsideRegion(int x, int width)
	{
		return ColumnsInsideRegion(x, width, returnsPartial: true, returnsFixedColumns: true);
	}

	public List<int> ColumnsInsideRegion(int x, int width, bool returnsPartial, bool returnsFixedColumns)
	{
		int num = x + width;
		List<int> list = new List<int>();
		for (int i = 0; i < Grid.FixedColumns && i < Count; i++)
		{
			int left = GetLeft(i);
			int num2 = left + GetWidth(i);
			if (num >= left && x <= num2 && (returnsPartial || (num2 <= num && left >= x)) && returnsFixedColumns)
			{
				list.Add(i);
			}
			if (num2 > num)
			{
				break;
			}
		}
		int? firstVisibleScrollableColumn = FirstVisibleScrollableColumn;
		if (firstVisibleScrollableColumn.HasValue)
		{
			for (int j = firstVisibleScrollableColumn.Value; j < Count; j++)
			{
				int left2 = GetLeft(j);
				int num3 = left2 + GetWidth(j);
				if (num >= left2 && x <= num3 && (returnsPartial || (num3 <= num && left2 >= x)))
				{
					list.Add(j);
				}
				if (num3 > num)
				{
					break;
				}
			}
		}
		return list;
	}

	public int? ColumnAtPoint(int x)
	{
		List<int> list = ColumnsInsideRegion(x, 1);
		if (list.Count != 0)
		{
			return list[0];
		}
		return null;
	}

	public Range GetRange(int column)
	{
		return new Range(0, column, Grid.Rows.Count - 1, column);
	}

	public void SuspendLayout()
	{
		int_0++;
	}

	public void ResumeLayout()
	{
		if (int_0 > 0)
		{
			int_0--;
		}
		PerformLayout();
	}

	public void PerformLayout()
	{
		if (int_0 == 0)
		{
			OnLayout();
		}
	}

	protected virtual void OnLayout()
	{
		Grid.OnCellsAreaChanged();
	}

	public void ColumnsChanged()
	{
		PerformLayout();
	}

	public int GetAbsoluteLeft(int column)
	{
		if (column >= 0)
		{
			int num = 0;
			for (int i = 0; i < column; i++)
			{
				num += GetWidth(i);
			}
			return num;
		}
		throw new ArgumentException("Must be a valid index");
	}

	public int GetAbsoluteRight(int column)
	{
		int absoluteLeft = GetAbsoluteLeft(column);
		return absoluteLeft + GetWidth(column);
	}

	public int GetLeft(int column)
	{
		int num = Math.Min(Grid.FixedColumns, Count);
		int num2 = 0;
		for (int i = 0; i < num; i++)
		{
			if (i != column)
			{
				num2 += GetWidth(i);
				continue;
			}
			return num2;
		}
		int? num3 = FirstVisibleScrollableColumn;
		if (!num3.HasValue)
		{
			num3 = Count;
		}
		if (num3 != column)
		{
			if (!(num3 < column))
			{
				if (num3 > column)
				{
					int num4 = num3.Value - 1;
					while (num4 >= 0)
					{
						num2 -= GetWidth(num4);
						if (num4 != column)
						{
							num4--;
							continue;
						}
						return num2;
					}
				}
			}
			else
			{
				for (int j = num3.Value; j < Count; j++)
				{
					if (j != column)
					{
						num2 += GetWidth(j);
						continue;
					}
					return num2;
				}
			}
			throw new IndexOutOfRangeException();
		}
		return num2;
	}

	public int GetRight(int column)
	{
		int left = GetLeft(column);
		return left + GetWidth(column);
	}

	public abstract void ShowColumn(int column);

	public abstract void HideColumn(int column);

	public abstract bool IsColumnVisible(int column);
}
