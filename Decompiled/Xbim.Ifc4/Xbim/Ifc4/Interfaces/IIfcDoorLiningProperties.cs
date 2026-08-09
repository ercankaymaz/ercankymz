using Xbim.Common;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcDoorLiningProperties : IIfcPreDefinedPropertySet, IIfcPropertySetDefinition, IIfcPropertyDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcPropertySetDefinitionSelect, IIfcPropertySetDefinitionSelect
{
	IfcPositiveLengthMeasure? LiningDepth { get; set; }

	IfcNonNegativeLengthMeasure? LiningThickness { get; set; }

	IfcPositiveLengthMeasure? ThresholdDepth { get; set; }

	IfcNonNegativeLengthMeasure? ThresholdThickness { get; set; }

	IfcNonNegativeLengthMeasure? TransomThickness { get; set; }

	IfcLengthMeasure? TransomOffset { get; set; }

	IfcLengthMeasure? LiningOffset { get; set; }

	IfcLengthMeasure? ThresholdOffset { get; set; }

	IfcPositiveLengthMeasure? CasingThickness { get; set; }

	IfcPositiveLengthMeasure? CasingDepth { get; set; }

	IIfcShapeAspect ShapeAspectStyle { get; set; }

	IfcLengthMeasure? LiningToPanelOffsetX { get; set; }

	IfcLengthMeasure? LiningToPanelOffsetY { get; set; }
}
