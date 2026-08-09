using Xbim.Common;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcReinforcingBarType : IIfcReinforcingElementType, IIfcElementComponentType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect
{
	IfcReinforcingBarTypeEnum PredefinedType { get; set; }

	IfcPositiveLengthMeasure? NominalDiameter { get; set; }

	IfcAreaMeasure? CrossSectionArea { get; set; }

	IfcPositiveLengthMeasure? BarLength { get; set; }

	IfcReinforcingBarSurfaceEnum? BarSurface { get; set; }

	IfcLabel? BendingShapeCode { get; set; }

	IItemSet<IIfcBendingParameterSelect> BendingParameters { get; }
}
