using Xbim.Common;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcDoorPanelProperties : IIfcPreDefinedPropertySet, IIfcPropertySetDefinition, IIfcPropertyDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcPropertySetDefinitionSelect, IIfcPropertySetDefinitionSelect
{
	IfcPositiveLengthMeasure? PanelDepth { get; set; }

	IfcDoorPanelOperationEnum PanelOperation { get; set; }

	IfcNormalisedRatioMeasure? PanelWidth { get; set; }

	IfcDoorPanelPositionEnum PanelPosition { get; set; }

	IIfcShapeAspect ShapeAspectStyle { get; set; }
}
