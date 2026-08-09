using Xbim.Common;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcAlignment2DVerSegParabolicArc : IIfcAlignment2DVerticalSegment, IIfcAlignment2DSegment, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType
{
	IfcPositiveLengthMeasure ParabolaConstant { get; set; }

	IfcBoolean IsConvex { get; set; }
}
