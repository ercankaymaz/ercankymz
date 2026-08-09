using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcSurfaceCurve : IIfcCurve, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcGeometricSetSelect, IIfcGeometricSetSelect, IfcCurveOnSurface, IIfcCurveOnSurface
{
	IIfcCurve Curve3D { get; set; }

	IItemSet<IIfcPcurve> AssociatedGeometry { get; }

	IfcPreferredSurfaceCurveRepresentation MasterRepresentation { get; set; }

	List<IIfcSurface> BasisSurface { get; }
}
