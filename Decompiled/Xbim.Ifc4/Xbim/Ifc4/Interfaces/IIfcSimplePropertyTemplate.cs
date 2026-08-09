using Xbim.Common;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcSimplePropertyTemplate : IIfcPropertyTemplate, IIfcPropertyTemplateDefinition, IIfcPropertyDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType
{
	IfcSimplePropertyTemplateTypeEnum? TemplateType { get; set; }

	IfcLabel? PrimaryMeasureType { get; set; }

	IfcLabel? SecondaryMeasureType { get; set; }

	IIfcPropertyEnumeration Enumerators { get; set; }

	IIfcUnit PrimaryUnit { get; set; }

	IIfcUnit SecondaryUnit { get; set; }

	IfcLabel? Expression { get; set; }

	IfcStateEnum? AccessState { get; set; }
}
