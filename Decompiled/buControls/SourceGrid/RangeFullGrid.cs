namespace SourceGrid;

public class RangeFullGrid : IRangeLoader
{
	public Range GetRange(GridVirtual p_Grid)
	{
		return p_Grid.CompleteRange;
	}
}
