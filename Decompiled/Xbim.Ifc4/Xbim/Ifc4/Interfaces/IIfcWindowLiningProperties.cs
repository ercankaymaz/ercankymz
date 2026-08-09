using Xbim.Common;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcWindowLiningProperties : IIfcPreDefinedPropertySet, IIfcPropertySetDefinition, IIfcPropertyDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcPropertySetDefinitionSelect, IIfcPropertySetDefinitionSelect
{
	IfcPositiveLengthMeasure? LiningDepth { get; set; }

	IfcNonNegativeLengthMeasure? LiningThickness { get; set; }

	IfcNonNegativeLengthMeasure? TransomThickness { get; set; }

	IfcNonNegativeLengthMeasure? MullionThickness { get; set; }

	IfcNormalisedRatioMeasure? FirstTransomOffset { get; set; }

	IfcNormalisedRatioMeasure? SecondTransomOffset { get; set; }

	IfcNormalisedRatioMeasure? FirstMullionOffset { get; set; }

	IfcNormalisedRatioMeasure? SecondMullionOffset { get; set; }

	IIfcShapeAspect ShapeAspectStyle { get; set; }

	IfcLengthMeasure? LiningOffset { get; set; }

	IfcLengthMeasure? LiningToPanelOffsetX { get; set; }

	IfcLengthMeasure? LiningToPanelOffsetY { get; set; }
}
