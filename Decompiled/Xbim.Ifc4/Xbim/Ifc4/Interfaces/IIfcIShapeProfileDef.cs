using Xbim.Common;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcIShapeProfileDef : IIfcParameterizedProfileDef, IIfcProfileDef, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType
{
	IfcPositiveLengthMeasure OverallWidth { get; set; }

	IfcPositiveLengthMeasure OverallDepth { get; set; }

	IfcPositiveLengthMeasure WebThickness { get; set; }

	IfcPositiveLengthMeasure FlangeThickness { get; set; }

	IfcNonNegativeLengthMeasure? FilletRadius { get; set; }

	IfcNonNegativeLengthMeasure? FlangeEdgeRadius { get; set; }

	IfcPlaneAngleMeasure? FlangeSlope { get; set; }
}
