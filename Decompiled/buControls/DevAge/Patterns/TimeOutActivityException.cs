using System;

namespace DevAge.Patterns;

[Serializable]
public class TimeOutActivityException : DevAgeApplicationException
{
	public TimeOutActivityException()
		: base("Activity timeout.")
	{
	}
}
