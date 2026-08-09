using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdDbGripOperations_GripStatus
{
	kGripStart = 0,
	kGripEnd = 1,
	kGripAbort = 2,
	kStretch = 3,
	kMove = 4,
	kRotate = 5,
	kScale = 6,
	kMirror = 7,
	kDimFocusChanged = 8,
	kPopUpMenu = 9
}
