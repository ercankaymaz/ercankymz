using System.Collections.Generic;
using SourceGrid.Cells;

namespace SourceGrid;

public class GridRow(Grid grid) : RowInfo(grid)
{
	private Dictionary<GridColumn, ICell> dictionary_0 = new Dictionary<GridColumn, ICell>();

	public ICell this[GridColumn column]
	{
		get
		{
			if (!dictionary_0.TryGetValue(column, out var value))
			{
				return null;
			}
			return value;
		}
		set
		{
			dictionary_0[column] = value;
		}
	}
}
