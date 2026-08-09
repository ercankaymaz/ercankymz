using System;

namespace DevAge.Patterns;

[Serializable]
public class SubActivityException : DevAgeApplicationException
{
	public SubActivityException(string activityName, Exception innerException)
		: base("The activity " + activityName + " throwed an exception, " + innerException.Message, innerException)
	{
	}
}
