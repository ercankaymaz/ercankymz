using System;

namespace SourceGrid;

public class RangeRegionEventArgs : EventArgs
{
	private RangeRegion p_GridRangeRegion;

	public RangeRegion RangeRegion => p_GridRangeRegion;

	public RangeRegionEventArgs(RangeRegion p_GridRangeRegion)
	{
		this.p_GridRangeRegion = p_GridRangeRegion;
	}
}
