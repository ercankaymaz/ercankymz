using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.StructuralAnalysisDomain;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcElement : IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect
{
	IfcIdentifier? Tag { get; set; }

	IEnumerable<IIfcRelFillsElement> FillsVoids { get; }

	IEnumerable<IIfcRelConnectsElements> ConnectedTo { get; }

	IEnumerable<IIfcRelInterferesElements> IsInterferedByElements { get; }

	IEnumerable<IIfcRelInterferesElements> InterferesElements { get; }

	IEnumerable<IIfcRelProjectsElement> HasProjections { get; }

	IEnumerable<IIfcRelReferencedInSpatialStructure> ReferencedInStructures { get; }

	IEnumerable<IIfcRelVoidsElement> HasOpenings { get; }

	IEnumerable<IIfcRelConnectsWithRealizingElements> IsConnectionRealization { get; }

	IEnumerable<IIfcRelSpaceBoundary> ProvidesBoundaries { get; }

	IEnumerable<IIfcRelConnectsElements> ConnectedFrom { get; }

	IEnumerable<IIfcRelContainedInSpatialStructure> ContainedInStructure { get; }

	IEnumerable<IIfcRelCoversBldgElements> HasCoverings { get; }
}
