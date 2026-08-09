using Xbim.Common;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcCostItem : IIfcControl, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType
{
	IfcCostItemTypeEnum? PredefinedType { get; set; }

	IItemSet<IIfcCostValue> CostValues { get; }

	IItemSet<IIfcPhysicalQuantity> CostQuantities { get; }
}
