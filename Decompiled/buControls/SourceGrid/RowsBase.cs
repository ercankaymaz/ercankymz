using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using SourceGrid.Cells;
using ns27;

namespace SourceGrid;

public abstract class RowsBase : IRows
{
	private GridVirtual grid;

	protected IHiddenRowCoordinator m_HiddenRowsCoordinator = null;

	[CompilerGenerated]
	private RowVisibilityChangedHandler rowVisibilityChangedHandler_0;

	private int int_0 = 0;

	public IHiddenRowCoordinator HiddenRowsCoordinator => m_HiddenRowsCoordinator;

	public GridVirtual Grid => grid;

	public abstract int Count { get; }

	public int? FirstVisibleScrollableRow
	{
		get
		{
			int num = HiddenRowsCoordinator.ConvertScrollbarValueToRowIndex(Grid.CustomScrollPosition.Y) + Grid.FixedRows;
			if (num < Count)
			{
				return num;
			}
			return null;
		}
	}

	public int? LastVisibleScrollableRow
	{
		get
		{
			int? firstVisibleScrollableRow = FirstVisibleScrollableRow;
			if (firstVisibleScrollableRow.HasValue)
			{
				Rectangle scrollableArea = Grid.GetScrollableArea();
				int num = GetTop(firstVisibleScrollableRow.Value);
				int i;
				for (i = firstVisibleScrollableRow.Value; i < Count; i++)
				{
					num += GetHeight(i);
					if (num >= scrollableArea.Bottom)
					{
						return i;
					}
				}
				return i - 1;
			}
			return null;
		}
	}

	public event RowVisibilityChangedHandler RowVisibilityChanged
	{
		[CompilerGenerated]
		add
		{
			RowVisibilityChangedHandler rowVisibilityChangedHandler = rowVisibilityChangedHandler_0;
			RowVisibilityChangedHandler rowVisibilityChangedHandler2;
			do
			{
				rowVisibilityChangedHandler2 = rowVisibilityChangedHandler;
				RowVisibilityChangedHandler value2 = (RowVisibilityChangedHandler)Delegate.Combine(rowVisibilityChangedHandler2, value);
				rowVisibilityChangedHandler = Interlocked.CompareExchange(ref rowVisibilityChangedHandler_0, value2, rowVisibilityChangedHandler2);
			}
			while ((object)rowVisibilityChangedHandler != rowVisibilityChangedHandler2);
		}
		[CompilerGenerated]
		remove
		{
			RowVisibilityChangedHandler rowVisibilityChangedHandler = rowVisibilityChangedHandler_0;
			RowVisibilityChangedHandler rowVisibilityChangedHandler2;
			do
			{
				rowVisibilityChangedHandler2 = rowVisibilityChangedHandler;
				RowVisibilityChangedHandler value2 = (RowVisibilityChangedHandler)Delegate.Remove(rowVisibilityChangedHandler2, value);
				rowVisibilityChangedHandler = Interlocked.CompareExchange(ref rowVisibilityChangedHandler_0, value2, rowVisibilityChangedHandler2);
			}
			while ((object)rowVisibilityChangedHandler != rowVisibilityChangedHandler2);
		}
	}

	protected virtual void OnRowVisibilityChanged(int rowIndex, bool becameVisible)
	{
		if (rowVisibilityChangedHandler_0 != null)
		{
			rowVisibilityChangedHandler_0(rowIndex, becameVisible);
		}
	}

	public RowsBase(GridVirtual grid)
	{
		this.grid = grid;
		m_HiddenRowsCoordinator = new StandardHiddenRowCoordinator(this);
	}

	public abstract int GetHeight(int row);

	public abstract void SetHeight(int row, int height);

	public abstract AutoSizeMode GetAutoSizeMode(int row);

	public List<int> RowsInsideRegion(int y, int height)
	{
		return RowsInsideRegion(y, height, returnsPartial: true, returnsFixedRows: true);
	}

	public List<int> RowsInsideRegion(int y, int height, bool returnsPartial, bool returnsFixedRows)
	{
		int num = y + height;
		List<int> list = new List<int>();
		for (int i = 0; i < Grid.FixedRows && i < Count; i++)
		{
			int top = GetTop(i);
			int num2 = top + GetHeight(i);
			if (num >= top && y <= num2 && (returnsPartial || (num2 <= num && top >= y)) && returnsFixedRows)
			{
				list.Add(i);
			}
			if (num2 > num)
			{
				break;
			}
		}
		int? firstVisibleScrollableRow = FirstVisibleScrollableRow;
		if (firstVisibleScrollableRow.HasValue)
		{
			for (int j = firstVisibleScrollableRow.Value; j < Count; j++)
			{
				int top2 = GetTop(j);
				int num3 = top2 + GetHeight(j);
				if (num >= top2 && y <= num3 && (returnsPartial || (num3 <= num && top2 >= y)))
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

	public int? RowAtPoint(int y)
	{
		List<int> list = RowsInsideRegion(y, 1);
		if (list.Count != 0)
		{
			return list[0];
		}
		return null;
	}

	public void AutoSizeRow(int row)
	{
		int startCol = 0;
		int endCol = Grid.Columns.Count - 1;
		if ((GetAutoSizeMode(row) & AutoSizeMode.EnableAutoSizeView) == AutoSizeMode.EnableAutoSizeView)
		{
			if (!Grid.GetVisibleRows(returnsPartial: true).Contains(row))
			{
				return;
			}
			List<int> visibleColumns = Grid.GetVisibleColumns(returnsPartial: true);
			visibleColumns.Sort();
			if (visibleColumns.Count == 0)
			{
				return;
			}
			startCol = visibleColumns[0];
			endCol = visibleColumns[visibleColumns.Count - 1];
		}
		AutoSizeRow(row, useColumnWidth: true, startCol, endCol);
	}

	public void AutoSizeRow(int row, bool useColumnWidth, int StartCol, int EndCol)
	{
		if ((GetAutoSizeMode(row) & AutoSizeMode.EnableAutoSize) == AutoSizeMode.EnableAutoSize && IsRowVisible(row))
		{
			SetHeight(row, MeasureRowHeight(row, useColumnWidth, StartCol, EndCol));
		}
	}

	public int MeasureRowHeight(int row, bool useColumnWidth, int StartCol, int EndCol)
	{
		int num = Grid.MinimumHeight;
		if ((GetAutoSizeMode(row) & AutoSizeMode.MinimumSize) != AutoSizeMode.MinimumSize)
		{
			for (int i = StartCol; i <= EndCol; i++)
			{
				ICellVirtual cell = Grid.GetCell(row, i);
				if (cell != null)
				{
					Position pPosition = new Position(row, i);
					Size empty = Size.Empty;
					if (useColumnWidth)
					{
						empty.Width = Grid.RangeToSize(Grid.PositionToCellRange(pPosition)).Width;
					}
					Size size = new CellContext(Grid, pPosition, cell).Measure(empty);
					if (size.Height > num)
					{
						num = size.Height;
					}
				}
			}
			return num;
		}
		return num;
	}

	public void AutoSize(bool useColumnWidth)
	{
		AutoSize(useColumnWidth, 0, Grid.Columns.Count - 1);
	}

	public void AutoSize(bool useColumnWidth, int StartCol, int EndCol)
	{
		SuspendLayout();
		for (int i = 0; i < Count; i++)
		{
			AutoSizeRow(i, useColumnWidth, StartCol, EndCol);
		}
		ResumeLayout();
	}

	public virtual void StretchToFit()
	{
		SuspendLayout();
		Rectangle displayRectangle = Grid.DisplayRectangle;
		if (Count > 0 && displayRectangle.Height > 0)
		{
			List<int> list = RowsInsideRegion(displayRectangle.Y, displayRectangle.Height);
			if (list.Count >= Count)
			{
				int? num = GetBottom(Count - 1);
				if (num.HasValue && displayRectangle.Height > num.Value)
				{
					int num2 = 0;
					for (int i = 0; i < Count; i++)
					{
						if ((GetAutoSizeMode(i) & AutoSizeMode.EnableStretch) == AutoSizeMode.EnableStretch && IsRowVisible(i))
						{
							num2++;
						}
					}
					if (num2 > 0)
					{
						int num3 = (displayRectangle.Height - num.Value) / num2;
						for (int j = 0; j < Count; j++)
						{
							if ((GetAutoSizeMode(j) & AutoSizeMode.EnableStretch) == AutoSizeMode.EnableStretch && IsRowVisible(j))
							{
								SetHeight(j, GetHeight(j) + num3);
							}
						}
					}
				}
			}
		}
		ResumeLayout();
	}

	public Range GetRange(int row)
	{
		return new Range(row, 0, row, Grid.Columns.Count - 1);
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

	public void RowsChanged()
	{
		PerformLayout();
	}

	public int GetAbsoluteTop(int row)
	{
		if (row >= 0)
		{
			int num = 0;
			for (int i = 0; i < row; i++)
			{
				num += GetHeight(i);
			}
			return num;
		}
		throw new ArgumentException("Must be a valid index");
	}

	public int GetAbsoluteBottom(int row)
	{
		int absoluteTop = GetAbsoluteTop(row);
		return absoluteTop + GetHeight(row);
	}

	public int GetTop(int row)
	{
		if (row >= 0)
		{
			int num = Math.Min(Grid.FixedRows, Count);
			int num2 = 0;
			for (int i = 0; i < num; i++)
			{
				if (i != row)
				{
					num2 += GetHeight(i);
					continue;
				}
				return num2;
			}
			int? num3 = FirstVisibleScrollableRow;
			if (!num3.HasValue)
			{
				num3 = Count;
			}
			if (num3 != row)
			{
				if (!(num3 < row))
				{
					if (!(num3 > row))
					{
						throw new IndexOutOfRangeException($"row value is {row}");
					}
					return num2 + Class76.smethod_683(num3.Value, row, this);
				}
				return num2 + Class76.smethod_509(num3.Value, row, this);
			}
			return num2;
		}
		throw new ArgumentNullException("Row is less than 0");
	}

	public int GetBottom(int row)
	{
		int top = GetTop(row);
		return top + GetHeight(row);
	}

	public void ShowRow(int row)
	{
		ShowRow(row, isVisible: true);
	}

	public void ShowRow(int row, bool isVisible)
	{
		if (!isVisible || IsRowVisible(row))
		{
			if (!isVisible && IsRowVisible(row))
			{
				SetHeight(row, 0);
				OnRowVisibilityChanged(row, isVisible);
			}
		}
		else
		{
			SetHeight(row, Grid.DefaultHeight);
			OnRowVisibilityChanged(row, isVisible);
		}
	}

	public void HideRow(int row)
	{
		ShowRow(row, isVisible: false);
	}

	public bool IsRowVisible(int row)
	{
		return GetHeight(row) > 0;
	}
}
