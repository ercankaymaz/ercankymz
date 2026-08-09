using Xbim.Common;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcLShapeProfileDef : IIfcParameterizedProfileDef, IIfcProfileDef, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType
{
	IfcPositiveLengthMeasure Depth { get; set; }

	IfcPositiveLengthMeasure? Width { get; set; }

	IfcPositiveLengthMeasure Thickness { get; set; }

	IfcNonNegativeLengthMeasure? FilletRadius { get; set; }

	IfcNonNegativeLengthMeasure? EdgeRadius { get; set; }

	IfcPlaneAngleMeasure? LegSlope { get; set; }
}
