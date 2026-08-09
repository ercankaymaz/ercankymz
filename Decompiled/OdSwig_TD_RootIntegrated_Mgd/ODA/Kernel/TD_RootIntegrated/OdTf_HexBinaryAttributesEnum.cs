using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdTf_HexBinaryAttributesEnum
{
	increaseIn = 1,
	reduceIn = 2,
	limitLen = 4,
	countBytes = 8,
	mul = 0x10,
	value = 0x20,
	cacheValue = 0x40
}
