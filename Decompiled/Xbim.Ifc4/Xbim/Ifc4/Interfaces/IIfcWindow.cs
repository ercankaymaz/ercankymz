using Xbim.Common;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.StructuralAnalysisDomain;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcWindow : IIfcBuildingElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect
{
	IfcPositiveLengthMeasure? OverallHeight { get; set; }

	IfcPositiveLengthMeasure? OverallWidth { get; set; }

	IfcWindowTypeEnum? PredefinedType { get; set; }

	IfcWindowTypePartitioningEnum? PartitioningType { get; set; }

	IfcLabel? UserDefinedPartitioningType { get; set; }
}
