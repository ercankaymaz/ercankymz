using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public interface OdGiConveyorOutput
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	HandleRef GetInterfaceCPtr();

	void setDestGeometry(OdGiConveyorGeometry destGeometry);

	OdGiConveyorGeometry destGeometry();
}
