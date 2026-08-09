using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcPropertySetDefinition : IIfcPropertyDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcPropertySetDefinitionSelect, IIfcPropertySetDefinitionSelect
{
	IEnumerable<IIfcTypeObject> DefinesType { get; }

	IEnumerable<IIfcRelDefinesByTemplate> IsDefinedBy { get; }

	IEnumerable<IIfcRelDefinesByProperties> DefinesOccurrence { get; }
}
