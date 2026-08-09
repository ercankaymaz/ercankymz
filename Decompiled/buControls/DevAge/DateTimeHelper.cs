using System;

namespace DevAge;

public class DateTimeHelper
{
	public static int YearsDifference(DateTime dateA, DateTime dateB)
	{
		return MonthsDifference(dateA, dateB) / 12;
	}

	public static int MonthsDifference(DateTime dateA, DateTime dateB)
	{
		if (!(dateA == dateB))
		{
			if (!(dateA > dateB))
			{
				return -MonthsDifference(dateB, dateA);
			}
			int num = dateA.Year - dateB.Year;
			int num2 = num * 12 + (dateA.Month - dateB.Month);
			if (num2 != 0)
			{
				DateTime dateTime = dateB.AddMonths(num2);
				if ((dateA - dateTime).Ticks < 0L)
				{
					return num2 - 1;
				}
				return num2;
			}
			return num2;
		}
		return 0;
	}
}
