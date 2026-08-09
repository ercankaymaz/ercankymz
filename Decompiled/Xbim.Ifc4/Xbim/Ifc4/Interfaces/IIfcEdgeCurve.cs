using Xbim.Common;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcEdgeCurve : IIfcEdge, IIfcTopologicalRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcCurveOrEdgeCurve, IIfcCurveOrEdgeCurve
{
	IIfcCurve EdgeGeometry { get; set; }

	IfcBoolean SameSense { get; set; }
}
