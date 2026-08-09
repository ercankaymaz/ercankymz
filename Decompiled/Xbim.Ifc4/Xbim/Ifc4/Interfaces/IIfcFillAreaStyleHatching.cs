using Xbim.Common;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationAppearanceResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcFillAreaStyleHatching : IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcFillStyleSelect, IIfcFillStyleSelect
{
	IIfcCurveStyle HatchLineAppearance { get; set; }

	IIfcHatchLineDistanceSelect StartOfNextHatchLine { get; set; }

	IIfcCartesianPoint PointOfReferenceHatchLine { get; set; }

	IIfcCartesianPoint PatternStart { get; set; }

	IfcPlaneAngleMeasure HatchLineAngle { get; set; }
}
