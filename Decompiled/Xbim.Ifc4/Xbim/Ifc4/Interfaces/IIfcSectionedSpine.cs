using Xbim.Common;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcSectionedSpine : IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType
{
	IIfcCompositeCurve SpineCurve { get; set; }

	IItemSet<IIfcProfileDef> CrossSections { get; }

	IItemSet<IIfcAxis2Placement3D> CrossSectionPositions { get; }

	IfcDimensionCount Dim { get; }
}
