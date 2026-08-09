using Xbim.Common;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcDistributionPort : IIfcPort, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect
{
	IfcFlowDirectionEnum? FlowDirection { get; set; }

	IfcDistributionPortTypeEnum? PredefinedType { get; set; }

	IfcDistributionSystemEnum? SystemType { get; set; }
}
