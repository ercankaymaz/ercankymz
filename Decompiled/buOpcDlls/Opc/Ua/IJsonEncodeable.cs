using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public interface IJsonEncodeable
{
	ExpandedNodeId JsonEncodingId { get; }
}
