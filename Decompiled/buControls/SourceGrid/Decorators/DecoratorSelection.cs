using System.Drawing;
using SourceGrid.Selection;

namespace SourceGrid.Decorators;

public class DecoratorSelection : DecoratorBase
{
	private SelectionBase selection;

	public DecoratorSelection(SelectionBase selection)
	{
		this.selection = selection;
	}

	public override bool IntersectWith(Range range)
	{
		return selection.IntersectsWith(range);
	}

	public override void Draw(RangePaintEventArgs e)
	{
		RangeRegion selectionRegion = selection.GetSelectionRegion();
		if (selectionRegion.IsEmpty())
		{
			return;
		}
		Range range = selection.Grid.RangeAtAreaExpanded(CellPositionType.Scrollable);
		Brush brush = e.GraphicsCache.BrushsCache.GetBrush(selection.BackColor);
		CellContext cellContext = new CellContext(e.Grid, selection.ActivePosition);
		Range range2 = range.Intersect(new Range(selection.ActivePosition, selection.ActivePosition));
		Rectangle rect = e.Grid.PositionToRectangle(range2.Start);
		foreach (Range item in selectionRegion)
		{
			Range range3 = range.Intersect(item);
			Rectangle rectangle = e.Grid.RangeToRectangle(range3);
			if (!(rectangle == Rectangle.Empty))
			{
				Region region = new Region(rectangle);
				if (rectangle.IntersectsWith(rect))
				{
					region.Exclude(rect);
				}
				e.GraphicsCache.Graphics.FillRegion(brush, region);
				if ((range3.Contains(selection.ActivePosition) || selectionRegion.Count == 1) && !cellContext.IsEditing())
				{
					selection.Border.Draw(e.GraphicsCache, rectangle);
				}
			}
		}
		Brush brush2 = e.GraphicsCache.BrushsCache.GetBrush(selection.FocusBackColor);
		e.GraphicsCache.Graphics.FillRectangle(brush2, rect);
	}
}
