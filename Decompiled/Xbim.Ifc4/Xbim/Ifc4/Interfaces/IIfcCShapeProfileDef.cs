using Xbim.Common;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcCShapeProfileDef : IIfcParameterizedProfileDef, IIfcProfileDef, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType
{
	IfcPositiveLengthMeasure Depth { get; set; }

	IfcPositiveLengthMeasure Width { get; set; }

	IfcPositiveLengthMeasure WallThickness { get; set; }

	IfcPositiveLengthMeasure Girth { get; set; }

	IfcNonNegativeLengthMeasure? InternalFilletRadius { get; set; }
}
