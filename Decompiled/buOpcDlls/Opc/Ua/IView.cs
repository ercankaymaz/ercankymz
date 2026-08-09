using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public interface IView : ILocalNode, INode
{
	byte EventNotifier { get; set; }

	bool ContainsNoLoops { get; set; }
}
