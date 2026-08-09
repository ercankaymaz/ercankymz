using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdTf_TagsEnum
{
	Element = 1,
	Condition = 2,
	Array = 4,
	version = 8,
	EndClass = 0x10,
	Mark = 0x20,
	EndTagMask = 0x40
}
