using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdPs_FillStyle
{
	kFsSolid = 0x40,
	kFsCheckerboard = 0x41,
	kFsCrosshatch = 0x42,
	kFsDiamonds = 0x43,
	kFsHorizontalBars = 0x44,
	kFsSlantLeft = 0x45,
	kFsSlantRight = 0x46,
	kFsSquareDots = 0x47,
	kFsVerticalBars = 0x48,
	kFsUseObject = 0x49,
	kFsLast = 0x49
}
