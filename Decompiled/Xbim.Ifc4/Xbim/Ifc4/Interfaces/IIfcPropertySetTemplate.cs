using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcPropertySetTemplate : IIfcPropertyTemplateDefinition, IIfcPropertyDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType
{
	IfcPropertySetTemplateTypeEnum? TemplateType { get; set; }

	IfcIdentifier? ApplicableEntity { get; set; }

	IItemSet<IIfcPropertyTemplate> HasPropertyTemplates { get; }

	IEnumerable<IIfcRelDefinesByTemplate> Defines { get; }
}
