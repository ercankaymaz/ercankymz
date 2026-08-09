using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public interface OdGiDeviation
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	HandleRef GetInterfaceCPtr();

	double deviation(OdGiDeviationType deviationType, OdGePoint3d pointOnCurve);
}
