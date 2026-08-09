using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdSDIValues
{
	kMDIEnabled = 0,
	kSDIUserEnforced = 1,
	kSDIAppEnforced = 2,
	kSDIUserAndAppEnforced = 3
}
