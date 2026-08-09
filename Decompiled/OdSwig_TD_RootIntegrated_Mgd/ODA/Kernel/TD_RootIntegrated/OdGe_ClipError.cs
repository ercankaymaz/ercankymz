using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGe_ClipError
{
	eOk = 0,
	eInvalidClipBoundary = 1,
	eNotInitialized = 2
}
