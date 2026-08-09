using Xbim.Common;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcTShapeProfileDef : IIfcParameterizedProfileDef, IIfcProfileDef, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType
{
	IfcPositiveLengthMeasure Depth { get; set; }

	IfcPositiveLengthMeasure FlangeWidth { get; set; }

	IfcPositiveLengthMeasure WebThickness { get; set; }

	IfcPositiveLengthMeasure FlangeThickness { get; set; }

	IfcNonNegativeLengthMeasure? FilletRadius { get; set; }

	IfcNonNegativeLengthMeasure? FlangeEdgeRadius { get; set; }

	IfcNonNegativeLengthMeasure? WebEdgeRadius { get; set; }

	IfcPlaneAngleMeasure? WebSlope { get; set; }

	IfcPlaneAngleMeasure? FlangeSlope { get; set; }
}
