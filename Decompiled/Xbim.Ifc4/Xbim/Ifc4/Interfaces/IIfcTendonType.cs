using Xbim.Common;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcTendonType : IIfcReinforcingElementType, IIfcElementComponentType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect
{
	IfcTendonTypeEnum PredefinedType { get; set; }

	IfcPositiveLengthMeasure? NominalDiameter { get; set; }

	IfcAreaMeasure? CrossSectionArea { get; set; }

	IfcPositiveLengthMeasure? SheathDiameter { get; set; }
}
