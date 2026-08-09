using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDb_OpenMode
{
	kNotOpen = -1,
	kForRead = 0,
	kForWrite = 1,
	kForNotify = 2
}
