using System;

namespace SourceGrid;

public class RangeRegionChangingEventArgs : EventArgs
{
	private RangeRegion pRangeToExclude;

	private RangeRegion pRangeToInclude;

	private RangeRegion pCurrentRegion;

	public RangeRegion CurrentRegion => pCurrentRegion;

	public RangeRegion RegionToInclude => pRangeToInclude;

	public RangeRegion RegionToExclude => pRangeToExclude;

	public RangeRegionChangingEventArgs(RangeRegion pCurrentRegion, RangeRegion pRangeToExclude, RangeRegion pRangeToInclude)
	{
		this.pRangeToExclude = pRangeToExclude;
		this.pCurrentRegion = pCurrentRegion;
		this.pRangeToInclude = pRangeToInclude;
	}
}
