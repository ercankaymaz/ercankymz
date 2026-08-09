using System;

namespace DevAge.Patterns;

[Serializable]
public class ActivityCanceledException : DevAgeApplicationException
{
	public ActivityCanceledException()
		: base("Activity canceled.")
	{
	}
}
