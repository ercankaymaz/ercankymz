using Xbim.Common;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcStructuralLoadSingleDisplacement : IIfcStructuralLoadStatic, IIfcStructuralLoadOrResult, IIfcStructuralLoad, IPersistEntity, IPersist
{
	IfcLengthMeasure? DisplacementX { get; set; }

	IfcLengthMeasure? DisplacementY { get; set; }

	IfcLengthMeasure? DisplacementZ { get; set; }

	IfcPlaneAngleMeasure? RotationalDisplacementRX { get; set; }

	IfcPlaneAngleMeasure? RotationalDisplacementRY { get; set; }

	IfcPlaneAngleMeasure? RotationalDisplacementRZ { get; set; }
}
