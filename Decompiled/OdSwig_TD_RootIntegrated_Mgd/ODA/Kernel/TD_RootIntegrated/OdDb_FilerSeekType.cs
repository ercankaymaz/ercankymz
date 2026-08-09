using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdDb_FilerSeekType
{
	kSeekFromStart = 0,
	kSeekFromCurrent = 1,
	kSeekFromEnd = 2
}
