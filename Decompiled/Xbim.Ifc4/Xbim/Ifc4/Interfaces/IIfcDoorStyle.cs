using Xbim.Common;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcDoorStyle : IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect
{
	IfcDoorStyleOperationEnum OperationType { get; set; }

	IfcDoorStyleConstructionEnum ConstructionType { get; set; }

	IfcBoolean ParameterTakesPrecedence { get; set; }

	IfcBoolean Sizeable { get; set; }
}
