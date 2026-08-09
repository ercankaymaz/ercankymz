using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiRasterImage_Units
{
	kNone = 0,
	kMillimeter = 1,
	kCentimeter = 2,
	kMeter = 3,
	kKilometer = 4,
	kInch = 5,
	kFoot = 6,
	kYard = 7,
	kMile = 8,
	kMicroinches = 9,
	kMils = 0xA,
	kAngstroms = 0xB,
	kNanometers = 0xC,
	kMicrons = 0xD,
	kDecimeters = 0xE,
	kDekameters = 0xF,
	kHectometers = 0x10,
	kGigameters = 0x11,
	kAstronomical = 0x12,
	kLightYears = 0x13,
	kParsecs = 0x14
}
