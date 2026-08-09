using Xbim.Common;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.StructuralAnalysisDomain;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcTendon : IIfcReinforcingElement, IIfcElementComponent, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect
{
	IfcTendonTypeEnum? PredefinedType { get; set; }

	IfcPositiveLengthMeasure? NominalDiameter { get; set; }

	IfcAreaMeasure? CrossSectionArea { get; set; }

	IfcForceMeasure? TensionForce { get; set; }

	IfcPressureMeasure? PreStress { get; set; }

	IfcNormalisedRatioMeasure? FrictionCoefficient { get; set; }

	IfcPositiveLengthMeasure? AnchorageSlip { get; set; }

	IfcPositiveLengthMeasure? MinCurvatureRadius { get; set; }
}
