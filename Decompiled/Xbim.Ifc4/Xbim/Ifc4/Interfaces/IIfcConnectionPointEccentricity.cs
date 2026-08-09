using Xbim.Common;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcConnectionPointEccentricity : IIfcConnectionPointGeometry, IIfcConnectionGeometry, IPersistEntity, IPersist
{
	IfcLengthMeasure? EccentricityInX { get; set; }

	IfcLengthMeasure? EccentricityInY { get; set; }

	IfcLengthMeasure? EccentricityInZ { get; set; }
}
