using Xbim.Common;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcTaskTime : IIfcSchedulingTime, IPersistEntity, IPersist
{
	IfcTaskDurationEnum? DurationType { get; set; }

	IfcDuration? ScheduleDuration { get; set; }

	IfcDateTime? ScheduleStart { get; set; }

	IfcDateTime? ScheduleFinish { get; set; }

	IfcDateTime? EarlyStart { get; set; }

	IfcDateTime? EarlyFinish { get; set; }

	IfcDateTime? LateStart { get; set; }

	IfcDateTime? LateFinish { get; set; }

	IfcDuration? FreeFloat { get; set; }

	IfcDuration? TotalFloat { get; set; }

	IfcBoolean? IsCritical { get; set; }

	IfcDateTime? StatusTime { get; set; }

	IfcDuration? ActualDuration { get; set; }

	IfcDateTime? ActualStart { get; set; }

	IfcDateTime? ActualFinish { get; set; }

	IfcDuration? RemainingTime { get; set; }

	IfcPositiveRatioMeasure? Completion { get; set; }
}
