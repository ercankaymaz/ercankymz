using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Geometry;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcBSplineSurface : IIfcBoundedSurface, IIfcSurface, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcGeometricSetSelect, IIfcGeometricSetSelect, IfcSurfaceOrFaceSurface, IIfcSurfaceOrFaceSurface
{
	IfcInteger UDegree { get; set; }

	IfcInteger VDegree { get; set; }

	IItemSet<IItemSet<IIfcCartesianPoint>> ControlPointsList { get; }

	IfcBSplineSurfaceForm SurfaceForm { get; set; }

	IfcLogical UClosed { get; set; }

	IfcLogical VClosed { get; set; }

	IfcLogical SelfIntersect { get; set; }

	IfcInteger UUpper { get; }

	IfcInteger VUpper { get; }

	List<List<XbimPoint3D>> ControlPoints { get; }
}
