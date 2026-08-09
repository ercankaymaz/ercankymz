using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDb_FilletTrimMode
{
	kTrimNone = 0,
	kTrimFirst = 1,
	kTrimSecond = 2,
	kTrimBoth = 3
}
