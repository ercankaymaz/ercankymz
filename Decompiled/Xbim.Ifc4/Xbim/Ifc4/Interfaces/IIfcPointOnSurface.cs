using Xbim.Common;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcPointOnSurface : IIfcPoint, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcGeometricSetSelect, IIfcGeometricSetSelect, IfcPointOrVertexPoint, IIfcPointOrVertexPoint
{
	IIfcSurface BasisSurface { get; set; }

	IfcParameterValue PointParameterU { get; set; }

	IfcParameterValue PointParameterV { get; set; }
}
