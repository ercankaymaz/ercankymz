namespace SourceGrid;

public class RangeLoader : IRangeLoader
{
	private Range range;

	public Range Range
	{
		get
		{
			return range;
		}
		set
		{
			range = value;
		}
	}

	public RangeLoader(Range range)
	{
		this.range = range;
	}

	public virtual Range GetRange(GridVirtual p_Grid)
	{
		return range;
	}
}
