using Xbim.Common;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcAxis2Placement2D : IIfcPlacement, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcAxis2Placement, IIfcAxis2Placement
{
	IIfcDirection RefDirection { get; set; }
}
