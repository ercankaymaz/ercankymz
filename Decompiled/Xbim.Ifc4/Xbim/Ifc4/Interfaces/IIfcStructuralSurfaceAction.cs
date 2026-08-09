using Xbim.Common;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcStructuralSurfaceAction : IIfcStructuralAction, IIfcStructuralActivity, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect
{
	IfcProjectedOrTrueLengthEnum? ProjectedOrTrue { get; set; }

	IfcStructuralSurfaceActivityTypeEnum PredefinedType { get; set; }
}
