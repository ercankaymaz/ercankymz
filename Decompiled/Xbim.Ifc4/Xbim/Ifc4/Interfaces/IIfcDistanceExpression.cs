using Xbim.Common;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcDistanceExpression : IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType
{
	IfcLengthMeasure DistanceAlong { get; set; }

	IfcLengthMeasure? OffsetLateral { get; set; }

	IfcLengthMeasure? OffsetVertical { get; set; }

	IfcLengthMeasure? OffsetLongitudinal { get; set; }

	IfcBoolean? AlongHorizontal { get; set; }
}
