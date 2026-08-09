using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDb_PathOption
{
	kPathOptionNone = 1,
	kPathOptionRelative = 2,
	kPathOptionAbsolute = 3,
	kPathOptionPathAndFile = 4
}
