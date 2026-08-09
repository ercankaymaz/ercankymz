using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public interface IFilterTarget
{
	bool IsTypeOf(FilterContext context, NodeId typeDefinitionId);

	object GetAttributeValue(FilterContext context, NodeId typeDefinitionId, IList<QualifiedName> relativePath, uint attributeId, NumericRange indexRange);
}
