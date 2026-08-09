using Xbim.Common;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcWindowStyle : IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect
{
	IfcWindowStyleConstructionEnum ConstructionType { get; set; }

	IfcWindowStyleOperationEnum OperationType { get; set; }

	IfcBoolean ParameterTakesPrecedence { get; set; }

	IfcBoolean Sizeable { get; set; }
}
