using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbLight_LampColorPreset
{
	kD65White = 0,
	kFluorescent = 1,
	kCoolWhite = 2,
	kWhiteFluorescent = 3,
	kDaylightFluorescent = 4,
	kIncandescent = 5,
	kXenon = 6,
	kHalogen = 7,
	kQuartz = 8,
	kMetalHalide = 9,
	kMercury = 0xA,
	kPhosphorMercury = 0xB,
	kHighPressureSodium = 0xC,
	kLowPressureSodium = 0xD,
	kCustom = 0xE
}
