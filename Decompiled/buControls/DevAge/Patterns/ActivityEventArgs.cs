using System;

namespace DevAge.Patterns;

public class ActivityEventArgs : EventArgs
{
	private IActivity activity;

	public IActivity Activity
	{
		get
		{
			return activity;
		}
		set
		{
			activity = value;
		}
	}

	public ActivityEventArgs(IActivity activity)
	{
		this.activity = activity;
	}
}
