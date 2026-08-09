using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcLagTime : IIfcSchedulingTime, IPersistEntity, IPersist
{
	IIfcTimeOrRatioSelect LagValue { get; set; }

	IfcTaskDurationEnum DurationType { get; set; }
}
