using System.Runtime.CompilerServices;
using SourceGrid.Decorators;

namespace SourceGrid.Selection;

public class FreeSelection : SelectionBase
{
	private RangeRegion rangeRegion_0 = new RangeRegion();

	private DecoratorSelection decoratorSelection_0;

	public FreeSelection()
	{
		rangeRegion_0.Changed += delegate(object sender, RangeRegionChangedEventArgs e)
		{
			OnSelectionChanged(e);
		};
	}

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
		return rangeRegion_0.ContainsColumn(column);
	}

	public override void SelectColumn(int column, bool select)
	{
		Range range = base.Grid.Columns.GetRange(column);
		SelectRange(range, select);
	}

	public override bool IsSelectedRow(int row)
	{
		return rangeRegion_0.ContainsRow(row);
	}

	public override void SelectRow(int row, bool select)
	{
		Range range = base.Grid.Rows.GetRange(row);
		SelectRange(range, select);
	}

	public override bool IsSelectedCell(Position position)
	{
		return rangeRegion_0.Contains(position);
	}

	public override void SelectCell(Position position, bool select)
	{
		SelectRange(base.Grid.PositionToCellRange(position), select);
	}

	public override bool IsSelectedRange(Range range)
	{
		return rangeRegion_0.Contains(range);
	}

	public override void SelectRange(Range range, bool select)
	{
		Range range2 = base.Grid.RangeToCellRange(range);
		if (!select)
		{
			rangeRegion_0.Remove(range2);
		}
		else
		{
			rangeRegion_0.Add(ValidateRange(range2));
		}
	}

	protected override void OnResetSelection()
	{
		rangeRegion_0.Clear();
	}

	public override bool IsEmpty()
	{
		return rangeRegion_0.IsEmpty();
	}

	public override RangeRegion GetSelectionRegion()
	{
		return new RangeRegion(rangeRegion_0);
	}

	public override bool IntersectsWith(Range rng)
	{
		return rangeRegion_0.IntersectsWith(rng);
	}

	[CompilerGenerated]
	private void rangeRegion_0_Changed(object sender, RangeRegionChangedEventArgs e)
	{
		OnSelectionChanged(e);
	}
}
