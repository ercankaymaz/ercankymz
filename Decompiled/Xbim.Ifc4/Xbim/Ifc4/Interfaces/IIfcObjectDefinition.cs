using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcObjectDefinition : IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType
{
	IEnumerable<IIfcRelAssigns> HasAssignments { get; }

	IEnumerable<IIfcRelNests> Nests { get; }

	IEnumerable<IIfcRelNests> IsNestedBy { get; }

	IEnumerable<IIfcRelDeclares> HasContext { get; }

	IEnumerable<IIfcRelAggregates> IsDecomposedBy { get; }

	IEnumerable<IIfcRelAggregates> Decomposes { get; }

	IEnumerable<IIfcRelAssociates> HasAssociations { get; }

	IIfcValue this[string property] { get; }

	IIfcMaterialSelect Material { get; }
}
