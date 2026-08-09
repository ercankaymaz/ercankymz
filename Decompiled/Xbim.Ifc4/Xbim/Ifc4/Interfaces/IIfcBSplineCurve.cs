using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Geometry;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcBSplineCurve : IIfcBoundedCurve, IIfcCurve, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcGeometricSetSelect, IIfcGeometricSetSelect, IfcCurveOrEdgeCurve, IIfcCurveOrEdgeCurve
{
	IfcInteger Degree { get; set; }

	IItemSet<IIfcCartesianPoint> ControlPointsList { get; }

	IfcBSplineCurveForm CurveForm { get; set; }

	IfcLogical ClosedCurve { get; set; }

	IfcLogical SelfIntersect { get; set; }

	IfcInteger UpperIndexOnControlPoints { get; }

	List<XbimPoint3D> ControlPoints { get; }
}
