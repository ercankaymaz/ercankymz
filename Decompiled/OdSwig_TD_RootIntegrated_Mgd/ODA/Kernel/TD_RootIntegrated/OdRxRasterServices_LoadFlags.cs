using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdRxRasterServices_LoadFlags
{
	kLoadFmt = 0x20544D46,
	kNoTIFFRotation = 0x5246544E
}
