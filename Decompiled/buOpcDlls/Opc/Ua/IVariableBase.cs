using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public interface IVariableBase : ILocalNode, INode
{
	object Value { get; set; }

	NodeId DataType { get; set; }

	int ValueRank { get; set; }

	IList<uint> ArrayDimensions { get; set; }
}
