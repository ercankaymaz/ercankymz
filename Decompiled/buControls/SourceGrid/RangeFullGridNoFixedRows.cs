namespace SourceGrid;

public class RangeFullGridNoFixedRows : IRangeLoader
{
	public Range GetRange(GridVirtual p_Grid)
	{
		if (p_Grid.Rows.Count < p_Grid.FixedRows)
		{
			return Range.Empty;
		}
		return new Range(p_Grid.FixedRows, 0, p_Grid.Rows.Count - 1, p_Grid.Columns.Count - 1);
	}
}
