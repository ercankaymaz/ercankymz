using Xbim.Common;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4x3.GeometryResource;

public interface IfcAxis2Placement : IExpressSelectType, IPersist, IPersistEntity, IIfcAxis2Placement
{
	IfcDimensionCount Dim { get; }
}
