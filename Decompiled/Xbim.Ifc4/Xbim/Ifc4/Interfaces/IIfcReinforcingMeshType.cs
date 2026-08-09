using Xbim.Common;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcReinforcingMeshType : IIfcReinforcingElementType, IIfcElementComponentType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect
{
	IfcReinforcingMeshTypeEnum PredefinedType { get; set; }

	IfcPositiveLengthMeasure? MeshLength { get; set; }

	IfcPositiveLengthMeasure? MeshWidth { get; set; }

	IfcPositiveLengthMeasure? LongitudinalBarNominalDiameter { get; set; }

	IfcPositiveLengthMeasure? TransverseBarNominalDiameter { get; set; }

	IfcAreaMeasure? LongitudinalBarCrossSectionArea { get; set; }

	IfcAreaMeasure? TransverseBarCrossSectionArea { get; set; }

	IfcPositiveLengthMeasure? LongitudinalBarSpacing { get; set; }

	IfcPositiveLengthMeasure? TransverseBarSpacing { get; set; }

	IfcLabel? BendingShapeCode { get; set; }

	IItemSet<IIfcBendingParameterSelect> BendingParameters { get; }
}
