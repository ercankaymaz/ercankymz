using System;
using SourceGrid.Decorators;
using ns27;

namespace SourceGrid.Selection;

public class RowSelection : SelectionBase
{
	private DecoratorSelection decoratorSelection_0;

	private RangeMergerByRows rangeMergerByRows_0 = new RangeMergerByRows();

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
		return false;
	}

	public override void SelectColumn(int column, bool select)
	{
		throw new Exception("The method or operation is not implemented.");
	}

	public override bool IsSelectedRow(int row)
	{
		return rangeMergerByRows_0.IsSelectedRow(row);
	}

	public override void SelectRow(int row, bool select)
	{
		Range range = base.Grid.Rows.GetRange(row);
		if (!select || rangeMergerByRows_0.IsSelectedRow(row))
		{
			if (!select && rangeMergerByRows_0.IsSelectedRow(row))
			{
				rangeMergerByRows_0.RemoveRange(range);
				OnSelectionChanged(new RangeRegionChangedEventArgs(Range.Empty, range));
			}
			return;
		}
		Position activePosition = base.ActivePosition;
		if (!base.EnableMultiSelection)
		{
			base.Grid.Selection.ResetSelection(mantainFocus: false);
		}
		rangeMergerByRows_0.AddRange(range);
		base.ActivePosition = activePosition;
		OnSelectionChanged(new RangeRegionChangedEventArgs(range, Range.Empty));
	}

	public override bool IsSelectedCell(Position position)
	{
		return IsSelectedRow(position.Row);
	}

	public override void SelectCell(Position position, bool select)
	{
		SelectRow(position.Row, select);
	}

	public override bool IsSelectedRange(Range range)
	{
		for (int i = range.Start.Row; i <= range.End.Row; i++)
		{
			if (!IsSelectedRow(i))
			{
				return false;
			}
		}
		return true;
	}

	public override void SelectRange(Range range, bool select)
	{
		Range range2 = Class76.smethod_760(range, this);
		if (!select)
		{
			rangeMergerByRows_0.RemoveRange(range2);
		}
		else
		{
			rangeMergerByRows_0.AddRange(range2);
		}
		OnSelectionChanged(new RangeRegionChangedEventArgs(range2, Range.Empty));
	}

	protected override void OnResetSelection()
	{
		RangeRegion selectionRegion = GetSelectionRegion();
		rangeMergerByRows_0.Clear();
		OnSelectionChanged(new RangeRegionChangedEventArgs(null, selectionRegion));
	}

	public override bool IsEmpty()
	{
		return rangeMergerByRows_0.IsEmpty();
	}

	public override RangeRegion GetSelectionRegion()
	{
		RangeRegion rangeRegion = new RangeRegion();
		if (base.Grid.Columns.Count != 0)
		{
			foreach (Range selectedRowRegion in rangeMergerByRows_0.GetSelectedRowRegions(0, base.Grid.Columns.Count))
			{
				rangeRegion.Add(ValidateRange(selectedRowRegion));
			}
			return rangeRegion;
		}
		return rangeRegion;
	}

	public override bool IntersectsWith(Range rng)
	{
		for (int i = rng.Start.Row; i <= rng.End.Row; i++)
		{
			if (IsSelectedRow(i))
			{
				return true;
			}
		}
		return false;
	}
}
