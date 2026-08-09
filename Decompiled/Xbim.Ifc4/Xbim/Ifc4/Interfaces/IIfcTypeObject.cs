using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcTypeObject : IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType
{
	IfcIdentifier? ApplicableOccurrence { get; set; }

	IItemSet<IIfcPropertySetDefinition> HasPropertySets { get; }

	IEnumerable<IIfcRelDefinesByType> Types { get; }

	IEnumerable<IIfcRelDefinesByProperties> DefinedByProperties { get; }
}
