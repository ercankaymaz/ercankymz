using Xbim.Common;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcStructuralLoadPlanarForce : IIfcStructuralLoadStatic, IIfcStructuralLoadOrResult, IIfcStructuralLoad, IPersistEntity, IPersist
{
	IfcPlanarForceMeasure? PlanarForceX { get; set; }

	IfcPlanarForceMeasure? PlanarForceY { get; set; }

	IfcPlanarForceMeasure? PlanarForceZ { get; set; }
}
