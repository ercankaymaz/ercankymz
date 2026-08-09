using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdValue_UnitType
{
	kUnitless = 0,
	kDistance = 1,
	kAngle = 2,
	kArea = 4,
	kVolume = 8,
	kCurrency = 0x10,
	kPercentage = 0x20
}
