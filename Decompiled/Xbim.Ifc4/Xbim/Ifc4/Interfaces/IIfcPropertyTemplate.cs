using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcPropertyTemplate : IIfcPropertyTemplateDefinition, IIfcPropertyDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType
{
	IEnumerable<IIfcComplexPropertyTemplate> PartOfComplexTemplate { get; }

	IEnumerable<IIfcPropertySetTemplate> PartOfPsetTemplate { get; }
}
