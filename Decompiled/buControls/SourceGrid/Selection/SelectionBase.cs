using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using DevAge.Drawing;
using SourceGrid.Cells;
using ns27;

namespace SourceGrid.Selection;

public abstract class SelectionBase : IGridSelection
{
	private GridVirtual gridVirtual_0;

	internal Position position_0 = Position.Empty;

	private Color color_0 = Color.Transparent;

	private FocusStyle focusStyle_0 = FocusStyle.Default;

	[CompilerGenerated]
	private ChangeActivePositionEventHandler changeActivePositionEventHandler_0;

	[CompilerGenerated]
	private ChangeActivePositionEventHandler changeActivePositionEventHandler_1;

	[CompilerGenerated]
	private RowCancelEventHandler rowCancelEventHandler_0;

	[CompilerGenerated]
	private RowEventHandler rowEventHandler_0;

	[CompilerGenerated]
	private ColumnCancelEventHandler columnCancelEventHandler_0;

	[CompilerGenerated]
	private ColumnEventHandler columnEventHandler_0;

	private bool bool_0 = true;

	private Color color_1 = Color.FromArgb(75, Color.FromKnownColor(KnownColor.Highlight));

	private RectangleBorder rectangleBorder_0 = new RectangleBorder(new BorderLine(Color.Black, 2f));

	[CompilerGenerated]
	private RangeRegionChangedEventHandler rangeRegionChangedEventHandler_0;

	public GridVirtual Grid => gridVirtual_0;

	public Position ActivePosition
	{
		get
		{
			return position_0;
		}
		protected set
		{
			position_0 = value;
		}
	}

	public Color FocusBackColor
	{
		get
		{
			return color_0;
		}
		set
		{
			color_0 = value;
			Invalidate();
		}
	}

	public FocusStyle FocusStyle
	{
		get
		{
			return focusStyle_0;
		}
		set
		{
			focusStyle_0 = value;
		}
	}

	public bool EnableMultiSelection
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public Color BackColor
	{
		get
		{
			return color_1;
		}
		set
		{
			color_1 = value;
			Invalidate();
		}
	}

	public RectangleBorder Border
	{
		get
		{
			return rectangleBorder_0;
		}
		set
		{
			rectangleBorder_0 = value;
			Invalidate();
		}
	}

	public event ChangeActivePositionEventHandler CellGotFocus
	{
		[CompilerGenerated]
		add
		{
			ChangeActivePositionEventHandler changeActivePositionEventHandler = changeActivePositionEventHandler_0;
			ChangeActivePositionEventHandler changeActivePositionEventHandler2;
			do
			{
				changeActivePositionEventHandler2 = changeActivePositionEventHandler;
				ChangeActivePositionEventHandler value2 = (ChangeActivePositionEventHandler)Delegate.Combine(changeActivePositionEventHandler2, value);
				changeActivePositionEventHandler = Interlocked.CompareExchange(ref changeActivePositionEventHandler_0, value2, changeActivePositionEventHandler2);
			}
			while ((object)changeActivePositionEventHandler != changeActivePositionEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ChangeActivePositionEventHandler changeActivePositionEventHandler = changeActivePositionEventHandler_0;
			ChangeActivePositionEventHandler changeActivePositionEventHandler2;
			do
			{
				changeActivePositionEventHandler2 = changeActivePositionEventHandler;
				ChangeActivePositionEventHandler value2 = (ChangeActivePositionEventHandler)Delegate.Remove(changeActivePositionEventHandler2, value);
				changeActivePositionEventHandler = Interlocked.CompareExchange(ref changeActivePositionEventHandler_0, value2, changeActivePositionEventHandler2);
			}
			while ((object)changeActivePositionEventHandler != changeActivePositionEventHandler2);
		}
	}

	public event ChangeActivePositionEventHandler CellLostFocus
	{
		[CompilerGenerated]
		add
		{
			ChangeActivePositionEventHandler changeActivePositionEventHandler = changeActivePositionEventHandler_1;
			ChangeActivePositionEventHandler changeActivePositionEventHandler2;
			do
			{
				changeActivePositionEventHandler2 = changeActivePositionEventHandler;
				ChangeActivePositionEventHandler value2 = (ChangeActivePositionEventHandler)Delegate.Combine(changeActivePositionEventHandler2, value);
				changeActivePositionEventHandler = Interlocked.CompareExchange(ref changeActivePositionEventHandler_1, value2, changeActivePositionEventHandler2);
			}
			while ((object)changeActivePositionEventHandler != changeActivePositionEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ChangeActivePositionEventHandler changeActivePositionEventHandler = changeActivePositionEventHandler_1;
			ChangeActivePositionEventHandler changeActivePositionEventHandler2;
			do
			{
				changeActivePositionEventHandler2 = changeActivePositionEventHandler;
				ChangeActivePositionEventHandler value2 = (ChangeActivePositionEventHandler)Delegate.Remove(changeActivePositionEventHandler2, value);
				changeActivePositionEventHandler = Interlocked.CompareExchange(ref changeActivePositionEventHandler_1, value2, changeActivePositionEventHandler2);
			}
			while ((object)changeActivePositionEventHandler != changeActivePositionEventHandler2);
		}
	}

	public event RowCancelEventHandler FocusRowLeaving
	{
		[CompilerGenerated]
		add
		{
			RowCancelEventHandler rowCancelEventHandler = rowCancelEventHandler_0;
			RowCancelEventHandler rowCancelEventHandler2;
			do
			{
				rowCancelEventHandler2 = rowCancelEventHandler;
				RowCancelEventHandler value2 = (RowCancelEventHandler)Delegate.Combine(rowCancelEventHandler2, value);
				rowCancelEventHandler = Interlocked.CompareExchange(ref rowCancelEventHandler_0, value2, rowCancelEventHandler2);
			}
			while ((object)rowCancelEventHandler != rowCancelEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			RowCancelEventHandler rowCancelEventHandler = rowCancelEventHandler_0;
			RowCancelEventHandler rowCancelEventHandler2;
			do
			{
				rowCancelEventHandler2 = rowCancelEventHandler;
				RowCancelEventHandler value2 = (RowCancelEventHandler)Delegate.Remove(rowCancelEventHandler2, value);
				rowCancelEventHandler = Interlocked.CompareExchange(ref rowCancelEventHandler_0, value2, rowCancelEventHandler2);
			}
			while ((object)rowCancelEventHandler != rowCancelEventHandler2);
		}
	}

	public event RowEventHandler FocusRowEntered
	{
		[CompilerGenerated]
		add
		{
			RowEventHandler rowEventHandler = rowEventHandler_0;
			RowEventHandler rowEventHandler2;
			do
			{
				rowEventHandler2 = rowEventHandler;
				RowEventHandler value2 = (RowEventHandler)Delegate.Combine(rowEventHandler2, value);
				rowEventHandler = Interlocked.CompareExchange(ref rowEventHandler_0, value2, rowEventHandler2);
			}
			while ((object)rowEventHandler != rowEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			RowEventHandler rowEventHandler = rowEventHandler_0;
			RowEventHandler rowEventHandler2;
			do
			{
				rowEventHandler2 = rowEventHandler;
				RowEventHandler value2 = (RowEventHandler)Delegate.Remove(rowEventHandler2, value);
				rowEventHandler = Interlocked.CompareExchange(ref rowEventHandler_0, value2, rowEventHandler2);
			}
			while ((object)rowEventHandler != rowEventHandler2);
		}
	}

	public event ColumnCancelEventHandler FocusColumnLeaving
	{
		[CompilerGenerated]
		add
		{
			ColumnCancelEventHandler columnCancelEventHandler = columnCancelEventHandler_0;
			ColumnCancelEventHandler columnCancelEventHandler2;
			do
			{
				columnCancelEventHandler2 = columnCancelEventHandler;
				ColumnCancelEventHandler value2 = (ColumnCancelEventHandler)Delegate.Combine(columnCancelEventHandler2, value);
				columnCancelEventHandler = Interlocked.CompareExchange(ref columnCancelEventHandler_0, value2, columnCancelEventHandler2);
			}
			while ((object)columnCancelEventHandler != columnCancelEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ColumnCancelEventHandler columnCancelEventHandler = columnCancelEventHandler_0;
			ColumnCancelEventHandler columnCancelEventHandler2;
			do
			{
				columnCancelEventHandler2 = columnCancelEventHandler;
				ColumnCancelEventHandler value2 = (ColumnCancelEventHandler)Delegate.Remove(columnCancelEventHandler2, value);
				columnCancelEventHandler = Interlocked.CompareExchange(ref columnCancelEventHandler_0, value2, columnCancelEventHandler2);
			}
			while ((object)columnCancelEventHandler != columnCancelEventHandler2);
		}
	}

	public event ColumnEventHandler FocusColumnEntered
	{
		[CompilerGenerated]
		add
		{
			ColumnEventHandler columnEventHandler = columnEventHandler_0;
			ColumnEventHandler columnEventHandler2;
			do
			{
				columnEventHandler2 = columnEventHandler;
				ColumnEventHandler value2 = (ColumnEventHandler)Delegate.Combine(columnEventHandler2, value);
				columnEventHandler = Interlocked.CompareExchange(ref columnEventHandler_0, value2, columnEventHandler2);
			}
			while ((object)columnEventHandler != columnEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ColumnEventHandler columnEventHandler = columnEventHandler_0;
			ColumnEventHandler columnEventHandler2;
			do
			{
				columnEventHandler2 = columnEventHandler;
				ColumnEventHandler value2 = (ColumnEventHandler)Delegate.Remove(columnEventHandler2, value);
				columnEventHandler = Interlocked.CompareExchange(ref columnEventHandler_0, value2, columnEventHandler2);
			}
			while ((object)columnEventHandler != columnEventHandler2);
		}
	}

	public event RangeRegionChangedEventHandler SelectionChanged
	{
		[CompilerGenerated]
		add
		{
			RangeRegionChangedEventHandler rangeRegionChangedEventHandler = rangeRegionChangedEventHandler_0;
			RangeRegionChangedEventHandler rangeRegionChangedEventHandler2;
			do
			{
				rangeRegionChangedEventHandler2 = rangeRegionChangedEventHandler;
				RangeRegionChangedEventHandler value2 = (RangeRegionChangedEventHandler)Delegate.Combine(rangeRegionChangedEventHandler2, value);
				rangeRegionChangedEventHandler = Interlocked.CompareExchange(ref rangeRegionChangedEventHandler_0, value2, rangeRegionChangedEventHandler2);
			}
			while ((object)rangeRegionChangedEventHandler != rangeRegionChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			RangeRegionChangedEventHandler rangeRegionChangedEventHandler = rangeRegionChangedEventHandler_0;
			RangeRegionChangedEventHandler rangeRegionChangedEventHandler2;
			do
			{
				rangeRegionChangedEventHandler2 = rangeRegionChangedEventHandler;
				RangeRegionChangedEventHandler value2 = (RangeRegionChangedEventHandler)Delegate.Remove(rangeRegionChangedEventHandler2, value);
				rangeRegionChangedEventHandler = Interlocked.CompareExchange(ref rangeRegionChangedEventHandler_0, value2, rangeRegionChangedEventHandler2);
			}
			while ((object)rangeRegionChangedEventHandler != rangeRegionChangedEventHandler2);
		}
	}

	public SelectionBase()
	{
	}

	public virtual void BindToGrid(GridVirtual p_grid)
	{
		gridVirtual_0 = p_grid;
	}

	public virtual void UnBindToGrid()
	{
		gridVirtual_0 = null;
	}

	private bool method_0()
	{
		return !ActivePosition.IsEmpty() && Grid != null && Grid.CompleteRange.Contains(ActivePosition);
	}

	public bool Focus(Position pCellToActivate, bool pResetSelection)
	{
		bool flag = false;
		if (!pCellToActivate.IsEmpty() && pResetSelection)
		{
			flag = true;
		}
		if (!(pCellToActivate != ActivePosition))
		{
			if (pCellToActivate.IsEmpty())
			{
				return true;
			}
			Class76.smethod_255(this);
			if (!Grid.ContainsFocus)
			{
				return Grid.Focus();
			}
			return true;
		}
		ICellVirtual cell = Grid.GetCell(pCellToActivate);
		CellContext sender = new CellContext(Grid, pCellToActivate, cell);
		ChangeActivePositionEventArgs e = new ChangeActivePositionEventArgs(ActivePosition, pCellToActivate);
		if (cell != null)
		{
			Grid.Controller.OnFocusEntering(sender, e);
			if (e.Cancel)
			{
				return false;
			}
			if (!Grid.Controller.CanReceiveFocus(sender, e))
			{
				return false;
			}
		}
		if (cell == null || Grid.Focus(selectFirstCell: false))
		{
			RangeRegion removedRange = null;
			if (!method_0())
			{
				position_0 = Position.Empty;
			}
			else
			{
				removedRange = new RangeRegion(ActivePosition);
				ICellVirtual cell2 = Grid.GetCell(ActivePosition);
				CellContext sender2 = new CellContext(Grid, ActivePosition, cell2);
				ChangeActivePositionEventArgs e2 = new ChangeActivePositionEventArgs(ActivePosition, pCellToActivate);
				Grid.Controller.OnFocusLeaving(sender2, e2);
				if (e2.Cancel)
				{
					return false;
				}
				OnCellLostFocus(e2);
				if (e2.Cancel)
				{
					return false;
				}
			}
			if (flag)
			{
				ResetSelection(mantainFocus: false);
			}
			bool result;
			if (cell == null)
			{
				result = true;
			}
			else
			{
				OnCellGotFocus(e);
				result = !e.Cancel;
			}
			RangeRegion addedRange = new RangeRegion(pCellToActivate);
			OnSelectionChanged(new RangeRegionChangedEventArgs(addedRange, removedRange));
			return result;
		}
		return false;
	}

	public virtual bool FocusFirstCell(bool pResetSelection)
	{
		PositionCollection cellsPositions = GetSelectionRegion().GetCellsPositions();
		Position pCellToActivate = method_1(cellsPositions);
		if (pCellToActivate.IsEmpty())
		{
			pCellToActivate = method_2();
		}
		if (pCellToActivate.IsEmpty())
		{
			return false;
		}
		return Focus(pCellToActivate, pResetSelection);
	}

	public bool FocusColumn(int column)
	{
		if (Grid.Columns.Count <= column)
		{
			return Focus(Position.Empty, pResetSelection: true);
		}
		for (int i = 0; i < Grid.Rows.Count; i++)
		{
			Position position = new Position(i, column);
			if (Grid.Controller.CanReceiveFocus(new CellContext(Grid, position), EventArgs.Empty))
			{
				return Focus(position, pResetSelection: true);
			}
		}
		return Focus(Position.Empty, pResetSelection: true);
	}

	public bool FocusRow(int row)
	{
		if (Grid.Rows.Count <= row)
		{
			return Focus(Position.Empty, pResetSelection: true);
		}
		for (int i = 0; i < Grid.Columns.Count; i++)
		{
			Position position = new Position(row, i);
			if (Grid.Controller.CanReceiveFocus(new CellContext(Grid, position), EventArgs.Empty))
			{
				return Focus(position, pResetSelection: true);
			}
		}
		return Focus(Position.Empty, pResetSelection: true);
	}

	private Position method_1(PositionCollection positionCollection_0)
	{
		foreach (Position item in positionCollection_0)
		{
			if (CanReceiveFocus(item))
			{
				return item;
			}
		}
		return Position.Empty;
	}

	private Position method_2()
	{
		for (int i = Grid.FixedRows; i < Grid.Rows.Count; i++)
		{
			for (int j = Grid.FixedColumns; j < Grid.Columns.Count; j++)
			{
				Position position = new Position(i, j);
				if (CanReceiveFocus(position))
				{
					return position;
				}
			}
		}
		return Position.Empty;
	}

	public bool CanReceiveFocus(Position position)
	{
		if (!Grid.CompleteRange.Contains(position))
		{
			return false;
		}
		ICellVirtual cell = Grid.GetCell(position);
		if (cell == null)
		{
			return false;
		}
		CellContext sender = new CellContext(Grid, position, cell);
		if (!Grid.Controller.CanReceiveFocus(sender, EventArgs.Empty))
		{
			return false;
		}
		return true;
	}

	protected virtual void OnFocusRowLeaving(RowCancelEventArgs e)
	{
		if (rowCancelEventHandler_0 != null)
		{
			rowCancelEventHandler_0(this, e);
		}
	}

	protected virtual void OnFocusRowEntered(RowEventArgs e)
	{
		if (rowEventHandler_0 != null)
		{
			rowEventHandler_0(this, e);
		}
	}

	protected virtual void OnFocusColumnLeaving(ColumnCancelEventArgs e)
	{
		if (columnCancelEventHandler_0 != null)
		{
			columnCancelEventHandler_0(this, e);
		}
	}

	protected virtual void OnFocusColumnEntered(ColumnEventArgs e)
	{
		if (columnEventHandler_0 != null)
		{
			columnEventHandler_0(this, e);
		}
	}

	protected virtual void OnCellGotFocus(ChangeActivePositionEventArgs e)
	{
		if (!Grid.CompleteRange.Contains(e.NewFocusPosition))
		{
			e.Cancel = true;
		}
		if (e.Cancel)
		{
			return;
		}
		if (changeActivePositionEventHandler_0 != null)
		{
			changeActivePositionEventHandler_0(this, e);
		}
		if (!e.Cancel)
		{
			position_0 = e.NewFocusPosition;
			SelectCell(position_0, select: true);
			Invalidate();
			Grid.Controller.OnFocusEntered(new CellContext(Grid, e.NewFocusPosition), EventArgs.Empty);
			if (e.NewFocusPosition.Row != e.OldFocusPosition.Row)
			{
				OnFocusRowEntered(new RowEventArgs(ActivePosition.Row));
			}
			if (e.NewFocusPosition.Column != e.OldFocusPosition.Column)
			{
				OnFocusColumnEntered(new ColumnEventArgs(ActivePosition.Column));
			}
		}
	}

	protected virtual void OnCellLostFocus(ChangeActivePositionEventArgs e)
	{
		if (e.Cancel)
		{
			return;
		}
		if (changeActivePositionEventHandler_1 != null)
		{
			changeActivePositionEventHandler_1(this, e);
		}
		if (e.Cancel)
		{
			return;
		}
		int row = ActivePosition.Row;
		if (!ActivePosition.IsEmpty() && row != e.NewFocusPosition.Row)
		{
			RowCancelEventArgs e2 = new RowCancelEventArgs(row, e.NewFocusPosition.Row);
			OnFocusRowLeaving(e2);
			if (e2.Cancel)
			{
				e.Cancel = true;
				return;
			}
		}
		int column = ActivePosition.Column;
		if (!ActivePosition.IsEmpty() && column != e.NewFocusPosition.Column)
		{
			ColumnCancelEventArgs e3 = new ColumnCancelEventArgs(column, e.NewFocusPosition.Column);
			OnFocusColumnLeaving(e3);
			if (e3.Cancel)
			{
				e.Cancel = true;
				return;
			}
		}
		position_0 = Position.Empty;
		Grid.Controller.OnFocusLeft(new CellContext(Grid, e.OldFocusPosition), EventArgs.Empty);
	}

	public bool MoveActiveCell(int rowShift, int colShift)
	{
		return MoveActiveCell(ActivePosition, rowShift, colShift);
	}

	public bool MoveActiveCell(int rowShift, int colShift, bool resetSelection)
	{
		return MoveActiveCell(ActivePosition, rowShift, colShift, resetSelection);
	}

	public bool MoveActiveCell(Position start, int rowShift, int colShift)
	{
		return MoveActiveCell(start, rowShift, colShift, resetSelection: true);
	}

	public bool MoveActiveCell(Position start, int rowShift, int colShift, bool resetSelection)
	{
		Position position = Position.Empty;
		if (start.IsEmpty())
		{
			position = new Position(0, 0);
			if (CanReceiveFocus(position))
			{
				return Focus(position, pResetSelection: true);
			}
			start = position;
			position = Position.Empty;
		}
		int row = start.Row;
		int column = start.Column;
		row += rowShift;
		column += colShift;
		while (position.IsEmpty() && row < Grid.Rows.Count && column < Grid.Columns.Count && row >= 0 && column >= 0)
		{
			position = new Position(row, column);
			if (!(Grid.PositionToStartPosition(position) == start))
			{
				if (!CanReceiveFocus(position))
				{
					position = Position.Empty;
				}
			}
			else
			{
				position = Position.Empty;
			}
			row += rowShift;
			column += colShift;
		}
		if (position.IsEmpty())
		{
			return false;
		}
		return Focus(position, resetSelection);
	}

	public bool MoveActiveCell(int rowShift1, int colShift1, int rowShift2, int colShift2)
	{
		return MoveActiveCell(ActivePosition, rowShift1, colShift1, rowShift2, colShift2);
	}

	public bool MoveActiveCell(Position start, int rowShift1, int colShift1, int rowShift2, int colShift2)
	{
		if (!MoveActiveCell(start, rowShift1, colShift1))
		{
			Position empty = Position.Empty;
			if (start.IsEmpty())
			{
				empty = new Position(0, 0);
				if (CanReceiveFocus(empty))
				{
					return Focus(empty, pResetSelection: true);
				}
				start = empty;
			}
			int row = ((rowShift2 != int.MinValue) ? ((rowShift2 == int.MaxValue) ? (Grid.Rows.Count - 1) : (start.Row + rowShift2)) : 0);
			int col = ((colShift2 != int.MinValue) ? ((colShift2 == int.MaxValue) ? (Grid.Columns.Count - 1) : (start.Column + colShift2)) : 0);
			empty = new Position(row, col);
			if (!(empty == start) && Grid.CompleteRange.Contains(empty))
			{
				if (!CanReceiveFocus(empty))
				{
					start = empty;
					return MoveActiveCell(start, rowShift1, colShift1, rowShift2, colShift2);
				}
				return Focus(empty, pResetSelection: true);
			}
			return false;
		}
		return true;
	}

	public virtual void Invalidate()
	{
		foreach (Range item in GetSelectionRegion())
		{
			Grid.InvalidateRange(item);
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
		if (!mantainFocus && !ActivePosition.IsEmpty())
		{
			Focus(Position.Empty, pResetSelection: false);
		}
		OnResetSelection();
		if (mantainFocus && !ActivePosition.IsEmpty())
		{
			SelectCell(ActivePosition, select: true);
		}
	}

	public abstract bool IsEmpty();

	public abstract RangeRegion GetSelectionRegion();

	public abstract bool IntersectsWith(Range rng);

	protected Range ValidateRange(Range rng)
	{
		return Grid.CompleteRange.Intersect(rng);
	}

	protected virtual void OnSelectionChanged(RangeRegionChangedEventArgs e)
	{
		if (rangeRegionChangedEventHandler_0 != null)
		{
			rangeRegionChangedEventHandler_0(this, e);
		}
		if (e.AddedRange != null)
		{
			foreach (Range item in e.AddedRange)
			{
				Grid.InvalidateRange(item);
			}
		}
		if (e.RemovedRange == null)
		{
			return;
		}
		foreach (Range item2 in e.RemovedRange)
		{
			Grid.InvalidateRange(item2);
		}
	}
}
