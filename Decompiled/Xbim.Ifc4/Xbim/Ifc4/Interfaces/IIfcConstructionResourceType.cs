using Xbim.Common;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcConstructionResourceType : IIfcTypeResource, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcResourceSelect, IIfcResourceSelect
{
	IItemSet<IIfcAppliedValue> BaseCosts { get; }

	IIfcPhysicalQuantity BaseQuantity { get; set; }
}
