using System;

namespace DevAge.Patterns;

[Serializable]
public class ActivityStatusNotValidException : DevAgeApplicationException
{
	public ActivityStatusNotValidException()
		: base("Activity status not valid.")
	{
	}
}
