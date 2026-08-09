using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGsBaseDeviceMTHelpers_SyncType
{
	kSyncDeviceAccess = 0,
	kSyncDeviceResource = 1,
	kSyncRasterCache = 2,
	kSyncTextureCache = 3,
	kSyncCount = 4
}
