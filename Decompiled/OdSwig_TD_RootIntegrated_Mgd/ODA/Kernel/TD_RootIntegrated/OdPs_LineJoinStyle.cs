using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdPs_LineJoinStyle
{
	kLjsMiter = 0,
	kLjsBevel = 1,
	kLjsRound = 2,
	kLjsDiamond = 3,
	kLjsUseObject = 5
}
