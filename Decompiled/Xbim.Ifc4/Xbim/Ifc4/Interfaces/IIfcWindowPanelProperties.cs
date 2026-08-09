using Xbim.Common;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcWindowPanelProperties : IIfcPreDefinedPropertySet, IIfcPropertySetDefinition, IIfcPropertyDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcPropertySetDefinitionSelect, IIfcPropertySetDefinitionSelect
{
	IfcWindowPanelOperationEnum OperationType { get; set; }

	IfcWindowPanelPositionEnum PanelPosition { get; set; }

	IfcPositiveLengthMeasure? FrameDepth { get; set; }

	IfcPositiveLengthMeasure? FrameThickness { get; set; }

	IIfcShapeAspect ShapeAspectStyle { get; set; }
}
