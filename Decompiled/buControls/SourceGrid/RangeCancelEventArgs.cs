namespace SourceGrid;

public class RangeCancelEventArgs(Range p_GridRange) : RangeEventArgs(p_GridRange)
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
