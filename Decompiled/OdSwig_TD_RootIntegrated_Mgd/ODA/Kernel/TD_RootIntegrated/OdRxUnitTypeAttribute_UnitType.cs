using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdRxUnitTypeAttribute_UnitType
{
	kUnitless = 0,
	kDistance = 1,
	kAngle = 2,
	kArea = 4,
	kVolume = 8,
	kCurrency = 0x10,
	kPercentage = 0x20,
	kAngleNotTransformed = 0x10000
}
