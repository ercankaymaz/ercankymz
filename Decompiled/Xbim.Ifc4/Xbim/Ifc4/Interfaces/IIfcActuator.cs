using Xbim.Common;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcActuator : IIfcDistributionControlElement, IIfcDistributionElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect
{
	IfcActuatorTypeEnum? PredefinedType { get; set; }
}
