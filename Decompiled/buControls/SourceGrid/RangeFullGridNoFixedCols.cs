namespace SourceGrid;

public class RangeFullGridNoFixedCols : IRangeLoader
{
	public Range GetRange(GridVirtual p_Grid)
	{
		if (p_Grid.Columns.Count < p_Grid.FixedColumns)
		{
			return Range.Empty;
		}
		return new Range(0, p_Grid.FixedColumns, p_Grid.Rows.Count - 1, p_Grid.Columns.Count - 1);
	}
}
