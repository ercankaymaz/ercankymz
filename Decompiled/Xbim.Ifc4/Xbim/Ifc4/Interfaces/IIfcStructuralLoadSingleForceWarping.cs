using Xbim.Common;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcStructuralLoadSingleForceWarping : IIfcStructuralLoadSingleForce, IIfcStructuralLoadStatic, IIfcStructuralLoadOrResult, IIfcStructuralLoad, IPersistEntity, IPersist
{
	IfcWarpingMomentMeasure? WarpingMoment { get; set; }
}
