using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcIndexedPolygonalFace : IIfcTessellatedItem, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType
{
	IItemSet<IfcPositiveInteger> CoordIndex { get; }

	IEnumerable<IIfcPolygonalFaceSet> ToFaceSet { get; }
}
