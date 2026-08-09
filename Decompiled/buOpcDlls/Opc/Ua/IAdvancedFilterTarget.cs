using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public interface IAdvancedFilterTarget : IFilterTarget
{
	bool IsInView(FilterContext context, NodeId viewId);

	bool IsRelatedTo(FilterContext context, NodeId intermediateNodeId, NodeId sourceTypeId, NodeId targetTypeId, NodeId referenceTypeId, int hops, bool includeTypeDefintionSubtypes, bool includeReferenceSubtypes);

	IList<NodeId> GetRelatedNodes(FilterContext context, NodeId intermediateNodeId, NodeId sourceTypeId, NodeId targetTypeId, NodeId referenceTypeId, int hops, bool includeTypeDefintionSubtypes, bool includeReferenceSubtypes);

	object GetRelatedAttributeValue(FilterContext context, NodeId typeDefinitionId, RelativePath relativePath, uint attributeId, NumericRange indexRange);
}
