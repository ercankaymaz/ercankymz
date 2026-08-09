using Xbim.Common;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcPolygonalBoundedHalfSpace : IIfcHalfSpaceSolid, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcBooleanOperand, IIfcBooleanOperand
{
	IIfcAxis2Placement3D Position { get; set; }

	IIfcBoundedCurve PolygonalBoundary { get; set; }
}
