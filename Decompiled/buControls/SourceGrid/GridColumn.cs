using System.Collections.Generic;
using SourceGrid.Cells;

namespace SourceGrid;

public class GridColumn(Grid grid) : ColumnInfo(grid)
{
	private Dictionary<GridRow, ICell> dictionary_0 = new Dictionary<GridRow, ICell>();

	public ICell this[GridRow row]
	{
		get
		{
			if (!dictionary_0.TryGetValue(row, out var value))
			{
				return null;
			}
			return value;
		}
		set
		{
			dictionary_0[row] = value;
		}
	}
}
