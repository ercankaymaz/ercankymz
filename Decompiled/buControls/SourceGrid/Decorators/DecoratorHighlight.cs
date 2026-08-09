namespace SourceGrid.Decorators;

public class DecoratorHighlight : DecoratorBase
{
	private Range range_0 = Range.Empty;

	public Range Range
	{
		get
		{
			return range_0;
		}
		set
		{
			range_0 = value;
		}
	}

	public override bool IntersectWith(Range range)
	{
		return Range.IntersectsWith(range);
	}

	public override void Draw(RangePaintEventArgs e)
	{
	}
}
