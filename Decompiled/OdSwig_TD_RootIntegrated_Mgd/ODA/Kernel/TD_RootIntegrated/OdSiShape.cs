using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public interface OdSiShape
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	HandleRef GetInterfaceCPtr();

	bool contains(OdGeExtents3d extents, bool planar, OdGeTol tol);

	bool intersects(OdGeExtents3d extents, bool planar, OdGeTol tol);

	OdSiShape clone();

	void transform(OdGeMatrix3d arg0);
}
