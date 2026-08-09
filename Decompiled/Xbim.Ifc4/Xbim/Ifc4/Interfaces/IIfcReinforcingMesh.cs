using Xbim.Common;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.StructuralAnalysisDomain;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcReinforcingMesh : IIfcReinforcingElement, IIfcElementComponent, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect
{
	IfcPositiveLengthMeasure? MeshLength { get; set; }

	IfcPositiveLengthMeasure? MeshWidth { get; set; }

	IfcPositiveLengthMeasure? LongitudinalBarNominalDiameter { get; set; }

	IfcPositiveLengthMeasure? TransverseBarNominalDiameter { get; set; }

	IfcAreaMeasure? LongitudinalBarCrossSectionArea { get; set; }

	IfcAreaMeasure? TransverseBarCrossSectionArea { get; set; }

	IfcPositiveLengthMeasure? LongitudinalBarSpacing { get; set; }

	IfcPositiveLengthMeasure? TransverseBarSpacing { get; set; }

	IfcReinforcingMeshTypeEnum? PredefinedType { get; set; }
}
