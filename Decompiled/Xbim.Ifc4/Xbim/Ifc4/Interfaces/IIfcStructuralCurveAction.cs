using Xbim.Common;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcStructuralCurveAction : IIfcStructuralAction, IIfcStructuralActivity, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect
{
	IfcProjectedOrTrueLengthEnum? ProjectedOrTrue { get; set; }

	IfcStructuralCurveActivityTypeEnum PredefinedType { get; set; }
}
