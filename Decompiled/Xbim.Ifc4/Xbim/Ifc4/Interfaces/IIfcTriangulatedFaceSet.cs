using Xbim.Common;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcTriangulatedFaceSet : IIfcTessellatedFaceSet, IIfcTessellatedItem, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcBooleanOperand, IIfcBooleanOperand
{
	IItemSet<IItemSet<IfcParameterValue>> Normals { get; }

	IfcBoolean? Closed { get; set; }

	IItemSet<IItemSet<IfcPositiveInteger>> CoordIndex { get; }

	IItemSet<IfcPositiveInteger> PnIndex { get; }

	IfcInteger NumberOfTriangles { get; }
}
