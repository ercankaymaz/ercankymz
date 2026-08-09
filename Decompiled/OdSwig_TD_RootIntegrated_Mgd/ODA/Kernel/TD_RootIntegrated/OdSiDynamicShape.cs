using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public interface OdSiDynamicShape : OdSiShape
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	new HandleRef GetInterfaceCPtr();

	void update(OdGeExtents3d we);
}
