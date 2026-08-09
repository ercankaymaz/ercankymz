using Xbim.Common;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.StructuralAnalysisDomain;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcDoor : IIfcBuildingElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect
{
	IfcPositiveLengthMeasure? OverallHeight { get; set; }

	IfcPositiveLengthMeasure? OverallWidth { get; set; }

	IfcDoorTypeEnum? PredefinedType { get; set; }

	IfcDoorTypeOperationEnum? OperationType { get; set; }

	IfcLabel? UserDefinedOperationType { get; set; }
}
