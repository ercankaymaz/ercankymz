using Xbim.Common;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcConstructionProductResourceType : IIfcConstructionResourceType, IIfcTypeResource, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcResourceSelect, IIfcResourceSelect
{
	IfcConstructionProductResourceTypeEnum PredefinedType { get; set; }
}
