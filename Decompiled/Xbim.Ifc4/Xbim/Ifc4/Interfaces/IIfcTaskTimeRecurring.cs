using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcTaskTimeRecurring : IIfcTaskTime, IIfcSchedulingTime, IPersistEntity, IPersist
{
	IIfcRecurrencePattern Recurrence { get; set; }
}
