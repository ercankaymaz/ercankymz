using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdUnitsFormatter_LUnits
{
	kScientific = 1,
	kDecimal = 2,
	kEngineering = 3,
	kArchitectural = 4,
	kFractional = 5,
	kWindowsDesktop = 6
}
