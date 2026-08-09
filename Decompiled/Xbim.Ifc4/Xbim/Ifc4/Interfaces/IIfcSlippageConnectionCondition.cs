using Xbim.Common;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcSlippageConnectionCondition : IIfcStructuralConnectionCondition, IPersistEntity, IPersist
{
	IfcLengthMeasure? SlippageX { get; set; }

	IfcLengthMeasure? SlippageY { get; set; }

	IfcLengthMeasure? SlippageZ { get; set; }
}
