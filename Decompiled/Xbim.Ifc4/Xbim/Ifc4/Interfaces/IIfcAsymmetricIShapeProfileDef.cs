using Xbim.Common;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcAsymmetricIShapeProfileDef : IIfcParameterizedProfileDef, IIfcProfileDef, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType
{
	IfcPositiveLengthMeasure BottomFlangeWidth { get; set; }

	IfcPositiveLengthMeasure OverallDepth { get; set; }

	IfcPositiveLengthMeasure WebThickness { get; set; }

	IfcPositiveLengthMeasure BottomFlangeThickness { get; set; }

	IfcNonNegativeLengthMeasure? BottomFlangeFilletRadius { get; set; }

	IfcPositiveLengthMeasure TopFlangeWidth { get; set; }

	IfcPositiveLengthMeasure? TopFlangeThickness { get; set; }

	IfcNonNegativeLengthMeasure? TopFlangeFilletRadius { get; set; }

	IfcNonNegativeLengthMeasure? BottomFlangeEdgeRadius { get; set; }

	IfcPlaneAngleMeasure? BottomFlangeSlope { get; set; }

	IfcNonNegativeLengthMeasure? TopFlangeEdgeRadius { get; set; }

	IfcPlaneAngleMeasure? TopFlangeSlope { get; set; }
}
