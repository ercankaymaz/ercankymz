using Xbim.Common;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcFailureConnectionCondition : IIfcStructuralConnectionCondition, IPersistEntity, IPersist
{
	IfcForceMeasure? TensionFailureX { get; set; }

	IfcForceMeasure? TensionFailureY { get; set; }

	IfcForceMeasure? TensionFailureZ { get; set; }

	IfcForceMeasure? CompressionFailureX { get; set; }

	IfcForceMeasure? CompressionFailureY { get; set; }

	IfcForceMeasure? CompressionFailureZ { get; set; }
}
