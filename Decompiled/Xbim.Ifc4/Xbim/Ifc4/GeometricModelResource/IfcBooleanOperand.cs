using Xbim.Common;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4.GeometricModelResource;

public interface IfcBooleanOperand : IIfcBooleanOperand, IExpressSelectType, IPersist, IPersistEntity
{
	IfcDimensionCount Dim { get; }
}
