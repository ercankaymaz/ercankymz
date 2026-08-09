using Xbim.Common;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcConstructionMaterialResource : IIfcConstructionResource, IIfcResource, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcResourceSelect, IIfcResourceSelect
{
	IfcConstructionMaterialResourceTypeEnum? PredefinedType { get; set; }
}
