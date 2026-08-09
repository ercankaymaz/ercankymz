using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdTf_ElementAttributesEnum
{
	isCacheValue = 1,
	isBreak = 2,
	isTableName = 4,
	isContextData = 8,
	isTableQueue = 0x10,
	isTableCache = 0x20,
	TableQueue = 0x40,
	isSum = 0x80
}
