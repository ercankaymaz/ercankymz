using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGe_NurbSurfaceProperties
{
	kUninit = 0,
	kOpen = 1,
	kClosed = 2,
	kPeriodic = 4,
	kRational = 8,
	kNoPoles = 0x10,
	kPoleAtMin = 0x20,
	kPoleAtMax = 0x40,
	kPoleAtBoth = 0x80
}
