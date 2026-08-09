using Xbim.Common;
using Xbim.Ifc4.DateTimeResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcTimePeriod : IPersistEntity, IPersist
{
	IfcTime StartTime { get; set; }

	IfcTime EndTime { get; set; }
}
