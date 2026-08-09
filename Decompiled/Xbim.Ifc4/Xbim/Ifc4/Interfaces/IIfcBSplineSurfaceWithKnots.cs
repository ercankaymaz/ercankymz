using Xbim.Common;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcBSplineSurfaceWithKnots : IIfcBSplineSurface, IIfcBoundedSurface, IIfcSurface, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcGeometricSetSelect, IIfcGeometricSetSelect, IfcSurfaceOrFaceSurface, IIfcSurfaceOrFaceSurface
{
	IItemSet<IfcInteger> UMultiplicities { get; }

	IItemSet<IfcInteger> VMultiplicities { get; }

	IItemSet<IfcParameterValue> UKnots { get; }

	IItemSet<IfcParameterValue> VKnots { get; }

	IfcKnotType KnotSpec { get; set; }

	IfcInteger KnotVUpper { get; }

	IfcInteger KnotUUpper { get; }
}
