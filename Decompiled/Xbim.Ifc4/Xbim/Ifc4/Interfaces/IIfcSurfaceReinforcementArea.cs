using Xbim.Common;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcSurfaceReinforcementArea : IIfcStructuralLoadOrResult, IIfcStructuralLoad, IPersistEntity, IPersist
{
	IItemSet<IfcLengthMeasure> SurfaceReinforcement1 { get; }

	IItemSet<IfcLengthMeasure> SurfaceReinforcement2 { get; }

	IfcRatioMeasure? ShearReinforcement { get; set; }
}
