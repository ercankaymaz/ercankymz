using Xbim.Common;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcStructuralLoadSingleForce : IIfcStructuralLoadStatic, IIfcStructuralLoadOrResult, IIfcStructuralLoad, IPersistEntity, IPersist
{
	IfcForceMeasure? ForceX { get; set; }

	IfcForceMeasure? ForceY { get; set; }

	IfcForceMeasure? ForceZ { get; set; }

	IfcTorqueMeasure? MomentX { get; set; }

	IfcTorqueMeasure? MomentY { get; set; }

	IfcTorqueMeasure? MomentZ { get; set; }
}
