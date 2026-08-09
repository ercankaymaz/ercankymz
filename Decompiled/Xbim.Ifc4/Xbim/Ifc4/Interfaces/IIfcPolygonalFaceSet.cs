using Xbim.Common;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcPolygonalFaceSet : IIfcTessellatedFaceSet, IIfcTessellatedItem, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcBooleanOperand, IIfcBooleanOperand
{
	IfcBoolean? Closed { get; set; }

	IItemSet<IIfcIndexedPolygonalFace> Faces { get; }

	IItemSet<IfcPositiveInteger> PnIndex { get; }
}
