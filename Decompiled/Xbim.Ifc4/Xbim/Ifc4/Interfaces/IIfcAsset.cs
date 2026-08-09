using Xbim.Common;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcAsset : IIfcGroup, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType
{
	IfcIdentifier? Identification { get; set; }

	IIfcCostValue OriginalValue { get; set; }

	IIfcCostValue CurrentValue { get; set; }

	IIfcCostValue TotalReplacementCost { get; set; }

	IIfcActorSelect Owner { get; set; }

	IIfcActorSelect User { get; set; }

	IIfcPerson ResponsiblePerson { get; set; }

	IfcDate? IncorporationDate { get; set; }

	IIfcCostValue DepreciatedValue { get; set; }
}
