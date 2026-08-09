using Xbim.Common;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcFaceSurface : IIfcFace, IIfcTopologicalRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcSurfaceOrFaceSurface, IIfcSurfaceOrFaceSurface
{
	IIfcSurface FaceSurface { get; set; }

	IfcBoolean SameSense { get; set; }
}
