using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdXrefSubCommand
{
	kXrefAttach = 0,
	kXrefBind = 1,
	kXrefDetach = 2,
	kXrefOverlay = 3,
	kXrefPath = 4,
	kXrefReload = 5,
	kXrefResolve = 6,
	kXrefUnload = 7,
	kXrefXBind = 8
}
