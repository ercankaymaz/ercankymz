using System;
using Xbim.Ifc2x3.DateTimeResource;
using Xbim.Ifc2x3.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public static class DateAndTimeExtensions
{
	public static string ToISODateTimeString(this IfcDateTimeSelect ifcDateTimeSelect)
	{
		IfcDateAndTime ifcDateAndTime = ifcDateTimeSelect as IfcDateAndTime;
		if (ifcDateAndTime != null)
		{
			return ifcDateAndTime.ToISODateTimeString();
		}
		IfcCalendarDate ifcCalendarDate = ifcDateTimeSelect as IfcCalendarDate;
		if (ifcCalendarDate != null)
		{
			return ifcCalendarDate.ToISODateTimeString();
		}
		IfcLocalTime ifcLocalTime = ifcDateTimeSelect as IfcLocalTime;
		if (ifcLocalTime != null)
		{
			return ifcLocalTime.ToISODateTimeString();
		}
		return new DateTime(1, 1, 1, 12, 0, 0).ToString("yyyy-MM-ddThh:mm:ss");
	}

	public static string ToISODateTimeString(this IfcDateAndTime dateAndTime)
	{
		int year = 1;
		int month = 1;
		int day = 1;
		int hour = 0;
		int minute = 0;
		double num = 0.0;
		int millisecond = 0;
		if (dateAndTime.DateComponent != null)
		{
			year = (int)(long)dateAndTime.DateComponent.YearComponent;
			month = (int)(long)dateAndTime.DateComponent.MonthComponent;
			day = (int)(long)dateAndTime.DateComponent.DayComponent;
		}
		if (dateAndTime.TimeComponent != null)
		{
			hour = (int)(long)dateAndTime.TimeComponent.HourComponent;
			if (dateAndTime.TimeComponent.MinuteComponent.HasValue)
			{
				minute = (int)(long)dateAndTime.TimeComponent.MinuteComponent.Value;
			}
			if (dateAndTime.TimeComponent.SecondComponent.HasValue)
			{
				num = dateAndTime.TimeComponent.SecondComponent.Value;
			}
			double num2 = Math.Truncate(num);
			millisecond = (int)((num - num2) * 1000.0);
			num = num2;
		}
		return new DateTime(year, month, day, hour, minute, (int)num, millisecond).ToString("yyyy-MM-ddThh:mm:ss.fff");
	}

	public static string ToISODateTimeString(this IfcCalendarDate calendarDate)
	{
		return new DateTime((int)(long)calendarDate.YearComponent, (int)(long)calendarDate.MonthComponent, (int)(long)calendarDate.DayComponent).ToString("yyyy-MM-ddThh:mm:ss");
	}

	public static string ToISODateTimeString(this IfcLocalTime localTime)
	{
		int minute = 0;
		if (localTime.MinuteComponent.HasValue)
		{
			minute = (int)(long)localTime.MinuteComponent.Value;
		}
		double num = 0.0;
		if (localTime.SecondComponent.HasValue)
		{
			num = localTime.SecondComponent.Value;
		}
		double num2 = Math.Truncate(num);
		int millisecond = (int)((num - num2) * 1000.0);
		num = num2;
		return new DateTime(1, 1, 1, (int)(long)localTime.HourComponent, minute, (int)num, millisecond).ToString("yyyy-MM-ddThh:mm:ss.fff");
	}

	public static string ToISODateTimeString(this IfcTimeMeasure timeMeasure)
	{
		TimeSpan timeSpan = TimeSpan.FromSeconds(timeMeasure);
		if ((double)timeMeasure - Math.Truncate(timeMeasure) > 0.0)
		{
			return string.Format("{0}{1}.{2}S", timeSpan.ToString("'P'd'DT'h'H'm'M'"), timeSpan.Seconds, timeSpan.Milliseconds);
		}
		return timeSpan.ToString("'P'd'DT'h'H'm'M's'S'");
	}
}
