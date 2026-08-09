using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbMultiModesGripPE_GripCursorType
{
	kcNone = 0,
	kcCrosshairPlus = 1,
	kcCrosshairMinus = 2,
	kcCrosshairCurve = 3,
	kcCrosshairLine = 4,
	kcCrosshairAngle = 5
}
