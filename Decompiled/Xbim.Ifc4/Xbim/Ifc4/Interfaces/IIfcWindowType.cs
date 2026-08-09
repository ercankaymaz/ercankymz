using Xbim.Common;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcWindowType : IIfcBuildingElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect
{
	IfcWindowTypeEnum PredefinedType { get; set; }

	IfcWindowTypePartitioningEnum PartitioningType { get; set; }

	IfcBoolean? ParameterTakesPrecedence { get; set; }

	IfcLabel? UserDefinedPartitioningType { get; set; }
}
