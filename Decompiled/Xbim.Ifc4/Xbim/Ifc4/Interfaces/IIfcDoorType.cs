using Xbim.Common;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcDoorType : IIfcBuildingElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect
{
	IfcDoorTypeEnum PredefinedType { get; set; }

	IfcDoorTypeOperationEnum OperationType { get; set; }

	IfcBoolean? ParameterTakesPrecedence { get; set; }

	IfcLabel? UserDefinedOperationType { get; set; }
}
