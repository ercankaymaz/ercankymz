using Xbim.Common;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcVirtualGridIntersection : IPersistEntity, IPersist, IfcGridPlacementDirectionSelect, IIfcGridPlacementDirectionSelect, IExpressSelectType
{
	IItemSet<IIfcGridAxis> IntersectingAxes { get; }

	IItemSet<IfcLengthMeasure> OffsetDistances { get; }
}
