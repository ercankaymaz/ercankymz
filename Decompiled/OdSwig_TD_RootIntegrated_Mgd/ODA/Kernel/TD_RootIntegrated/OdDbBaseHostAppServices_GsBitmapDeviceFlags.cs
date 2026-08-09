using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdDbBaseHostAppServices_GsBitmapDeviceFlags
{
	kUseSoftwareHLR = 1,
	kFor2dExportRender = 2,
	kFor2dExportRenderHLR = 4,
	kForThumbnail = 8
}
