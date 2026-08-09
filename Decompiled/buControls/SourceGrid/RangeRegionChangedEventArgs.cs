using System;

namespace SourceGrid;

public class RangeRegionChangedEventArgs : EventArgs
{
	private RangeRegion addedRange;

	private RangeRegion removedRange;

	public RangeRegion AddedRange => addedRange;

	public RangeRegion RemovedRange => removedRange;

	public RangeRegionChangedEventArgs(Range addedRange, Range removedRange)
	{
		if (!addedRange.IsEmpty())
		{
			this.addedRange = new RangeRegion(addedRange);
		}
		if (!removedRange.IsEmpty())
		{
			this.removedRange = new RangeRegion(removedRange);
		}
	}

	public RangeRegionChangedEventArgs(RangeRegion addedRange, RangeRegion removedRange)
	{
		this.addedRange = addedRange;
		this.removedRange = removedRange;
	}
}
