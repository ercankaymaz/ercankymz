using Xbim.Common;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcComplexPropertyTemplate : IIfcPropertyTemplate, IIfcPropertyTemplateDefinition, IIfcPropertyDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType
{
	IfcLabel? UsageName { get; set; }

	IfcComplexPropertyTemplateTypeEnum? TemplateType { get; set; }

	IItemSet<IIfcPropertyTemplate> HasPropertyTemplates { get; }
}
