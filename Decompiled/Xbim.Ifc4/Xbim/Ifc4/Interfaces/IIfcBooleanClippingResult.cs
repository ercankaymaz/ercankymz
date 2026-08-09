using Xbim.Common;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcBooleanClippingResult : IIfcBooleanResult, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcBooleanOperand, IIfcBooleanOperand, IfcCsgSelect, IIfcCsgSelect
{
}
