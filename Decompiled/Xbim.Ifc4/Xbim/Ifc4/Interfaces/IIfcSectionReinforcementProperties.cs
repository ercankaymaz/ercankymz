using Xbim.Common;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcSectionReinforcementProperties : IIfcPreDefinedProperties, IIfcPropertyAbstraction, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType
{
	IfcLengthMeasure LongitudinalStartPosition { get; set; }

	IfcLengthMeasure LongitudinalEndPosition { get; set; }

	IfcLengthMeasure? TransversePosition { get; set; }

	IfcReinforcingBarRoleEnum ReinforcementRole { get; set; }

	IIfcSectionProperties SectionDefinition { get; set; }

	IItemSet<IIfcReinforcementBarProperties> CrossSectionReinforcementDefinitions { get; }
}
