using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdDb_DragStat
{
	kDragStart = 0,
	kDragEnd = 1,
	kDragAbort = 2
}
