using System;
using System.ComponentModel;
using System.Drawing;
using SourceGrid.Cells;

namespace SourceGrid;

public struct CellContext
{
	public static readonly CellContext Empty;

	public Position Position;

	public ICellVirtual Cell;

	public GridVirtual Grid;

	public string DisplayText
	{
		get
		{
			if (Cell != null)
			{
				try
				{
					object value = Cell.Model.ValueModel.GetValue(this);
					if (Cell.Editor != null)
					{
						return Cell.Editor.ValueToDisplayString(value);
					}
					if (value != null)
					{
						return value.ToString();
					}
					return string.Empty;
				}
				catch (Exception ex)
				{
					return "Error:" + ex.Message;
				}
			}
			return null;
		}
	}

	public object Value
	{
		get
		{
			return Cell.Model.ValueModel.GetValue(this);
		}
		set
		{
			Cell.Model.ValueModel.SetValue(this, value);
		}
	}

	public Range CellRange => Grid.PositionToCellRange(Position);

	static CellContext()
	{
		Empty = new CellContext(null, Position.Empty, null);
	}

	public CellContext(GridVirtual pGridVirtual, Position pPosition, ICellVirtual pCell)
	{
		Position = pPosition;
		Cell = pCell;
		Grid = pGridVirtual;
	}

	public CellContext(GridVirtual pGridVirtual, Position pPosition)
	{
		Position = pPosition;
		Grid = pGridVirtual;
		Cell = Grid.GetCell(Position);
	}

	public Size Measure(Size maxLayoutArea)
	{
		if (Cell != null)
		{
			if (Grid != null)
			{
				Size result = Cell.View.Measure(this, maxLayoutArea);
				Range range = Grid.PositionToCellRange(Position);
				result.Width = (int)Math.Ceiling((float)result.Width / (float)range.ColumnsCount);
				result.Height = (int)Math.Ceiling((float)result.Height / (float)range.RowsCount);
				return result;
			}
			throw new SourceGridException("Grid is null");
		}
		return Size.Empty;
	}

	public void StartEdit()
	{
		if (Cell != null)
		{
			if (Grid != null)
			{
				if (Cell.Editor != null && Cell.Editor.EnableEdit && !IsEditing() && Grid.Selection.Focus(Position, pResetSelection: true))
				{
					CancelEventArgs e = new CancelEventArgs();
					Grid.Controller.OnEditStarting(this, e);
					if (!e.Cancel)
					{
						Cell.Editor.vmethod_0(this);
						Grid.Controller.OnEditStarted(this, EventArgs.Empty);
					}
				}
				return;
			}
			throw new SourceGridException("Grid is null");
		}
		throw new SourceGridException("No cell at position " + Position.ToString());
	}

	public bool EndEdit(bool cancel)
	{
		if (Cell != null)
		{
			if (Grid != null)
			{
				if (Cell.Editor == null || !Cell.Editor.IsEditing)
				{
					return true;
				}
				CellContext editCellContext = Cell.Editor.EditCellContext;
				bool result;
				if (result = Cell.Editor.vmethod_1(cancel))
				{
					Grid.Controller.OnEditEnded(editCellContext, EventArgs.Empty);
				}
				return result;
			}
			return true;
		}
		return true;
	}

	public bool IsEditing()
	{
		if (Cell != null)
		{
			if (Grid != null)
			{
				if (Cell.Editor == null)
				{
					return false;
				}
				return Cell.Editor.IsEditing && Cell.Editor.EditCellContext == this;
			}
			return false;
		}
		return false;
	}

	public bool CanBeDrawn()
	{
		return Cell != null && (Cell.Editor == null || Cell.Editor.EnableCellDrawOnEdit || !IsEditing());
	}

	public void Invalidate()
	{
		if (Cell != null && Grid != null)
		{
			Grid.InvalidateCell(Position);
		}
	}

	public bool IsEmpty()
	{
		return Equals(Empty);
	}

	public override int GetHashCode()
	{
		return Position.GetHashCode();
	}

	public bool Equals(CellContext other)
	{
		return Position == other.Position && Cell == other.Cell && Grid == other.Grid;
	}

	public override bool Equals(object obj)
	{
		return Equals((CellContext)obj);
	}

	public static bool operator ==(CellContext Left, CellContext Right)
	{
		return Left.Equals(Right);
	}

	public static bool operator !=(CellContext Left, CellContext Right)
	{
		return !Left.Equals(Right);
	}

	public override string ToString()
	{
		return Position.ToString();
	}
}
