using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGsView_SelectionMode
{
	kWindow = 0,
	kCrossing = 1,
	kFence = 2,
	kWPoly = 3,
	kCPoly = 4,
	kPoint = 0x10,
	kPointLast = 0x11
}
