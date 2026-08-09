using System;
using System.Globalization;

namespace Xbim.Ifc2x3.DateTimeResource;

public static class DateTimeSelectExtensions
{
	public static string AsString(this IfcDateTimeSelect ifcDateTimeSelect)
	{
		IfcDateAndTime ifcDateAndTime = ifcDateTimeSelect as IfcDateAndTime;
		if (ifcDateAndTime != null)
		{
			int minute = 0;
			if (ifcDateAndTime.TimeComponent.MinuteComponent.HasValue)
			{
				minute = (int)(long)ifcDateAndTime.TimeComponent.MinuteComponent.Value;
			}
			int second = 0;
			if (ifcDateAndTime.TimeComponent.SecondComponent.HasValue)
			{
				second = (int)(double)ifcDateAndTime.TimeComponent.SecondComponent.Value;
			}
			return new DateTime((int)(long)ifcDateAndTime.DateComponent.YearComponent, (int)(long)ifcDateAndTime.DateComponent.MonthComponent, (int)(long)ifcDateAndTime.DateComponent.DayComponent, (int)(long)ifcDateAndTime.TimeComponent.HourComponent, minute, second).ToString(CultureInfo.InvariantCulture);
		}
		IfcCalendarDate ifcCalendarDate = ifcDateTimeSelect as IfcCalendarDate;
		if (ifcCalendarDate != null)
		{
			IfcCalendarDate ifcCalendarDate2 = ifcCalendarDate;
			return new DateTime((int)(long)ifcCalendarDate2.YearComponent, (int)(long)ifcCalendarDate2.MonthComponent, (int)(long)ifcCalendarDate2.DayComponent).ToString("d");
		}
		IfcLocalTime ifcLocalTime = ifcDateTimeSelect as IfcLocalTime;
		if (ifcLocalTime != null)
		{
			IfcLocalTime ifcLocalTime2 = ifcLocalTime;
			int minute2 = 0;
			if (ifcLocalTime2.MinuteComponent.HasValue)
			{
				minute2 = (int)(long)ifcLocalTime2.MinuteComponent.Value;
			}
			int second2 = 0;
			if (ifcLocalTime2.SecondComponent.HasValue)
			{
				second2 = (int)(double)ifcLocalTime2.SecondComponent.Value;
			}
			return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, (int)(long)ifcLocalTime2.HourComponent, minute2, second2).ToString("HH:mm:ss");
		}
		return string.Empty;
	}
}
