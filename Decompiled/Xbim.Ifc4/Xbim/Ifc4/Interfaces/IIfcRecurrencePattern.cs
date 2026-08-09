using Xbim.Common;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcRecurrencePattern : IPersistEntity, IPersist
{
	IfcRecurrenceTypeEnum RecurrenceType { get; set; }

	IItemSet<IfcDayInMonthNumber> DayComponent { get; }

	IItemSet<IfcDayInWeekNumber> WeekdayComponent { get; }

	IItemSet<IfcMonthInYearNumber> MonthComponent { get; }

	IfcInteger? Position { get; set; }

	IfcInteger? Interval { get; set; }

	IfcInteger? Occurrences { get; set; }

	IItemSet<IIfcTimePeriod> TimePeriods { get; }
}
