using Xbim.Common;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcInventory : IIfcGroup, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType
{
	IfcInventoryTypeEnum? PredefinedType { get; set; }

	IIfcActorSelect Jurisdiction { get; set; }

	IItemSet<IIfcPerson> ResponsiblePersons { get; }

	IfcDate? LastUpdateDate { get; set; }

	IIfcCostValue CurrentValue { get; set; }

	IIfcCostValue OriginalValue { get; set; }
}
