using Xbim.Common;
using Xbim.Ifc4.DateTimeResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcWorkTime : IIfcSchedulingTime, IPersistEntity, IPersist
{
	IIfcRecurrencePattern RecurrencePattern { get; set; }

	IfcDate? Start { get; set; }

	IfcDate? Finish { get; set; }
}
