using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiMrTileOrder_
{
	krHilbert = 0,
	krSpiral = 1,
	krLeftToRight = 2,
	krRightToLeft = 3,
	krTopToBottom = 4,
	krBottomToTop = 5
}
