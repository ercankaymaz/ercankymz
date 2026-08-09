using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdRx_MTSupport
{
	kMTRender = 1,
	kMTRenderInBlock = 2,
	kMTRenderNested = 4,
	kMTRenderReserved = 8,
	kMTRenderMask = 0xF,
	kMTLoading = 0x80,
	kHistoryAware = 0x100
}
