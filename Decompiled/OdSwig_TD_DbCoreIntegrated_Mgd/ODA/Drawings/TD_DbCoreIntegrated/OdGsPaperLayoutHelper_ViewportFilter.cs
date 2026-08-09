using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdGsPaperLayoutHelper_ViewportFilter
{
	kVpScreenFilter = 1,
	kVpSizeFilter = 2,
	kVpMaxActFilter = 4
}
