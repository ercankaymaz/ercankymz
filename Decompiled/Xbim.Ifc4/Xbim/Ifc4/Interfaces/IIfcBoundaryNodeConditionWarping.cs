using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcBoundaryNodeConditionWarping : IIfcBoundaryNodeCondition, IIfcBoundaryCondition, IPersistEntity, IPersist
{
	IIfcWarpingStiffnessSelect WarpingStiffness { get; set; }
}
