using Xbim.Common;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcTransitionCurveSegment2D : IIfcCurveSegment2D, IIfcBoundedCurve, IIfcCurve, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcGeometricSetSelect, IIfcGeometricSetSelect, IfcCurveOrEdgeCurve, IIfcCurveOrEdgeCurve
{
	IfcPositiveLengthMeasure? StartRadius { get; set; }

	IfcPositiveLengthMeasure? EndRadius { get; set; }

	IfcBoolean IsStartRadiusCCW { get; set; }

	IfcBoolean IsEndRadiusCCW { get; set; }

	IfcTransitionCurveType TransitionCurveType { get; set; }
}
