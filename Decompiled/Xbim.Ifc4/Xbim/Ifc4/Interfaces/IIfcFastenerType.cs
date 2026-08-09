using Xbim.Common;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcFastenerType : IIfcElementComponentType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect
{
	IfcFastenerTypeEnum PredefinedType { get; set; }
}
