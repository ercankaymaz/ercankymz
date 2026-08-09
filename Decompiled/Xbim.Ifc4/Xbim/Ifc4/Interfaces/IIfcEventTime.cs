using Xbim.Common;
using Xbim.Ifc4.DateTimeResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcEventTime : IIfcSchedulingTime, IPersistEntity, IPersist
{
	IfcDateTime? ActualDate { get; set; }

	IfcDateTime? EarlyDate { get; set; }

	IfcDateTime? LateDate { get; set; }

	IfcDateTime? ScheduleDate { get; set; }
}
