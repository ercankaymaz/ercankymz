using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdDbGripOperations_MoveGripPointsFlags
{
	kOsnapped = 1,
	kPolar = 2,
	kOtrack = 4,
	kZdir = 8,
	kKeyboard = 0x10
}
