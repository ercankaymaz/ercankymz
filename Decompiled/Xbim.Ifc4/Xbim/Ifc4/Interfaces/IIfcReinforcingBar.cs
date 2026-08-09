using Xbim.Common;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.StructuralAnalysisDomain;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcReinforcingBar : IIfcReinforcingElement, IIfcElementComponent, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect
{
	IfcPositiveLengthMeasure? NominalDiameter { get; set; }

	IfcAreaMeasure? CrossSectionArea { get; set; }

	IfcPositiveLengthMeasure? BarLength { get; set; }

	IfcReinforcingBarTypeEnum? PredefinedType { get; set; }

	IfcReinforcingBarSurfaceEnum? BarSurface { get; set; }
}
