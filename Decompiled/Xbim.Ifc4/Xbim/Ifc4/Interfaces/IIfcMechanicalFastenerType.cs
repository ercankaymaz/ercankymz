using Xbim.Common;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcMechanicalFastenerType : IIfcElementComponentType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect
{
	IfcMechanicalFastenerTypeEnum PredefinedType { get; set; }

	IfcPositiveLengthMeasure? NominalDiameter { get; set; }

	IfcPositiveLengthMeasure? NominalLength { get; set; }
}
