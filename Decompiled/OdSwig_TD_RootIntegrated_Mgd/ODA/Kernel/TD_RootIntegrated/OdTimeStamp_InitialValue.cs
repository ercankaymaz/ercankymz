using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdTimeStamp_InitialValue
{
	kInitZero = 1,
	kInitLocalTime = 2,
	kInitUniversalTime = 3
}
