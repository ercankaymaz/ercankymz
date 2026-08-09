using Xbim.Common;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcLightSourceSpot : IIfcLightSourcePositional, IIfcLightSource, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType
{
	IIfcDirection Orientation { get; set; }

	IfcReal? ConcentrationExponent { get; set; }

	IfcPositivePlaneAngleMeasure SpreadAngle { get; set; }

	IfcPositivePlaneAngleMeasure BeamWidthAngle { get; set; }
}
