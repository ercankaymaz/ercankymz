using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiDgLinetypeDash_DashInfo_StrokeCapsType
{
	kLsCapsClosed = 0,
	kLsCapsOpen = 1,
	kLsCapsExtended = 2,
	kLsCapsHexagon = 3,
	kLsCapsOctagon = 4,
	kLsCapsDecagon = 5,
	kLsCapsArc = 0x1E
}
