using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdDbVisualSelection_Mode
{
	kPoint = 0,
	kBox = 1,
	kWindow = 2,
	kCrossing = 3,
	kFence = 4,
	kWPoly = 5,
	kCPoly = 6
}
