using System;
using System.Collections.Generic;
using SourceGrid.Decorators;

namespace SourceGrid.Selection;

public class ColumnSelection : SelectionBase
{
	private DecoratorSelection decoratorSelection_0;

	private List<int> list_0 = new List<int>();

	public override void BindToGrid(GridVirtual p_grid)
	{
		base.BindToGrid(p_grid);
		decoratorSelection_0 = new DecoratorSelection(this);
		base.Grid.Decorators.Add(decoratorSelection_0);
	}

	public override void UnBindToGrid()
	{
		base.Grid.Decorators.Remove(decoratorSelection_0);
		base.UnBindToGrid();
	}

	public override bool IsSelectedColumn(int column)
	{
		return list_0.Contains(column);
	}

	public override void SelectColumn(int column, bool select)
	{
		if (!select || list_0.Contains(column))
		{
			if (!select && list_0.Contains(column))
			{
				list_0.Remove(column);
				OnSelectionChanged(new RangeRegionChangedEventArgs(Range.Empty, base.Grid.Columns.GetRange(column)));
			}
		}
		else
		{
			list_0.Add(column);
			OnSelectionChanged(new RangeRegionChangedEventArgs(base.Grid.Columns.GetRange(column), Range.Empty));
		}
	}

	public override bool IsSelectedRow(int row)
	{
		return false;
	}

	public override void SelectRow(int row, bool select)
	{
		throw new Exception("The method or operation is not implemented.");
	}

	public override bool IsSelectedCell(Position position)
	{
		return IsSelectedColumn(position.Column);
	}

	public override void SelectCell(Position position, bool select)
	{
		SelectColumn(position.Column, select);
	}

	public override bool IsSelectedRange(Range range)
	{
		for (int i = range.Start.Column; i <= range.End.Column; i++)
		{
			if (!IsSelectedColumn(i))
			{
				return false;
			}
		}
		return true;
	}

	public override void SelectRange(Range range, bool select)
	{
		for (int i = range.Start.Column; i <= range.End.Column; i++)
		{
			SelectColumn(i, select);
		}
	}

	protected override void OnResetSelection()
	{
		RangeRegion selectionRegion = GetSelectionRegion();
		list_0.Clear();
		OnSelectionChanged(new RangeRegionChangedEventArgs(null, selectionRegion));
	}

	public override bool IsEmpty()
	{
		return list_0.Count == 0;
	}

	public override RangeRegion GetSelectionRegion()
	{
		RangeRegion rangeRegion = new RangeRegion();
		if (base.Grid.Rows.Count > 0)
		{
			foreach (int item in list_0)
			{
				rangeRegion.Add(ValidateRange(new Range(base.Grid.FixedRows, item, base.Grid.Rows.Count - 1, item)));
			}
		}
		return rangeRegion;
	}

	public override bool IntersectsWith(Range rng)
	{
		for (int i = rng.Start.Column; i <= rng.End.Column; i++)
		{
			if (IsSelectedColumn(i))
			{
				return true;
			}
		}
		return false;
	}
}
