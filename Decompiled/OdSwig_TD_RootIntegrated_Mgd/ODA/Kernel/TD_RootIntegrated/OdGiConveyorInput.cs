using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public interface OdGiConveyorInput
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	HandleRef GetInterfaceCPtr();

	void addSourceNode(OdGiConveyorOutput sourceNode);

	void removeSourceNode(OdGiConveyorOutput sourceNode);
}
