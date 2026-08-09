using Xbim.Common;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcConstructionResource : IIfcResource, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcResourceSelect, IIfcResourceSelect
{
	IIfcResourceTime Usage { get; set; }

	IItemSet<IIfcAppliedValue> BaseCosts { get; }

	IIfcPhysicalQuantity BaseQuantity { get; set; }
}
