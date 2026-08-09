using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiPointCloud_Flags
{
	kLastComponentFlag = 0x40,
	kAsyncCall = 0x40,
	kPartialData = 0x80,
	kLastFlag = 0x80
}
