using Xbim.Common;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4x3.GeometryResource;

namespace Xbim.Ifc4x3.GeometricModelResource;

public interface IfcGeometricSetSelect : IExpressSelectType, IPersist, IPersistEntity, IIfcGeometricSetSelect
{
	IfcDimensionCount Dim { get; }
}
