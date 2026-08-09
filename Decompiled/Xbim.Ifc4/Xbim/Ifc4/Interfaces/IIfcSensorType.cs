using Xbim.Common;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcSensorType : IIfcDistributionControlElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect
{
	IfcSensorTypeEnum PredefinedType { get; set; }
}
