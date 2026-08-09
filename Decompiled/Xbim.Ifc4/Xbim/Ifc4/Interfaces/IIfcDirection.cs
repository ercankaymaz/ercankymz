using Xbim.Common;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcDirection : IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcGridPlacementDirectionSelect, IIfcGridPlacementDirectionSelect, IfcVectorOrDirection, IIfcVectorOrDirection
{
	IItemSet<IfcReal> DirectionRatios { get; }

	IfcDimensionCount Dim { get; }

	double X { get; }

	double Y { get; }

	double Z { get; }
}
