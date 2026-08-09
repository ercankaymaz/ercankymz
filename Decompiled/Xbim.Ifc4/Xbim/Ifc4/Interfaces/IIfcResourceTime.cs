using Xbim.Common;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcResourceTime : IIfcSchedulingTime, IPersistEntity, IPersist
{
	IfcDuration? ScheduleWork { get; set; }

	IfcPositiveRatioMeasure? ScheduleUsage { get; set; }

	IfcDateTime? ScheduleStart { get; set; }

	IfcDateTime? ScheduleFinish { get; set; }

	IfcLabel? ScheduleContour { get; set; }

	IfcDuration? LevelingDelay { get; set; }

	IfcBoolean? IsOverAllocated { get; set; }

	IfcDateTime? StatusTime { get; set; }

	IfcDuration? ActualWork { get; set; }

	IfcPositiveRatioMeasure? ActualUsage { get; set; }

	IfcDateTime? ActualStart { get; set; }

	IfcDateTime? ActualFinish { get; set; }

	IfcDuration? RemainingWork { get; set; }

	IfcPositiveRatioMeasure? RemainingUsage { get; set; }

	IfcPositiveRatioMeasure? Completion { get; set; }
}
