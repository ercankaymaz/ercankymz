namespace SourceGrid;

public class RangeRegionCancelEventArgs(RangeRegion p_GridRangeRegion) : RangeRegionEventArgs(p_GridRangeRegion)
{
	private bool bool_0 = false;

	public bool Cancel
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}
}
