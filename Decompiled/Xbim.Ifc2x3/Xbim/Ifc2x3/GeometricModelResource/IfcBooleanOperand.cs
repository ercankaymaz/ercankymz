using Xbim.Common;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc2x3.GeometricModelResource;

public interface IfcBooleanOperand : IExpressSelectType, IPersist, IPersistEntity, IIfcBooleanOperand
{
	IfcDimensionCount Dim { get; }
}
