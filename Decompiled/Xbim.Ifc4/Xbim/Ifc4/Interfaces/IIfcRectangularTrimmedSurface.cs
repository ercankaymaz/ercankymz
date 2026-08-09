using Xbim.Common;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcRectangularTrimmedSurface : IIfcBoundedSurface, IIfcSurface, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcGeometricSetSelect, IIfcGeometricSetSelect, IfcSurfaceOrFaceSurface, IIfcSurfaceOrFaceSurface
{
	IIfcSurface BasisSurface { get; set; }

	IfcParameterValue U1 { get; set; }

	IfcParameterValue V1 { get; set; }

	IfcParameterValue U2 { get; set; }

	IfcParameterValue V2 { get; set; }

	IfcBoolean Usense { get; set; }

	IfcBoolean Vsense { get; set; }
}
