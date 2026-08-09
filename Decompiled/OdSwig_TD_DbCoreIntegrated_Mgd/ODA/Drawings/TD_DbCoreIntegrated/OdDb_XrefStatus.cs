using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDb_XrefStatus
{
	kXrfNotAnXref = 0,
	kXrfResolved = 1,
	kXrfUnloaded = 2,
	kXrfUnreferenced = 3,
	kXrfFileNotFound = 4,
	kXrfUnresolved = 5
}
