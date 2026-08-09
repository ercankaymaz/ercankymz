using System;

namespace Xbim.IO.Step21;

public static class StepDateTimeHelper
{
	public static int ToStep21(this DateTime dateTime)
	{
		DateTime value = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
		return Convert.ToInt32(dateTime.Subtract(value).TotalSeconds);
	}
}
