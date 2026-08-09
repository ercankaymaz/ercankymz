using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdAuditInfo_PrintDest
{
	kSilent = 0,
	kCmdLine = 1,
	kFile = 2,
	kBoth = 3
}
