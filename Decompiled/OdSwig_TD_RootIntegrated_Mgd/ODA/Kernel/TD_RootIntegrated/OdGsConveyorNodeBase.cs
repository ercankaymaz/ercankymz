using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public interface OdGsConveyorNodeBase : OdGiConveyorInput, OdGiConveyorOutput
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	new HandleRef GetInterfaceCPtr();

	new void addSourceNode(OdGiConveyorOutput sourceNode);

	new void removeSourceNode(OdGiConveyorOutput sourceNode);

	new void setDestGeometry(OdGiConveyorGeometry destGeometry);

	new OdGiConveyorGeometry destGeometry();

	void updateLink();

	void updateLink(OdGiConveyorGeometry pGeometry);

	OdGiConveyorGeometry optionalGeometry();
}
