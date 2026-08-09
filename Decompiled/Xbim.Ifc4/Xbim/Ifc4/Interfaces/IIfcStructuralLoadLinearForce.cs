using Xbim.Common;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcStructuralLoadLinearForce : IIfcStructuralLoadStatic, IIfcStructuralLoadOrResult, IIfcStructuralLoad, IPersistEntity, IPersist
{
	IfcLinearForceMeasure? LinearForceX { get; set; }

	IfcLinearForceMeasure? LinearForceY { get; set; }

	IfcLinearForceMeasure? LinearForceZ { get; set; }

	IfcLinearMomentMeasure? LinearMomentX { get; set; }

	IfcLinearMomentMeasure? LinearMomentY { get; set; }

	IfcLinearMomentMeasure? LinearMomentZ { get; set; }
}
