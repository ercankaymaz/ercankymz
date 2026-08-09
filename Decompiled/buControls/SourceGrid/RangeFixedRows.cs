namespace SourceGrid;

public class RangeFixedRows : IRangeLoader
{
	public Range GetRange(GridVirtual p_Grid)
	{
		if (p_Grid.Rows.Count < p_Grid.FixedRows)
		{
			return Range.Empty;
		}
		return new Range(0, 0, p_Grid.FixedRows, p_Grid.Columns.Count - 1);
	}
}
