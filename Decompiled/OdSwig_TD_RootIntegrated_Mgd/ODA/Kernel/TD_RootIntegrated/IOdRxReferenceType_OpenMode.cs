using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum IOdRxReferenceType_OpenMode
{
	kForRead = 0,
	kForWrite = 1,
	kForNotify = 2
}
